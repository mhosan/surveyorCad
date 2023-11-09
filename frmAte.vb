Imports VectorDraw.Professional.vdFigures
Imports System.IO

Public Class frmAte

    Dim ocultarCuadroColores As Boolean

    Dim bloqueLeido As VectorDraw.Professional.vdFigures.vdInsert
    Dim definicionDeAtributoNro() As String

    Public Sub cargarDatos(ByVal bloque As VectorDraw.Professional.vdFigures.vdInsert)
        '////////////////////////////////////////////////////////////////////////////////////////
        ' Este proc se llama desde frmPpal, en el evento doble click.
        ' Recibe un bloque como parametro.
        ' Configura la grilla para cargar los datos y luego la vacia.
        ' Finalmente recorre todos los atributos del bloque y los 
        ' carga en la grilla (lvAte)
        '/////////////////////////////////////////////////////////////////////////////////////////

        bloqueLeido = bloque
        ConfiguraGrillaAte()
        lvAte.Items.Clear()

        Dim definicionesEncontradas As Integer = 0
        Dim j As Integer

        Dim elTextoDelBloque As VectorDraw.Professional.vdFigures.vdText
        Dim defBloque As VectorDraw.Professional.vdFigures.vdAttribDef
        ReDim definicionDeAtributoNro(0)
        For j = 0 To bloqueLeido.Block.Entities.Count - 1
            If bloqueLeido.Block.Entities.Item(j).ToString = "vdAttribDef" Then
                defBloque = bloqueLeido.Block.Entities.Item(j)
                If definicionesEncontradas = 0 Then
                    definicionDeAtributoNro(0) = defBloque.PromptString
                Else
                    ReDim Preserve definicionDeAtributoNro(UBound(definicionDeAtributoNro) + 1)
                    definicionDeAtributoNro(UBound(definicionDeAtributoNro)) = defBloque.PromptString
                End If
                definicionesEncontradas = definicionesEncontradas + 1
            ElseIf bloqueLeido.Block.Entities.Item(j).ToString = "vdText" Then
                'elTextoDelBloque = New VectorDraw.Professional.vdFigures.vdText
                'elTextoDelBloque = bloqueLeido.Block.Entities.Item(j)
                'elTextoDelBloque.Style.IsUnderLine = True
                'elTextoDelBloque = Nothing
            End If
        Next

        Dim lvAteItem As ListViewItem
        Dim i As Integer = 0
        Dim atributoNro As Integer = 0

        For Each atributo As vdAttrib In bloqueLeido.Attributes
            For i = 0 To lvAte.Columns.Count - 1
                If i = 0 Then
                    'valor "promptString" de la definición del atributo (vdAttribDef)
                    If definicionDeAtributoNro(atributoNro) = "Prompt" Then
                        lvAteItem = lvAte.Items.Add(atributo.TagString.ToString)
                    Else
                        lvAteItem = lvAte.Items.Add(definicionDeAtributoNro(atributoNro))
                    End If

                ElseIf i = 1 Then
                    'valor del atributo insertado, ya puesto. Es el "textString"
                    'del vdinsert.attributes.item(i).texstring
                    lvAteItem.SubItems.Add(atributo.TextString)
                ElseIf i = 2 Then
                    lvAteItem.SubItems.Add(atributoNro)
                ElseIf i = 3 Then
                    lvAteItem.SubItems.Add(atributo.TagString)
                End If
            Next
            atributoNro = atributoNro + 1
        Next

    End Sub

    Private Sub frmAte_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        '////////////////////////////////////////////////////////
        '
        ' cada vez que se activa el form mostrar el documento
        '
        '////////////////////////////////////////////////////////
        Me.Text = aplicacionNombre & " - Ediciòn de atributos. - " & frmPpal.VdF.BaseControl.ActiveDocument.FileName
        cargarComboEstilosTexto()
        cargarComboLayer()
        cargarComboTipoLinea()

    End Sub

    'Private Sub seleccionarColorActivo()

    '    Dim atributo As vdAttrib = bloqueLeido.Attributes.Item(CInt(lblAttFormatTexto.Text))
    '    If atributo Is Nothing Then Exit Sub

    '    'atributo.Layer = frmPpal.VdF.BaseControl.ActiveDocument.Layers.FindName(cmbLayer.Text)
    '    'If atributo.PenColor 

    '    atributo.Update()
    '    atributo.Dispose()
    '    atributo = Nothing
    '    'frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    'End Sub

    Private Sub cargarComboTipoLinea()
        cmbTipoLinea.Items.Clear()

        For Each tipoDeLinea As VectorDraw.Professional.vdPrimaries.vdLineType In frmPpal.VdF.BaseControl.ActiveDocument.LineTypes
            cmbTipoLinea.Items.Add(tipoDeLinea)
        Next
    End Sub

    Private Sub cargarComboLayer()
        cmbLayer.Items.Clear()

        For Each capa As VectorDraw.Professional.vdPrimaries.vdLayer In frmPpal.VdF.BaseControl.ActiveDocument.Layers
            cmbLayer.Items.Add(capa)
        Next
    End Sub
    Private Sub cargarComboEstilosTexto()
        cmbEstiloTexto.Items.Clear()

        For Each estilo As VectorDraw.Professional.vdPrimaries.vdTextstyle In frmPpal.VdF.BaseControl.ActiveDocument.TextStyles
            cmbEstiloTexto.Items.Add(estilo)
        Next

    End Sub

    Public Sub atributosCrear()
        Dim def As VectorDraw.Professional.vdFigures.vdAttribDef = VectorDraw.Professional.Dialogs.frmAddAttribute.Show(frmPpal.VdF.BaseControl.ActiveDocument)
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(def)
        frmPpal.VdF.BaseControl.ActiveDocument.ActionDrawFigure(def)

    End Sub


    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        '//////////////////////////////////////////////////////////
        ' actualizar los valores del bloque de acuerdo al valor de 
        ' los items en la grilla (lvAte)
        '/////////////////////////////////////////////////////////
        For Each valorEnListView As ListViewItem In lvAte.Items
            bloqueLeido.Attributes.Item(valorEnListView.SubItems(2).Text).ValueString = valorEnListView.SubItems(1).Text
        Next

        salir()

    End Sub

    Private Sub ConfiguraGrillaAte()
        '///////////////////////////////////////////////
        ' Configurar la grilla
        '///////////////////////////////////////////////
        With lvAte
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .LabelEdit = False
            .HideSelection = False
            .Columns.Clear()
        End With
        lvAte.Columns.Add("Atributo", 290, HorizontalAlignment.Left)
        lvAte.Columns.Add("Valor", 130, HorizontalAlignment.Left)
        lvAte.Columns.Add("Nro.", 40, HorizontalAlignment.Left)
        lvAte.Columns.Add("Tag", 40, HorizontalAlignment.Left)

    End Sub

    Private Sub lvAte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvAte.SelectedIndexChanged
        '///////////////////////////////////////////
        ' se seleccionó un item de la grilla y se 
        ' muestra en el textbox de abajo del form
        '///////////////////////////////////////////
        If lvAte.SelectedItems.Count = 1 Then
            txtValorAtt.Text = lvAte.SelectedItems.Item(0).SubItems(1).Text
            lblAtributo.Text = lvAte.SelectedItems.Item(0).SubItems(2).Text
            lblAttFormatTexto.Text = lvAte.SelectedItems.Item(0).SubItems(2).Text
            lblAttPropiedades.Text = lvAte.SelectedItems.Item(0).SubItems(2).Text
        End If

    End Sub

    Private Sub txtValorAtt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValorAtt.KeyPress
        '/////////////////////////////////////////
        ' se oprimió una tecla en el txtBox de 
        ' edicion de datos. Por lo tanto habilitar
        ' el botón de validar lo escrito en el 
        ' txtBox.
        '//////////////////////////////////////////
        'btnAplicar.Enabled = True

    End Sub

    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click
        '/////////////////////////////////////////
        ' se hizo click en el boton "Aplicar"
        ' para validar lo escrito en el txtBox y 
        ' pasarlo a la grilla
        '/////////////////////////////////////////
        If TabControl.SelectedTab.Text = "Atributo" Then
            If lvAte.SelectedItems.Count > 0 Then
                lvAte.SelectedItems.Item(0).SubItems(1).Text = txtValorAtt.Text
                'btnAplicar.Enabled = False
            Else
                MessageBox.Show("No se actualizò ningùn atributo." & vbCrLf & _
                "No se selecciono ningùn item de la grilla de atributos.", "mhCad", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf TabControl.SelectedTab.Text = "Opciones de texto" Then
            Dim atributo As vdAttrib = bloqueLeido.Attributes.Item(CInt(lblAttFormatTexto.Text))
            If Not atributo Is Nothing Then
            
                atributo.Style = frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.FindName(cmbEstiloTexto.Text)

                Select Case cmbJustificacion.Text
                    Case Is = "Alineado"
                        atributo.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorAligned
                    Case Is = "Centrado"
                        atributo.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
                    Case Is = "Justificado"
                        atributo.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorFit
                    Case Is = "Izquierda"
                        atributo.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorLeft
                    Case Is = "Derecha"
                        atributo.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorRight
                End Select
                atributo.Height = CDbl(txtAltura.Text)
                atributo.WidthFactor = CDbl(txtFactorAncho.Text)
                atributo.ObliqueAngle = CDbl(txtAnguloLetra.Text)
                atributo.Rotation = CDbl(txtRotacion.Text)
                atributo.Update()
                atributo.Dispose()
                atributo = Nothing
            End If
        ElseIf TabControl.SelectedTab.Text = "Propiedades" Then
            'Dim atributo As vdAttrib = bloqueLeido.Attributes.Item(CInt(lblAttFormatTexto.Text))
            'If Not atributo Is Nothing Then
            '    Select Case cmbColor.Text
            '        Case Is = "Por layer"
            '            atributo.PenColor.ByLayer = True
            '        Case Is = "Rojo"
            '            atributo.PenColor.FromSystemColor(Color.Red)
            '        Case Is = "Amarillo"
            '            atributo.PenColor.FromSystemColor(Color.Yellow)
            '        Case Is = "Verde"
            '            atributo.PenColor.FromSystemColor(Color.Green)
            '        Case Is = "Cian"
            '            atributo.PenColor.FromSystemColor(Color.Cyan)
            '        Case Is = "Azul"
            '            atributo.PenColor.FromSystemColor(Color.Blue)
            '        Case Is = "Magenta"
            '            atributo.PenColor.FromSystemColor(Color.Magenta)
            '        Case Is = "Negro"
            '            atributo.PenColor.FromSystemColor(Color.Black)
            '        Case Else
            '            Dim mColor As VectorDraw.Professional.vdObjects.vdColor = New VectorDraw.Professional.vdObjects.vdColor()
            '            mColor.Palette = frmPpal.VdF.BaseControl.ActiveDocument.Palette

            '            Dim dialog As VectorDraw.Professional.Dialogs.frmColor = New VectorDraw.Professional.Dialogs.frmColor((mColor), False)
            '            dialog.ShowDialog()

            '            If (dialog.DialogResult = DialogResult.OK) Then
            '                atributo.PenColor = mColor
            '            End If
            '    End Select
            '    atributo.Update()
            '    atributo.Dispose()
            '    atributo = Nothing
            'End If

        End If

        For Each valorEnListView As ListViewItem In lvAte.Items
            bloqueLeido.Attributes.Item(valorEnListView.SubItems(2).Text).ValueString = valorEnListView.SubItems(1).Text
        Next
        'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        salir()
    End Sub

    Private Sub salir()
        txtValorAtt.Clear()
        Me.Close()
    End Sub

    Private Sub lvAte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvAte.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmAte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub TabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl.SelectedIndexChanged
        'Dim atributo As vdAttrib = bloqueLeido.Attributes.Item(CInt(lblAttFormatTexto.Text))

        'si no hay ningun atributo seleccionado, lblAttFormatTexto.text esta vacio, por lo tanto me voy..
        If lblAttFormatTexto.Text = "--" Or lblAttFormatTexto.Text = "" Then Exit Sub

        Dim atributo As vdAttrib = bloqueLeido.Attributes.Item(CInt(lblAttFormatTexto.Text))
        If atributo Is Nothing Then Exit Sub

        Select Case TabControl.SelectedTab.Text
            Case Is = "Opciones de texto"
                cmbEstiloTexto.Text = atributo.Style.Name.ToString
                cmbJustificacion.Text = atributo.HorJustify.ToString
                txtAltura.Text = atributo.Height.ToString
                txtFactorAncho.Text = atributo.WidthFactor.ToString
                txtAnguloLetra.Text = atributo.ObliqueAngle.ToString
                txtRotacion.Text = atributo.Rotation.ToString
            Case Is = "Propiedades"
                cmbLayer.Text = atributo.Layer.ToString
                cmbTipoLinea.Text = atributo.LineType.ToString
                ocultarCuadroColores = True
                Select Case atributo.PenColor.ToString
                    Case "0"
                        cmbColor.Text = "Rojo"
                    Case "(255,0,0)"
                        cmbColor.Text = "Rojo"
                    Case "1"
                        cmbColor.Text = "Amarillo"
                    Case "(255,255,0)"
                        cmbColor.Text = "Amarillo"
                    Case "2"
                        cmbColor.Text = "Verde"
                    Case "(0,255,0)"
                        cmbColor.Text = "Verde"
                    Case "3"
                        cmbColor.Text = "Cian"
                    Case "(0,255,255)"
                        cmbColor.Text = "Cian"
                    Case "4"
                        cmbColor.Text = "Azul"
                    Case "(0,0,255)"
                        cmbColor.Text = "Azul"
                    Case "5"
                        cmbColor.Text = "Magenta"
                    Case "(255,0,255)"
                        cmbColor.Text = "Magenta"
                    Case "6"
                        cmbColor.Text = "Negro"
                    Case "(255,255,255)"
                        cmbColor.Text = "Negro"
                    Case Else
                        If cmbColor.FindStringExact(atributo.PenColor.ToString) = 1 Then
                            cmbColor.Text = atributo.PenColor.ToString
                        Else
                            cmbColor.Items.Add(atributo.PenColor.ToString)
                            cmbColor.Text = atributo.PenColor.ToString
                        End If
                End Select
        End Select
        atributo.Update()
        atributo.Dispose()
        atributo = Nothing
        ocultarCuadroColores = False
    End Sub

    Private Sub cmbColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbColor.SelectedIndexChanged

        If ocultarCuadroColores = True Then Exit Sub

        Dim atributo As vdAttrib = bloqueLeido.Attributes.Item(CInt(lblAttFormatTexto.Text))
        If atributo Is Nothing Then Exit Sub
        Select Case cmbColor.Text
            Case Is = "Por layer"
                atributo.PenColor.ByLayer = True
            Case Is = "Rojo"
                atributo.PenColor.FromSystemColor(Color.Red)
            Case Is = "Amarillo"
                atributo.PenColor.FromSystemColor(Color.Yellow)
            Case Is = "Verde"
                atributo.PenColor.FromSystemColor(Color.Green)
            Case Is = "Cian"
                atributo.PenColor.FromSystemColor(Color.Cyan)
            Case Is = "Azul"
                atributo.PenColor.FromSystemColor(Color.Blue)
            Case Is = "Magenta"
                atributo.PenColor.FromSystemColor(Color.Magenta)
            Case Is = "Negro"
                atributo.PenColor.FromSystemColor(Color.Black)
            Case Is = "Seleccionar color..."
                Dim mColor As VectorDraw.Professional.vdObjects.vdColor = New VectorDraw.Professional.vdObjects.vdColor()
                mColor.Palette = frmPpal.VdF.BaseControl.ActiveDocument.Palette

                Dim dialog As VectorDraw.Professional.Dialogs.frmColor = New VectorDraw.Professional.Dialogs.frmColor((mColor), False)
                dialog.ShowDialog()

                If (dialog.DialogResult = DialogResult.OK) Then
                    atributo.PenColor = mColor
                End If

        End Select
        atributo.Update()
        atributo.Dispose()
        atributo = Nothing
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub cmbLayer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLayer.SelectedIndexChanged
        Dim atributo As vdAttrib = bloqueLeido.Attributes.Item(CInt(lblAttFormatTexto.Text))
        If atributo Is Nothing Then Exit Sub

        atributo.Layer = frmPpal.VdF.BaseControl.ActiveDocument.Layers.FindName(cmbLayer.Text)

        atributo.Update()
        atributo.Dispose()
        atributo = Nothing
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub cmbTipoLinea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoLinea.SelectedIndexChanged
        Dim atributo As vdAttrib = bloqueLeido.Attributes.Item(CInt(lblAttFormatTexto.Text))
        If atributo Is Nothing Then Exit Sub

        atributo.LineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName(cmbTipoLinea.Text)

        atributo.Update()
        atributo.Dispose()
        atributo = Nothing
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub
End Class