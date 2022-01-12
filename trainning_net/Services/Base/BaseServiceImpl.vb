Imports Core.ConstantCore.Consts
Imports Core.Util
Imports Dao
Imports Dao.Dto
Imports Entities

Namespace Services
    Public Class BaseServiceImpl
        Implements IBaseService
        Private ReadOnly _エラーログDao As エラーログDao
        Private ReadOnly _ログDao As ログDao

        Public Sub New(エラーログDao As エラーログDao, ログDao As ログDao)
            Me._エラーログDao = エラーログDao
            Me._ログDao = ログDao
        End Sub

        'Normal Log
        Public Sub InsertLog(obj As LogDto) Implements IBaseService.InsertLog
            Dim log As New TPL_ログ()
            Dim sysdate = DateUtil.ConvertStringToDate(DateUtil.GetSysDate(SysdateFormat.YYYYMMDDHHMMSS), DateFormat.DATETIMEFULL)
            log.処理日時 = sysdate
            log.区分 = obj.区分
            log.担当 = obj.担当
            If obj.画面名 IsNot Nothing Then
                log.画面名 = If(obj.画面名.Length > 100, obj.画面名.Substring(0, 100), obj.画面名)
            End If
            log.接続元IP = obj.接続元IP
            log.SQL文 = If(obj.SQL文.Length > 1000, obj.SQL文.Substring(0, 1000), obj.SQL文) 
            _ログDao.InsertLog(log)
        End Sub

        'Error Log
        Public Sub InsertErrorLog(obj As ErrorLogDto) Implements IBaseService.InsertErrorLog
            Dim log As New TPL_エラーログ()
            Dim sysdate = DateUtil.ConvertStringToDate(DateUtil.GetSysDate(SysdateFormat.YYYYMMDDHHMMSS), DateFormat.DATETIMEFULL)
            log.処理日時 = sysdate
            log.接続元IP = obj.接続元IP
            log.担当 = obj.担当
            If obj.画面名 IsNot Nothing Then
                log.画面名 = If(obj.画面名.Length > 100, obj.画面名.Substring(0, 100), obj.画面名)
            End If
            If obj.エラー内容 IsNot Nothing Then
                log.エラー内容 = If(obj.エラー内容.Length > 1000, obj.エラー内容.Substring(0, 1000), obj.エラー内容)
            End If
            If obj.エラー詳細 IsNot Nothing Then
                log.エラー詳細 = If(obj.エラー詳細.Length > 1000, obj.エラー詳細.Substring(0, 1000), obj.エラー詳細)
            End If

            _エラーログDao.InsertErrorLog(log)
        End Sub

        Public Sub WriteErrorLog(ex As Exception, logInfo As LogInfoDto) Implements IBaseService.WriteErrorLog
            Dim log As New ErrorLogDto
            log.担当 = logInfo.LoginId
            log.画面名 = logInfo.ScreenName
            log.接続元IP = logInfo.SourceIp
            log.エラー内容 = ex.Message
            log.エラー詳細 = ex.ToString
            Me.InsertErrorLog(log)
        End Sub

    End Class
End Namespace
