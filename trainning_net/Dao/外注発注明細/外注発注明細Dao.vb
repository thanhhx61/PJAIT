Imports System.Text
Imports Entities
Imports Unity
Public Class 外注発注明細Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_外注発注明細)
    Public Function SelectPurchaseDetail1ByPurchaseNo(purchaseNo As String) As List(Of TPL_外注発注明細)
        Return _Repository._dbSet.Where(Function(x) x.発注番号 = purchaseNo).
              OrderBy(Function(x) x.行番号).Select(Function(x) x).ToList()
    End Function

End Class
