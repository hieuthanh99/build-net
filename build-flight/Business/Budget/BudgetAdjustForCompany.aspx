<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BudgetAdjustForCompany.aspx.cs" Inherits="Business_Budget_BudgetAdjustForCompany" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/BudgetAdjustForCompany.js"></script>

    <dx:ASPxPanel runat="server" ID="MainPanel" ClientInstanceName="ClientMainPanel" CssClass="main-container" EnableCallbackAnimation="true" Width="100%">
        <PanelCollection>
            <dx:PanelContent>
                <div class="content-pane">
                    <dx:ASPxSplitter ID="contentSplitter" runat="server" ClientInstanceName="ClientContentSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live">
                        <ClientSideEvents PaneResized="RevCost.ClientContentSplitter_PaneResized" />
                        <Panes>
                            <dx:SplitterPane Size="30">
                                <Separator Visible="False"></Separator>
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxButton ID="MenuButton" ClientInstanceName="MenuButton" AllowFocus="false" runat="server" AutoPostBack="False" CssClass="button"
                                            Height="40px" GroupName="Menu">
                                            <ClientSideEvents Click="RevCost.ClientShowMenuButton_Click" />
                                            <Image Url="../../Content/images/SpringboardMenu.png"></Image>
                                        </dx:ASPxButton>
                                        <div class="powered-text">
                                            <asp:Literal ID="Literal1" runat="server" Text="Budget Adjust for Department" />
                                            <%--<dx:ASPxLabel ID="lbTitle" runat="server" ClientInstanceName="ClientlbTitle" Text="Budget Adjust for Department" Font-Size="Medium" Font-Bold="true"></dx:ASPxLabel>--%>
                                        </div>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                            </dx:SplitterPane>
                            <dx:SplitterPane>
                                <Separator Visible="False"></Separator>
                                <Panes>
                                    <dx:SplitterPane Name="BudgetAdjustPane" Size="80%">
                                        <Separator Visible="False"></Separator>
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxGridView ID="BudgetAdjustGrid" runat="server" Width="100%" ClientInstanceName="ClientBudgetAdjustGrid" EnableCallBacks="true"
                                                    Caption="Điều chuyển & bổ sung ngân sách (Theo công văn số)" SettingsEditing-Mode="Inline" OnRowInserting="BudgetAdjustGrid_RowInserting"
                                                    OnRowUpdating="BudgetAdjustGrid_RowUpdating" OnRowDeleting="BudgetAdjustGrid_RowDeleting" OnCustomUnboundColumnData="BudgetAdjustGrid_CustomUnboundColumnData"
                                                    KeyFieldName="ID" Styles-Header-HorizontalAlign="Center" OnCustomCallback="BudgetAdjustGrid_CustomCallback">
                                                    <ClientSideEvents FocusedRowChanged="RevCost.ClientBudgetAdjustGrid_FocusedRowChanged"
                                                        BeginCallback="RevCost.ClientBudgetAdjustGrid_BeginCallback"
                                                        EndCallback="RevCost.ClientBudgetAdjustGrid_EndCallback"
                                                        Init="RevCost.ClientBudgetAdjustGrid_Init"
                                                        CustomButtonClick="RevCost.ClientBudgetAdjustGrid_CustomButtonClick" />
                                                    <Border BorderWidth="1px" />
                                                    <SettingsPager Visible="true" Mode="ShowAllRecords" />
                                                    <Settings VerticalScrollBarMode="Auto" />
                                                    <SettingsBehavior AllowFocusedRow="true" AllowSort="false" ConfirmDelete="true" />
                                                    <SettingsText ConfirmDelete="Do you want to delete the record ?" />
                                                    <SettingsResizing ColumnResizeMode="Control" />
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="NO" Caption="No" VisibleIndex="0" UnboundType="String" ReadOnly="true" Width="5%" CellStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataColumn FieldName="DOC_NUMBER" VisibleIndex="1" Caption="Doc Number" Width="15%" HeaderStyle-Wrap="True">
                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataColumn>
                                                        <dx:GridViewDataDateColumn FieldName="DOC_DATE" VisibleIndex="2" Width="10%" Caption="Doc Date" CellStyle-Wrap="True" HeaderStyle-Wrap="True">
                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>

                                                            <HeaderStyle Wrap="True"></HeaderStyle>

                                                            <CellStyle Wrap="True"></CellStyle>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataColumn FieldName="APPROVED_BY" VisibleIndex="3" Caption="Approved By" Width="10%" HeaderStyle-Wrap="True">
                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataColumn>
                                                        <dx:GridViewDataTextColumn FieldName="DOC_MONTH" VisibleIndex="4" Caption="Doc Month" Width="5%" CellStyle-HorizontalAlign="Center">
                                                            <HeaderStyle Wrap="True" />
                                                            <PropertiesTextEdit DisplayFormatString="N0"></PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataComboBoxColumn FieldName="ADJUST_TYPE" VisibleIndex="5" Caption="Adjust Type" Width="10%" HeaderStyle-Wrap="True">
                                                            <PropertiesComboBox DropDownStyle="DropDownList">
                                                                <Items>
                                                                    <dx:ListEditItem Value="DC" Text="Điều chuyển" />
                                                                    <dx:ListEditItem Value="BS" Text="Bổ sung" />
                                                                    <dx:ListEditItem Value="TK" Text="Tiết kiệm" />
                                                                </Items>
                                                            </PropertiesComboBox>

                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataColumn FieldName="NOTES" VisibleIndex="6" Caption="Notes" Width="30%"></dx:GridViewDataColumn>
                                                        <dx:GridViewDataCheckColumn FieldName="STATUS" VisibleIndex="7" Caption="Post" Width="5%">
                                                            <PropertiesCheckEdit ValueType="System.String" ValueChecked="01" ValueUnchecked="00"></PropertiesCheckEdit>
                                                        </dx:GridViewDataCheckColumn>
                                                        <dx:GridViewCommandColumn VisibleIndex="8" Caption="#" Width="10%" ShowNewButtonInHeader="true" ShowEditButton="true" ShowDeleteButton="true"
                                                            ShowUpdateButton="true" ShowCancelButton="true" ShowClearFilterButton="true">
                                                            <CustomButtons>
                                                                <dx:GridViewCommandColumnCustomButton ID="btnBudgetAdjustFiles" Text="Files">
                                                                    <%--<Image Url="../../Content/images/more-detail-glyph.png" Height="16"></Image>--%>
                                                                </dx:GridViewCommandColumnCustomButton>
                                                            </CustomButtons>
                                                        </dx:GridViewCommandColumn>
                                                    </Columns>
                                                    <Styles>
                                                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                    </Styles>
                                                    <Paddings Padding="0px" />
                                                    <Border BorderStyle="None" />
                                                    <BorderBottom BorderWidth="1px" />
                                                </dx:ASPxGridView>
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                    </dx:SplitterPane>
                                    <dx:SplitterPane Name="BudgetAdjustRoePane" Size="20%">
                                        <Separator Visible="False"></Separator>
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxGridView ID="BudgetAdjustRoeGrid" runat="server" Width="100%" ClientInstanceName="ClientBudgetAdjustRoeGrid" EnableCallBacks="true"
                                                    Caption="Khai báo tỷ giá Bante/VND" KeyFieldName="ID" Styles-Header-HorizontalAlign="Center" SettingsEditing-Mode="Inline"
                                                    OnRowInserting="BudgetAdjustRoeGrid_RowInserting" OnRowUpdating="BudgetAdjustRoeGrid_RowUpdating" OnRowDeleting="BudgetAdjustRoeGrid_RowDeleting"
                                                    OnCustomCallback="BudgetAdjustRoeGrid_CustomCallback">
                                                    <ClientSideEvents BeginCallback="RevCost.ClientBudgetAdjustRoeGrid_BeginCallback"
                                                        EndCallback="RevCost.ClientBudgetAdjustRoeGrid_EndCallback" />
                                                    <Columns>
                                                        <dx:GridViewDataColumn FieldName="CURR" VisibleIndex="0" Caption="Curr" Width="20%" HeaderStyle-Wrap="True" CellStyle-HorizontalAlign="Center">
                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataColumn>
                                                        <dx:GridViewDataTextColumn FieldName="ROE" VisibleIndex="1" Caption="Roe" Width="50%" HeaderStyle-Wrap="True">
                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewCommandColumn VisibleIndex="2" Caption="#" Width="30%" ShowNewButtonInHeader="true" ShowEditButton="true" ShowDeleteButton="true"
                                                            ShowUpdateButton="true" ShowCancelButton="true" ShowClearFilterButton="true">
                                                        </dx:GridViewCommandColumn>
                                                    </Columns>
                                                    <Styles>
                                                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                    </Styles>
                                                    <Settings ShowTitlePanel="true" ShowStatusBar="Visible" VerticalScrollBarMode="Auto" />
                                                    <Paddings Padding="0px" />
                                                    <Border BorderWidth="1px" />
                                                    <BorderBottom BorderWidth="1px" />
                                                    <SettingsBehavior AllowFocusedRow="true" AllowSort="false" ConfirmDelete="true" />
                                                    <SettingsText ConfirmDelete="Do you want to delete the record ?" />
                                                    <SettingsResizing ColumnResizeMode="Control" />
                                                    <SettingsPager Visible="true" Mode="ShowAllRecords" />
                                                    <Border BorderStyle="None" />
                                                    <Templates>
                                                        <StatusBar>
                                                            <dx:ASPxButton ID="btnSelectSubAccount" ClientInstanceName="ClientbtnSelectSubAccount" runat="server"
                                                                Text="Chọn nội dung điều chuyển/bổ sung" RenderMode="Button" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientbtnSelectSubAccount_Click" />
                                                            </dx:ASPxButton>
                                                        </StatusBar>
                                                    </Templates>
                                                </dx:ASPxGridView>
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                    </dx:SplitterPane>
                                </Panes>
                                <ContentCollection>
                                    <dx:SplitterContentControl runat="server"></dx:SplitterContentControl>
                                </ContentCollection>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="BudgetAdjustTransactionHDPane">
                                <Separator Visible="False"></Separator>
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="BudgetAdjustTransactionHDGrid" runat="server" Width="100%" ClientInstanceName="ClientBudgetAdjustTransactionHDGrid" EnableCallBacks="true"
                                            KeyFieldName="ID" OnCustomCallback="BudgetAdjustTransactionHDGrid_CustomCallback" Styles-Header-HorizontalAlign="Center"
                                            Caption="Điều chuyển & bổ sung ngân sách đi" OnCustomUnboundColumnData="BudgetAdjustTransactionHDGrid_CustomUnboundColumnData">
                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientBudgetAdjustTransactionHDGrid_FocusedRowChanged"
                                                        BeginCallback="RevCost.ClientBudgetAdjustTransactionHDGrid_BeginCallback"
                                                        EndCallback="RevCost.ClientBudgetAdjustTransactionHDGrid_EndCallback" />
                                            <Border BorderWidth="1px" />
                                            <Templates>
                                                <StatusBar>
                                                    <dx:ASPxButton ID="btnSelectCompany" ClientInstanceName="ClientbtnSelectCompany" runat="server" Text="Chọn đơn vị nhận điều chuyển" 
                                                        RenderMode="Button" AutoPostBack="false">
                                                        <ClientSideEvents Click="RevCost.ClientbtnSelectCompany_Click" />
                                                    </dx:ASPxButton>
                                                    <dx:ASPxButton ID="btnReport" ClientInstanceName="ClientbtnReport" runat="server" Text="Báo cáo" RenderMode="Button" AutoPostBack="false"></dx:ASPxButton>
                                                </StatusBar>
                                            </Templates>
                                            <SettingsPager Visible="true" Mode="ShowAllRecords" />
                                            <Settings ShowTitlePanel="true" ShowStatusBar="Visible" VerticalScrollBarMode="Auto" />
                                            <SettingsBehavior AllowFocusedRow="true" AllowSort="false" />
                                            <SettingsResizing ColumnResizeMode="Control" />
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="NO" Caption="No" VisibleIndex="0" UnboundType="String" ReadOnly="true" HeaderStyle-Wrap="True" Width="5%" CellStyle-HorizontalAlign="Center">
                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataColumn FieldName="ShortName" VisibleIndex="1" Caption=" " Width="5%" ReadOnly="true"></dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="NameV" VisibleIndex="2" Caption=" " Width="20%" ReadOnly="true"></dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="SORTING" VisibleIndex="3" Caption="Sorting" Width="5%" ReadOnly="true" HeaderStyle-Wrap="True">
                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="DESCRIPTION" VisibleIndex="4" Caption="Description" Width="20%" ReadOnly="true" HeaderStyle-Wrap="True">
                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="CURR" VisibleIndex="5" Caption="Curr" Width="5%" ReadOnly="true" HeaderStyle-Wrap="True">
                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataTextColumn FieldName="BUDGET" VisibleIndex="6" Caption="Budget<br/>(1)" Width="10%" ReadOnly="true" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CREDIT_AMOUNT" VisibleIndex="7" Caption="Credit Amount<br/>(2)" Width="10%" ReadOnly="true" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DEBIT_AMOUNT" VisibleIndex="8" Caption="Debit Amount<br/>(3)" Width="10%" ReadOnly="true" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn VisibleIndex="9" Caption="Total<br/>(4=1+2-3)" Width="10%" ReadOnly="true" HeaderStyle-Wrap="True">
                                                    <DataItemTemplate>
                                                        <%#Convert.ToDecimal(Eval("BUDGET")) + Convert.ToDecimal(Eval("CREDIT_AMOUNT")) - Convert.ToDecimal(Eval("DEBIT_AMOUNT"))%>
                                                    </DataItemTemplate>
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Styles>
                                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                            </Styles>
                                            <Paddings Padding="0px" />
                                            <Border BorderStyle="None" />
                                            <BorderBottom BorderWidth="1px" />
                                        </dx:ASPxGridView>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="BudgetAdjustTransactionPane">
                                <Separator Visible="False"></Separator>
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="BudgetAdjustTransactionGrid" runat="server" Width="100%" ClientInstanceName="ClientBudgetAdjustTransactionGrid" EnableCallBacks="true"
                                            KeyFieldName="ID" OnCustomCallback="BudgetAdjustTransactionGrid_CustomCallback" Styles-Header-HorizontalAlign="Center" SettingsEditing-Mode="Inline"
                                            Caption="Điều chuyển & bổ sung chi tiết đến chỉ tiêu ngân sách nhận" OnCustomUnboundColumnData="BudgetAdjustTransactionGrid_CustomUnboundColumnData"
                                             OnRowUpdating="BudgetAdjustTransactionGrid_RowUpdating">
                                            <%--<ClientSideEvents EndCallback="RevCost.ClientBudgetDetailGrid_EndCallback" />--%>
                                            <Border BorderWidth="1px" />
                                            <SettingsPager Visible="true" Mode="ShowAllRecords" />
                                            <Settings ShowTitlePanel="true" ShowStatusBar="Visible" VerticalScrollBarMode="Auto" />
                                            <SettingsBehavior AllowFocusedRow="true" AllowSort="false" />
                                            <SettingsResizing ColumnResizeMode="Control" />
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="NO"  Caption="No" VisibleIndex="0" UnboundType="String" ReadOnly="true" HeaderStyle-Wrap="True" Width="5%" CellStyle-HorizontalAlign="Center">
                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataColumn FieldName="ShortName" VisibleIndex="1" Caption=" " Width="5%" ReadOnly="true"></dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="NameV" VisibleIndex="2" Caption=" " Width="15%" ReadOnly="true"></dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="SORTING" VisibleIndex="3" Caption="Sorting" Width="5%" ReadOnly="true" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="DESCRIPTION" VisibleIndex="4" Caption="Description" Width="15%" ReadOnly="true" HeaderStyle-Wrap="True">
                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="CURR" VisibleIndex="5" Caption="Curr" Width="5%" ReadOnly="true" HeaderStyle-Wrap="True">
                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataTextColumn FieldName="CREDIT_AMOUNT" VisibleIndex="6" Caption="Credit Amount<br/>(2)" Width="10%" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DEBIT_AMOUNT" VisibleIndex="7" Caption="Debit Amount<br/>(3)" Width="10%" ReadOnly="true" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="REMARKS" VisibleIndex="8" Caption="Remarks" Width="30%"></dx:GridViewDataTextColumn>
                                                <dx:GridViewCommandColumn VisibleIndex="9" ShowEditButton="true" ShowCancelButton="true" ShowUpdateButton="true" ShowClearFilterButton="true" 
                                                    Width="5%" Caption=" "></dx:GridViewCommandColumn>
                                            </Columns>
                                            <TotalSummary>
                                                <dx:ASPxSummaryItem FieldName="DEBIT_AMOUNT" SummaryType="Sum" DisplayFormat="N2" />
                                            </TotalSummary>
                                            <Styles>
                                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                            </Styles>
                                            <Paddings Padding="0px" />
                                            <Border BorderStyle="None" />
                                            <BorderBottom BorderWidth="1px" />
                                        </dx:ASPxGridView>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                            </dx:SplitterPane>
                        </Panes>
                    </dx:ASPxSplitter>
                </div>
                <div class="left-pane">
                    <dx:ASPxSplitter ID="splitterVersion" runat="server" CssClass="main-menu" ClientInstanceName="ClientSplitterVersion" Orientation="Vertical" Width="550" Height="100%">
                        <ClientSideEvents PaneResized="RevCost.ClientSplitterVersion_PaneResized" />
                        <Panes>
                            <dx:SplitterPane Size="100%" Separator-Visible="False">
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
                                                                    <dx:ASPxSpinEdit ID="VersionYearEditor" Caption="Year" MinValue="2000" MaxValue="9999" runat="server" Width="60px"></dx:ASPxSpinEdit>
                                                                </td>
                                                                <td style="width: 230px;">
                                                                    <dx:ASPxRadioButtonList ID="rdoVersionType" runat="server" RepeatDirection="Horizontal" ValueType="System.String">
                                                                        <Border BorderWidth="0" BorderStyle="None" />
                                                                        <Paddings Padding="0" />
                                                                        <Items>
                                                                            <dx:ListEditItem Value="P" Text="Planning" Selected="true" />
                                                                            <dx:ListEditItem Value="E" Text="Estimate" />
                                                                            <dx:ListEditItem Value="A" Text="Actual" />
                                                                        </Items>
                                                                    </dx:ASPxRadioButtonList>
                                                                </td>
                                                                <td style="text-align: right; padding-right: 15px">
                                                                    <dx:ASPxButton ID="btnQuery" runat="server" Text="Query" AutoPostBack="false" UseSubmitBehavior="true">
                                                                        <ClientSideEvents Click="RevCost.ClientQuery_Click" />
                                                                    </dx:ASPxButton>
                                                                </td>
                                                                <td>
                                                                    <dx:ASPxButton ID="HideMenuButton" ClientInstanceName="MenuButton" RenderMode="Link" Text="Hide" ImagePosition="Top" runat="server" AutoPostBack="False"
                                                                        Height="30px" GroupName="Menu">
                                                                        <ClientSideEvents Click="RevCost.ClientHideMenuButton_Click" />
                                                                        <Image Url="../../Content/images/action/go_back.png"></Image>
                                                                    </dx:ASPxButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                            <dx:SplitterPane Name="VersionsPane">
                                                <Separator Visible="False"></Separator>
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxGridView ID="VersionGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                            ClientInstanceName="ClientVersionGrid" Width="100%" KeyFieldName="VersionID"
                                                            OnCustomCallback="VersionGrid_CustomCallback">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="VersionType" VisibleIndex="2" Caption="Type" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="3" Caption="Description" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="4" Caption="Status" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                            </Columns>
                                                            <Styles>
                                                                <AlternatingRow Enabled="true" />
                                                                <TitlePanel HorizontalAlign="Left"></TitlePanel>
                                                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                            </Styles>
                                                            <Settings ShowTitlePanel="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" VerticalScrollBarStyle="Standard" />
                                                            <Paddings Padding="0px" />
                                                            <Border BorderWidth="1px" />
                                                            <BorderBottom BorderWidth="1px" />
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
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
                        </Panes>
                    </dx:ASPxSplitter>
                </div>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>

    <dx:ASPxPopupControl ID="BudgetAdjustOri" runat="server" Width="1000" Height="800" AllowDragging="true" ShowFooter="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
        Modal="true" AllowResize="false" PopupAnimationType="Fade" ClientInstanceName="ClientBudgetAdjustOri" ShowCloseButton="true" CloseAction="CloseButton" HeaderText="Điều chuyển/bổ sung ngân sách">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" HeaderStyle-HorizontalAlign="Left" HeaderText=" " Collapsed="false" ShowCollapseButton="true" Width="100%" Height="100%">
                    <ContentPaddings Padding="0" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxSplitter ID="AdjustOriSplitter" runat="server" ClientInstanceName="ClientAdjustOriSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live">
                                <ClientSideEvents PaneResized="RevCost.ClientAdjustOriSplitter_PaneResized" />
                                <Panes>
                                    <dx:SplitterPane Separator-Visible="False">
                                        <Panes>
                                            <dx:SplitterPane Separator-Visible="False" Name="VersionCompanyOriPane" Size="50%">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxGridView ID="VersionCompanyGrid" runat="server" EnableCallBacks="true" ClientInstanceName="ClientVersionCompanyGrid"
                                                            KeyFieldName="VerCompanyID" OnCustomUnboundColumnData="VesionCompanyGrid_CustomUnboundColumnData" OnCustomCallback="VersionCompanyGrid_CustomCallback">
                                                            <SettingsBehavior AllowFocusedRow="true" AllowAutoFilter="true" AllowSort="false" />
                                                            <Settings AutoFilterCondition="Contains" VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" />
                                                            <SettingsResizing ColumnResizeMode="Control" />
                                                            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="NO" Caption="No" VisibleIndex="0" UnboundType="String" ReadOnly="true" Width="10%"
                                                                    CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="ShortName" VisibleIndex="1" Caption="Short Name" Width="18%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="NameV" VisibleIndex="2" Caption="Company Name" Width="32%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="VersionName" VisibleIndex="3" Caption="Version Name" Width="40%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                            </Columns>
                                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientVersionCompanyGrid_FocusedRowChanged"
                                                                BeginCallback="RevCost.ClientVersionCompanyGrid_BeginCallback"
                                                                EndCallback="RevCost.ClientVersionCompanyGrid_EndCallback" />
                                                        </dx:ASPxGridView>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                            <dx:SplitterPane Separator-Visible="False">
                                                <Panes>
                                                    <dx:SplitterPane Separator-Visible="False" Name="BudgetOriPane" Size="60%">
                                                        <ContentCollection>
                                                            <dx:SplitterContentControl>
                                                                <dx:ASPxGridView ID="BudgetGrid" runat="server" EnableCallBacks="true" ClientInstanceName="ClientBudgetGrid"
                                                                    KeyFieldName="ID" OnHtmlRowPrepared="BudgetGrid_HtmlRowPrepared" OnCustomCallback="BudgetGrid_CustomCallback">
                                                                    <SettingsBehavior AllowFocusedRow="true" AllowAutoFilter="true" AllowSort="false" />
                                                                    <Settings AutoFilterCondition="Contains" VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" />
                                                                    <SettingsResizing ColumnResizeMode="Control" />
                                                                    <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                                                    <Columns>
                                                                        <dx:GridViewDataTextColumn FieldName="SORTING" VisibleIndex="0" Caption="Sorting" Width="15%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn FieldName="DESCRIPTION" VisibleIndex="1" Caption="Description" Width="40%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn FieldName="CALCULATION" VisibleIndex="2" Caption="Cal" Width="10%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn FieldName="CURR" VisibleIndex="3" Caption="Curr" Width="10%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn FieldName="BUDGET1" VisibleIndex="4" Caption="Budget" Width="25%" HeaderStyle-HorizontalAlign="Center">
                                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                                        </dx:GridViewDataTextColumn>
                                                                    </Columns>
                                                                    <ClientSideEvents FocusedRowChanged="RevCost.ClientBudgetGrid_FocusedRowChanged"
                                                                        BeginCallback="RevCost.ClientBudgetGrid_BeginCallback"
                                                                        EndCallback="RevCost.ClientBudgetGrid_EndCallback" />
                                                                </dx:ASPxGridView>
                                                            </dx:SplitterContentControl>
                                                        </ContentCollection>
                                                    </dx:SplitterPane>
                                                    <dx:SplitterPane Separator-Visible="False" Name="CompanyOriPane" Size="40%">
                                                        <ContentCollection>
                                                            <dx:SplitterContentControl>
                                                                <dx:ASPxGridView ID="CompanyGrid" runat="server" EnableCallBacks="true" ClientInstanceName="ClientCompanyGrid"
                                                                    KeyFieldName="CompanyID" OnCustomUnboundColumnData="CompanyGrid_CustomUnboundColumnData" OnCustomCallback="CompanyGrid_CustomCallback">
                                                                    <SettingsBehavior AllowFocusedRow="true" AllowAutoFilter="true" AllowSort="false" />
                                                                    <Settings AutoFilterCondition="Contains" VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" />
                                                                    <SettingsResizing ColumnResizeMode="Control" />
                                                                    <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                                                    <Columns>
                                                                        <dx:GridViewDataTextColumn FieldName="NO" Caption="No" VisibleIndex="0" UnboundType="String" ReadOnly="true" Width="10%"
                                                                            CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn FieldName="ShortName" VisibleIndex="1" Caption="Short Name" Width="20%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn FieldName="NameV" VisibleIndex="2" Caption="Company Name" Width="60%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                        <dx:GridViewCommandColumn VisibleIndex="3" ShowSelectCheckbox="true" Caption=" " Width="10%"></dx:GridViewCommandColumn>
                                                                    </Columns>
                                                                </dx:ASPxGridView>
                                                            </dx:SplitterContentControl>
                                                        </ContentCollection>
                                                    </dx:SplitterPane>
                                                </Panes>
                                            </dx:SplitterPane>
                                        </Panes>
                                    </dx:SplitterPane>
                                </Panes>
                            </dx:ASPxSplitter>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="3px" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Close" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientBudgetAdjustOri.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApplyCopy" runat="server" Text="Apply" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyBudgetOriButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientBudgetAdjustOri_Shown" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="BudgetAdjustDes" runat="server" Width="1000" Height="800" AllowDragging="true" ShowFooter="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
        Modal="true" AllowResize="false" PopupAnimationType="Fade" ClientInstanceName="ClientBudgetAdjustDes" ShowCloseButton="true" CloseAction="CloseButton" HeaderText="Nhận điều chuyển/bổ sung ngân sách">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" HeaderStyle-HorizontalAlign="Left" HeaderText=" " Collapsed="false" ShowCollapseButton="true" Width="100%" Height="100%">
                    <ContentPaddings Padding="0" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxSplitter ID="AdjustDesSplitter" runat="server" ClientInstanceName="ClientAdjustDesSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live">
                                <ClientSideEvents PaneResized="RevCost.ClientAdjustDesSplitter_PaneResized" />
                                <Panes>
                                    <dx:SplitterPane Separator-Visible="False">
                                        <Panes>
                                            <dx:SplitterPane Separator-Visible="False" Name="VersionCompanyDesPane" Size="50%">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxGridView ID="VersionCompanyDesGrid" runat="server" EnableCallBacks="true" ClientInstanceName="ClientVersionCompanyDesGrid"
                                                            KeyFieldName="VerCompanyID" OnCustomCallback="VersionCompanyDesGrid_CustomCallback">
                                                            <SettingsBehavior AllowFocusedRow="true" AllowAutoFilter="true" AllowSort="false" />
                                                            <Settings AutoFilterCondition="Contains" VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" />
                                                            <SettingsResizing ColumnResizeMode="Control" />
                                                            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="ShortName" VisibleIndex="0" Caption="Short Name" Width="18%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="NameV" VisibleIndex="1" Caption="Company Name" Width="32%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="VersionName" VisibleIndex="2" Caption="Version Name" Width="35%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="3" Caption="Status" Width="15%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                            </Columns>
                                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientVersionCompanyDesGrid_FocusedRowChanged"
                                                                BeginCallback="RevCost.ClientVersionCompanyDesGrid_BeginCallback"
                                                                EndCallback="RevCost.ClientVersionCompanyDesGrid_EndCallback" />
                                                        </dx:ASPxGridView>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                            <dx:SplitterPane Separator-Visible="False" Name="BudgetDesPane" Size="50%">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxGridView ID="BudgetDesGrid" runat="server" EnableCallBacks="true" ClientInstanceName="ClientBudgetDesGrid"
                                                            KeyFieldName="ID" OnHtmlRowPrepared="BudgetDesGrid_HtmlRowPrepared" OnCustomCallback="BudgetDesGrid_CustomCallback">
                                                            <SettingsBehavior AllowFocusedRow="true" AllowAutoFilter="true" AllowSort="false" />
                                                            <Settings AutoFilterCondition="Contains" VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" />
                                                            <SettingsResizing ColumnResizeMode="Control" />
                                                            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="SORTING" VisibleIndex="0" Caption="Sorting" Width="15%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="DESCRIPTION" VisibleIndex="1" Caption="Description" Width="35%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="CALCULATION" VisibleIndex="2" Caption="Cal" Width="10%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="CURR" VisibleIndex="3" Caption="Curr" Width="10%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="BUDGET1" VisibleIndex="4" Caption="Budget" Width="25%" HeaderStyle-HorizontalAlign="Center">
                                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewCommandColumn VisibleIndex="5" ShowSelectCheckbox="true" Caption=" " Width="10%"></dx:GridViewCommandColumn>
                                                            </Columns>
                                                        </dx:ASPxGridView>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                        </Panes>
                                    </dx:SplitterPane>
                                </Panes>
                            </dx:ASPxSplitter>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="3px" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Close" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientBudgetAdjustDes.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApplyCopy" runat="server" Text="Apply" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyBudgetDesButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientBudgetAdjustDes_Shown" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="BudgetAdjustFilesPopup" runat="server" Width="800" Height="300" AllowDragging="True" HeaderText="Budget Adjust Files" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientBudgetAdjustFilesPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" HeaderStyle-HorizontalAlign="Left" Collapsed="false" HeaderText="Version Files" ShowCollapseButton="true" Width="100%">
                    <ContentPaddings Padding="0" />

                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxGridView ID="BudgetAdjustFilesGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                ClientInstanceName="ClientBudgetAdjustFilesGrid" Width="100%" KeyFieldName="ID"
                                OnCustomCallback="BudgetAdjustFilesGrid_CustomCallback">
                                <Columns>
                                    <dx:GridViewCommandColumn VisibleIndex="0" Caption="" Width="80">
                                        <CustomButtons>
                                            <dx:GridViewCommandColumnCustomButton Text="Download" ID="DownloadBudgetAdjustFile"></dx:GridViewCommandColumnCustomButton>
                                        </CustomButtons>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn FieldName="FILE_NAME" VisibleIndex="1" Caption="File Name" Width="200" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        <Settings AutoFilterCondition="Contains"></Settings>
                                        <EditFormSettings Visible="False" />
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DESCRIPTION" VisibleIndex="2" Caption="Description" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        <Settings AutoFilterCondition="Contains"></Settings>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
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
                                <ClientSideEvents CustomButtonClick="RevCost.ClientBudgetAdjustFilesGrid_CustomButtonClick" />
                            </dx:ASPxGridView>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <div style="float: right; padding-right: 5px; padding-top: 4px">
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxUploadControl ID="BudgetAdjustFilesUC" runat="server" ClientInstanceName="ClientBudgetAdjustFilesUC" ShowProgressPanel="true" NullText="Browse file here"
                                    Width="280px" FileUploadMode="OnPageLoad" UploadMode="Advanced" OnFilesUploadComplete="BudgetAdjustFilesUC_FilesUploadComplete" BrowseButton-Text="Browse File">
                                    <ClientSideEvents FilesUploadComplete="RevCost.ClientBudgetAdjustFilesUC_FilesUploadComplete" />
                                    <ValidationSettings MaxFileSize="10000000" AllowedFileExtensions=".jpg,.jpeg,.gif,.doc,.docx,.xls,.xlsx,.pdf,.txt,.png" ShowErrors="true"></ValidationSettings>

                                    <BrowseButton Text="Browse File"></BrowseButton>
                                </dx:ASPxUploadControl>
                            </td>
                            <td style="padding-left: 5px;">
                                <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Upload" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                    <ClientSideEvents Click="RevCost.ClientUploadBudgetAdjustFile_Click" />
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Close" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientBudgetAdjustFilesPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientBudgetAdjustFilesPopup_Shown" />
    </dx:ASPxPopupControl>

    <%--<dx:ASPxCallback ID="PermissionCallback" runat="server" ClientInstanceName="ClientPermissionCallback" OnCallback="PermissionCallback_Callback">
        <ClientSideEvents CallbackComplete="RevCost.ClientPermissionCallback_CallbackComplete" />
    </dx:ASPxCallback>--%>

    <dx:ASPxHiddenField ID="RevCostHiddenField" runat="server" ClientInstanceName="ClientRevCostHiddenField"></dx:ASPxHiddenField>

    <dx:ASPxGlobalEvents runat="server">
        <ClientSideEvents ControlsInitialized="RevCost.OnPageInit" />
    </dx:ASPxGlobalEvents>
</asp:Content>

