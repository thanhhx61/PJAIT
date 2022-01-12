Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("受注基本", Schema:="public")>
Public Class TPL_受注基本
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="受注番号")>
    <Column("受注番号")>
    Public Property 受注番号 As String

    <StringLength(8)>
    <Display(Name:="参照元受注番号")>
    <Column("参照元受注番号")>
    Public Property 参照元受注番号 As String

    <StringLength(10)>
    <Display(Name:="先方注番")>
    <Column("先方注番")>
    Public Property 先方注番 As String

    <Required>
    <StringLength(30)>
    <Display(Name:="品名")>
    <Column("品名")>
    Public Property 品名 As String

    <StringLength(20)>
    <Display(Name:="品名備考")>
    <Column("品名備考")>
    Public Property 品名備考 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="得意先")>
    <Column("得意先")>
    Public Property 得意先 As String

    <Required>
    <StringLength(30)>
    <Display(Name:="得意先名")>
    <Column("得意先名")>
    Public Property 得意先名 As String

    <Required>
    <StringLength(6)>
    <Display(Name:="担当")>
    <Column("担当")>
    Public Property 担当 As String

    <Required>
    <StringLength(10)>
    <Display(Name:="担当名")>
    <Column("担当名")>
    Public Property 担当名 As String

    <StringLength(8)>
    <Display(Name:="部署")>
    <Column("部署")>
    Public Property 部署 As String

    <StringLength(10)>
    <Display(Name:="部署名")>
    <Column("部署名")>
    Public Property 部署名 As String

    <StringLength(8)>
    <Display(Name:="伝票区分")>
    <Column("伝票区分")>
    Public Property 伝票区分 As String

    <StringLength(8)>
    <Display(Name:="受注区分")>
    <Column("受注区分")>
    Public Property 受注区分 As String

    <StringLength(8)>
    <Display(Name:="製品種別")>
    <Column("製品種別")>
    Public Property 製品種別 As String

    <Required>
    <Display(Name:="受注日")>
    <Column("受注日")>
    Public Property 受注日 As Date

    <Required>
    <Display(Name:="納品日")>
    <Column("納品日")>
    Public Property 納品日 As Date

    <Display(Name:="検収日")>
    <Column("検収日")>
    Public Property 検収日 As Date?

    <StringLength(8)>
    <Display(Name:="製品サイズ")>
    <Column("製品サイズ")>
    Public Property 製品サイズ As String

    <Display(Name:="縦")>
    <Column("縦")>
    Public Property 縦 As Decimal?

    <Display(Name:="横")>
    <Column("横")>
    Public Property 横 As Decimal?

    <Display(Name:="頁数")>
    <Column("頁数")>
    Public Property 頁数 As Decimal?

    <Display(Name:="受注数量")>
    <Column("受注数量")>
    Public Property 受注数量 As Decimal?

    <Display(Name:="受注単価")>
    <Column("受注単価")>
    Public Property 受注単価 As Decimal?

    <Required>
    <Display(Name:="受注金額")>
    <Column("受注金額")>
    Public Property 受注金額 As Decimal

    <Display(Name:="社内原価")>
    <Column("社内原価")>
    Public Property 社内原価 As Decimal?

    <Display(Name:="明細仕切金額")>
    <Column("明細仕切金額")>
    Public Property 明細仕切金額 As Decimal?

    <StringLength(8)>
    <Display(Name:="単位")>
    <Column("単位")>
    Public Property 単位 As String

    <StringLength(1)>
    <Display(Name:="FSC")>
    <Column("fsc")>
    Public Property FSC As String

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

    <StringLength(30)>
    <Display(Name:="メモ4")>
    <Column("メモ4")>
    Public Property メモ4 As String

    <StringLength(30)>
    <Display(Name:="メモ5")>
    <Column("メモ5")>
    Public Property メモ5 As String

    <StringLength(30)>
    <Display(Name:="メモ6")>
    <Column("メモ6")>
    Public Property メモ6 As String

    <StringLength(30)>
    <Display(Name:="メモ7")>
    <Column("メモ7")>
    Public Property メモ7 As String

    <StringLength(30)>
    <Display(Name:="メモ8")>
    <Column("メモ8")>
    Public Property メモ8 As String

    <StringLength(30)>
    <Display(Name:="メモ9")>
    <Column("メモ9")>
    Public Property メモ9 As String

    <StringLength(30)>
    <Display(Name:="メモ10")>
    <Column("メモ10")>
    Public Property メモ10 As String

    <StringLength(100)>
    <Display(Name:="受注範囲")>
    <Column("受注範囲")>
    Public Property 受注範囲 As String

    <StringLength(1)>
    <Display(Name:="完納区分")>
    <Column("完納区分")>
    Public Property 完納区分 As String

    <Display(Name:="削除フラグ")>
    <Column("削除フラグ")>
    Public Property 削除フラグ As Boolean?

    <Display(Name:="更新回数")>
    <Column("更新回数")>
    Public Property 更新回数 As Integer?

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
