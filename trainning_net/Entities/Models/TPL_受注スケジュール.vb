Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("受注スケジュール", Schema:="public")>
Public Class TPL_受注スケジュール
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="受注番号")>
    <Column("受注番号")>
    Public Property 受注番号 As String

    <Display(Name:="入稿")>
    <Column("入稿")>
    Public Property 入稿 As Date?

    <StringLength(20)>
    <Display(Name:="入稿備考")>
    <Column("入稿備考")>
    Public Property 入稿備考 As String

    <Display(Name:="初校")>
    <Column("初校")>
    Public Property 初校 As Date?

    <StringLength(20)>
    <Display(Name:="初校備考")>
    <Column("初校備考")>
    Public Property 初校備考 As String

    <Display(Name:="再校")>
    <Column("再校")>
    Public Property 再校 As Date?

    <StringLength(20)>
    <Display(Name:="再校備考")>
    <Column("再校備考")>
    Public Property 再校備考 As String

    <Display(Name:="三校")>
    <Column("三校")>
    Public Property 三校 As Date?

    <StringLength(20)>
    <Display(Name:="三校備考")>
    <Column("三校備考")>
    Public Property 三校備考 As String

    <Display(Name:="下版")>
    <Column("下版")>
    Public Property 下版 As Date?

    <StringLength(20)>
    <Display(Name:="下版備考")>
    <Column("下版備考")>
    Public Property 下版備考 As String

    <Display(Name:="刷版")>
    <Column("刷版")>
    Public Property 刷版 As Date?

    <StringLength(20)>
    <Display(Name:="刷版備考")>
    <Column("刷版備考")>
    Public Property 刷版備考 As String

    <Display(Name:="印刷")>
    <Column("印刷")>
    Public Property 印刷 As Date?

    <StringLength(20)>
    <Display(Name:="印刷備考")>
    <Column("印刷備考")>
    Public Property 印刷備考 As String

    <Display(Name:="加工")>
    <Column("加工")>
    Public Property 加工 As Date?

    <StringLength(20)>
    <Display(Name:="加工備考")>
    <Column("加工備考")>
    Public Property 加工備考 As String

    <StringLength(30)>
    <Display(Name:="メモ1")>
    <Column("メモ1")>
    Public Property メモ1 As String

    <StringLength(30)>
    <Display(Name:="メモ2")>
    <Column("メモ2")>
    Public Property メモ2 As String

    <StringLength(30)>
    <Display(Name:="メモ3")>
    <Column("メモ3")>
    Public Property メモ3 As String

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
