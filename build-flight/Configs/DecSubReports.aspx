<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DecSubReports.aspx.cs" Inherits="Configs_DecSubReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../Scripts/Common.js"></script>
    <script src="../../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../../signalr/hubs"></script>
    <script type="text/javascript">
        var currentNodeKey = 0;
        var IsApplied = false;
        var copyItem = '';

        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "Companies") {
                ClientCompaniesGrid.SetHeight(e.pane.GetClientHeight());
            }
            else if (e.pane.name == "SubReports") {
                ClientSubReportsGrid.SetHeight(e.pane.GetClientHeight());
            }
        }

        function ClientQueryButton_Click(s, e) {
            var key = ClientCompaniesGrid.GetFocusedNodeKey();
            DoCallback(ClientSubReportsGrid, function () {
                ClientSubReportsGrid.PerformCallback('Refresh|' + key);
            });
        }

        function ClientCompaniesGrid_FocusedNodeChanged(s, e) {
            s.SetFocusedNodeKey(e.nodeKey);
            var key = s.GetFocusedNodeKey();
            if (currentNodeKey == key)
                return;
            currentNodeKey = key;
            DoCallback(ClientSubReportsGrid, function () {
                ClientSubReportsGrid.PerformCallback('Refresh|' + key);
            });
        }

        function ClientSubReportsGrid_EndCallback(s, e) {
            var state = State;
            if (state.View == "SaveForm" && (state.Command == "New" || state.Command == "Edit")) {
                if (s.cpResult == "Success") {
                    ClientEditPopupControl.Hide();
                    ChangeState("List", "", "");
                    var key = ClientCompaniesGrid.GetFocusedNodeKey();
                    DoCallback(ClientSubReportsGrid, function () {
                        ClientSubReportsGrid.PerformCallback('Refresh|' + key);
                    });
                }
                else {
                    alert(s.cpResult);
                }
            }
        }

        function ClientShowReportEditor_ValueChanged(key, value) {
            DoCallback(ClientSubReportCallback, function () {
                ClientSubReportCallback.PerformCallback('ShowReport|' + key + "|" + value);
            });
        }

        function ClientCopyButton_Click(s, e) {
            ClientCopyPopup.Show();
        }

        function ClientCopyPopup_Shown(s, e) {
            var year = ClientForYearEditor.GetValue();
            ClientFromYearEditor.SetValue(year);
            ClientToYearEditor.SetValue(year + 1);
        }

        function ClientApplyButton_Click(s, e) {
            var companyId = ClientCompaniesGrid.GetFocusedNodeKey();
            DoCallback(ClientSubReportsGrid, function () {
                ClientSubReportsGrid.PerformCallback('DoCopy|' + companyId);
            });
        }

        function ClientCheckAllButton_Click(s, e) {
            var cf = confirm("Are you sure?");
            if (cf) {
                var year = ClientForYearEditor.GetValue();
                var reportName = ClientListReportEditor.GetValue();
                var companyId = ClientCompaniesGrid.GetFocusedNodeKey();

                DoCallback(ClientSubReportsGrid, function () {
                    ClientSubReportsGrid.PerformCallback('CheckAll|' + year + "|" + reportName + "|" + companyId);
                });
            }
        }

        function ClientUncheckAllButton_Click(s, e) {
            var cf = confirm("Are you sure?");
            if (cf) {
                var year = ClientForYearEditor.GetValue();
                var reportName = ClientListReportEditor.GetValue();
                var companyId = ClientCompaniesGrid.GetFocusedNodeKey();

                DoCallback(ClientSubReportsGrid, function () {
                    ClientSubReportsGrid.PerformCallback('UncheckAll|' + year + "|" + reportName + "|" + companyId);
                });
            }
        }

        function ClientForYearEditor_ValueChanged(s, e) {
            ClientQueryButton_Click(null, null);
        }
        function ClientListReportEditor_ValueChanged(s, e) {
            ClientQueryButton_Click(null, null);
        }
    </script>

    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>

                        <div style="padding: 10px 10px 10px; font-size: 1.5em; font-weight: bold; margin: 0px 4px 4px; float: right;">
                            <asp:Literal ID="Literal2" runat="server" Text="Thiết lập chỉ tiêu báo cáo đơn vị" />
                        </div>
                        <div style="float: left; display: flex; flex-direction: row;">
                            <dx:ASPxSpinEdit runat="server" ID="ForYearEditor" Height="26" MinValue="2000" MaxValue="9999" Width="120" AllowNull="false" Caption="Year" ClientInstanceName="ClientForYearEditor">
                                <ClientSideEvents ValueChanged="ClientForYearEditor_ValueChanged" />
                            </dx:ASPxSpinEdit>
                            &nbsp;&nbsp;
                             <dx:ASPxComboBox runat="server" ID="ListReportEditor" Height="26" DropDownStyle="DropDownList" Width="300" ValueType="System.String" AllowNull="false" Caption="Report" ClientInstanceName="ClientListReportEditor" OnInit="ListReportEditor_Init">
                                 <ClientSideEvents ValueChanged="ClientListReportEditor_ValueChanged" />
                             </dx:ASPxComboBox>
                            &nbsp;&nbsp;
                            <dx:ASPxButton ID="btnQuery" runat="server" Text="Query" AutoPostBack="false" UseSubmitBehavior="true">
                                <ClientSideEvents Click="ClientQueryButton_Click" />
                            </dx:ASPxButton>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <dx:ASPxButton ID="btnCopy" runat="server" Text="Copy" AutoPostBack="false" UseSubmitBehavior="true">
                                <ClientSideEvents Click="ClientCopyButton_Click" />
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
                    <dx:SplitterPane Name="Companies" Size="400">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxTreeList ID="CompaniesGrid" runat="server" Width="100%" ClientInstanceName="ClientCompaniesGrid"
                                    KeyFieldName="CompanyID" ParentFieldName="ParentID"
                                    OnHtmlRowPrepared="CompaniesGrid_HtmlRowPrepared"
                                    OnDataBound="CompaniesGrid_DataBound">
                                    <Columns>
                                        <dx:TreeListTextColumn FieldName="NameV" VisibleIndex="1" Caption="Company Name" CellStyle-Wrap="True">
                                            <DataCellTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("CompanyID").ToString().Trim() +"-"+ Eval("NameV") %>'></asp:Label>
                                            </DataCellTemplate>
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="ShortName" VisibleIndex="2" Caption="Short Name" Width="80"></dx:TreeListTextColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingNode Enabled="True"></AlternatingNode>
                                    </Styles>
                                    <SettingsSelection AllowSelectAll="true" Enabled="true" Recursive="true" />
                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" ScrollableHeight="500" />
                                    <SettingsSearchPanel Visible="false" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="Description" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="1px" />
                                    <SettingsBehavior AllowFocusedNode="true" />
                                    <SettingsResizing ColumnResizeMode="NextColumn" />
                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                                    <ClientSideEvents NodeClick="ClientCompaniesGrid_FocusedNodeChanged"
                                        ContextMenu="function(s, e) {
                                        if(e.objectKey){
                                            s.SetFocusedNodeKey(e.objectKey);
                                        }
                                        if (e.objectType != 'Node' || s.GetNodeState(e.objectKey) !='Child') 
                                            return;
                                        
                                        ClientPopupMenu.ShowAtPos(ASPxClientUtils.GetEventX(e.htmlEvent), ASPxClientUtils.GetEventY(e.htmlEvent));
                                    }" />
                                </dx:ASPxTreeList>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0">
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                        </PaneStyle>
                    </dx:SplitterPane>
                    <dx:SplitterPane Name="SubReports">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxGridView ID="SubReportsGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                    ClientInstanceName="ClientSubReportsGrid" Width="100%" KeyFieldName="Id"
                                    OnCustomCallback="SubReportsGrid_CustomCallback"
                                    OnHtmlRowPrepared="SubReportsGrid_HtmlRowPrepared"
                                    OnBatchUpdate="SubReportsGrid_BatchUpdate">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="Seq" VisibleIndex="1" Caption="Seq" ReadOnly="true" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Sorting" VisibleIndex="2" Caption="Sorting" ReadOnly="true" Width="90" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="3" Caption="Description" ReadOnly="true" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Calculation" VisibleIndex="4" Caption="Calc" ReadOnly="true" Width="50" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="AccountGroup" VisibleIndex="5" Caption="Account Group" ReadOnly="true" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <PropertiesComboBox>
                                                <Items>
                                                    <dx:ListEditItem Value="T" Text="Doanh thu" />
                                                    <dx:ListEditItem Value="C" Text="Chi phí" />
                                                </Items>
                                            </PropertiesComboBox>
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataCheckColumn FieldName="ShowReport" VisibleIndex="6" Caption="Show Report" ReadOnly="true" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            <DataItemTemplate>
                                                <dx:ASPxCheckBox ID="ShowReportEditor" runat="server" OnInit="ShowReportEditor_Init" Checked='<%# Eval("ShowReport")!=null? Eval("ShowReport"): false  %>' CssClass="checkbok-grid">
                                                    <RootStyle Paddings-Padding="0"></RootStyle>
                                                </dx:ASPxCheckBox>
                                            </DataItemTemplate>
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataCheckColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingRow Enabled="true" />
                                        <CommandColumn Spacing="10px" Wrap="False" />
                                    </Styles>
                                    <Settings ShowStatusBar="Visible" ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="1px" />
                                    <SettingsResizing ColumnResizeMode="Control" />
                                    <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                                    <Templates>
                                        <StatusBar>
                                            <dx:ASPxButton ID="btnCheckAll" runat="server" Text="Check All" AutoPostBack="false" UseSubmitBehavior="true">
                                                <ClientSideEvents Click="ClientCheckAllButton_Click" />
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btnUnCheckAll" runat="server" Text="Uncheck All" AutoPostBack="false" UseSubmitBehavior="true">
                                                <ClientSideEvents Click="ClientUncheckAllButton_Click" />
                                            </dx:ASPxButton>
                                        </StatusBar>
                                    </Templates>
                                    <ClientSideEvents
                                        EndCallback="ClientSubReportsGrid_EndCallback" />
                                </dx:ASPxGridView>
                                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="SubReportsGrid"></dx:ASPxGridViewExporter>
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
    <dx:ASPxPopupControl ID="CopyPopup" runat="server" ClientInstanceName="ClientCopyPopup" Width="500px" Height="150px"
        HeaderText="Copy" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowFooter="true">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxFormLayout ID="CopyForm" runat="server" ColCount="2" RequiredMarkDisplayMode="None" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientCopyForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="From Year">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit ID="FromYearEditor" runat="server" AllowNull="false" ClientInstanceName="ClientFromYearEditor" MinValue="2000" MaxValue="9999" Width="120" AutoResizeWithContainer="true">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="true" ErrorText="*" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="To Year">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit ID="ToYearEditor" runat="server" AllowNull="false" ClientInstanceName="ClientToYearEditor" MinValue="2000" MaxValue="9999" Width="120" AutoResizeWithContainer="true">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="true" ErrorText="*" />
                                        </ValidationSettings>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="From Report" ColumnSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="FromReportEditor" runat="server" AllowNull="false" ClientInstanceName="ClientFromReportEditor" OnInit="FromReportEditor_Init" Width="100%" AutoResizeWithContainer="true">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="true" ErrorText="*" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                         <dx:LayoutItem Caption="To Report" ColumnSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="ToReportEditor" runat="server" AllowNull="false" ClientInstanceName="ClientToReportEditor" OnInit="FromReportEditor_Init" Width="100%" AutoResizeWithContainer="true">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="true" ErrorText="*" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:ASPxFormLayout>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCopyCancel" runat="server" Text="Close" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientCopyPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCopyApply" runat="server" Text="Apply" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientApplyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Shown="ClientCopyPopup_Shown" />
    </dx:ASPxPopupControl>

    <dx:ASPxPopupMenu ID="ASPxPopupMenu1" runat="server"
        ClientInstanceName="ClientPopupMenu"
        GutterWidth="0px" ItemSpacing="5px">
        <Items>
            <dx:MenuItem Name="miCopy" Text="Copy" Image-Url="../Content/images/action/copy.png">
            </dx:MenuItem>
            <dx:MenuItem Name="miPasteFocused" Text="Paste into focused company" Image-Url="../Content/images/action/paste.png">
            </dx:MenuItem>
            <dx:MenuItem Name="miPasteSelected" Text="Paste into selected companies" Image-Url="../Content/images/action/paste.png">
            </dx:MenuItem>
        </Items>
        <ClientSideEvents Init="function(s, e){
            s.GetItemByName('miPasteFocused').SetEnabled(false);
            s.GetItemByName('miPasteSelected').SetEnabled(false);
            }"
            ItemClick="function(s, e) {
            if (e.item.name == 'miCopy') {
                var year = ClientForYearEditor.GetValue();
                var reportName = ClientListReportEditor.GetValue();
                var companyId = ClientCompaniesGrid.GetFocusedNodeKey();

                copyItem =  companyId + '|' + year + '|' + reportName;

                s.GetItemByName('miPasteFocused').SetEnabled(true);
                s.GetItemByName('miPasteSelected').SetEnabled(true);
                return;
            }
            if (e.item.name == 'miPasteFocused') {
                var year = ClientForYearEditor.GetValue();
                var reportName = ClientListReportEditor.GetValue();
                var companyId = ClientCompaniesGrid.GetFocusedNodeKey();

                var pasteItem =  companyId + '|' + year + '|' + reportName;
                //console.log('Copy Item: ' + copyItem);
                //console.log('Paste Item: ' + pasteItem);

                if(copyItem == pasteItem) {
                    console.log('Same node') ;
                    return;
                }

                DoCallback(ClientSubReportsGrid, function () {
                    ClientSubReportsGrid.PerformCallback('CopyNode|' + copyItem + '|' + pasteItem);
                });

                return;
            }
            if (e.item.name == 'miPasteSelected') {
                ClientCompaniesGrid.GetSelectedNodeValues('CompanyID', function (values) { 
                    if(values.length <= 0) 
                        return; 
                    var year = ClientForYearEditor.GetValue();
                    var reportName = ClientListReportEditor.GetValue();
                    for (let i = 0; i < values.length; i++) {
                        var pasteItem =  values[i] + '|' + year + '|' + reportName;
                        DoCallback(ClientSubReportsGrid, function () {
                            ClientSubReportsGrid.PerformCallback('CopyNode|' + copyItem + '|' + pasteItem);
                        });
                       ClientCompaniesGrid.SelectNode(values[i], false);
                    }
                });  
            }
        }" />
    </dx:ASPxPopupMenu>
    <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="ClientSubReportCallback" OnCallback="ASPxCallback1_Callback"></dx:ASPxCallback>
</asp:Content>

