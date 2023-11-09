Imports VectorDraw.Professional.vdFigures


Public Class frmPropiedades

    Dim elRadio As Double = 1.0
    Dim idCirculito As Integer
    Public tipoObjeto As String

    Private Sub frmPropiedades_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        trvAltura.Visible = False
        lstLayers.Visible = False
        lstTipoLinea.Visible = False
    End Sub

    Private Sub frmPropiedades_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.DesignMode = True Then Exit Sub

        Me.Text = "Edición " & tipoObjeto
        traducirColores()                                 'cartel del color actual
        lblLayer.Text = entidad.Layer.ToString            'cartel del layer actual
        lblTipoLinea.Text = entidad.LineType.ToString     'cartel del tipo de linea actual

        lstLayers.BringToFront()
        lstLayers.Visible = False
        lstTipoLinea.BringToFront()
        lstTipoLinea.Visible = False

        lblLargoEntidad.Visible = False
        lblAreaEntidad.Visible = False
        lblAlturaEntidad.Visible = False
        lblAnchoEntidad.Visible = False
        lblOtro.Visible = False
        btnAltura.Visible = False
        trvAltura.Visible = False
        Label4.Visible = False
        NumericUpDown1.Visible = False


        If tipoObjeto = "Linea" Then
            linea()
        ElseIf tipoObjeto = "Polilinea" Then
            polilinea()
        ElseIf tipoObjeto = "Rectangulo" Then
            rectangulo()
        ElseIf tipoObjeto = "Arco" Then
            arco()
        ElseIf tipoObjeto = "Circulo" Then
            circulo()
        ElseIf tipoObjeto = "Elipse" Then
            elipse()
        Else
            lblLargoEntidad.Visible = False
            lblAreaEntidad.Visible = False
            lblAlturaEntidad.Visible = False
            lblAnchoEntidad.Visible = False
            lblOtro.Visible = False
            btnAltura.Visible = False
            trvAltura.Visible = False
            Label4.Visible = False
            NumericUpDown1.Visible = False

        End If


    End Sub

    Private Sub linea()
        lblLargoEntidad.Visible = True
        lblAreaEntidad.Visible = True
        lblAlturaEntidad.Visible = True
        btnAltura.Visible = True
        Label4.Visible = True
        NumericUpDown1.Visible = True

        Dim laLinea As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine
        laLinea = TryCast(entidad, VectorDraw.Professional.vdFigures.vdLine)
        lblLargoEntidad.Text = "Longitud: " & CStr(Format(laLinea.Length, "0.0###"))
        lblAreaEntidad.Text = "P1: X= " & CStr(Format(laLinea.StartPoint.x, "0.0###")) & ", Y= " & CStr(Format(laLinea.StartPoint.y, "0.0###"))
        lblAlturaEntidad.Text = "P2: X= " & CStr(Format(laLinea.EndPoint.x, "0.0###")) & ", Y= " & CStr(Format(laLinea.EndPoint.y, "0.0###"))

        laLinea = Nothing

    End Sub

    Private Sub polilinea()
        lblLargoEntidad.Visible = True
        lblAreaEntidad.Visible = True
        lblAlturaEntidad.Visible = True
        btnAltura.Visible = True
        Label4.Visible = True
        NumericUpDown1.Visible = True

        Dim area As Double
        Dim listaDeVertices As VectorDraw.Geometry.Vertexes
        Dim laPoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
        laPoli = TryCast(entidad, VectorDraw.Professional.vdFigures.vdPolyline)
        lblLargoEntidad.Text = "Longitud: " & CStr(Format(laPoli.Length, "0.0###"))
        area = CDbl(laPoli.Area)
        If laPoli.Area < 0 Then
            area = area * -1
        End If
        lblAreaEntidad.Text = "Area: " & CStr(Format(area, "0.0###"))
        listaDeVertices = laPoli.VertexList
        lblAlturaEntidad.Text = "Cantidad de vertices: " & listaDeVertices.Count.ToString
        laPoli = Nothing
        area = Nothing
        listaDeVertices = Nothing

    End Sub

    Private Sub btnAltura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltura.Click

        lstLayers.Visible = False
        lstTipoLinea.Visible = False

        If trvAltura.Visible Then
            trvAltura.Visible = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
            Exit Sub
        End If

        If tipoObjeto = "Polilinea" Then
            Dim laPoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
            laPoli = TryCast(entidad, VectorDraw.Professional.vdFigures.vdPolyline)
            Dim listaDeVertices As VectorDraw.Geometry.Vertexes
            listaDeVertices = laPoli.VertexList
            trvAltura.Nodes.Clear()
            trvAltura.Visible = True
            trvAltura.Location = New System.Drawing.Point(6, 6)
            trvAltura.Size = New System.Drawing.Size(232, 155)
            Dim nodo As TreeNode, nodoCoord As TreeNode
            nodo = trvAltura.Nodes.Add("Vertices")
            nodo.Tag = "Raiz"
            For Each vertice As VectorDraw.Geometry.Vertex In listaDeVertices
                '24/03/13

                nodo = trvAltura.Nodes(0).Nodes.Add(vertice.GetHashCode.ToString)
                nodo.Tag = "Vertice"
                nodoCoord = nodo.Nodes.Add("X: " & vertice.x.ToString)
                nodoCoord.Tag = "X"
                nodoCoord = nodo.Nodes.Add("Y: " & vertice.y.ToString)
                nodoCoord.Tag = "Y"
                nodoCoord = nodo.Nodes.Add("Z: " & vertice.z.ToString)
                nodoCoord.Tag = "Z"
            Next
            laPoli = Nothing
        End If
        If tipoObjeto = "Linea" Then
            Dim laLinea As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine
            laLinea = TryCast(entidad, VectorDraw.Professional.vdFigures.vdLine)
            trvAltura.Nodes.Clear()
            trvAltura.Visible = True
            trvAltura.Location = New System.Drawing.Point(6, 6)
            trvAltura.Size = New System.Drawing.Size(232, 155)
            Dim nodo As TreeNode, nodoCoord As TreeNode
            nodo = trvAltura.Nodes.Add("Vertices")
            nodo.Tag = "Raiz"
            nodo = trvAltura.Nodes(0).Nodes.Add("P1")
            nodo.Tag = "P1"
            nodoCoord = nodo.Nodes.Add("X: " & laLinea.StartPoint.x.ToString)
            nodoCoord.Tag = "X"
            nodoCoord = nodo.Nodes.Add("Y: " & laLinea.StartPoint.y.ToString)
            nodoCoord.Tag = "Y"
            nodoCoord = nodo.Nodes.Add("Z: " & laLinea.StartPoint.z.ToString)
            nodoCoord.Tag = "Z"
            nodo = trvAltura.Nodes(0).Nodes.Add("P2")
            nodo.Tag = "P2"
            nodoCoord = nodo.Nodes.Add("X: " & laLinea.EndPoint.x.ToString)
            nodoCoord.Tag = "X"
            nodoCoord = nodo.Nodes.Add("Y: " & laLinea.EndPoint.y.ToString)
            nodoCoord.Tag = "Y"
            nodoCoord = nodo.Nodes.Add("Z: " & laLinea.EndPoint.z.ToString)
            nodoCoord.Tag = "Z"
            laLinea = Nothing
        End If
        trvAltura.EndUpdate()

    End Sub

    Private Sub rectangulo()
        lblLargoEntidad.Visible = True
        lblAreaEntidad.Visible = True
        lblAlturaEntidad.Visible = True
        lblAnchoEntidad.Visible = True
        lblOtro.Visible = True

        Dim elRectangulo As VectorDraw.Professional.vdFigures.vdRect = New VectorDraw.Professional.vdFigures.vdRect
        elRectangulo = TryCast(entidad, VectorDraw.Professional.vdFigures.vdRect)
        lblLargoEntidad.Text = "Longitud: " & CStr(Format(elRectangulo.Length, "0.0###"))
        lblAreaEntidad.Text = "Area: " & CStr(Format(elRectangulo.Area, "0.0###"))
        If elRectangulo.Height < 0 Then elRectangulo.Height = elRectangulo.Height * -1
        lblAlturaEntidad.Text = "Altura: " & CStr(Format(elRectangulo.Height, "0.0###"))
        If elRectangulo.Width < 0 Then elRectangulo.Width = elRectangulo.Width * -1
        lblAnchoEntidad.Text = "Ancho: " & CStr(Format(elRectangulo.Width, "0.0###"))
        lblOtro.Text = "Rotación: " & CStr(Format(VectorDraw.Geometry.Globals.RadiansToDegrees(elRectangulo.Rotation), "0.0###"))
        elRectangulo = Nothing

    End Sub

    Private Sub arco()
        lblLargoEntidad.Visible = True
        lblAreaEntidad.Visible = True
        lblAlturaEntidad.Visible = True
        lblAnchoEntidad.Visible = True
        Dim elArco As VectorDraw.Professional.vdFigures.vdArc = New VectorDraw.Professional.vdFigures.vdArc
        elArco = TryCast(entidad, VectorDraw.Professional.vdFigures.vdArc)
        lblLargoEntidad.Text = "Long. Arco: " & CStr(Format(elArco.Length, "0.0###"))
        lblAreaEntidad.Text = "Area: " & CStr(Format(elArco.Area, "0.0###"))
        lblAlturaEntidad.Text = "Coord.Centro X: " & CStr(Format(elArco.Center.x, "0.0###")) & ", Y: " & CStr(Format(elArco.Center.y, "0.0###"))
        lblAnchoEntidad.Text = "Radio: " & CStr(Format(elArco.Radius, "0.0###"))
        elArco = Nothing
    End Sub

    Private Sub circulo()
        lblLargoEntidad.Visible = True
        lblAreaEntidad.Visible = True
        lblAlturaEntidad.Visible = True
        lblAnchoEntidad.Visible = True
        Dim elCirculo As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle
        elCirculo = TryCast(entidad, VectorDraw.Professional.vdFigures.vdCircle)
        lblLargoEntidad.Text = "Perimetro: " & CStr(Format(elCirculo.Length, "0.0###"))
        lblAreaEntidad.Text = "Area: " & CStr(Format(elCirculo.Area, "0.0###"))
        lblAlturaEntidad.Text = "Coord.Centro X: " & CStr(Format(elCirculo.Center.x, "0.0###")) & ", Y: " & CStr(Format(elCirculo.Center.y, "0.0###"))
        lblAnchoEntidad.Text = "Radio: " & CStr(Format(elCirculo.Radius, "0.0###"))
        elCirculo = Nothing
    End Sub

    Private Sub elipse()
        lblLargoEntidad.Visible = True
        lblAreaEntidad.Visible = True
        lblAlturaEntidad.Visible = True
        lblAnchoEntidad.Visible = True
        lblOtro.Visible = True
        Dim laElipse As VectorDraw.Professional.vdFigures.vdEllipse = New VectorDraw.Professional.vdFigures.vdEllipse
        laElipse = TryCast(entidad, VectorDraw.Professional.vdFigures.vdEllipse)
        lblLargoEntidad.Text = "Perimetro: " & CStr(Format(laElipse.Length, "0.0###"))
        lblAreaEntidad.Text = "Area: " & CStr(Format(laElipse.Area, "0.0###"))
        lblAlturaEntidad.Text = "Coord.Centro X: " & CStr(Format(laElipse.Center.x, "0.0###")) & ", Y: " & CStr(Format(laElipse.Center.y, "0.0###"))
        lblAnchoEntidad.Text = "Semi eje menor: " & CStr(Format(laElipse.MajorLength, "0.0###"))
        lblOtro.Text = "Semi eje mayor: " & CStr(Format(laElipse.MinorLength, "0.0###"))
        laElipse = Nothing

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '------------------------
        ' Colores
        '------------------------
        Dim tramado As vdPolyhatch = New vdPolyhatch

        If lstLayers.Visible Then lstLayers.Visible = False
        If lstTipoLinea.Visible Then lstTipoLinea.Visible = False
        If trvAltura.Visible Then trvAltura.Visible = False


        Dim mColor As VectorDraw.Professional.vdObjects.vdColor = New VectorDraw.Professional.vdObjects.vdColor()
        mColor.Palette = frmPpal.VdF.BaseControl.ActiveDocument.Palette

        Dim dialog As VectorDraw.Professional.Dialogs.frmColor = New VectorDraw.Professional.Dialogs.frmColor((mColor), False)
        dialog.ShowDialog()

        If (dialog.DialogResult = DialogResult.OK) Then
            If entidad._TypeName = "vdPolyhatch" Then
                tramado = entidad
                tramado.HatchProperties.FillColor = mColor
            Else
                entidad.PenColor = mColor
                'traducirColores()
            End If
        End If
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '--------------------------------------
        ' Layers
        '--------------------------------------

        'precauciones..
        'si el listbox de tipos de linea esta visible aun, apagarlo. Idem con el de layers
        If lstTipoLinea.Visible = True Then lstTipoLinea.Visible = False
        If trvAltura.Visible Then trvAltura.Visible = False

        If lstLayers.Visible Then
            lstLayers.Visible = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
            Exit Sub
        End If

        lstLayers.Items.Clear()
        For Each capa As VectorDraw.Professional.vdPrimaries.vdLayer In frmPpal.VdF.BaseControl.ActiveDocument.Layers
            lstLayers.Items.Add(capa.Name.ToString)
        Next

        lstLayers.Visible = True
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub lstLayers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLayers.SelectedIndexChanged
        If lstTipoLinea.Visible = True Then lstTipoLinea.Visible = False
        lstLayers.Visible = False

        For Each capa As VectorDraw.Professional.vdPrimaries.vdLayer In frmPpal.VdF.BaseControl.ActiveDocument.Layers
            If capa.Name = lstLayers.SelectedItem.ToString Then
                entidad.Layer = capa
                lblLayer.Text = capa.Name
                frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()

                If estoyEnUnViewport() Then
                    salirDelViewport()
                    frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
                End If

            End If
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '---------------------------------------------------
        ' Tipos de linea
        '---------------------------------------------------
        If lstTipoLinea.Visible = True Then
            lstTipoLinea.Visible = False
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            Exit Sub
        End If
        If lstLayers.Visible Then lstLayers.Visible = False
        If trvAltura.Visible Then trvAltura.Visible = False

        lstTipoLinea.Items.Clear()
        For Each tipoLinea As VectorDraw.Professional.vdPrimaries.vdLineType In frmPpal.VdF.BaseControl.ActiveDocument.LineTypes
            If Not tipoLinea.Deleted Then
                lstTipoLinea.Items.Add(tipoLinea.Name)
            End If
        Next
        lstTipoLinea.Visible = True
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()

    End Sub

    Private Sub lstTipoLinea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTipoLinea.SelectedIndexChanged
        If lstLayers.Visible = True Then lstLayers.Visible = False
        lstTipoLinea.Visible = False
        For Each tipoLinea As VectorDraw.Professional.vdPrimaries.vdLineType In frmPpal.VdF.BaseControl.ActiveDocument.LineTypes
            If tipoLinea.Name = lstTipoLinea.SelectedItem.ToString Then
                entidad.LineType = tipoLinea
                lblTipoLinea.Text = tipoLinea.Name
                frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            End If
        Next
    End Sub

    Private Sub traducirColores()
        Select Case entidad.PenColor.ToString
            Case "ByBlock"
                lblColor.Text = " Por Bloque "
            Case "ForGround"
                lblColor.Text = " Blanco "
            Case "ByLayer"
                lblColor.Text = " Por Layer "
            Case "0"
                lblColor.Text = " Rojo "
            Case "1"
                lblColor.Text = " Amarillo "
            Case "2"
                lblColor.Text = " Verde "
            Case "3"
                lblColor.Text = " Cyan  "
            Case "4"
                lblColor.Text = " Azul  "
            Case "5"
                lblColor.Text = " Magenta "
            Case "6"
                lblColor.Text = " Blanco "
            Case Else
                lblColor.Text = entidad.PenColor.ToString
        End Select

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        'ultimoComando = "chPropiedades"
        LimpiarSeleccion(obtenerSeleccion)
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'ultimoComando = "chPropiedades"
        LimpiarSeleccion(obtenerSeleccion)
        Close()
    End Sub

    Private Sub trvAltura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvAltura.LostFocus
        Dim circuloABorrar As VectorDraw.Professional.vdFigures.vdCircle
        circuloABorrar = TryCast(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.FindFromId(idCirculito), VectorDraw.Professional.vdFigures.vdCircle)
        If Not circuloABorrar Is Nothing Then
            circuloABorrar.Deleted = True
        End If
        circuloABorrar = Nothing
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    End Sub

    Private Sub trvAltura_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles trvAltura.NodeMouseClick

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Exit Sub
        End If

        If e.Node.Tag.ToString = "Vertice" Or e.Node.Tag.ToString = "P1" Or e.Node.Tag.ToString = "P2" Then
            borradorDeCirculito()
            dibujadoraDeCirculito(e.Node)
        Else
            borradorDeCirculito()
            If e.Node.Tag.ToString = "X" Or _
                e.Node.Tag.ToString = "Y" Or _
                e.Node.Tag.ToString = "Z" Then
                dibujadoraDeCirculito(e.Node.Parent)
            End If
        End If
    End Sub

    Private Sub dibujadoraDeCirculito(ByVal nodoACirculear As TreeNode)

        Dim circulito As New VectorDraw.Professional.vdFigures.vdCircle
        circulito.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        circulito.setDocumentDefaults()

        circulito.Center = New VectorDraw.Geometry.gPoint(CDbl(nodoACirculear.Nodes(0).Text.Remove(0, 3)), CDbl(nodoACirculear.Nodes(1).Text.Remove(0, 3)), 0.0)
        circulito.Radius = elRadio
        idCirculito = circulito.Id
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(circulito)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    End Sub

    Private Sub borradorDeCirculito()
        Dim circuloABorrar As VectorDraw.Professional.vdFigures.vdCircle
        circuloABorrar = TryCast(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.FindFromId(idCirculito), VectorDraw.Professional.vdFigures.vdCircle)
        If Not circuloABorrar Is Nothing Then
            circuloABorrar.Deleted = True
        End If
        circuloABorrar = Nothing
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        elRadio = NumericUpDown1.Value
    End Sub
End Class