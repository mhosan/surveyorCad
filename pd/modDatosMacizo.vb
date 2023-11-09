Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports ADOX
Imports System.Windows.Forms
Imports VectorDraw.Geometry

Module modDatosMacizo

    Public Sub Carga_EntidadesCalle(ByVal pt1 As gPoint, ByVal pt2 As gPoint, ByVal ppto As gPoint, ByVal angulo As Object, ByVal dato As String, ByVal bandera As Integer) '(ByVal datos As String, ByVal laPolilinea As VectorDraw.Professional.vdFigures.vdPolyline, ByVal tipoEntidadLogica As String)

        Dim Random As New Random()
        conectar1()
        angulo = Math.Round(angulo, 2)
        Dim adaptador As New OleDb.OleDbDataAdapter("Select Max(idTrabajo)from trabajos ", conexionMdb1)
        Dim ds As New DataSet
        Dim sql As String
        Dim Cmd As OleDbCommand = New OleDbCommand()
        Dim idEnti As Integer
        Dim x, y, z As Double
        x = ppto.x
        y = ppto.y
        z = ppto.z
        adaptador.Fill(ds, "Trabajo")
        If ds.Tables("Trabajo").Rows.Count = 1 Then
            'sh:
            'ALTA: Siempre que se llega a esta pantalla es un alta
            idEnti = Random.Next(999999)

            If bandera = 1 Then '1=nombre de calle
                'sh:
                sql = "INSERT into trabajoEntidad (idTrabajo, idEntidad) values(" & idTrabajo & ", " & idEnti & ")"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()

                'si es nombre calle guardo el tipo de entidad
                sql = "INSERT into entidades (idEntidad, tipoEntidadLogica, tipoEntidadGeometrica) values(" & idEnti & ", 'Nombre Calle', 'Texto')"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()

                'guardo el nombre de la entidad calle
                sql = "INSERT into atributosLogicos (idEntidad,idmacizo, nombre_calle," _
                                          & " ladoMacizoPt1x, ladoMacizoPt1y, ladoMacizoPt1z," _
                                          & " ladoMacizoPt2x, ladoMacizoPt2y, ladoMacizoPt2z)" _
                                          & " values(" _
                                          & idEnti & ", " _
                                           & "'" & id_macizo & "', " _
                                          & "'" & dato & "', " _
                                          & pt1.x & ", " _
                                          & pt1.y & ", " _
                                          & pt1.z & ", " _
                                          & pt2.x & ", " _
                                          & pt2.y & ", " _
                                          & pt2.z & ")"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()

                'guardo los puntos y el angulo 
                sql = "INSERT into coordenadas (idEntidad , x,y,z,angulo) values(" & idEnti & ", " & x & ", " & y & ", " & z & ", " & angulo & " )"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()
            ElseIf bandera = 2 Then 'ancho de calle
                'sh:
                sql = "INSERT into trabajoEntidad (idTrabajo, idEntidad) values(" & idTrabajo & ", " & idEnti & ")"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()

                'si es  ancho de  la calle guardo el tipo de entidad
                sql = "INSERT into entidades (idEntidad, tipoEntidadLogica, tipoEntidadGeometrica) values(" & idEnti & ", 'Ancho Calle', 'Texto')"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()

                'guardo el ancho dela calle de la entidad calle
                'sql = "INSERT into atributosLogicos (idEntidad , ancho_calle) values(" & idEnti & ", '" & dato & "')"
                sql = "INSERT into atributosLogicos (idEntidad,idmacizo, ancho_calle," _
                                          & " ladoMacizoPt1x, ladoMacizoPt1y, ladoMacizoPt1z," _
                                          & " ladoMacizoPt2x, ladoMacizoPt2y, ladoMacizoPt2z)" _
                                          & " values(" _
                                          & idEnti & ", " _
                                          & "'" & id_macizo & "', " _
                                          & "'" & dato & "', " _
                                          & pt1.x & ", " _
                                          & pt1.y & ", " _
                                          & pt1.z & ", " _
                                          & pt2.x & ", " _
                                          & pt2.y & ", " _
                                          & pt2.z & ")"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()


                'guardo los puntos y el angulo 
                sql = "INSERT into coordenadas (idEntidad , x,y,z,angulo) values(" & idEnti & ", " & x & ", " & y & ", " & z & ", " & angulo & " )"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()

            ElseIf bandera = 4 Then
                'texto identificador del macizo, con la nomenclatura sin la parcela:
                'sh:
                sql = "INSERT into trabajoEntidad (idTrabajo, idEntidad) values(" & idTrabajo & ", " & idEnti & ")"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()

                sql = "INSERT into entidades (idEntidad, tipoEntidadLogica, tipoEntidadGeometrica) values(" & idEnti & ", 'Identificador Macizo', 'Texto')"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()

                sql = "INSERT into atributosLogicos (idEntidad,idmacizo, nomenclatura, designacion)" _
                                          & " values(" _
                                          & idEnti & ", " _
                                          & "'" & id_macizo & "', " _
                                          & "'" & dato & "', " _
                                          & "'Identificador Macizo')"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()

                sql = "INSERT into coordenadas (idEntidad , x,y,z,angulo) values(" & idEnti & ", " & x & ", " & y & ", " & z & ", " & angulo & " )"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()

            Else    'si es 3 es la medida del lado del macizo
                'sh:
                sql = "INSERT into trabajoEntidad (idTrabajo, idEntidad) values(" & idTrabajo & ", " & idEnti & ")"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()


                sql = "INSERT into entidades (idEntidad, tipoEntidadLogica, tipoEntidadGeometrica) values(" & idEnti & ", 'Medida Lado Macizo', 'Texto')"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()


                'guardo la medida
                'sql = "INSERT into atributosLogicos (idEntidad , medida_lado_macizo) values(" & idEnti & ", '" & dato & "')"
                sql = "INSERT into atributosLogicos (idEntidad,idMacizo, medida_lado_macizo," _
                                          & " ladoMacizoPt1x, ladoMacizoPt1y, ladoMacizoPt1z," _
                                          & " ladoMacizoPt2x, ladoMacizoPt2y, ladoMacizoPt2z)" _
                                          & " values(" _
                                          & idEnti & ", " _
                                          & "'" & id_macizo & "', " _
                                          & "'" & dato & "', " _
                                          & pt1.x & ", " _
                                          & pt1.y & ", " _
                                          & pt1.z & ", " _
                                          & pt2.x & ", " _
                                          & pt2.y & ", " _
                                          & pt2.z & ")"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()
                'guardo los puntos y el angulo 
                sql = "INSERT into coordenadas (idEntidad , x,y,z,angulo) values(" & idEnti & ", " & x & ", " & y & ", " & z & ", " & angulo & " )"
                Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
                Cmd.ExecuteNonQuery()
            End If
        End If
        conexionMdb1.Close()
    End Sub


    Public Sub GuardoDatosParcela()
        conectar1()
        Dim sql, sql1 As String
        Dim Cmd As OleDbCommand = New OleDbCommand()
        Dim id As Integer = idTrabajo
        Dim calle, numero As String
        Dim pavimento, alumbrado, energia, gas, cloacas, escuela, micros, domicilio_fiscal As Boolean
        Dim cadena As String
        Dim parcela As String = frmPruebaParcela.t_parcela.Text





        Try
            For Each row As DataGridViewRow In frmPruebaParcela.DgCalles.Rows
                If Not row.IsNewRow Then
                    calle = row.Cells("calle").Value
                    numero = row.Cells("numero").Value
                    pavimento = row.Cells("pavimento").Value
                    alumbrado = row.Cells("alumbrado").Value
                    energia = row.Cells("energia").Value
                    gas = row.Cells("gas").Value
                    cloacas = row.Cells("cloacas").Value
                    escuela = row.Cells("escuela").Value
                    micros = row.Cells("micros").Value
                    'domicilio_fiscal = row.Cells("domicilio_fiscal").Value
                    domicilio_fiscal = row.Cells("domi").Value
                    sql = "INSERT into servicios (id_trabajo , calle,numero,pavimento,alumbrado,energia_electrica,gas,cloacas,escuela,micros, domicilio_fiscal)" _
                        & "  values('" & id & "' ,'" & calle & "','" & numero & "'," & pavimento & "," _
                        & "  " & alumbrado & "," & energia & "," & gas & "," & cloacas & "," & escuela & "," & micros & "," & domicilio_fiscal & " )"
                    Cmd.CommandText = sql
                    Cmd.Connection = conexionMdb1
                    Cmd.ExecuteNonQuery()

                End If
            Next
        Catch ex As Exception
            MsgBox("Error con la grilla de los servicios")
            Err.Clear()
        End Try


        'dataGridview1.Rows(xFila).Cells("estado").value

        '======recorro el listbox rumbo para guardar todos los items==============================================================
        For ii As Integer = 0 To frmPruebaParcela.rumbos.Items.Count - 1 'recorro cada elemento del listbox
            cadena = frmPruebaParcela.rumbos.Items(ii)
            sql1 = "insert into  deslinde(id_trabajo,deslinde,designacion_parcela) values('" & id & "','" & cadena & "','" & parcela & "')"
            Cmd.CommandText = sql1
            Cmd.Connection = conexionMdb1
            Cmd.ExecuteNonQuery()
        Next


        conexionMdb1.Close()


    End Sub
    Public Sub GuardoDatosParcela_actualizar()
        conectar1()
        Dim sql, sql1 As String
        Dim Cmd As OleDbCommand = New OleDbCommand()
        Dim id As Integer = idTrabajo
       
        sql = "delete from servicios where id_trabajo like '" & id & "'"
        Cmd.CommandText = sql
                Cmd.Connection = conexionMdb1
        Cmd.ExecuteNonQuery()


        sql = "delete from deslinde where id_trabajo like '" & id & "'"
        Cmd.CommandText = sql
        Cmd.Connection = conexionMdb1
        Cmd.ExecuteNonQuery()
        conexionMdb1.Close()

        'Error de sintaxis (falta operador) en la expresión de consulta 'servicios where id_trabajo= '107''.


    End Sub

    'Sql = "INSERT into atributosGeometricos (idEntidad, tipoLinea, espesor, color) values(" & idEntidad & ", '" & elTipoDeLinea & "', '" & elEspesorDeLinea & "', '" & elColorDeLinea & "')"
    'Cmd.CommandText = Sql
    'Cmd.Connection = conexionMdb
    'Cmd.ExecuteNonQuery()

    'Sql = "INSERT into atributosLogicos (idEntidad, nomenclatura, prefijosTextos, linderos, superficie, designacion) values (" & idEntidad & ", '" & datos & "', '-', '-', 0, '-')"
    'Cmd.CommandText = Sql
    'Cmd.Connection = conexionMdb
    'Cmd.ExecuteNonQuery()

    'Try
    '    Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    '    Dim i As Integer
    '    Dim puntox, puntoy, puntoz As String
    '    For Each punto In laPolilinea.VertexList
    '        i = i + 1
    '        puntox = punto.x.ToString.Replace(",", ".")
    '        puntoy = punto.y.ToString.Replace(",", ".")
    '        puntoz = punto.z.ToString.Replace(",", ".")
    '        Sql = "INSERT into coordenadas (idEntidad,X,Y,Z) values(" & idEntidad & "," & puntox & "," & puntoy & "," & puntoz & ")"
    '        Cmd.CommandText = Sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()
    '    Next
    'Catch ex As Exception
    '    MsgBox("Error al guardar las coordenadas de la polilinea.")
    'End Try

    '    ElseIf ds.Tables("tblEntidad").Rows.Count = 1 Then
    ''EDICION:
    'Sql = "UPDATE atributosGeometricos SET tipoLinea='" & elTipoDeLinea & "', espesor='" & elEspesorDeLinea & "', color='" & elColorDeLinea & "' WHERE idEntidad=" & idEntidad
    'Cmd.CommandText = Sql
    'Cmd.Connection = conexionMdb
    'Cmd.ExecuteNonQuery()

    'Sql = "UPDATE atributosLogicos SET nomenclatura='" & datos & "', prefijosTextos='-', linderos='-', superficie=0, designacion='-' WHERE idEntidad=" & idEntidad
    'Cmd.CommandText = Sql
    'Cmd.Connection = conexionMdb
    'Cmd.ExecuteNonQuery()

    'Sql = "DELETE * from coordenadas where idEntidad=" & idEntidad
    'Cmd.CommandText = Sql
    'Cmd.Connection = conexionMdb
    'Cmd.ExecuteNonQuery()

    'Try
    '    Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint
    '    Dim i As Integer
    '    Dim puntox, puntoy, puntoz As String
    '    For Each punto In laPolilinea.VertexList
    '        i = i + 1
    '        puntox = punto.x.ToString.Replace(",", ".")
    '        puntoy = punto.y.ToString.Replace(",", ".")
    '        puntoz = punto.z.ToString.Replace(",", ".")
    '        Sql = "INSERT into coordenadas (idEntidad,X,Y,Z) values(" & idEntidad & "," & puntox & "," & puntoy & "," & puntoz & ")"
    '        Cmd.CommandText = Sql
    '        Cmd.Connection = conexionMdb
    '        Cmd.ExecuteNonQuery()
    '    Next
    'Catch ex As Exception
    '    MsgBox("Error al guardar las coordenadas de la polilinea.")
    'End Try

    '    Else
    'MsgBox("Error de Inconsistencia. Hay mas de una entidad con el mismo Id.")
    'Exit Sub
    '    End If


    'End If



End Module
