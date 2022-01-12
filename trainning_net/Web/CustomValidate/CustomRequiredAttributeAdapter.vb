Imports System.ComponentModel.DataAnnotations

Public Class CustomRequiredAttributeAdapter
    Inherits RequiredAttributeAdapter

    Public Sub New(ByVal metadata As ModelMetadata, ByVal context As ControllerContext, ByVal attribute As RequiredAttribute)
        MyBase.New(metadata, context, attribute)
        'TODO
        'attribute.ErrorMessage = Core.My.Resources.ValidationResource.ERR_001
    End Sub
End Class
