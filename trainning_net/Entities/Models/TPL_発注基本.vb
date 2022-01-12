Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("発注基本", Schema:="public")>
Public Class TPL_発注基本
    Public Sub New()
    End Sub

    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="発注番号")>
    <Column("発注番号")>
    Public Property 発注番号 As String

    <StringLength(8)>
    <Display(Name:="受注番号")>
    <Column("受注番号")>
    Public Property 受注番号 As String

    <Required>
    <StringLength(1)>
    <Display(Name:="発注区分")>
    <Column("発注区分")>
    Public Property 発注区分 As String

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
    <StringLength(6)>
    <Display(Name:="発注部署")>
    <Column("発注部署")>
    Public Property 発注部署 As String

    <Required>
    <StringLength(10)>
    <Display(Name:="発注部署名")>
    <Column("発注部署名")>
    Public Property 発注部署名 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="発注先")>
    <Column("発注先")>
    Public Property 発注先 As String

    <Required>
    <StringLength(30)>
    <Display(Name:="発注先名")>
    <Column("発注先名")>
    Public Property 発注先名 As String

    <StringLength(8)>
    <Display(Name:="納入先")>
    <Column("納入先")>
    Public Property 納入先 As String

    <StringLength(30)>
    <Display(Name:="納入先名")>
    <Column("納入先名")>
    Public Property 納入先名 As String

    <StringLength(30)>
    <Display(Name:="納入先テキスト")>
    <Column("納入先テキスト")>
    Public Property 納入先テキスト As String

    <Display(Name:="納期")>
    <Column("納期")>
    Public Property 納期 As Date?

    <StringLength(4)>
    <Display(Name:="納期時刻")>
    <Column("納期時刻")>
    Public Property 納期時刻 As String

    <Display(Name:="金額")>
    <Column("金額")>
    Public Property 金額 As Decimal?

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

    <Display(Name:="帳票出力日")>
    <Column("帳票出力日")>
    Public Property 帳票出力日 As Date?

    <StringLength(1)>
    <Display(Name:="完了区分")>
    <Column("完了区分")>
    Public Property 完了区分 As String

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
