Imports Dao

Namespace Services
    ''' <summary>
    ''' 共通関数
    ''' </summary>
    Public Interface ICMN9000Service

        ''' <summary>
        ''' コードを検索条件に、データ検索を行う。名称・略称のどちらを取得するかParamで指定する。
        ''' </summary>
        ''' <param name="key">コード.識別</param>
        ''' <param name="code">コード.コード</param>
        ''' <param name="typeGet">1：名称、2：略称</param>
        ''' <returns></returns>
        Function GetNameByCode(key As String, code As String, typeGet As String) As String

        ''' <summary>
        ''' 識別を検索条件に、データ検索を行う。
        ''' </summary>
        ''' <param name="key">コード.識別</param>
        ''' <param name="code">コード.コード</param>
        ''' <returns></returns>
        Function GetCodeByIdentifer(key As String, code As String) As List(Of コードDto)

        ''' <summary>
        ''' 識別を検索条件に、データ検索を行う。
        ''' </summary>
        ''' <param name="code">取引先</param>
        ''' <param name="customerType">1：得意先、2：仕入先</param>
        ''' <param name="typeGet">1：名称、2：略称</param>
        ''' <returns>String</returns>
        Function GetCustomerByCode(code As String, customerType As String, typeGet As String) As String



        ''' <summary>
        ''' 担当を元に担当名を取得する。
        ''' </summary>
        ''' <param name="code">担当</param>
        ''' <returns></returns>
        Function GetEmployeeByCode(code As String) As String

        ''' <summary>
        ''' 銘柄を元に銘柄名を取得する。
        ''' </summary>
        ''' <param name="code">銘柄</param>
        ''' <returns></returns>
        Function GetPaperByCode(code As String) As String



        ''' <summary>
        ''' 担当を検索条件に、部署のデータ検索を行う。戻り値としてコード + 名称または略称を返す。
        ''' </summary>
        ''' <param name="code">担当</param>
        ''' <param name="typeGet">1：名称、2：略称</param>
        ''' <returns></returns>
        Function GetDepatureByCode(code As String, typeGet As String) As String


        ''' <summary>
        ''' 受注番号を元に、受注情報を取得する。
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns></returns>
        Function GetOrderByKey1(orderNo As String) As 受注基本Dto

        ''' <summary>
        ''' 受注番号を元に、受注-制作を取得する。
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns></returns>
        Function GetOrderByKey2(orderNo As String) As List(Of 受注制作Dto)

        ''' <summary>
        ''' 受注番号を元に、受注-製版を取得する。
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns></returns>
        Function GetOrderByKey3(orderNo As String) As List(Of 受注製版Dto)

        ''' <summary>
        ''' 受注番号を元に、受注-刷版を取得する。
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns></returns>
        Function GetOrderByKey4(orderNo As String) As List(Of 受注刷版Dto)

        ''' <summary>
        ''' 受注番号を元に、受注-印刷を取得する。
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns></returns>
        Function GetOrderByKey5(orderNo As String) As List(Of 受注印刷Dto)

        ''' <summary>
        ''' 受注番号を元に、受注-加工を取得する。
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns></returns>
        Function GetOrderByKey6(orderNo As String) As List(Of 受注加工Dto)

        ''' <summary>
        ''' 受注番号を元に、受注-用紙を取得する。
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns></returns>
        Function GetOrderByKey7(orderNo As String) As List(Of 受注用紙Dto)

        ''' <summary>
        ''' 受注番号を元に、受注-その他を取得する。
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns></returns>
        Function GetOrderByKey8(orderNo As String) As List(Of 受注その他Dto)

        ''' <summary>
        ''' 受注番号を元に、受注情報の品名を取得する。
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns></returns>
        Function GetOrderItemByKey(orderNo As String) As String

        ''' <summary>
        ''' 受注番号を元に、受注スケジュールを取得する。
        ''' </summary>
        ''' <param name="orderNo">受注番号</param>
        ''' <returns></returns>
        Function GetScheduleByKey(orderNo As String) As 受注スケジュールDto

        '
        ''' <summary>
        ''' 取引先を検索条件に、データ検索を行う。取引先の回収日または支払日を加味した日付を返す(例：2021/05/31)
        ''' </summary>
        ''' <param name="code">取引先</param>
        ''' <param name="targetDate">日付</param>
        ''' <param name="typeGet">0：回収日、1：支払日</param>
        ''' <returns></returns>
        Function GetPaymentDateByCode2(code As String, targetDate As Date?, typeGet As String) As Date?

        ''' <summary>
        ''' 日付を元に税率を取得する。
        ''' </summary>
        ''' <param name="targetDate">日付</param>
        ''' <returns>コード</returns>
        Function GetTaxRateByDate(targetDate As Date?) As String

        ''' <summary>
        ''' 引数の値を丸め処理して、戻り値を返す。丸め処理する対象桁も引数で指定する。
        ''' </summary>
        ''' <param name="number">数値</param>
        ''' <param name="numberOfDigits">丸め処理する桁数(例：小数点第1位の場合は[1]、10の位の場合は[-1])</param>
        ''' <param name="fractionType">端数処理区分(0001：四捨五入、0002：切捨て、0003：切上げ)</param>
        ''' <returns></returns>
        Function GetRoundValue(number As Decimal?, numberOfDigits As Integer?, fractionType As String) As Decimal?

        ''' <summary>
        ''' Paramを全角カナに置換する。
        ''' </summary>
        ''' <param name="character">置換対象の文字列</param>
        ''' <returns></returns>
        Function ModFullWidthKana(character As String) As String

        ''' <summary>
        ''' 各工程ごとの作業の識別を取得する。
        ''' </summary>
        ''' <param name="task">工程</param>
        ''' <returns>識別</returns>
        Function GetTaskIndentifer(task As String) As String

        ''' <summary>
        ''' 引数を掛け算し、戻り値を返す。(正数での端数処理は想定しない)
        ''' </summary>
        ''' <param name="number1">数値</param>
        ''' <param name="number2">数値</param>
        ''' <param name="fractionType">端数処理区分(0001:四捨五入、0002:切捨て、0003：切上げ)</param>
        ''' <param name="decimalPoint">端数処理を行う小数点桁</param>
        ''' <param name="maxDigits">最大桁数</param>
        ''' <returns></returns>
        Function CalcMultiplication(number1 As Decimal?, number2 As Decimal?, fractionType As String,
                                    decimalPoint As Integer?, maxDigits As Integer?) As Decimal?


    End Interface
End Namespace