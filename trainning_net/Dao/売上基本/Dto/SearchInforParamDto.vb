<Serializable>
Public Class SearchInforParamDto
    Public Sub New()
    End Sub
    Public Sub New(startDate As Date?, endDate As Date?, proudFirst As String, billingDeadline As String, receivingOrder As String)
        Me.ProudFirst = proudFirst
        Me.BillingDeadline = billingDeadline
        Me.ReceivingOrder = receivingOrder
        Me.StartDate = startDate.GetValueOrDefault()
        Me.EndDate = endDate.GetValueOrDefault()

    End Sub
    ''' <summary>
    ''' 得意先
    ''' </summary>
    ''' <returns></returns>
    Public Property ProudFirst As String
    ''' <summary>
    ''' 請求締日
    ''' </summary>
    ''' <returns></returns>
    Public Property BillingDeadline As String
    ''' <summary>
    ''' 受注担当
    ''' </summary>
    ''' <returns></returns>
    Public Property ReceivingOrder As String
    Public Property StartDate As Date
    Public Property EndDate As Date

End Class

