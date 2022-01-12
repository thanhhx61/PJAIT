Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("原価単価", Schema:="public")>
Public Class TPL_原価単価
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="原価単価")>
    <Column("原価単価")>
    Public Property 原価単価 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="適用区分")>
    <Column("適用区分")>
    Public Property 適用区分 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="工程")>
    <Column("工程")>
    Public Property 工程 As String

    <StringLength(8)>
    <Display(Name:="作業")>
    <Column("作業")>
    Public Property 作業 As String

    <StringLength(8)>
    <Display(Name:="サイズ")>
    <Column("サイズ")>
    Public Property サイズ As String

    <StringLength(8)>
    <Display(Name:="印刷機種")>
    <Column("印刷機種")>
    Public Property 印刷機種 As String

    <StringLength(8)>
    <Display(Name:="銘柄")>
    <Column("銘柄")>
    Public Property 銘柄 As String

    <Display(Name:="通し数から")>
    <Column("通し数から")>
    Public Property 通し数から As Decimal?

    <Display(Name:="通し数まで")>
    <Column("通し数まで")>
    Public Property 通し数まで As Decimal?

    <Display(Name:="数量から")>
    <Column("数量から")>
    Public Property 数量から As Decimal?

    <Display(Name:="数量まで")>
    <Column("数量まで")>
    Public Property 数量まで As Decimal?

    <Display(Name:="単価")>
    <Column("単価")>
    Public Property 単価 As Decimal?

    <Display(Name:="刷版単価")>
    <Column("刷版単価")>
    Public Property 刷版単価 As Decimal?

    <Display(Name:="台数単価")>
    <Column("台数単価")>
    Public Property 台数単価 As Decimal?

    <Display(Name:="kg単価")>
    <Column("kg単価")>
    Public Property kg単価 As Decimal?

    <Display(Name:="枚単価")>
    <Column("枚単価")>
    Public Property 枚単価 As Decimal?

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
