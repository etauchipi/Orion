<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Orion._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        #logo
    {
        text-align: center;
    }
    .style3
    {
        color: #000000;
    }
    .style4
    {
        color: #000000;
        font-weight: bold;
    }
    #tableInfo
    {
        width: 449px;
        margin-left: 0px;
    }
    .style5
    {
        width: 13px;
    }
    .style6
    {
        font-family: Arial, Helvetica, sans-serif;
    }
    .style18
    {
        text-align: right;
        color: #000000;
    }
    .style25
    {
        color: #000000;
        font-weight: bold;
        font-family: Arial, Helvetica, sans-serif;
        width: 203px;
    }
        .auto-style1 {
            color: #000000;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            width: 203px;
            height: 19px;
        }
        .auto-style2 {
            text-align: right;
            color: #000000;
            height: 19px;
        }
    .auto-style5 {
        color: #000000;
        font-weight: bold;
        font-family: Arial, Helvetica, sans-serif;
        width: 203px;
        height: 19px;
        text-align: left;
    }
    .auto-style6 {
        color: #000000;
        font-weight: bold;
        font-family: Arial, Helvetica, sans-serif;
        width: 203px;
        text-align: right;
    }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
    </h2>

        <asp:Panel ID="PanelInfo" runat="server">
        
        &nbsp;
        <table id="tableInfo"  border="0" >
            <tr>
                <td colspan="2" style="text-align: center">
                    <br />
                    <a>
                    <asp:Image ID="logo" runat="server" 
                        ImageUrl="~/Images/LogoOrion.png" Height="223px" Width="334px" ClientIDMode="AutoID" />
                    
                    </a>
                    <br />
                    <asp:Image ID="Image2" runat="server" Height="2px" 
                        ImageUrl="~/Images/red2whiteline.jpg" Width="449px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    Bienvenido
                </td>
                <td class="auto-style2">
                    <b>
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                    </span></b>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="style18">
                    <b>
                    <asp:Label ID="lbl_UltIngreso" runat="server"></asp:Label>
                    </span></b>
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="2">
                    <asp:Label ID="lbl_Error" runat="server" CssClass="style6"></asp:Label>
                </td>
            </tr>
        </table>
    </p>
    </asp:Panel>

    <asp:Panel ID="PanelLogin" runat="server">
    <h2 class="style3">
        &nbsp;</h2>
        <h2 class="style3">
            Iniciar sesión
        </h2>
    <p>
        Digite su nombre de usuario y contraseña.</p>
    <p>
        <asp:TextBox ID="Usuario" runat="server" CausesValidation="True" Height="25px" 
            ValidationGroup="LoginGroup" Width="168px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="Usuario" 
            ErrorMessage="* Error. Debe digitar un nombre de usuario válido" 
            Font-Bold="True" ForeColor="Red" SetFocusOnError="True" 
            ValidationGroup="LoginGroup"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" 
            Width="168px" CausesValidation="True" Height="25px" TextMode="Password" 
            ValidationGroup="LoginGroup"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="Password" 
            ErrorMessage="* Error. Debe digitar su password. " Font-Bold="True" 
            ForeColor="Red" SetFocusOnError="True" ValidationGroup="LoginGroup"></asp:RequiredFieldValidator>
    </p>
    <p>
         <asp:Label ID="InvalidCredentialsMessage" runat="server" Font-Bold="True" 
            ForeColor="Blue" 
            Text="-" 
            Visible="False"></asp:Label>
    </p>
    </asp:Panel>

    <p>
        <asp:ImageButton ID="Bt_Verificar" runat="server" 
            ImageUrl="~/Images/bt_Login.gif" ValidationGroup="LoginGroup" 
            AlternateText="Login" />
        <asp:ImageButton ID="Bt_Logout" runat="server" 
            ImageUrl="~/Images/bt_Logout.gif" ValidationGroup="LoginGroup" AlternateText="Logout" />
    </p>
    <p>
        &nbsp;</p>

    </asp:Content>


