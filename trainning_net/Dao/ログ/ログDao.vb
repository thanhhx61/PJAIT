Imports Entities
Imports Unity
Public Class ログDao
    <Dependency>
    Public _Repository As IRepository(Of TPL_ログ)

    Public Sub InsertLog(log As TPL_ログ)
        _Repository.Insert(log, Nothing, False)
    End Sub
End Class
