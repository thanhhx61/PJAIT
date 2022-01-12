Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("受注加工", Schema:="public")>
Public Class TPL_受注加工
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
    <Display(Name:="内外区分")>
    <Column("内外区分")>
    Public Property 内外区分 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="作業")>
    <Column("作業")>
    Public Property 作業 As String

    <Required>
    <StringLength(30)>
    <Display(Name:="作業名")>
    <Column("作業名")>
    Public Property 作業名 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="サイズ")>
    <Column("サイズ")>
    Public Property サイズ As String

    <Required>
    <StringLength(30)>
    <Display(Name:="サイズ名")>
    <Column("サイズ名")>
    Public Property サイズ名 As String

    <Required>
    <Display(Name:="数量")>
    <Column("数量")>
    Public Property 数量 As Decimal

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
