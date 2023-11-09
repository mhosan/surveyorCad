Imports System.IO
Module modVersion

    Public Sub seteaVersion(ByVal version As String)
        Select Case (version)
            Case "DEMO"
                Demo()
            Case "CPA"
                Cpa()
            Case "MHCAD"
                mhCad()
            Case Else
                Demo()
        End Select
    End Sub

    Private Sub Demo()
        frmPpal.GuardarToolStripMenuItem.Enabled = False
        frmPpal.GuardarComoToolStripMenuItem.Enabled = False
        frmPpal.GuardarToolStripButton.Enabled = False
        frmPpal.ImprimirPlotearToolStripMenuItem.Enabled = False
        frmPpal.ImprimirToolStripButton.Enabled = False
        frmPpal.AgrimensoresToolStripMenuItem.Visible = False
        frmPpal.ActivarProductoToolStripMenuItem.Visible = True
        frmPpal.Text = "MhCad"
        aplicacionNombre = "mhCad - Demo"
    End Sub

    Private Sub Cpa()
        frmPpal.GuardarToolStripMenuItem.Enabled = True
        frmPpal.GuardarComoToolStripMenuItem.Enabled = True
        frmPpal.GuardarToolStripButton.Enabled = True
        frmPpal.ImprimirPlotearToolStripMenuItem.Enabled = True
        frmPpal.ImprimirToolStripButton.Enabled = True
        frmPpal.AgrimensoresToolStripMenuItem.Visible = True
        frmPpal.ActivarProductoToolStripMenuItem.Visible = False
        frmPpal.Text = "CpaCad"
        aplicacionNombre = "CpaCad"
    End Sub

    Private Sub mhCad()
        frmPpal.GuardarToolStripMenuItem.Enabled = True
        frmPpal.GuardarComoToolStripMenuItem.Enabled = True
        frmPpal.GuardarToolStripButton.Enabled = True
        frmPpal.ImprimirPlotearToolStripMenuItem.Enabled = True
        frmPpal.ImprimirToolStripButton.Enabled = True
        frmPpal.AgrimensoresToolStripMenuItem.Visible = False
        frmPpal.ActivarProductoToolStripMenuItem.Visible = False
        frmPpal.Text = "mhCad"
        aplicacionNombre = "mhCad"
    End Sub

    Public Function getVersion() As String
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        '--------------------------------------------------------------------------
        ' verificar que existe la carpeta de soporte
        '--------------------------------------------------------------------------
        Dim carpetaSoporte As DirectoryInfo = New DirectoryInfo(Application.StartupPath & "\mhcadt")
        If carpetaSoporte.Exists = False Then
            MsgBox("No se encuentra la carpeta de soporte. Reportar error al mail: mhosan@gmail.com")
            End
        End If

        '--------------------------------------------------------------------------
        'verificar si existe el archivo de configuracion "mhCad.sys"
        '--------------------------------------------------------------------------
        Dim hayMhCadSys As FileInfo = New FileInfo(Application.StartupPath & "\mhcadt\mhCad.sys")
        If hayMhCadSys.Exists = False Then
            Return "Demo"
            Exit Function
        End If

        'leer archivo de version..
        Dim archivo As Stream = File.Open(hayMhCadSys.FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
        Dim lector As New StreamReader(archivo)
        Do Until lector.Peek = -1
            Return lector.ReadLine().ToString
            '        If queLeyo = "" Then Exit Do
            '        nada = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
            '        If Right(nada, 3) = "dwg" Or Right(nada, 3) = "DWG" Then
            '            'verificar si existe el archivo dwg que esta referenciado en el arch.intercamb.
            '            Dim hayDibujo As FileInfo = New FileInfo(nada)
            '            If hayDibujo.Exists = False Then
            '                MsgBox("No se encuentra el archivo " & nada & " que aparece en el archivo de intercambio.", MsgBoxStyle.Information, aplicacionNombre)
            '                'traer el dibujo de la plantilla..
            '                Dim exito As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.Open(hayPlantilla.FullName)
            '                If exito Then frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
            '                lector.Close()
            '                archivoActivo(hayPlantilla.Name)
            '                insertarDatosGrales()
            '                Exit Function
            '            Else
            '                Dim success As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.Open(nada)
            '                If (success) Then
            '                    frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
            '                    configurarInicio()
            '                    archivoActivo(nada)
            '                End If
            '            End If
            '            lector.Close()
            '            insertarDatosVisado()
            '            hayDwg = True
            '            Exit Do
            '        End If
        Loop
        '    'lector.Close()
        '    If hayDwg = False Then
        '        'traer el dibujo de la plantilla..
        '        Dim exito As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.Open(hayPlantilla.FullName)
        '        If exito Then frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        '        archivoActivo(hayPlantilla.Name)
        '        lector.Close()
        '        insertarDatosGrales()
        '    End If
        '    ultimoComando = "certificadoAmojonamiento"

    End Function

End Module
