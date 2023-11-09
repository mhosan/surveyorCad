
Module modTextos

    Public Sub textoMulti()
        '----------------------
        ' texto multilinea
        '----------------------
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If
        MsgBox("Indicar punto inserción, ángulo de rotación y escribir texto." & vbCrLf & "Oprimiendo Enter el cursor baja a un nuevo renglón." & vbCrLf & "Finalizar con botòn derecho del mouse.", MsgBoxStyle.Information, aplicacionNombre)
        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdMText("", "User", "User")

    End Sub

    Public Sub textoSingle()
        '----------------------
        ' texto de una linea
        '----------------------
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.CmdText("", "USER", "USER")

    End Sub

    Public Sub agregar_Estilos_Textos()
        '--------------------------------------------------------
        ' agregar estilos de textos de la plantilla de Catastro
        '--------------------------------------------------------
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        If frmPpal.versionCad = "DEMO" Or frmPpal.versionCad = "MHCAD" Then
            Exit Sub
        End If

        Dim txtEstilo1 As VectorDraw.Professional.vdPrimaries.vdTextstyle = New VectorDraw.Professional.vdPrimaries.vdTextstyle
        txtEstilo1.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        txtEstilo1.setDocumentDefaults()
        txtEstilo1.Name = "Mensura_Grande"
        txtEstilo1.FontFile = "Arial Unicode MS"
        txtEstilo1.Height = 5.0
        frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.AddItem(txtEstilo1)

        Dim txtEstilo2 As VectorDraw.Professional.vdPrimaries.vdTextstyle = New VectorDraw.Professional.vdPrimaries.vdTextstyle
        txtEstilo2.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        txtEstilo2.setDocumentDefaults()
        txtEstilo2.Name = "Mensura_Medio"
        txtEstilo2.FontFile = "Arial Unicode MS"
        txtEstilo2.Height = 2.5
        frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.AddItem(txtEstilo2)

        Dim txtEstilo3 As VectorDraw.Professional.vdPrimaries.vdTextstyle = New VectorDraw.Professional.vdPrimaries.vdTextstyle
        txtEstilo3.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        txtEstilo3.setDocumentDefaults()
        txtEstilo3.Name = "Mensura_Chico"
        txtEstilo3.FontFile = "Arial Unicode MS"
        txtEstilo3.Height = 1.0
        frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.AddItem(txtEstilo3)

        Dim txtEstiloCodBarras As VectorDraw.Professional.vdPrimaries.vdTextstyle = New VectorDraw.Professional.vdPrimaries.vdTextstyle
        txtEstiloCodBarras.SetUnRegisterDocument(frmPpal.VdF.BaseControl.ActiveDocument)
        txtEstiloCodBarras.setDocumentDefaults()
        txtEstiloCodBarras.Name = "Codigo_Barras"
        txtEstiloCodBarras.FontFile = "3 of 9 Barcode"
        txtEstiloCodBarras.Height = 1.5
        frmPpal.VdF.BaseControl.ActiveDocument.TextStyles.AddItem(txtEstiloCodBarras)

    End Sub

    Public Sub estiloTextos()
        '----------------------------------------------
        ' mostrar cuadro de dialogo estilos de textos
        '----------------------------------------------
        If frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.OpenLoops > 0 Then
            frmPpal.VdF.BaseControl.ActiveDocument.CommandAction.Cancel()
        End If

        Try
            VectorDraw.Professional.Dialogs.frmTextStyle.Show(frmPpal.VdF.BaseControl.ActiveDocument)
        Catch ex As Exception

        End Try
        actualizarGrillaPropiedades()

    End Sub

End Module
