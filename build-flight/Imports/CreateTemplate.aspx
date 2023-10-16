<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CreateTemplate.aspx.cs" Inherits="Imports_CreateTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link href="../Content/RevCost.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.11.1.min.js"></script>
    <script src="../Scripts/PageModuleBase.js"></script>
    <script src="../Scripts/CreateTemplate.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="../signalr/hubs"></script>
    <dx:ASPxSplitter ID="contentSplitter" runat="server" ClientInstanceName="ClientContentSplitter" Orientation="Vertical" Width="100%" Height="100%" ResizingMode="Live">
        <ClientSideEvents PaneResized="RevCost.ClientContentSplitter_PaneResized" />
        <Border BorderStyle="None" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: left">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="Tạo mẫu đổ dữ liệu từ Excel" />
                            </div>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
            </dx:SplitterPane>
            <dx:SplitterPane Separator-Visible="False">
                <Panes>
                    <dx:SplitterPane Separator-Visible="False">
                        <Panes>
                            <dx:SplitterPane Size="100" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxFormLayout ID="FormLayout" runat="server" ColCount="2" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                                            AlignItemCaptionsInAllGroups="true">
                                            <Items>
                                                <dx:LayoutItem Caption="Tên mẫu đổ dữ liệu" ColSpan="2">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxComboBox ID="cboTableName" runat="server" ClientInstanceName="ClientTableName" OnInit="cboTableName_Init" ValueType="System.String" ValueField="ETCode"
                                                                TextFormatString="{0} {2}" DropDownStyle="DropDownList" Width="400" DropDownHeight="200" OnCallback="cboTableName_Callback">
                                                                <ClientSideEvents ValueChanged="RevCost.ClientTableName_ValueChanged" />
                                                                <Columns>
                                                                    <dx:ListBoxColumn Caption="Tên bảng" FieldName="ToTableName" Width="80"></dx:ListBoxColumn>
                                                                    <dx:ListBoxColumn Caption="Mã mẫu" FieldName="ETCode" Width="70"></dx:ListBoxColumn>
                                                                    <dx:ListBoxColumn Caption="Tên mẫu" FieldName="Name" Width="250"></dx:ListBoxColumn>
                                                                    <dx:ListBoxColumn Caption="Loại mẫu" FieldName="FileType" Width="80"></dx:ListBoxColumn>
                                                                </Columns>

                                                                <Buttons>
                                                                    <dx:EditButton Image-Url="../Content/images/SpinEditPlus.png" Position="Right" Image-Height="16" Image-Width="16"></dx:EditButton>
                                                                </Buttons>
                                                                <ClientSideEvents ButtonClick="RevCost.ClientNewTemplateTable_ButtonClick" EndCallback="RevCost.ClientNewTemplateTable_EndCallback" />
                                                            </dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                                                <dx:LayoutItem Caption="" ColSpan="2">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxButton ID="btCreate" runat="server" Text="TẠO MẪU" AutoPostBack="false" Font-Bold="true">
                                                                <ClientSideEvents Click="RevCost.ClientCreate_Click" />
                                                            </dx:ASPxButton>
                                                            <dx:ASPxButton ID="btRecreate" runat="server" Text="Recreate" AutoPostBack="false" Visible="false" Font-Bold="true">
                                                                <ClientSideEvents Click="RevCost.ClientRecreate_Click" />
                                                            </dx:ASPxButton>
                                                            <dx:ASPxButton ID="btTemplateFile" runat="server" Text="TẢI MẪU" AutoPostBack="false" Font-Bold="true">
                                                                <ClientSideEvents Click="RevCost.ClientCreateTemplateFile_Click" />
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
                                <PaneStyle Border-BorderWidth="0">
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                            <dx:SplitterPane Name="TemplatePane" Separator-Visible="False">
                                <ContentCollection>
                                    <dx:SplitterContentControl>
                                        <dx:ASPxGridView ID="TemplateGrid" runat="server" ClientInstanceName="ClientTemplateGrid" AutoGenerateColumns="false" Width="100%"
                                            OnCustomCallback="TemplateGrid_CustomCallback" KeyFieldName="HeaderID"
                                            OnCellEditorInitialize="TemplateGrid_CellEditorInitialize"
                                            OnBatchUpdate="TemplateGrid_BatchUpdate">
                                            <Columns>
                                                <dx:GridViewCommandColumn VisibleIndex="0" Width="80" Caption="#">
                                                    <CustomButtons>
                                                        <dx:GridViewCommandColumnCustomButton ID="Delete" Text="Xóa" Image-Url="../Content/images/action/delete.gif"></dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataColumn FieldName="Seq" Caption="Thứ tự" VisibleIndex="1" Width="70"></dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="ColumnName" Caption="Tên cột" VisibleIndex="2" Width="120"></dx:GridViewDataColumn>
                                                <dx:GridViewDataTextColumn FieldName="Description" Caption="Diễn giải" VisibleIndex="2" Width="250">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings>
                                                            <RequiredField IsRequired="true" ErrorText="This field must be entered." />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="ColumnWidth" Caption="Độ rộng cột" VisibleIndex="3" Width="100">
                                                    <PropertiesSpinEdit>
                                                        <ValidationSettings>
                                                            <RequiredField IsRequired="true" ErrorText="This field must be entered." />
                                                        </ValidationSettings>
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataColumn FieldName="MapingColumn" Caption="Map Cột" VisibleIndex="4" Width="120"></dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="DataType" Caption="Loại dữ liệu" VisibleIndex="5" Width="100"></dx:GridViewDataColumn>
                                                <dx:GridViewDataColumn FieldName="DataLength" Caption="Độ dài dữ liệu" VisibleIndex="6" Width="100"></dx:GridViewDataColumn>
                                                <dx:GridViewDataCheckColumn FieldName="IsNotNull" Caption="Để trống?" VisibleIndex="7" Width="80"></dx:GridViewDataCheckColumn>
                                                <dx:GridViewCommandColumn VisibleIndex="7" Width="130" Caption="Sắp xếp">
                                                    <CustomButtons>
                                                        <dx:GridViewCommandColumnCustomButton ID="Up" Text="Lên" Image-Url="../Content/images/action/up.png"></dx:GridViewCommandColumnCustomButton>
                                                        <dx:GridViewCommandColumnCustomButton ID="Down" Text="Xuống" Image-Url="../Content/images/action/down.png"></dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataColumn Caption="" VisibleIndex="9" Width="60%"></dx:GridViewDataColumn>
                                            </Columns>
                                            <Styles>
                                                <AlternatingRow Enabled="true" />
                                            </Styles>
                                            <Settings ShowFilterRow="true" ShowStatusBar="Visible" VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" VerticalScrollBarStyle="Standard" HorizontalScrollBarMode="Auto" />
                                            <Paddings Padding="0px" />
                                            <Border BorderWidth="1px" />
                                            <BorderBottom BorderWidth="1px" />
                                            <SettingsBehavior AllowFocusedRow="True" />
                                            <SettingsPager Mode="ShowAllRecords" />
                                            <SettingsResizing ColumnResizeMode="Control" />
                                            <SettingsEditing Mode="Batch">
                                                <BatchEditSettings EditMode="Cell" StartEditAction="FocusedCellClick" />
                                            </SettingsEditing>
                                            <Templates>
                                                <StatusBar>
                                                    <dx:ASPxButton ID="btnSave" runat="server" Text="LƯU MẪU" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                                        <ClientSideEvents Click="RevCost.ClientSaveTemplate_Click" />
                                                        <Image Url="../../Content/images/action/save.png" Height="16"></Image>
                                                    </dx:ASPxButton>

                                                    <dx:ASPxButton ID="btnUpdateSeq" runat="server" Text="CẬP NHẬT THỨ TỰ" RenderMode="Button" AutoPostBack="false" UseSubmitBehavior="true" Image-Width="16" Font-Bold="true">
                                                        <ClientSideEvents Click="RevCost.ClientUpdateSeq_Click" />
                                                    </dx:ASPxButton>
                                                </StatusBar>
                                            </Templates>
                                            <ClientSideEvents CustomButtonClick="RevCost.ClientTemplateGrid_CustomButtonClick" />
                                        </dx:ASPxGridView>
                                    </dx:SplitterContentControl>
                                </ContentCollection>
                                <PaneStyle>
                                    <BorderTop BorderWidth="0px"></BorderTop>
                                    <BorderLeft BorderWidth="0px"></BorderLeft>
                                    <BorderRight BorderWidth="0px"></BorderRight>
                                    <BorderBottom BorderWidth="0px"></BorderBottom>
                                    <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                                </PaneStyle>
                            </dx:SplitterPane>
                        </Panes>
                    </dx:SplitterPane>
                </Panes>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>


    <dx:ASPxPopupControl ID="EditPopup" runat="server" Width="250" Height="250" AllowDragging="True" HeaderText="Add template" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopup" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Code">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="ETCodeEditor" Width="250" ClientInstanceName="ClientETCodeEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="NameEditor" Width="250" ClientInstanceName="ClientNameEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Table Name">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="TableNameEditor" Width="250" ClientInstanceName="ClientTableNameEditor" OnInit="TableNameEditor_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="File Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="FileTypeEditor" Width="250" ClientInstanceName="ClientFileTypeEditor" OnInit="FileTypeEditor_Init">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Use Version">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox runat="server" ID="UseVersionEditor" ClientInstanceName="ClientUseVersionEditor" Text="(Apply To Version or not)">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                        <ClientSideEvents CheckedChanged="RevCost.ClientUseVersionEditor_CheckedChanged" />
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Transfer Type">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="TransferTypeEditor" Width="250" ClientInstanceName="ClientTransferTypeEditor">
                                        <Items>
                                            <dx:ListEditItem Value="REPLACE" Text="Replace" Selected="true" />
                                            <dx:ListEditItem Value="APPEND" Text="Append" />
                                        </Items>
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
                <ClientSideEvents Click="function(s, e) {{ ASPxClientEdit.ClearEditorsInContainerById('EditForm');  ClientEditPopup.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnASave" runat="server" Text="Save" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="RevCost.ClientSaveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxCallback ID="CreateTemplateCallback" runat="server" ClientInstanceName="ClientCreateTemplateCallback" OnCallback="CreateTemplateCallback_Callback"></dx:ASPxCallback>
</asp:Content>

