<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LaborNormDetailAddOrEdit.ascx.cs" Inherits="Configs_PopupControl_LaborNormDetailAddOrEdit" %>

<dx:ASPxFormLayout ID="LaborNormForm" runat="server" ColCount="1" RequiredMarkDisplayMode="None" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientLaborNormForm"
    AlignItemCaptionsInAllGroups="true" Width="100%">
    <Items>
        <dx:LayoutItem Caption="Nhóm sản phẩm">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxComboBox ID="GroupEditor" runat="server" Width="255" ClientInstanceName="ClientGroupEditor"  OnInit="GroupEditor_Init">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                        <ClientSideEvents ValueChanged="RevCost.ClientGroupEditor_ValueChanged" />
                    </dx:ASPxComboBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="Tên sản phẩm">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxComboBox runat="server" ID="CodeEditor" Width="255" ClientInstanceName="ClientCodeEditor"  OnCallback="CodeEditor_Callback">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                        <ClientSideEvents EndCallback="RevCost.ClientCodeEditor_EndCallback" />
                    </dx:ASPxComboBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="TG chuẩn bị">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="PrepareTimeEditor" Width="255" ClientInstanceName="ClientPrepareTimeEditor" >
                        <ClientSideEvents ValueChanged="RevCost.CalculateLaborNormTimes" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="TG tác nghiệp">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="OperatingTimeEditor" Width="255" ClientInstanceName="ClientOperatingTimeEditor" >
                        <ClientSideEvents ValueChanged="RevCost.CalculateLaborNormTimes" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="Số người">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="PeopleEditor" Width="255" ClientInstanceName="ClientPeopleEditor" >
                        <ClientSideEvents ValueChanged="RevCost.CalculateLaborNormTimes" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="Hệ số K">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="CoefficientKEditor" Width="255" ClientInstanceName="ClientCoefficientKEditor" >
                        <ClientSideEvents ValueChanged="RevCost.CalculateLaborNormTimes" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="Tổng TG hao phí(phút)">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="ExpendMinutesEditor" Width="255" ClientInstanceName="ClientExpendMinutesEditor" ReadOnly="true" >
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="Tổng TG hao phí(giờ)">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="ExpendHoursEditor" Width="255" ClientInstanceName="ClientExpendHoursEditor" ReadOnly="true" >
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Diễn giải">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxMemo runat="server" ID="LaborNormDetailDescriptionEditor" Width="400" Rows="3" ClientInstanceName="ClientLaborNormDetailDescriptionEditor" >
                    </dx:ASPxMemo>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Ngừng theo dõi">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxCheckBox ID="LaborNormDetailInactiveEditor" runat="server" ClientInstanceName="ClientLaborNormDetailInactiveEditor" ></dx:ASPxCheckBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
        <dx:LayoutItem Caption=" ">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxButton ID="btnSaveLaborNormDetail" runat="server" CssClass="btn btn-success" Text="LƯU"  AutoPostBack="false" UseSubmitBehavior="true">
                        <ClientSideEvents Click="RevCost.ClientLaborNormDetailAddOrEditPopup_Save" />
                    </dx:ASPxButton>
                    &nbsp;&nbsp;            &nbsp;&nbsp;            &nbsp;&nbsp;            &nbsp;&nbsp;          
                        <dx:ASPxButton ID="btnCancelUpdateLaborNormDetail" runat="server" CssClass="btn btn-success" Text="HỦY BỎ"  AutoPostBack="false" UseSubmitBehavior="true">
                            <ClientSideEvents Click="RevCost.ClientLaborNormDetailAddOrEditPopup_Hide" />
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
