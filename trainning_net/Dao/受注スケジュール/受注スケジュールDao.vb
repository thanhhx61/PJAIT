Imports System.Text
Imports Core.Util
Imports Entities
Imports Unity
Public Class 受注スケジュールDao
    <Dependency>
    Public _Repository As IRepository(Of TPL_受注スケジュール)

    Public Function GetScheduleByKey(orderNo As String) As TPL_受注スケジュール
        Return _Repository._dbSet.FirstOrDefault(Function(a) a.受注番号 = orderNo)
    End Function
End Class
