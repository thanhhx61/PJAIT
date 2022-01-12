Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("受注用紙", Schema:="public")>
Public Class TPL_受注用紙
    <Key>
    <StringLength(8)>
    <Display(Name:="受注番号")>
    <Column("受注番号", Order:=0)>
    Public Property 受注番号 As String

    <Key>
    <Required>
    <Display(Name:="行番号")>
    <Column("行番号", Order:=1)>
    Public Property 行番号 As Decimal

    <Required>
    <StringLength(8)>
    <Display(Name:="当先区分")>
    <Column("当先区分")>
    Public Property 当先区分 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="部品")>
    <Column("部品")>
    Public Property 部品 As String

    <Required>
    <StringLength(30)>
    <Display(Name:="部品名")>
    <Column("部品名")>
    Public Property 部品名 As String

    <Required>
    <Display(Name:="頁数")>
    <Column("頁数")>
    Public Property 頁数 As Decimal

    <Required>
    <StringLength(8)>
    <Display(Name:="銘柄")>
    <Column("銘柄")>
    Public Property 銘柄 As String

    <Required>
    <StringLength(30)>
    <Display(Name:="銘柄名")>
    <Column("銘柄名")>
    Public Property 銘柄名 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="規格")>
    <Column("規格")>
    Public Property 規格 As String

    <Required>
    <Display(Name:="縦")>
    <Column("縦")>
    Public Property 縦 As Decimal

    <Required>
    <Display(Name:="横")>
    <Column("横")>
    Public Property 横 As Decimal

    <Required>
    <StringLength(8)>
    <Display(Name:="RS区分")>
    <Column("rs区分")>
    Public Property RS区分 As String

    <Required>
    <Display(Name:="連量")>
    <Column("連量")>
    Public Property 連量 As Decimal

    <Required>
    <StringLength(8)>
    <Display(Name:="単位区分")>
    <Column("単位区分")>
    Public Property 単位区分 As String

    <Required>
    <Display(Name:="数量")>
    <Column("数量")>
    Public Property 数量 As Decimal

    <Required>
    <Display(Name:="予備")>
    <Column("予備")>
    Public Property 予備 As Decimal

    <Required>
    <Display(Name:="数量合計")>
    <Column("数量合計")>
    Public Property 数量合計 As Decimal

    <Required>
    <Display(Name:="単価")>
    <Column("単価")>
    Public Property 単価 As Decimal

    <Required>
    <Display(Name:="金額")>
    <Column("金額")>
    Public Property 金額 As Decimal

    <Display(Name:="仕切単価")>
    <Column("仕切単価")>
    Public Property 仕切単価 As Decimal?

    <Display(Name:="仕切金額")>
    <Column("仕切金額")>
    Public Property 仕切金額 As Decimal?

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
