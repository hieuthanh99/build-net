<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_NormYears.aspx.cs" Inherits="Configs_DM_NormYears" %>

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
        var currentColumnName;
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

                    DoCallback(ClientDataGrid, function () {
                        ClientDataGrid.PerformCallback('DELETE|' + key);
                    });
                }
            }

            if (e.buttonID == "btnCopy") {
                if (!s.IsDataRow(s.GetFocusedRowIndex()))
                    return;

                ClientNormYearPopup.Show();
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

        function OnFocusedRowChanged(s, e) {
            if (!s.IsDataRow(s.GetFocusedRowIndex()))
                return;
            var key = s.GetRowKey(s.GetFocusedRowIndex());

            ClientHiddenField.Set("NormYearID", key);
        }

        function OnBatchEditStartEditing(s, e) {
            currentColumnName = e.focusedColumn.fieldName;
        }

        function OnBatchEditEndEditing(s, e) {
            if (this.currentColumnName != "ForYear")
                return;

            if (e.visibleIndex >= 0) return;

            window.setTimeout(function () {
                s.batchEditApi.SetCellValue(e.visibleIndex, "Status", "WORKING", null, true);
            }, 0);
        }

        function ClientNormYearPopup_Shown(s, e) {
            if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
                return;
            var key = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());

            DoCallback(ClientNormYearGrid, function () {
                ClientNormYearGrid.PerformCallback('LOAD_DATA|' + key);
            });
        }

        function OnCopyButton_Click(s, e) {
            if (!ClientNormYearGrid.IsDataRow(ClientNormYearGrid.GetFocusedRowIndex()))
                return;

            if (!ClientDataGrid.IsDataRow(ClientDataGrid.GetFocusedRowIndex()))
                return;

            var keyFrom = ClientNormYearGrid.GetRowKey(ClientNormYearGrid.GetFocusedRowIndex());

            var keyTo = ClientDataGrid.GetRowKey(ClientDataGrid.GetFocusedRowIndex());

            DoCallback(ClientDataGrid, function () {
                ClientDataGrid.PerformCallback('COPY_DATA|' + keyFrom + "|" + keyTo);
            });
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
                                <asp:Literal ID="Literal1" runat="server" Text="KHAI BÁO NĂM ĐỊNH MỨC" />
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
                        <dx:ASPxGridView ID="DataGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                            ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="NormYearID"
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
                                <dx:GridViewDataSpinEditColumn FieldName="ForYear" VisibleIndex="1" Caption="Năm" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                    <CellStyle Wrap="True"></CellStyle>
                                    <PropertiesSpinEdit>
                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                            <RequiredField IsRequired="true" ErrorText="Năm bắt buộc nhập giá trị" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" Caption="Diễn giải" Width="500" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit>                                        
                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                            <RequiredField IsRequired="true" ErrorText="Diễn giải bắt buộc nhập giá trị" />
                                        </ValidationSettings>
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="Status" VisibleIndex="3" Caption="Trạng thái" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesComboBox>
                                        <Items>
                                            <dx:ListEditItem Text="Đang cập nhật" Value="WORKING" />
                                            <dx:ListEditItem Text="Khóa cập nhật" Value="LOCKED" />
                                        </Items>
                                         <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                            <RequiredField IsRequired="true" ErrorText="Tranjd thái bắt buộc nhập giá trị" />
                                        </ValidationSettings>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <%--  <dx:GridViewDataSpinEditColumn FieldName="TotalSalary" VisibleIndex="4" Caption="Tổng quỹ lương" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals" HeaderStyle-Wrap="True">
                                    <CellStyle Wrap="True"></CellStyle>
                                     <PropertiesSpinEdit DisplayFormatString="{0:N2}"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>--%>
                                <dx:GridViewDataColumn UnboundType="String" VisibleIndex="5" Width="80%">
                                    <Settings AllowAutoFilter="False" AllowSort="False" />
                                </dx:GridViewDataColumn>
                                <dx:GridViewCommandColumn VisibleIndex="6" Width="200" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="false">

                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="btnCopy" Text="Sao chép số liệu từ" Image-Url="../Content/images/duplicate.png">
                                            <Styles>
                                                <Style Paddings-PaddingLeft="1px"></Style>
                                            </Styles>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>

                            </Columns>
                            <Styles>
                                <AlternatingRow Enabled="true" />
                            </Styles>
                            <Settings ShowFilterRow="true" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                            <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="ForYear;Description" />
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
                            <ClientSideEvents CustomButtonClick="ClientDataGrid_CustomButtonClick"
                                BatchEditStartEditing="OnBatchEditStartEditing"
                                BatchEditEndEditing="OnBatchEditEndEditing"
                                FocusedRowChanged="OnFocusedRowChanged" />
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

    <dx:ASPxPopupControl ID="NormYearPopup" runat="server" ClientInstanceName="ClientNormYearPopup" Width="420px" Height="150px" HeaderText="" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowFooter="true">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="NormYearGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientNormYearGrid" Width="100%" KeyFieldName="NormYearID"
                    OnCustomCallback="NormYearGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="ForYear" VisibleIndex="1" Caption="Năm" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" Caption="Diễn giải" Width="100%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="3" Caption="Trạng thái" Width="90" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="true" />
                    </Styles>
                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="350" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                    <Paddings Padding="0px" />
                    <Border BorderWidth="1px" />
                    <BorderBottom BorderWidth="0px" />
                    <SettingsBehavior AllowFocusedRow="True" />
                    <SettingsPager PageSize="100" Mode="ShowAllRecords" />
                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Hủy bỏ" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientNormYearPopup.Hide(); }}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Sao chép" AutoPostBack="false">
                <ClientSideEvents Click="OnCopyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="ClientNormYearPopup_Shown" />
    </dx:ASPxPopupControl>
</asp:Content>

