Imports Entities

Namespace Dto
    <Serializable>
    Public Class LoginResultDto
        Public Property Pic As PicDto
        Public Property Message As MessageInfoDto
        Public Property ProgramIds As List(Of String)
        Public Property IsSuccess As Boolean = False
    End Class
End Namespace

