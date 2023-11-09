
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports ADOX

Module modConn

    Public Function conectar() As Boolean

        If Not setearDondeGuardarLosDatos() Then
            Return False
        End If

        'La cadena de conexión
        'Dim sCnn As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & dondeGuardarLosDatosTransitorio
        Dim sCnn As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & dondeGuardarLosDatos

        'Establecer y Abrir la conexión
        Try
            conexionMdb = New OleDbConnection(sCnn)
            conexionMdb.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Function setearDondeGuardarLosDatos() As Boolean

        'Dim nombre As String = frmPpal.vdf.BaseControl.ActiveDocument.FileName
        'If nombre = "" Then
        '    MsgBox("El archivo actual carece de nombre. Guardar y reintentar.")
        '    Return False
        'End If
        'Dim posBackSlash As Integer = InStrRev(frmPpal.vdf.BaseControl.ActiveDocument.FileName, "\")
        'Dim nombreSinPath As String = frmPpal.vdf.BaseControl.ActiveDocument.FileName.Substring(0, posBackSlash)
        'Dim nombreSoloConExtension As String = frmPpal.vdf.BaseControl.ActiveDocument.FileName.Substring(posBackSlash)
        'Dim nombreSoloSinExtension() As String = nombreSoloConExtension.Split(".")
        'dondeGuardarLosDatos = nombreSinPath & nombreSoloSinExtension(0) & ".mdb"
        'dondeGuardarLosDatosTransitorio = dondeGuardarLosDatos
        dondeGuardarLosDatos = Application.StartupPath & "\planoDigitalDB\pd.mdb"
        Return True
        'Try
        '    If System.IO.File.Exists(dondeGuardarLosDatos) Then
        '        System.IO.File.Delete(dondeGuardarLosDatos)
        '        GC.Collect()
        '        GC.WaitForPendingFinalizers()
        '        'Return True
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, vbCritical)
        '    Return False
        'End Try

        'If System.IO.File.Exists(dondeGuardarLosDatos) = False Then
        '    Dim cat As New ADOX.Catalog
        '    Try
        '        'nueva base de datos access 2000, 2002 o 2003
        '        cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" _
        '                   & "Data Source= " & dondeGuardarLosDatos & ";" _
        '                   & "Jet OLEDB:Engine Type = 5;")
        '        MsgBox("Se ha creado la base de datos *.mdb en " & dondeGuardarLosDatos, vbOK, vbInformation)
        '        Return True
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.OkOnly, vbCritical)
        '        Return False
        '    Finally
        '        cat.ActiveConnection = Nothing
        '        cat = Nothing
        '        GC.Collect()
        '        GC.WaitForPendingFinalizers()
        '    End Try
        'End If


    End Function

    Public Function cerrarConexion()
        If conexionMdb Is Nothing Then
            Return True
        End If

        Try
            conexionMdb.Close()
            conexionMdb.Dispose()
            conexionMdb = Nothing
            Return True
        Catch ex As Exception
            Return False
        Finally
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try

    End Function
End Module
