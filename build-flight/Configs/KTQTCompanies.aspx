<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="KTQTCompanies.aspx.cs" Inherits="Pages_KTQTCompanies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <script type="text/javascript">

        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "GridPane") {
                ClientDataGrid.SetHeight(e.pane.GetClientHeight());
            }
        }


        function ClientMenu_ItemClick(e) {
            var name = e.item.name;
            if (name.toUpperCase() == "DELETE") {
                var cf = confirm("<%= GetMessage("MSG-0015") %>");
                if (cf) {
                    var key = ClientDataGrid.GetFocusedNodeKey();
                    DoCallback(ClientDataGrid, function () {
                        ClientDataGrid.PerformCallback('DELETE|' + key);
                    });
                }
                e.processOnServer = false;
                return;
            } else if (name.toUpperCase() == "NEW") {
                ChangeState("EditForm", name.toUpperCase(), "");
                ClientEditPopupControl.SetHeaderText("Thêm mới");
                var state = State;
                ShowEditForm(state.Command, State.Key);
            } else if (name.toUpperCase() == "EDIT") {
                var key = ClientDataGrid.GetFocusedNodeKey();
                ChangeState("EditForm", name.toUpperCase(), key);
                ClientEditPopupControl.SetHeaderText("Cập nhật");
                var state = State;
                ShowEditForm(state.Command, state.Key);
            } else if (name.toUpperCase() == "SYNCDATA") {
                var cf = confirm("Bạn chắc chắn muốn đồng bộ dữ liệu từ PMS không?");
                if (cf) {
                    DoCallback(ClientDataGrid, function () {
                        ClientDataGrid.PerformCallback('SYNC_DATA');
                    });
                }
                e.processOnServer = false;
                return;
            }
            e.processOnServer = false;
        }

        function ClientDataGrid_NodeDblClick(s, e) {
            var edit = ClientMenu.GetItemByName("Edit");
            if (edit.GetVisible()) {
                var key = ClientDataGrid.GetFocusedNodeKey();
                ChangeState("EditForm", "EDIT", key);
                ClientEditPopupControl.SetHeaderText("Cập nhật");
                var state = State;
                ShowEditForm(state.Command, state.Key);
            }
        }

        function ShowEditForm(command, key) {
            ClientParentEditor.SetValue(key);
            //ClientDivisionEditor.SetValue(null);
            ClientShortNameEditor.SetValue("");
            ClientNameVNEditor.SetValue("");
            ClientNameENEditor.SetValue("");
            ClientCompanyGroupEditor.SetValue(null);
            ClientCompanyTypeEditor.SetValue(null);
            ClientValidFromEditor.SetValue(null);
            ClientValidToEditor.SetValue(null);
            ClientSeqEditor.SetValue(0);
            ClientNoteEditor.SetValue("");
            ClientAreaEditor.SetValue("SGN");
            //ClientOriAreaEditor.SetValue("SGN");
            //ClientTxtFASTCodeEditor.SetValue("");
            ClientDivisionCodeEditor.SetValue("");
            ClientDepartmentCodeEditor.SetValue("");
            ClientCurrencyEditor.SetValue("VND");
            ClientSectionEditor.SetValue("");
            //ClientOnBehalfOfBRAEditor.SetValue(false);
            //ClientOnBehalfOfCTYEditor.SetValue(false);
            //ClientOnBehalfOfEditor.SetValue("NO");
            //ClientIsExternalCostEditor.SetValue(false);
            ClientActiveEditor.SetValue(true);

            ShowLoadingPanel(ClientSplitter.GetMainElement());
            DoCallback(ClientParentEditor, function () {
                ClientParentEditor.PerformCallback('');
            });

        }

        function ClientParentEditor_EndCallback(s, e) {
            var command = State.Command;
            if (command == "NEW") {
                HideLoadingPanel();
                ClientShortNameEditor.Focus();
                var key = ClientDataGrid.GetFocusedNodeKey();
                ClientParentEditor.SetValue(key);
                if (!ClientEditPopupControl.IsVisible())
                    ClientEditPopupControl.Show();
            }
            else if (command == "EDIT") {
                var key = State.Key;
                ClientDataGrid.PerformCustomDataCallback(key);
            }
        }

        function ClientDataGrid_CustomDataCallback(s, e) {
            HideLoadingPanel();
            var values = e.result;
            if (!values)
                return;

            ClientParentEditor.SetValue(values["ParentID"]);
            //ClientDivisionEditor.SetValue(values["DivisionID"]);
            ClientShortNameEditor.SetValue(values["ShortName"]);
            ClientNameVNEditor.SetValue(values["NameV"]);
            ClientNameENEditor.SetValue(values["NameE"]);
            ClientCompanyGroupEditor.SetValue(values["CompanyGroup"]);
            ClientCompanyTypeEditor.SetValue(values["CompanyType"]);
            ClientAreaEditor.SetValue(values["AreaCode"]);
            //ClientOriAreaEditor.SetValue(values["OriArea"]);
            //ClientTxtFASTCodeEditor.SetValue(values["FASTCode"]);
            ClientDivisionCodeEditor.SetValue(values["DivisionCode"]);
            ClientDepartmentCodeEditor.SetValue(values["DepartmentCode"]);
            //ClientOnBehalfOfBRAEditor.SetValue(values["IsOnBehalfOfBRA"] == "True");
            //ClientOnBehalfOfCTYEditor.SetValue(values["IsOnBehalfOfCTY"] == "True");
            //ClientOnBehalfOfEditor.SetValue(values["IsOnBehalfOf"]);
            //ClientIsExternalCostEditor.SetValue(values["IsExternalCost"] == "True");
            ClientSectionEditor.SetValue(values["Section"]);
            ClientCurrencyEditor.SetValue(values["Curr"]);
            ClientActiveEditor.SetValue(values["Active"] == "True");

            if (values["ValidFrom"] != "") {
                var validFrom = values["ValidFrom"].split("-");
                ClientValidFromEditor.SetDate(new Date(validFrom[0], validFrom[1] - 1, validFrom[2]));
            }
            if (values["ValidTo"] != "") {
                var validTo = values["ValidTo"].split("-");
                ClientValidToEditor.SetDate(new Date(validTo[0], validTo[1] - 1, validTo[2]));
            }
            //ClientActivityEditor.SetValue(values["ActivityID"]);
            ClientSeqEditor.SetValue(parseInt(values["Seq"]));
            ClientNoteEditor.SetValue(values["Note"]);

            ClientShortNameEditor.Focus();
            ClientEditPopupControl.Show();
        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientShortNameEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
                return;

            var state = State;
            var args = "SaveForm|" + state.Command + "|" + state.Key;
            ChangeState("SaveForm", state.Command, state.Key);
            DoCallback(ClientDataGrid, function () {
                ClientDataGrid.PerformCallback(args);
            });
        }

        function ClientDataGrid_EndCallback(s, e) {
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

        function ClientCompanyGroupEditor_ButtonClick(s, e) {
            if (e.buttonIndex == 0) {
                ClientCGCodeEditor.SetValue("");
                ClientCGNameEditor.SetValue("");
                ClientCompanyGroupPopup.Show();
            }
        }

        function ClientSaveCompanyGroupButton_Click(s, e) {
            if (window.ClientCGCodeEditor && !ASPxClientEdit.ValidateEditorsInContainerById("CompanyGroupEditForm"))
                return;
            var args = "AddCompanyGroup";
            DoCallback(ClientCompanyGroupEditor, function () {
                ClientCompanyGroupEditor.PerformCallback(args);
            });
        }

        function ClientCompanyGroupEditor_EndCallback(s, e) {
            ClientCompanyGroupPopup.Hide();
            s.SetValue(ClientCGCodeEditor.GetValue());
        }


    </script>
    <style>
        .dxtlControl_Office2010Blue caption {
            font-weight: bold;
            color: #1e395b;
            padding: 3px 3px 5px;
            text-align: left;
            background: #bdd0e7 url(/DXR.axd?r=0_4030-86T5g) repeat-x left top;
            border-bottom: 0 solid #8ba0bc;
            border: 1px solid #8ba0bc;
        }

        caption {
            display: table-caption;
            text-align: -webkit-center;
        }

        .dxtlNode_Office2010Blue td.dxtl, .dxtlAltNode_Office2010Blue td.dxtl, .dxtlSelectedNode_Office2010Blue td.dxtl, .dxtlFocusedNode_Office2010Blue td.dxtl, .dxtlEditFormDisplayNode_Office2010Blue td.dxtl, .dxtlCommandCell_Office2010Blue {
            padding: 4px 6px;
            border-width: 0;
            border: 1px solid #C2D4DA;
            white-space: nowrap;
            overflow: hidden;
        }

        .dxtl__B0 {
            border-top-style: none !important;
            border-left-style: none !important;
            border-right-style: solid !important;
            border-bottom-style: none !important;
        }

        /*.dxtl__B1 {
            border-top-style: none !important;
            border-right-style: none !important;
            border-bottom-style: solid !important;
        }*/
    </style>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Name="Menu" Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="padding: 10px 10px 10px; font-size: 1.5em; font-weight: bold; margin: 0px 4px 4px; float: right;">
                            <asp:Literal ID="Literal1" runat="server" Text="Companies" />
                        </div>
                        <div style="float: left">

                            <dx:ASPxMenu ID="mMain" runat="server" ClientInstanceName="ClientMenu" CssClass="main-menu" Theme="Moderno">
                                <ClientSideEvents ItemClick="function(s, e) { ClientMenu_ItemClick(e);}" />
                                <Items>
                                    <dx:MenuItem Name="New" Text="<%$Resources:Language, Add %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/add.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Edit" Text="<%$Resources:Language, Edit %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/edit.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Delete" Text="<%$Resources:Language, Delete %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/delete.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="SyncData" Text="Đồng bộ PMS" ItemStyle-CssClass="menu-item" Image-Url="../Content/images/execute.png" Image-Height="16px" Image-Width="16px">
                                    </dx:MenuItem>
                                    <%-- <dx:MenuItem Name="EXPORT" Text="Export Excel" ItemStyle-CssClass="menu-item" Image-Url="../Content/images/action/export.png">                                                          
                                    </dx:MenuItem>--%>
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
                        <dx:ASPxTreeList ID="DataGrid" runat="server" Width="100%" ClientInstanceName="ClientDataGrid" KeyFieldName="CompanyID" ParentFieldName="ParentID"
                            OnCustomCallback="DataGrid_CustomCallback" OnCustomDataCallback="DataGrid_CustomDataCallback"
                            OnHtmlRowPrepared="DataGrid_HtmlRowPrepared" OnCustomUnboundColumnData="DataGrid_CustomUnboundColumnData">
                            <Columns>
                                <dx:TreeListTextColumn FieldName="ShortName" VisibleIndex="1" Caption="Short Name" Width="100">
                                    <DataCellTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("CompanyID").ToString().Trim() +"-"+ Eval("ShortName") %>'></asp:Label>
                                    </DataCellTemplate>
                                </dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="DivisionCode" VisibleIndex="2" Caption="Division" Width="80" AutoFilterCondition="Contains"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="DepartmentCode" VisibleIndex="2" Caption="Department" Width="80" AutoFilterCondition="Contains"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="NameV" VisibleIndex="2" Caption="Name VN" Width="300" AutoFilterCondition="Contains"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="NameE" VisibleIndex="3" Caption="Name EN" Width="300" AutoFilterCondition="Contains"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="AreaCode" VisibleIndex="4" Caption="Group" Width="80" AutoFilterCondition="Contains"></dx:TreeListTextColumn>
                                <%--<dx:TreeListTextColumn FieldName="OriArea" VisibleIndex="4" Caption="Ori Area" Width="80" AutoFilterCondition="Contains"></dx:TreeListTextColumn>--%>
                                <%--<dx:TreeListTextColumn FieldName="FASTCode" VisibleIndex="5" Caption="FASTCode" Width="250" AutoFilterCondition="Contains"></dx:TreeListTextColumn>--%>
                                <dx:TreeListDateTimeColumn FieldName="ValidFrom" VisibleIndex="6" Caption="Valid From">
                                    <PropertiesDateEdit EditFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                </dx:TreeListDateTimeColumn>
                                <dx:TreeListDateTimeColumn FieldName="ValidTo" VisibleIndex="7" Caption="Valid To">
                                    <PropertiesDateEdit EditFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                </dx:TreeListDateTimeColumn>
                                <dx:TreeListTextColumn FieldName="Section" VisibleIndex="8" Caption="Section" Width="60" HeaderStyle-Wrap="True">
                                </dx:TreeListTextColumn>
                                <%-- <dx:TreeListCheckColumn FieldName="IsOnBehalfOfBRA" VisibleIndex="8" Caption="On Behalf Of Branch" Width="80" HeaderStyle-Wrap="True"></dx:TreeListCheckColumn>
                                <dx:TreeListCheckColumn FieldName="IsOnBehalfOfCTY" VisibleIndex="8" Caption="On Behalf Of KVP" Width="80" HeaderStyle-Wrap="True"></dx:TreeListCheckColumn>--%>
                                <%--<dx:TreeListCheckColumn FieldName="IsExternalCost" VisibleIndex="9" Caption="Is External Cost" Width="120" HeaderStyle-Wrap="True"></dx:TreeListCheckColumn>--%>
                                <dx:TreeListCheckColumn FieldName="Active" VisibleIndex="10" Caption="Active" Width="80" HeaderStyle-Wrap="True"></dx:TreeListCheckColumn>
                                <dx:TreeListTextColumn FieldName="Note" VisibleIndex="11" Caption="Note" Width="300"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn FieldName="Seq" VisibleIndex="12" Caption="Seq"></dx:TreeListTextColumn>
                            </Columns>
                            <Styles>
                                <AlternatingNode Enabled="True"></AlternatingNode>
                            </Styles>
                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" HorizontalScrollBarMode="Auto" ScrollableHeight="500" />
                            <SettingsSearchPanel Visible="false" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="ShortName;NameV;NameE;Note" />
                            <Paddings Padding="0px" />
                            <Border BorderWidth="1px" />
                            <BorderBottom BorderWidth="1px" />
                            <SettingsBehavior AllowFocusedNode="true" />
                            <SettingsResizing ColumnResizeMode="Control" />
                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                            <ClientSideEvents NodeDblClick="ClientDataGrid_NodeDblClick"
                                CustomDataCallback="ClientDataGrid_CustomDataCallback"
                                EndCallback="ClientDataGrid_EndCallback" />
                        </dx:ASPxTreeList>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="DataGrid"></dx:ASPxGridViewExporter>


    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="450" Height="250" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Parent">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="ParentEditor" Width="350" ClientInstanceName="ClientParentEditor" OnCallback="ParentEditor_Callback">
                                        <ClientSideEvents EndCallback="ClientParentEditor_EndCallback" />
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <%--  <dx:LayoutItem Caption="Division">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="DivisionEditor" Width="350" ValueType="System.Int32" ClientInstanceName="ClientDivisionEditor" OnInit="DivisionEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <dx:LayoutItem Caption="Group">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="AreaEditor" Width="350" ValueType="System.String" ClientInstanceName="ClientAreaEditor" OnInit="AreaEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                      <%--  <dx:LayoutItem Caption="Origin Area">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="OriAreaEditor" Width="350" ValueType="System.String" ClientInstanceName="ClientOriAreaEditor" OnInit="AreaEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <dx:LayoutItem Caption="Short Name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ShortNameEditor" Width="350" ClientInstanceName="ClientShortNameEditor" OnValidation="ShortNameEditor_Validation">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Short Name is required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Division Code">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="DivisionCodeEditor" Width="350" ClientInstanceName="ClientDivisionCodeEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Department Code">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="DepartmentCodeEditor" Width="350" ClientInstanceName="ClientDepartmentCodeEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Name VN">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="NameVNEditor" Width="350" ClientInstanceName="ClientNameVNEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Name EN">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="NameENEditor" Width="350" ClientInstanceName="ClientNameENEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <%--<dx:LayoutItem Caption="FASTCode">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="txtFASTCodeEditor" Width="350" ClientInstanceName="ClientTxtFASTCodeEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <dx:LayoutItem Caption="Company Group">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="CompanyGroupEditor" Width="350" ValueType="System.String" ClientInstanceName="ClientCompanyGroupEditor"
                                        OnInit="CompanyGroupEditor_Init" OnCallback="CompanyGroupEditor_Callback">
                                        <Buttons>
                                            <dx:EditButton Image-Url="../Content/images/SpinEditPlus.png" Position="Right" Image-Height="16" Image-Width="16"></dx:EditButton>
                                        </Buttons>
                                        <ClientSideEvents ButtonClick="ClientCompanyGroupEditor_ButtonClick" EndCallback="ClientCompanyGroupEditor_EndCallback" />
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="CompanyTypeEditor" Width="350" ValueType="System.String" ClientInstanceName="ClientCompanyTypeEditor">
                                        <Items>
                                            <dx:ListEditItem Value="K" Text="Khối trung gian" />
                                            <dx:ListEditItem Value="D" Text="Hộ ngân sách" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Section">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="SectionEditor" Width="350" ValueType="System.String" ClientInstanceName="ClientSectionEditor">
                                        <Items>
                                            <dx:ListEditItem Value="LVTM" Text="Lĩnh vực thương mại" />
                                            <dx:ListEditItem Value="OTH" Text="Lĩnh vực khác" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Currency">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="CurrencyEditor" Width="100" ClientInstanceName="ClientCurrencyEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Valid From">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit runat="server" ID="ValidFromEditor" Width="100" ClientInstanceName="ClientValidFromEditor" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Valid To">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit runat="server" ID="ValidToEditor" Width="100" ClientInstanceName="ClientValidToEditor" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <%--  <dx:LayoutItem Caption="On Behalf Of">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="cboOnBehalfOf" Width="350" ClientInstanceName="ClientOnBehalfOfEditor" OnInit="cboOnBehalfOf_Init">
                                      
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <%-- <dx:LayoutItem Caption="On Behalf Of CTY">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox runat="server" ID="ckOnBehalfOfCTY" Width="100" ClientInstanceName="ClientOnBehalfOfCTYEditor">
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <%--<dx:LayoutItem Caption="Is External Cost">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox runat="server" ID="ckIsExternalCost" Width="100" ClientInstanceName="ClientIsExternalCostEditor">
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <dx:LayoutItem Caption="Active">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox runat="server" ID="ckActive" Width="100" ClientInstanceName="ClientActiveEditor">
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Seq">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="SeqEditor" Width="100" ClientInstanceName="ClientSeqEditor">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Note">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo runat="server" ID="NoteEditor" Width="350" Rows="3" ClientInstanceName="ClientNoteEditor">
                                    </dx:ASPxMemo>
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

    <dx:ASPxPopupControl ID="CompanyGroupPopup" runat="server" Width="250" Height="150" AllowDragging="True" HeaderText="Add Company Group" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientCompanyGroupPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="CompanyGroupEditForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Code">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="CGCodeEditor" Width="250" ClientInstanceName="ClientCGCodeEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="CGNameEditor" Width="250" ClientInstanceName="ClientCGNameEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnACancel" runat="server" Text="Đóng" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ASPxClientEdit.ClearEditorsInContainerById('CompanyGroupEditForm');  ClientCompanyGroupPopup.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnASave" runat="server" Text="Lưu" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientSaveCompanyGroupButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>
</asp:Content>

