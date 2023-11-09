Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports ADOX

Module modAccess

    'Public dondeGuardarLosDatos As String = "C:\pruebas.mdb"
    'Public dondeGuardarLosDatos As String
    'Public dondeGuardarLosDatosTransitorio As String
    'Public adaptador As OleDb.OleDbDataAdapter
    'Public ds As New DataSet
    'Public conexionMdb As OleDb.OleDbConnection


    Public Function buscarGuardarDatos() As Boolean

        'La conexión a Access
        Dim conexionAccess As OleDb.OleDbConnection

        'La cadena de conexión
        Dim sCnn As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & dondeGuardarLosDatosTransitorio

        'Establecer y Abrir la conexión
        Try
            conexionAccess = New OleDbConnection(sCnn)
            conexionAccess.Open()
        Catch ex As Exception
            Return False
        End Try

        'Dim arrayXproperties As VectorDraw.Professional.vdCollections.StringArray = frmPpal.VdF.BaseControl.ActiveDocument.GetAllXpropertiesNames()
        Dim idPl() As String, sup As Double
        Dim linderos As String, lado As String, rumbo As String, medida As Double
        Dim Secc, ChaL, QtaL, FraL, MzaL, Subp As String
        Dim Pdo, Pda, Circ, ChaN, QtaN, FraN, MzaN As Double

        '........................................................
        '  ojo, estoy buscando entidades solo en espacio MODELO!
        '........................................................
        For Each obj As VectorDraw.Professional.vdObjects.vdObject In frmPpal.VdF.BaseControl.ActiveDocument.Model.Entities

            If obj._TypeName = "vdPolyline" Then
                Dim poli As VectorDraw.Professional.vdFigures.vdPolyline = CType(obj, VectorDraw.Professional.vdFigures.vdPolyline)
                If poli.XProperties.Count > 0 Then
                    For Each prop As VectorDraw.Professional.vdObjects.vdXProperty In poli.XProperties
                        If prop.Name = "Denominacion" Then
                            idPl = prop.PropValue.ToString.Split(" ")
                        ElseIf prop.Name = "Superficie" Then
                            sup = CDbl(prop.PropValue)
                        End If
                    Next
                    Dim sql As String = "INSERT into nomencla (parcn,parcl,superf) values(" & CDbl(idPl(0)) & ",'" & idPl(1) & "'," & sup & ")"
                    Dim Cmd As OleDbCommand = New OleDbCommand(sql, conexionAccess)
                    Cmd.ExecuteNonQuery()
                End If
            End If

            If obj._TypeName = "vdDimension" Then
                Dim cota As VectorDraw.Professional.vdFigures.vdDimension = CType(obj, VectorDraw.Professional.vdFigures.vdDimension)
                If cota.XProperties.Count > 0 Then
                    For Each prop As VectorDraw.Professional.vdObjects.vdXProperty In cota.XProperties
                        If prop.Name = "Linderos" Then
                            linderos = prop.PropValue.ToString
                        ElseIf prop.Name = "Lado" Then
                            lado = prop.PropValue.ToString
                        ElseIf prop.Name = "Rumbo" Then
                            rumbo = prop.PropValue.ToString
                        ElseIf prop.Name = "Medida" Then
                            medida = CDbl(prop.PropValue)
                        End If
                    Next
                    Dim sql As String = "INSERT into lados (rumbo,longi,cara,descrip) values('" & rumbo & "'," & medida & ",'" & lado & "','" & linderos & "')"
                    Dim Cmd As OleDbCommand = New OleDbCommand(sql, conexionAccess)
                    Cmd.ExecuteNonQuery()
                End If
            End If
            If obj._TypeName = "vdInsert" Then
                Dim insercion As VectorDraw.Professional.vdFigures.vdInsert = CType(obj, VectorDraw.Professional.vdFigures.vdInsert)
                If insercion.Block.Name = "nomenclatura" Then
                    If insercion.XProperties.Count > 0 Then
                        For Each prop As VectorDraw.Professional.vdObjects.vdXProperty In insercion.XProperties
                            If prop.Name = "Pdo" Then
                                Pdo = prop.PropValue.ToString
                            ElseIf prop.Name = "Pda" Then
                                Pda = prop.PropValue.ToString
                            ElseIf prop.Name = "Circ" Then
                                Circ = prop.PropValue.ToString
                            ElseIf prop.Name = "Secc" Then
                                Secc = prop.PropValue.ToString
                            ElseIf prop.Name = "Chan" Then
                                ChaN = prop.PropValue.ToString
                            ElseIf prop.Name = "Chal" Then
                                ChaL = prop.PropValue.ToString
                            ElseIf prop.Name = "Qtan" Then
                                QtaN = prop.PropValue.ToString
                            ElseIf prop.Name = "Qtal" Then
                                QtaL = prop.PropValue.ToString
                            ElseIf prop.Name = "Fran" Then
                                FraN = prop.PropValue.ToString
                            ElseIf prop.Name = "Fral" Then
                                FraL = prop.PropValue.ToString
                            ElseIf prop.Name = "Mzan" Then
                                MzaN = prop.PropValue.ToString
                            ElseIf prop.Name = "Mzal" Then
                                MzaL = prop.PropValue.ToString
                            ElseIf prop.Name = "Subp" Then
                                Subp = prop.PropValue.ToString
                            End If
                        Next
                        Dim adaptador As New OleDb.OleDbDataAdapter("Select * from nomencla", conexionAccess)
                        Dim ds As New DataSet
                        adaptador.Fill(ds, "tblNomencla")
                        Dim sql As String
                        If ds.Tables("tblNomencla").Rows.Count = 0 Then
                            sql = "INSERT into nomencla (pdo, pda, circ, secc, chan, chal, qtan, qtal, fran, fral, mzan, mzal, subp) values(" & Pdo & "," & Pda & "," & Circ & ",'" & Secc & "'," & ChaN & ",'" & ChaL & "'," & QtaN & ",'" & QtaL & "'," & FraN & ",'" & FraL & "'," & MzaN & ",'" & MzaL & "','" & Subp & "')"
                            Dim Cmd As OleDbCommand = New OleDbCommand(sql, conexionAccess)
                            Cmd.ExecuteNonQuery()
                        ElseIf ds.Tables("tblNomencla").Rows.Count = 1 Then
                            Dim parcelaNro As Double = ds.Tables("tblNomencla").Rows(0).Item("parcn")
                            sql = "UPDATE nomencla set pdo=" & Pdo & ", pda=" & Pda & ", circ=" & Circ & ", secc='" & Secc & "', chan=" & ChaN & ", chal='" & ChaL & "', qtan=" & QtaN & ", qtal='" & QtaL & "', fran=" & FraN & ", fral='" & FraL & "', mzan=" & MzaN & ", mzal='" & MzaL & "', subp='" & Subp & "' where parcn=" & parcelaNro
                            Dim Cmd As OleDbCommand = New OleDbCommand(sql, conexionAccess)
                            Cmd.ExecuteNonQuery()
                        End If
                    End If
                End If
            End If
        Next

        ''----------------------
        ''Borrar
        ''----------------------
        'sql = "DELETE * from nomencla where pdo='caca02'"
        'Cmd.CommandText = sql
        'Cmd.ExecuteNonQuery()

    End Function

    'Public Function armarMdb() As Boolean

    '    Dim posBackSlash As Integer = InStrRev(frmPpal.VdF.BaseControl.ActiveDocument.FileName, "\")
    '    Dim nombreSinPath As String = frmPpal.VdF.BaseControl.ActiveDocument.FileName.Substring(0, posBackSlash)
    '    Dim nombreSoloConExtension As String = frmPpal.VdF.BaseControl.ActiveDocument.FileName.Substring(posBackSlash)
    '    Dim nombreSoloSinExtension() As String = nombreSoloConExtension.Split(".")
    '    dondeGuardarLosDatos = nombreSinPath & nombreSoloSinExtension(0) & ".mdb"
    '    dondeGuardarLosDatosTransitorio = dondeGuardarLosDatos

    '    Try
    '        If System.IO.File.Exists(dondeGuardarLosDatos) Then
    '            System.IO.File.Delete(dondeGuardarLosDatos)
    '            GC.Collect()
    '            GC.WaitForPendingFinalizers()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, vbCritical)
    '        Return False
    '    End Try

    '    If System.IO.File.Exists(dondeGuardarLosDatos) = False Then
    '        Dim cat As New ADOX.Catalog
    '        Try
    '            'nueva base de datos access 2000, 2002 o 2003
    '            cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" _
    '                       & "Data Source= " & dondeGuardarLosDatos & ";" _
    '                       & "Jet OLEDB:Engine Type = 5;")
    '            MsgBox("Se ha creado la base de datos *.mdb en " & dondeGuardarLosDatos, vbOK, vbInformation)
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.OkOnly, vbCritical)
    '            Return False
    '        Finally
    '            cat.ActiveConnection = Nothing
    '            cat = Nothing
    '            GC.Collect()
    '            GC.WaitForPendingFinalizers()
    '        End Try
    '    End If

    '    'La cadena de conexión
    '    Dim sCnn As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & dondeGuardarLosDatos
    '    'Establecer y Abrir la conexión
    '    Try
    '        conexionMdb = New OleDbConnection(sCnn)
    '        conexionMdb.Open()
    '    Catch ex As Exception
    '        'MsgBox("Se ha producido error al abrir la conexion:" & ex.Message)
    '        'Exit Function
    '        Return False
    '    End Try

    '    ''supuestamente a esta altura el archivo mdb vacio esta creado. Y la conexion apuntandole esta abierta..
    '    Dim SQL As String = "CREATE TABLE nomencla ([Id]       COUNTER," _
    '                                             & "[pdo]      DOUBLE," _
    '                                             & "[pda]      DOUBLE," _
    '                                             & "[ordinal]  DOUBLE," _
    '                                             & "[circ]     DOUBLE," _
    '                                             & "[secc]     TEXT(2)," _
    '                                             & "[chan]     DOUBLE," _
    '                                             & "[chal]     TEXT(3)," _
    '                                             & "[qtan]     DOUBLE," _
    '                                             & "[qtal]     TEXT(4)," _
    '                                             & "[fran]     DOUBLE," _
    '                                             & "[fral]     TEXT(4)," _
    '                                             & "[mzan]     DOUBLE," _
    '                                             & "[mzal]     TEXT(3)," _
    '                                             & "[parcn]    DOUBLE," _
    '                                             & "[parcl]    TEXT(4)," _
    '                                             & "[subp]     TEXT(6)," _
    '                                             & "[superf]   DOUBLE," _
    '                                             & "[capturar] LOGICAL)"
    '    Dim Cmd As OleDbCommand = New OleDbCommand(SQL, conexionMdb)
    '    Cmd.ExecuteNonQuery()

    '    SQL = "CREATE TABLE datcompl (              [Id]       COUNTER," _
    '                                             & "[pdo]      DOUBLE," _
    '                                             & "[pda]      DOUBLE," _
    '                                             & "[parcn]    DOUBLE," _
    '                                             & "[parcl]    TEXT(4)," _
    '                                             & "[ordinal]  DOUBLE," _
    '                                             & "[enesq]    LOGICAL," _
    '                                             & "[rodeada]  LOGICAL," _
    '                                             & "[rumbcalle]TEXT(50)," _
    '                                             & "[distcalle]DOUBLE," _
    '                                             & "[anchcalle]DOUBLE," _
    '                                             & "[capturar] LOGICAL)"
    '    Cmd.CommandText = SQL
    '    Cmd.ExecuteNonQuery()

    '    SQL = "CREATE TABLE lados (         [Id]       COUNTER," _
    '                                     & "[pdo]      DOUBLE," _
    '                                     & "[pda]      DOUBLE," _
    '                                     & "[ordinal]  DOUBLE," _
    '                                     & "[parcn]    DOUBLE," _
    '                                     & "[parcl]    TEXT(4)," _
    '                                     & "[rumbo]    TEXT(10)," _
    '                                     & "[longi]    DOUBLE," _
    '                                     & "[cara]     TEXT(10)," _
    '                                     & "[descrip]  MEMO," _
    '                                     & "[capturar] LOGICAL)"
    '    Cmd.CommandText = SQL
    '    Cmd.ExecuteNonQuery()

    '    dondeGuardarLosDatos = ""
    '    dondeGuardarLosDatos = Nothing
    '    Cmd.Dispose()
    '    Cmd = Nothing
    '    conexionMdb.Close()
    '    conexionMdb.Dispose()
    '    conexionMdb = Nothing
    '    sCnn = Nothing
    '    GC.Collect()
    '    GC.WaitForPendingFinalizers()
    '    Return True

    'End Function

End Module
