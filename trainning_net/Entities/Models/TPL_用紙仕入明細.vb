Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("用紙仕入明細", Schema:="public")>
Public Class TPL_用紙仕入明細
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="仕入番号")>
    <Column("仕入番号", Order:=0)>
    Public Property 仕入番号 As String

    <Key>
    <Required>
    <Display(Name:="連番")>
    <Column("連番", Order:=1)>
    Public Property 連番 As Decimal

    <Required>
    <StringLength(8)>
    <Display(Name:="発注番号")>
    <Column("発注番号")>
    Public Property 発注番号 As String

    <Required>
    <Display(Name:="発注日")>
    <Column("発注日")>
    Public Property 発注日 As Date

    <Required>
    <StringLength(6)>
    <Display(Name:="発注担当")>
    <Column("発注担当")>
    Public Property 発注担当 As String

    <Required>
    <StringLength(10)>
    <Display(Name:="発注担当名")>
    <Column("発注担当名")>
    Public Property 発注担当名 As String

    <Required>
    <Display(Name:="行番号")>
    <Column("行番号")>
    Public Property 行番号 As Decimal

    <StringLength(8)>
    <Display(Name:="受注番号")>
    <Column("受注番号")>
    Public Property 受注番号 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="工程")>
    <Column("工程")>
    Public Property 工程 As String

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
    <Display(Name:="数量")>
    <Column("数量")>
    Public Property 数量 As Decimal

    <Required>
    <StringLength(8)>
    <Display(Name:="単位")>
    <Column("単位")>
    Public Property 単位 As String

    <Required>
    <Display(Name:="単価")>
    <Column("単価")>
    Public Property 単価 As Decimal

    <Required>
    <Display(Name:="金額")>
    <Column("金額")>
    Public Property 金額 As Decimal

    <Required>
    <StringLength(8)>
    <Display(Name:="課税区分")>
    <Column("課税区分")>
    Public Property 課税区分 As String

    <StringLength(8)>
    <Display(Name:="税率")>
    <Column("税率")>
    Public Property 税率 As String

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
