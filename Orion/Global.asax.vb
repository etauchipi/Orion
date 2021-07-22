Imports System.Web.Optimization
Imports System.Web.SessionState
Imports System.Web.Routing
Imports System.Xml
Imports System.Web.HttpServerUtility
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Se desencadena al iniciar la aplicación
        RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al iniciar la sesión

        Inicalizar()

    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al comienzo de cada solicitud

    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al intentar autenticar el uso
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando se produce un error

        Dim AppGen As New AppGeneral.AppGeneral
        Dim ex As New Exception

        Try
            ex = Server.GetLastError.GetBaseException
            AppGen.RegistreEventoError(ex)

        Catch ex1 As Exception
            'Si el error ocurre en el log
            Server.ClearError()

        End Try

    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la sesión

        Session("App_Sess") = String.Empty
        Session.Clear()
        Session.Abandon()
        Session.RemoveAll()

    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la aplicación

        'Session("App_Sess") = String.Empty
        'Session("App_LoginStatus") = False

    End Sub

    'Sección propia ----------------------------------------------
    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)

        routes.MapPageRoute("Inicio",
            "Inicio/",
            "~/Default.aspx")
        routes.MapPageRoute("Votar",
            "Votar/",
            "~/Pages/Califica.aspx")
        routes.MapPageRoute("Calidad_Votar",
            "Calidad_Votar/",
            "~/Pages/CalificaCal.aspx")
        routes.MapPageRoute("Reportes",
            "Reportes/",
             "~/Pages/Reporte.aspx")

    End Sub

    'Sección pública propia ----------------------------------------------
    Public Sub Inicalizar()

        'Sesion
        Session("App_SessionId") = 0
        Session("App_LoginStatus") = False
        Session("App_UserDescriptor") = "No autenticado"

        'AppUser
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

        'Control
        Session("App_Sess") = "XXX"

        'AppUser Votado
        Session("App_vUserId") = 0
        Session("App_vUserLogin") = ""
        Session("App_vUserName") = ""
        Session("App_vUserCodigo") = False
        Session("App_vUserArea") = False
        Session("App_vUserCco") = False
        Session("App_vUserSexo") = ""
        Session("App_vUserIngreso") = ""
        Session("App_vUserNacimiento") = ""
        Session("App_vUserIdentificacion") = ""

        'Control
        Session("App_Sess") = "XXX"

    End Sub

End Class