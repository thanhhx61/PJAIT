<Serializable>
Public Class SearchOrderParamDto
    Public Sub New()
    End Sub

    Public Sub New(orderNo As String, productType As String, customer As String, startDate As Date?, endDate As Date?, productName As String, productRemark As String, employee As String, isAnyOrderBacklog As String)
        Me.OrderNo = orderNo
        Me.ProductType = productType
        Me.Customer = customer
        Me.StartDate = startDate.GetValueOrDefault()
        Me.EndDate = endDate.GetValueOrDefault()
        Me.ProductName = productName
        Me.ProductRemark = productRemark
        Me.Employee = employee
        Me.IsAnyOrderBacklog = isAnyOrderBacklog
    End Sub

    Public Property OrderNo As String
    Public Property ProductType As String
    Public Property Customer As String
    Public Property StartDate As Date
    Public Property EndDate As Date
    Public Property ProductName As String
    Public Property ProductRemark As String
    Public Property Employee As String
    Public Property IsAnyOrderBacklog As String
End Class
