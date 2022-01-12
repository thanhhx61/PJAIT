Namespace Models
    <Serializable>
    Public Class LayoutBaseViewModel
        Public Property Message As String

        Public Property Type As MessageType

        Public Property IsMessage As Boolean = False

        Public Property Focus As String
    End Class

    Public Enum MessageType
        QUESTION = 1
        INFO = 2
    End Enum
End Namespace
