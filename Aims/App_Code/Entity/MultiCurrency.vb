Imports Microsoft.VisualBasic

Public Class MultiCurrency
    Private _id As Long
    Public Property CurrencyCode() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _currencyName As String
    Public Property CurrencyName() As String
        Get
            Return _currencyName
        End Get
        Set(ByVal value As String)
            _currencyName = value
        End Set
    End Property
    Private _buyconversionrate As Single
    Public Property BuyConversionRate() As Single
        Get
            Return _buyconversionrate
        End Get
        Set(ByVal value As Single)
            _buyconversionrate = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(ByVal id As Long, ByVal currencyName As String, ByVal buyconversionrate As Single)
        _id = id
        _currencyName = CurrencyName
        _buyconversionrate = BuyConversionRate
    End Sub
End Class
