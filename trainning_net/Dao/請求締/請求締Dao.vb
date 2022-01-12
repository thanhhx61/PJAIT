Imports System.Text
Imports Entities
Imports Unity
Public Class 請求締Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_請求締)
    Public Function SelectStatusByDateAndDeadline(targetDate As Date, dateline As String) As String
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT 状況 FROM 請求締 ")
        sql.AppendLine(" WHERE 締対象開始日 <= :targetDate ")
        sql.AppendLine(" AND 締対象終了日 >= :targetDate ")
        sql.AppendLine(" AND 締日 = :dateline ")

        Return _Repository.Selects(Of String)(sql.ToString(), New With {.targetDate = targetDate,
                                              .dateline = dateline}).FirstOrDefault()
    End Function

End Class
