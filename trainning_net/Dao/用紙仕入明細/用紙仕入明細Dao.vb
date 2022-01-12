Imports Entities
Imports Unity
Public Class 用紙仕入明細Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_用紙仕入明細)
    Public Function SelectShipmentDetailByPurchaseNo(purchaseNo As String) As List(Of TPL_用紙仕入明細)
        Return _Repository._dbSet.Where(Function(x) x.発注番号 = purchaseNo).OrderBy(Function(x) x.連番).Select(Function(x) x).ToList()
    End Function

    Public Function SelectShipmentDetailByShipNo(shipNo As String) As List(Of TPL_用紙仕入明細)
        Return _Repository._dbSet.Where(Function(x) x.発注番号 = shipNo).OrderBy(Function(x) x.連番).Select(Function(x) x).ToList()
    End Function

End Class
