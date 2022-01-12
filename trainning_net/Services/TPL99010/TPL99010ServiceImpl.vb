Imports Core.ConstantCore.Consts
Imports Core.My.Resources
Imports Core.Session
Imports Core.Util
Imports Dao
Imports Entities

Namespace Services
    Public Class TPL99010ServiceImpl
        Implements ITPL99010Service
        Private ReadOnly _TPL_コードDao As コードDao
        Private ReadOnly _BaseService As IBaseService
        Public Sub New(tPL_コードDao As コードDao)
            _TPL_コードDao = tPL_コードDao
        End Sub

        Public Function SearchCodePagedList(request As PaginationRequestDto(Of SearchCodeParamDto)) As PanigationResultDto(Of コードDto) Implements ITPL99010Service.SearchCodePagedList
            Return _TPL_コードDao.SearchCodePagedListDao(request)
        End Function

    End Class
End Namespace
