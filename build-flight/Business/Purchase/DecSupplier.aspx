<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DecSupplier.aspx.cs" Inherits="Pages_DecSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../../Scripts/Common.js"></script>
    <script type="text/javascript">

        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "GridPane") {
                ClientDecSupplierGrid.SetHeight(e.pane.GetClientHeight());
            }
        }


        function ClientMenu_ItemClick(e) {
            var name = e.item.name;
            if (name.toUpperCase() == "DELETE") {
                var cf = confirm("<%= GetMessage("MSG-0015") %>");
                if (cf) {
                    if (!ClientDecSupplierGrid.IsDataRow(ClientDecSupplierGrid.GetFocusedRowIndex()))
                        return;
                    var key = ClientDecSupplierGrid.GetRowKey(ClientDecSupplierGrid.GetFocusedRowIndex());
                    DoCallback(ClientDecSupplierGrid, function () {
                        ClientDecSupplierGrid.PerformCallback('DELETE|' + key);
                    });
                }
                e.processOnServer = false;
                return;
            } else if (name.toUpperCase() == "NEW") {
                ChangeState("EditForm", name.toUpperCase(), "");
                ClientEditPopupControl.SetHeaderText("Add New Supplier");
                var state = State;
                ShowEditForm(state.Command, state.Key);
            } else if (name.toUpperCase() == "EDIT") {
                if (!ClientDecSupplierGrid.IsDataRow(ClientDecSupplierGrid.GetFocusedRowIndex()))
                    return;
                var key = ClientDecSupplierGrid.GetRowKey(ClientDecSupplierGrid.GetFocusedRowIndex());
                ChangeState("EditForm", name.toUpperCase(), key);
                ClientEditPopupControl.SetHeaderText("Edit Supplier");
                var state = State;
                ShowEditForm(state.Command, state.Key);
            }
            e.processOnServer = false;
        }

        function ClientDecSupplierGrid_RowDblClick(s, e) {
            if (!ClientDecSupplierGrid.IsDataRow(ClientDecSupplierGrid.GetFocusedRowIndex()))
                return;
            var key = ClientDecSupplierGrid.GetRowKey(ClientDecSupplierGrid.GetFocusedRowIndex());
            ChangeState("EditForm", "EDIT", key);
            ClientEditPopupControl.SetHeaderText("Edit Supplier");
            var state = State;
            ShowEditForm(state.Command, state.Key);
        }

        function ShowEditForm(command, key) {

            ClientSUP_CODEEditor.SetValue("");
            ClientSUP_NAMEEditor.SetValue("");
            ClientSHORT_NAMEEditor.SetValue("");
            ClientDESCRIPTIONEditor.SetValue("");
            ClientADDRESSEditor.SetValue("");
            ClientTELEditor.SetValue("");
            ClientFAXEditor.SetValue("");
            ClientEMAILEditor.SetValue("");
            ClientWEBSITEEditor.SetValue("");

            //ClientActiveEditor.SetValue(false);

            if (command == "NEW") {
                ClientSUP_CODEEditor.GetInputElement().readOnly = false;
                ClientSUP_CODEEditor.Focus();
                ClientEditPopupControl.Show();
            }
            else if (command == "EDIT") {
                //ClientSUP_CODEEditor.GetInputElement().readOnly = true;
                ClientDecSupplierGrid.GetValuesOnCustomCallback("EditForm|" + command + "|" + key, function (values) {
                    var setValuesFunc = function () {
                        HideLoadingPanel();
                        if (!values)
                            return;

                        ClientSUP_CODEEditor.SetValue(values["SUP_CODE"]);
                        ClientSUP_NAMEEditor.SetValue(values["SUP_NAME"]);
                        ClientSHORT_NAMEEditor.SetValue(values["SHORT_NAME"]);
                        ClientDESCRIPTIONEditor.SetValue(values["DESCRIPTION"]);
                        ClientADDRESSEditor.SetValue(values["ADDRESS"]);
                        ClientTELEditor.SetValue(values["TEL"]);
                        ClientFAXEditor.SetValue(values["FAX"]);
                        ClientEMAILEditor.SetValue(values["EMAIL"]);
                        ClientWEBSITEEditor.SetValue(values["WEBSITE"]);

                        //ClientActiveEditor.SetValue(values["Active"] == "TRUE" ? true : false);

                        ClientSUP_CODEEditor.Focus();
                        ClientEditPopupControl.Show();
                    };
                    PostponeAction(setValuesFunc, function () { return !!window.ClientSUP_CODEEditor });
                });
                ShowLoadingPanel(ClientSplitter.GetMainElement());
            }
        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientSUP_CODEEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
                return;

            var state = State;
            var args = "SaveForm|" + state.Command + "|" + state.Key;
            ChangeState("SaveForm", state.Command, state.Key);
            DoCallback(ClientDecSupplierGrid, function () {
                ClientDecSupplierGrid.PerformCallback(args);
            });


        }

        function ClientDecSupplierGrid_EndCallback(s, e) {
            var state = State;
            if (state.View == "SaveForm" && (state.Command == "NEW" || state.Command == "EDIT")) {
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
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Name="Menu" Size="100" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="Declare Supplier" />
                            </div>
                            <dx:ASPxMenu ID="mMain" runat="server" CssClass="main-menu" Theme="Moderno">
                                <ClientSideEvents ItemClick="function(s, e) { ClientMenu_ItemClick(e);}" />
                                <Items>
                                    <dx:MenuItem Name="New" Text="<%$Resources:Language, Add %>" ItemStyle-CssClass="menu-item" Image-Url="../../Content/Images/action/add.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Edit" Text="<%$Resources:Language, Edit %>" ItemStyle-CssClass="menu-item" Image-Url="../../Content/Images/action/edit.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Delete" Text="<%$Resources:Language, Delete %>" ItemStyle-CssClass="menu-item" Image-Url="../../Content/Images/action/delete.gif">
                                    </dx:MenuItem>
                                </Items>
                            </dx:ASPxMenu>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Name="GridPane">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxGridView ID="DecSupplierGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true" OnCustomCallback="DecSupplierGrid_CustomCallback" OnCustomDataCallback="DecSupplierGrid_CustomDataCallback"
                            ClientInstanceName="ClientDecSupplierGrid" Width="100%" KeyFieldName="SUP_CODE">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="SUP_CODE" VisibleIndex="1" Caption="Code" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="SUP_NAME" VisibleIndex="1" Caption="Name" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="SHORT_NAME" VisibleIndex="1" Caption="Short Name" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DESCRIPTION" VisibleIndex="1" Caption="Description" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ADDRESS" VisibleIndex="1" Caption="Address" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="TEL" VisibleIndex="1" Caption="Tel" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="FAX" VisibleIndex="1" Caption="Fax" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="EMAIL" VisibleIndex="1" Caption="Email" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="WEBSITE" VisibleIndex="1" Caption="Website" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <Styles>
                                <AlternatingRow Enabled="true" />
                            </Styles>
                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                            <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="SUP_CODE;SUP_NAME;SHORT_NAME" />
                            <Paddings Padding="0px" />
                            <Border BorderWidth="1px" />
                            <BorderBottom BorderWidth="1px" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                            <ClientSideEvents EndCallback="ClientDecSupplierGrid_EndCallback"
                                RowDblClick="ClientDecSupplierGrid_RowDblClick" />
                        </dx:ASPxGridView>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>



    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="350" Height="200" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Code">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="SUP_CODEEditor" Width="200" AutoResizeWithContainer="true" ClientInstanceName="ClientSUP_CODEEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="SUP_NAMEEditor" Width="200" AutoResizeWithContainer="true" ClientInstanceName="ClientSUP_NAMEEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Short name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="SHORT_NAMEEditor" Width="200" AutoResizeWithContainer="true" ClientInstanceName="ClientSHORT_NAMEEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Description">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="DESCRIPTIONEditor" Width="200" AutoResizeWithContainer="true" ClientInstanceName="ClientDESCRIPTIONEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Address">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ADDRESSEditor" Width="200" AutoResizeWithContainer="true" ClientInstanceName="ClientADDRESSEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Tel">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="TELEditor" Width="200" AutoResizeWithContainer="true" ClientInstanceName="ClientTELEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Fax">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="FAXEditor" Width="200" AutoResizeWithContainer="true" ClientInstanceName="ClientFAXEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Email">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="EMAILEditor" Width="200" AutoResizeWithContainer="true" ClientInstanceName="ClientEMAILEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Website">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="WEBSITEEditor" Width="200" AutoResizeWithContainer="true" ClientInstanceName="ClientWEBSITEEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                       <%-- <dx:LayoutItem Caption="Active">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox runat="server" ID="ActiveEditor" ClientInstanceName="ClientActiveEditor">
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Đóng" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ASPxClientEdit.ClearEditorsInContainerById('EditForm'); ChangeState('List', '', '');  ClientEditPopupControl.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnSave" runat="server" Text="Lưu" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientSaveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Closing="ClientEditPopupControl_Closing" />
    </dx:ASPxPopupControl>
</asp:Content>

