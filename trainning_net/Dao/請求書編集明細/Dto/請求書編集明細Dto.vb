Namespace Dto
    <Serializable>
    Public Class 請求書編集明細Dto
        Public Property No As Integer
        Public Property 内訳 As String
        Public Property 枝番 As Decimal?
        Public Property 発行日 As Date?
        Public Property 売上日 As Date?
        Public Property 売上番号 As String
        Public Property 受注番号 As String
        Public Property 品名 As String
        Public Property 数量 As Decimal?
        Public Property 単位 As String
        Public Property 単位コード As String
        Public Property 単価 As Decimal?
        Public Property 金額 As Decimal?
        Public Property 課税区分 As String
        Public Property 課税区分コード As String
        Public Property 税率 As String
        Public Property 税率コード As String
        Public Property 消費税 As Decimal?
        Public Property 備考 As String
        Public Property 印字しない As String
        Public Property チェックボックス As Boolean

        Public Property 処理種別 As String
        Public Property 印字しないChk As Boolean

        ''' <summary>
        ''' TODO
        ''' </summary>
        ''' <returns></returns>
        Public Property 処理対象行 As Decimal?
    End Class
End Namespace

