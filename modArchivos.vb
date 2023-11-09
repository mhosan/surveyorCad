Imports System.IO
Imports mhCad.frmPpal

Module modArchivos

    Public vectorUltimos() As String

    Public Sub importarAntecedenteGeodesia()
        '----------------------------------------------------------------------------------------
        ' insertar archivo antecedente como bloque y luego explotarlo, para no perder la sesion
        ' actual y que el archivo importado quede dentro del dibujo actual.
        '----------------------------------------------------------------------------------------
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        'If huboCambios() Then
        ' GuardarArchivoComo()
        'End If

        Dim ret As Object
        Directory.SetCurrentDirectory("c:\")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.GetOpenFileNameDlg(0, "", 0)
        If (ret Is Nothing) Then
            Exit Sub
        Else
            Dim fname As String = CType(ret, String)
            Dim ins1 As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert()
            ins1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
            ins1.setDocumentDefaults()
            ins1.Block = frmPpal.VdF.BaseControl.ActiveDocument.Blocks.AddFromFile(fname, False)

            ins1.InsertionPoint = New VectorDraw.Geometry.gPoint(0, 0)
            Dim entidades As VectorDraw.Professional.vdCollections.vdEntities = New VectorDraw.Professional.vdCollections.vdEntities
            ins1.Rotation = 0
            entidades = ins1.Explode()

            For a = 0 To entidades.Count - 1
                frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(entidades(a))
            Next

            frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents()
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
            ultimoComando = "importarAntecedenteGeodesia"
        End If

    End Sub

    Public Sub plantillaGeodesia()
        '-------------------------------------------------------------------------------------------------
        '26/7/2010, anulada por ahora, hasta que se defina exactamente como es el nombre y extension de la 
        'plantilla.
        '16/1/2011, activada nuevamente. Que la busque por default en la carpeta del programa y si no esta
        'mostrar cuadro de dialogo de seleccionar archivo.
        'Por lo tanto se usa el procedimiento "AbrirDwt"
        '-------------------------------------------------------------------------------------------------
        AbrirDwt()

        'If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
        '    frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        'End If

        'If huboCambios() Then
        '    GuardarArchivo()
        'End If

        'Dim plantillaOriginal As New FileInfo(ubicacionSoporte & "\PlantGeodesia01.dwg")
        'Dim existe As Boolean = plantillaOriginal.Exists
        'If existe Then
        '    plantillaOriginal.CopyTo("C:\CpaCad2\PlantillaGeodesia.dwg", True)
        '    Dim fname As String = "C:\CpaCad2\PlantillaGeodesia.dwg"
        '    Dim success As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.Open(fname)
        '    If (success) Then frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
        '    configurarInicio()
        '    archivoActivo(fname)
        'Else
        '    MsgBox("No se encuentra el archivo de la plantilla de Geodesia", MsgBoxStyle.Information, aplicacionNombre)
        'End If
        'ultimoComando = "plantillaGeodesia"
    End Sub

    Public Function huboCambios() As Boolean
        Dim cantEntidades As Integer = frmPpal.VdF.BaseControl.ActiveDocument.PrimaryCount
        Dim huboCambiosEnarchivo As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.IsModified

        huboCambios = huboCambiosEnarchivo

    End Function

    Public Sub NuevoArchivo()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        Dim version As String = frmPpal.versionCad

        If huboCambios() And frmPpal.versionCad <> "Demo" Then
            GuardarArchivo()
        End If


        If frmPpal.VdF.BaseControl.Visible = False Then
            frmPpal.VdF.BaseControl.Visible = True
        End If

        archivoActivo("")
        frmPpal.VdF.BaseControl.ActiveDocument.[New]()
        configurarInicio()
        ultimoComando = "nuevoArchivo"

    End Sub

    Public Sub AbrirDwt()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        If huboCambios() And frmPpal.versionCad <> "Demo" Then
            GuardarArchivo()
        End If

        Dim archivoAbrir As String
        With frmPpal.ofdDwt
            .CheckFileExists = True
            .ShowReadOnly = False
            .Filter = "Archivos dwg|*.dwg|Archivos dwt|*.dwt"
            .FilterIndex = 2
            .FileName = ""
            .InitialDirectory = "C:\CpaCad2"
            If .ShowDialog = DialogResult.OK Then
                Dim fname As New FileInfo(.FileName)
                If fname.Extension = ".dwt" Then
                    fname.CopyTo(fname.ToString.Substring(0, (fname.ToString.Length - 4)) & ".dwg", True)
                    archivoAbrir = fname.ToString.Substring(0, (fname.ToString.Length - 4)) & ".dwg"
                Else
                    archivoAbrir = fname.ToString
                End If


                If frmPpal.VdF.BaseControl.Visible = False Then
                    frmPpal.VdF.BaseControl.Visible = True
                End If
                Dim exito As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.Open(archivoAbrir)
                If exito Then
                    'si es la plantilla de catastro mover...
                    frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                    configurarInicio()
                    archivoActivo(archivoAbrir)
                End If
            End If
        End With
        ultimoComando = "abrirDwt"

    End Sub

    Public Sub AbrirArchivo(Optional ByVal nombreArchivo As String = "")

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        If huboCambios() And frmPpal.versionCad <> "Demo" Then
            Dim respuesta As Integer = MsgBox("Guardar cambios?", MsgBoxStyle.YesNo, aplicacionNombre)
            If respuesta = 6 Then
                GuardarArchivo()
            End If
        End If

        If frmPpal.VdF.BaseControl.Visible = False Then
            frmPpal.VdF.BaseControl.Visible = True
        End If

        Dim ret As Object
        If nombreArchivo = "" Then
            ret = frmPpal.VdF.BaseControl.ActiveDocument.GetOpenFileNameDlg(0, "", 0)
            If (ret Is Nothing) Then Return
        Else
            ret = nombreArchivo
        End If

        Dim fname As String = CType(ret, String)
        Dim success As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.Open(fname)
        If (success) Then
            frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
            configurarInicioArchivoExistente()
            archivoActivo(fname)
        End If
        actualizarCmbLayers()
        ultimoComando = "abrirArchivo"

    End Sub

    Public Sub puntas()

        frmConfiguraImpresion.ShowDialog()

    End Sub

    Public Sub imprimir()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        'frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdPrintDialog("E", "F")

        Dim printerDelDoc As VectorDraw.Professional.vdObjects.vdPrint = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Printer
        'printerDelDoc.DocumentName = "VectorDraw Printing Document"
        'printerDelDoc.GetPapers.AddItem("A4 extendido: 220 x 310 mm")
        Dim printer As VectorDraw.Professional.vdObjects.vdPrint = New VectorDraw.Professional.vdObjects.vdPrint(printerDelDoc)
        printer.PrinterName = VectorDraw.Professional.Utilities.vdGlobals.GetFileName(frmPpal.VdF.BaseControl.ActiveDocument.FileName)


        printer.InitializePreviewFormProperties(True, True, False, False)
        '                                      (zoom extents, scaled to fit, pulgadas, vista parcial) 

        printer.SelectPaper("ISO A4: 210 x 297 mm")

        'ojo que las medidas de los margenes estan en decimas de pulgadas!
        'x mm * 0.1" / 2.54 mm = medida a usar (en decimas de pugadas)
        'si quiero 10 mm --> 10 * 0.1 / 2.54 = 
        printer.margins.Left = 0.0 '0.984251968503937    '25 mm pasados a pulgadas: 25mm / 25.4
        printer.margins.Right = 0.0 '0.19685039370078741 '5 mm
        printer.margins.Bottom = 0.0 '0.19685039370078741
        printer.margins.Top = 0.0 '0.19685039370078741


        '---------------------
        'Las puntas..
        Dim espesoresPuntas As VectorDraw.Geometry.DoubleArray = New VectorDraw.Geometry.DoubleArray
        For Each elemento As Double In matrizEspesores
            espesoresPuntas.Add(elemento)
        Next
        printer.Penwidth = espesoresPuntas
        '---------------------


        '---------------------
        ' La impresora
        '---------------------
        'printer.PrinterSetup()

        printer.DialogPreview()
        ultimoComando = "imprimir"

    End Sub

    Public Sub cerrarArchivo()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        If huboCambios() And frmPpal.versionCad <> "Demo" Then
            Dim respuesta As Integer = MsgBox("Guardar cambios?", MsgBoxStyle.YesNo, aplicacionNombre)
            If respuesta = 6 Then
                GuardarArchivo()
            End If
        End If

        archivoActivo("No hay ningún archivo abierto.")
        'archivoActivo(frmPpal.VdF.BaseControl.ActiveDocument.FileName)
        frmPpal.VdF.BaseControl.ActiveDocument.[New]()
        frmPpal.VdF.BaseControl.ActiveDocument.Dispose()

        frmPpal.VdF.BaseControl.Visible = False

    End Sub

    Public Sub GuardarArchivo()

        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        Dim posBackSlash As Integer = InStrRev(frmPpal.VdF.BaseControl.ActiveDocument.FileName, "\")
        Dim nombreSinPath As String = frmPpal.VdF.BaseControl.ActiveDocument.FileName.Substring(posBackSlash)

        If (Not (frmPpal.VdF.BaseControl.ActiveDocument.FileName Is Nothing) And frmPpal.VdF.BaseControl.ActiveDocument.FileName.Trim() <> "" And nombreSinPath <> "Temporario.dwg") Then
            frmPpal.VdF.BaseControl.ActiveDocument.SaveAs(frmPpal.VdF.BaseControl.ActiveDocument.FileName)
            frmPpal.VdF.BaseControl.ActiveDocument.IsModified = False
            frmPpal.lineaComandos.UserText.Text = "Archivo " & frmPpal.VdF.BaseControl.ActiveDocument.FileName & " guardado ok!!"
        Else
            GuardarArchivoComo()
        End If
        guardarConfiguracionOsnap()

        ultimoComando = "guardarArchivo"

    End Sub

    Public Sub asignarNombre()
        '-------------------------------------------------------------------------------------
        ' En el frmPpal_Load se ejecuta "asignarNombre" ni bien comienza la ejecucion del pgma
        '-------------------------------------------------------------------------------------
        Dim posBackSlash As Integer = InStrRev(frmPpal.VdF.BaseControl.ActiveDocument.FileName, "\")
        Dim nombreSinPath As String = frmPpal.VdF.BaseControl.ActiveDocument.FileName.Substring(posBackSlash)
        Dim nombre As String = frmPpal.VdF.BaseControl.ActiveDocument.FileName

        If posBackSlash = 0 And _
            nombreSinPath = "" And _
            nombre = "" Then
            'el archivo NO TIENE nombre
            frmPpal.VdF.BaseControl.ActiveDocument.SaveAs("dibujo.dwg")
            archivoActivo(frmPpal.VdF.BaseControl.ActiveDocument.FileName)
            frmPpal.VdF.BaseControl.ActiveDocument.IsModified = False
        End If
    End Sub

    Public Sub autoSave()
        '--------------------------------------------------------------------------------------------
        ' Se dispara cada "n" minutos (configurables). Cuando se hace el autosave, la copia
        ' se guarda en la carpeta donde se esta ejecutando el programa, con el nombre "autosave.dwg"
        '--------------------------------------------------------------------------------------------
        Dim archivoOriginal As String = frmPpal.VdF.BaseControl.ActiveDocument.FileName
        Dim archivoGuardar As String = Application.StartupPath & "\autosave.dwg"
        frmPpal.VdF.BaseControl.ActiveDocument.SaveAs(archivoGuardar)
        frmPpal.VdF.BaseControl.ActiveDocument.SaveAs(archivoOriginal)
        frmPpal.lineaComandos.UserText.Text = "Copia de seguridad " & archivoGuardar & " ok. Intervalo entre copias: " & CStr(frmPpal.tiempoDeAutosave / 60000) & " minutos."

    End Sub
    Public Sub GuardarArchivoComo()

        Dim ver As String = ""
        Dim fname As String = frmPpal.VdF.BaseControl.ActiveDocument.GetSaveFileNameDlg(frmPpal.VdF.BaseControl.ActiveDocument.FileName, ver)
        If Not (fname Is Nothing) Then
            frmPpal.VdF.BaseControl.ActiveDocument.SaveAs(fname)
            frmPpal.VdF.BaseControl.ActiveDocument.IsModified = False
            frmPpal.lineaComandos.UserText.Text = "Archivo " & frmPpal.VdF.BaseControl.ActiveDocument.FileName & " guardado ok!!"
        End If
        guardarConfiguracionOsnap()
        archivoActivo(frmPpal.VdF.BaseControl.ActiveDocument.FileName)
        If hayArchivoIntercambio Then
            guardarPathEnArchivoIntercambio(frmPpal.VdF.BaseControl.ActiveDocument.FileName)
        End If
        ultimoComando = "guardarArchivoComo"

    End Sub

    Private Sub guardarPathEnArchivoIntercambio(ByVal archivo As String)
        'leer archivo de intercambio..
        Dim intercambio As Stream = File.Open("C:\CpaCad2\" & "intercambio.INT", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
        Dim escribir As New StreamWriter(intercambio)

        intercambio.Seek(0, SeekOrigin.End)
        escribir.WriteLine()
        escribir.WriteLine(archivo)
        escribir.Flush()

    End Sub

    Public Sub guardarArchivoRecienAbierto()
        '===========================================================================
        ' Guardar en un archivo de texto (c:\cpacad2\mhcadt\ultimos.txt) los ùltimos
        ' dibujos que se abrieron.
        '===========================================================================
        Dim archivoUltimos As Stream = File.Open(ubicacionSoporte & "ultimos.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
        Dim escribir As New StreamWriter(archivoUltimos)

        archivoUltimos.Seek(0, SeekOrigin.End)
        'escribir.WriteLine()
        escribir.WriteLine(frmPpal.VdF.BaseControl.ActiveDocument.FileName.ToString)
        escribir.Flush()
        escribir.Close()

    End Sub

    Public Sub leerUltimosAbiertos()
        '===========================================================
        ' Leer los ùltimos planos abiertos. Se leen desde el archivo
        ' ultimos.txt, que se encuentra en la ubicacion de soporte.
        ' o sea "c:\windows\mhcadt"
        '===========================================================

        Dim archivo As Stream = File.Open(ubicacionSoporte & "ultimos.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)
        Dim lector As New StreamReader(archivo)
        Dim strLeido As String

        ReDim vectorUltimos(0)
        Dim i As Integer
        While lector.Peek <> -1
            strLeido = lector.ReadLine
            If strLeido <> "" Then
                If Array.IndexOf(vectorUltimos, strLeido) = -1 Then
                    If i = 0 Then
                        ReDim vectorUltimos(0)
                    Else
                        ReDim Preserve vectorUltimos(UBound(vectorUltimos) + 1)
                    End If
                    vectorUltimos(UBound(vectorUltimos)) = strLeido
                    i = i + 1
                End If
            End If
        End While
        If UBound(vectorUltimos) > 0 Then
            Array.Reverse(vectorUltimos)
        End If

        Dim itemArchivos As System.Windows.Forms.ToolStripMenuItem
        itemArchivos = frmPpal.ArchivoToolStripMenuItem
        Dim posicion As Integer = itemArchivos.DropDownItems.IndexOfKey("SalirToolStripMenuItem")

        Dim itemDeMenu As System.Windows.Forms.ToolStripMenuItem
        If UBound(vectorUltimos) > 0 Then
            Dim pasadas As Integer = 0
            For a = 0 To UBound(vectorUltimos)
                itemDeMenu = New System.Windows.Forms.ToolStripMenuItem
                itemDeMenu = itemArchivos.DropDownItems.Add(vectorUltimos(a))
                'itemDeMenu = frmPpal.ArchivoToolStripMenuItem.DropDownItems.Add(vectorUltimos(a))
                itemArchivos.DropDownItems.Insert(posicion + a, itemDeMenu)
                itemDeMenu.Tag = a
                itemDeMenu.Name = CStr(a)
                AddHandler itemDeMenu.Click, AddressOf manejadorUltimos
                pasadas = pasadas + 1
                If pasadas = 10 Then Exit For
            Next
        Else
            itemDeMenu = New System.Windows.Forms.ToolStripMenuItem
            itemDeMenu = itemArchivos.DropDownItems.Add(vectorUltimos(0))
            itemArchivos.DropDownItems.Insert(posicion, itemDeMenu)
        End If
        lector.Close()

    End Sub

    Public Sub manejadorUltimos(ByVal sender As Object, ByVal e As System.EventArgs)
        'el valor del string viene en sender.text
        AbrirArchivo(sender.text)

    End Sub

    Public Sub agregarSoloElUltimoAbierto(ByVal nombreDelArchivo As String)
        '---------------------------------------------------------
        ' Esto es para agregar a la lista de los ultimos
        ' archivos abiertos SOLO el archivo actual..
        ' Se dispara desde frmppal en el evento OnAfterOpenDocumen
        ' y en el parametro nombreDelArchivo viene el nombre del
        ' archivo abierto actualmente. Pero si ya esta en la lista 
        ' no se carga nada..
        '----------------------------------------------------------
        If vectorUltimos Is Nothing Then Exit Sub

        For i = 0 To UBound(vectorUltimos)
            If vectorUltimos(i) = nombreDelArchivo Then
                Exit Sub
            End If
        Next
        Dim itemArchivos As System.Windows.Forms.ToolStripMenuItem
        itemArchivos = frmPpal.ArchivoToolStripMenuItem
        Dim itemDeMenu As System.Windows.Forms.ToolStripMenuItem
        itemDeMenu = New System.Windows.Forms.ToolStripMenuItem

        Dim posicion As Integer = itemArchivos.DropDownItems.IndexOfKey("ImprimirPlotearToolStripMenuItem") + 1
        'itemDeMenu = frmPpal.ArchivoToolStripMenuItem.DropDownItems.Add(nombreDelArchivo)
        itemDeMenu = itemArchivos.DropDownItems.Add(nombreDelArchivo)
        itemArchivos.DropDownItems.Insert(posicion, itemDeMenu)
        AddHandler itemDeMenu.Click, AddressOf manejadorUltimos

        'verificar si hay mas de diez items y borrar para que queden diez..
        Dim posicion2 As Integer = itemArchivos.DropDownItems.IndexOfKey("SalirToolStripMenuItem")
        If posicion2 - posicion > 11 Then
            itemArchivos.DropDownItems.RemoveAt(posicion2 - 1)
        End If

    End Sub
End Module
