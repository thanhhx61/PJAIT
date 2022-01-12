Imports System.Text
Imports Entities
Imports Unity
Public Class 売上基本Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_売上基本)

    Public Function SelectSaleBasicByOrderNo(orderNo As String) As List(Of TPL_売上基本)
        Return _Repository._dbSet.Where(Function(x) x.受注番号 = orderNo AndAlso x.削除フラグ = False).OrderBy(Function(x) x.売上番号).Select(Function(x) x).ToList()
    End Function

    Public Function SelectSaleBasicByNoAndSerial(saleNo As String, serialNumber As Integer?) As TPL_売上基本
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT * FROM ")
        sql.AppendLine("   売上基本 ")
        sql.AppendLine(" WHERE ")
        sql.AppendLine("   売上番号 = :saleNo ")
        If serialNumber IsNot Nothing Then sql.AppendLine(" AND 行番号 = :serialNumber ")
        sql.AppendLine(" AND 削除フラグ = false ")

        Return _Repository.Selects(Of TPL_売上基本)(sql.ToString(), New With {.saleNo = saleNo, .serialNumber = serialNumber}).FirstOrDefault
    End Function

    Private Function GetQuerySelectInfOder(param As SearchInforParamDto) As StringBuilder
        Dim sql = New StringBuilder()
        sql.AppendLine(" SELECT	売上基本.売上番号,		")
        sql.AppendLine(" 		売上基本.受注番号,		")
        sql.AppendLine(" 		売上基本.売上日,		")
        sql.AppendLine(" 		売上基本.請求日,		")
        sql.AppendLine(" 		売上基本.取引区分,		")
        sql.AppendLine(" 		A.略称 AS 取引区分名,	")
        sql.AppendLine(" 		売上基本.品名,			")
        sql.AppendLine(" 		売上基本.売上数量,		")
        sql.AppendLine(" 		売上基本.売上金額,		")
        sql.AppendLine(" 		売上基本.得意先名,		")
        sql.AppendLine(" 		受注基本.担当名,		")
        sql.AppendLine(" 		B.数字1 AS 税,		")
        sql.AppendLine(" 		B.略称 AS 税率,		")
        sql.AppendLine(" 		C.略称 AS 単位名,		")
        sql.AppendLine(" 		D.略称 AS 課税区分名,	")
        sql.AppendLine(" 		売上基本.売上単価,		")
        sql.AppendLine(" 		売上基本.備考			")
        sql.AppendLine(" ON					売上基本.受注番号			=		受注基本.受注番号	 ")
        sql.AppendLine(" AND					受注基本.削除フラグ		=		false			 ")
        sql.AppendLine(" LEFT JOIN					コード A									 ")
        sql.AppendLine(" ON					A.識別					=		'1037'			 ")
        sql.AppendLine(" AND					売上基本.取引区分		=		A.コード			 ")
        sql.AppendLine(" LEFT JOIN					コード B									 ")
        sql.AppendLine(" ON					B.識別					=		'1040'			 ")
        sql.AppendLine(" AND					売上基本.税率			=		B.コード			 ")
        sql.AppendLine(" LEFT JOIN					コード C									 ")
        sql.AppendLine(" ON					C.識別					=		'1025'			 ")
        sql.AppendLine(" AND					売上基本.単位			=		C.コード			 ")
        sql.AppendLine(" LEFT JOIN					コード D									 ")
        sql.AppendLine(" ON					D.識別					=		'1039'			 ")
        sql.AppendLine(" AND					売上基本.課税区分		=		D.コード			 ")
        sql.AppendLine(" WHERE					1=1											 ")
        '得意先
        If (Not String.IsNullOrEmpty(param.ProudFirst)) Then
            sql.AppendLine(" AND 売上基本.得意先 = :ProudFirst")
        End If
        '受注担当
        If (Not String.IsNullOrEmpty(param.ReceivingOrder)) Then
            sql.AppendLine(" AND 売上基本.担当	= :ReceivingOrder")
        End If
        '売上日(開始)
        sql.AppendLine(" AND 売上基本.売上日 >= :StartDate")
        '売上日(終了)
        sql.AppendLine(" AND A.受注日 <= :EndDate")
        sql.AppendLine(" AND					削除フラグ				=		false				")

        Return sql
    End Function
    ''' <summary>
    ''' TPL01040 受注検索処理 
    ''' </summary>
    ''' <param name="param">SearchOrderParamDto</param>
    ''' <returns>List(Of SearchOrderResultDto)</returns>
    Public Function GetInfoList(param As SearchInforParamDto) As List(Of SearchInforResultDto)
        Dim sql = GetQuerySelectInfOder(param)
        Return _Repository.Selects(Of SearchInforResultDto)(sql.ToString(), param)
    End Function

End Class
