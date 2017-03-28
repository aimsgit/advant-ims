Imports Microsoft.VisualBasic

Public Class Mfg_ELProductDetails
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Category As String
    Public Property Category() As String
        Get
            Return _Category
        End Get
        Set(ByVal value As String)
            _Category = value
        End Set
    End Property
    Private _Product As String
    Public Property Product() As String
        Get
            Return _Product
        End Get
        Set(ByVal value As String)
            _Product = value
        End Set
    End Property
    Private _Type As String
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property
    Private _Code As String
    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(ByVal value As String)
            _Code = value
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
    
    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
    Private _Discount As String
    Public Property Discount() As String
        Get
            Return _Discount
        End Get
        Set(ByVal value As String)
            _Discount = value
        End Set
    End Property
    Private _Description As Integer
    Public Property Description() As Integer
        Get
            Return _Description
        End Get
        Set(ByVal value As Integer)
            _Description = value
        End Set
    End Property
    Private _Supplier As Integer
    Public Property Supplier() As Integer
        Get
            Return _Supplier
        End Get
        Set(ByVal value As Integer)
            _Supplier = value
        End Set
    End Property

    Private _Company As Integer
    Public Property Company() As Integer
        Get
            Return _Company
        End Get
        Set(ByVal value As Integer)
            _Company = value
        End Set
    End Property

    Private _Reorder As Integer
    Public Property Reorder() As Integer
        Get
            Return _Reorder
        End Get
        Set(ByVal value As Integer)
            _Reorder = value
        End Set
    End Property

    Private _Unit As Integer
    Public Property Unit() As Integer
        Get
            Return _Unit
        End Get
        Set(ByVal value As Integer)
            _Unit = value
        End Set
    End Property

    Private _Purchase As Double
    Public Property Purchase() As Double
        Get
            Return _Purchase
        End Get
        Set(ByVal value As Double)
            _Purchase = value
        End Set
    End Property
    Private _PDeal1 As Double
    Public Property PDeal1() As Double
        Get
            Return _PDeal1
        End Get
        Set(ByVal value As Double)
            _PDeal1 = value
        End Set
    End Property
    Private _PDeal2 As Double
    Public Property PDeal2() As Double
        Get
            Return _PDeal2
        End Get
        Set(ByVal value As Double)
            _PDeal2 = value
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
    Private _PurchRate As Double
    Public Property PurchRate() As Double
        Get
            Return _PurchRate
        End Get
        Set(ByVal value As Double)
            _PurchRate = value
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
    Private _SalePlan As Integer
    Public Property SalePlan() As Integer
        Get
            Return _SalePlan
        End Get
        Set(ByVal value As Integer)
            _SalePlan = value
        End Set
    End Property
    Private _OfferPeriod As DateTime
    Public Property OfferPeriod() As DateTime
        Get
            Return _OfferPeriod
        End Get
        Set(ByVal value As DateTime)
            _OfferPeriod = value
        End Set
    End Property
    Private _SaleDeal1 As Double
    Public Property SaleDeal1() As Double
        Get
            Return _SaleDeal1
        End Get
        Set(ByVal value As Double)
            _SaleDeal1 = value
        End Set
    End Property
    Private _SaleDeal2 As Double
    Public Property SaleDeal2() As Double
        Get
            Return _SaleDeal2
        End Get
        Set(ByVal value As Double)
            _SaleDeal2 = value
        End Set
    End Property
    Private _SaleDiscount As Double
    Public Property SaleDiscount() As Double
        Get
            Return _SaleDiscount
        End Get
        Set(ByVal value As Double)
            _SaleDiscount = value
        End Set
    End Property
End Class
