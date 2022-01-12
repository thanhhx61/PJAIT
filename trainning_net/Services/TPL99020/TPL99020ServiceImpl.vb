Imports Core.ConstantCore.Consts
Imports Core.My.Resources
Imports Core.Session
Imports Core.Util
Imports Dao
Imports Entities

Namespace Services
    Public Class TPL99020ServiceImpl
        Implements ITPL99020Service
        Private ReadOnly _TPL_コードDao As コードDao
        Private ReadOnly _TPL_取引先Dao As 取引先Dao
        Private ReadOnly _BaseService As IBaseService
        Public Sub New(tPL_コードDao As コードDao, tPL_取引先Dao As 取引先Dao)
            _TPL_コードDao = tPL_コードDao
            _TPL_取引先Dao = tPL_取引先Dao
        End Sub

        Public Function SearchCodePagedList(request As PaginationRequestDto(Of SearchCustomerParamDto)) As PanigationResultDto(Of 取引先Dto) Implements ITPL99020Service.SearchCodePagedList
            Dim resultDao = _TPL_取引先Dao.GetCustomerByTypeAndNameOrYomiPagedList(request)
            Dim result = New PanigationResultDto(Of 取引先Dto)() With {
                .List = MapUtil(Of TPL_取引先, 取引先Dto).MapFromToList(resultDao.List), .PageSize = resultDao.PageSize, .Total = resultDao.Total}
            Return result
        End Function

        Public Function GetDataComboBoxById(id As String) As List(Of ComboBoxDto) Implements ITPL99020Service.GetDataComboBoxById
            Return _TPL_コードDao.GetCombo(id)
        End Function
    End Class
End Namespace
