Imports System.Text
Imports Entities
Imports Unity
Public Class 用紙発注明細Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_用紙発注明細)
    Public Function SelectPurchaseDetail2ByPurchaseNo(purchaseNo As String) As List(Of TPL_用紙発注明細)
        Return _Repository._dbSet.Where(Function(x) x.発注番号 = purchaseNo).
              OrderBy(Function(x) x.行番号).Select(Function(x) x).ToList()
    End Function


End Class
