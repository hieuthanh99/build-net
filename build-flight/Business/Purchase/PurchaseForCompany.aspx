<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PurchaseForCompany.aspx.cs" Inherits="Business_RevenueCost_RevenueCostForCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">

    <link href="../../Content/RevCost.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../../Scripts/PageModuleBase.js"></script>
    <script src="../../Scripts/PurchaseForCompany.js"></script>
    <dx:ASPxPanel runat="server" ID="MainPanel" ClientInstanceName="ClientMainPanel" CssClass="main-container" EnableCallbackAnimation="true" Width="100%">
        <PanelCollection>
            <dx:PanelContent>
                <div class="content-pane">
                    <dx:ASPxSplitter ID="contentSplitter" runat="server" ClientInstanceName="ClientContentSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live">
                        <ClientSideEvents PaneResized="RevCost.ClientContentSplitter_PaneResized" />
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
                                            <dx:ASPxLabel ID="lbTitle" runat="server" ClientInstanceName="ClientlbTitle" Text="Purchase for Department/Company" Font-Size="Medium" Font-Bold="true"></dx:ASPxLabel>
                                        </div>
                                        <div style="float: right;">
                                            Version: <dx:ASPxLabel ID="lbVersionNametitle" runat="server" ClientInstanceName="ClientlbTitleVersion" Font-Size="Medium"></dx:ASPxLabel>  
                                            <br />                                          
                                            Company: <dx:ASPxLabel ID="lbVersionCompanyNametitle" runat="server" ClientInstanceName="ClientlbVersionCompanyNametitle" Font-Size="Medium"></dx:ASPxLabel>
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
                                            <dx:SplitterPane Name="PurchaseLVL" Separator-Visible="False" Size="17%">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl>
                                                        <dx:ASPxGridView ID="PurchaseLVLGrid" runat="server" Width="100%" ClientInstanceName="ClientPurchaseLVLGrid" EnableCallBacks="true"
                                                            KeyFieldName="ID" Styles-Header-HorizontalAlign="Center">
                                                            <Border BorderStyle="None" />
                                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllRecords" />
                                                            <Settings ShowTitlePanel="true" ShowStatusBar="Visible" VerticalScrollBarMode="Auto" VerticalScrollableHeight="300" HorizontalScrollBarMode="Auto" />
                                                            <SettingsBehavior AllowFocusedRow="true" AllowSort="false" />
                                                            <SettingsResizing ColumnResizeMode="Control" />
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="PURCHASE_LEVEL" VisibleIndex="2" Caption="Level" Width="50" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="DESCRIPTION" VisibleIndex="3" Caption="Description" Width="450" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                                                                </dx:GridViewDataTextColumn>
                                                            </Columns>
                                                            <Styles>
                                                                <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                            </Styles>
                                                            <Paddings Padding="0px" />
                                                            <Border BorderWidth="1px" />
                                                            <BorderBottom BorderWidth="1px" />
                                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientPurchaseLVLGrid_FocusedRowChanged"
                                                                EndCallback="RevCost.ClientPurchaseLVLGrid_EndCallback" />
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

                                                    <dx:SplitterPane Name="Purchase" Separator-Visible="False">
                                                        <ContentCollection>
                                                            <dx:SplitterContentControl>
                                                                <dx:ASPxGridView ID="PurchaseGrid" runat="server" Width="100%" ClientInstanceName="ClientPurchaseGrid" EnableCallBacks="true"
                                                                    KeyFieldName="ID" Styles-Header-HorizontalAlign="Center"
                                                                    OnCustomCallback="PurchaseGrid_CustomCallback" OnCustomDataCallback="PurchaseGrid_CustomDataCallback"
                                                                    OnCustomColumnDisplayText="PurchaseGrid_CustomColumnDisplayText">
                                                                    <Border BorderStyle="None" />
                                                                    <Templates>
                                                                        <StatusBar>
                                                                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="New" RenderMode="Button" AutoPostBack="false">
                                                                                <ClientSideEvents Click="RevCost.ClientPurchaseNewButton_Click" />
                                                                                <Image Height="16" Url="../../Content/Images/action/add.gif"></Image>
                                                                            </dx:ASPxButton>
                                                                            <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Edit" RenderMode="Button" AutoPostBack="false">
                                                                                <ClientSideEvents Click="RevCost.ClientPurchaseEditButton_Click" />
                                                                                <Image Height="16" Url="../../Content/Images/action/edit.gif"></Image>
                                                                            </dx:ASPxButton>
                                                                            <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Delete" RenderMode="Button" AutoPostBack="false">
                                                                                <ClientSideEvents Click="RevCost.ClientPurchaseDeleteButton_Click" />
                                                                                <Image Height="16" Url="../../Content/Images/action/delete.gif"></Image>
                                                                            </dx:ASPxButton>
                                                                            <dx:ASPxButton ID="btnRefreshSrore" runat="server" Text="<%$Resources:app.language,Refresh%>" RenderMode="Button" AutoPostBack="false">
                                                                                <ClientSideEvents Click="RevCost.ClientPurchaseRefreshButton_Click" />
                                                                                <Image Url="../../Content/images/action/action_refresh.gif" Height="16"></Image>
                                                                            </dx:ASPxButton>
                                                                            <%-- <dx:ASPxButton ID="btnSaveChangesStore" runat="server" Text="Save Stores" RenderMode="Button" AutoPostBack="false">
                                                                                <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                                            </dx:ASPxButton>--%>
                                                                            <%--<dx:ASPxButton ID="btnCalculateStore" runat="server" Text="<%$Resources:app.language,Calculate%>" RenderMode="Button" AutoPostBack="false">
                                                                                <ClientSideEvents Click="RevCost.ClientCalculateStore_Click" />
                                                                                <Image Url="../../Content/images/if_Calculator_669940.png" Height="16"></Image>
                                                                            </dx:ASPxButton>--%>

                                                                            <%--<dx:ASPxButton ID="btnChangeCompanyStore" runat="server" Text="<%$Resources:app.language,ChangeCompany%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                                <ClientSideEvents Click="RevCost.ClientChangeCompanyButton_Click" />
                                                                                <Image Url="../../Content/images/relationship.png"></Image>
                                                                            </dx:ASPxButton>--%>
                                                                        </StatusBar>
                                                                        <TitlePanel>
                                                                            <div style="float: left">
                                                                                <dx:ASPxLabel runat="server" Font-Bold="true" Text="Purchase"></dx:ASPxLabel>
                                                                            </div>
                                                                        </TitlePanel>
                                                                    </Templates>
                                                                    <SettingsPager Visible="true" PageSize="50" Mode="ShowAllRecords" />
                                                                    <Settings ShowTitlePanel="true" ShowStatusBar="Visible" VerticalScrollBarMode="Auto" VerticalScrollableHeight="300" HorizontalScrollBarMode="Auto" />
                                                                    <SettingsBehavior AllowFocusedRow="true" AllowSort="false" />
                                                                    <SettingsResizing ColumnResizeMode="Control" />
                                                                    <Columns>
                                                                        <dx:GridViewDataColumn FieldName="ID" VisibleIndex="0" Caption="ID" Width="80" FixedStyle="Left" Visible="false">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="DESCRIPTION" VisibleIndex="0" Caption="Description" Width="250" FixedStyle="Left">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="ITEM_UNIT_ID" VisibleIndex="1" Width="80" Caption="Unit" FixedStyle="Left" CellStyle-Wrap="True">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="QUANTITY" VisibleIndex="2" Caption="Quantity" FixedStyle="Left">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="PRICE" VisibleIndex="2" Caption="Price" FixedStyle="Left">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="TAX_RATE" VisibleIndex="2" Caption="Tax Rate" FixedStyle="Left">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="TAX_AMOUNT" VisibleIndex="2" Caption="Tax Amount" FixedStyle="Left">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="AMOUNT" VisibleIndex="2" Caption="Amount" FixedStyle="Left">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="PLAN_AMOUNT" VisibleIndex="2" Caption="Plan Amount" FixedStyle="Left">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="PLAN_TIME" VisibleIndex="2" Caption="Plan Time" FixedStyle="Left">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="PURCHASE_TIME" VisibleIndex="2" Caption="Purchase Time" FixedStyle="Left">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="IMPLEMENT_DURATION" VisibleIndex="2" Caption="Implement Duration" FixedStyle="Left">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="PURCHASE_TIME_UNIT" VisibleIndex="2" Caption="Purchase Time Unit" FixedStyle="Left">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="SUP_SEL_FORM" VisibleIndex="2" Caption="Purchase Form" FixedStyle="Left">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="SUP_SEL_CODE" VisibleIndex="2" Caption="Supplier" FixedStyle="Left">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn FieldName="NOTE" VisibleIndex="2" Caption="Note" FixedStyle="Left" Width="250">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                        </dx:GridViewDataColumn>
                                                                    </Columns>
                                                                    <Styles>
                                                                        <%--  <AlternatingRow Enabled="True"></AlternatingRow>--%>
                                                                        <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                                                                    </Styles>
                                                                    <Paddings Padding="0px" />
                                                                    <Border BorderWidth="1px" />
                                                                    <BorderBottom BorderWidth="1px" />
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
                                                </Panes>
                                                <ContentCollection>
                                                    <dx:SplitterContentControl runat="server"></dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                           <%-- <dx:SplitterPane>
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
                                                                                    <dx:ASPxMemo ID="StoreNoteEditor" runat="server" Width="100%" ClientInstanceName="ClientStoreNoteEditor" Rows="4">
                                                                                        <ClientSideEvents KeyDown="RevCost.ClientStoreNoteEditor_KeyDown"
                                                                                            KeyPress="RevCost.ClientStoreNoteEditor_KeyPress"
                                                                                            TextChanged="RevCost.ClientStoreNoteEditor_TextChanged" />
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
                                                    <dx:SplitterPane Size="550" Separator-Visible="False">
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
                                                                                <dx:GridViewCommandColumn VisibleIndex="0" Caption="" Width="80">
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
                                            </dx:SplitterPane>--%>
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
                                                                    <dx:ASPxSpinEdit ID="VersionYearEditor" Caption="<%$Resources:app.language,Year%>" MinValue="2000" MaxValue="9999" runat="server" Width="60px"></dx:ASPxSpinEdit>
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
                                                                    </dx:ASPxRadioButtonList>
                                                                </td>
                                                                <td>
                                                                    <dx:ASPxButton ID="btnQuery" runat="server" Text="<%$Resources:app.language,Query%>" AutoPostBack="false" UseSubmitBehavior="true">
                                                                        <%--<ClientSideEvents Click="RevCost.ClientQuery_Click" />--%>
                                                                    </dx:ASPxButton>
                                                                </td>
                                                                <td>
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
                                                            ClientInstanceName="ClientVersionGrid" Width="100%" KeyFieldName="VersionID" PreviewFieldName="Description"
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
                                                                </TitlePanel>
                                                                <StatusBar>
                                                                    <%--<dx:ASPxButton ID="btnChangeCompany" runat="server" ClientInstanceName="ClientChangeCompanyButton" Text="<%$Resources:app.language,ChangeCompany%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                        <ClientSideEvents Click="RevCost.ClientChangeCompanyButton_Click" />
                                                                        <Image Url="../../Content/images/relationship.png"></Image>
                                                                    </dx:ASPxButton>--%>                                                                                                                                      
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
                                                                <dx:GridViewDataTextColumn FieldName="ReportType" VisibleIndex="4" Caption="<%$Resources:app.language,Type%>" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="5" Caption="<%$Resources:app.language,Status%>" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                                    <Settings AutoFilterCondition="Contains"></Settings>

                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                                </dx:GridViewDataTextColumn>                    
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
                                                                    <dx:ASPxButton ID="btnChangeCompany" runat="server" ClientInstanceName="ClientChangeCompanyButton" Text="<%$Resources:app.language,ChangeCompany%>" RenderMode="Button" AutoPostBack="false" Image-Width="16">
                                                                        <ClientSideEvents Click="RevCost.ClientChangeCompanyButton_Click" />
                                                                        <Image Url="../../Content/images/relationship.png"></Image>
                                                                    </dx:ASPxButton>
                                                                </FooterRow>                                                                
                                                                <TitlePanel>
                                                                    <div style="float: left">
                                                                        <dx:ASPxLabel runat="server" Font-Bold="true" Text="<%$Resources:app.language,VersionCompany%>"></dx:ASPxLabel>
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

    <dx:ASPxPopupControl ID="CompanyListPopup" runat="server" Width="400" Height="300" AllowDragging="True" HeaderText="<%$Resources:app.language,ChangeCompany%>" ShowFooter="True"
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



    <dx:ASPxPopupControl ID="PurchaseEditPopupControl" runat="server" Width="350" Height="250" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientPurchaseEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Purchase Name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="PurchaseItemEditor" Width="250" DropDownRows="16" ClientInstanceName="ClientPurchaseItemEditor" OnInit="PurchaseItemEditor_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Unit">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="PurchaseUnitEditor" Width="250" DropDownRows="16" ClientInstanceName="ClientPurchaseUnitEditor" OnInit="PurchaseUnitEditor_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Quantity">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="QuantityEditor" Width="250" ClientInstanceName="ClientQuantityEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Price">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="PriceEditor" Width="250" ClientInstanceName="ClientPriceEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Tax Rate">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="TaxRateEditor" Width="250" ClientInstanceName="ClientTaxRateEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Plan Amount">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="PlanAmountEditor" Width="250" ClientInstanceName="ClientPlanAmountEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Plan Time">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="PlanTimeEditor" Width="250" ClientInstanceName="ClientPlanTimeEditor" MaxValue="12" MinValue="1" NumberType="Integer">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Purchase Time">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="PurchaseTimeEditor" Width="100" DropDownRows="16" ValueType="System.String" ClientInstanceName="ClientPurchaseTimeEditor">
                                        <Items>
                                            <dx:ListEditItem Value="1" Text="Tháng 1" />
                                            <dx:ListEditItem Value="2" Text="Tháng 2" />
                                            <dx:ListEditItem Value="3" Text="Tháng 3" />
                                            <dx:ListEditItem Value="4" Text="Tháng 4" />
                                            <dx:ListEditItem Value="5" Text="Tháng 5" />
                                            <dx:ListEditItem Value="6" Text="Tháng 6" />
                                            <dx:ListEditItem Value="7" Text="Tháng 7" />
                                            <dx:ListEditItem Value="8" Text="Tháng 8" />
                                            <dx:ListEditItem Value="9" Text="Tháng 9" />
                                            <dx:ListEditItem Value="10" Text="Tháng 10" />
                                            <dx:ListEditItem Value="11" Text="Tháng 11" />
                                            <dx:ListEditItem Value="12" Text="Tháng 12" />
                                        </Items>
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Implement Duration">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ImplementDurationEditor" Width="100" ClientInstanceName="ClientImplementDurationEditor" MaxValue="12" MinValue="1" NumberType="Integer">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Purchase Time Unit">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="PurchaseTimeUnitEditor" Width="100" DropDownRows="16" ValueType="System.String" ClientInstanceName="ClientPurchaseTimeUnitEditor">
                                        <Items>
                                            <dx:ListEditItem Value="T" Text="Tháng" />
                                        </Items>
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Purchase Form">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="PurchaseFormEditor" Width="250" DropDownRows="16" ClientInstanceName="ClientPurchaseFormEditor" OnInit="PurchaseFormEditor_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Supplier">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="SupplierEditor" Width="250" DropDownRows="16" ClientInstanceName="ClientSupplierEditor" OnInit="SupplierEditor_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" ErrorText="Required" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Note">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="NoteEditor" Width="250" ClientInstanceName="ClientNoteEditor"></dx:ASPxTextBox>
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
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Đóng" AutoPostBack="false" ClientInstanceName="ClientCancelButton">
                <ClientSideEvents Click="function(s, e) {{ ASPxClientEdit.ClearEditorsInContainerById('EditForm'); RevCost.ChangeState('List', '', '');  ClientPurchaseEditPopupControl.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnSave" runat="server" Text="Lưu" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientSaveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxHiddenField ID="RevCostHiddenField" runat="server" ClientInstanceName="ClientRevCostHiddenField"></dx:ASPxHiddenField>

    <dx:ASPxGlobalEvents runat="server">
        <ClientSideEvents ControlsInitialized="RevCost.OnPageInit" />
    </dx:ASPxGlobalEvents>
</asp:Content>

