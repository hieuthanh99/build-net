<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FerryFlightConfigs.aspx.cs" Inherits="Configs_FerryFlightConfigs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
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
                                <asp:Literal ID="Literal1" runat="server" Text="KHAI BÁO PHÂN BỔ CHI PHÍ CHO CHUYẾN BAY FERRY" />
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
                        <dx:ASPxGridView ID="DataGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true" ClientInstanceName="ClientDataGrid"
                            Width="100%" KeyFieldName="FerryFlightConfigID"
                            OnCustomCallback="DataGrid_CustomCallback"
                            OnCustomDataCallback="DataGrid_CustomDataCallback"
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
                                        <dx:GridViewCommandColumnCustomButton ID="btnDelete" Text="Xóa bỏ" Image-Url="../Content/images/action/delete.gif">
                                            <Styles>
                                                <Style Paddings-PaddingLeft="1px"></Style>
                                            </Styles>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataDateColumn FieldName="EffectiveDateFrom" VisibleIndex="1" Caption="Hiệu lực từ" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                            <RequiredField IsRequired="true" ErrorText="Hiệu lực từ ngày bắt buộc nhập giá trị" />
                                        </ValidationSettings>
                                    </PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn FieldName="EffectiveDateTo" VisibleIndex="2" Caption="Hiệu lực đến" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                                    </PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="InOut" VisibleIndex="3" Caption="Tính chất chuyến bay" Width="180" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                    <PropertiesComboBox>
                                        <Items>
                                            <dx:ListEditItem Value="IN" Text="Chuyến bay Fery đến" />
                                            <dx:ListEditItem Value="OUT" Text="Chuyến bay Fery đi" />
                                        </Items>
                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                            <RequiredField IsRequired="true" ErrorText="Tính chất chuyến bay bắt buộc nhập giá trị" />
                                        </ValidationSettings>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="MTOW" VisibleIndex="4" Caption="Tải trọng MTOW trên" Width="170" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="{0:N2} tấn">
                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                            <RequiredField IsRequired="true" ErrorText="Tải trọng MTOW bắt buộc nhập giá trị" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="Coefficient" VisibleIndex="4" Caption="Tỷ lệ phân bổ" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="{0:N2}">
                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                            <RequiredField IsRequired="true" ErrorText="Tỷ lệ phân bổ bắt buộc nhập giá trị" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="5" Caption="Diễn giải" Width="80%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <Styles>
                                <AlternatingRow Enabled="true" />
                            </Styles>
                            <Settings ShowFilterRow="true" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                            <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="PostionName;Description" />
                            <Paddings Padding="0px" />
                            <Border BorderWidth="1px" />
                            <BorderBottom BorderWidth="0px" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsPager Visible="true" PageSize="50" Mode="ShowPager" />
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
                            <ClientSideEvents CustomButtonClick="ClientDataGrid_CustomButtonClick" />
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

