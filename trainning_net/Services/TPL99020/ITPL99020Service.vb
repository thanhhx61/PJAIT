Imports Core.Session
Imports Dao
Imports Entities

Namespace Services
    Public Interface ITPL99020Service

        Function SearchCodePagedList(request As PaginationRequestDto(Of SearchCustomerParamDto)) As PanigationResultDto(Of 取引先Dto)
        Function GetDataComboBoxById(id As String) As List(Of ComboBoxDto)

    End Interface
End Namespace

