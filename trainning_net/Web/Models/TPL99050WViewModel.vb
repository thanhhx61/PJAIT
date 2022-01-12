Namespace Models
    <Serializable>
    Public Class TPL99050WViewModel

        Public Sub New()

        End Sub

        Public Sub New(CurrentPage As Integer, ProductType As String, ProductTypeName As String, ProducerCode As String,
                       ProducerName As String, NameSearch As String, POnLoad As String)
            Me.pageCurrent = CurrentPage
            Me.ProductType = ProductType
            Me.ProductTypeName = ProductTypeName
            Me.ProducerCode = ProducerCode
            Me.ProducerName = ProducerName
            Me.NameSearch = NameSearch
            Me.POnLoad = POnLoad
        End Sub

        Public Property pageCurrent As Integer = 1
        Public Property ProductType As String
        Public Property ProductTypeName As String
        Public Property ProducerCode As String
        Public Property ProducerName As String
        Public Property NameSearch As String
        Public Property POnLoad As String = ""
    End Class
End Namespace
