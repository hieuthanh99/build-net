<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AutoPricing.aspx.cs" Inherits="Business_RevenueCost_AutoPricing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/AutoPricing.js"></script>
    <script src="../../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../../signalr/hubs"></script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="padding: 10px 10px 10px; font-size: 1.5em; font-weight: bold; margin: 0px 4px 4px; float: right;">
                            <asp:Literal ID="Literal1" runat="server" Text="Auto Pricing" />
                        </div>
                        <div style="float: left; display: flex; flex-direction: row;">
                            <dx:ASPxComboBox runat="server" ID="VersionEditor" ClientInstanceName="ClientVersionEditor" Width="250" OnInit="VersionEditor_Init">
                                <ClientSideEvents ValueChanged="RevCost.ClientVersionEditor_ValueChanged" />
                            </dx:ASPxComboBox>
                            &nbsp;&nbsp;
                            <dx:ASPxButton ID="btnRefresh" runat="server" Text="Refresh" RenderMode="Button" AutoPostBack="false">
                                <Image Url="../../Content/images/refresh.png" Height="16"></Image>
                                <ClientSideEvents Click="RevCost.ClientRefreshButtonClick" />
                            </dx:ASPxButton>
                            &nbsp;&nbsp;
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Create Auto Pricing" RenderMode="Button" AutoPostBack="false">
                                <Image Url="../../Content/images/SpinEditPlus.png"></Image>
                                <ClientSideEvents Click="function(s, e) {{ 
                                   ClientAutoPricingGrid.AddNewRow(); }}" />
                            </dx:ASPxButton>

                            &nbsp;&nbsp;
                            <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Copy" RenderMode="Button" AutoPostBack="false">
                                <Image Url="../../Content/images/duplicate.png"></Image>
                                <ClientSideEvents Click="RevCost.ClientCopyButton_Click" />
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
                <PaneStyle>
                    <BorderBottom BorderWidth="0px" />
                    <BorderLeft BorderWidth="0px" />
                    <BorderRight BorderWidth="0px" />
                </PaneStyle>
                <Panes>
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane Size="250" ScrollBars="Auto">
                                <Panes>
                                    <dx:SplitterPane Name="AutoPricing" Separator-Visible="False">
                                        <PaneStyle>
                                            <BorderBottom BorderWidth="0px" />
                                            <BorderLeft BorderWidth="0px" />
                                            <BorderRight BorderWidth="0px" />
                                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                        </PaneStyle>
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxGridView ID="AutoPricingGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                    ClientInstanceName="ClientAutoPricingGrid" Width="100%" KeyFieldName="AutoPricingID"
                                                    OnCustomUnboundColumnData="AutoPricingGrid_CustomUnboundColumnData"
                                                    OnCustomCallback="AutoPricingGrid_CustomCallback"
                                                    OnBatchUpdate="AutoPricingGrid_BatchUpdate"
                                                    OnCellEditorInitialize="AutoPricingGrid_CellEditorInitialize">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn Name="Checkbox" ShowSelectCheckbox="true" Width="30" VisibleIndex="1" SelectCheckBoxPosition="Left" SelectAllCheckboxMode="AllPages">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </dx:GridViewCommandColumn>

                                                        <dx:GridViewDataComboBoxColumn FieldName="AutoItemID" VisibleIndex="2" Caption="AutoItemID" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesComboBox
                                                                ValueType="System.Int32">
                                                                <ClearButton DisplayMode="OnHover" />
                                                                <ValidationSettings Display="Dynamic">
                                                                    <RequiredField IsRequired="true" ErrorText="This field is required." />
                                                                </ValidationSettings>
                                                            </PropertiesComboBox>
                                                        </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Description" UnboundType="String" ReadOnly="true" VisibleIndex="3" Caption="Description" Width="300" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="AccLevel5" UnboundType="String" ReadOnly="true" VisibleIndex="4" Caption="AccLevel5" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="SQL_P1" UnboundType="String" ReadOnly="true" VisibleIndex="5" Caption="SQL_P1" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Driver" VisibleIndex="6" Caption="Driver" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings>
                                                                    <RequiredField IsRequired="true" ErrorText="This field is required." />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataComboBoxColumn FieldName="Carrier" VisibleIndex="7" Caption="Carrier" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesComboBox ValueType="System.String">
                                                                <Items>
                                                                    <dx:ListEditItem Value="QH" Text="QH" />
                                                                </Items>
                                                                <ClearButton DisplayMode="OnHover" />
                                                                <ValidationSettings Display="Dynamic">
                                                                    <RequiredField IsRequired="false" ErrorText="This field is required." />
                                                                </ValidationSettings>
                                                            </PropertiesComboBox>
                                                        </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataTextColumn FieldName="FleetType" VisibleIndex="8" Caption="FleetType" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataComboBoxColumn FieldName="FltType" VisibleIndex="9" Caption="FltType" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesComboBox ValueType="System.String">
                                                                <Items>
                                                                    <dx:ListEditItem Value="PXR" Text="PXR" />
                                                                    <dx:ListEditItem Value="PXC" Text="PXC" />
                                                                    <dx:ListEditItem Value="FER" Text="FER" />
                                                                </Items>
                                                                <ClearButton DisplayMode="OnHover" />
                                                                <ValidationSettings Display="Dynamic">
                                                                    <RequiredField IsRequired="false" ErrorText="This field is required." />
                                                                </ValidationSettings>
                                                            </PropertiesComboBox>
                                                        </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Route" VisibleIndex="10" Caption="Route" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Airports" VisibleIndex="11" Caption="Airports" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="ACID" VisibleIndex="12" Caption="ACID" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataComboBoxColumn FieldName="Direction" VisibleIndex="13" Caption="Direction" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesComboBox ValueType="System.String">
                                                                <Items>
                                                                    <dx:ListEditItem Value="D" Text="Chuyến bay đi" />
                                                                    <dx:ListEditItem Value="A" Text="Chuyến bay đến" />
                                                                </Items>
                                                                <ClearButton DisplayMode="OnHover" />
                                                                <ValidationSettings Display="Dynamic">
                                                                    <RequiredField IsRequired="false" ErrorText="This field is required." />
                                                                </ValidationSettings>
                                                            </PropertiesComboBox>
                                                        </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataComboBoxColumn FieldName="Network" VisibleIndex="14" Caption="Network" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesComboBox ValueType="System.String">
                                                                <Items>
                                                                    <dx:ListEditItem Value="DOM" Text="Quốc nội" />
                                                                    <dx:ListEditItem Value="INT" Text="Quốc tế" />
                                                                </Items>
                                                                <ClearButton DisplayMode="OnHover" />
                                                                <ValidationSettings Display="Dynamic">
                                                                    <RequiredField IsRequired="false" ErrorText="This field is required." />
                                                                </ValidationSettings>
                                                            </PropertiesComboBox>
                                                        </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataTextColumn FieldName="OriCountry" VisibleIndex="15" Caption="OriCountry" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="DesCountry" VisibleIndex="16" Caption="DesCountry" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Remark" VisibleIndex="17" Caption="Remark" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewCommandColumn VisibleIndex="18" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="false">
                                                            <%-- <HeaderTemplate>
                                                                <dx:ASPxButton runat="server" ID="btnNew" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                                    <Image Url="../../Content/images/action/add.gif"></Image>
                                                                    <ClientSideEvents Click="RevCost.ClientAutoPricingGrid_AddNewButtonClick" />
                                                                </dx:ASPxButton>
                                                            </HeaderTemplate>--%>
                                                            <CustomButtons>
                                                                <dx:GridViewCommandColumnCustomButton ID="btnDelete" Text="Delete" Image-Url="../../Content/images/action/delete.gif">
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
                                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                                    <Paddings Padding="0px" />
                                                    <Border BorderWidth="1px" />
                                                    <BorderBottom BorderWidth="1px" />
                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                    <SettingsResizing ColumnResizeMode="Control" />
                                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                                    <Templates>
                                                        <StatusBar>
                                                            <div style="float: left;">
                                                                <dx:ASPxButton runat="server" Text="Calc Unit" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                                                    <ClientSideEvents Click="RevCost.ClientCalUnitButton_Click" />
                                                                    <Image Url="../../Content/images/if_Calculator_669940.png" Height="16"></Image>
                                                                </dx:ASPxButton>
                                                            </div>
                                                            <div style="float: right;">
                                                                <dx:ASPxButton runat="server" Text="Save Changes" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                                                    <ClientSideEvents Click="function(s,e){{
                                                                         if (ClientAutoPricingGrid.batchEditApi.HasChanges()) {
                                                                                ClientAutoPricingGrid.UpdateEdit();
                                                                            }
                                                                         if (ClientAutoPricingDetailGrid.batchEditApi.HasChanges()) {
                                                                                ClientAutoPricingDetailGrid.UpdateEdit();
                                                                            }
                                                                        }}" />
                                                                    <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                                </dx:ASPxButton>
                                                                &nbsp;
                                                                <dx:ASPxButton runat="server" Text="Revert Changes" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                                                    <ClientSideEvents Click="function(s,e){{
                                                                         if (ClientAutoPricingGrid.batchEditApi.HasChanges()) {
                                                                                ClientAutoPricingGrid.CancelEdit();
                                                                            }
                                                                         if (ClientAutoPricingDetailGrid.batchEditApi.HasChanges()) {
                                                                                ClientAutoPricingDetailGrid.CancelEdit();
                                                                            }
                                                                        }}" />
                                                                    <Image Url="../../Content/images/action/undo.png" Height="16"></Image>
                                                                </dx:ASPxButton>
                                                            </div>
                                                        </StatusBar>
                                                    </Templates>
                                                    <SettingsEditing Mode="Batch">
                                                        <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                                    </SettingsEditing>
                                                    <ClientSideEvents FocusedRowChanged="RevCost.ClientAutoPricingGrid_FocusedRowChanged"
                                                        CustomButtonClick="RevCost.ClientAutoPricingGrid_CustomButtonClick"
                                                        EndCallback="RevCost.ClientAutoPricingGrid_EndCallback" />
                                                </dx:ASPxGridView>
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                        <PaneStyle>
                                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                        </PaneStyle>
                                    </dx:SplitterPane>
                                    <dx:SplitterPane Size="500" Name="AutoPricingDetail" Separator-Visible="False">
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxGridView ID="AutoPricingDetailGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                    ClientInstanceName="ClientAutoPricingDetailGrid" Width="100%" KeyFieldName="AutoPricingDetailID"
                                                    OnCustomCallback="AutoPricingDetailGrid_CustomCallback"
                                                    OnBatchUpdate="AutoPricingDetailGrid_BatchUpdate">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="ForMonth" VisibleIndex="1" Caption="Month" ReadOnly="true" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Curr" VisibleIndex="2" Caption="Curr" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="Amount" VisibleIndex="3" Caption="Amount" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="K" VisibleIndex="4" Caption="K" Width="160" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>

                                                    </Columns>
                                                    <Styles>
                                                        <AlternatingRow Enabled="true" />
                                                    </Styles>
                                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                                    <Paddings Padding="0px" />
                                                    <Border BorderWidth="1px" />
                                                    <BorderBottom BorderWidth="1px" />
                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                    <SettingsResizing ColumnResizeMode="Control" />
                                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                                    <SettingsEditing Mode="Batch">
                                                        <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                                    </SettingsEditing>
                                                    <Templates>
                                                        <StatusBar>
                                                            <div style="float: right">
                                                                <dx:ASPxButton runat="server" Text="Refresh" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                                                    <ClientSideEvents Click="RevCost.RefreshButton_Click" />
                                                                    <Image Url="../../Content/images/action/action_refresh.gif" Height="16"></Image>
                                                                </dx:ASPxButton>

                                                            </div>
                                                        </StatusBar>
                                                    </Templates>
                                                    <ClientSideEvents FocusedRowChanged="RevCost.ClientJobGrid_FocusedRowChanged" />
                                                </dx:ASPxGridView>
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                        <PaneStyle>
                                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                        </PaneStyle>
                                    </dx:SplitterPane>

                                </Panes>
                                <PaneStyle Border-BorderWidth="0">
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                </PaneStyle>
                            </dx:SplitterPane>

                        </Panes>
                    </dx:SplitterPane>
                </Panes>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
    <dx:ASPxPopupControl ID="EditPopup" runat="server" Width="400" Height="100" AllowDragging="True" HeaderText="Copy From" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" ColCount="2" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Copy From" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="CopyVersionEditor" Width="100%" ClientInstanceName="ClientCopyVersionEditor" OnInit="CopyVersionEditor_Init"
                                        OnCallback="CopyVersionEditor_Callback">

                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnACancel" runat="server" Text="Cancel" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ClientEditPopup.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnAplyCopy" runat="server" Text="Copy" AutoPostBack="false" ClientInstanceName="ClientCopyButton" UseSubmitBehavior="true">
                <Image Url="../../Content/images/duplicate.png"></Image>
                <ClientSideEvents Click="RevCost.ClientAplyCopyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxHiddenField ID="AutoPricingHiddenField" runat="server" ClientInstanceName="ClientAutoPricingHiddenField"></dx:ASPxHiddenField>

</asp:Content>

