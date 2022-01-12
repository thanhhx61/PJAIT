Imports System.IO

Namespace Util
    Public Class FileUtil

        Public Shared Sub SaveStreamAsFile(ByVal filePath As String, ByVal inputStream As Stream, ByVal fileName As String)
            Dim info As New DirectoryInfo(filePath)
            If Not info.Exists Then
                info.Create()
            End If

            Using outputFileStream As New FileStream(filePath + fileName, FileMode.Create)
                inputStream.CopyTo(outputFileStream)
            End Using
        End Sub

        Public Shared Function SelectFileByFilePathAndFileName(filePath As String, fileName As String) As Stream
            Return File.OpenRead(Path.Combine(filePath, fileName))
        End Function
    End Class

End Namespace
