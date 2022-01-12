Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("売上明細", Schema:="public")>
Public Class TPL_売上明細
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="売上番号")>
    <Column("売上番号", Order:=0)>
    Public Property 売上番号 As String

    <Key>
    <Required>
    <Display(Name:="内訳番号")>
    <Column("内訳番号", Order:=1)>
    Public Property 内訳番号 As Decimal

    <Required>
    <StringLength(8)>
    <Display(Name:="工程")>
    <Column("工程")>
    Public Property 工程 As String

    <StringLength(20)>
    <Display(Name:="品名")>
    <Column("品名")>
    Public Property 品名 As String

    <Display(Name:="売上数量")>
    <Column("売上数量")>
    Public Property 売上数量 As Decimal?

    <StringLength(8)>
    <Display(Name:="単位")>
    <Column("単位")>
    Public Property 単位 As String

    <Display(Name:="売上単価")>
    <Column("売上単価")>
    Public Property 売上単価 As Decimal?

    <Required>
    <Display(Name:="売上金額")>
    <Column("売上金額")>
    Public Property 売上金額 As Decimal

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
