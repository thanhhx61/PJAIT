Imports Core.Util
Imports Dao
Imports Entities

Namespace Services
    Public Class TPL99040ServiceImpl
        Implements ITPL99040Service
        Public _TPL_コードDao As コードDao
        Public _TPL_担当Dao As 担当Dao

        Public Sub New(tPL_コードDao As コードDao, tPL_担当Dao As 担当Dao)
            _TPL_コードDao = tPL_コードDao
            _TPL_担当Dao = tPL_担当Dao
        End Sub

        Public Function SearchCodePagedList(request As PaginationRequestDto(Of SearchEmployeeParamDto)) As PanigationResultDto(Of ResultSearchByDepartAndNameDto) Implements ITPL99040Service.SearchCodePagedList
            Dim resultDao = _TPL_担当Dao.GetEmployeeByDepartmentAndNamePagedList(request)
            Return resultDao
        End Function

        Public Function GetDataComboBoxById(id As String) As List(Of ComboBoxDto) Implements ITPL99040Service.GetDataComboBoxById
            Dim listCombo = _TPL_コードDao.GetCombo(id)
            listCombo.Insert(0, New ComboBoxDto() With {.コード = String.Empty, .名称 = String.Empty, .略称 = String.Empty, .表示順 = 0})
            Return listCombo
        End Function
    End Class
End Namespace
