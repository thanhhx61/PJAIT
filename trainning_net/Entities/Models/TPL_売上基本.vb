Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("売上基本", Schema:="public")>
Public Class TPL_売上基本
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="売上番号")>
    <Column("売上番号", Order:=0)>
    Public Property 売上番号 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="受注番号")>
    <Column("受注番号")>
    Public Property 受注番号 As String

    <Key>
    <Required>
    <Display(Name:="行番号")>
    <Column("行番号", Order:=1)>
    Public Property 行番号 As Decimal

    <Required>
    <StringLength(8)>
    <Display(Name:="得意先")>
    <Column("得意先")>
    Public Property 得意先 As String

    <Required>
    <StringLength(30)>
    <Display(Name:="得意先名")>
    <Column("得意先名")>
    Public Property 得意先名 As String

    <Required>
    <Display(Name:="売上日")>
    <Column("売上日")>
    Public Property 売上日 As Date

    <Required>
    <Display(Name:="請求日")>
    <Column("請求日")>
    Public Property 請求日 As Date

    <Required>
    <StringLength(8)>
    <Display(Name:="請求月")>
    <Column("請求月")>
    Public Property 請求月 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="取引区分")>
    <Column("取引区分")>
    Public Property 取引区分 As String

    <Required>
    <StringLength(20)>
    <Display(Name:="品名")>
    <Column("品名")>
    Public Property 品名 As String

    <Display(Name:="売上数量")>
    <Column("売上数量")>
    Public Property 売上数量 As Decimal?

    <Display(Name:="売上単価")>
    <Column("売上単価")>
    Public Property 売上単価 As Decimal?

    <Required>
    <Display(Name:="売上金額")>
    <Column("売上金額")>
    Public Property 売上金額 As Decimal

    <StringLength(8)>
    <Display(Name:="単位")>
    <Column("単位")>
    Public Property 単位 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="課税区分")>
    <Column("課税区分")>
    Public Property 課税区分 As String

    <StringLength(8)>
    <Display(Name:="税率")>
    <Column("税率")>
    Public Property 税率 As String

    <StringLength(30)>
    <Display(Name:="備考")>
    <Column("備考")>
    Public Property 備考 As String

    <Display(Name:="削除フラグ")>
    <Column("削除フラグ")>
    Public Property 削除フラグ As Boolean?

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
