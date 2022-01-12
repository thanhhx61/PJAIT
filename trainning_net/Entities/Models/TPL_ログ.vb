Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("ログ", Schema:="public")>
Public Class TPL_ログ
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    <StringLength(13)>
    <Display(Name:="ログID")>
    <Column("ログid")>
    Public Property ログID As String

    <Display(Name:="処理日時")>
    <Column("処理日時")>
    Public Property 処理日時 As DateTime?

    <StringLength(100)>
    <Display(Name:="区分")>
    <Column("区分")>
    Public Property 区分 As String

    <StringLength(8)>
    <Display(Name:="担当")>
    <Column("担当")>
    Public Property 担当 As String

    <StringLength(100)>
    <Display(Name:="画面名")>
    <Column("画面名")>
    Public Property 画面名 As String

    <StringLength(30)>
    <Display(Name:="接続元IP")>
    <Column("接続元ip")>
    Public Property 接続元IP As String

    <StringLength(1000)>
    <Display(Name:="SQL文")>
    <Column("sql文")>
    Public Property SQL文 As String
End Class
