Imports System.IO
Imports Core.ConstantCore
Imports Core.Session
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Services
Imports Services.Services
Imports Unity
Imports Web.Models

Namespace Controllers
    Public Class BaseController
        Inherits Controller
        <Dependency>
        Public Property _baseService As IBaseService
        <Dependency>
        Public Property _commonService As ICMN9000Service

        Public Property _layoutBaseModel As LayoutBaseViewModel = New LayoutBaseViewModel()

        ''' <summary>
        ''' 文字エンコーディング
        ''' </summary>
        Protected Shared ReadOnly SJIS_ENC As Encoding = Encoding.GetEncoding("shift-jis")

        Public Sub New()
            SetLayoutModel()
        End Sub

        Private Sub SetLayoutModel()
            Me.ViewBag.Title = "印刷テンプレート"
            Me.ViewData("LayoutBaseModel") = Me._layoutBaseModel
        End Sub

        Public Sub SetMessage()
            Dim message = TempData("Message")
            If message IsNot Nothing Then
                Me.ViewData("LayoutBaseModel") = CType(message, LayoutBaseViewModel)
            End If
        End Sub

        Protected Sub SetInforReponseFile(nameFile As String, content As StringBuilder)
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=" + nameFile)
            Response.AddHeader("Set-Cookie", "fileDownload=true; path=/")
            Response.Charset = ""
            Response.ContentEncoding = SJIS_ENC
            Response.Output.Write(content.ToString())
            Response.Flush()
            Response.End()
        End Sub

        <NonAction>
        Protected Function RenderViewToString(ByVal context As ControllerContext, ByVal viewName As String, ByVal model As Object, ByVal viewData As Object) As String
            If String.IsNullOrEmpty(viewName) Then viewName = context.RouteData.GetRequiredString("action")
            Dim data = New ViewDataDictionary(model)
            If viewData IsNot Nothing Then
                Dim viewDataType = viewData.GetType()
                Dim propertyViewDatas = viewDataType.GetProperties()
                For Each propertyViewData In propertyViewDatas
                    data.Add(propertyViewData.Name, viewDataType.GetProperty(propertyViewData.Name).GetValue(viewData))
                Next
            End If

            Dim sw = New StringWriter()
            Dim viewResult = ViewEngines.Engines.FindPartialView(context, viewName)
            Dim viewContext = New ViewContext(context, viewResult.View, data, New TempDataDictionary(), sw)
            viewResult.View.Render(viewContext, sw)
            Return sw.GetStringBuilder().ToString()
        End Function

        Protected Sub SetMessageModalstate(modelstate As ModelStateDictionary)
            For Each key As String In modelstate.Keys
                If modelstate(key).Errors.Count > 0 Then
                    _layoutBaseModel.Message = modelstate(key).Errors.FirstOrDefault().ErrorMessage
                    _layoutBaseModel.Focus = key
                    _layoutBaseModel.IsMessage = True
                    Exit For
                End If
            Next
        End Sub

        Protected Function SetMessageForAjax(modelState As ModelStateDictionary) As AjaxResultDto
            Dim ajaxResult = New AjaxResultDto()
            For Each key As String In modelState.Keys
                If modelState(key).Errors.Count > 0 Then
                    ajaxResult.Message = modelState(key).Errors.FirstOrDefault().ErrorMessage
                    ajaxResult.Focus = key
                    ajaxResult.Status = 400
                    Exit For
                End If
            Next
            Return ajaxResult
        End Function


        ''' <summary>
        ''' Set Response
        ''' </summary>
        ''' <param name="message">message Error</param>
        Protected Sub SetResponse(message As String)
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "text/html"
            Response.Charset = "utf-8"
            Response.Output.Write(message)
            Response.Flush()
            Response.End()
        End Sub

        ''' <summary>
        ''' Export pdf (Crystal report)
        ''' </summary>
        ''' <param name="exportOptions">Options</param>
        ''' <returns></returns>
        Protected Function ExportPdf(exportOptions As Object) As FileStreamResult
            Dim rd As ReportDocument = New ReportDocument()
            Dim margins As PageMargins
            Dim rptPath = Path.Combine(Server.MapPath("~/Report/"), exportOptions.RptName)
            'load
            rd.Load(rptPath)
            rd.SetDataSource(exportOptions.Data)
            'set print option
            margins = rd.PrintOptions.PageMargins
            rd.PrintOptions.PaperSize = exportOptions.PaperSize
            rd.PrintOptions.PaperOrientation = exportOptions.PaperOrn
            rd.PrintOptions.ApplyPageMargins(margins)

            Dim fname As String = exportOptions.FileId & ".pdf"
            Dim destinationOptions = New DiskFileDestinationOptions
            destinationOptions.DiskFileName = fname
            Dim expOption = rd.ExportOptions

            With expOption
                .DestinationOptions = destinationOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
            End With

            Dim stream As Stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
            stream.Seek(0, SeekOrigin.Begin)

            'save file to server TODO (if needed)
            Dim fs As FileStream = System.IO.File.Create(ConfigurationManager.AppSettings("Pdf_Path") + fname)
            stream.CopyTo(fs)
            fs.Close()

            'return stream
            stream.Seek(0, SeekOrigin.Begin)
            Return File(stream, "application/pdf", fname)
        End Function

        ''' <summary>
        ''' Export pdf (Crystal report)
        ''' </summary>
        ''' <param name="exportOptions">Options</param>
        ''' <returns></returns>
        Protected Function ExportPdfSaveFile(exportOptions As Object)
            Dim rd As ReportDocument = New ReportDocument()
            Dim margins As PageMargins
            Dim rptPath = Path.Combine(Server.MapPath("~/Report/"), exportOptions.RptName)
            'load
            rd.Load(rptPath)
            rd.SetDataSource(exportOptions.Data)
            'set print option
            margins = rd.PrintOptions.PageMargins
            rd.PrintOptions.PaperSize = exportOptions.PaperSize
            rd.PrintOptions.PaperOrientation = exportOptions.PaperOrn
            rd.PrintOptions.ApplyPageMargins(margins)

            Dim configPath As String = ConfigurationManager.AppSettings("Pdf_Path")
            Dim pdfPath As String = Server.MapPath("~/" + configPath)
            'check folder exist
            Dim info As New DirectoryInfo(pdfPath)
            If Not info.Exists Then
                info.Create()
            End If

            Dim fname As String = pdfPath & exportOptions.FileId & ".pdf"

            Dim crExportOptions As ExportOptions
            Dim destinationOptions As DiskFileDestinationOptions = New DiskFileDestinationOptions
            destinationOptions.DiskFileName = fname
            crExportOptions = rd.ExportOptions

            With crExportOptions
                .DestinationOptions = destinationOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
            End With

            rd.Export()

            Dim LPath As String = ConfigurationManager.AppSettings("AppRoot") & configPath & exportOptions.FileId & ".pdf"
            Return LPath

        End Function

        ''' <summary>
        ''' Export pdf file in response header (Crystal report)
        ''' </summary>
        ''' <param name="exportOptions">Options - should be ExportPDFModel</param>
        Protected Sub ExportPdfAndSetInfoResponseFile(exportOptions As Object)
            Dim rd As New ReportDocument()
            Dim margins As PageMargins
            Dim rptPath = Path.Combine(Server.MapPath("~/Report/"), exportOptions.RptName)
            'load
            rd.Load(rptPath)
            rd.SetDataSource(exportOptions.Data)
            'set print option
            margins = rd.PrintOptions.PageMargins
            rd.PrintOptions.PaperSize = exportOptions.PaperSize
            rd.PrintOptions.PaperOrientation = exportOptions.PaperOrn
            rd.PrintOptions.ApplyPageMargins(margins)

            Dim fname As String = exportOptions.FileId & ".pdf"
            Dim destinationOptions = New DiskFileDestinationOptions
            destinationOptions.DiskFileName = fname
            Dim expOption = rd.ExportOptions

            With expOption
                .DestinationOptions = destinationOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
            End With

            Dim stream As Stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
            stream.Seek(0, SeekOrigin.Begin)
            'Set file into response content
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=" + fname)
            Response.AddHeader("Set-Cookie", "fileDownload=true; path=/")
            Response.Charset = ""
            Response.ContentEncoding = SJIS_ENC
            Dim memoryStream As New MemoryStream
            stream.CopyTo(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)
            memoryStream.WriteTo(Response.OutputStream)
            Response.Flush()
            Response.End()
        End Sub

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function DownloadS(model As DownloadViewModel) As ActionResult
            Dim loginSession = CType(Session(SessionKey.LOGIN_INFO), LoginInfo)
            Dim userInfo = loginSession.UserInfo
            Dim fPath As String = ConfigurationManager.AppSettings("Pdf_Path") + model.fileName
            'read file
            Dim stream As Stream = New StreamReader(fPath).BaseStream
            'return stream
            Return File(stream, "application/pdf", model.fileName)
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function GetNameByCode(param As CodeNameParamInfo) As ActionResult
            Dim loginSession = CType(Session(SessionKey.LOGIN_INFO), LoginInfo)
            If loginSession Is Nothing Then
                Return Nothing
            End If
            Dim name = _commonService.GetNameByCode(param.Key, param.Code, param.Type)
            Return Json(New With {.name = name})
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function GetPaymentDateByCode2(code As String, targetDate As Date?, typeGet As String) As ActionResult
            Dim loginSession = CType(Session(SessionKey.LOGIN_INFO), LoginInfo)
            If loginSession Is Nothing Then
                Return Nothing
            End If
            Dim paymentDate = _commonService.GetPaymentDateByCode2(code, targetDate, typeGet)
            Return Json(New With {.paymentDate = If(paymentDate Is Nothing, paymentDate, String.Format(paymentDate, DateFormat.YYYYMMDD))})
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function GetTaxRateByDate(targetDate As Date?) As ActionResult
            Dim loginSession = CType(Session(SessionKey.LOGIN_INFO), LoginInfo)
            If loginSession Is Nothing Then
                Return Nothing
            End If
            Dim tax = _commonService.GetTaxRateByDate(targetDate)
            Return Json(New With {.tax = tax})
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function GetTaskIndentifer(task As String) As ActionResult
            Dim loginSession = CType(Session(SessionKey.LOGIN_INFO), LoginInfo)
            If loginSession Is Nothing Then
                Return Nothing
            End If
            Dim identify = _commonService.GetTaskIndentifer(task)
            Return Json(New With {.identify = identify})
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function CalcMultiplication(param As CalcMultiplicationModel) As ActionResult
            Dim loginSession = CType(Session(SessionKey.LOGIN_INFO), LoginInfo)
            If loginSession Is Nothing Then
                Return Nothing
            End If
            Dim value = _commonService.CalcMultiplication(param.Number1, param.Number2, param.FractionType, param.DecimalPoint, param.MaxDigits)
            Return Json(New With {.value = value})
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function GetCustomerByCode(param As CustomParamInfo) As ActionResult
            Dim loginSession = CType(Session(SessionKey.LOGIN_INFO), LoginInfo)
            If loginSession Is Nothing Then
                Return Nothing
            End If
            Dim name = _commonService.GetCustomerByCode(param.Code, param.CustomerType, TypeGetName.FULLNAME)
            Return Json(New With {.name = name})
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function GetOrderItemByKey(orderNo As String) As ActionResult
            Dim loginSession = CType(Session(SessionKey.LOGIN_INFO), LoginInfo)
            If loginSession Is Nothing Then
                Return Nothing
            End If
            Dim name = _commonService.GetOrderItemByKey(orderNo)
            Return Json(New With {.name = name})
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function GetEmployeeByCode(code As String) As ActionResult
            Dim loginSession = CType(Session(SessionKey.LOGIN_INFO), LoginInfo)
            If loginSession Is Nothing Then
                Return Nothing
            End If
            Dim name = _commonService.GetEmployeeByCode(code)
            Return Json(New With {.name = name})
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function GetPaperByCode(code As String) As ActionResult
            Dim loginSession = CType(Session(SessionKey.LOGIN_INFO), LoginInfo)
            If loginSession Is Nothing Then
                Return Nothing
            End If
            Dim name = _commonService.GetPaperByCode(code)
            Return Json(New With {.name = name})
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function GetDepartmentIC(code As String) As ActionResult
            Dim loginSession = CType(Session(SessionKey.LOGIN_INFO), LoginInfo)
            If loginSession Is Nothing Then
                Return Nothing
            End If
            Dim picName = _commonService.GetEmployeeByCode(code)
            Dim department = _commonService.GetDepatureByCode(code, TypeGetName.SHORT_NAME)
            Dim deptCode = String.Empty
            Dim deptName = String.Empty
            If Not String.IsNullOrEmpty(department) Then
                Dim deptList = Split(department, ",").ToList()
                deptCode = deptList(0)
                deptName = deptList(1)
            End If
            Return Json(New With {.picName = picName, .deptCode = deptCode, .deptName = deptName})
        End Function

        Protected Sub SetAjaxResultDto(ByRef ajaxResultDto As AjaxResultDto,
                                        Optional status As String = "",
                                        Optional message As String = "",
                                        Optional dataString As String = "",
                                        Optional dataAdd As Dictionary(Of String, Object) = Nothing,
                                   Optional focus As String = "")
            If (Not String.IsNullOrEmpty(status)) Then
                ajaxResultDto.Status = status
            End If
            If (Not String.IsNullOrEmpty(message)) Then
                ajaxResultDto.Message = message
            End If
            If (Not String.IsNullOrEmpty(dataString)) Then
                ajaxResultDto.DataString = dataString
            End If
            If (Not String.IsNullOrEmpty(focus)) Then
                ajaxResultDto.Focus = focus
            End If

            If (dataAdd IsNot Nothing AndAlso dataAdd.Count > 0) Then
                For i = 0 To dataAdd.Keys.Count - 1
                    Dim key = dataAdd.Keys.ElementAt(i)
                    ajaxResultDto.Data.Add(key, dataAdd.Item(key))
                Next
            End If
        End Sub

        Protected Sub WriteLog(区分 As String, 画面名 As String)
            Dim loginSession = CType(Session(SessionKey.LOGIN_INFO), LoginInfo)
            'log
            Dim log As New LogDto()
            log.区分 = 区分
            log.担当 = loginSession.UserInfo.UserId
            log.画面名 = 画面名
            log.接続元IP = Request.UserHostAddress
            _baseService.InsertLog(log)
        End Sub

        Protected Sub WriteErrorLog(obj As ErrorLogDto)
            _baseService.InsertErrorLog(obj)
        End Sub
    End Class
End Namespace