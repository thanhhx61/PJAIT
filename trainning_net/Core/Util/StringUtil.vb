Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports Core.ConstantCore.Consts

Namespace Util
    ''' <summary>
    ''' 文字列操作を行う汎用クラス
    ''' </summary>
    Public Class StringUtil

        ''' <summary>
        ''' Convert nothing value to empty
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Shared Function ConvertNullToEmpty(value As Object) As String
            If (value Is Nothing) Then
                Return String.Empty
            Else
                Return value.ToString
            End If
        End Function

        ''' <summary>
        ''' パスワード暗号化を処理する。
        ''' </summary>
        ''' <param name="password">パスワード</param>
        ''' <returns>パスワード暗号化</returns>
        Public Shared Function PasswordSha256(password As String) As String
            ' Init SHA256 hash for the data using the managed library
            Dim crypt = New SHA256Managed()
            Dim hash = New StringBuilder()
            ' ComputeHash method of HashAlgorithm computes a hash
            Dim crypto As Byte() = crypt.ComputeHash(Encoding.UTF8.GetBytes(password))
            For Each theByte As Byte In crypto
                ' Append exactly two hexadecimal digits
                hash.Append(theByte.ToString("x2"))
            Next
            Return hash.ToString()
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sql"></param>
        ''' <param name="obj"></param>
        ''' <returns> 
        '''  Param + Sql
        ''' </returns>
        Public Shared Function GetQueryCompleted(sql As String, obj As Object) As String
            Dim propertiesInfo = obj.GetType().GetProperties()
            Dim paramInfo = "["
            If propertiesInfo.Length = 0 Then
                Return sql
            End If
            Dim index = 0
            For Each p As PropertyInfo In propertiesInfo
                Dim propertyName = $":{p.Name}"
                Dim propertyValue As String
                If (p.GetValue(obj) IsNot Nothing) Then
                    propertyValue = If(p.PropertyType.Name <> "String", p.GetValue(obj).ToString(), $"'{p.GetValue(obj)}'")
                Else
                    propertyValue = "Null"
                End If
                If index = 0 Then
                    paramInfo = paramInfo + propertyName + ":" + propertyValue
                Else
                    paramInfo = paramInfo + ", " + propertyName + ":" + propertyValue
                End If
            Next
            Return sql + "; " + paramInfo + "]"
        End Function

        ''' <summary>
        ''' Split string to two substring by first index substring  and last index substring 
        ''' </summary>
        ''' <param name="strSplit">input string</param>
        ''' <param name="firstIndex">first index substring</param>
        ''' <param name="lasIndex">last index substring</param>
        ''' <returns></returns>
        Public Shared Function SplitStringByIndex(strSplit As String, firstIndex As Short, lasIndex As Short) As List(Of String)
            Dim str1 = String.Empty
            Dim str2 = String.Empty
            'return if string split is null or empty
            If (String.IsNullOrEmpty(strSplit)) Then
                Return New List(Of String) From {str1, str2}
            End If

            Dim strLength = strSplit.Length
            If (strLength > firstIndex) Then
                str1 = strSplit.Substring(0, firstIndex)
                If (strLength > lasIndex) Then
                    str2 = strSplit.Substring(firstIndex, lasIndex - firstIndex)
                Else
                    str2 = strSplit.Substring(firstIndex, strLength - firstIndex)
                End If
            Else
                str1 = strSplit
            End If
            Return New List(Of String) From {str1, str2}
        End Function
    End Class
End Namespace