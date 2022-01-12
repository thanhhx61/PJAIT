<Serializable>
Public Class SearchOrderResultDto
    Public Sub New()
    End Sub

    Public Property 受注番号 As String
    Public Property 得意先名 As String
    Public Property 品名 As String
    Public Property 受注数量 As Decimal?
    Public Property 受注単価 As Decimal?
    Public Property 受注金額 As Decimal
    Public Property 受注日 As Date?
    Public Property 納品日 As Date?
    Public Property 検収日 As Date?
    Public Property 売上金額 As Decimal



    Public Property 売上番号 As String
    Public Property 売上日 As Date?
    Public Property 請求日 As Date?
    Public Property 取引区分 As String
    Public Property 消費税 As Decimal?
    Public Property 受注担当 As String
    Public Property 得意先 As String









    Public Function Cal受注残金額() As Decimal
        Return 受注金額 - 売上金額
    End Function
End Class
