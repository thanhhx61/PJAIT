Imports System.Text
Imports Dao.Dto
Imports Entities
Imports Unity
Public Class メニューDao
    <Dependency>
    Public _Repository As IRepository(Of TPL_メニュー)

    Public Function SelectMenuByRoleId(roleId As String) As List(Of TPL_メニュー)
        Dim sql = New StringBuilder()
        sql.AppendLine("SELECT")
        sql.AppendLine("  メニュー.* ")
        sql.AppendLine("FROM ")
        sql.AppendLine("  メニュー ")
        sql.AppendLine("  INNER JOIN メニュー権限 ")
        sql.AppendLine("    ON メニュー.メニュー権限 = メニュー権限.メニュー権限 ")
        sql.AppendLine("WHERE ")
        sql.AppendLine("  メニュー権限.メニュー権限 = :roleId ")
        sql.AppendLine("  AND メニュー.使用可否 = '0' ")
        sql.AppendLine("  AND メニュー権限.使用可否 = '0' ")
        sql.AppendLine("  AND メニュー.処理種別 = '2' ")

        Return _Repository.Selects(Of TPL_メニュー)(sql.ToString(), New With {.roleId = roleId}).ToList()
    End Function

    Public Function SelectMenuDispByRoleId(ByVal roleId As String) As List(Of MenuResultDto)
        Dim sql As StringBuilder = New StringBuilder()
        sql.AppendLine("SELECT")
        sql.AppendLine("  * ")
        sql.AppendLine("FROM ")
        sql.AppendLine("  メニュー ")
        sql.AppendLine("  INNER JOIN メニュー権限 ")
        sql.AppendLine("    ON メニュー.メニュー権限 = メニュー権限.メニュー権限 ")
        sql.AppendLine("WHERE ")
        sql.AppendLine("  メニュー権限.メニュー権限 = :roleId ")
        sql.AppendLine("  AND メニュー.使用可否 = '0' ")
        sql.AppendLine("  AND メニュー権限.使用可否 = '0' ")
        sql.AppendLine("  AND メニュー.処理種別 = '2' ")
        sql.AppendLine("  ORDER BY メニュー.表示順 ")

        Return _Repository.Selects(Of MenuResultDto)(sql.ToString(), New With {.roleId = roleId}).ToList()
    End Function

    ''' <summary>
    ''' URLの画面を取得する。
    ''' </summary>
    ''' <param name="parentMenuID">MenuID</param>
    ''' <returns></returns>
    Public Function SelectProgramByParentMenuID(ByVal parentMenuID As String) As List(Of MenuProgramResultDto)
        Dim sql As StringBuilder = New StringBuilder()
        sql.AppendLine("SELECT メニュー.メニュー名 AS MenuName, コード.文字１ AS MenuUrl ")
        sql.AppendLine("FROM ")
        sql.AppendLine("  メニュー  ")
        sql.AppendLine("  INNER JOIN コード  ")
        sql.AppendLine("    ON メニュー.プログラムID = コード.コード  ")
        sql.AppendLine("    AND コード.識別 = '1047' ")
        sql.AppendLine("WHERE ")
        sql.AppendLine("  メニュー.上位メニューID = :parentMenuID ")
        sql.AppendLine("  AND メニュー.処理種別 = '1' ")
        sql.AppendLine("  AND メニュー.使用可否 = '0' ")
        sql.AppendLine("ORDER BY ")
        sql.AppendLine("  メニュー.表示順 ")

        Return _Repository.Selects(Of MenuProgramResultDto)(sql.ToString(), New With {.parentMenuID = parentMenuID})

    End Function

End Class
