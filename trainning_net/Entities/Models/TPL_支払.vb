Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("支払", Schema:="public")>
Public Class TPL_支払
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="支払番号")>
    <Column("支払番号")>
    Public Property 支払番号 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="取引先")>
    <Column("取引先")>
    Public Property 取引先 As String

    <Required>
    <Display(Name:="支払日")>
    <Column("支払日")>
    Public Property 支払日 As Date

    <Required>
    <StringLength(8)>
    <Display(Name:="取引区分")>
    <Column("取引区分")>
    Public Property 取引区分 As String

    <StringLength(8)>
    <Display(Name:="手形内訳")>
    <Column("手形内訳")>
    Public Property 手形内訳 As String

    <Display(Name:="手形期日")>
    <Column("手形期日")>
    Public Property 手形期日 As Date?

    <Required>
    <Display(Name:="金額")>
    <Column("金額")>
    Public Property 金額 As Decimal

    <StringLength(20)>
    <Display(Name:="備考")>
    <Column("備考")>
    Public Property 備考 As String

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
