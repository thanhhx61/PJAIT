Imports System.Text
Imports Core.ConstantCore.Consts
Imports Entities
Imports Unity

Public Class 取引先Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_取引先)

    Public Function GetCustomerByCode(code As String, customerType As String, typeGet As String) As String
        Dim result As IQueryable(Of TPL_取引先)
        If String.IsNullOrEmpty(customerType) Then
            result = _Repository._dbSet.Where(Function(a) a.取引先 = code And a.削除フラグ = False)
        Else
            result = _Repository._dbSet.Where(Function(a) a.取引先 = code And a.取引先区分 = customerType And a.削除フラグ = False)
        End If

        '3-2. 上記以外の場合、
        '3-2-1. パラメタ.getType = "0"の場合、以下の戻り値を返す。戻り値 = 2.の取得結果.名称
        '3-2-2. パラメタ.getType = "1"の場合、以下の戻り値を返す。戻り値 = 2.の取得結果.略称
        Return If(typeGet = "0", result.Select(Function(x) x.名称).FirstOrDefault(), result.Select(Function(x) x.略称).FirstOrDefault())
    End Function

    Public Function GetCustomerByCode2(code As String, customerType As String) As TPL_取引先
        Return _Repository._dbSet.Where(Function(a) a.取引先 = code And a.取引先区分 = customerType And a.削除フラグ = False).FirstOrDefault()
    End Function

    Public Function GetInvoiceDateByCode(code As String) As String
        Return _Repository._dbSet.Where(Function(a) a.取引先 = code And a.削除フラグ = False).Select(Function(a) a.請求締日).FirstOrDefault()
    End Function

    Public Function GetPaymentDateByCode(code As String, typeGet As String) As String
        Dim sql = New StringBuilder()
        Dim fieldSelect = If(typeGet = PaymentDateType.COLLECT_DATE, "回収日_日", "支払日_日")
        Dim identiferCondition = If(typeGet = PaymentDateType.COLLECT_DATE, "1002", "1003")

        sql.AppendLine($" SELECT B.略称 || (CASE A.{fieldSelect} WHEN '31' THEN '末' ELSE A.{fieldSelect} END) || '日' ")
        sql.AppendLine(" FROM 取引先 A ")
        sql.AppendLine(" LEFT JOIN コード B ")
        sql.AppendLine(" ON A.回収日_月 = B.コード ")
        sql.AppendLine($" AND B.識別 = '{identiferCondition}' ")
        sql.AppendLine(" AND B.削除フラグ = false ")
        sql.AppendLine(" WHERE A.削除フラグ = false ")
        sql.AppendLine(" AND A.取引先 = :code ")
        Return _Repository.Selects(Of String)(sql.ToString(), New With {.code = code}).FirstOrDefault()
    End Function

    Public Function GetPaymentDateByCode2(code As String, typeGet As String) As PaymentDateDto
        Dim fieldSelect = If(typeGet = PaymentDateType.COLLECT_DATE, "回収日_日", "支払日_日")
        Dim identiferCondition = If(typeGet = PaymentDateType.COLLECT_DATE, "1002", "1003")
        Dim sql = New StringBuilder()
        sql.AppendLine($" SELECT B.数字１ as 加算月 , A.{fieldSelect} as 日 ")
        sql.AppendLine(" FROM 取引先 A ")
        sql.AppendLine(" LEFT JOIN コード B ")
        sql.AppendLine(" ON A.取引先 = :code ")
        sql.AppendLine(" AND A.回収日_月 = B.コード ")
        sql.AppendLine($" AND B.識別 = '{identiferCondition}' ")
        sql.AppendLine(" AND B.削除フラグ = false ")
        sql.AppendLine(" WHERE A.取引先 = :code ")
        sql.AppendLine(" AND A.削除フラグ = false ")
        Return _Repository.Selects(Of PaymentDateDto)(sql.ToString(), New With {.code = code}).FirstOrDefault()
    End Function

    Public Function CalcManeyAddTax(code As String) As String
        Return _Repository._dbSet.Where(Function(a) a.取引先 = code).Select(Function(a) a.税端数処理).FirstOrDefault()
    End Function
    Public Function GetCustomerByTypeAndNameOrYomiPagedList(request As PaginationRequestDto(Of SearchCustomerParamDto)) As PanigationResultDto(Of TPL_取引先)
        Dim param = request.Param
        Dim sql = New StringBuilder()
        sql.AppendLine("SELECT * FROM 取引先 ")
        sql.AppendLine(" WHERE 取引先.取引先区分 = :customerType ")
        sql.AppendLine(" AND ( 取引先.名称 LIKE '%' || :nameOrYomi ||'%'  OR  取引先.よみ LIKE '%' || :nameOrYomi ||'%' )")
        sql.AppendLine(" AND  削除フラグ = false ")
        sql.AppendLine(" ORDER BY よみ, 名称, 支店名 ")
        Return _Repository.SelectByPagination(Of SearchCustomerParamDto, TPL_取引先)(sql.ToString(), request)
    End Function

End Class
