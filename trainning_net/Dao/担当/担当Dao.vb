Imports System.Text
Imports Entities
Imports Unity
Public Class 担当Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_担当)

    Public Function SelectUserByUserId(userId As String) As TPL_担当
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT * FROM 担当 ")
        sql.AppendLine(" WHERE 担当 = :userId ")
        sql.AppendLine(" AND 使用可否 = '0' ")
        sql.AppendLine(" AND 削除フラグ = false ")

        Return _Repository.Selects(Of TPL_担当)(sql.ToString(), New With {.userId = userId}).FirstOrDefault()
    End Function
    Public Function GetEmployeeByCode(code As String) As String
        Return _Repository._dbSet.Where(Function(a) a.担当 = code And a.使用可否 = "0" And a.削除フラグ = False).Select(Function(a) a.氏名).FirstOrDefault()
    End Function

    Public Function GetEmployeeByDepartmentAndNamePagedList(request As PaginationRequestDto(Of SearchEmployeeParamDto)) As PanigationResultDto(Of ResultSearchByDepartAndNameDto)
        Dim param = request.Param
        Dim sql = New StringBuilder()
        sql.AppendLine("SELECT A.担当 as 担当, A.氏名 as 氏名, B.略称 as 略称, A.ふりがな as ふりがな FROM 担当 A ")
        sql.AppendLine(" LEFT JOIN コード B ON A.部署 = B.コード  AND B.識別 = '1009' ")
        sql.AppendLine(" WHERE 1 = 1 ")
        If Not String.IsNullOrEmpty(param.DepartmentCode) Then
            sql.AppendLine(" AND A.部署 = :DepartmentCode ")
        End If
        If Not String.IsNullOrEmpty(param.NameEmployee) Then
            sql.AppendLine(" AND A.氏名 LIKE '%' || :NameEmployee ||'%' ")
        End If
        sql.AppendLine(" AND A.使用可否 = '0' ")
        sql.AppendLine(" AND A.削除フラグ = false ")
        sql.AppendLine(" ORDER BY ふりがな ")
        Return _Repository.SelectByPagination(Of SearchEmployeeParamDto, ResultSearchByDepartAndNameDto)(sql.ToString(), request)
    End Function
End Class
