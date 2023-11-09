Imports System.IO
Imports System.Data.OleDb
Imports System.Data
Imports Microsoft.Reporting.WinForms
Public Class frmCedula

    Private Sub CustomizeRV(ByVal ctrl As Control)
        For Each c As Control In ctrl.Controls
            If TypeOf c Is ToolStrip Then
                Dim ts As ToolStrip = DirectCast(c, ToolStrip)
                For i As Integer = 0 To ts.Items.Count - 1
                    If ts.Items(i).Name = "export" Then
                        Dim exp As ToolStripDropDownButton = ts.Items(i)
                        AddHandler exp.DropDownOpening, AddressOf disableButton
                    End If
                Next
            End If
            If c.HasChildren Then
                CustomizeRV(c)
            End If
        Next
    End Sub

    Private Sub disableButton(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btn As ToolStripDropDownButton = DirectCast(sender, ToolStripDropDownButton)
        btn.DropDownItems(0).Visible = False
        btn.DropDownItems(2).Visible = False
    End Sub

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reportViewer.Load
        Dim cedulaCatastral = GetCedulaCatastral()
        CedulaCastralBindingSource.DataSource = cedulaCatastral
        NomenclaturaCatastralBindingSource.DataSource = cedulaCatastral.NomenclaturaCatastral
        DireccionBindingSource.DataSource = cedulaCatastral.Ubicacion
        'En esta linea es donde se hace lento
        '=================================================
        reportViewer.SetDisplayMode(DisplayMode.PrintLayout)
        '==================================================
        reportViewer.ZoomMode = ZoomMode.PageWidth
        '    reportViewer.RefreshReport()
    End Sub

    Private Function GetCedulaCatastral() As BO.CedulaCastral

        Dim cc = New BO.CedulaCastral()

        '======== 1 ====================================================
        cc.Partido = "(" & frmInicial.T_num_p.Text & ")" & " " & frmInicial.Combo_partido.Text
        cc.Partida = frmInicial.t_partida.Text
        '===============================================================
        '========= 2 ===================================================
        cargonomenclatura()
        cc.NomenclaturaCatastral.Circunscripcion = nomenclatura.Circunscripcion
        cc.NomenclaturaCatastral.Seccion = nomenclatura.Seccion
        cc.NomenclaturaCatastral.Chacra = nomenclatura.Chacra & " " & nomenclatura.ChacraLetra
        cc.NomenclaturaCatastral.Quinta = nomenclatura.Quinta & " " & nomenclatura.QuintaLetra
        cc.NomenclaturaCatastral.Fraccion = nomenclatura.Fraccion & " " & nomenclatura.FraccionLetra
        cc.NomenclaturaCatastral.Manzana = nomenclatura.Manzana & " " & nomenclatura.ManzanaLetra
        cc.NomenclaturaCatastral.Parcela = nomenclatura.Parcela & " " & nomenclatura.ParcelaLetra

        '===============================================================
        '========= 3 ===================================================
        cc.Ubicacion.Calle = frmInicial.T_calle_i.Text
        cc.Ubicacion.Nro = 10
        cc.Ubicacion.EntreCalle1 = 116
        cc.Ubicacion.EntreCalle2 = 117
        cc.Ubicacion.Localidad = "La Plata"
        cc.Ubicacion.CodigoPostal = 123
        '===============================================================
        '====== 4 ======================================================
        cc.Designacion = "Muchas mass designacionasdkjñsdlfkasñdfasld"
        cc.Medidas = "Muchassadalsñdkfjlañksdjasñdfklasdfasd"
        '===============================================================
        '====== 8 ======================================================
        cc.PaChacra = nomenclatura.Chacra & " " & nomenclatura.ChacraLetra
        cc.PaSeccion = nomenclatura.Seccion
        cc.PaQuinta = nomenclatura.Quinta & " " & nomenclatura.QuintaLetra
        cc.PaParcela = nomenclatura.Parcela & " " & nomenclatura.ParcelaLetra
        cc.PaPartido = frmInicial.T_num_p.Text
        cc.PaManzana = nomenclatura.Manzana & " " & nomenclatura.ManzanaLetra
        cc.PaCircunscripcion = nomenclatura.Circunscripcion
        cc.PaFraccion = nomenclatura.Fraccion & " " & nomenclatura.FraccionLetra
        '===============================================================
        '======= 10 ====================================================
        cc.AguaCorriente = "X"
        cc.Alumbrado = "X"
        cc.Cloacas = "X"
        cc.Electrica = "X"
        cc.Gas = "X"



        'ubicar imagen aqui...
        cc.Croquis = "C:\imagen.jpg"
        Return (cc)
    End Function

    Private Sub frmCedula_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim extension As New Microsoft.Reporting.WinForms.ReportViewer

        End If
    End Sub

    Private Sub frmCedula_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmCedula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CustomizeRV(reportViewer)
        reportViewer.LocalReport.EnableExternalImages = True
        ' reportViewer.RefreshReport()
       
        'reportViewer.SetDisplayMode(DisplayMode.PrintLayout)
        'reportViewer.ZoomMode = ZoomMode.PageWidth
        
        '===========================
        'Creo una colección de parámetros de tipo ReportParameter
        'para añadirlos al control ReportViewer.
        '======================================================================
        ' conectar1()
        '_titular.Clear()

        'Dim id_ti As String = frmInicial.id_titu.Text
        'Dim adaptador = New OleDb.OleDbDataAdapter("SELECT * FROM persona where id_persona LIKE '" & id_ti & "' ", conexionMdb1)
        'Dim constructor = New OleDb.OleDbCommandBuilder(adaptador) 'Se interpreta la consulta
        'adaptador.Fill(_titular)
        'Dim row As DataRow = _titular.Rows(_titular.Rows.Count - 1)

        '=================================
        'Dim tt As Integer = 0
        'For Each item As Object In row.ItemArray

        '    If IsDBNull(row(tt)) Or row(tt).ToString.Length = 0 Then
        '        row(tt) = "---"
        '    End If
        '    tt = tt + 1

        'Next
        '==================================================
        '==================================================

        'Datos del Titular=================================
        If frmInicial.id_titu.Text = "0" Then
            Dim parametros As New List(Of ReportParameter)
            parametros.Add(New ReportParameter("apellido_titular", "--"))
            parametros.Add(New ReportParameter("doc_titular", "--"))
            parametros.Add(New ReportParameter("calle_titu", "--"))
            parametros.Add(New ReportParameter("numero_titu", "--"))
            parametros.Add(New ReportParameter("piso_titu", "--"))
            parametros.Add(New ReportParameter("dpto_titu", "--"))
            parametros.Add(New ReportParameter("localidad_titu", "--"))
            parametros.Add(New ReportParameter("prov_titu", "--"))
            parametros.Add(New ReportParameter("cp_titu", "--"))
            ' Añado el/los parámetro/s al ReportViewer.
            reportViewer.LocalReport.SetParameters(parametros)
            reportViewer.RefreshReport()


        Else
            Dim parametros As New List(Of ReportParameter)
            parametros.Add(New ReportParameter("apellido_titular", frmInicial.row(2).ToString & "," & " " & frmInicial.row(1).ToString))
            parametros.Add(New ReportParameter("doc_titular", frmInicial.row(5).ToString))
            parametros.Add(New ReportParameter("calle_titu", frmInicial.row(8).ToString))
            parametros.Add(New ReportParameter("numero_titu", frmInicial.row(9).ToString))
            parametros.Add(New ReportParameter("piso_titu", frmInicial.row(10).ToString))
            parametros.Add(New ReportParameter("dpto_titu", frmInicial.row(11).ToString))
            parametros.Add(New ReportParameter("localidad_titu", frmInicial.row(7).ToString))
            parametros.Add(New ReportParameter("prov_titu", frmInicial.row(12).ToString))
            parametros.Add(New ReportParameter("cp_titu", frmInicial.row(13).ToString))
            ' Añado el/los parámetro/s al ReportViewer.
            reportViewer.LocalReport.SetParameters(parametros)
            reportViewer.RefreshReport()
            '  conexionMdb1.Close()
        End If
    End Sub


End Class
