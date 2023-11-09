Module modBloques

    Public Sub Agregar_Bloques()
        '----------------------------------------------------------------------------
        ' insertar bloques ya existentes en el archivo "Bloques.dxf" que se encuentra
        ' en la carpeta de instalación del programa --> "C:\CpaCad2".
        ' este archivo trae los bloques de la plantilla de Catastro.
        '----------------------------------------------------------------------------
        Dim path0 As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "Bloques.dxf"
        Dim path1 As String = "C:\CpaCad2\Bloques.dxf"
        Dim path2 As String = ""

        If frmPpal.VdF.BaseControl.ActiveDocument.FindFile(path0, path2) Or frmPpal.VdF.BaseControl.ActiveDocument.FindFile(path1, path2) Then
            Dim ins1 As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert()
            ins1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            ins1.setDocumentDefaults()
            ins1.Block = frmPpal.VdF.BaseControl.ActiveDocument.Blocks.AddFromFile("C:\CpaCad2\Bloques.dxf", False)

            ins1.InsertionPoint = New VectorDraw.Geometry.gPoint(0, 0)
            'ins1.PenColor.ColorIndex = 55
            'ins1.Rotation = VectorDraw.Geometry.Globals.HALF_PI
            ins1.Rotation = 0
            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ins1)
        End If

        'Zoom in order to see the object.
        'vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        'vdFramedControl.BaseControl.ActiveDocument.Redraw(True)
        ultimoComando = "insert"

    End Sub

    Public Sub insertarBloque()

        Dim anduvoBien As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdInsertBlockDialog()
        If anduvoBien = True Then
            Dim bloqueInsertado As VectorDraw.Professional.vdFigures.vdInsert
            bloqueInsertado = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities(frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count - 1)
            If bloqueInsertado Is Nothing Then
                Exit Sub
            Else
                If bloqueInsertado.Attributes.Count > 0 Then
                    frmAte.cargarDatos(bloqueInsertado)
                    frmAte.ShowDialog()
                End If
            End If
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.RegenAll()
        End If

    End Sub
End Module
