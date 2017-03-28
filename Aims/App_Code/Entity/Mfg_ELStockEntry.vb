Imports Microsoft.VisualBasic

Public Class Mfg_ELStockEntry
    Private _EntryDate As DateTime
    Public Property EntryDate() As DateTime
        Get
            Return _EntryDate
        End Get
        Set(ByVal value As DateTime)
            _EntryDate = value
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
    Private _BatchId As Integer
    Public Property BatchId() As Integer
        Get
            Return _BatchId
        End Get
        Set(ByVal value As Integer)
            _BatchId = value
        End Set
    End Property
    Private _PID As Integer
    Public Property PID() As Integer
        Get
            Return _PID
        End Get
        Set(ByVal value As Integer)
            _PID = value
        End Set
    End Property
    Private _InvoiceID As Integer
    Public Property InvoiceID() As Integer
        Get
            Return _InvoiceID
        End Get
        Set(ByVal value As Integer)
            _InvoiceID = value
        End Set
    End Property
    Private _ProductType As Integer
    Public Property ProductType() As Integer
        Get
            Return _ProductType
        End Get
        Set(ByVal value As Integer)
            _ProductType = value
        End Set
    End Property
    Private _SO As Integer
    Public Property SO() As Integer
        Get
            Return _SO
        End Get
        Set(ByVal value As Integer)
            _SO = value
        End Set
    End Property
    Private _TranscationTypeid As Integer
    Public Property TranscationTypeid() As Integer
        Get
            Return _TranscationTypeid
        End Get
        Set(ByVal value As Integer)
            _TranscationTypeid = value
        End Set
    End Property
    Private _TranscationType As String
    Public Property TranscationType() As String
        Get
            Return _TranscationType
        End Get
        Set(ByVal value As String)
            _TranscationType = value
        End Set
    End Property
    Private _InvoiceNo As String
    Public Property InvoiceNo() As String
        Get
            Return _InvoiceNo
        End Get
        Set(ByVal value As String)
            _InvoiceNo = value
        End Set
    End Property
    Private _ChkID As String
    Public Property ChkID() As String
        Get
            Return _ChkID
        End Get
        Set(ByVal value As String)
            _ChkID = value
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
    Private _Type As String
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
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
    Private _Packing As String
    Public Property Packing() As String
        Get
            Return _Packing
        End Get
        Set(ByVal value As String)
            _Packing = value
        End Set
    End Property
    Private _Currency As Integer
    Public Property Currency() As Integer
        Get
            Return _Currency
        End Get
        Set(ByVal value As Integer)
            _Currency = value
        End Set
    End Property
    Private _ExchangeRate As Double
    Public Property ExchangeRate() As Double
        Get
            Return _ExchangeRate
        End Get
        Set(ByVal value As Double)
            _ExchangeRate = value
        End Set
    End Property
    Private _FinalAmt As Double
    Public Property FinalAmt() As Double
        Get
            Return _FinalAmt
        End Get
        Set(ByVal value As Double)
            _FinalAmt = value
        End Set
    End Property
    Private _Amount As Double
    Public Property Amount() As Double
        Get
            Return _Amount
        End Get
        Set(ByVal value As Double)
            _Amount = value
        End Set
    End Property
    Private _PurchaseVat As Double
    Public Property PurchaseVat() As Double
        Get
            Return _PurchaseVat
        End Get
        Set(ByVal value As Double)
            _PurchaseVat = value
        End Set
    End Property
    Private _PurchaseCST As Double
    Public Property PurchaseCST() As Double
        Get
            Return _PurchaseCST
        End Get
        Set(ByVal value As Double)
            _PurchaseCST = value
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
    Private _BatchName As String
    Public Property BatchName() As String
        Get
            Return _BatchName
        End Get
        Set(ByVal value As String)
            _BatchName = value
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
    Private _PurchaseDeal As Double
    Public Property PurchaseDeal() As Double
        Get
            Return _PurchaseDeal
        End Get
        Set(ByVal value As Double)
            _PurchaseDeal = value
        End Set
    End Property
    Private _Free As Double
    Public Property Free() As Double
        Get
            Return _Free
        End Get
        Set(ByVal value As Double)
            _Free = value
        End Set
    End Property
    Private _Deal As Double
    Public Property Deal() As Double
        Get
            Return _Deal
        End Get
        Set(ByVal value As Double)
            _Deal = value
        End Set
    End Property
    Private _Qty As Double
    Public Property Qty() As Double
        Get
            Return _Qty
        End Get
        Set(ByVal value As Double)
            _Qty = value
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
    Private _MKT As Integer
    Public Property MKT() As Integer
        Get
            Return _MKT
        End Get
        Set(ByVal value As Integer)
            _MKT = value
        End Set
    End Property

    Private _MFG As Integer
    Public Property MFG() As Integer
        Get
            Return _MFG
        End Get
        Set(ByVal value As Integer)
            _MFG = value
        End Set
    End Property
    Private _Taxon As String
    Public Property Taxon() As String
        Get
            Return _Taxon
        End Get
        Set(ByVal value As String)
            _Taxon = value
        End Set
    End Property
    Private _TaxAB As String
    Public Property TaxAB() As String
        Get
            Return _TaxAB
        End Get
        Set(ByVal value As String)
            _TaxAB = value
        End Set
    End Property
    Private _PurchaseDeal1 As Double
    Public Property PurchaseDeal1() As Double
        Get
            Return _PurchaseDeal1
        End Get
        Set(ByVal value As Double)
            _PurchaseDeal1 = value
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
    Private _MRP As Double
    Public Property MRP() As Double
        Get
            Return _MRP
        End Get
        Set(ByVal value As Double)
            _MRP = value
        End Set
    End Property
    Private _Discount As Double
    Public Property Discount() As Double
        Get
            Return _Discount
        End Get
        Set(ByVal value As Double)
            _Discount = value
        End Set
    End Property
    Private _Discountamt As Double
    Public Property Discountamt() As Double
        Get
            Return _Discountamt
        End Get
        Set(ByVal value As Double)
            _Discountamt = value
        End Set
    End Property
    Private _TaxPlan As Integer
    Public Property TaxPlan() As Integer
        Get
            Return _TaxPlan
        End Get
        Set(ByVal value As Integer)
            _TaxPlan = value
        End Set
    End Property
    Private _flatRate As Double
    Public Property flatRate() As Double
        Get
            Return _flatRate
        End Get
        Set(ByVal value As Double)
            _flatRate = value
        End Set
    End Property
    Private _VAT As Double
    Public Property VAT() As Double
        Get
            Return _VAT
        End Get
        Set(ByVal value As Double)
            _VAT = value
        End Set
    End Property
    Private _CST As Double
    Public Property CST() As Double
        Get
            Return _CST
        End Get
        Set(ByVal value As Double)
            _CST = value
        End Set
    End Property
    Private _sngPurchRate As Double
    Public Property sngPurchRate() As Double
        Get
            Return _sngPurchRate
        End Get
        Set(ByVal value As Double)
            _sngPurchRate = value
        End Set
    End Property
    Private _sngTradeDiscount As Double
    Public Property sngTradeDiscount() As Double
        Get
            Return _sngTradeDiscount
        End Get
        Set(ByVal value As Double)
            _sngTradeDiscount = value
        End Set
    End Property
    Private _sngFlatDiscount As Double
    Public Property sngFlatDiscount() As Double
        Get
            Return _sngFlatDiscount
        End Get
        Set(ByVal value As Double)
            _sngFlatDiscount = value
        End Set
    End Property
    Private _sngTax As Double
    Public Property sngTax() As Double
        Get
            Return _sngTax
        End Get
        Set(ByVal value As Double)
            _sngTax = value
        End Set
    End Property
    Private _VATRate As Double
    Public Property VATRate() As Double
        Get
            Return _VATRate
        End Get
        Set(ByVal value As Double)
            _VATRate = value
        End Set
    End Property
    Private _CSTRate As Double
    Public Property CSTRate() As Double
        Get
            Return _CSTRate
        End Get
        Set(ByVal value As Double)
            _CSTRate = value
        End Set
    End Property
    Private _MRPValue As Double
    Public Property MRPValue() As Double
        Get
            Return _MRPValue
        End Get
        Set(ByVal value As Double)
            _MRPValue = value
        End Set
    End Property

    Private _FinalAmount As Double
    Public Property FinalAmount() As Double
        Get
            Return _FinalAmount
        End Get
        Set(ByVal value As Double)
            _FinalAmount = value
        End Set
    End Property
End Class
