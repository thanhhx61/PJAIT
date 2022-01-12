Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("用紙仕入基本", Schema:="public")>
Public Class TPL_用紙仕入基本
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="仕入番号")>
    <Column("仕入番号")>
    Public Property 仕入番号 As String

    <Required>
    <Display(Name:="仕入日")>
    <Column("仕入日")>
    Public Property 仕入日 As Date

    <Required>
    <StringLength(8)>
    <Display(Name:="発注先")>
    <Column("発注先")>
    Public Property 発注先 As String

    <Required>
    <StringLength(10)>
    <Display(Name:="発注先名")>
    <Column("発注先名")>
    Public Property 発注先名 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="取引区分")>
    <Column("取引区分")>
    Public Property 取引区分 As String

    <Display(Name:="その他経費")>
    <Column("その他経費")>
    Public Property その他経費 As Decimal?

    <StringLength(8)>
    <Display(Name:="その他経費課税区分")>
    <Column("その他経費課税区分")>
    Public Property その他経費課税区分 As String

    <StringLength(8)>
    <Display(Name:="その他経費税率")>
    <Column("その他経費税率")>
    Public Property その他経費税率 As String

    <Display(Name:="値引")>
    <Column("値引")>
    Public Property 値引 As Decimal?

    <StringLength(8)>
    <Display(Name:="値引課税区分")>
    <Column("値引課税区分")>
    Public Property 値引課税区分 As String

    <StringLength(8)>
    <Display(Name:="値引税率")>
    <Column("値引税率")>
    Public Property 値引税率 As String

    <Required>
    <Display(Name:="金額")>
    <Column("金額")>
    Public Property 金額 As Decimal

    <Required>
    <Display(Name:="合計")>
    <Column("合計")>
    Public Property 合計 As Decimal

    <Required>
    <Display(Name:="支払予定日")>
    <Column("支払予定日")>
    Public Property 支払予定日 As Date

    <StringLength(30)>
    <Display(Name:="備考1")>
    <Column("備考1")>
    Public Property 備考1 As String

    <StringLength(30)>
    <Display(Name:="備考2")>
    <Column("備考2")>
    Public Property 備考2 As String

    <StringLength(30)>
    <Display(Name:="備考3")>
    <Column("備考3")>
    Public Property 備考3 As String

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
