Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("コード", Schema:="public")>
Public Class TPL_コード
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="識別")>
    <Column("識別", Order:=0)>
    Public Property 識別 As String

    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="コード")>
    <Column("コード", Order:=1)>
    Public Property コード As String

    <Required>
    <StringLength(30)>
    <Display(Name:="名称")>
    <Column("名称")>
    Public Property 名称 As String

    <Required>
    <StringLength(20)>
    <Display(Name:="略称")>
    <Column("略称")>
    Public Property 略称 As String

    <Display(Name:="数字１")>
    <Column("数字１")>
    Public Property 数字１ As Decimal?

    <Display(Name:="数字２")>
    <Column("数字２")>
    Public Property 数字２ As Decimal?

    <Display(Name:="数字３")>
    <Column("数字３")>
    Public Property 数字３ As Decimal?

    <StringLength(100)>
    <Display(Name:="文字１")>
    <Column("文字１")>
    Public Property 文字１ As String

    <StringLength(100)>
    <Display(Name:="文字２")>
    <Column("文字２")>
    Public Property 文字２ As String

    <StringLength(100)>
    <Display(Name:="文字３")>
    <Column("文字３")>
    Public Property 文字３ As String

    <Required>
    <Display(Name:="表示順")>
    <Column("表示順")>
    Public Property 表示順 As Int32

    <Display(Name:="変更不可フラグ")>
    <Column("変更不可フラグ")>
    Public Property 変更不可フラグ As Boolean?

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
