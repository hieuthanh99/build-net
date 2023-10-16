<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProfitSubaccount.aspx.cs" Inherits="Business_RouteProfit_ProfitSubaccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <script src="../../Scripts/Common.js"></script>
    <script type="text/javascript">
        function ClientSplitter_PaneResized(s, e) {
            if (e.pane.name == "RouteProfits") {
                ClientRouteProfitsGrid.SetHeight(e.pane.GetClientHeight());
            }
            else if (e.pane.name == "Subaccounts") {
                ClientSubacountsGrid.SetHeight(e.pane.GetClientHeight());
            }

        }

        function ClientRouteProfitsGrid_FocusedNodeChanged(s, e) {
            var key = s.GetFocusedNodeKey();
            DoCallback(ClientSubacountsGrid, function () {
                ClientSubacountsGrid.PerformCallback('RestoreSellection|' + key);
            });
        }

        function ClientSubacountsGrid_SelectionChanged(s, e) {
            var key = s.GetFocusedNodeKey();
            DoCallback(ClientSubacountsGrid, function () {
                ClientSubacountsGrid.PerformCallback('UpdateRouteProfitID|' + key);
            });
        }

        function ClientNewRouteProfit_Click(s, e) {
            ASPxClientEdit.ClearEditorsInContainerById('EditForm');
            ChangeState("EditForm", "NEW", null);
            DoCallback(ClientParentEditor, function () {
                ClientParentEditor.PerformCallback('');
            });

        }

        function ClientParentEditor_EndCallback(s, e) {
            ClientEditPopupControl.Show();
        }

        function ClientRouteProfitsGrid_CustomButtonClick(s, e) {
            if (e.buttonID == "Edit") {
                ASPxClientEdit.ClearEditorsInContainerById('EditForm');
                var key = s.GetFocusedNodeKey();
                ChangeState("EditForm", "EDIT", key);
                ClientEditPopupControl.Show();
            }
            else if (e.buttonID == "Delete") {
                alert("Delete");
            }
        }

        function ClientEditPopupControl_Closing(s, e) {
            ChangeState("List", "", "");
        }

    </script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="ClientSplitter" Orientation="Vertical" Width="100%" Height="100%">
        <ClientSideEvents PaneResized="ClientSplitter_PaneResized" />
        <Panes>
            <dx:SplitterPane Size="50" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div class="title">
                            <asp:Literal ID="Literal1" runat="server" Text="Profit Subaccounts" />
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
                    <dx:SplitterPane Name="RouteProfits">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxTreeList ID="RouteProfitsGrid" runat="server" Width="100%" ClientInstanceName="ClientRouteProfitsGrid"
                                    KeyFieldName="RouteProfitID" ParentFieldName="ParentID"
                                    OnHtmlRowPrepared="RouteProfitsGrid_HtmlRowPrepared">
                                    <Columns>
                                        <dx:TreeListTextColumn FieldName="Description" VisibleIndex="1" Caption="Description" CellStyle-Wrap="True"></dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Calculation" VisibleIndex="2" Caption="Calc" Width="50"></dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Priority" VisibleIndex="3" Caption="Priority" Width="50"></dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Formula" VisibleIndex="4" Caption="Formula" Width="55"></dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="GroupItem" VisibleIndex="5" Caption="Group Item" Width="100"></dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Seq" VisibleIndex="6" Caption="Seq" Width="50"></dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Sorting" VisibleIndex="7" Caption="Sorting" Width="70"></dx:TreeListTextColumn>
                                        <dx:TreeListCommandColumn VisibleIndex="8" Width="120">
                                            <HeaderCaptionTemplate>
                                                <dx:ASPxButton ID="New" runat="server" Text="New" RenderMode="Link" AutoPostBack="false" Image-Url="~/Content/images/action/add.gif">
                                                    <ClientSideEvents Click="ClientNewRouteProfit_Click" />
                                                </dx:ASPxButton>
                                            </HeaderCaptionTemplate>
                                            <CustomButtons>
                                                <dx:TreeListCommandColumnCustomButton ID="Edit" Text="Edit" Image-Url="../../Content/images/action/edit.gif"></dx:TreeListCommandColumnCustomButton>
                                                <dx:TreeListCommandColumnCustomButton ID="Delete" Text="Delete" Image-Url="../../Content/images/action/delete.gif"></dx:TreeListCommandColumnCustomButton>
                                            </CustomButtons>
                                        </dx:TreeListCommandColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingNode Enabled="True"></AlternatingNode>
                                    </Styles>
                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" ScrollableHeight="500" />
                                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="Description" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="1px" />
                                    <SettingsBehavior AllowFocusedNode="true" FocusNodeOnExpandButtonClick="true" />
                                    <SettingsResizing ColumnResizeMode="NextColumn" />
                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                                    <ClientSideEvents CustomButtonClick="ClientRouteProfitsGrid_CustomButtonClick" FocusedNodeChanged="ClientRouteProfitsGrid_FocusedNodeChanged" />
                                </dx:ASPxTreeList>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                        <PaneStyle Border-BorderWidth="0">
                            <BorderTop BorderWidth="0px"></BorderTop>
                            <Paddings PaddingLeft="1" PaddingRight="1" PaddingBottom="1" PaddingTop="1" />
                        </PaneStyle>
                    </dx:SplitterPane>
                    <dx:SplitterPane Name="Subaccounts" Size="400">
                        <ContentCollection>
                            <dx:SplitterContentControl>
                                <dx:ASPxTreeList ID="SubacountsGrid" runat="server" Width="100%" ClientInstanceName="ClientSubacountsGrid"
                                    KeyFieldName="SubaccountID" ParentFieldName="SubaccountParentID"
                                    OnHtmlRowPrepared="SubacountsGrid_HtmlRowPrepared"
                                    OnDataBound="SubacountsGrid_DataBound"
                                    OnCustomCallback="SubacountsGrid_CustomCallback">
                                    <Columns>
                                        <dx:TreeListTextColumn FieldName="Description" VisibleIndex="1" Caption="Description" CellStyle-Wrap="True"></dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Calculation" VisibleIndex="2" Caption="Calc" Width="50"></dx:TreeListTextColumn>
                                    </Columns>
                                    <Styles>
                                        <AlternatingNode Enabled="True"></AlternatingNode>
                                    </Styles>
                                    <SettingsSelection Enabled="true" />
                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" ScrollableHeight="500" />
                                    <SettingsSearchPanel Visible="true" ShowApplyButton="true" AllowTextInputTimer="true" ColumnNames="Description" />
                                    <Paddings Padding="0px" />
                                    <Border BorderWidth="1px" />
                                    <BorderBottom BorderWidth="1px" />
                                    <SettingsBehavior AllowFocusedNode="true" FocusNodeOnExpandButtonClick="true" />
                                    <SettingsResizing ColumnResizeMode="NextColumn" />
                                    <SettingsPager Visible="true" PageSize="30" Mode="ShowAllNodes" />
                                    <ClientSideEvents SelectionChanged="ClientSubacountsGrid_SelectionChanged" />
                                </dx:ASPxTreeList>
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

    <dx:ASPxPopupControl ID="EditPopupControl" runat="server" Width="350" Height="270" AllowDragging="True" HeaderText="" ShowFooter="True"
        Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
        PopupAnimationType="Fade" ClientInstanceName="ClientEditPopupControl" ShowCloseButton="true" CloseAction="CloseButton">
        <ContentCollection>
            <dx:PopupControlContentControl>
                <dx:ASPxFormLayout ID="EditForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientEditForm"
                    AlignItemCaptionsInAllGroups="true" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Parent">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="ParentEditor" runat="server" Width="300" ValueType="System.Int32" ClientInstanceName="ClientParentEditor"
                                        OnCallback="ParentEditor_Callback">
                                        <ClientSideEvents EndCallback="ClientParentEditor_EndCallback" />
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Description">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="DescriptionEditor" Width="300" ClientInstanceName="ClientDescriptionEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Seq">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="SeqEditor" Width="100" ClientInstanceName="ClientSeqEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Sorting">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="SortingEditor" Width="100" ClientInstanceName="ClientSortingEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Calculation">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="CalculationEditor" Width="100" ClientInstanceName="ClientCalculationEditor">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Priority">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit ID="PriorityEditor" runat="server" Width="100" ClientInstanceName="ClientPriorityEditor">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Formula">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="FormulaEditor" runat="server" Width="100" ClientInstanceName="ClientFormulaEditor">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="GroupItem">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="GroupItemEditor" Width="100" ClientInstanceName="ClientGroupItemEditor" Rows="3">
                                    </dx:ASPxTextBox>
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
                <ClientSideEvents Click="function(s, e) {{ ASPxClientEdit.ClearEditorsInContainerById('EditForm'); ChangeState('List', '', '');  ClientEditPopupControl.Hide();}}" />
            </dx:ASPxButton>
            <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnSave" runat="server" Text="Lưu" AutoPostBack="false" ClientInstanceName="ClientSaveButton" UseSubmitBehavior="true">
                <ClientSideEvents Click="ClientSaveButton_Click" />
            </dx:ASPxButton>
            <div class="clear"></div>
        </FooterTemplate>
        <ClientSideEvents Closing="ClientEditPopupControl_Closing" />
    </dx:ASPxPopupControl>
</asp:Content>

