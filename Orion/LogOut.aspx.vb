Public Class LogOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sManager As New SessionIDManager
        Dim isRedirected As Boolean
        Dim cookieAdded As Boolean
        Dim newId As String

        isRedirected = False
        cookieAdded = False
        sManager.CreateSessionID(Context)

        Session.Timeout = 1
        Session.Clear()
        Session.Abandon()
        Session.RemoveAll()
        newId = sManager.CreateSessionID(Context)
        sManager.SaveSessionID(Context, newId, isRedirected, cookieAdded)

    End Sub

End Class