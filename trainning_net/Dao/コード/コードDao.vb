Imports System.Text
Imports Core.ConstantCore
Imports Core.Util
Imports Entities
Imports Unity

Public Class コードDao
    <Dependency>
    Public _Repository As IRepository(Of TPL_コード)

    Public Function GetNameByCode(key As String, code As String) As NameDto
        Return _Repository._dbSet.Where(Function(a) a.識別 = key And a.コード = code And a.削除フラグ = False) _
        .Select(Function(a) New NameDto() With {.名称 = a.名称, .略称 = a.略称}) _
        .FirstOrDefault()
    End Function



    Public Function GetCodeByIdentifer(key As String, code As String) As List(Of TPL_コード)
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT * From コード")
        sql.AppendLine(" WHERE 識別 = :key ")
        If Not String.IsNullOrEmpty(code) Then
            sql.AppendLine(" AND コード = :code ")
        End If
        sql.AppendLine(" AND コード <> '00000000' ")
        sql.AppendLine(" AND 削除フラグ = false ")
        sql.AppendLine(" ORDER BY  表示順 , コード")
        Return _Repository.Selects(Of TPL_コード)(sql.ToString(), New With {.key = key, .code = code}).ToList()
    End Function

    Public Function GetCombo(key As String) As List(Of ComboBoxDto)
        Return _Repository._dbSet.Where(Function(a) a.識別 = key And a.コード <> Consts.COMMON_CODE And a.削除フラグ = False) _
        .Select(Function(a) New ComboBoxDto() With {.コード = a.コード, .名称 = a.名称, .略称 = a.略称, .表示順 = a.表示順}) _
        .OrderBy(Function(a) a.表示順).ThenBy(Function(a) a.コード).ToList()
    End Function


    Public Function GetDepatureByCode(code As String) As DepatureDto
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT B.コード, B.名称, B.略称 ")
        sql.AppendLine(" FROM 担当 A")
        sql.AppendLine(" LEFT JOIN コード B ")
        sql.AppendLine("  ON A.部署 = B.コード ")
        sql.AppendLine(" AND B.削除フラグ = false ")
        sql.AppendLine(" AND B.識別 = '1009' ")
        sql.AppendLine(" AND B.コード <> '00000000' ")
        sql.AppendLine(" WHERE A.削除フラグ = false ")
        sql.AppendLine(" AND A.担当 = :code ")
        Return _Repository.Selects(Of DepatureDto)(sql.ToString(), New With {.code = code}).FirstOrDefault()
    End Function

    Public Function GetTaxRateByDate(targetDate As Date) As String
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT コード ")
        sql.AppendLine(" FROM コード")
        sql.AppendLine(" WHERE 識別 = '1040' ")
        sql.AppendLine(" AND コード <> '00000000' ")
        sql.AppendLine(" AND 文字１ = (SELECT MIN(文字１) as minvalue  FROM コード WHERE 識別 = '1040'  AND 文字１ >= :targetDate) ")
        Return _Repository.Selects(Of String)(sql.ToString(), New With {.targetDate = Format(targetDate, "yyyyMMdd")}).FirstOrDefault()
    End Function

    ''' <summary>
    ''' 適用区分のコード情報を取得する。
    ''' </summary>
    ''' <param name="targetDate">受注日</param>
    ''' <returns>コード一覧</returns>
    Public Function GetCodeApplyByDate(targetDate As Date) As List(Of String)
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT コード ")
        sql.AppendLine(" FROM コード")
        sql.AppendLine(" WHERE 識別 = '1012' ")
        sql.AppendLine(" AND コード <> '00000000' ")
        sql.AppendLine(" AND 文字１ <= :targetDate ")
        sql.AppendLine(" AND 文字２ >= :targetDate ")
        Return _Repository.Selects(Of String)(sql.ToString(), New With {.targetDate = DateUtil.ConvertDateToString(targetDate, "yyyyMMdd")}).ToList()
    End Function

    Public Function SearchCodePagedListDao(request As PaginationRequestDto(Of SearchCodeParamDto)) As PanigationResultDto(Of コードDto)
        Dim param = request.Param
        Dim sql = New StringBuilder()
        sql.AppendLine("SELECT * FROM コード ")
        If (String.IsNullOrEmpty(request.Param.code)) Then
            sql.AppendLine(" WHERE コード.コード = '00000000' ")
        Else
            sql.AppendLine(" WHERE コード.識別 = :code ")
            sql.AppendLine(" AND コード.コード <> '00000000' ")
        End If
        sql.AppendLine(" ORDER BY 識別, コード ")

        Return _Repository.SelectByPagination(Of SearchCodeParamDto, コードDto)(sql.ToString(), request)
    End Function

    Public Function GetComboById(id As String) As List(Of ComboBoxDto)
        Return _Repository._dbSet.Where(Function(a) a.識別 = id And a.コード <> Consts.COMMON_CODE And a.削除フラグ = False) _
        .Select(Function(a) New ComboBoxDto() With {.コード = a.コード, .名称 = a.名称, .略称 = a.略称, .表示順 = a.表示順}) _
        .OrderBy(Function(a) a.表示順) _
        .ToList()
    End Function
    Public Function GetCodePageListByIdentifer(request As PaginationRequestDto(Of ClassSearchCodeDto)) As PanigationResultDto(Of コードDto)
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT * From コード")
        sql.AppendLine(" WHERE 識別 = :key ")
        If request.Param.Code IsNot Nothing Then
            sql.AppendLine(" AND コード = :code ")
        End If
        sql.AppendLine(" AND 削除フラグ = false ")
        sql.AppendLine(" AND コード.コード <> '00000000' ")
        sql.AppendLine(" ORDER BY  表示順")
        Return _Repository.SelectByPagination(Of ClassSearchCodeDto, コードDto)(sql.ToString(), request)
    End Function
    ''' <summary>
    ''' 識別でコード情報を取得する。
    ''' </summary>
    ''' <param name="key">画面情報.識別</param>
    ''' <param name="code">画面情報.コード</param>
    ''' <returns></returns>
    Public Function GetCodeBykey(key As String, code As String) As TPL_コード
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT * From コード")
        sql.AppendLine(" WHERE 識別 = :key ")
        sql.AppendLine(" AND コード = :code ")
        sql.AppendLine(" AND 削除フラグ = false ")
        sql.AppendLine(" ORDER BY  表示順 , コード")
        Return _Repository.Selects(Of TPL_コード)(sql.ToString(), New With {.key = key, .code = code}).First()
    End Function
    ''' <summary>
    ''' コード情報を更新する。
    ''' </summary>
    ''' <param name="data">画面情報</param>
    ''' <returns>データ件数</returns>
    Public Function UpdateCode(data As Object, log As LogInfoDto) As Integer
        Dim sql As StringBuilder = New StringBuilder()
        sql.AppendLine("update コード set")
        sql.AppendLine("名称 = :Name,")
        sql.AppendLine("略称 = :Abbreviation, ")
        sql.AppendLine("数字１= :Number1, ")
        sql.AppendLine("数字２= :Number2, ")
        sql.AppendLine("数字３= :Number3, ")
        sql.AppendLine("文字１= :Character1, ")
        sql.AppendLine("文字２= :Character2, ")
        sql.AppendLine("文字３= :Character3, ")
        sql.AppendLine("表示順= :DisplayOrder, ")
        sql.AppendLine("更新日= :UpdateDate, ")
        sql.AppendLine("更新者= :UserId, ")
        sql.AppendLine("登録日= :UpdateDate, ")
        sql.AppendLine("登録者= :UserId, ")
        sql.AppendLine("変更不可フラグ=:ImmutableFlag ")
        sql.AppendLine("where コード = :Code and 識別 = :Key")
        Return _Repository.UpdateByQuery(sql.ToString(), data, log)
    End Function
    ''' <summary>
    ''' コード情報を削除する。
    ''' </summary>
    ''' <param name="UpdateDate">更新日</param>
    ''' <param name="UserId">更新者</param>
    ''' <param name="key">画面情報.識別</param>
    ''' <param name="code">画面情報.コード</param>
    ''' <returns>データ件数</returns>
    Public Function DeleteCode(UpdateDate As Date, UserId As String, Code As String, Key As String, log As LogInfoDto) As Integer
        Dim sql As StringBuilder = New StringBuilder()
        sql.AppendLine("update コード set ")
        sql.AppendLine("削除フラグ = true, ")
        sql.AppendLine("更新日 = :UpdateDate, ")
        sql.AppendLine("更新者 = :UserId ")
        sql.AppendLine(" where ")
        sql.AppendLine("コード = :Code ")
        sql.AppendLine("and 識別 = :Key")
        Return _Repository.UpdateByQuery(sql.ToString(), New With {.UpdateDate = UpdateDate, .UserId = UserId, .Code = Code, .Key = Key}, log)
    End Function
End Class
