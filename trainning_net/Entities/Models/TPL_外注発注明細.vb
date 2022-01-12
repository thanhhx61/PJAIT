Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("外注発注明細", Schema:="public")>
Public Class TPL_外注発注明細
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="発注番号")>
    <Column("発注番号", Order:=0)>
    Public Property 発注番号 As String

    <Key>
    <Required>
    <Display(Name:="行番号")>
    <Column("行番号", Order:=1)>
    Public Property 行番号 As Decimal

    <Required>
    <StringLength(8)>
    <Display(Name:="工程")>
    <Column("工程")>
    Public Property 工程 As String

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
    <Display(Name:="数量")>
    <Column("数量")>
    Public Property 数量 As Decimal

    <StringLength(8)>
    <Display(Name:="単位")>
    <Column("単位")>
    Public Property 単位 As String

    <Display(Name:="単価")>
    <Column("単価")>
    Public Property 単価 As Decimal?

    <Required>
    <Display(Name:="金額")>
    <Column("金額")>
    Public Property 金額 As Decimal

    <StringLength(15)>
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
