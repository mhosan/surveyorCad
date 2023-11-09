Public Class frmEncenderApagarLayers

    Dim Marco As VectorDraw.Professional.vdFigures.vdViewport = New VectorDraw.Professional.vdFigures.vdViewport
    Dim solapaActiva As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout

    Private Sub frmEncenderApagarLayers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Text = aplicacionNombre & " - Encender / Apagar capas"

        solapaActiva = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut
        Marco = solapaActiva.ActiveViewPort
        If Marco Is Nothing Then
            MsgBox("No hay ningun viewport activo.", MsgBoxStyle.Exclamation, aplicacionNombre)
            Me.Close()
        End If

        ConfiguraLvLayers()
        cargarDatos()

    End Sub

    Public Sub cargarDatos()
        '==========================================================
        ' Si llegue hasta aqui es porque ya se verifico que existen
        ' layouts.
        '==========================================================
        Dim lvItem As ListViewItem
        Static pasadas As Integer
        pasadas = pasadas + 1
        LvLayers.Items.Clear()

        For Each i As VectorDraw.Professional.vdPrimaries.vdLayer In frmPpal.VdF.BaseControl.ActiveDocument.Layers
            If Not i.Deleted Then
                For k As Integer = 0 To LvLayers.Columns.Count - 1
                    If k = 0 Then
                        lvItem = LvLayers.Items.Add("")
                        lvItem.Tag = i.Name
                        If Marco.FrozenLayerList.Contains(i.Name, True) Then
                            lvItem.Checked = False
                        Else
                            lvItem.Checked = True
                        End If
                    Else
                        lvItem.SubItems.Add(i.Name)
                    End If
                Next
            End If
        Next

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        'vaciar la lista de layers apagados
        Marco.FrozenLayerList.RemoveAll()

        For Each i As ListViewItem In LvLayers.Items
            If Not i.Checked Then
                'apagar
                Marco.FrozenLayerList.AddItem(i.Tag.ToString)

            End If
        Next
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        Me.Close()
    End Sub

    Private Sub ConfiguraLvLayers()
        '///////////////////////////////////////////////
        ' Configurar la grilla
        '///////////////////////////////////////////////
        With LvLayers
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .LabelEdit = False
            .HideSelection = False
            .Columns.Clear()
        End With
        LvLayers.Columns.Add("Visible", 80, HorizontalAlignment.Center)
        LvLayers.Columns.Add("Layer", 160, HorizontalAlignment.Left)

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        salir()
    End Sub

    Private Sub salir()
        'txtValorAtt.Clear()
        Me.Close()
    End Sub

End Class