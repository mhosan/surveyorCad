Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Geometry
Imports VectorDraw.Render
Imports VectorDraw.Serialize
Imports VectorDraw.Generics
Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdObjects

Module modInfoAyudas

    Public Sub cambiosVersionActual()
        frmNovedades.ShowDialog()
    End Sub

    Public Sub VersiónLibreria()
        Dim asm As System.Reflection.Assembly = frmPpal.VdF.GetType().Assembly
        Dim asmname As System.Reflection.AssemblyName = New System.Reflection.AssemblyName(asm.FullName)
        MessageBox.Show("Utilizando libreria Base: " + asmname.Version.ToString())
    End Sub

    Public Sub AbreviaturasDeComandos()
        '--------------------------------------------
        'abreviaturas de comandos
        '--------------------------------------------
        Dim texto As String
        texto = "linea = l" & vbCrLf
        texto = texto & "Xlinea (linea infinita) = xl" & vbCrLf
        texto = texto & "Linea radial (linea infinita a partir de un punto) = rl" & vbCrLf
        texto = texto & "Arco = a" & vbCrLf
        texto = texto & "Copy = c" & vbCrLf
        texto = texto & "Circulo = ci" & vbCrLf
        texto = texto & "Texto = t" & vbCrLf
        texto = texto & "Punto = pt" & vbCrLf
        texto = texto & "Elipse = el" & vbCrLf
        texto = texto & "Polilinea = pl" & vbCrLf
        texto = texto & "Nota (leader) = le" & vbCrLf
        texto = texto & "Erase = e" & vbCrLf
        texto = texto & "Mover (move) = m" & vbCrLf
        texto = texto & "Break = br" & vbCrLf
        texto = texto & "Trim = tr" & vbCrLf
        texto = texto & "Fillet = f" & vbCrLf
        texto = texto & "Undo = u" & vbCrLf
        texto = texto & "Redraw = r" & vbCrLf
        texto = texto & "Regen = re" & vbCrLf
        texto = texto & "Dist = di" & vbCrLf
        texto = texto & "Rotate = ro" & vbCrLf
        texto = texto & "Scale = s" & vbCrLf
        texto = texto & "Pan = p" & vbCrLf
        texto = texto & "Zoom = z y luego e para Extent" & vbCrLf
        MsgBox(texto, MsgBoxStyle.OkOnly, aplicacionNombre & " Abreviaturas de comandos")
    End Sub

End Module
