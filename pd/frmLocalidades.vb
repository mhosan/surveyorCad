Imports System.Data

Public Class frmLocalidades
    Dim tabla As New DataTable
    Dim localidades As String


    Public Sub mostrar1_grilla()
        conectar1()
        'Dim tabla = New DataTable  'Crea una nueva instancia de tabla
        tabla.Clear()
        Me.DataGridView1.DataSource = Nothing
        Dim adaptador = New OleDb.OleDbDataAdapter("select * from Localidades order by [Cod_Part]", conexionMdb1) 'Crea una <span class="IL_AD" id="IL_AD12">consulta</span>
        Dim constructor = New OleDb.OleDbCommandBuilder(adaptador) 'Se interpreta la consulta
        adaptador.Fill(tabla)
        DataGridView1.AutoGenerateColumns = False ' oculta el head, 
        'Se guarda los registros obtenido en la variable tabla
        DataGridView1.DataSource = tabla 'Se dibujan los datos en el DataGridView

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Nueva_localidad.ShowDialog()


    End Sub

    Private Sub localidades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        conectar1() 'conecta con la base de datos en el módulo conexiones 
        TextBox1.Clear()
        'localidades = "select * from Localidades"
        localidades = "select * from Localidades order by [Cod_Part]"
        Dim tabla_loca As New OleDb.OleDbDataAdapter(localidades, conexionMdb1)
        tabla_loca.Fill(tabla)
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
        DataGridView1.DataSource = tabla
        conexionMdb1.Close()




    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged


        If RadioButton1.Checked Then
            tabla.DefaultView.RowFilter = "Cod_Part like '%" & TextBox1.Text & "%' "

            DataGridView1.DataSource = tabla.DefaultView
        ElseIf RadioButton2.Checked Then
            tabla.DefaultView.RowFilter = "Localidad like '%" & TextBox1.Text & "%' "

            DataGridView1.DataSource = tabla.DefaultView
        ElseIf RadioButton3.Checked Then
            tabla.DefaultView.RowFilter = "Partido like '%" & TextBox1.Text & "%' "
            DataGridView1.DataSource = tabla.DefaultView

        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aceptar.Click
        '// Cargo en las variables globales el renglon seleccionado en el datagridview
        If DataGridView1.RowCount >= 1 Then
            cod_partido = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
            partido_1 = DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value
            localidad = DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value
            cod_postal = DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value
            '//

            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
            Me.Close()
        End If



    End Sub


    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        '// Cargo en las variables globales el renglon seleccionado en el datagridview
        If DataGridView1.RowCount >= 1 Then
            cod_partido = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
            partido_1 = DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value
            localidad = DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value
            cod_postal = DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value
            '//

            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' conectar() 'conecta con la base de datos en el módulo conexiones 
        'localidades = "delete  from Localidades where ID_COD by [Cod_Part]"
        'Dim tabla_loca As New OleDb.OleDbDataAdapter(localidades, conexionMdb)
        'tabla_loca.Fill(tabla)
        'DataGridView1.AutoGenerateColumns = False
        'DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
        'DataGridView1.DataSource = tabla
        'conexionMdb.Close()

        Dim identificados, t, h As VariantType
        h = DataGridView1.Rows.Count
        If h >= 2 Then
            conectar1()
            Dim resultado As Boolean = MsgBox("Eliminar Inmueble ?", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, "ATENCIÓN") = MsgBoxResult.Cancel
            If resultado Then Exit Sub
            identificados = DataGridView1.CurrentRow.Index()
            t = DataGridView1.Rows(identificados).Cells("identificador").Value
            Dim cmd As New OleDb.OleDbCommand("Delete from Localidades where id_cod like '" & t & "'", conexionMdb1)
            cmd.ExecuteNonQuery()
            conexionMdb1.Close()
            '// Voy al procedure a cargar la tabla de nuevo
            mostrar1_grilla()
            '//
        Else
            Dim resultado As Boolean = MsgBox("No existen Registros", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENCIÓN")
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        flag = 0

        Me.Close()

    End Sub
End Class