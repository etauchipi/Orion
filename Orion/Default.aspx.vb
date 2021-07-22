Imports System.Web.HttpServerUtility
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.Web.UI.Control
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.SessionState
Imports System.Web.Routing
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.IO.Stream
Imports System.IO.Compression
Imports wsOrionProxy
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports wsOrionProxy.IwsOrionClient



Public Class _Default
    Inherits System.Web.UI.Page

    Private hostName As String
    Private IPV4 As String
    Private AppGen As New AppGeneral.AppGeneral
    Private AppProxy As New wsOrionProxy.IwsOrionClient
    Private HTTPSfromHA As String
    Private urlHTTPs As String
    Private urlPath As String
    Private urlRedirect As String
    Private fromHA As String
    Private bHTTPS As String
    Private sUser As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'ICredentialsByHost.Visible = False

        If Session("App_LoginStatus") = False Then
            Bt_Verificar.Visible = True
            Bt_Logout.Visible = False
            PanelInfo.Visible = False
            PanelLogin.Visible = True

        Else
            If (Session("App_UserVotante") Or Session("App_UserAdministrador")) Then
                If Trim(Session("App_UserName")) <> "" And Trim(Session("App_UserName")) <> "No autenticado" Then
                    Bt_Verificar.Visible = False
                    Bt_Logout.Visible = True
                    PanelInfo.Visible = True
                    PanelLogin.Visible = False
                    'lbl_UltIngreso.Text = Session("App_UserLoginTime")
                    lblUsuario.Text = Session("App_UserName")
                    Session("App_LoginStatus") = True
                Else
                    Session("App_LoginStatus") = False
                    'No autorizado
                    Response.Redirect("~/Inicio")
                End If
            Else
                Session("App_LoginStatus") = False
                'No autorizado
                Response.Redirect("~/Inicio")
            End If

        End If

        hostName = Dns.GetHostName()
        'Eliminar la siguiente línea en producción
        'IPV4 = GetLocalIPV4()
        'Habilitar la siguiente línea en pruebas y producción cuendo esté con netscaler
        IPV4 = Trim(" " & Request.ServerVariables("HTTP_CLIENT_IP"))

    End Sub

    Protected Function IgnoreCertificateErrorHandler(sender As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) As Boolean

        Return True

    End Function

    Protected Sub Bt_Verificar_Click(sender As Object, e As ImageClickEventArgs) Handles Bt_Verificar.Click

        ' ColpatriaProxy debe cambiarse en producción por la nueva librería
        Dim dtUsuario As wsOrionProxy.wsOrion.dtSessionVars
        Dim sUser As String
        Dim sPass As String
        Dim nSesion As Integer

        nSesion = 0
        dtUsuario = New wsOrionProxy.wsOrion.dtSessionVars
        sUser = Trim(Usuario.Text)
        sUser = AppGen.CleanString(sUser)
        sPass = Trim(Password.Text)
        sPass = AppGen.CleanString(sPass)
        dtUsuario.autorizado = False

        AppProxy = New wsOrionProxy.IwsOrionClient
        Try
            'ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf IgnoreCertificateErrorHandler)
            dtUsuario = AppProxy.autenticar(sUser, sPass)
        Catch ex As Exception
        Finally
        End Try

        AppProxy.Close()

        If dtUsuario.autorizado Then

            Bt_Verificar.Enabled = False
            FormsAuthentication.RedirectFromLoginPage(sUser, True)
            Session("App_UserDescriptor") = (dtUsuario.nombre) & " " & (dtUsuario.apellido) & " (" & Trim(dtUsuario.cargo) & ") - " & Trim(dtUsuario.clasedoc)
            Session("App_UserDescriptor") += ": " & Trim(dtUsuario.identificacion) & " - " & Trim(dtUsuario.email)
            Session("App_UserLoginTime") = Now().ToString
            Session("App_LoginStatus") = True
            lbl_Error.Text = "Autenticado"
            CargarVariablesApp(dtUsuario)
            'CargaDatosLogin()

        Else

            InvalidCredentialsMessage.Visible = True
            Bt_Verificar.Enabled = True
            InvalidCredentialsMessage.Text = "Usuario no autorizado en esta aplicación"
            'AppGen.RegistreEvento("User: " & sUser & " - " & Session("App_UserId") & " - No Autenticado Desde: " & IPV4 & " Host: " & hostName & " - Browser: '" & Request.ServerVariables("HTTP_USER_AGENT") & "'", AppGeneral.AppGeneral.TipoEvento.Ev_Login, "Orion")

        End If

        '
        urlHTTPs = LCase(Trim(Request.ServerVariables("HTTP_HOST")))
        urlPath = LCase(Trim(Request.ServerVariables("URL")))
        fromHA = Trim(" " & Request.ServerVariables("HTTP_HA "))
        bHTTPS = Trim(" " & Request.ServerVariables("HTTPS"))

    End Sub

    'Private Function Trim(text As Object) As String
    'Throw New NotImplementedException()
    'End Function

    Sub CargaDatosLogin()

        AppGen.RegistreEvento("User: " & sUser & " - " & Session("App_UserId") & " - Autenticado Desde: " & IPV4 & " Host: " & hostName & " - Browser: '" & Request.ServerVariables("HTTP_USER_AGENT") & "'", "Login", "Orion")

    End Sub

    Protected Sub Bt_Logout_Click1(sender As Object, e As ImageClickEventArgs) Handles Bt_Logout.Click

        'AppGen.RegistreEvento("User: " & Session("App_UserLogin"), "Logout", "Orion")
        Session("App_SessionId") = 0
        Session("App_LoginStatus") = False
        Session("App_UserDescriptor") = "No autenticado"

        Session("App_UserId") = 0
        Session("App_UserLogin") = ""
        Session("App_UserName") = "No conectado"
        Session("App_UserLoginTime") = Now()
        Session("App_UserAdministrador") = False
        Session("App_UserCalidad") = False
        Session("App_UserVotante") = False
        Session("App_UserPerfil") = 0
        Session("App_UserMail") = ""
        Session("App_UserIdentificacion") = ""


        FormsAuthentication.SignOut()
        Session.Clear()
        Session.Abandon()
        Session.RemoveAll()
        lblUsuario.Text = ""
        lbl_UltIngreso.Text = ""
        lbl_Error.Text = ""
        Response.BufferOutput = True
        Response.Redirect("~/Inicio")

    End Sub


    Function GetLocalIPV4() As String
        Dim IPList As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)

        For Each IPaddress In IPList.AddressList

            'Solamente devuelve IPv4 routable IPs
            If (IPaddress.AddressFamily = Sockets.AddressFamily.InterNetwork) AndAlso (IsPrivateIP(IPaddress.ToString)) Then
                Return IPaddress.ToString
            End If
        Next

        Return ""

    End Function

    Function IsPrivateIP(ByVal CheckIP As String) As Boolean

        Dim Quad1, Quad2 As Integer

        Quad1 = CInt(CheckIP.Substring(0, CheckIP.IndexOf(".")))
        Quad2 = CInt(CheckIP.Substring(CheckIP.IndexOf(".") + 1).Substring(0, CheckIP.IndexOf(".")))

        Select Case Quad1
            Case 10
                Return True
            Case 172
                If Quad2 >= 16 And Quad2 <= 31 Then Return True
            Case 192
                If Quad2 = 168 Then Return True
        End Select

        Return False

    End Function

    Sub CargarVariablesApp(dtUsuario As wsOrionProxy.wsOrion.dtSessionVars)

        Dim nGuid As String

        nGuid = String.Empty
        Session("App_UserId") = dtUsuario.id_empleado
        Session("App_UserLogin") = dtUsuario.usuario
        Session("App_UserName") = Trim(dtUsuario.nombre) & " " & Trim(dtUsuario.apellido)
        Session("App_UserMail") = dtUsuario.email
        Session("App_UserIdentificacion") = dtUsuario.identificacion
        Session("App_UserLoginTime") = Now()
        Session("App_UserAdministrador") = dtUsuario.administrador
        Session("App_UserCalidad") = dtUsuario.calidad
        Session("App_UserVotante") = dtUsuario.votante
        Session("App_UserPerfil") = dtUsuario.perfil

        Session("App_SessionId") = 0
        Session("App_UserDescriptor") = "Autenticado"

        'Sesscontrol
        nGuid = Guid.NewGuid().ToString()
        Session("App_Sess") = nGuid
        Response.Redirect("~/Inicio")

    End Sub


End Class
