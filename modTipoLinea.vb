Module modTipoLinea
    Public nuevoTipo As VectorDraw.Professional.vdPrimaries.vdLineType

    Public Sub actualizarCmbTipoLinea()
        Static pasadas As Integer
        pasadas = pasadas + 1
        If pasadas > 1 Then
            frmPpal.ToolStrLayersCmbTipoLinea.Items.Clear()
            frmPpal.ToolStrLayersCmbTipoLinea.Text = ""
        Else
            nuevosTiposLineas()
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()

        For Each i As VectorDraw.Professional.vdPrimaries.vdLineType In frmPpal.VdF.BaseControl.ActiveDocument.LineTypes
            If Not i.Deleted Then
                frmPpal.ToolStrLayersCmbTipoLinea.Items.Add(i.Name)
            End If
        Next

        For j As Integer = 0 To frmPpal.ToolStrLayersCmbTipoLinea.Items.Count - 1
            If frmPpal.ToolStrLayersCmbTipoLinea.Items.Item(j).ToString = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLineType().ToString Then
                frmPpal.ToolStrLayersCmbTipoLinea.Text = frmPpal.ToolStrLayersCmbTipoLinea.Items.Item(j)
                Exit For
            End If
        Next
        'frmPpal.ToolStrLayersCmbTipoLinea.Text = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLineType().ToString

        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName(frmPpal.ToolStrLayersCmbTipoLinea.Text)

    End Sub

    Public Sub tipoLinea()
        '----------------------------------------------
        ' mostrar cuadro de dialogo de tipos  de linea
        '----------------------------------------------
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        Dim frm As VectorDraw.Professional.Dialogs.GetLineTypeDialog = VectorDraw.Professional.Dialogs.GetLineTypeDialog.Show(frmPpal.VdF.BaseControl.ActiveDocument, frmPpal.VdF.BaseControl.ActiveControl, "Solid", True)

        If (frm.DialogResult = Windows.Forms.DialogResult.OK) Then
            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName(frm.finalSelected)
            For j As Integer = 0 To frmPpal.ToolStrLayersCmbTipoLinea.Items.Count - 1
                If frmPpal.ToolStrLayersCmbTipoLinea.Items.Item(j).ToString = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLineType().ToString Then
                    frmPpal.ToolStrLayersCmbTipoLinea.Text = frmPpal.ToolStrLayersCmbTipoLinea.Items.Item(j)
                    Exit For
                End If
            Next
            actualizarGrillaPropiedades()

        Else
            MessageBox.Show("Accion cancelada")
        End If

        ultimoComando = "cuadroDialogotipoLinea"
    End Sub
    Public Sub cmbTipoLineaClick()

        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLineType() = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName(frmPpal.ToolStrLayersCmbTipoLinea.Text)
        'ultimoComando = "comboTipoLinea"
    End Sub
    Private Sub nuevosTiposLineas()
        Dim seg As VectorDraw.Render.LineTypeSegment = New VectorDraw.Render.LineTypeSegment

        nuevoTipo = New VectorDraw.Professional.vdPrimaries.vdLineType
        nuevoTipo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        nuevoTipo.setDocumentDefaults()
        nuevoTipo.Name = "Alambrado"
        nuevoTipo.Comment = "Alambrado - X - X - X - X "
        nuevoTipo.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(1.0)) 'dash..
        nuevoTipo.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(-0.01)) 'blanco..
        seg.Flag = VectorDraw.Render.LineTypeSegment.LineTypeElementType.TTF_TEXT
        seg.ShapeScale = 0.3
        seg.ShapeStyle = frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.Standard.GrTextStyle
        seg.ShapeText = "X"
        nuevoTipo.Segments.AddItem(seg) 'X..
        nuevoTipo.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(-0.01)) 'blanco..
        nuevoTipo.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(1.0)) 'dash..
        nuevoTipo.Segments.UpdateLength()
        frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.AddItem(nuevoTipo)
        nuevoTipo = Nothing
        seg = Nothing

        nuevoTipo = New VectorDraw.Professional.vdPrimaries.vdLineType
        nuevoTipo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        nuevoTipo.setDocumentDefaults()
        nuevoTipo.Name = "AlambradoX2"
        nuevoTipo.Comment = "Alambrado - X - X - X - X "
        nuevoTipo.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(1.0)) 'dash..
        nuevoTipo.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(-1.0)) 'blanco..
        seg = New VectorDraw.Render.LineTypeSegment
        seg.Flag = VectorDraw.Render.LineTypeSegment.LineTypeElementType.TTF_TEXT
        seg.ShapeScale = 0.3
        seg.ShapeStyle = frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.Standard.GrTextStyle
        seg.ShapeText = "X"
        nuevoTipo.Segments.AddItem(seg) 'X..
        nuevoTipo.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(-1.0)) 'blanco..
        nuevoTipo.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(1.0)) 'dash..
        nuevoTipo.Segments.UpdateLength()
        frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.AddItem(nuevoTipo)
        nuevoTipo = Nothing
        seg = Nothing

        nuevoTipo = New VectorDraw.Professional.vdPrimaries.vdLineType
        nuevoTipo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        nuevoTipo.setDocumentDefaults()
        nuevoTipo.Name = "Alambrado1"
        nuevoTipo.Comment = "Alambrado - X - X - X - X "
        nuevoTipo.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(0.25)) 'dash..
        nuevoTipo.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(-0.25)) 'blanco..
        seg = New VectorDraw.Render.LineTypeSegment
        seg.Flag = VectorDraw.Render.LineTypeSegment.LineTypeElementType.TTF_TEXT
        seg.ShapeScale = 0.3
        seg.ShapeStyle = frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.Standard.GrTextStyle
        seg.ShapeText = "X"
        nuevoTipo.Segments.AddItem(seg) 'X..
        nuevoTipo.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(-0.5)) 'blanco..
        nuevoTipo.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(0.25)) 'dash..
        nuevoTipo.Segments.UpdateLength()
        frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.AddItem(nuevoTipo)
        nuevoTipo = Nothing
        seg = Nothing

    End Sub
End Module
