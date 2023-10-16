<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BudgetForCompany.aspx.cs" Inherits="Business_Budget_BudgetForCompany" %>

<%@ Register Assembly="DevExpress.XtraReports.v20.2.Web.WebForms, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/BudgetForCompany.js"></script>


    <dx:ASPxPanel runat="server" ID="MainPanel" ClientInstanceName="ClientMainPanel" CssClass="main-container" EnableCallbackAnimation="true" Width="100%">
        <PanelCollection>
            <dx:PanelContent>
                <div class="content-pane">
                    <dx:ASPxSplitter ID="contentSplitter" runat="server" ClientInstanceName="ClientContentSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live">
                        <ClientSideEvents PaneResized="RevCost.ClientContentSplitter_PaneResized" />
                        <Panes>
                            <dx:SplitterPane Size="30" Separator-Visible="False">
                                <Separator Visible="False"></Separator>
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxButton ID="MenuButton" ClientInstanceName="MenuButton" AllowFocus="false" runat="server" AutoPostBack="False" CssClass="button"
                                            Height="40px" GroupName="Menu">
                                            <ClientSideEvents Click="RevCost.ClientShowMenuButton_Click" />
                                            <Image Url="../../Content/images/SpringboardMenu.png"></Image>
                                        </dx:ASPxButton>
                                        <div class="powered-text">
                                            <%--<asp:Literal ID="LiteralTitle" runat="server" Text="Budget for Department/Company"/>--%>
                                            <dx:ASPxLabel ID="lbTitle" runat="server" ClientInstanceName="ClientlbTitle" Text="Budget for Department/Company" Font-Size="Medium" Font-Bold="true"></dx:ASPxLabel>
                                        </div>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="Budget" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="BudgetGrid" runat="server" Width="100%" ClientInstanceName="ClientBudgetGrid" EnableCallBacks="true"
                                            KeyFieldName="ID" Styles-Header-HorizontalAlign="Center" OnCustomCallback="BudgetGrid_CustomCallback"
                                            OnHtmlRowPrepared="BudgetGrid_HtmlRowPrepared">
                                            <Columns>
                                                <dx:GridViewDataColumn FieldName="SORTING" VisibleIndex="0" Caption="Sorting<br/>(1)" Width="80" HeaderStyle-Wrap="True">
                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="DESCRIPTION" VisibleIndex="1" Width="300" Caption="Description<br/>(2)" CellStyle-Wrap="True" HeaderStyle-Wrap="True">
                                                    <HeaderStyle Wrap="True"></HeaderStyle>

                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="CALCULATION" VisibleIndex="2" Caption="Cal" Width="50" HeaderStyle-Wrap="True">
                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataTextColumn FieldName="REV_COST" VisibleIndex="3" Caption="Rev Cost<br/>(3)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ALLOCATED_RATE" VisibleIndex="4" Caption="Allocated Rate<br/>(4)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="AMOUNT" VisibleIndex="5" Caption="Amount<br/>(5)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="BEGIN_BALANCE" VisibleIndex="6" Caption="Begin Balance<br/>(6)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="END_BALANCE" VisibleIndex="7" Caption="End Balance<br/>(7)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="VAT_RATE" VisibleIndex="8" Caption="Vat Rate<br/>(8)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="VAT" VisibleIndex="9" Caption="Vat<br/>(9=8*5)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="BUDGET_CHANGE" VisibleIndex="10" Caption="Budget Change<br/>(10)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ONE_TIME_BUDGET" VisibleIndex="11" Caption="One-Time Budget<br/>(Include Vat) (11)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="BUDGET1" VisibleIndex="12" Caption="Total Budget<br/>(12=5+6+9+10+11)" Width="170" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn VisibleIndex="13" Caption="Total<br/>(13=12-7)" Width="170" HeaderStyle-Wrap="True">
                                                    <DataItemTemplate>
                                                        <%#(Convert.ToDecimal(Eval("BUDGET1")) - Convert.ToDecimal(Eval("END_BALANCE"))).ToString("N2") %>
                                                    </DataItemTemplate>
                                                    <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataCheckColumn VisibleIndex="14" Caption="" Width="50">
                                                    <PropertiesCheckEdit ValueType="System.String" ValueChecked="Y" ValueUnchecked="N"></PropertiesCheckEdit>
                                                </dx:GridViewDataCheckColumn>
                                                <dx:GridViewCommandColumn VisibleIndex="15" Caption="Update" Width="60" HeaderStyle-Wrap="True">
                                                    <CustomButtons>
                                                        <dx:GridViewCommandColumnCustomButton ID="btnUpdateBudget" Text="U">
                                                        </dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>

                                                    <HeaderStyle Wrap="True"></HeaderStyle>
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewCommandColumn VisibleIndex="16" Caption=" " Width="40">
                                                    <CustomButtons>
                                                        <dx:GridViewCommandColumnCustomButton ID="btnBudgetFiles" Text=" ">
                                                            <Image Url="../../Content/images/more-detail-glyph.png" Height="16"></Image>
                                                        </dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:GridViewCommandColumn>
                                            </Columns>
                                            <Styles>
                                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                            </Styles>
                                            <Settings ShowTitlePanel="true" ShowStatusBar="Visible" VerticalScrollBarMode="Auto" VerticalScrollableHeight="300" HorizontalScrollBarMode="Auto" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="1px" />
                                            <SettingsBehavior AllowFocusedRow="true" AllowSort="false" />
                                            <SettingsResizing ColumnResizeMode="Control" />
                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                                            <Border BorderStyle="None" />
                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientBudgetGrid_FocusedRowChanged"
                                                BeginCallback="RevCost.ClientBudgetGrid_BeginCallback"
                                                EndCallback="RevCost.ClientBudgetGrid_EndCallback"
                                                Init="RevCost.ClientBudgetGrid_Init"
                                                CustomButtonClick="RevCost.ClientBudgetGrid_CustomButtonClick" />
                                        </dx:ASPxGridView>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <Separator Visible="False"></Separator>

                                <PaneStyle>
                                    <BorderTop BorderWidth="1px"></BorderTop>
                                    <BorderLeft BorderWidth="1px"></BorderLeft>
                                    <BorderRight BorderWidth="1px"></BorderRight>
                                    <BorderBottom BorderWidth="1px"></BorderBottom>
                                    <Paddings PaddingLeft="0" PaddingRight="1" PaddingBottom="0" PaddingTop="0" />
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Separator-Visible="False">
                                <Separator Visible="False"></Separator>
                                <Panes>
                                    <dx:SplitterPane Separator-Visible="False" Size="380">
                                        <Separator Visible="False"></Separator>
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxLabel Text="Note" runat="server"></dx:ASPxLabel>
                                                <dx:ASPxMemo runat="server" Width="360" Height="50" AutoPostBack="false" ClientInstanceName="ClientmmNote" ID="mmNote" row="8"></dx:ASPxMemo>
                                                <table>
                                                    <tr>
                                                        <td>Creadted By
                                                        </td>
                                                        <td>Updated
                                                        </td>
                                                        <td>Lasted User
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtCreatedBy" Width="120" runat="server" ClientInstanceName="ClienttxtCreatedBy" ReadOnly="true" AutoPostBack="false"></dx:ASPxTextBox>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtUpdatedBy" Width="120" runat="server" ClientInstanceName="ClienttxtUpdatedBy" ReadOnly="true" AutoPostBack="false"></dx:ASPxTextBox>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtLastedBy" Width="120" runat="server" ClientInstanceName="ClienttxtLastedBy" ReadOnly="true" AutoPostBack="false"></dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtCreatedDate" Width="120" runat="server" ClientInstanceName="ClienttxtCreatedDate" ReadOnly="true" AutoPostBack="false"></dx:ASPxTextBox>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtUpdatedDate" Width="120" runat="server" ClientInstanceName="ClienttxtUpdatedDate" ReadOnly="true" AutoPostBack="false"></dx:ASPxTextBox>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtLastedDate" Width="120" runat="server" ClientInstanceName="txtLastedDate" ReadOnly="true" AutoPostBack="false"></dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table style="font-size: larger">
                                                    <tr>
                                                        <td style="width: 160px">
                                                            <dx:ASPxButton ID="btnGetDataBudget" runat="server" Width="155" ClientInstanceName="ClientbtnGetDataBudget" Text="Get Data Budget" RenderMode="Button" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientbtnGetDataBudget_Click" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <dx:ASPxButton ID="btnUpdateRevCostAll" runat="server" Width="195" ClientInstanceName="ClientbtnUpdateRevCostAll" Text="Update Rev_cost All" RenderMode="Button" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientbtnUpdateRevCostAll_Click" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxButton ID="btnViewErr" Enabled="false" runat="server" Width="155" ClientInstanceName="ClientbtnViewErr" Text="View Err" RenderMode="Button" AutoPostBack="false"></dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="btnUpdateRevCost1Sub" runat="server" Width="195" ClientInstanceName="ClientbtnUpdateRevCost1Sub" Text="Update Rev_cost 1Sub" RenderMode="Button" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientbtnUpdateRevCost1Sub_Click" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxButton ID="btnCheck" Enabled="false" runat="server" Width="155" ClientInstanceName="ClientbtnCheck" Text="Check" RenderMode="Button" AutoPostBack="false"></dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="btnGetAllFieldsFor1Sub" runat="server" Width="195" ClientInstanceName="ClientbtnGetAllFieldsFor1Sub" Text="Get All Fields for 1Sub" RenderMode="Button" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientbtnGetAllFieldsFor1Sub_Click" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxButton ID="btnChangeCompany" runat="server" Width="155" ClientInstanceName="ClientbtnChangeCompany" Text="Change Company" RenderMode="Button" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientChangeCompanyButton_Click" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="btnCalculate" runat="server" Width="195" ClientInstanceName="ClientbtnCalculate" Text="Calculate" RenderMode="Button" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientbtnCalculate_Click" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxButton ID="btnViewRevCost" Enabled="false" runat="server" Width="155" ClientInstanceName="ClientbtnViewRevCost" Text="View Rev_Cost" RenderMode="Button" AutoPostBack="false"></dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="btnGetBudgetGas" Enabled="false" runat="server" Width="195" ClientInstanceName="ClientbtnGetBudgetGas" Text="Get Budget Gas" RenderMode="Button" AutoPostBack="false"></dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxButton ID="btnSave" runat="server" Width="155" ClientInstanceName="ClientbtnSave" Text="Save" RenderMode="Button" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientbtnSave_Click" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="btnPrint" runat="server" Width="195" ClientInstanceName="ClientbtnPrint" Text="Report" RenderMode="Button" AutoPostBack="false">
                                                                <ClientSideEvents Click="RevCost.ClientbtnPrint_Click" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>

                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                    </dx:SplitterPane>
                                    <dx:SplitterPane Separator-Visible="False" Name="BudgetDetail">
                                        <Separator Visible="False"></Separator>
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxGridView ID="BudgetDetailGrid" runat="server" Width="100%" ClientInstanceName="ClientBudgetDetailGrid" EnableCallBacks="true"
                                                    KeyFieldName="ID" OnCustomCallback="BudgetDetailGrid_CustomCallback" Styles-Header-HorizontalAlign="Center" OnRowUpdating="BudgetDetailGrid_RowUpdating"
                                                    OnRowDeleting="BudgetDetailGrid_RowDeleting">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn VisibleIndex="0" Caption="#" Width="10%" ShowEditButton="true" ShowDeleteButton="true"
                                                            ShowUpdateButton="true" ShowCancelButton="true" ShowClearFilterButton="true">
                                                        </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataColumn FieldName="BUDGET_MONTH" VisibleIndex="0" Caption="Month<br/>(1)" Width="50" HeaderStyle-Wrap="True">
                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataColumn>
                                                        <dx:GridViewDataTextColumn FieldName="REV_COST" VisibleIndex="1" Caption="Rev Cost<br/>(3)" Width="170" HeaderStyle-Wrap="True">
                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="ALLOCATED_RATE" VisibleIndex="2" Caption="Allocated Rate<br/>(4)" Width="170" HeaderStyle-Wrap="True">
                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="AMOUNT" VisibleIndex="3" Caption="Amount<br/>(5)" Width="170" HeaderStyle-Wrap="True">
                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BEGIN_BALANCE" VisibleIndex="4" Caption="Begin Balance<br/>(6)" Width="170" HeaderStyle-Wrap="True">
                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="END_BALANCE" VisibleIndex="5" Caption="End Balance<br/>(7)" Width="170" HeaderStyle-Wrap="True">
                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="VAT_RATE" VisibleIndex="6" Caption="Vat Rate<br/>(8)" Width="170" HeaderStyle-Wrap="True">
                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="VAT" VisibleIndex="7" Caption="Vat<br/>(9=8*5)" Width="170" HeaderStyle-Wrap="True">
                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BUDGET_CHANGE" VisibleIndex="8" Caption="Budget Change<br/>(10)" Width="170" HeaderStyle-Wrap="True">
                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="ONE_TIME_BUDGET" VisibleIndex="9" Caption="One-Time Budget<br/>(Include Vat) (11)" Width="170" HeaderStyle-Wrap="True">
                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="BUDGET" VisibleIndex="10" Caption="Total Budget<br/>(12=5+6+9+10+11)" Width="170" HeaderStyle-Wrap="True">
                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn VisibleIndex="11" Caption="Total<br/>(13=12-7)" Width="170" HeaderStyle-Wrap="True">
                                                            <DataItemTemplate>
                                                                <%#(Convert.ToDecimal(Eval("BUDGET")) - Convert.ToDecimal(Eval("END_BALANCE"))).ToString("N2") %>
                                                            </DataItemTemplate>
                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="ROE_VN" VisibleIndex="12" Caption="Roe Vnd" Width="100" HeaderStyle-Wrap="True">
                                                            <PropertiesTextEdit DisplayFormatString="N2"></PropertiesTextEdit>

                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <Styles>
                                                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                    </Styles>
                                                    <Settings ShowTitlePanel="true" ShowStatusBar="Visible" VerticalScrollBarMode="Auto" VerticalScrollableHeight="300" HorizontalScrollBarMode="Auto" />
                                                    <Paddings Padding="0px" />
                                                    <Border BorderWidth="1px" />
                                                    <BorderBottom BorderWidth="1px" />
                                                    <SettingsBehavior AllowFocusedRow="true" AllowSort="false" />
                                                    <SettingsResizing ColumnResizeMode="Control" />
                                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                                                    <Border BorderStyle="None" />
                                                    <ClientSideEvents EndCallback="RevCost.ClientBudgetDetailGrid_EndCallback" />
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
                    </dx:ASPxSplitter>
                </div>
                <div class="left-pane">
                    <dx:ASPxSplitter ID="splitterVersion" runat="server" CssClass="main-menu" ClientInstanceName="ClientSplitterVersion" Orientation="Vertical" Width="550" Height="100%">
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
                                                                    <dx:ASPxSpinEdit ID="VersionYearEditor" Caption="Year" MinValue="2000" MaxValue="9999" runat="server" Width="60px"></dx:ASPxSpinEdit>
                                                                </td>
                                                                <td style="width: 230px;">
                                                                    <dx:ASPxRadioButtonList ID="rdoVersionType" runat="server" RepeatDirection="Horizontal" ValueType="System.String">
                                                                        <Border BorderWidth="0" BorderStyle="None" />
                                                                        <Paddings Padding="0" />
                                                                        <Items>
                                                                            <dx:ListEditItem Value="P" Text="Planning" Selected="true" />
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
                                            <dx:SplitterPane Name="VersionsPane" Separator-Visible="False">
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
                                                                <dx:GridViewDataTextColumn FieldName="VersionName" VisibleIndex="1" Caption="Version Name" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="VersionNumber" VisibleIndex="2" Caption="Number" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="VerLevel" VisibleIndex="3" Caption="Level" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="ReportType" VisibleIndex="4" Caption="Type" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewCommandColumn VisibleIndex="5" Width="30">
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
                                                            <Settings ShowTitlePanel="true" ShowFooter="true" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="400" VerticalScrollBarStyle="Standard" />
                                                            <Paddings Padding="0px" />
                                                            <Border BorderWidth="1px" />
                                                            <BorderBottom BorderWidth="1px" />
                                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                                                            <Templates>
                                                                <FooterRow>
                                                                    <dx:ASPxButton ID="btnGetDataBudget" runat="server" ClientInstanceName="ClientGetDataBudgetButton" Text="Get Data Budget" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                        <ClientSideEvents Click="RevCost.ClientbtnGetDataBudget_Click" />
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="btnChangeCompany" runat="server" ClientInstanceName="ClientChangeCompanyButton" Text="Change Company" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                        <ClientSideEvents Click="RevCost.ClientChangeCompanyButton_Click" />
                                                                        <Image Url="../../Content/images/relationship.png"></Image>
                                                                    </dx:ASPxButton>
                                                                </FooterRow>
                                                                <StatusBar>
                                                                    <dx:ASPxButton ID="btnPost" runat="server" Text="Post" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                        <Image Url="../../Content/images/action/Appr.gif"></Image>
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="btnUnPost" runat="server" Text="UnPost" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                        <Image Url="../../Content/images/action/UnAppr.gif"></Image>
                                                                    </dx:ASPxButton>
                                                                </StatusBar>
                                                            </Templates>
                                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientVersionCompanyGrid_FocusedRowChanged"
                                                                BeginCallback="RevCost.ClientVersionCompanyGrid_BeginCallback"
                                                                EndCallback="RevCost.ClientVersionCompanyGrid_EndCallback"
                                                                CustomButtonClick="RevCost.ClientVersionCompanyGrid_CustomButtonClick" />
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

    <dx:ASPxPopupControl ID="CompanyListPopup" runat="server" Width="400" Height="300" AllowDragging="True" HeaderText="Change Company" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientCompanyListPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxGridView ID="CompanyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                    ClientInstanceName="ClientCompanyGrid" Width="100%" KeyFieldName="CompanyID"
                    OnCustomCallback="CompanyGrid_CustomCallback">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="ShortName" VisibleIndex="1" Caption="Short Name" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NameV" VisibleIndex="2" Caption="Name VN" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="true" />
                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                    </Styles>
                    <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" VerticalScrollBarStyle="Standard" />
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Cancel" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ClientCompanyListPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Apply" AutoPostBack="false" ClientInstanceName="ClientApplyButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientCompanyListPopup_Shown" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="VersionCompanyFilesPopup" runat="server" Width="800" Height="300" AllowDragging="True" HeaderText="Version Company Files" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientVersionCompanyFilesPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxRoundPanel ID="VersionCompanyFilesRoundPanel" runat="server" HeaderStyle-HorizontalAlign="Left" Collapsed="false" HeaderText="Version Files" ShowCollapseButton="true" Width="100%">
                    <ContentPaddings Padding="0" />

                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxGridView ID="VersionCompanyFilesGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                ClientInstanceName="ClientVersionCompanyFilesGrid" Width="100%" KeyFieldName="VerCompanyFileID"
                                OnCustomCallback="VersionCompanyFilesGrid_CustomCallback">
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Close" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientVersionCompanyFilesPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <%--<dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Save" AutoPostBack="false" ClientInstanceName="ClientApplyVersionCompanyFilesButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyVersionCompanyFilesButton_Click" />
                <Image Url="../../Content/images/action/save.png" Height="16"></Image>
            </dx:ASPxButton>--%>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientVersionCompanyFilesPopup_Shown" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="BudgetFilesPopup" runat="server" Width="800" Height="300" AllowDragging="True" HeaderText="Budget Files" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientBudgetFilesPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" HeaderStyle-HorizontalAlign="Left" Collapsed="false" HeaderText="Version Files" ShowCollapseButton="true" Width="100%">
                    <ContentPaddings Padding="0" />

                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxGridView ID="BudgetFilesGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                ClientInstanceName="ClientBudgetFilesGrid" Width="100%" KeyFieldName="ID"
                                OnCustomCallback="BudgetFilesGrid_CustomCallback">
                                <Columns>
                                    <dx:GridViewCommandColumn VisibleIndex="0" Caption="" Width="80">
                                        <CustomButtons>
                                            <dx:GridViewCommandColumnCustomButton Text="Download" ID="DownloadBudgetFile"></dx:GridViewCommandColumnCustomButton>
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
                                <ClientSideEvents CustomButtonClick="RevCost.ClientBudgetFilesGrid_CustomButtonClick" />
                            </dx:ASPxGridView>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <div style="float: right; padding-right: 5px; padding-top: 4px">
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxUploadControl ID="BudgetFilesUC" runat="server" ClientInstanceName="ClientBudgetFilesUC" ShowProgressPanel="true" NullText="Browse file here"
                                    Width="280px" FileUploadMode="OnPageLoad" UploadMode="Advanced" OnFilesUploadComplete="BudgetFilesUC_FilesUploadComplete" BrowseButton-Text="Browse File">
                                    <ClientSideEvents FilesUploadComplete="RevCost.ClientBudgetFilesUC_FilesUploadComplete" />
                                    <ValidationSettings MaxFileSize="10000000" AllowedFileExtensions=".jpg,.jpeg,.gif,.doc,.docx,.xls,.xlsx,.pdf,.txt,.png" ShowErrors="true"></ValidationSettings>

                                    <BrowseButton Text="Browse File"></BrowseButton>
                                </dx:ASPxUploadControl>
                            </td>
                            <td style="padding-left: 5px;">
                                <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Upload" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                    <ClientSideEvents Click="RevCost.ClientUploadBudgetFile_Click" />
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
                <ClientSideEvents Click="function(s, e) {{ ClientBudgetFilesPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <%--<dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Save" AutoPostBack="false" ClientInstanceName="ClientApplyVersionCompanyFilesButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientApplyBudgetFilesButton_Click" />
                <Image Url="../../Content/images/action/save.png" Height="16"></Image>
            </dx:ASPxButton>--%>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="RevCost.ClientBudgetFilesPopup_Shown" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="ReportPopup" runat="server" Maximized="true" AllowDragging="True" HeaderText="Báo cáo"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientReportPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" HeaderStyle-HorizontalAlign="Left" HeaderText="" Collapsed="false" ShowCollapseButton="true" Width="100%" Height="100%">
                    <ContentPaddings Padding="0" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Orientation="Horizontal" Width="100%" Height="100%" SeparatorVisible="false">
                                <Panes>
                                    <dx:SplitterPane Size="295" ScrollBars="Auto">
                                        <PaneStyle>
                                            <BorderTop BorderWidth="0" />
                                            <Paddings PaddingBottom="0" PaddingRight="0" PaddingTop="0" PaddingLeft="0" />
                                        </PaneStyle>
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxFormLayout ID="ParameterForm" runat="server" Width="100%" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientParameterForm"
                                                    AlignItemCaptionsInAllGroups="true">
                                                    <Items>
                                                        <dx:LayoutGroup Caption="Danh sách báo cáo">
                                                            <Items>
                                                                <dx:LayoutItem ShowCaption="False">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxRadioButtonList ID="rdReport" runat="server" ValueType="System.String" ClientInstanceName="rdReport">
                                                                                <Items>
                                                                                    <dx:ListEditItem Value="1" Text="Báo cáo kế hoạch ngân sách phân kỳ" Selected="true" />
                                                                                    <dx:ListEditItem Value="2" Text="Báo cáo kế hoạch ngân sách" />
                                                                                </Items>
                                                                                <Border BorderStyle="None" />
                                                                                <ClientSideEvents SelectedIndexChanged="RevCost.rdReport_SelectedIndexChanged" Init="RevCost.rdReport_Init"/>
                                                                            </dx:ASPxRadioButtonList>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                            </Items>
                                                        </dx:LayoutGroup>

                                                        <dx:LayoutGroup Caption="Giai đoạn">
                                                            <Items>
                                                                <dx:LayoutItem ShowCaption="False">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxDateEdit ID="dedFromDate" runat="server" ClientInstanceName="dedFromDate" NullText="Từ ngày">
                                                                            </dx:ASPxDateEdit>
                                                                            <dx:ASPxDateEdit ID="dedToDate" runat="server" ClientInstanceName="dedToDate" NullText="Đến ngày">
                                                                            </dx:ASPxDateEdit>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                            </Items>
                                                        </dx:LayoutGroup>

                                                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>

                                                        <dx:LayoutItem Caption="">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxButton ID="btnPrintReport" runat="server" Text="Xem báo cáo" AutoPostBack="false" ClientInstanceName="ClientPrintReportButton" UseSubmitBehavior="true">
                                                                        <%--<ClientSideEvents Click="function(s, e) {{ ClientReportViewer.Refresh(); }}" />--%>
                                                                        <ClientSideEvents Click="RevCost.btnPrintReport_Click" />
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
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                    </dx:SplitterPane>
                                    <dx:SplitterPane ScrollBars="Auto">
                                        <PaneStyle>
                                            <BorderTop BorderWidth="0" />
                                            <Paddings PaddingBottom="0" PaddingRight="0" PaddingTop="0" PaddingLeft="0" />
                                        </PaneStyle>
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxWebDocumentViewer ID="ReportViewer" runat="server"  Width="100%" Height="100%"></dx:ASPxWebDocumentViewer>
                                               
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                    </dx:SplitterPane>
                                </Panes>
                            </dx:ASPxSplitter>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <%--<div style="float: left; padding-left: 5px; padding-top: 4px">
                    <table>
                        <tr>
                            <td style="padding-left: 5px;">
                                <dx:ASPxButton ID="btnShowReport" ClientInstanceName="ClientbtnShowReport" runat="server" Text="Show" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                    <ClientSideEvents Click="RevCost.ClientbtnShowReport_Click" />
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </div>--%>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxHiddenField ID="RevCostHiddenField" runat="server" ClientInstanceName="ClientRevCostHiddenField"></dx:ASPxHiddenField>

    <dx:ASPxGlobalEvents runat="server">
        <ClientSideEvents ControlsInitialized="RevCost.OnPageInit" />
    </dx:ASPxGlobalEvents>
</asp:Content>

