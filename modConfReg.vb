Imports System.Threading
Imports System.Globalization

Module modConfReg

    '    Averiguar separador decimal:

    'Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Dim s As String

    '    s = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
    '    Label1.Text = "El separador decimal es: '" & s & "'"

    '    s = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator
    '    Label2.Text = "El separador de miles es: '" & s & "'"

    'End Sub

    Public Sub configuracionRegional()
        Dim forceDotCulture As CultureInfo
        forceDotCulture = Application.CurrentCulture.Clone()
        forceDotCulture.NumberFormat.NumberDecimalSeparator = "."
        forceDotCulture.NumberFormat.NumberGroupSeparator = ","
        Application.CurrentCulture = forceDotCulture
        sepDecimal = "."
        sepMiles = ","

        'sepDecimal = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
        'sepMiles = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator

        'Dim resultado As Object = New CultureInfo(CultureInfo.CurrentCulture.ToString(), False).NumberFormat

        ''Para el separador de decimales:
        ''Thread.CurrentThread.CurrentCulture.NumberFormat.C(urrencyDecimalSeparator)

        ''Para el separador de grupos de cifras:
        ''Thread.CurrentThread.CurrentCulture.NumberFormat.C(urrencyGroupSeparator)
        'Dim separadorDeDecimales As Object = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
        'Dim separadorDeMiles As Object = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator

        'System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "." 'New System.Globalization.CultureInfo("es-mx")
        'System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","


    End Sub
End Module
