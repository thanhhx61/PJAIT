Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("運用条件", Schema:="public")>
Public Class TPL_運用条件
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="識別")>
    <Column("識別")>
    Public Property 識別 As String

    <Required>
    <StringLength(30)>
    <Display(Name:="名称")>
    <Column("名称")>
    Public Property 名称 As String

    <StringLength(100)>
    <Display(Name:="データ１")>
    <Column("データ１")>
    Public Property データ１ As String

    <StringLength(100)>
    <Display(Name:="データ２")>
    <Column("データ２")>
    Public Property データ２ As String

    <StringLength(100)>
    <Display(Name:="データ３")>
    <Column("データ３")>
    Public Property データ３ As String

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
