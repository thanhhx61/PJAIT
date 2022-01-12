Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("原価", Schema:="public")>
Public Class TPL_原価
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="受注番号")>
    <Column("受注番号", Order:=0)>
    Public Property 受注番号 As String

    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="工程")>
    <Column("工程", Order:=1)>
    Public Property 工程 As String

    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="原価区分")>
    <Column("原価区分", Order:=2)>
    Public Property 原価区分 As String

    <Display(Name:="原価")>
    <Column("原価")>
    Public Property 原価 As Decimal?

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
