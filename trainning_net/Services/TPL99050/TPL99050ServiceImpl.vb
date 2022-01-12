Imports Core.ConstantCore.Consts
Imports Core.My.Resources
Imports Core.Session
Imports Core.Util
Imports Dao
Imports Entities

Namespace Services
    Public Class TPL99050ServiceImpl
        Implements ITPL99050Service
        Private ReadOnly _TPL_用紙Dao As 用紙Dao
        Private ReadOnly _commonService As ICMN9000Service
        Private ReadOnly _BaseService As IBaseService

        Public Sub New(tPL_用紙Dao As 用紙Dao, commonService As ICMN9000Service)
            _TPL_用紙Dao = tPL_用紙Dao
            _commonService = commonService
        End Sub
        ''' <summary>
        ''' ヘッダー部の情報を元に用紙情報を検索する。
        ''' </summary>
        ''' <param name="request">ヘッダー部分</param>
        ''' <returns>リスト</returns>
        Public Function SearchPaperPagedList(request As PaginationRequestDto(Of SearchPaperPopupParamDto)) As PanigationResultDto(Of ResultPaperPopupDto) Implements ITPL99050Service.SearchPaperPagedList
            If Not String.IsNullOrEmpty(request.Param.ProducerName) Then
                request.Param.ProducerName = _commonService.ModFullWidthKana(request.Param.ProducerName)
            End If
            Dim resultDao = _TPL_用紙Dao.GetPaperByTypeAndProducer(request)
            Return resultDao
        End Function
    End Class
End Namespace
