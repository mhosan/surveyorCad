Imports System.Data
 
Public Class frmBuscaPersonas
    Dim dv As DataView
    Public tabla As New DataTable


    Public Sub mostrar_grilla()
        conectar1()
        'Dim tabla = New DataTable  'Crea una nueva instancia de tabla
        tabla.Clear()
        Me.Datag_personas.DataSource = Nothing
        Dim adaptador = New OleDb.OleDbDataAdapter("SELECT * FROM persona ", conexionMdb1) 'Crea una <span class="IL_AD" id="IL_AD12">consulta</span>
        Dim constructor = New OleDb.OleDbCommandBuilder(adaptador) 'Se interpreta la consulta
        adaptador.Fill(tabla)
        Datag_personas.AutoGenerateColumns = False ' oculta el head, 
        'Se guarda los registros obtenido en la variable tabla
        Datag_personas.DataSource = tabla 'Se dibujan los datos en el DataGridView

    End Sub


    Private Sub frmBuscaPersonas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mostrar_grilla()
        Check_cliente.Checked = False
        Check_comitente.Checked = False
        Check_contribuyente.Checked = False
        Check_titular.Checked = False
        Check_propietario.Checked = False


    End Sub

    Private Sub filtro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles filtro.KeyDown
        
    End Sub

    Private Sub filtro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles filtro.KeyPress
        'Dim ka As Integer
        'dv = tabla.DefaultView
        'ka = dv.Count
        'If ka >= 1 Then
        '    dv.RowFilter = "apellido like '%" & filtro.Text & "%' "
        '    Datag_personas.DataSource = dv

        '    'Button2.Enabled = True
        'Else
        'End If


        ''para cargar de nuevo el datagrid
        ''dv.RowFilter = ""
        ''Button2.Enabled = False
        ''T1.Text = ""

    End Sub

    Private Sub filtro_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles filtro.KeyUp
        'Dim ka As Integer
        'dv = tabla.DefaultView
        'ka = dv.Count


        'If ka >= 1 Then
        '    If RadioButton1.Checked = True Then
        '        dv.RowFilter = "apellido like '%" & Trim(filtro.Text) & "%' "
        '        Datag_personas.DataSource = dv

        '        'Button2.Enabled = True
        '    Else
        '        If RadioButton2.Checked = True Then
        '            dv.RowFilter = "doc like '%" & Trim(filtro.Text) & "%' "
        '            Datag_personas.DataSource = dv
        '        End If

        '        End If
        'End If



          
    End Sub

    Private Sub filtro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles filtro.TextChanged
        filtro.CharacterCasing = CharacterCasing.Upper
        Dim ka As Integer
        dv = tabla.DefaultView
        ka = dv.Count


        'If ka >= 1 Then ' si me da error destildo esto
        If RadioButton1.Checked = True Then
            dv.RowFilter = "apellido like '%" & Trim(filtro.Text) & "%' "
            Datag_personas.DataSource = dv

            'Button2.Enabled = True
        Else
            If RadioButton2.Checked = True Then
                dv.RowFilter = "doc like '%" & Trim(filtro.Text) & "%' "
                Datag_personas.DataSource = dv
            End If

        End If
        '    End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If dv Is Nothing Then

        Else
            dv.RowFilter = ""
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Datag.CurrentRow.Index + 1

        modPublico_pd.id_persona = Datag_personas.CurrentRow.Cells("id_persona").Value

        '=================Me guardo el id de c/persona asi lo guardo en el inicial==========
        If Check_cliente.Checked = True Then
            frmInicial.id_cli.Text = modPublico_pd.id_persona
            frmInicial.Tcliente.Text = Datag_personas.CurrentRow.Cells("apellido").Value & "," & " " & Datag_personas.CurrentRow.Cells("nombre").Value
        End If
        '======================================================================================
        If Check_contribuyente.Checked = True Then
            frmInicial.id_contri.Text = modPublico_pd.id_persona
            frmInicial.Tcontribuyene.Text = Datag_personas.CurrentRow.Cells("apellido").Value & "," & " " & Datag_personas.CurrentRow.Cells("nombre").Value
        End If
        '======================================================================================
        If Check_titular.Checked = True Then
            frmInicial.id_titu.Text = modPublico_pd.id_persona
            frmInicial.Ttitular.Text = Datag_personas.CurrentRow.Cells("apellido").Value & "," & " " & Datag_personas.CurrentRow.Cells("nombre").Value
        End If
        '======================================================================================
        If Check_comitente.Checked = True Then
            frmInicial.id_comi.Text = modPublico_pd.id_persona
            frmInicial.Tcomitente.Text = Datag_personas.CurrentRow.Cells("apellido").Value & "," & " " & Datag_personas.CurrentRow.Cells("nombre").Value
            '===================================================================================
        End If

        If Check_propietario.Checked = True Then
            frmInicial.id_propietario.Text = modPublico_pd.id_persona
            frmInicial.T_propietario.Text = Datag_personas.CurrentRow.Cells("apellido").Value & "," & " " & Datag_personas.CurrentRow.Cells("nombre").Value
            '===================================================================================
        End If

        If Check_cliente.Checked = False And Check_comitente.Checked = False And Check_contribuyente.Checked = False And Check_propietario.Checked = False And Check_titular.Checked = False Then
            modPublico_pd.id_persona = 0
        End If

        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

        frmPersonas.ShowDialog()
      
    End Sub
End Class