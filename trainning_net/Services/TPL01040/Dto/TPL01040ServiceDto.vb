<Serializable>
Public Class TPL01040ResultDto
    Public Property MessageInfo As MessageInfoDto
    Public Property ErrorType As String
    Public Property IsSuccess As Boolean = False
End Class

<Serializable>
Public Class TPL01040ResultWithDataDto(Of T)
    Inherits TPL01040ResultDto
    Public Property Data As T
End Class
