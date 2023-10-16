<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EquipmentTimeDetailNormAddOrEdit.ascx.cs" Inherits="Configs_PopupControl_EquipmentTimeDetailNormAddOrEdit" %>

<dx:ASPxFormLayout ID="DetailNormForm" runat="server" ColCount="2" RequiredMarkDisplayMode="None" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientDetailNormForm"
    AlignItemCaptionsInAllGroups="true" Width="100%">
    <Items>
        <dx:LayoutItem Caption="Nhóm thiết bị" ColSpan="2">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxComboBox ID="GroupEditor" runat="server" Width="362" AutoResizeWithContainer="true" ClientInstanceName="ClientGroupEditor"  OnInit="GroupEditor_Init">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                        <ClientSideEvents ValueChanged="RevCost.ClientGroupEditor_ValueChanged" />
                    </dx:ASPxComboBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Tên thiết bị" ColSpan="2">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxComboBox runat="server" ID="CodeEditor" Width="362" AutoResizeWithContainer="true" ClientInstanceName="ClientCodeEditor" OnCallback="CodeEditor_Callback" >
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                        <ClientSideEvents EndCallback="RevCost.ClientCodeEditor_EndCallback" />
                    </dx:ASPxComboBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Số lượng TTB">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="SoluongTTBEditor" Width="100" ClientInstanceName="ClientSoluongTTBEditor" >
                        <ClientSideEvents ValueChanged="RevCost.CalculateTotalTimes" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="TG chuẩn bị">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="PrepareTimeEditor" Width="100" ClientInstanceName="ClientPrepareTimeEditor" >
                        <ClientSideEvents ValueChanged="RevCost.CalculateTotalTimes" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="TG di chuyển">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="MovingTimeEditor" Width="100" ClientInstanceName="ClientMovingTimeEditor" >
                        <ClientSideEvents ValueChanged="RevCost.CalculateTotalTimes" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="TG chờ">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="WaitingTimeEditor" Width="100" ClientInstanceName="ClientWaitingTimeEditor" >
                        <ClientSideEvents ValueChanged="RevCost.CalculateTotalTimes" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="TG tiếp cận">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="ApproachTimeEditor" Width="100" ClientInstanceName="ClientApproachTimeEditor" >
                        <ClientSideEvents ValueChanged="RevCost.CalculateTotalTimes" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="TG p/v trên MB">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="TimeServedAtPlaneEditor" Width="100" ClientInstanceName="ClientTimeServedAtPlaneEditor" >
                        <ClientSideEvents ValueChanged="RevCost.CalculateTotalTimes" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="TG p/v tại kho">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="TimeServedAtStoreEditor" Width="100" ClientInstanceName="ClientTimeServedAtStoreEditor" >
                        <ClientSideEvents ValueChanged="RevCost.CalculateTotalTimes" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="TG p/v BC">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="TimeServedAtBCEditor" Width="100" ClientInstanceName="ClientTimeServedAtBCEditor" >
                        <ClientSideEvents ValueChanged="RevCost.CalculateTotalTimes" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="TG p/v đêm">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="NightServedTimeEditor" Width="100" ClientInstanceName="ClientNightServedTimeEditor" >
                        <ClientSideEvents ValueChanged="RevCost.CalculateTotalTimes" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="TG thu dọn">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="CleaningTimeEditor" Width="100" ClientInstanceName="ClientCleaningTimeEditor" >
                        <ClientSideEvents ValueChanged="RevCost.CalculateTotalTimes" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="Tổng thời gian">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="TotalTimeEditor" Width="100" ClientInstanceName="ClientTotalTimeEditor" ReadOnly="true" >
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Tần suất">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="FrequencyEditor" Width="100" ClientInstanceName="ClientFrequencyEditor" >
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:EmptyLayoutItem ColSpan="2"></dx:EmptyLayoutItem>
        <dx:LayoutItem Caption=" " ColSpan="2">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxButton ID="btnSaveDetailNorm" runat="server" CssClass="btn btn-success" Text="LƯU"  AutoPostBack="false" UseSubmitBehavior="true">
                        <ClientSideEvents Click="RevCost.ClientDetailNormAddOrEditPopup_Save" />
                    </dx:ASPxButton>
                    &nbsp;&nbsp;            &nbsp;&nbsp;            &nbsp;&nbsp;            &nbsp;&nbsp;          
                        <dx:ASPxButton ID="btnCancelUpdateDetailNorm" runat="server" CssClass="btn btn-success" Text="HỦY BỎ"  AutoPostBack="false" UseSubmitBehavior="true">
                            <ClientSideEvents Click="RevCost.ClientDetailNormAddOrEditPopup_Hide" />
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
