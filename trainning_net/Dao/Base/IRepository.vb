Imports System.Data.Entity
Imports System.Web
Imports Dao.Dto
Imports Entities

Public MustInherit Class IRepository(Of T As Class)
    Public Property _context As CustomContext
    Public Property _dbSet As DbSet(Of T)
    Public Property _dbSetLog As DbSet(Of TPL_ログ)
    Public MustOverride Function GetById(id As Object) As T
    Public MustOverride Function GetAll(request As PaginationRequestDto(Of T), orderBy As String) As List(Of T)
    Public MustOverride Function CountAll(request As PaginationRequestDto(Of T)) As Int64
    Public MustOverride Sub Insert(obj As T, loginfo As LogInfoDto, Optional needLog As Boolean = True)
    Public MustOverride Sub Delete(id As Object, loginfo As LogInfoDto)
    Public MustOverride Function Selects(Of M)(ByVal query As String, ByVal param As Object) As List(Of M)
    Public MustOverride Function CountSelect(query As String, param As Object) As Long
    Public MustOverride Function SelectByPagination(Of M As Class, Z As Class)(query As String, request As PaginationRequestDto(Of M)) As PanigationResultDto(Of Z)
    Public MustOverride Function Queryable(Of M As Class)(query As String, request As PaginationRequestDto(Of M)) As IQueryable(Of M)
    Public MustOverride Sub InsertList(objs As List(Of T), loginfo As LogInfoDto)

    Friend Function Selects(p As Func(Of Object, Object)) As Object
        Throw New NotImplementedException()
    End Function

    Public MustOverride Function Delete(obj As T, loginfo As LogInfoDto) As Long
    Public MustOverride Function DeleteList(List As List(Of T), loginfo As LogInfoDto) As Long
    Public MustOverride Function Update(obj As T, loginfo As LogInfoDto) As Long
    Public MustOverride Function UpdateList(List As List(Of T), loginfo As LogInfoDto) As Long
    Public MustOverride Function DeleteByQuery(query As String, param As Object, loginfo As LogInfoDto) As Integer
    Public MustOverride Function UpdateByQuery(query As String, param As Object, loginfo As LogInfoDto) As Integer
    Public MustOverride Function SelectNextValSeq(ByVal query As String) As Long
End Class