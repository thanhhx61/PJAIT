Imports Entities
Imports Unity
Public Class 発注基本Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_発注基本)
    Public Function SelectPurchase2ByOrderNo(orderNo As String) As List(Of TPL_発注基本)
        Return _Repository._dbSet.Where(Function(x) x.受注番号 = orderNo AndAlso x.削除フラグ = False).
              OrderBy(Function(x) x.発注番号).Select(Function(x) x).ToList()
    End Function

    Public Function SelectPurchaseByOrderNo(purchaseNo As String) As TPL_発注基本
        Return _Repository._dbSet.Where(Function(x) x.発注番号 = purchaseNo AndAlso x.削除フラグ = False).Select(Function(x) x).FirstOrDefault()
    End Function
End Class
