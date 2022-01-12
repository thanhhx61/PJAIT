Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Public Class TPLContext
    Inherits DbContext
    Public Sub New()
        MyBase.New("name=ConnectionPGSQL")
        Database.SetInitializer(Of TPLContext)(Nothing)
    End Sub
    Public Property TPL_エラーログ As DbSet(Of TPL_エラーログ)
    Public Property TPL_コード As DbSet(Of TPL_コード)
    Public Property TPL_メニュー As DbSet(Of TPL_メニュー)
    Public Property TPL_メニュー権限 As DbSet(Of TPL_メニュー権限)
    Public Property TPL_ログ As DbSet(Of TPL_ログ)

    Public Property TPL_運用条件 As DbSet(Of TPL_運用条件)
    Public Property TPL_外注仕入基本 As DbSet(Of TPL_外注仕入基本)
    Public Property TPL_外注発注明細 As DbSet(Of TPL_外注発注明細)
    Public Property TPL_外注仕入明細 As DbSet(Of TPL_外注仕入明細)

    Public Property TPL_原価 As DbSet(Of TPL_原価)
    Public Property TPL_原価取込履歴 As DbSet(Of TPL_原価取込履歴)
    Public Property TPL_原価単価 As DbSet(Of TPL_原価単価)

    Public Property TPL_支払 As DbSet(Of TPL_支払)
    Public Property TPL_自社 As DbSet(Of TPL_自社)

    Public Property TPL_取引先 As DbSet(Of TPL_取引先) ''

    Public Property TPL_受注基本 As DbSet(Of TPL_受注基本)
    Public Property TPL_受注制作 As DbSet(Of TPL_受注制作)
    Public Property TPL_受注製版 As DbSet(Of TPL_受注製版)
    Public Property TPL_受注刷版 As DbSet(Of TPL_受注刷版)
    Public Property TPL_受注印刷 As DbSet(Of TPL_受注印刷)
    Public Property TPL_受注加工 As DbSet(Of TPL_受注加工)
    Public Property TPL_受注用紙 As DbSet(Of TPL_受注用紙)
    Public Property TPL_受注その他 As DbSet(Of TPL_受注その他)
    Public Property TPL_受注スケジュール As DbSet(Of TPL_受注スケジュール)
    Public Property TPL_請求 As DbSet(Of TPL_請求)
    Public Property TPL_請求締得意先 As DbSet(Of TPL_請求締得意先)
    Public Property TPL_請求書編集明細 As DbSet(Of TPL_請求書編集明細)
    Public Property TPL_請求締 As DbSet(Of TPL_請求締)
    Public Property TPL_請求明細 As DbSet(Of TPL_請求明細)
    Public Property TPL_請求書編集 As DbSet(Of TPL_請求書編集)
    Public Property TPL_担当 As DbSet(Of TPL_担当)
    Public Property TPL_入金 As DbSet(Of TPL_入金)
    Public Property TPL_買掛締 As DbSet(Of TPL_買掛締)
    Public Property TPL_買掛締仕入先 As DbSet(Of TPL_買掛締仕入先)
    Public Property TPL_買掛金 As DbSet(Of TPL_買掛金)
    Public Property TPL_買掛金明細 As DbSet(Of TPL_買掛金明細)
    Public Property TPL_売掛締 As DbSet(Of TPL_売掛締)
    Public Property TPL_売掛金 As DbSet(Of TPL_売掛金)
    Public Property TPL_売掛金明細 As DbSet(Of TPL_売掛金明細)
    Public Property TPL_売上基本 As DbSet(Of TPL_売上基本)
    Public Property TPL_売上明細 As DbSet(Of TPL_売上明細)
    Public Property TPL_発注基本 As DbSet(Of TPL_発注基本)
    Public Property TPL_用紙 As DbSet(Of TPL_用紙)
    Public Property TPL_用紙仕入基本 As DbSet(Of TPL_用紙仕入基本)
    Public Property TPL_用紙発注明細 As DbSet(Of TPL_用紙発注明細)
    Public Property TPL_用紙仕入明細 As DbSet(Of TPL_用紙仕入明細)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
    End Sub
End Class
