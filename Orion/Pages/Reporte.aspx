<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Reporte.aspx.vb" Inherits="Orion.Reporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</p>
<p>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="EXCELENCIA EN CULTURA ORGANIZACIONAL              "></asp:Label>
</p>
        <asp:UpdatePanel ID="updp_data" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gv_dataG1" runat="server" Width="99%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="15" RowHeaderColumn="id_archivo" ShowHeaderWhenEmpty="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="votanteNombre" HeaderText="Votante" ReadOnly="True" />
                        <asp:BoundField DataField="nomb1" HeaderText="Calidez en la atención" ReadOnly="True" />
                        <asp:BoundField DataField="nomb2" HeaderText="Ética profesional" ReadOnly="True" />
                        <asp:BoundField DataField="nomb3" HeaderText="Sensibilidad por el dolor ajeno" ReadOnly="True" />
                        <asp:BoundField DataField="nomb4" HeaderText="Prontitud en la atención" ReadOnly="True" />
                        <asp:BoundField DataField="nomb5" HeaderText="Vocación de servicio" />
                        <asp:BoundField DataField="nomb6" HeaderText="Seguridad del paciente" />
                        <asp:BoundField DataField="nomb7" HeaderText="Presentación personal" />
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
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" Text="MEJOR EQUIPO DE TRABAJO                           "></asp:Label>
                <br />
                <br />
                <asp:GridView ID="gv_dataG2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="15" RowHeaderColumn="id_archivo" ShowHeaderWhenEmpty="True" Width="99%">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="votanteNombre" HeaderText="Votante" ReadOnly="True" />
                        <asp:BoundField DataField="nomb8" HeaderText="Cumplimiento de metas" ReadOnly="True" />
                        <asp:BoundField DataField="nomb9" HeaderText="Colaboración" ReadOnly="True" />
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
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" Text="PREMIO A LA INNOVACIÓN                            "></asp:Label>
                <br />
                <br />
                <asp:GridView ID="gv_dataG3" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="15" RowHeaderColumn="id_archivo" ShowHeaderWhenEmpty="True" Width="99%">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="votanteNombre" HeaderText="Votante" ReadOnly="True" />
                        <asp:BoundField DataField="nomb10" HeaderText="Cambios/mejoras procesos/procedimientos" ReadOnly="True" />
                        <asp:BoundField DataField="nomb11" HeaderText="Adherencia/creación valor con herramientas tec." ReadOnly="True" />
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
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" Text="CUMPLIMIENTO EN CALIDAD Y MEJORAMIENTO CONTINUO   "></asp:Label>
                <br />
                <br />
                <asp:GridView ID="gv_dataG4" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="15" RowHeaderColumn="id_archivo" ShowHeaderWhenEmpty="True" Width="99%">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="votanteNombre" HeaderText="Votante" ReadOnly="True" />
                        <asp:BoundField DataField="nomb12" HeaderText="Cumplimiento en registro de indicadores" ReadOnly="True" />
                        <asp:BoundField DataField="nomb13" HeaderText="Análisis de indicadores" ReadOnly="True" />
                        <asp:BoundField DataField="nomb14" HeaderText="Gestión en oportunidad de mejora" />
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
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gv_dataG1" EventName="DataBinding" />
                <asp:AsyncPostBackTrigger ControlID="gv_dataG2" EventName="DataBinding" />
            </Triggers>
        </asp:UpdatePanel>
    <p>
</p>
</asp:Content>
