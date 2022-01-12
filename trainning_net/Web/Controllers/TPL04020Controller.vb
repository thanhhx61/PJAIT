Imports System.Web.Mvc
Imports Core.ConstantCore.Consts
Imports Core.My.Resources
Imports Core.Util
Imports Dao
Imports Services
Imports Web.Models

Namespace Controllers
    Public Class TPL04020Controller
        Inherits BaseController
        Private ReadOnly _service As ITPL04020Service


#Region "CONSTANT"
        Private Const PAGESIZE = 10
        Private Const VIEW_INDEX = "Index"
        Private Const VIEW_TABLE = "_TableTPL04020"
        Private Const TYPE_ERROR = "TypeError"
#End Region
        Public Sub New(service As ITPL04020Service)
            _service = service
        End Sub
        <HttpGet>
        Function Index() As ActionResult
            Dim viewModel As New TPL04020ViewModel
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
        Function Search(viewModel As TPL04020ViewModel) As ActionResult
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
        Private Function GetParamSearch(viewModel As TPL04020ViewModel) As SearchOrderParamDto
            Return New SearchOrderParamDto(viewModel.OrderNo, viewModel.ProductType, viewModel.Customer, viewModel.StartDate, viewModel.EndDate, viewModel.ProductName, viewModel.ProductRemark, viewModel.Employee, viewModel.IsAnyOrderBacklog)
        End Function
    End Class
End Namespace
