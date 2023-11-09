Namespace BO
    Public Class Direccion
        Private _calle As String
        Private _entreCalle1 As String
        Private _entreCalle2 As String
        Private _nro As String
        Private _piso As String
        Private _depto As String
        Private _localidad As String
        Private _provincia As String
        Private _codigoPostal As String

        Property Calle() As String
            Get
                Return _calle
            End Get
            Set(ByVal value As String)
                _calle = value
            End Set
        End Property

        Property EntreCalle1() As String
            Get
                Return _entreCalle1
            End Get
            Set(ByVal value As String)
                _entreCalle1 = value
            End Set
        End Property

        Property EntreCalle2() As String
            Get
                Return _entreCalle2
            End Get
            Set(ByVal value As String)
                _entreCalle2 = value
            End Set
        End Property

        Property Nro() As String
            Get
                Return _nro
            End Get
            Set(ByVal value As String)
                _nro = value
            End Set
        End Property

        Property Piso() As String
            Get
                Return _piso
            End Get
            Set(ByVal value As String)
                _piso = value
            End Set
        End Property

        Property Depto() As String
            Get
                Return _depto
            End Get
            Set(ByVal value As String)
                _depto = value
            End Set
        End Property

        Property Localidad() As String
            Get
                Return _localidad
            End Get
            Set(ByVal value As String)
                _localidad = value
            End Set
        End Property

        Property Provincia() As String
            Get
                Return _provincia
            End Get
            Set(ByVal value As String)
                _provincia = value
            End Set
        End Property

        Property CodigoPostal() As String
            Get
                Return _codigoPostal
            End Get
            Set(ByVal value As String)
                _codigoPostal = value
            End Set
        End Property

    End Class
End Namespace
