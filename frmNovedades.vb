Imports System.Windows.Forms

Public Class frmNovedades

    Private Sub frmNovedades_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tx As String = ""

        tx = tx & "----------------Versión 2.3.3------------------" & vbCrLf & vbCrLf
        tx = tx & "* Soporte para imagenes georeferenciadas. La función insertar imagen del menú ""Dibujar"" soporta archivos georeferenciados del tipo tif y jpg. Si en el momento de la inserción del archivo de imagen, existe un archivo adjunto con la información de georeferenciacion (por ejemplo del tipo tfw para las imagenes tif), la imagen se inserta de acuerdo a los parametros definidos en este archivo." & vbCrLf & vbCrLf
        tx = tx & "* Nuevo punto de pinzamiento (grips) en el medio de un segmento recto de una polilinea. Haciendo click en este punto de pinzamiento se puede mover este segmento independiente del resto de la polilinea, produciendo un efecto de strecht o estirado." & vbCrLf & vbCrLf
        tx = tx & "* Corrección de error en giro del origen de coordenadas en la función ""Giro de viewport"", del menú ""Vistas"", ""Ventanas""." & vbCrLf & vbCrLf
        tx = tx & "* Corrección de textos importados de otros cad con codigos %%O y %%U. Estos codigos aparecian tal cual sin producir el sobrerayado o subrayado." & vbCrLf & vbCrLf
        RichTextBox1.Text = tx
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
