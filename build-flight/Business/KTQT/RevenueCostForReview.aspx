<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RevenueCostForReview.aspx.cs" Inherits="Business_KTQT_RevenueCostForReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/KTQTRevCostForReview.js"></script>
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
    </style>
    <dx:ASPxSplitter ID="contentSplitter" runat="server" ClientInstanceName="ClientContentSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live">
        <ClientSideEvents PaneResized="RevCost.ClientContentSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="40" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div class="title">
                            <asp:Literal ID="Literal1" runat="server" Text="Revenue Cost for Review" />
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle>
                    <BorderTop BorderWidth="0px"></BorderTop>
                    <BorderLeft BorderWidth="0px"></BorderLeft>
                    <BorderRight BorderWidth="0px"></BorderRight>
                    <BorderBottom BorderWidth="0px"></BorderBottom>
                    <Paddings PaddingLeft="0" PaddingRight="0" PaddingBottom="0" PaddingTop="0" />
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Separator-Visible="False">
                <Panes>
                    <dx:SplitterPane Size="450" Separator-Visible="False">
                        <Panes>
                            <dx:SplitterPane Size="50%">
                                <Panes>
                                    <dx:SplitterPane>
                                        <Panes>
                                            <dx:SplitterPane Size="70" Separator-Visible="False">
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
                                                                        <ClientSideEvents ValueChanged="RevCost.ClientVersionType_ValueChanged" />
                                                                    </dx:ASPxRadioButtonList>
                                                                </td>
                                                                <td>
                                                                    <dx:ASPxButton ID="btnQuery" runat="server" Text="Query" AutoPostBack="false" UseSubmitBehavior="true">
                                                                        <ClientSideEvents Click="RevCost.ClientQuery_Click" />
                                                                    </dx:ASPxButton>
                                                                </td>
                                                            </tr>
                                                            <tr class="Separator">
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <%-- <dx:ASPxComboBox ID="cboCompanies" ClientInstanceName="ClientCompanies" Caption="Company" runat="server" ValueType="System.Int32" AutoResizeWithContainer="true" Width="100%" OnInit="cboCompanies_Init">
                                                                        <ClientSideEvents ValueChanged="RevCost.ClientCompanies_ValueChanged" />
                                                                    </dx:ASPxComboBox>--%>
                                                                    <dx:ASPxDropDownEdit ID="CompanyDropDown" runat="server" ClientInstanceName="ClientCompanyDropDown"
                                                                        AllowUserInput="False" EnableAnimation="False" Caption="Company" AutoResizeWithContainer="true" Width="100%">                                                                       
                                                                        <DropDownWindowTemplate>
                                                                            <dx:ASPxTreeList ID="TreeCompanies" runat="server" ClientInstanceName="ClientTreeCompanies"
                                                                                OnCustomJSProperties="TreeCompanies_CustomJSProperties" OnDataBound="TreeCompanies_DataBound" OnHtmlRowPrepared="TreeCompanies_HtmlRowPrepared"
                                                                                KeyFieldName="CompanyID" ParentFieldName="ParentID" OnInit="TreeCompanies_Init" Width="500" Height="300">
                                                                                <Border BorderStyle="Solid" />
                                                                                <SettingsBehavior AllowFocusedNode="true" />
                                                                                <SettingsEditing ConfirmDelete="true" />
                                                                                <SettingsPager Mode="ShowAllNodes">
                                                                                </SettingsPager>
                                                                                <Settings VerticalScrollBarMode="Auto" ScrollableHeight="300" HorizontalScrollBarMode="Auto" />
                                                                                <Columns>
                                                                                    <dx:TreeListTextColumn FieldName="NameV" VisibleIndex="0" Caption="Name" Width="250">
                                                                                    </dx:TreeListTextColumn>
                                                                                    <dx:TreeListTextColumn FieldName="ShortName" VisibleIndex="1" Caption="Short Name" Width="100">
                                                                                    </dx:TreeListTextColumn>
                                                                                    <dx:TreeListDateTimeColumn FieldName="AreaCode" VisibleIndex="2" Caption="Area" Width="50">
                                                                                    </dx:TreeListDateTimeColumn>
                                                                                </Columns>
                                                                                  <ClientSideEvents Init="RevCost.TreeListInitHandler" EndCallback="RevCost.TreeListEndCallbackHandler"
                                                                                    NodeClick="RevCost.TreeListNodeClickHandler" />
                                                                            </dx:ASPxTreeList>
                                                                        </DropDownWindowTemplate>
                                                                     <%--   <Buttons>
                                                                            <dx:EditButton Text="Clear"></dx:EditButton>
                                                                        </Buttons>--%>
                                                                        <ClientSideEvents DropDown="RevCost.DropDownHandler" ButtonClick="RevCost.ButtonClickHandler" />
                                                                    </dx:ASPxDropDownEdit>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                                <PaneStyle>
                                                    <BorderTop BorderWidth="1px"></BorderTop>
                                                    <BorderLeft BorderWidth="1px"></BorderLeft>
                                                    <BorderRight BorderWidth="1px"></BorderRight>
                                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                                    <Paddings PaddingLeft="5" PaddingRight="0" PaddingBottom="0" PaddingTop="6" />
                                                </PaneStyle>
                                            </dx:SplitterPane>
                                            <dx:SplitterPane Name="VersionsPane" Separator-Visible="False">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxGridView ID="VersionGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                            ClientInstanceName="ClientVersionGrid" Width="100%" KeyFieldName="VersionID"
                                                            OnCustomCallback="VersionGrid_CustomCallback">
                                                            <Columns>
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
                                                            <Settings ShowTitlePanel="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" VerticalScrollBarStyle="Standard" />
                                                            <Paddings Padding="0px" />
                                                            <Border BorderWidth="1px" />
                                                            <BorderBottom BorderWidth="0px" />
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
                                                            <Templates>
                                                                <TitlePanel>
                                                                    <div style="float: left">
                                                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="Version Type"></dx:ASPxLabel>
                                                                    </div>
                                                                </TitlePanel>
                                                            </Templates>
                                                             <ClientSideEvents FocusedRowChanged="RevCost.ClientVersionGrid_FocusedRowChanged"
                                                                BeginCallback="RevCost.ClientVersionGrid_BeginCallback"
                                                                EndCallback="RevCost.ClientVersionGrid_EndCallback" />
                                                        </dx:ASPxGridView>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                                <PaneStyle>
                                                    <BorderTop BorderWidth="0px"></BorderTop>
                                                    <BorderLeft BorderWidth="0px"></BorderLeft>
                                                    <BorderRight BorderWidth="0px"></BorderRight>
                                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                                    <Paddings PaddingLeft="0" PaddingRight="0" PaddingBottom="1" PaddingTop="0" />
                                                </PaneStyle>
                                            </dx:SplitterPane>

                                        </Panes>
                                    </dx:SplitterPane>
                                </Panes>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="VersionCompanyPane" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="VersionCompanyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientVersionCompanyGrid" Width="100%" KeyFieldName="VerCompanyID"
                                            OnCustomCallback="VersionCompanyGrid_CustomCallback"
                                            OnCustomDataCallback="VersionCompanyGrid_CustomDataCallback">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="VersionName" VisibleIndex="1" Caption="Version Name" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="VersionNumber" VisibleIndex="2" Caption="Number" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="VerLevel" VisibleIndex="3" Caption="Level" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ReportType" VisibleIndex="4" Caption="Type" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>
                                               <%-- <dx:GridViewCommandColumn VisibleIndex="5" Width="30">
                                                    <CustomButtons>
                                                        <dx:GridViewCommandColumnCustomButton ID="btnVersionFiles" Text="">
                                                            <Image Url="../../Content/images/more-detail-glyph.png" Height="16"></Image>
                                                        </dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:GridViewCommandColumn>--%>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                                <TitlePanel HorizontalAlign="Left"></TitlePanel>
                                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                            </Styles>
                                            <Settings ShowTitlePanel="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="400" VerticalScrollBarStyle="Standard" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="0px" />
                                            <SettingsResizing ColumnResizeMode="NextColumn" />
                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                                            <Templates>
                                                <TitlePanel>
                                                    <div style="float: left">
                                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="Version Company"></dx:ASPxLabel>
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
                                <PaneStyle>
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <BorderLeft BorderWidth="0px"></BorderLeft>
                                    <BorderRight BorderWidth="0px"></BorderRight>
                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                    <Paddings PaddingLeft="0" PaddingRight="0" PaddingBottom="0" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Size="40">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxTreeList ID="CompanyGrid" runat="server" AutoGenerateColumns="false" Width="100%" ClientInstanceName="ClientCompanyGrid"
                                            KeyFieldName="CompanyID">
                                            <Columns>
                                                <dx:TreeListTextColumn FieldName="NameV" Caption="Name"></dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="ShortName" Caption="Short Name"></dx:TreeListTextColumn>
                                            </Columns>
                                            <Settings ShowColumnHeaders="false" ScrollableHeight="300" HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Auto" />
                                            <SettingsBehavior AutoExpandAllNodes="true" FocusNodeOnLoad="true" AllowFocusedNode="true" />
                                        </dx:ASPxTreeList>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                            </dx:SplitterPane>
                        </Panes>
                        <PaneStyle>
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <BorderLeft BorderWidth="0px"></BorderLeft>
                            <BorderRight BorderWidth="0px"></BorderRight>
                            <BorderBottom BorderWidth="0px"></BorderBottom>
                            <Paddings PaddingLeft="0" PaddingRight="0" PaddingBottom="0" PaddingTop="0" />
                        </PaneStyle>
                    </dx:SplitterPane>
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane Name="CompanyStores" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxTreeList ID="StoresGrid" runat="server" Width="100%" ClientInstanceName="ClientStoresGrid" EnableCallbacks="true"
                                            KeyFieldName="StoreID" ParentFieldName="ParentStoreID" Caption="Stores" Styles-Header-HorizontalAlign="Center"
                                            OnHtmlRowPrepared="StoresGrid_HtmlRowPrepared"
                                            OnCustomCallback="StoresGrid_CustomCallback"
                                            OnCustomColumnDisplayText="StoresGrid_CustomColumnDisplayText">
                                            <Columns>
                                                <%-- <dx:TreeListDataColumn FieldName="Sorting" VisibleIndex="0" Caption="Sorting" Width="80" HeaderStyle-Wrap="True"></dx:TreeListDataColumn>--%>
                                                <dx:TreeListDataColumn FieldName="Description" VisibleIndex="0" Width="300" Caption="Description" HeaderStyle-Wrap="True">
                                                    <DataCellTemplate>
                                                        <asp:Label runat="server" Font-Bold='<%# Eval("Calculation").ToString().Equals("SUM")? true: false%>' Text='<%# Eval("Sorting").ToString().Trim() +". "+ Eval("Description") %>'></asp:Label>
                                                    </DataCellTemplate>
                                                </dx:TreeListDataColumn>
                                                <dx:TreeListDataColumn FieldName="Calculation" VisibleIndex="1" Caption="Calc" Width="50" HeaderStyle-Wrap="True"></dx:TreeListDataColumn>
                                                <dx:TreeListDataColumn FieldName="Curr" VisibleIndex="2" Caption="Curr" Width="50" HeaderStyle-Wrap="True"></dx:TreeListDataColumn>
                                                <dx:TreeListTextColumn FieldName="Amount" VisibleIndex="4" Caption="Amount" Width="150" HeaderStyle-Wrap="True">
                                                    <PropertiesTextEdit DisplayFormatString="N2" />
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="AllocatedDriver" VisibleIndex="23" Caption="Allocated Driver" Width="140" HeaderStyle-Wrap="True">
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="ACID" VisibleIndex="25" Caption="AC" Width="60" HeaderStyle-Wrap="True">
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="AllocatedRT" VisibleIndex="26" Caption="AllocatedRT" Width="100" HeaderStyle-Wrap="True">
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="Airports" VisibleIndex="27" Caption="Airports" Width="100" HeaderStyle-Wrap="True">
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="AllocatedFLT" VisibleIndex="28" Caption="AllocatedFLT" Width="100" HeaderStyle-Wrap="True">
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="AllocateFltDirection" VisibleIndex="29" Caption="Direction" Width="70" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="Network" VisibleIndex="30" Caption="Network" Width="65" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="Carrier" VisibleIndex="31" Caption="Carrier" Width="80" HeaderStyle-Wrap="True">
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="Fields" VisibleIndex="32" Caption="Fields" Width="80" HeaderStyle-Wrap="True">
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="Division" VisibleIndex="33" Caption="Division" Width="80" HeaderStyle-Wrap="True">
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="DirectIndirect" VisibleIndex="34" Caption="Direct Indirect" Width="110" HeaderStyle-Wrap="True">
                                                </dx:TreeListTextColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingNode Enabled="True"></AlternatingNode>
                                            </Styles>
                                            <Settings ShowTreeLines="true" GridLines="Both" VerticalScrollBarMode="Auto" ScrollableHeight="300" HorizontalScrollBarMode="Auto" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="0px" />
                                            <SettingsBehavior AllowFocusedNode="true" AllowSort="false" />
                                            <SettingsResizing ColumnResizeMode="Control" />
                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                                            <Border BorderStyle="None" />
                                             <ClientSideEvents FocusedNodeChanged="RevCost.ClientStoresGrid_FocusedNodeChanged"
                                                BeginCallback="RevCost.ClientStoresGrid_BeginCallback"
                                                EndCallback="RevCost.ClientStoresGrid_EndCallback" />
                                        </dx:ASPxTreeList>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <PaneStyle>
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <BorderLeft BorderWidth="1px"></BorderLeft>
                                    <BorderRight BorderWidth="1px"></BorderRight>
                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                    <Paddings PaddingLeft="0" PaddingRight="0" PaddingBottom="0" PaddingTop="0" />
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Size="40">
                            </dx:SplitterPane>
                        </Panes>
                        <PaneStyle>
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <BorderLeft BorderWidth="0px"></BorderLeft>
                            <BorderRight BorderWidth="0px"></BorderRight>
                            <BorderBottom BorderWidth="0px"></BorderBottom>
                            <Paddings PaddingLeft="0" PaddingRight="0" PaddingBottom="0" PaddingTop="0" />
                        </PaneStyle>
                    </dx:SplitterPane>
                </Panes>
                <PaneStyle>
                    <BorderTop BorderWidth="0px"></BorderTop>
                    <BorderLeft BorderWidth="0px"></BorderLeft>
                    <BorderRight BorderWidth="0px"></BorderRight>
                    <BorderBottom BorderWidth="0px"></BorderBottom>
                    <Paddings PaddingLeft="0" PaddingRight="0" PaddingBottom="0" PaddingTop="0" />
                </PaneStyle>
            </dx:SplitterPane>

        </Panes>
    </dx:ASPxSplitter>

</asp:Content>

