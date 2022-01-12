Imports System.Text
Imports Core.ConstantCore.Consts
Imports Core.Util
Imports Dao
Imports Services.Services

Namespace Services
    Public Class TPL04020Servicelmpl
        Implements ITPL04020Service
        Private ReadOnly _TPL_受注基本Dao As 受注基本Dao
        Private ReadOnly _TPL_売上基本Dao As 売上基本Dao
        Private ReadOnly _TPL_売上明細Dao As 売上明細Dao
        Private ReadOnly _TPL_コードDao As コードDao
        Private ReadOnly _TPL_取引先Dao As 取引先Dao
        Private ReadOnly _TPL_担当Dao As 担当Dao
        Private ReadOnly _commonService As ICMN9000Service

#Region "CONSTANT"
        Public Const START_GREAT_THAN_END = "StartGreatThanEnd"
        Public Const DATE_GREAT_THAN_12M = "DateGreatThan12M"
        Public Const START_DATE = "StartDate"
        Public Const END_DATE = "EndDate"
        Public Const BTN_VISIBLE_VALUE = "1"
        Public Const DEFAULT_FSC = "1"
#End Region

        Public Sub New(tPL_受注基本Dao As 受注基本Dao, tPL_売上基本Dao As 売上基本Dao, tPL_売上明細Dao As 売上明細Dao, tPL_コードDao As コードDao, tPL_取引先Dao As 取引先Dao, tPL_担当Dao As 担当Dao, commonService As ICMN9000Service)
            _TPL_受注基本Dao = tPL_受注基本Dao
            _TPL_売上基本Dao = tPL_売上基本Dao
            _TPL_売上明細Dao = tPL_売上明細Dao
            _TPL_コードDao = tPL_コードDao
            _TPL_取引先Dao = tPL_取引先Dao
            _TPL_担当Dao = tPL_担当Dao
            _commonService = commonService
        End Sub

        Public Function ValidateSearchCondition(startDate As Date?, endDate As Date?) As Object Implements ITPL04020Service.ValidateSearchCondition

            Dim result As New TPL01040ResultDto With {
                .IsSuccess = True
                }
            'ヘッダー部.受注日(開始)が未入力
            If startDate Is Nothing Then
                result.IsSuccess = False
                result.ErrorType = START_DATE
                result.MessageInfo = New MessageInfoDto() With {.Message = Core.My.Resources.ValidationResource.MSG_060, .Focus = START_DATE, .IsMessage = True}
                Return result
            End If
            'ヘッダー部.受注日(終了)が未入力
            If endDate Is Nothing Then
                result.IsSuccess = False
                result.ErrorType = END_DATE
                result.MessageInfo = New MessageInfoDto() With {.Message = Core.My.Resources.ValidationResource.MSG_060, .Focus = END_DATE, .IsMessage = True}
                Return result
            End If
            'ヘッダー部.受注日(開始) > ヘッダー部.受注日(終了)
            If (startDate.GetValueOrDefault() > endDate.GetValueOrDefault()) Then
                result.IsSuccess = False
                result.ErrorType = START_GREAT_THAN_END
                result.MessageInfo = New MessageInfoDto() With {.Message = Core.My.Resources.ValidationResource.MSG_027, .Focus = START_DATE, .IsMessage = True}
                Return result
            End If
            'ヘッダー部.受注日(開始)の年月(yyyyMM)とヘッダー部.受注日(終了)の年月(yyyyMM)の差が12か月を超える
            Dim countMonth = DateUtil.GetMonthBetweenDate(startDate.GetValueOrDefault(), endDate.GetValueOrDefault())
            If (countMonth > 12) Then
                result.IsSuccess = False
                result.ErrorType = DATE_GREAT_THAN_12M
                result.MessageInfo = New MessageInfoDto() With {.Message = Core.My.Resources.ValidationResource.MSG_028, .Focus = START_DATE, .IsMessage = True}
                Return result
            End If
            Return result
        End Function

        Public Function SearchOrderPagedList(request As SearchInforParamDto) As SearchInforResultDto Implements ITPL04020Service.SearchOrderPagedList
            Return Nothing
        End Function

        Public Function GetBtnControlArray() As Boolean() Implements ITPL04020Service.GetBtnControlArray
            '6.2-1. ボタンの制御情報を取得する。
            Dim btnCtrlList = _commonService.GetCodeByIdentifer(COMMON_NO.BUTTON_CONTROL, Nothing)
            If (btnCtrlList Is Nothing OrElse btnCtrlList.Count = 0) Then
                Return {False, False, False}
            End If
            '6.2-2. パラメタを編集する。
            Dim visibleCostBtn = BTN_VISIBLE_VALUE.Equals(btnCtrlList.FirstOrDefault(Function(a) a.コード = BUTTON_CONTROL.COST)?.文字１)
            Dim visibleWorkInstructionBtn = BTN_VISIBLE_VALUE.Equals(btnCtrlList.FirstOrDefault(Function(a) a.コード = BUTTON_CONTROL.WORK_INSTRUCTION)?.文字１)
            Dim visibleSettlementEstimateBtn = BTN_VISIBLE_VALUE.Equals(btnCtrlList.FirstOrDefault(Function(a) a.コード = BUTTON_CONTROL.SETTLEMENT_ESTIMATE)?.文字１)
            Dim btnCtrlArr() As Boolean = {visibleCostBtn, visibleWorkInstructionBtn, visibleSettlementEstimateBtn}
            Return btnCtrlArr
        End Function

        Public Function ExportDataCSV(paramSearch As SearchInforParamDto, loginId As String, ipAddr As String) As TPL01040ResultWithDataDto(Of StringBuilder) Implements ITPL04020Service.ExportDataCSV

            Dim data = _TPL_売上基本Dao.GetInfoList(paramSearch)

            Throw New NotImplementedException()
        End Function


    End Class
End Namespace

