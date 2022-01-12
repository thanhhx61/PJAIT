Imports Core.ConstantCore.Consts

Namespace Util
    ''' <summary>
    ''' 日付操作を行う汎用クラス
    ''' </summary>
    Public Class DateUtil
        ''' <summary>
        ''' DateからStringまでに変換する。
        ''' </summary>
        ''' <param name="dateVal">日付</param>
        ''' <param name="format">日付変換フォーマット</param>
        ''' <returns></returns>
        Public Shared Function ConvertDateToString(dateVal As Date?, format As String) As String
            If dateVal Is Nothing Then
                Return String.Empty
            End If
            Return String.Format("{0:" + format + "}", dateVal)
        End Function

        ''' <summary>
        ''' StringからDateまでに変換する。
        ''' </summary>
        ''' <param name="dateString">日付</param>
        ''' <param name="format">日付変換フォーマット</param>
        ''' <returns></returns>
        Public Shared Function ConvertStringToDate(dateString As String, format As String) As DateTime
            If String.IsNullOrEmpty(dateString) Then
                Return Nothing
            End If
            Return DateTime.ParseExact(dateString, format, Globalization.CultureInfo.InvariantCulture)
        End Function

        ''' <summary>
        ''' 月を取得する。
        ''' </summary>
        ''' <param name="d1">日付１</param>
        ''' <param name="d2">日付２</param>
        ''' <returns></returns>
        Public Shared Function GetMonthBetweenDate(d1 As Date, d2 As Date) As Integer
            Return Convert.ToInt32(((d2.Year - d1.Year) * 12) + d2.Month - d1.Month) + 1
        End Function

        ''' <summary>
        ''' WEBサーバーのシステム日付を取得する。
        ''' </summary>
        ''' <param name="formatType">0：yyyy/MM/dd、1：yyyy/MM/dd HHmmss、2：yyyy/MM/dd HHmmss.fffff、3：yyyy/MM</param>
        ''' <returns></returns>
        Public Shared Function GetSysDate(formatType As String) As String
            '1. 引数の妥当性検証
            If String.IsNullOrEmpty(formatType) Then
                Return Nothing
            End If
            '2. 時刻を取得し、戻り値を返す。
            Dim format As String = String.Empty
            Select Case formatType
                Case SysdateFormat.YYYYMMDD
                    format = DateFormat.YYYYMMDD
                Case SysdateFormat.YYYYMMDDHHMMSS
                    format = DateFormat.DATETIMEFULL
                Case SysdateFormat.YYYYMMDDHHMMSSFFF
                    format = DateFormat.DATETIMEFULL_F6
                Case SysdateFormat.YYYYMM
                    format = DateFormat.YYYYMM
                Case Else
                    Return Nothing
            End Select
            Return DateUtil.ConvertDateToString(System.DateTime.Now, format)
        End Function

        ''' <summary>
        ''' システム日付の月の月初と月末を取得する。
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetSysDateStartEnd() As List(Of Date)
            '1. システム日付の月初を取得する。
            Dim firstDateOfMon = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            '2. システム日付の月末を取得する。
            Dim lastDateOfMon = firstDateOfMon.AddMonths(1).AddDays(-1)
            '1行目：パラメタ.システム日付_月初		
            '2行目：パラメタ.システム日付_月末
            Return New List(Of Date)({firstDateOfMon, lastDateOfMon})
        End Function
    End Class
End Namespace

