Imports System.Text
Imports Core.ConstantCore.Consts
Imports Core.My.Resources
Imports Core.Util
Imports Dao

Namespace Services
    Public Class TPL01040ServiceImpl
        Implements ITPL01040Service
        Private ReadOnly _TPL_受注基本Dao As 受注基本Dao
        Private ReadOnly _TPL_コードDao As コードDao
        Private ReadOnly _commonService As ICMN9000Service

#Region "CONSTANT"
        Public Const START_GREAT_THAN_END = "StartGreatThanEnd"
        Public Const DATE_GREAT_THAN_12M = "DateGreatThan12M"
        Public Const START_DATE = "StartDate"
        Public Const END_DATE = "EndDate"
        Public Const BTN_VISIBLE_VALUE = "1"
        Public Const DEFAULT_FSC = "1"
#End Region

        Public Sub New(tPL_受注基本Dao As 受注基本Dao, tPL_コードDao As コードDao, commonService As ICMN9000Service)
            _TPL_受注基本Dao = tPL_受注基本Dao
            _TPL_コードDao = tPL_コードDao
            _commonService = commonService
        End Sub
        ''' <summary>
        ''' 受注検索処理
        ''' </summary>
        ''' <param name="request">PaginationRequestDto(Of SearchOrderParamDto)</param>
        ''' <returns>PanigationResultDto(Of SearchOrderResultDto)</returns>
        Public Function SearchOrderPagedList(request As PaginationRequestDto(Of SearchOrderParamDto)) As PanigationResultDto(Of SearchOrderResultDto) Implements ITPL01040Service.SearchOrderPagedList
            Return _TPL_受注基本Dao.GetOrderPagedList(request)
        End Function

        ''' <summary>
        ''' Get Data Combobox By Id
        ''' </summary>
        ''' <param name="id">String</param>
        ''' <param name="blank">Boolean. Default = false</param>
        ''' <returns>List(Of ComboBoxDto)</returns>
        Public Function GetDataComboBoxById(id As String, Optional blank As Boolean = False) As List(Of ComboBoxDto) Implements ITPL01040Service.GetDataComboBoxById
            Dim result = _TPL_コードDao.GetCombo(id)
            If (blank) Then
                result.Insert(0, New ComboBoxDto(String.Empty, String.Empty, String.Empty, 0))
            End If
            Return result
        End Function

        ''' <summary>
        ''' Check 内外区分
        ''' </summary>
        ''' <param name="orderNo">string</param>
        ''' <returns>Boolean</returns>
        Public Function IsAnySalesByOrderNo(orderNo As String) As Boolean Implements ITPL01040Service.IsAnySalesByOrderNo
            Dim result = _TPL_受注基本Dao.GetListOrderSales(orderNo)
            Return result.Any()
        End Function

        ''' <summary>
        ''' 検索時エラーチェック
        ''' </summary>
        ''' <param name="startDate">開始 - Date</param>
        ''' <param name="endDate">終了- Date</param>
        ''' <returns>TPL01040ResultDto</returns>
        Public Function ValidateSearchCondition(startDate As Date?, endDate As Date?) As TPL01040ResultDto Implements ITPL01040Service.ValidateSearchCondition
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

        ''' <summary>
        ''' 6.Form_Load時仕様 -2. ボタン制御情報を取得する。
        ''' </summary>
        ''' <returns>array Boolean</returns>
        Public Function GetBtnControlArray() As Boolean() Implements ITPL01040Service.GetBtnControlArray
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

        ''' <summary>
        ''' CSV出力ボタンクリック時
        ''' </summary>
        ''' <param name="paramSearch">SearchOrderParamDto</param>
        ''' <param name="loginId">User Login Id</param>
        ''' <param name="ipAddr">User IP Address</param>
        ''' <returns>StringBuilder Data csv</returns>
        Public Function ExportDataCSV(paramSearch As SearchOrderParamDto, loginId As String, ipAddr As String) As TPL01040ResultWithDataDto(Of StringBuilder) Implements ITPL01040Service.ExportDataCSV
            Dim result = New TPL01040ResultWithDataDto(Of StringBuilder)
            Dim dataSearch = _TPL_受注基本Dao.GetOrderList(paramSearch)
            If (Not dataSearch.Any()) Then
                result.IsSuccess = False
                result.MessageInfo = New MessageInfoDto() With {.Message = ValidationResource.MSG_198}
                result.Data = Nothing
                Return result
            End If
            '8.3 CSV編集仕様(ヘッダー部)
            Dim content = AddCSVHeader(paramSearch)
            '8.4.CSV編集仕様(ボディ部-受注)
            AddCSVBody(content, dataSearch)
            '8.5.CSV add ※
            content.Append(CsvUtil.CreateValueRow(New List(Of String) From {"※"}))
            '8.6.CSV編集仕様(ボディ部-受注明細)
            AddCSVBodyDetail(content, dataSearch)
            result.IsSuccess = True
            result.Data = content
            Return result
        End Function

#Region "GetValuesForCSV"
        ''' <summary>
        ''' CSV編集仕様(ヘッダー部)
        ''' </summary>
        ''' <param name="param">CSVHeaderParamDto</param>
        ''' <returns>String csv header</returns>
        Private Function AddCSVHeader(param As SearchOrderParamDto) As StringBuilder
            Dim content As New StringBuilder()
            Dim csvHeader As New List(Of String) From {
                "受注番号",
                "製品種別",
                "得意先",
                "得意先名",
                "受注日(開始)",
                "受注日(終了)",
                "受注残あり",
                "品名",
                "品名備考",
                "担当"
            }
            content.Append(CsvUtil.CreateHeaderRow(csvHeader))
            Dim customerName = _commonService.GetCustomerByCode(param.Customer, CUSTOMER_TYPE.CUSTOMER, TypeGetName.FULLNAME)
            Dim isCheckedAnyOrder = param.IsAnyOrderBacklog IsNot Nothing
            Dim conditionValues = New List(Of String) From {
                param.OrderNo,
                param.ProductType,
                param.Customer,
                customerName,
                DateUtil.ConvertDateToString(param.StartDate, DateFormat.YYYYMMDD),
                DateUtil.ConvertDateToString(param.EndDate, DateFormat.YYYYMMDD),
                If(isCheckedAnyOrder, param.IsAnyOrderBacklog.ToUpper, String.Empty),
                param.ProductName,
                param.ProductRemark,
                param.Employee
            }
            content.Append(CsvUtil.CreateValueRow(conditionValues))
            Return content
        End Function

        ''' <summary>
        ''' CSV編集仕様(ボディ部-受注)
        ''' </summary>
        ''' <param name="content">StringBuilder - ByRef</param>
        ''' <param name="dataSearch">List(Of SearchOrderResultDto)</param>
        Private Sub AddCSVBody(ByRef content As StringBuilder, dataSearch As List(Of SearchOrderResultDto))

            Dim headers As New List(Of String) From
            {
            "受注番号",'1
            "参照元",'2
            "先方注番",'3
            "スケジュール登録有無",'4
            "品名",'5
            "品名備考",'6
            "得意先",'7
            "得意先名",'8
            "担当",'9
            "担当名",'10
            "伝票区分",
            "受注区分",
            "製品種別",
            "受注日",
            "納品日",'15
            "検収日",
            "製品サイズ",
            "縦",
            "横",
            "頁数",'20
            "受注数量",
            "受注単価",
            "受注金額",
            "受注残金額",
            "明細金額",'25
            "明細仕切金額",
            "受注利益",
            "受注利益率",
            "単位",
            "FSC",'30
            "メモ１",
            "メモ２",
            "メモ３",
            "メモ４",
            "メモ５",
            "メモ６",
            "メモ７",
            "メモ８",
            "メモ９",
            "メモ１０",'40
            "入稿",
            "入稿備考",
            "初校",
            "初校備考",
            "再校",'45
            "再校備考",
            "三校",
            "三校備考",
            "下版",
            "下版備考",'50
            "刷版",
            "刷版備考",
            "印刷",
            "印刷備考",
            "加工",'55
            "加工備考",
            "スケジュールメモ１",
            "スケジュールメモ２",
            "スケジュールメモ３"'59
            }

            content.Append(CsvUtil.CreateHeaderRow(headers))

            'create body value rows
            For Each itemSearch As SearchOrderResultDto In dataSearch
                '8.4.1受注基本情報を検索する。
                Dim orderInfo = _commonService.GetOrderByKey1(itemSearch.受注番号)
                '8.4.2スケジュール情報を検索する。
                Dim scheduleInfo = _commonService.GetScheduleByKey(itemSearch.受注番号)

                content.Append(CsvUtil.CreateValueRow(GetValueCSVOrderInfo(orderInfo, scheduleInfo, itemSearch)))
            Next
        End Sub

        ''' <summary>
        ''' CSV編集仕様(ボディ部-受注)
        ''' </summary>
        ''' <param name="content">StringBuilder - ByRef</param>
        ''' <param name="dataSearch">List(Of SearchOrderResultDto)</param>
        Private Sub AddCSVBodyDetail(ByRef content As StringBuilder, dataSearch As List(Of SearchOrderResultDto))
            '8.6.CSV編集仕様(ボディ部-受注明細)
            Dim header2 As New List(Of String) From
            {
                "工程",
                "行番号",
                "内外",
                "当/先",
                "部品",
                "部品名",
                "頁数",
                "作業／銘柄",
                "作業／銘柄名",
                "機種",
                "機種名",
                "サイズ",
                "サイズ名",
                "色数",
                "面付",
                "色表",
                "色裏",
                "台数",
                "計算区分",
                "R/S",
                "連量",
                "単位区分",
                "数量",
                "予備",
                "数量合計",
                "単価",
                "金額",
                "仕切単価",
                "仕切金額"
            }

            content.Append(CsvUtil.CreateHeaderRow(header2))
            '8.6 CSV編集仕様(ボディ部-受注明細)
            For Each itemSearch As SearchOrderResultDto In dataSearch
                '8.6.1受注制作情報を取得する。(複数行あり)
                Dim orderKey2 = _commonService.GetOrderByKey2(itemSearch.受注番号)
                '8.6.2受注製版情報を取得する。(複数行あり)
                Dim orderKey3 = _commonService.GetOrderByKey3(itemSearch.受注番号)
                '8.6.3受注刷版情報を取得する。(複数行あり)
                Dim orderKey4 = _commonService.GetOrderByKey4(itemSearch.受注番号)
                '8.6.4受注印刷情報を取得する。(複数行あり)
                Dim orderKey5 = _commonService.GetOrderByKey5(itemSearch.受注番号)
                '8.6.5受注加工情報を取得する。(複数行あり)
                Dim orderKey6 = _commonService.GetOrderByKey6(itemSearch.受注番号)
                '8.6.6受注用紙情報を取得する。(複数行あり)
                Dim orderKey7 = _commonService.GetOrderByKey7(itemSearch.受注番号)
                '8.6.7受注その他情報を取得する。(複数行あり)
                Dim orderKey8 = _commonService.GetOrderByKey8(itemSearch.受注番号)
                '2
                If (orderKey2 IsNot Nothing) Then
                    For Each order2 As 受注制作Dto In orderKey2
                        content.Append(CsvUtil.CreateValueRow(GetValueCSVOrderByKey2(order2)))
                    Next
                End If
                '3
                If (orderKey3 IsNot Nothing) Then
                    For Each order3 As 受注製版Dto In orderKey3
                        content.Append(CsvUtil.CreateValueRow(GetValueCSVOrderByKey3(order3)))
                    Next
                End If
                '4
                If (orderKey4 IsNot Nothing) Then
                    For Each order4 As 受注刷版Dto In orderKey4
                        content.Append(CsvUtil.CreateValueRow(GetValueCSVOrderByKey4(order4)))
                    Next
                End If
                '5
                If (orderKey5 IsNot Nothing) Then
                    For Each order5 As 受注印刷Dto In orderKey5
                        content.Append(CsvUtil.CreateValueRow(GetValueCSVOrderByKey5(order5)))
                    Next
                End If
                '6
                If (orderKey6 IsNot Nothing) Then
                    For Each order6 As 受注加工Dto In orderKey6
                        content.Append(CsvUtil.CreateValueRow(GetValueCSVOrderByKey6(order6)))
                    Next
                End If
                '7
                If (orderKey7 IsNot Nothing) Then
                    For Each order7 As 受注用紙Dto In orderKey7
                        content.Append(CsvUtil.CreateValueRow(GetValueCSVOrderByKey7(order7)))
                    Next
                End If
                '8
                If (orderKey8 IsNot Nothing) Then
                    For Each order8 As 受注その他Dto In orderKey8
                        content.Append(CsvUtil.CreateValueRow(GetValueCSVOrderByKey8(order8)))
                    Next
                End If
            Next
        End Sub

        ''' <summary>
        ''' 検索条件を元に取得した受注情報を3行目以降に編集する。
        ''' </summary>
        ''' <param name="orderInfo">受注基本Dto</param>
        ''' <param name="scheduleInfo">受注スケジュールDto</param>
        ''' <param name="itemSearch">SearchOrderResultDto</param>
        ''' <returns></returns>
        Private Function GetValueCSVOrderInfo(orderInfo As 受注基本Dto, scheduleInfo As 受注スケジュールDto, itemSearch As SearchOrderResultDto) As List(Of String)
            Dim 利益率 = CalProfitRate(orderInfo.受注金額, orderInfo.明細仕切金額)
            Dim 伝票区分名 = _commonService.GetNameByCode(COMMON_NO.SLIP_TYPE, orderInfo.伝票区分, TypeGetName.FULLNAME)
            Dim 受注区分名 = _commonService.GetNameByCode(COMMON_NO.ORDER_TYPE, orderInfo.受注区分, TypeGetName.FULLNAME)
            Dim 製品種別名 = _commonService.GetNameByCode(COMMON_NO.PRODUCT_TYPE, orderInfo.製品種別, TypeGetName.FULLNAME)
            Dim 検収日Value = If(orderInfo.検収日.HasValue, DateUtil.ConvertDateToString(orderInfo.検収日, DateFormat.YYYYMMDD), String.Empty)
            Dim 製品サイズ名 = _commonService.GetNameByCode(COMMON_NO.PRODUCT_SIZE, orderInfo.製品サイズ, TypeGetName.FULLNAME)
            Dim 単位名 = _commonService.GetNameByCode(COMMON_NO.PRODUCT_UNIT, orderInfo.単位, TypeGetName.FULLNAME)

            Dim values = New List(Of String) From {
                orderInfo.受注番号,'1
                orderInfo.参照元受注番号,'2
                orderInfo.先方注番,'3
                If(scheduleInfo IsNot Nothing, "〇", String.Empty),'4
                orderInfo.品名,'5
                orderInfo.品名備考,'6
                orderInfo.得意先,'7
                orderInfo.得意先名,'8
                orderInfo.担当,'9
                orderInfo.担当名,'10
                If(伝票区分名 Is Nothing, String.Empty, 伝票区分名),'11
                If(受注区分名 Is Nothing, String.Empty, 受注区分名),'12
                If(製品種別名 Is Nothing, String.Empty, 製品種別名),'13
                DateUtil.ConvertDateToString(orderInfo.受注日, DateFormat.YYYYMMDD),'14
                DateUtil.ConvertDateToString(orderInfo.納品日, DateFormat.YYYYMMDD),'15
                検収日Value,'16
                If(製品サイズ名 Is Nothing, String.Empty, 製品サイズ名),'17
                If(orderInfo.縦 Is Nothing, String.Empty, orderInfo.縦.GetValueOrDefault()),'18
                If(orderInfo.横 Is Nothing, String.Empty, orderInfo.横.GetValueOrDefault()),'19
                If(orderInfo.頁数 Is Nothing, String.Empty, orderInfo.頁数.GetValueOrDefault()),'20
                If(orderInfo.受注数量 Is Nothing, String.Empty, orderInfo.受注数量.GetValueOrDefault()),'21
                If(orderInfo.受注単価 Is Nothing, String.Empty, orderInfo.受注単価.GetValueOrDefault()),'22
                orderInfo.受注金額,'23
                orderInfo.受注金額 - NumberUtil.ConvertToDecimal(itemSearch.売上金額),
                orderInfo.受注金額,'25
                If(orderInfo.明細仕切金額 Is Nothing, String.Empty, orderInfo.明細仕切金額.GetValueOrDefault()),'26
                orderInfo.受注金額 - orderInfo.明細仕切金額.GetValueOrDefault(),'27
                If(利益率 Is Nothing, String.Empty, 利益率.GetValueOrDefault()),'28
                If(単位名 Is Nothing, String.Empty, 単位名),'29
                If(DEFAULT_FSC.Equals(orderInfo.FSC), "〇", String.Empty),'30
                orderInfo.メモ1,
                orderInfo.メモ2,
                orderInfo.メモ3,
                orderInfo.メモ4,
                orderInfo.メモ5,
                orderInfo.メモ6,
                orderInfo.メモ7,
                orderInfo.メモ8,
                orderInfo.メモ9,
                orderInfo.メモ10 '40
            }
            If (scheduleInfo Is Nothing) Then
                values.AddRange({String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty})
            Else
                values.Add(DateUtil.ConvertDateToString(scheduleInfo.入稿, DateFormat.YYYYMMDD))
                values.Add(scheduleInfo.入稿備考)
                values.Add(DateUtil.ConvertDateToString(scheduleInfo.初校, DateFormat.YYYYMMDD))
                values.Add(scheduleInfo.初校備考)
                values.Add(DateUtil.ConvertDateToString(scheduleInfo.再校, DateFormat.YYYYMMDD))
                values.Add(scheduleInfo.再校備考)
                values.Add(DateUtil.ConvertDateToString(scheduleInfo.三校, DateFormat.YYYYMMDD))
                values.Add(scheduleInfo.三校備考)
                values.Add(DateUtil.ConvertDateToString(scheduleInfo.下版, DateFormat.YYYYMMDD))
                values.Add(scheduleInfo.下版備考)
                values.Add(DateUtil.ConvertDateToString(scheduleInfo.刷版, DateFormat.YYYYMMDD))
                values.Add(scheduleInfo.刷版備考)
                values.Add(DateUtil.ConvertDateToString(scheduleInfo.印刷, DateFormat.YYYYMMDD))
                values.Add(scheduleInfo.印刷備考)
                values.Add(DateUtil.ConvertDateToString(scheduleInfo.加工, DateFormat.YYYYMMDD))
                values.Add(scheduleInfo.加工備考)
                values.Add(scheduleInfo.メモ1)
                values.Add(scheduleInfo.メモ2)
                values.Add(scheduleInfo.メモ3)
            End If
            Return values
        End Function
        ''' <summary>
        ''' Calculate profit rate (利益率)
        ''' </summary>
        ''' <param name="受注金額">Decimal</param>
        ''' <param name="明細仕切金額">Decimal?</param>
        ''' <returns>利益率</returns>
        Private Function CalProfitRate(受注金額 As Decimal, 明細仕切金額 As Decimal?) As Decimal?
            Dim 利益率 As Decimal? = 0
            If (受注金額 = 0) Then
                利益率 = 0
            Else
                利益率 = (受注金額 - 明細仕切金額.GetValueOrDefault()) / 受注金額 * 100
            End If

            Return _commonService.GetRoundValue(利益率, 1, TAX_FRACTION.ROUND)
        End Function
        ''' <summary>
        ''' 制作工程の情報を編集する。
        ''' </summary>
        ''' <param name="order2">受注制作Dto</param>
        ''' <returns> List(Of String)</returns>
        Private Function GetValueCSVOrderByKey2(order2 As 受注制作Dto) As List(Of String)
            Dim 内外区分名 = _commonService.GetNameByCode(COMMON_NO.IN_OUT_TYPE, order2.内外区分, TypeGetName.FULLNAME)
            Return New List(Of String)() From {
                        "制作", '1
                        order2.行番号,'2
                        If(内外区分名 Is Nothing, String.Empty, 内外区分名),'3
                        String.Empty,'4
                        String.Empty,'5
                        String.Empty,'6
                        String.Empty,'7
                        order2.作業,'8
                        order2.作業名,'9
                        String.Empty,'10
                        String.Empty,'11
                        String.Empty,'12
                        String.Empty,'13
                        String.Empty,'14
                        String.Empty,'15
                        String.Empty,'16
                        String.Empty,'17
                        String.Empty,'18
                        String.Empty,'19
                        String.Empty,'20
                        String.Empty,'21
                        String.Empty,'22
                        order2.数量,'23
                        String.Empty,'24
                        order2.数量,'25
                        order2.単価,'26
                        order2.金額,'27
                        If(order2.仕切単価 Is Nothing, String.Empty, order2.仕切単価),'28
                        If(order2.仕切金額 Is Nothing, String.Empty, order2.仕切金額)'29
                    }
        End Function
        ''' <summary>
        ''' 製版工程の情報を編集する。
        ''' </summary>
        ''' <param name="order3">受注製版Dto</param>
        ''' <returns> List(Of String)</returns>
        Private Function GetValueCSVOrderByKey3(order3 As 受注製版Dto) As List(Of String)
            Dim 内外区分名 = _commonService.GetNameByCode(COMMON_NO.IN_OUT_TYPE, order3.内外区分, TypeGetName.FULLNAME)
            Return New List(Of String)() From {
                        "製版・デジタル印刷", '1
                        order3.行番号,
                        If(内外区分名 Is Nothing, String.Empty, 内外区分名),'3
                        String.Empty,
                        order3.部品,'5
                        order3.部品名,'6
                        If(order3.頁数 Is Nothing, String.Empty, order3.頁数),'7
                        order3.作業,'8
                        order3.作業名,'9
                        String.Empty,'10
                        String.Empty,'11
                        String.Empty,'12
                        String.Empty,'13
                        order3.色数,'14
                        String.Empty,'15
                        String.Empty,'16
                        String.Empty,'17
                        String.Empty,'18
                        String.Empty,'19
                        String.Empty,'20
                        String.Empty,'21
                        String.Empty,'22
                        order3.数量,'23
                        String.Empty,'24
                        order3.数量合計,'25
                        order3.単価,'26
                        order3.金額,'27
                        If(order3.仕切単価 Is Nothing, String.Empty, order3.仕切単価),'28
                        If(order3.仕切金額 Is Nothing, String.Empty, order3.仕切金額)'29
                    }
        End Function
        ''' <summary>
        ''' 刷版工程の情報を編集する。
        ''' </summary>
        ''' <param name="order4">受注刷版Dto</param>
        ''' <returns>List(Of String)</returns>
        Private Function GetValueCSVOrderByKey4(order4 As 受注刷版Dto) As List(Of String)
            Dim param数量 = (order4.色表 + order4.色裏) * order4.台数
            Dim 内外区分名 = _commonService.GetNameByCode(COMMON_NO.IN_OUT_TYPE, order4.内外区分, TypeGetName.FULLNAME)
            Return New List(Of String)() From {
                        "刷版", '1
                        order4.行番号,'2
                        If(内外区分名 Is Nothing, String.Empty, 内外区分名),'3
                        String.Empty,'4
                        order4.部品,'5
                        order4.部品名,'6
                        order4.頁数,'7
                        order4.作業,'8
                        order4.作業名,'9
                        String.Empty,'10
                        String.Empty,
                        order4.サイズ,'12
                        order4.サイズ名,'13
                        String.Empty,'14
                        If(order4.面付 Is Nothing, String.Empty, order4.面付),'15
                        If(order4.色表 Is Nothing, String.Empty, order4.色表),'16
                        If(order4.色裏 Is Nothing, String.Empty, order4.色裏),'17
                        order4.台数,'18
                        String.Empty,'19
                        String.Empty,'20
                        String.Empty,'21
                        String.Empty,'22
                        If(param数量 Is Nothing, String.Empty, param数量),'23
                        String.Empty,'24
                        If(param数量 Is Nothing, String.Empty, param数量),'25
                        order4.単価,'26
                        order4.金額,'27
                        If(order4.仕切単価 Is Nothing, String.Empty, order4.仕切単価),'28
                        If(order4.仕切金額 Is Nothing, String.Empty, order4.仕切金額)'29
                   }
        End Function
        ''' <summary>
        ''' 印刷工程の情報を編集する。
        ''' </summary>
        ''' <param name="order5">受注印刷Dto</param>
        ''' <returns>List(Of String)</returns>
        Private Function GetValueCSVOrderByKey5(order5 As 受注印刷Dto) As List(Of String)
            Dim param数量 As Decimal? = CalQuatityByType(order5.計算区分, order5.通し数, order5.台数)
            Dim 内外区分名 = _commonService.GetNameByCode(COMMON_NO.IN_OUT_TYPE, order5.内外区分, TypeGetName.FULLNAME)
            Return New List(Of String)() From {
                        "印刷", '1
                        order5.行番号,'2
                        If(内外区分名 Is Nothing, String.Empty, 内外区分名),'3
                        String.Empty,'4
                        order5.部品,'5
                        order5.部品名,'6
                        order5.頁数,'7
                        String.Empty,'8
                        String.Empty,'9
                        order5.機種,'10
                        order5.機種名,'11
                        order5.サイズ,'12
                        order5.サイズ名,'13
                        String.Empty,'14
                        String.Empty,'15
                        If(order5.色表 Is Nothing, String.Empty, order5.色表),'16
                        If(order5.色裏 Is Nothing, String.Empty, order5.色裏),'17
                        order5.台数,'18
                        _commonService.GetNameByCode(COMMON_NO.CALC_TYPE, order5.計算区分, TypeGetName.FULLNAME),'19
                        String.Empty,'20
                        String.Empty,'21
                        String.Empty,'22
                        If(param数量 Is Nothing, String.Empty, param数量),'23
                        String.Empty,'24
                        If(param数量 Is Nothing, String.Empty, param数量),'25
                        order5.単価,'26
                        order5.金額,'27
                        If(order5.仕切単価 Is Nothing, String.Empty, order5.仕切単価),'28
                        If(order5.仕切金額 Is Nothing, String.Empty, order5.仕切金額)'29
                   }
        End Function

        ''' <summary>
        ''' Cal quantity (数量) by type(計算区分)
        ''' </summary>
        ''' <param name="計算区分">string</param>
        ''' <param name="通し数">Decimal</param>
        ''' <param name="台数">Decimal</param>
        ''' <returns>数量</returns>
        Private Function CalQuatityByType(計算区分 As String, 通し数 As Decimal, 台数 As Decimal) As Decimal?
            If CALC_TYPE.THREAD.Equals(計算区分) Then
                Return 通し数
            ElseIf CALC_TYPE.UNIT_NUM.Equals(計算区分) Then
                Return 台数
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' 加工工程の情報を編集する。
        ''' </summary>
        ''' <param name="order6">受注加工Dto</param>
        ''' <returns> List(Of String)</returns>
        Private Function GetValueCSVOrderByKey6(order6 As 受注加工Dto) As List(Of String)
            Dim 内外区分名 = _commonService.GetNameByCode(COMMON_NO.IN_OUT_TYPE, order6.内外区分, TypeGetName.FULLNAME)
            Return New List(Of String)() From {
                        "加工", '1
                        order6.行番号,'2
                        If(内外区分名 Is Nothing, String.Empty, 内外区分名),'3
                        String.Empty,'4
                        String.Empty,'5
                        String.Empty,'6
                        String.Empty,'7
                        order6.作業,'8
                        order6.作業名,'9
                        String.Empty,'10
                        String.Empty,'11
                        order6.サイズ,'12
                        order6.サイズ名,'13
                        String.Empty,'14
                        String.Empty,'15
                        String.Empty,'16
                        String.Empty,'17
                        String.Empty,'18
                        String.Empty,'19
                        String.Empty,'20
                        String.Empty,'21
                        String.Empty,'22
                        order6.数量,'23
                        String.Empty,'24
                        order6.数量,'25
                        order6.単価,'26
                        order6.金額,'27
                        If(order6.仕切単価 Is Nothing, String.Empty, order6.仕切単価),'28
                        If(order6.仕切金額 Is Nothing, String.Empty, order6.仕切金額)'29
                   }
        End Function
        ''' <summary>
        ''' 用紙工程の情報を編集する。
        ''' </summary>
        ''' <param name="order7">受注用紙Dto</param>
        ''' <returns>List(Of String)</returns>
        Private Function GetValueCSVOrderByKey7(order7 As 受注用紙Dto) As List(Of String)
            Dim 当先区分名 = _commonService.GetNameByCode(COMMON_NO.OUR_OTHER_TYPE, order7.当先区分, TypeGetName.FULLNAME)
            Dim RS区分名 = _commonService.GetNameByCode(COMMON_NO.RS_TYPE, order7.RS区分, TypeGetName.FULLNAME)
            Dim 単位区分名 = _commonService.GetNameByCode(COMMON_NO.UNIT_TYPE, order7.単位区分, TypeGetName.FULLNAME)
            Return New List(Of String)() From {
                        "用紙", '1
                        order7.行番号,'2
                        String.Empty,'3
                        If(当先区分名 Is Nothing, String.Empty, 当先区分名),'4
                        order7.部品,'5
                        order7.部品名,'6
                        order7.頁数,'7
                        order7.銘柄,'8
                        order7.銘柄名,'9
                        String.Empty,'10
                        String.Empty,'11
                        order7.規格,'12
                        GetSizeName(order7.規格, order7.縦, order7.横),'13
                        String.Empty,'14
                        String.Empty,'15
                        String.Empty,'16
                        String.Empty,'17
                        String.Empty,'18
                        String.Empty,'19
                        If(RS区分名 Is Nothing, String.Empty, RS区分名),'20
                        order7.連量,'21
                        If(単位区分名 Is Nothing, String.Empty, 単位区分名),'22
                        order7.数量,'23
                        order7.予備,'24
                        order7.数量合計,'25
                        order7.単価,'26
                        order7.金額,'27
                        If(order7.仕切単価 Is Nothing, String.Empty, order7.仕切単価),'28
                        If(order7.仕切金額 Is Nothing, String.Empty, order7.仕切金額)'29
                   }
        End Function
        ''' <summary>
        ''' Get サイズ名
        ''' </summary>
        ''' <param name="規格">string</param>
        ''' <param name="縦">Decimal</param>
        ''' <param name="横">Decimal</param>
        ''' <returns>サイズ名</returns>
        Private Function GetSizeName(規格 As String, 縦 As Decimal, 横 As Decimal) As String
            Dim namePaperSize = _commonService.GetNameByCode(COMMON_NO.PAPER_SIZE, 規格, TypeGetName.FULLNAME)
            Dim paramサイズ名 As String = namePaperSize + "(" + NumberUtil.ConvertNumToStrFormat(縦, NumberFormat.FORMAT_NUMBER) _
                + "×" + NumberUtil.ConvertNumToStrFormat(横, NumberFormat.FORMAT_NUMBER) + ")"
            Return paramサイズ名
        End Function
        ''' <summary>                               
        ''' その他工程の情報を編集する。
        ''' </summary>
        ''' <param name="order8">受注その他Dto</param>
        ''' <returns>List(Of String)</returns>
        Private Function GetValueCSVOrderByKey8(order8 As 受注その他Dto) As List(Of String)
            Dim 内外区分名 = _commonService.GetNameByCode(COMMON_NO.IN_OUT_TYPE, order8.内外区分, TypeGetName.FULLNAME)
            Return New List(Of String)() From {
                       "その他", '1
                       order8.行番号,'2
                       If(内外区分名 Is Nothing, String.Empty, 内外区分名),'3
                       String.Empty,'4
                       String.Empty,'5
                       String.Empty,'6
                       String.Empty,'7
                       order8.作業,'8
                       order8.作業名,'9
                       String.Empty,'10
                       String.Empty,'11
                       String.Empty,'12
                       String.Empty,'13
                       String.Empty,'14
                       String.Empty,'15
                       String.Empty,'16
                       String.Empty,'17
                       String.Empty,'18
                       String.Empty,'19
                       String.Empty,'20
                       String.Empty,'21
                       String.Empty,'22
                       order8.数量,'23
                       String.Empty,'24
                       order8.数量,'25
                       order8.単価,'26
                       order8.金額,'27
                       If(order8.仕切単価 Is Nothing, String.Empty, order8.仕切単価),'28
                       If(order8.仕切金額 Is Nothing, String.Empty, order8.仕切金額)'29
                  }
        End Function
#End Region

    End Class
End Namespace
