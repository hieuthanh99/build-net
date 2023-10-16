<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RevenueCostForCompany.aspx.cs" Inherits="Business_RevenueCost_RevenueCostForCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script>
        $('#<%=lbCurrVersion%>')
    </script>
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/RevCostForCompany.js"></script>
    <script src="../../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../../signalr/hubs"></script>
    <style>
        .dxtlControl_Office2010Blue caption {
            font-weight: bold;
            color: #1e395b;
            padding: 3px 3px 5px;
            text-align: left;
            background: #bdd0e7 url(/DXR.axd?r=0_4030-86T5g) repeat-x left top;
            border-bottom: 0 solid #8ba0bc;
            border: 1px solid #8ba0bc;
        }

        caption {
            display: table-caption;
            text-align: -webkit-center;
        }

        .dxtlNode_Office2010Blue td.dxtl, .dxtlAltNode_Office2010Blue td.dxtl, .dxtlSelectedNode_Office2010Blue td.dxtl, .dxtlFocusedNode_Office2010Blue td.dxtl, .dxtlEditFormDisplayNode_Office2010Blue td.dxtl, .dxtlCommandCell_Office2010Blue {
            padding: 4px 6px;
            border-width: 0;
            border: 1px solid #C2D4DA;
            white-space: nowrap;
            overflow: hidden;
        }

        /*.dxtl__B3 {
            border-top-style: none !important;
            border-right-style: none !important;
        }
*/
        /*.dxtl__B1 {
            border-top-style: none !important;
            border-right-style: none !important;
            border-bottom-style: solid !important;
        }*/
    </style>
    <dx:ASPxPanel runat="server" ID="MainPanel" ClientInstanceName="ClientMainPanel" CssClass="main-container" EnableCallbackAnimation="true" Width="100%">
        <PanelCollection>
            <dx:PanelContent>
                <div class="content-pane">
                    <dx:ASPxSplitter ID="contentSplitter" runat="server" ClientInstanceName="ClientContentSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live" ShowCollapseBackwardButton="true" ShowCollapseForwardButton="true">
                        <ClientSideEvents PaneResized="RevCost.ClientContentSplitter_PaneResized"
                            Init="function(s, e) {{ 
                                var pane = ClientContentSplitter.GetPaneByName('StoreDetail');
                                pane.Expand();
                                ClientShowHideStoreDetail.SetText('Hide Store Detail');
                                ClientbtnRoe1.SetVisible(false);
                                ClientbtnUnit1.SetVisible(false);
                            }}" />
                        <Panes>
                            <dx:SplitterPane Size="30" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxButton ID="MenuButton" ClientInstanceName="MenuButton" AllowFocus="false" runat="server" AutoPostBack="False" CssClass="button"
                                            Height="40px" GroupName="Menu">
                                            <ClientSideEvents Click="RevCost.ClientShowMenuButton_Click" />
                                            <Image Url="../../Content/images/SpringboardMenu.png"></Image>
                                        </dx:ASPxButton>
                                        <div class="powered-text">
                                            <%--<asp:Literal ID="Literal1" runat="server" Text="Revenue Cost for Department" />
                                            <dx:ASPxLabel ID="ComapnyName" runat="server" ClientInstanceName="ClientCompanyName" Font-Bold="true" Font-Size="Large"></dx:ASPxLabel>--%>
                                            <dx:ASPxLabel ID="lbTitle" runat="server" EncodeHtml="False" ClientInstanceName="ClientlbTitle" Text="Revenue/Cost for Department/Company" Font-Size="Medium" Font-Bold="true"></dx:ASPxLabel>
                                        </div>
                                        <div style="float: right; margin-top: 6px; margin-right: 10px;">
                                            <dx:ASPxButton ID="btnShowHideStoreDetail" Text="Show/Hide Store Detail" ClientInstanceName="ClientShowHideStoreDetail" Width="178px" AllowFocus="false" runat="server" AutoPostBack="False" CssClass="button">
                                                <ClientSideEvents Click="function(s, e) {{ 
                                                    var pane = ClientContentSplitter.GetPaneByName('StoreDetail');
                                                    if(pane.IsCollapsed()){
                                                        pane.Expand();
                                                        ClientShowHideStoreDetail.SetText('Hide Store Detail');
                                                        ClientbtnRoe1.SetVisible(false);
                                                        ClientbtnUnit1.SetVisible(false);
                                                    }
                                                    else {
                                                        pane.Collapse(pane);
                                                        ClientShowHideStoreDetail.SetText('Show Store Detail');
                                                        ClientbtnRoe1.SetVisible(true);
                                                        ClientbtnUnit1.SetVisible(true);
                                                    }
                                                }}" />
                                                <Image Url="../../Content/images/SpringboardMenu.png" Height="16px" Width="16px"></Image>
                                            </dx:ASPxButton>
                                        </div>
                                        <div style="float: right; margin-top: 8px; margin-right: 415px;">
                                            <%--<dx:ASPxRadioButtonList ID="rdoAmountType" runat="server" ClientVisible="false" ClientInstanceName="ClientAmountType" RepeatDirection="Horizontal" ValueType="System.String">
                                                <Border BorderWidth="0" BorderStyle="None" />
                                                <Paddings Padding="5" />
                                                <CaptionStyle Font-Bold="true"></CaptionStyle>
                                                <RadioButtonStyle Font-Bold="true"></RadioButtonStyle>
                                                <Items>
                                                    <dx:ListEditItem Value="FA" Text="<%$Resources:app.language,TypeFA%>" Selected="true" />
                                                    <dx:ListEditItem Value="AD" Text="<%$Resources:app.language,TypeAD%>" />
                                                    <dx:ListEditItem Value="SA" Text="<%$Resources:app.language,TypeSA%>" />
                                                    <dx:ListEditItem Value="AS" Text="<%$Resources:app.language,TypeAS%>" />
                                                    <%--<dx:ListEditItem Value="AN" Text="Analyze" />
                                                </Items>
                                                <ClientSideEvents ValueChanged="RevCost.ClientAmountType_ValueChanged" />
                                            </dx:ASPxRadioButtonList>--%>
                                            <dx:ASPxComboBox runat="server" ID="cboReviewStatus" AllowNull="true" ClearButton-DisplayMode="OnHover" Caption="Review Status" OnInit="cboReviewStatus_Init">
                                                <ClientSideEvents ValueChanged="RevCost.ClientCboReviewStatus_ValueChanged" />
                                            </dx:ASPxComboBox>
                                        </div>

                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <Separator Visible="False"></Separator>

                                <PaneStyle>
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <BorderLeft BorderWidth="0px"></BorderLeft>
                                    <BorderRight BorderWidth="0px"></BorderRight>
                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                    <Paddings PaddingLeft="0" PaddingRight="1" PaddingBottom="0" PaddingTop="0" />
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Separator-Visible="False">
                                <Separator Visible="False"></Separator>
                                <Panes>
                                    <dx:SplitterPane>
                                        <Panes>
                                            <dx:SplitterPane Separator-Visible="False">
                                                <Separator Visible="False"></Separator>
                                                <Panes>
                                                    <dx:SplitterPane Separator-Visible="False">
                                                        <Panes>
                                                            <dx:SplitterPane Name="CompanyStores" Separator-Visible="False">
                                                                <PaneStyle>
                                                                    <BorderTop BorderWidth="0px"></BorderTop>
                                                                    <BorderLeft BorderWidth="1px"></BorderLeft>
                                                                    <BorderRight BorderWidth="1px"></BorderRight>
                                                                    <BorderBottom BorderWidth="1px"></BorderBottom>
                                                                    <Paddings PaddingLeft="0" PaddingRight="1" PaddingTop="0" PaddingBottom="0" />
                                                                </PaneStyle>
                                                                <ContentCollection>
                                                                    <dx:SplitterContentControl>
                                                                        <dx:ASPxTreeList ID="StoresGrid" runat="server" Width="100%" ClientInstanceName="ClientStoresGrid" EnableCallbacks="true"
                                                                            KeyFieldName="StoreID" ParentFieldName="ParentStoreID" Styles-Header-HorizontalAlign="Center"
                                                                            OnHtmlRowPrepared="StoresGrid_HtmlRowPrepared"
                                                                            OnCustomCallback="StoresGrid_CustomCallback"
                                                                            OnCustomColumnDisplayText="StoresGrid_CustomColumnDisplayText"
                                                                            OnBatchUpdate="StoresGrid_BatchUpdate"
                                                                            OnHtmlDataCellPrepared="StoresGrid_HtmlDataCellPrepared"
                                                                            OnCellEditorInitialize="StoresGrid_CellEditorInitialize">
                                                                            <Border BorderStyle="None" />
                                                                            <ClientSideEvents NodeClick="RevCost.ClientStoresGrid_FocusedNodeChanged"
                                                                                BeginCallback="RevCost.ClientStoresGrid_BeginCallback"
                                                                                EndCallback="RevCost.ClientStoresGrid_EndCallback"
                                                                                Init="RevCost.ClientStoresGrid_Init"
                                                                                BatchEditStartEditing="RevCost.ClientStoresGrid_BatchEditStartEditing" />
                                                                            <Styles>
                                                                                <AlternatingNode Enabled="True"></AlternatingNode>
                                                                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                                            </Styles>
                                                                            <SettingsEditing Mode="Batch">
                                                                                <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                                                            </SettingsEditing>
                                                                            <Settings ShowTreeLines="true" GridLines="Vertical" VerticalScrollBarMode="Auto" ScrollableHeight="250" HorizontalScrollBarMode="Auto" />
                                                                            <Paddings Padding="0px" />
                                                                            <Border BorderWidth="1px" />
                                                                            <BorderBottom BorderWidth="1px" />
                                                                            <SettingsBehavior AllowFocusedNode="true" AllowSort="false" AutoExpandAllNodes="true" />
                                                                            <SettingsResizing ColumnResizeMode="Control" />
                                                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                                                                            <Border BorderStyle="Solid" />
                                                                            <Columns>
                                                                                <dx:TreeListDataColumn ReadOnly="true" FieldName="StoreId" VisibleIndex="0" Caption="StoreId" Width="80" HeaderStyle-Wrap="True" Visible="False">
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                    <EditFormSettings Visible="False" />
                                                                                </dx:TreeListDataColumn>
                                                                                <dx:TreeListDataColumn ReadOnly="true" FieldName="Description" VisibleIndex="1" Width="300" Caption="Description" HeaderStyle-Wrap="True">
                                                                                    <DataCellTemplate>
                                                                                        <asp:Label runat="server" Font-Bold='<%# Eval("Calculation")!=null && Eval("Calculation").ToString().Equals("SUM")? true: false%>' Text='<%# (Eval("Sorting")!=null? Eval("Sorting").ToString().Trim():"") +". "+ Eval("Description") %>'></asp:Label>
                                                                                    </DataCellTemplate>
                                                                                    <EditFormSettings Visible="False" />
                                                                                </dx:TreeListDataColumn>
                                                                                <%--<dx:TreeListDataColumn FieldName="Description" VisibleIndex="1" Width="300" Caption="Description" HeaderStyle-Wrap="True">
                                                                                    <DataCellTemplate>
                                                                                        <asp:Label runat="server" Font-Bold='<%# Eval("Calculation").ToString().Equals("SUM")? true: false%>' Text='<%# Eval("Sorting").ToString().Trim() +". "+ Eval("Description") %>'></asp:Label>
                                                                                    </DataCellTemplate>
                                                                                </dx:TreeListDataColumn>--%>

                                                                                <dx:TreeListDataColumn ReadOnly="true" FieldName="Sorting" VisibleIndex="3" Caption="Sorting <br/>(1)" Width="80" HeaderStyle-Wrap="True">
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                    <EditFormSettings Visible="False" />
                                                                                </dx:TreeListDataColumn>
                                                                                <dx:TreeListDataColumn ReadOnly="true" ShowEditorInBatchEditMode="false" FieldName="Calculation" VisibleIndex="4" Caption="Calc <br/>(3)" Width="50" HeaderStyle-Wrap="True">
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                </dx:TreeListDataColumn>
                                                                                <dx:TreeListDataColumn ReadOnly="true" FieldName="IsOK" VisibleIndex="5" Caption="OK? <br/>(4)" Width="35" HeaderStyle-HorizontalAlign="Center">
                                                                                    <DataCellTemplate>
                                                                                        <dx:ASPxCheckBox ID="StoreIsOK" runat="server" OnInit="StoreIsOK_Init" Checked='<%# Eval("IsOK")!=null? Eval("IsOK"): false  %>' CssClass="checkbok-grid">
                                                                                            <RootStyle Paddings-Padding="0"></RootStyle>
                                                                                        </dx:ASPxCheckBox>
                                                                                    </DataCellTemplate>
                                                                                    <EditFormSettings Visible="False" />
                                                                                </dx:TreeListDataColumn>
                                                                                <%-- <dx:TreeListDataColumn ReadOnly="true" FieldName="Curr" VisibleIndex="6" Caption="Curr" Width="60" HeaderStyle-Wrap="True">
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                    <EditFormSettings Visible="False" />
                                                                                </dx:TreeListDataColumn>--%>
                                                                                <dx:TreeListSpinEditColumn FieldName="OutStandards" VisibleIndex="7" Caption="Out Standard <br/> (ĐBHĐ)" Width="145" HeaderStyle-Wrap="True">
                                                                                    <PropertiesSpinEdit DisplayFormatString="{0:N2}" DisplayFormatInEditMode="false" SpinButtons-ShowIncrementButtons="false" AllowMouseWheel="false">
                                                                                    </PropertiesSpinEdit>
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                </dx:TreeListSpinEditColumn>
                                                                                <dx:TreeListSpinEditColumn FieldName="Decentralization" VisibleIndex="8" Caption="Decentralization <br/> (Nghiệp vụ)" Width="145" HeaderStyle-Wrap="True">
                                                                                    <PropertiesSpinEdit DisplayFormatString="{0:N2}" DisplayFormatInEditMode="false" SpinButtons-ShowIncrementButtons="false" AllowMouseWheel="false">
                                                                                    </PropertiesSpinEdit>
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                </dx:TreeListSpinEditColumn>
                                                                                <dx:TreeListSpinEditColumn FieldName="Amount" VisibleIndex="9" ReadOnly="true" Caption="Amount (Tổng)" Width="145" HeaderStyle-Wrap="True">
                                                                                    <PropertiesSpinEdit DisplayFormatString="{0:N2}" DisplayFormatInEditMode="false" SpinButtons-ShowIncrementButtons="false" AllowMouseWheel="false"></PropertiesSpinEdit>
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                    <EditFormSettings Visible="False" />
                                                                                </dx:TreeListSpinEditColumn>
                                                                                <dx:TreeListSpinEditColumn FieldName="AmountVND" VisibleIndex="10" ReadOnly="true" Caption="Amount VND <br/> (Quy VND)" Width="145" HeaderStyle-Wrap="True">
                                                                                    <PropertiesSpinEdit DisplayFormatString="{0:N0}" DisplayFormatInEditMode="false" SpinButtons-ShowIncrementButtons="false" AllowMouseWheel="false">
                                                                                    </PropertiesSpinEdit>
                                                                                    <EditFormSettings Visible="False" />
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                </dx:TreeListSpinEditColumn>
                                                                                <dx:TreeListComboBoxColumn FieldName="ReviewStatus" VisibleIndex="11" Caption="<%$Resources:app.language,ReviewStatus%>" Width="80" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                    <PropertiesComboBox
                                                                                        ValueType="System.String" DropDownStyle="DropDownList">
                                                                                        <ClearButton DisplayMode="Never" />
                                                                                    </PropertiesComboBox>
                                                                                </dx:TreeListComboBoxColumn>
                                                                                <dx:TreeListSpinEditColumn ReadOnly="true" FieldName="Percentage01" VisibleIndex="16" Caption="%Version Base 01" Width="150" HeaderStyle-Wrap="True">
                                                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                    <EditFormSettings Visible="False" />
                                                                                </dx:TreeListSpinEditColumn>
                                                                                <dx:TreeListSpinEditColumn ReadOnly="true" FieldName="Percentage02" VisibleIndex="23" Caption="%Version Base 02" Width="150" HeaderStyle-Wrap="True">
                                                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                    <EditFormSettings Visible="False" />
                                                                                </dx:TreeListSpinEditColumn>
                                                                                <dx:TreeListSpinEditColumn ReadOnly="true" FieldName="Percentage03" VisibleIndex="30" Caption="%Version Base 03" Width="150" HeaderStyle-Wrap="True">
                                                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                    <EditFormSettings Visible="False" />
                                                                                </dx:TreeListSpinEditColumn>
                                                                                <dx:TreeListSpinEditColumn ReadOnly="true" FieldName="Percentage04" VisibleIndex="30" Caption="%Version Base 04" Width="150" HeaderStyle-Wrap="True">
                                                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                    <EditFormSettings Visible="False" />
                                                                                </dx:TreeListSpinEditColumn>
                                                                                <dx:TreeListSpinEditColumn ReadOnly="true" FieldName="Percentage05" VisibleIndex="30" Caption="%Version Base 05" Width="150" HeaderStyle-Wrap="True">
                                                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                    <EditFormSettings Visible="False" />
                                                                                </dx:TreeListSpinEditColumn>

                                                                                <dx:TreeListComboBoxColumn FieldName="ApproveStatus" VisibleIndex="35" Caption="<%$Resources:app.language,ApproveStatus%>" Width="120" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                    <PropertiesComboBox
                                                                                        ValueType="System.String" DropDownStyle="DropDownList">
                                                                                        <ClearButton DisplayMode="Never" />
                                                                                    </PropertiesComboBox>
                                                                                </dx:TreeListComboBoxColumn>
                                                                                <dx:TreeListDataColumn ReadOnly="true" FieldName="Status" VisibleIndex="36" Caption="Status" Width="80" HeaderStyle-Wrap="True">
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                    <EditFormSettings Visible="False" />
                                                                                </dx:TreeListDataColumn>
                                                                                <dx:TreeListDataColumn ReadOnly="true" Visible="false" FieldName="OutAllowUpdate" VisibleIndex="36" Caption="Status" Width="80" HeaderStyle-Wrap="True">
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                </dx:TreeListDataColumn>
                                                                                <dx:TreeListDataColumn ReadOnly="true" Visible="false" FieldName="DecAllowUpdate" VisibleIndex="36" Caption="Status" Width="80" HeaderStyle-Wrap="True">
                                                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                                                </dx:TreeListDataColumn>
                                                                            </Columns>
                                                                            <Styles>
                                                                                <%--  <AlternatingRow Enabled="True"></AlternatingRow>--%>
                                                                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                                            </Styles>
                                                                            <Paddings Padding="0px" />
                                                                            <Border BorderWidth="1px" />
                                                                            <BorderBottom BorderWidth="1px" />
                                                                        </dx:ASPxTreeList>
                                                                    </dx:SplitterContentControl>
                                                                </ContentCollection>
                                                            </dx:SplitterPane>
                                                            <dx:SplitterPane Size="45" Separator-Visible="False">
                                                                <ContentCollection>
                                                                    <dx:SplitterContentControl>
                                                                        <dx:ASPxButton ID="btExpandAll" runat="server" Text="Expand All" RenderMode="Button" AutoPostBack="false">
                                                                            <ClientSideEvents Click="RevCost.ClientExpandAll_Click" />
                                                                        </dx:ASPxButton>
                                                                        <dx:ASPxButton ID="btlCollapseAll" runat="server" Text="Collapse All" RenderMode="Button" AutoPostBack="false">
                                                                            <ClientSideEvents Click="RevCost.ClientCollapseAll_Click" />
                                                                        </dx:ASPxButton>
                                                                        <dx:ASPxButton ID="btnRefreshSrore" runat="server" Text="<%$Resources:app.language,Refresh%>" RenderMode="Button" AutoPostBack="false">
                                                                            <ClientSideEvents Click="RevCost.ClientRefreshSrore_Click" />
                                                                            <Image Url="../../Content/images/action/action_refresh.gif" Height="16"></Image>
                                                                        </dx:ASPxButton>
                                                                        <dx:ASPxButton ID="btnSaveChangesStore" runat="server" Text="Save Store" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                            <ClientSideEvents Click="RevCost.ClientSaveStore_Click" />
                                                                            <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                                        </dx:ASPxButton>
                                                                        <%-- <dx:ASPxButton ID="btnSaveChangesStore" runat="server" Text="Save Stores" RenderMode="Button" AutoPostBack="false">
                                                                                <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                                            </dx:ASPxButton>--%>
                                                                        <dx:ASPxButton ID="btnCalculateStore" runat="server" Text="<%$Resources:app.language,Calculate%>" RenderMode="Button" AutoPostBack="false">
                                                                            <ClientSideEvents Click="RevCost.ClientCalculateStore_Click" />
                                                                            <Image Url="../../Content/images/if_Calculator_669940.png" Height="16"></Image>
                                                                        </dx:ASPxButton>
                                                                        <dx:ASPxButton ID="btnAutoItem" runat="server" Text="<%$Resources:app.language,AutoItem%>" RenderMode="Button" AutoPostBack="false">
                                                                            <ClientSideEvents Click="RevCost.ClientAutoItem_Click" />
                                                                            <Image Url="../../Content/images/if_Calculator_669940.png" Height="16"></Image>
                                                                        </dx:ASPxButton>
                                                                        <dx:ASPxButton ID="btnAutoAllItem" runat="server" Text="<%$Resources:app.language,AutoAllItem%>" RenderMode="Button" AutoPostBack="false">
                                                                            <ClientSideEvents Click="RevCost.ClientAutoAllItem_Click" />
                                                                            <Image Url="../../Content/images/if_Calculator_669940.png" Height="16"></Image>
                                                                        </dx:ASPxButton>
                                                                        <dx:ASPxButton ID="btnChangeCompanyStore" runat="server" Text="<%$Resources:app.language,ChangeCompany%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                            <ClientSideEvents Click="RevCost.ClientChangeCompanyButton_Click" />
                                                                            <Image Url="../../Content/images/relationship.png"></Image>
                                                                        </dx:ASPxButton>
                                                                        <%--  <dx:ASPxButton ID="btnQuantity" runat="server" Text="<%$Resources:app.language,Quantity%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                            <Image Url="../../Content/images/if_growth_1312842.png"></Image>
                                                                        </dx:ASPxButton>--%>

                                                                        <%--   <dx:ASPxButton ID="btnImportRevCost" runat="server" Text="<%$Resources:app.language,ImportFileDetail%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                            <Image Url="../../Content/images/if_growth_1312842.png"></Image>
                                                                            <ClientSideEvents Click="RevCost.ClientImportRevCostButton_Click" />
                                                                        </dx:ASPxButton>--%>
                                                                        <dx:ASPxButton ID="btnPrintStore" runat="server" Text="<%$Resources:app.language,Print%>" RenderMode="Button" AutoPostBack="false">
                                                                            <Image Url="~/Content/images/if_simpline_5_2305642.png" Height="16"></Image>

                                                                            <ClientSideEvents Click="RevCost.ClientbtnPrintStoreButton_Click" />
                                                                        </dx:ASPxButton>

                                                                        <dx:ASPxButton ID="btnRoe1" ClientInstanceName="ClientbtnRoe1" runat="server" Text="ROE" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                                            <ClientSideEvents Click="RevCost.ClientViewRoe_Click" />
                                                                        </dx:ASPxButton>
                                                                        <dx:ASPxButton ID="btnUnit1" runat="server" ClientInstanceName="ClientbtnUnit1" Text="<%$Resources:app.language,Unit%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                            <%--<Image Url="../../Content/images/if_growth_1312842.png"></Image>--%>
                                                                            <ClientSideEvents Click="RevCost.ClientbtnUnitButton_Click" />
                                                                        </dx:ASPxButton>
                                                                    </dx:SplitterContentControl>
                                                                </ContentCollection>
                                                                <PaneStyle>

                                                                    <Paddings PaddingLeft="10" PaddingRight="1" />
                                                                </PaneStyle>
                                                            </dx:SplitterPane>
                                                        </Panes>

                                                        <Separator Visible="False"></Separator>

                                                    </dx:SplitterPane>
                                                    <dx:SplitterPane Size="475" Name="StoreDetail">
                                                        <ContentCollection>
                                                            <dx:SplitterContentControl>
                                                                <dx:ASPxGridView ID="StoreDetailsGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                                    ClientInstanceName="ClientStoreDetailsGrid" Width="100%" KeyFieldName="StoreDetailID"
                                                                    OnCustomCallback="StoreDetailsGrid_CustomCallback"
                                                                    OnBatchUpdate="StoreDetailsGrid_BatchUpdate"
                                                                    OnRowValidating="StoreDetailsGrid_RowValidating"
                                                                    OnCellEditorInitialize="StoreDetailsGrid_CellEditorInitialize"
                                                                    OnHtmlRowPrepared="StoreDetailsGrid_HtmlRowPrepared">
                                                                    <Columns>
                                                                        <dx:GridViewDataTextColumn FieldName="RevCostMonth" VisibleIndex="0" ReadOnly="true" Caption="#" Width="30" FixedStyle="Left" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <Settings AutoFilterCondition="Contains"></Settings>
                                                                            <EditFormSettings Visible="False" />
                                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataSpinEditColumn FieldName="OutStandards" VisibleIndex="3" Width="145" Caption="Out Standard <br/> (ĐBHĐ)" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true" MinValue="0">
                                                                                <SpinButtons ShowIncrementButtons="false" ShowLargeIncrementButtons="false"></SpinButtons>
                                                                                <Style HorizontalAlign="Right"></Style>
                                                                            </PropertiesSpinEdit>
                                                                            <Settings AutoFilterCondition="Contains"></Settings>
                                                                            <EditCellStyle HorizontalAlign="Right"></EditCellStyle>
                                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                                        </dx:GridViewDataSpinEditColumn>
                                                                        <dx:GridViewDataSpinEditColumn FieldName="Decentralization" VisibleIndex="4" Width="145" Caption="Decentralization <br/> (Nghiệp vụ)" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true" MinValue="0">
                                                                                <SpinButtons ShowIncrementButtons="false" ShowLargeIncrementButtons="false"></SpinButtons>
                                                                                <Style HorizontalAlign="Right"></Style>
                                                                            </PropertiesSpinEdit>
                                                                            <Settings AutoFilterCondition="Contains"></Settings>
                                                                            <EditCellStyle HorizontalAlign="Right"></EditCellStyle>
                                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                                        </dx:GridViewDataSpinEditColumn>
                                                                        <dx:GridViewDataSpinEditColumn FieldName="Amount" VisibleIndex="5" Width="145" Caption="Amount (Tổng)" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <PropertiesSpinEdit DisplayFormatString="N2" DisplayFormatInEditMode="true" MinValue="0">
                                                                                <SpinButtons ShowIncrementButtons="false" ShowLargeIncrementButtons="false"></SpinButtons>
                                                                                <Style HorizontalAlign="Right"></Style>
                                                                            </PropertiesSpinEdit>
                                                                            <EditFormSettings Visible="False" />
                                                                            <Settings AutoFilterCondition="Contains"></Settings>
                                                                            <EditCellStyle HorizontalAlign="Right"></EditCellStyle>
                                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                                        </dx:GridViewDataSpinEditColumn>
                                                                        <%--<dx:GridViewDataSpinEditColumn FieldName="AmountVND" VisibleIndex="6" Width="145" ReadOnly="true" Caption="Amount VND <br/> (Quy VND)" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <PropertiesSpinEdit DisplayFormatString="N0" DisplayFormatInEditMode="true" MinValue="0">
                                                                                <SpinButtons ShowIncrementButtons="false" ShowLargeIncrementButtons="false"></SpinButtons>
                                                                                <Style HorizontalAlign="Right"></Style>
                                                                            </PropertiesSpinEdit>
                                                                            <EditFormSettings Visible="False" />
                                                                            <Settings AutoFilterCondition="Contains"></Settings>
                                                                            <EditCellStyle HorizontalAlign="Right"></EditCellStyle>
                                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                            <CellStyle HorizontalAlign="Right"></CellStyle>
                                                                        </dx:GridViewDataSpinEditColumn>--%>
                                                                        <%-- <dx:GridViewDataCheckColumn FieldName="IsOK" VisibleIndex="14" Caption="OK?" Width="40" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                            <Settings AutoFilterCondition="Contains"></Settings>
                                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataCheckColumn>--%>
                                                                    </Columns>
                                                                    <Styles>
                                                                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                                    </Styles>
                                                                    <Settings ShowTitlePanel="true" ShowStatusBar="Visible" VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" />
                                                                    <SettingsEditing Mode="Batch">
                                                                        <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                                                    </SettingsEditing>
                                                                    <Paddings Padding="0px" />
                                                                    <Border BorderWidth="1px" />
                                                                    <BorderBottom BorderWidth="1px" />
                                                                    <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                                                    <SettingsResizing ColumnResizeMode="Control" />
                                                                    <Templates>
                                                                        <StatusBar>
                                                                            <dx:ASPxButton ID="btnSaveStoreDetail" ClientInstanceName="ClientbtnSaveStoreDetail" runat="server" Text="Save Store Details" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                                                <ClientSideEvents Click="RevCost.ClientSaveStoreDetail_Click" />
                                                                                <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                                            </dx:ASPxButton>
                                                                            <dx:ASPxButton ID="btnRoe" ClientInstanceName="ClientbtnRoe" runat="server" Text="ROE" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                                                <ClientSideEvents Click="RevCost.ClientViewRoe_Click" />
                                                                            </dx:ASPxButton>
                                                                            <dx:ASPxButton ID="btnUnit" runat="server" ClientInstanceName="ClientbtnUnit" Text="<%$Resources:app.language,Unit%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                                <%--<Image Url="../../Content/images/if_growth_1312842.png"></Image>--%>
                                                                                <ClientSideEvents Click="RevCost.ClientbtnUnitButton_Click" />
                                                                            </dx:ASPxButton>
                                                                        </StatusBar>
                                                                        <TitlePanel>
                                                                            <div style="float: left">
                                                                                <dx:ASPxLabel runat="server" Font-Bold="true" Text="<%$Resources:app.language,StoreDetails%>"></dx:ASPxLabel>
                                                                            </div>
                                                                            <dx:ASPxRoundPanel ID="AllocateRoundPanel" runat="server" HeaderStyle-HorizontalAlign="Left" Collapsed="true" HeaderText="Allocate by Quarter/Year" ShowCollapseButton="true" Width="100%">
                                                                                <ClientSideEvents CollapsedChanged="RevCost.ClientAllocate_CollapsedChanged" />
                                                                                <ContentPaddings Padding="0" />
                                                                                <PanelCollection>
                                                                                    <dx:PanelContent>
                                                                                        <dx:ASPxFormLayout ID="AllocateForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                                                                                            AlignItemCaptionsInAllGroups="true" Width="100%" ColCount="5">
                                                                                            <Paddings Padding="0" />
                                                                                            <Styles>
                                                                                                <LayoutItem>
                                                                                                    <Paddings PaddingLeft="0px" PaddingTop="1px" PaddingBottom="1px" />
                                                                                                </LayoutItem>
                                                                                            </Styles>
                                                                                            <Items>
                                                                                                <dx:LayoutItem ShowCaption="False">
                                                                                                    <LayoutItemNestedControlCollection>
                                                                                                        <dx:LayoutItemNestedControlContainer>
                                                                                                            <dx:ASPxComboBox ID="StoreDetailTypeOfAmount" runat="server" ValueType="System.String" Caption="Type Of Amount" Width="115" CaptionSettings-Position="Top" ClientInstanceName="ClientStoreDetailTypeOfAmount">
                                                                                                                <Items>
                                                                                                                    <dx:ListEditItem Text="Outstandard" Value="Out Standard" Selected="true" />
                                                                                                                    <dx:ListEditItem Text="Decentralization" Value="Decentralization" />
                                                                                                                </Items>
                                                                                                            </dx:ASPxComboBox>
                                                                                                        </dx:LayoutItemNestedControlContainer>
                                                                                                    </LayoutItemNestedControlCollection>
                                                                                                </dx:LayoutItem>
                                                                                                <dx:LayoutItem ShowCaption="False">
                                                                                                    <LayoutItemNestedControlCollection>
                                                                                                        <dx:LayoutItemNestedControlContainer>
                                                                                                            <dx:ASPxSpinEdit runat="server" ID="StoreDetailMonthFrom" Width="40" HorizontalAlign="Right" Caption="From" CaptionSettings-Position="Top" MaxValue="12" MinValue="1" NumberType="Integer" ClientInstanceName="ClientStoreDetailMonthFrom">
                                                                                                                <SpinButtons ShowIncrementButtons="false" ShowLargeIncrementButtons="false"></SpinButtons>
                                                                                                            </dx:ASPxSpinEdit>
                                                                                                        </dx:LayoutItemNestedControlContainer>
                                                                                                    </LayoutItemNestedControlCollection>
                                                                                                </dx:LayoutItem>
                                                                                                <dx:LayoutItem ShowCaption="False">
                                                                                                    <LayoutItemNestedControlCollection>
                                                                                                        <dx:LayoutItemNestedControlContainer>
                                                                                                            <dx:ASPxSpinEdit runat="server" ID="StoreDetailMonthTo" Width="40" HorizontalAlign="Right" Caption="To" CaptionSettings-Position="Top" MaxValue="12" MinValue="1" NumberType="Integer" ClientInstanceName="ClientStoreDetailMonthTo">
                                                                                                                <SpinButtons ShowIncrementButtons="false" ShowLargeIncrementButtons="false"></SpinButtons>
                                                                                                            </dx:ASPxSpinEdit>
                                                                                                        </dx:LayoutItemNestedControlContainer>
                                                                                                    </LayoutItemNestedControlCollection>
                                                                                                </dx:LayoutItem>
                                                                                                <dx:LayoutItem ShowCaption="False">
                                                                                                    <LayoutItemNestedControlCollection>
                                                                                                        <dx:LayoutItemNestedControlContainer>
                                                                                                            <dx:ASPxSpinEdit runat="server" ID="StoreDetailAmount" Width="150" DisplayFormatString="N2" HorizontalAlign="Right" Caption="Amount" CaptionSettings-Position="Top" ClientInstanceName="ClientStoreDetailAmount">
                                                                                                                <SpinButtons ShowIncrementButtons="false" ShowLargeIncrementButtons="false"></SpinButtons>
                                                                                                            </dx:ASPxSpinEdit>
                                                                                                        </dx:LayoutItemNestedControlContainer>
                                                                                                    </LayoutItemNestedControlCollection>
                                                                                                </dx:LayoutItem>
                                                                                                <dx:LayoutItem ShowCaption="False">
                                                                                                    <LayoutItemNestedControlCollection>
                                                                                                        <dx:LayoutItemNestedControlContainer>
                                                                                                        </dx:LayoutItemNestedControlContainer>
                                                                                                    </LayoutItemNestedControlCollection>
                                                                                                </dx:LayoutItem>
                                                                                                <dx:LayoutItem ShowCaption="False" ColSpan="5" VerticalAlign="Middle" HorizontalAlign="Left" Paddings-PaddingTop="5">
                                                                                                    <LayoutItemNestedControlCollection>
                                                                                                        <dx:LayoutItemNestedControlContainer>
                                                                                                            <dx:ASPxButton ID="ASPxButton1" ClientInstanceName="ClientAllocateApply" runat="server" Text="<%$Resources:app.language,Apply%>" AutoPostBack="false">
                                                                                                                <ClientSideEvents Click="RevCost.ClientAllocateApply_Click" />
                                                                                                            </dx:ASPxButton>
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
                                                                                    </dx:PanelContent>
                                                                                </PanelCollection>
                                                                            </dx:ASPxRoundPanel>
                                                                        </TitlePanel>
                                                                    </Templates>
                                                                    <ClientSideEvents
                                                                        BeginCallback="RevCost.ClientStoreDetailsGrid_BeginCallback"
                                                                        EndCallback="RevCost.ClientStoreDetailsGrid_EndCallback" />
                                                                </dx:ASPxGridView>
                                                            </dx:SplitterContentControl>
                                                        </ContentCollection>
                                                        <Separator Visible="False"></Separator>

                                                        <PaneStyle>
                                                            <BorderTop BorderWidth="0px"></BorderTop>
                                                            <BorderLeft BorderWidth="0px"></BorderLeft>
                                                            <BorderRight BorderWidth="0px"></BorderRight>
                                                            <BorderBottom BorderWidth="0px"></BorderBottom>
                                                            <Paddings PaddingLeft="2" PaddingRight="0" PaddingBottom="0" PaddingTop="0" />
                                                        </PaneStyle>
                                                    </dx:SplitterPane>
                                                </Panes>
                                                <ContentCollection>
                                                    <dx:SplitterContentControl runat="server"></dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                            <dx:SplitterPane Size="190">
                                                <Panes>
                                                    <dx:SplitterPane Name="StoreNote" Separator-Visible="False" ScrollBars="Auto">
                                                        <ContentCollection>
                                                            <dx:SplitterContentControl>
                                                                <dx:ASPxFormLayout ID="NoteForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                                                                    AlignItemCaptionsInAllGroups="true" Width="100%">
                                                                    <Paddings Padding="0" />
                                                                    <Styles>
                                                                        <LayoutGroupBox>
                                                                            <Caption CssClass="layoutGroupBoxCaption"></Caption>
                                                                        </LayoutGroupBox>

                                                                        <LayoutItem>
                                                                            <Paddings PaddingLeft="0px" PaddingTop="1px" PaddingBottom="1px" />
                                                                        </LayoutItem>
                                                                    </Styles>
                                                                    <Items>
                                                                        <dx:LayoutItem Caption="Store Note" CaptionStyle-Font-Bold="true">
                                                                            <LayoutItemNestedControlCollection>
                                                                                <dx:LayoutItemNestedControlContainer>
                                                                                    <dx:ASPxMemo ID="StoreNoteEditor" runat="server" Width="100%" ClientInstanceName="ClientStoreNoteEditor" Rows="3">
                                                                                        <ClientSideEvents KeyDown="RevCost.ClientStoreNoteEditor_KeyDown"
                                                                                            KeyPress="RevCost.ClientStoreNoteEditor_KeyPress"
                                                                                            TextChanged="RevCost.ClientStoreNoteEditor_TextChanged" />
                                                                                    </dx:ASPxMemo>
                                                                                </dx:LayoutItemNestedControlContainer>
                                                                            </LayoutItemNestedControlCollection>

                                                                            <CaptionStyle Font-Bold="True"></CaptionStyle>
                                                                        </dx:LayoutItem>
                                                                        <dx:LayoutItem Caption="Review Note" CaptionStyle-Font-Bold="true">
                                                                            <LayoutItemNestedControlCollection>
                                                                                <dx:LayoutItemNestedControlContainer>
                                                                                    <dx:ASPxMemo ID="StoreReviewEditor" runat="server" Width="100%" ClientInstanceName="ClientStoreReviewEditor" Rows="3">
                                                                                        <%--<ClientSideEvents KeyDown="RevCost.ClientStoreNoteEditor_KeyDown"
                                                                                            KeyPress="RevCost.ClientStoreNoteEditor_KeyPress"
                                                                                            TextChanged="RevCost.ClientStoreNoteEditor_TextChanged" />--%>
                                                                                    </dx:ASPxMemo>
                                                                                </dx:LayoutItemNestedControlContainer>
                                                                            </LayoutItemNestedControlCollection>

                                                                            <CaptionStyle Font-Bold="True"></CaptionStyle>
                                                                        </dx:LayoutItem>
                                                                        <dx:LayoutItem Caption="Approve Note" CaptionStyle-Font-Bold="true">
                                                                            <LayoutItemNestedControlCollection>
                                                                                <dx:LayoutItemNestedControlContainer>
                                                                                    <dx:ASPxMemo ID="StoreApproveEditor" runat="server" Width="100%" ClientInstanceName="ClientStoreApproveEditor" Rows="3">
                                                                                        <%-- <ClientSideEvents KeyDown="RevCost.ClientStoreNoteEditor_KeyDown"
                                                                                            KeyPress="RevCost.ClientStoreNoteEditor_KeyPress"
                                                                                            TextChanged="RevCost.ClientStoreNoteEditor_TextChanged" />--%>
                                                                                    </dx:ASPxMemo>
                                                                                </dx:LayoutItemNestedControlContainer>
                                                                            </LayoutItemNestedControlCollection>

                                                                            <CaptionStyle Font-Bold="True"></CaptionStyle>
                                                                        </dx:LayoutItem>
                                                                    </Items>
                                                                </dx:ASPxFormLayout>
                                                            </dx:SplitterContentControl>
                                                        </ContentCollection>
                                                        <Separator Visible="False"></Separator>

                                                        <PaneStyle>
                                                            <BorderTop BorderWidth="1px"></BorderTop>
                                                            <BorderLeft BorderWidth="1px"></BorderLeft>
                                                            <BorderRight BorderWidth="1px"></BorderRight>
                                                            <BorderBottom BorderWidth="1px"></BorderBottom>
                                                            <Paddings PaddingLeft="0" PaddingRight="0" PaddingBottom="0" PaddingTop="1" />
                                                        </PaneStyle>
                                                    </dx:SplitterPane>
                                                    <dx:SplitterPane Size="600" Separator-Visible="False">
                                                        <Separator Visible="False"></Separator>
                                                        <Panes>
                                                            <dx:SplitterPane Name="StoreFiles" Separator-Visible="False">
                                                                <ContentCollection>
                                                                    <dx:SplitterContentControl>
                                                                        <dx:ASPxGridView ID="StoreFilesGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                                            ClientInstanceName="ClientStoreFilesGrid" Width="100%" KeyFieldName="StoreFileID"
                                                                            OnCustomCallback="StoreFilesGrid_CustomCallback"
                                                                            OnCellEditorInitialize="StoreFilesGrid_CellEditorInitialize"
                                                                            OnBatchUpdate="StoreFilesGrid_BatchUpdate">
                                                                            <Columns>
                                                                                <dx:GridViewCommandColumn VisibleIndex="0" Caption=" " Width="75">
                                                                                    <CustomButtons>
                                                                                        <dx:GridViewCommandColumnCustomButton Text="Download" ID="Download"></dx:GridViewCommandColumnCustomButton>
                                                                                    </CustomButtons>
                                                                                </dx:GridViewCommandColumn>
                                                                                <dx:GridViewDataTextColumn FieldName="FileName" VisibleIndex="1" Caption="File Name" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                                    <EditFormSettings Visible="False" />

                                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                                </dx:GridViewDataTextColumn>
                                                                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" Caption="Description" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                                </dx:GridViewDataTextColumn>
                                                                                <dx:GridViewCommandColumn VisibleIndex="5" Caption=" " Width="75">
                                                                                    <CustomButtons>
                                                                                        <dx:GridViewCommandColumnCustomButton ID="Delete" Text="Delete" Image-Url="../../Content/images/action/delete.gif"></dx:GridViewCommandColumnCustomButton>
                                                                                    </CustomButtons>
                                                                                </dx:GridViewCommandColumn>
                                                                            </Columns>
                                                                            <Styles>
                                                                                <AlternatingRow Enabled="true" />
                                                                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                                            </Styles>
                                                                            <Settings ShowTitlePanel="true" ShowStatusBar="Hidden" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" />
                                                                            <SettingsEditing Mode="Batch">
                                                                                <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                                                            </SettingsEditing>
                                                                            <Paddings Padding="0px" />
                                                                            <Border BorderWidth="1px" />
                                                                            <BorderBottom BorderWidth="1px" />
                                                                            <SettingsResizing ColumnResizeMode="NextColumn" />
                                                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                                                            <Templates>
                                                                                <TitlePanel>
                                                                                    <div style="float: left">
                                                                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="Store Files"></dx:ASPxLabel>
                                                                                    </div>
                                                                                </TitlePanel>
                                                                            </Templates>
                                                                            <ClientSideEvents CustomButtonClick="RevCost.ClientStoreFilesGrid_CustomButtonClick" />
                                                                        </dx:ASPxGridView>
                                                                    </dx:SplitterContentControl>
                                                                </ContentCollection>
                                                                <Separator Visible="False"></Separator>

                                                                <PaneStyle>
                                                                    <BorderTop BorderWidth="0px"></BorderTop>
                                                                    <BorderLeft BorderWidth="0px"></BorderLeft>
                                                                    <BorderRight BorderWidth="0px"></BorderRight>
                                                                    <BorderBottom BorderWidth="1px"></BorderBottom>
                                                                    <Paddings PaddingLeft="2" PaddingRight="0" PaddingBottom="0" PaddingTop="1" />
                                                                </PaneStyle>
                                                            </dx:SplitterPane>
                                                            <dx:SplitterPane Size="30" Separator-Visible="False">
                                                                <ContentCollection>
                                                                    <dx:SplitterContentControl>
                                                                        <div style="float: left">
                                                                            <dx:ASPxButton ID="btnSaveStoreFiles" runat="server" Text="Save Store Files" AutoPostBack="false">
                                                                                <ClientSideEvents Click="RevCost.ClientSaveStoreFiles_Click" />
                                                                                <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                                            </dx:ASPxButton>
                                                                        </div>
                                                                        <div style="float: right; padding-right: 5px;">
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <dx:ASPxUploadControl ID="StoreFilesUploadControl" runat="server" ClientInstanceName="ClientStoreFilesUploadControl" ShowProgressPanel="true" NullText="Browse file here"
                                                                                            Width="280px" FileUploadMode="OnPageLoad" UploadMode="Advanced" OnFilesUploadComplete="StoreFilesUploadControl_FilesUploadComplete" BrowseButton-Text="Browse File">
                                                                                            <ClientSideEvents FileUploadStart="RevCost.ClientStoreFilesUploadControl_FileUploadStart"
                                                                                                UploadingProgressChanged="RevCost.ClientStoreFilesUploadControl_UploadingProgressChanged"
                                                                                                FilesUploadComplete="RevCost.ClientStoreFilesUploadControl_FilesUploadComplete" />
                                                                                            <ValidationSettings MaxFileSize="10000000" AllowedFileExtensions=".jpg,.jpeg,.gif,.doc,.docx,.xls,.xlsx,.pdf,.txt,.png" ShowErrors="true"></ValidationSettings>

                                                                                            <BrowseButton Text="Browse File"></BrowseButton>
                                                                                        </dx:ASPxUploadControl>
                                                                                    </td>
                                                                                    <td style="padding-left: 5px;">
                                                                                        <dx:ASPxButton ID="btnUploadStoreFile" runat="server" Text="Upload" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                                            <ClientSideEvents Click="RevCost.ClientUploadStoreFile_Click" />
                                                                                            <Image Url="../../Content/images/if_icon-98-folder-upload_314782.png"></Image>
                                                                                        </dx:ASPxButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </dx:SplitterContentControl>
                                                                </ContentCollection>
                                                                <Separator Visible="False"></Separator>

                                                                <PaneStyle>
                                                                    <BorderTop BorderWidth="0px"></BorderTop>
                                                                    <BorderLeft BorderWidth="0px"></BorderLeft>
                                                                    <BorderRight BorderWidth="0px"></BorderRight>
                                                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                                                    <Paddings PaddingLeft="2" PaddingRight="0" PaddingBottom="0" PaddingTop="5" />
                                                                </PaneStyle>
                                                            </dx:SplitterPane>
                                                        </Panes>
                                                        <ContentCollection>
                                                            <dx:SplitterContentControl runat="server"></dx:SplitterContentControl>
                                                        </ContentCollection>
                                                    </dx:SplitterPane>
                                                </Panes>
                                                <PaneStyle>
                                                    <BorderTop BorderWidth="0px"></BorderTop>
                                                    <BorderLeft BorderWidth="0px"></BorderLeft>
                                                    <BorderRight BorderWidth="0px"></BorderRight>
                                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                                </PaneStyle>
                                                <ContentCollection>
                                                    <dx:SplitterContentControl runat="server"></dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                        </Panes>
                                        <ContentCollection>
                                            <dx:SplitterContentControl runat="server"></dx:SplitterContentControl>
                                        </ContentCollection>
                                    </dx:SplitterPane>
                                </Panes>
                                <ContentCollection>
                                    <dx:SplitterContentControl runat="server"></dx:SplitterContentControl>
                                </ContentCollection>
                            </dx:SplitterPane>
                        </Panes>
                    </dx:ASPxSplitter>
                </div>
                <div class="left-pane">
                    <dx:ASPxSplitter ID="splitterVersion" runat="server" CssClass="main-menu" ClientInstanceName="ClientSplitterVersion" Orientation="Vertical" Width="695" Height="100%" ResizingMode="Live">
                        <ClientSideEvents PaneResized="RevCost.ClientSplitterVersion_PaneResized" />
                        <Panes>
                            <dx:SplitterPane Size="45%" Separator-Visible="False">
                                <Separator Visible="False"></Separator>
                                <Panes>
                                    <dx:SplitterPane Separator-Visible="False">
                                        <Separator Visible="False"></Separator>
                                        <Panes>
                                            <dx:SplitterPane Size="40" Separator-Visible="False">
                                                <Separator Visible="False"></Separator>
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <dx:ASPxSpinEdit ID="VersionYearEditor" Caption="<%$Resources:app.language,Year%>" MinValue="2000" MaxValue="9999" runat="server" Width="80px">
                                                                        <ClientSideEvents ValueChanged="RevCost.ClientQuery_Click" />
                                                                    </dx:ASPxSpinEdit>
                                                                </td>
                                                                <td style="width: 250px;">
                                                                    <dx:ASPxRadioButtonList ID="rdoVersionType" runat="server" RepeatDirection="Horizontal" ValueType="System.String">
                                                                        <Border BorderWidth="0" BorderStyle="None" />
                                                                        <Paddings Padding="0" />
                                                                        <Items>
                                                                            <dx:ListEditItem Value="P" Text="<%$Resources:app.language,Planning%>" Selected="true" />
                                                                            <dx:ListEditItem Value="E" Text="<%$Resources:app.language,Estimate%>" />
                                                                            <dx:ListEditItem Value="A" Text="<%$Resources:app.language,Actual%>" />
                                                                        </Items>
                                                                        <ClientSideEvents ValueChanged="RevCost.ClientQuery_Click" />
                                                                    </dx:ASPxRadioButtonList>
                                                                </td>
                                                                <td>
                                                                    <dx:ASPxButton ID="btnQuery" runat="server" Visible="false" Text="<%$Resources:app.language,Query%>" AutoPostBack="false" UseSubmitBehavior="true">
                                                                        <ClientSideEvents Click="RevCost.ClientQuery_Click" />
                                                                    </dx:ASPxButton>
                                                                </td>
                                                                <td style="width: 50px;">
                                                                    <dx:ASPxButton ID="HideMenuButton" ClientInstanceName="MenuButton" RenderMode="Link" Text="<%$Resources:app.language,Hide%>" ImagePosition="Top" runat="server" AutoPostBack="False" Height="30px" GroupName="Menu">
                                                                        <ClientSideEvents Click="RevCost.ClientHideMenuButton_Click" />
                                                                        <Image Url="../../Content/images/action/go_back.png"></Image>
                                                                    </dx:ASPxButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                            <dx:SplitterPane Name="VersionsPane" Separator-Visible="False">
                                                <Separator Visible="False"></Separator>
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxGridView ID="VersionGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                            ClientInstanceName="ClientVersionGrid" Width="100%" KeyFieldName="VersionID"
                                                            OnCustomCallback="VersionGrid_CustomCallback">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="VersionType" VisibleIndex="2" Caption="<%$Resources:app.language,Type%>" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="3" Caption="<%$Resources:app.language,Description%>" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="4" Caption="<%$Resources:app.language,Status%>" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                            </Columns>
                                                            <Styles>
                                                                <AlternatingRow Enabled="true" />
                                                                <TitlePanel HorizontalAlign="Left"></TitlePanel>
                                                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                            </Styles>
                                                            <Settings ShowTitlePanel="true" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" VerticalScrollBarStyle="Standard" />
                                                            <Paddings Padding="0px" />
                                                            <Border BorderWidth="1px" />
                                                            <BorderBottom BorderWidth="1px" />
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                                            <Templates>
                                                                <TitlePanel>
                                                                    <div style="float: left">
                                                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="<%$Resources:app.language,Version%>"></dx:ASPxLabel>
                                                                    </div>
                                                                    <div style="float: right; padding-right: 10px">
                                                                        <dx:ASPxButton ID="btnNewVersion" runat="server" ClientInstanceName="ClientNewVersionButton" Text="<%$Resources:app.language,Create%>" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                                                            <Image Height="16" Url="../../Content/images/SpinEditPlus.png"></Image>
                                                                            <ClientSideEvents Click="RevCost.ClientNewVersionButton_Click" />
                                                                        </dx:ASPxButton>
                                                                        &nbsp;
                                                                        <dx:ASPxButton ID="btnCopyVersion" runat="server" ClientInstanceName="ClientCopyVersionButton" Text="<%$Resources:app.language,Copy%>" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                                                            <Image Url="../../Content/images/if_simpline_4_2305586.png" Height="16"></Image>
                                                                            <ClientSideEvents Click="RevCost.ClientCopyVersionButton_Click" />
                                                                        </dx:ASPxButton>
                                                                    </div>
                                                                </TitlePanel>
                                                                <StatusBar>
                                                                    <dx:ASPxButton ID="btnSelectVersion" runat="server" Text="<%$Resources:app.language,SelectVersion%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                        <ClientSideEvents Click="RevCost.ClientSelectVersionBase_Click" />
                                                                        <Image Url="../../Content/images/action/test.png"></Image>
                                                                    </dx:ASPxButton>

                                                                    <dx:ASPxButton ID="btnApprove" runat="server" ClientEnabled='<%# IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Approve") %>' Text="<%$Resources:app.language,Approve%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                        <Image Url="../../Content/images/action/Appr.gif"></Image>
                                                                        <ClientSideEvents Click="RevCost.ClientApproveVersion_Click" />
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="btnUnApprove" runat="server" ClientEnabled='<%# IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Unapprove") %>' Text="<%$Resources:app.language,Unapprove%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                        <Image Url="../../Content/images/action/UnAppr.gif"></Image>
                                                                        <ClientSideEvents Click="RevCost.ClientDisApproveVersion_Click" />
                                                                    </dx:ASPxButton>

                                                                </StatusBar>
                                                            </Templates>
                                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientVersionGrid_FocusedRowChanged"
                                                                BeginCallback="RevCost.ClientVersionGrid_BeginCallback"
                                                                EndCallback="RevCost.ClientVersionGrid_EndCallback" />
                                                        </dx:ASPxGridView>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                        </Panes>
                                        <ContentCollection>
                                            <dx:SplitterContentControl runat="server"></dx:SplitterContentControl>
                                        </ContentCollection>
                                    </dx:SplitterPane>
                                </Panes>
                                <PaneStyle>
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <BorderLeft BorderWidth="0px"></BorderLeft>
                                    <BorderRight BorderWidth="0px"></BorderRight>
                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                                <ContentCollection>
                                    <dx:SplitterContentControl runat="server"></dx:SplitterContentControl>
                                </ContentCollection>
                            </dx:SplitterPane>
                            <dx:SplitterPane Separator-Visible="False">
                                <Separator Visible="False"></Separator>
                                <Panes>
                                    <dx:SplitterPane Separator-Visible="False">
                                        <Separator Visible="False"></Separator>
                                        <Panes>
                                            <dx:SplitterPane Name="VersionCompanyPane" Separator-Visible="False">
                                                <Separator Visible="False"></Separator>
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxGridView ID="VersionCompanyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                            ClientInstanceName="ClientVersionCompanyGrid" Width="100%" KeyFieldName="VerCompanyID"
                                                            OnCustomCallback="VersionCompanyGrid_CustomCallback"
                                                            OnCustomDataCallback="VersionCompanyGrid_CustomDataCallback">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="VersionName" VisibleIndex="1" Caption="<%$Resources:app.language,VersionName%>" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="VersionNumber" VisibleIndex="2" Caption="<%$Resources:app.language,Number%>" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="VerLevel" VisibleIndex="3" Caption="<%$Resources:app.language,Level%>" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <%-- <dx:GridViewDataTextColumn FieldName="ReportType" VisibleIndex="4" Caption="<%$Resources:app.language,Type%>" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>--%>
                                                                <dx:GridViewDataTextColumn FieldName="ReviewStatus" VisibleIndex="5" Caption="<%$Resources:app.language,ReviewStatus%>" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="ApproveStatus" VisibleIndex="5" Caption="<%$Resources:app.language,Status%>" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewCommandColumn VisibleIndex="6" Width="30">
                                                                    <CustomButtons>
                                                                        <dx:GridViewCommandColumnCustomButton ID="btnVersionFiles" Text="">
                                                                            <Image Url="../../Content/images/more-detail-glyph.png" Height="16"></Image>
                                                                        </dx:GridViewCommandColumnCustomButton>
                                                                    </CustomButtons>
                                                                </dx:GridViewCommandColumn>
                                                            </Columns>
                                                            <Styles>
                                                                <AlternatingRow Enabled="true" />
                                                                <TitlePanel HorizontalAlign="Left"></TitlePanel>
                                                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                            </Styles>
                                                            <Settings ShowTitlePanel="true" ShowFooter="true" ShowStatusBar="Hidden" VerticalScrollBarMode="Visible" VerticalScrollableHeight="400" VerticalScrollBarStyle="Standard" />
                                                            <Paddings Padding="0px" />
                                                            <Border BorderWidth="1px" />
                                                            <BorderBottom BorderWidth="1px" />
                                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                                                            <Templates>
                                                                <%--  <FooterRow>
                                                                   
                                                                </FooterRow>--%>
                                                                <%-- <StatusBar>
                                                                    <dx:ASPxButton ID="btnSelectVersion" runat="server" Text="<%$Resources:app.language,SelectVersion%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                        <ClientSideEvents Click="RevCost.ClientSelectVersionBase_Click" />
                                                                        <Image Url="../../Content/images/action/test.png"></Image>
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="btnChangeCompany" runat="server" ClientInstanceName="ClientChangeCompanyButton" Text="<%$Resources:app.language,ChangeCompany%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                        <ClientSideEvents Click="RevCost.ClientChangeCompanyButton_Click" />
                                                                        <Image Url="../../Content/images/relationship.png"></Image>
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="btnPrint" runat="server" Text="<%$Resources:app.language,Print%>" RenderMode="Button" AutoPostBack="false" Image-Width="16" Image-Url="~/Content/images/if_simpline_5_2305642.png">
                                                                        <ClientSideEvents Click="RevCost.ClientbtnPrintStoreButton_Click" />
                                                                    </dx:ASPxButton>
                                                                </StatusBar>--%>
                                                                <TitlePanel>
                                                                    <div style="float: left">
                                                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="<%$Resources:app.language,VersionCompany%>"></dx:ASPxLabel>
                                                                    </div>
                                                                    <div style="float: right; padding-right: 10px">
                                                                        <dx:ASPxButton ID="btnNewVersionCompany" runat="server" ClientInstanceName="ClientNewVersionCompanyButton" Text="<%$Resources:app.language,New%>" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                                                            <Image Height="16" Url="../../Content/images/SpinEditPlus.png"></Image>
                                                                            <ClientSideEvents Click="RevCost.ClientNewVersionCompanyButton_Click" />
                                                                        </dx:ASPxButton>
                                                                        <%--  &nbsp;
                                                                        <dx:ASPxButton ID="btnCopyVersionCompany" runat="server" ClientInstanceName="ClientCopyVersionCompanyButton" Text="<%$Resources:app.language,Copy%>" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                                                            <Image Url="../../Content/images/if_simpline_4_2305586.png" Height="16"></Image>
                                                                            <ClientSideEvents Click="RevCost.ClientCopyVersionCompanyButton_Click" />
                                                                        </dx:ASPxButton>--%>
                                                                        &nbsp;
                                                                        <dx:ASPxButton ID="btnDuplicateVersionCompany" runat="server" ClientInstanceName="ClientDuplicateVersionCompany" Text="<%$Resources:app.language,Duplicate%>" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                                                            <Image Url="../../Content/images/duplicate.png" Height="16"></Image>
                                                                            <ClientSideEvents Click="RevCost.ClientClientDuplicateVersionCompanyButton_Click" />
                                                                        </dx:ASPxButton>
                                                                    </div>
                                                                </TitlePanel>
                                                            </Templates>
                                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientVersionCompanyGrid_FocusedRowChanged"
                                                                BeginCallback="RevCost.ClientVersionCompanyGrid_BeginCallback"
                                                                EndCallback="RevCost.ClientVersionCompanyGrid_EndCallback"
                                                                CustomButtonClick="RevCost.ClientVersionCompanyGrid_CustomButtonClick" />
                                                        </dx:ASPxGridView>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                            <dx:SplitterPane Size="40" Separator-Visible="False">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <%-- <dx:ASPxButton ID="btnSelectVersion" runat="server" Text="<%$Resources:app.language,SelectVersion%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                            <ClientSideEvents Click="RevCost.ClientSelectVersionBase_Click" />
                                                            <Image Url="../../Content/images/action/test.png"></Image>
                                                        </dx:ASPxButton>--%>

                                                        <%-- <dx:ASPxButton ID="btnPrint" runat="server" Text="<%$Resources:app.language,Print%>" RenderMode="Button" AutoPostBack="false" Image-Width="16" Image-Url="~/Content/images/if_simpline_5_2305642.png">
                                                            <ClientSideEvents Click="RevCost.ClientbtnPrintStoreButton_Click" />
                                                        </dx:ASPxButton>--%>
                                                        <dx:ASPxButton ID="btnPost" runat="server" ClientEnabled='<%# IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Post") %>' Text="<%$Resources:app.language,Post%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                            <Image Url="../../Content/images/action/Appr.gif"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientPostButton_Click" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnUnpost" runat="server" ClientEnabled='<%# IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.Unpost") %>' Text="<%$Resources:app.language,Unpost%>" RenderMode="Button" AutoPostBack="false" Image-Width="16" Image-Url="~/Content/images/if_simpline_5_2305642.png">
                                                            <Image Url="../../Content/images/action/UnAppr.gif"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientUnpostButton_Click" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnComApprove" runat="server" ClientEnabled='<%# IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.ComApprove") %>' Text="<%$Resources:app.language,Approve%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                            <Image Url="../../Content/images/action/Appr.gif"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientComApproveButton_Click" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnComUnapprove" runat="server" ClientEnabled='<%# IsGranted("Pages.KHTC.Business.RevenueCost.RevenueCostForCompany.ComUnapprove") %>' Text="<%$Resources:app.language,Unapprove%>" RenderMode="Button" AutoPostBack="false" Image-Width="16" Image-Url="~/Content/images/if_simpline_5_2305642.png">
                                                            <Image Url="../../Content/images/action/UnAppr.gif"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientComUnapproveButton_Click" />
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnChangeCompany" runat="server" ClientInstanceName="ClientChangeCompanyButton" Text="<%$Resources:app.language,ChangeCompany%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                            <ClientSideEvents Click="RevCost.ClientChangeCompanyButton_Click" />
                                                            <Image Url="../../Content/images/relationship.png"></Image>
                                                        </dx:ASPxButton>
                                                        <dx:ASPxButton ID="btnPrint" runat="server" Text="<%$Resources:app.language,Print%>" RenderMode="Button" AutoPostBack="false" Image-Width="16" Image-Url="~/Content/images/if_simpline_5_2305642.png">
                                                            <ClientSideEvents Click="RevCost.ClientbtnPrintStoreButton_Click" />
                                                        </dx:ASPxButton>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                                <PaneStyle>
                                                    <BorderTop BorderWidth="0px"></BorderTop>
                                                    <BorderLeft BorderWidth="0px"></BorderLeft>
                                                    <BorderRight BorderWidth="0px"></BorderRight>
                                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="2" PaddingTop="5" />
                                                </PaneStyle>
                                            </dx:SplitterPane>
                                        </Panes>

                                    </dx:SplitterPane>
                                </Panes>
                                <PaneStyle>
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <BorderLeft BorderWidth="0px"></BorderLeft>
                                    <BorderRight BorderWidth="0px"></BorderRight>
                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                        </Panes>
                    </dx:ASPxSplitter>
                </div>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>

    <dx:ASPxPopupControl ID="CompanyListPopup" runat="server" Width="500" Height="450" AllowDragging="True" HeaderText="<%$Resources:app.language,ChangeCompany%>" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientCompanyListPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="CompanyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientCompanyGrid" Width="100%" KeyFieldName="CompanyID"
                    OnCustomCallback="CompanyGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="ShortName" VisibleIndex="1" Caption="<%$Resources:app.language,ShortName%>" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NameV" VisibleIndex="2" Caption="<%$Resources:app.language,Description%>" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <DataItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("AreaCode") +"-"+ Eval("NameV") %>'></asp:Label>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="true" />
                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                    </Styles>
                    <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="450" VerticalScrollBarStyle="Standard" />
                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="ShortName;NameV" />
                    <Paddings Padding="0px" />
                    <Border BorderWidth="0px" BorderStyle="None" />
                    <BorderBottom BorderWidth="1px" />
                    <SettingsBehavior AllowFocusedRow="True" />
                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                    <ClientSideEvents RowDblClick="RevCost.ClientCompanyGrid_RowDblClick" />
                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="<%$Resources:app.language,Cancel%>" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ClientCompanyListPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="<%$Resources:app.language,Apply%>" AutoPostBack="false" ClientInstanceName="ClientApplyButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientCompanyListPopup_Shown" />
    </dx:ASPxPopupControl>


    <dx:ASPxPopupControl ID="VersionCompanyFilesPopup" runat="server" Width="800" Height="600" AllowDragging="True" HeaderText="Version Detail" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientVersionCompanyFilesPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxRoundPanel ID="VersionDetailRoundPanel" runat="server" HeaderStyle-HorizontalAlign="Left" Collapsed="false" HeaderText="Version Detail" ShowCollapseButton="true" Width="100%">
                    <ContentPaddings Padding="5px" />

                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxMemo ID="VerCompanyDescriptionEditor" ClientInstanceName="ClientVerCompanyDescriptionEditor" runat="server" Caption="Description" Height="71px" Width="100%" AutoResizeWithContainer="true" Rows="3">
                                <CaptionSettings Position="Top" />
                            </dx:ASPxMemo>
                            <dx:ASPxMemo ID="VerCompanyApproveNoteEditor" ClientInstanceName="ClientVerCompanyApproveNoteEditor" runat="server" Caption="Approved Note" Height="71px" Width="100%" AutoResizeWithContainer="true" Rows="3">
                                <CaptionSettings Position="Top" />
                            </dx:ASPxMemo>
                            <dx:ASPxMemo ID="VerCompanyReviewNoteEditor" ClientInstanceName="ClientVerCompanyReviewNoteEditor" runat="server" Caption="Review Note" Height="71px" Width="100%" AutoResizeWithContainer="true" Rows="3">
                                <CaptionSettings Position="Top" />
                            </dx:ASPxMemo>
                            <dx:ASPxMemo ID="VerCompanyCreateNoteEditor" ClientInstanceName="ClientVerCompanyCreateNoteEditor" runat="server" Caption="Create Note" Height="71px" Width="100%" AutoResizeWithContainer="true" Rows="3">
                                <CaptionSettings Position="Top" />
                            </dx:ASPxMemo>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <br />
                <dx:ASPxRoundPanel ID="VersionCompanyFilesRoundPanel" runat="server" HeaderStyle-HorizontalAlign="Left" Collapsed="false" HeaderText="Version Files" ShowCollapseButton="true" Width="100%">
                    <ContentPaddings Padding="0" />

                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxGridView ID="VersionCompanyFilesGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                ClientInstanceName="ClientVersionCompanyFilesGrid" Width="100%" KeyFieldName="VerCompanyFileID"
                                OnCustomCallback="VersionCompanyFilesGrid_CustomCallback"
                                OnCellEditorInitialize="VersionCompanyFilesGrid_CellEditorInitialize"
                                OnBatchUpdate="VersionCompanyFilesGrid_BatchUpdate">
                                <Columns>
                                    <dx:GridViewCommandColumn VisibleIndex="0" Caption="" Width="80">
                                        <CustomButtons>
                                            <dx:GridViewCommandColumnCustomButton Text="Download" ID="DownloadFile"></dx:GridViewCommandColumnCustomButton>
                                        </CustomButtons>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn FieldName="FileName" VisibleIndex="1" Caption="File Name" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <EditFormSettings Visible="False" />

                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" Caption="Description" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        <Settings AutoFilterCondition="Contains"></Settings>

                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewCommandColumn VisibleIndex="5" Caption=" " Width="75">
                                        <CustomButtons>
                                            <dx:GridViewCommandColumnCustomButton ID="DeleteVersionFile" Text="Delete" Image-Url="../../Content/images/action/delete.gif"></dx:GridViewCommandColumnCustomButton>
                                        </CustomButtons>
                                    </dx:GridViewCommandColumn>
                                </Columns>
                                <Styles>
                                    <AlternatingRow Enabled="true" />
                                    <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                </Styles>
                                <Settings ShowStatusBar="Hidden" VerticalScrollBarMode="Visible" VerticalScrollableHeight="120" VerticalScrollBarStyle="Standard" />
                                <SettingsEditing Mode="Batch">
                                    <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                </SettingsEditing>
                                <Paddings Padding="0px" />
                                <Border BorderWidth="0px" />
                                <BorderBottom BorderWidth="0px" />
                                <SettingsResizing ColumnResizeMode="NextColumn" />
                                <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                <ClientSideEvents CustomButtonClick="RevCost.ClientVersionCompanyFilesGrid_CustomButtonClick" />
                            </dx:ASPxGridView>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <div style="float: right; padding-right: 5px; padding-top: 4px">
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxUploadControl ID="VerCompanyFilesUC" runat="server" ClientInstanceName="ClientVerCompanyFilesUC" ShowProgressPanel="true" NullText="Browse file here"
                                    Width="280px" FileUploadMode="OnPageLoad" UploadMode="Advanced" OnFilesUploadComplete="VerCompanyFilesUC_FilesUploadComplete" BrowseButton-Text="Browse File">
                                    <ClientSideEvents FilesUploadComplete="RevCost.ClientVerCompanyFilesUC_FilesUploadComplete" />
                                    <ValidationSettings MaxFileSize="10000000" AllowedFileExtensions=".jpg,.jpeg,.gif,.doc,.docx,.xls,.xlsx,.pdf,.txt,.png" ShowErrors="true"></ValidationSettings>

                                    <BrowseButton Text="Browse File"></BrowseButton>
                                </dx:ASPxUploadControl>
                            </td>
                            <td style="padding-left: 5px;">
                                <dx:ASPxButton ID="btnVerCompanyFileUpload" runat="server" Text="Upload" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                    <ClientSideEvents Click="RevCost.ClientUploadVerCompanyFile_Click" />
                                    <Image Url="../../Content/images/if_icon-98-folder-upload_314782.png"></Image>
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="3px" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="<%$Resources:app.language,Close%>" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientVersionCompanyFilesPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="<%$Resources:app.language,Save%>" AutoPostBack="false" ClientInstanceName="ClientApplyVersionCompanyFilesButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyVersionCompanyFilesButton_Click" />
                <Image Url="../../Content/images/action/save.png" Height="16"></Image>
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientVersionCompanyFilesPopup_Shown" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="CopyVersionCompanyPopup" runat="server" Width="500" Height="300" AllowDragging="True" HeaderText="Copy Version Company" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientCopyVersionCompanyPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="VersionCopyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientVersionCopyGrid" Width="100%" KeyFieldName="VersionID"
                    OnCustomCallback="VersionCopyGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="VersionYear" VisibleIndex="1" Caption="Year" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="VersionType" VisibleIndex="2" Caption="Type" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="3" Caption="Description" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="4" Caption="Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="true" />
                        <TitlePanel HorizontalAlign="Left"></TitlePanel>
                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                    </Styles>
                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" VerticalScrollBarStyle="Standard" />
                    <Paddings Padding="0px" />
                    <Border BorderWidth="0px" />
                    <SettingsBehavior AllowFocusedRow="True" />
                    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancelCopy" runat="server" Text="<%$Resources:app.language,Cancel%>" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientCopyVersionCompanyPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApplyCopy" runat="server" Text="<%$Resources:app.language,Apply%>" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyCopyVersionCompanyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientCopyVersionCompanyPopup_Shown"
            CloseUp="RevCost.ClientCopyVersionCompanyPopup_CloseUp" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="VersionCompanyPopup" runat="server" Width="580" Height="300" AllowDragging="True" HeaderText="Select Version" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientVersionCompanyPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="VersionCompanyBaseGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientVersionCompanyBaseGrid" Width="100%" KeyFieldName="VerCompanyID"
                    OnCustomCallback="VersionCompanyBaseGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="VersionName" VisibleIndex="1" Caption="Version Name" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CreateStatus" VisibleIndex="2" Caption="Create Status" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ReviewStatus" VisibleIndex="3" Caption="Review Status" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ApproveStatus" VisibleIndex="4" Caption="Approve Status" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="5" Caption="Status" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn VisibleIndex="6" Width="35" ShowSelectCheckbox="true" ShowClearFilterButton="true"></dx:GridViewCommandColumn>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="true" />
                        <TitlePanel HorizontalAlign="Left"></TitlePanel>
                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                    </Styles>
                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" VerticalScrollBarStyle="Standard" />
                    <Paddings Padding="0px" />
                    <Border BorderWidth="0px" />
                    <SettingsBehavior AllowFocusedRow="True" />
                    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancelCopy" runat="server" Text="<%$Resources:app.language,Cancel%>" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientVersionCompanyPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApplyVersioBase" runat="server" Text="<%$Resources:app.language,VersionCompany%>" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyVersionBase_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientVersionCompanyBaseGrid_Shown"
            CloseUp="RevCost.ClientVersionCompanyBaseGrid_CloseUp" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="ClientbtnPrintStorePopup" runat="server" Width="1000" Height="700" AllowDragging="True" HeaderText="Print Report" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientbtnPrintStorePopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
                    <Panes>
                        <dx:SplitterPane Size="1000" Separator-Visible="False">
                            <ContentCollection>
                                <dx:SplitterContentControl>
                                    <dx:ASPxFormLayout ID="PrintReportForm" runat="server" ColCount="4" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
                                        AlignItemCaptionsInAllGroups="true" Width="100%">
                                        <Items>

                                            <dx:LayoutItem Caption="Current Version" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="CurrentVerEditor" Width="200" AutoResizeWithContainer="true" ClientInstanceName="ClientCurrentVerEditor">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>

                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>

                                            <dx:LayoutItem Caption="From Month" ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox runat="server" ID="FromMonthEditor" Width="100" ClientInstanceName="ClientFromMonthEditor">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                            <Items>
                                                                <dx:ListEditItem Value="1" Text="1" Selected="true" />
                                                                <dx:ListEditItem Value="2" Text="2" />
                                                                <dx:ListEditItem Value="3" Text="3" />
                                                                <dx:ListEditItem Value="4" Text="4" />
                                                                <dx:ListEditItem Value="5" Text="5" />
                                                                <dx:ListEditItem Value="6" Text="6" />
                                                                <dx:ListEditItem Value="7" Text="7" />
                                                                <dx:ListEditItem Value="8" Text="8" />
                                                                <dx:ListEditItem Value="9" Text="9" />
                                                                <dx:ListEditItem Value="10" Text="10" />
                                                                <dx:ListEditItem Value="11" Text="11" />
                                                                <dx:ListEditItem Value="12" Text="12" />
                                                            </Items>
                                                        </dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>

                                            <dx:LayoutItem Caption="To Month" ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox runat="server" ID="ToMonthEditor" Width="100" ClientInstanceName="ClientToMonthEditor">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                            <Items>
                                                                <dx:ListEditItem Value="1" Text="1" />
                                                                <dx:ListEditItem Value="2" Text="2" />
                                                                <dx:ListEditItem Value="3" Text="3" />
                                                                <dx:ListEditItem Value="4" Text="4" />
                                                                <dx:ListEditItem Value="5" Text="5" />
                                                                <dx:ListEditItem Value="6" Text="6" />
                                                                <dx:ListEditItem Value="7" Text="7" />
                                                                <dx:ListEditItem Value="8" Text="8" />
                                                                <dx:ListEditItem Value="9" Text="9" />
                                                                <dx:ListEditItem Value="10" Text="10" />
                                                                <dx:ListEditItem Value="11" Text="11" />
                                                                <dx:ListEditItem Value="12" Text="12" Selected="true" />
                                                            </Items>
                                                        </dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>

                                            <dx:LayoutItem Caption="Version Base1" ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="VerEditorBase1" Width="200" AutoResizeWithContainer="true" ClientInstanceName="ClientVersionBase1Editor">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption=" " ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxButton ID="btnVerEditorBase1" runat="server" ClientInstanceName="ClientNewVerEditorBase1" Text="New" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                                            <Image Height="16" Url="../../Content/images/SpinEditPlus.png"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientSelectVersionBaseReport_Click" />
                                                        </dx:ASPxButton>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>

                                            <dx:LayoutItem Caption="From Month" ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox runat="server" ID="FromMonthBase1Editor" Width="100" ClientInstanceName="ClientFromMonthBase1Editor">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                            <Items>
                                                                <dx:ListEditItem Value="1" Text="1" Selected="true" />
                                                                <dx:ListEditItem Value="2" Text="2" />
                                                                <dx:ListEditItem Value="3" Text="3" />
                                                                <dx:ListEditItem Value="4" Text="4" />
                                                                <dx:ListEditItem Value="5" Text="5" />
                                                                <dx:ListEditItem Value="6" Text="6" />
                                                                <dx:ListEditItem Value="7" Text="7" />
                                                                <dx:ListEditItem Value="8" Text="8" />
                                                                <dx:ListEditItem Value="9" Text="9" />
                                                                <dx:ListEditItem Value="10" Text="10" />
                                                                <dx:ListEditItem Value="11" Text="11" />
                                                                <dx:ListEditItem Value="12" Text="12" />
                                                            </Items>
                                                        </dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="To Month" ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox runat="server" ID="ToMonthBase1Editor" Width="100" ClientInstanceName="ClientToMonthBase1Editor">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                            <Items>
                                                                <dx:ListEditItem Value="1" Text="1" />
                                                                <dx:ListEditItem Value="2" Text="2" />
                                                                <dx:ListEditItem Value="3" Text="3" />
                                                                <dx:ListEditItem Value="4" Text="4" />
                                                                <dx:ListEditItem Value="5" Text="5" />
                                                                <dx:ListEditItem Value="6" Text="6" />
                                                                <dx:ListEditItem Value="7" Text="7" />
                                                                <dx:ListEditItem Value="8" Text="8" />
                                                                <dx:ListEditItem Value="9" Text="9" />
                                                                <dx:ListEditItem Value="10" Text="10" />
                                                                <dx:ListEditItem Value="11" Text="11" />
                                                                <dx:ListEditItem Value="12" Text="12" Selected="true" />
                                                            </Items>
                                                        </dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>

                                            <dx:LayoutItem Caption="Version Base2" ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="VerEditorBase2" Width="200" AutoResizeWithContainer="true" ClientInstanceName="ClientVersionBase2Editor">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption=" " ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxButton ID="btnVerEditorBase2" runat="server" ClientInstanceName="ClientNewVerEditorBase2" Text="New" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                                            <Image Height="16" Url="../../Content/images/SpinEditPlus.png"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientSelectVersionBaseReport_Click" />
                                                        </dx:ASPxButton>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="From Month" ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox runat="server" ID="FromMonthBase2Editor" Width="100" ClientInstanceName="ClientFromMonthBase2Editor">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                            <Items>
                                                                <dx:ListEditItem Value="1" Text="1" Selected="true" />
                                                                <dx:ListEditItem Value="2" Text="2" />
                                                                <dx:ListEditItem Value="3" Text="3" />
                                                                <dx:ListEditItem Value="4" Text="4" />
                                                                <dx:ListEditItem Value="5" Text="5" />
                                                                <dx:ListEditItem Value="6" Text="6" />
                                                                <dx:ListEditItem Value="7" Text="7" />
                                                                <dx:ListEditItem Value="8" Text="8" />
                                                                <dx:ListEditItem Value="9" Text="9" />
                                                                <dx:ListEditItem Value="10" Text="10" />
                                                                <dx:ListEditItem Value="11" Text="11" />
                                                                <dx:ListEditItem Value="12" Text="12" />
                                                            </Items>
                                                        </dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="To Month" ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox runat="server" ID="ToMonthBase2Editor" Width="100" ClientInstanceName="ClientToMonthBase2Editor">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                            <Items>
                                                                <dx:ListEditItem Value="1" Text="1" />
                                                                <dx:ListEditItem Value="2" Text="2" />
                                                                <dx:ListEditItem Value="3" Text="3" />
                                                                <dx:ListEditItem Value="4" Text="4" />
                                                                <dx:ListEditItem Value="5" Text="5" />
                                                                <dx:ListEditItem Value="6" Text="6" />
                                                                <dx:ListEditItem Value="7" Text="7" />
                                                                <dx:ListEditItem Value="8" Text="8" />
                                                                <dx:ListEditItem Value="9" Text="9" />
                                                                <dx:ListEditItem Value="10" Text="10" />
                                                                <dx:ListEditItem Value="11" Text="11" />
                                                                <dx:ListEditItem Value="12" Text="12" Selected="true" />
                                                            </Items>
                                                        </dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>

                                            <dx:LayoutItem Caption="Version Base3" ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="VerEditorBase3" Width="200" AutoResizeWithContainer="true" ClientInstanceName="ClientVersionBase3Editor">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption=" " ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxButton ID="btnVerEditorBase3" runat="server" ClientInstanceName="ClientNewVerEditorBase3" Text="New" RenderMode="Link" ImagePosition="Left" AutoPostBack="false">
                                                            <Image Height="16" Url="../../Content/images/SpinEditPlus.png"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientSelectVersionBaseReport_Click" />
                                                        </dx:ASPxButton>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="From Month" ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox runat="server" ID="FromMonthBase3Editor" Width="100" ClientInstanceName="ClientFromMonthBase3Editor">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                            <Items>
                                                                <dx:ListEditItem Value="1" Text="1" Selected="true" />
                                                                <dx:ListEditItem Value="2" Text="2" />
                                                                <dx:ListEditItem Value="3" Text="3" />
                                                                <dx:ListEditItem Value="4" Text="4" />
                                                                <dx:ListEditItem Value="5" Text="5" />
                                                                <dx:ListEditItem Value="6" Text="6" />
                                                                <dx:ListEditItem Value="7" Text="7" />
                                                                <dx:ListEditItem Value="8" Text="8" />
                                                                <dx:ListEditItem Value="9" Text="9" />
                                                                <dx:ListEditItem Value="10" Text="10" />
                                                                <dx:ListEditItem Value="11" Text="11" />
                                                                <dx:ListEditItem Value="12" Text="12" />
                                                            </Items>
                                                        </dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="To Month" ColSpan="1">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox runat="server" ID="ToMonthBase3Editor" Width="100" ClientInstanceName="ClientToMonthBase3Editor">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                            <Items>
                                                                <dx:ListEditItem Value="1" Text="1" />
                                                                <dx:ListEditItem Value="2" Text="2" />
                                                                <dx:ListEditItem Value="3" Text="3" />
                                                                <dx:ListEditItem Value="4" Text="4" />
                                                                <dx:ListEditItem Value="5" Text="5" />
                                                                <dx:ListEditItem Value="6" Text="6" />
                                                                <dx:ListEditItem Value="7" Text="7" />
                                                                <dx:ListEditItem Value="8" Text="8" />
                                                                <dx:ListEditItem Value="9" Text="9" />
                                                                <dx:ListEditItem Value="10" Text="10" />
                                                                <dx:ListEditItem Value="11" Text="11" />
                                                                <dx:ListEditItem Value="12" Text="12" Selected="true" />
                                                            </Items>
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
                                </dx:SplitterContentControl>
                            </ContentCollection>
                            <Separator Visible="False"></Separator>

                            <PaneStyle>
                                <BorderTop BorderWidth="0px" />
                                <BorderLeft BorderWidth="0px" />
                                <BorderRight BorderWidth="0px" />
                            </PaneStyle>

                        </dx:SplitterPane>


                        <dx:SplitterPane Size="1000" Separator-Visible="False">
                            <ContentCollection>
                                <dx:SplitterContentControl>
                                    Version hiện tại:
                                    <dx:ASPxLabel ID="lbCurrVersion" runat="server" ClientInstanceName="ClientlbCurrVersion" Text="" Font-Bold="true"></dx:ASPxLabel>
                                    Đơn vị hiện tại:
                                    <dx:ASPxLabel ID="lbCurrCompany" runat="server" ClientInstanceName="ClientlbCurrVersion" Text="" Font-Bold="true"></dx:ASPxLabel>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 100%;">
                                                <dx:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" RepeatDirection="Horizontal" ValueType="System.String">
                                                    <Border BorderWidth="0" BorderStyle="None" />
                                                    <Paddings Padding="0" />
                                                    <Items>
                                                        <dx:ListEditItem Value="BC1" Text="Báo cáo chi tiết Thu - Chi của đơn vị" Selected="true" />
                                                    </Items>
                                                </dx:ASPxRadioButtonList>
                                            </td>

                                        </tr>
                                        <%--<tr>
                                            <td style="width: 100%;">
                                                <dx:ASPxRadioButtonList ID="ASPxRadioButtonList2" runat="server" RepeatDirection="Horizontal" ValueType="System.String">
                                                    <Border BorderWidth="0" BorderStyle="None" />
                                                    <Paddings Padding="0" />
                                                    <Items>
                                                        <dx:ListEditItem Value="BC2" Text="Báo cáo so sánh version theo tháng của đơn vị" />
                                                    </Items>
                                                </dx:ASPxRadioButtonList>
                                            </td>

                                        </tr>--%>
                                    </table>
                                </dx:SplitterContentControl>
                            </ContentCollection>
                            <Separator Visible="False"></Separator>

                            <PaneStyle>
                                <BorderTop BorderWidth="0px" />
                                <BorderLeft BorderWidth="0px" />
                                <BorderRight BorderWidth="0px" />
                            </PaneStyle>
                        </dx:SplitterPane>
                    </Panes>

                </dx:ASPxSplitter>

            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancelPrint" runat="server" Text="<%$Resources:app.language,Cancel%>" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientbtnPrintStorePopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnPrintReort" runat="server" Text="Print" AutoPostBack="false" UseSubmitBehavior="true">
                <%--<ClientSideEvents Click="RevCost.ClientApplyCopyVersionCompanyButton_Click" />--%>
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientbtnPrintStorePopup_Shown"
            CloseUp="RevCost.ClientbtnPrintStoreButton_CloseUp" />
    </dx:ASPxPopupControl>

    <!-- Unit-->
    <dx:ASPxPopupControl ID="VersionCompanyUnitPopup" runat="server" Width="1500" Height="500" AllowDragging="True" HeaderText="Show Unit" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientVersionCompanyUnitPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="VersionCompanyUnitGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientVersionCompanyUnitGrid" Width="100%" KeyFieldName="UnitId"
                    OnCustomCallback="VersionCompanyUnitGrid_CustomCallback">
                    <Settings HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Auto" />
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Carrier" VisibleIndex="1" Caption="Carrier" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Flt_Type" VisibleIndex="2" Caption="Flt Type" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Ac_ID" VisibleIndex="3" Caption="Ac Id" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Ori" VisibleIndex="4" Caption="Dep" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Des" VisibleIndex="5" Caption="Arr" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Network" VisibleIndex="6" Caption="NetWork" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Cls" VisibleIndex="7" Caption="Cls" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Supplier" VisibleIndex="8" Caption="Supplier" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Curr" VisibleIndex="9" Caption="Curr" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CalUnit" VisibleIndex="10" Caption="CalUnit" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M01" VisibleIndex="11" Caption="M01" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M02" VisibleIndex="12" Caption="M02" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M03" VisibleIndex="13" Caption="M03" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M04" VisibleIndex="14" Caption="M04" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M05" VisibleIndex="15" Caption="M05" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M06" VisibleIndex="16" Caption="M06" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M07" VisibleIndex="17" Caption="M07" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M08" VisibleIndex="18" Caption="M08" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M09" VisibleIndex="19" Caption="M09" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M10" VisibleIndex="20" Caption="M10" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M11" VisibleIndex="21" Caption="M11" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M12" VisibleIndex="22" Caption="M12" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="K1" VisibleIndex="23" Caption="K1" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="K2" VisibleIndex="24" Caption="K2" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="K3" VisibleIndex="25" Caption="K3" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <%-- <dx:GridViewCommandColumn VisibleIndex="6" Width="35" ShowSelectCheckbox="true" ShowClearFilterButton="true"></dx:GridViewCommandColumn>--%>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="true" />
                        <TitlePanel HorizontalAlign="Left"></TitlePanel>
                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                    </Styles>
                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" />
                    <Paddings Padding="0px" />
                    <Border BorderWidth="0px" />
                    <SettingsBehavior AllowFocusedRow="True" />
                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancelUnit" runat="server" Text="<%$Resources:app.language,Cancel%>" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientVersionCompanyUnitPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <%--OnClick="btnUploadUnit_Click"--%>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnUploadUnit" runat="server" Text="Upload Unit" AutoPostBack="false">
                <ClientSideEvents Click="RevCost.ClientUploadUnit_Click" />

            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientVersionCompanyUnitGrid_Shown"
            CloseUp="RevCost.ClientVersionCompanyUnitGrid_CloseUp" />
    </dx:ASPxPopupControl>

    <!-- ROE-->
    <dx:ASPxPopupControl ID="RoePoup" runat="server" Width="1300" Height="500" AllowDragging="True" HeaderText="Show ROE" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientRoePopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="RoeDataGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true" OnCustomCallback="RoeDataGrid_CustomCallback"
                    ClientInstanceName="ClientRoeDataGrid" Width="100%" KeyFieldName="RoeID">
                    <Columns>
                        <%--  <dx:GridViewDataTextColumn FieldName="Ver_ID" VisibleIndex="1" Caption="Version ID" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>--%>
                        <dx:GridViewDataTextColumn FieldName="Curr" VisibleIndex="2" Caption="Curr" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M01" VisibleIndex="3" Caption="M01" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M02" VisibleIndex="4" Caption="M02" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M03" VisibleIndex="5" Caption="M03" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M04" VisibleIndex="6" Caption="M04" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M05" VisibleIndex="7" Caption="M05" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M06" VisibleIndex="8" Caption="M06" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M07" VisibleIndex="9" Caption="M07" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M08" VisibleIndex="10" Caption="M08" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M09" VisibleIndex="11" Caption="M09" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M10" VisibleIndex="12" Caption="M10" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M11" VisibleIndex="13" Caption="M11" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M12" VisibleIndex="14" Caption="M12" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Note" VisibleIndex="24" Caption="Note" Width="250" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="true" />
                    </Styles>
                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                    <%-- <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="ACID;ACGroup;Note" />--%>
                    <Paddings Padding="0px" />
                    <Border BorderWidth="1px" />
                    <BorderBottom BorderWidth="1px" />
                    <SettingsBehavior AllowFocusedRow="True" />
                    <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancelRoe" runat="server" Text="<%$Resources:app.language,Cancel%>" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientRoePopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>

            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientVersionCompanyUnitGrid_Shown"
            CloseUp="RevCost.ClientVersionCompanyUnitGrid_CloseUp" />
    </dx:ASPxPopupControl>

    <dx:ASPxHiddenField ID="RevCostHiddenField" runat="server" ClientInstanceName="ClientRevCostHiddenField"></dx:ASPxHiddenField>

    <dx:ASPxGlobalEvents runat="server">
        <ClientSideEvents ControlsInitialized="RevCost.OnPageInit" />
    </dx:ASPxGlobalEvents>
</asp:Content>

