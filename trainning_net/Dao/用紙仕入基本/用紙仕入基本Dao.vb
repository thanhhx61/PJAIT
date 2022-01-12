Imports Entities
Imports Unity
Public Class 用紙仕入基本Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_用紙仕入基本)
    Public Function SelectShipmentPByShipNo(shipNo As String) As TPL_用紙仕入基本
        Return _Repository._dbSet.Where(Function(x) x.仕入番号 = shipNo).Select(Function(x) x).FirstOrDefault()
    End Function

End Class
