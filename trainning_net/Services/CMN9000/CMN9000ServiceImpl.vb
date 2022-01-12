Imports System.Text.RegularExpressions
Imports Core.ConstantCore.Consts
Imports Core.Util
Imports Dao
Imports Entities

Namespace Services
    Public Class CMN9000ServiceImpl
        Implements ICMN9000Service
        Public _TPL_コードDao As コードDao
        Public _TPL_取引先Dao As 取引先Dao
        Public _TPL_用紙Dao As 用紙Dao
        Public _TPL_受注基本Dao As 受注基本Dao
        Public _TPL_受注制作Dao As 受注制作Dao
        Public _TPL_受注製版Dao As 受注製版Dao
        Public _TPL_受注刷版Dao As 受注刷版Dao
        Public _TPL_受注印刷Dao As 受注印刷Dao
        Public _TPL_受注加工Dao As 受注加工Dao
        Public _TPL_受注用紙Dao As 受注用紙Dao
        Public _TPL_受注その他Dao As 受注その他Dao
        Public _TPL_受注スケジュールDao As 受注スケジュールDao
        Public _TPL_発注基本Dao As 発注基本Dao
        Public _TPL_外注発注明細Dao As 外注発注明細Dao
        Public _TPL_用紙発注明細Dao As 用紙発注明細Dao
        Public _TPL_外注仕入基本Dao As 外注仕入基本Dao
        Public _TPL_用紙仕入基本Dao As 用紙仕入基本Dao
        Public _TPL_外注仕入明細Dao As 外注仕入明細Dao
        Public _TPL_用紙仕入明細Dao As 用紙仕入明細Dao
        Public _TPL_売上基本Dao As 売上基本Dao
        Public _TPL_売上明細Dao As 売上明細Dao
        Public _TPL_自社Dao As 自社Dao
        Public _TPL_担当Dao As 担当Dao
        Public _TPL_買掛締Dao As 買掛締Dao
        Public _TPL_売掛締Dao As 売掛締Dao
        Public _TPL_請求締得意先Dao As 請求締得意先Dao
        Public _TPL_買掛締仕入先Dao As 買掛締仕入先Dao
        Public _TPL_請求締Dao As 請求締Dao

        Public Sub New(tPL_コードDao As コードDao, tPL_取引先Dao As 取引先Dao, tPL_用紙Dao As 用紙Dao,
                       tPL_受注基本Dao As 受注基本Dao, tPL_受注制作Dao As 受注制作Dao, tPL_受注製版Dao As 受注製版Dao,
                       tPL_受注刷版Dao As 受注刷版Dao, tPL_受注印刷Dao As 受注印刷Dao, tPL_受注加工Dao As 受注加工Dao,
                       tPL_受注用紙Dao As 受注用紙Dao, tPL_受注その他Dao As 受注その他Dao,
                       tPL_受注スケジュールDao As 受注スケジュールDao, tPL_発注基本Dao As 発注基本Dao,
                       tPL_外注発注明細Dao As 外注発注明細Dao, tPL_用紙発注明細Dao As 用紙発注明細Dao,
                       tPL_外注仕入基本Dao As 外注仕入基本Dao, tPL_用紙仕入基本Dao As 用紙仕入基本Dao,
                       tPL_外注仕入明細Dao As 外注仕入明細Dao, tPL_用紙仕入明細Dao As 用紙仕入明細Dao,
                       tPL_売上基本Dao As 売上基本Dao, tPL_売上明細Dao As 売上明細Dao,
                       tPL_自社Dao As 自社Dao, tPL_担当Dao As 担当Dao, tPL_買掛締Dao As 買掛締Dao,
                       tPL_売掛締Dao As 売掛締Dao, 請求締得意先Dao As 請求締得意先Dao, 買掛締仕入先Dao As 買掛締仕入先Dao,
                       請求締Dao As 請求締Dao)
            _TPL_コードDao = tPL_コードDao
            _TPL_取引先Dao = tPL_取引先Dao
            _TPL_用紙Dao = tPL_用紙Dao
            _TPL_受注基本Dao = tPL_受注基本Dao
            _TPL_受注制作Dao = tPL_受注制作Dao
            _TPL_受注製版Dao = tPL_受注製版Dao
            _TPL_受注刷版Dao = tPL_受注刷版Dao
            _TPL_受注印刷Dao = tPL_受注印刷Dao
            _TPL_受注加工Dao = tPL_受注加工Dao
            _TPL_受注用紙Dao = tPL_受注用紙Dao
            _TPL_受注その他Dao = tPL_受注その他Dao
            _TPL_受注スケジュールDao = tPL_受注スケジュールDao
            _TPL_発注基本Dao = tPL_発注基本Dao
            _TPL_外注発注明細Dao = tPL_外注発注明細Dao
            _TPL_用紙発注明細Dao = tPL_用紙発注明細Dao
            _TPL_外注仕入基本Dao = tPL_外注仕入基本Dao
            _TPL_用紙仕入基本Dao = tPL_用紙仕入基本Dao
            _TPL_外注仕入明細Dao = tPL_外注仕入明細Dao
            _TPL_用紙仕入明細Dao = tPL_用紙仕入明細Dao
            _TPL_売上基本Dao = tPL_売上基本Dao
            _TPL_売上明細Dao = tPL_売上明細Dao
            _TPL_自社Dao = tPL_自社Dao
            _TPL_担当Dao = tPL_担当Dao
            _TPL_買掛締Dao = tPL_買掛締Dao
            _TPL_売掛締Dao = tPL_売掛締Dao
            _TPL_請求締得意先Dao = 請求締得意先Dao
            _TPL_買掛締仕入先Dao = 買掛締仕入先Dao
            _TPL_請求締Dao = 請求締Dao
        End Sub

        Public Function GetNameByCode(key As String, code As String, typeGet As String) As String Implements ICMN9000Service.GetNameByCode
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(key) OrElse String.IsNullOrEmpty(code) OrElse String.IsNullOrEmpty(typeGet) OrElse
                (Not TypeGetName.FULLNAME.Equals(typeGet) AndAlso Not TypeGetName.SHORT_NAME.Equals(typeGet)) Then
                Return Nothing
            End If
            '2. マスタを検索する。
            Dim result = _TPL_コードDao.GetNameByCode(key, code)
            '3. 2.の取得結果を元に判定を行う。
            '3-1. 2.の取得結果が0件の場合、		
            If result Is Nothing Then
                Return Nothing
            End If
            '3-2. 上記以外の場合、
            If TypeGetName.FULLNAME.Equals(typeGet) Then
                Return result.名称
            End If
            Return result.略称
        End Function

        Public Function GetCodeByIdentifer(key As String, code As String) As List(Of コードDto) Implements ICMN9000Service.GetCodeByIdentifer
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(key) Then
                Return Nothing
            End If
            '2. マスタを検索する。
            Dim result = _TPL_コードDao.GetCodeByIdentifer(key, code)
            '3. 2.の取得結果を元に判定を行う。	
            '3-1. 2.の取得結果が0件の場合、
            If result.Count = 0 Then
                Return Nothing
            End If
            '3-2. 上記以外の場合、2.で取得した件数分、値をコードDaoに編集する。
            Return MapUtil(Of TPL_コード, コードDto).MapFromToList(result)
        End Function

        Public Function GetCustomerByCode(code As String, customerType As String, typeGet As String) As String Implements ICMN9000Service.GetCustomerByCode
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(code) OrElse String.IsNullOrEmpty(typeGet) OrElse
                (Not String.IsNullOrEmpty(customerType) AndAlso Not CUSTOMER_TYPE.CUSTOMER.Equals(customerType) AndAlso Not CUSTOMER_TYPE.SUPPLIER.Equals(customerType)) OrElse
                (Not TypeGetName.FULLNAME.Equals(typeGet) AndAlso Not TypeGetName.SHORT_NAME.Equals(typeGet)) Then
                Return Nothing
            End If
            '2. マスタを検索する。
            '3. 2.の取得結果を元に判定を行う。
            Return _TPL_取引先Dao.GetCustomerByCode(code, customerType, typeGet)
        End Function
        Public Function GetEmployeeByCode(code As String) As String Implements ICMN9000Service.GetEmployeeByCode
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(code) Then
                Return Nothing
            End If
            '2. マスタを検索する。
            '3. 2.の取得結果を元に判定を行う。
            '   戻り値 = 2.の取得結果.氏名
            Return _TPL_担当Dao.GetEmployeeByCode(code)
        End Function

        Public Function GetPaperByCode(code As String) As String Implements ICMN9000Service.GetPaperByCode
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(code) Then
                Return Nothing
            End If
            '2. マスタを検索する。
            '3. 2.の取得結果を元に判定を行う。
            '   戻り値 = 2.の取得結果.名称
            Return _TPL_用紙Dao.GetPaperByCode(code)
        End Function


        Public Function GetDepatureByCode(code As String, typeGet As String) As String Implements ICMN9000Service.GetDepatureByCode
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(code) OrElse String.IsNullOrEmpty(typeGet) OrElse
                (Not TypeGetName.FULLNAME.Equals(typeGet) AndAlso Not TypeGetName.SHORT_NAME.Equals(typeGet)) Then
                Return Nothing
            End If
            '2. マスタを検索する。
            Dim result = _TPL_コードDao.GetDepatureByCode(code)
            '3. 2.の取得結果を元に判定を行う。
            '3-1. 2.の取得結果が0件の場合、
            If result Is Nothing Then
                Return Nothing
            End If
            '3-2. 上記以外の場合、
            Dim nameVal As String

            If TypeGetName.FULLNAME.Equals(typeGet) Then
                '3-2-1. パラメタ.getType = "1"の場合、以下の戻り値を返す。戻り値 = 2.の取得結果.コード + "," +  2.の取得結果.名称
                nameVal = result.名称
            Else
                '3-2-2. パラメタ.getType = "2"の場合、以下の戻り値を返す。戻り値 = 2.の取得結果.コード + "," +  2.の取得結果.略称
                nameVal = result.略称
            End If
            Return String.Concat(result.コード, ",", nameVal)
        End Function


        Public Function GetOrderByKey1(orderNo As String) As 受注基本Dto Implements ICMN9000Service.GetOrderByKey1
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(orderNo) Then
                Return Nothing
            End If
            '2. 受注基本テーブルを検索する。
            Dim result = _TPL_受注基本Dao.GetOrderByKey1(orderNo)
            '3. 2.の取得結果を元に判定を行う。
            '3-1. 2.の取得結果が0件の場合、
            If (result Is Nothing) Then
                Return Nothing
            End If
            '3-2. 上記以外の場合、
            '   2. で取得した値をDaoに編集する。
            Return MapUtil(Of TPL_受注基本, 受注基本Dto).MapFromTo(result)
        End Function

        Public Function GetOrderByKey2(orderNo As String) As List(Of 受注制作Dto) Implements ICMN9000Service.GetOrderByKey2
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(orderNo) Then
                Return Nothing
            End If
            '2. 受注基本テーブルを検索する。
            Dim result = _TPL_受注制作Dao.GetOrderByKey2(orderNo)
            '3. 2.の取得結果を元に判定を行う。
            '3-1. 2.の取得結果が0件の場合、
            If (result.Count = 0) Then
                Return Nothing
            End If
            '3-2. 上記以外の場合、2.で取得した件数分、値をDaoに編集する。
            Return MapUtil(Of TPL_受注制作, 受注制作Dto).MapFromToList(result)
        End Function

        Public Function GetOrderByKey3(orderNo As String) As List(Of 受注製版Dto) Implements ICMN9000Service.GetOrderByKey3
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(orderNo) Then
                Return Nothing
            End If
            ''2. 受注基本テーブルを検索する。
            Dim result = _TPL_受注製版Dao.GetOrderByKey3(orderNo)
            '3. 2.の取得結果を元に判定を行う。
            '3-1. 2.の取得結果が0件の場合、
            If (result.Count = 0) Then
                Return Nothing
            End If
            '3-2. 上記以外の場合、2.で取得した件数分、値をDaoに編集する。
            Return MapUtil(Of TPL_受注製版, 受注製版Dto).MapFromToList(result)
        End Function

        Public Function GetOrderByKey4(orderNo As String) As List(Of 受注刷版Dto) Implements ICMN9000Service.GetOrderByKey4
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(orderNo) Then
                Return Nothing
            End If
            '2. 受注基本テーブルを検索する。
            Dim result = _TPL_受注刷版Dao.GetOrderByKey4(orderNo)
            '3. 2.の取得結果を元に判定を行う。
            '3-1. 2.の取得結果が0件の場合、
            If (result.Count = 0) Then
                Return Nothing
            End If
            '3-2. 上記以外の場合、2.で取得した件数分、値をDaoに編集する。
            Return MapUtil(Of TPL_受注刷版, 受注刷版Dto).MapFromToList(result)
        End Function

        Public Function GetOrderByKey5(orderNo As String) As List(Of 受注印刷Dto) Implements ICMN9000Service.GetOrderByKey5
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(orderNo) Then
                Return Nothing
            End If
            '2. 受注基本テーブルを検索する。
            Dim result = _TPL_受注印刷Dao.GetOrderByKey5(orderNo)
            '3. 2.の取得結果を元に判定を行う。
            '3-1. 2.の取得結果が0件の場合、
            If (result.Count = 0) Then
                Return Nothing
            End If
            '3-2. 上記以外の場合、2.で取得した件数分、値をDaoに編集する。
            Return MapUtil(Of TPL_受注印刷, 受注印刷Dto).MapFromToList(result)
        End Function

        Public Function GetOrderByKey6(orderNo As String) As List(Of 受注加工Dto) Implements ICMN9000Service.GetOrderByKey6
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(orderNo) Then
                Return Nothing
            End If
            '2. 受注基本テーブルを検索する。
            Dim result = _TPL_受注加工Dao.GetOrderByKey6(orderNo)
            '3. 2.の取得結果を元に判定を行う。
            '3-1. 2.の取得結果が0件の場合、
            If (result.Count = 0) Then
                Return Nothing
            End If
            '3-2. 上記以外の場合、2.で取得した件数分、値をDaoに編集する。
            Return MapUtil(Of TPL_受注加工, 受注加工Dto).MapFromToList(result)
        End Function

        Public Function GetOrderByKey7(orderNo As String) As List(Of 受注用紙Dto) Implements ICMN9000Service.GetOrderByKey7
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(orderNo) Then
                Return Nothing
            End If
            '2. 受注基本テーブルを検索する。
            Dim result = _TPL_受注用紙Dao.GetOrderByKey7(orderNo)
            '3. 2.の取得結果を元に判定を行う。
            '3-1. 2.の取得結果が0件の場合、
            If (result.Count = 0) Then
                Return Nothing
            End If
            '3-2. 上記以外の場合、2.で取得した件数分、値をDaoに編集する。
            Return MapUtil(Of TPL_受注用紙, 受注用紙Dto).MapFromToList(result)
        End Function

        Public Function GetOrderByKey8(orderNo As String) As List(Of 受注その他Dto) Implements ICMN9000Service.GetOrderByKey8
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(orderNo) Then
                Return Nothing
            End If
            '2. 受注基本テーブルを検索する。
            Dim result = _TPL_受注その他Dao.GetOrderByKey8(orderNo)
            '3. 2.の取得結果を元に判定を行う。
            '3-1. 2.の取得結果が0件の場合
            If (result.Count = 0) Then
                Return Nothing
            End If
            '3-2. 上記以外の場合、2.で取得した件数分、値をDaoに編集する。
            Return MapUtil(Of TPL_受注その他, 受注その他Dto).MapFromToList(result)
        End Function

        Public Function GetOrderItemByKey(orderNo As String) As String Implements ICMN9000Service.GetOrderItemByKey
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(orderNo) Then
                Return Nothing
            End If
            '2. 受注基本テーブルを検索する。
            '3. 2.の取得結果を元に判定を行う。
            Return _TPL_受注基本Dao.GetOrderItemByKey(orderNo)
        End Function

        Public Function GetScheduleByKey(orderNo As String) As 受注スケジュールDto Implements ICMN9000Service.GetScheduleByKey
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(orderNo) Then
                Return Nothing
            End If
            '2. 受注スケジュールテーブルを検索する。
            Dim result = _TPL_受注スケジュールDao.GetScheduleByKey(orderNo)
            '3. 2.の取得結果を元に判定を行う。
            '3-1. 2.の取得結果が0件の場合、
            If (result Is Nothing) Then
                Return Nothing
            End If
            '3-2. 上記以外の場合、2. で取得した値を受注スケジュールDaoに編集する。
            Return MapUtil(Of TPL_受注スケジュール, 受注スケジュールDto).MapFromTo(result)
        End Function


        Public Function GetPaymentDateByCode2(code As String, targetDate As Date?, typeGet As String) As Date? Implements ICMN9000Service.GetPaymentDateByCode2
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(code) OrElse targetDate Is Nothing OrElse String.IsNullOrEmpty(typeGet) OrElse
                (Not PaymentDateType.COLLECT_DATE.Equals(typeGet) AndAlso Not PaymentDateType.PAYMENT_DATE.Equals(typeGet)) Then
                Return Nothing
            End If
            '2. マスタを検索する。
            Dim result = _TPL_取引先Dao.GetPaymentDateByCode2(code, typeGet)
            '3. 2.の取得結果を元に判定を行う。
            '3-1. 2.の取得結果が0件もしくは、数字１がNULLの場合、
            If result Is Nothing OrElse String.IsNullOrEmpty(result.加算月) Then
                Return Nothing
            End If
            '3-2. 上記以外の場合、
            '3-2-2. 月を計算し、変数.計算日付に格納する。
            Dim 計算日付 = targetDate.GetValueOrDefault().AddMonths(result.加算月)
            Dim 計算日付DaysInMonth = Date.DaysInMonth(計算日付.Year, 計算日付.Month)
            If result.日 > 計算日付DaysInMonth Then
                '3-2-3. 日を計算する。
                計算日付 = New Date(計算日付.Year, 計算日付.Month, 計算日付DaysInMonth)
            Else
                '3-2-4. 戻り値を戻り値を返す。
                計算日付 = New Date(計算日付.Year, 計算日付.Month, result.日)
            End If

            Return 計算日付.ToString(DateFormat.YYYYMMDD)
        End Function

        Public Function GetTaxRateByDate(targetDate As Date?) As String Implements ICMN9000Service.GetTaxRateByDate
            '1. 引数の妥当性検証
            If targetDate Is Nothing Then
                Return Nothing
            End If
            '2. マスタを検索する。
            '3. 2.の取得結果を元に判定を行う。
            Return _TPL_コードDao.GetTaxRateByDate(targetDate)
        End Function


        Public Function GetRoundValue(number As Decimal?, numberOfDigits As Integer?, fractionType As String) As Decimal? Implements ICMN9000Service.GetRoundValue
            '1. 引数の妥当性検証
            If (fractionType <> TAX_FRACTION.ROUND And fractionType <> TAX_FRACTION.ROUND_DOWN And fractionType <> TAX_FRACTION.ROUND_UP) OrElse (number Is Nothing) OrElse (numberOfDigits Is Nothing) Then
                Return Nothing
            End If
            Dim sign = If(number.GetValueOrDefault() > 0, 1, -1)
            Dim 計算結果 = Math.Abs(number.GetValueOrDefault())
            Dim 端数処理桁 = 1
            If (Int(numberOfDigits) > 0) Then
                端数処理桁 = Math.Pow(10, numberOfDigits.GetValueOrDefault())
            End If
            Select Case fractionType
                Case TAX_FRACTION.ROUND
                    '4-1. パラメタ.fractionType = '0001'(四捨五入)の場合、
                    Return Math.Round(計算結果, numberOfDigits.GetValueOrDefault(), MidpointRounding.AwayFromZero) * sign
                Case TAX_FRACTION.ROUND_DOWN
                    '4-2. パラメタ.fractionType = '0002'(切捨て)の場合、
                    Return (Math.Floor(計算結果 * 端数処理桁) / 端数処理桁) * sign
                Case TAX_FRACTION.ROUND_UP
                    Return (Math.Ceiling(計算結果 * 端数処理桁) / 端数処理桁) * sign
                Case Else
                    Return Nothing
            End Select
        End Function


        Public Function ModFullWidthKana(character As String) As String Implements ICMN9000Service.ModFullWidthKana
            '戻り値をNULLとして、処理を終了する。
            If String.IsNullOrEmpty(character) Then
                Return Nothing
            End If
            Dim res = Regex.Replace(character, RegexType.HANKAKU_KANA_PTTERN,
                                        Function(in_match As Match) As String
                                            ' 切り出した半角カナ部分を全角カナに変換	
                                            Return StrConv(in_match.ToString, VbStrConv.Wide)
                                        End Function
                                    )
            Return res
        End Function

        Public Function GetTaskIndentifer(task As String) As String Implements ICMN9000Service.GetTaskIndentifer
            If PROCESS.TASK_0001.Equals(task) Then
                Return COMMON_NO.TASK_PRODUCTION
            ElseIf PROCESS.TASK_0002.Equals(task) Then
                Return COMMON_NO.TASK_PLATE_MAKING
            ElseIf PROCESS.TASK_0003.Equals(task) Then
                Return COMMON_NO.TASK_PRINTING_PLATE
            ElseIf PROCESS.TASK_0004.Equals(task) Then
                Return COMMON_NO.MODEL
            ElseIf PROCESS.TASK_0005.Equals(task) Then
                Return COMMON_NO.TASK_PROCESSING
            ElseIf PROCESS.TASK_0006.Equals(task) Then
                Return String.Empty
            ElseIf PROCESS.TASK_0007.Equals(task) Then
                Return COMMON_NO.TASK_ETC
            Else
                Return Nothing
            End If
        End Function

        Public Function CalcMultiplication(number1 As Decimal?, number2 As Decimal?,
                                           fractionType As String, decimalPoint As Integer?,
                                           maxDigits As Integer?) As Decimal? Implements ICMN9000Service.CalcMultiplication
            '1. 引数の妥当性検証
            If Not number1.HasValue OrElse Not number2.HasValue Then
                Return Nothing
            End If
            If String.IsNullOrEmpty(fractionType) OrElse Not (TAX_FRACTION.ROUND.Equals(fractionType) OrElse
                TAX_FRACTION.ROUND_DOWN.Equals(fractionType) OrElse
                TAX_FRACTION.ROUND_UP.Equals(fractionType)) Then
                Return Nothing
            End If
            If Not decimalPoint.HasValue OrElse decimalPoint < 0 Then
                Return Nothing
            End If
            If Not maxDigits.HasValue OrElse maxDigits < 0 Then
                Return Nothing
            End If
            '2. 掛け算を行う。
            'パラメタ.計算結果 = number1 * number2
            Dim calResult As Decimal = number1 * number2
            '3. 端数処理が切捨て・切上げの場合に、パラメタを編集する。		
            Dim roundDigits As Integer
            '3-1. パラメタ.fractionType = '0002','0003'の場合に以下の処理を行う。		
            If TAX_FRACTION.ROUND_DOWN.Equals(fractionType) OrElse TAX_FRACTION.ROUND_UP.Equals(fractionType) Then
                '3-1-1. パラメタ.decimalPoint - 1の値だけ0を編集する。				
                '3-1-2. 3-1-1.で編集したパラメタに1を付与する。
                '3-1-3. 3-1-2.で編集した値を「パラメタ.端数処理桁」に編集する。
                roundDigits = If(decimalPoint = 0, 1, 10 ^ decimalPoint)
            End If

            '4. 丸め処理を行う。			
            '4-1. パラメタ.fractionType = '0001'(四捨五入)の場合、		
            If TAX_FRACTION.ROUND.Equals(fractionType) Then
                calResult = Math.Round(calResult, decimalPoint.Value, MidpointRounding.AwayFromZero)
            ElseIf TAX_FRACTION.ROUND_DOWN.Equals(fractionType) Then '4-2. パラメタ.fractionType = '0002'(切捨て)の場合、		
                calResult = Math.Floor(calResult * roundDigits) / roundDigits
            ElseIf TAX_FRACTION.ROUND_UP.Equals(fractionType) Then '4-3. パラメタ.fractionType = '0003'(切上げ)の場合、
                calResult = Math.Ceiling(calResult * roundDigits) / roundDigits
            End If

            '5. 計算結果を戻り値として返す。			
            '5-1. 4.計算結果の桁数 > パラメタ.maxDigits の場合、桁数超過とみなす。		
            If calResult.ToString.Replace(".", String.Empty).Length > maxDigits Then
                Return 0
            End If
            '5-2. 上記以外の場合、	
            Return calResult
        End Function


    End Class
End Namespace
