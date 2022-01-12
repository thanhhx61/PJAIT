Namespace Attribute
    Public Class AllowHtmlBinder
        Implements IModelBinder
        Public Function BindModel(controllerContext As ControllerContext, bindingContext As ModelBindingContext) As Object Implements IModelBinder.BindModel
            Dim request = controllerContext.HttpContext.Request
            Dim name = bindingContext.ModelName
            Return request.Unvalidated(name)
        End Function
    End Class
End Namespace
