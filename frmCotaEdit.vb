Imports VectorDraw.Professional.vdFigures

Public Class frmCotaEdit

    Dim laCota As vdDimension = New vdDimension

    Private Sub frmCotaEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '--------------------------------------------------------------------------------------
        ' leer los valores que trae la entidad, en este caso un texto, y mostrarlos en pantalla
        '--------------------------------------------------------------------------------------
        Dim lugaresDecimales As Integer
        Me.Text = "Edición de Cota"
        laCota = entidad
        lugaresDecimales = laCota.DecimalPrecision
        'ojo, formatNumber(nro,decimales) no trunca, redondea al mas proximo
        If cajaTexto.Enabled Then
            cajaTexto.Text = laCota.dimText
        Else
            cajaTexto.Text = FormatNumber(laCota.Measurement, lugaresDecimales)
        End If

        cajaAlturaTexto.Text = laCota.TextHeight.ToString

        If InStr(laCota.dimText, "L") <> 0 Then
            rbtSubrayado.Checked = True
            If cajaTexto.Enabled Then
                cajaTexto.Text = Replace(cajaTexto.Text, "\L", "")
            End If
        ElseIf InStr(laCota.dimText, "O") <> 0 Then
            rbtSobrerayado.Checked = True
            If cajaTexto.Enabled Then
                cajaTexto.Text = Replace(cajaTexto.Text, "\O", "")
            End If
        Else
            rbtNinguno.Checked = True
        End If
        ToolTip1.SetToolTip(btnCambiarCota, "Habilitar/Deshabilitar cambio del texto del valor medido." _
                            & vbCrLf & "Habilitar: Al poner un valor manual se pierden el prefijo y el sufijo." _
                            & vbCrLf & "Estos valores se deberán escribir dentro del área donde también se escribe " _
                            & vbCrLf & "el nuevo texto de la cota." _
                            & vbCrLf & "-----------------------------------------------------------------" _
                            & vbCrLf & "Deshabilitar: Al deshabilitar el texto puesto a mano, se restituye el " _
                            & vbCrLf & "valor original leido por el sistema y se pueden escribir los prefijos y sufijos" _
                            & vbCrLf & "en sus respectivas áreas")
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        cargarCambios()
        LimpiarSeleccion(obtenerSeleccion)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        Close()
    End Sub

    Private Sub btnRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRechazar.Click
        LimpiarSeleccion(obtenerSeleccion)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        Close()
    End Sub

    Private Sub cargarCambios()

        If cajaTexto.Enabled Then
            laCota.PostString = ""
            Dim contenidoNuevo As String
            contenidoNuevo = cajaTexto.Text
            If contenidoNuevo <> "" Then
                laCota.dimText = contenidoNuevo
            End If
        Else
            'prefijo y sufijo
            'laCota.dimText = cajaPrefijo.Text & " " & laCota.dimText & " " & cajaSufijo.Text
            laCota.PostString = cajaPrefijo.Text & " <> " & cajaSufijo.Text
            'laCota.PostString = cajaPrefijo.Text & laCota.dimText & cajaSufijo.Text
        End If


        'altura texto
        If IsNumeric(cajaAlturaTexto.Text) Then
            laCota.TextHeight = CDbl(cajaAlturaTexto.Text)
        End If

        'palito arriba y abajo.
        If cajaTexto.Enabled Then
            If rbtSubrayado.Checked Then
                laCota.dimText = "\L" & laCota.dimText
            ElseIf rbtSobrerayado.Checked Then
                laCota.dimText = "\O" & laCota.dimText
            Else
                laCota.dimText = laCota.dimText
            End If
        Else
            If rbtSubrayado.Checked Then
                laCota.dimText = "\L<>"
            ElseIf rbtSobrerayado.Checked Then
                laCota.dimText = "\O<>"
            Else
                laCota.dimText = "<>"
            End If
        End If


        laCota.Update()

    End Sub

    Private Sub btnCambiarCota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiarCota.Click
        If cajaTexto.Enabled = False Then
            cajaTexto.Enabled = True
            cajaPrefijo.Enabled = False
            cajaSufijo.Enabled = False
        Else
            cajaTexto.Enabled = False
            cajaPrefijo.Enabled = True
            cajaSufijo.Enabled = True
        End If
    End Sub
End Class