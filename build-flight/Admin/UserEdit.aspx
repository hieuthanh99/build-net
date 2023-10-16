<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="Admin_UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <style type="text/css">
        .formLayoutContainer {
            width: 100%;
            margin: auto;
        }

        .layoutGroupBoxCaption {
            font-size: 16px;
        }
    </style>
    <script>
        function MenuItemClick(e) {
            var name = e.item.name;
            if (name.toUpperCase() == "SAVE") {
                var areEditorsValid = ASPxClientEdit.ValidateEditorsInContainerById(editUserFormLayout.name);
                if (areEditorsValid) {
                    e.processOnServer = true;
                }
                else {
                    e.processOnServer = false;
                } //dxpError.SetVisible(!areEditorsValid);
            }
            else {
                e.processOnServer = true;
            }
        }
    </script>
    <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="splitter" SeparatorVisible="false" Orientation="Vertical" Width="100%" Height="100%">
        <Panes>
            <dx:SplitterPane Size="35" Separator-Visible="False">
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div style="float: right">
                            <dx:ASPxMenu ID="mMain" runat="server" CssClass="main-menu" Theme="Moderno" OnItemClick="mMain_ItemClick">
                                <ClientSideEvents ItemClick="function(s, e) { MenuItemClick(e);}" />
                                <Items>
                                    <dx:MenuItem Name="Save" Text="<%$Resources:Language, Save %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/save.png">
                                    </dx:MenuItem>
                                    <dx:MenuItem Name="Cancel" Text="<%$Resources:Language, Cancel %>" ItemStyle-CssClass="menu-item" Image-Url="../Content/Images/action/undo.png">
                                    </dx:MenuItem>
                                </Items>
                            </dx:ASPxMenu>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
            <dx:SplitterPane>
                <ContentCollection>
                    <dx:SplitterContentControl>
                        <div class="alert-danger">
                            <asp:Literal ID="lbNotice" runat="server"></asp:Literal>
                        </div>
                        <div class="formLayoutContainer">
                            <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="editUserFormLayout"
                                AlignItemCaptionsInAllGroups="true" Width="100%">
                                <Items>
                                    <dx:LayoutGroup Caption="<%$Resources:Language, frmUserEdit_Registration %>" GroupBoxDecoration="HeadingLine" SettingsItemCaptions-HorizontalAlign="Right" ColCount="2">
                                        <Items>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Name %>" ColSpan="2" HelpTextSettings-HorizontalAlign="Right">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <table>
                                                            <tr>
                                                                <td style="padding-right: 5px;">
                                                                    <dx:ASPxTextBox ID="firstNameTextBox" runat="server" NullText="First Name" Width="170">
                                                                        <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true" SetFocusOnError="true">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxTextBox>
                                                                </td>
                                                                <td>
                                                                    <dx:ASPxTextBox ID="lastNameTextBox" runat="server" NullText="Last Name" Width="170">
                                                                        <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true" SetFocusOnError="true">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxTextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>

                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Gender %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxRadioButtonList ID="genderRadioButtonList" runat="server" RepeatDirection="Horizontal" ClientInstanceName="gender">
                                                            <Items>
                                                                <dx:ListEditItem Text="<%$Resources:Language, frmUserEdit_GenderMale %>" Value="1" />
                                                                <dx:ListEditItem Text="<%$Resources:Language, frmUserEdit_GenderFemale %>" Value="2" />
                                                            </Items>
                                                            <Border BorderStyle="None" />
                                                        </dx:ASPxRadioButtonList>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Country %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox runat="server" ID="countryComboBox" DropDownStyle="DropDownList" IncrementalFilteringMode="StartsWith"
                                                            TextField="CountryName" ValueField="CountryName" ClientInstanceName="country" OnInit="countryComboBox_Init" />
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Address %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="address" NullText="Address" Width="350" />
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Telephone %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="telephone" NullText="Telephone" Width="170" />
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Mobile %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="mobile" NullText="Mobile" Width="170" />
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Email %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="eMailTextBox" Width="170">
                                                            <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>

                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                          
                                        </Items>

                                    </dx:LayoutGroup>
                                    <dx:LayoutGroup Caption="<%$Resources:Language, frmUserEdit_Authorization %>" GroupBoxDecoration="HeadingLine" SettingsItemCaptions-HorizontalAlign="Right" ColCount="2">
                                        <Items>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_UserName %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="userNameTextBox" Width="170">
                                                            <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <%--<dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Password %>">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="passwordTextBox" runat="server" ClientInstanceName="passwordTextBox" Password="true" Width="170" ViewStateMode="Disabled" AutoCompleteType="Disabled">
                                                            <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                            <ClientSideEvents Init="OnPasswordTextBoxInit" KeyUp="OnPassChanged" Validation="OnPassValidation" />
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>--%>

                                            <%--   <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_StartDate %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxDateEdit ID="dateStartDate" runat="server" Width="100">
                                                            <ValidationSettings ErrorDisplayMode="None" ValidateOnLeave="true" SetFocusOnError="true">
                                                                <RequiredField IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxDateEdit>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_ExpiryDate %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxDateEdit ID="dateExpiryDate" runat="server" Width="100"></dx:ASPxDateEdit>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>--%>
                                            <dx:LayoutItem Caption="Update Password" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxCheckBox ID="checkChangePass" runat="server" ValueType="System.String" ValueChecked="Y" ValueUnchecked="N">
                                                        </dx:ASPxCheckBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>

                                            <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_HostUser %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxCheckBox ID="checkIsSystem" runat="server" ValueType="System.String" ValueChecked="Y" ValueUnchecked="N"></dx:ASPxCheckBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_IsLocked %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxCheckBox ID="checkLocked" runat="server" ValueType="System.String" ValueChecked="Y" ValueUnchecked="N"></dx:ASPxCheckBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <%-- <dx:LayoutItem Caption="<%$Resources:Language, frmUserEdit_Description %>" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="textboxDescription" Width="350">
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>--%>
                                        </Items>

                                        <SettingsItemCaptions HorizontalAlign="Right"></SettingsItemCaptions>
                                    </dx:LayoutGroup>

                                </Items>

                                <Styles>
                                    <LayoutGroupBox>
                                        <Caption CssClass="layoutGroupBoxCaption"></Caption>
                                    </LayoutGroupBox>
                                </Styles>
                            </dx:ASPxFormLayout>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle Border-BorderWidth="0">
                    <BorderTop BorderWidth="0px"></BorderTop>
                </PaneStyle>
            </dx:SplitterPane>
        </Panes>
    </dx:ASPxSplitter>
</asp:Content>

