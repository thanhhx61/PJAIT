Imports System.Data.Entity
Imports Core.ConstantCore.Consts
Imports Core.Util
Imports Dapper
Imports Entities

Public Class Repository(Of T As Class)
    Inherits IRepository(Of T)
    Public Sub New()
        MyBase._context = CustomContext.Current
        MyBase._dbSet = _context.Set(Of T)()
        MyBase._dbSetLog = _context.Set(Of TPL_ログ)()
    End Sub

    Public Overrides Function GetById(id As Object) As T
        Return _dbSet.Find(id)
    End Function

    Public Overrides Sub Insert(obj As T, loginfo As LogInfoDto, Optional needLog As Boolean = True)
        _dbSet.Add(obj)
        If needLog Then
            loginfo.LogType = LogType.INSERT
            Me.InsertLog(obj, loginfo)
        End If
        Me.SaveChanges()
    End Sub

    Public Overrides Sub Delete(id As Object, loginfo As LogInfoDto)
        Dim obj As Object = _dbSet.Find(id)
        If obj IsNot Nothing Then
            _dbSet.Remove(obj)
            loginfo.LogType = LogType.DELETE
            Me.InsertLog(obj, loginfo)
            Me.SaveChanges()
        End If
    End Sub

    Public Overrides Sub InsertList(objs As List(Of T), loginfo As LogInfoDto)
        _dbSet.AddRange(objs)
        loginfo.LogType = LogType.INSERT
        Me.InsertLog(objs(0), loginfo)
        Me.SaveChanges()
    End Sub

    Private Sub SaveChanges()
        _context.SaveChanges()
    End Sub

    Public Overrides Function Selects(Of M)(query As String, param As Object) As List(Of M)
        Return MyBase._context.Database.Connection.Query(Of M)(query, param).ToList()
    End Function

    Public Overrides Function CountSelect(query As String, param As Object) As Long
        Return MyBase._context.Database.Connection.Query(query, param).Count()
    End Function

    Public Overrides Function SelectByPagination(Of M As Class, Z As Class)(query As String, request As PaginationRequestDto(Of M)) As PanigationResultDto(Of Z)
        Dim list = MyBase._context.Database.Connection.Query(Of Z)(query, request.Param).Skip((request.PageCurrent - 1) * request.PageSize).Take(request.PageSize).ToList()
        Dim result = New PanigationResultDto(Of Z) With {.Total = Me.CountSelect(query, request.Param), .List = list, .PageSize = request.PageSize}
        Return result
    End Function

    Public Overrides Function Queryable(Of M As Class)(query As String, request As PaginationRequestDto(Of M)) As IQueryable(Of M)
        Return _context.Database.Connection.Query(query, request.Param).AsQueryable()
    End Function

    Public Overrides Function Delete(obj As T, loginfo As LogInfoDto) As Long
        _context.Entry(obj).State = EntityState.Deleted
        loginfo.LogType = LogType.DELETE
        InsertLog(obj, loginfo)
        Return _context.SaveChanges()
    End Function

    Public Overrides Function DeleteList(objs As List(Of T), loginfo As LogInfoDto) As Long
        _context.Entry(objs).State = EntityState.Deleted
        loginfo.LogType = LogType.DELETE
        InsertLog(objs(0), loginfo)
        Return _context.SaveChanges()
    End Function

    Public Overrides Function Update(obj As T, loginfo As LogInfoDto) As Long
        _context.Entry(obj).State = EntityState.Modified
        loginfo.LogType = LogType.UPDATE
        InsertLog(obj, loginfo)
        Return _context.SaveChanges()
    End Function

    Public Overrides Function UpdateList(objs As List(Of T), loginfo As LogInfoDto) As Long
        _context.Entry(objs).State = EntityState.Modified
        loginfo.LogType = LogType.UPDATE
        InsertLog(objs(0), loginfo)
        Return _context.SaveChanges()
    End Function

    Public Overrides Function DeleteByQuery(query As String, param As Object, loginfo As LogInfoDto) As Integer
        Dim result = _context.Database.Connection.Execute(query, param)
        loginfo.LogType = LogType.DELETE
        InsertLogQuery(query, param, loginfo)
        Return result
    End Function

    Public Overrides Function UpdateByQuery(query As String, param As Object, loginfo As LogInfoDto) As Integer
        Dim result = _context.Database.Connection.Execute(query, param)
        loginfo.LogType = LogType.UPDATE
        InsertLogQuery(query, param, loginfo)
        Return result
    End Function

    Public Overrides Function SelectNextValSeq(sequenceName As String) As Long
        Dim query = "select nextval('" + sequenceName + "')"
        Return _context.Database.SqlQuery(Of Long)(query, {}).SingleOrDefault
    End Function

    Public Overrides Function GetAll(request As PaginationRequestDto(Of T), orderBy As String) As List(Of T)
        Return _dbSet.Where(Function(d) True = True).OrderBy(Function(x) orderBy).Skip((request.PageCurrent - 1) * request.PageSize).Take(request.PageSize).ToList()
    End Function

    Public Overrides Function CountAll(request As PaginationRequestDto(Of T)) As Int64
        Return _dbSet.Where(Function(d) True = True).Count()
    End Function
    Private Sub InsertLog(obj As T, loginfo As LogInfoDto)
        Dim nowStr = DateUtil.GetSysDate(SysdateFormat.YYYYMMDDHHMMSSFFF)
        Dim query = StringUtil.GetQueryCompleted(obj.GetType().Name, obj)
        query = If(query.Length > 1000, query.Substring(0, 1000), query)
        Dim log = New TPL_ログ()
        log.処理日時 = DateUtil.ConvertStringToDate(nowStr, DateFormat.DATETIMEFULL_F6)
        log.区分 = loginfo.LogType
        log.SQL文 = query
        log.担当 = loginfo.LoginId
        log.画面名 = If(loginfo.ScreenName.Length > 100, loginfo.ScreenName.Substring(0, 100), loginfo.ScreenName)
        log.接続元IP = loginfo.SourceIp

        _dbSetLog.Add(log)
    End Sub

    Private Sub InsertLogQuery(query As String, param As Object, loginfo As LogInfoDto)
        Try
            query = StringUtil.GetQueryCompleted(query, param)
            query = If(query.Length > 1000, query.Substring(0, 1000), query)
            Dim nowStr = DateUtil.GetSysDate(SysdateFormat.YYYYMMDDHHMMSSFFF)
            Dim log = New TPL_ログ()
            log.処理日時 = DateUtil.ConvertStringToDate(nowStr, DateFormat.DATETIMEFULL_F6)
            log.区分 = loginfo.LogType
            log.担当 = loginfo.LoginId
            log.画面名 = If(loginfo.ScreenName.Length > 100, loginfo.ScreenName.Substring(0, 100), loginfo.ScreenName)
            log.接続元IP = loginfo.SourceIp
            log.SQL文 = query
            _dbSetLog.Add(log)

            _context.SaveChanges()
        Catch ex As Exception
            _context.Dispose()
        End Try
    End Sub
End Class