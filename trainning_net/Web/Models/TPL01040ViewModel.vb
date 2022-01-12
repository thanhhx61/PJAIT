Namespace Models
    <Serializable>
    Public Class TPL01040ViewModel
        Public Sub New()
        End Sub
        Public Property RecordNumberOfPage As Long = 10
        Public Property PageCurrent As Integer = 1
        Public Property OrderNo As String
        Public Property ProductType As String
        Public Property Customer As String
        Public Property CustomerName As String
        Public Property StartDate As Date?
        Public Property EndDate As Date?
        Public Property IsAnyOrderBacklog As String
        Public Property ProductName As String
        Public Property ProductRemark As String
        Public Property Employee As String
    End Class

    Friend Class Tpl01010ParameterDto
        Public Property OrderNo As String
        Public Property ProcessMode As String
    End Class
    Friend Class TPL04030ParameterDto
        Public Property orderNo As String
    End Class

    Friend Class TPL04010ParameterDto
        Public Property orderNo As String
        Public Property SalesNo As Object
    End Class

    Friend Class Tpl02030ParameterDto
        Public Property orderNo As String
        Public Property purchaseNo As Object
    End Class
    Friend Class Tpl02010ParameterDto
        Public Property orderNo As String
        Public Property PurchaseNo As Object
    End Class
End Namespace
