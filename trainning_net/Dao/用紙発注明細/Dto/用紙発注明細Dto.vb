<Serializable>
Public Class 用紙発注明細Dto
    Public Property 発注番号 As String
    Public Property 行番号 As Decimal

    Public Property 工程 As String

    Public Property 銘柄 As String

    Public Property 銘柄名 As String

    Public Property 規格 As String

    Public Property 縦 As Decimal?

    Public Property 横 As Decimal?
    Public Property 連量 As Decimal

    Public Property 厚さ As String

    Public Property RS区分 As String

    Public Property 流れ目 As String

    Public Property 連数 As Decimal?

    Public Property 本数 As Decimal?

    Public Property 数量 As Decimal

    Public Property 単位 As String

    'Public Property 単価 As Decimal
    'Public Property 金額 As Decimal

    Public Property 断数 As String

    Public Property 断裁金額 As Decimal?

    Public Property 倉庫 As String
    Public Property 納入先 As String

    Public Property 納入先名 As String

    Public Property 搬入日 As Date

    Public Property 搬入時刻 As String

    Public Property 備考 As String

    Public Property 登録日 As Date?

    Public Property 登録者 As String

    Public Property 更新日 As Date?

    Public Property 更新者 As String

End Class
