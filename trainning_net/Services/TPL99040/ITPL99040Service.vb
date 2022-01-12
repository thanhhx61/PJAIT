Imports Dao
Imports Entities

Namespace Services
    Public Interface ITPL99040Service
        Function SearchCodePagedList(request As PaginationRequestDto(Of SearchEmployeeParamDto)) As PanigationResultDto(Of ResultSearchByDepartAndNameDto)
        Function GetDataComboBoxById(id As String) As List(Of ComboBoxDto)
    End Interface
End Namespace

