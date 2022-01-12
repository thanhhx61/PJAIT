Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("請求書編集明細", Schema:="public")>
Public Class TPL_請求書編集明細
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="請求書番号")>
    <Column("請求書番号", Order:=0)>
    Public Property 請求書番号 As String

    <Key>
    <Required>
    <Display(Name:="行番号")>
    <Column("行番号", Order:=1)>
    Public Property 行番号 As Decimal

    <StringLength(8)>
    <Display(Name:="売上番号")>
    <Column("売上番号")>
    Public Property 売上番号 As String

    <StringLength(8)>
    <Display(Name:="受注番号")>
    <Column("受注番号")>
    Public Property 受注番号 As String

    <Required>
    <Display(Name:="売上日")>
    <Column("売上日")>
    Public Property 売上日 As Date

    <Required>
    <StringLength(20)>
    <Display(Name:="品名")>
    <Column("品名")>
    Public Property 品名 As String

    <Display(Name:="数量")>
    <Column("数量")>
    Public Property 数量 As Decimal?

    <Display(Name:="単価")>
    <Column("単価")>
    Public Property 単価 As Decimal?

    <Required>
    <Display(Name:="金額")>
    <Column("金額")>
    Public Property 金額 As Decimal

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

    <Display(Name:="消費税")>
    <Column("消費税")>
    Public Property 消費税 As Decimal?

    <StringLength(30)>
    <Display(Name:="備考")>
    <Column("備考")>
    Public Property 備考 As String

    <Required>
    <StringLength(1)>
    <Display(Name:="印字しない")>
    <Column("印字しない")>
    Public Property 印字しない As String

    <Required>
    <Display(Name:="発行日")>
    <Column("発行日")>
    Public Property 発行日 As Date

    <Display(Name:="枝番")>
    <Column("枝番")>
    Public Property 枝番 As Decimal?

    <StringLength(1)>
    <Display(Name:="内訳")>
    <Column("内訳")>
    Public Property 内訳 As String

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
