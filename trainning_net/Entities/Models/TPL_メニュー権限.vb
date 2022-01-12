Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("メニュー権限", Schema:="public")>
Public Class TPL_メニュー権限
    <Key>
    <StringLength(8)>
    <Display(Name:="メニュー権限")>
    <Column("メニュー権限")>
    Public Property メニュー権限 As String

    <StringLength(30)>
    <Display(Name:="名称")>
    <Column("名称")>
    Public Property 名称 As String

    <Display(Name:="表示順")>
    <Column("表示順")>
    Public Property 表示順 As Int32?

    <StringLength(1)>
    <Display(Name:="使用可否")>
    <Column("使用可否")>
    Public Property 使用可否 As String

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
