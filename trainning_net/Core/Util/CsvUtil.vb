Imports System.IO
Imports System.Text
Imports System.Web
Imports Core.ConstantCore.Consts
Imports Core.Util.DateUtil

Namespace Util
    ''' <summary>
    ''' CSVファイル操作のユーティリティクラス
    ''' </summary>
    Public Class CsvUtil

        ''' <summary>
        ''' ヘッダ行の出力
        ''' </summary>
        ''' <param name="headers"></param>
        ''' <returns></returns>
        Public Shared Function CreateHeaderRow(headers As List(Of String)) As StringBuilder
            Dim sb = New StringBuilder()
            For Each head As String In headers
                sb.Append(CSVFile.SGQUOTE + head + CSVFile.SGQUOTE)
                If Not head = headers.Last Then
                    sb.Append(CSVFile.DELIMITER)
                End If
            Next
            sb.AppendLine()
            Return sb
        End Function

        ''' <summary>
        '''  データの出力
        ''' </summary>
        ''' <param name="values"></param>
        ''' <returns></returns>
        Public Shared Function CreateValueRow(values As List(Of String)) As StringBuilder
            Dim sb = New StringBuilder()
            Dim index = 1
            For Each value As String In values
                If value Is Nothing Then
                    value = String.Empty
                End If
                sb.Append(CSVFile.SGQUOTE + value + CSVFile.SGQUOTE)
                If index < values.Count Then
                    sb.Append(CSVFile.DELIMITER)
                End If
                index = index + 1
            Next
            sb.AppendLine()
            Return sb
        End Function

    End Class
End Namespace

