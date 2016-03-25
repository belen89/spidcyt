<%@ page title="Iniciar sesión" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Account_Login, App_Web_klehqjqv" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 class="TitulosTablaABM">
        Iniciar sesión
    </h2>
    <p align="center">
        Especifique su nombre de usuario y contraseña.
        <%--<asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">Registrarse</asp:HyperLink> si no tiene una cuenta.--%>
    </p>
    <div style="width: 50%; position: relative; margin-left: 250px">
        <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
            <LayoutTemplate>
                <span class="failureNotification">
                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                </span>
                <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                    ValidationGroup="LoginUserValidationGroup" />
                <div>
                    <fieldset style="width:80%; height:250px;">
                        <legend>Información de cuenta</legend>
                        <p align="left">
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                            <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                CssClass="failureNotification" ErrorMessage="El nombre de usuario es obligatorio."
                                ToolTip="El nombre de usuario es obligatorio." ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p align="left">
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label><br />
                            <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                CssClass="failureNotification" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria."
                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p align="left">
                            <asp:CheckBox ID="RememberMe" runat="server" />
                            <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">No cerrar sesión</asp:Label>
                        </p>
                        <p align="left">                                                       
                            <asp:LinkButton ID="linkReestablecerContrsena" runat="server" OnClientClick="return confirm('Se le enviará un Email con su nueva contraseña. ¿Continuar?');" 
                                onclick="linkReestablecerContrsena_Click">Reestablecer contraseña</asp:LinkButton>
                        </p>
                        <p class="submitButton">
                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Iniciar sesión" CssClass="ui-button"
                                ValidationGroup="LoginUserValidationGroup" />
                        </p>
                    </fieldset>
                </div>
            </LayoutTemplate>
        </asp:Login>
    </div>
    </asp:Content>
