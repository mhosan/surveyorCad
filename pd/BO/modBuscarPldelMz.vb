Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports ADOX

Module modBuscarPldelMz

    Dim poli As VectorDraw.Professional.vdFigures.vdPolyline

    Public Function buscarParcelasDelMacizo() As List(Of VectorDraw.Professional.vdFigures.vdPolyline)
        Dim polilineasParcelasMacizo As New List(Of VectorDraw.Professional.vdFigures.vdPolyline)

        If conexionMdb Is Nothing Then
            If Not conectar() Then
                MsgBox("No se pudo establecer la conexion.")
                Return Nothing
            End If
        ElseIf conexionMdb.State = System.Data.ConnectionState.Closed Then
            If Not conectar() Then
                MsgBox("No se pudo establecer la conexion.")
                Return Nothing
            End If
        End If

        Dim tblTrabajoEntidades As New DataTable
        Dim sqlId As String = "SELECT * FROM trabajoEntidad WHERE idTrabajo =" & idTrabajo
        Dim cmdId As New OleDbCommand(sqlId, conexionMdb)
        Dim da As New OleDbDataAdapter(cmdId)
        da.Fill(tblTrabajoEntidades)
        If tblTrabajoEntidades.Rows.Count = 0 Then
            MsgBox("Este trabajo no tiene entidades.")
            Return Nothing
        End If

        For Each regEntidad As DataRow In tblTrabajoEntidades.Rows
            'recorro las entidades de este trabajo y me quedo con una parcela lindera
            Dim tblEntidad As New DataTable
            sqlId = "Select * from entidades where idEntidad =" & regEntidad.Item("idEntidad").ToString & " AND tipoEntidadLogica = 'Parcela lindera'"
            cmdId.CommandText = sqlId
            cmdId.Connection = conexionMdb
            da.SelectCommand = cmdId
            da.Fill(tblEntidad)
            If tblEntidad.Rows.Count = 0 Then
                'MsgBox("Inconsistencia. La entidad " & regEntidad.Item("idEntidad").ToString & " no se encuentra en la tabla de entidades")
                Continue For
            ElseIf tblEntidad.Rows.Count > 1 Then
                'MsgBox("Inconsistencia. La entidad " & regEntidad.Item("idEntidad").ToString & " se encuentra mas de una vez en la tabla de entidades (?)")
                Continue For
            End If

            Dim tblCoordenadas As New DataTable
            sqlId = "Select * from coordenadas where idEntidad =" & tblEntidad.Rows(0).Item("idEntidad").ToString
            cmdId.CommandText = sqlId
            cmdId.Connection = conexionMdb
            da.SelectCommand = cmdId
            da.Fill(tblCoordenadas)
            If tblCoordenadas.Rows.Count = 0 Then
                'MsgBox("La entidad " & regEntidad.Item("idEntidad").ToString & " no tiene coordenadas")
                Continue For
            End If

            Dim tblAtributosLogicos As New DataTable
            sqlId = "Select * from atributosLogicos where idEntidad =" & regEntidad.Item("idEntidad").ToString
            cmdId.CommandText = sqlId
            cmdId.Connection = conexionMdb
            da.SelectCommand = cmdId
            da.Fill(tblAtributosLogicos)
            If tblAtributosLogicos.Rows.Count = 0 Then
                'MsgBox("La entidad " & regEntidad.Item("idEntidad").ToString & " no tiene atributos logicos")
                Continue For
            ElseIf tblAtributosLogicos.Rows.Count > 1 Then
                'MsgBox("La entidad " & regEntidad.Item("idEntidad").ToString & " esta mas de una vez en la tabla de atributos logicos.")
                Continue For
            End If


            poli = New VectorDraw.Professional.vdFigures.vdPolyline
            poli.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            poli.setDocumentDefaults()

            For Each registro As DataRow In tblCoordenadas.Rows
                poli.VertexList.Add(CDbl(registro("x")), CDbl(registro("y")), CDbl(registro("z")), 0.0)
            Next
            'numerar los vertices:
            'numerarVerticesParcela(poli)
            poli.ToolTip = tblAtributosLogicos.Rows(0).Item("nomenclatura").ToString
            polilineasParcelasMacizo.Add(poli)
        Next

        Return polilineasParcelasMacizo

    End Function
End Module
