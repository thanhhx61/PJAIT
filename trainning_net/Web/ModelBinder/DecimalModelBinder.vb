Imports Core.Util

Public Class DecimalModelBinder
    Inherits DefaultModelBinder
    Public Overrides Function BindModel(controllerContext As ControllerContext, bindingContext As ModelBindingContext) As Object
        Dim valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName)

        If String.IsNullOrEmpty(valueProviderResult.AttemptedValue) OrElse Not IsNumeric(valueProviderResult.AttemptedValue) Then
            Return Nothing
        End If

        Return NumberUtil.ConvertToDecimal(valueProviderResult.AttemptedValue)
    End Function

End Class
