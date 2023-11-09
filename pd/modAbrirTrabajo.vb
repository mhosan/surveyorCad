Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports ADOX
Imports System.Linq
Imports System
Imports System.Linq.Expressions
Imports System.Collections.Generic
Imports System.Data.Common
Imports System.Globalization
Imports System.Data.DataSetExtensions


Module modAbrirTrabajo

    Dim poli As VectorDraw.Professional.vdFigures.vdPolyline
    Dim circulo As VectorDraw.Professional.vdFigures.vdCircle
    Dim texto As VectorDraw.Professional.vdFigures.vdText
    Dim linea As VectorDraw.Professional.vdFigures.vdLine

    Public Sub abrirTrabajo()

        If identificadorTrabajo = 0 Then
            MsgBox("No hay trabajo activo.", vbInformation, "Plano digital")
            Exit Sub
        Else
            idTrabajo = identificadorTrabajo  '<----------trabajo activo
        End If

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

        Dim tabla As New DataTable
        Dim sqlId As String = "SELECT * FROM trabajos WHERE idTrabajo =" & idTrabajo
        Dim cmdId As New OleDbCommand(sqlId, conexionMdb)
        Dim da As New OleDbDataAdapter(cmdId)
        da.Fill(tabla)

        frmPpal.tsLbIdTrabajo.Text = "Trabajo activo: " & tabla.Rows(0).Item("idTrabajo").ToString

        cargarEntidadesTrabajoActivo(tabla.Rows(0).Item("idTrabajo"))

        'habilitar los botones de la toolbar de pd:
        frmPpal.tsdMacizo.Enabled = True
        frmPpal.tsdMacizoLinderos.Enabled = True
        frmPpal.tsdDistanciaEsquina.Enabled = True
        frmPpal.tsdParcela.Enabled = True
        frmPpal.tsdParcelaLindera.Enabled = True
        frmPpal.tsdSimbolos.Enabled = True
        frmPpal.tsMuros.Enabled = True

    End Sub

    Private Sub cargarEntidadesTrabajoActivo(ByVal idTrabajo As Integer)
        '----------------------------------------------------------------
        '
        'cargar las entidades graficas que correspondan al trabajo activo
        '
        '----------------------------------------------------------------

        Dim tblSegmentosPl As New DataTable
        Dim linea1 As VectorDraw.Professional.vdFigures.vdLine
        Dim circulo As VectorDraw.Professional.vdFigures.vdCircle
        Dim pt1, pt2, pt3, pt4, pt1NoDibujar, pt2NoDibujar, puntoMedio As VectorDraw.Geometry.gPoint
        Dim anguloEje As Double
        Dim textoPl As VectorDraw.Professional.vdFigures.vdText




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
        Dim sqlId As String = "SELECT * FROM trabajoEntidad WHERE idTrabajo =" & idTrabajo
        Dim cmdId As New OleDbCommand(sqlId, conexionMdb)
        Dim da As New OleDbDataAdapter(cmdId)
        da.Fill(tblTrabajoEntidades)
        If tblTrabajoEntidades.Rows.Count = 0 Then
            MsgBox("Este trabajo no tiene entidades.")
            Exit Sub
        End If




        '------------------------------------------------------------
        ' 1) CROQUIS
        '------------------------------------------------------------
        Dim tblCroquis As New DataTable
        sqlId = "SELECT * FROM croquis WHERE idTrabajo =" & idTrabajo
        cmdId.Connection = conexionMdb
        cmdId.CommandText = sqlId
        da.SelectCommand = cmdId
        da.Fill(tblCroquis)
        If tblCroquis.Rows.Count > 0 And frmPpal.croquis Then
            'MsgBox("Hay croquis en la bd")
            cargarCroquisDesdeBD(idTrabajo)

            Exit Sub
        End If






        '...................................................................
        '
        'en la tabla "tblTrabajoEntidades" tengo las entidades de un trabajo
        '
        '...................................................................
        For Each regEntidad As DataRow In tblTrabajoEntidades.Rows
            'recorro las entidades de este trabajo...

            '.........................................................................................................................
            '
            'TBLENTIDAD
            '
            'en esta tabla debo tener UN solo registro, ya que en la tabla de entidades debe haber UNA sola entidad por cada id unico.
            'aqui se guarda tipoEntidadLogica, tipoEntidadGeometrica
            '.........................................................................................................................
            Dim tblEntidad As New DataTable
            sqlId = "Select * from entidades where idEntidad =" & regEntidad.Item("idEntidad")
            cmdId.CommandText = sqlId
            cmdId.Connection = conexionMdb
            da.SelectCommand = cmdId
            da.Fill(tblEntidad)
            If tblEntidad.Rows.Count = 0 Then
                MsgBox("Inconsistencia. La entidad " & regEntidad.Item("idEntidad").ToString & " no se encuentra en la tabla de entidades")
                Exit Sub
            ElseIf tblEntidad.Rows.Count > 1 Then
                MsgBox("Inconsistencia. La entidad " & regEntidad.Item("idEntidad").ToString & " se encuentra mas de una vez en la tabla de entidades (?)")
                Exit Sub
            End If


            '......................................................................................
            '
            'TBLCOORDENADAS
            '
            'en esta tabla hay varios registros por cada entidad, ya que son todas las coordenadas
            'aqui se guarda x, y, z
            '......................................................................................
            Dim tblCoordenadas As New DataTable
            sqlId = "Select * from coordenadas where idEntidad =" & regEntidad.Item("idEntidad") 'X, Y, Z
            cmdId.CommandText = sqlId
            cmdId.Connection = conexionMdb
            da.SelectCommand = cmdId
            da.Fill(tblCoordenadas)
            If tblCoordenadas.Rows.Count = 0 Then
                'MsgBox("La entidad " & regEntidad.Item("idEntidad").ToString & " no tiene coordenadas")
                'Exit Sub
            End If


            '.....................................................
            '
            'TBLATRIBUTOSGEOMETRICOS
            '
            'en esta tabla debe haber UN solo registro por entidad
            'aqui se guarda tipoLinea, espesor, color
            '.....................................................
            Dim tblAtributosGeometricos As New DataTable
            sqlId = "Select * from atributosGeometricos where idEntidad =" & regEntidad.Item("idEntidad")
            cmdId.CommandText = sqlId
            cmdId.Connection = conexionMdb
            da.SelectCommand = cmdId
            da.Fill(tblAtributosGeometricos)
            If tblAtributosGeometricos.Rows.Count = 0 Then
                'MsgBox("La entidad " & regEntidad.Item("idEntidad").ToString & " no tiene atributos geometricos")
                'Exit Sub
            ElseIf tblAtributosGeometricos.Rows.Count > 1 Then
                MsgBox("La entidad " & regEntidad.Item("idEntidad").ToString & " esta mas de una vez en la tabla de atributos geometricos")
                Exit Sub
            End If


            '................................................................................
            '
            'TBLATRIBUTOSLOGICOS
            '
            'en esta tabla debe haber UN solo registro por entidad
            'se guardan nomenclatura, prefijosTextos, linderos, superficie, designacion, etc
            '................................................................................
            Dim tblAtributosLogicos As New DataTable
            sqlId = "Select * from atributosLogicos where idEntidad =" & regEntidad.Item("idEntidad").ToString
            cmdId.CommandText = sqlId
            cmdId.Connection = conexionMdb
            da.SelectCommand = cmdId
            da.Fill(tblAtributosLogicos)
            If tblAtributosLogicos.Rows.Count = 0 Then
                'MsgBox("La entidad " & regEntidad.Item("idEntidad").ToString & " no tiene atributos logicos")
                'Exit Sub
            ElseIf tblAtributosLogicos.Rows.Count > 1 Then
                MsgBox("La entidad " & regEntidad.Item("idEntidad").ToString & " esta mas de una vez en la tabla de atributos logicos.")
                Exit Sub
            End If




            '................................................................................
            '
            'TBLDESLINDE
            '
            '................................................................................
            Dim tblDeslinde As New DataTable
            sqlId = "Select * from deslinde where id_Trabajo =" & idTrabajo
            cmdId.CommandText = sqlId
            cmdId.Connection = conexionMdb
            da.SelectCommand = cmdId
            da.Fill(tblDeslinde)
            If tblDeslinde.Rows.Count = 0 Then
                'MsgBox("La entidad " & regEntidad.Item("idEntidad").ToString & " no tiene atributos logicos")
                'Exit Sub
            End If



            '.....................................................................................................................
            '
            'DIBUJAR la entidad activa
            '
            '.....................................................................................................................
            Select Case tblEntidad.Rows(0).Item("tipoEntidadGeometrica")

                Case Is = "Polilinea"

                    '--------------------------------------------------------------------------------------------
                    ' 2) CROQUIS
                    '--------------------------------------------------------------------------------------------
                    If frmPpal.croquis And tblEntidad.Rows(0).Item("tipoEntidadLogica") = "Parcela lindera" Then
                        Continue For
                    End If

                    poli = New VectorDraw.Professional.vdFigures.vdPolyline
                    poli.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                    poli.setDocumentDefaults()

                    'cargar los vertices de la polilinea.
                    For Each registro As DataRow In tblCoordenadas.Rows
                        poli.VertexList.Add(CDbl(registro("x")), CDbl(registro("y")), CDbl(registro("z")), 0.0)
                    Next

                    'cargar las caracteristicas de la polilinea
                    Dim elColor() As String = tblAtributosGeometricos.Rows(0).Item("color").ToString.Split(",")
                    poli.PenColor.FromRGB(CInt(elColor(0).Replace("(", "")), CInt(elColor(1)), CInt(elColor(2).Replace(")", "")))
                    poli.PenWidth = 0.01 'CDbl(tblAtributosGeometricos.Rows(0).Item("espesor"))

                    'dibujar en pantalla:
                    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(poli)
                    frmPpal.VdF.BaseControl.ActiveDocument.ZoomExtents()
                    frmPpal.VdF.BaseControl.ActiveDocument.ZoomScale(1.5)
                    frmPpal.VdF.BaseControl.Redraw()

                    'pegar datos en el tooltip (nada mas que el tooltip):
                    Dim boxing As VectorDraw.Professional.vdObjects.vdPrimary
                    boxing = poli
                    pegarDatosEntidad(boxing, regEntidad.Item("idEntidad"))

                    '---------------------------------------------------------------------------------------------------------
                    'La polilinea puede ser una parcela, una parcela lindera, un muro o un macizo.
                    '
                    'PARCELA LINDERA: Si es una parcela lindera, carga solo el circulo con el id y la sup. debajo del circ.
                    '
                    'MURO: si es un muro, lo dibuja y le pone el tooltip
                    '
                    'MACIZO: si es un macizo, carga en la estructura _macizo los puntos y los nombres de calle que
                    'corresponden a cada lado (lindo kilombito..je)
                    '
                    'PARCELA: si es una parcela, numera los vertices y agrega el circulo con el id y la sup. debaje del circ.
                    'en caso de estar dibujando el croquis, agrega los segmentos que indican las parcelas linderas
                    'y los circulos con el id de cada parcela lindera.
                    '---------------------------------------------------------------------------------------------------------
                    Select Case tblEntidad.Rows(0).Item("tipoEntidadLogica")
                        Case Is = "Parcela"
                            'numerarVerticesParcela(poli)
                            Dim gpuntos As New VectorDraw.Geometry.gPoints
                            Dim punto As VectorDraw.Geometry.gPoint
                            For Each elementoPunto As VectorDraw.Geometry.gPoint In poli.VertexList
                                punto = New VectorDraw.Geometry.gPoint
                                punto.x = elementoPunto.x
                                punto.y = elementoPunto.y
                                punto.z = 0.0
                                gpuntos.Add(punto)
                            Next
                            If Not tblDeslinde.Rows.Count = 0 Then
                                agregarBloqueIdParcelaDesdeBd(tblDeslinde.Rows(0).Item("Designacion_parcela"), Math.Round(poli.Area, 2), gpuntos.Centroid, False)
                            End If

                            '---------------------------------------------------------------------
                            ' 3) CROQUIS
                            ' leerSegmentosPl:
                            '---------------------------------------------------------------------
                            If frmPpal.croquis Then
                                sqlId = "SELECT * FROM segmentosPl WHERE idParcela =" & idTrabajo
                                cmdId.Connection = conexionMdb
                                cmdId.CommandText = sqlId
                                da.SelectCommand = cmdId
                                da.Fill(tblSegmentosPl)
                                If tblSegmentosPl.Rows.Count = 0 Then
                                    MsgBox("Este trabajo no tiene segmentos .")
                                    Exit Sub
                                End If

                                pt1NoDibujar = New VectorDraw.Geometry.gPoint
                                pt2NoDibujar = New VectorDraw.Geometry.gPoint
                                For Each registro As DataRow In tblSegmentosPl.Rows
                                    If registro.Item("nroParcela") = "frente" Then
                                        pt1NoDibujar.x = CDbl(registro.Item("x1"))
                                        pt1NoDibujar.y = CDbl(registro.Item("y1"))
                                        pt1NoDibujar.z = CDbl(registro.Item("z1"))
                                        pt2NoDibujar.x = CDbl(registro.Item("x2"))
                                        pt2NoDibujar.y = CDbl(registro.Item("y2"))
                                        pt2NoDibujar.z = CDbl(registro.Item("z2"))
                                    End If
                                Next

                                For Each regSegmento As DataRow In tblSegmentosPl.Rows
                                    If regSegmento.Item("nroParcela") = "frente" Then
                                        Continue For
                                    End If
                                    pt1 = New VectorDraw.Geometry.gPoint
                                    pt2 = New VectorDraw.Geometry.gPoint
                                    pt3 = New VectorDraw.Geometry.gPoint
                                    pt4 = New VectorDraw.Geometry.gPoint
                                    puntoMedio = New VectorDraw.Geometry.gPoint
                                    pt1.x = CDbl(regSegmento.Item("x1"))
                                    pt1.y = CDbl(regSegmento.Item("y1"))
                                    pt1.z = 0.0
                                    pt2.x = CDbl(regSegmento.Item("x2"))
                                    pt2.y = CDbl(regSegmento.Item("y2"))
                                    pt2.z = 0.0

                                    anguloEje = pt1.GetAngle(pt2)

                                    If Math.Round(pt2.x, 2) = Math.Round(pt1NoDibujar.x, 2) Or Math.Round(pt2.x, 2) = Math.Round(pt2NoDibujar.x, 2) Then
                                        pt2 = Nothing
                                        pt3 = pt1NoDibujar
                                    Else
                                        linea1 = New VectorDraw.Professional.vdFigures.vdLine()
                                        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                                        linea1.setDocumentDefaults()
                                        linea1.PenColor.ColorIndex = 2
                                        linea1.PenWidth = 0.01 '1.01
                                        linea1.ToolTip = "segmentoPl"
                                        linea1.StartPoint = pt2.Polar(anguloEje + VectorDraw.Geometry.Globals.DegreesToRadians(90.0), 0.0)
                                        linea1.EndPoint = pt2.Polar(anguloEje + VectorDraw.Geometry.Globals.DegreesToRadians(90.0), 10.0)
                                        pt3 = linea1.EndPoint
                                        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
                                    End If

                                    If Math.Round(pt1.x, 2) = Math.Round(pt1NoDibujar.x, 2) Or Math.Round(pt1.x, 2) = Math.Round(pt2NoDibujar.x, 2) Then
                                        pt1 = Nothing
                                        pt4 = pt2NoDibujar
                                    Else
                                        linea1 = New VectorDraw.Professional.vdFigures.vdLine()
                                        linea1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                                        linea1.setDocumentDefaults()
                                        linea1.PenColor.ColorIndex = 2
                                        linea1.PenWidth = 0.01 '1.01
                                        linea1.ToolTip = "segmentoPl"
                                        linea1.StartPoint = pt1.Polar(anguloEje + VectorDraw.Geometry.Globals.DegreesToRadians(90.0), 0.0)
                                        linea1.EndPoint = pt1.Polar(anguloEje + VectorDraw.Geometry.Globals.DegreesToRadians(90.0), 10.0)
                                        pt4 = linea1.EndPoint
                                        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea1)
                                    End If

                                    circulo = New VectorDraw.Professional.vdFigures.vdCircle()
                                    circulo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                                    circulo.setDocumentDefaults()
                                    puntoMedio = VectorDraw.Geometry.gPoint.MidPoint(pt3, pt4)
                                    circulo.Center = puntoMedio
                                    circulo.Radius = 1.5
                                    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(circulo)
                                    textoPl = New VectorDraw.Professional.vdFigures.vdText
                                    textoPl.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                                    textoPl.setDocumentDefaults()
                                    'texto.PenColor.ColorIndex= 3
                                    textoPl.TextString = regSegmento.Item("nroParcela")
                                    textoPl.ToolTip = "idParcela"
                                    'frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.Standard.FontFile = "verdana"
                                    textoPl.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
                                    textoPl.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
                                    textoPl.Height = 0.7  '<--
                                    textoPl.InsertionPoint = puntoMedio
                                    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textoPl)
                                    frmPpal.VdF.BaseControl.Redraw()
                                Next
                            End If

                        Case Is = "Parcela lindera"
                            'numerarVerticesParcela(poli)
                            Dim gpuntos As New VectorDraw.Geometry.gPoints
                            Dim punto As VectorDraw.Geometry.gPoint
                            For Each elementoPunto As VectorDraw.Geometry.gPoint In poli.VertexList
                                punto = New VectorDraw.Geometry.gPoint
                                punto.x = elementoPunto.x
                                punto.y = elementoPunto.y
                                punto.z = 0.0
                                gpuntos.Add(punto)
                            Next
                            agregarBloqueIdParcelaDesdeBd(tblAtributosLogicos.Rows(0).Item("nomenclatura"), Math.Round(poli.Area, 2), gpuntos.Centroid, True)

                        Case Is = "Macizo"
                            'numerarVerticesMacizo(poli)
                            '---------------------------------------------------------------------
                            'cargar los datos del macizo en la estructura
                            '---------------------------------------------------------------------
                            Dim k, idBuscar As Integer
                            For Each puntoVertice As VectorDraw.Geometry.gPoint In poli.VertexList
                                k = k + 1
                                If k = 1 Then
                                    ReDim _macizo.puntos(0)
                                    ReDim _macizo.puntosOriginales(0)
                                    _macizo.puntosOriginales(0) = New VectorDraw.Geometry.gPoint
                                    _macizo.puntos(0).X = puntoVertice.x
                                    _macizo.puntosOriginales(0).x = puntoVertice.x
                                    _macizo.puntos(0).Y = puntoVertice.y
                                    _macizo.puntosOriginales(0).y = puntoVertice.y
                                ElseIf k < poli.VertexList.Count Then
                                    ReDim Preserve _macizo.puntos(k - 1)
                                    ReDim Preserve _macizo.puntosOriginales(k - 1)
                                    _macizo.puntosOriginales(k - 1) = New VectorDraw.Geometry.gPoint
                                    _macizo.puntos(k - 1).X = puntoVertice.x
                                    _macizo.puntosOriginales(k - 1).x = puntoVertice.x
                                    _macizo.puntos(k - 1).Y = puntoVertice.y
                                    _macizo.puntosOriginales(k - 1).y = puntoVertice.y
                                End If
                            Next


                            Dim tblDatosMacizo As New DataTable
                            sqlId = "SELECT entidades.tipoEntidadGeometrica, entidades.tipoEntidadLogica, atributosLogicos.*" _
& " FROM (entidades INNER JOIN trabajoEntidad ON entidades.idEntidad = trabajoEntidad.idEntidad) INNER JOIN atributosLogicos ON entidades.idEntidad = atributosLogicos.idEntidad" _
& " WHERE (((trabajoEntidad.idTrabajo)=" & idTrabajo & "))"
                            cmdId.CommandText = sqlId
                            cmdId.Connection = conexionMdb
                            da.SelectCommand = cmdId
                            da.Fill(tblDatosMacizo)
                            If tblDatosMacizo.Rows.Count = 0 Then
                                Exit Sub
                            End If
                            For Each registroEnt As DataRow In tblDatosMacizo.Rows
                                If Trim(registroEnt("tipoEntidadLogica")) = "Nombre Calle" Then
                                    For Each puntoVertice As VectorDraw.Geometry.gPoint In poli.VertexList
                                        If Math.Round(CDbl(registroEnt("ladoMacizoPt1x")), 2) = Math.Round(puntoVertice.x, 2) And _
                                           Math.Round(CDbl(registroEnt("ladoMacizoPt1y")), 2) = Math.Round(puntoVertice.y, 2) Then
                                            If IsNothing(_macizo.txMedidaNombreCalle_contenbido) Then
                                                ReDim _macizo.txMedidaNombreCalle_contenbido(0)
                                                _macizo.txMedidaNombreCalle_contenbido(0) = registroEnt("nombre_calle")
                                                Continue For
                                            Else
                                                ReDim Preserve _macizo.txMedidaNombreCalle_contenbido(UBound(_macizo.txMedidaNombreCalle_contenbido) + 1)
                                                _macizo.txMedidaNombreCalle_contenbido(UBound(_macizo.txMedidaNombreCalle_contenbido)) = registroEnt("nombre_calle")
                                                Continue For
                                            End If
                                        End If
                                    Next
                                End If
                            Next
                        Case Is = "Muro"

                            Dim tblMuro As New DataTable
                            Dim anguloEjeMuro As Double
                            sqlId = "Select * from muros where id_entidad ='" & regEntidad.Item("idEntidad") & "'"
                            cmdId.CommandText = sqlId
                            cmdId.Connection = conexionMdb
                            da.SelectCommand = cmdId
                            da.Fill(tblMuro)
                            If tblMuro.Rows.Count = 0 Then
                                Continue For
                            End If

                            Dim linea, linea01, linea02 As VectorDraw.Professional.vdFigures.vdLine
                            '------------------> linea es la linea de eje
                            linea = New VectorDraw.Professional.vdFigures.vdLine()
                            linea.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                            linea.setDocumentDefaults()
                            linea.LineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName("Dashed")
                            linea.LineTypeScale = 4.0
                            linea.PenColor.ColorIndex = 1
                            'linea.PenWidth = 0.0001
                            linea.StartPoint.x = CDbl(tblMuro.Rows(0).Item("punto1x"))
                            linea.StartPoint.y = CDbl(tblMuro.Rows(0).Item("punto1y"))
                            linea.EndPoint.x = CDbl(tblMuro.Rows(0).Item("punto2x"))
                            linea.EndPoint.y = CDbl(tblMuro.Rows(0).Item("punto2y"))
                            anguloEjeMuro = linea.StartPoint.GetAngle(linea.EndPoint)
                            linea.ToolTip = "Tipo Entidad: muro, id: " & regEntidad.Item("idEntidad")
                            'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea)


                            '------------------> linea01 es una de las lineas del muro
                            linea01 = New VectorDraw.Professional.vdFigures.vdLine
                            linea01.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                            linea01.setDocumentDefaults()
                            Dim dif2 As String = tblMuro.Rows(0).Item("diferencia2").ToString
                            If InStr(dif2, sepMiles) <> 0 Then
                                dif2 = Replace(dif2, sepMiles, sepDecimal)
                            End If
                            Dim dif1 As String = tblMuro.Rows(0).Item("diferencia1").ToString
                            If InStr(dif1, sepMiles) <> 0 Then
                                dif1 = Replace(dif1, sepMiles, sepDecimal)
                            End If
                            linea01.StartPoint = linea.StartPoint.Polar(anguloEjeMuro + VectorDraw.Geometry.Globals.DegreesToRadians(90.0), CDbl(dif2))
                            linea01.EndPoint = linea.EndPoint.Polar(anguloEjeMuro + VectorDraw.Geometry.Globals.DegreesToRadians(90.0), CDbl(dif1))
                            linea01.ToolTip = "Tipo Entidad: muro, id: " & regEntidad.Item("idEntidad")
                            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea01)


                            '------------------> linea02 es una de las lineas del muro
                            linea02 = New VectorDraw.Professional.vdFigures.vdLine
                            linea02.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                            linea02.setDocumentDefaults()
                            Dim anchoCalculado As String = tblMuro.Rows(0).Item("ancho")
                            If InStr(anchoCalculado, sepMiles) <> 0 Then
                                anchoCalculado = Replace(anchoCalculado, sepMiles, sepDecimal)
                            End If
                            Dim dif3 As Double = CDbl(anchoCalculado) - dif2
                            Dim dif4 As Double = CDbl(anchoCalculado) - dif1
                            linea02.StartPoint = linea.StartPoint.Polar(anguloEjeMuro - VectorDraw.Geometry.Globals.DegreesToRadians(90.0), dif3)
                            linea02.EndPoint = linea.EndPoint.Polar(anguloEjeMuro - VectorDraw.Geometry.Globals.DegreesToRadians(90.0), dif4)
                            linea02.ToolTip = "Tipo Entidad: muro, id: " & regEntidad.Item("idEntidad")
                            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea02)
                            frmPpal.VdF.BaseControl.Redraw()
                            'End If
                            tblMuro.Dispose()
                            tblMuro = Nothing
                    End Select



                Case Is = "Texto"
                    Dim texto As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText
                    texto.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                    texto.setDocumentDefaults()


                    If Not tblAtributosLogicos.Rows.Count = 0 Then
                        If Not IsDBNull(tblAtributosLogicos.Rows(0).Item("nombre_calle")) Then
                            texto.TextString = tblAtributosLogicos.Rows(0).Item("nombre_calle")
                            texto.ToolTip = "Tipo Entidad: Nombre de calle, id: " & tblAtributosLogicos.Rows(0).Item("idEntidad")
                            texto.Style = estiloNombreCalle2
                        End If
                    Else
                        Continue For
                    End If


                    If Not tblAtributosLogicos.Rows.Count = 0 Then
                        If Not IsDBNull(tblAtributosLogicos.Rows(0).Item("ancho_calle")) Then
                            texto.TextString = tblAtributosLogicos.Rows(0).Item("ancho_calle")
                            texto.ToolTip = "Tipo Entidad: Ancho de calle, id: " & tblAtributosLogicos.Rows(0).Item("idEntidad")
                            texto.Style = estiloNombreCalle2
                        End If
                    Else
                        Continue For
                    End If


                    If Not tblAtributosLogicos.Rows.Count = 0 Then
                        If Not IsDBNull(tblAtributosLogicos.Rows(0).Item("medida_lado_macizo")) Then
                            texto.TextString = tblAtributosLogicos.Rows(0).Item("medida_lado_macizo")
                            texto.ToolTip = "Tipo Entidad: Medida lado macizo, id: " & tblAtributosLogicos.Rows(0).Item("idEntidad")
                            texto.Style = estiloMedidaPl3
                        End If
                    Else
                        Continue For
                    End If

                    If Not tblAtributosLogicos.Rows.Count = 0 Then
                        If Not IsDBNull(tblAtributosLogicos.Rows(0).Item("medida_lado_parcela")) Then
                            texto.TextString = tblAtributosLogicos.Rows(0).Item("medida_lado_parcela")
                            texto.ToolTip = "Tipo Entidad: Medida lado parcela, id: " & tblAtributosLogicos.Rows(0).Item("idEntidad")
                            texto.Style = estiloMedidaPl3
                        End If
                    Else
                        Continue For
                    End If


                    If Not tblAtributosLogicos.Rows.Count = 0 Then
                        If Not IsDBNull(tblAtributosLogicos.Rows(0).Item("designacion")) Then
                            If tblAtributosLogicos.Rows(0).Item("designacion") <> "-" Then
                                texto.TextString = tblAtributosLogicos.Rows(0).Item("nomenclatura")
                                texto.ToolTip = "Tipo Entidad: Identificador Macizo, id: " & tblAtributosLogicos.Rows(0).Item("idEntidad")
                                texto.Style = estiloMz1
                            End If
                        End If
                    Else
                        Continue For
                    End If

                    If Not tblAtributosLogicos.Rows.Count = 0 Then
                        If Not IsDBNull(tblAtributosLogicos.Rows(0).Item("idMuro")) Then
                            If Not IsDBNull(tblAtributosLogicos.Rows(0).Item("medida_muro")) Then
                                texto.TextString = tblAtributosLogicos.Rows(0).Item("medida_muro")
                                texto.ToolTip = "Tipo Entidad: Ancho muro, id: " & tblAtributosLogicos.Rows(0).Item("idEntidad")
                                texto.Style = estiloAnchoMuro4
                            End If
                        End If
                    End If


                    texto.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
                    texto.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen


                    Dim ptIn = New VectorDraw.Geometry.gPoint
                    Dim ptOffseteado = New VectorDraw.Geometry.gPoint
                    If Not tblCoordenadas.Rows.Count = 0 Then

                        ptIn.x = tblCoordenadas.Rows(0).Item("x")
                        ptIn.y = tblCoordenadas.Rows(0).Item("y")
                        ptIn.z = tblCoordenadas.Rows(0).Item("z")
                        texto.InsertionPoint = ptIn
                        texto.Rotation = tblCoordenadas.Rows(0).Item("angulo")
                        'ptOffseteado .SetOffsetFrom (ptIn,
                    End If

                    If InStr(texto.ToolTip, "Ancho muro") <> 0 Then
                        '-----------> linea de cota que atravieza el ancho del muro
                        Dim lineaCota As New VectorDraw.Professional.vdFigures.vdLine()
                        lineaCota.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                        lineaCota.setDocumentDefaults()

                        'linea2.LineType = frmPpal.VdF.BaseControl.ActiveDocument.LineTypes.FindName("Dashed")
                        'linea2.LineTypeScale = 4.0
                        lineaCota.PenColor.ColorIndex = 1
                        lineaCota.PenWidth = 0.0001
                        'lineaCota.StartPoint = ptIn.Polar(texto.Rotation - VectorDraw.Geometry.Globals.DegreesToRadians(180.0), 1.5)
                        lineaCota.StartPoint = ptIn.Polar(texto.Rotation, 2.5)
                        'lineaCota.EndPoint = lineaCota.StartPoint.Polar(texto.Rotation - VectorDraw.Geometry.Globals.DegreesToRadians(90.0), 4.5)
                        lineaCota.EndPoint = lineaCota.StartPoint.Polar(texto.Rotation, 4.5)
                        lineaCota.ToolTip = "Tipo Entidad: ancho muro, id: " & idEntidad.ToString
                        frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lineaCota)
                    End If

                    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(texto)
                    frmPpal.VdF.BaseControl.Redraw()

                Case Is = "Bloque"
                    '..........................................................................
                    'TBLSIMBOLOS
                    'en esta tabla estan los simbolos como un norte,
                    'se guardan idEntidad, nombreSimbolo, x, y, z, angulo, medida
                    '..........................................................................
                    Dim tblSimbolos As New DataTable
                    sqlId = "Select * from simbolos where idEntidad =" & regEntidad.Item("idEntidad")
                    cmdId.CommandText = sqlId
                    cmdId.Connection = conexionMdb
                    da.SelectCommand = cmdId
                    da.Fill(tblSimbolos)
                    If tblSimbolos.Rows.Count = 0 Then
                        MsgBox("Hay un simbolo (norte?) definido en la tabla entidades sin datos en la tabla de simbolos", vbInformation)
                        Exit Sub
                    ElseIf tblAtributosLogicos.Rows.Count > 1 Then
                        MsgBox("Hay un simbolo que esta repetido en la tabla de simbolos")
                        Exit Sub
                    End If
                    'definir el punto de insercion, como un gpoint y cargarle las coordenadas leidas de la 
                    'tabla simbolos
                    Dim puntoInsertar As New VectorDraw.Geometry.gPoint
                    puntoInsertar.x = tblSimbolos.Rows(0).Item("x")
                    puntoInsertar.y = tblSimbolos.Rows(0).Item("y")
                    puntoInsertar.z = tblSimbolos.Rows(0).Item("z")
                    dibujarNorte(regEntidad.Item("idEntidad"), puntoInsertar, tblSimbolos.Rows(0).Item("angulo"), tblSimbolos.Rows(0).Item("medida"))

                Case Else

            End Select
        Next

    End Sub

    Private Sub cargarCroquisDesdeBD(ByVal idTrabajo As Integer)
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

        Dim tblCroquis As New DataTable
        Dim sqlId As String = "SELECT * FROM croquis WHERE idTrabajo =" & idTrabajo
        Dim cmdId As New OleDbCommand(sqlId, conexionMdb)
        Dim da As New OleDbDataAdapter(cmdId)
        da.Fill(tblCroquis)
        If tblCroquis.Rows.Count = 0 Then
            MsgBox("Este trabajo no tiene croquis.")
            Exit Sub
        End If



        Dim arrayListParcela As New ArrayList
        For Each regEntidad As DataRow In tblCroquis.Rows
            Select Case regEntidad.Item("tipoEntidadGeometrica")
                Case Is = "Polilinea"

                    poli = New VectorDraw.Professional.vdFigures.vdPolyline
                    poli.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                    poli.setDocumentDefaults()

                    'LINQ:
                    Dim entidadBuscada = From entidad In tblCroquis.AsEnumerable() _
                                         Where entidad("idEntidad") = regEntidad.Item("idEntidad") _
                                         Select entidad
                    For Each poliLeida In entidadBuscada
                        poli.VertexList.Add(poliLeida.Item("x"), poliLeida.Item("y"), poliLeida.Item("z"), 0.0)
                    Next
                    If arrayListParcela.Contains(Trim(entidadBuscada(0).Item("tooltip").ToString)) Then
                        Continue For
                    End If
                    poli.ToolTip = Trim(entidadBuscada(0).Item("tooltip").ToString)
                    'dibuja en pantalla:
                    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(poli)
                    arrayListParcela.Add(poli.ToolTip)
                Case Is = "Circulo"
                    circulo = New VectorDraw.Professional.vdFigures.vdCircle
                    circulo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                    circulo.setDocumentDefaults()
                    circulo.Center.x = CDbl(regEntidad.Item("x"))
                    circulo.Center.y = CDbl(regEntidad.Item("y"))
                    circulo.Radius = 2.0
                    circulo.ToolTip = Trim(regEntidad.Item("tooltip").ToString)
                    'dibuja en pantalla:
                    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(circulo)
                Case Is = "Texto"
                    texto = New VectorDraw.Professional.vdFigures.vdText
                    texto.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                    texto.setDocumentDefaults()
                    texto.Rotation = VectorDraw.Geometry.Globals.DegreesToRadians(regEntidad.Item("angulo"))
                    texto.InsertionPoint.x = CDbl(regEntidad.Item("x"))
                    texto.InsertionPoint.y = CDbl(regEntidad.Item("y"))
                    texto.InsertionPoint.z = CDbl(regEntidad.Item("z"))
                    texto.TextString = regEntidad.Item("texto").ToString
                    texto.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
                    texto.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
                    texto.Height = CDbl(regEntidad.Item("alturaTexto"))
                    texto.ToolTip = Trim(regEntidad.Item("tooltip").ToString)
                    'dibuja en pantalla:
                    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(texto)
                Case Is = "Linea"
                    linea = New VectorDraw.Professional.vdFigures.vdLine
                    linea.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                    linea.setDocumentDefaults()

                    'LINQ:
                    Dim entidadBuscada = From entidad In tblCroquis.AsEnumerable() _
                                         Where entidad("idEntidad") = regEntidad.Item("idEntidad") _
                                         Select entidad
                    Dim i As Integer = 0
                    For Each lineaLeida In entidadBuscada
                        If i = 0 Then
                            linea.StartPoint.x = CDbl(lineaLeida.Item("x"))
                            linea.StartPoint.y = CDbl(lineaLeida.Item("y"))
                            linea.StartPoint.z = CDbl(lineaLeida.Item("z"))
                        ElseIf i = 1 Then
                            linea.EndPoint.x = CDbl(lineaLeida.Item("x"))
                            linea.EndPoint.y = CDbl(lineaLeida.Item("y"))
                            linea.EndPoint.z = CDbl(lineaLeida.Item("z"))
                        End If
                        i = i + 1
                    Next
                    linea.ToolTip = Trim(entidadBuscada(0).Item("tooltip").ToString)
                    'dibuja en pantalla:
                    frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(linea)
            End Select
        Next
        frmPpal.VdF.BaseControl.ActiveDocument.ZoomExtents()
        frmPpal.VdF.BaseControl.ActiveDocument.ZoomScale(1.5)
        frmPpal.VdF.BaseControl.Redraw()
    End Sub
End Module
