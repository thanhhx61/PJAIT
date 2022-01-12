Imports Entities
Imports Unity
Public Class 受注制作Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_受注制作)

    Public Function GetOrderByKey2(orderNo As String) As List(Of TPL_受注制作)
        Return _Repository._dbSet.Where(Function(a) a.受注番号 = orderNo).OrderBy(Function(a) a.行番号).ToList()
    End Function


End Class
