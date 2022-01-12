Imports Core.ConstantCore.Consts
Imports Core.Util
Imports Dao
Imports Entities
Imports Services.Dto

Namespace Services
    ''' <summary>
    ''' ログイン画面のサービス
    ''' </summary>
    Public Class TPL00010ServiceImpl
        Implements ITPL00010Service
        Private ReadOnly _担当Dao As 担当Dao
        Private ReadOnly _メニューDao As メニューDao
        Private ReadOnly _ログDao As ログDao
        Private ReadOnly _CMN9000 As ICMN9000Service

        Public Sub New(担当Dao As 担当Dao, メニューDao As メニューDao, ログDao As ログDao, CMN9000 As ICMN9000Service)
            _担当Dao = 担当Dao
            _メニューDao = メニューDao
            _ログDao = ログDao
            _CMN9000 = CMN9000
        End Sub

        ''' <summary>
        ''' 社員情報を取得する。
        ''' </summary>
        ''' <param name="loginDto"></param>
        ''' <returns></returns>
        Public Function Login(loginDto As LoginDto) As LoginResultDto Implements ITPL00010Service.Login
            Dim res As New LoginResultDto
            Dim message As New MessageInfoDto
            Dim picDto As New PicDto()
            Dim sysStr = DateUtil.GetSysDate(SysdateFormat.YYYYMMDDHHMMSSFFF)
            'Check input
            If String.IsNullOrEmpty(loginDto.UserId) Then
                'failed
                SetMessage(message, "Login.UserId", Core.My.Resources.ValidationResource.MSG_018, True)
                res.Message = message
                WriteLog(LogType.LOGIN_FAIL, loginDto.UserId, loginDto.IPAddress, sysStr)
                Return res
            End If

            If String.IsNullOrEmpty(loginDto.Password) Then
                'failed
                SetMessage(message, "Login.Password", Core.My.Resources.ValidationResource.MSG_019, True)
                res.Message = message
                'write log
                WriteLog(LogType.LOGIN_FAIL, loginDto.UserId, loginDto.IPAddress, sysStr)
                Return res
            End If

            'check DB
            Dim pic = _担当Dao.SelectUserByUserId(loginDto.UserId)
            If pic Is Nothing Then
                'failed
                SetMessage(message, "Login.UserId", Core.My.Resources.ValidationResource.MSG_020, True)
                res.Message = message
                WriteLog(LogType.LOGIN_FAIL, loginDto.UserId, loginDto.IPAddress, sysStr)
                Return res
            End If
            If pic.パスワード Is Nothing OrElse Not pic.パスワード.Equals(StringUtil.PasswordSha256(loginDto.Password)) Then
                'failed
                SetMessage(message, "Login.UserId", Core.My.Resources.ValidationResource.MSG_020, True)
                res.Message = message
                'write log
                WriteLog(LogType.LOGIN_FAIL, loginDto.UserId, loginDto.IPAddress, sysStr)
                Return res
            End If
            Dim menus = _メニューDao.SelectMenuByRoleId(pic.メニュー権限)
            If menus.Count <= 0 Then
                'failed
                SetMessage(message, "Login.UserId", Core.My.Resources.ValidationResource.MSG_021, True)
                res.Message = message
                'write log
                WriteLog(LogType.LOGIN_FAIL, loginDto.UserId, loginDto.IPAddress, sysStr)
                Return res
            End If
            'set return
            Dim programId = menus.Select(Function(x) x.プログラムID).ToList()
            picDto.担当 = pic.担当
            picDto.氏名 = pic.氏名
            picDto.ふりがな = pic.ふりがな

            res.IsSuccess = True
            res.ProgramIds = programId
            res.Message = message
            res.Pic = picDto
            'write log
            WriteLog(LogType.LOGIN_SUCCESS, pic.担当, loginDto.IPAddress, sysStr)

            Return res
        End Function

        Private Sub SetMessage(ByRef messageDto As MessageInfoDto, focus As String, message As String, isMessage As Boolean)
            messageDto.Focus = focus
            messageDto.Message = message
            messageDto.IsMessage = isMessage
        End Sub

        Private Sub WriteLog(type As String, pic As String, ip As String, dateTime As String)
            Dim log = New TPL_ログ()
            log.処理日時 = DateUtil.ConvertStringToDate(dateTime, DateFormat.DATETIMEFULL_F6)
            log.区分 = LogType.LOGIN + "(" + type + ")"
            log.担当 = pic
            log.画面名 = "TPL00010/Login"
            log.接続元IP = ip
            log.SQL文 = String.Empty

            _ログDao._Repository.Insert(log, Nothing, False)
        End Sub

    End Class
End Namespace