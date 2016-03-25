<%@ page title="Cambiar contraseña" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Account_ChangePassword, App_Web_klehqjqv" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 class="TitulosTablaABM">
        Cambiar contraseña
    </h2>
    <p>
        Las contraseñas nuevas deben tener una longitud mínima de
        <%= Membership.MinRequiredPasswordLength %>
        caracteres.
    </p>
    <div style="width: 100%; position: relative; margin-left: 250px">
        <asp:ChangePassword ID="ChangeUserPassword" runat="server" CancelDestinationPageUrl="~/"
            EnableViewState="false" RenderOuterTable="false" SuccessPageUrl="ChangePasswordSuccess.aspx">
            <ChangePasswordTemplate>
                <span class="failureNotification">
                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                </span>
                <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification"
                    ValidationGroup="ChangeUserPasswordValidationGroup" />
                <div style="width: 100%">
                    <fieldset style="width: 40%; height: 250px;">
                        <legend>Información de cuenta</legend>
                        <p align="left">
                            <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Contraseña anterior:</asp:Label>
                            <asp:TextBox ID="CurrentPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                CssClass="failureNotification" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña anterior es obligatoria."
                                ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p align="left">
                            <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">Nueva contraseña:</asp:Label>
                            <asp:TextBox ID="NewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                CssClass="failureNotification" ErrorMessage="La nueva contraseña es obligatoria."
                                ToolTip="La nueva contraseña es obligatoria." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p align="left">
                            <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirmar la nueva contraseña:</asp:Label>
                            <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirmar la nueva contraseña es obligatorio."
                                ToolTip="Confirmar la nueva contraseña es obligatorio." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                ControlToValidate="ConfirmNewPassword" CssClass="failureNotification" Display="Dynamic"
                                ErrorMessage="Confirmar la nueva contraseña debe coincidir con la entrada Nueva contraseña."
                                ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:CompareValidator>
                        </p>
                        <p class="submitButton">
                            <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="Cancelar" CssClass="ui-button"/>
                            <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                Text="Cambiar contraseña" ValidationGroup="ChangeUserPasswordValidationGroup" CssClass="ui-button"/>
                        </p>
                    </fieldset>
                </div>
            </ChangePasswordTemplate>
        </asp:ChangePassword>
    </div>
</asp:Content>
