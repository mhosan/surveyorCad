Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports ADOX
Imports System.Windows.Forms

Public Class frmNuevo

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        guardarTrabajoNuevo()
        frmPpal.tsLbIdTrabajo.Text = "Trabajo activo: " & frmPpal.tsLbIdTrabajo.Text
        frmPpal.tsdMacizo.Enabled = True
        frmPpal.tsdMacizoLinderos.Enabled = True
        frmPpal.tsdDistanciaEsquina.Enabled = True
        frmPpal.tsdParcela.Enabled = True
        frmPpal.tsdParcelaLindera.Enabled = True
        frmPpal.tsdSimbolos.Enabled = True
        obra_nueva = True
        frmEntrada.cargotabla()
        frmInicial.Show()
        Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        frmEntrada.Show()
        Me.Close()

    End Sub

    Private Sub guardarTrabajoNuevo()

        If txtDescripcion.Text = "" Then
            MsgBox("Completar descripcion.")
            Exit Sub
        End If
        If txtProfesional.Text = "" Then
            MsgBox("Completar profesional.")
            Exit Sub
        End If
        'If txtCliente.Text = "" Then
        '    MsgBox("Completar cliente.")
        '    Exit Sub
        'End If

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


        Dim fechaAltaTrabajo As String = Format(dtpFechaAlta.Value, "yyyy-MM-dd")

        Dim sql As String = "INSERT into trabajos (descripcion, fecha, profesional) values('" & txtDescripcion.Text.ToString & "', '" & fechaAltaTrabajo & "', '" & txtProfesional.Text.ToString & "')"
        Dim Cmd As OleDbCommand = New OleDbCommand(sql, conexionMdb)
        Cmd.ExecuteNonQuery()

        Dim tabla As New DataTable
        Dim sqlId As String = "SELECT @@IDENTITY as ID"
        Dim cmdId As New OleDbCommand(sqlId, conexionMdb)
        Dim da As New OleDbDataAdapter(cmdId)
        da.Fill(tabla)
        Dim idInsertar As Integer = tabla.Rows(0).Item(0)
        'lblIdTrabajo.Text = idInsertar.ToString
        frmPpal.tsLbIdTrabajo.Text = idInsertar.ToString

        identificadorTrabajo = tabla.Rows(0).Item(0)
        'sql = "INSERT into nomencla (pdo, pda, circ, secc, chan, chal, qtan, qtal, fran, fral, mzan, mzal, subp) values(" & Pdo & "," & Pda & "," & Circ & ",'" & Secc & "'," & ChaN & ",'" & ChaL & "'," & QtaN & ",'" & QtaL & "'," & FraN & ",'" & FraL & "'," & MzaN & ",'" & MzaL & "','" & Subp & "')"
        'Dim Cmd As OleDbCommand = New OleDbCommand(sql, conexionMdb)
        'Cmd.ExecuteNonQuery()
        cerrarConexion()
    End Sub

   

End Class
