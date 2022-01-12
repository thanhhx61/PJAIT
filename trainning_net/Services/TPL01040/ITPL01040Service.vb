Imports System.Text
Imports Dao

Namespace Services
    Public Interface ITPL01040Service
        ''' <summary>
        ''' 受注検索処理
        ''' </summary>
        ''' <param name="request">PaginationRequestDto(Of SearchOrderParamDto)</param>
        ''' <returns>PanigationResultDto(Of SearchOrderResultDto)</returns>
        Function SearchOrderPagedList(request As PaginationRequestDto(Of SearchOrderParamDto)) As PanigationResultDto(Of SearchOrderResultDto)

        ''' <summary>
        ''' Get Data Combobox By Id
        ''' </summary>
        ''' <param name="id">String</param>
        ''' <param name="blank">Boolean. Default = false</param>
        ''' <returns>List(Of ComboBoxDto)</returns>
        Function GetDataComboBoxById(id As String, Optional blank As Boolean = False) As List(Of ComboBoxDto)

        ''' <summary>
        ''' Check 内外区分
        ''' </summary>
        ''' <param name="orderNo">string</param>
        ''' <returns>Boolean</returns>
        Function IsAnySalesByOrderNo(orderNo As String) As Boolean

        ''' <summary>
        ''' 6.Form_Load時仕様 -2. ボタン制御情報を取得する。
        ''' </summary>
        ''' <returns></returns>
        Function GetBtnControlArray() As Boolean()
        ''' <summary>
        ''' 検索時エラーチェック
        ''' </summary>
        ''' <param name="startDate">開始 - Date</param>
        ''' <param name="endDate">終了- Date</param>
        ''' <returns>TPL01040ResultDto</returns>
        Function ValidateSearchCondition(startDate As Date?, endDate As Date?) As TPL01040ResultDto

        ''' <summary>
        ''' CSV出力ボタンクリック時
        ''' </summary>
        ''' <param name="paramSearch">SearchOrderParamDto</param>
        ''' <param name="loginId">User Login Id</param>
        ''' <param name="ipAddr">User IP Address</param>
        ''' <returns>StringBuilder Data csv</returns>
        Function ExportDataCSV(paramSearch As SearchOrderParamDto, loginId As String, ipAddr As String) As TPL01040ResultWithDataDto(Of StringBuilder)

    End Interface
End Namespace
