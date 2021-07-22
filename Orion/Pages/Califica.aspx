<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Califica.aspx.vb" Inherits="Orion.Califica" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            </h1>

        <asp:UpdatePanel ID="updp_txtBuscar" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="c_Search" runat="server" Width="32%" CausesValidation="True" ToolTip="Digite texto a buscar"></asp:TextBox>
                &nbsp;
                <asp:Button ID="bt_buscar" runat="server" Text="Buscar" UseSubmitBehavior="False" ToolTip="Buscar empleado" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="bt_enviar" runat="server" Text="Votar" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMensajeenvio" runat="server" CssClass="mensaje_nota" Font-Bold="True" Font-Size="Small" ForeColor="#0000CC" style="color: #0000CC" Width="46%"></asp:Label>
                <br />
                <br />
                <table align="center" class="auto-style14">
                    <tr>
                        <td class="auto-style18" colspan="4">
                            <asp:Label ID="lblDataEmpleado" runat="server" CssClass="mensaje_nota" Font-Bold="True" Font-Size="Medium" ForeColor="#0000CC" style="color: #0000CC" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style35">
                            <strong>PREMIO A LA INNOVACIÓN</strong></td>
                        <td class="auto-style36">
                            <asp:CheckBox ID="CheckBox10" runat="server" Text="Cambios o mejoras en procesos/procedimientos" />
                            <br />
                            <asp:CheckBox ID="CheckBox11" runat="server" Text="Adherencia/creación de valor con herramientas tecnológicas de innovación" />
                        </td>
                        <td class="auto-style34"><strong>EXCELENCIA EN CULTURA ORGANIZACIONAL</strong></td>


                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Calidez en la atención" />
                            <br />
                            <asp:CheckBox ID="CheckBox2" runat="server" Text="Ética profesional" />
                            <br />
                            <asp:CheckBox ID="CheckBox3" runat="server" Text="Sensibilidad por el dolor ajeno" />
                            <br />
                            <asp:CheckBox ID="CheckBox4" runat="server" CausesValidation="True" Text="Prontitud en la atención" />
                            <br />
                            <asp:CheckBox ID="CheckBox5" runat="server" CausesValidation="True" Text="Vocación de servicio" />
                            <br />
                            <asp:CheckBox ID="CheckBox6" runat="server" Text="Seguridad del paciente" />
                            <br />
                            <asp:CheckBox ID="CheckBox7" runat="server" Text="Presentación personal " />
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="auto-style35"><strong>CUMPLIMIENTO EN CALIDAD Y MEJORAMIENTO CONTINUO</strong></td>
                        <td class="auto-style36">
                            <asp:CheckBox ID="CheckBox12" runat="server" Text="Cumplimiento en registro de indicadores" />
                            <br />
                            <asp:CheckBox ID="CheckBox13" runat="server" Text="Análisis de indicadores" />
                            <br />
                            <asp:CheckBox ID="CheckBox14" runat="server" Text="Gestión en oportunidad de mejora" />
                        </td>
                        <td class="auto-style22"><strong>MEJOR EQUIPO DE TRABAJO</strong></td>
                        <td class="auto-style23">
                            <asp:CheckBox ID="CheckBox8" runat="server" Text="Cumplimiento de metas" />
                            <br />
                            <asp:CheckBox ID="CheckBox9" runat="server" Text="Colaboración" />
                        </td>
                    </tr>
                </table>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="updp_data" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gv_data" runat="server" Width="70%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="id_empleado" AllowSorting="True" AutoGenerateSelectButton="True" PageSize="15" RowHeaderColumn="id_archivo" ShowHeaderWhenEmpty="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="id_empleado" HeaderText="id_empleado" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="apellido" HeaderText="Apellido(s)" ReadOnly="True" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre(s)" ReadOnly="True" />
                        <asp:BoundField DataField="ccosto" HeaderText="Centro Costo" ReadOnly="True" />
                        <asp:BoundField DataField="eMail" HeaderText="eMail" ReadOnly="True" />
                        <asp:BoundField DataField="Identificacion" HeaderText="Identificación" ReadOnly="True" Visible="False" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                &nbsp;
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gv_data" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="gv_data" EventName="DataBinding" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <div class="row">
        <div class="col-md-4">
             
                        
             
             
                        
            <asp:UpdatePanel ID="updp_solicitud" runat="server">
                <ContentTemplate>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="img_empleado" runat="server" />
&nbsp;<asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField2" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField3" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField4" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField5" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField6" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField7" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField8" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField9" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField10" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField11" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField12" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField13" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField14" runat="server" Value="0" />
                    <asp:HiddenField ID="HFCategorias" runat="server" />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-4">
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style14 {
            width: 95%;
            border: 2px solid #000000;
        }
        .auto-style18 {
            height: 23px;
        }
        .auto-style22 {
            width: 190px;
            height: 56px;
        }
        .auto-style23 {
            text-align: left;
            height: 56px;
        }
        .auto-style34 {
        width: 190px;
    }
    .auto-style35 {
        width: 278px;
        text-align: center;
    }
    .auto-style36 {
        width: 242px;
        text-align: left;
    }
    </style>
</asp:Content>

