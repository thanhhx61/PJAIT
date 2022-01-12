@Imports Web.Models
@code
    Dim model = CType(ViewBag.LayoutBaseModel, LayoutBaseViewModel)
End Code
@Section Scripts
    <script src="~/Scripts/common/index.js" type="text/javascript"></script>
End Section
 <style>
    .msg-btn {
         width: 88px;
         height: 32px;
         padding-bottom: 5px;
     }
 </style>
@If model IsNot Nothing Then
    @<input type="hidden" value="@model.IsMessage" id="isMessage" />
    @<input type="hidden" value="@model.Focus" id="focusName" />
    @<div id="message_Info">
    <div id="myModal_info" Class="modal" tabindex="-1" role="dialog">
        <div Class="modal-dialog modal-dialog-centered" role="document">
            <div Class="modal-content">
                <div Class="modal-header">
                    <h5 Class="modal-title">Message</h5>
                    <Button type="button" Class="close" data-dismiss="modal" aria-label="Close">
                        <Span aria-hidden="true">&times;</Span>
                    </Button>
                </div>
                <div Class="modal-body">
                    <p id="content-message-info">
                        @Html.Raw(model.Message)
                    </p>
                </div>
                <div Class="modal-footer">
                    <button type="button" Class="btn btn-sm btn-secondary btn-close msg-btn " id="message_Info_close" data-dismiss="modal">Ok</button>
                </div>
            </div>
        </div>
    </div>
</div>
    @<div id="message_Question">
    <div id="myModal_question" Class="modal" tabindex="-1" role="dialog">
        <div Class="modal-dialog modal-dialog-centered" role="document">
            <div Class="modal-content">
                <div Class="modal-header">
                    <h5 Class="modal-title">Message</h5>
                    <Button type="button" Class="close close-modal-confirm" data-dismiss="modal" aria-label="Close">
                        <Span aria-hidden="true">&times;</Span>
                    </Button>
                </div>
                <div Class="modal-body">
                    <p id="content-message-question">
                        @model.Message
                    </p>
                </div>
                <div Class="modal-footer">
                    <button type="button" Class="btn btn-sm btn-primary btn-ok msg-btn" data-dismiss="modal">Ok</button>
                    <button type="button" Class="btn btn-sm btn-secondary btn-cancel msg-btn" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>
</div>
End If