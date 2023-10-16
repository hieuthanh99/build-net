<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_LaborNormRate.aspx.cs" Inherits="Configs_DM_LaborNormRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <style>
        .dxtlControl_MaterialCompact caption, .dxgvTitlePanel_MaterialCompact, .dxgvTable_MaterialCompact caption {
            font-size: 1.25em;
            font-weight: normal;
            padding: 3px 3px 5px;
            text-align: center;
            color: #999999;
            text-align: left;
        }

        .dxgvTitlePanel_Office2010Blue, .dxgvTable_Office2010Blue caption {
            font-weight: bold;
            padding: 3px 3px 5px;
            text-align: left;
            background: #bdd0e7 url(/DXR.axd?r=0_3969-ttc8i) repeat-x left top;
            color: #1e395b;
            border-bottom: 1px solid #8ba0bc;
        }

        caption {
            display: table-caption;
            text-align: -webkit-center;
        }
    </style>
    <script src="../Scripts/Common.js"></script>
    <script type="text/javascript">

        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "GridPane") {
                ClientDataGrid.SetHeight(e.pane.GetClientHeight());
            }
        }

        function ClientDataGrid_AddNewButtonClick(s, e) {
            ClientDataGrid.AddNewRow();
        }

        function ClientDataGrid_CustomButtonClick(s, e) {
            if (e.buttonID == "btnEdit") {
                alert("Cập nhật");
            }

            if (e.buttonID == "btnDelete") {
                var cf = confirm("Bạn chắc chắn muốn xóa bản ghi này?");
                if (cf) {
                    if (!s.IsDataRow(s.GetFocusedRowIndex()))
                        return;
                    var key = s.GetRowKey(s.GetFocusedRowIndex());

                    RevCost.DoCallback(ClientDataGrid, function () {
                        ClientDataGrid.PerformCallback('DELETE|' + key);
                    });
                }
            }
        }

        function ClientSaveGridButton_Click(s, e) {
            if (ClientDataGrid.batchEditApi.HasChanges()) {
                ClientDataGrid.UpdateEdit();
            }
        }

        function ClientCancelEditButton_Click(s, e) {
            if (ClientDataGrid.batchEditApi.HasChanges()) {
                ClientDataGrid.CancelEdit();
            }
        }

        function ClientDataGrid_EndCallback(s, e) {
            ClientSplitter.AdjustControl();
        }
    </script>
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
                                <asp:Literal ID="Literal1" runat="server" Text="KHAI BÁO TỶ LỆ HAO PHÍ ĐỊNH MỨC" />
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
                        <dx:ASPxGridView ID="DataGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true" OnCustomCallback="DataGrid_CustomCallback" OnCustomDataCallback="DataGrid_CustomDataCallback"
                            ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="ExpendRateID"
                            OnBatchUpdate="DataGrid_BatchUpdate">
                            <Columns>
                                <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                    <HeaderTemplate>
                                        <dx:ASPxButton runat="server" ID="btnNew" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                            <Image Url="../Content/images/action/add.gif"></Image>
                                            <ClientSideEvents Click="ClientDataGrid_AddNewButtonClick" />
                                        </dx:ASPxButton>
                                    </HeaderTemplate>
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="btnDelete" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                            <Styles>
                                                <Style Paddings-PaddingLeft="1px"></Style>
                                            </Styles>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="NormYearID" VisibleIndex="1" Caption="Năm định mức" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="AreaCode" VisibleIndex="1" Caption="Chi nhánh" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                    <PropertiesComboBox ValueType="System.String">
                                        <Items>
                                            <dx:ListEditItem Value="SGN" Text="TÂN SƠN NHẤT" />
                                            <dx:ListEditItem Value="HAN" Text="NỘI BÀI" />
                                            <dx:ListEditItem Value="DAD" Text="ĐÀ NẴNG" />
                                        </Items>
                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                            <RequiredField IsRequired="true" ErrorText="*" />
                                        </ValidationSettings>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="ExpendType" VisibleIndex="2" Caption="Loại hao phí" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                    <CellStyle Wrap="True"></CellStyle>
                                    <PropertiesComboBox ValueType="System.String">
                                        <Items>
                                            <dx:ListEditItem Value="DM" Text="Định mức SL trực tiếp" />
                                            <dx:ListEditItem Value="DB" Text="Định biên (trực tiếp cố định)" />
                                            <dx:ListEditItem Value="GT" Text="Quản lý phụ trợ (gián tiếp)" />
                                        </Items>
                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                            <RequiredField IsRequired="true" ErrorText="*" />
                                        </ValidationSettings>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="ForPax" VisibleIndex="3" Caption="CB chở khách" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="{0:N2} %">
                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                            <RequiredField IsRequired="true" ErrorText="*" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="ForCargo" VisibleIndex="4" Caption="CB chở hàng" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="{0:N2} %">
                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                            <RequiredField IsRequired="true" ErrorText="*" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="CommonRate" VisibleIndex="5" Caption="Tỷ lệ chung" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="{0:N2} %">
                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                            <RequiredField IsRequired="true" ErrorText="*" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="6" Caption="Diễn giải" Width="70%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <Styles>
                                <AlternatingRow Enabled="true" />
                            </Styles>
                            <Settings ShowFilterRow="true" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                            <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="AreaCode;ExpendType;Description" />
                            <Paddings Padding="0px" />
                            <Border BorderWidth="1px" />
                            <BorderBottom BorderWidth="0px" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsPager Visible="true" PageSize="50" Mode="ShowPager" />
                            <%--   <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="ForPax" ShowInColumn="ForPax" ValueDisplayFormat="{0:N2} %" ShowInGroupFooterColumn="ForPax" DisplayFormat="{0:N2} %" SummaryType="Sum" />
                                <dx:ASPxSummaryItem FieldName="ForCargo" ShowInColumn="ForCargo" ValueDisplayFormat="{0:N2} %" ShowInGroupFooterColumn="ForCargo" DisplayFormat="{0:N2} %" SummaryType="Sum" />
                                <dx:ASPxSummaryItem FieldName="CommonRate" ShowInColumn="CommonRate" ValueDisplayFormat="{0:N2} %" ShowInGroupFooterColumn="CommonRate" DisplayFormat="{0:N2} %" SummaryType="Sum" />
                            </TotalSummary>--%>
                            <SettingsEditing Mode="Batch">
                                <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                            </SettingsEditing>
                            <Templates>
                                <StatusBar>
                                    <dx:ASPxButton runat="server" Text="LƯU THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                        <ClientSideEvents Click="ClientSaveGridButton_Click" />
                                        <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                    </dx:ASPxButton>
                                    &nbsp;
                                        <dx:ASPxButton runat="server" Text="HỦY THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                            <ClientSideEvents Click="ClientCancelEditButton_Click" />
                                            <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                        </dx:ASPxButton>
                                </StatusBar>
                            </Templates>
                            <ClientSideEvents CustomButtonClick="ClientDataGrid_CustomButtonClick"
                                EndCallback="ClientDataGrid_EndCallback" />
                        </dx:ASPxGridView>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="DataGrid"></dx:ASPxGridViewExporter>
</asp:Content>

