Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("自社", Schema:="public")>
Public Class TPL_自社
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="コード")>
    <Column("コード")>
    Public Property コード As String

    <Required>
    <StringLength(30)>
    <Display(Name:="名称")>
    <Column("名称")>
    Public Property 名称 As String

    <Required>
    <StringLength(30)>
    <Display(Name:="略称")>
    <Column("略称")>
    Public Property 略称 As String

    <StringLength(30)>
    <Display(Name:="支店名")>
    <Column("支店名")>
    Public Property 支店名 As String

    <StringLength(30)>
    <Display(Name:="よみ")>
    <Column("よみ")>
    Public Property よみ As String

    <StringLength(30)>
    <Display(Name:="住所１")>
    <Column("住所１")>
    Public Property 住所１ As String

    <StringLength(30)>
    <Display(Name:="住所２")>
    <Column("住所２")>
    Public Property 住所２ As String

    <StringLength(30)>
    <Display(Name:="郵便番号")>
    <Column("郵便番号")>
    Public Property 郵便番号 As String

    <StringLength(30)>
    <Display(Name:="電話番号FAX")>
    <Column("電話番号fax")>
    Public Property 電話番号FAX As String

    <StringLength(30)>
    <Display(Name:="FSCNo")>
    <Column("fscno")>
    Public Property FSCNo As String

    <Required>
    <StringLength(2)>
    <Display(Name:="買掛金締日")>
    <Column("買掛金締日")>
    Public Property 買掛金締日 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="買掛金税端数処理")>
    <Column("買掛金税端数処理")>
    Public Property 買掛金税端数処理 As String

    <Required>
    <StringLength(2)>
    <Display(Name:="売掛金締日")>
    <Column("売掛金締日")>
    Public Property 売掛金締日 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="売掛金税端数処理")>
    <Column("売掛金税端数処理")>
    Public Property 売掛金税端数処理 As String

    <StringLength(100)>
    <Display(Name:="振込先銀行1")>
    <Column("振込先銀行1")>
    Public Property 振込先銀行1 As String

    <StringLength(100)>
    <Display(Name:="振込先銀行2")>
    <Column("振込先銀行2")>
    Public Property 振込先銀行2 As String

    <StringLength(100)>
    <Display(Name:="振込先銀行3")>
    <Column("振込先銀行3")>
    Public Property 振込先銀行3 As String

    <Display(Name:="登録日")>
    <Column("登録日")>
    Public Property 登録日 As Date?

    <StringLength(6)>
    <Display(Name:="登録者")>
    <Column("登録者")>
    Public Property 登録者 As String

    <Display(Name:="更新日")>
    <Column("更新日")>
    Public Property 更新日 As Date?

    <StringLength(6)>
    <Display(Name:="更新者")>
    <Column("更新者")>
    Public Property 更新者 As String

End Class
