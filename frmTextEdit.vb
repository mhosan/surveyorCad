Imports VectorDraw.Professional.vdFigures

Public Class frmTextEdit
    Dim elTexto As vdText = New vdText
    Dim elMtexto As vdMText = New vdMText

    Private Sub frmTextEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '--------------------------------------------------------------------------------------
        ' leer los valores que trae la entidad, en este caso un texto, y mostrarlos en pantalla
        '--------------------------------------------------------------------------------------
        If entidad._TypeName.ToString = "vdMText" Then
            Me.Text = "Edicion de Mtext"
            elMtexto = entidad
            elTexto = Nothing
            cajaTexto.Visible = False
            rtbMtext.Visible = True
            nudAngulo.Value = VectorDraw.Geometry.Globals.RadiansToDegrees(elMtexto.Rotation)
            cajaAltura.Text = elMtexto.Height
            rtbMtext.Clear()
            rtbMtext.AppendText(elMtexto.TextString)
            btnOkMtext.Visible = True
        Else
            Me.Text = "Edicion de Texto"
            elMtexto = Nothing
            elTexto = entidad
            cajaTexto.Visible = True
            rtbMtext.Visible = False
            cajaTexto.Text = elTexto.TextString
            Dim anguloConvertido As Double = Math.Round(VectorDraw.Geometry.Globals.RadiansToDegrees(elTexto.Rotation), 2)
            If anguloConvertido > 360 Then
                anguloConvertido = anguloConvertido - 360
            End If
            nudAngulo.Value = anguloConvertido 'Math.Round(VectorDraw.Geometry.Globals.RadiansToDegrees(elTexto.Rotation), 2)
            cajaAltura.Text = elTexto.Height
            btnOkMtext.Visible = False
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        cargarCambios()
        LimpiarSeleccion(obtenerSeleccion)
        Close()
    End Sub

    Private Sub btnRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRechazar.Click
        LimpiarSeleccion(obtenerSeleccion)
        Close()
    End Sub

    Private Sub btnOkMtext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOkMtext.Click
        elMtexto.TextString = rtbMtext.Text
        elMtexto.Update()
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
    End Sub

    Private Sub cargarCambios()
        Dim contenidoNuevo As String, justificacion As Integer

        If elTexto Is Nothing Then
            elMtexto.Rotation = VectorDraw.Geometry.Globals.DegreesToRadians(nudAngulo.Value)  'en radianes
            If IsNumeric(cajaAltura.Text) Then
                elMtexto.Height = cajaAltura.Text
            End If
        Else
            justificacion = elTexto.HorJustify
            elTexto.Rotation = VectorDraw.Geometry.Globals.DegreesToRadians(nudAngulo.Value)  'en radianes
            If IsNumeric(cajaAltura.Text) Then
                elTexto.Height = cajaAltura.Text
            End If
            contenidoNuevo = cajaTexto.Text   'InputBox("Ingrese texto..", "Mhcad", elTexto.TextString)
            If contenidoNuevo <> "" Then
                elTexto.TextString = contenidoNuevo
                elTexto.HorJustify = justificacion
            End If
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
    End Sub
End Class