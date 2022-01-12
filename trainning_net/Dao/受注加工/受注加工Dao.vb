Imports System.Text
Imports Core.Util
Imports Entities
Imports Unity
Public Class 受注加工Dao
    <Dependency>
    Public _Repository As IRepository(Of TPL_受注加工)

    Public Function GetOrderByKey6(orderNo As String) As List(Of TPL_受注加工)
        Return _Repository._dbSet.Where(Function(a) a.受注番号 = orderNo).OrderBy(Function(a) a.行番号).ToList()
    End Function

    ''' <summary>
    ''' 受注加工情報を削除する。
    ''' </summary>
    ''' <param name="param">パラメタ情報</param>
    ''' <returns></returns>
    Public Function DeleteQueryById(param As Object, log As LogInfoDto) As Integer
        Dim sql As StringBuilder = New StringBuilder()
        sql.AppendLine(" DELETE FROM 受注加工  ")
        sql.AppendLine(" WHERE ")
        sql.AppendLine(" 受注番号 = :OrderNo ")

        Return _Repository.DeleteByQuery(sql.ToString(), param, log)

    End Function
End Class
