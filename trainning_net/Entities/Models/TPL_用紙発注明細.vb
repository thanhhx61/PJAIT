Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("用紙発注明細", Schema:="public")>
Public Class TPL_用紙発注明細
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="発注番号")>
    <Column("発注番号", Order:=0)>
    Public Property 発注番号 As String

    <Key>
    <Required>
    <Display(Name:="行番号")>
    <Column("行番号", Order:=1)>
    Public Property 行番号 As Decimal

    <Required>
    <StringLength(8)>
    <Display(Name:="工程")>
    <Column("工程")>
    Public Property 工程 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="銘柄")>
    <Column("銘柄")>
    Public Property 銘柄 As String

    <Required>
    <StringLength(30)>
    <Display(Name:="銘柄名")>
    <Column("銘柄名")>
    Public Property 銘柄名 As String

    <StringLength(8)>
    <Display(Name:="規格")>
    <Column("規格")>
    Public Property 規格 As String

    <Display(Name:="縦")>
    <Column("縦")>
    Public Property 縦 As Decimal?

    <Display(Name:="横")>
    <Column("横")>
    Public Property 横 As Decimal?

    <Required>
    <Display(Name:="連量")>
    <Column("連量")>
    Public Property 連量 As Decimal

    <Required>
    <StringLength(8)>
    <Display(Name:="厚さ")>
    <Column("厚さ")>
    Public Property 厚さ As String

    <StringLength(8)>
    <Display(Name:="RS区分")>
    <Column("rs区分")>
    Public Property RS区分 As String

    <StringLength(8)>
    <Display(Name:="流れ目")>
    <Column("流れ目")>
    Public Property 流れ目 As String

    <Display(Name:="連数")>
    <Column("連数")>
    Public Property 連数 As Decimal?

    <Display(Name:="本数")>
    <Column("本数")>
    Public Property 本数 As Decimal?

    <Required>
    <Display(Name:="数量")>
    <Column("数量")>
    Public Property 数量 As Decimal

    <StringLength(8)>
    <Display(Name:="単位")>
    <Column("単位")>
    Public Property 単位 As String

    <Required>
    <Display(Name:="単価")>
    <Column("単価")>
    Public Property 単価 As Decimal

    <Required>
    <Display(Name:="金額")>
    <Column("金額")>
    Public Property 金額 As Decimal

    <StringLength(8)>
    <Display(Name:="断数")>
    <Column("断数")>
    Public Property 断数 As String

    <Display(Name:="断裁金額")>
    <Column("断裁金額")>
    Public Property 断裁金額 As Decimal?

    <Required>
    <StringLength(8)>
    <Display(Name:="倉庫")>
    <Column("倉庫")>
    Public Property 倉庫 As String

    <StringLength(8)>
    <Display(Name:="納入先")>
    <Column("納入先")>
    Public Property 納入先 As String

    <StringLength(30)>
    <Display(Name:="納入先名")>
    <Column("納入先名")>
    Public Property 納入先名 As String

    <Required>
    <Display(Name:="搬入日")>
    <Column("搬入日")>
    Public Property 搬入日 As Date

    <StringLength(4)>
    <Display(Name:="搬入時刻")>
    <Column("搬入時刻")>
    Public Property 搬入時刻 As String

    <StringLength(30)>
    <Display(Name:="備考")>
    <Column("備考")>
    Public Property 備考 As String

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
