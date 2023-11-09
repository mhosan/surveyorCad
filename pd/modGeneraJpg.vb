Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Geometry
Imports VectorDraw.Render
Imports VectorDraw.Serialize
Imports VectorDraw.Generics
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdObjects
Imports System.IO


Module modGeneraJpg

    Public Sub generarImagen()
        Var_Cedula.creaCarpeta()


        Dim archivo As String = CStr(identificadorTrabajo)

        frmPpal.baseControl.ActiveDocument.Model.Printer.PrinterName = "c:\cpaPD\Imagenes\" + archivo + ".jpg"

        Dim caja As VectorDraw.Geometry.Box = frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Entities.GetBoundingBox(True, True)
        'Dim pathDibujo As String = VectorDraw.Professional.Utilities.vdGlobals.GetDirectoryName(frmPpal.VdF.BaseControl.ActiveDocument.FileName)
        'Dim nombreDibujo As String = frmPpal.baseControl.ActiveDocument.Model.Printer.PrinterName
        Dim ancho, alto As Double
        alto = caja.Height
        ancho = caja.Width
        'frmPpal.baseControl.ActiveDocument.Model.Printer.paperSize = New Rectangle(0.0, 0.0, ancho, alto)
        'frmPpal.baseControl.ActiveDocument.Model.Printer.PrintWindow = caja
        frmPpal.baseControl.ActiveDocument.Model.Printer.PrintExtents()
        frmPpal.baseControl.ActiveDocument.Model.Printer.PrintWindow.AddWidth(5.0)
        frmPpal.baseControl.ActiveDocument.Model.Printer.PrintScaleToFit()
        frmPpal.baseControl.ActiveDocument.Model.Printer.Resolution = 600
        frmPpal.baseControl.ActiveDocument.Model.Printer.LandScape = True
        frmPpal.baseControl.ActiveDocument.Model.Printer.CenterDrawingToPaper()
        'frmPpal.VdF.BaseControl.ActiveDocument.ActiveLayOut.Printer.CopyFrom(impresora)
        Try
            'Dim archivoGuardadoOk As Boolean = frmPpal.VdF.BaseControl.ActiveDocument.SaveAs(pathDibujo & "\" & nombreDibujo)
            frmPpal.baseControl.ActiveDocument.Model.Printer.PrintOut()
            Dim mensaje As String = "Archivo jpg generado ok!!" & vbCrLf & "en " & frmPpal.baseControl.ActiveDocument.Model.Printer.PrinterName.ToString
            MsgBox(mensaje, vbInformation, aplicacionNombre)
        Catch ex As Exception
            MsgBox("Error en la exportación del archivo.", vbInformation, aplicacionNombre)
        End Try
        
    End Sub

    Public Sub imprimeJpg()
        'Dim VdDocumentComponent1 As VectorDraw.Professional.Components.vdDocumentComponent
        'frmPpal.VdDocumentComponent1 = New VectorDraw.Professional.Components.vdDocumentComponent(frmPpal.components)

        frmPpal.baseControl.ActiveDocument.Model.Printer.PrinterName = Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".jpg"
        'frmPpal.baseControl.ActiveDocument.Model.Printer.PrinterName = VectorDraw.Professional.Utilities.vdGlobals.GetFileNameWithoutExtension(frmPpal.VdF.BaseControl.ActiveDocument.FileName) & ".jpg"
        'frmPpal.baseControl.ActiveDocument.Model.Printer.PrinterName = Application.StartupPath & ".jpg"
        frmPpal.baseControl.ActiveDocument.Model.Printer.PrintExtents()
        frmPpal.baseControl.ActiveDocument.Model.Printer.PrintWindow.AddWidth(5.0)
        frmPpal.baseControl.ActiveDocument.Model.Printer.PrintScaleToFit()
        frmPpal.baseControl.ActiveDocument.Model.Printer.PrintOut()

    End Sub

End Module
