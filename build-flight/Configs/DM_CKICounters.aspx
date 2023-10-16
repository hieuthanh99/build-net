<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DM_CKICounters.aspx.cs" Inherits="Configs_DM_CKICounters" %>

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

        caption {
            display: table-caption;
            text-align: -webkit-center;
        }
    </style>
    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/CKICounters.js"></script>

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
                                <asp:Literal ID="Literal1" runat="server" Text="ĐỊNH MỨC QUẦY THỦ TỤC" />
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
                    <dx:SplitterPane>
                        <Panes>
                            <dx:SplitterPane Size="200" Name="GridNormYearPane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="NormYearGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientNormYearGrid" Width="100%" KeyFieldName="NormYearID">
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
                                <PaneStyle Border-BorderWidth="0px">
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="CKICountersPane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="CKICountersGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientCKICountersGrid" Width="100%" KeyFieldName="CKICountersID"
                                            OnCustomCallback="CKICountersGrid_CustomCallback"
                                            OnBatchUpdate="CKICountersGrid_BatchUpdate"
                                            Caption="ĐỊNH MỨC QUẦY THỦ TỤC PHỤC VỤ HÀNH KHÁCH">
                                            <Columns>
                                                <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                    <HeaderTemplate>
                                                        <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                            <Image Url="../Content/images/action/add.gif"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientCKICountersGrid_AddNewButtonClick" />
                                                        </dx:ASPxButton>
                                                    </HeaderTemplate>
                                                    <CustomButtons>
                                                        <dx:GridViewCommandColumnCustomButton ID="CKICountersGridDelete" Text="Xóa bỏ" Image-Url="../Content/images/action/delete.gif">
                                                            <Styles>
                                                                <Style Paddings-PaddingLeft="1px"></Style>
                                                            </Styles>
                                                        </dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:GridViewCommandColumn>
                                                <%--  <dx:GridViewDataTextColumn FieldName="ForYear" VisibleIndex="1" Caption="Năm" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                        </dx:GridViewDataTextColumn>--%>
                                                <dx:GridViewDataComboBoxColumn FieldName="ACType" VisibleIndex="2" Caption="Loại tàu bay" Width="150" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesComboBox>
                                                        <Items>
                                                            <dx:ListEditItem Value="OW" Text="TÀU BAY 1 LỐI ĐI" />
                                                            <dx:ListEditItem Value="TW" Text="TÀU BAY 2 LỐI ĐI" />
                                                        </Items>
                                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                            <RequiredField IsRequired="true" ErrorText="Loại tàu bay bắt buộc nhập giá trị" />
                                                        </ValidationSettings>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataComboBoxColumn FieldName="ACID" VisibleIndex="3" Caption="Tàu bay" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewBandColumn Caption="A/C CONFIGURATION" VisibleIndex="4" HeaderStyle-HorizontalAlign="Center">
                                                    <Columns>
                                                        <dx:GridViewDataSpinEditColumn FieldName="TotalPax" VisibleIndex="1" Caption="Tổng cộng" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                            <EditFormSettings Visible="False" />
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="PaxFC" VisibleIndex="2" Caption="F/C" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="PaxY" VisibleIndex="3" Caption="Y" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                    </Columns>
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewBandColumn Caption="SỐ QUẦY THỦ TỤC TỐI ĐA" VisibleIndex="5" HeaderStyle-HorizontalAlign="Center">
                                                    <Columns>
                                                        <dx:GridViewDataSpinEditColumn FieldName="TotalMaxCounters" VisibleIndex="1" Caption="Tổng cộng" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                            <EditFormSettings Visible="False" />
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="MaxCountersPaxFC" VisibleIndex="2" Caption="F/C" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="MaxCountersPaxY" VisibleIndex="3" Caption="Y" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                    </Columns>
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewBandColumn Caption="SỐ QUẦY THỦ TỤC TỐI THIỂU" VisibleIndex="6" HeaderStyle-HorizontalAlign="Center">
                                                    <Columns>
                                                        <dx:GridViewDataSpinEditColumn FieldName="TotalMinCounters" VisibleIndex="1" Caption="Tổng cộng" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                            <EditFormSettings Visible="False" />
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="MinCountersPaxFC" VisibleIndex="2" Caption="F/C" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="MinCountersPaxY" VisibleIndex="3" Caption="Y" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                    </Columns>
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="7" Caption="Diễn giải" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                            </Styles>
                                            <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="true" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
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
                                                    <div style="float: right">
                                                        <dx:ASPxButton runat="server" Text="LƯU THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                            <ClientSideEvents Click="RevCost.ClientCKICountersGridSaveButton_Click" />
                                                            <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                        </dx:ASPxButton>
                                                        &nbsp;
                                                <dx:ASPxButton runat="server" Text="HỦY THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                    <ClientSideEvents Click="RevCost.ClientCKICountersGridCancelButton_Click" />
                                                    <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                                </dx:ASPxButton>
                                                    </div>
                                                </StatusBar>
                                            </Templates>
                                            <ClientSideEvents CustomButtonClick="RevCost.ClientCKICountersGrid_CustomButtonClick" />
                                        </dx:ASPxGridView>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <PaneStyle Border-BorderWidth="0px">
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                        </Panes>
                    </dx:SplitterPane>

                    <dx:SplitterPane Size="700">
                        <Panes>
                            <dx:SplitterPane Name="CKIAverageTimePane" Size="320">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="CKIAverageTimeGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientCKIAverageTimeGrid" Width="100%" KeyFieldName="CKIAvgTimeID"
                                            OnCustomCallback="CKIAverageTimeGrid_CustomCallback"
                                            OnBatchUpdate="CKIAverageTimeGrid_BatchUpdate"
                                            Caption="Thời gian trung bình thực hiện thủ tục cho hành khách">
                                            <Columns>
                                                <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                    <HeaderTemplate>
                                                        <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                            <Image Url="../Content/images/action/add.gif"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientCKIAverageTimeGrid_AddNewButtonClick" />
                                                        </dx:ASPxButton>
                                                    </HeaderTemplate>
                                                    <CustomButtons>
                                                        <dx:GridViewCommandColumnCustomButton ID="CKIAverageTimeGridDelete" Text="Xóa bỏ" Image-Url="../Content/images/action/delete.gif">
                                                            <Styles>
                                                                <Style Paddings-PaddingLeft="1px"></Style>
                                                            </Styles>
                                                        </dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:GridViewCommandColumn>
                                                <%--<dx:GridViewDataTextColumn FieldName="ForYear" VisibleIndex="1" Caption="Năm" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                </dx:GridViewDataTextColumn>--%>
                                                <dx:GridViewDataTextColumn FieldName="AreaCode" VisibleIndex="2" Caption="Chi nhánh" Width="70" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                            <RequiredField IsRequired="true" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewBandColumn Caption="Phục vụ khách C" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center">
                                                    <Columns>
                                                        <dx:GridViewDataSpinEditColumn FieldName="PaxCTotalSample" VisibleIndex="1" Caption="Tổng số mẫu" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="PaxCAvgTime" VisibleIndex="2" Caption="Thời gian TB (phút/khách)" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N2">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                    </Columns>
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewBandColumn Caption="Phục vụ khách Y" VisibleIndex="4" HeaderStyle-HorizontalAlign="Center">
                                                    <Columns>
                                                        <dx:GridViewDataSpinEditColumn FieldName="PaxYTotalSample" VisibleIndex="1" Caption="Tổng số mẫu" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="PaxYAvgTime" VisibleIndex="2" Caption="Thời gian TB (phút/khách)" Width="110" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N2">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                    </Columns>
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="5" Caption="Diễn giải" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                            </Styles>
                                            <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="true" ShowStatusBar="Hidden" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
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
                                                    <div style="float: right">
                                                        <dx:ASPxButton runat="server" Text="LƯU THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                            <ClientSideEvents Click="RevCost.ClientCKIAverageTimeGridSaveButton_Click" />
                                                            <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                        </dx:ASPxButton>
                                                        &nbsp;
                                                        <dx:ASPxButton runat="server" Text="HỦY THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                            <ClientSideEvents Click="RevCost.ClientCKIAverageTimeGridCancelButton_Click" />
                                                            <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                                        </dx:ASPxButton>
                                                    </div>
                                                </StatusBar>
                                            </Templates>
                                            <ClientSideEvents CustomButtonClick="RevCost.ClientCKIAverageTimeGrid_CustomButtonClick" />
                                        </dx:ASPxGridView>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <PaneStyle Border-BorderWidth="0">
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="VNAACConfigPane">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="VNAACConfigGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                                            ClientInstanceName="ClientVNAACConfigGrid" Width="100%" KeyFieldName="VNAACConfigID"
                                            OnCustomCallback="VNAACConfigGrid_CustomCallback"
                                            OnBatchUpdate="VNAACConfigGrid_BatchUpdate"
                                            Caption="Cấu hình tàu bay của Vietnam Airlines">
                                            <Columns>
                                                <dx:GridViewCommandColumn VisibleIndex="0" Width="100" HeaderStyle-HorizontalAlign="Center" ShowNewButtonInHeader="true">
                                                    <HeaderTemplate>
                                                        <dx:ASPxButton runat="server" Text="Thêm" RenderMode="Link" AutoPostBack="false">
                                                            <Image Url="../Content/images/action/add.gif"></Image>
                                                            <ClientSideEvents Click="RevCost.ClientVNAACConfigGrid_AddNewButtonClick" />
                                                        </dx:ASPxButton>
                                                    </HeaderTemplate>
                                                    <CustomButtons>
                                                        <dx:GridViewCommandColumnCustomButton ID="VNAACConfigGridDelete" Text="Xóa bỏ" Image-Url="../Content/images/action/delete.gif">
                                                            <Styles>
                                                                <Style Paddings-PaddingLeft="1px"></Style>
                                                            </Styles>
                                                        </dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:GridViewCommandColumn>
                                                <%-- <dx:GridViewDataTextColumn FieldName="ForYear" VisibleIndex="1" Caption="Năm" Width="60" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataTextColumn>--%>
                                                <dx:GridViewDataComboBoxColumn FieldName="ACID" VisibleIndex="2" Caption="Tàu bay" Width="100" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <PropertiesComboBox>
                                                        <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                            <RequiredField IsRequired="true" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewBandColumn VisibleIndex="3" Caption="A/C CONFIGURATION" HeaderStyle-HorizontalAlign="Center">
                                                    <Columns>
                                                        <dx:GridViewDataSpinEditColumn FieldName="TotalPax" VisibleIndex="1" Caption="Tổng cộng" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0"></PropertiesSpinEdit>
                                                            <EditFormSettings Visible="False" />
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="PaxC" VisibleIndex="2" Caption="Khách C" Width="120" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn FieldName="PaxY" VisibleIndex="3" Caption="Khách Y" Width="130" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                                <ValidationSettings ValidateOnLeave="true" ErrorDisplayMode="None">
                                                                    <RequiredField IsRequired="true" ErrorText="*" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>

                                                    </Columns>
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="4" Caption="Diễn giải" Width="350" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                                    <CellStyle Wrap="True"></CellStyle>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                            </Styles>
                                            <Settings GroupFormat="{1}" ShowGroupPanel="false" ShowFilterRow="true" ShowStatusBar="Hidden" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
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
                                                    <div style="float: right">
                                                        <dx:ASPxButton runat="server" Text="LƯU THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                            <ClientSideEvents Click="RevCost.ClientVNAACConfigGridSaveButton_Click" />
                                                            <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                        </dx:ASPxButton>
                                                        &nbsp;
                                                        <dx:ASPxButton runat="server" Text="HỦY THAY ĐỔI" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16">
                                                            <ClientSideEvents Click="RevCost.ClientVNAACConfigGridCancelButton_Click" />
                                                            <Image Url="../Content/images/action/undo.png" Height="16"></Image>
                                                        </dx:ASPxButton>
                                                    </div>
                                                </StatusBar>
                                            </Templates>
                                            <ClientSideEvents CustomButtonClick="RevCost.ClientVNAACConfigGrid_CustomButtonClick" />
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
</asp:Content>

