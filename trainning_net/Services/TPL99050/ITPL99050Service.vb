Imports Core.Session
Imports Dao
Imports Entities

Namespace Services
    Public Interface ITPL99050Service
        Function SearchPaperPagedList(request As PaginationRequestDto(Of SearchPaperPopupParamDto)) As PanigationResultDto(Of ResultPaperPopupDto)

    End Interface
End Namespace

