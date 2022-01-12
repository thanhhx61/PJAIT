Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
<Table("取引先", Schema:="public")>
Public Class TPL_取引先
    <Key>
    <Required>
    <StringLength(8)>
    <Display(Name:="取引先")>
    <Column("取引先")>
    Public Property 取引先 As String

    <Required>
    <StringLength(2)>
    <Display(Name:="取引先区分")>
    <Column("取引先区分")>
    Public Property 取引先区分 As String

    <Required>
    <StringLength(30)>
    <Display(Name:="名称")>
    <Column("名称")>
    Public Property 名称 As String

    <StringLength(30)>
    <Display(Name:="支店名")>
    <Column("支店名")>
    Public Property 支店名 As String

    <Required>
    <StringLength(10)>
    <Display(Name:="略称")>
    <Column("略称")>
    Public Property 略称 As String

    <StringLength(30)>
    <Display(Name:="よみ")>
    <Column("よみ")>
    Public Property よみ As String

    <StringLength(8)>
    <Display(Name:="郵便番号")>
    <Column("郵便番号")>
    Public Property 郵便番号 As String

    <StringLength(30)>
    <Display(Name:="住所１")>
    <Column("住所１")>
    Public Property 住所１ As String

    <StringLength(30)>
    <Display(Name:="住所２")>
    <Column("住所２")>
    Public Property 住所２ As String

    <StringLength(15)>
    <Display(Name:="電話番号")>
    <Column("電話番号")>
    Public Property 電話番号 As String

    <StringLength(15)>
    <Display(Name:="FAX")>
    <Column("fax")>
    Public Property FAX As String

    <StringLength(30)>
    <Display(Name:="備考１")>
    <Column("備考１")>
    Public Property 備考１ As String

    <StringLength(30)>
    <Display(Name:="備考２")>
    <Column("備考２")>
    Public Property 備考２ As String

    <StringLength(6)>
    <Display(Name:="担当")>
    <Column("担当")>
    Public Property 担当 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="取引状況")>
    <Column("取引状況")>
    Public Property 取引状況 As String

    <StringLength(2)>
    <Display(Name:="請求締日")>
    <Column("請求締日")>
    Public Property 請求締日 As String

    <StringLength(2)>
    <Display(Name:="請求書着日")>
    <Column("請求書着日")>
    Public Property 請求書着日 As String

    <StringLength(8)>
    <Display(Name:="回収日_月")>
    <Column("回収日_月")>
    Public Property 回収日_月 As String

    <StringLength(2)>
    <Display(Name:="回収日_日")>
    <Column("回収日_日")>
    Public Property 回収日_日 As String

    <StringLength(8)>
    <Display(Name:="支払日_月")>
    <Column("支払日_月")>
    Public Property 支払日_月 As String

    <StringLength(2)>
    <Display(Name:="支払日_日")>
    <Column("支払日_日")>
    Public Property 支払日_日 As String

    <StringLength(20)>
    <Display(Name:="支払条件１")>
    <Column("支払条件１")>
    Public Property 支払条件１ As String

    <StringLength(20)>
    <Display(Name:="支払条件２")>
    <Column("支払条件２")>
    Public Property 支払条件２ As String

    <StringLength(8)>
    <Display(Name:="消費税処理")>
    <Column("消費税処理")>
    Public Property 消費税処理 As String

    <Required>
    <StringLength(8)>
    <Display(Name:="税端数処理")>
    <Column("税端数処理")>
    Public Property 税端数処理 As String

    <Display(Name:="資本金")>
    <Column("資本金")>
    Public Property 資本金 As Decimal?

    <StringLength(8)>
    <Display(Name:="地区")>
    <Column("地区")>
    Public Property 地区 As String

    <StringLength(8)>
    <Display(Name:="業種")>
    <Column("業種")>
    Public Property 業種 As String

    <StringLength(8)>
    <Display(Name:="仕入業態")>
    <Column("仕入業態")>
    Public Property 仕入業態 As String

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
    <StringLength(20)>
    <Display(Name:="集金方法２")>
    <Column("集金方法２")>
    Public Property 集金方法２ As String
    <StringLength(20)>
    <Display(Name:="集金方法１")>
    <Column("集金方法１")>
    Public Property 集金方法１ As String

End Class
