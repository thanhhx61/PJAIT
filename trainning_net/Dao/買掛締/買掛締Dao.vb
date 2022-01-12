Imports System.Text
Imports Core.ConstantCore.Consts
Imports Core.Util
Imports Entities
Imports Unity
Public Class 買掛締Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_買掛締)
    Public Function GetMAXClosingDate() As String
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT MAX(締年月) FROM 買掛締 ")
        sql.AppendLine(" WHERE 状況 = '2' ")

        Return _Repository.Selects(Of String)(sql.ToString(), Nothing).FirstOrDefault()
    End Function

    Public Function SelectStatusByDate(targetDate As Date) As String
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT 状況 FROM 買掛締 ")
        sql.AppendLine(" WHERE 締対象開始日 <= :targetDate ")
        sql.AppendLine(" AND 締対象終了日 >= :targetDate ")

        Return _Repository.Selects(Of String)(sql.ToString(), New With {.targetDate = targetDate}).FirstOrDefault()
    End Function
End Class
