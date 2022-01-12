Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("担当", Schema:="public")>
Public Class TPL_担当
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="担当")>
    <Column("担当")>
    Public Property 担当 As String

    <Required>
    <StringLength(30)>
    <Display(Name:="氏名")>
    <Column("氏名")>
    Public Property 氏名 As String

    <Required>
    <StringLength(30)>
    <Display(Name:="ふりがな")>
    <Column("ふりがな")>
    Public Property ふりがな As String

    <Required>
    <StringLength(8)>
    <Display(Name:="部署")>
    <Column("部署")>
    Public Property 部署 As String

    <Required>
    <StringLength(100)>
    <Display(Name:="パスワード")>
    <Column("パスワード")>
    Public Property パスワード As String

    <StringLength(8)>
    <Display(Name:="メニュー権限")>
    <Column("メニュー権限")>
    Public Property メニュー権限 As String

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

    <StringLength(100)>
    <Display(Name:="データ４")>
    <Column("データ４")>
    Public Property データ４ As String

    <StringLength(100)>
    <Display(Name:="データ５")>
    <Column("データ５")>
    Public Property データ５ As String

    <StringLength(100)>
    <Display(Name:="データ６")>
    <Column("データ６")>
    Public Property データ６ As String

    <StringLength(100)>
    <Display(Name:="データ７")>
    <Column("データ７")>
    Public Property データ７ As String

    <StringLength(100)>
    <Display(Name:="データ８")>
    <Column("データ８")>
    Public Property データ８ As String

    <StringLength(100)>
    <Display(Name:="データ９")>
    <Column("データ９")>
    Public Property データ９ As String

    <StringLength(100)>
    <Display(Name:="データ１０")>
    <Column("データ１０")>
    Public Property データ１０ As String

    <StringLength(1)>
    <Display(Name:="使用可否")>
    <Column("使用可否")>
    Public Property 使用可否 As String

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
