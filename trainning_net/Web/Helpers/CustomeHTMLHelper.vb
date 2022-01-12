Imports System.Linq.Expressions
Imports Core.ConstantCore
Imports Core.Util
Imports Dao.Dto
Imports Entities
Imports Web.Models

Namespace CustomHTML
    Public Class CustomeHTMLHelper
        Public Shared Function TPLDatePicker(Value As Date?, width As Integer, tabIndex As Integer, inputMode As String,
                                             nameControl As String, Optional disable As Boolean = False, Optional id As String = "") As MvcHtmlString
            Dim tagBuilder As TagBuilder = New TagBuilder("input")
            tagBuilder.AddCssClass("form-control form-control-sm datepicker-date")
            tagBuilder.Attributes.Add("style", "width:" + width.ToString() + "px")
            tagBuilder.Attributes.Add("TabIndex", tabIndex)
            tagBuilder.Attributes.Add("autocomplete", "off")
            tagBuilder.Attributes.Add("name", nameControl)
            If Not String.IsNullOrEmpty(id) Then
                tagBuilder.MergeAttribute("id", id)
            End If
            If disable Then
                tagBuilder.Attributes.Add("disabled", "disabled")
            End If

            If Value.HasValue AndAlso Core.ConstantCore.InputMode.MONTH.Equals(inputMode) Then
                tagBuilder.Attributes.Add("value", DateUtil.ConvertDateToString(Value, DateFormat.YYYYMM_NF))
            ElseIf Value.HasValue Then
                tagBuilder.Attributes.Add("value", DateUtil.ConvertDateToString(Value, DateFormat.YYYYMMDD))
            End If
            If "date".Equals(inputMode) Then
                tagBuilder.Attributes.Add("data-date-format", DateFormat.YYMMDD_P)
                tagBuilder.AddCssClass("only-date")
            Else
                tagBuilder.Attributes.Add("data-date-format", DateFormat.YYYYMM_P)
                tagBuilder.AddCssClass("only-month")
            End If
            Return New MvcHtmlString(tagBuilder.ToString())
        End Function

        Public Shared Function TPLNumberFor(Of TModel, TProperty)(htmlHelper As HtmlHelper(Of TModel), expression As Expression(Of Func(Of TModel, TProperty)), htmlAttributes As Object) As MvcHtmlString
            Dim attributes As New Dictionary(Of String, Object)
            attributes.Add("class", "form-control-sm ct-input-number")
            attributes.Add("numeralThousandsGroupStyle", "thousand")
            attributes.Add("numeralPositiveOnly", False)
            attributes.Add("numeralIntegerScale", 1)
            attributes.Add("numeralDecimalScale", 0)

            If Not IsNothing(htmlAttributes) Then
                Dim beginhtmlAttributes As Dictionary(Of String, Object) = htmlAttributes.GetType().GetProperties().ToDictionary(Function(x) x.Name, Function(x) x.GetValue(htmlAttributes, Nothing))
                For Each pair As KeyValuePair(Of String, Object) In beginhtmlAttributes
                    If "class".Equals(pair.Key.ToLower()) Then
                        attributes.Item("class") = attributes.Item("class") & " " & pair.Value
                    Else
                        If attributes.ContainsKey(pair.Key) Then
                            attributes.Item(pair.Key) = pair.Value
                        Else
                            attributes.Add(pair.Key, pair.Value)
                        End If
                    End If
                Next
            End If
            Return InputExtensions.TextBoxFor(htmlHelper, expression, attributes)

        End Function

        ''' <summary>
        ''' コード
        ''' </summary>
        ''' <param name="name1"></param>
        ''' <param name="name2"></param>
        ''' <param name="codeWidth"></param>
        ''' <param name="nameWidth"></param>
        ''' <param name="identify"></param>
        ''' <param name="length"></param>
        ''' <param name="type"></param>
        ''' <param name="disableFlag1"></param>
        ''' <param name="disableFlag2"></param>
        ''' <param name="tabIndex"></param>
        ''' <param name="codeValue"></param>
        ''' <param name="nameValue"></param>
        ''' <returns></returns>
        Public Shared Function TPLCode(name1 As String, name2 As String, codeWidth As Integer, nameWidth As Integer,
                                          identify As String, length As Integer, type As String, disableFlag1 As Boolean, disableFlag2 As Boolean,
                                          tabIndex As Integer, codeValue As String, nameValue As String, Optional id1 As String = "") As MvcHtmlString
            Dim container = New TagBuilder("div")
            container.Attributes.Add("style", "display: flex")
            Dim codeInput = New TagBuilder("input")
            codeInput.AddCssClass("form-control form-control-sm code-custom mr-0 only-half-size ")
            codeInput.MergeAttribute("value", codeValue)
            codeInput.Attributes.Add("name", name1)
            If String.IsNullOrEmpty(id1) Then
                codeInput.Attributes.Add("id", name1)
            Else
                codeInput.Attributes.Add("id", id1)
            End If
            codeInput.Attributes.Add("style", "width:" + codeWidth.ToString() + "px")
            codeInput.Attributes.Add("TabIndex", tabIndex)
            codeInput.Attributes.Add("maxlength", length)
            codeInput.Attributes.Add("data-code-identify", identify)
            codeInput.Attributes.Add("data-get-type", type)
            If disableFlag1 = True Then
                codeInput.Attributes.Add("disabled", "disabled")
            End If
            If String.IsNullOrEmpty(codeValue) Then
                nameValue = String.Empty
            End If
            Dim nameInput = New TagBuilder("input")
            nameInput.AddCssClass("form-control form-control-sm code-name-custom ml-0 ")
            nameInput.MergeAttribute("value", nameValue)
            nameInput.Attributes.Add("name", name2)
            nameInput.Attributes.Add("style", "width:" + nameWidth.ToString() + "px")
            nameInput.Attributes.Add("maxlength", 10)
            If disableFlag2 = True Then
                nameInput.Attributes.Add("disabled", "disabled")
            Else
                nameInput.Attributes.Add("TabIndex", tabIndex + 1)
            End If

            container.InnerHtml = codeInput.ToString() + nameInput.ToString()
            Return New MvcHtmlString(container.ToString())
        End Function

        ''' <summary>
        ''' コード Grid
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="codeWidth"></param>
        ''' <param name="identify"></param>
        ''' <param name="length"></param>
        ''' <param name="type"></param>
        ''' <param name="disableFlag"></param>
        ''' <param name="tabIndex"></param>
        ''' <param name="codeValue"></param>
        ''' <param name="classField"></param>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Shared Function TPLCodeForGrid(name As String, codeWidth As Integer, length As Integer, type As String, identify As String,
                                              disableFlag As Boolean, tabIndex As Integer, codeValue As String, classField As String, Optional id As String = "") As MvcHtmlString
            Dim container = New TagBuilder("div")
            container.Attributes.Add("style", "display: flex")
            Dim codeInput = New TagBuilder("input")
            codeInput.AddCssClass("form-control code-grid-custom mr-0 only-half-size " + classField + " ")
            codeInput.MergeAttribute("value", codeValue)
            codeInput.Attributes.Add("name", name)
            codeInput.Attributes.Add("style", "width:" + codeWidth.ToString() + "px")
            codeInput.Attributes.Add("TabIndex", tabIndex)
            codeInput.Attributes.Add("maxlength", length)
            codeInput.Attributes.Add("data-get-type", type)
            codeInput.Attributes.Add("data-code-identify", identify)
            If disableFlag = True Then
                codeInput.Attributes.Add("disabled", "disabled")
            End If
            If Not String.IsNullOrEmpty(id) Then
                codeInput.MergeAttribute("id", id)
            End If

            container.InnerHtml = codeInput.ToString()
            Return New MvcHtmlString(container.ToString())
        End Function

        ''' <summary>
        ''' 取引先
        ''' </summary>
        ''' <param name="name1"></param>
        ''' <param name="name2"></param>
        ''' <param name="codeWidth"></param>
        ''' <param name="nameWidth"></param>
        ''' <param name="customerType"></param>
        ''' <param name="disableFlag1"></param>
        ''' <param name="disableFlag2"></param>
        ''' <param name="tabIndex"></param>
        ''' <param name="codeValue"></param>
        ''' <param name="nameValue"></param>
        ''' <returns></returns>
        Public Shared Function TPLCustomer(name1 As String, name2 As String, codeWidth As Integer, nameWidth As Integer,
                                          customerType As String, disableFlag1 As Boolean, disableFlag2 As Boolean,
                                          tabIndex As Integer, codeValue As String, nameValue As String, Optional id1 As String = "") As MvcHtmlString
            Dim container = New TagBuilder("div")
            container.Attributes.Add("style", "display: flex")
            Dim codeInput = New TagBuilder("input")
            codeInput.AddCssClass("form-control form-control-sm customer-code mr-0 only-half-size ")
            codeInput.MergeAttribute("value", codeValue)
            codeInput.Attributes.Add("name", name1)
            If String.IsNullOrEmpty(id1) Then
                codeInput.Attributes.Add("id", name1)
            Else
                codeInput.Attributes.Add("id", id1)
            End If
            codeInput.Attributes.Add("style", "width:" + codeWidth.ToString() + "px")
            codeInput.Attributes.Add("TabIndex", tabIndex)
            codeInput.Attributes.Add("maxlength", 8)
            codeInput.Attributes.Add("data-customer-type", customerType)
            If disableFlag1 = True Then
                codeInput.Attributes.Add("disabled", "disabled")
            End If
            If String.IsNullOrEmpty(codeValue) Then
                nameValue = String.Empty
            End If
            Dim nameInput = New TagBuilder("input")
            nameInput.AddCssClass("form-control form-control-sm customer-name ml-0 ")
            nameInput.MergeAttribute("value", nameValue)
            nameInput.Attributes.Add("name", name2)
            nameInput.Attributes.Add("style", "width:" + nameWidth.ToString() + "px")
            nameInput.Attributes.Add("maxlength", 30)
            If disableFlag2 = True Then
                nameInput.Attributes.Add("disabled", "disabled")
            Else
                nameInput.Attributes.Add("TabIndex", tabIndex + 1)
            End If

            container.InnerHtml = codeInput.ToString() + nameInput.ToString()
            Return New MvcHtmlString(container.ToString())
        End Function

        ''' <summary>
        ''' 受注番号
        ''' </summary>
        ''' <param name="name1"></param>
        ''' <param name="name2"></param>
        ''' <param name="codeWidth"></param>
        ''' <param name="nameWidth"></param>
        ''' <param name="disableFlag"></param>
        ''' <param name="tabIndex"></param>
        ''' <param name="codeValue"></param>
        ''' <param name="nameValue"></param>
        ''' <returns></returns>
        Public Shared Function TPLOrderNo(name1 As String, name2 As String, codeWidth As Integer, nameWidth As Integer, disableFlag As Boolean,
                                          tabIndex As Integer, codeValue As String, nameValue As String, Optional id1 As String = "") As MvcHtmlString
            Dim container = New TagBuilder("div")
            container.Attributes.Add("style", "display: flex")
            Dim codeInput = New TagBuilder("input")
            codeInput.AddCssClass("form-control form-control-sm order-no mr-0 only-half-size ")
            codeInput.MergeAttribute("value", codeValue)
            codeInput.Attributes.Add("name", name1)
            If String.IsNullOrEmpty(id1) Then
                codeInput.Attributes.Add("id", name1)
            Else
                codeInput.Attributes.Add("id", id1)
            End If
            codeInput.Attributes.Add("style", "width:" + codeWidth.ToString() + "px")
            codeInput.Attributes.Add("TabIndex", tabIndex)
            codeInput.Attributes.Add("maxlength", 8)

            If disableFlag = True Then
                codeInput.Attributes.Add("disabled", "disabled")
            End If
            If String.IsNullOrEmpty(codeValue) Then
                nameValue = String.Empty
            End If
            Dim nameInput = New TagBuilder("input")
            nameInput.AddCssClass("form-control form-control-sm order-name ml-0 ")
            nameInput.MergeAttribute("value", nameValue)
            nameInput.Attributes.Add("name", name2)
            nameInput.Attributes.Add("style", "width:" + nameWidth.ToString() + "px")
            nameInput.Attributes.Add("maxlength", 30)
            nameInput.Attributes.Add("disabled", "disabled")

            container.InnerHtml = codeInput.ToString() + nameInput.ToString()
            Return New MvcHtmlString(container.ToString())
        End Function

        ''' <summary>
        ''' 担当
        ''' </summary>
        ''' <param name="name1"></param>
        ''' <param name="name2"></param>
        ''' <param name="codeWidth"></param>
        ''' <param name="nameWidth"></param>
        ''' <param name="tabIndex"></param>
        ''' <param name="codeValue"></param>
        ''' <param name="nameValue"></param>
        ''' <returns></returns>
        Public Shared Function TPLPerson(name1 As String, name2 As String, codeWidth As Integer, nameWidth As Integer,
                                  tabIndex As Integer, codeValue As String, nameValue As String, Optional id1 As String = "") As MvcHtmlString
            Dim container = New TagBuilder("div")
            container.Attributes.Add("style", "display: flex")
            Dim codeInput = New TagBuilder("input")
            codeInput.AddCssClass("form-control form-control-sm person-code mr-0 only-half-size ")
            codeInput.MergeAttribute("value", codeValue)
            codeInput.Attributes.Add("name", name1)
            If String.IsNullOrEmpty(id1) Then
                codeInput.Attributes.Add("id", name1)
            Else
                codeInput.Attributes.Add("id", id1)
            End If
            codeInput.Attributes.Add("style", "width:" + codeWidth.ToString() + "px")
            codeInput.Attributes.Add("TabIndex", tabIndex)
            codeInput.Attributes.Add("maxlength", 6)

            If String.IsNullOrEmpty(codeValue) Then
                nameValue = String.Empty
            End If
            Dim nameInput = New TagBuilder("input")
            nameInput.AddCssClass("form-control form-control-sm person-name ml-0 ")
            nameInput.MergeAttribute("value", nameValue)
            nameInput.Attributes.Add("name", name2)
            nameInput.Attributes.Add("style", "width:" + nameWidth.ToString() + "px")
            nameInput.Attributes.Add("maxlength", 10)
            nameInput.Attributes.Add("disabled", "disabled")

            container.InnerHtml = codeInput.ToString() + nameInput.ToString()
            Return New MvcHtmlString(container.ToString())
        End Function

        ''' <summary>
        ''' 担当部署
        ''' </summary>
        ''' <param name="name1"></param>
        ''' <param name="name2"></param>
        ''' <param name="name3"></param>
        ''' <param name="name4"></param>
        ''' <param name="codeWidth"></param>
        ''' <param name="nameWidth1"></param>
        ''' <param name="nameWidth2"></param>
        ''' <param name="tabIndex"></param>
        ''' <param name="codeValue"></param>
        ''' <param name="nameValue1"></param>
        ''' <param name="nameValue2"></param>
        ''' <param name="nameValue3"></param>
        ''' <returns></returns>
        Public Shared Function TPLDepartment(name1 As String, name2 As String, name3 As String, name4 As String, codeWidth As Integer,
                                             nameWidth1 As Integer, nameWidth2 As Integer, tabIndex As Integer,
                                             codeValue As String, nameValue1 As String, nameValue2 As String, nameValue3 As String,
                                             Optional id1 As String = "") As MvcHtmlString
            Dim container = New TagBuilder("div")
            container.Attributes.Add("style", "display: flex")
            Dim codeInput = New TagBuilder("input")
            codeInput.AddCssClass("form-control form-control-sm pic-code mr-0 only-half-size ")
            codeInput.MergeAttribute("value", codeValue)
            codeInput.Attributes.Add("name", name1)
            If String.IsNullOrEmpty(id1) Then
                codeInput.Attributes.Add("id", name1)
            Else
                codeInput.Attributes.Add("id", id1)
            End If
            codeInput.Attributes.Add("style", "width:" + codeWidth.ToString() + "px")
            codeInput.Attributes.Add("TabIndex", tabIndex)
            codeInput.Attributes.Add("maxlength", 6)

            If String.IsNullOrEmpty(codeValue) Then
                nameValue1 = String.Empty
                nameValue2 = String.Empty
                nameValue3 = String.Empty
            End If
            Dim nameInput1 = New TagBuilder("input")
            nameInput1.AddCssClass("form-control form-control-sm department-name ml-0 ")
            nameInput1.MergeAttribute("value", nameValue1)
            nameInput1.Attributes.Add("name", name2)
            nameInput1.Attributes.Add("style", "width:" + nameWidth1.ToString() + "px")
            nameInput1.Attributes.Add("maxlength", 10)
            nameInput1.Attributes.Add("disabled", "disabled")

            Dim nameInput2 = New TagBuilder("input")
            nameInput2.AddCssClass("form-control form-control-sm pic-name ml-0 ")
            nameInput2.MergeAttribute("value", nameValue2)
            nameInput2.Attributes.Add("name", name3)
            nameInput2.Attributes.Add("style", "width:" + nameWidth2.ToString() + "px")
            nameInput2.Attributes.Add("maxlength", 10)
            nameInput2.Attributes.Add("disabled", "disabled")

            Dim deptHidden = New TagBuilder("input")
            deptHidden.AddCssClass("form-control form-control-sm department-code ")
            deptHidden.MergeAttribute("value", nameValue3)
            deptHidden.Attributes.Add("name", name4)
            deptHidden.MergeAttribute("type", "hidden")

            container.InnerHtml = codeInput.ToString() + nameInput1.ToString() + nameInput2.ToString() + deptHidden.ToString()
            Return New MvcHtmlString(container.ToString())
        End Function

        ''' <summary>
        ''' 用紙
        ''' </summary>
        ''' <param name="name1"></param>
        ''' <param name="name2"></param>
        ''' <param name="codeWidth"></param>
        ''' <param name="nameWidth"></param>
        ''' <param name="disableFlag1"></param>
        ''' <param name="disableFlag2"></param>
        ''' <param name="tabIndex"></param>
        ''' <param name="codeValue"></param>
        ''' <param name="nameValue"></param>
        ''' <returns></returns>
        Public Shared Function TPLPaper(name1 As String, name2 As String, codeWidth As Integer, nameWidth As Integer,
                                  disableFlag1 As Boolean, disableFlag2 As Boolean,
                                  tabIndex As Integer, codeValue As String, nameValue As String, Optional id1 As String = "") As MvcHtmlString
            Dim container = New TagBuilder("div")
            container.Attributes.Add("style", "display: flex")
            Dim codeInput = New TagBuilder("input")
            codeInput.AddCssClass("form-control form-control-sm paper-code mr-0 only-half-size ")
            codeInput.MergeAttribute("value", codeValue)
            codeInput.Attributes.Add("name", name1)
            If String.IsNullOrEmpty(id1) Then
                codeInput.Attributes.Add("id", name1)
            Else
                codeInput.Attributes.Add("id", id1)
            End If
            codeInput.Attributes.Add("style", "width:" + codeWidth.ToString() + "px")
            codeInput.Attributes.Add("TabIndex", tabIndex)
            codeInput.Attributes.Add("maxlength", 8)
            If disableFlag1 = True Then
                codeInput.Attributes.Add("disabled", "disabled")
            End If
            If String.IsNullOrEmpty(codeValue) Then
                nameValue = String.Empty
            End If
            Dim nameInput = New TagBuilder("input")
            nameInput.AddCssClass("form-control form-control-sm paper-name ml-0 ")
            nameInput.MergeAttribute("value", nameValue)
            nameInput.Attributes.Add("name", name2)
            nameInput.Attributes.Add("style", "width:" + nameWidth.ToString() + "px")
            nameInput.Attributes.Add("maxlength", 30)
            If disableFlag2 = True Then
                nameInput.Attributes.Add("disabled", "disabled")
            End If

            container.InnerHtml = codeInput.ToString() + nameInput.ToString()
            Return New MvcHtmlString(container.ToString())
        End Function

        ''' <summary>
        ''' Custom 用紙 for grid
        ''' </summary>
        ''' <param name="name1"></param>
        ''' <param name="codeWidth"></param>
        ''' <param name="disableFlag1"></param>
        ''' <param name="tabIndex"></param>
        ''' <param name="codeValue"></param>
        ''' <param name="classField"></param>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Shared Function TPLPaperForGrid(name1 As String, codeWidth As Integer, disableFlag1 As Boolean, tabIndex As Integer,
                                               codeValue As String, classField As String, Optional id As String = "") As MvcHtmlString
            Dim container = New TagBuilder("div")
            container.Attributes.Add("style", "display: flex")
            Dim codeInput = New TagBuilder("input")
            codeInput.AddCssClass("form-control form-control-sm grid-paper-code mr-0 only-half-size " + classField + " ")
            codeInput.MergeAttribute("value", codeValue)
            codeInput.Attributes.Add("name", name1)
            codeInput.Attributes.Add("id", id)
            codeInput.Attributes.Add("style", "width:" + codeWidth.ToString() + "px")
            codeInput.Attributes.Add("TabIndex", tabIndex)
            codeInput.Attributes.Add("maxlength", 8)
            If disableFlag1 = True Then
                codeInput.Attributes.Add("disabled", "disabled")
            End If
            container.InnerHtml = codeInput.ToString()
            Return New MvcHtmlString(container.ToString())
        End Function

    End Class
End Namespace