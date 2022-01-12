Imports System.Text
Imports Dao

Public Interface ITPL04020Service
    ''' <summary>
    ''' 検索時エラーチェック
    ''' </summary>
    ''' <param name="startDate">開始 - Date</param>
    ''' <param name="endDate">終了- Date</param>
    ''' <returns>TPL01040ResultDto</returns>
    Function ValidateSearchCondition(startDate As Date?, endDate As Date?)
    ''' <summary>
    ''' 受注検索処理
    ''' </summary>
    ''' <param name="request">PaginationRequestDto(Of SearchOrderParamDto)</param>
    ''' <returns>PanigationResultDto(Of SearchOrderResultDto)</returns>
    Function SearchOrderPagedList(request As SearchInforParamDto) As SearchInforResultDto
    ''' <summary>
    ''' 6.Form_Load時仕様 -2. ボタン制御情報を取得する。
    ''' </summary>
    ''' <returns></returns>
    Function GetBtnControlArray() As Boolean()
    ''' <summary>
    ''' CSV出力ボタンクリック時
    ''' </summary>
    ''' <param name="paramSearch">SearchOrderParamDto</param>
    ''' <param name="loginId">User Login Id</param>
    ''' <param name="ipAddr">User IP Address</param>
    ''' <returns>StringBuilder Data csv</returns>
    Function ExportDataCSV(paramSearch As SearchOrderParamDto, loginId As String, ipAddr As String) As TPL01040ResultWithDataDto(Of StringBuilder)

End Interface
