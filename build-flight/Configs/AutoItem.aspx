<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AutoItem.aspx.cs" Inherits="Pages_AutoItem" %>

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
                ShowEditForm(state.Command, state.Key);

                e.processOnServer = false;
                return;
            } else if (name.toUpperCase() == "EDIT") {

                var key = ClientDataGrid.GetFocusedNodeKey();
                ChangeState("EditForm", name.toUpperCase(), key);
                ClientEditPopupControl.SetHeaderText("Cập nhật");
                var state = State;
                ShowEditForm(state.Command, state.Key);

                e.processOnServer = false;
                return;
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
            e.processOnServer = true;
        }

        function ClientDataGrid_NodeDblClick(s, e) {
            var key = ClientDataGrid.GetFocusedNodeKey();
            ChangeState("EditForm", "EDIT", key);
            ClientEditPopupControl.SetHeaderText("Cập nhật");
            var state = State;
            ShowEditForm(state.Command, state.Key);
        }

        function ShowEditForm(command, key) {

            ClientParentEditor.SetValue(null);
            ClientViewNameEditor.SetValue("");
            ClientModuleNameEditor.SetValue("");
            ClientRunSelectEditor.SetValue("");
            ClientInputsEditor.SetValue("");
            ClientOutputsEditor.SetValue("");
            ClientDescriptionEditor.SetValue("");
            ClientCompanyEditor.SetValue("");
            ClientSubaccountEditor.SetValue("");
            ClientItemEditor.SetValue("");
            ClientCheckBeforeEditor.SetValue("");
            ClientCheckAfterEditor.SetValue("");
            ClientStepsEditor.SetValue("");
            ClientSqlQ1Editor.SetValue("");
            ClientSqlQ2Editor.SetValue("");
            ClientSqlP1Editor.SetValue("");
            ClientSqlP2Editor.SetValue("");
            ClientActivityEditor.SetValue(null);
            ClientClsEditor.SetValue("");
            ClientUnitVersionEditor.SetValue("");
            ClientUnitFormulaEditor.SetValue("");
            //ClientSimilarGroupEditor.SetValue("");
            //ClientSQLSimilarEditor.SetValue("");
            ClientGroupTypeEditor.SetValue("");
            ClientAutoTypeEditor.SetValue("");
            ClientSeqEditor.SetValue(0);
            ClientActiveEditor.SetValue("");


            ShowLoadingPanel(ClientSplitter.GetMainElement());
            DoCallback(ClientParentEditor, function () {
                ClientParentEditor.PerformCallback('');
            });

        }

        function ClientParentEditor_EndCallback(s, e) {
            var command = State.Command;
            if (command == "NEW") {
                HideLoadingPanel();
                ClientViewNameEditor.Focus();
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
            ClientViewNameEditor.SetValue(values["ViewName"]);
            ClientModuleNameEditor.SetValue(values["ModuleName"]);
            ClientRunSelectEditor.SetValue(values["RunSelect"] == "True" ? true : false);
            ClientInputsEditor.SetValue(values["Inputs"]);
            ClientOutputsEditor.SetValue(values["Outputs"]);
            ClientDescriptionEditor.SetValue(values["Description"]);
            ClientCompanyEditor.SetValue(values["CompanyID"]);
            ClientSubaccountEditor.SetValue(values["SubaccountID"]);
            ClientItemEditor.SetValue(values["Item"]);
            ClientCheckBeforeEditor.SetValue(values["CheckBefore"]);
            ClientCheckAfterEditor.SetValue(values["CheckAfter"]);
            ClientStepsEditor.SetValue(values["Steps"]);
            ClientSqlQ1Editor.SetValue(values["SQL_Q1"]);
            ClientSqlQ2Editor.SetValue(values["SQL_Q2"]);
            ClientSqlP1Editor.SetValue(values["SQL_P1"]);
            ClientSqlP2Editor.SetValue(values["SQL_P2"]);
            ClientActivityEditor.SetValue(values["ActivityID"]);
            ClientClsEditor.SetValue(values["Cls"]);
            ClientUnitVersionEditor.SetValue(values["UnitVersionID"]);
            ClientUnitFormulaEditor.SetValue(values["UnitFormula"]);
            //ClientSimilarGroupEditor.SetValue(values["SimilarGroup"]);
            //ClientSQLSimilarEditor.SetValue(values["SqlSimilar"]);
            ClientGroupTypeEditor.SetValue(values["GroupType"]);
            ClientAutoTypeEditor.SetValue(values["AutoType"]);
            ClientSeqEditor.SetValue(values["Seq"]);
            ClientActiveEditor.SetValue(values["Active"] == "True" ? true : false);

            ClientViewNameEditor.Focus();
            ClientEditPopupControl.Show();
        }

        function ClientSaveButton_Click(s, e) {
            if (window.ClientViewNameEditor && !ASPxClientEdit.ValidateEditorsInContainerById("EditForm"))
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

        function ClientDataGrid_NodeClick(s, e) {
            var key = s.GetFocusedNodeKey();
            ChangeState("List", "", key);

        }


    </script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Name="Menu" Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                          <div style="padding: 10px 10px 10px; font-size: 1.5em; font-weight: bold; margin: 0px 4px 4px; float: right;">
                           <asp:Literal ID="Literal1" runat="server" Text="Auto Item" />
                        </div>
                        <div style="float: left">
                            <dx:ASPxMenu ID="mMain" runat="server" CssClass="main-menu" Theme="Moderno" OnItemClick="mMain_ItemClick">
                                <ClientSideEvents ItemClick="function(s, e) { ClientMenu_ItemClick(e);}" />
                                <Items>
                                    <dx:MenuItem Name="New" Text="<%$Resources:Language, Add %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/add.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Edit" Text="<%$Resources:Language, Edit %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/edit.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Delete" Text="<%$Resources:Language, Delete %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/delete.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="SyncData" Text="Đồng bộ PMS" ItemStyle-CssClass="menu-item" Image-Url="../Content/images/execute.png"  Image-Height="16px" Image-Width="16px">
                                    </dx:MenuItem>
                                     <dx:MenuItem Name="EXPORT" Text="Export Excel" ItemStyle-CssClass="menu-item" Image-Url="../Content/images/action/export.png"  Image-Height="16px" Image-Width="16px">                                                          
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
                        <dx:ASPxTreeList ID="DataGrid" runat="server" Width="100%" AutoGenerateColumns="false" ClientInstanceName="ClientDataGrid" KeyFieldName="AutoItemID" ParentFieldName="ParentID"
                            OnCustomCallback="DataGrid_CustomCallback" OnCustomDataCallback="DataGrid_CustomDataCallback"
                            OnHtmlRowPrepared="DataGrid_HtmlRowPrepared">
                            <Columns>
                                   <dx:TreeListDataColumn FieldName="Description" VisibleIndex="0" Caption="Description" Width="300"></dx:TreeListDataColumn>
                                
                                <dx:TreeListDataColumn FieldName="Item" VisibleIndex="2" Caption="Item" Width="150"></dx:TreeListDataColumn>
                                <dx:TreeListDataColumn FieldName="ViewName" VisibleIndex="3" Caption="View Name" Width="100"></dx:TreeListDataColumn>
                                 <dx:TreeListDataColumn FieldName="ModuleName" VisibleIndex="4" Caption="Module Name" Width="100"></dx:TreeListDataColumn>
                                 <dx:TreeListCheckColumn FieldName="RunSelect" VisibleIndex="5" Caption="Run Select" Width="100"></dx:TreeListCheckColumn>
                                 <dx:TreeListDataColumn FieldName="Inputs" VisibleIndex="6" Caption="Inputs" Width="100"></dx:TreeListDataColumn>
                                 <dx:TreeListDataColumn FieldName="Outputs" VisibleIndex="7" Caption="Outputs" Width="100"></dx:TreeListDataColumn>
                                 <dx:TreeListComboBoxColumn FieldName="CompanyID" VisibleIndex="8" Caption="Company" Width="200" CellStyle-HorizontalAlign="Left">
                                     <PropertiesComboBox  
                                        ValueType="System.Int32" DropDownStyle="DropDownList"  >
                                        <ClearButton DisplayMode="OnHover" />
                                    </PropertiesComboBox>
                                 </dx:TreeListComboBoxColumn>
                                 <dx:TreeListComboBoxColumn FieldName="SubaccountID" VisibleIndex="9" Caption="Subaccount" Width="200" CellStyle-HorizontalAlign="Left">
                                      <PropertiesComboBox  
                                        ValueType="System.Int32" DropDownStyle="DropDownList"  >
                                        <ClearButton DisplayMode="OnHover" />
                                    </PropertiesComboBox>
                                 </dx:TreeListComboBoxColumn>
                                 
                                 <dx:TreeListDataColumn FieldName="CheckBefore" VisibleIndex="10" Caption="Check Before" Width="100"></dx:TreeListDataColumn>
                                 <dx:TreeListDataColumn FieldName="CheckAfter" VisibleIndex="11" Caption="Check After" Width="100"></dx:TreeListDataColumn>
                                 <dx:TreeListDataColumn FieldName="Steps" VisibleIndex="12" Caption="Steps" Width="80"></dx:TreeListDataColumn>
                                 <dx:TreeListDataColumn FieldName="SQL_Q1" VisibleIndex="13" Caption="SQL_Q1" Width="300"></dx:TreeListDataColumn>
                                 <dx:TreeListDataColumn FieldName="SQL_Q2" VisibleIndex="14" Caption="SQL_Q2" Width="300"></dx:TreeListDataColumn>
                                 <dx:TreeListDataColumn FieldName="SQL_P1" VisibleIndex="15" Caption="SQL_P1" Width="300"></dx:TreeListDataColumn>
                                 <dx:TreeListDataColumn FieldName="SQL_P2" VisibleIndex="16" Caption="SQL_P2" Width="300"></dx:TreeListDataColumn>
                                 <dx:TreeListComboBoxColumn FieldName="ActivityID" VisibleIndex="17" Caption="Activity" Width="00" CellStyle-HorizontalAlign="Left">
                                      <PropertiesComboBox  
                                        ValueType="System.Int32" DropDownStyle="DropDownList"  >
                                        <ClearButton DisplayMode="OnHover" />
                                    </PropertiesComboBox>
                                 </dx:TreeListComboBoxColumn>
                                 <dx:TreeListDataColumn FieldName="Cls" VisibleIndex="18" Caption="Cls" Width="100"></dx:TreeListDataColumn>
                                 <dx:TreeListComboBoxColumn FieldName="UnitVersionID" VisibleIndex="19" Caption="UnitVersion" Width="200" CellStyle-HorizontalAlign="Left">
                                      <PropertiesComboBox  
                                        ValueType="System.Int32" DropDownStyle="DropDownList"  >
                                        <ClearButton DisplayMode="OnHover" />
                                    </PropertiesComboBox>
                                 </dx:TreeListComboBoxColumn>
                                      <dx:TreeListDataColumn FieldName="UnitFormula" VisibleIndex="20" Caption="Unit Formula" Width="270"></dx:TreeListDataColumn>
                           
                                 <%--<dx:TreeListDataColumn FieldName="SimilarGroup" VisibleIndex="20" Caption="Similar Group" Width="100"></dx:TreeListDataColumn>
                                 <dx:TreeListDataColumn FieldName="SQLSimilar" VisibleIndex="21" Caption="SQL Similar" Width="160"></dx:TreeListDataColumn>
                                --%>  
                                <dx:TreeListDataColumn FieldName="GroupType" VisibleIndex="22" Caption="Group Type" Width="100"></dx:TreeListDataColumn>
                                <dx:TreeListDataColumn FieldName="AutoType" VisibleIndex="23" Caption="Auto Type" Width="100"></dx:TreeListDataColumn>
                                  <dx:TreeListDataColumn FieldName="Seq" VisibleIndex="24" Caption="Seq" Width="100"></dx:TreeListDataColumn>
                                  <dx:TreeListCheckColumn FieldName="Active" VisibleIndex="25" Caption="Active" Width="100"></dx:TreeListCheckColumn>
                             </Columns>
                            
                        
                            <Styles>
                                <AlternatingNode Enabled="True"></AlternatingNode>
                            </Styles>
                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" HorizontalScrollBarMode="Auto" ScrollableHeight="500" />
                            <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="Description;Note" />
                            <Paddings Padding="0px" />
                            <Border BorderWidth="1px" />
                            <BorderBottom BorderWidth="1px" />
                            <SettingsBehavior AllowFocusedNode="true" />
                            <SettingsResizing ColumnResizeMode="Control" />
                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                            <ClientSideEvents NodeDblClick="ClientDataGrid_NodeDblClick"
                                FocusedNodeChanged="ClientDataGrid_NodeClick"
                                CustomDataCallback="ClientDataGrid_CustomDataCallback"
                                EndCallback="ClientDataGrid_EndCallback" />
                        </dx:ASPxTreeList>
                            <dx:ASPxTreeListExporter ID="TreeListExporter" runat="server" TreeListID="DataGrid"></dx:ASPxTreeListExporter>
                       
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
   <%-- <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="DataGrid"></dx:ASPxGridViewExporter>--%>
    

    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="400" Height="250" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="Auto" ColCount="2" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Parent">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="ParentEditor" Width="250" ClientInstanceName="ClientParentEditor" OnCallback="ParentEditor_Callback">
                                        <ClientSideEvents EndCallback="ClientParentEditor_EndCallback" />
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="View Name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ViewNameEditor" Width="250" ClientInstanceName="ClientViewNameEditor">
                                       
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Module Name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                   <dx:ASPxTextBox runat="server" ID="ModuleNameEditor" Width="250" ClientInstanceName="ClientModuleNameEditor">
                                       
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Run Select">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox runat="server" ID="RunSelectEditor" ClientInstanceName="ClientRunSelectEditor">
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Inputs">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="InputsEditor" Width="250" ClientInstanceName="ClientInputsEditor">
                                       
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Outputs">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="OutputsEditor" Width="250" ClientInstanceName="ClientOutputsEditor">
                                       
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Description">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="DescriptionEditor" Width="250" ClientInstanceName="ClientDescriptionEditor">
                                       
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Company">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="CompanyEditor" Width="250" ClientInstanceName="ClientCompanyEditor" OnInit="CompanyEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                          <dx:LayoutItem Caption="Subaccount">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="SubaccountEditor" Width="250" ClientInstanceName="ClientSubaccountEditor" OnInit="SubaccountEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Item">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ItemEditor" Width="250" ClientInstanceName="ClientItemEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Check Before">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="CheckBeforeEditor" Width="250" ClientInstanceName="ClientCheckBeforeEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Check After">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="CheckAfterEditor" Width="250" ClientInstanceName="ClientCheckAfterEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
               
                         <dx:LayoutItem Caption="SQL Q1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="SqlQ1Editor" Width="250" ClientInstanceName="ClientSqlQ1Editor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         <dx:LayoutItem Caption="SQL Q2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="SqlQ2Editor" Width="250" ClientInstanceName="ClientSqlQ2Editor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         <dx:LayoutItem Caption="SQL P1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="SqlP1Editor" Width="250" ClientInstanceName="ClientSqlP1Editor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         <dx:LayoutItem Caption="SQL P2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="SqlP2Editor" Width="250" ClientInstanceName="ClientSqlP2Editor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Unit Formula">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="UnitFormulaEditor" Width="250" ClientInstanceName="ClientUnitFormulaEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Activity">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="ActivityEditor" Width="250" ClientInstanceName="ClientActivityEditor" OnInit="ActivityEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>  
                        <dx:LayoutItem Caption="Cls">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ClsEditor" Width="250" ClientInstanceName="ClientClsEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         <dx:LayoutItem Caption="Unit Version">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="UnitVersionEditor" Width="250" ClientInstanceName="ClientUnitVersionEditor" OnInit="UnitVersionEditor_Init">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem> 
                        <dx:LayoutItem Caption="Steps">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit runat="server" ID="StepsEditor" Width="250" ClientInstanceName="ClientStepsEditor">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
          
                      <%--   <dx:LayoutItem Caption="Similar Group">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="SimilarGroupEditor" Width="250" ClientInstanceName="ClientSimilarGroupEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="SQL Similar">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="SQLSimilarEditor" Width="250" ClientInstanceName="ClientSQLSimilarEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                         <dx:LayoutItem Caption="Group Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="GroupTypeEditor" Width="250" ClientInstanceName="ClientGroupTypeEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         <dx:LayoutItem Caption="Auto Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="AutoTypeEditor" Width="250" ClientInstanceName="ClientAutoTypeEditor">
                                    </dx:ASPxTextBox>
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
                        <dx:LayoutItem Caption="Active">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox runat="server" ID="ActiveEditor" ClientInstanceName="ClientActiveEditor">
                                    </dx:ASPxCheckBox>
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
</asp:Content>

