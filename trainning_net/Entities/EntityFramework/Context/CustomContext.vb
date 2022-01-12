Imports System.Data.Entity
Imports System.Web
Imports Core.Session

''' <summary>
''' 拡張DbContextクラス
''' </summary>
Public Class CustomContext
    Inherits TPLContext
    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Current As CustomContext
        Get
            Try
                Dim context = CType(HttpContext.Current.Items("CACHE_KEY_CTX"), CustomContext)
                If context Is Nothing Then
                    context = New CustomContext()
                    HttpContext.Current.Items("CACHE_KEY_CTX") = context
                    Dim tran = context.Database.BeginTransaction()
                    HttpContext.Current.Items("CACHE_KEY_TRAN") = tran
                End If
                Return context
            Catch e As Exception
                Throw e
            End Try
        End Get
    End Property

    Private Overloads Sub Dispose()
        HttpContext.Current.Items("CACHE_KEY_CTX") = Nothing
        HttpContext.Current.Items("CACHE_KEY_TRAN") = Nothing
        MyBase.Dispose()
    End Sub
    Public Shared ReadOnly Property HasCurrent As Boolean
        Get
            Dim context = CType(HttpContext.Current.Items("CACHE_KEY_CTX"), CustomContext)
            Return context IsNot Nothing
        End Get
    End Property

    Public Shared Sub RollbackDispose()
        If Not HasCurrent Then
            Return
        End If

        Dim tran = CType(HttpContext.Current.Items("CACHE_KEY_TRAN"), DbContextTransaction)

        If tran IsNot Nothing Then
            tran.Rollback()
            tran.Dispose()
        End If

        Current.Dispose()
    End Sub

    Public Shared Sub Rollback()
        If Not HasCurrent Then
            Return
        End If

        Dim tran = CType(HttpContext.Current.Items("CACHE_KEY_TRAN"), DbContextTransaction)

        If tran IsNot Nothing Then
            tran.Rollback()
            tran.Dispose()
        End If

        Current.DetacheState()
        tran = Current.Database.BeginTransaction()
        HttpContext.Current.Items("CACHE_KEY_TRAN") = tran
    End Sub

    Public Shared Sub CommitDispose()
        If Not HasCurrent Then
            Return
        End If

        Dim tran = CType(HttpContext.Current.Items("CACHE_KEY_TRAN"), DbContextTransaction)

        If tran IsNot Nothing Then
            tran.Commit()
            tran.Dispose()
        End If

        Current.Dispose()
    End Sub

    Public Shared Sub Commit()
        If Not HasCurrent Then
            Return
        End If

        Dim tran = CType(HttpContext.Current.Items("CACHE_KEY_TRAN"), DbContextTransaction)

        If tran IsNot Nothing Then
            tran.Commit()
            tran.Dispose()
        End If

        tran = Current.Database.BeginTransaction()
        HttpContext.Current.Items("CACHE_KEY_TRAN") = tran
    End Sub

    Public Sub AutoSaveChange(Optional autocomplete As Boolean = False)
        If autocomplete Then
            MyBase.SaveChanges()
        Else
            Me.SaveChanges()
        End If
    End Sub

    Public Overrides Function SaveChanges() As Integer
        Return MyBase.SaveChanges()
    End Function

    Private Sub DetacheState()
        Dim changedEntriesCopy = Current.ChangeTracker.Entries().Where(Function(e) e.State = EntityState.Added OrElse
                    e.State = EntityState.Modified OrElse
                    e.State = EntityState.Deleted).ToList()
        For Each changedEntry In changedEntriesCopy
            changedEntry.State = EntityState.Detached
        Next
    End Sub
End Class
