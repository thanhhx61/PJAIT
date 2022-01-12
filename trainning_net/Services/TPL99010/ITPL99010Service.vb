Imports Core.Session
Imports Dao
Imports Entities

Namespace Services
    Public Interface ITPL99010Service

        Function SearchCodePagedList(request As PaginationRequestDto(Of SearchCodeParamDto)) As PanigationResultDto(Of コードDto)

    End Interface
End Namespace

