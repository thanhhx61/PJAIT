Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("買掛金", Schema:="public")>
Public Class TPL_買掛金
    <Key>
    <StringLength(8)>
    <Display(Name:="買掛金番号")>
    <Column("買掛金番号")>
    Public Property 買掛金番号 As String

    <Required>
    <StringLength(6)>
    <Display(Name:="締年月")>
    <Column("締年月")>
    Public Property 締年月 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="取引先")>
    <Column("取引先")>
    Public Property 取引先 As String

    <Required>
    <Display(Name:="前回買掛残")>
    <Column("前回買掛残")>
    Public Property 前回買掛残 As Decimal

    <Required>
    <Display(Name:="支払金額")>
    <Column("支払金額")>
    Public Property 支払金額 As Decimal

    <Required>
    <Display(Name:="繰越金額")>
    <Column("繰越金額")>
    Public Property 繰越金額 As Decimal

    <Required>
    <Display(Name:="仕入金額")>
    <Column("仕入金額")>
    Public Property 仕入金額 As Decimal

    <Required>
    <Display(Name:="消費税")>
    <Column("消費税")>
    Public Property 消費税 As Decimal

    <Required>
    <Display(Name:="買掛金合計")>
    <Column("買掛金合計")>
    Public Property 買掛金合計 As Decimal

    <Required>
    <Display(Name:="買掛金残")>
    <Column("買掛金残")>
    Public Property 買掛金残 As Decimal

    <Required>
    <Display(Name:="手形でんさい")>
    <Column("手形でんさい")>
    Public Property 手形でんさい As Decimal

    <Required>
    <Display(Name:="現金")>
    <Column("現金")>
    Public Property 現金 As Decimal

    <Required>
    <Display(Name:="小切手")>
    <Column("小切手")>
    Public Property 小切手 As Decimal

    <Required>
    <Display(Name:="振込")>
    <Column("振込")>
    Public Property 振込 As Decimal

    <Required>
    <Display(Name:="相殺")>
    <Column("相殺")>
    Public Property 相殺 As Decimal

    <Required>
    <Display(Name:="消費税調整")>
    <Column("消費税調整")>
    Public Property 消費税調整 As Decimal

    <Required>
    <Display(Name:="振込手数料")>
    <Column("振込手数料")>
    Public Property 振込手数料 As Decimal

    <Required>
    <Display(Name:="その他")>
    <Column("その他")>
    Public Property その他 As Decimal

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
