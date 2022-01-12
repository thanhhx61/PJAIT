Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("エラーログ", Schema:="public")>
Public Class TPL_エラーログ

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    <StringLength(13)>
    <Display(Name:="エラーログID")>
    <Column("エラーログid")>
    Public Property エラーログID As String

    <Display(Name:="処理日時")>
    <Column("処理日時")>
    Public Property 処理日時 As DateTime?

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
    <Display(Name:="エラー内容")>
    <Column("エラー内容")>
    Public Property エラー内容 As String

    <StringLength(1000)>
    <Display(Name:="エラー詳細")>
    <Column("エラー詳細")>
    Public Property エラー詳細 As String

End Class
