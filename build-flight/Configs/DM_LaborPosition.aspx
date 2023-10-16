<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_LaborPosition.aspx.cs" Inherits="Configs_DM_LaborPosition" %>

<%@ Register Src="~/Configs/PopupControl/PositionLOV.ascx" TagPrefix="dx" TagName="PositionLOV" %>
<%@ Register Src="~/Configs/PopupControl/LaborPositionNormAddOrEdit.ascx" TagPrefix="dx" TagName="LaborPositionNormAddOrEdit" %>
<%@ Register Src="~/Configs/PopupControl/CompanyLOV.ascx" TagPrefix="dx" TagName="CompanyLOV" %>

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

        .dxtlControl_Office2010Blue caption {
            font-weight: bold;
            color: #1e395b;
            padding: 3px 3px 5px;
            text-align: left;
            background: #bdd0e7 url(/DXR.axd?r=0_4030-ttc8i) repeat-x left top;
            border-bottom: 0 solid #8ba0bc;
            border: 1px solid #8ba0bc;
        }

        caption {
            display: table-caption;
            text-align: -webkit-center;
        }
    </style>
    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/LaborPosition.js"></script>
    <script>
        var AreaCode = "<%= SessionUser.AreaCode=="KCQ"?"CTY": SessionUser.AreaCode %>";
    </script>

    <dx:ASPxGlobalEvents ID="ge" runat="server">
        <ClientSideEvents ControlsInitialized="RevCost.ControlsInitialized" />
    </dx:ASPxGlobalEvents>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <Styles>
            <Separator>
                <BorderTop BorderStyle="None" />
                <BorderBottom BorderStyle="None" />
            </Separator>
        </Styles>
        <ClientSideEvents PaneResized="RevCost.ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Name="Menu" Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: right">
                        </div>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="ĐỊNH BIÊN LAO ĐỘNG TRỰC TIẾP/QUẢN LÝ" />
                            </div>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane Separator-Visible="False">
                <Panes>
                    <dx:SplitterPane Size="500px">
                        <Panes>

                            <dx:SplitterPane Name="GridPGPane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxTreeList ID="GroupGrid" runat="server" Width="100%" ClientInstanceName="ClientGroupGrid" KeyFieldName="DMGroupID"
                                            ParentFieldName="ParentGroupID" Caption="Nhóm lao động">
                                            <Columns>
                                                <dx:TreeListTextColumn FieldName="GroupName" VisibleIndex="1" Caption="Tên nhóm lao động" Width="100%"></dx:TreeListTextColumn>
                                                <%--<dx:TreeListTextColumn FieldName="Description" VisibleIndex="2" Caption="Diễn giải" Width="300"></dx:TreeListTextColumn>--%>
                                                <%--<dx:TreeListCheckColumn FieldName="Inactive" VisibleIndex="3" Caption="Bỏ theo dõi"></dx:TreeListCheckColumn>--%>
                                                <%-- <dx:TreeListCommandColumn VisibleIndex="4" Width="150" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="false">
                                                    <HeaderCaptionTemplate>
                                                        <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                            <Image Url="../Content/images/action/add.gif"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientGroupGrid_AddNewButtonClick" />
                                                        </dx:ASPxButton>
                                                    </HeaderCaptionTemplate>

                                                    <CustomButtons>
                                                        <dx:TreeListCommandColumnCustomButton ID="GroupEdit" Text="Edit" Image-Url="../Content/images/action/edit.gif">
                                                            <Styles>
                                                                <Style Paddings-PaddingRight="1px"></Style>
                                                            </Styles>
                                                        </dx:TreeListCommandColumnCustomButton>
                                                        <dx:TreeListCommandColumnCustomButton ID="GroupDelete" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                                            <Styles>
                                                                <Style Paddings-PaddingLeft="1px"></Style>
                                                            </Styles>
                                                        </dx:TreeListCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:TreeListCommandColumn>--%>
                                            </Columns>
                                            <Styles>
                                                <AlternatingNode Enabled="True"></AlternatingNode>
                                            </Styles>
                                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" HorizontalScrollBarMode="Auto" ScrollableHeight="500" />
                                            <%-- <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="GroupName;Description" />--%>
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="0px" />
                                            <SettingsBehavior AllowFocusedNode="true" AllowSort="false" />
                                            <SettingsResizing ColumnResizeMode="NextColumn" />
                                            <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                                            <ClientSideEvents FocusedNodeChanged="RevCost.ClientGroupGrid_FocusedNodeChanged"
                                                EndCallback="RevCost.ClientGroupGrid_EndCallback" />
                                        </dx:ASPxTreeList>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <PaneStyle Border-BorderWidth="0">
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="GridNormYearPane" Size="250">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="NormYearGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientNormYearGrid" Width="100%" KeyFieldName="NormYearID"
                                            Caption="Năm định mức">
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
                                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="0px" />
                                            <SettingsBehavior AllowFocusedRow="True" />
                                            <SettingsPager PageSize="100" Mode="ShowAllRecords" />
                                            <ClientSideEvents FocusedRowChanged="RevCost.ClientNormYearGrid_FocusedRowChanged" />
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
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane>
                                <Panes>
                                    <dx:SplitterPane Name="GridPositionPane">
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxGridView ID="PositionGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                    ClientInstanceName="ClientPositionGrid" Width="100%" KeyFieldName="DMPositionID"
                                                    OnCustomCallback="PositionGrid_CustomCallback" Caption="Chức danh">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                            <HeaderTemplate>
                                                                <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                                    <Image Url="../Content/images/action/add.gif"></Image>
                                                                    <ClientSideEvents Click="RevCost.ClientPositionGrid_AddNewButtonClick" />
                                                                </dx:ASPxButton>
                                                            </HeaderTemplate>

                                                            <CustomButtons>
                                                                <%-- <dx:GridViewCommandColumnCustomButton ID="PositionEdit" Text="Edit" Image-Url="../Content/images/action/edit.gif">
                                                                    <Styles>
                                                                        <Style Paddings-PaddingRight="1px"></Style>
                                                                    </Styles>
                                                                </dx:GridViewCommandColumnCustomButton>--%>
                                                                <dx:GridViewCommandColumnCustomButton ID="PositionDelete" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                                                    <Styles>
                                                                        <Style Paddings-PaddingLeft="1px"></Style>
                                                                    </Styles>
                                                                </dx:GridViewCommandColumnCustomButton>
                                                            </CustomButtons>
                                                        </dx:GridViewCommandColumn>
                                                        <%-- <dx:GridViewDataTextColumn FieldName="PositionID" VisibleIndex="1" Caption="PositionID" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            </dx:GridViewDataTextColumn>--%>
                                                        <dx:GridViewDataTextColumn FieldName="PostionName" VisibleIndex="2" Caption="Tên chức danh" Width="300" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="4" Caption="Diễn giải" Width="300" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Sip" VisibleIndex="5" Caption="Thứ tự" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataCheckColumn FieldName="Inactive" VisibleIndex="6" Caption="Bỏ theo dõi" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataCheckColumn>
                                                    </Columns>
                                                    <Styles>
                                                        <AlternatingRow Enabled="true" />
                                                    </Styles>
                                                    <%--  <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="PostionName;Description" />--%>
                                                    <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                                    <Paddings Padding="0px" />
                                                    <Border BorderWidth="1px" />
                                                    <BorderBottom BorderWidth="0px" />
                                                    <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                                    <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                                    <SettingsPager Visible="true" PageSize="100" Mode="ShowAllRecords" />
                                                    <%--  <SettingsEditing Mode="Batch">
                                                        <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                                    </SettingsEditing>--%>
                                                    <ClientSideEvents FocusedRowChanged="RevCost.ClientPositionGrid_FocusedRowChanged"
                                                        BeginCallback="RevCost.ClientPositionGrid_BeginCallback"
                                                        EndCallback="RevCost.ClientPositionGrid_EndCallback" />
                                                </dx:ASPxGridView>
                                            </dx:SplitterContentControl>
                                        </ContentCollection>
                                        <PaneStyle Border-BorderWidth="0">
                                            <BorderTop BorderWidth="0px"></BorderTop>
                                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                        </PaneStyle>
                                    </dx:SplitterPane>
                                    <dx:SplitterPane Size="535" Name="CompanyGridPane">
                                        <ContentCollection>
                                            <dx:SplitterContentControl>
                                                <dx:ASPxGridView ID="CompanyGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                                    ClientInstanceName="ClientCompanyGrid" Width="100%" KeyFieldName="PositionCompanyID"
                                                    OnCustomCallback="CompanyGrid_CustomCallback" Caption="Đơn vị"
                                                    OnCustomColumnDisplayText="CompanyGrid_CustomColumnDisplayText">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                            <HeaderTemplate>
                                                                <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                                    <Image Url="../Content/images/action/add.gif"></Image>
                                                                    <ClientSideEvents Click="RevCost.ClientCompanyGrid_AddNewButtonClick" />
                                                                </dx:ASPxButton>
                                                            </HeaderTemplate>
                                                            <CustomButtons>
                                                                <dx:GridViewCommandColumnCustomButton ID="CompanyRemove" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                                                    <Styles>
                                                                        <Style Paddings-PaddingLeft="1px"></Style>
                                                                    </Styles>
                                                                </dx:GridViewCommandColumnCustomButton>
                                                            </CustomButtons>
                                                        </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Area" VisibleIndex="2" Caption="Khu vực" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="CompanyName" UnboundType="String" VisibleIndex="3" Caption="Tên đơn vị" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <CellStyle Wrap="True"></CellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <Styles>
                                                        <AlternatingRow Enabled="true" />
                                                    </Styles>
                                                    <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="false" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                                    <Paddings Padding="0px" />
                                                    <Border BorderWidth="1px" />
                                                    <BorderBottom BorderWidth="0px" />
                                                    <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                                    <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                                    <SettingsPager Visible="true" PageSize="100" Mode="ShowAllRecords" />
                                                    <ClientSideEvents CustomButtonClick="RevCost.ClientCompanyGrid_CustomButtonClick" />
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
                            <dx:SplitterPane Size="300" Name="LaborNormGridPane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="LaborNormGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientLaborNormGrid" Width="100%" KeyFieldName="NormID"
                                            OnCustomCallback="LaborNormGrid_CustomCallback"
                                            OnBatchUpdate="LaborNormGrid_BatchUpdate"
                                            Caption="Định mức lao động">
                                            <Columns>
                                                <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                    <HeaderTemplate>
                                                        <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                            <Image Url="../Content/images/action/add.gif"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientLaborNormGrid_AddNewButtonClick" />
                                                        </dx:ASPxButton>
                                                    </HeaderTemplate>
                                                    <CustomButtons>
                                                        <%--  <dx:GridViewCommandColumnCustomButton ID="NormEdit" Text="Edit" Image-Url="../Content/images/action/edit.gif">
                                                            <Styles>
                                                                <Style Paddings-PaddingRight="1px"></Style>
                                                            </Styles>
                                                        </dx:GridViewCommandColumnCustomButton>--%>
                                                        <dx:GridViewCommandColumnCustomButton ID="NormDelete" Text="Delete" Image-Url="../Content/images/action/delete.gif">
                                                            <Styles>
                                                                <Style Paddings-PaddingLeft="1px"></Style>
                                                            </Styles>
                                                        </dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:GridViewCommandColumn>
                                                <%-- <dx:GridViewDataTextColumn FieldName="ForYear" VisibleIndex="1" Caption="Năm" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>--%>
                                                <dx:GridViewDataComboBoxColumn FieldName="Area" VisibleIndex="2" Caption="Chi nhánh" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesComboBox>
                                                        <Items>
                                                            <dx:ListEditItem Value="SGN" Text="SGN" />
                                                            <dx:ListEditItem Value="HAN" Text="HAN" />
                                                            <dx:ListEditItem Value="DAD" Text="DAD" />
                                                            <dx:ListEditItem Value="CTY" Text="CTY" />
                                                        </Items>
                                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                            <RequiredField IsRequired="true" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="PeopleNbr" VisibleIndex="3" Caption="Số người" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N0">
                                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                            <RequiredField IsRequired="true" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="ShiftNbr" VisibleIndex="4" Visible="false" Caption="Số ca" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="WorkTotal" VisibleIndex="5" Visible="false" Caption="Hao phí LĐ(công)" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesSpinEdit DisplayFormatString="N2"></PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="6" Caption="Diễn giải" Width="600" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataCheckColumn FieldName="Inactive" VisibleIndex="7" Caption="Bỏ theo dõi" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataCheckColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                            </Styles>
                                            <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="false" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="0px" />
                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                            <SettingsCommandButton RenderMode="Button"></SettingsCommandButton>
                                            <SettingsPager Visible="true" PageSize="100" Mode="ShowAllRecords" />
                                            <SettingsEditing Mode="Batch">
                                                <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                            </SettingsEditing>
                                            <Templates>
                                                <StatusBar>

                                                    <dx:ASPxButton runat="server" Text="LƯU THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                                        <ClientSideEvents Click="RevCost.ClientSaveDataGridButton_Click" />
                                                        <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                    </dx:ASPxButton>
                                                    &nbsp;
                                                        <dx:ASPxButton runat="server" Text="HỦY THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                                            <ClientSideEvents Click="RevCost.ClientCancelDataGridButton_Click" />
                                                            <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                                        </dx:ASPxButton>

                                                </StatusBar>
                                            </Templates>

                                            <ClientSideEvents CustomButtonClick="RevCost.ClientLaborNormGrid_CustomButtonClick" />

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
            </dx:SplitterPane>

        </Panes>
    </dx:ASPxSplitter>

    <dx:ASPxPopupControl ID="PositionPopup" runat="server" ClientInstanceName="ClientPositionPopup" Width="550px" Height="300px" HeaderText="Chọn chức danh"
        Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowFooter="true">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:PositionLOV runat="server" ID="PositionLOV" />
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Đóng" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientPositionPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Chấp nhận" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientAddPositionButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="LaborPositionNormPopup" runat="server" ClientInstanceName="ClientLaborPositionNormPopup" Width="550px" Height="350px" HeaderText="Cập nhật"
        Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowFooter="true">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:LaborPositionNormAddOrEdit runat="server" ID="LaborPositionNormAddOrEdit" />
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Đóng" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientLaborPositionNormPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" runat="server" Text="Chấp nhận" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientAddLaborNormButton_Click" />
                <Image Url="../Content/images/action/save.png"></Image>
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="CompanyPopup" runat="server" ClientInstanceName="ClientCompanyPopup" Width="550px" Height="300px" HeaderText=""
        Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowFooter="true">
        <HeaderStyle Font-Bold="True" Font-Size="Medium">
            <Paddings PaddingBottom="5px" PaddingTop="5px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:CompanyLOV runat="server" ID="CompanyLOV" />
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings Padding="0" />
        </ContentStyle>
        <FooterTemplate>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Đóng" AutoPostBack="false">
                <ClientSideEvents Click="function(s, e) {{ ClientCompanyPopup.Hide(); }}" />
                <Image Url="../../Content/images/reject.png" Height="16"></Image>
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Chấp nhận" AutoPostBack="false" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientAddCompanyButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

</asp:Content>

