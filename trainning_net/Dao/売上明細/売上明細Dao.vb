Imports System.Text
Imports Entities
Imports Unity
Public Class 売上明細Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_売上明細)

    Public Function SelectSaleDetailBySaleNo(saleNo As String) As List(Of TPL_売上明細)
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT ")
        sql.AppendLine("   売上明細.* ")
        sql.AppendLine(" FROM ")
        sql.AppendLine("   売上基本 ")
        sql.AppendLine("   INNER JOIN 売上明細 ")
        sql.AppendLine("    ON 売上基本.売上番号 = 売上明細.売上番号 ")
        sql.AppendLine(" WHERE ")
        sql.AppendLine("   売上明細.売上番号 = :saleNo ")
        sql.AppendLine("   AND 売上基本.削除フラグ = false ")
        sql.AppendLine(" ORDER BY ")
        sql.AppendLine("   売上明細.売上番号 ")
        sql.AppendLine("   , 売上明細.内訳番号 ")

        Return _Repository.Selects(Of TPL_売上明細)(sql.ToString(), New With {.saleNo = saleNo}).ToList()
    End Function

    Public Function SelectSaleDetailByNo(orderNo As String) As List(Of TPL_売上明細)
        Dim sql = New StringBuilder()
        sql.AppendLine("SELECT ")
        sql.AppendLine("  売上明細.* ")
        sql.AppendLine("FROM")
        sql.AppendLine("  売上基本 ")
        sql.AppendLine("  INNER JOIN 売上明細 ")
        sql.AppendLine("    ON 売上基本.売上番号 = 売上明細.売上番号 ")
        sql.AppendLine("WHERE ")
        sql.AppendLine("  売上基本.受注番号 = :orderNo ")
        sql.AppendLine("  AND 売上基本.削除フラグ = false ")
        sql.AppendLine("ORDER BY ")
        sql.AppendLine("  売上明細.売上番号 ")
        sql.AppendLine("  , 売上明細.内訳番号 ")

        Return _Repository.Selects(Of TPL_売上明細)(sql.ToString(), New With {.orderNo = orderNo}).ToList()
    End Function

End Class
