Imports Entities
Imports Unity
Public Class エラーログDao
    <Dependency>
    Public _Repository As IRepository(Of TPL_エラーログ)
    Public Sub InsertErrorLog(erroLog As TPL_エラーログ)
        _Repository.Insert(erroLog, Nothing, False)
    End Sub
End Class
