<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EquipmentTimeNormAddOrEdit.ascx.cs" Inherits="Configs_PopupControl_EquipmentTimeNormAddOrEdit" %>


<dx:ASPxFormLayout ID="MasterNormForm" runat="server" ColCount="1" RequiredMarkDisplayMode="None" Styles-LayoutGroupBox-Caption-CssClass="layoutGroupBoxCaption" ClientInstanceName="ClientMasterNormForm"
    AlignItemCaptionsInAllGroups="true" Width="100%">
    <Items>

        <dx:LayoutItem Caption="Khu vực">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxComboBox runat="server" ID="AreaEditor" Width="250" Height="25px" ClientInstanceName="ClientAreaEditor"  OnInit="AreaEditor_Init">
                    </dx:ASPxComboBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="Hãng VC">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxComboBox runat="server" ID="CarrierEditor" Width="250" Height="25px" ClientInstanceName="ClientCarrierEditor"  OnInit="CarrierEditor_Init">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="Mạng">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxComboBox runat="server" ID="NetworkEditor" Width="250" Height="25px" ClientInstanceName="ClientNetworkEditor" >
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                        <Items>
                            <dx:ListEditItem Value="DOM" Text="Quốc nội" />
                            <dx:ListEditItem Value="INT" Text="Quốc tế" />
                        </Items>
                    </dx:ASPxComboBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>

        <dx:LayoutItem Caption="Tàu bay">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxComboBox runat="server" ID="AircraftEditor" Width="250" Height="25px" ClientInstanceName="ClientAircraftEditor"  OnInit="AircraftEditor_Init">
                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="true" SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>       
        <dx:LayoutItem Caption="Diễn giải">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxMemo runat="server" ID="MasterNormDescriptionEditor" Width="400" Rows="3" ClientInstanceName="ClientMasterNormDescriptionEditor" >
                    </dx:ASPxMemo>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Ngừng theo dõi">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxCheckBox ID="MasterNormInactiveEditor" runat="server" ClientInstanceName="ClientMasterNormInactiveEditor" ></dx:ASPxCheckBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
        <dx:LayoutItem Caption=" ">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer>
                    <dx:ASPxButton ID="btnSaveLaborNorms" runat="server" CssClass="btn btn-success" Text="LƯU"  AutoPostBack="false" UseSubmitBehavior="true">
                        <ClientSideEvents Click="RevCost.ClienMasterNormAddOrEditPopup_Save" />
                    </dx:ASPxButton>
                    &nbsp;&nbsp;            &nbsp;&nbsp;            &nbsp;&nbsp;            &nbsp;&nbsp;          
                        <dx:ASPxButton ID="btnCancelUpdateLaborNorms" runat="server" CssClass="btn btn-success" Text="HỦY BỎ"  AutoPostBack="false" UseSubmitBehavior="true">
                            <ClientSideEvents Click="RevCost.ClientMasterNormAddOrEditPopup_Hide" />
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