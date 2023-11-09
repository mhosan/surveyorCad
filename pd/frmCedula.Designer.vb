<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCedula
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.DireccionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CedulaCastralBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NomenclaturaCatastralBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.reportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.DireccionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CedulaCastralBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NomenclaturaCatastralBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DireccionBindingSource
        '
        Me.DireccionBindingSource.DataSource = GetType(mhCad.FormServicios)
        '
        'CedulaCastralBindingSource
        '
        Me.CedulaCastralBindingSource.DataSource = GetType(mhCad.BO.NomenclaturaCatastral)
        '
        'NomenclaturaCatastralBindingSource
        '
        Me.NomenclaturaCatastralBindingSource.DataSource = GetType(mhCad.BO.NomenclaturaCatastral)
        '
        'reportViewer
        '
        Me.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DSUbicacion"
        ReportDataSource1.Value = Me.DireccionBindingSource
        ReportDataSource2.Name = "DSCedulaCatastral"
        ReportDataSource2.Value = Me.CedulaCastralBindingSource
        ReportDataSource3.Name = "DSNomenclaturaCatastral"
        ReportDataSource3.Value = Me.NomenclaturaCatastralBindingSource
        ReportDataSource4.Name = "DSDireccionTitular"
        ReportDataSource4.Value = Me.DireccionBindingSource
        Me.reportViewer.LocalReport.DataSources.Add(ReportDataSource1)
        Me.reportViewer.LocalReport.DataSources.Add(ReportDataSource2)
        Me.reportViewer.LocalReport.DataSources.Add(ReportDataSource3)
        Me.reportViewer.LocalReport.DataSources.Add(ReportDataSource4)
        Me.reportViewer.LocalReport.ReportEmbeddedResource = "mhCad.RptCedulaCatastral.rdlc"
        Me.reportViewer.Location = New System.Drawing.Point(0, 0)
        Me.reportViewer.Name = "reportViewer"
        Me.reportViewer.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual
        Me.reportViewer.ShowPrintButton = False
        Me.reportViewer.ShowRefreshButton = False
        Me.reportViewer.ShowStopButton = False
        Me.reportViewer.Size = New System.Drawing.Size(830, 508)
        Me.reportViewer.TabIndex = 0
        '
        'frmCedula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 508)
        Me.Controls.Add(Me.reportViewer)
        Me.Name = "frmCedula"
        Me.Text = "Cédula"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DireccionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CedulaCastralBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NomenclaturaCatastralBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents reportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DireccionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NomenclaturaCatastralBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CedulaCastralBindingSource As System.Windows.Forms.BindingSource

End Class
