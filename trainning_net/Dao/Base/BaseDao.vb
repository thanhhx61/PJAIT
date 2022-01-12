Imports Unity

Public Class BaseDao(Of T As Class)
    <Dependency>
    Public ReadOnly _Repository As IRepository(Of T)

    'Public Sub Insert(value As T)
    '    _Repository.Insert(value)
    'End Sub
End Class
