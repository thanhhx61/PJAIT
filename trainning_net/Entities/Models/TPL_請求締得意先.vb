Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("請求締得意先", Schema:="public")>
Public Class TPL_請求締得意先
    <Key>
    <Required>
    <StringLength(2)>
    <Display(Name:="締日")>
    <Column("締日", Order:=0)>
    Public Property 締日 As String

    <Key>
    <Required>
    <Display(Name:="締対象開始日")>
    <Column("締対象開始日", Order:=1)>
    Public Property 締対象開始日 As Date

    <Key>
    <Required>
    <Display(Name:="締対象終了日")>
    <Column("締対象終了日", Order:=2)>
    Public Property 締対象終了日 As Date

    <Required>
    <Display(Name:="処理日")>
    <Column("処理日")>
    Public Property 処理日 As Date

    <Required>
    <StringLength(1)>
    <Display(Name:="状況")>
    <Column("状況")>
    Public Property 状況 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="得意先")>
    <Column("得意先")>
    Public Property 得意先 As String

End Class
