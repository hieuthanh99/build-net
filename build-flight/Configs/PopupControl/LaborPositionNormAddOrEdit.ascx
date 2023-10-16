<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LaborPositionNormAddOrEdit.ascx.cs" Inherits="Configs_PopupControl_LaborPositionNormAddOrEdit" %>


<dx:ASPxFormLayout ID="LaborNormForm" runat="server" ColCount="1" RequiredMarkDisplayMode="None" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientLaborNormForm"
    AlignItemCaptionsInAllGroups="true" Width="100%">
    <Items>
       <%-- <dx:LayoutItem Caption="Năm">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="ForYearEditor" Width="350" Height="25px" MinValue="2018" MaxValue="9999" HorizontalAlign="Right" ClientInstanceName="ClientForYearEditor" >
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>--%>
        <dx:LayoutItem Caption="Khu vực">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxComboBox runat="server" ID="AreaCodeEditor" Width="350" Height="25px" ClientInstanceName="ClientAreaCodeEditor"  OnInit="AreaCodeEditor_Init">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Số người">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="PeopleNbrEditor" Width="350" MinValue="0" MaxValue="1000" HorizontalAlign="Right" ClientInstanceName="ClientPeopleNbrEditor" >
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                        <ClientSideEvents ValueChanged="RevCost.CalculateWorkTotal" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Số ca">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="ShiftNbrEditor" Width="350" MinValue="0" MaxValue="3" HorizontalAlign="Right" ClientInstanceName="ClientShiftNbrEditor" >
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                        <ClientSideEvents ValueChanged="RevCost.CalculateWorkTotal" />
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Hao phí LĐ(công)">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxSpinEdit runat="server" ID="WorkTotalEditor" Width="350" ReadOnly="true" HorizontalAlign="Right" ClientInstanceName="ClientWorkTotalEditor" >
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Diễn giải">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxMemo runat="server" ID="DescriptionEditor" Width="350" Rows="3" ClientInstanceName="ClientDescriptionEditor" >
                    </dx:ASPxMemo>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Ngừng theo dõi">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxCheckBox ID="InactiveEditor" runat="server" ClientInstanceName="ClientInactiveEditor" ></dx:ASPxCheckBox>
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
