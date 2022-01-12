Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("買掛締仕入先", Schema:="public")>
Public Class TPL_買掛締仕入先
    <Key>
    <Required>
    <StringLength(6)>
    <Display(Name:="締年月")>
    <Column("締年月", Order:=0)>
    Public Property 締年月 As String

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
    <Display(Name:="仕入先")>
    <Column("仕入先")>
    Public Property 仕入先 As String

End Class
