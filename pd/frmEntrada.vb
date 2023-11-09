Imports System.Data
Imports Ionic.Zip
Imports System.IO
Imports System.Data.OleDb
Imports ADOX
Public Class frmEntrada
    Dim tabla As New DataTable

    Private Sub Entrada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cargotabla()
        formatoGrilla()
        'tipografias()

    End Sub
    Private Sub formatoGrilla()
        'Datag.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        With Datag.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .BackColor = Color.LightBlue
            '.ForeColor = Color.Cornsilk
            '.Font = New Font(.Font.FontFamily, .Font.Size, _
            ' .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
        End With
        For Each columna As DataGridViewColumn In Datag.Columns
            Select Case columna.Name
                Case Is = "idtrabajo"
                    'columna.Visible = False
                    'columna.Width = 100
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'columna.HeaderText = "Acuerdo/Enmienda Nro."
                Case Is = "descrip"
                    'columna.Width = 70
                    'columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    'columna.HeaderText = "Fecha Inicio"
                Case Is = "fecha"
                    'columna.Width = 70
                    'columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    'columna.HeaderText = "Fecha Fin"
                Case Is = "cliente"
                    'columna.Width = 100
                    'columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'columna.DefaultCellStyle.Format = "##,##0.00"
                    'columna.HeaderText = "Total acuerdo/enmienda"
            End Select
        Next
    End Sub
    Public Sub cargotabla()
        conectar1()
        Dim trabajos As String
        trabajos = "select * from trabajos order by [idTrabajo]"
        Dim tabla_t As New OleDb.OleDbDataAdapter(trabajos, conexionMdb1)
        tabla_t.Fill(tabla)
        Datag.AutoGenerateColumns = False
        Datag.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
        Datag.DataSource = tabla
        'conexionMdb1.Close()
        cerrarConexion1()
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub InciarObraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InciarObraToolStripMenuItem.Click
        Me.Hide()
        frmNuevo.ShowDialog()
        


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        identificadorTrabajo = Datag.CurrentRow.Cells("idTrabajo").Value   'Datag.CurrentRow.Index + 1
        trabajoexistente = True
        Me.Hide()
        obra_nueva = False
        frmInicial.Show()
    End Sub

    Private Sub Datag_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datag.CellContentClick

    End Sub

    Private Sub Datag_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Datag.DoubleClick
        identificadorTrabajo = Datag.CurrentRow.Cells("idTrabajo").Value
        trabajoexistente = True
        Me.Hide()
        obra_nueva = False
        frmInicial.Show()
    End Sub

    Private Sub ObrasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObrasToolStripMenuItem.Click

    End Sub

    Private Sub RealizarCopiaDeSeguridadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RealizarCopiaDeSeguridadToolStripMenuItem.Click

        Var_Cedula.creaCarpetaCopia()
        Dim bd_original As String = Application.StartupPath & "\planoDigitalDB\pd.mdb"
        'Dim copia As String = "c:\cpaPD\Copia de Seguridad\pd.mdb"



        ' Backup *.mdb database

        If File.Exists(bd_original) Then

            'Dim db As New DAO.DBEngine

            'CompactDatabase has two parameters, creates a copy of compact DB at the Destination path

            '   db.CompactDatabase(bd_original, copia)
            '  Dim dia As Date = Now

            Dim zip As New ZipFile()
            zip.AddFile(bd_original)
            zip.Save("C:\cpaPD\Copia de Seguridad\pd.zip")





        End If



        'Restore the original file from the compacted file

        'If File.Exists(sBackUpFile) Then

        '    File.Copy(sBackUpFile, sDBFile, True)

        'End If



    End Sub



    Private Sub RestaurarCopiaDeSeguridadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurarCopiaDeSeguridadToolStripMenuItem.Click

        If File.Exists("C:\cpaPD\Copia de Seguridad\pd.zip") Then
            Dim ZipAExtraer As String = "C:\cpaPD\Copia de Seguridad\pd.zip"
            Dim DirectorioExtraccion As String = "C:\cpaPD\Copia de Seguridad"
            Dim zip1 As ZipFile = ZipFile.Read(ZipAExtraer)
            Dim k As ZipEntry
            For Each k In zip1
                k.Extract(DirectorioExtraccion, ExtractExistingFileAction.OverwriteSilently)

            Next
            End
        End If
    End Sub



End Class