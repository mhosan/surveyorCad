Namespace BO
    Public Class NomenclaturaCatastral
        Private _circunscripcion As String
        Private _seccion As String
        Private _chacra As String
        Private _quinta As String
        Private _fraccion As String
        Private _manzana As String
        Private _parcela As String
        Private _subParcela As String

        Property Circunscripcion() As String
            Get
                Return _circunscripcion
            End Get
            Set(ByVal value As String)
                _circunscripcion = value
            End Set
        End Property

        Property Seccion() As String
            Get
                Return _seccion
            End Get
            Set(ByVal value As String)
                _seccion = value
            End Set
        End Property

        Property Chacra() As String
            Get
                Return _chacra
            End Get
            Set(ByVal value As String)
                _chacra = value
            End Set
        End Property

        Property Quinta() As String
            Get
                Return _quinta
            End Get
            Set(ByVal value As String)
                _quinta = value
            End Set
        End Property

        Property Fraccion() As String
            Get
                Return _fraccion
            End Get
            Set(ByVal value As String)
                _fraccion = value
            End Set
        End Property

        Property Manzana() As String
            Get
                Return _manzana
            End Get
            Set(ByVal value As String)
                _manzana = value
            End Set
        End Property

        Property Parcela() As String
            Get
                Return _parcela
            End Get
            Set(ByVal value As String)
                _parcela = value
            End Set
        End Property
        Property SubParcela() As String
            Get
                Return _subParcela
            End Get
            Set(ByVal value As String)
                _subParcela = value
            End Set
        End Property
    End Class
End Namespace