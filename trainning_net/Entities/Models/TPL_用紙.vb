Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("用紙", Schema:="public")>
Public Class TPL_用紙
    <Key>
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
    <Display(Name:="品種")>
    <Column("品種")>
    Public Property 品種 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="メーカー")>
    <Column("メーカー")>
    Public Property メーカー As String

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
