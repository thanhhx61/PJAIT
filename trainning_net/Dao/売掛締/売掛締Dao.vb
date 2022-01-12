Imports System.Text
Imports Core.ConstantCore.Consts
Imports Core.Util
Imports Entities
Imports Unity
Public Class 売掛締Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_売掛締)
    Public Function GetMAXClosingDate() As String
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT MAX(締年月) FROM 売掛締 ")
        sql.AppendLine(" WHERE 状況 = '2' ")

        Return _Repository.Selects(Of String)(sql.ToString(), Nothing).FirstOrDefault()
    End Function
    ''' <summary>
    ''' Get 状況 by 日付
    ''' </summary>
    ''' <param name="targetDate"></param>
    ''' <returns></returns>
    Public Function SelectStatusByDate(targetDate As Date) As String
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT 状況 FROM 売掛締 ")
        sql.AppendLine(" WHERE 締対象開始日 <= :targetDate ")
        sql.AppendLine(" AND 締対象終了日 >= :targetDate ")

        Return _Repository.Selects(Of String)(sql.ToString(), New With {.targetDate = targetDate}).FirstOrDefault()
    End Function
End Class