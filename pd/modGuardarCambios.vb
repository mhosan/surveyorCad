
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports ADOX
Imports System.Windows.Forms

Module modGuardarCambios

    Dim rnd As New Random

    Public Sub guardarCambios()
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

        Dim idEntidadAGuardar As Integer, sql As String, Cmd As OleDbCommand = New OleDbCommand()

        For Each entidad As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If entidad.ToolTip <> "" Then
                Dim auxiliar() As String = Split(entidad.ToolTip, ", id:")
                If auxiliar.Count > 1 Then
                    If entidad._TypeName = "vdText" Then
                        If Not Trim(auxiliar(1)) = "" Then
                            If IsNumeric(auxiliar(1)) Then
                                idEntidadAGuardar = CInt(Trim(auxiliar(1)))
                            Else
                                Continue For
                            End If
                        Else
                            Continue For
                        End If
                        Dim texto As New VectorDraw.Professional.vdFigures.vdText
                        texto.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                        texto.setDocumentDefaults()
                        texto = entidad
                        '-------------------------------------------------------------
                        'tabla coordenadas
                        '-------------------------------------------------------------
                        sql = "UPDATE coordenadas SET x= " & Math.Round(texto.InsertionPoint.x, 4) & ", y=" & Math.Round(texto.InsertionPoint.y, 4) & ", z=" & Math.Round(texto.InsertionPoint.z, 2) & ", angulo=" & Math.Round(texto.Rotation, 2) & " " _
                            & "WHERE idEntidad= " & idEntidadAGuardar
                        Cmd.CommandText = sql
                        Cmd.Connection = conexionMdb
                        Cmd.ExecuteNonQuery()
                        '-------------------------------------------------------------
                        'tabla atributosLogicos
                        '-------------------------------------------------------------
                        If InStr(auxiliar(0), "Identificador Macizo") Then
                            sql = "UPDATE atributosLogicos SET nomenclatura= '" & texto.TextString & "' WHERE idEntidad= " & idEntidadAGuardar
                        ElseIf InStr(auxiliar(0), "Nombre de calle") Then
                            sql = "UPDATE atributosLogicos SET nombre_calle= '" & texto.TextString & "' WHERE idEntidad= " & idEntidadAGuardar
                        ElseIf InStr(auxiliar(0), "Medida lado macizo") Then
                            sql = "UPDATE atributosLogicos SET medida_lado_macizo= '" & texto.TextString & "' WHERE idEntidad= " & idEntidadAGuardar
                        ElseIf InStr(auxiliar(0), "Medida lado parcela") Then
                            sql = "UPDATE atributosLogicos SET medida_lado_parcela= '" & texto.TextString & "' WHERE idEntidad= " & idEntidadAGuardar
                        ElseIf InStr(auxiliar(0), "Ancho de calle") Then
                            sql = "UPDATE atributosLogicos SET ancho_calle= '" & texto.TextString & "' WHERE idEntidad= " & idEntidadAGuardar
                        ElseIf InStr(auxiliar(0), "Ancho muro") Then
                            sql = "UPDATE atributosLogicos SET medida_muro= '" & texto.TextString & "' WHERE idEntidad= " & idEntidadAGuardar
                        End If
                        Cmd.CommandText = sql
                        Cmd.Connection = conexionMdb
                        Cmd.ExecuteNonQuery()
                    End If
                
                End If


            End If
        Next

    End Sub

    'Public Sub guardarCroquis()
    '    Dim poli As VectorDraw.Professional.vdFigures.vdPolyline
    '    Dim linea As VectorDraw.Professional.vdFigures.vdLine
    '    Dim texto As VectorDraw.Professional.vdFigures.vdText
    '    Dim circulo As VectorDraw.Professional.vdFigures.vdCircle
    '    Dim Random As New Random()
    '    Dim sql, tipoEntidadLogica, tipoEntidadGeometrica, contenidoTexto, puntox, puntoy, puntoz, puntox2, puntoy2, puntoz2 As String
    '    Dim Cmd As OleDbCommand = New OleDbCommand()
    '    Dim alturaTexto, angulo As Double
    '    Dim toolTip As String

    '    If conexionMdb Is Nothing Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    End If


    '    'frmPHUnidadesFuncionales.limpiarMemoria()
    '    For Each figura As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
    '        Select Case figura._TypeName
    '            Case "vdLine"
    '                linea = New VectorDraw.Professional.vdFigures.vdLine()
    '                linea.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
    '                linea.setDocumentDefaults()
    '                linea = figura
    '                puntox = linea.StartPoint.x.ToString.Replace(",", ".")
    '                puntoy = linea.StartPoint.y.ToString.Replace(",", ".")
    '                puntoz = linea.StartPoint.z.ToString.Replace(",", ".")
    '                puntox2 = linea.EndPoint.x.ToString.Replace(",", ".")
    '                puntoy2 = linea.EndPoint.y.ToString.Replace(",", ".")
    '                puntoz2 = linea.EndPoint.z.ToString.Replace(",", ".")

    '                idEntidad = linea.Handle.Value + CInt(rnd.Next)
    '                tipoEntidadLogica = "--"
    '                tipoEntidadGeometrica = "Linea"
    '                contenidoTexto = "--"
    '                alturaTexto = 0.0
    '                angulo = 0.0
    '                toolTip = linea.ToolTip

    '                sql = "INSERT into croquis (" _
    '                    & "idTrabajo, " _
    '                    & "idEntidad, " _
    '                    & "tipoEntidadLogica, " _
    '                    & "tipoEntidadGeometrica, " _
    '                    & "texto, " _
    '                    & "alturaTexto, " _
    '                    & "X, " _
    '                    & "Y, " _
    '                    & "Z, " _
    '                    & "angulo, " _
    '                    & "tooltip) values(" _
    '                    & idTrabajo & " ," _
    '                    & idEntidad & " ,'" _
    '                    & tipoEntidadLogica & "', '" _
    '                    & tipoEntidadGeometrica & "', '" _
    '                    & contenidoTexto & "', " _
    '                    & alturaTexto & ", " _
    '                    & CDbl(puntox) & ", " _
    '                    & CDbl(puntoy) & ", " _
    '                    & CDbl(puntoz) & ", " _
    '                    & angulo & ", '" _
    '                    & toolTip & "')"
    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()
    '                sql = "INSERT into croquis (" _
    '                                        & "idTrabajo, " _
    '                                        & "idEntidad, " _
    '                                        & "tipoEntidadLogica, " _
    '                                        & "tipoEntidadGeometrica, " _
    '                                        & "texto, " _
    '                                        & "alturaTexto, " _
    '                                        & "X, " _
    '                                        & "Y, " _
    '                                        & "Z, " _
    '                                        & "angulo, " _
    '                                        & "tooltip) values(" _
    '                                        & idTrabajo & " ," _
    '                                        & idEntidad & " ,'" _
    '                                        & tipoEntidadLogica & "', '" _
    '                                        & tipoEntidadGeometrica & "', '" _
    '                                        & contenidoTexto & "', " _
    '                                        & alturaTexto & ", " _
    '                                        & CDbl(puntox2) & ", " _
    '                                        & CDbl(puntoy2) & ", " _
    '                                        & CDbl(puntoz2) & ", " _
    '                                        & angulo & ", '" _
    '                                        & toolTip & "')"
    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()

    '            Case "vdPolyline"
    '                poli = New VectorDraw.Professional.vdFigures.vdPolyline
    '                poli.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
    '                poli.setDocumentDefaults()
    '                poli = figura

    '                idEntidad = poli.Handle.Value + CInt(rnd.Next)
    '                tipoEntidadLogica = "--"
    '                tipoEntidadGeometrica = "Polilinea"
    '                contenidoTexto = "--"
    '                alturaTexto = 0.0
    '                toolTip = poli.ToolTip

    '                Try
    '                    Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    '                    Dim i As Integer

    '                    For Each punto In poli.VertexList
    '                        i = i + 1
    '                        puntox = punto.x.ToString.Replace(",", ".")
    '                        puntoy = punto.y.ToString.Replace(",", ".")
    '                        puntoz = punto.z.ToString.Replace(",", ".")
    '                        sql = "INSERT into croquis (" _
    '                    & "idTrabajo, " _
    '                    & "idEntidad, " _
    '                    & "tipoEntidadLogica, " _
    '                    & "tipoEntidadGeometrica, " _
    '                    & "texto, " _
    '                    & "alturaTexto, " _
    '                    & "X, " _
    '                    & "Y, " _
    '                    & "Z, " _
    '                    & "angulo, " _
    '                    & "tooltip) values(" _
    '                    & idTrabajo & " ," _
    '                    & idEntidad & " ,'" _
    '                    & tipoEntidadLogica & "', '" _
    '                    & tipoEntidadGeometrica & "', '" _
    '                    & contenidoTexto & "', " _
    '                    & alturaTexto & ", " _
    '                    & CDbl(puntox) & ", " _
    '                    & CDbl(puntoy) & ", " _
    '                    & CDbl(puntoz) & ", " _
    '                    & angulo & ", '" _
    '                    & toolTip & "')"

    '                        Cmd.CommandText = sql
    '                        Cmd.Connection = conexionMdb
    '                        Cmd.ExecuteNonQuery()
    '                    Next
    '                Catch ex As Exception
    '                    MsgBox("Error al guardar las coordenadas de una polilinea.")
    '                End Try

    '            Case "vdText"
    '                texto = New VectorDraw.Professional.vdFigures.vdText
    '                texto.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
    '                texto.setDocumentDefaults()
    '                texto = figura
    '                puntox = texto.InsertionPoint.x.ToString.Replace(",", ".")
    '                puntoy = texto.InsertionPoint.y.ToString.Replace(",", ".")
    '                puntoz = texto.InsertionPoint.z.ToString.Replace(",", ".")

    '                idEntidad = texto.Handle.Value + CInt(rnd.Next)
    '                tipoEntidadLogica = "--"
    '                tipoEntidadGeometrica = "Texto"
    '                contenidoTexto = texto.TextString
    '                alturaTexto = texto.Height
    '                angulo = Math.Round(VectorDraw.Geometry.Globals.RadiansToDegrees(texto.Rotation), 2)
    '                toolTip = texto.ToolTip

    '                sql = "INSERT into croquis (" _
    '                    & "idTrabajo, " _
    '                    & "idEntidad, " _
    '                    & "tipoEntidadLogica, " _
    '                    & "tipoEntidadGeometrica, " _
    '                    & "texto, " _
    '                    & "alturaTexto, " _
    '                    & "X, " _
    '                    & "Y, " _
    '                    & "Z, " _
    '                    & "angulo, " _
    '                    & "tooltip) values(" _
    '                    & idTrabajo & " ," _
    '                    & idEntidad & " ,'" _
    '                    & tipoEntidadLogica & "', '" _
    '                    & tipoEntidadGeometrica & "', '" _
    '                    & contenidoTexto & "', " _
    '                    & alturaTexto & ", " _
    '                    & CDbl(puntox) & ", " _
    '                    & CDbl(puntoy) & ", " _
    '                    & CDbl(puntoz) & ", " _
    '                    & angulo & ", '" _
    '                    & toolTip & "')"

    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()

    '            Case "vdCircle"
    '                circulo = New VectorDraw.Professional.vdFigures.vdCircle()
    '                circulo.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
    '                circulo.setDocumentDefaults()
    '                circulo = figura
    '                puntox = circulo.Center.x.ToString.Replace(",", ".")
    '                puntoy = circulo.Center.y.ToString.Replace(",", ".")
    '                puntoz = circulo.Center.z.ToString.Replace(",", ".")

    '                idEntidad = circulo.Handle.Value + CInt(rnd.Next)
    '                tipoEntidadLogica = "--"
    '                tipoEntidadGeometrica = "Circulo"
    '                contenidoTexto = "--"
    '                alturaTexto = 0.0
    '                angulo = 0.0
    '                toolTip = circulo.ToolTip

    '                sql = "INSERT into croquis (" _
    '                    & "idTrabajo, " _
    '                    & "idEntidad, " _
    '                    & "tipoEntidadLogica, " _
    '                    & "tipoEntidadGeometrica, " _
    '                    & "texto, " _
    '                    & "alturaTexto, " _
    '                    & "X, " _
    '                    & "Y, " _
    '                    & "Z, " _
    '                    & "angulo, " _
    '                    & "tooltip) values(" _
    '                    & idTrabajo & " ," _
    '                    & idEntidad & " ,'" _
    '                    & tipoEntidadLogica & "', '" _
    '                    & tipoEntidadGeometrica & "', '" _
    '                    & contenidoTexto & "', " _
    '                    & alturaTexto & ", " _
    '                    & CDbl(puntox) & ", " _
    '                    & CDbl(puntoy) & ", " _
    '                    & CDbl(puntoz) & ", " _
    '                    & angulo & ", '" _
    '                    & toolTip & "')"

    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()

    '        End Select
    '    Next
    'End Sub

    'Public Function borrarCroquis() As Boolean

    '    If conexionMdb Is Nothing Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Function
    '        End If
    '    ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Function
    '        End If
    '    End If
    '    Try
    '        Dim sql As String = "DELETE * FROM croquis WHERE idTrabajo=" & idTrabajo
    '        Dim Cmd As OleDbCommand = New OleDbCommand(sql, conexionMdb)
    '        Cmd.ExecuteNonQuery()
    '        Return True
    '    Catch ex As Exception
    '        Err.Clear()
    '        Return False
    '    End Try

    'End Function

    'Public Sub agregarDatosMacizoBD(ByVal datos As String, ByVal laPolilinea As VectorDraw.Professional.vdFigures.vdPolyline, ByVal tipoEntidadLogica As String)

    '    Dim Random As New Random()
    '    '-------------------
    '    'alta o modificacion
    '    '-------------------
    '    idEntidad = laPolilinea.Handle.Value + CInt(rnd.Next(999999))

    '    If conexionMdb Is Nothing Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    End If

    '    Dim sql As String
    '    Dim Cmd As OleDbCommand = New OleDbCommand()

    '    Dim elTipoDeLinea As String = laPolilinea.LineType.ToString
    '    Dim elEspesorDeLinea As String = laPolilinea.PenWidth.ToString
    '    Dim elColorDeLinea As String = laPolilinea.PenColor.ToString



    '    Dim adaptador As New OleDb.OleDbDataAdapter("Select * from entidades where idEntidad=" & idEntidad, conexionMdb)
    '    Dim ds As New DataSet
    '    adaptador.Fill(ds, "tblEntidad")
    '    If ds.Tables("tblEntidad").Rows.Count = 0 Then
    '        'ALTA:
    '        '--------------------
    '        'tabla trabajoEntidad
    '        '--------------------
    '        If tipoEntidadLogica = "macizo" Then

    '            sql = "INSERT into trabajoEntidad (idTrabajo, idEntidad) values(" & idTrabajo & ", " & id_macizo & ")"
    '            Cmd.CommandText = sql
    '            Cmd.Connection = conexionMdb
    '            Cmd.ExecuteNonQuery()
    '        Else
    '            sql = "INSERT into trabajoEntidad (idTrabajo, idEntidad) values(" & idTrabajo & ", " & idEntidad & ")"
    '            Cmd.CommandText = sql
    '            Cmd.Connection = conexionMdb
    '            Cmd.ExecuteNonQuery()
    '        End If
    '        '---------------------
    '        'tabla entidades
    '        '---------------------
    '        If tipoEntidadLogica = "macizo" Then
    '            sql = "INSERT into entidades (idEntidad, tipoEntidadLogica, tipoEntidadGeometrica) values(" & id_macizo & ", 'Macizo', 'Polilinea')"
    '        End If
    '        If tipoEntidadLogica = "parcela" Then
    '            sql = "INSERT into entidades (idEntidad, tipoEntidadLogica, tipoEntidadGeometrica) values(" & idEntidad & ", 'Parcela', 'Polilinea')"
    '        End If
    '        If tipoEntidadLogica = "Parcela lindera" Then
    '            sql = "INSERT into entidades (idEntidad, tipoEntidadLogica, tipoEntidadGeometrica) values(" & idEntidad & ", 'Parcela lindera', 'Polilinea')"
    '        End If
    '        If tipoEntidadLogica = "muro" Then
    '            sql = "INSERT into entidades (idEntidad, tipoEntidadLogica, tipoEntidadGeometrica) values(" & idEntidad & ", 'Parcela lindera', 'Polilinea')"
    '        End If
    '        Cmd.CommandText = sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()

    '        '----------------------
    '        'atributosGeometricos
    '        '----------------------
    '        If tipoEntidadLogica = "macizo" Then
    '            sql = "INSERT into atributosGeometricos (idEntidad, tipoLinea, espesor, color) values(" & id_macizo & ", '" & elTipoDeLinea & "', '" & elEspesorDeLinea & "', '" & elColorDeLinea & "')"
    '        Else
    '            sql = "INSERT into atributosGeometricos (idEntidad, tipoLinea, espesor, color) values(" & idEntidad & ", '" & elTipoDeLinea & "', '" & elEspesorDeLinea & "', '" & elColorDeLinea & "')"
    '        End If
    '        Cmd.CommandText = sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()

    '        '-----------------------
    '        'atributosLogicos
    '        '-----------------------
    '        If tipoEntidadLogica = "macizo" Then
    '            sql = "INSERT into atributosLogicos (idEntidad, nomenclatura, prefijosTextos, linderos, superficie, designacion, idMacizo) values (" & id_macizo & ", '" & datos & "', '-', 'macizo', 0, '-', " & id_macizo & ")"
    '        End If
    '        If tipoEntidadLogica = "parcela" Then
    '            sql = "INSERT into atributosLogicos (idEntidad, nomenclatura, prefijosTextos, linderos, superficie, designacion, idMacizo) values (" & idEntidad & ", '" & datos & "', '-', 'parcela ppal', 0, '-', " & "0000" & ")"
    '        End If
    '        If tipoEntidadLogica = "Parcela lindera" Then
    '            sql = "INSERT into atributosLogicos (idEntidad, nomenclatura, prefijosTextos, linderos, superficie, designacion, idMacizo) values (" & idEntidad & ", '" & datos & "', '-', 'parcela lindera', 0, '-', " & "0000" & ")"
    '        End If
    '        Cmd.CommandText = sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()

    '        '------------------------
    '        'tabla coordenadas
    '        '------------------------
    '        Try
    '            Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    '            Dim i As Integer
    '            Dim puntox, puntoy, puntoz As String
    '            For Each punto In laPolilinea.VertexList
    '                i = i + 1
    '                puntox = punto.x.ToString.Replace(",", ".")
    '                puntoy = punto.y.ToString.Replace(",", ".")
    '                puntoz = punto.z.ToString.Replace(",", ".")
    '                If tipoEntidadLogica = "macizo" Then
    '                    sql = "INSERT into coordenadas (idEntidad,X,Y,Z) values(" & id_macizo & "," & puntox & "," & puntoy & "," & puntoz & ")"
    '                Else
    '                    sql = "INSERT into coordenadas (idEntidad,X,Y,Z) values(" & idEntidad & "," & puntox & "," & puntoy & "," & puntoz & ")"
    '                End If

    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()
    '            Next
    '        Catch ex As Exception
    '            MsgBox("Error al guardar las coordenadas de la polilinea.")
    '        End Try

    '    ElseIf ds.Tables("tblEntidad").Rows.Count = 1 Then
    '        'EDICION:
    '        '--------------------------
    '        'tabla atributosGeometricos
    '        '--------------------------
    '        sql = "UPDATE atributosGeometricos SET tipoLinea='" & elTipoDeLinea & "', espesor='" & elEspesorDeLinea & "', color='" & elColorDeLinea & "' WHERE idEntidad=" & idEntidad
    '        Cmd.CommandText = sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()

    '        '---------------------------
    '        'tabla atributosLogicos
    '        '---------------------------
    '        sql = "UPDATE atributosLogicos SET nomenclatura='" & datos & "', prefijosTextos='-', superficie=0, designacion='-' WHERE idEntidad=" & idEntidad
    '        Cmd.CommandText = sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()

    '        '----------------------------
    '        'tabla coordenadas
    '        '----------------------------
    '        sql = "DELETE * from coordenadas where idEntidad=" & idEntidad
    '        Cmd.CommandText = sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()
    '        Try
    '            Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    '            Dim i As Integer
    '            Dim puntox, puntoy, puntoz As String
    '            For Each punto In laPolilinea.VertexList
    '                i = i + 1
    '                puntox = punto.x.ToString.Replace(",", ".")
    '                puntoy = punto.y.ToString.Replace(",", ".")
    '                puntoz = punto.z.ToString.Replace(",", ".")
    '                sql = "INSERT into coordenadas (idEntidad,X,Y,Z) values(" & idEntidad & "," & puntox & "," & puntoy & "," & puntoz & ")"
    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()
    '            Next
    '        Catch ex As Exception
    '            MsgBox("Error al guardar las coordenadas de la polilinea.")
    '        End Try

    '    Else
    '        MsgBox("Error de Inconsistencia. Hay mas de una entidad con el mismo Id.")
    '        Exit Sub
    '    End If

    'End Sub

    'Public Sub borrarSegmentos(ByVal nroTrabajo As Integer)
    '    If conexionMdb Is Nothing Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    End If

    '    Dim sql As String = "DELETE * FROM segmentosPl WHERE idParcela=" & nroTrabajo
    '    Dim Cmd As OleDbCommand = New OleDbCommand(sql, conexionMdb)
    '    Cmd.ExecuteNonQuery()

    'End Sub

    'Public Sub guardarSegmento(ByVal idParcela As Integer, ByVal pt1 As VectorDraw.Geometry.gPoint, ByVal pt2 As VectorDraw.Geometry.gPoint, ByVal nroParcela As String)
    '    '-------------------
    '    'alta
    '    '-------------------
    '    '24/03/13
    '    idEntidad = CInt(rnd.Next(999999))
    '    'pt1.GetHashCode()
    '    'pt1.Id
    '    If conexionMdb Is Nothing Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    End If
    '    Dim sql As String
    '    Dim Cmd As OleDbCommand = New OleDbCommand()

    '    Dim adaptador As New OleDb.OleDbDataAdapter("Select * from segmentosPl where idEntidad=" & idEntidad, conexionMdb)
    '    Dim ds As New DataSet
    '    adaptador.Fill(ds, "tblEntidad")
    '    If ds.Tables("tblEntidad").Rows.Count = 0 Then
    '        Try
    '            sql = "INSERT into segmentosPl (idEntidad, idParcela, x1, y1, z1, x2, y2, z2, nroParcela) values(" & idEntidad & ", " & idParcela & ", " & pt1.x & ", " & pt1.y & ", " & pt1.z & ", " & pt2.x & ", " & pt2.y & ", " & pt2.z & ", '" & nroParcela & "')"
    '            Cmd.CommandText = sql
    '            Cmd.Connection = conexionMdb
    '            Cmd.ExecuteNonQuery()
    '        Catch ex As Exception
    '            MsgBox("Hugo un error al guardar el segmento: " & ex.Message)
    '        End Try
    '    Else
    '        MsgBox("Ya existe este segmento")
    '        Exit Sub
    '    End If
    'End Sub

    'Public Function leerDatosEntidad(ByVal id As Integer) As DataTable
    '    If conexionMdb Is Nothing Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Return Nothing
    '        End If
    '    ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Return Nothing
    '        End If
    '    End If

    '    Dim adaptador As New OleDb.OleDbDataAdapter("Select * from entidades ent INNER JOIN " _
    '                                               & "(atributosGeometricos attg INNER JOIN " _
    '                                               & "atributosLogicos attl ON attg.identidad=attl.identidad) " _
    '                                               & "ON ent.identidad=attg.identidad " _
    '                                               & "WHERE ent.idEntidad=" & id, conexionMdb)
    '    'Dim adaptador As New OleDb.OleDbDataAdapter("SELECT atributosGeometricos.*, atributosLogicos.*, coordenadas.*, entidades.* " _
    '    '& "FROM entidades INNER JOIN " _
    '    '& "((atributosGeometricos INNER JOIN " _
    '    '& "atributosLogicos ON atributosGeometricos.idEntidad = atributosLogicos.identidad) INNER JOIN coordenadas ON atributosLogicos.identidad = coordenadas.idEntidad) " _
    '    '& " ON (atributosLogicos.identidad = entidades.idEntidad) AND (entidades.idEntidad = atributosGeometricos.idEntidad) " _
    '    '& "WHERE entidades.idEntidad=" & id, conexionMdb)

    '    'SELECT * FROM tabla1 INNER JOIN (tabla2 INNER JOIN 
    '    'tabla3 ON tabla2.campo=tabla3.campo) ON
    '    'tabla1.campo=tabla2.campo

    '    'Select campos
    '    'FROM tabla1 INNER JOIN
    '    '(tabla2 INNER JOIN [( ]tabla3
    '    '[INNER JOIN [( ]tablax [INNER JOIN ...)] 
    '    'ON tabla3.campo3 operadordecomparación tablax.campox)]
    '    'ON tabla2.campo2 operadordecomparación tabla3.campo3) 
    '    'ON tabla1.campo1 operadordecomparación tabla2.campo2;

    '    'SELECT entidades.*, atributosGeometricos.*, atributosLogicos.*, coordenadas.*
    '    'FROM ((entidades INNER JOIN atributosGeometricos ON entidades.idEntidad = atributosGeometricos.idEntidad)
    '    'INNER JOIN atributosLogicos ON entidades.idEntidad = atributosLogicos.identidad) 
    '    'INNER JOIN coordenadas ON entidades.idEntidad = coordenadas.idEntidad;

    '    Dim ds As New DataSet
    '    adaptador.Fill(ds, "tblEntidades")
    '    If ds.Tables("tblEntidades").Rows.Count = 0 Then
    '        Return Nothing
    '    ElseIf ds.Tables("tblEntidades").Rows.Count = 1 Then
    '        Return ds.Tables("tblEntidades")
    '    End If
    '    ds = Nothing
    '    ds.Dispose()
    '    adaptador = Nothing
    '    adaptador.Dispose()

    'End Function

    'Public Sub borrarSimbolo(ByVal nombre As String)
    '    If conexionMdb Is Nothing Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    End If

    '    Dim adaptador As New OleDb.OleDbDataAdapter("Select * from simbolos where nombreSimbolo='" & nombre & "'", conexionMdb)

    '    Dim dsSim As New DataSet
    '    adaptador.Fill(dsSim, "tblSimbolos")
    '    If dsSim.Tables("tblSimbolos").Rows.Count = 0 Then
    '        Exit Sub
    '    ElseIf dsSim.Tables("tblSimbolos").Rows.Count > 1 Then
    '        MsgBox("Hay mas de un simbolo con ese nombre")
    '        Exit Sub
    '    ElseIf dsSim.Tables("tblSimbolos").Rows.Count = 1 Then
    '        borrarEntidad(dsSim.Tables("tblSimbolos").Rows(0).Item("idEntidad"))
    '    End If
    '    dsSim.Dispose()
    '    dsSim = Nothing
    '    adaptador.Dispose()
    '    adaptador = Nothing

    'End Sub

    'Public Sub borrarEntidad(ByVal idEntidadABorrar As Integer)
    '    '---------
    '    'baja ...
    '    '---------
    '    idEntidad = idEntidadABorrar
    '    If conexionMdb Is Nothing Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    End If

    '    Dim sql As String = "SELECT tipoEntidadLogica FROM entidades WHERE idEntidad=" & idEntidad
    '    Dim Cmd As OleDbCommand = New OleDbCommand(sql, conexionMdb)
    '    Dim adaptador As New OleDbDataAdapter(sql, conexionMdb)
    '    Dim ds As New DataSet
    '    adaptador.Fill(ds, "tblEntidad")
    '    If ds.Tables("tblEntidad").Rows.Count = 1 Then
    '        If ds.Tables("tblEntidad").Rows(0).Item("tipoEntidadLogica") = "Macizo" Then
    '            'sql = "DELETE atributosLogicos.*, entidades.*, trabajoEntidad.*, coordenadas.*, atributosLogicos.idMacizo" _
    '            '    & " FROM ((atributosLogicos INNER JOIN entidades ON atributosLogicos.idEntidad = entidades.idEntidad) INNER JOIN trabajoEntidad ON entidades.idEntidad = trabajoEntidad.idEntidad) INNER JOIN coordenadas ON (entidades.idEntidad = coordenadas.idEntidad) AND (atributosLogicos.idEntidad = coordenadas.idEntidad)" _
    '            '    & " WHERE (((atributosLogicos.idMacizo)=" & idEntidad & "))"

    '            '----> nombre de calle:
    '            Cmd.CommandText = "select nombre_calle, idEntidad from atributosLogicos where ((not nombre_calle="""") and (idMacizo=" & idEntidad & "))"
    '            Cmd.Connection = conexionMdb
    '            adaptador.SelectCommand = Cmd
    '            adaptador.Fill(ds, "tblNombreCalle")
    '            For Each registro As DataRow In ds.Tables("tblNombreCalle").Rows
    '                sql = "DELETE * FROM entidades WHERE idEntidad=" & registro("idEntidad")
    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()
    '                sql = "DELETE * FROM trabajoEntidad WHERE idEntidad=" & registro("idEntidad")
    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()
    '                sql = "DELETE * FROM coordenadas WHERE idEntidad=" & registro("idEntidad")
    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()
    '                For Each entidad As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
    '                    If entidad.ToolTip <> "" Then
    '                        Dim auxiliar() As String = Split(entidad.ToolTip, ", id:")
    '                        If auxiliar.Count > 1 Then
    '                            If CInt(Trim(auxiliar(1))) = registro("idEntidad") Then
    '                                entidad.Deleted = True
    '                            End If
    '                        End If
    '                    End If
    '                Next

    '            Next

    '            '----> ancho de calle:
    '            Cmd.CommandText = "select ancho_calle, idEntidad from atributosLogicos where not ancho_calle="""" and idMacizo=" & idEntidad
    '            Cmd.Connection = conexionMdb
    '            adaptador.SelectCommand = Cmd
    '            adaptador.Fill(ds, "tblAnchoCalle")
    '            For Each registro As DataRow In ds.Tables("tblAnchoCalle").Rows
    '                sql = "DELETE * FROM entidades WHERE idEntidad=" & registro("idEntidad")
    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()
    '                sql = "DELETE * FROM trabajoEntidad WHERE idEntidad=" & registro("idEntidad")
    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()
    '                sql = "DELETE * FROM coordenadas WHERE idEntidad=" & registro("idEntidad")
    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()
    '                For Each entidad As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
    '                    If entidad.ToolTip <> "" Then
    '                        Dim auxiliar() As String = Split(entidad.ToolTip, ", id:")
    '                        If auxiliar.Count > 1 Then
    '                            If CInt(Trim(auxiliar(1))) = registro("idEntidad") Then
    '                                entidad.Deleted = True
    '                            End If
    '                        End If
    '                    End If
    '                Next
    '            Next

    '            '----> medida_lado_macizo:
    '            Cmd.CommandText = "select medida_lado_macizo, idEntidad from atributosLogicos where not medida_lado_macizo="""" and idMacizo=" & idEntidad
    '            Cmd.Connection = conexionMdb
    '            adaptador.SelectCommand = Cmd
    '            adaptador.Fill(ds, "tblLadoMacizo")
    '            For Each registro As DataRow In ds.Tables("tblLadoMacizo").Rows
    '                sql = "DELETE * FROM entidades WHERE idEntidad=" & registro("idEntidad")
    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()
    '                sql = "DELETE * FROM trabajoEntidad WHERE idEntidad=" & registro("idEntidad")
    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()
    '                sql = "DELETE * FROM coordenadas WHERE idEntidad=" & registro("idEntidad")
    '                Cmd.CommandText = sql
    '                Cmd.Connection = conexionMdb
    '                Cmd.ExecuteNonQuery()
    '                For Each entidad As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
    '                    If entidad.ToolTip <> "" Then
    '                        Dim auxiliar() As String = Split(entidad.ToolTip, ", id:")
    '                        If auxiliar.Count > 1 Then
    '                            If CInt(Trim(auxiliar(1))) = registro("idEntidad") Then
    '                                entidad.Deleted = True
    '                            End If
    '                        End If
    '                    End If
    '                Next
    '            Next
    '        End If
    '        ds = Nothing
    '        adaptador = Nothing
    '        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
    '    End If


    '    sql = "DELETE * FROM trabajoEntidad WHERE idEntidad=" & idEntidad
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()

    '    sql = "DELETE * FROM entidades WHERE idEntidad=" & idEntidad
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()

    '    sql = "DELETE * FROM coordenadas WHERE idEntidad=" & idEntidad
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()

    '    sql = "DELETE * FROM atributosLogicos WHERE idEntidad=" & idEntidad
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()

    '    sql = "DELETE * FROM atributosGeometricos WHERE idEntidad=" & idEntidad
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()

    '    sql = "DELETE * FROM simbolos WHERE idEntidad=" & idEntidad
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()


    '    'Dim adaptador As New OleDb.OleDbDataAdapter("Select * from muros where id_entidad='" & idEntidad.ToString & "'", conexionMdb)
    '    'Dim ds As New DataSet
    '    'adaptador.Fill(ds, "tblMuros")
    '    'If ds.Tables("tblMuros").Rows.Count > 0 Then
    '    sql = "DELETE * FROM muros WHERE id_entidad='" & idEntidad.ToString & "'"
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()
    '    'End If

    'End Sub

    'Public Sub agregarDatosMacizoLinderoBD(ByVal datos As String, ByVal laPolilinea As VectorDraw.Professional.vdFigures.vdPolyline)
    '    '---------
    '    'alta ...
    '    '---------
    '    idEntidad = laPolilinea.Handle.Value + CInt(rnd.Next(999999))
    '    If conexionMdb Is Nothing Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    End If

    '    Dim sql As String = "INSERT into trabajoEntidad (idTrabajo, idEntidad) values(" & idTrabajo & ", " & idEntidad & ")"
    '    Dim Cmd As OleDbCommand = New OleDbCommand(sql, conexionMdb)
    '    Cmd.ExecuteNonQuery()

    '    sql = "INSERT into entidades (idEntidad, tipoEntidadLogica, tipoEntidadGeometrica) values(" & idEntidad & ", 'Macizo Lindero', 'Polilinea')"
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()

    '    Dim elTipoDeLinea As String = laPolilinea.LineType.ToString
    '    Dim elEspesorDeLinea As String = laPolilinea.PenWidth.ToString
    '    Dim elColorDeLinea As String = laPolilinea.PenColor.ToString
    '    sql = "INSERT into atributosGeometricos (idEntidad, tipoLinea, espesor, color) values(" & idEntidad & ", '" & elTipoDeLinea & "', '" & elEspesorDeLinea & "', '" & elColorDeLinea & "')"
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()

    '    sql = "INSERT into atributosLogicos (idEntidad, nomenclatura, prefijosTextos, linderos, superficie, designacion) values (" & idEntidad & ", '" & datos & "', '-', 'macizo lindero', 0, '-')"
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()
    '    Try
    '        Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    '        Dim i As Integer
    '        Dim puntox, puntoy, puntoz As String
    '        For Each punto In laPolilinea.VertexList
    '            i = i + 1
    '            puntox = punto.x.ToString.Replace(",", ".")
    '            puntoy = punto.y.ToString.Replace(",", ".")
    '            puntoz = punto.z.ToString.Replace(",", ".")
    '            sql = "INSERT into coordenadas (idEntidad,X,Y,Z) values(" & idEntidad & "," & puntox & "," & puntoy & "," & puntoz & ")"
    '            Cmd.CommandText = sql
    '            Cmd.Connection = conexionMdb
    '            Cmd.ExecuteNonQuery()
    '        Next
    '    Catch ex As Exception
    '        MsgBox("Error al guardar las coordenadas de la polilinea.")
    '    End Try

    'End Sub

    'Public Sub agregarDatosDistanciaEsquinaBD(ByVal datos As String, ByVal laPolilinea As VectorDraw.Professional.vdFigures.vdPolyline)
    '    '---------
    '    'alta ...
    '    '---------
    '    idEntidad = laPolilinea.Handle.Value + CInt(rnd.Next(999999))
    '    If conexionMdb Is Nothing Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    End If

    '    Dim sql As String = "INSERT into trabajoEntidad (idTrabajo, idEntidad) values(" & idTrabajo & ", " & idEntidad & ")"
    '    Dim Cmd As OleDbCommand = New OleDbCommand(sql, conexionMdb)
    '    Cmd.ExecuteNonQuery()

    '    sql = "INSERT into entidades (idEntidad, tipoEntidadLogica, tipoEntidadGeometrica) values(" & idEntidad & ", 'Distancia esquina', 'Polilinea')"
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()

    '    Dim elTipoDeLinea As String = laPolilinea.LineType.ToString
    '    Dim elEspesorDeLinea As String = laPolilinea.PenWidth.ToString
    '    Dim elColorDeLinea As String = laPolilinea.PenColor.ToString
    '    sql = "INSERT into atributosGeometricos (idEntidad, tipoLinea, espesor, color) values(" & idEntidad & ", '" & elTipoDeLinea & "', '" & elEspesorDeLinea & "', '" & elColorDeLinea & "')"
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()

    '    sql = "INSERT into atributosLogicos (idEntidad, nomenclatura, prefijosTextos, linderos, superficie, designacion) values (" & idEntidad & ", '" & datos & "', '-', '-', 0, '-')"
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()
    '    Try
    '        Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    '        Dim i As Integer
    '        Dim puntox, puntoy, puntoz As String
    '        For Each punto In laPolilinea.VertexList
    '            i = i + 1
    '            puntox = punto.x.ToString.Replace(",", ".")
    '            puntoy = punto.y.ToString.Replace(",", ".")
    '            puntoz = punto.z.ToString.Replace(",", ".")
    '            sql = "INSERT into coordenadas (idEntidad,X,Y,Z) values(" & idEntidad & "," & puntox & "," & puntoy & "," & puntoz & ")"
    '            Cmd.CommandText = sql
    '            Cmd.Connection = conexionMdb
    '            Cmd.ExecuteNonQuery()
    '        Next
    '    Catch ex As Exception
    '        MsgBox("Error al guardar las coordenadas de la polilinea.")
    '    End Try

    'End Sub

    'Public Function guardarSimboloBD(ByVal handleBloque As ULong, ByVal nombre As String, ByVal puntoInsercion As VectorDraw.Geometry.gPoint, ByVal angulo As Double, ByVal medida As Double) As Integer

    '    '-------------------------------------
    '    ' guardar simbolos (norte por ahora..)
    '    '------------------------------------- 
    '    'If idEntidad = 0 Then
    '    '    Dim idEntidad As Integer = handleBloque + CInt(rnd.Next)
    '    'End If

    '    idEntidad = CInt(rnd.Next(999999))


    '    If conexionMdb Is Nothing Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Function
    '        End If
    '    ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Function
    '        End If
    '    End If

    '    Dim sql As String = "INSERT into simbolos " _
    '                      & "(idEntidad, nombreSimbolo, x, y, z, angulo, medida) " _
    '                      & "values(" _
    '                      & idEntidad & ", " _
    '                      & "'" & nombre & "', " _
    '                      & puntoInsercion.x & ", " _
    '                      & puntoInsercion.y & ", " _
    '                      & puntoInsercion.z & ", " _
    '                      & angulo & ", " _
    '                      & medida & ")"
    '    Dim Cmd As OleDbCommand = New OleDbCommand(sql, conexionMdb)
    '    Cmd.ExecuteNonQuery()

    '    'Dim tabla As New DataTable
    '    'Dim sqlId As String = "SELECT @@IDENTITY as ID"
    '    'Dim cmdId As New OleDbCommand(sqlId, conexionMdb)
    '    'Dim da As New OleDbDataAdapter(cmdId)
    '    'da.Fill(tabla)
    '    'Dim idSimbolo As Integer = tabla.Rows(0).Item(0)

    '    sql = "INSERT into trabajoEntidad (idTrabajo, idEntidad)" _
    '                      & " values(" & idTrabajo & ", " & idEntidad & ")"
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()
    '    '============VERLO POR MARCELO==================
    '    Dim id_entidad_bloque As Integer
    '    sql = "INSERT into entidades (idEntidad, tipoEntidadLogica, tipoEntidadGeometrica)" _
    '        & " values(" & idEntidad & ", 'Norte', 'Bloque')"
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()
    '    'Dim id_entidad_bloque1 As Integer = CInt(rnd.Next)
    '    'sql = "INSERT into entidades (idEntidad, tipoEntidadLogica, tipoEntidadGeometrica)" _
    '    '    & " values(" & id_entidad_bloque & ", 'Norte', 'Bloque')"
    '    'Cmd.CommandText = sql
    '    'Cmd.Connection = conexionMdb
    '    'Cmd.ExecuteNonQuery()

    '    sql = "INSERT into coordenadas (idEntidad,X,Y,Z) values(" & idEntidad & "," & puntoInsercion.x & "," & puntoInsercion.y & "," & puntoInsercion.z & ")"
    '    Cmd.CommandText = sql
    '    Cmd.Connection = conexionMdb
    '    Cmd.ExecuteNonQuery()

    '    Return idEntidad


    '    'Dim elTipoDeLinea As String = laPolilinea.LineType.ToString
    '    'Dim elEspesorDeLinea As String = laPolilinea.PenWidth.ToString
    '    'Dim elColorDeLinea As String = laPolilinea.PenColor.ToString
    '    'Sql = "INSERT into atributosGeometricos (idEntidad, tipoLinea, espesor, color) values(" & idEntidad & ", '" & elTipoDeLinea & "', '" & elEspesorDeLinea & "', '" & elColorDeLinea & "')"
    '    'Cmd.CommandText = Sql
    '    'Cmd.Connection = conexionMdb
    '    'Cmd.ExecuteNonQuery()

    '    'Sql = "INSERT into atributosLogicos (idEntidad, nomenclatura, prefijosTextos, linderos, superficie, designacion) values (" & idEntidad & ", '" & datos & "', '-', '-', 0, '-')"
    '    'Cmd.CommandText = Sql
    '    'Cmd.Connection = conexionMdb
    '    'Cmd.ExecuteNonQuery()
    '    'Try
    '    '    Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    '    '    Dim i As Integer
    '    '    Dim puntox, puntoy, puntoz As String
    '    '    For Each punto In laPolilinea.VertexList
    '    '        i = i + 1
    '    '        puntox = punto.x.ToString.Replace(",", ".")
    '    '        puntoy = punto.y.ToString.Replace(",", ".")
    '    '        puntoz = punto.z.ToString.Replace(",", ".")
    '    '        Sql = "INSERT into coordenadas (idEntidad,X,Y,Z) values(" & idEntidad & "," & puntox & "," & puntoy & "," & puntoz & ")"
    '    '        Cmd.CommandText = Sql
    '    '        Cmd.Connection = conexionMdb
    '    '        Cmd.ExecuteNonQuery()
    '    '    Next
    '    'Catch ex As Exception
    '    ' MsgBox("Error al guardar las coordenadas de la polilinea.")
    '    'End Try

    'End Function

    'Public Sub agregarDatosMacizoBD_muros(ByVal datos As String, ByVal laPolilinea As VectorDraw.Professional.vdFigures.vdPolyline, ByVal tipoEntidadLogica As String)

    '    Dim Random As New Random()
    '    '-------------------
    '    'alta o modificacion
    '    '-------------------
    '    idEntidad = laPolilinea.Handle.Value + CInt(rnd.Next(999999))

    '    If conexionMdb Is Nothing Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    End If

    '    Dim sql As String
    '    Dim Cmd As OleDbCommand = New OleDbCommand()

    '    Dim elTipoDeLinea As String = "SOLID" 'laPolilinea.LineType.ToString
    '    Dim elEspesorDeLinea As String = "0.15" ' laPolilinea.PenWidth.ToString
    '    Dim elColorDeLinea As String = ("0,128,0") 'laPolilinea.PenColor.ToString



    '    Dim adaptador As New OleDb.OleDbDataAdapter("Select * from entidades where idEntidad=" & idEntidad, conexionMdb)
    '    Dim ds As New DataSet
    '    adaptador.Fill(ds, "tblEntidad")
    '    If ds.Tables("tblEntidad").Rows.Count = 0 Then
    '        'ALTA:
    '        '--------------------
    '        'tabla trabajoEntidad
    '        '--------------------
    '        sql = "INSERT into trabajoEntidad (idTrabajo, idEntidad) values(" & idTrabajo & ", " & idEntidad & ")"
    '        Cmd.CommandText = sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()

    '        '---------------------
    '        'tabla entidades

    '        If tipoEntidadLogica = "muro" Then
    '            sql = "INSERT into entidades (idEntidad, tipoEntidadLogica, tipoEntidadGeometrica) values(" & idEntidad & ", 'Muro', 'Polilinea')"
    '        End If
    '        Cmd.CommandText = sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()

    '        '----------------------
    '        'atributosGeometricos
    '        '----------------------
    '        sql = "INSERT into atributosGeometricos (idEntidad, tipoLinea, espesor, color) values(" & idEntidad & ", '" & elTipoDeLinea & "', '" & elEspesorDeLinea & "', '" & elColorDeLinea & "')"
    '        Cmd.CommandText = sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()

    '        '-----------------------
    '        'Muros
    '        '-----------------------
    '        Dim punto1x As Double = _muro.puntosEjeParcela(0).X
    '        Dim punto1y As Double = _muro.puntosEjeParcela(0).Y
    '        Dim punto2x As Double = _muro.puntosEjeParcela(1).X
    '        Dim punto2y As Double = _muro.puntosEjeParcela(1).Y
    '        Dim ancho_m As Double = _muro.anchoMuro

    '        If tipoEntidadLogica = "muro" Then
    '            sql = "INSERT into muros (id_trabajo,id_entidad, punto1x,punto1y,punto2x,punto2y, ancho,diferencia1,diferencia2) values (" & identificadorTrabajo & "," & idEntidad & ", '" & punto1x & "','" & punto1y & "', '" & punto2x & "','" & punto2y & "','" & ancho_m & "' , " & diferencia1 & ", " & diferencia2 & ")"
    '        End If

    '        Cmd.CommandText = sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()


    '    ElseIf ds.Tables("tblEntidad").Rows.Count = 1 Then
    '        'EDICION:
    '        '--------------------------
    '        'tabla atributosGeometricos
    '        '--------------------------
    '        sql = "UPDATE atributosGeometricos SET tipoLinea='" & elTipoDeLinea & "', espesor='" & elEspesorDeLinea & "', color='" & elColorDeLinea & "' WHERE idEntidad=" & idEntidad
    '        Cmd.CommandText = sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()

    '        '---------------------------
    '        'tabla muros
    '        '---------------------------
    '        Dim punto1x As Double = _muro.puntosEjeParcela(0).X
    '        Dim punto1y As Double = _muro.puntosEjeParcela(0).Y
    '        Dim punto2x As Double = _muro.puntosEjeParcela(1).X
    '        Dim punto2y As Double = _muro.puntosEjeParcela(1).Y
    '        Dim ancho_m As Double = _muro.anchoMuro

    '        sql = "delete from muros  WHERE id_entidad=" & idEntidad
    '        Cmd.CommandText = sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()

    '        '----------------------------
    '        'vuelvo a cargar los datos
    '        '----------------------------
    '        If tipoEntidadLogica = "muro" Then
    '            sql = "INSERT into muros (id_trabajo,id_entidad, punto1x,punto1y,punto2x,punto2y, ancho,diferencia1,diferencia2) values (" & identificadorTrabajo & "," & idEntidad & ", '" & punto1x & "','" & punto1y & "', '" & punto2x & "','" & punto2y & "','" & ancho_m & "' , " & diferencia1 & ", " & diferencia2 & ")"
    '        End If

    '        Cmd.CommandText = sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()





    '    Else
    '        MsgBox("Error de Inconsistencia. Hay mas de una entidad con el mismo Id.")
    '        Exit Sub
    '    End If

    'End Sub

    'Public Sub elimino(ByVal id_ent)
    '    Dim Cmd As OleDbCommand = New OleDbCommand()
    '    Dim sql As String
    '    If conexionMdb Is Nothing Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
    '        If Not conectar() Then
    '            MsgBox("No se pudo establecer la conexion.")
    '            Exit Sub
    '        End If
    '    End If
    '    Dim adaptador As New OleDb.OleDbDataAdapter("Select * from trabajoEntidad where idtrabajo=" & id_ent, conexionMdb)
    '    Dim ds As New DataSet
    '    adaptador.Fill(ds, "trabajoEntidad")
    '    If ds.Tables("trabajoEntidad").Rows.Count = 0 Then

    '    Else
    '        Dim t As Integer
    '        Dim _id_entidad As Object
    '        For t = 0 To ds.Tables("trabajoEntidad").Rows.Count - 1

    '            _id_entidad = ds.Tables("trabajoEntidad").Rows(t).Item("idEntidad")

    '            sql = "delete from entidades  WHERE identidad=" & _id_entidad
    '            Cmd.CommandText = sql
    '            Cmd.Connection = conexionMdb
    '            Cmd.ExecuteNonQuery()

    '        Next
    '        t = 0
    '        _id_entidad = 0
    '        '=========================================================
    '        For t = 0 To ds.Tables("trabajoEntidad").Rows.Count - 1
    '            _id_entidad = ds.Tables("trabajoEntidad").Rows(t).Item("idEntidad")
    '            sql = "delete from atributosGeometricos  WHERE identidad=" & _id_entidad
    '            Cmd.CommandText = sql
    '            Cmd.Connection = conexionMdb
    '            Cmd.ExecuteNonQuery()

    '        Next

    '        '============================================================
    '        t = 0
    '        _id_entidad = 0
    '        For t = 0 To ds.Tables("trabajoEntidad").Rows.Count - 1
    '            _id_entidad = ds.Tables("trabajoEntidad").Rows(t).Item("idEntidad")
    '            sql = "delete from atributoslogicos  WHERE identidad=" & _id_entidad
    '            Cmd.CommandText = sql
    '            Cmd.Connection = conexionMdb
    '            Cmd.ExecuteNonQuery()

    '        Next

    '        '====================================================================
    '        t = 0
    '        _id_entidad = 0
    '        For t = 0 To ds.Tables("trabajoEntidad").Rows.Count - 1
    '            _id_entidad = ds.Tables("trabajoEntidad").Rows(t).Item("idEntidad")
    '            sql = "delete from trabajoEntidad  WHERE identidad=" & _id_entidad
    '            Cmd.CommandText = sql
    '            Cmd.Connection = conexionMdb
    '            Cmd.ExecuteNonQuery()

    '        Next

    '    End If


    '    conexionMdb.Close()
    'End Sub



End Module
