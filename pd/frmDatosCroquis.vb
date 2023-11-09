Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports ADOX

Public Class frmDatosCroquis

    Dim tblPlCoord As New DataTable
    Dim tblMzCoord As New DataTable
    Dim tblParcela As New DataTable
    Dim tblMacizo As New DataTable
    Dim poly As VectorDraw.Professional.vdFigures.vdPolyline


    Private Sub frmDatosCroquis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '----------------------------------------------------------------
        '
        'cargar las entidades graficas que correspondan al trabajo activo
        ' la parcela y el macizo..
        '----------------------------------------------------------------
        If conexionMdb Is Nothing Then
            If Not conectar() Then
                MsgBox("No se pudo establecer la conexion.")
                Exit Sub
            End If
        ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
            If Not conectar() Then
                MsgBox("No se pudo establecer la conexion.")
                Exit Sub
            End If
        End If

        Dim tblTrabajoEntidades As New DataTable
        Dim sqlId As String = "SELECT * FROM trabajoEntidad WHERE idTrabajo =" & identificadorTrabajo
        Dim cmdId As New OleDbCommand(sqlId, conexionMdb)
        Dim da As New OleDbDataAdapter(cmdId)
        da.Fill(tblTrabajoEntidades)
        If tblTrabajoEntidades.Rows.Count = 0 Then
            MsgBox("Este trabajo no tiene entidades.")
            Exit Sub
        End If

        Dim sqlMz As String
        cmdId.Connection = conexionMdb

        'primero buscar la parcela:
        For Each regEntidad As DataRow In tblTrabajoEntidades.Rows
            'recorro las entidades de este trabajo...
            sqlId = "Select * from entidades where idEntidad =" & regEntidad.Item("idEntidad") & " and tipoEntidadLogica ='Parcela'"
            cmdId.CommandText = sqlId
            da.SelectCommand = cmdId
            da.Fill(tblParcela)
            If tblParcela.Rows.Count > 0 Then
                Exit For
            End If
        Next

        'buscar el macizo:
        For Each regEntidad As DataRow In tblTrabajoEntidades.Rows
            'recorro las entidades de este trabajo...
            sqlMz = "Select * from entidades where idEntidad =" & regEntidad.Item("idEntidad") & " and tipoEntidadLogica ='Macizo'"
            cmdId.CommandText = sqlMz
            da.SelectCommand = cmdId
            da.Fill(tblMacizo)
            If tblMacizo.Rows.Count > 0 Then
                Exit For
            End If
        Next

        Select Case tblParcela.Rows.Count
            Case Is = 0
                lblParcela.Text = "No hay parcela definida"
                nudEscalaPl.Value = 0.0
            Case Is = 1
                'lblParcela.Text = "Id parcela: " & tblParcela.Rows(0).Item("idEntidad").ToString
                lblParcela.Text = ""
                sqlId = "SELECT * FROM coordenadas WHERE idEntidad =" & tblParcela.Rows(0).Item("idEntidad").ToString
                cmdId.CommandText = sqlId
                da.SelectCommand = cmdId
                da.Fill(tblPlCoord)
                'dgvPl.DataSource = tblPlCoord
                nudEscalaPl.Value = 1.0
            Case Is > 1
                lblParcela.Text = "Hay mas de una parcela principal definida..."
        End Select

        Select Case tblMacizo.Rows.Count
            Case Is = 0
                lblMacizo.Text = "No hay macizo definido"
            Case Is = 1
                'lblMacizo.Text = "Id Macizo: " & tblMacizo.Rows(0).Item("idEntidad").ToString
                lblMacizo.Text = ""
                sqlId = "SELECT * FROM coordenadas WHERE idEntidad =" & tblMacizo.Rows(0).Item("idEntidad").ToString
                cmdId.CommandText = sqlId
                da.SelectCommand = cmdId
                da.Fill(tblMzCoord)
                'dgvMz.DataSource = tblMzCoord
            Case Is > 1
                lblMacizo.Text = "Hay mas de un macizo definido..."
        End Select

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If borrarCroquis() Then
            guardarCroquis()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            MsgBox("Croquis guardado ok!", vbInformation, "Plano Digital")
            frmPpal.blancoNegro()

        Else
            MsgBox("No se pudo guardar el croquis")
        End If
        
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'Private Sub dgvPl_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)

    '    dgvPl.Columns("x").DisplayIndex = 2
    '    dgvPl.Columns("x").Width = 60
    '    dgvPl.Columns("x").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    dgvPl.Columns("x").HeaderText = "Coord.X"

    '    dgvPl.Columns("y").DisplayIndex = 3
    '    dgvPl.Columns("y").Width = 60
    '    dgvPl.Columns("y").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    dgvPl.Columns("y").HeaderText = "Coord.Y"

    '    dgvPl.Columns("idEntidad").Visible = False
    '    dgvPl.Columns("z").Visible = False
    '    dgvPl.Columns("angulo").Visible = False
    '    'dgvPl.Columns.RemoveAt(4)

    '    dgvPl.Columns.Add("nro", "Nro")
    '    dgvPl.Columns("nro").Width = 35
    '    dgvPl.Columns("nro").DisplayIndex = 1
    '    Dim contador As Integer = 1
    '    For Each fila As DataGridViewRow In dgvPl.Rows
    '        fila.Cells("nro").Value = contador
    '        contador = contador + 1
    '    Next
    'End Sub
    'Private Sub dgvMz_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
    '    dgvMz.Columns("x").DisplayIndex = 2
    '    dgvMz.Columns("x").Width = 60
    '    dgvMz.Columns("x").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    dgvMz.Columns("x").HeaderText = "Coord.X"

    '    dgvMz.Columns("y").DisplayIndex = 3
    '    dgvMz.Columns("y").Width = 60
    '    dgvMz.Columns("y").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    dgvMz.Columns("y").HeaderText = "Coord.Y"

    '    dgvMz.Columns("idEntidad").Visible = False
    '    dgvMz.Columns("z").Visible = False
    '    dgvMz.Columns("angulo").Visible = False
    '    'dgvPl.Columns.RemoveAt(4)

    '    dgvMz.Columns.Add("nro", "Nro")
    '    dgvMz.Columns("nro").Width = 30
    '    dgvMz.Columns("nro").DisplayIndex = 1
    '    Dim contador As Integer = 1
    '    For Each fila As DataGridViewRow In dgvMz.Rows
    '        fila.Cells("nro").Value = contador
    '        contador = contador + 1
    '    Next

    'End Sub

    Private Sub btnPlEscala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlEscala.Click
        '--------------------------------------------------------------------------------------------------------------
        '
        ' Escaleo
        '
        '--------------------------------------------------------------------------------------------------------------
        If tblParcela.Rows.Count = 0 Then
            MsgBox("No hay parcela definida", vbInformation, "Plano Digital")
            Exit Sub
        End If

        Dim mat As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
        mat.ScaleMatrix(nudEscalaPl.Value, nudEscalaPl.Value, 0)


        '----------------------------------
        ' transformacion para una polilinea
        '----------------------------------
        For Each figura As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If figura._TypeName = "vdPolyline" Then
                poly = figura
                If poly.ToolTip.ToString.IndexOf(tblParcela.Rows(0).Item(0).ToString) > 0 Then
                    'poly.PenWidth = 2.5
                    'poly.HighLight = True
                    poly.Transformby(mat)
                End If
            End If
        Next



        '--------------------------
        ' linea
        '--------------------------
        Dim linea1 As New VectorDraw.Professional.vdFigures.vdLine()
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        For Each figura As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If figura._TypeName = "vdLine" Then
                linea1 = figura
                If linea1.ToolTip = "segmentoPl" Or InStr(linea1.ToolTip, "muro") Then
                    'linea1.PenWidth = 2.5
                    'linea1.HighLight = True
                    linea1.Transformby(mat)
                End If
            End If
        Next


        '--------------------------------
        ' circulo
        '--------------------------------
        Dim circulo As New VectorDraw.Professional.vdFigures.vdCircle()
        circulo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        circulo.setDocumentDefaults()
        For Each figura As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If figura._TypeName = "vdCircle" Then
                circulo = figura
                'circulo.PenWidth = 2.5
                'circulo.HighLight = True
                circulo.Transformby(mat)
            End If
        Next


        '--------------------------------------
        ' texto
        '--------------------------------------
        Dim texto As New VectorDraw.Professional.vdFigures.vdText()
        texto.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        texto.setDocumentDefaults()
        For Each figura As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If figura._TypeName = "vdText" And (figura.ToolTip = "idParcela" Or _
                                                figura.ToolTip = "txtMedidaLado" Or _
                                                figura.ToolTip = "txtNroVertice" Or _
                                                figura.ToolTip = "txMedidaLadoPl" Or _
                                                figura.ToolTip.Contains("Medida lado parcela")) Then
                texto = figura
                'circulo.PenWidth = 2.5
                'texto.HighLight = True
                texto.Transformby(mat)
            End If
        Next



        '----------------------------------------
        ' bloque
        '----------------------------------------
        Dim bloqueInsertado As New VectorDraw.Professional.vdFigures.vdInsert
        bloqueInsertado.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        bloqueInsertado.setDocumentDefaults()
        For Each figura As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If figura._TypeName = "vdInsert" Then
                bloqueInsertado = figura
                If InStr(bloqueInsertado.Block.Name, "idParcela") > 0 Then
                    'bloqueInsertado.HighLight = True
                    bloqueInsertado.Transformby(mat)
                End If
            End If
        Next
        bloqueInsertado = Nothing


        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)


    End Sub

    Private Sub btnPlMover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlMover.Click
        '--------------------------------------------------------------------------------------------------------------
        '
        ' Mover
        '
        '--------------------------------------------------------------------------------------------------------------
        If tblParcela.Rows.Count = 0 Then
            MsgBox("No hay parcela definida", vbInformation, "Plano Digital")
            Exit Sub
        End If

        '------------------------
        ' polilinea
        '------------------------
        For Each figura As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If figura._TypeName = "vdPolyline" Then
                poly = figura
                If poly.ToolTip.ToString.IndexOf(tblParcela.Rows(0).Item(0).ToString) > 0 Then
                    'poly.PenWidth = 2.5
                    'poly.HighLight = True
                    Exit For
                Else
                    poly = Nothing
                End If
            End If
        Next

        Dim seleccion As New VectorDraw.Professional.vdCollections.vdSelection
        seleccion.AddItem(poly, True, VectorDraw.Professional.vdCollections.vdSelection.AddItemCheck.Nochecking)

        'buscar si hay segmentos dibujados, para arrastrarlos con la polilinea de la parcela:
        Dim linea1 As New VectorDraw.Professional.vdFigures.vdLine()
        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        linea1.setDocumentDefaults()
        For Each figura As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If figura._TypeName = "vdLine" Then
                linea1 = figura
                If linea1.ToolTip = "segmentoPl" Or InStr(linea1.ToolTip, "muro") Then
                    'linea1.PenWidth = 2.5
                    'linea1.HighLight = True
                    seleccion.AddItem(linea1, True, VectorDraw.Professional.vdCollections.vdSelection.AddItemCheck.Nochecking)
                Else
                    linea1 = Nothing
                End If
            End If
        Next

        'buscar si hay circulos con id's para arrastrarlos con la polilinea de la parcela:
        Dim circulo As New VectorDraw.Professional.vdFigures.vdCircle()
        circulo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        circulo.setDocumentDefaults()
        For Each figura As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If figura._TypeName = "vdCircle" Then
                circulo = figura
                'circulo.PenWidth = 2.5
                'circulo.HighLight = True
                seleccion.AddItem(circulo, True, VectorDraw.Professional.vdCollections.vdSelection.AddItemCheck.Nochecking)
            End If
        Next

        'buscar si hay textos
        Dim texto As New VectorDraw.Professional.vdFigures.vdText()
        texto.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        texto.setDocumentDefaults()
        For Each figura As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If figura._TypeName = "vdText" And (figura.ToolTip = "idParcela" Or _
                                                figura.ToolTip = "txtMedidaLado" Or _
                                                figura.ToolTip = "txtNroVertice" Or _
                                                figura.ToolTip = "txMedidaLadoPl" Or _
                                                figura.ToolTip.Contains("Medida lado parcela")) Then
                texto = figura
                'circulo.PenWidth = 2.5
                'texto.HighLight = True
                seleccion.AddItem(texto, True, VectorDraw.Professional.vdCollections.vdSelection.AddItemCheck.Nochecking)
            End If
        Next

        'busco un bloque que se llama "idParcelaN". Con "n" igual al numero de parcela, en este caso "1"
        'If Not frmPpal.VdF.BaseControl.ActiveDocument.Blocks.FindName("idParcela1") Is Nothing Then
        '    Dim bloqueLeer As VectorDraw.Professional.vdPrimaries.vdBlock = frmPpal.VdF.BaseControl.ActiveDocument.Blocks.FindName("idParcela1")
        '    For Each obj As VectorDraw.Professional.vdObjects.vdObject In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
        '        If obj Is Nothing Then Exit For
        '        If obj._TypeName = "vdInsert" Then
        '            Dim elVdInsert As VectorDraw.Professional.vdFigures.vdInsert = obj
        '            If elVdInsert.Block.Name = "idParcela1" Then
        '                elVdInsert.HighLight = True
        '                seleccion.AddItem(elVdInsert, True, VectorDraw.Professional.vdCollections.vdSelection.AddItemCheck.Nochecking)
        '            End If
        '        End If
        '    Next
        'End If
        Dim bloqueInsertado As New VectorDraw.Professional.vdFigures.vdInsert
        bloqueInsertado.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        bloqueInsertado.setDocumentDefaults()
        For Each figura As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If figura._TypeName = "vdInsert" Then
                bloqueInsertado = figura
                If InStr(bloqueInsertado.Block.Name, "idParcela") > 0 Then
                    'bloqueInsertado.HighLight = True
                    seleccion.AddItem(bloqueInsertado, True, VectorDraw.Professional.vdCollections.vdSelection.AddItemCheck.Nochecking)
                End If
            End If
        Next
        bloqueInsertado = Nothing


        Dim puntoPl As New VectorDraw.Geometry.gPoint
        puntoPl.x = poly.VertexList.Item(0).x 'CDbl(tblPlCoord.Rows(0).Item(1))
        puntoPl.y = poly.VertexList.Item(0).y 'CDbl(tblPlCoord.Rows(0).Item(2))
        puntoPl.z = 0.0
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdMove(seleccion, puntoPl, "USER")
    End Sub

    Private Sub btnDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.Click
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Undo("")

    End Sub

    Private Sub btnBorrarCroquis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarCroquis.Click
        If borrarCroquis() Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdErase("ALL")
            abrirTrabajo()
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        Else
            MsgBox("No se pudo actualizar el croquis")
        End If
        
    End Sub
End Class
