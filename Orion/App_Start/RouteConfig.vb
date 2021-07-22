Imports System.Web.Routing
Imports Microsoft.AspNet.FriendlyUrls

Public Module RouteConfig
    Sub RegisterRoutes(ByVal routes As RouteCollection)
        Dim settings As FriendlyUrlSettings = New FriendlyUrlSettings()
        settings.AutoRedirectMode = RedirectMode.Permanent
        routes.EnableFriendlyUrls(settings)

        routes.MapPageRoute("Home", "Home", "~/Default.aspx")
        routes.MapPageRoute("HomeUser", "Home/{User}", "~/Default.aspx")
        routes.MapPageRoute("Votaciones", "Votaciones/General", "~/Pages/Califica.aspx")
        routes.MapPageRoute("VotacionesCal", "Votaciones/Calidad", "~/Pages/CalificaCal.aspx")
        routes.MapPageRoute("Reportes", "Info/Reportes", "~/Pages/Reporte.aspx")

    End Sub
End Module

