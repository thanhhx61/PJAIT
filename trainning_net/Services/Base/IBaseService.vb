Imports Dao
Imports Dao.Dto
Imports Entities

Public Interface IBaseService
    '----- log
    Sub InsertLog(obj As LogDto)
    Sub InsertErrorLog(obj As ErrorLogDto)
    Sub WriteErrorLog(ex As Exception, logInfo As LogInfoDto)
End Interface
