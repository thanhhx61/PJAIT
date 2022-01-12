Imports Core.ConstantCore.Consts
Imports Core.My.Resources
Imports Core.Session
Imports Core.Util
Imports Dao
Imports Services.Services
Imports Web.Models

Namespace Controllers
    ''' <summary>
    ''' 受注検索
    ''' </summary>
    Public Class TPL01040Controller
        Inherits BaseController

        Private ReadOnly _service As ITPL01040Service


#Region "CONSTANT"
        Private Const PAGESIZE = 10
        Private Const VIEW_INDEX = "Index"
        Private Const VIEW_TABLE = "_TableTPL01040"
        Private Const TPL01010VM = "TPL01010ViewModel"
        Private Const TPL02010VM = "TPL02010ViewModel"
        Private Const TPL02030VM = "TPL02030ViewModel"
        Private Const TPL04010VM = "TPL04010ViewModel"
        Private Const TPL05030VM = "TPL05030ViewModel"
        Private Const TYPE_ERROR = "TypeError"

#End Region
        Public Sub New(service As ITPL01040Service)
            _service = service
        End Sub

        ''' <summary>
        ''' Form_Load時仕様
        ''' </summary>
        ''' <returns>Page Index</returns>
        <HttpGet>
        Function Index() As ActionResult
            Dim viewModel As New TPL01040ViewModel
            '4.1.以下にコンボボックスの取得方法を記載する。
            Dim dataComboBoxProductType = _service.GetDataComboBoxById(COMMON_NO.PRODUCT_TYPE, True)
            ViewBag.cbbProductType = dataComboBoxProductType

            '6.1受注日の初期値を設定する。
            Dim listDateStartEnd = DateUtil.GetSysDateStartEnd()
            viewModel.StartDate = listDateStartEnd(0)
            viewModel.EndDate = listDateStartEnd(1)

            Return View(VIEW_INDEX, viewModel)
        End Function

        ''' <summary>
        ''' 検索ボタンクリック時
        ''' </summary>
        ''' <param name="viewModel">TPL01040ViewModel</param>
        ''' <returns>Table search result</returns>
        <ValidateAntiForgeryToken>
        <HttpPost>
        Function Search(viewModel As TPL01040ViewModel) As ActionResult
            Dim ajaxResultDto = New AjaxResultDto With {
                .Status = StatusInf.SUCCESS
                }
            '7.1.入力チェックを行う。
            Dim validInput = _service.ValidateSearchCondition(viewModel.StartDate, viewModel.EndDate)
            If (Not validInput.IsSuccess) Then
                SetAjaxResultDto(ajaxResultDto, StatusInf.FAILED, validInput.MessageInfo.Message, String.Empty,
                                 New Dictionary(Of String, Object) From {{TYPE_ERROR, validInput.ErrorType}}, validInput.MessageInfo.Focus)
                Return Json(ajaxResultDto)
            End If

            Dim paramSearch = GetParamSearch(viewModel)
            Dim param As New PaginationRequestDto(Of SearchOrderParamDto) With {.Param = paramSearch, .PageCurrent = viewModel.PageCurrent, .PageSize = PAGESIZE}
            Dim result As PanigationResultDto(Of SearchOrderResultDto) = _service.SearchOrderPagedList(param)
            '7.2.1.以下の条件に合致する場合、エラーとして処理を終了する。
            If Not result.List.Any() Then
                SetAjaxResultDto(ajaxResultDto, StatusInf.FAILED, ValidationResource.MSG_198)
                Return Json(ajaxResultDto)
            End If
            '6.2. ボタン制御情報を取得する。
            Dim btnCtrlArr = _service.GetBtnControlArray()
            Dim viewData As New With {
                .searchResult = result.List,
                .checkSearch = True,
                .paramSearch = paramSearch,
                .total = result.Total,
                .pageSize = PAGESIZE,
                .pageCurrent = viewModel.PageCurrent,
                .btnCtrlArr = btnCtrlArr
            }

            Dim stringResult = RenderViewToString(Me.ControllerContext, VIEW_TABLE, viewModel, viewData)
            SetAjaxResultDto(ajaxResultDto, StatusInf.SUCCESS, Nothing, stringResult)

            Return Json(ajaxResultDto)
        End Function

        ''' <summary>
        ''' Export To CSVボタンクリック時
        ''' </summary>
        ''' <param name="viewModel">TPL01040ViewModel</param>
        ''' <returns>CSV file</returns>
        <ValidateAntiForgeryToken>
        <HttpPost>
        Function ExportCSV(viewModel As TPL01040ViewModel) As ActionResult
            'Get loginInfo to creater log
            Dim loginSession = CType(Session(SessionKey.LOGIN_INFO), LoginInfo)
            Dim ajaxResultDto = New AjaxResultDto With {
                .Status = StatusInf.SUCCESS
                }

            'log
            Me.WriteLog(LogType.EXPORT_CSV, "TPL01040/ExportCSV")

            '8.1.入力チェックを行う。
            Dim validInput = _service.ValidateSearchCondition(viewModel.StartDate, viewModel.EndDate)
            If (Not validInput.IsSuccess) Then
                SetAjaxResultDto(ajaxResultDto, StatusInf.FAILED, validInput.MessageInfo.Message, String.Empty,
                                 New Dictionary(Of String, Object) From {{TYPE_ERROR, validInput.ErrorType}}, validInput.MessageInfo.Focus)
                Return Json(ajaxResultDto)
            End If

            Dim paramSearch = GetParamSearch(viewModel)
            Dim result = _service.ExportDataCSV(paramSearch, loginSession.UserInfo.UserId, Request.UserHostAddress)
            '8.2.検索条件を元に、受注情報を検索する。
            If Not result.IsSuccess Then
                SetAjaxResultDto(ajaxResultDto, StatusInf.FAILED, result.MessageInfo.Message)
                Return Json(ajaxResultDto)
            End If

            Dim nameFile = $"受注データCSV_{DateUtil.GetSysDate(SysdateFormat.YYYYMMDDHHMMSSFFF).Replace("/", String.Empty).Replace(":", String.Empty).Replace(".", String.Empty)}.csv"
            ' Export file
            SetInforReponseFile(nameFile, result.Data)
            Return Nothing
        End Function

        ''' <summary>
        ''' 9.選択 10. 参照作成
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <param name="isSelectBtn">False is 10. 参照作成</param>
        ''' <returns>Set TempData for TPL01010</returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function GoToTPL01010(orderNo As String, Optional isSelectBtn As Boolean = False) As ActionResult
            Dim tpl01010WiewModel As New Tpl01010ParameterDto With {
                .OrderNo = orderNo,
                .ProcessMode = If(isSelectBtn, PROCESS_STATUS.READY, PROCESS_STATUS.PROCESSED)
            }

            TempData(TPL01010VM) = tpl01010WiewModel
            Dim AjaxResultDto As New AjaxResultDto With {
                .Status = StatusInf.SUCCESS
            }
            Return Json(AjaxResultDto)
        End Function


        ''' <summary>
        ''' 15.外注発注
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns>Set TempData for TPL02010</returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function GoToTPL02010(orderNo As String) As ActionResult
            Dim tpl02010ParameterDto As New Tpl02010ParameterDto With {
                .orderNo = orderNo,
                .PurchaseNo = Nothing
            }

            TempData(TPL02010VM) = tpl02010ParameterDto
            Dim AjaxResultDto As New AjaxResultDto With {
                .Status = StatusInf.SUCCESS
            }
            Return Json(AjaxResultDto)
        End Function

        ''' <summary>
        ''' 16.用紙発注
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns>Set TempData for TPL02030</returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function GoToTPL02030(orderNo As String) As ActionResult
            Dim tpl02030WiewModel As New Tpl02030ParameterDto With {
                .orderNo = orderNo,
                .purchaseNo = Nothing
            }
            TempData(TPL02030VM) = tpl02030WiewModel
            Dim AjaxResultDto As New AjaxResultDto With {
                .Status = StatusInf.SUCCESS
            }
            Return Json(AjaxResultDto)
        End Function

        ''' <summary>
        ''' 17.売上
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns>Check sales can register or not</returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function CheckSalesRegister(orderNo As String) As ActionResult
            Dim ajaxResultDto As New AjaxResultDto With {
                .Status = StatusInf.SUCCESS
            }
            If String.IsNullOrEmpty(orderNo) Then
                ajaxResultDto.Status = StatusInf.FAILED
                Return Json(ajaxResultDto)
            End If
            Dim checkSales = _service.IsAnySalesByOrderNo(orderNo)
            ajaxResultDto.DataString = checkSales
            Return Json(ajaxResultDto)
        End Function

        ''' <summary>
        '''  17.売上
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns>Set TempData for TPL04010</returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function GoToTPL04010(orderNo As String) As ActionResult
            Dim tpl04010WiewModel As New TPL04010ParameterDto With {
                .orderNo = orderNo,
                .SalesNo = Nothing
            }

            TempData(TPL04010VM) = tpl04010WiewModel
            Dim ajaxResultDto As New AjaxResultDto With {
                .Status = StatusInf.SUCCESS
            }
            Return Json(ajaxResultDto)
        End Function

        ''' <summary>
        ''' 18.原価
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns>Set TempData for TPL05030</returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function GoToTPL05030(orderNo As String) As ActionResult
            Dim tpl05030WiewModel As New TPL04030ParameterDto With {
                .orderNo = orderNo
            }
            TempData(TPL05030VM) = tpl05030WiewModel
            Dim AjaxResultDto As New AjaxResultDto With {
                .Status = StatusInf.SUCCESS
            }
            Return Json(AjaxResultDto)
        End Function


        ''' <summary>
        ''' Constructor or search param
        ''' </summary>
        ''' <param name="viewModel">TPL01040ViewModel</param>
        ''' <returns>SearchOrderParamDto</returns>
        Private Function GetParamSearch(viewModel As TPL01040ViewModel) As SearchOrderParamDto
            Return New SearchOrderParamDto(viewModel.OrderNo, viewModel.ProductType, viewModel.Customer, viewModel.StartDate, viewModel.EndDate, viewModel.ProductName, viewModel.ProductRemark, viewModel.Employee, viewModel.IsAnyOrderBacklog)
        End Function
    End Class

End Namespace