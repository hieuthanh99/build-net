<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PositionGroup.aspx.cs" Inherits="Configs_PositionGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <script type="text/javascript">

        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "GridPane") {
                ClientGroupGrid.SetHeight(e.pane.GetClientHeight());
            }
        }

        function ClientGroupGrid_AddNewButtonClick(s, e) {

        }

        function ClientGroupGrid_CustomButtonClick(s, e) {
            if (e.buttonID == "btnEdit") {
                alert("Cập nhật");
            }

            if (e.buttonID == "btnDelete") {
                var cf = confirm("Bạn chắc chắn muốn xóa bản ghi này?");
                if (cf) {

                    var key = s.GetFocusedNodeKey();

                    RevCost.DoCallback(ClientGroupGrid, function () {
                        ClientGroupGrid.PerformCallback('DELETE_POSITION_GROUP|' + key);
                    });
                }
            }
        }


    </script>
    <style>
        .dxgvTitlePanel_Office2010Blue, .dxgvTable_Office2010Blue caption {
            font-weight: bold;
            padding: 3px 3px 5px;
            text-align: left;
            background: #bdd0e7 url(/DXR.axd?r=0_3969-ttc8i) repeat-x left top;
            color: #1e395b;
            border-bottom: 1px solid #8ba0bc;
        }
    </style>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <Styles>
            <Separator>
                <BorderTop BorderStyle="None" />
                <BorderBottom BorderStyle="None" />
            </Separator>
        </Styles>
        <ClientSideEvents PaneResized="ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Name="Menu" Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="DANH MỤC NHÓM CHỨC DANH" />
                            </div>
                        </div>
                        <div style="float: right">
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
                        <dx:ASPxTreeList ID="GroupGrid" runat="server" Width="100%" ClientInstanceName="ClientGroupGrid" KeyFieldName="DMGroupID"
                            ParentFieldName="ParentGroupID"
                            OnNodeUpdated="GroupGrid_NodeUpdated">
                            <Columns>
                                <dx:TreeListTextColumn FieldName="GroupName" VisibleIndex="1" Caption="Tên nhóm chức danh" Width="450">
                                    <EditFormSettings VisibleIndex="1" />
                                </dx:TreeListTextColumn>
                                <dx:TreeListComboBoxColumn FieldName="PositionGroupType" VisibleIndex="2" Caption="Nhóm lao động" Width="200" CellStyle-HorizontalAlign="Left">
                                    <EditFormSettings VisibleIndex="2" />
                                    <PropertiesComboBox ValueType="System.String">
                                        <Items>
                                            <dx:ListEditItem Value="DB" Text="Lao động định biên" />
                                            <dx:ListEditItem Value="PT" Text="Lao động phụ trợ" />
                                        </Items>
                                    </PropertiesComboBox>
                                </dx:TreeListComboBoxColumn>
                                <dx:TreeListComboBoxColumn FieldName="ParentGroupID" VisibleIndex="3" Caption="Thuộc nhóm" Width="0" CellStyle-HorizontalAlign="Left">
                                    <EditFormSettings VisibleIndex="3" />
                                    <PropertiesComboBox ValueType="System.Int32" ValueField="DMGroupID" TextField="GroupName"></PropertiesComboBox>
                                </dx:TreeListComboBoxColumn>
                                <dx:TreeListTextColumn FieldName="Description" VisibleIndex="4" Caption="Diễn giải" Width="40%">
                                    <EditFormSettings VisibleIndex="4" ColumnSpan="2" />
                                </dx:TreeListTextColumn>
                                <dx:TreeListCheckColumn FieldName="Inactive" VisibleIndex="5" Caption="Bỏ theo dõi">
                                    <EditFormSettings VisibleIndex="5" />
                                </dx:TreeListCheckColumn>
                                <dx:TreeListCommandColumn VisibleIndex="6" Width="150" HeaderStyle-HorizontalAlign="Center" EditButton-Visible="true" ShowNewButtonInHeader="false">
                                    <HeaderCaptionTemplate>
                                        <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                            <Image Url="../Content/images/action/add.gif"></Image>
                                            <ClientSideEvents Click="ClientGroupGrid_AddNewButtonClick" />
                                        </dx:ASPxButton>
                                    </HeaderCaptionTemplate>

                                    <CustomButtons>
                                        <%--<dx:TreeListCommandColumnCustomButton ID="GroupEdit" Text="Edit" Image-Url="../Content/images/action/edit.gif">
                                            <Styles>
                                                <Style Paddings-PaddingRight="1px"></Style>
                                            </Styles>
                                        </dx:TreeListCommandColumnCustomButton>--%>
                                        <dx:TreeListCommandColumnCustomButton ID="GroupDelete" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                            <Styles>
                                                <Style Paddings-PaddingLeft="1px"></Style>
                                            </Styles>
                                        </dx:TreeListCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:TreeListCommandColumn>

                            </Columns>
                            <Styles>
                                <AlternatingNode Enabled="True"></AlternatingNode>
                            </Styles>
                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" HorizontalScrollBarMode="Auto" ScrollableHeight="500" />
                            <%-- <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="GroupName;Description" />--%>
                            <Paddings Padding="0px" />
                            <Border BorderWidth="1px" />
                            <BorderBottom BorderWidth="0px" />
                            <SettingsBehavior AllowFocusedNode="true" AllowSort="false" />
                            <SettingsResizing ColumnResizeMode="NextColumn" />
                            <SettingsEditing Mode="EditForm" />
                            <ClientSideEvents CustomButtonClick="ClientGroupGrid_CustomButtonClick" />
                        </dx:ASPxTreeList>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
</asp:Content>

