Imports System.IO

Module modCertifAmoj

    Public Sub certificadoAmojonamiento()
        '-------------------------------------------------------------------------------------------------------------------------
        ' El archivo de intercambio está. Verificado en modConfigura.certificadoAmojonamientoSiNo. Alli esta la llamada a esta sub
        '-------------------------------------------------------------------------------------------------------------------------
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        'verificar si existe la plantilla
        Dim hayPlantilla As FileInfo = New FileInfo(ubicacionSoporte & "\PlantAmoj01.dwg")
        If hayPlantilla.Exists = False Then
            MsgBox("No se encuentra la plantilla del Certif. de Amojonamiento", MsgBoxStyle.Information, aplicacionNombre)
            Exit Sub
        Else
            hayPlantilla.CopyTo("C:\CpaCad2\Temporario.dwg", True)
            hayPlantilla = New FileInfo("C:\CpaCad2\Temporario.dwg")
        End If

        If huboCambios() Then
            GuardarArchivo()
        End If

        'leer archivo de intercambio..
        Dim archivo As Stream = File.Open("C:\CpaCad2\" & "intercambio.INT", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
        Dim lector As New StreamReader(archivo)

        Dim queLeyo As String
        Dim nada As String
        Dim hayDwg As Boolean = False

        Do Until lector.Peek = -1
            queLeyo = lector.ReadLine().ToString
            If queLeyo = "" Then Exit Do
            nada = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
            If Right(nada, 3) = "dwg" Or Right(nada, 3) = "DWG" Then
                'verificar si existe el archivo dwg que esta referenciado en el arch.intercamb.
                Dim hayDibujo As FileInfo = New FileInfo(nada)
                If hayDibujo.Exists = False Then
                    MsgBox("No se encuentra el archivo " & nada & " que aparece en el archivo de intercambio.", MsgBoxStyle.Information, aplicacionNombre)
                    'traer el dibujo de la plantilla..
                    Dim exito As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.Open(hayPlantilla.FullName)
                    If exito Then frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                    lector.Close()
                    archivoActivo(hayPlantilla.Name)
                    insertarDatosGrales()
                    Exit Sub
                Else
                    Dim success As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.Open(nada)
                    If (success) Then
                        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                        configurarInicio()
                        archivoActivo(nada)
                    End If
                End If
                lector.Close()
                insertarDatosVisado()
                hayDwg = True
                Exit Do
            End If
        Loop
        'lector.Close()
        If hayDwg = False Then
            'traer el dibujo de la plantilla..
            Dim exito As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.Open(hayPlantilla.FullName)
            If exito Then frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
            archivoActivo(hayPlantilla.Name)
            lector.Close()
            insertarDatosGrales()
        End If
        ultimoComando = "certificadoAmojonamiento"

    End Sub

    Private Sub insertarDatosGrales()
        'insertar los datos generales del certificado de amojonamiento. 
        'leer archivo de intercambio..
        Dim archivo As Stream = File.Open("C:\CpaCad2\" & "intercambio.INT", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
        Dim lector As New StreamReader(archivo)

        Dim queLeyo As String, valorLeido As String, laManzana As String, laParcela As String
        Dim nada As String
        Do Until lector.Peek = -1
            queLeyo = lector.ReadLine().ToString
            If queLeyo = "" Then Exit Do
            nada = UCase(Trim(queLeyo.Substring(0, (InStr(queLeyo, ";") - 1))))
            Select Case nada
                Case "DIRCOMITENTE"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("Direccion comitente", valorLeido)
                Case "NOMBRECOMITENTE"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("Nombre comitente", valorLeido)
                Case "LOCCOMITENTE"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("Localidad comitente", valorLeido)
                Case "CPCOMITENTE"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("CP comitente", valorLeido)
                Case "LOCALIDADOBRA"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("Localidad obra", valorLeido)
                Case "PARTIDOOBRA"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("Partido obra", valorLeido)
                Case "PARTIDA"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("Partida", valorLeido)
                Case "NOMBREPROF"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("Nombre profesional", valorLeido)
                Case "MATRICULAPROF"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("Matricula profesional", valorLeido)
                Case "SECCIONL"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("Sec", valorLeido)
                Case "CIRCUNSCRIPCION"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("Cir", valorLeido)
                Case "MANZANAN"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    laManzana = laManzana & valorLeido
                Case "MANZANAL"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    laManzana = laManzana & valorLeido
                Case "PARCELAN"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    laParcela = laParcela & valorLeido
                Case "PARCELAL"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    laParcela = laParcela & valorLeido
            End Select
        Loop
        lector.Close()
        buscaEntidadTexto("Mz", laManzana)
        buscaEntidadTexto("Pl", laParcela)

    End Sub
    Private Sub insertarDatosVisado()

        'leer archivo de intercambio..
        'ya se verifico en la rutina llamadora que el archivo existe. Por lo tanto lo 
        'abro directamente.
        Dim archivo As Stream = File.Open("C:\CpaCad2\" & "intercambio.INT", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
        Dim lector As New StreamReader(archivo)
        Dim queLeyo As String, valorLeido As String
        Dim nada As String, nada2 As String, nomencla As String, codigoDeBarra As String

        Do Until lector.Peek = -1
            queLeyo = lector.ReadLine().ToString
            If queLeyo = "" Then Exit Do
            nada = UCase(Trim(queLeyo.Substring(0, (InStr(queLeyo, ";") - 1))))
            nada2 = Replace(nada, Chr(Keys.Tab), "")

            Select Case nada2
                Case "PARTIDOOBRACOD"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("Pdo.:", "Pdo.:" & valorLeido)
                Case "PARTIDA"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("Pda.:", "Pda.:" & valorLeido)
                Case "SECCIONL"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    nomencla = valorLeido
                Case "CIRCUNSCRIPCION"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    nomencla = nomencla & "-" & valorLeido
                Case "CHACRAN"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    nomencla = nomencla & "-" & valorLeido
                Case "CHACRAL"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    nomencla = nomencla & "-" & valorLeido
                Case "QUINTAN"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                Case "QUNTAL"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    nomencla = nomencla & "-" & valorLeido
                Case "FRACCIONN"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    nomencla = nomencla & "-" & valorLeido
                Case "FRACCIONL"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    nomencla = nomencla & "-" & valorLeido
                Case "MANZANAN"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    nomencla = nomencla & "-" & valorLeido
                Case "MANZANAL"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    nomencla = nomencla & "-" & valorLeido
                Case "PARCELAN"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    nomencla = nomencla & "-" & valorLeido
                Case "PARCELAL"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    nomencla = nomencla & "-" & valorLeido
                Case "SUBPARCELA"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    nomencla = nomencla & "-" & valorLeido
                    buscaEntidadTexto("Nomenc.:", "(" & nomencla & ")")
                Case "CUITPROF"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("CUIT:", "CUIT: " & valorLeido)
                Case "NOMBREPROF"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("Prof.:", "Prof.:" & valorLeido)
                Case "MATRICULAPROF"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    buscaEntidadTexto("Matricula profesional", valorLeido)
                Case "NUMEROVISADO"
                    valorLeido = UCase(Trim(queLeyo.Substring(InStr(queLeyo, ";"))))
                    codigoDeBarra = valorLeido
                    buscaEntidadTexto("Nro. de Visado:", valorLeido)
                    buscaEntidadTextoBarras("Codigo de barras", codigoDeBarra)

            End Select
        Loop
        lector.Close()

    End Sub
    Private Sub buscaEntidadTexto(ByVal queBusco As String, ByVal valor As String)

        Dim texto As VectorDraw.Professional.vdFigures.vdText
        For i As Integer = 0 To frmPpal.VdF.BaseControl.ActiveDocument.Model.Entities.Count - 1
            If frmPpal.VdF.BaseControl.ActiveDocument.Model.Entities.Item(i)._TypeName.ToString = "vdText" Then
                texto = New VectorDraw.Professional.vdFigures.vdText()
                texto = frmPpal.VdF.BaseControl.ActiveDocument.Model.Entities.Item(i)
                If Trim(texto.TextString) = queBusco Then
                    texto.Style.FontFile = "Times New Roman"
                    texto.TextString = valor
                    Exit For
                End If
            End If
        Next

    End Sub
    Private Sub buscaEntidadTextoBarras(ByVal queBusco As String, ByVal valor As String)

        Dim textoBarras As VectorDraw.Professional.vdFigures.vdText
        For i As Integer = 0 To frmPpal.VdF.BaseControl.ActiveDocument.Model.Entities.Count - 1
            If frmPpal.VdF.BaseControl.ActiveDocument.Model.Entities.Item(i)._TypeName.ToString = "vdText" Then
                textoBarras = New VectorDraw.Professional.vdFigures.vdText()
                textoBarras = frmPpal.VdF.BaseControl.ActiveDocument.Model.Entities.Item(i)
                If Trim(textoBarras.TextString) = queBusco Then
                    If valor = "" Then
                        textoBarras.TextString = ""
                    Else
                        textoBarras.TextString = "*" & valor & "*"
                    End If

                    'textoBarras.Style.FontFile = "3 of 9 Barcode"

                    Dim txtEstiloCodBarras As VectorDraw.Professional.vdPrimaries.vdTextstyle = New VectorDraw.Professional.vdPrimaries.vdTextstyle
                    txtEstiloCodBarras.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
                    txtEstiloCodBarras.setDocumentDefaults()
                    txtEstiloCodBarras.Name = "Codigo_Barras"
                    txtEstiloCodBarras.FontFile = "3 of 9 Barcode"
                    txtEstiloCodBarras.Height = 18

                    frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.AddItem(txtEstiloCodBarras)

                    textoBarras.Style = txtEstiloCodBarras

                    Exit For
                End If
            End If
        Next

    End Sub
    Private Sub insertarImagen()
        '===============================================================================
        '
        ' se esta suponiendo que el archivo esta en la carpeta: "C:\CpaCad2\prueba.jpg"
        ' imagen del certificado de amoj. (el codigo de barras)
        '===============================================================================

        Dim imagen As VectorDraw.Professional.vdFigures.vdImage = New VectorDraw.Professional.vdFigures.vdImage()
        imagen.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        imagen.setDocumentDefaults()

        Dim path As String = "C:\CpaCad2\prueba.jpg"
        Dim punto As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint(21655.5, 4765)

        imagen.ImageDefinition = frmPpal.VdF.BaseControl.ActiveDocument.Images.Add(path)
        imagen.ImageScale = 88

        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdImage(imagen, punto)
        frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)


    End Sub

End Module
