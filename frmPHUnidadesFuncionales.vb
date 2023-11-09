Imports System.Windows.Forms

Public Class frmPHUnidadesFuncionales

    Public WithEvents baseControl As VectorDraw.Professional.Control.VectorDrawBaseControl
    Public WithEvents doc As VectorDraw.Professional.vdObjects.vdDocument
    Public fig As VectorDraw.Professional.vdPrimaries.vdFigure = Nothing
    Public bloque As VectorDraw.Professional.vdPrimaries.vdBlock = New VectorDraw.Professional.vdPrimaries.vdBlock
    Dim punto2 As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    Dim punto3 As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    Dim linea1 As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
    Dim lapolilinea As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline

    Structure poligonoDominio
        Dim pertenece As String
        Dim denominacion As String
        Dim superficie As String
    End Structure

    Private Sub frmAtributosPoligonos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        baseControl = frmPpal.VdF.BaseControl
        doc = frmPpal.VdF.BaseControl.ActiveDocument
        formatearGrillaUF()
        formatearGrillaTotales()
        cargarGrillaUF()

    End Sub
#Region "Formatear grilla de Uf y totales"

    Private Sub formatearGrillaTotales()
        dgvPhTotales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        For Each columna As DataGridViewColumn In dgvPhTotales.Columns
            Select Case columna.Name
                Case Is = "totales"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    'columna.HeaderText = "Polig. que" & vbCrLf & "la integran"
                    columna.Width = 120
                Case Is = "cubiertaT"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'columna.HeaderText = "Cubierta"
                    columna.Width = 60
                    columna.DefaultCellStyle.Format = "##,##0.00"
                Case Is = "semicubT"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'columna.HeaderText = "Semi" & vbCrLf & "Cubierta"
                    columna.Width = 50
                    columna.DefaultCellStyle.Format = "##,##0.00"
                Case Is = "descubiertaT"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'columna.HeaderText = "Descubierta"
                    columna.Width = 65
                    columna.DefaultCellStyle.Format = "##,##0.00"
                Case Is = "balconT"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'columna.HeaderText = "Balcón"
                    columna.Width = 50
                    columna.DefaultCellStyle.Format = "##,##0.00"
                Case Is = "totPolT"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'columna.HeaderText = "Total" & vbCrLf & "Poligono"
                    columna.Width = 60
                    columna.DefaultCellStyle.Format = "##,##0.00"
                Case Is = "totUFT"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'columna.HeaderText = "Total" & vbCrLf & "U.F."
                    columna.Width = 60
                    columna.DefaultCellStyle.Format = "##,##0.00"
            End Select
        Next

    End Sub
    Private Sub formatearGrillaUF()

        dgvPH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

        With dgvPH.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .BackColor = Color.LightSteelBlue
            .ForeColor = Color.Cornsilk
            '.Font = New Font(.Font.FontFamily, .Font.Size, _
            ' .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
        End With

        For Each columna As DataGridViewColumn In dgvPH.Columns
            Select Case columna.Name
                Case Is = "uf"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    columna.HeaderText = "UNID." & vbCrLf & "FUNC."
                    columna.Width = 60
                    columna.ReadOnly = False
                Case Is = "poligonos"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    columna.HeaderText = "Polig. que" & vbCrLf & "la integran"
                    columna.Width = 60
                Case Is = "cubierta"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    columna.HeaderText = "Cubierta"
                    columna.Width = 60
                    columna.DefaultCellStyle.Format = "##,##0.00"
                Case Is = "semicub"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    columna.HeaderText = "Semi" & vbCrLf & "Cubierta"
                    columna.Width = 50
                    columna.DefaultCellStyle.Format = "##,##0.00"
                Case Is = "descubierta"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    columna.HeaderText = "Descubierta"
                    columna.Width = 65
                    columna.DefaultCellStyle.Format = "##,##0.00"
                Case Is = "balcon"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    columna.HeaderText = "Balcón"
                    columna.Width = 50
                    columna.DefaultCellStyle.Format = "##,##0.00"
                Case Is = "totPol"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    columna.HeaderText = "Total" & vbCrLf & "Poligono"
                    columna.Width = 60
                    columna.DefaultCellStyle.Format = "##,##0.00"
                Case Is = "totUF"
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    columna.HeaderText = "Total" & vbCrLf & "U.F."
                    columna.Width = 60
                    columna.DefaultCellStyle.Format = "##,##0.00"
            End Select
        Next
        '--->agregar un registro a la grilla:
        'dgvTotales.Rows.Add("Total asignado: ", 0.0, 0.0)

        'dgvEnmiendas.Columns.Item(1).Visible = False
        'dgvSeleccionMultiple.Rows(j).Cells("Tarea").Value = modBuscaDatosAsignar.tarea

        'nuevoValorAtributo = dgvAtt.Rows(e.RowIndex).Cells("AValor").Value 

        'Dim valor As Integer = dgvEnmiendas.Rows.Item(dgvEnmiendas.Rows.GetLastRow(DataGridViewElementStates.Visible) - 1).Cells.Item(0).Value

        'dgvTotales.Rows.Item(0).Cells(1).Value = Format(totalPesos, "##,##0.00")
        'dgvTotales.Rows.Item(0).Cells(2).Value = Format(totalDolares, "##,##0.00")
        'dgvTotales.Rows.Item(1).Cells(1).Value = Format(CDbl(totalPesos), "##,##0.00")
        'dgvTotales.Rows.Item(1).Cells(2).Value = Format(CDbl(totalDolares), "##,##0.00")
        'dgvTotales.Rows.Item(2).Cells(1).Value = Format(CDbl(totalPesos) - CDbl(dgvTotales.Rows.Item(0).Cells(1).Value), "##,##0.00")
        'dgvTotales.Rows.Item(2).Cells(1).Value = Format(CDbl(totalDolares) - CDbl(dgvTotales.Rows.Item(0).Cells(2).Value), "##,##0.00")

        '-->borrar columna:
        'dgvSeleccionMultiple.Columns.Clear()

        '-->agregar columna:
        'dgvSeleccionMultiple.Columns.Add("Tarea", "Tarea")

        'dgvAtt.Columns("AId").ReadOnly = True
        'dgvSeleccionMultiple.Columns("Tarea").Width = 250
        '-------------------------------------------------------
        'Dim AAtributo = New System.Windows.Forms.DataGridViewTextBoxColumn
        'Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        'DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        'AAtributo.DefaultCellStyle = DataGridViewCellStyle1
        '-------------------------------------------------------

        'For Each renglonGrilla As DataGridViewRow In dgvSeleccionMultiple.Rows
        '    If Not renglonGrilla.Cells(0).Value Is Nothing Then

        'dgvAtt.CurrentCell = dgvAtt.Rows(0).Cells.Item(2)

        'dgvConsultaExpte.Rows(Filaseleccionada).Cells("Imprimir").Selected = False

        'dgvResueltos.Rows(i).DefaultCellStyle.BackColor = Color.LightGray

        '    With DataGridView1.ColumnHeadersDefaultCellStyle
        '        .Alignment = DataGridViewContentAlignment.MiddleCenter
        '        .BackColor = Color.LightSteelBlue
        '        .ForeColor = Color.Cornsilk
        '        .Font = New Font(.Font.FontFamily, .Font.Size, _
        '         .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
        '    End With

    End Sub

#End Region

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        If Not lapolilinea Is Nothing Then
            lapolilinea.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If
        Me.Close()
    End Sub

    'Private Sub doc_ActionEnd(ByVal sender As Object, ByVal actionName As String) Handles doc.ActionEnd
    '    '------------------------------------------------------------------------------------------------------------------
    '    ' esto es para volver a activar esta pantalla cuando se minimizó (para realizar alguna accion) y la accion terminó.
    '    ' en ese momento se produce el evento ActionEnd
    '    '------------------------------------------------------------------------------------------------------------------
    '    Me.Activate()
    'End Sub

    'Private Sub baseControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles baseControl.KeyDown
    '    '------------------------------------------------------------------------------------------------------------------
    '    ' esto es para volver a activar esta pantalla cuando se minimizó (para realizar alguna accion) y la accion terminó.
    '    ' en ese momento se produce el evento cuando se oprime una tecla
    '    '------------------------------------------------------------------------------------------------------------------
    '    Me.Activate()
    'End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        '==========================================================================================
        '
        'Botón aceptar. Se dibuja el encabezado de la planilla y los renglones que tenga la grilla.
        'Hay que guardar los datos (la planilla)
        '
        '==========================================================================================
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        seleccionarPunto()
        If Not lapolilinea Is Nothing Then
            lapolilinea.HighLight = False
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If
        Me.Close()
    End Sub

    Public Sub cargarGrillaUF()
        Dim cantUF As Integer = 0

        'busco un bloque que se llama "Planilla". Si existe lo cargo en bloqueLeer
        If Not frmPpal.VdF.BaseControl.ActiveDocument.Blocks.FindName("Planilla") Is Nothing Then

            Dim bloqueLeer As VectorDraw.Professional.vdPrimaries.vdBlock = frmPpal.VdF.BaseControl.ActiveDocument.Blocks.FindName("Planilla")
            'necesito recuperar el handle del vdInsert..
            For Each obj As VectorDraw.Professional.vdObjects.vdObject In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
                If obj Is Nothing Then Exit For
                If obj._TypeName = "vdInsert" Then
                    Dim elVdInsert As VectorDraw.Professional.vdFigures.vdInsert = obj
                    For Each xdata As VectorDraw.Professional.vdObjects.vdXProperty In elVdInsert.XProperties
                        If xdata.Name = "Total unidades funcionales" Then
                            cantUF = xdata.PropValue
                            Exit For
                        End If
                    Next
                End If
            Next
        End If

        dgvPH.Rows.Clear()
        frmPHPoligonoDominio.cmbUf.Items.Clear()
        For a As Integer = 1 To cantUF
            dgvPH.Rows.Add(a.ToString)
            frmPHPoligonoDominio.cmbUf.Items.Add(a)
        Next
        nudCantUF.Value = cantUF

    End Sub

    Public Sub seleccionarPunto()
        '===============================================================================
        ' busco el bloque planilla, si esta lo borro para volver a dibujarlo actualizado
        ' si el bloque no esta, se dibuja por primera vez
        '===============================================================================
        Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
        Dim XRefInsertHandle As ULong = 0

        '---------------------------------------------------------------------------
        'busco un bloque que se llama "Planilla". Si existe lo cargo en bloqueBorrar
        '---------------------------------------------------------------------------
        If Not frmPpal.VdF.BaseControl.ActiveDocument.Blocks.FindName("Planilla") Is Nothing Then

            Dim bloqueBorrar As VectorDraw.Professional.vdPrimaries.vdBlock = frmPpal.VdF.BaseControl.ActiveDocument.Blocks.FindName("Planilla")
            '----------------------------------------------------
            'busco ahora el vdinsert para borrarlo
            'necesito recuperar el handle del vdInsert..
            '----------------------------------------------------
            For Each obj As VectorDraw.Professional.vdObjects.vdObject In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
                If obj Is Nothing Then Exit For
                If obj._TypeName = "vdInsert" Then
                    Dim elVdInsert As VectorDraw.Professional.vdFigures.vdInsert = obj
                    For Each xdata As VectorDraw.Professional.vdObjects.vdXProperty In elVdInsert.XProperties
                        If xdata.Name = "Handle vdInsert" Then
                            elVdInsert.Invalidate()
                            elVdInsert.Deleted = True
                            elVdInsert.Update()
                            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(elVdInsert)
                            Exit For
                        End If
                    Next
                End If
            Next

            '---------------------------------
            'sigo ahora borrando el bloque..
            '---------------------------------
            bloqueBorrar.Deleted = True
            bloqueBorrar.Update()
            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(bloqueBorrar)
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
            limpiarMemoria()
        End If

        '------------------------------------------------------------------------------------------------------
        'obtener un punto para insertar la planilla. La planilla se inserta desde el vertice superior izquierdo
        'el punto es el centro del display
        '------------------------------------------------------------------------------------------------------
        punto = frmPpal.VdF.BaseControl.ActiveDocument.ViewCenter()
        'frmPpal.VdF.BaseControl.ActiveDocument.Prompt("Seleccionar posicion vertice superior izquierdo de la planilla..")
        'ret = frmPpal.VdF.BaseControl.ActiveDocument.ActionUtility.getUserPoint(punto)
        'frmPpal.VdF.BaseControl.ActiveDocument.Prompt(Nothing)
        'If ret = VectorDraw.Actions.StatusCode.Success Then
        '    dibujarPlanillaUF(punto)
        'Else
        '    Exit Sub
        'End If

        '------------------------------------------
        ' con el punto obtenido dibujar la planilla
        '------------------------------------------
        dibujarPlanillaUF(punto)

    End Sub
#Region "Limpiar memoria"
    Public Sub limpiarMemoria()
        'NOTE : In big drawings this will take some time.
        Dim ByteArrayDoc As Object = Nothing
        Dim memorystream As System.IO.MemoryStream = frmPpal.VdF.BaseControl.ActiveDocument.ToStream()
        'Document is saved to memory in a ByteArray object
        If (memorystream Is Nothing) Then
            'MessageBox.Show("Method Failed", "Clearing Memory")
            Exit Sub
        End If

        ByteArrayDoc = memorystream.ToArray()
        Dim size As Long = memorystream.Length
        memorystream.Close()
        'Document is saved in memory in the ByteArray.
        Dim TempA As Byte() = ByteArrayDoc
        Dim memorystream2 As System.IO.MemoryStream = New System.IO.MemoryStream(TempA)
        memorystream2.Position = 0
        frmPpal.VdF.BaseControl.ActiveDocument.LoadFromMemory(memorystream2)
        memorystream2.Close()
        'MessageBox.Show("Deleted and Removed items doesn't exist any more. Undo/Redo doesn't work. \n\r \n\rNote: In big drawings this might take some time.", "Memory cleared !!!")
        'Document is "LOADED" again from the ByteArray in the memory.
    End Sub

#End Region
    
    Private Sub dibujarPlanillaUF(ByVal punto1 As VectorDraw.Geometry.gPoint)
        '==================================
        '
        ' dibujar la planilla de las uf
        '
        '==================================

        '---------------------------------------------------
        ' ENCABEZADO - dibujar solo el encabezado
        '---------------------------------------------------
        dibujarEncabezadoUF(punto1)
        '---------------------------------------------------------------
        ' RENGLONES - si la grilla de las uf tiene renglones, dibujarlos
        '---------------------------------------------------------------
        If dgvPH.Rows.Count > 0 Then
            dibujarUF(punto1)
        End If

        '---------------------------------------------------------------------------------------------
        'luego de dibujar la planilla, con o sin renglones, agregar un bloque con la planilla dibujada
        'a la colección de bloques del dibujo.
        '---------------------------------------------------------------------------------------------
        frmPpal.VdF.BaseControl.ActiveDocument.Blocks.AddItem(bloque)

        '----------------------------------------------------------------------------------------------------------
        ' Insertar el bloque definido
        '----------------------------------------------------------------------------------------------------------
        Dim insertar As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert
        insertar.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        insertar.setDocumentDefaults()

        Dim xProp As VectorDraw.Professional.vdObjects.vdXProperty
        xProp = New VectorDraw.Professional.vdObjects.vdXProperty
        xProp.Name = "Total unidades funcionales"
        xProp.PropValue = nudCantUF.Value.ToString
        insertar.XProperties.AddItem(xProp) '<--------------------------------------------------- pegar la xprop al insert

        xProp = New VectorDraw.Professional.vdObjects.vdXProperty
        xProp.Name = "Handle vdInsert"
        xProp.PropValue = insertar.Handle
        insertar.XProperties.AddItem(xProp) '<--------------------------------------------------- pegar la xprop al insert

        'xProp = New VectorDraw.Professional.vdObjects.vdXProperty
        'xProp.Name = ""

        insertar.Block = frmPpal.VdF.BaseControl.ActiveDocument.Blocks.FindName("Planilla") '<--- definir el bloque del insert
        insertar.InsertionPoint = punto1 '<------------------------------------------------------ punto de insercino del insert
        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(insertar)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        '----------------------------------------------------------------------------------------

    End Sub

    Private Sub dibujarEncabezadoUF(ByVal punto1 As VectorDraw.Geometry.gPoint)
        '90  = VectorDraw.Geometry.Globals.HALF_PI
        '180 = VectorDraw.Geometry.Globals.PI
        '270 = VectorDraw.Geometry.Globals.VD_270PI
        '360 = VectorDraw.Geometry .Globals .VD_TWOPI

        bloque.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        bloque.setDocumentDefaults()
        bloque.Name = "Planilla"
        bloque.Origin = punto1

        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()

        Dim polilinea As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline
        polilinea.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        polilinea.setDocumentDefaults()
        polilinea.VertexList.Add(punto1)
        '------
        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto1.Polar(0.0, 180.0)
        polilinea.VertexList.Add(New VectorDraw.Geometry.gPoint(punto2))
        '------
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, 30.0)
        polilinea.VertexList.Add(New VectorDraw.Geometry.gPoint(punto3))
        '------
        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto3.Polar(VectorDraw.Geometry.Globals.PI, 180)
        polilinea.VertexList.Add(New VectorDraw.Geometry.gPoint(punto2))
        '------
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.HALF_PI, 30)
        polilinea.VertexList.Add(New VectorDraw.Geometry.gPoint(punto3))
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(polilinea)
        bloque.Entities.AddItem(polilinea)


        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto1.Polar(0.0, 30.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, 30.0)
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)


        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto1.Polar(0.0, 60.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, 30.0)
        linea1 = New VectorDraw.Professional.vdFigures.vdLine
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)


        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto3.Polar(VectorDraw.Geometry.Globals.HALF_PI, 15.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(0, 120.0)
        linea1 = New VectorDraw.Professional.vdFigures.vdLine
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)


        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto3.Polar(VectorDraw.Geometry.Globals.PI, 100.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, 15.0)
        linea1 = New VectorDraw.Professional.vdFigures.vdLine
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)

        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto3.Polar(0.0, 20.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.HALF_PI, 15.0)
        linea1 = New VectorDraw.Professional.vdFigures.vdLine
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)


        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto3.Polar(0.0, 20.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, 15.0)
        linea1 = New VectorDraw.Professional.vdFigures.vdLine
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)


        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto3.Polar(0.0, 20.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.HALF_PI, 15.0)
        linea1 = New VectorDraw.Professional.vdFigures.vdLine
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)


        punto2 = New VectorDraw.Geometry.gPoint
        punto2 = punto3.Polar(0.0, 20.0)
        punto3 = New VectorDraw.Geometry.gPoint
        punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, 15.0)
        linea1 = New VectorDraw.Professional.vdFigures.vdLine
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        linea1.StartPoint = punto2
        linea1.EndPoint = punto3
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
        bloque.Entities.AddItem(linea1)


        Dim textoM As VectorDraw.Professional.vdFigures.vdMText = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 15.0, punto1.y - 15.0)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 25.0
        textoM.TextString = "UNIDAD FUNCIONAL (Desig)"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 45.0, punto1.y - 15.0)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 25.0
        textoM.TextString = "POLIGONOS QUE LA INTEGRAN"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 120.0, punto1.y - 7.5)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 120.0
        textoM.TextString = "SUPERFICIES"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 70.0, punto1.y - 22.5)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 20.0
        textoM.TextString = "CUBIERTA"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 90.0, punto1.y - 22.5)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 20.0
        textoM.TextString = "\W0.70;SEMICUBIERTA"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 110.0, punto1.y - 22.5)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 20.0
        textoM.TextString = "\W0.70;DESCUBIERTA"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 130.0, punto1.y - 22.5)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 20.0
        textoM.TextString = "BALCON"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 150.0, punto1.y - 22.5)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 20.0
        textoM.TextString = "\W0.70;TOTAL POLIGONO"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)


        textoM = New VectorDraw.Professional.vdFigures.vdMText
        textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        textoM.setDocumentDefaults()
        textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto1.x + 170.0, punto1.y - 22.5)
        textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        textoM.BoxWidth = 20.0
        textoM.TextString = "\W0.70;TOTAL UNIDAD FUNCIONAL"
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
        bloque.Entities.AddItem(textoM)

        'frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)

    End Sub

    Private Sub dibujarUF(ByVal punto1 As VectorDraw.Geometry.gPoint)
        '----------------------------------------------------------------------------------------------------------------------------
        'Si llegue hasta aca es porque hay uf, por lo menos una!
        '
        'revisar las polilineas del dibujo que tengan tres xproperties y ver si una de ellas se llama "Denominacion".
        'las que cumplan esto, contarlas y guardarlas en una variable por cada uf (o un vector..)
        '
        'en las ufs que no tiene poligonos asignados, dibujar un renglon simple y rellenar valores con rayitas
        '
        'en las ufs que si tienen poligonos asignados, leer los valores de las superficies y ponerlos en los casilleros correspondientes
        'y si tiene mas de un poligono asignado, agregar los renglones que correspondan.
        '----------------------------------------------------------------------------------------------------------------------------

        Dim alPoligonos As New ArrayList
        Dim pol As New poligonoDominio


    
        Dim moduloAltura As Integer = 10, modulo As Integer = 0
        For i As Integer = 1 To dgvPH.Rows.Count
            If i = 1 Then
                modulo = 0
            Else
                modulo = i * moduloAltura - moduloAltura
            End If

            '--------------------
            'izq columna uno: UF
            '--------------------
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto1.Polar(VectorDraw.Geometry.Globals.VD_270PI, 30.0 + modulo)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            Dim textoM As VectorDraw.Professional.vdFigures.vdMText = New VectorDraw.Professional.vdFigures.vdMText
            textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            textoM.setDocumentDefaults()
            textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto2.x + 15.0, punto2.y - moduloAltura / 2)
            textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
            textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
            textoM.BoxWidth = 25.0
            textoM.TextString = "U.F. " & i.ToString
            'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
            bloque.Entities.AddItem(textoM)

            '--------------------------
            'derecha columna uno: UF
            '--------------------------
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 30.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.HALF_PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            'Dim cartel As String
            'Dim pase As Integer = 0
            'For j As Integer = 1 To vector(j) 'la cantidad de poligonos que tiene esta uf..


            '------------------------------------------------
            'derecha. columna dos: POLIGONOS QUE LA INTEGRAN
            '------------------------------------------------
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 30.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            textoM = New VectorDraw.Professional.vdFigures.vdMText
            textoM.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            textoM.setDocumentDefaults()
            textoM.InsertionPoint = New VectorDraw.Geometry.gPoint(punto2.x - 15.0, punto2.y - moduloAltura / 2)
            textoM.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
            textoM.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
            textoM.BoxWidth = 25.0
            'For kk As Integer = 0 To UBound(matrizValores, 1)
            '    If CInt(matrizValores(kk, 0)) = i Then
            '        If pase = 0 Then
            '            cartel = matrizValores(kk, 2)
            '            pase = pase + 1
            '            Exit For
            '        End If
            '    End If
            'Next
            textoM.TextString = "poligono xx" 'cartel
            'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoM)
            bloque.Entities.AddItem(textoM)


            '------------------------------------
            'derecha. columna tres
            'esta columna es la de sup. CUBIERTA
            '------------------------------------
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 20.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.HALF_PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)


            '-------------------------------------
            'derecha. columna cuatro: SEMICUBIERTA
            '-------------------------------------
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 20.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            '-----------------------------------
            'derecha. columna cinco: DESCUBIERTA
            '-----------------------------------
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 20.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.HALF_PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)


            '-------------------------------
            'derecha. columna seis: BALCON
            '-------------------------------
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 20.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            '--------------------------------------
            'derecha. columna siete: TOTAL POLIGONO
            '--------------------------------------
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 20.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.HALF_PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)


            '-------------------------------
            'derecha. columna ocho: TOTAL UF
            '-------------------------------
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3.Polar(0.0, 20.0)
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto2.Polar(VectorDraw.Geometry.Globals.VD_270PI, moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)

            '-----------------------------------------------------------------------------------
            'linea de cierre entre el borde derecho de la planilla, a la derecha de "Total uf" y
            'el borde izquierdo de la planilla a la izq. de "UF"
            '-----------------------------------------------------------------------------------
            punto2 = New VectorDraw.Geometry.gPoint
            punto2 = punto3
            punto3 = New VectorDraw.Geometry.gPoint
            punto3 = punto1.Polar(VectorDraw.Geometry.Globals.VD_270PI, 30 + modulo + moduloAltura)
            linea1 = New VectorDraw.Professional.vdFigures.vdLine
            linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            linea1.setDocumentDefaults()
            linea1.StartPoint = punto2
            linea1.EndPoint = punto3
            bloque.Entities.AddItem(linea1)
        Next
        'Next

    End Sub


    'revisar
    'Private Sub btnCancelarAtributos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    rbCubierta.Checked = False
    '    rbBalcon.Checked = False
    '    rbDescubierta.Checked = False
    '    rbSemicubierta.Checked = False
    '    'txtDenominacion.Text = ""
    '    cmbPoligonosDominio.Text = ""
    '    lblSuperficieSeleccionado.Text = "--"
    'End Sub


    'revisar
    'Private Sub btnCancelaAttPolDom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    lblPoligonoDominioSeleccionado.Text = "--"
    '    txtPolDominioNombre.Text = ""
    '    lblUfUcOwner.Text = ""
    '    If Not lapolilinea Is Nothing Then
    '        lapolilinea.HighLight = False
    '        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
    '    End If
    'End Sub

    'revisar
    'Private Sub btnAgregaAGrilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Select Case TabControl1.SelectedTab.Name
    '        Case Is = "defUf"
    '            If CInt(nudCantUF.Value) = 0 Then Exit Sub
    '            Dim cantidadDeFilasExistentes As Integer = dgvPH.Rows.Count
    '            Dim cantidadFilasAgregar As Integer = nudCantUF.Value - cantidadDeFilasExistentes

    '            Select Case cantidadFilasAgregar
    '                Case Is < 0
    '                    'nada, puse en el nud menos uf's de las que hay
    '                    Exit Sub
    '                Case Is = 0
    '                    'puse la misma cantidad de uf's en el nud que las que ya hay en la grilla
    '                    Exit Sub
    '                Case Is > 0
    '                    'puse en el nud mas uf's de las que existen. 
    '                    'agregar la diferencia. 
    '                    'la diferencia es "cantidadFilasAgregar"
    '                    If cantidadDeFilasExistentes = 0 Then
    '                        For a As Integer = 1 To cantidadFilasAgregar
    '                            dgvPH.Rows.Add(CStr(a))
    '                        Next
    '                    Else
    '                        For a As Integer = cantidadDeFilasExistentes + 1 To nudCantUF.Value
    '                            dgvPH.Rows.Add(CStr(a))
    '                        Next
    '                    End If
    '            End Select
    '            actualizarCmbUnidadesFuncionales()

    '        Case Is = "poligono"
    '            'pegarDatosPoligonoDominio es el procedimiento para pegarle datos a la polilinea
    '            If Not pegarDatosPoligonoDominio() Then Exit Sub
    '            'el nombre del pol. dom. esta en "txtPolDominioNombre.text"
    '            'a que uf pertenece esta en el combo "cmbUfUc"
    '            'el area del poligono de dominio esta en "lblPoligonoDeDominioSeleccionado.text"
    '            For c As Integer = 0 To dgvPH.Rows.Count - 1
    '                If dgvPH.Rows(c).Cells(0).Value = cmbUfUc.Text Then
    '                    If dgvPH.Rows(c).Cells(1).Value = "" Then
    '                        'si la fila de la grilla esta vacia cargo el texto en esa fila
    '                        dgvPH.Rows(c).Cells(1).Value = txtPolDominioNombre.Text
    '                        dgvPH.Rows(c).Cells(6).Value = lblPoligonoDominioSeleccionado.Text
    '                    Else
    '                        'si la fila de la grilla no esta vacia, agrego una fila y cargo la info
    '                        dgvPH.Rows.Add(dgvPH.Rows(c).Cells(0).Value, txtPolDominioNombre.Text, "", "", "", "", lblPoligonoDominioSeleccionado.Text)
    '                    End If
    '                    Exit For
    '                End If
    '            Next
    '            calcularTotalesUF()
    '        Case Is = "superficies"
    '            MsgBox("superficies")
    '        Case Is = "dibujar"
    '            MsgBox("dibujar")
    '    End Select
    '    dgvPH.Update()
    '    dgvPH.Refresh()
    'End Sub

    Private Sub calcularTotalesUF()
        Dim cubiertaTotal, descubiertaTotal, semiCubiertaTotal, balconTotal, poligonoTotal, ufTotal As Double
        For Each fila As DataGridViewRow In dgvPH.Rows

            If fila.Cells("cubierta").Value <> "" Then
                cubiertaTotal = cubiertaTotal + fila.Cells("cubierta").Value
            End If

            If fila.Cells("semicub").Value <> "" Then
                semiCubiertaTotal = semiCubiertaTotal + fila.Cells("semicub").Value
            End If

            If fila.Cells("descubierta").Value <> "" Then
                descubiertaTotal = descubiertaTotal + fila.Cells("descubierta").Value
            End If

            If fila.Cells("balcon").Value <> "" Then
                balconTotal = balconTotal + fila.Cells("balcon").Value
            End If

            If fila.Cells("totPol").Value <> "" And fila.Cells("totPol").Value <> "--" Then
                poligonoTotal = poligonoTotal + fila.Cells("totPol").Value
            End If

            If fila.Cells("totUF").Value <> "" Then
                ufTotal = ufTotal + fila.Cells("totUF").Value
            End If

        Next
        If dgvPhTotales.Rows.Count = 0 Then
            dgvPhTotales.Rows.Add("Totales", cubiertaTotal, semiCubiertaTotal, descubiertaTotal, balconTotal, poligonoTotal, ufTotal)
        Else
            dgvPhTotales.Rows(0).Cells("cubiertaT").Value = cubiertaTotal
            dgvPhTotales.Rows(0).Cells("semicubT").Value = semiCubiertaTotal
            dgvPhTotales.Rows(0).Cells("descubiertaT").Value = descubiertaTotal
            dgvPhTotales.Rows(0).Cells("balconT").Value = balconTotal
            dgvPhTotales.Rows(0).Cells("totPolT").Value = poligonoTotal
            dgvPhTotales.Rows(0).Cells("totUFT").Value = ufTotal
        End If

    End Sub

    'revisar
    'Private Sub dgvPH_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPH.CellEndEdit
    '    actualizarCmbUnidadesFuncionales()
    'End Sub

    Private Sub btnAgregaAGrilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregaAGrilla.Click
        'Select Case TabControl1.SelectedTab.Name
        '    Case Is = "defUf"
        If CInt(nudCantUF.Value) = 0 Then Exit Sub
        Dim cantidadDeFilasExistentes As Integer = dgvPH.Rows.Count
        Dim cantidadFilasAgregar As Integer = nudCantUF.Value - cantidadDeFilasExistentes

        Select Case cantidadFilasAgregar
            Case Is < 0
                'nada, puse en el nud menos uf's de las que hay
                Exit Sub
            Case Is = 0
                'puse la misma cantidad de uf's en el nud que las que ya hay en la grilla
                Exit Sub
            Case Is > 0
                'puse en el nud mas uf's de las que existen. 
                'agregar la diferencia. 
                'la diferencia es "cantidadFilasAgregar"
                If cantidadDeFilasExistentes = 0 Then
                    For a As Integer = 1 To cantidadFilasAgregar
                        dgvPH.Rows.Add(CStr(a))
                    Next
                Else
                    For a As Integer = cantidadDeFilasExistentes + 1 To nudCantUF.Value
                        dgvPH.Rows.Add(CStr(a))
                    Next
                End If
        End Select
        actualizarCmbUnidadesFuncionales()

        '    Case Is = "poligono"
        '        'pegarDatosPoligonoDominio es el procedimiento para pegarle datos a la polilinea
        '        If Not pegarDatosPoligonoDominio() Then Exit Sub
        '        'el nombre del pol. dom. esta en "txtPolDominioNombre.text"
        '        'a que uf pertenece esta en el combo "cmbUfUc"
        '        'el area del poligono de dominio esta en "lblPoligonoDeDominioSeleccionado.text"
        '        For c As Integer = 0 To dgvPH.Rows.Count - 1
        '            If dgvPH.Rows(c).Cells(0).Value = cmbUfUc.Text Then
        '                If dgvPH.Rows(c).Cells(1).Value = "" Then
        '                    'si la fila de la grilla esta vacia cargo el texto en esa fila
        '                    dgvPH.Rows(c).Cells(1).Value = txtPolDominioNombre.Text
        '                    dgvPH.Rows(c).Cells(6).Value = lblPoligonoDominioSeleccionado.Text
        '                Else
        '                    'si la fila de la grilla no esta vacia, agrego una fila y cargo la info
        '                    dgvPH.Rows.Add(dgvPH.Rows(c).Cells(0).Value, txtPolDominioNombre.Text, "", "", "", "", lblPoligonoDominioSeleccionado.Text)
        '                End If
        '                Exit For
        '            End If
        '        Next
        '        calcularTotalesUF()
        '    Case Is = "superficies"
        '        MsgBox("superficies")
        '    Case Is = "dibujar"
        '        MsgBox("dibujar")
        'End Select
        'dgvPH.Update()
        'dgvPH.Refresh()
    End Sub

    Private Sub btnSacaDeGrilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSacaDeGrilla.Click
        dgvPH.Rows.Remove(dgvPH.CurrentRow)
        nudCantUF.Value = dgvPH.Rows.Count
        actualizarCmbUnidadesFuncionales()
    End Sub

    Private Sub actualizarCmbUnidadesFuncionales()
        frmPHPoligonoDominio.cmbUf.Items.Clear()
        For b As Integer = 0 To dgvPH.Rows.Count - 1
            frmPHPoligonoDominio.cmbUf.Items.Add(dgvPH.Rows(b).Cells(0).Value)
        Next
    End Sub

End Class
