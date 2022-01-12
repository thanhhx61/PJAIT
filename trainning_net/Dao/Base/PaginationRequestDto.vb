Public Class PaginationRequestDto(Of M As Class)
    Public Property Param As M
    Public Property PageCurrent As Integer
    Public Property PageSize As Integer
End Class