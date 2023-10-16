<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="Account_UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script type="text/javascript">
        var PendingJobs = {};

        function ExecCallback(sender, callback) {
            if (sender.InCallback()) {
                PendingJobs[sender.name] = callback;
                sender.EndCallback.RemoveHandler(ExecEndCallback);
                sender.EndCallback.AddHandler(ExecEndCallback);
            } else {
                callback();
            }
        }

        function ExecEndCallback(s, e) {
            var pendingCallback = PendingJobs[s.name];
            if (pendingCallback) {
                pendingCallback();
                delete PendingJobs[s.name];
            }
        }

        function ClientUpdateUserProfile_Click(s, e) {
            var args = "SAVE";
            ExecCallback(ClientSettingsPanel, function () {
                ClientSettingsPanel.PerformCallback(args);
            });
        }


    </script>
    <dx:ASPxCallbackPanel ID="SettingsPanel" runat="server" RenderMode="Div" Height="100%" CssClass="MailPreviewPanel" ClientInstanceName="ClientSettingsPanel"
        OnCallback="SettingsPanel_Callback">
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="800px" RequiredMarkDisplayMode="None" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="editUserFormLayout"
                    AlignItemCaptionsInAllGroups="true" ColCount="2">
                    <Items>
                        <dx:LayoutItem ShowCaption="False" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxLabel ID="FormTitleLabel" runat="server" Text="Edit User Profile" Font-Size="Large" Font-Bold="true" ForeColor="BlueViolet" />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:EmptyLayoutItem ColSpan="2"></dx:EmptyLayoutItem>
                        <dx:LayoutItem Caption="First Name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="FirstNameEditor" runat="server" Width="200px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Title">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="TitleEditor" runat="server" Width="200px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Middle Name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="MiddleNameEditor" runat="server" Width="200px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Telephone">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="TelephoneEditor" runat="server" Width="200px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Last Name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="LastNameEditor" runat="server" Width="200px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Organization">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="OrganizationEditor" runat="server" Width="200px"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="E-Mail Signature" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxHtmlEditor ID="EmailSignatureEditor" runat="server" ClientInstanceName="ClientEmailSignatureEditor" Width="100%" Height="350">
                                        <Settings AllowContextMenu="True" />
                                        <SettingsHtmlEditing EnterMode="BR" AllowScripts="false" AllowIFrames="false" />
                                        <CssFiles>
                                            <dx:HtmlEditorCssFile FilePath="../Content/HtmlEditor.css" />
                                        </CssFiles>
                                        <Toolbars>
                                            <dx:HtmlEditorToolbar>
                                                <Items>
                                                    <dx:ToolbarCutButton></dx:ToolbarCutButton>
                                                    <dx:ToolbarCopyButton></dx:ToolbarCopyButton>
                                                    <dx:ToolbarPasteButton></dx:ToolbarPasteButton>
                                                    <dx:ToolbarPasteFromWordButton>
                                                    </dx:ToolbarPasteFromWordButton>
                                                    <dx:ToolbarUndoButton BeginGroup="true"></dx:ToolbarUndoButton>
                                                    <dx:ToolbarRedoButton></dx:ToolbarRedoButton>
                                                    <dx:ToolbarRemoveFormatButton BeginGroup="true"></dx:ToolbarRemoveFormatButton>
                                                    <dx:ToolbarSuperscriptButton BeginGroup="true">
                                                    </dx:ToolbarSuperscriptButton>
                                                    <dx:ToolbarSuperscriptButton></dx:ToolbarSuperscriptButton>
                                                    <dx:ToolbarInsertOrderedListButton BeginGroup="True">
                                                    </dx:ToolbarInsertOrderedListButton>
                                                    <dx:ToolbarInsertUnorderedListButton>
                                                    </dx:ToolbarInsertUnorderedListButton>
                                                    <dx:ToolbarIndentButton BeginGroup="true">
                                                    </dx:ToolbarIndentButton>
                                                    <dx:ToolbarOutdentButton>
                                                    </dx:ToolbarOutdentButton>
                                                    <dx:ToolbarInsertLinkDialogButton BeginGroup="true"></dx:ToolbarInsertLinkDialogButton>
                                                    <dx:ToolbarUnlinkButton></dx:ToolbarUnlinkButton>
                                                    <dx:ToolbarInsertImageDialogButton>
                                                    </dx:ToolbarInsertImageDialogButton>
                                                    <dx:ToolbarTableOperationsDropDownButton BeginGroup="true">
                                                        <Items>
                                                            <dx:ToolbarInsertTableDialogButton BeginGroup="True">
                                                            </dx:ToolbarInsertTableDialogButton>
                                                            <dx:ToolbarTablePropertiesDialogButton BeginGroup="True">
                                                            </dx:ToolbarTablePropertiesDialogButton>
                                                            <dx:ToolbarTableRowPropertiesDialogButton>
                                                            </dx:ToolbarTableRowPropertiesDialogButton>
                                                            <dx:ToolbarTableColumnPropertiesDialogButton>
                                                            </dx:ToolbarTableColumnPropertiesDialogButton>
                                                            <dx:ToolbarTableCellPropertiesDialogButton>
                                                            </dx:ToolbarTableCellPropertiesDialogButton>
                                                            <dx:ToolbarInsertTableRowAboveButton BeginGroup="True">
                                                            </dx:ToolbarInsertTableRowAboveButton>
                                                            <dx:ToolbarInsertTableRowBelowButton>
                                                            </dx:ToolbarInsertTableRowBelowButton>
                                                            <dx:ToolbarInsertTableColumnToLeftButton>
                                                            </dx:ToolbarInsertTableColumnToLeftButton>
                                                            <dx:ToolbarInsertTableColumnToRightButton>
                                                            </dx:ToolbarInsertTableColumnToRightButton>
                                                            <dx:ToolbarSplitTableCellHorizontallyButton BeginGroup="True">
                                                            </dx:ToolbarSplitTableCellHorizontallyButton>
                                                            <dx:ToolbarSplitTableCellVerticallyButton>
                                                            </dx:ToolbarSplitTableCellVerticallyButton>
                                                            <dx:ToolbarMergeTableCellRightButton>
                                                            </dx:ToolbarMergeTableCellRightButton>
                                                            <dx:ToolbarMergeTableCellDownButton>
                                                            </dx:ToolbarMergeTableCellDownButton>
                                                            <dx:ToolbarDeleteTableButton BeginGroup="True">
                                                            </dx:ToolbarDeleteTableButton>
                                                            <dx:ToolbarDeleteTableRowButton>
                                                            </dx:ToolbarDeleteTableRowButton>
                                                            <dx:ToolbarDeleteTableColumnButton>
                                                            </dx:ToolbarDeleteTableColumnButton>
                                                        </Items>
                                                    </dx:ToolbarTableOperationsDropDownButton>
                                                    <dx:ToolbarFindAndReplaceDialogButton BeginGroup="true"></dx:ToolbarFindAndReplaceDialogButton>
                                                    <dx:ToolbarFullscreenButton BeginGroup="True">
                                                    </dx:ToolbarFullscreenButton>
                                                </Items>
                                            </dx:HtmlEditorToolbar>
                                            <dx:HtmlEditorToolbar>
                                                <Items>
                                                    <dx:ToolbarFontNameEdit>
                                                        <Items>
                                                            <dx:ToolbarListEditItem Text="Times New Roman" Value="Times New Roman" Selected="True" />
                                                            <dx:ToolbarListEditItem Text="Tahoma" Value="Tahoma" />
                                                            <dx:ToolbarListEditItem Text="Verdana" Value="Verdana" />
                                                            <dx:ToolbarListEditItem Text="Arial" Value="Arial" />
                                                            <dx:ToolbarListEditItem Text="Segoe UI" Value="Segoe UI" />
                                                            <dx:ToolbarListEditItem Text="MS Sans Serif" Value="MS Sans Serif" />
                                                            <dx:ToolbarListEditItem Text="Courier" Value="Courier" />
                                                        </Items>
                                                    </dx:ToolbarFontNameEdit>
                                                    <dx:ToolbarFontSizeEdit>
                                                        <Items>
                                                            <dx:ToolbarListEditItem Text="1 (8pt)" Value="1" />
                                                            <dx:ToolbarListEditItem Text="2 (10pt)" Value="2" />
                                                            <dx:ToolbarListEditItem Text="3 (12pt)" Value="3" Selected="true" />
                                                            <dx:ToolbarListEditItem Text="4 (14pt)" Value="4" />
                                                            <dx:ToolbarListEditItem Text="5 (18pt)" Value="5" />
                                                            <dx:ToolbarListEditItem Text="6 (24pt)" Value="6" />
                                                            <dx:ToolbarListEditItem Text="7 (36pt)" Value="7" />
                                                        </Items>
                                                    </dx:ToolbarFontSizeEdit>
                                                    <dx:ToolbarBoldButton BeginGroup="True">
                                                    </dx:ToolbarBoldButton>
                                                    <dx:ToolbarItalicButton>
                                                    </dx:ToolbarItalicButton>
                                                    <dx:ToolbarUnderlineButton>
                                                    </dx:ToolbarUnderlineButton>
                                                    <dx:ToolbarStrikethroughButton></dx:ToolbarStrikethroughButton>
                                                    <dx:ToolbarJustifyLeftButton BeginGroup="true"></dx:ToolbarJustifyLeftButton>
                                                    <dx:ToolbarJustifyCenterButton></dx:ToolbarJustifyCenterButton>
                                                    <dx:ToolbarJustifyRightButton></dx:ToolbarJustifyRightButton>
                                                    <dx:ToolbarBackColorButton BeginGroup="True">
                                                    </dx:ToolbarBackColorButton>
                                                    <dx:ToolbarFontColorButton>
                                                    </dx:ToolbarFontColorButton>
                                                </Items>
                                            </dx:HtmlEditorToolbar>
                                        </Toolbars>
                                    </dx:ASPxHtmlEditor>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption=" " ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="IncludeCheckboxEditor" ClientInstanceName="ClientIncludeCheckboxEditor" runat="server" Checked="true" Text="Automatically include my signature on messages I send"></dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption=" " ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxLabel ID="MessageLabel" runat="server" Font-Size="Large" Font-Bold="true" ForeColor="Blue" />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False" HorizontalAlign="Center" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxButton ID="btnUpdateUserProfile" runat="server" Text="Update" Image-Url="~/Content/images/action/save.png" ClientInstanceName="ClientUpdateUserProfile" AutoPostBack="false" UseSubmitBehavior="true">
                                        <ClientSideEvents Click="ClientUpdateUserProfile_Click" />
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                    <SettingsItemCaptions HorizontalAlign="Right"></SettingsItemCaptions>
                    <Styles>
                        <LayoutGroupBox>
                            <Caption CssClass="layoutGroupBoxCaption"></Caption>
                        </LayoutGroupBox>
                    </Styles>
                </dx:ASPxFormLayout>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
</asp:Content>

