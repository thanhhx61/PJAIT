Imports System.Text
Imports Entities
Imports Unity
Public Class 外注仕入基本Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_外注仕入基本)
    Public Function SelectShipment2ByPurchaseNo(purchaseNo As String) As List(Of TPL_外注仕入基本)
        Return _Repository._dbSet.Where(Function(x) x.発注番号 = purchaseNo AndAlso x.削除フラグ = False).
            OrderBy(Function(x) x.仕入番号).ThenBy(Function(x) x.発注番号).
            ThenBy(Function(x) x.連番).Select(Function(x) x).ToList()
    End Function

    Public Function SelectShipmentByShipNo(shipNo As String) As TPL_外注仕入基本
        Return _Repository._dbSet.Where(Function(x) x.仕入番号 = shipNo AndAlso x.削除フラグ = False).
            Select(Function(x) x).FirstOrDefault()
    End Function

End Class
