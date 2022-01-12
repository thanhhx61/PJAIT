Imports System.Text
Imports Entities
Imports Unity

Public Class 用紙Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_用紙)

    Public Function GetPaperByCode(code As String) As String
        Return _Repository._dbSet.Where(Function(a) a.銘柄 = code And a.削除フラグ = False).Select(Function(a) a.銘柄名).FirstOrDefault()
    End Function

    Public Function GetPaperByCode2(code As String) As TPL_用紙
        Return _Repository._dbSet.FirstOrDefault(Function(a) a.銘柄 = code And a.削除フラグ = False)
    End Function

    Public Function GetPaperByTypeAndProducer(request As PaginationRequestDto(Of SearchPaperPopupParamDto)) As PanigationResultDto(Of ResultPaperPopupDto)
        Dim param = request.Param
        Dim sql = New StringBuilder()
        sql.AppendLine("SELECT  ")
        sql.AppendLine(" A.銘柄 as 銘柄, ")
        sql.AppendLine(" A.銘柄名 as 銘柄名, ")
        sql.AppendLine(" A.品種 as 品種, ")
        sql.AppendLine(" C.略称 As 品種名, ")
        sql.AppendLine(" A.メーカー as メーカー, ")
        sql.AppendLine(" B.略称 As メーカー名 ")
        sql.AppendLine(" FROM 用紙 A")
        sql.AppendLine(" LEFT JOIN コード C ON A.品種 = C.コード  AND C.識別 = '1010' ")
        sql.AppendLine(" LEFT JOIN コード B ON A.メーカー = B.コード  AND B.識別 = '1011' ")
        sql.AppendLine(" WHERE 1 = 1 ")
        If Not String.IsNullOrEmpty(param.ProducerName) Then
            sql.AppendLine(" AND Convert_Half_To_Full(A.銘柄名) Like '%' || :ProducerName || '%' ")
        End If
        If Not String.IsNullOrEmpty(param.ProductType) Then
            sql.AppendLine(" AND A.品種 = :ProductType ")
        End If
        If Not String.IsNullOrEmpty(param.ProducerCode) Then
            sql.AppendLine(" AND A.メーカー = :ProducerCode ")
        End If
        sql.AppendLine(" AND A.削除フラグ = false ")
        sql.AppendLine(" ORDER BY 銘柄名, 品種名, メーカー名 ")

        Return _Repository.SelectByPagination(Of SearchPaperPopupParamDto, ResultPaperPopupDto)(sql.ToString(), request)
    End Function

End Class
