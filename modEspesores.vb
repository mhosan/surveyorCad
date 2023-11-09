Module modEspesores

    Public Sub actualizarCmbEspesores()
        Static pasadas As Integer
        pasadas = pasadas + 1
        If pasadas > 1 Then
            frmPpal.ToolStrLayersCmbEspesor.Items.Clear()
            frmPpal.ToolStrLayersCmbEspesor.Text = ""
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLineWeight = esp.finalSelected
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_50

        'otra forma de recorrer el enum: [Enum].GetNames(GetType(VectorDraw.Professional.Constants.VdConstLineWeight))

        For Each i As VectorDraw.Professional.Constants.VdConstLineWeight In [Enum].GetValues(GetType(VectorDraw.Professional.Constants.VdConstLineWeight))
            frmPpal.ToolStrLayersCmbEspesor.Items.Add(i.ToString)
        Next

        For j As Integer = 0 To frmPpal.ToolStrLayersCmbEspesor.Items.Count - 1
            If frmPpal.ToolStrLayersCmbEspesor.Items.Item(j).ToString = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLineWeight().ToString Then
                frmPpal.ToolStrLayersCmbEspesor.Text = frmPpal.ToolStrLayersCmbEspesor.Items.Item(j)
                Exit For
            End If
        Next

    End Sub

    Public Sub espesores()
        '---------------------------------------------
        ' mostrar cuadro de dialogo espesores
        '---------------------------------------------
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        Dim esp As VectorDraw.Professional.Dialogs.GetLineWeightDialog = VectorDraw.Professional.Dialogs.GetLineWeightDialog.Show(frmPpal.VdF.BaseControl.ActiveDocument, frmPpal.VdF.BaseControl.ActiveControl, VectorDraw.Professional.Constants.VdConstLineWeight.LW_BYLAYER, True)
        If (esp.DialogResult = Windows.Forms.DialogResult.OK) Then
            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLineWeight = esp.finalSelected
            For j As Integer = 0 To frmPpal.ToolStrLayersCmbEspesor.Items.Count - 1
                If frmPpal.ToolStrLayersCmbEspesor.Items.Item(j).ToString = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLineWeight().ToString Then
                    frmPpal.ToolStrLayersCmbEspesor.Text = frmPpal.ToolStrLayersCmbEspesor.Items.Item(j)
                    Exit For
                End If
            Next
        End If
        actualizarGrillaPropiedades()
        ultimoComando = "espesores"

    End Sub

End Module
