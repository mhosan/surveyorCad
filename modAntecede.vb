Imports System.IO

Module modAntecede

    Public Sub importarAntecedente()

        '============================================
        'Traer antecedente de catastro. (archivo dxf)
        '============================================
        If huboCambios() Then
            GuardarArchivoComo()
        End If

        Dim ret As Object
        Directory.SetCurrentDirectory("c:\")
        ret = frmPpal.VdF.BaseControl.ActiveDocument.GetOpenFileNameDlg(0, "*.dxf", 0)
        If (ret Is Nothing) Then
            Exit Sub
        Else
            Dim fname As String = CType(ret, String)
            Dim success As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.Open(fname)
            If (success) Then
                frmPpal.VdF.BaseControl.ActiveDocument.Redraw(True)
                'luego de la importacion:
                'Configurar()
                frmPpal.VdF.BaseControl.ActiveDocument.IsModified = False
            End If
        End If
        ultimoComando = "importarAntecedente"

    End Sub



    Public Sub Guarda_Antecedente()
        '=======================================
        'Guardar antecedente y generar punto sys
        '=======================================
        Dim ver As String = ""
        Dim fname As String

        fname = frmPpal.VdF.BaseControl.ActiveDocument.GetSaveFileNameDlg(frmPpal.VdF.BaseControl.ActiveDocument.FileName, ver)
        'fname = frmPpal.VdF.BaseControl.ActiveDocument.GetSaveFileNameDlg("dwg", ver)
        'fname = frmPpal.VdF.BaseControl.ActiveDocument.GetSaveFileNameDlg("", ver)
        If fname Is Nothing Then Exit Sub 'es el nombre del archivo dwg. Es el mismo o uno nuevo..
        frmPpal.VdF.BaseControl.ActiveDocument.SaveAs(fname)

        Dim ArchivoOriginal As New FileInfo(fname)    'la informacion del archivo que se acaba de guardar..

        Dim ArchivoSys As String = Left(ArchivoOriginal.Name, Len(ArchivoOriginal.Name) - 4) & ".sys" 'el nombre del archivo
        '                                                                                             que se acaba de guardar
        '                                                                                             pero con extension .sys

        Dim procId As Integer
        Dim elPath As Object
        Try
            elPath = My.Computer.FileSystem.GetFiles("C:\CpaCad2\", FileIO.SearchOption.SearchAllSubDirectories, "haceMd5.exe")
            If elPath.count = 0 Then
                Dim MsgError As String = " No se encuentra el utilitario ""haceMd5.exe"" en la carpeta del programa"
                MsgError = MsgError & ", por lo cual no se puede generar el archivo .sys correspondiente. "
                MsgError = MsgError & " Reinstalar el programa o la última actualización."
                MsgBox(MsgError, MsgBoxStyle.OkOnly, aplicacionNombre)
                Exit Sub
            Else
                procId = Shell(elPath.item(0).ToString & " " & ArchivoOriginal.FullName, AppWinStyle.NormalFocus)
            End If
        Catch ex As Exception
            Err.Clear()
            Exit Sub
        End Try

        'Dim el_hash As String = Genero_Hash(ArchivoOriginal.FullName)   'me voy a generar el hash con el nombre completo del
        ''                                                                archivo .dwg

        'If File.Exists(ArchivoOriginal.DirectoryName & "\" & ArchivoSys) Then
        '    File.Delete(ArchivoOriginal.DirectoryName & "\" & ArchivoSys)
        'End If

        'Dim escribo As New StreamWriter(ArchivoOriginal.DirectoryName & "\" & ArchivoSys)
        'escribo.WriteLine(el_hash)
        'escribo.Close()


        Dim Mensaje As String = " Se acaba de generar una clave de seguridad en la carpeta " & ArchivoOriginal.DirectoryName
        Mensaje = Mensaje & ", en el archivo " & ArchivoSys & ", el cual debe permanecer"
        Mensaje = Mensaje & " junto al plano (archivo cad ó .dwg) para adjuntar al pgf"
        MsgBox(Mensaje, MsgBoxStyle.OkOnly, aplicacionNombre)
        ultimoComando = "guardarAntecedente"



    End Sub

    Public Function Genero_Hash(ByVal PathArch As String) As String
        '------------------------------------------------------------
        'calcular el hash
        'pathArch es el nombre del archivo original con path incluido
        '------------------------------------------------------------
        Dim Hash As CAPICOM.HashedData
        Dim NroF As Integer
        Dim StrData As String

        Hash = New CAPICOM.HashedData
        Hash.Algorithm = CAPICOM.CAPICOM_HASH_ALGORITHM.CAPICOM_HASH_ALGORITHM_MD5
        NroF = FreeFile()

        FileOpen(1, PathArch, OpenMode.Binary)
        StrData = InputString(1, FileLen(PathArch)) 'revisar aqui!!!, debe ser una lectura binaria...ojo
        'Dim leidoB() As Byte = File.ReadAllBytes(StrData)

        FileClose(1)

        Hash.Hash(StrData)
        'Hash.Hash(leidoB.ToString)
        Genero_Hash = Hash.Value


        'Dim oUtilities As CAPICOM.Utilities
        'oUtilities.BinaryStringToByteArray()

    End Function

End Module
