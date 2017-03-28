Imports Microsoft.VisualBasic

Public Class Mfg_ELBatchDetails
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Batch As String
    Public Property Batch() As String
        Get
            Return _Batch
        End Get
        Set(ByVal value As String)
            _Batch = value
        End Set
    End Property
    Private _Productid As Integer
    Public Property Productid() As Integer
        Get
            Return _Productid
        End Get
        Set(ByVal value As Integer)
            _Productid = value
        End Set
    End Property
    Private _Mfgdate As DateTime
    Public Property Mfgdate() As DateTime
        Get
            Return _Mfgdate
        End Get
        Set(ByVal value As DateTime)
            _Mfgdate = value
        End Set
    End Property
    Private _Expiry As DateTime
    Public Property Expiry() As DateTime
        Get
            Return _Expiry
        End Get
        Set(ByVal value As DateTime)
            _Expiry = value
        End Set
    End Property
    Private _DealQty As Integer
    Public Property DealQty() As Integer
        Get
            Return _DealQty
        End Get
        Set(ByVal value As Integer)
            _DealQty = value
        End Set
    End Property
    Private _DealFree As Double
    Public Property DealFree() As Double
        Get
            Return _DealFree
        End Get
        Set(ByVal value As Double)
            _DealFree = value
        End Set
    End Property
    Private _Packing As String
    Public Property Packing() As String
        Get
            Return _Packing
        End Get
        Set(ByVal value As String)
            _Packing = value
        End Set
    End Property
    Private _PRate As Double
    Public Property PRate() As Double
        Get
            Return _PRate
        End Get
        Set(ByVal value As Double)
            _PRate = value
        End Set
    End Property
    Private _MRP As Double
    Public Property MPR() As Double
        Get
            Return _MRP
        End Get
        Set(ByVal value As Double)
            _MRP = value
        End Set
    End Property
    Private _SaleRate As Double
    Public Property SaleRate() As Double
        Get
            Return _SaleRate
        End Get
        Set(ByVal value As Double)
            _SaleRate = value
        End Set
    End Property
    Private _PurchaseDis As Double
    Public Property PurchaseDis() As Double
        Get
            Return _PurchaseDis
        End Get
        Set(ByVal value As Double)
            _PurchaseDis = value
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
    Private _vat As Double
    Public Property vat() As Double
        Get
            Return _vat
        End Get
        Set(ByVal value As Double)
            _vat = value
        End Set
    End Property
    Private _Hold As String
    Public Property Hold() As String
        Get
            Return _Hold
        End Get
        Set(ByVal value As String)
            _Hold = value
        End Set
    End Property
End Class
