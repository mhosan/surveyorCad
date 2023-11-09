Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports ADOX


Public Class frmEstilos
    Dim filaSeleccionada As Integer
    Dim bsEstilos As New BindingSource

    Private Sub frmEstilos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargardatosGrilla()
        ListBox1.Visible = False
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cargardatosGrilla()
        'dgvEstilos.Rows.Clear()
        bsEstilos.DataSource = tblEstilos
        dgvEstilos.DataSource = bsEstilos

    End Sub
    Private Sub actualizarLaGrilla(ByVal filaseleccionada As Integer, ByVal columnaSeleccionada As Integer)

        If filaseleccionada = -1 Then Exit Sub
        'MsgBox("Fila: " & dgvEstilos(e.ColumnIndex, e.RowIndex).OwningRow.Cells("nombreEstilo").Value.ToString)
        'MsgBox("Columna: " & dgvEstilos(e.ColumnIndex, e.RowIndex).OwningColumn.HeaderText.ToString)
        'MsgBox("Nuevo valor: " & dgvEstilos(e.ColumnIndex, e.RowIndex).Value.ToString)
        actuEstilos(dgvEstilos(columnaSeleccionada, filaseleccionada).OwningRow.Cells("nombreEstilo").Value.ToString, dgvEstilos(columnaSeleccionada, filaseleccionada).OwningRow.Cells("tipoLetra").Value.ToString, dgvEstilos(columnaSeleccionada, filaseleccionada).OwningRow.Cells("altura").Value.ToString)
        leerEstilos()
        tipografias()
        For Each entidad As VectorDraw.Professional.vdPrimaries.vdFigure In frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities
            If entidad._TypeName = "vdText" Then
                If entidad.ToolTip <> "" Then
                    Dim texto As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText
                    texto.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                    texto.setDocumentDefaults()
                    If InStr(entidad.ToolTip.ToString, "Identificador Macizo") > 0 Then
                        texto = entidad
                        texto.Style = Nothing
                        texto.Style = estiloMz1
                    End If
                    If InStr(entidad.ToolTip.ToString, "Medida lado parcela") > 0 Then
                        texto = entidad
                        texto.Style = Nothing
                        texto.Style = estiloMedidaPl3
                    End If
                    If InStr(entidad.ToolTip.ToString, "Medida lado macizo") > 0 Then
                        texto = entidad
                        texto.Style = Nothing
                        texto.Style = estiloMedidaPl3
                    End If
                    If InStr(entidad.ToolTip.ToString, "Ancho de calle") > 0 Then
                        texto = entidad
                        texto.Style = Nothing
                        texto.Style = estiloNombreCalle2
                    End If
                    If InStr(entidad.ToolTip.ToString, "Nombre de calle") > 0 Then
                        texto = entidad
                        texto.Style = Nothing
                        texto.Style = estiloNombreCalle2
                    End If
                End If
            End If
        Next
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()

        'texto.Style = estiloMz1

    End Sub
    Private Sub dgvEstilos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEstilos.CellEndEdit
        actualizarLaGrilla(CInt(e.RowIndex), CInt(e.ColumnIndex))

    End Sub

    Private Sub dgvEstilos_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvEstilos.DataBindingComplete
        dgvEstilos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        With dgvEstilos.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .BackColor = Color.LightSteelBlue
            .ForeColor = Color.Cornsilk
            '.Font = New Font(.Font.FontFamily, .Font.Size, _
            ' .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
        End With
        With dgvEstilos
            Try
                .Columns("tachado").Visible = False
            Catch ex As Exception
                Err.Clear()
            End Try

            Try
                .Columns("sobrerayado").Visible = False
            Catch ex As Exception
                Err.Clear()
            End Try

            Try
                .Columns("subrayado").Visible = False
            Catch ex As Exception
                Err.Clear()
            End Try

            Try
                .Columns("negrita").Visible = False
            Catch ex As Exception
                Err.Clear()
            End Try

            Try
                .Columns("idEstilo").Visible = False
            Catch ex As Exception
                Err.Clear()
            End Try

            .Columns("nombreEstilo").HeaderText = "Nombre estilo"
            .Columns("nombreEstilo").ReadOnly = True
            .Columns("nombreEstilo").DefaultCellStyle.BackColor = Color.LightGray

            .Columns("tipoLetra").Visible = True
            .Columns("tipoLetra").HeaderText = "Tipografìa"
            .Columns("tipoLetra").ReadOnly = True

            'If Not .Columns.Contains("tipografia") = True Then
            '    Dim columnaTipoLetra As New DataGridViewComboBoxColumn()
            '    columnaTipoLetra.Name = "tipografiaCombo"
            '    columnaTipoLetra.HeaderText = "Tipografia"
            '    columnaTipoLetra.MaxDropDownItems = 4
            '    columnaTipoLetra.ReadOnly = True
            '    columnaTipoLetra.Items.Add("Times New Roman")
            '    columnaTipoLetra.Items.Add("Arial")
            '    columnaTipoLetra.Items.Add("Arial Narrow")
            '    columnaTipoLetra.Items.Add("Arial Black")
            '    .Columns.Add(columnaTipoLetra)

            '    For Each renglon As DataGridViewRow In dgvEstilos.Rows
            '        For Each registro As DataRow In tblEstilos.Rows
            '            If registro("nombreEstilo").ToString = renglon.Cells("nombreEstilo").Value Then
            '                'renglon.Cells("tipografiaCombo").Value = registro("tipoLetra").ToString
            '                columnaTipoLetra.Items.It()
            '            End If
            '        Next
            '    Next
            'End If

            .Columns("altura").HeaderText = "Altura"

        End With
    End Sub

    Private Sub dgvEstilos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEstilos.CellClick
        If e.ColumnIndex = 2 Then
            'MsgBox("esta es la columna de los tipos de letra")
            'mostrar opciones...(los distintos tipos de letra)
            filaSeleccionada = e.RowIndex
            ListBox1.Visible = True
        Else
            ListBox1.Visible = False
        End If

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        'MsgBox(ListBox1.SelectedItem.ToString)
        dgvEstilos("tipoLetra", filaSeleccionada).Value = ListBox1.SelectedItem.ToString
        actualizarLaGrilla(filaSeleccionada, dgvEstilos.Columns("tipoLetra").Index)
        ListBox1.Visible = False
    End Sub

    Private Sub frmEstilos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        ListBox1.Visible = False
    End Sub

    Private Sub dgvEstilos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvEstilos.Click
        ListBox1.Visible = False
    End Sub
End Class
