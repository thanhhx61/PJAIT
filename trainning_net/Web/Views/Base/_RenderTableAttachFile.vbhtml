@ModelType Web.Models.AttachFileViewModel
@Imports Core.ConstantCore
@code
    Dim i As Int16 = 0
End Code
<style>
    .scroll-body {
        height: 450px;
        overflow-y: auto;
    }

 </style>
<div Class="modal-dialog modal-lg" role="document">
    <div Class="modal-content">
        <div Class="modal-header">
           <div class="content-header bg-secondary w-100 pl-2 pr-2 pt-1 pb-1 navbar">
            <span><b>Attachment File</b></span>
                <div class="login-info">
                    <span> LoginID : @Model.EmpName</span>
                    <span id="timeDate">Date :  @DateTime.Now.ToString(Core.ConstantCore.DateFormat.DATETIMEFULL)</span>
                </div>
           </div>
        </div>
        <div Class="modal-body scroll-body">
            <div class="table-file">
                <Table id="tbFile" Class="table table-striped table-bordered fmodal-scroll">
                    <thead Class="thead-light">
                        <tr>
                            <th class="w-75">Attachment File</th>
                            @If Model.ProcessMode = ProcessModel.EDIT Then
                                @<th Class="w-25">Delete File</th>
                            End If
                        </tr>
                    </thead>
                    <tbody>
                        @For Each item In Model.AttachFileLst
                            @<tr class="file-server" id="row-item-file-@item.AttachID.ToString()">
                                <td><a href="#" onclick="downloadFileAttach(@item.AttachID)">@(item.AttachFileName + " (" + item.AttachFileSize.ToString() + " KB)")</a></td>
                                @If ProcessModel.EDIT.Equals(Model.ProcessMode) Then
                                    @<td>
                                        <a onclick="deleteFileItem(@item.AttachID)" Class="file-delete" href="#" index="@i.ToString()">Delete</a>
                                    </td>
                                End If
                                @Html.HiddenFor(Function(m) m.AttachFileLst.Item(i).AttachID)
                                @Html.HiddenFor(Function(m) m.AttachFileLst.Item(i).AttachMangID)
                                @Html.HiddenFor(Function(m) m.AttachFileLst.Item(i).AttachFolderPath)
                                @Html.HiddenFor(Function(m) m.AttachFileLst.Item(i).AttachFileName)
                                @Html.HiddenFor(Function(m) m.AttachFileLst.Item(i).AttachFileSize)
                                @code
                                    i += 1
                                End Code
                            </tr>
                                    Next item
                    </tbody>
                </Table>
            </div>
        </div>
        <div Class="modal-footer">
            <Button type="button" Class="btn btn-sm btn-secondary pt-1 pb-1 btn-show-all-file" data-dismiss="modal">Close</Button>
        </div>
    </div>
</div>