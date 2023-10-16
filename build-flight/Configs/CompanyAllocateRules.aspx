<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CompanyAllocateRules.aspx.cs" Inherits="Configs_CompanyAllocateRules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <script type="text/javascript">

        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "Companies") {
                ClientCompaniesGrid.SetHeight(e.pane.GetClientHeight());
            }
            else if (e.pane.name == "AllocateRules") {
                ClientAllocateRulesGrid.SetHeight(e.pane.GetClientHeight());
            }
        }

        function ClientCompaniesGrid_FocusedNodeChanged(s, e) {
            var key = s.GetFocusedNodeKey();
            DoCallback(ClientAllocateRulesGrid, function () {
                ClientAllocateRulesGrid.PerformCallback('Refresh|' + key);
            });
        }

        function ClientAddActivity_Click(s, e) {
            ClientActivityListPopup.Show();
        }

        function ClientRemoveActivity_Click(s, e) {
            if (!ClientAllocateRulesGrid.IsDataRow(ClientAllocateRulesGrid.GetFocusedRowIndex()))
                return;
            var cf = confirm("<%= GetMessage("MSG-0015") %>");
            if (cf) {
                var key = ClientAllocateRulesGrid.GetRowKey(ClientAllocateRulesGrid.GetFocusedRowIndex());
                DoCallback(ClientAllocateRulesGrid, function () {
                    ClientAllocateRulesGrid.PerformCallback('Remove|' + key);
                });
            }
        }

        function ClientActivityListPopup_Shown(s, e) {
            var key = ClientCompaniesGrid.GetFocusedNodeKey();
            DoCallback(ClientActivityGrid, function () {
                ClientActivityGrid.PerformCallback('Refresh|' + key);
            });
        }

        function ClientActivityListPopup_Closing(s, e) {
            var key = ClientCompaniesGrid.GetFocusedNodeKey();
            DoCallback(ClientAllocateRulesGrid, function () {
                ClientAllocateRulesGrid.PerformCallback('Refresh|' + key);
            });
        }

        function ClientApplyButton_Click(s, e) {
            var key = ClientCompaniesGrid.GetFocusedNodeKey();
            DoCallback(ClientActivityGrid, function () {
                ClientActivityGrid.PerformCallback('Apply|' + key);
            });
        }

        function ClientAllocateRulesGrid_CustomButtonClick(s, e) {
            if (e.buttonID == "Edit") {
                ClientActivityEditor.SetValue(null);
                ClientAllocateKEditor.SetValue("");
                ClientStaffEditor.SetValue("");
                ClientSalaryEditor.SetValue("");
                ClientCostEditor.SetValue("");
                ClientRevenueEditor.SetValue("");
                ClientOption1Editor.SetValue("");
                ClientOption2Editor.SetValue("");
                ClientOption3Editor.SetValue("");

                if (!ClientAllocateRulesGrid.IsDataRow(ClientAllocateRulesGrid.GetFocusedRowIndex()))
                    return;
                var key = ClientAllocateRulesGrid.GetRowKey(ClientAllocateRulesGrid.GetFocusedRowIndex());
                ChangeState("EditForm", e.buttonID, key);
                ClientAllocateRulesGrid.GetValuesOnCustomCallback("EditForm|" + e.buttonID + "|" + key, function (values) {
                    var setValuesFunc = function () {
                        HideLoadingPanel();
                        if (!values)
                            return;

                        ClientActivityEditor.SetValue(values["ActivityID"]);
                        ClientAllocateKEditor.SetValue(values["AllocateK"]);
                        ClientStaffEditor.SetValue(values["Staff"]);
                        ClientSalaryEditor.SetValue(values["Salary"]);
                        ClientCostEditor.SetValue(values["Cost"]);
                        ClientRevenueEditor.SetValue(values["Revenue"]);
                        ClientOption1Editor.SetValue(values["Option1"]);
                        ClientOption2Editor.SetValue(values["Option2"]);
                        ClientOption3Editor.SetValue(values["Option3"]);

                        ClientActivityEditor.Focus();
                        ClientEditPopupControl.Show();
                    };
                    PostponeAction(setValuesFunc, function () { return !!window.ClientActivityEditor });
                });
                ShowLoadingPanel(ClientSplitter.GetMainElement());
            }
            else if (e.buttonID == "Delete") {
                ClientRemoveActivity_Click(null, null);
            }
        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientActivityEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
                return;

            var state = State;
            var args = "SaveForm|" + state.Command + "|" + state.Key;
            ChangeState("SaveForm", state.Command, state.Key);
            DoCallback(ClientAllocateRulesGrid, function () {
                ClientAllocateRulesGrid.PerformCallback(args);
            });
        }

        function ClientAllocateRulesGrid_EndCallback(s, e) {
            var state = State;
            if (state.View == "SaveForm" && (state.Command == "New" || state.Command == "Edit")) {
                if (s.cpResult == "Success") {
                    ClientEditPopupControl.Hide();
                    ChangeState("List", "", "");
                }
                else {
                    alert(s.cpResult);
                }
            }
        }

        function ClientEditPopupControl_Closing(s, e) {
            ChangeState("List", "", "");
        }

    </script>

    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div class="title">
                            <asp:Literal ID="Literal1" runat="server" Text="Company Allocate Rules" />
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle>
                    <BorderTop BorderWidth="0px" />
                    <BorderLeft BorderWidth="0px" />
                    <BorderRight BorderWidth="0px" />
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Separator-Visible="False">
                <PaneStyle>
                    <BorderBottom BorderWidth="0px" />
                    <BorderLeft BorderWidth="0px" />
                    <BorderRight BorderWidth="0px" />
                </PaneStyle>
                <Panes>
                    <dx:SplitterPane Name="Companies" Size="400">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxTreeList ID="CompaniesGrid" runat="server" Width="100%" ClientInstanceName="ClientCompaniesGrid"
                                    KeyFieldName="CompanyID" ParentFieldName="ParentID"
                                    OnHtmlRowPrepared="CompaniesGrid_HtmlRowPrepared">
                                    <Columns>
                                        <dx:TreeListTextColumn FieldName="ShortName" VisibleIndex="1" Caption="Short Name" Width="90" CellStyle-Wrap="True"></dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="NameV" VisibleIndex="3" Caption="Name"></dx:TreeListTextColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingNode Enabled="True"></AlternatingNode>
                                    </Styles>
                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" ScrollableHeight="500" />
                                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="ShortName;NameV" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="1px" />
                                    <SettingsBehavior AllowFocusedNode="true" />
                                    <SettingsResizing ColumnResizeMode="NextColumn" />
                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                                    <ClientSideEvents FocusedNodeChanged="ClientCompaniesGrid_FocusedNodeChanged" />
                                </dx:ASPxTreeList>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0">
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                        </PaneStyle>
                    </dx:SplitterPane>
                    <dx:SplitterPane Name="AllocateRules">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxGridView ID="AllocateRulesGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                    ClientInstanceName="ClientAllocateRulesGrid" Width="100%" KeyFieldName="CompanyAllocatedRuleID"
                                    OnCustomCallback="AllocateRulesGrid_CustomCallback"
                                    OnCustomDataCallback="AllocateRulesGrid_CustomDataCallback"
                                    OnHtmlRowPrepared="AllocateRulesGrid_HtmlRowPrepared">
                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="150">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="Edit" Text="Edit" Image-Url="../Content/images/action/edit.gif"></dx:GridViewCommandColumnCustomButton>
                                                <dx:GridViewCommandColumnCustomButton ID="Delete" Text="Delete" Image-Url="../Content/images/action/delete.gif"></dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="1" Caption="Description" Width="300" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="AllocateK" VisibleIndex="2" Caption="Allocate K" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Staff" VisibleIndex="3" Caption="Staff" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Salary" VisibleIndex="4" Caption="Salary" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Cost" VisibleIndex="6" Caption="Cost" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Revenue" VisibleIndex="7" Caption="Revenue" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Option1" VisibleIndex="8" Caption="Option 1" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Option2" VisibleIndex="9" Caption="Option 2" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Option3" VisibleIndex="10" Caption="Option 3" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingRow Enabled="true" />
                                        <CommandColumn Spacing="10px" Wrap="False" />
                                    </Styles>
                                    <Settings ShowStatusBar="Visible" ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="Description" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="1px" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                    <Templates>
                                        <StatusBar>
                                            <dx:ASPxButton ID="btnAddActivity" runat="server" Text="Add Activity" RenderMode="Button" AutoPostBack="false" Image-Url="~/Content/images/action/add.gif">
                                                <ClientSideEvents Click="ClientAddActivity_Click" />
                                            </dx:ASPxButton>
                                            &nbsp;&nbsp;                                                                                                          
                                    <dx:ASPxButton ID="btnRemoveActivity" runat="server" Text="Remove Activity" RenderMode="Button" AutoPostBack="false" Image-Url="~/Content/images/action/reject.png">
                                        <ClientSideEvents Click="ClientRemoveActivity_Click" />
                                    </dx:ASPxButton>
                                        </StatusBar>
                                    </Templates>
                                    <ClientSideEvents CustomButtonClick="ClientAllocateRulesGrid_CustomButtonClick"
                                        EndCallback="ClientAllocateRulesGrid_EndCallback" />
                                </dx:ASPxGridView>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0">
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                        </PaneStyle>
                    </dx:SplitterPane>
                </Panes>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>


    <dx:ASPxPopupControl ID="ActivityListPopup" runat="server" Width="400" Height="400" AllowDragging="True" HeaderText="Add Activity" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientActivityListPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="ActivityGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientActivityGrid" Width="100%" KeyFieldName="ActivityID"
                    OnCustomCallback="ActivityGrid_CustomCallback"
                    OnHtmlRowPrepared="ActivityGrid_HtmlRowPrepared">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Seq" VisibleIndex="1" Caption="Seq" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Sorting" VisibleIndex="2" Caption="Sort" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ActivityName" VisibleIndex="3" Caption="Activity Name" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn VisibleIndex="4" Width="35" ShowSelectCheckbox="true" ShowClearFilterButton="true" SelectAllCheckboxMode="AllPages"></dx:GridViewCommandColumn>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="true" />
                    </Styles>
                    <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="400" VerticalScrollBarStyle="Standard" />
                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="ShortName;NameV" />
                    <Paddings Padding="0px" />
                    <Border BorderWidth="0px" BorderStyle="None" />
                    <BorderBottom BorderWidth="1px" />
                    <SettingsBehavior AllowFocusedRow="True" />
                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Cancel" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ClientActivityGrid.UnselectRows(); ClientActivityListPopup.Hide(); }}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Apply" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientApplyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="ClientActivityListPopup_Shown" Closing="ClientActivityListPopup_Closing" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="350" Height="200" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Activity">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="ActivityEditor" Width="255" ReadOnly="true" ClientInstanceName="ClientActivityEditor" OnInit="ActivityEditor_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Activity is required" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Allocate K">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="AllocateKEditor" Width="170" ClientInstanceName="ClientAllocateKEditor">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Staff">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="StaffEditor" Width="170" ClientInstanceName="ClientStaffEditor">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Salary">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="SalaryEditor" Width="170" ClientInstanceName="ClientSalaryEditor">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Cost">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="CostEditor" Width="170" ClientInstanceName="ClientCostEditor">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Revenue">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="RevenueEditor" Width="170" ClientInstanceName="ClientRevenueEditor">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Option 1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="Option1Editor" Width="170" ClientInstanceName="ClientOption1Editor">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Option 2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="Option2Editor" Width="170" ClientInstanceName="ClientOption2Editor">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Option 3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="Option3Editor" Width="170" ClientInstanceName="ClientOption3Editor">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                    <Styles>
                        <LayoutGroupBox>
                            <Caption CssClass="layoutGroupBoxCaption"></Caption>
                        </LayoutGroupBox>
                    </Styles>
                </dx:ASPxFormLayout>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Close" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ASPxClientEdit.ClearEditorsInContainerById('EditForm'); ClientEditPopupControl.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnSave" runat="server" Text="Save" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientSaveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Closing="ClientEditPopupControl_Closing" />
    </dx:ASPxPopupControl>
</asp:Content>

