Namespace Models
    <Serializable>
    Public Class TPL04020ViewModel
        Public Property StartDate As Date?
        Public Property EndDate As Date?
        Public Property Billingdeadline As String
        Public Property Employee As String
        Public Property PageCurrent As Integer = 1
        Public Property OrderNo As String
        Public Property Customer As String
        Public Property ProductType As String
        Public Property ProductName As String
        Public Property ProductRemark As String
        Public Property IsAnyOrderBacklog As String
    End Class
End Namespace

