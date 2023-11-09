Module modColores

    Public Sub actualizarLblColores()
        Dim colorActivo As VectorDraw.Professional.vdObjects.vdColor = New VectorDraw.Professional.vdObjects.vdColor()
        colorActivo = frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor
        frmPpal.ToolStrLayersBtnColor.BackColor = colorActivo.SystemColor
        Select Case colorActivo.ToString
            Case "ByBlock"
                frmPpal.ToolStrLayersLblColor.Text = " Por Bloque "
            Case "ForGround"
                frmPpal.ToolStrLayersLblColor.Text = " Blanco "
            Case "ByLayer"
                frmPpal.ToolStrLayersLblColor.Text = " Por Layer "
            Case "0"
                frmPpal.ToolStrLayersLblColor.Text = " Rojo "
            Case "1"
                frmPpal.ToolStrLayersLblColor.Text = " Amarillo "
            Case "2"
                frmPpal.ToolStrLayersLblColor.Text = " Verde "
            Case "3"
                frmPpal.ToolStrLayersLblColor.Text = " Cyan  "
            Case "4"
                frmPpal.ToolStrLayersLblColor.Text = " Azul  "
            Case "5"
                frmPpal.ToolStrLayersLblColor.Text = " Magenta "
            Case "6"
                frmPpal.ToolStrLayersLblColor.Text = " Blanco "
            Case Else
                frmPpal.ToolStrLayersLblColor.Text = "  " & colorActivo.ToString & "  "

        End Select

    End Sub

    Public Sub colores()
        '------------------------------------------
        ' mostrar cuadro de dialogo colores
        '------------------------------------------
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        Dim mColor As VectorDraw.Professional.vdObjects.vdColor = New VectorDraw.Professional.vdObjects.vdColor()
        mColor.Palette = frmPpal.VdF.BaseControl.ActiveDocument.Palette

        Dim dialog As VectorDraw.Professional.Dialogs.frmColor = New VectorDraw.Professional.Dialogs.frmColor((mColor), False)
        dialog.ShowDialog()

        If (dialog.DialogResult = DialogResult.OK) Then
            frmPpal.VdF.BaseControl.ActiveDocument.ActivePenColor = mColor
        End If
        actualizarLblColores()
        actualizarGrillaPropiedades()
        ultimoComando = "dialogoColores"


    End Sub

End Module
