Imports System.Reflection
Imports System.Web

Namespace ConstantCore
    ''' <summary>
    ''' 共通番号
    ''' </summary>
    Public Module Consts
        ''' <summary>
        ''' セッションキークラス
        ''' </summary>
        Public Class SessionKey
            Public Shared LOGIN_INFO As String = "LoginInfo_new"
        End Class

        ''' <summary>
        ''' 画面ID
        ''' </summary>
        Public Class ScreenId
            ''' <summary>
            ''' ログイン画面
            ''' </summary>
            Public Const TPL00010 = "TPL00010"
            ''' <summary>
            ''' メニュー画面
            ''' </summary>
            Public Const TPL00020 = "TPL00020"
            ''' <summary>
            ''' 外注発注書
            ''' </summary>
            Public Const TPL02050P = "TPL02050P"
        End Class

        ''' <summary>
        ''' コンテンツ形式
        ''' </summary>
        Public Class MimeType
            Public Shared XLS As String = "application/vnd.ms-excel"
            Public Shared XLSX As String = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Public Shared JPEG As String = "image/jpeg"
            Public Shared PNG As String = "image/png"
            Public Shared JSON As String = "application/json"
            Public Shared XML As String = "application/xml"
            Public Shared CSV As String = "text/csv"
            Public Shared PDF As String = "application/pdf"
            Public Shared TEXT As String = "text/plain"
        End Class

        ''' <summary>
        ''' 数変換フォーマットクラス
        ''' </summary>
        Public Class NumberFormat
            ''' <summary>
            ''' 999,999,999
            ''' </summary>
            Public Shared FORMAT_NUMBER As String = "#,##0"
            ''' <summary>
            ''' 9,999,999.9
            ''' </summary>
            Public Shared FORMAT_NUMBER_1_DECIMAL As String = "#,##0.0"
            ''' <summary>
            ''' 9,999,999.9999
            ''' </summary>
            Public Shared FORMAT_NUMBER_3_DECIMAL As String = "#,##0.##0"
        End Class

        ''' <summary>
        ''' 日付変換フォーマットクラス
        ''' </summary>
        Public Class DateFormat
            ' For JavaScript
            Public Shared YYMMDD_P As String = "yyyy/mm/dd"
            Public Shared YYYYMM_P As String = "yyyy/mm"
            ' For VB.NET
            Public Shared YYYYMM As String = "yyyy/MM"
            Public Shared YYYYMMDD As String = "yyyy/MM/dd"
            Public Shared DATETIMEFULL_NS As String = "yyyy/MM/dd HH:mm"
            Public Shared DATETIMEFULL As String = "yyyy/MM/dd HH:mm:ss"
            Public Shared DATETIMEFULL_F6 As String = "yyyy/MM/dd HH:mm:ss.fffff"
            Public Shared YYYYMM_NF As String = "yyyyMM"
            Public Shared YYYYMMDD_NF As String = "yyyyMMdd"
            Public Shared DATETIMEFULL_NF As String = "yyyyMMddHHmmss"
            Public Shared DATETIMEFULL_F6_NF As String = "yyyyMMddHHmmssffff"
            Public Shared HHMM As String = "HHmm"
        End Class

        ''' <summary>
        ''' システム日付の形式
        ''' </summary>
        Public Class SysdateFormat
            Public Const YYYYMMDD As String = "0"
            Public Const YYYYMMDDHHMMSS As String = "1"
            Public Const YYYYMMDDHHMMSSFFF As String = "2"
            Public Const YYYYMM As String = "3"
        End Class

        ''' <summary>
        ''' 出力先フォルダ名
        ''' </summary>
        Public Class FolderName
            Public Shared CSV As String = "CSV"
            Public Shared PDF As String = "PDF"
        End Class

        ''' <summary>
        ''' 正規表現
        ''' </summary>
        Public Class RegexType
            Public Shared ALPHA_NUMBER_SYMBOL As String = "[a-zA-Z0-9 -/:-@\[-\`\{-\~]+"
            Public Shared ALPHA_NUMBER As String = "[a-zA-Z0-9]+"
            Public Shared TIME As String = "([0-1][0-9]|2[0-3]):[0-5][0-9]"
            Public Shared SMALL_NUM As String = "\d+\.\d"
            ''' <summary>
            ''' 半角カナのコード範囲をCONST
            ''' </summary>
            Public Const HANKAKU_KANA_PTTERN As String = "[a-zA-Z0-9\uFF61-\uFF9F]+"
        End Class

#Region "区分設計"
        ''' <summary>
        ''' 共通番号のコード
        ''' </summary>
        Public Const COMMON_CODE As String = "00000000"

        ''' <summary>
        ''' 共通番号
        ''' </summary>
        Public Class COMMON_NO
            Public Const SYS_COMMON = "1000"
            Public Const DEAL_STATUS = "1001"
            Public Const COLLECTION_MONTH = "1002"
            Public Const PAYMENT_MONTH = "1003"
            Public Const TAX = "1004"
            Public Const TAX_FRACTION = "1005"
            Public Const LOCATION = "1006"
            Public Const INDUSTRY = "1007"
            Public Const PURCHASING_FORMAT = "1008"
            Public Const DEPARTMENT = "1009"
            Public Const ITEM_TYPE = "1010"
            Public Const MAKER = "1011"
            Public Const APPLY_TYPE = "1012"
            Public Const PROCESS = "1013"
            Public Const TASK_PRODUCTION = "1014"
            Public Const TASK_PLATE_MAKING = "1015"
            Public Const TASK_PRINTING_PLATE = "1016"
            Public Const TASK_PROCESSING = "1017"
            Public Const TASK_ETC = "1018"
            Public Const PRODUCT_SIZE = "1019"
            Public Const PAPER_SIZE = "1020"
            Public Const MODEL = "1021"
            Public Const SLIP_TYPE = "1022"
            Public Const ORDER_TYPE = "1023"
            Public Const PRODUCT_TYPE = "1024"
            Public Const PRODUCT_UNIT = "1025"
            Public Const PAPER_UNIT = "1026"
            Public Const PARTS = "1027"
            Public Const CALC_TYPE = "1028"
            Public Const OUR_OTHER_TYPE = "1029"
            Public Const RS_TYPE = "1030"
            Public Const UNIT_TYPE = "1031"
            Public Const THICKNESS = "1032"
            Public Const VERTICAL_WIDTH = "1033"
            Public Const CUTTING_COUNT = "1034"
            Public Const WAREHOUSE = "1035"
            Public Const DEAL_PURCHASE = "1036"
            Public Const DEAL_SALE = "1037"
            Public Const DEAL_PAYMENT = "1038"
            Public Const TAXLATION_TYPE = "1039"
            Public Const TAX_RATE = "1040"
            Public Const BILL_BREAKDOWN = "1041"
            Public Const INVOICE_MONTH = "1042"
            Public Const PROFIT_RATE = "1043"
            Public Const COST_TYPE = "1044"
            Public Const IN_OUT_TYPE = "1045"
            Public Const CUSTOMER_TYPE = "1046"
            Public Const PROGRAM_ID = "1047"
            Public Const PROCESS_STATUS = "1048"
            Public Const BUTTON_CONTROL = "1049"
            Public Const COLOR_CONTROL = "1050"
        End Class

        ''' <summary>
        ''' 取引状況 (1001)
        ''' </summary>
        Public Class DEAL_STATUS
            ''' <summary>
            ''' 取引中
            ''' </summary>
            Public Const DURING_TRADING = "0001"
            ''' <summary>
            ''' 取引不可
            ''' </summary>
            Public Const NOT_TRADEABLE = "0002"
        End Class

        ''' <summary>
        ''' 回収月 (1002)
        ''' </summary>
        Public Class COLLECTION_MONTH
            ''' <summary>
            ''' 当月
            ''' </summary>
            Public Const CURR_MONTH = "0001"
            ''' <summary>
            ''' 翌月
            ''' </summary>
            Public Const NEXT_MONTH = "0002"
            ''' <summary>
            ''' 翌々月
            ''' </summary>
            Public Const AFTER_NEXT_MONTH = "0003"
            ''' <summary>
            ''' 3カ月後
            ''' </summary>
            Public Const THREE_MONTH_LATER = "0004"
        End Class

        ''' <summary>
        ''' 支払月 (1003)
        ''' </summary>
        Public Class PAYMENT_MONTH
            ''' <summary>
            ''' 当月
            ''' </summary>
            Public Const CURR_MONTH = "0001"
            ''' <summary>
            ''' 翌月
            ''' </summary>
            Public Const NEXT_MONTH = "0002"
            ''' <summary>
            ''' 翌々月
            ''' </summary>
            Public Const AFTER_NEXT_MONTH = "0003"
            ''' <summary>
            ''' 3カ月後
            ''' </summary>
            Public Const THREE_MONTH_LATER = "0004"
        End Class

        ''' <summary>
        ''' 消費税処理 (1004)
        ''' </summary>
        Public Class TAX
            ''' <summary>
            ''' 明細単位
            ''' </summary>
            Public Const DETAIL_UNIT = "0001"
            ''' <summary>
            ''' 請求単位
            ''' </summary>
            Public Const BILLING_UNIT = "0002"
        End Class

        ''' <summary>
        ''' 端数処理区分 (1005)
        ''' </summary>
        Public Class TAX_FRACTION
            ''' <summary>
            ''' 四捨五入
            ''' </summary>
            Public Shared ROUND As String = "0001"
            ''' <summary>
            ''' 切捨て
            ''' </summary>
            Public Shared ROUND_DOWN As String = "0002"
            ''' <summary>
            ''' 切上げ
            ''' </summary>
            Public Shared ROUND_UP As String = "0003"
        End Class

        ''' <summary>
        ''' 地区 (1006)
        ''' </summary>
        Public Class LOCATION
            ''' <summary>
            ''' 関東
            ''' </summary>
            Public Shared KANTO As String = "0001"
            ''' <summary>
            ''' 関西
            ''' </summary>
            Public Shared KANSAI As String = "0002"
            ''' <summary>
            ''' 東海
            ''' </summary>
            Public Shared TOKAI As String = "0003"
        End Class

        ''' <summary>
        ''' 業種 (1007)
        ''' </summary>
        Public Class INDUSTRY
            ''' <summary>
            ''' 指定なし
            ''' </summary>
            Public Shared UN_SPECIFIED As String = "0001"
            ''' <summary>
            ''' 指定あり
            ''' </summary>
            Public Shared SPECIFIED As String = "0002"
        End Class

        ''' <summary>
        ''' 仕入業態 (1008)
        ''' </summary>
        Public Class PURCHASING_FORMAT
            ''' <summary>
            ''' 通常支払
            ''' </summary>
            Public Shared NORMAL_PAY As String = "0001"
            ''' <summary>
            ''' 外税源泉あり
            ''' </summary>
            Public Shared FOREIGN_TAX As String = "0002"
            ''' <summary>
            ''' 内税源泉あり
            ''' </summary>
            Public Shared TAX As String = "0003"
            ''' <summary>
            ''' 払なし外税
            ''' </summary>
            Public Shared NON_FOREIGN_TAX As String = "0004"
            ''' <summary>
            ''' 払なし内税
            ''' </summary>
            Public Shared NON_TAX As String = "0005"
        End Class

        ''' <summary>
        ''' 部署 (1009)
        ''' </summary>
        Public Class DEPARTMENT
            ''' <summary>
            ''' 部署A
            ''' </summary>
            Public Shared DEPARTMENT_A As String = "0001"
            ''' <summary>
            ''' 部署B
            ''' </summary>
            Public Shared DEPARTMENT_B As String = "0002"
            ''' <summary>
            ''' 部署C
            ''' </summary>
            Public Shared DEPARTMENT_C As String = "0003"
        End Class

        ''' <summary>
        ''' 品種 (1010)
        ''' </summary>
        Public Class ITEM_TYPE
            ''' <summary>
            ''' 上質(平)
            ''' </summary>
            Public Shared HIGH_QUALITY_FLAT As String = "0001"
            ''' <summary>
            ''' A1アート(平)
            ''' </summary>
            Public Shared A1_ART As String = "0002"
            ''' <summary>
            ''' A2グロス(平)
            ''' </summary>
            Public Shared A2_GLOS_FLAT As String = "0003"
            ''' <summary>
            ''' A2マット(平)
            ''' </summary>
            Public Shared A2_MAT_FLAT As String = "0004"
            ''' <summary>
            ''' A3グロス(平)
            ''' </summary>
            Public Shared A3_GLOS_FLAT As String = "0005"
            ''' <summary>
            ''' A3マット(平)
            ''' </summary>
            Public Shared A3_MAT_FLAT As String = "0006"
            ''' <summary>
            ''' 板紙(平)
            ''' </summary>
            Public Shared PAPER_BOARD As String = "0007"
            ''' <summary>
            ''' その他(平)
            ''' </summary>
            Public Shared OTHER_FLAT As String = "0008"
            ''' <summary>
            ''' 上質(巻)
            ''' </summary>
            Public Shared HIGH_QUALITY As String = "0009"
            ''' <summary>
            ''' A2グロス(巻)
            ''' </summary>
            Public Shared A2_GLOS As String = "0010"
            ''' <summary>
            ''' A2マット(巻)
            ''' </summary>
            Public Shared A2_MAT As String = "0011"
            ''' <summary>
            ''' A3グロス(巻)
            ''' </summary>
            Public Shared A3_GLOS As String = "0012"
            ''' <summary>
            ''' A3マット(巻)
            ''' </summary>
            Public Shared A3_MAT As String = "0013"
            ''' <summary>
            ''' 微塗工(巻)
            ''' </summary>
            Public Shared FINE_COATING As String = "0014"
            ''' <summary>
            ''' その他(巻)
            ''' </summary>
            Public Shared OTHER As String = "0015"
        End Class

        ''' <summary>
        ''' メーカー (1011)
        ''' </summary>
        Public Class MAKER
            ''' <summary>
            ''' 王子製紙
            ''' </summary>
            Public Shared PRINCE_PAPER As String = "0001"
            ''' <summary>
            ''' 日本製紙
            ''' </summary>
            Public Shared NIPPON_PAPAER As String = "0002"
            ''' <summary>
            ''' 大王製紙
            ''' </summary>
            Public Shared DAIO_PAPER As String = "0003"
            ''' <summary>
            ''' 三菱製紙
            ''' </summary>
            Public Shared MITSUBISHI_PAPER As String = "0004"
            ''' <summary>
            ''' 中越パルプ工業
            ''' </summary>
            Public Shared CHUETSU_PULP_PAPAER As String = "0005"
            ''' <summary>
            ''' 輸入紙
            ''' </summary>
            Public Shared IMPORT_PAPER As String = "0006"
            ''' <summary>
            ''' 竹尾
            ''' </summary>
            Public Shared TAKEO As String = "0007"
            ''' <summary>
            ''' その他
            ''' </summary>
            Public Shared OTHER As String = "0008"
            ''' <summary>
            ''' 指定無し
            ''' </summary>
            Public Shared NOT_SPECIFIED As String = "0009"
        End Class

        ''' <summary>
        ''' 適用区分 (1012)
        ''' </summary>
        Public Class APPLY_TYPE
            ''' <summary>
            ''' A
            ''' </summary>
            Public Shared A As String = "0001"
            ''' <summary>
            ''' B
            ''' </summary>
            Public Shared B As String = "0002"
            ''' <summary>
            ''' C
            ''' </summary>
            Public Shared C As String = "0003"
        End Class

        ''' <summary>
        ''' 工程 (1013)
        ''' </summary>
        Public Class PROCESS
            ''' <summary>
            ''' 制作
            ''' </summary>
            Public Shared TASK_0001 As String = "0001"
            ''' <summary>
            ''' 製版・デジタル印刷
            ''' </summary>
            Public Shared TASK_0002 As String = "0002"
            ''' <summary>
            ''' 刷版
            ''' </summary>
            Public Shared TASK_0003 As String = "0003"
            ''' <summary>
            ''' 印刷
            ''' </summary>
            Public Shared TASK_0004 As String = "0004"
            ''' <summary>
            ''' 加工
            ''' </summary>
            Public Shared TASK_0005 As String = "0005"
            ''' <summary>
            ''' 用紙
            ''' </summary>
            Public Shared TASK_0006 As String = "0006"
            ''' <summary>
            ''' その他
            ''' </summary>
            Public Shared TASK_0007 As String = "0007"
        End Class

        ''' <summary>
        ''' 作業(制作) (1014)
        ''' </summary>
        Public Class TASK_PRODUCTION
            ''' <summary>
            ''' 企画立案
            ''' </summary>
            Public Shared PLANNING As String = "0001"
            ''' <summary>
            ''' 調査
            ''' </summary>
            Public Shared RESEARCH As String = "0002"
            ''' <summary>
            ''' 資料
            ''' </summary>
            Public Shared DOCUMENT As String = "0003"
            ''' <summary>
            ''' コピーライト
            ''' </summary>
            Public Shared COPYRIGHT As String = "0004"
            ''' <summary>
            ''' 取材
            ''' </summary>
            Public Shared COVERAGE As String = "0005"
            ''' <summary>
            ''' 進行管理(AD・PD)
            ''' </summary>
            Public Shared PROC_MANAGER As String = "0006"
            ''' <summary>
            ''' デザイン　難易度A
            ''' </summary>
            Public Shared DESIGN_DIFFICUL_A As String = "0007"
            ''' <summary>
            ''' デザイン　難易度B
            ''' </summary>
            Public Shared DESIGN_DIFFICUL_B As String = "0008"
            ''' <summary>
            ''' デザイン　難易度C
            ''' </summary>
            Public Shared DESIGN_DIFFICUL_C As String = "0009"
            ''' <summary>
            ''' DTP　難易度A
            ''' </summary>
            Public Shared DTP_DIFFICUL_A As String = "0010"
            ''' <summary>
            ''' DTP　難易度B
            ''' </summary>
            Public Shared DTP_DIFFICUL_B As String = "0011"
            ''' <summary>
            ''' DTP　難易度C
            ''' </summary>
            Public Shared DTP_DIFFICUL_C As String = "0012"
            ''' <summary>
            ''' RiP処理
            ''' </summary>
            Public Shared RIP_PROC As String = "0013"
            ''' <summary>
            ''' WEB制作
            ''' </summary>
            Public Shared WEB_PRODUCT As String = "0014"
            ''' <summary>
            ''' イラスト
            ''' </summary>
            Public Shared ILLUSTRATION As String = "0015"
            ''' <summary>
            ''' 図面トレース(MAP等)
            ''' </summary>
            Public Shared DRAW_TRACE As String = "0016"
            ''' <summary>
            ''' リースフォト
            ''' </summary>
            Public Shared REESE_PHOTO As String = "0017"
            ''' <summary>
            ''' イメージ撮影
            ''' </summary>
            Public Shared IMAGE_SHOT As String = "0018"
            ''' <summary>
            ''' 単品撮影
            ''' </summary>
            Public Shared SINGLE_SHOT As String = "0019"
            ''' <summary>
            ''' モデル
            ''' </summary>
            Public Shared MODEL As String = "0020"
            ''' <summary>
            ''' 小道具
            ''' </summary>
            Public Shared PROPS As String = "0021"
            ''' <summary>
            ''' ヘアメイク
            ''' </summary>
            Public Shared HAIR_MAKE As String = "0022"
            ''' <summary>
            ''' スタイリング
            ''' </summary>
            Public Shared STYLING As String = "0023"
            ''' <summary>
            ''' 画像修正
            ''' </summary>
            Public Shared IMAGE_FIX As String = "0024"
            ''' <summary>
            ''' プログラム
            ''' </summary>
            Public Shared PROGRAM As String = "0025"
            ''' <summary>
            ''' データ処理
            ''' </summary>
            Public Shared DATA_PROC As String = "0026"
            ''' <summary>
            ''' 校正
            ''' </summary>
            Public Shared PROOF As String = "0027"
            ''' <summary>
            ''' 試作
            ''' </summary>
            Public Shared TRAIL_PRODUCT As String = "0028"
            ''' <summary>
            ''' 出力費
            ''' </summary>
            Public Shared OUTPUT_FEE As String = "0029"
            ''' <summary>
            ''' 派遣代
            ''' </summary>
            Public Shared DISPATCH_FEE As String = "0030"
            ''' <summary>
            ''' PS出張費
            ''' </summary>
            Public Shared PS_BUSINESS_EXP As String = "0031"
            ''' <summary>
            ''' ロケ出張費
            ''' </summary>
            Public Shared LOCA_BUSINESS_EXP As String = "0032"
        End Class

        ''' <summary>
        ''' 作業(製版) (1015)
        ''' </summary>
        Public Class TASK_PLATE_MAKING

        End Class

        ''' <summary>
        ''' 作業(刷版) (1016)
        ''' </summary>
        Public Class TASK_PRINTING_PLATE
            ''' <summary>
            ''' CTP
            ''' </summary>
            Public Shared CTP As String = "0001"
            ''' <summary>
            ''' 版無(ｵﾝﾃﾞﾏﾝﾄﾞ)
            ''' </summary>
            Public Shared NO_VERSION_ON_DEMAN As String = "0002"
            ''' <summary>
            ''' 版無(ｲﾝｸｼﾞｪｯﾄ)
            ''' </summary>
            Public Shared NO_VERSION_INKJET As String = "0003"
            ''' <summary>
            ''' 外注入稿
            ''' </summary>
            Public Shared SUBCONTRACT_INJECTION As String = "0004"
        End Class

        ''' <summary>
        ''' 作業(加工) (1017)
        ''' </summary>
        Public Class TASK_PROCESSING

        End Class

        ''' <summary>
        ''' 作業(その他) (1018)
        ''' </summary>
        Public Class TASK_ETC
            ''' <summary>
            ''' 端数調整
            ''' </summary>
            Public Shared FRAG_ADJUSTMENT As String = "0001"
            ''' <summary>
            ''' 配送料
            ''' </summary>
            Public Shared DELIVERY_FEE As String = "0002"
            ''' <summary>
            ''' オンデマンド
            ''' </summary>
            Public Shared ON_DEMAND As String = "0003"
            ''' <summary>
            ''' 梱包作業
            ''' </summary>
            Public Shared PACK_WORK As String = "0004"
            ''' <summary>
            ''' 値引き
            ''' </summary>
            Public Shared DISCOUNT As String = "0005"
        End Class

        ''' <summary>
        ''' 製品サイズ (1019)
        ''' </summary>
        Public Class PRODUCT_SIZE
            ''' <summary>
            ''' A0
            ''' </summary>
            Public Shared A0 As String = "0001"
            ''' <summary>
            ''' A1
            ''' </summary>
            Public Shared A1 As String = "0002"
            ''' <summary>
            ''' A2
            ''' </summary>
            Public Shared A2 As String = "0003"
            ''' <summary>
            ''' A3
            ''' </summary>
            Public Shared A3 As String = "0004"
            ''' <summary>
            ''' A4
            ''' </summary>
            Public Shared A4 As String = "0005"
            ''' <summary>
            ''' A5
            ''' </summary>
            Public Shared A5 As String = "0006"
            ''' <summary>
            ''' A6
            ''' </summary>
            Public Shared A6 As String = "0007"
            ''' <summary>
            ''' A7
            ''' </summary>
            Public Shared A7 As String = "0008"
            ''' <summary>
            ''' B0
            ''' </summary>
            Public Shared B0 As String = "0009"
            ''' <summary>
            ''' B1
            ''' </summary>
            Public Shared B1 As String = "0010"
            ''' <summary>
            ''' B2
            ''' </summary>
            Public Shared B2 As String = "0011"
            ''' <summary>
            ''' B3
            ''' </summary>
            Public Shared B3 As String = "0012"
            ''' <summary>
            ''' B4
            ''' </summary>
            Public Shared B4 As String = "0013"
            ''' <summary>
            ''' B5
            ''' </summary>
            Public Shared B5 As String = "0014"
            ''' <summary>
            ''' B6
            ''' </summary>
            Public Shared B6 As String = "0015"
            ''' <summary>
            ''' B7
            ''' </summary>
            Public Shared B7 As String = "0016"
            ''' <summary>
            ''' D2
            ''' </summary>
            Public Shared D2 As String = "0017"
            ''' <summary>
            ''' D3
            ''' </summary>
            Public Shared D3 As String = "0018"
            ''' <summary>
            ''' D4
            ''' </summary>
            Public Shared D4 As String = "0019"
            ''' <summary>
            ''' D5
            ''' </summary>
            Public Shared D5 As String = "0020"
            ''' <summary>
            ''' 規格外
            ''' </summary>
            Public Shared NON_STANDARD As String = "9000"
        End Class

        ''' <summary>
        ''' 用紙サイズ (1020)
        ''' </summary>
        Public Class PAPER_SIZE
            ''' <summary>
            ''' 4/6判
            ''' </summary>
            Public Shared SIZE4_6 As String = "0001"
            ''' <summary>
            ''' A判
            ''' </summary>
            Public Shared SIZE_A As String = "0002"
            ''' <summary>
            ''' AB判
            ''' </summary>
            Public Shared SIZE_AB As String = "0003"
            ''' <summary>
            ''' B判
            ''' </summary>
            Public Shared SIZE_B As String = "0004"
            ''' <summary>
            ''' D判
            ''' </summary>
            Public Shared SIZE_D As String = "0005"
            ''' <summary>
            ''' ﾊﾄﾛﾝ判
            ''' </summary>
            Public Shared SIZE_HATRON As String = "0006"
            ''' <summary>
            ''' 菊判
            ''' </summary>
            Public Shared SIZE_KIKU As String = "0007"
            ''' <summary>
            ''' K判
            ''' </summary>
            Public Shared SIZE_k As String = "0008"
            ''' <summary>
            ''' L判
            ''' </summary>
            Public Shared SIZE_L As String = "0009"
            ''' <summary>
            ''' 既製封筒
            ''' </summary>
            Public Shared READY_ENVELOP As String = "0010"
            ''' <summary>
            ''' 規格外
            ''' </summary>
            Public Shared NON_STANDARD As String = "9000"
        End Class

        ''' <summary>
        ''' 印刷機種 (1021)
        ''' </summary>
        Public Class MODEL
            ''' <summary>
            ''' オフ輪AT
            ''' </summary>
            Public Shared OFF_WHEEL_AT As String = "0001"
            ''' <summary>
            ''' オフ輪BT
            ''' </summary>
            Public Shared OFF_WHEEL_BT As String = "0002"
            ''' <summary>
            ''' 菊半UV
            ''' </summary>
            Public Shared KIKUHAN_UV As String = "0003"
            ''' <summary>
            ''' 菊全UV
            ''' </summary>
            Public Shared KIKUZEN_UV As String = "0004"
            ''' <summary>
            ''' 菊全ﾊｲﾃﾞﾙ
            ''' </summary>
            Public Shared KIKUZEN_HEIDEL As String = "0005"
            ''' <summary>
            ''' オンデマンド
            ''' </summary>
            Public Shared ON_DEMAND As String = "0006"
            ''' <summary>
            ''' ｲﾝｸｼﾞｪｯﾄ
            ''' </summary>
            Public Shared INKJET As String = "0007"
            ''' <summary>
            ''' 外注印刷機
            ''' </summary>
            Public Shared SUBCONTRACT_PRINT_MACHINE As String = "0008"
            ''' <summary>
            ''' 印刷無し
            ''' </summary>
            Public Shared NO_PRINTING As String = "0009"
        End Class

        ''' <summary>
        ''' 伝票区分 "1022"
        ''' </summary>
        Public Class SLIP_TYPE
            ''' <summary>
            ''' 通常
            ''' </summary>
            Public Shared GENERRALLY As String = "0001"
            ''' <summary>
            ''' プレゼン費
            ''' </summary>
            Public Shared PRESENTATION_FEE As String = "0002"
            ''' <summary>
            ''' 社用
            ''' </summary>
            Public Shared COMPANY_USE As String = "0003"
            ''' <summary>
            ''' 仕損費
            ''' </summary>
            Public Shared DEFECTIVE_COST As String = "0004"
            ''' <summary>
            ''' 社内売上経費
            ''' </summary>
            Public Shared INTERNAL_SALES As String = "0005"
        End Class

        ''' <summary>
        ''' 受注区分 "1023"
        ''' </summary>
        Public Class ORDER_TYPE
            ''' <summary>
            ''' 新版
            ''' </summary>
            Public Shared NEW_EDITION As String = "0001"
            ''' <summary>
            ''' 再版
            ''' </summary>
            Public Shared SECOND_EDITION As String = "0002"
            ''' <summary>
            ''' 改版
            ''' </summary>
            Public Shared REVISION As String = "0003"
        End Class

        ''' <summary>
        ''' 製品種別 = "1024"
        ''' </summary>
        Public Class PRODUCT_TYPE

        End Class

        ''' <summary>
        ''' 製品単位 = "1025"
        ''' </summary>
        Public Class PRODUCT_UNIT
            ''' <summary>
            ''' 部
            ''' </summary>
            Public Shared PART As String = "0001"
            ''' <summary>
            ''' 枚
            ''' </summary>
            Public Shared SHEET As String = "0002"
            ''' <summary>
            ''' 冊
            ''' </summary>
            Public Shared BOOK As String = "0003"
            ''' <summary>
            ''' 折
            ''' </summary>
            Public Shared CHANCE As String = "0004"
            ''' <summary>
            ''' 函
            ''' </summary>
            Public Shared BOX As String = "0005"
            ''' <summary>
            ''' 袋
            ''' </summary>
            Public Shared BAG As String = "0006"
            ''' <summary>
            ''' 組
            ''' </summary>
            Public Shared GROUP As String = "0007"
            ''' <summary>
            ''' 個
            ''' </summary>
            Public Shared PIECES As String = "0008"
            ''' <summary>
            ''' 束
            ''' </summary>
            Public Shared BUNDLE As String = "0009"
        End Class

        ''' <summary>
        ''' 用紙単位 = "1026"
        ''' </summary>
        Public Class PAPER_UNIT

        End Class

        ''' <summary>
        ''' 部品 = "1027"
        ''' </summary>
        Public Class PARTS

        End Class

        ''' <summary>
        ''' 計算区分 (1028)
        ''' </summary>
        Public Class CALC_TYPE
            ''' <summary>
            ''' 通し
            ''' </summary>
            Public Const THREAD = "0001"
            ''' <summary>
            ''' 台数
            ''' </summary>
            Public Const UNIT_NUM = "0002"
        End Class

        ''' <summary>
        ''' 当先区分  = "1029"
        ''' </summary>
        Public Class OUR_OTHER_TYPE

        End Class

        ''' <summary>
        ''' RS区分 = "1030"
        ''' </summary>
        Public Class RS_TYPE
            ''' <summary>
            ''' S
            ''' </summary>
            Public Const S = "0001"
            ''' <summary>
            ''' R
            ''' </summary>
            Public Const R = "0002"
        End Class

        ''' <summary>
        ''' 単位区分 = "1031"
        ''' </summary>
        Public Class UNIT_TYPE

        End Class

        ''' <summary>
        ''' 厚さ = "1032"
        ''' </summary>
        Public Class THICKNESS

        End Class

        ''' <summary>
        ''' 流れ目 = "1033"
        ''' </summary>
        Public Class VERTICAL_WIDTH
            ''' <summary>
            ''' 縦目
            ''' </summary>
            Public Const VERTICAL = "0001"
            ''' <summary>
            ''' 横目
            ''' </summary>
            Public Const HORIZONTAL = "0002"
        End Class

        ''' <summary>
        ''' 断数 = "1034"
        ''' </summary>
        Public Class CUTTING_COUNT

        End Class

        ''' <summary>
        ''' 倉庫 = "1035"
        ''' </summary>
        Public Class WAREHOUSE

        End Class

        ''' <summary>
        ''' 取引区分(仕入) = "1036"
        ''' </summary>
        Public Class DEAL_PURCHASE

        End Class

        ''' <summary>
        ''' 取引区分(売上) = "1037"
        ''' </summary>
        Public Class DEAL_SALE
            ''' <summary>
            ''' 通常売上
            ''' </summary>
            Public Const SALE_NORMAL = "200"
            ''' <summary>
            ''' 預かり売上
            ''' </summary>
            Public Const SALE_CUSTODY = "201"
            ''' <summary>
            ''' 売上返品
            ''' </summary>
            Public Const SALE_PROFIT = "202"
        End Class

        ''' <summary>
        ''' 取引区分(支払・入金) = "1038"
        ''' </summary>
        Public Class DEAL_PAYMENT
            ''' <summary>
            ''' 振込
            ''' </summary>
            Public Const TRANSFER = "300"
            ''' <summary>
            ''' 現金
            ''' </summary>
            Public Const CASH = "301"
            ''' <summary>
            ''' 小切手
            ''' </summary>
            Public Const CHECK = "302"
            ''' <summary>
            ''' 手形・でんさい
            ''' </summary>
            Public Const BILL = "303"
            ''' <summary>
            ''' 相殺
            ''' </summary>
            Public Const OFFSET = "304"
            ''' <summary>
            ''' 消費税端数
            ''' </summary>
            Public Const SALES_TAX = "305"
            ''' <summary>
            ''' 振込手数料
            ''' </summary>
            Public Const TRANSFER_FEE = "306"
            ''' <summary>
            ''' その他
            ''' </summary>
            Public Const OTHERS = "307"
        End Class

        ''' <summary>
        ''' 課税区分 = "1039"
        ''' </summary>
        Public Class TAXLATION_TYPE
            ''' <summary>
            ''' 課税
            ''' </summary>
            Public Const TAXATION = "0001"
            ''' <summary>
            ''' 非課税
            ''' </summary>
            Public Const NON_TAXATION = "0002"
        End Class

        ''' <summary>
        ''' 税率 = "1040"
        ''' </summary>
        Public Class TAX_RATE
            ''' <summary>
            ''' 0%
            ''' </summary>
            Public Const TAX0_PERCENT = "0001"
            ''' <summary>
            ''' 3%
            ''' </summary>
            Public Const TAX3_PERCENT = "0002"
            ''' <summary>
            ''' 5%
            ''' </summary>
            Public Const TAX5_PERCENT = "0003"
            ''' <summary>
            ''' 8%
            ''' </summary>
            Public Const TAX8_PERCENT = "0004"
            ''' <summary>
            ''' 10%
            ''' </summary>
            Public Const TAX10_PERCENT = "0005"
        End Class

        ''' <summary>
        ''' 手形内訳 = "1041"
        ''' </summary>
        Public Class BILL_BREAKDOWN

        End Class

        ''' <summary>
        ''' 請求月 = "1042"
        ''' </summary>
        Public Class INVOICE_MONTH
            ''' <summary>
            ''' 蠖捺怦
            ''' </summary>
            Public Const THIS_MONTH As String = "0001"
            ''' <summary>
            ''' 鄙梧怦
            ''' </summary>
            Public Const NEXT_MONTH As String = "0002"
            ''' <summary>
            ''' 鄙後
            ''' </summary>
            Public Const MONTH_AFTER_NEXT As String = "0003"
            ''' <summary>
            ''' 3繧ｫ譛亥ｾ
            ''' </summary>
            Public Const THREE_MONTHS_LATER As String = "0004"
        End Class

        ''' <summary>
        ''' 利益率 = "1043"
        ''' </summary>
        Public Class PROFIT_RATE

            ''' <summary>
            ''' 受注利益率
            ''' </summary>
            Public Shared ORDER As String = "0001"
            ''' <summary>
            ''' 製造利益率
            ''' </summary>
            Public Shared MANUFACTUR As String = "0002"
        End Class

        ''' <summary>
        ''' 原価区分 = "1044"
        ''' </summary>
        Public Class COST_TYPE

        End Class

        ''' <summary>
        ''' 内外区分 (1045)
        ''' </summary>
        Public Class IN_OUT_TYPE
            ''' <summary>
            ''' 内作
            ''' </summary>
            Public Const IN_WORK = "0001"
            ''' <summary>
            ''' 外作
            ''' </summary>
            Public Const OUT_WORK = "0002"
            ''' <summary>
            ''' 未定
            ''' </summary>
            Public Const UNDECIDED = "0003"
        End Class

        ''' <summary>
        ''' 取引先区分 = "1046"
        ''' </summary>
        Public Class CUSTOMER_TYPE
            ''' <summary>
            ''' 得意先
            ''' </summary>
            Public Const CUSTOMER = "1"
            ''' <summary>
            ''' 仕入先
            ''' </summary>
            Public Const SUPPLIER = "2"
        End Class

        ''' <summary> = "1047"
        ''' </summary>
        Public Class PROGRAM_ID

        End Class

        ''' <summary>
        ''' 処理状況 = "1048"
        ''' </summary>
        Public Class PROCESS_STATUS
            ''' <summary>
            ''' 未処理
            ''' </summary>
            Public Const UNTREATED = "0"
            ''' <summary>
            ''' 準備完了
            ''' </summary>
            Public Const READY = "1"
            ''' <summary>
            ''' 処理済
            ''' </summary>
            Public Const PROCESSED = "2"
        End Class

        ''' <summary>
        ''' ボタン制御 = "1049"
        ''' </summary>
        Public Class BUTTON_CONTROL
            ''' <summary>
            ''' 受注登録(CSV取込)
            ''' </summary>
            Public Const CSV_IN = "0001"
            ''' <summary>
            ''' 受注登録(CSV出力)
            ''' </summary>
            Public Const CSV_OUT = "0002"
            ''' <summary>
            ''' 原価登録
            ''' </summary>
            Public Const COST = "0003"
            ''' <summary>
            ''' 作業指示書
            ''' </summary>
            Public Const WORK_INSTRUCTION = "0004"
            ''' <summary>
            ''' 精算見積書
            ''' </summary>
            Public Const SETTLEMENT_ESTIMATE = "0005"
        End Class

        ''' <summary>
        ''' 文字色制御 = "1050"
        ''' </summary>
        Public Class COLOR_CONTROL
            ''' <summary>
            ''' 外注発注未出力
            ''' </summary>
            Public Const SUBCONTRACT_ORDER_NO_OUTPUT = "0001"
            ''' <summary>
            ''' 用紙発注未出力
            ''' </summary>
            Public Const PAPER_ORDER_NO_OUTPUT = "0002"
        End Class
#End Region

        Public Class ClosingDateType
            Public Const BILL = "0"
            Public Const ACCNT_PAY = "1"
            Public Const RECEIVE = "2"
        End Class

        ''' <summary>
        ''' CSVの区分
        ''' </summary>
        Public Class CSVFile
            Public Const UNDERLINE As String = "_"
            Public Const DASH As String = "-"
            Public Const DELIMITER As String = ","
            Public Const TAB As String = "\t"
            Public Const SLASH As String = "\"
            Public Const SGQUOTE As String = """"
            Public Const YES As String = "Yes"
        End Class

        Public Class InputMode
            Public Const MONTH = "month"
        End Class

        ''' <summary>
        ''' ファイルの種類
        ''' </summary>
        Public Class FileType
            Public Const IMAGE = ".png,.jpg,.gif,.bmp,.jpeg"
        End Class

        Public Class File
            Public Const BACKSLASH As String = "\"
        End Class

        Public Structure LogType
            Public Const INSERT = "登録"
            Public Const UPDATE = "更新"
            Public Const DELETE = "削除"
            Public Const LOGIN = "ログイン"
            Public Const LOGIN_SUCCESS = "成功"
            Public Const LOGIN_FAIL = "失敗"
            Public Const LOGOUT = "ログアウト"
            Public Const EXPORT_CSV = "CSV出力"
            Public Const EXPORT_PDF = "PDF出力"
            Public Const IMPORT_CSV = "ログアウト"
        End Structure

        ''' <summary>
        ''' 状態情報
        ''' </summary>
        Public Class StatusInf
            Public Shared SUCCESS As String = "OK"
            Public Shared FAILED As String = "ERR"
            Public Shared VALIDATE As String = "VALIDATE"
        End Class

        ''' <summary>
        ''' 完了区分
        ''' </summary>
        Public Class CompleteClass
            ''' <summary>
            ''' 仕入未完了
            ''' </summary>
            Public Shared INCOMPLETE As String = "0"
            ''' <summary>
            ''' 完了
            ''' </summary>
            Public Shared COMPLETE As String = "1"
        End Class

        ''' <summary>
        ''' 発注区分
        ''' </summary>
        Public Class OrderClass
            ''' <summary>
            ''' 外注発注
            ''' </summary>
            Public Shared SUBCONTRACT_ORDER As String = "1"
            ''' <summary>
            ''' 用紙発注
            ''' </summary>
            Public Shared PAPER_ORDER As String = "2"
        End Class

        ''' <summary>
        ''' Type get Name 1：名称、2：略称
        ''' </summary>
        Public Class TypeGetName
            ''' <summary>
            ''' 名称
            ''' </summary>
            Public Const FULLNAME = "1"
            ''' <summary>
            ''' 略称
            ''' </summary>
            Public Const SHORT_NAME = "2"
        End Class

        ''' <summary>
        ''' 対象日範囲
        ''' </summary>
        Public Class TargetDateType
            ''' <summary>
            ''' 発注日
            ''' </summary>
            Public Shared PURCHASE_DATE As String = "0"
            ''' <summary>
            ''' 搬入日
            ''' </summary>
            Public Shared DELIVERY_DATE As String = "1"
        End Class

        ''' <summary>
        ''' 取引先の回収日または支払日
        ''' </summary>
        Public Class PaymentDateType
            ''' <summary>
            ''' 回収日
            ''' </summary>
            Public Shared COLLECT_DATE As String = "0"
            ''' <summary>
            ''' 支払日
            ''' </summary>
            Public Shared PAYMENT_DATE As String = "1"
        End Class

        ''' <summary>
        ''' PROCESS_TYPE
        ''' </summary>
        Public Class ProcessType
            ''' <summary>
            ''' 準備処理
            ''' </summary>
            Public Const PREPARATION = "1"
            ''' <summary>
            ''' 準備解除
            ''' </summary>
            Public Const UNPREPARED = "2"
            ''' <summary>
            ''' 締処理
            ''' </summary>
            Public Const TIGHTENING = "3"
        End Class

        ''' <summary>
        ''' 状態区分
        ''' </summary>
        Public Class StatusClass
            ''' <summary>
            ''' 新規作成
            ''' </summary>
            Public Const CREATE_NEW = "0"
            ''' <summary>
            ''' 修正
            ''' </summary>
            Public Const EDIT = "1"
            ''' <summary>
            ''' 参照作成
            ''' </summary>
            Public Const CREATE_REFERENCE = "2"
        End Class
    End Module
End Namespace
