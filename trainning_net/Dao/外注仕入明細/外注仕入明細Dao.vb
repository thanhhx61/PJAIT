Imports System.Text
Imports Entities
Imports Unity
Public Class 外注仕入明細Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_外注仕入明細)
    Public Function SelectShipmentDetailByShipNoAndSerial(shipNo As String, serialNumber As Integer) As List(Of TPL_外注仕入明細)
        Return _Repository._dbSet.Where(Function(x) x.仕入番号 = shipNo AndAlso x.連番 = serialNumber).
            OrderBy(Function(x) x.連番).
            ThenBy(Function(x) x.行番号).Select(Function(x) x).ToList()
    End Function


End Class
