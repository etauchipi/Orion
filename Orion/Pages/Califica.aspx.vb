Public Class Califica
    Inherits System.Web.UI.Page


    Private appProxy As wsOrionProxy.IwsOrionClient
    Private Compresion As Compresion.Compresion
    Private AppGeneral As AppGeneral.AppGeneral
    Private fFormato As AppGeneral.AppGeneral.FormatoFecha
    Private sCadena As String
    Private sImagenes As String
    Private nId_empleado As Integer
    Private nEmpleado As Integer
    Private nperiodo As Integer
    Private bOk As Boolean
    Private empleado_data As wsOrionProxy.wsOrion.dtSessionVars
    Private xnotas As wsOrionProxy.wsOrion.votanteData

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        xnotas = New wsOrionProxy.wsOrion.votanteData

        If Not (Page.IsPostBack) Then
            inicializa_ctrls()
            Inicia_notas(False)
            img_empleado.ImageUrl = ""
        End If

        nId_empleado = 0
        lblMensajeenvio.Text = "Digite un nombre, apellido, identificación o una parte de éstos, y dar click en Buscar"
        bt_enviar.Visible = False
        sImagenes = ConfigurationManager.AppSettings("app_global_imagenes")
        xnotas = Cargar_calificaciones()
        Carga_notas(xnotas)

    End Sub

    Private Sub inicializa_ctrls()

        Me.Title = "Orion - Clínica de la Mujer"

    End Sub

    Private Function Cargar_calificaciones() As wsOrionProxy.wsOrion.votanteData

        Dim retorno As wsOrionProxy.wsOrion.votanteData

        retorno = New wsOrionProxy.wsOrion.votanteData
        nperiodo = CInt(ConfigurationManager.AppSettings("app_global_periodo"))
        appProxy = New wsOrionProxy.IwsOrionClient

        Try
            retorno = appProxy.get_votante_data(CInt(Session("App_UserId")), CInt(nperiodo))
        Catch ex As Exception
            retorno.id_empleado = 0
        Finally
            'Mensaje de error
        End Try

        Return retorno

    End Function

    Private Sub Inicia_notas(bopcion As Boolean)

        'Grupo 1
        CheckBox1.Enabled = bopcion
        CheckBox2.Enabled = bopcion
        CheckBox3.Enabled = bopcion
        CheckBox4.Enabled = bopcion
        CheckBox5.Enabled = bopcion
        CheckBox6.Enabled = bopcion
        CheckBox7.Enabled = bopcion
        CheckBox8.Enabled = bopcion
        CheckBox9.Enabled = bopcion
        CheckBox10.Enabled = bopcion
        CheckBox11.Enabled = bopcion
        CheckBox12.Enabled = bopcion
        CheckBox13.Enabled = bopcion
        CheckBox14.Enabled = bopcion

    End Sub

    Private Sub Carga_notas(ByRef xnotas As wsOrionProxy.wsOrion.votanteData)

        'Grupo 1
        CheckBox1.Checked = IIf(xnotas.p1 > 0, True, False)
        CheckBox2.Checked = IIf(xnotas.p2 > 0, True, False)
        CheckBox3.Checked = IIf(xnotas.p3 > 0, True, False)
        CheckBox4.Checked = IIf(xnotas.p4 > 0, True, False)
        CheckBox5.Checked = IIf(xnotas.p5 > 0, True, False)
        CheckBox6.Checked = IIf(xnotas.p6 > 0, True, False)
        CheckBox7.Checked = IIf(xnotas.p7 > 0, True, False)
        CheckBox8.Checked = IIf(xnotas.p8 > 0, True, False)
        CheckBox9.Checked = IIf(xnotas.p9 > 0, True, False)
        CheckBox10.Checked = IIf(xnotas.p10 > 0, True, False)
        CheckBox11.Checked = IIf(xnotas.p11 > 0, True, False)
        CheckBox12.Checked = IIf(xnotas.p12 > 0, True, False)
        CheckBox13.Checked = IIf(xnotas.p13 > 0, True, False)
        CheckBox14.Checked = IIf(xnotas.p14 > 0, True, False)

        If (gv_data.Rows.Count > 0) Then

            CheckBox1.Enabled = IIf(xnotas.p1 <= 0, True, False)
            CheckBox2.Enabled = IIf(xnotas.p2 <= 0, True, False)
            CheckBox3.Enabled = IIf(xnotas.p3 <= 0, True, False)
            CheckBox4.Enabled = IIf(xnotas.p4 <= 0, True, False)
            CheckBox5.Enabled = IIf(xnotas.p5 <= 0, True, False)
            CheckBox6.Enabled = IIf(xnotas.p6 <= 0, True, False)
            CheckBox7.Enabled = IIf(xnotas.p7 <= 0, True, False)
            CheckBox8.Enabled = IIf(xnotas.p8 <= 0, True, False)
            CheckBox9.Enabled = IIf(xnotas.p9 <= 0, True, False)
            CheckBox10.Enabled = IIf(xnotas.p10 <= 0, True, False)
            CheckBox11.Enabled = IIf(xnotas.p11 <= 0, True, False)
            CheckBox12.Enabled = IIf(xnotas.p12 <= 0, True, False)
            CheckBox13.Enabled = IIf(xnotas.p13 <= 0, True, False)
            CheckBox14.Enabled = IIf(xnotas.p14 <= 0, True, False)

        End If

        If Session("App_UserCalidad") Then
            CheckBox12.Visible = True
            CheckBox13.Visible = True
            CheckBox14.Visible = True

            If Not (Session("App_UserAdministrador")) Then
                '
                CheckBox1.Visible = False
                CheckBox2.Visible = False
                CheckBox3.Visible = False
                CheckBox4.Visible = False
                CheckBox5.Visible = False
                CheckBox6.Visible = False
                CheckBox7.Visible = False
                CheckBox8.Visible = False
                CheckBox9.Visible = False
                CheckBox10.Visible = False
                CheckBox11.Visible = False

            End If

        Else

            CheckBox12.Visible = False
            CheckBox13.Visible = False
            CheckBox14.Visible = False

        End If

    End Sub

    Private Sub Cargar_lista()

        Dim ds As DataSet
        Dim sds As String
        Dim sFecha As String

        ds = New DataSet
        sds = String.Empty
        sFecha = ""
        appProxy = New wsOrionProxy.IwsOrionClient
        Compresion = New Compresion.Compresion

        Try
            sds = appProxy.get_data(0, sCadena)
        Catch ex As Exception
            sds = String.Empty
        Finally
            'Mensaje de error
        End Try

        If sds <> String.Empty Then
            Try
                ds = Compresion.DescomprimirDataset(sds)
            Catch ex As Exception
                sds = String.Empty
            Finally
            End Try
        End If

        If sds <> String.Empty Then
            lblMensajeenvio.Text = "Seleccione el registro buscado, o busque otro dato"
            gv_data.DataSource = Nothing
            ds.Tables(0).DefaultView.Sort = " apellido DESC"
            gv_data.DataSource = ds.Tables(0)
            gv_data.DataBind()
        End If

    End Sub

    Protected Sub bt_buscar_Click1(sender As Object, e As EventArgs) Handles bt_buscar.Click

        Dim sCad As String

        gv_data.Visible = True
        bt_enviar.Enabled = True

        sCad = IIf(IsError(Trim(c_Search.Text)), "", Trim(c_Search.Text))
        lblMensajeenvio.Text = "Seleccione el registro buscado, realice una nueva búsqueda"

        If (Len(sCad) > 0) Then
            sCadena = "%" & sCad & "%"
            Cargar_lista()
        Else
            img_empleado.ImageUrl = ""
            gv_data.DataSource = Nothing
            gv_data.DataBind()
        End If

    End Sub

    Protected Sub bt_enviar_Click1(sender As Object, e As EventArgs) Handles bt_enviar.Click

        If (gv_data.SelectedValue > 0) Then
            Guarda_calificacion(xnotas)
            Response.Redirect("~/inicio")
        End If

    End Sub

    Protected Sub gv_data_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gv_data.SelectedIndexChanged

        xnotas = New wsOrionProxy.wsOrion.votanteData
        bOk = True
        bt_enviar.Visible = True
        nId_empleado = gv_data.SelectedValue
        lblMensajeenvio.Text = "Seleccione una o mas de las categorías disponibles por las que desee votar, y presione Votar, o seleecione/busque otro dato. Una vez realizada la votación, espere unos momentos mientras se procesan los correos y el registro."

        Carga_empleado()
        Inicia_notas(True)
        xnotas = Cargar_calificaciones()
        Carga_notas(xnotas)

    End Sub

    Private Sub Guarda_calificacion(ByRef xnotas As wsOrionProxy.wsOrion.votanteData)

        Dim nSeleccion As Integer
        Dim bSi As Boolean

        xnotas = New wsOrionProxy.wsOrion.votanteData
        appProxy = New wsOrionProxy.IwsOrionClient

        nSeleccion = 0
        bSi = False
        lblMensajeenvio.Text = "Se ha enviado una notificación a la persona seleccionada. Un momento, por favor"
        nperiodo = CInt(ConfigurationManager.AppSettings("app_global_periodo"))
        xnotas = Cargar_calificaciones()

        nSeleccion = gv_data.SelectedValue
        xnotas.id_empleado = CInt(Session("App_UserId"))
        xnotas.id_periodo_cal = nperiodo
        xnotas.p1 = IIf(HiddenField1.Value = 1, nSeleccion, xnotas.p1)
        xnotas.p2 = IIf(HiddenField2.Value = 1, nSeleccion, xnotas.p2)
        xnotas.p3 = IIf(HiddenField3.Value = 1, nSeleccion, xnotas.p3)
        xnotas.p4 = IIf(HiddenField4.Value = 1, nSeleccion, xnotas.p4)
        xnotas.p5 = IIf(HiddenField5.Value = 1, nSeleccion, xnotas.p5)
        xnotas.p6 = IIf(HiddenField6.Value = 1, nSeleccion, xnotas.p6)
        xnotas.p7 = IIf(HiddenField7.Value = 1, nSeleccion, xnotas.p7)
        xnotas.p8 = IIf(HiddenField8.Value = 1, nSeleccion, xnotas.p8)
        xnotas.p9 = IIf(HiddenField9.Value = 1, nSeleccion, xnotas.p9)
        xnotas.p10 = IIf(HiddenField10.Value = 1, nSeleccion, xnotas.p10)
        xnotas.p11 = IIf(HiddenField11.Value = 1, nSeleccion, xnotas.p11)
        xnotas.p12 = IIf(HiddenField12.Value = 1, nSeleccion, xnotas.p12)
        xnotas.p13 = IIf(HiddenField13.Value = 1, nSeleccion, xnotas.p13)
        xnotas.p14 = IIf(HiddenField14.Value = 1, nSeleccion, xnotas.p14)

        Try
            appProxy.set_votante_data(xnotas)
            bSi = True
        Catch ex As Exception
        Finally
            'Mensaje de error
        End Try

        If bSi Then
            Try
                enviar_aviso()
            Catch ex As Exception
            Finally
                'Mensaje de error
            End Try
        End If

    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        HiddenField1.Value = 1
    End Sub

    Protected Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        HiddenField2.Value = 1
    End Sub

    Protected Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        HiddenField3.Value = 1
    End Sub

    Protected Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        HiddenField4.Value = 1
    End Sub

    Protected Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        HiddenField5.Value = 1
    End Sub

    Protected Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        HiddenField6.Value = 1
    End Sub

    Protected Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        HiddenField7.Value = 1
    End Sub

    Protected Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        HiddenField8.Value = 1
    End Sub

    Protected Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        HiddenField9.Value = 1
    End Sub

    Protected Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox10.CheckedChanged
        HiddenField10.Value = 1
    End Sub

    Protected Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox11.CheckedChanged
        HiddenField11.Value = 1
    End Sub

    Protected Sub CheckBox12_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox12.CheckedChanged
        HiddenField12.Value = 1
    End Sub

    Protected Sub CheckBox13_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox13.CheckedChanged
        HiddenField13.Value = 1
    End Sub

    Protected Sub CheckBox14_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox14.CheckedChanged
        HiddenField14.Value = 1
    End Sub
    Private Sub Carga_empleado()

        Dim sCad As String
        Dim msg As wsOrionProxy.wsOrion.eMailData
        Dim ds As DataSet
        Dim sds As String

        ds = New DataSet
        sds = String.Empty
        appProxy = New wsOrionProxy.IwsOrionClient
        sImagenes = ConfigurationManager.AppSettings("app_global_imagenes")

        msg = New wsOrionProxy.wsOrion.eMailData
        sCad = String.Empty

        Try
            sCad = "CALIFICANDO A:  " & Trim(gv_data.Rows(gv_data.SelectedIndex).Cells(3).Text) & " " & Trim(gv_data.Rows(gv_data.SelectedIndex).Cells(2).Text) & " - " & Trim(gv_data.Rows(gv_data.SelectedIndex).Cells(4).Text)
            img_empleado.ImageUrl = sImagenes & Trim(gv_data.Rows(gv_data.SelectedIndex).Cells(6).Text) & ".jpg"

        Catch ex As Exception
            sCad = String.Empty
        End Try

        lblDataEmpleado.Text = sCad

    End Sub

    Private Sub enviar_aviso()

        Dim msg As wsOrionProxy.wsOrion.eMailData
        Dim sCategoria As String

        sCategoria = String.Empty
        msg = New wsOrionProxy.wsOrion.eMailData

        If (HiddenField1.Value = 1) Then
            sCategoria += "EXCELENCIA EN CULTURA ORGANIZACIONAL" & ": "
            sCategoria += Trim(CheckBox1.Text) & " - "
        End If

        If (HiddenField2.Value = 1) Then
            sCategoria += "EXCELENCIA EN CULTURA ORGANIZACIONAL" & ": "
            sCategoria += Trim(CheckBox2.Text) & " - "
        End If

        If (HiddenField3.Value = 1) Then
            sCategoria += "EXCELENCIA EN CULTURA ORGANIZACIONAL" & ": "
            sCategoria += Trim(CheckBox3.Text) & " - "
        End If

        If (HiddenField4.Value = 1) Then
            sCategoria += "EXCELENCIA EN CULTURA ORGANIZACIONAL" & ": "
            sCategoria += Trim(CheckBox4.Text) & " - "
        End If

        If (HiddenField5.Value = 1) Then
            sCategoria += "EXCELENCIA EN CULTURA ORGANIZACIONAL" & ": "
            sCategoria += Trim(CheckBox5.Text) & " - "
        End If

        If (HiddenField6.Value = 1) Then
            sCategoria += "EXCELENCIA EN CULTURA ORGANIZACIONAL" & ": "
            sCategoria += Trim(CheckBox6.Text) & " - "
        End If

        If (HiddenField7.Value = 1) Then
            sCategoria += "EXCELENCIA EN CULTURA ORGANIZACIONAL" & ": "
            sCategoria += Trim(CheckBox7.Text) & " - "
        End If

        If (HiddenField8.Value = 1) Then
            sCategoria += "MEJOR EQUIPO DE TRABAJO" & ": "
            sCategoria += Trim(CheckBox8.Text) & " - "
        End If

        If (HiddenField9.Value = 1) Then
            sCategoria += "MEJOR EQUIPO DE TRABAJO" & ": "
            sCategoria += Trim(CheckBox9.Text) & " - "
        End If

        If (HiddenField10.Value = 1) Then
            sCategoria += "PREMIO A LA INNOVACIÓN" & ": "
            sCategoria += Trim(CheckBox10.Text) & " - "
        End If

        If (HiddenField11.Value = 1) Then
            sCategoria += "PREMIO A LA INNOVACIÓN" & ": "
            sCategoria += Trim(CheckBox11.Text) & " - "
        End If

        If (HiddenField12.Value = 1) Then
            sCategoria += "CUMPLIMIENTO EN CALIDAD Y MEJORAMIENTO CONTINUO" & ": "
            sCategoria += Trim(CheckBox12.Text) & " - "
        End If

        If (HiddenField13.Value = 1) Then
            sCategoria += "CUMPLIMIENTO EN CALIDAD Y MEJORAMIENTO CONTINUO" & ": "
            sCategoria += Trim(CheckBox13.Text) & " - "
        End If

        If (HiddenField14.Value = 1) Then
            sCategoria += "CUMPLIMIENTO EN CALIDAD Y MEJORAMIENTO CONTINUO" & ": "
            sCategoria += Trim(CheckBox14.Text)
        End If

        If (Len(Trim(sCategoria)) > 1) Then
            email_carga(msg, sCategoria)
        End If

    End Sub

    Private Sub email_carga(ByRef msg As wsOrionProxy.wsOrion.eMailData, sCategoria As String)

        Dim m_body As StringBuilder
        Dim sCad1 As String

        sCad1 = String.Empty
        m_body = New StringBuilder
        appProxy = New wsOrionProxy.IwsOrionClient

        m_body.AppendFormat(ConfigurationManager.AppSettings("app_email_body_header").ToString).AppendLine()
        m_body.AppendFormat("").AppendLine()
        m_body.AppendFormat(ConfigurationManager.AppSettings("app_email_body_01").ToString).AppendLine()
        m_body.AppendFormat("").AppendLine()
        m_body.AppendFormat(sCategoria).AppendLine()
        m_body.AppendFormat("").AppendLine()
        m_body.AppendFormat(ConfigurationManager.AppSettings("app_email_body_02").ToString).AppendLine()
        m_body.AppendFormat("").AppendLine()
        m_body.AppendFormat(ConfigurationManager.AppSettings("app_email_body_03").ToString).AppendLine()
        m_body.AppendFormat("").AppendLine()
        m_body.AppendFormat("").AppendLine()
        m_body.AppendFormat("").AppendLine()
        m_body.AppendFormat(ConfigurationManager.AppSettings("app_email_body_footer03").ToString).AppendLine()
        m_body.AppendFormat(ConfigurationManager.AppSettings("Header_footer_generado").ToString & " - Fecha:  " & Now().ToLongDateString).AppendLine()
        m_body.AppendFormat("").AppendLine()

        'msg.email = "analistasistemas@clinicadelamujer.com.co"
        msg.Body = m_body.ToString
        msg.Empleado_eMail = Trim(gv_data.Rows(gv_data.SelectedIndex).Cells(5).Text)
        msg.Adicional_eMail1 = ConfigurationManager.AppSettings("app_email_cc").ToString
        msg.Empleado_Nombre = Trim(gv_data.Rows(gv_data.SelectedIndex).Cells(3).Text) & " " & Trim(gv_data.Rows(gv_data.SelectedIndex).Cells(2).Text)
        msg.Subject = ConfigurationManager.AppSettings("app_email_subject").ToString

        Try
            appProxy.eMail_Crear(msg)
        Catch ex As Exception
            sCad1 = ex.InnerException.Source.ToString
        Finally
        End Try

        m_body = New StringBuilder

        m_body.AppendFormat("").AppendLine()
        m_body.AppendFormat("Usted registró votación para: " & Trim(gv_data.Rows(gv_data.SelectedIndex).Cells(3).Text) & " " & Trim(gv_data.Rows(gv_data.SelectedIndex).Cells(2).Text)).AppendLine()
        m_body.AppendFormat("").AppendLine()
        m_body.AppendFormat(sCategoria).AppendLine()
        m_body.AppendFormat("").AppendLine()
        m_body.AppendFormat("").AppendLine()
        m_body.AppendFormat("").AppendLine()
        m_body.AppendFormat(ConfigurationManager.AppSettings("app_email_body_footer03").ToString).AppendLine()
        m_body.AppendFormat(ConfigurationManager.AppSettings("Header_footer_generado").ToString & " - Fecha: " & Now().ToLongDateString).AppendLine()
        m_body.AppendFormat("").AppendLine()

        'msg.email = "analistasistemas@clinicadelamujer.com.co"
        msg.Body = m_body.ToString
        msg.Empleado_eMail = Trim(Session("App_UserMail"))
        msg.Adicional_eMail1 = ""
        msg.Empleado_Nombre = Trim(Session("App_UserName"))
        msg.Subject = "ORION - Registro de votación"

        Try
            appProxy.eMail_Crear(msg)
        Catch ex As Exception
            sCad1 = ex.InnerException.Source.ToString
        Finally
        End Try



    End Sub

End Class