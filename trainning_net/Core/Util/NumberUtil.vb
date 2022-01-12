Namespace Util
    ''' <summary>
    ''' 数操作を行う汎用クラス
    ''' </summary>
    Public Class NumberUtil
        ''' <summary>
        ''' Convert number to string with format
        ''' </summary>
        ''' <param name="value">数値</param>
        ''' <param name="format">数変換フォーマット</param>
        ''' <returns></returns>
        Public Shared Function ConvertNumToStrFormat(value As Decimal?, format As String, Optional isEmpty As Boolean = False) As String
            If value Is Nothing Then
                If isEmpty Then
                    Return String.Empty
                Else
                    value = 0
                End If
            End If
            ' Convert number to string with format
            Return value.GetValueOrDefault.ToString(format)
        End Function

        ''' <summary>
        ''' Convert to Integer
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>数値(INTEGER)</returns>
        Public Shared Function ConvertToInteger(value As Object) As Integer
            If value = Nothing OrElse String.IsNullOrEmpty(value) Then
                Return 0
            End If
            ' Convert to Integer
            Return Integer.Parse(value)
        End Function

        ''' <summary>
        ''' Convert to Decimal
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>数値(DECIMAL)</returns>
        Public Shared Function ConvertToDecimal(value As Object) As Decimal
            If value = Nothing OrElse String.IsNullOrEmpty(value) Then
                Return 0
            End If
            ' Convert to Decimal
            Return Decimal.Parse(value)
        End Function
    End Class
End Namespace
