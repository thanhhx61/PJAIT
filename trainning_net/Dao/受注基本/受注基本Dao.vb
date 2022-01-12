Imports System.Text
Imports Entities
Imports Unity
Public Class 受注基本Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_受注基本)
    ''' <summary>
    ''' GetOrderByKey1
    ''' </summary>
    ''' <param name="orderNo">受注番号</param>
    ''' <returns>TPL_受注基本</returns>
    Public Function GetOrderByKey1(orderNo As String) As TPL_受注基本
        Return _Repository._dbSet.FirstOrDefault(Function(a) a.受注番号 = orderNo And a.削除フラグ = False)
    End Function
    ''' <summary>
    ''' GetOrderItemByKey
    ''' </summary>
    ''' <param name="orderNo">受注番号</param>
    ''' <returns>String</returns>
    Public Function GetOrderItemByKey(orderNo As String) As String
        Return _Repository._dbSet.Where(Function(a) a.受注番号 = orderNo And a.削除フラグ = False).Select(Function(a) a.品名).FirstOrDefault()
    End Function

    ''' <summary>
    ''' TPL01040 受注検索処理 - Pagination
    ''' </summary>
    ''' <param name="request">PaginationRequestDto(Of SearchOrderParamDto)</param>
    ''' <returns>PanigationResultDto(Of SearchOrderResultDto)</returns>
    Public Function GetOrderPagedList(request As PaginationRequestDto(Of SearchOrderParamDto)) As PanigationResultDto(Of SearchOrderResultDto)
        Dim param = request.Param
        Dim sql = GetQuerySelectOrder(param)
        Return _Repository.SelectByPagination(Of SearchOrderParamDto, SearchOrderResultDto)(sql.ToString(), request)
    End Function

    ''' <summary>
    ''' TPL01040 受注検索処理 
    ''' </summary>
    ''' <param name="param">SearchOrderParamDto</param>
    ''' <returns>List(Of SearchOrderResultDto)</returns>
    Public Function GetOrderList(param As SearchOrderParamDto) As List(Of SearchOrderResultDto)
        Dim sql = GetQuerySelectOrder(param)
        Return _Repository.Selects(Of SearchOrderResultDto)(sql.ToString(), param)
    End Function

    ''' <summary>
    ''' 売上ボタンクリック時 - 2. 各工程の内外区分のチェックを行う。
    ''' </summary>
    ''' <param name="param">string</param>
    ''' <returns>List(Of 受注番号)</returns>
    Public Function GetListOrderSales(param As String) As List(Of String)
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT 受注番号 FROM 受注制作 WHERE 受注番号 = :OrderNo AND 内外区分 = '0003' ")
        sql.AppendLine(" UNION ")
        sql.AppendLine(" SELECT 受注番号 FROM 受注製版 WHERE 受注番号 = :OrderNo AND 内外区分 = '0003' ")
        sql.AppendLine(" UNION ")
        sql.AppendLine(" SELECT 受注番号 FROM 受注刷版 WHERE 受注番号 = :OrderNo AND 内外区分 = '0003' ")
        sql.AppendLine(" UNION ")
        sql.AppendLine(" SELECT 受注番号 FROM 受注印刷 WHERE 受注番号 = :OrderNo AND 内外区分 = '0003' ")
        sql.AppendLine(" UNION ")
        sql.AppendLine(" SELECT 受注番号 FROM 受注加工 WHERE 受注番号 = :OrderNo AND 内外区分 = '0003' ")
        sql.AppendLine(" UNION ")
        sql.AppendLine(" SELECT 受注番号 FROM 受注用紙 WHERE 受注番号 = :OrderNo AND 当先区分 = '0003' ")
        sql.AppendLine(" UNION ")
        sql.AppendLine(" SELECT 受注番号 FROM 受注その他 WHERE 受注番号 = :OrderNo AND 内外区分 = '0003' ")

        Return _Repository.Selects(Of String)(sql.ToString(), New With {.OrderNo = param})
    End Function

    ''' <summary>
    ''' Get query select order
    ''' </summary>
    ''' <param name="param">SearchOrderParamDto</param>
    ''' <returns>Query select order</returns>
    Private Function GetQuerySelectOrder(param As SearchOrderParamDto) As StringBuilder
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT ")
        sql.AppendLine(" A.受注番号 as 受注番号, ")
        sql.AppendLine(" A.得意先名 as 得意先名, ")
        sql.AppendLine(" A.品名 as 品名, ")
        sql.AppendLine(" A.受注数量 as 受注数量, ")
        sql.AppendLine(" A.受注単価 as 受注単価, ")
        sql.AppendLine(" A.受注金額 as 受注金額, ")
        sql.AppendLine(" A.受注日 as 受注日, ")
        sql.AppendLine(" A.納品日 as 納品日, ")
        sql.AppendLine(" A.検収日 as 検収日, ")
        sql.AppendLine(" (SELECT COALESCE(SUM(売上基本.売上金額),0 ) FROM 売上基本 ")
        sql.AppendLine("    WHERE 売上基本.受注番号 = A.受注番号")
        sql.AppendLine("    AND 売上基本.削除フラグ = false ) AS 売上金額 ")
        sql.AppendLine(" FROM 受注基本 A")
        sql.AppendLine(" WHERE 1 = 1 ")
        If (Not String.IsNullOrEmpty(param.OrderNo)) Then
            sql.AppendLine(" AND A.受注番号 = :OrderNo")
        End If
        If (Not String.IsNullOrEmpty(param.ProductType)) Then
            sql.AppendLine(" AND A.製品種別 = :ProductType")
        End If
        sql.AppendLine(" AND A.受注日 >= :StartDate")
        sql.AppendLine(" AND A.受注日 <= :EndDate")
        If (Not String.IsNullOrEmpty(param.ProductName)) Then
            sql.AppendLine(" AND A.品名 LIKE '%' || :ProductName ||'%' ")
        End If
        If (Not String.IsNullOrEmpty(param.ProductRemark)) Then
            sql.AppendLine(" AND A.品名備考 LIKE '%' || :ProductRemark ||'%' ")
        End If
        If (Not String.IsNullOrEmpty(param.Employee)) Then
            sql.AppendLine(" AND A.担当名 LIKE '%' || :Employee ||'%' ")
        End If
        If "on".Equals(param.IsAnyOrderBacklog) Then
            sql.AppendLine(" AND A.受注金額 >  (SELECT COALESCE(SUM(売上基本.売上金額),0 ) FROM 売上基本 ")
            sql.AppendLine("    WHERE 売上基本.受注番号 = A.受注番号")
            sql.AppendLine("    AND 売上基本.削除フラグ = false ) ")
        End If
        sql.AppendLine(" AND A.削除フラグ = false ")
        Return sql
    End Function


    ''' <summary>
    ''' 受注メモ更新処理
    ''' </summary>
    ''' <param name="model">受注基本Dto</param>
    ''' <returns>更新件数</returns>
    Public Function UpdateOrderMemoBy受注番号And更新回数(model As 受注基本Dto, log As LogInfoDto) As Integer
        Dim sql As StringBuilder = New StringBuilder()
        sql.AppendLine(" UPDATE 受注基本 ")
        sql.AppendLine(" SET ")
        sql.AppendLine(" 	メモ1 = :メモ1 ")
        sql.AppendLine("   , メモ2 = :メモ2 ")
        sql.AppendLine("   , メモ3 = :メモ3 ")
        sql.AppendLine("   , メモ4 = :メモ4 ")
        sql.AppendLine("   , メモ5 = :メモ5 ")
        sql.AppendLine("   , メモ6 = :メモ6 ")
        sql.AppendLine("   , メモ7 = :メモ7 ")
        sql.AppendLine("   , メモ8 = :メモ8 ")
        sql.AppendLine("   , メモ9 = :メモ9 ")
        sql.AppendLine("   , メモ10 = :メモ10 ")
        sql.AppendLine("   , 更新日 = :更新日 ")
        sql.AppendLine("   , 更新者 = :更新者 ")
        sql.AppendLine(" WHERE ")
        sql.AppendLine("   受注番号 = :受注番号 ")
        sql.AppendLine("   AND 更新回数 = :更新回数 ")

        Dim param As Object = New With {
        .メモ1 = model.メモ1,
        .メモ2 = model.メモ2,
        .メモ3 = model.メモ3,
        .メモ4 = model.メモ4,
        .メモ5 = model.メモ5,
        .メモ6 = model.メモ6,
        .メモ7 = model.メモ7,
        .メモ8 = model.メモ8,
        .メモ9 = model.メモ9,
        .メモ10 = model.メモ10,
        .更新日 = model.更新日,
        .更新者 = model.更新者,
        .受注番号 = model.受注番号,
        .更新回数 = model.更新回数
        }

        Return _Repository.UpdateByQuery(sql.ToString(), param, log)
    End Function
End Class
