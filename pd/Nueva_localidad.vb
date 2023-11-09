Imports System.Data

Public Class Nueva_localidad
    Dim tabla As New DataTable

    Private Sub Nueva_localidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim local As String

        local = "select distinct Cod_Part,partido from localidades"
        Dim adaptador As New OleDb.OleDbDataAdapter(local, conexionMdb1)
        adaptador.Fill(tabla)
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
        DataGridView1.DataSource = tabla



    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged


        'tabla.DefaultView.RowFilter = "Cod_Part like '%" & TextBox1.Text & "%' "
        tabla.DefaultView.RowFilter = "Cod_Part like '%" & TextBox1.Text & "%' "
        DataGridView1.DataSource = tabla.DefaultView




    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

        tabla.DefaultView.RowFilter = "Partido like '%" & TextBox2.Text & "%' "
        DataGridView1.DataSource = tabla.DefaultView
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

    End Sub
End Class