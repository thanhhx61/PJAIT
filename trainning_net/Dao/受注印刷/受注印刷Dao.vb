Imports System.Text
Imports Core.Util
Imports Entities
Imports Unity
Public Class 受注印刷Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_受注印刷)

    Public Function GetOrderByKey5(orderNo As String) As List(Of TPL_受注印刷)
        Return _Repository._dbSet.Where(Function(a) a.受注番号 = orderNo).OrderBy(Function(a) a.行番号).ToList()

    End Function
End Class
