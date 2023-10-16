<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AOGTime.aspx.cs" Inherits="Configs_AOGTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <script type="text/javascript">
        var currentRowIndex = -1;

        function ClientDataGrid_BatchEditStartEditing(s, e) {
            currentRowIndex = e.visibleIndex;
        }

        function onSelectedVersionIDChanged(s, e) {

            DoCallback(ClientCallback, function () {
                ClientCallback.PerformCallback('GETYEAR|' + s.GetValue());
            });

        }
        function Callback_CallbackComplete(s, e) {
            ClientDataGrid.batchEditApi.SetCellValue(currentRowIndex, "ForYear", e.result);
        }

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
                var cf = confirm("Record will be deleted?");
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
                                <asp:Literal ID="Literal1" runat="server" Text="AOG Time" />
                            </div>
                        </div>
                        <div style="float: right">
                            <%--   <dx:ASPxButton ID="btnNew" runat="server" Text="Thêm mới"  AutoPostBack="false">
                                <Image Url="../Content/Images/action/add.gif"></Image>
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btnEdit" runat="server" Text="Sửa"  AutoPostBack="false">
                                <Image Url="../Content/Images/action/edit.gif"></Image>
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btnDelete" runat="server" Text="Xóa"  AutoPostBack="false">
                                <Image Url="../Content/Images/action/delete.gif"></Image>
                            </dx:ASPxButton>--%>
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
                            ClientInstanceName="ClientDataGrid" Width="100%" KeyFieldName="Id"
                            OnBatchUpdate="DataGrid_BatchUpdate" OnCellEditorInitialize="DataGrid_CellEditorInitialize">
                            <Columns>
                                <dx:GridViewCommandColumn VisibleIndex="0" Width="110" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                    <HeaderTemplate>
                                        <dx:ASPxButton runat="server" ID="btnNew" Text="Create New" RenderMode="Link" AutoPostBack="false">
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
                                <dx:GridViewDataComboBoxColumn FieldName="VersionID" VisibleIndex="1" Caption="Version" Width="200" CellStyle-HorizontalAlign="Left">
                                    <PropertiesComboBox
                                        ValueType="System.Int32" DropDownStyle="DropDownList">
                                        <ClearButton DisplayMode="OnHover" />
                                        <ClientSideEvents ValueChanged="onSelectedVersionIDChanged" />
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="ForYear" VisibleIndex="2" Caption="Year" ReadOnly="true" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit>
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="true" ErrorText="This field is required" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="M01" VisibleIndex="3" Caption="M01" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true">
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="true" ErrorText="This field is required" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="M02" VisibleIndex="4" Caption="M02" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true">
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="true" ErrorText="This field is required" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="M03" VisibleIndex="5" Caption="M03" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true">
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="true" ErrorText="This field is required" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="M04" VisibleIndex="6" Caption="M04" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true">
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="true" ErrorText="This field is required" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="M05" VisibleIndex="7" Caption="M05" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true">
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="true" ErrorText="This field is required" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="M06" VisibleIndex="8" Caption="M06" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true">
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="true" ErrorText="This field is required" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="M07" VisibleIndex="9" Caption="M07" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true">
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="true" ErrorText="This field is required" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="M08" VisibleIndex="10" Caption="M08" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true">
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="true" ErrorText="This field is required" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="M09" VisibleIndex="11" Caption="M09" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true">
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="true" ErrorText="This field is required" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="M10" VisibleIndex="12" Caption="M10" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true">
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="true" ErrorText="This field is required" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="M11" VisibleIndex="13" Caption="M11" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true">
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="true" ErrorText="This field is required" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="M12" VisibleIndex="14" Caption="M12" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                    <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true">
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField IsRequired="true" ErrorText="This field is required" />
                                        </ValidationSettings>
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataTextColumn FieldName="Remark" VisibleIndex="15" Caption="Remark" Width="450" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataColumn UnboundType="String" VisibleIndex="8" Width="40%">
                                    <Settings AllowAutoFilter="False" AllowSort="False" />
                                </dx:GridViewDataColumn>
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
                                    <dx:ASPxButton runat="server" Text="Save Changes" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                        <ClientSideEvents Click="ClientSaveGridButton_Click" />
                                        <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                    </dx:ASPxButton>
                                    &nbsp;
                                        <dx:ASPxButton runat="server" Text="Revert Changes" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                            <ClientSideEvents Click="ClientCancelEditButton_Click" />
                                            <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                        </dx:ASPxButton>
                                </StatusBar>
                            </Templates>
                            <ClientSideEvents CustomButtonClick="ClientDataGrid_CustomButtonClick" 
                                BatchEditStartEditing="ClientDataGrid_BatchEditStartEditing" />
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
    <dx:ASPxCallback ID="Callback" runat="server" ClientInstanceName="ClientCallback" OnCallback="Callback_Callback">
        <ClientSideEvents CallbackComplete="Callback_CallbackComplete" />
    </dx:ASPxCallback>
</asp:Content>

