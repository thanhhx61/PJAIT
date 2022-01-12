Imports Dao
Imports Dao.Dto
Imports Entities
Imports Services.Dto

Namespace Services
    ''' <summary>
    ''' メニュー画面のサービス
    ''' </summary>
    Public Class TPL00020ServiceImpl
        Implements ITPL00020Service
        Private ReadOnly _担当Dao As 担当Dao
        Private ReadOnly _メニューDao As メニューDao


        Public Sub New(担当Dao As 担当Dao, メニューDao As メニューDao)
            _担当Dao = 担当Dao
            _メニューDao = メニューDao
        End Sub


        ''' <summary>
        ''' メニューマスタを検索する。
        ''' </summary>
        ''' <param name="userId"></param>
        ''' <returns></returns>
        Public Function GetMenu(userId As String) As MenuDetailResultDto Implements ITPL00020Service.GetMenu
            Dim menuDetail As MenuDetailResultDto = New MenuDetailResultDto()
            Dim pic = _担当Dao.SelectUserByUserId(userId)
            Dim menus = _メニューDao.SelectMenuDispByRoleId(pic.メニュー権限)
            If menus.Count <> 0 Then
                Dim firstMenuId = menus.FirstOrDefault().メニューID
                menuDetail.menus = menus
                menuDetail.programs = _メニューDao.SelectProgramByParentMenuID(firstMenuId)
            End If
            Return menuDetail
        End Function

        ''' <summary>
        ''' URLの画面を取得する。
        ''' </summary>
        ''' <param name="MenuId"></param>
        ''' <returns></returns>
        Public Function GetProgram(MenuId As String) As List(Of MenuProgramResultDto) Implements ITPL00020Service.GetProgram
            Return _メニューDao.SelectProgramByParentMenuID(MenuId)
        End Function

    End Class
End Namespace