<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MainToolbar.ascx.cs" Inherits="UserControls_MainToolbar" %>

<script type="text/javascript">
    var PendingCallbacks = {};
    var ParamsAct = "VIEW";

    function DoCallback(sender, callback) {
        if (sender.InCallback()) {
            PendingCallbacks[sender.name] = callback;
            sender.EndCallback.RemoveHandler(DoEndCallback);
            sender.EndCallback.AddHandler(DoEndCallback);
        } else {
            callback();
        }
    }

    function DoEndCallback(s, e) {
        var pendingCallback = PendingCallbacks[s.name];
        if (pendingCallback) {
            pendingCallback();
            delete PendingCallbacks[s.name];
        }
    }

    function ClientInfoMenu_ItemClick(s, e) {
        if (e.item.parent && e.item.parent.name == "theme") {
            ASPxClientUtils.SetCookie("MailClientCurrentTheme", e.item.name || "");
            e.processOnServer = true;
        }
        else if (e.item.name == "signout") {
            if (!window.confirm("Are you sure?"))
                return;
            var signOutURL = window.location.protocol + "//" + window.location.host + "<%= HelpDeskConstant.SignOutUrl %>";
            document.location = signOutURL;
        }
        else if (e.item.name == "SwitchApp") {
            ClientSwitchAppPopup.Show();
        }
        else if (e.item.name == "BIParameters") {
            ParamsAct = "VIEW";
            ClientBIParameterPopup.Show();
        }
        else if (e.item.name == "OtherParameters") {
            ClientSystemParameterPopup.Show();
        }

    }

    function ClientSwitchAppPopup_Shown(s, e) {
        DoCallback(ClientApplicationGrid, function () {
            ClientApplicationGrid.PerformCallback('LOAD');
        });
    }

    function ClientSwitchAppApplyButton_Click(s, e) {
        if (!ClientApplicationGrid.IsDataRow(ClientApplicationGrid.GetFocusedRowIndex()))
            return;
        var key = ClientApplicationGrid.GetRowKey(ClientApplicationGrid.GetFocusedRowIndex());
        DoCallback(ClientApplicationGrid, function () {
            ClientApplicationGrid.PerformCallback('SWITCHAPP|' + key);
        });
    }

    function OpenUserProfilePage(s, e) {
        var profileURL = window.location.protocol + "//" + window.location.host + "<%= HelpDeskConstant.UserProfileUrl %>";;
        document.location = profileURL;
    }

    function PrepareTimeValue(value) {
        if (value < 10)
            value = "0" + value;
        return value;
    }
    function UpdateTime(s, e) {
        var dateTime = new Date();
        var timeString = PrepareTimeValue(dateTime.getHours()) + ":" + PrepareTimeValue(dateTime.getMinutes()) + ":" +
            PrepareTimeValue(dateTime.getSeconds());
        timeLabel.SetText(timeString);
    }

    function ClientBIParametersApplyButton_Click(s, e) {
        if (!ASPxClientEdit.ValidateEditorsInContainerById("BIParametersForm"))
            return;
        ParamsAct = "SAVE";
        DoCallback(BIParamsCallbackPanel, function () {
            BIParamsCallbackPanel.PerformCallback('SAVE_PARAMS');
        });
    }

    function ClientBIParametersPopup_Shown(s, e) {
        ParamsAct = "VIEW";
        DoCallback(BIParamsCallbackPanel, function () {
            BIParamsCallbackPanel.PerformCallback('LOAD_PARAMS');
        });
    }

    function ClientBIParamsCallbackPanel_EndCallback(s, e) {
        if (ParamsAct == "SAVE") {
            if (s.cpCommand == "SAVE_PARAMS")
                ClientBIParameterPopup.Hide();
            else
                alert(s.cpCommand);
        }
    }

    function SystemParameterCallbackPanel_EndCallback(s, e) {
        if (ParamsAct == "SAVE") {
            if (s.cpCommand == "SAVE_PARAMS")
                ClientSystemParameterPopup.Hide();
            else
                alert(s.cpCommand);
        }
    }

    function ClientSystemParameterPopup_Shown(s, e) {
        ParamsAct = "VIEW";
        DoCallback(SystemParameterCallbackPanel, function () {
            SystemParameterCallbackPanel.PerformCallback('LOAD_PARAMS');
        });
    }

    function ClientSystemParameterApplyButton_Click(s, e) {
        if (!ASPxClientEdit.ValidateEditorsInContainerById("SystemParameterFormLayout"))
            return;
        ParamsAct = "SAVE";
        DoCallback(SystemParameterCallbackPanel, function () {
            SystemParameterCallbackPanel.PerformCallback('SAVE_PARAMS');
        });
    }
</script>
<style>
    .Menu_Css_Chrome {
        position: absolute;
        float: left;
        left: 250px;
        margin-top: 40px;
        margin-left: 0px;
        width: auto;
    }

    .Menu_Css_Other {
        position: absolute;
        float: left;
        left: 250px;
        margin-top: 40px;
        margin-left: 10px;
        width: auto;
    }

    @media screen and (max-width: 750px) {
        .Menu_Css_Chrome {
            left: 200px;
            margin-top: 30px;
        }
    }

    @media screen and (max-width: 750px) {
        .Menu_Css_Other {
            left: 200px;
            margin-top: 30px;
        }
    }
</style>
<table class="ActionToolbar" style="position: absolute; top: 0;">
    <tr>
        <td>
            <div class="logo_css">
            </div>
            <div class='<%= Utils.IsChrome? "Menu_Css_Chrome" : "Menu_Css_Other" %>'>
                <dx:ASPxMenu ID="AppMenu" runat="server" ShowAsToolbar="false" ShowPopOutImages="True" ShowSubMenuShadow="true" Theme="Moderno" CssClass="ActionMenu" SeparatorWidth="0">
                    <Border BorderWidth="0" />
                    <SubMenuStyle CssClass="SubMenu" />
                </dx:ASPxMenu>
            </div>
            <div class="sw_name_css">
                <div class="part_all_css">
                    <div>
                        <%--<div class="notification-icon left">
                            <i class="material-icons dp48">notifications</i>
                            <span class="num-count">1</span>
                        </div>--%>
                        <span style="float: right">
                            <span class="part_2">VIETNAMAIRLINES</span>
                            <span class="part_1"><%= this.AppName %></span>
                        </span>
                    </div>
                    <br />
                    <div>
                        <span style="float: right">
                            <span class="part_1">Welcome: </span>
                            <span class="part_2"><a onclick="javascript:OpenUserProfilePage();" style="text-decoration: underline; cursor: pointer"><%= SessionUser.DisplayName %></a></span>
                        </span>
                    </div>
                    <div>
                        <span style="float: right">
                            <span style="float: right">
                                <dx:ASPxMenu ID="InfoMenu" runat="server" DataSourceID="InfoMenuDataSource" ClientInstanceName="ClientInfoMenu" Theme="Moderno"
                                    ShowAsToolbar="false" SeparatorWidth="0" CssClass="InfoMenu" OnItemDataBound="InfoMenu_OnItemDataBound" ItemAutoWidth="true">
                                    <ClientSideEvents ItemClick="ClientInfoMenu_ItemClick" />
                                    <Border BorderWidth="0" />
                                    <SubMenuStyle CssClass="SubMenu" />
                                </dx:ASPxMenu>
                            </span>
                        </span>
                    </div>
                    <%--<div class="timeContainer">
                        <dx:ASPxLabel runat="server" ID="TimeLabel" ClientInstanceName="timeLabel" Font-Bold="true" ForeColor="White"
                            Font-Size="14px">
                        </dx:ASPxLabel>
                    </div>--%>
                </div>
            </div>
            <b class="clear"></b>
        </td>
    </tr>
</table>

<div class="notification-container">
    <h3>Notifications
      <i class="material-icons dp48 right">settings</i>
    </h3>

    <input class="checkbox" type="checkbox" id="size_1" value="small" checked />
    <label class="notification new" for="size_1"><em>1</em> new <a href="">guest account(s)</a> have been created.<i class="material-icons dp48 right">clear</i></label>

    <input class="checkbox" type="checkbox" id="size_2" value="small" checked />
    <label class="notification new" for="size_2"><em>3</em> new <a href="">lead(s)</a> are available in the system.<i class="material-icons dp48 right">clear</i></label>

    <input class="checkbox" type="checkbox" id="size_3" value="small" checked />
    <label class="notification" for="size_3"><em>5</em> new <a href="">task(s)</a>.<i class="material-icons dp48 right">clear</i></label>

    <input class="checkbox" type="checkbox" id="size_4" value="small" checked />
    <label class="notification" for="size_4"><em>9</em> new <a href="">calendar event(s)</a> are scheduled for today.<i class="material-icons dp48 right">clear</i></label>

    <input class="checkbox" type="checkbox" id="size_5" value="small" checked />
    <label class="notification" for="size_5"><em>1</em> blog post <a href="">comment(s)</a> need approval.<i class="material-icons dp48 right">clear</i></label>

</div>

<dx:ASPxPopupControl ID="SwitchAppPopup" runat="server" Width="500" Height="200" AllowDragging="True" HeaderText="Switch App" ShowFooter="True"
    Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
    PopupAnimationType="Fade" ClientInstanceName="ClientSwitchAppPopup" ShowCloseButton="true" CloseAction="CloseButton">
    <ContentCollection>
        <dx:PopupControlContentControl>
            <dx:ASPxGridView ID="ApplicationGrid" runat="server" AutoGenerateColumns="false" EnableCallBacks="true"
                ClientInstanceName="ClientApplicationGrid" Width="100%" KeyFieldName="AppCode"
                OnCustomCallback="ApplicationGrid_CustomCallback">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="AppCode" VisibleIndex="1" Caption="Code" Width="80" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="AppName" VisibleIndex="2" Caption="Name" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Styles>
                    <AlternatingRow Enabled="true" />
                    <TitlePanel HorizontalAlign="Left"></TitlePanel>
                    <Header Border-BorderWidth="1" Font-Bold="true"></Header>
                </Styles>
                <Settings ShowFilterRow="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="200" VerticalScrollBarStyle="Standard" />
                <Paddings Padding="0px" />
                <Border BorderWidth="0px" />
                <SettingsBehavior AllowFocusedRow="True" />
                <SettingsPager Visible="true" PageSize="30" Mode="ShowPager" />
            </dx:ASPxGridView>
        </dx:PopupControlContentControl>
    </ContentCollection>
    <ContentStyle>
        <Paddings Padding="0" />
    </ContentStyle>
    <FooterTemplate>
        <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Cancel" AutoPostBack="false">
            <ClientSideEvents Click="function(s, e) {{ ClientSwitchAppPopup.Hide(); }}" />
        </dx:ASPxButton>
        <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Apply" UseSubmitBehavior="true" AutoPostBack="false">
            <ClientSideEvents Click="ClientSwitchAppApplyButton_Click" />
        </dx:ASPxButton>
        <div class="clear"></div>
    </FooterTemplate>
    <ClientSideEvents Shown="ClientSwitchAppPopup_Shown" />
</dx:ASPxPopupControl>

<dx:ASPxPopupControl ID="BIParameterPopup" runat="server" Width="380" Height="150" AllowDragging="True" HeaderText="Set System Parameters" ShowFooter="True"
    Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
    PopupAnimationType="Fade" ClientInstanceName="ClientBIParameterPopup" ShowCloseButton="true" CloseAction="CloseButton">
    <ContentCollection>
        <dx:PopupControlContentControl>
            <dx:ASPxCallbackPanel ID="BIParamsCallbackPanel" runat="server" Width="100%" OnCallback="BIParamsCallbackPanel_Callback" ClientInstanceName="BIParamsCallbackPanel">
                <ClientSideEvents EndCallback="ClientBIParamsCallbackPanel_EndCallback" />
                <PanelCollection>
                    <dx:PanelContent>
                        <dx:ASPxFormLayout ID="BIParametersForm" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                            AlignItemCaptionsInAllGroups="true" Width="100%" ColCount="1" OptionalMark=" ">
                            <Items>
                                <dx:LayoutGroup Caption="BI Parameters" ColCount="2">
                                    <Items>
                                        <dx:LayoutItem Caption="Actual" CaptionStyle-Font-Bold="true">
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Chốt đến ngày">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dtpADateOfFAST" runat="server" Width="100" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption=" " Visible="false">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dtpADatePreviousWeek" runat="server" Width="100" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                                        <%-- <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>--%>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Estimate" CaptionStyle-Font-Bold="true">
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Chốt đến ngày">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dtpEDateOfFAST" runat="server" Width="100" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption=" " Visible="false">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dtpEDatePreviousWeek" runat="server" Width="100" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                                        <%-- <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>--%>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Đồng bộ sản lượng, doanh thu VMS" ColCount="2">
                                    <Items>
                                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                                        <dx:LayoutItem Caption="Đồng bộ từ ngày">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dtpSyncFromDate" runat="server" Width="100" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Ước Doanh thu VNA" ColCount="2">
                                    <Items>
                                        <dx:LayoutItem Caption="Ước DT VNA" CaptionStyle-Font-Bold="true">
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Tháng">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxSpinEdit ID="spEstMonth" runat="server" Width="100" Number="1" MinValue="1" MaxValue="12">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxSpinEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                                        <dx:LayoutItem Caption="Năm">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxSpinEdit ID="spEstYear" runat="server" Width="100" MinValue="2010" MaxValue="9999">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxSpinEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                                        <dx:LayoutItem Caption="Tỷ lệ CK(%)">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxSpinEdit ID="spEstRate" runat="server" Number="12" Width="100" NumberType="Float">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxSpinEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Dashboard" ColCount="2">
                                    <Items>
                                        <dx:LayoutItem Caption="Version" ColSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cboDBVersion" runat="server" Width="100%" AutoResizeWithContainer="true" ValueType="System.Int32" OnInit="cboDBVersion_Init">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Hiển thị dữ liệu" CaptionStyle-Font-Bold="true">
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Từ ngày">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dtpDBFromDate" runat="server" Width="100" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                                        <dx:LayoutItem Caption="Đến ngày">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dtpDBToDate" runat="server" Width="100" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                            <Styles>
                                <LayoutGroupBox>
                                    <Caption CssClass="layoutGroupBoxCaption"></Caption>
                                </LayoutGroupBox>
                            </Styles>
                        </dx:ASPxFormLayout>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>
        </dx:PopupControlContentControl>
    </ContentCollection>
    <ContentStyle>
        <Paddings Padding="0" />
    </ContentStyle>
    <FooterTemplate>
        <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Cancel" AutoPostBack="false">
            <ClientSideEvents Click="function(s, e) {{ ClientBIParameterPopup.Hide(); }}" />
        </dx:ASPxButton>
        <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Apply" UseSubmitBehavior="true" AutoPostBack="false">
            <ClientSideEvents Click="ClientBIParametersApplyButton_Click" />
        </dx:ASPxButton>
        <div class="clear"></div>
    </FooterTemplate>
    <ClientSideEvents Shown="ClientBIParametersPopup_Shown" />
</dx:ASPxPopupControl>

<dx:ASPxPopupControl ID="SystemParameterPopup" runat="server" Width="380" Height="150" AllowDragging="True" HeaderText="Set System Parameters" ShowFooter="True"
    Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false"
    PopupAnimationType="Fade" ClientInstanceName="ClientSystemParameterPopup" ShowCloseButton="true" CloseAction="CloseButton">
    <ContentCollection>
        <dx:PopupControlContentControl>
            <dx:ASPxCallbackPanel ID="SystemParameterCallbackPanel" runat="server" Width="100%" OnCallback="SystemParameterCallbackPanel_Callback" ClientInstanceName="SystemParameterCallbackPanel">
                <ClientSideEvents EndCallback="SystemParameterCallbackPanel_EndCallback" />
                <PanelCollection>
                    <dx:PanelContent>
                        <dx:ASPxFormLayout ID="SystemParameterFormLayout" runat="server" RequiredMarkDisplayMode="Auto" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption"
                            AlignItemCaptionsInAllGroups="true" Width="100%" ColCount="1" OptionalMark=" ">
                            <Items>
                                <dx:LayoutGroup Caption="Database Information" ColCount="2">
                                    <Items>
                                        <dx:LayoutItem Caption="VMS Database" CaptionStyle-Font-Bold="true">
                                        </dx:LayoutItem>
                                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                                        <dx:LayoutItem Caption="VMS Server">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="VMSIPAddressEditor" runat="server" Width="120">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Database name">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="VMSDatabaseNameEditor" runat="server" Width="120">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="User Name">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="VMSDatabaseUIDEditor" runat="server" Width="120">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Password">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="VMSDatabasePwdEditor" runat="server" Width="120" Password="true">
                                                        <%-- <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>--%>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>

                                        <dx:LayoutItem Caption="FAST Database" CaptionStyle-Font-Bold="true">
                                        </dx:LayoutItem>
                                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                                        <dx:LayoutItem Caption="FAST Server">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="FASTIPAddressEditor" runat="server" Width="120">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Database name">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="FASTDatabaseNameEditor" runat="server" Width="120">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="User Name">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="FASTDatabaseUIDEditor" runat="server" Width="120">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Password">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="FASTDatabasePwdEditor" runat="server" Width="120" Password="true">
                                                        <%-- <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>--%>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>

                                        <dx:LayoutItem Caption="BAMBOO Database" CaptionStyle-Font-Bold="true">
                                        </dx:LayoutItem>
                                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                                        <dx:LayoutItem Caption="BAMBOO Server">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="BAMBOOIPAddressEditor" runat="server" Width="120">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Database name">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="BAMBOODatabaseNameEditor" runat="server" Width="120">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="User Name">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="BAMBOODatabaseUIDEditor" runat="server" Width="120">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Password">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="BAMBOODatabasePwdEditor" runat="server" Width="120" Password="true">
                                                        <%-- <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>--%>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Mã vụ việc được tổng hợp từ FAST sang KTQT" ColCount="2">
                                    <Items>
                                        <dx:LayoutItem Caption="Mã vụ việc" ColSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxMemo ID="ListFASTCodeEditor" runat="server" Width="100%" Rows="5">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxMemo>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Mã đơn vị cơ sở" ColCount="2">
                                    <Items>
                                        <dx:LayoutItem Caption="Mã ĐVCS BAMBOO">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="DVCSBAMBOOEditor" runat="server" Width="120">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Mã ĐVCS TSN">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="DVCSTsnEditor" runat="server" Width="120">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Mã ĐVCS NBA">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="DVCSNbaEditor" runat="server" Width="120">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Mã ĐVCS DAD">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="DVCSDadEditor" runat="server" Width="120">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Phương pháp phân bổ doanh thu, chi phí" ColCount="2">
                                    <Items>
                                        <dx:LayoutItem Caption="DT không theo CB" ColSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="AllocateMethodEditor" runat="server" Width="100%">
                                                        <Items>
                                                            <dx:ListEditItem Value="M" Text="Phân bổ theo kỳ voucher" />
                                                            <dx:ListEditItem Value="P" Text="Phân bổ theo kỳ báo cáo" />
                                                        </Items>
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true" ErrorTextPosition="Right">
                                                            <RequiredField IsRequired="True" ErrorText="" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                            <Styles>
                                <LayoutGroupBox>
                                    <Caption CssClass="layoutGroupBoxCaption"></Caption>
                                </LayoutGroupBox>
                            </Styles>
                        </dx:ASPxFormLayout>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>
        </dx:PopupControlContentControl>
    </ContentCollection>
    <ContentStyle>
        <Paddings Padding="0" />
    </ContentStyle>
    <FooterTemplate>
        <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnCancel" runat="server" Text="Cancel" AutoPostBack="false">
            <ClientSideEvents Click="function(s, e) {{ ClientSystemParameterPopup.Hide(); }}" />
        </dx:ASPxButton>
        <dx:ASPxButton CssClass="AddressBookPopupButton" ID="btnApply" runat="server" Text="Apply" UseSubmitBehavior="true" AutoPostBack="false">
            <ClientSideEvents Click="ClientSystemParameterApplyButton_Click" />
        </dx:ASPxButton>
        <div class="clear"></div>
    </FooterTemplate>
    <ClientSideEvents Shown="ClientSystemParameterPopup_Shown" />
</dx:ASPxPopupControl>

<%--<dx:ASPxTimer runat="server" ID="Timer" ClientInstanceName="timer" Interval="1000">
    <ClientSideEvents Init="UpdateTime" Tick="UpdateTime" />
</dx:ASPxTimer>--%>
<asp:XmlDataSource ID="InfoMenuDataSource" runat="server" DataFile="~/App_Data/InfoLayout.xml" XPath="Items/Item" />
