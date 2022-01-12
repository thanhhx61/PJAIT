Imports System.Text
Imports Core.ConstantCore.Consts
Imports Core.Util
Imports Entities
Imports Unity
Public Class 買掛締仕入先Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_買掛締仕入先)
    Public Function SelectStatusByCodeDate(code As String, targetDate As Date) As String
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT COALESCE(状況, '0') FROM 買掛締仕入先 ")
        sql.AppendLine(" WHERE 仕入先 = :code ")
        sql.AppendLine(" AND 締対象開始日 <= :targetDate ")
        sql.AppendLine(" AND 締対象終了日 >= :targetDate ")

        Return _Repository.Selects(Of String)(sql.ToString(), New With {.code = code,
                                              .targetDate = targetDate}).FirstOrDefault()
    End Function

End Class
