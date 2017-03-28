Imports Microsoft.VisualBasic

Public Class ELProperty
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Private _Lot_Number As String
    Public Property Lot_Number() As String
        Get
            Return _Lot_Number
        End Get
        Set(ByVal value As String)
            _Lot_Number = value
        End Set
    End Property
    Private _SaleDate As DateTime
    Public Property SaleDate() As DateTime
        Get
            Return _SaleDate
        End Get
        Set(ByVal value As DateTime)
            _SaleDate = value
        End Set
    End Property

    Private _Properties As String
    Public Property Properties() As String
        Get
            Return _Properties
        End Get
        Set(ByVal value As String)
            _Properties = value
        End Set
    End Property
   

    Private _NoofUnits As Integer
    Public Property NoofUnits() As Integer
        Get
            Return _NoofUnits
        End Get
        Set(ByVal value As Integer)
            _NoofUnits = value
        End Set
    End Property
    Private _Avg_price As Double
    Public Property Avg_price() As Double
        Get
            Return _Avg_price
        End Get
        Set(ByVal value As Double)
            _Avg_price = value
        End Set
    End Property
    Private _LotStatus As String
    Public Property LotStatus() As String
        Get
            Return _LotStatus
        End Get
        Set(ByVal value As String)
            _LotStatus = value
        End Set
    End Property
    Private _Location As String
    Public Property Location() As String
        Get
            Return _Location
        End Get
        Set(ByVal value As String)
            _Location = value
        End Set
    End Property
End Class
