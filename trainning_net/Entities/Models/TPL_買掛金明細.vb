Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("買掛金明細", Schema:="public")>
Public Class TPL_買掛金明細
    <Key>
    <Required>
    <StringLength(6)>
    <Display(Name:="締年月")>
    <Column("締年月", Order:=0)>
    Public Property 締年月 As String

    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="取引先")>
    <Column("取引先", Order:=1)>
    Public Property 取引先 As String

    <Key>
    <Required>
    <StringLength(1)>
    <Display(Name:="対象区分")>
    <Column("対象区分", Order:=2)>
    Public Property 対象区分 As String

    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="対象番号")>
    <Column("対象番号", Order:=3)>
    Public Property 対象番号 As String

End Class
