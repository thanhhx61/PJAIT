Imports System.Text
Imports Core.ConstantCore
Imports Entities
Imports Unity
Public Class 自社Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_自社)
    Public Function SelectCompanyByCode(code As String) As TPL_自社
        Return _Repository._dbSet.Where(Function(x) x.コード = code).Select(Function(x) x).FirstOrDefault()
    End Function
    ''' <summary>
    ''' 自社締日
    ''' </summary>
    ''' <returns>ClosingDateDto</returns>
    Function GetPayableAndReciveClosingDate() As ClosingDateDto
        Return _Repository._dbSet.Where(Function(a) a.コード = COMMON_CODE).Select(Function(a) New ClosingDateDto() With {.買掛金締日 = a.買掛金締日, .売掛金締日 = a.売掛金締日}).FirstOrDefault()
    End Function

End Class
