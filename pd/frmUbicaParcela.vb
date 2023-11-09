Imports System.Windows.Forms
Imports VectorDraw.Professional.vdCollections

Public Class frmUbicaParcela

    Dim lineaParalelaUnoId, lineaParalelaDosId, circuloId, circuloIdEsquina As Integer
    Public idPoliParcela As Integer
    Dim puntoOrigen As VectorDraw.Geometry.gPoint = Nothing
    Dim puntoDestino As VectorDraw.Geometry.gPoint = Nothing
    Dim segmentoPolilinea As VectorDraw.Professional.vdFigures.vdCurve

    Private Sub frmUbicaParcela_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If idPoliParcela <> 0 Then
            lblParcela.Text = "Id: " & idPoliParcela.ToString
            habilitarMoverParcela()
        Else
            desHabilitarMoverParcela()
        End If
    End Sub
    Private Sub habilitarMoverParcela()
        btnVertice.Enabled = True
        btnLadoMz.Enabled = True
        btnEsquina.Enabled = True
        btnDistEsq.Enabled = True
    End Sub
    Private Sub desHabilitarMoverParcela()
        btnVertice.Enabled = False
        btnLadoMz.Enabled = False
        btnEsquina.Enabled = False
        btnDistEsq.Enabled = False
    End Sub
    Private Sub btnVertice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVertice.Click
        '--------------------------------------------------------------------------------------
        '
        'PARCELA
        '
        'Seleccionar vertice de la parcela 
        '
        '--------------------------------------------------------------------------------------
        Dim ret As VectorDraw.Actions.StatusCode

        'Definir poligono..
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar VERTICE DE PARCELA")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(puntoOrigen)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdCircle(puntoOrigen, 1.0)
            circuloId = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count - 1).Id
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            lblVerticePl.Text = "X: " & Format(puntoOrigen.x, "##,##0.00") & ",   Y: " & Format(puntoOrigen.y, "##,##0.00") & ",    Z: " & Format(puntoOrigen.z, "##,##0.00")
            Me.Activate()
            habilitarBtnUbicarParcela()
        End If
    End Sub

    Private Sub habilitarBtnUbicarParcela()
        If Trim(lblVerticePl.Text) <> "" And lblVerticePl.Text <> "---" And _
        Trim(lblLadoMz.Text) <> "" And lblLadoMz.Text <> "---" And _
        Trim(lblEsquina.Text) <> "" And lblEsquina.Text <> "---" And _
        Trim(lblDistEsquina.Text) <> "" And lblDistEsquina.Text <> "---" Then
            OK_Button.Enabled = True
        Else
            OK_Button.Enabled = False
        End If
    End Sub

    Private Sub btnLadoMz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLadoMz.Click
        '--------------------------------------------------------------------------------------
        '
        'MACIZO
        '
        'Seleccionar lado del macizo
        '
        '--------------------------------------------------------------------------------------
        Dim ret As VectorDraw.Actions.StatusCode
        Dim pt As VectorDraw.Geometry.gPoint = Nothing
        Dim fig As VectorDraw.Professional.vdPrimaries.vdFigure
        Dim lapolilinea As VectorDraw.Professional.vdFigures.vdPolyline
        Dim segmento As Integer

        Dim curvas As VectorDraw.Professional.vdCollections.vdCurves

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar LADO DEL MACIZO")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserEntity(fig, pt)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            If fig._TypeName = "vdPolyline" Then                                             'es una polilinea
                lapolilinea = New VectorDraw.Professional.vdFigures.vdPolyline
                lapolilinea.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                lapolilinea.setDocumentDefaults()
                lapolilinea = CType(fig, VectorDraw.Professional.vdFigures.vdPolyline)
                lapolilinea.HighLight = True
                'lapolilinea .GetFigureAtSegmentIndex
                'lapolilinea.getOffsetCurve
                'lapolilinea.getPointAtDist()
                'lapolilinea.PointOnCurve()
                'lapolilinea.SegmentIndexFromParam()
                segmento = lapolilinea.SegmentIndexFromPoint(pt, 0.0)
                'MsgBox("Segmento Nro.: " & segmento.ToString)
                segmentoPolilinea = lapolilinea.GetFigureAtSegmentIndex(segmento)
                If segmentoPolilinea._TypeName = "vdLine" Then

                    curvas = segmentoPolilinea.getOffsetCurve(0.5)
                    curvas.Item(0).PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.White)
                    curvas.Item(0).PenWidth = 0.01
                    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(curvas.Item(0))
                    'lapoli = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count - 1)
                    lineaParalelaUnoId = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count - 1).Id
                    curvas = segmentoPolilinea.getOffsetCurve(-0.5)
                    curvas.Item(0).PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.White)
                    curvas.Item(0).PenWidth = 0.01
                    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(curvas.Item(0))
                    lineaParalelaDosId = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count - 1).Id
                    lblLadoMz.Text = "Lado seleccionado: " & segmento.ToString
                End If

                frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            End If
            Me.Activate()
            habilitarBtnUbicarParcela()
        End If
    End Sub

    Private Sub btnEsquina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEsquina.Click
        '--------------------------------------------------------------------------------------
        '
        'MACIZO
        '
        'Seleccionar vertice del macizo del lado seleccionado para tomar como esquina de refer.
        'para la distancia a esquina y colocar la parcela
        '
        '--------------------------------------------------------------------------------------
        Dim ret As VectorDraw.Actions.StatusCode

        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar ESQUINA DE REFERENCIA")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(puntoDestino)
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdCircle(puntoDestino, 1.0)
            circuloIdEsquina = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count - 1).Id
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            lblEsquina.Text = "X: " & Format(puntoDestino.x, "##,##0.00") & ",   Y: " & Format(puntoDestino.y, "##,##0.00") & ",    Z: " & Format(puntoDestino.z, "##,##0.00")
            Me.Activate()
            habilitarBtnUbicarParcela()
        End If
        
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmUbicaParcela_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim lapolilinea As VectorDraw.Professional.vdFigures.vdPolyline
        For Each obj As VectorDraw.Professional.vdObjects.vdObject In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If obj._TypeName = "vdPolyline" Then
                lapolilinea = New VectorDraw.Professional.vdFigures.vdPolyline
                lapolilinea.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                lapolilinea.setDocumentDefaults()
                lapolilinea = CType(obj, VectorDraw.Professional.vdFigures.vdPolyline)
                lapolilinea.HighLight = False
            End If
        Next

        Dim lineaABorrar As VectorDraw.Professional.vdFigures.vdLine
        lineaABorrar = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.FindFromId(lineaParalelaUnoId)
        If Not lineaABorrar Is Nothing Then
            lineaABorrar.Deleted = True
        End If
        lineaABorrar = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.FindFromId(lineaParalelaDosId)
        If Not lineaABorrar Is Nothing Then
            lineaABorrar.Deleted = True
        End If
        lineaABorrar = Nothing

        Dim circuloABorrar As VectorDraw.Professional.vdFigures.vdCircle
        circuloABorrar = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.FindFromId(circuloId)
        If Not circuloABorrar Is Nothing Then
            circuloABorrar.Deleted = True
        End If
        circuloABorrar = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.FindFromId(circuloIdEsquina)
        If Not circuloABorrar Is Nothing Then
            circuloABorrar.Deleted = True
        End If

        circuloABorrar = Nothing

        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
    End Sub

    Private Sub btnDistEsq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDistEsq.Click
        Dim valor As String
        valor = InputBox("Ingresar distancia a esquina", "mh Cad")
        If IsNumeric(valor) Then
            If InStr(valor, ",") <> 0 Then
                valor = Replace(valor, ",", ".")
            End If
            lblDistEsquina.Text = valor
            habilitarBtnUbicarParcela()
        Else
            MsgBox("Ingresar distancia utilizando cero a la izquierda para valores menores a 1")
            frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Comando:")
            frmPpal.lineaComandos.UserText.Clear()
            habilitarBtnUbicarParcela()
            Exit Sub
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        Dim puntoFinal As VectorDraw.Geometry.gPoint
        Dim poliMover As VectorDraw.Professional.vdFigures.vdPolyline
        poliMover = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.FindFromId(idPoliParcela)
        If poliMover Is Nothing Then
            MsgBox("No hay polilinea de parcela", vbInformation, aplicacionNombre)
            Exit Sub
        End If

        'verificar el angulo entre el vertice seleccionado de la polilinea y el vertice anterior
        'y con el vertice posterior. Alguno de estos angulos debe coincidir con el angulo de lado
        'del macizo donde va la parcela. Este angulo del macizo puede ser entre el vertice de la esquina
        'de referencia y el punto a partir del cual se inserta la parcela en el macizo.
        Dim i As Integer = 0
        Dim anguloPlAnterior, anguloPlSiguiente, anguloMacizo As Double
        For Each punto As VectorDraw.Geometry.gPoint In poliMover.VertexList
            If punto = puntoOrigen And i = 0 Then
                'estoy en el vertice seleccionado de la parcela, para moverla hacia el macizo
                anguloPlAnterior = VectorDraw.Geometry.Globals.GetAngle(punto, poliMover.VertexList.Item(poliMover.VertexList.Count - 1))
                anguloPlSiguiente = VectorDraw.Geometry.Globals.GetAngle(punto, poliMover.VertexList.Item(i + 1))
            ElseIf punto = puntoOrigen Then
                'estoy en el vertice seleccionado de la parcela, para moverla hacia el macizo
                anguloPlAnterior = VectorDraw.Geometry.Globals.GetAngle(punto, poliMover.VertexList.Item(i - 1))
                anguloPlSiguiente = VectorDraw.Geometry.Globals.GetAngle(punto, poliMover.VertexList.Item(i + 1))
            End If
            i = i + 1
        Next


        Dim sel As New vdSelection
        sel.AddItem(poliMover, False, vdSelection.AddItemCheck.Nochecking)

        'segmentoPolilinea es un segmento, una linea, del macizo
        puntoFinal = segmentoPolilinea.getPointAtDist(CDbl(lblDistEsquina.Text))

        anguloMacizo = VectorDraw.Geometry.Globals.RadiansToDegrees(VectorDraw.Geometry.Globals.GetAngle(puntoFinal, puntoDestino))
        anguloPlAnterior = VectorDraw.Geometry.Globals.RadiansToDegrees(anguloPlAnterior)
        anguloPlSiguiente = VectorDraw.Geometry.Globals.RadiansToDegrees(anguloPlSiguiente)
        MsgBox("Angulo pl. anterior: " & anguloPlAnterior.ToString & ", angulo pl. siguiente: " & anguloPlSiguiente.ToString & ", angulo macizo: " & anguloMacizo.ToString)

        If anguloMacizo = anguloPlAnterior Or anguloMacizo = anguloPlSiguiente Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdMove(sel, puntoOrigen, puntoFinal)
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        Else
            MsgBox("El angulo de la parcela y del macizo no coinciden", vbCritical, aplicacionNombre)
        End If

        Me.Close()
    End Sub

    Private Sub btnSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccion.Click
        '-----------------------------------------------------------
        'PARCELA. definir cual es la polilinea de la parcela a mover
        '-----------------------------------------------------------
      
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar POLILINEA (boton derecho del mouse para finalizar)")
        Dim seleccion As vdSelection = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserSelection
        frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)

        If seleccion Is Nothing Then
            MsgBox("No hay seleccion")
            Me.Activate()
            Exit Sub
        End If
        If seleccion.Count = 0 Then
            MsgBox("No hay seleccion")
            Me.Activate()
            Exit Sub
        End If
        If seleccion.Count > 1 Then
            MsgBox("Hay mas de una entidad seleccionada...")
            Me.Activate()
            Exit Sub
        End If

        If seleccion.Item(0)._TypeName = "vdPolyline" Then
            Dim lapoli As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
            lapoli.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            lapoli.setDocumentDefaults()
            lapoli = CType(seleccion.Item(0), VectorDraw.Professional.vdFigures.vdPolyline)
            idPoliParcela = lapoli.Id
            lblParcela.Text = "Id: " & idPoliParcela.ToString
            habilitarMoverParcela()
            Me.Activate()

        End If

    End Sub

End Class
