Imports Dao.Dto
Imports Services.Dto

Namespace Services
    Public Interface ITPL00020Service
        Function GetMenu(EmpCode As String) As MenuDetailResultDto

        Function GetProgram(EmpCode As String) As List(Of MenuProgramResultDto)

    End Interface
End Namespace
