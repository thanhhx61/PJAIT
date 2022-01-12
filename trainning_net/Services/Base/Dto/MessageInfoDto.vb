<Serializable>
Public Class MessageInfoDto
    Public Property Message As String

    Public Property Type As MessageType

    Public Property IsMessage As Boolean = False

    Public Property Focus As String

    Public Property RowIndex As String

    Public Enum MessageType
        QUESTION = 1
        INFO = 2
    End Enum

    ''' <summary>
    ''' Update message info
    ''' </summary>
    ''' <param name="message">string</param>
    ''' <param name="focus">element focus</param>
    Public Sub UpdateMessage(message As String, Optional focus As String = Nothing)
        Me.Message = message
        Me.IsMessage = Not String.IsNullOrEmpty(message)
        If (Not String.IsNullOrEmpty(focus)) Then
            Me.Focus = focus
        End If
    End Sub
End Class
