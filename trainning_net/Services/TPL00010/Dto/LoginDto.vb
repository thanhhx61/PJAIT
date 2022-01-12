Imports System.ComponentModel.DataAnnotations

Namespace Dto
    <Serializable>
    Public Class LoginDto
        Public Sub New()
        End Sub

        Public Sub New(userId As String, passWord As String)
            Me.UserId = userId
            Me.Password = passWord
        End Sub

        Public Sub New(userId As String, passWord As String, iPAddress As String)
            Me.UserId = userId
            Me.Password = passWord
            Me.IPAddress = iPAddress
        End Sub

        Public Property UserId As String
        Public Property Password As String
        Public Property IPAddress As String
    End Class

End Namespace

