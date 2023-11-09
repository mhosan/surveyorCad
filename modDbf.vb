Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.IO
Imports ADOX


Module modDbf

    Dim dondeEstanLosDatos As String ' = "C:\S.I.Ap\AFIP\PGF\Cad"
    Dim carpetaProgramas As String
    Public adaptador As OleDbDataAdapter
    'Public ds As New dataset
    Public conexionDbf As OdbcConnection
    Dim sCnn As String

    Dim parcelaNro As Double, parcelaLetra As String, sup As Double

    Dim linderos() As String, lado() As Double, rumbo() As Double, medida() As Double

    Dim Secc, ChaL, QtaL, FraL, MzaL, Subp As String
    Dim Pdo, Pda, Circ, ChaN, QtaN, FraN, MzaN As Double
    Dim distanciaEsquinaCota As Double, distanciaEsquinaCotaAnchoCalle As Double
    Dim distanciaEsquinaCotaNombreCalle As String

    Dim tipoSup() As String, planta() As Double, formu() As String, poligono() As Double, supPol() As Double

    Public Function buscarGuardarDatosDbf() As Boolean

        Try
            If Directory.Exists("c:\Archivos de programa (x86)") Then
                carpetaProgramas = "c:\Archivos de programa (x86)"
            ElseIf Directory.Exists("c:\Program Files (x86)") Then
                carpetaProgramas = "c:\Program Files (x86)"
            ElseIf Directory.Exists("c:\Archivos de programa") Then
                carpetaProgramas = "c:\Archivos de programa"
            ElseIf Directory.Exists("c:\Program Files") Then
                carpetaProgramas = "c:\Program Files"
            End If

            If Directory.Exists(carpetaProgramas & "\S.I.Ap\AFIP\PGF\Cad") Then
                dondeEstanLosDatos = carpetaProgramas & "\S.I.Ap\AFIP\PGF\Cad"
            Else
                MsgBox("No se encontrò el Pgf instalado.")
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, vbCritical)
            Return False
        End Try

        sCnn = "Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;Dbq=" & dondeEstanLosDatos & ";"
        Try
            conexionDbf = New System.Data.Odbc.OdbcConnection(sCnn)
            conexionDbf.Open()
        Catch ex As Exception
            Return False
        End Try

        '........................................................
        '  ojo, estoy buscando entidades solo en espacio MODELO!
        '........................................................
        For Each obj As VectorDraw.Professional.vdObjects.vdObject In frmPpal.VdF.BaseControl.ActiveDocument.Model.Entities

            '--------------------------------------------
            ' Nomenclatura, el bloque de la nomenclatura
            '--------------------------------------------
            If obj._TypeName = "vdInsert" Then
                Dim insercion As VectorDraw.Professional.vdFigures.vdInsert = CType(obj, VectorDraw.Professional.vdFigures.vdInsert)
                If insercion.Block.Name = "nomenclatura" Then
                    If insercion.XProperties.Count > 0 Then
                        If insercion.XProperties.FindName("Pdo") Is Nothing Then
                            MsgBox("Falta el partido")
                            Return False
                        End If
                        If insercion.XProperties.FindName("Pda") Is Nothing Then
                            MsgBox("Falta la partida")
                            Return False
                        End If
                        For Each prop As VectorDraw.Professional.vdObjects.vdXProperty In insercion.XProperties
                            If prop.Name = "Pdo" Then
                                Pdo = CDbl(prop.PropValue)
                                If Pdo = 0.0 Then
                                    MsgBox("Falta el partido")
                                    Return False
                                End If
                            ElseIf prop.Name = "Pda" Then
                                Pda = CDbl(prop.PropValue)
                                If Pda = 0.0 Then
                                    MsgBox("Falta la partida")
                                    Return False
                                End If
                            ElseIf prop.Name = "Circ" Then
                                Circ = CDbl(prop.PropValue)
                            ElseIf prop.Name = "Secc" Then
                                Secc = prop.PropValue.ToString
                            ElseIf prop.Name = "Chan" Then
                                ChaN = CDbl(prop.PropValue)
                            ElseIf prop.Name = "Chal" Then
                                ChaL = prop.PropValue.ToString
                            ElseIf prop.Name = "Qtan" Then
                                QtaN = CDbl(prop.PropValue)
                            ElseIf prop.Name = "Qtal" Then
                                QtaL = prop.PropValue.ToString
                            ElseIf prop.Name = "Fran" Then
                                FraN = CDbl(prop.PropValue)
                            ElseIf prop.Name = "Fral" Then
                                FraL = prop.PropValue.ToString
                            ElseIf prop.Name = "Mzan" Then
                                MzaN = CDbl(prop.PropValue)
                            ElseIf prop.Name = "Mzal" Then
                                MzaL = prop.PropValue.ToString
                            ElseIf prop.Name = "Subp" Then
                                Subp = prop.PropValue.ToString
                            End If
                        Next
                    End If
                End If
            End If


            '-------------------------------------------------
            ' Parcela, la polilinea cerrada de la parcela
            '-------------------------------------------------
            If obj._TypeName = "vdPolyline" Then
                Dim poli As VectorDraw.Professional.vdFigures.vdPolyline = CType(obj, VectorDraw.Professional.vdFigures.vdPolyline)
                If poli.XProperties.Count > 0 Then
                    If poli.XProperties.FindName("Tipo").PropValue.ToString = "Parcela" Then
                        For Each prop As VectorDraw.Professional.vdObjects.vdXProperty In poli.XProperties
                            If prop.Name = "Nro" Then
                                parcelaNro = CDbl(prop.PropValue)
                            ElseIf prop.Name = "Letra" Then
                                parcelaLetra = prop.PropValue.ToString
                            ElseIf prop.Name = "Area" Then
                                If prop.PropValue Is "--" Then
                                    sup = 0.0
                                Else
                                    sup = CDbl(prop.PropValue)
                                End If
                            End If
                        Next
                    End If
                End If
            End If


            '--------------------------------------------------
            ' Cotas, aca ojo que hay (hasta ahora) tres cotas:
            ' 1) la de los Deslindes
            ' 2) la distancia a esquina
            ' 3) el ancho de calle
            '--------------------------------------------------
            If obj._TypeName = "vdDimension" Then

                Dim cota As VectorDraw.Professional.vdFigures.vdDimension = CType(obj, VectorDraw.Professional.vdFigures.vdDimension)
                If cota.XProperties.Count > 0 Then

                    'Es una cota. Ver primero ver que valor trae en el campo "Tipo". 
                    If cota.XProperties.FindName("Tipo").PropValue.ToString = "Deslinde" Then
                        For Each prop As VectorDraw.Professional.vdObjects.vdXProperty In cota.XProperties
                            If prop.Name = "Linderos" Then
                                If linderos Is Nothing Then
                                    ReDim linderos(0)
                                Else
                                    ReDim Preserve linderos(UBound(linderos) + 1)
                                End If
                                linderos(UBound(linderos)) = prop.PropValue.ToString
                            ElseIf prop.Name = "Lado" Then
                                If lado Is Nothing Then
                                    ReDim lado(0)
                                Else
                                    ReDim Preserve lado(UBound(lado) + 1)
                                End If

                                Select Case prop.PropValue.ToString
                                    Case Is = "Frente"
                                        lado(UBound(lado)) = 1
                                    Case Is = "Contrafrente"
                                        lado(UBound(lado)) = 2
                                    Case Is = "Costado"
                                        lado(UBound(lado)) = 3
                                    Case Is = "Ochava"
                                        lado(UBound(lado)) = 4
                                    Case Is = "Fondo"
                                        lado(UBound(lado)) = 5
                                End Select
                            ElseIf prop.Name = "Rumbo" Then
                                If rumbo Is Nothing Then
                                    ReDim rumbo(0)
                                Else
                                    ReDim Preserve rumbo(UBound(rumbo) + 1)
                                End If

                                Select Case prop.PropValue.ToString
                                    Case Is = "N"
                                        rumbo(UBound(rumbo)) = 1
                                    Case Is = "NO"
                                        rumbo(UBound(rumbo)) = 2
                                    Case Is = "S"
                                        rumbo(UBound(rumbo)) = 3
                                    Case Is = "SO"
                                        rumbo(UBound(rumbo)) = 4
                                    Case Is = "O"
                                        rumbo(UBound(rumbo)) = 5
                                    Case Is = "SE"
                                        rumbo(UBound(rumbo)) = 6
                                    Case Is = "E"
                                        rumbo(UBound(rumbo)) = 7
                                    Case Is = "NE"
                                        rumbo(UBound(rumbo)) = 8
                                    Case Is = "NNO"
                                        rumbo(UBound(rumbo)) = 9
                                    Case Is = "NNE"
                                        rumbo(UBound(rumbo)) = 10
                                    Case Is = "SS"
                                        rumbo(UBound(rumbo)) = 11
                                    Case Is = "SSE"
                                        rumbo(UBound(rumbo)) = 12
                                    Case Is = "OSO"
                                        rumbo(UBound(rumbo)) = 13
                                    Case Is = "ENE"
                                        rumbo(UBound(rumbo)) = 14
                                    Case Is = "ONO"
                                        rumbo(UBound(rumbo)) = 15
                                    Case Is = "ESE"
                                        rumbo(UBound(rumbo)) = 16
                                End Select
                            ElseIf prop.Name = "Medida" Then
                                If medida Is Nothing Then
                                    ReDim medida(0)
                                Else
                                    ReDim Preserve medida(UBound(medida) + 1)
                                End If

                                medida(UBound(medida)) = CDbl(prop.PropValue)
                            End If
                        Next


                    ElseIf cota.XProperties.FindName("Tipo").PropValue.ToString = "DEsquinaCota" Then
                        distanciaEsquinaCota = CDbl(cota.XProperties.Item(1).PropValue)
                    ElseIf cota.XProperties.FindName("Tipo").PropValue.ToString = "DEsquinaCotaAnchoCalle" Then
                        distanciaEsquinaCotaAnchoCalle = CDbl(cota.XProperties(1).PropValue)
                    End If
                End If
            End If


            '-------------------------------------------------
            ' Distancia a esquina, el nombre de la calle, es un texto
            '-------------------------------------------------
            If obj._TypeName = "vdText" Then
                Dim texto As VectorDraw.Professional.vdFigures.vdText = CType(obj, VectorDraw.Professional.vdFigures.vdText)
                If texto.XProperties.Count > 0 Then
                    If texto.XProperties.FindName("Tipo").PropValue.ToString = "DEsquinaNombreCalle" Then
                        distanciaEsquinaCotaNombreCalle = texto.XProperties(1).PropValue.ToString
                    End If
                End If
            End If

            '------------------------------------------------------------------
            ' Poligono edificio
            '------------------------------------------------------------------
            If obj._TypeName = "vdPolyline" Then
                Dim poli As VectorDraw.Professional.vdFigures.vdPolyline = CType(obj, VectorDraw.Professional.vdFigures.vdPolyline)
                If poli.XProperties.Count > 0 Then
                    If poli.XProperties.FindName("Tipo").PropValue.ToString = "PEdificio" Then
                        For Each prop As VectorDraw.Professional.vdObjects.vdXProperty In poli.XProperties
                            If prop.Name = "Numero" Then
                                If poligono Is Nothing Then
                                    ReDim poligono(0)
                                Else
                                    ReDim Preserve poligono(UBound(poligono) + 1)
                                End If
                                poligono(UBound(poligono)) = CDbl(prop.PropValue)
                            ElseIf prop.Name = "Formulario" Then
                                If formu Is Nothing Then
                                    ReDim formu(0)
                                Else
                                    ReDim Preserve formu(UBound(formu) + 1)
                                End If
                                formu(UBound(formu)) = prop.PropValue.ToString
                            ElseIf prop.Name = "Area" Then
                                If supPol Is Nothing Then
                                    ReDim supPol(0)
                                Else
                                    ReDim Preserve supPol(UBound(supPol) + 1)
                                End If
                                If prop.PropValue Is "--" Then
                                    supPol(UBound(supPol)) = 0.0
                                Else
                                    supPol(UBound(supPol)) = CDbl(prop.PropValue)
                                End If
                            ElseIf prop.Name = "Planta" Then
                                If planta Is Nothing Then
                                    ReDim planta(0)
                                Else
                                    ReDim Preserve planta(UBound(planta) + 1)
                                End If
                                planta(UBound(planta)) = CDbl(prop.PropValue)
                            ElseIf prop.Name = "TipoArea" Then
                                If tipoSup Is Nothing Then
                                    ReDim tipoSup(0)
                                Else
                                    ReDim Preserve tipoSup(UBound(tipoSup) + 1)
                                End If
                                tipoSup(UBound(tipoSup)) = prop.PropValue.ToString
                            End If
                        Next
                    End If
                End If
            End If

        Next

        guardarDatos(Pdo, Pda)
        conexionDbf.Close()

    End Function


    Private Function insertar(ByVal pdoBuscar As Double, ByVal pdaBuscar As Double) As Boolean

        Dim adaptador As New OdbcDataAdapter("Select * from nomencla where pdo =" & pdoBuscar & " and pda =" & pdaBuscar, conexionDbf)
        Dim ds As New DataSet
        adaptador.Fill(ds, "tblNomencla")

        'ver que pasa si hay mas de un registro...
        If ds.Tables("tblNomencla").Rows.Count = 0 Then
            Return True
        ElseIf ds.Tables("tblNomencla").Rows.Count = 1 Then
            Return False
        End If
        ds = Nothing
        ds.Dispose()
        adaptador = Nothing
        adaptador.Dispose()

    End Function


    Private Sub guardarDatos(ByVal pdo As Double, ByVal pda As Double)

        Dim sql As String

        If insertar(pdo, pda) Then
            '============================================================================================
            ' Insertar
            '============================================================================================

            '----------------
            'Tabla "NOMENCLA", vienen datos del bloque de la nomenclatura y de la polilinea de la parcela
            '----------------
            sql = "INSERT into nomencla (pdo, pda, circ, secc, chan, chal, qtan, qtal, fran, fral, mzan, mzal, parcn, parcl, subp, superf) values(" & pdo & ", " & pda & ", " & Circ & ", '" & Secc & "', " & ChaN & ", '" & ChaL & "', " & QtaN & ", '" & QtaL & "', " & FraN & ", '" & FraL & "', " & MzaN & ", '" & MzaL & "', " & parcelaNro & ", '" & parcelaLetra & "', '" & Subp & "', " & sup & ")"
            Dim Cmd As OdbcCommand = New OdbcCommand(sql, conexionDbf)
            Cmd.ExecuteNonQuery()
            Cmd = Nothing

            '----------------
            'Tabla "LADOS", vienen los datos de las cotas de los deslindes.
            '----------------
            For a As Integer = 0 To UBound(rumbo)
                sql = "INSERT into lados (pdo, pda, parcn, parcl, rumbo, longi, cara, descrip) values(" & pdo & ", " & pda & ", " & parcelaNro & ", '" & parcelaLetra & "', " & rumbo(a) & ", " & medida(a) & ", " & lado(a) & ", '" & linderos(a) & "')"
                Cmd = New OdbcCommand(sql, conexionDbf)
                Cmd.ExecuteNonQuery()
                Cmd = Nothing
            Next

            '-----------------
            'Tabla "DATCOMPL", vienen datos de distancia a esquina, de dos cotas y un texto
            '-----------------
            sql = "INSERT into datcompl (pdo, pda, parcn, parcl, rumbcalle, distcalle, anchcalle) values(" & pdo & ", " & pda & ", " & parcelaNro & ", '" & parcelaLetra & "', '" & distanciaEsquinaCotaNombreCalle & "', " & distanciaEsquinaCota & ", " & distanciaEsquinaCotaAnchoCalle & ")"
            Cmd = New OdbcCommand(sql, conexionDbf)
            Cmd.ExecuteNonQuery()
            Cmd = Nothing

            '----------------
            'Tabla "POLIGIC", vienen datos de la polilinea de los poligonos de edificio
            '----------------
            For i As Integer = 0 To UBound(poligono)
                sql = "INSERT into poligic (pdo, pda, parcn, parcl, polig, formu, planta, tiposup, superf ) values(" & pdo & ", " & pda & ", " & parcelaNro & ", '" & parcelaLetra & "', " & poligono(i) & ", '" & formu(i) & "', " & planta(i) & ", '" & tipoSup(i) & "', " & supPol(i) & ")"
                Cmd = New OdbcCommand(sql, conexionDbf)
                Cmd.ExecuteNonQuery()
                Cmd = Nothing
            Next

        Else
            '========================================================================================
            ' Actualizar (update)
            '========================================================================================

            '----------------------
            'Tabla "NOMENCLA"
            '----------------------
            sql = "UPDATE nomencla set circ=" & Circ & ", secc='" & Secc & "', chan=" & ChaN & ", chal='" & ChaL & "', qtan=" & QtaN & ", qtal='" & QtaL & "', fran=" & FraN & ", fral='" & FraL & "', mzan=" & MzaN & ", mzal='" & MzaL & "', parcn=" & parcelaNro & ", parcl='" & parcelaLetra & "', subp='" & Subp & "', superf=" & sup & " WHERE pdo=" & pdo & " AND pda=" & pda
            Dim Cmd As OdbcCommand = New OdbcCommand(Sql, conexionDbf)
            Cmd.ExecuteNonQuery()
            Cmd = Nothing

            '------------------------------------
            'Tabla "LADOS"
            'primero borrar para luego insertar..
            '------------------------------------
            borrarRegistros(pdo, pda, "lados")
            For a As Integer = 0 To UBound(rumbo)
                sql = "INSERT into lados (pdo, pda, parcn, parcl, rumbo, longi, cara, descrip) values(" & pdo & ", " & pda & ", " & parcelaNro & ", '" & parcelaLetra & "', " & rumbo(a) & ", " & medida(a) & ", " & lado(a) & ", '" & linderos(a) & "')"
                Cmd = New OdbcCommand(sql, conexionDbf)
                Cmd.ExecuteNonQuery()
                Cmd = Nothing
            Next
            'For b As Integer = 0 To UBound(rumbo)
            '    sql = "UPDATE lados set parcn=" & parcelaNro & ", parcl='" & parcelaLetra & "', rumbo=" & rumbo(b) & ", longi=" & medida(b) & ", cara=" & lado(b) & ", descrip='" & linderos(b) & "' WHERE pdo=" & pdo & " AND pda=" & pda
            '    Cmd = New OdbcCommand(sql, conexionDbf)
            '    Cmd.ExecuteNonQuery()
            '    Cmd = Nothing
            'Next

            '-------------------------------
            'Tabla "DATCOMPL"
            '-------------------------------
            sql = "UPDATE datcompl set parcn=" & parcelaNro & ", parcl='" & parcelaLetra & "', rumbcalle='" & distanciaEsquinaCotaNombreCalle & "', distcalle=" & distanciaEsquinaCota & ", anchcalle=" & distanciaEsquinaCotaAnchoCalle & " WHERE pdo=" & pdo & " AND pda=" & pda
            Cmd = New OdbcCommand(sql, conexionDbf)
            Cmd.ExecuteNonQuery()
            Cmd = Nothing

            '--------------------------------------------------------------------------
            'Tabla "POLIGIC", vienen datos de la polilinea de los poligonos de edificio
            '--------------------------------------------------------------------------
            borrarRegistros(pdo, pda, "poligic")
            For i As Integer = 0 To UBound(poligono)
                sql = "INSERT into poligic (pdo, pda, parcn, parcl, polig, formu, planta, tiposup, superf ) values(" & pdo & ", " & pda & ", " & parcelaNro & ", '" & parcelaLetra & "', " & poligono(i) & ", '" & formu(i) & "', " & planta(i) & ", '" & tipoSup(i) & "', " & supPol(i) & ")"
                Cmd = New OdbcCommand(sql, conexionDbf)
                Cmd.ExecuteNonQuery()
                Cmd = Nothing
            Next


        End If

    End Sub


    Private Function borrarRegistros(ByVal partido As Double, ByVal partida As Double, ByVal tabla As String) As Boolean
        '---------------------------
        'DELETE
        '---------------------------

        Dim sql As String

        sql = "DELETE from " & tabla & " WHERE pdo = " & partido & " AND pda =" & partida
        Dim Cmd As OdbcCommand = New OdbcCommand(sql, conexionDbf)
        Cmd.ExecuteNonQuery()

        Cmd = Nothing

    End Function

End Module
