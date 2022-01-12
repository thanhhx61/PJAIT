Imports System.Text
Imports Entities
Imports Unity
Public Class 請求締得意先Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_請求締得意先)
    Public Function SelectStatusByCodeDateAndDeadline(code As String, targetDate As Date, dateline As String) As String
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT COALESCE(状況, '0') FROM 請求締得意先 ")
        sql.AppendLine(" WHERE 得意先 = :code ")
        sql.AppendLine(" AND 締対象開始日 <= :targetDate ")
        sql.AppendLine(" AND 締対象終了日 >= :targetDate ")
        sql.AppendLine(" AND 締日 = :dateline ")

        Return _Repository.Selects(Of String)(sql.ToString(), New With {.code = code,
                                              .targetDate = targetDate,
                                              .dateline = dateline}).FirstOrDefault()
    End Function

End Class
