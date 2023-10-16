<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Function.aspx.cs" Inherits="Admin_Function" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <script type="text/javascript">
        function Splitter_PaneResized(s, e) {
            if (e.pane.name == 'GridPane') {
                ClientTreeListMenu.SetHeight(e.pane.GetClientHeight());
            }
        }

        function MenuItemClick(e) {
            if (e.item.name.toUpperCase() == "EXPORT") {
                e.processOnServer = false;
                return;
            }
            else if (e.item.name.toUpperCase() == "BASEACTION") {
                var cf = confirm("Bạn chắc chắn thêm các quyền CRUD không?");
                if (cf) {
                    var key = ClientTreeListMenu.GetFocusedNodeKey();
                    DoCallback(ClientTreeListMenu, function () {
                        ClientTreeListMenu.PerformCallback('BASEACTION|' + key);
                    });
                }
                e.processOnServer = false;
                return;
            }
            else if (e.item.name.toUpperCase() == "ADDACTION") {
                var cf = confirm("Bạn chắc chắn thêm quyền không?");
                if (cf) {
                    var key = ClientTreeListMenu.GetFocusedNodeKey();
                    DoCallback(ClientTreeListMenu, function () {
                        ClientTreeListMenu.PerformCallback('ADDACTION|' + key);
                    });
                }
                e.processOnServer = false;
                return;
            }
            e.processOnServer = false;
        }
    </script>

    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="splitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="Splitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="100" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="Declare Functions" />
                            </div>
                            <dx:ASPxMenu ID="Menu" runat="server" CssClass="main-menu" Theme="Moderno" OnItemClick="Menu_ItemClick">
                                <ClientSideEvents ItemClick="function(s, e) { MenuItemClick(e);}" />
                                <Items>
                                    <dx:MenuItem Name="BaseAction" Text="Add base action" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/add.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="AddAction" Text="Add action" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/add.gif">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="EXPORT" Text="Export" ItemStyle-CssClass="menu-item" Image-Url="../Content/images/action/export.png">
                                        <Items>
                                            <dx:MenuItem Name="PDF" Text="PDF" />
                                            <dx:MenuItem Name="XLS" Text="XLS" />
                                            <dx:MenuItem Name="XLSX" Text="XLSX" />
                                            <dx:MenuItem Name="RTF" Text="RTF" />
                                        </Items>
                                    </dx:MenuItem>
                                </Items>
                            </dx:ASPxMenu>
                        </div>
                        <div>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <Separator Visible="False"></Separator>

                <PaneStyle Border-BorderWidth="0">
                    <Border BorderWidth="0px"></Border>

                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Name="GridPane">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <dx:ASPxTreeList ID="treeListMenu" runat="server" AutoGenerateColumns="false" Width="100%"
                            KeyFieldName="MenuID" ParentFieldName="ParentMenuID" ClientInstanceName="ClientTreeListMenu" OnNodeDeleting="treeListMenu_NodeDeleting"
                            OnNodeInserting="treeListMenu_NodeInserting" OnNodeUpdating="treeListMenu_NodeUpdating" OnCellEditorInitialize="treeListMenu_CellEditorInitialize"
                            OnCustomCallback="treeListMenu_CustomCallback">
                            <Settings GridLines="Both" VerticalScrollBarMode="Auto" ScrollableHeight="500" />
                            <SettingsEditing Mode="PopupEditForm" />
                            <SettingsPopupEditForm Width="800" HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
                            <SettingsBehavior AllowFocusedNode="true" ExpandCollapseAction="NodeDblClick" />
                            <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="AppCode;NameVN;NameEN;MenuType;ActionRight" />
                            <SettingsResizing ColumnResizeMode="Control" />
                            <Columns>
                                <dx:TreeListDataColumn FieldName="NameVN" VisibleIndex="1" Caption="<%$Resources:Language, frmFunction_colNameVN %>">
                                </dx:TreeListDataColumn>
                                <dx:TreeListDataColumn FieldName="NameEN" VisibleIndex="2" Caption="<%$Resources:Language, frmFunction_colNameEN %>">
                                </dx:TreeListDataColumn>
                                <dx:TreeListDataColumn FieldName="AppCode" VisibleIndex="3" Caption="Application" Width="100">
                                </dx:TreeListDataColumn>
                                <dx:TreeListDataColumn FieldName="FileName" VisibleIndex="3" Caption="<%$Resources:Language, frmFunction_colFileName %>">
                                </dx:TreeListDataColumn>
                                <dx:TreeListDataColumn FieldName="MenuType" VisibleIndex="4" Caption="Menu Type" Width="100">
                                </dx:TreeListDataColumn>
                                <dx:TreeListDataColumn FieldName="ActionRight" VisibleIndex="5" Caption="Action Right" Width="300">
                                </dx:TreeListDataColumn>
                                <dx:TreeListDataColumn FieldName="Seq" VisibleIndex="6" Caption="Seq" Width="60">
                                </dx:TreeListDataColumn>
                                <dx:TreeListCheckColumn FieldName="Active" VisibleIndex="7" Caption="<%$Resources:Language, Active %>" Visible="false">
                                    <EditFormSettings ColumnSpan="2" Visible="True" />
                                    <EditFormSettings VisibleIndex="7" />
                                </dx:TreeListCheckColumn>
                                <dx:TreeListComboBoxColumn FieldName="ParentMenuID" VisibleIndex="8" Caption="<%$Resources:Language, frmFunction_colParent %>" Visible="false">
                                    <PropertiesComboBox EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                                    </PropertiesComboBox>
                                    <EditFormSettings Visible="True" />
                                    <EditFormSettings VisibleIndex="8" />
                                </dx:TreeListComboBoxColumn>
                                <dx:TreeListCommandColumn ButtonType="Image" VisibleIndex="9" ShowNewButtonInHeader="true" ShowInCustomizationForm="True" Width="100" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                                    <EditButton Visible="True">
                                        <Image Url="~/Content/images/action/edit.gif">
                                        </Image>
                                    </EditButton>
                                    <NewButton Visible="false">
                                        <Image Url="~/Content/images/action/add.gif">
                                        </Image>
                                    </NewButton>
                                    <DeleteButton Visible="True">
                                        <Image Url="~/Content/images/action/delete.gif">
                                        </Image>
                                    </DeleteButton>
                                    <UpdateButton>
                                        <Image Url="~/Content/images/action/save.png">
                                        </Image>
                                    </UpdateButton>
                                    <CancelButton>
                                        <Image Url="~/Content/images/action/undo.png">
                                        </Image>
                                    </CancelButton>
                                </dx:TreeListCommandColumn>
                            </Columns>
                        </dx:ASPxTreeList>
                        <dx:ASPxTreeListExporter ID="TreeListExporter" runat="server" TreeListID="treeListMenu"></dx:ASPxTreeListExporter>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
</asp:Content>

