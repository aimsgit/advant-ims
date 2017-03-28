Imports Microsoft.VisualBasic

Public Class Mfg_ELTaxDetails
    Private _TaxDescription As String
    Public Property TaxDescription() As String
        Get
            Return _TaxDescription
        End Get
        Set(ByVal value As String)
            _TaxDescription = value
        End Set
    End Property
    Private _IE As String
    Public Property IE() As String
        Get
            Return _IE
        End Get
        Set(ByVal value As String)
            _IE = value
        End Set
    End Property
    Private _vat As Double
    Public Property vat() As Double
        Get
            Return _vat
        End Get
        Set(ByVal value As Double)
            _vat = value
        End Set
    End Property
    Private _cst As Double
    Public Property cst() As Double
        Get
            Return _cst
        End Get
        Set(ByVal value As Double)
            _cst = value
        End Set
    End Property
    Private _Evat As Double
    Public Property Evat() As Double
        Get
            Return _Evat
        End Get
        Set(ByVal value As Double)
            _Evat = value
        End Set
    End Property
    Private _Ecst As Double
    Public Property Ecst() As Double
        Get
            Return _Ecst
        End Get
        Set(ByVal value As Double)
            _Ecst = value
        End Set
    End Property
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
End Class
