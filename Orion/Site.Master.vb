Imports System.Web.HttpServerUtility
Imports System.Web.UI.MasterPage
Imports System.Web.UI.WebControls
Imports System.Web.Routing
Imports System.Web.Security
Imports System.Web.ApplicationServices
Imports System.Web.HttpContext
Imports System.Web.HttpRequest
Imports System.Web.HttpRequestBase
Imports System.Collections.Specialized.NameObjectCollectionBase.KeysCollection
Imports System.Web.Services
Imports System.Drawing
Imports System.Drawing.Image


Public Class SiteMaster
    Inherits MasterPage

    Private AppGen As New AppGeneral.AppGeneral
    Private m_AssInfo As System.Reflection.Assembly

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim bFlag As Boolean

        bFlag = False

        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout) * 60 + 5))

        If (Session("App_LoginStatus") = True) Then
            'Usuario autenticado
            If (Session("App_UserAdministrador") Or Session("App_UserCalidad") Or Session("App_UserVotante")) Then
                If Trim(Session("App_UserName")) <> "" And Trim(Session("App_UserName")) <> "No autenticado" Then
                    If Trim(Session("App_UserLogin")) <> "" Then
                        bFlag = True
                    End If
                End If
            End If

            If bFlag = True Then
                'User_Status.ImageUrl = Convert.ToString(GetGlobalResourceObject("Resources", "User_Logged"))
            Else
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
                Response.Redirect("~/Inicio")
            End If

        Else
            Session("App_UserName") = "No autenticado"
            Session("App_UserDescriptor") = "No autenticado"
            Session("App_UserLoginTime") = " "
            'User_Status.ImageUrl = Convert.ToString(GetGlobalResourceObject("Resources", "User_NotLogged"))

        End If

        If bFlag = True Then
            Menu_Habilitar()
        End If

        Lbl_UserInfo.Text = Session("App_UserName")
        Lbl_UserInfo1.Text = "Servidor: " & Request.ServerVariables("SERVER_NAME") & " - Ingreso: " & Date.Today.ToLongDateString & " " & TimeOfDay

        'Dim m_Text As SR.AssemblyTitleAttribute
        'm_AssInfo = System.Reflection.Assembly.GetExecutingAssembly
        'm_Text = m_AssInfo.GetCustomAttributes(GetType(SR.AssemblyTitleAttribute), False)(0)
        'Lbl_AppInfo.Text = m_Text.Title

        'Dim m_Text1 As SR.AssemblyFileVersionAttribute
        'm_AssInfo = System.Reflection.Assembly.GetExecutingAssembly
        'm_Text1 = m_AssInfo.GetCustomAttributes(GetType(SR.AssemblyFileVersionAttribute), True)(0)
        'Lbl_AppInfo.Text += " - Ver. " & m_Text1.Version

    End Sub

    Sub Menu_Habilitar()

        Dim MenuItem As MenuItem
        Dim subMenuItem As MenuItem

        MenuItem = New MenuItem
        subMenuItem = New MenuItem

        'Menu Registro
        If Session("App_UserVotante") Then

            MenuItem = CrearMenuItem("Votar", "", "Votar")
            MenuItem.ChildItems.Add(CrearMenuItem("Votar", "~/Votar", "Votar"))

            MenuItem.ChildItems.Add(CrearMenuItem("Salir", "~/Inicio", "Salir"))
            NavigationMenu.Items.Add(MenuItem)

        End If

        'Menu Registro
        If Session("App_UserAdministrador") Then

            MenuItem = CrearMenuItem("Reportes", "", "Reportes")
            MenuItem.ChildItems.Add(CrearMenuItem("Reportes", "~/Reportes", "Reportes"))
            NavigationMenu.Items.Add(MenuItem)

        End If

        'Agrega menu completo
        'NavigationMenu.Items.Add(MenuItem)

    End Sub

    Private Function CrearMenuItem(Titulo As String, url As String, ToolTip As String) As MenuItem

        Dim Retorno As MenuItem

        Retorno = New MenuItem

        Retorno.Text = Trim(Titulo)
        Retorno.NavigateUrl = Trim(url)
        Retorno.ToolTip = Trim(ToolTip)

        Return Retorno

    End Function

End Class