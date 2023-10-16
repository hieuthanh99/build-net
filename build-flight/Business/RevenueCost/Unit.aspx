<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Unit.aspx.cs" Inherits="Business_RevenueCost_Unit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/Unit.js"></script>
    <script src="../../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../../signalr/hubs"></script>

    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%" FullscreenMode="true">
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="padding: 10px 10px 10px; font-size: 1.5em; font-weight: bold; margin: 0px 4px 4px; float: right;">
                            <asp:Literal ID="Literal1" runat="server" Text="Unit" />
                        </div>
                        <div style="float: left; display: flex; flex-direction: row;">
                            <dx:ASPxSpinEdit runat="server" ID="FilterYearEditor" Width="80" ClientEnabled="true" Caption="Version">
                                <ClientSideEvents ValueChanged="RevCost.ClientFilterYearEditor_ValueChanged" />
                            </dx:ASPxSpinEdit>
                            &nbsp;&nbsp;
                            <dx:ASPxComboBox runat="server" ID="VersionEditor" Width="200" ClientInstanceName="ClientVersionEditor" ClientEnabled="true" OnCallback="VersionEditor_Callback">
                                <ClientSideEvents ValueChanged="RevCost.ClientQueryButton_Click" />
                            </dx:ASPxComboBox>
                            &nbsp;&nbsp;
                            <dx:ASPxButton ID="btnQuery" runat="server" Text="Query" AutoPostBack="false" UseSubmitBehavior="true">
                                <ClientSideEvents Click="RevCost.ClientQueryButton_Click" />
                            </dx:ASPxButton>
                            &nbsp;&nbsp;
                            <dx:ASPxButton ID="btnSyncData" runat="server" Text="Đồng bộ PMS" AutoPostBack="false" UseSubmitBehavior="true">
                                <ClientSideEvents Click="RevCost.ClientSyncDataButton_Click" />
                            </dx:ASPxButton>
                            &nbsp;&nbsp;
                                <dx:ASPxButton ID="btnExport" runat="server" Text="Export Excel" UseSubmitBehavior="true" OnClick="btnExport_Click">
                                </dx:ASPxButton>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle>
                    <BorderTop BorderWidth="0px" />
                    <BorderLeft BorderWidth="0px" />
                    <BorderRight BorderWidth="0px" />
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Separator-Visible="False">
                <Panes>
                    <dx:SplitterPane Name="Unit" Separator-Visible="False">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxGridView ID="UnitGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                    ClientInstanceName="ClientUnitGrid" Width="100%" KeyFieldName="UnitID"
                                    OnCustomCallback="UnitGrid_CustomCallback"
                                    OnBatchUpdate="UnitGrid_BatchUpdate"
                                    OnCellEditorInitialize="UnitGrid_CellEditorInitialize">

                                    <Columns>
                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="110" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                            <HeaderTemplate>
                                                <dx:ASPxButton runat="server" ID="btnNew" Text="Create New" RenderMode="Link" AutoPostBack="false">
                                                    <Image Url="../../Content/images/action/add.gif"></Image>
                                                    <ClientSideEvents Click="RevCost.ClientDataGrid_AddNewButtonClick" />
                                                </dx:ASPxButton>
                                            </HeaderTemplate>
                                            <CustomButtons>

                                                <dx:GridViewCommandColumnCustomButton ID="btnDelete" Text="Delete" Image-Url="../../Content/images/action/delete.gif">
                                                    <Styles>
                                                        <Style Paddings-PaddingLeft="1px"></Style>
                                                    </Styles>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="Item" VisibleIndex="1" Caption="Item" Width="130" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Carrier" VisibleIndex="1" Caption="Carrier" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Flt_Type" VisibleIndex="2" Caption="Flt Type" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Fleet_Type" VisibleIndex="2" Caption="Fleet Type" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Ac_ID" VisibleIndex="3" Caption="Ac Id" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Ori" VisibleIndex="4" Caption="Dep" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Des" VisibleIndex="5" Caption="Arr" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Network" VisibleIndex="6" Caption="Network" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataTextColumn FieldName="Curr" VisibleIndex="7" Caption="Curr" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="CompanyID" VisibleIndex="8" Caption="Company" Width="100" CellStyle-HorizontalAlign="Left">
                                            <PropertiesComboBox
                                                ValueType="System.Int32" DropDownStyle="DropDownList">
                                                <ClearButton DisplayMode="OnHover" />
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="SubaccountID" VisibleIndex="9" Caption="Subaccount" Width="350" CellStyle-HorizontalAlign="Left">
                                            <PropertiesComboBox
                                                ValueType="System.Int32" DropDownStyle="DropDownList">
                                                <ClearButton DisplayMode="OnHover" />
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="M01" VisibleIndex="10" Caption="M01" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5" DisplayFormatInEditMode="true">
                                                <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="M02" VisibleIndex="11" Caption="M02" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5" DisplayFormatInEditMode="true">
                                                <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="M03" VisibleIndex="12" Caption="M03" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5" DisplayFormatInEditMode="true">
                                                <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="M04" VisibleIndex="13" Caption="M04" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5" DisplayFormatInEditMode="true">
                                                <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="M05" VisibleIndex="14" Caption="M05" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5" DisplayFormatInEditMode="true">
                                                <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="M06" VisibleIndex="15" Caption="M06" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5" DisplayFormatInEditMode="true">
                                                <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="M07" VisibleIndex="16" Caption="M07" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5" DisplayFormatInEditMode="true">
                                                <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="M08" VisibleIndex="17" Caption="M08" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5" DisplayFormatInEditMode="true">
                                                <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="M09" VisibleIndex="18" Caption="M09" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5" DisplayFormatInEditMode="true">
                                                <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="M10" VisibleIndex="19" Caption="M10" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5" DisplayFormatInEditMode="true">
                                                <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="M11" VisibleIndex="20" Caption="M11" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5" DisplayFormatInEditMode="true">
                                                <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="M12" VisibleIndex="21" Caption="M12" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5" DisplayFormatInEditMode="true">
                                                <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="K1" VisibleIndex="23" Caption="K1" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5">
                                                <%--  <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>--%>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="K2" VisibleIndex="24" Caption="K2" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5">
                                                <%-- <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>--%>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="K3" VisibleIndex="25" Caption="K3" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5">
                                                <%--  <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>--%>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="K4" VisibleIndex="26" Caption="K4" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5">
                                                <%--  <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>--%>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="K5" VisibleIndex="27" Caption="K5" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5">
                                                <%--   <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>--%>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="K6" VisibleIndex="28" Caption="K6" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5">
                                                <%-- <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>--%>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="K7" VisibleIndex="29" Caption="K7" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5">
                                                <%--  <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>--%>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="K8" VisibleIndex="30" Caption="K8" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5">
                                                <%--    <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>--%>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="K9" VisibleIndex="31" Caption="K9" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5">
                                                <%--   <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>--%>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="K10" VisibleIndex="32" Caption="K10" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5">
                                                <%--  <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>--%>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="K11" VisibleIndex="33" Caption="K11" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5">
                                                <%--  <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>--%>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="K12" VisibleIndex="34" Caption="K12" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesSpinEdit DisplayFormatString="N5">
                                                <%--  <ValidationSettings Display="Dynamic">
                                                    <RequiredField IsRequired="true" ErrorText="This field is required" />
                                                </ValidationSettings>--%>
                                            </PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingRow Enabled="true" />
                                    </Styles>
                                    <SettingsResizing ColumnResizeMode="Control" />
                                    <Settings ShowStatusBar="Visible" ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
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
                                                <ClientSideEvents Click="RevCost.ClientSaveGridButton_Click" />
                                                <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                            </dx:ASPxButton>
                                            &nbsp;
                                                    <dx:ASPxButton runat="server" Text="Revert Changes" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                        <ClientSideEvents Click="RevCost.ClientCancelEditButton_Click" />
                                                        <Image Url="../../Content/images/action/undo.png" Height="16"></Image>
                                                    </dx:ASPxButton>
                                        </StatusBar>
                                    </Templates>
                                    <ClientSideEvents CustomButtonClick="RevCost.ClientDataGrid_CustomButtonClick" />
                                </dx:ASPxGridView>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0">
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                        </PaneStyle>
                    </dx:SplitterPane>
                </Panes>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="UnitGrid"></dx:ASPxGridViewExporter>
</asp:Content>

