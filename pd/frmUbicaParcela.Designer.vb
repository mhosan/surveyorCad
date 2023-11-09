<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUbicaParcela
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.btnDistEsq = New System.Windows.Forms.Button()
        Me.lblEsquina = New System.Windows.Forms.Label()
        Me.btnEsquina = New System.Windows.Forms.Button()
        Me.lblLadoMz = New System.Windows.Forms.Label()
        Me.btnLadoMz = New System.Windows.Forms.Button()
        Me.lblVerticePl = New System.Windows.Forms.Label()
        Me.btnVertice = New System.Windows.Forms.Button()
        Me.lblDistEsquina = New System.Windows.Forms.Label()
        Me.lblParcela = New System.Windows.Forms.Label()
        Me.btnSeleccion = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(201, 180)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Enabled = False
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        '
        'btnDistEsq
        '
        Me.btnDistEsq.Location = New System.Drawing.Point(12, 140)
        Me.btnDistEsq.Name = "btnDistEsq"
        Me.btnDistEsq.Size = New System.Drawing.Size(129, 23)
        Me.btnDistEsq.TabIndex = 25
        Me.btnDistEsq.Text = "Dist. a esquina"
        Me.btnDistEsq.UseVisualStyleBackColor = True
        '
        'lblEsquina
        '
        Me.lblEsquina.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblEsquina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEsquina.Location = New System.Drawing.Point(155, 111)
        Me.lblEsquina.Name = "lblEsquina"
        Me.lblEsquina.Size = New System.Drawing.Size(190, 20)
        Me.lblEsquina.TabIndex = 24
        Me.lblEsquina.Text = "---"
        Me.lblEsquina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnEsquina
        '
        Me.btnEsquina.Location = New System.Drawing.Point(12, 111)
        Me.btnEsquina.Name = "btnEsquina"
        Me.btnEsquina.Size = New System.Drawing.Size(129, 23)
        Me.btnEsquina.TabIndex = 23
        Me.btnEsquina.Text = "Esquina de referencia"
        Me.btnEsquina.UseVisualStyleBackColor = True
        '
        'lblLadoMz
        '
        Me.lblLadoMz.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblLadoMz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLadoMz.Location = New System.Drawing.Point(155, 82)
        Me.lblLadoMz.Name = "lblLadoMz"
        Me.lblLadoMz.Size = New System.Drawing.Size(190, 20)
        Me.lblLadoMz.TabIndex = 22
        Me.lblLadoMz.Text = "---"
        Me.lblLadoMz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLadoMz
        '
        Me.btnLadoMz.Location = New System.Drawing.Point(12, 82)
        Me.btnLadoMz.Name = "btnLadoMz"
        Me.btnLadoMz.Size = New System.Drawing.Size(129, 23)
        Me.btnLadoMz.TabIndex = 21
        Me.btnLadoMz.Text = "Lado en macizo"
        Me.btnLadoMz.UseVisualStyleBackColor = True
        '
        'lblVerticePl
        '
        Me.lblVerticePl.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblVerticePl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVerticePl.Location = New System.Drawing.Point(155, 55)
        Me.lblVerticePl.Name = "lblVerticePl"
        Me.lblVerticePl.Size = New System.Drawing.Size(190, 20)
        Me.lblVerticePl.TabIndex = 20
        Me.lblVerticePl.Text = "---"
        Me.lblVerticePl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnVertice
        '
        Me.btnVertice.Location = New System.Drawing.Point(12, 53)
        Me.btnVertice.Name = "btnVertice"
        Me.btnVertice.Size = New System.Drawing.Size(129, 23)
        Me.btnVertice.TabIndex = 19
        Me.btnVertice.Text = "Vertice ubic. parcela"
        Me.btnVertice.UseVisualStyleBackColor = True
        '
        'lblDistEsquina
        '
        Me.lblDistEsquina.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblDistEsquina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDistEsquina.Location = New System.Drawing.Point(155, 142)
        Me.lblDistEsquina.Name = "lblDistEsquina"
        Me.lblDistEsquina.Size = New System.Drawing.Size(190, 20)
        Me.lblDistEsquina.TabIndex = 26
        Me.lblDistEsquina.Text = "---"
        Me.lblDistEsquina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParcela
        '
        Me.lblParcela.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblParcela.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblParcela.Location = New System.Drawing.Point(51, 15)
        Me.lblParcela.Name = "lblParcela"
        Me.lblParcela.Size = New System.Drawing.Size(169, 20)
        Me.lblParcela.TabIndex = 27
        Me.lblParcela.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSeleccion
        '
        Me.btnSeleccion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSeleccion.Location = New System.Drawing.Point(223, 13)
        Me.btnSeleccion.Name = "btnSeleccion"
        Me.btnSeleccion.Size = New System.Drawing.Size(84, 23)
        Me.btnSeleccion.TabIndex = 28
        Me.btnSeleccion.Text = "Seleccionar"
        '
        'frmUbicaParcela
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(359, 221)
        Me.Controls.Add(Me.btnSeleccion)
        Me.Controls.Add(Me.lblParcela)
        Me.Controls.Add(Me.lblDistEsquina)
        Me.Controls.Add(Me.btnDistEsq)
        Me.Controls.Add(Me.lblEsquina)
        Me.Controls.Add(Me.btnEsquina)
        Me.Controls.Add(Me.lblLadoMz)
        Me.Controls.Add(Me.btnLadoMz)
        Me.Controls.Add(Me.lblVerticePl)
        Me.Controls.Add(Me.btnVertice)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(60, 120)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUbicaParcela"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ubica Parcela"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents btnDistEsq As System.Windows.Forms.Button
    Friend WithEvents lblEsquina As System.Windows.Forms.Label
    Friend WithEvents btnEsquina As System.Windows.Forms.Button
    Friend WithEvents lblLadoMz As System.Windows.Forms.Label
    Friend WithEvents btnLadoMz As System.Windows.Forms.Button
    Friend WithEvents lblVerticePl As System.Windows.Forms.Label
    Friend WithEvents btnVertice As System.Windows.Forms.Button
    Friend WithEvents lblDistEsquina As System.Windows.Forms.Label
    Friend WithEvents lblParcela As System.Windows.Forms.Label
    Friend WithEvents btnSeleccion As System.Windows.Forms.Button

End Class
