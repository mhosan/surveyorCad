

Module modLayers
    Public WithEvents comboLayers As vdLayersComboBox.vdLayersCombo

    Public Sub agregarComboLayers()

        For Each elemento As ToolStripItem In frmPpal.ToolStrLayers.Items
            If elemento.Name = "comboCapas" Then
                Exit Sub
            End If
        Next

        Dim item1 As ToolStripControlHost
        'Dim strip As ToolStrip

        comboLayers = New vdLayersComboBox.vdLayersCombo
        comboLayers.ApplicationsMainForm = frmPpal
        comboLayers.LayersDocument = frmPpal.VdF.BaseControl.ActiveDocument
        comboLayers.Location = New Point(0, 0)
        comboLayers.Name = "comboLayers"
        comboLayers.MinimumSize = New Size(350, 21) '120 es el minimo
        comboLayers.MaxNumberOfLayersShown = 20

        'strip = New ToolStrip
        item1 = New ToolStripControlHost(comboLayers)
        item1.Name = "comboCapas"
        'frmPpal.ToolTip1.SetToolTip(frmPpal.ToolStrLayers, "control combo nuevo")
        'strip.Items.Add(item1)
        'frmPpal.Controls.Add(strip)

        frmPpal.ToolStrLayers.Items.Insert(1, item1)
        'para el control que se arrastra desde la barra de herramientas de visual b.
        'combolayers.LayersDocument = frmPpal.VdF.BaseControl.ActiveDocument
        'vdLayersCombo1.ApplicationsMainForm = this;
        'vdFramedControl1.BaseControl.AfterOpenDocument += new VectorDraw.Professional.Control.AfterOpenDocumentEventHandler(BaseControl_AfterOpenDocument);
        actualizarCmbLayers()

    End Sub

    Public Sub actualizarCmbLayers()
        Dim elLayer As VectorDraw.Professional.vdPrimaries.vdLayer
        elLayer = New VectorDraw.Professional.vdPrimaries.vdLayer()

        elLayer = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayer()
        comboLayers.LayersDocument.ActiveLayer = frmPpal.VdF.BaseControl.ActiveDocument.Layers.FindName("0")
        comboLayers.Refresh()
        'comboLayers.LayersDocument.ActiveLayer = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayer
        comboLayers.LayersDocument.ActiveLayer = elLayer
        comboLayers.Refresh()
        'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        elLayer = Nothing

    End Sub

    Public Sub layers()
        '-------------------------------------------
        ' mostrar cuadro de dialogo de layers.
        '-------------------------------------------
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        VectorDraw.Professional.Dialogs.LayersDialog.Show(frmPpal.doc)
        'actualizarCmbLayers()
        actualizarGrillaPropiedades()
        comboLayers.Refresh()
        ultimoComando = "layers"

    End Sub

    Public Sub agregarLayers()
        '--------------------------------------------------------------
        '
        ' agregar los layers de la plantilla de catastro
        '
        '--------------------------------------------------------------
        Dim elLayer As VectorDraw.Professional.vdPrimaries.vdLayer
        elLayer = New VectorDraw.Professional.vdPrimaries.vdLayer()

        frmPpal.VdF.BaseControl.ActiveDocument.Layers.Add("Notas Mensura")
        frmPpal.VdF.BaseControl.ActiveDocument.Layers.Add("Mensura")
        frmPpal.VdF.BaseControl.ActiveDocument.Layers.Add("Accesiones_0")
        frmPpal.VdF.BaseControl.ActiveDocument.Layers.Add("Notas_Accesiones_0")
        frmPpal.VdF.BaseControl.ActiveDocument.Layers.Add("Inst_Comp_0")

        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayer() = frmPpal.VdF.BaseControl.ActiveDocument.Layers.FindName("Mensura")

        Try
            'borrar los layers que sobran de la plantilla:
            elLayer = (frmPpal.VdF.BaseControl.ActiveDocument.Layers.FindName("cotas_0"))
            If Not elLayer Is Nothing Then
                If Not elLayer.Lock Then
                    elLayer.Deleted = True
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                End If
            End If

            elLayer = (frmPpal.VdF.BaseControl.ActiveDocument.Layers.FindName("Macizo_0"))
            If Not elLayer Is Nothing Then
                If Not elLayer.Lock Then
                    elLayer.Deleted = True
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                End If
            End If

            elLayer = (frmPpal.VdF.BaseControl.ActiveDocument.Layers.FindName("MacizosLinderos"))
            If Not elLayer Is Nothing Then
                If Not elLayer.Lock Then
                    elLayer.Deleted = True
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                End If
            End If

            elLayer = (frmPpal.VdF.BaseControl.ActiveDocument.Layers.FindName("Parcelas_"))
            If Not elLayer Is Nothing Then
                If Not elLayer.Lock Then
                    elLayer.Deleted = True
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub


    Public Sub Trabar_Layers()
        ''================================================
        ''cerrar los layers de la plantilla
        ''================================================
        'Dim Buscar As vdLayer

        'On Error Resume Next
        'Buscar = frmMain.VD.ActiveDocument.Layers.FindName("Cotas")
        'If Err.Number = 0 Then
        '    If Buscar.LayerName = "Cotas" Then
        '        Buscar.Lock = True
        '    End If
        'Else
        '    Err.Clear()
        '    Exit Sub
        'End If

        'Buscar = frmMain.VD.ActiveDocument.Layers.FindName("Macizo")
        'If Buscar.LayerName = "Macizo" Then
        '    Buscar.Lock = True
        'End If

        'Buscar = frmMain.VD.ActiveDocument.Layers.FindName("MacizosLinderos")
        'If Buscar.LayerName = "MacizosLinderos" Then
        '    Buscar.Lock = True
        'End If

        'Buscar = frmMain.VD.ActiveDocument.Layers.FindName("Parcelas")
        'If Buscar.LayerName = "Parcelas" Then
        '    Buscar.Lock = True
        'End If

        'frmMain.VD.Refresh()

    End Sub

    Private Sub comboLayers_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboLayers.Leave
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    End Sub
End Module
