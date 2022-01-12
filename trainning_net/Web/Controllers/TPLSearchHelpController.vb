Imports Core.ConstantCore.Consts
Imports Dao
Imports Newtonsoft.Json
Imports Services.Services
Imports Web.Models

Namespace Controllers
    ''' <summary>
    ''' Popup controller
    ''' </summary>
    Public Class TPLSearchHelpController
        Inherits BaseController

        Private ReadOnly _TPL99010Service As ITPL99010Service
        Private ReadOnly _TPL99020Service As ITPL99020Service
        Private ReadOnly _TPL99040Service As ITPL99040Service
        Private ReadOnly _TPL99050Service As ITPL99050Service

#Region "Constants"
        Private Const LAYOUT_TPL99010W = "_TPL99010W"
        Private Const LAYOUT_TABLE_TPL99010W = "_TPL99010W_Table"
        Private Const LAYOUT_TPL99020W = "_TPL99020W"
        Private Const LAYOUT_TABLE_TPL99020W = "_TPL99020W_Table"
        Private Const LAYOUT_TPL99040W = "_TPL99040W"
        Private Const LAYOUT_TABLE_TPL99040W = "_TPL99040W_Table"
        Private Const LAYOUT_TPL99050W = "_TPL99050W"
        Private Const LAYOUT_TABLE_TPL99050W = "_TPL99050W_Table"
#End Region
        Public Sub New(tPL99010 As ITPL99010Service, tPL99020 As ITPL99020Service, tPL99040 As ITPL99040Service, tPL99050 As ITPL99050Service)
            _TPL99010Service = tPL99010
            _TPL99020Service = tPL99020
            _TPL99040Service = tPL99040
            _TPL99050Service = tPL99050
        End Sub
        ''' <summary>
        ''' TPL99010W_コード選択
        ''' </summary>
        ''' <param name="viewModel">TPL99010WViewModel</param>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function TPL99010W(viewModel As TPL99010WViewModel) As ActionResult
            Dim request = New PaginationRequestDto(Of SearchCodeParamDto) With {
                .PageSize = 10,
                .PageCurrent = viewModel.pageCurrent,
                .Param = New SearchCodeParamDto() With {.code = viewModel.Ident}
            }
            Dim result = _TPL99010Service.SearchCodePagedList(request)
            Dim viewData As New With {.searchResult = result.List, .checkSearch = True, .total = result.Total, .pageSize = request.PageSize, .pageCurrent = request.PageCurrent, .idInput = viewModel.Ident}
            Dim ajaxResultDto = New AjaxResultDto With {
                .Status = StatusInf.SUCCESS,
                .DataString = RenderViewToString(Me.ControllerContext, LAYOUT_TPL99010W, New TPL99010WViewModel(), viewData)
            }
            If result.Total = 0 Then
                ajaxResultDto.Message = String.Format(Core.My.Resources.ValidationResource.MSG_010, "コード情報")
                ajaxResultDto.Status = StatusInf.FAILED
            End If
            Return Json(ajaxResultDto)
        End Function

        ''' <summary>
        ''' TPL99010W_コード選択 - Table HTML
        ''' </summary>
        ''' <param name="viewModel">TPL99010WViewModel</param>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function SearchTPL99010(viewModel As TPL99010WViewModel) As ActionResult
            Dim request = New PaginationRequestDto(Of SearchCodeParamDto) With {
                .PageSize = 10,
                .PageCurrent = viewModel.pageCurrent,
                .Param = New SearchCodeParamDto() With {.code = viewModel.Ident}
            }
            Dim result = _TPL99010Service.SearchCodePagedList(request)
            Dim viewData As New With {.searchResult = result.List, .checkSearch = True, .total = result.Total, .pageSize = request.PageSize, .pageCurrent = request.PageCurrent, .idInput = viewModel.Ident}
            Dim ajaxResultDto = New AjaxResultDto With {
                .Status = StatusInf.SUCCESS,
                .DataString = RenderViewToString(Me.ControllerContext, LAYOUT_TABLE_TPL99010W, New TPL99010WViewModel(), viewData)
            }
            If result.Total = 0 Then
                ajaxResultDto.Message = String.Format(Core.My.Resources.ValidationResource.MSG_010, "コード情報")
                ajaxResultDto.Status = StatusInf.FAILED
            End If
            Return Json(ajaxResultDto)
        End Function
        ''' <summary>
        ''' TPL99020W_取引先選択
        ''' </summary>
        ''' <param name="viewModel">TPL99020WViewModel</param>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function TPL99020W(viewModel As TPL99020WViewModel) As ActionResult
            Dim request = New PaginationRequestDto(Of SearchCustomerParamDto) With {
                .PageSize = 10,
                .PageCurrent = viewModel.pageCurrent,
                .Param = New SearchCustomerParamDto() With {.customerType = viewModel.Code, .nameOrYomi = If(String.IsNullOrEmpty(viewModel.NameSearch), "", viewModel.NameSearch)}
            }
            Dim result As New PanigationResultDto(Of 取引先Dto)
            result.List = New List(Of 取引先Dto)
            result.Total = 0

            Dim dataComboBoxCustomer = _TPL99020Service.GetDataComboBoxById(COMMON_NO.CUSTOMER_TYPE)
            Dim viewData As New With {
                .searchResult = result.List,
                .checkSearch = True,
                .total = result.Total,
                .pageSize = request.PageSize,
                .pageCurrent = request.PageCurrent,
                .comboboxCustomer = dataComboBoxCustomer
            }

            Dim ajaxResultDto = New AjaxResultDto With {
                .Status = StatusInf.SUCCESS,
                .DataString = RenderViewToString(Me.ControllerContext, LAYOUT_TPL99020W, viewModel, viewData)
            }

            Return Json(ajaxResultDto)
        End Function
        ''' <summary>
        ''' TPL99020W_取引先選択 Table HTML
        ''' </summary>
        ''' <param name="viewModel">TPL99020WViewModel</param>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function SearchTPL99020(viewModel As TPL99020WViewModel) As ActionResult
            Dim request = New PaginationRequestDto(Of SearchCustomerParamDto) With {
                .PageSize = 10,
                .PageCurrent = viewModel.pageCurrent,
                .Param = New SearchCustomerParamDto() With {.customerType = viewModel.Code, .nameOrYomi = If(String.IsNullOrEmpty(viewModel.NameSearch), "", viewModel.NameSearch)}
            }
            Dim result = _TPL99020Service.SearchCodePagedList(request)

            Dim viewData As New With {
                .searchResult = result.List,
                .checkSearch = True,
                .total = result.Total,
                .pageSize = request.PageSize,
                .pageCurrent = request.PageCurrent
            }

            Dim ajaxResultDto = New AjaxResultDto With {
                .Status = StatusInf.SUCCESS,
                .DataString = RenderViewToString(Me.ControllerContext, LAYOUT_TABLE_TPL99020W, viewModel, viewData)
            }

            If result.Total = 0 Then
                ajaxResultDto.Message = String.Format(Core.My.Resources.ValidationResource.MSG_010, "取引先情報")
                ajaxResultDto.Status = StatusInf.FAILED
            End If
            Return Json(ajaxResultDto)
        End Function

        ''' <summary>
        ''' TPL99040W_担当選択
        ''' </summary>
        ''' <param name="viewModel">TPL99040WViewModel</param>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function TPL99040W(viewModel As TPL99040WViewModel) As ActionResult
            Dim request = New PaginationRequestDto(Of SearchEmployeeParamDto) With {
                .PageSize = 10,
                .PageCurrent = viewModel.pageCurrent,
                .Param = New SearchEmployeeParamDto() With {.DepartmentCode = viewModel.DepartmentCode, .NameEmployee = If(String.IsNullOrEmpty(viewModel.NameSearch), "", viewModel.NameSearch)}
            }

            Dim result As New PanigationResultDto(Of ResultSearchByDepartAndNameDto)
            Dim dataComboBoDepartment = _TPL99040Service.GetDataComboBoxById(COMMON_NO.DEPARTMENT)
            result.List = New List(Of ResultSearchByDepartAndNameDto)
            result.Total = 0

            Dim viewData As New With {
                .searchResult = result.List,
                .checkSearch = True,
                .total = result.Total,
                .pageSize = request.PageSize,
                .pageCurrent = request.PageCurrent,
                .cbbDepartment = dataComboBoDepartment
            }

            Dim ajaxResultDto = New AjaxResultDto With {
                .Status = StatusInf.SUCCESS,
                .DataString = RenderViewToString(Me.ControllerContext, LAYOUT_TPL99040W, viewModel, viewData)
            }

            Return Json(ajaxResultDto)
        End Function
        ''' <summary>
        ''' TPL99040W_担当選択 Table HTML
        ''' </summary>
        ''' <param name="viewModel">TPL99040WViewModel</param>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function SearchTPL99040(viewModel As TPL99040WViewModel) As ActionResult
            Dim request = New PaginationRequestDto(Of SearchEmployeeParamDto) With {
                .PageSize = 10,
                .PageCurrent = viewModel.pageCurrent,
                .Param = New SearchEmployeeParamDto() With {.DepartmentCode = viewModel.DepartmentCode, .NameEmployee = If(String.IsNullOrEmpty(viewModel.NameSearch), "", viewModel.NameSearch)}
            }
            Dim result = _TPL99040Service.SearchCodePagedList(request)
            Dim viewData As New With {
                .searchResult = result.List,
                .checkSearch = True,
                .total = result.Total,
                .pageSize = request.PageSize,
                .pageCurrent = request.PageCurrent
            }
            Dim ajaxResultDto = New AjaxResultDto With {
                .Status = StatusInf.SUCCESS,
                .DataString = RenderViewToString(Me.ControllerContext, LAYOUT_TABLE_TPL99040W, viewModel, viewData)
            }

            If result.Total = 0 Then
                ajaxResultDto.Message = String.Format(Core.My.Resources.ValidationResource.MSG_010, "担当情報")
                ajaxResultDto.Status = StatusInf.FAILED
            End If
            Return Json(ajaxResultDto)
        End Function

        ''' <summary>
        ''' TPL99050W_用紙選択
        ''' </summary>
        ''' <param name="viewModel">TPL99050WViewModel</param>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function TPL99050W(viewModel As TPL99050WViewModel) As ActionResult
            Dim request = New PaginationRequestDto(Of SearchPaperPopupParamDto) With {
                .PageSize = 10,
                .PageCurrent = viewModel.pageCurrent,
                .Param = New SearchPaperPopupParamDto() With {
                    .ProductType = viewModel.ProductType,
                    .ProducerCode = viewModel.ProducerCode,
                    .ProducerName = viewModel.NameSearch
                }
            }
            Dim result As New PanigationResultDto(Of ResultPaperPopupDto)
            result.List = New List(Of ResultPaperPopupDto)
            result.Total = 0

            Dim viewData As New With {
                .searchResult = result.List,
                .checkSearch = True,
                .total = result.Total,
                .pageSize = request.PageSize,
                .pageCurrent = request.PageCurrent
            }
            Dim ajaxResultDto = New AjaxResultDto With {
                .Status = StatusInf.SUCCESS,
                .DataString = RenderViewToString(Me.ControllerContext, LAYOUT_TPL99050W, viewModel, viewData)
            }

            Return Json(ajaxResultDto)
        End Function

        ''' <summary>
        ''' TPL99050W_用紙選択 - Table HTML
        ''' </summary>
        ''' <param name="viewModel">TPL99050WViewModel</param>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function SearchTPL99050(viewModel As TPL99050WViewModel) As ActionResult
            Dim request = New PaginationRequestDto(Of SearchPaperPopupParamDto) With {
                .PageSize = 10,
                .PageCurrent = viewModel.pageCurrent,
                .Param = New SearchPaperPopupParamDto() With {
                    .ProductType = viewModel.ProductType,
                    .ProducerCode = viewModel.ProducerCode,
                    .ProducerName = viewModel.NameSearch
                }
            }

            Dim result = _TPL99050Service.SearchPaperPagedList(request)

            Dim viewData As New With {
                .searchResult = result.List,
                .checkSearch = True,
                .total = result.Total,
                .pageSize = request.PageSize,
                .pageCurrent = request.PageCurrent
            }
            Dim ajaxResultDto = New AjaxResultDto With {
                .Status = StatusInf.SUCCESS,
                .DataString = RenderViewToString(Me.ControllerContext, LAYOUT_TABLE_TPL99050W, viewModel, viewData)
            }

            If result.Total = 0 Then
                ajaxResultDto.Message = String.Format(Core.My.Resources.ValidationResource.MSG_010, "用紙情報")
                ajaxResultDto.Status = StatusInf.FAILED
            End If
            Return Json(ajaxResultDto)
        End Function

    End Class
End Namespace