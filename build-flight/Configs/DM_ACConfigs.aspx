<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_ACConfigs.aspx.cs" Inherits="Configs_DM_ACConfigs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <style>
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
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <script type="text/javascript">

        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "GridPane") {
                ClientDataGrid.SetHeight(e.pane.GetClientHeight());
            }

            if (e.pane.name == "CounterNbrPane") {
                ClientCountersGrid.SetHeight(e.pane.GetClientHeight());
            }
        }

        function ClientDataGrid_AddNewButtonClick(s, e) {
            ClientDataGrid.AddNewRow();
        }

        function ClientDataGrid_FocusedRowChanged(s, e) {
            if (!s.IsDataRow(s.GetFocusedRowIndex()))
                return;
            var key = s.GetRowKey(s.GetFocusedRowIndex());

            ClientHiddenField.Set("ACConfigID", key);

            DoCallback(ClientCountersGrid, function () {
                ClientCountersGrid.PerformCallback('LOAD_COUNTER|' + key);
            });
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

                    DoCallback(ClientDataGrid, function () {
                        ClientDataGrid.PerformCallback('DELETE|' + key);
                    });
                }
            }
        }

        function ClientSaveGridButton_Click(s, e) {
            if (ClientDataGrid.batchEditApi.HasChanges()) {
                ClientDataGrid.UpdateEdit();
            }
            if (ClientCountersGrid.batchEditApi.HasChanges()) {
                ClientCountersGrid.UpdateEdit();
            }

        }

        function ClientCancelEditButton_Click(s, e) {
            if (ClientDataGrid.batchEditApi.HasChanges()) {
                ClientDataGrid.CancelEdit();
            }
            if (ClientCountersGrid.batchEditApi.HasChanges()) {
                ClientCountersGrid.CancelEdit();
            }
        }

        function ClientCountersGrid_CustomButtonClick(s, e) {
            if (e.buttonID == "CountersGridDelete") {
                var cf = confirm("Bạn chắc chắn muốn xóa bản ghi này?");
                if (cf) {
                    if (!s.IsDataRow(s.GetFocusedRowIndex()))
                        return;
                    var key = s.GetRowKey(s.GetFocusedRowIndex());

                    DoCallback(ClientCountersGrid, function () {
                        ClientCountersGrid.PerformCallback('DELETE|' + key);
                    });
                }
            }
        }

        function ClientMasterGrid_AddNewButtonClick(s, e) {
            ClientCountersPopup.Show();
        }

        function ClientAddCountersButton_Click(s, e) {
            if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
                return;
            var aACConfigID = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());

            var keys = [];
            keys = ClientLOVCountersGrid.GetSelectedKeysOnPage();

            if (keys.length == 0) {
                alert("Bạn phải chọn ít nhất một quầy.");
                return;
            }
            if (keys.length > 0) {
                DoCallback(ClientCountersGrid, function () {
                    ClientCountersGrid.PerformCallback("ADD_COUNTERS|" + aACConfigID + "|" + keys.join('|'));
                });
            }

            ClientLOVCountersGrid.UnselectAllRowsOnPage();

            ClientCountersPopup.Hide();
        }

        function ClientCountersPopup_Shown(s, e) {
            if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
                return;
            var key = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());

            DoCallback(ClientLOVCountersGrid, function () {
                ClientLOVCountersGrid.PerformCallback("LOAD_COUNTERS|" + key);
            });
        }
    </script>

    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" SeparatorVisible="false" FullscreenMode="true" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Name="Menu" Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="DANH MỤC CẤU HÌNH TẦU BAY THEO HÃNG" />
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
            <dx:SplitterPane>
                <Panes>
                    <dx:SplitterPane Name="GridPane">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxGridView ID="DataGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                    ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="ACConfigID"
                                    OnCustomCallback="DataGrid_CustomCallback"
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
                                        <dx:GridViewDataComboBoxColumn FieldName="AreaCode" VisibleIndex="1" Caption="Chi nhánh" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesComboBox>
                                                <Items>
                                                    <dx:ListEditItem Value="SGN" Text="SGN" />
                                                    <dx:ListEditItem Value="HAN" Text="HAN" />
                                                    <dx:ListEditItem Value="DAD" Text="DAD" />
                                                </Items>
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="Carrier" VisibleIndex="2" Caption="Hãng" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesComboBox>
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="Network" VisibleIndex="3" Caption="Mạng đường bay" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesComboBox>
                                                <Items>
                                                    <dx:ListEditItem Value="INT" Text="INT" />
                                                    <dx:ListEditItem Value="DOM" Text="DOM" />
                                                </Items>
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="AcID" VisibleIndex="4" Caption="Loại tàu bay" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesComboBox>
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="FltType" VisibleIndex="5" Caption="Nhiệm vụ bay" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesComboBox>
                                                <Items>
                                                    <dx:ListEditItem Value="PAX" Text="PAX" />
                                                    <dx:ListEditItem Value="CGO" Text="CARGO" />
                                                </Items>
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="PaxF" VisibleIndex="6" Caption="Khách F" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="{0:N0}">
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="PaxC" VisibleIndex="7" Caption="Khách C" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="{0:N0}">
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="PaxY" VisibleIndex="8" Caption="Khách Y" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="{0:N0}">
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <%--  <dx:GridViewDataSpinEditColumn FieldName="CountersNbr" VisibleIndex="8" Caption="Số quầy CKI (Theo HĐ)" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="{0:N0}">
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>--%>
                                        <dx:GridViewDataSpinEditColumn FieldName="CountersMin" VisibleIndex="8" Caption="Số quầy tối thiểu" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="{0:N0}">
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="CountersMax" VisibleIndex="8" Caption="Số quầy tối đa" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="{0:N0}">
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="CommonCKI" VisibleIndex="10" Caption="Hệ số Common CKI" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="{0:N2}">
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="11" Caption="Diễn giải" Width="650" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataCheckColumn FieldName="Inactive" VisibleIndex="12" Caption="Ngừng theo dõi" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesCheckEdit>
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesCheckEdit>
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataColumn UnboundType="String" VisibleIndex="13" Width="40%">
                                            <Settings AllowAutoFilter="False" AllowSort="False" />
                                        </dx:GridViewDataColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingRow Enabled="true" />
                                    </Styles>
                                    <Settings ShowFilterRow="true" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="AreaCode;Carrier;Network;AcID;FltType;Description" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="0px" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <SettingsResizing ColumnResizeMode="Control" />
                                    <SettingsPager Visible="true" PageSize="50" Mode="ShowAllRecords" />

                                    <Templates>
                                        <StatusBar>
                                            <div style="float: right">
                                                <dx:ASPxButton runat="server" Text="LƯU THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                                    <ClientSideEvents Click="ClientSaveGridButton_Click" />
                                                    <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                </dx:ASPxButton>
                                                &nbsp;
                                        <dx:ASPxButton runat="server" Text="HỦY THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                            <ClientSideEvents Click="ClientCancelEditButton_Click" />
                                            <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                        </dx:ASPxButton>
                                            </div>
                                        </StatusBar>
                                    </Templates>
                                    <%--EditFormColumnCount="2"--%>
                                    <SettingsEditing Mode="Batch" >
                                        <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                    </SettingsEditing>
                                  <%--  <SettingsPopup>
                                        <EditForm>
                                            <SettingsAdaptivity MaxWidth="800" Mode="Always" VerticalAlign="WindowCenter" />
                                        </EditForm>
                                    </SettingsPopup>
                                    <SettingsCommandButton>
                                        <UpdateButton Text="Lưu thay đổi" RenderMode="Button">
                                            <Image Url="../../Content/images/action/save.png"></Image>
                                        </UpdateButton>
                                        <CancelButton Text="Hủy bỏ" RenderMode="Button">
                                            <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                        </CancelButton>
                                    </SettingsCommandButton>
                                    <EditFormLayoutProperties UseDefaultPaddings="false">
                                        <Styles LayoutItem-Paddings-PaddingBottom="8" />
                                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600"></SettingsAdaptivity>
                                        <Items>
                                            <dx:GridViewLayoutGroup ColCount="2" GroupBoxDecoration="None">
                                                <Items>
                                                    <dx:GridViewColumnLayoutItem ColumnName="AreaCode" />
                                                    <dx:GridViewColumnLayoutItem ColumnName="Carrier" />
                                                    <dx:GridViewColumnLayoutItem ColumnName="Network" />
                                                    <dx:GridViewColumnLayoutItem ColumnName="AcID" />
                                                    <dx:GridViewColumnLayoutItem ColumnName="FltType" />
                                                    <dx:GridViewColumnLayoutItem ColumnName="PaxF" />
                                                    <dx:GridViewColumnLayoutItem ColumnName="PaxC" />
                                                    <dx:GridViewColumnLayoutItem ColumnName="PaxY" />
                                                    <dx:EditModeCommandLayoutItem Width="100%" HorizontalAlign="Right" />
                                                </Items>
                                            </dx:GridViewLayoutGroup>
                                        </Items>
                                    </EditFormLayoutProperties>--%>
                                    <ClientSideEvents CustomButtonClick="ClientDataGrid_CustomButtonClick"
                                        FocusedRowChanged="ClientDataGrid_FocusedRowChanged" />
                                </dx:ASPxGridView>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0px">
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                        </PaneStyle>
                    </dx:SplitterPane>
                    <dx:SplitterPane Name="CounterNbrPane" Size="560">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxGridView ID="CountersGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                    ClientInstanceName="ClientCountersGrid" Width="100%" KeyFieldName="ACCounterID"
                                    OnCustomCallback="CountersGrid_CustomCallback"
                                    OnBatchUpdate="CountersGrid_BatchUpdate"
                                    Caption="KHAI BÁO QUẦY">
                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="90" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                            <HeaderTemplate>
                                                <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                    <Image Url="../Content/images/action/add.gif"></Image>
                                                    <ClientSideEvents Click="ClientMasterGrid_AddNewButtonClick" />
                                                </dx:ASPxButton>
                                            </HeaderTemplate>
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="CountersGridDelete" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                                    <Styles>
                                                        <Style Paddings-PaddingLeft="1px"></Style>
                                                    </Styles>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                        <%-- <dx:GridViewDataComboBoxColumn FieldName="CounterType" VisibleIndex="5" Caption="Loại quầy" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <PropertiesComboBox ValueType="System.String" ValueField="DefValue" TextField="Description">
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>--%>

                                        <dx:GridViewDataColumn FieldName="Description" VisibleIndex="2" Caption="Diễn giải" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataTextColumn FieldName="UnitOfMeasure" VisibleIndex="3" Caption="ĐVT" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="CounterNbr" VisibleIndex="4" Caption="Số lượng quầy" Width="135" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <CellStyle Wrap="True"></CellStyle>
                                            <FooterCellStyle Font-Bold="true"></FooterCellStyle>
                                            <PropertiesSpinEdit DisplayFormatString="N2">
                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingRow Enabled="true" />
                                    </Styles>
                                    <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="false" ShowStatusBar="Hidden" ShowFooter="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="0px" />
                                    <SettingsResizing ColumnResizeMode="Control" />
                                    <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                    <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="Description" />

                                    <SettingsPager Visible="true" PageSize="100" Mode="ShowAllRecords" />
                                    <SettingsEditing Mode="Batch">
                                        <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                    </SettingsEditing>

                                    <ClientSideEvents CustomButtonClick="ClientCountersGrid_CustomButtonClick" />
                                </dx:ASPxGridView>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0px">
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                        </PaneStyle>
                    </dx:SplitterPane>
                </Panes>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="DataGrid"></dx:ASPxGridViewExporter>

    <dx:ASPxPopupControl ID="CountersPopup" runat="server" ClientInstanceName="ClientCountersPopup" Width="400px" Height="350px"
        HeaderText="Thêm loại quầy" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowFooter="true">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxGridView ID="LOVCountersGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientLOVCountersGrid" Width="100%" KeyFieldName="CounterType"
                    OnCustomCallback="LOVCountersGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewCommandColumn ShowSelectCheckbox="true" Width="55" SelectAllCheckboxMode="AllPages"></dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="CounterType" VisibleIndex="1" Caption="Mã loại quầy" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" Caption="Tên loại quầy" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="true" />
                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                    </Styles>
                    <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" VerticalScrollBarStyle="Standard" />
                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="CounterType;Description" />
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Đóng" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientCountersPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Chấp nhận" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientAddCountersButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="ClientCountersPopup_Shown" />
    </dx:ASPxPopupControl>
</asp:Content>

