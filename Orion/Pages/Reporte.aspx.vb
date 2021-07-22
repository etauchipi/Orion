Public Class Reporte
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        nperiodo = CInt(ConfigurationManager.AppSettings("app_global_periodo"))
        Cargar_lista()

    End Sub

    Private Sub Cargar_lista()

        Dim ds As DataSet
        Dim sds As String

        ds = New DataSet
        sds = String.Empty
        appProxy = New wsOrionProxy.IwsOrionClient
        Compresion = New Compresion.Compresion

        Try
            sds = appProxy.get_data_votos(nperiodo)
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

            gv_dataG1.DataSource = Nothing
            'ds.Tables(0).DefaultView.Sort = " apellido DESC"
            gv_dataG1.DataSource = ds.Tables(0)
            gv_dataG1.DataBind()

            gv_dataG2.DataSource = Nothing
            'ds.Tables(0).DefaultView.Sort = " apellido DESC"
            gv_dataG2.DataSource = ds.Tables(0)
            gv_dataG2.DataBind()

            gv_dataG3.DataSource = Nothing
            'ds.Tables(0).DefaultView.Sort = " apellido DESC"
            gv_dataG3.DataSource = ds.Tables(0)
            gv_dataG3.DataBind()

            gv_dataG4.DataSource = Nothing
            'ds.Tables(0).DefaultView.Sort = " apellido DESC"
            gv_dataG4.DataSource = ds.Tables(0)
            gv_dataG4.DataBind()

        End If

    End Sub

End Class