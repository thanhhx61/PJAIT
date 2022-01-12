Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("請求明細", Schema:="public")>
Public Class TPL_請求明細
    <Key>
    <Required>
    <Display(Name:="請求締日")>
    <Column("請求締日", Order:=0)>
    Public Property 請求締日 As Date

    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="取引先")>
    <Column("取引先", Order:=1)>
    Public Property 取引先 As String

    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="売上番号")>
    <Column("売上番号", Order:=2)>
    Public Property 売上番号 As String

End Class
