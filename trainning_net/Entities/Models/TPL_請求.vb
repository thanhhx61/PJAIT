Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("請求", Schema:="public")>
Public Class TPL_請求
    <Key>
    <StringLength(8)>
    <Display(Name:="請求書番号")>
    <Column("請求書番号")>
    Public Property 請求書番号 As String

    <Required>
    <Display(Name:="請求締日")>
    <Column("請求締日")>
    Public Property 請求締日 As Date

    <Required>
    <StringLength(8)>
    <Display(Name:="取引先")>
    <Column("取引先")>
    Public Property 取引先 As String

    <Required>
    <Display(Name:="前回請求残")>
    <Column("前回請求残")>
    Public Property 前回請求残 As Decimal

    <Required>
    <Display(Name:="入金金額")>
    <Column("入金金額")>
    Public Property 入金金額 As Decimal

    <Required>
    <Display(Name:="繰越金額")>
    <Column("繰越金額")>
    Public Property 繰越金額 As Decimal

    <Required>
    <Display(Name:="請求金額")>
    <Column("請求金額")>
    Public Property 請求金額 As Decimal

    <Required>
    <Display(Name:="消費税")>
    <Column("消費税")>
    Public Property 消費税 As Decimal

    <Required>
    <Display(Name:="請求金額合計")>
    <Column("請求金額合計")>
    Public Property 請求金額合計 As Decimal

    <Required>
    <Display(Name:="請求金額総計")>
    <Column("請求金額総計")>
    Public Property 請求金額総計 As Decimal

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
