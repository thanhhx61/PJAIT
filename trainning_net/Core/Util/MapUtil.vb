Imports Core.ConstantCore.Consts

Namespace Util
    ''' <summary>
    ''' 「Object変換」操作のユーティリティクラス
    ''' </summary>
    ''' <typeparam name="Source"></typeparam>
    ''' <typeparam name="Destinate"></typeparam>
    Public Class MapUtil(Of Source, Destinate)
        ''' <summary>
        ''' SourceからDestinateに変換する
        ''' </summary>
        ''' <param name="source"></param>
        ''' <returns></returns>
        Public Overloads Shared Function MapFromTo(ByVal source As Source) As Destinate
            Dim typeSource As Type = source.GetType()
            Dim destinate As Destinate = CType(Activator.CreateInstance(GetType(Destinate)), Destinate)
            Dim typeDestinate As Type = destinate.GetType()
            Dim propertyNameSources = typeSource.GetProperties().Select(Function(x) x.Name)
            Dim propertyNameDestinate = typeDestinate.GetProperties().Select(Function(x) x.Name)

            For Each nameDestivate In propertyNameDestinate
                If propertyNameSources.Contains(nameDestivate) Then
                    Dim desPropertyInfo = typeDestinate.GetProperty(nameDestivate)
                    Dim srcPropertyInfo = typeSource.GetProperty(nameDestivate)
                    Dim srcValue = srcPropertyInfo.GetValue(source, Nothing)
                    If srcValue IsNot Nothing Then
                        If desPropertyInfo.PropertyType = GetType(Int16) OrElse desPropertyInfo.PropertyType = GetType(Nullable(Of Int16)) Then
                            desPropertyInfo.SetValue(destinate, Convert.ToInt16(srcValue.ToString()))
                        ElseIf desPropertyInfo.PropertyType = GetType(Int32) OrElse desPropertyInfo.PropertyType = GetType(Nullable(Of Int32)) Then
                            desPropertyInfo.SetValue(destinate, Convert.ToInt32(srcValue.ToString()))
                        ElseIf desPropertyInfo.PropertyType = GetType(Int64) OrElse desPropertyInfo.PropertyType = GetType(Nullable(Of Int64)) Then
                            desPropertyInfo.SetValue(destinate, Convert.ToInt64(srcValue.ToString()))
                        ElseIf desPropertyInfo.PropertyType = GetType(Double) OrElse desPropertyInfo.PropertyType = GetType(Nullable(Of Double)) Then
                            desPropertyInfo.SetValue(destinate, Convert.ToDouble(srcValue.ToString()))
                        ElseIf desPropertyInfo.PropertyType = GetType(Decimal) OrElse desPropertyInfo.PropertyType = GetType(Nullable(Of Decimal)) Then
                            desPropertyInfo.SetValue(destinate, Convert.ToDecimal(srcValue.ToString()))
                        ElseIf desPropertyInfo.PropertyType = GetType(String) Then
                            desPropertyInfo.SetValue(destinate, srcValue.ToString())
                        ElseIf desPropertyInfo.PropertyType = GetType(Boolean) OrElse desPropertyInfo.PropertyType = GetType(Nullable(Of Boolean)) Then
                            desPropertyInfo.SetValue(destinate, srcValue)
                        ElseIf desPropertyInfo.PropertyType = GetType(Nullable(Of DateTime)) AndAlso srcPropertyInfo.PropertyType = GetType(Nullable(Of DateTime)) Then
                            desPropertyInfo.SetValue(destinate, srcValue)
                        ElseIf desPropertyInfo.PropertyType = GetType(Nullable(Of DateTime)) AndAlso srcPropertyInfo.PropertyType = GetType(Nullable(Of DateTime)) Then
                            desPropertyInfo.SetValue(destinate, DateUtil.ConvertStringToDate(srcValue, DateFormat.YYYYMMDD))
                        ElseIf desPropertyInfo.PropertyType = GetType(DateTime) AndAlso srcPropertyInfo.PropertyType = GetType(DateTime) Then
                            desPropertyInfo.SetValue(destinate, DateUtil.ConvertStringToDate(srcValue, DateFormat.YYYYMMDD))
                        ElseIf desPropertyInfo.PropertyType = GetType(DateTime) AndAlso srcPropertyInfo.PropertyType = GetType(Nullable(Of DateTime)) Then
                            desPropertyInfo.SetValue(destinate, srcValue)
                        ElseIf (desPropertyInfo.PropertyType = GetType(DateTime) OrElse desPropertyInfo.PropertyType = GetType(Nullable(Of DateTime))) AndAlso srcPropertyInfo.PropertyType = GetType(String) Then
                            desPropertyInfo.SetValue(destinate, DateUtil.ConvertStringToDate(srcValue, DateFormat.YYYYMMDD))
                        ElseIf (desPropertyInfo.PropertyType = GetType(Nullable(Of DateTime)) Or desPropertyInfo.PropertyType = GetType(DateTime)) AndAlso srcPropertyInfo.PropertyType = GetType(String) Then
                            desPropertyInfo.SetValue(destinate, DateUtil.ConvertStringToDate(srcValue, DateFormat.YYYYMMDD))
                        ElseIf desPropertyInfo.PropertyType = GetType(Nullable(Of DateTime)) AndAlso srcPropertyInfo.PropertyType = GetType(DateTime) Then
                            desPropertyInfo.SetValue(destinate, srcValue)
                        ElseIf desPropertyInfo.PropertyType = GetType(Decimal) OrElse desPropertyInfo.PropertyType = GetType(Nullable(Of Decimal)) Then
                            desPropertyInfo.SetValue(destinate, srcValue)
                        Else
                            desPropertyInfo.SetValue(destinate, srcValue.ToString())
                        End If
                    End If
                End If
            Next
            Return destinate
        End Function

        Public Overloads Shared Sub MapFromTo(ByVal source As Source, ByRef destinate As Destinate)
            Dim typeSource As Type = source.GetType()
            Dim typeDestinate As Type = destinate.GetType()
            Dim propertyNameSources = typeSource.GetProperties().Select(Function(x) x.Name)
            Dim propertyNameDestinate = typeDestinate.GetProperties().Select(Function(x) x.Name)

            For Each nameDestivate In propertyNameDestinate
                If propertyNameSources.Contains(nameDestivate) Then
                    Dim desPropertyInfo = typeDestinate.GetProperty(nameDestivate)
                    Dim srcPropertyInfo = typeSource.GetProperty(nameDestivate)
                    Dim srcValue = srcPropertyInfo.GetValue(source, Nothing)
                    If srcValue IsNot Nothing Then
                        If desPropertyInfo.PropertyType = GetType(Int16) OrElse srcPropertyInfo.PropertyType = GetType(Nullable(Of Int16)) Then
                            desPropertyInfo.SetValue(destinate, Convert.ToInt16(srcValue.ToString()))
                        ElseIf desPropertyInfo.PropertyType = GetType(Int32) OrElse srcPropertyInfo.PropertyType = GetType(Nullable(Of Int32)) Then
                            desPropertyInfo.SetValue(destinate, Convert.ToInt32(srcValue.ToString()))
                        ElseIf desPropertyInfo.PropertyType = GetType(Int64) OrElse srcPropertyInfo.PropertyType = GetType(Nullable(Of Int64)) Then
                            desPropertyInfo.SetValue(destinate, Convert.ToInt64(srcValue.ToString()))
                        ElseIf desPropertyInfo.PropertyType = GetType(Double) OrElse srcPropertyInfo.PropertyType = GetType(Nullable(Of Double)) Then
                            desPropertyInfo.SetValue(destinate, Convert.ToDouble(srcValue.ToString()))
                        ElseIf desPropertyInfo.PropertyType = GetType(String) Then
                            desPropertyInfo.SetValue(destinate, srcValue.ToString())
                        ElseIf desPropertyInfo.PropertyType = GetType(Boolean) OrElse srcPropertyInfo.PropertyType = GetType(Nullable(Of Boolean)) Then
                            desPropertyInfo.SetValue(destinate, srcValue)
                        ElseIf desPropertyInfo.PropertyType = GetType(Nullable(Of DateTime)) AndAlso srcPropertyInfo.PropertyType = GetType(Nullable(Of DateTime)) Then
                            desPropertyInfo.SetValue(destinate, srcValue, Nothing)
                        ElseIf desPropertyInfo.PropertyType = GetType(Nullable(Of DateTime)) Then
                            desPropertyInfo.SetValue(destinate, DateUtil.ConvertStringToDate(srcValue, DateFormat.YYYYMMDD), Nothing)
                        Else
                            desPropertyInfo.SetValue(destinate, srcValue.ToString())
                        End If
                    End If
                End If
            Next
        End Sub

        ''' <summary>
        ''' Source一覧からDestinate一覧に変換する
        ''' </summary>
        ''' <param name="source"></param>
        ''' <returns></returns>
        Public Shared Function MapFromToList(ByVal source As List(Of Source)) As List(Of Destinate)
            Dim listDestinate = New List(Of Destinate)()

            For Each itemSource In source
                listDestinate.Add(MapFromTo(itemSource))
            Next
            Return listDestinate
        End Function
    End Class
End Namespace