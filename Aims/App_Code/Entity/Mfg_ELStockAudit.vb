Imports Microsoft.VisualBasic

Public Class Mfg_ELStockAudit
    Private _Id As Long
    Public Property Id() As Long
        Get
            Return _Id
        End Get
        Set(ByVal value As Long)
            _Id = value
        End Set
    End Property
    Private _Supp_ID As Integer
    Public Property Supp_ID() As Integer
        Get
            Return _Supp_ID
        End Get
        Set(ByVal value As Integer)
            _Supp_ID = value
        End Set
    End Property
    Private _AuditID As Integer
    Public Property AuditID() As Integer
        Get
            Return _AuditID
        End Get
        Set(ByVal value As Integer)
            _AuditID = value
        End Set
    End Property
    Private _AuditNo As String
    Public Property AuditNo() As String
        Get
            Return _AuditNo
        End Get
        Set(ByVal value As String)
            _AuditNo = value
        End Set
    End Property
    Private _Countsign As String
    Public Property Countsign() As String
        Get
            Return _Countsign
        End Get
        Set(ByVal value As String)
            _Countsign = value
        End Set
    End Property
    Private _Stock_Audit As String
    Public Property Stock_Audit() As String
        Get
            Return _Stock_Audit
        End Get
        Set(ByVal value As String)
            _Stock_Audit = value
        End Set
    End Property

    Private _FromDate As Date
    Public Property FromDate() As Date
        Get
            Return _FromDate
        End Get
        Set(ByVal value As Date)
            _FromDate = value
        End Set
    End Property

    Private _Todate As Date
    Public Property Todate() As Date
        Get
            Return _Todate
        End Get
        Set(ByVal value As Date)
            _Todate = value
        End Set
    End Property
    Private _ProductID As Integer
    Public Property ProductID() As Integer
        Get
            Return _ProductID
        End Get
        Set(ByVal value As Integer)
            _ProductID = value
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
    Private _Auditflag As String
    Public Property Auditflag() As String
        Get
            Return _Auditflag
        End Get
        Set(ByVal value As String)
            _Auditflag = value
        End Set
    End Property
    Private _QtyIn As Double
    Public Property QtyIn() As Double
        Get
            Return _QtyIn
        End Get
        Set(ByVal value As Double)
            _QtyIn = value
        End Set
    End Property
    Private _QtyOut As Double
    Public Property QtyOut() As Double
        Get
            Return _QtyOut
        End Get
        Set(ByVal value As Double)
            _QtyOut = value
        End Set
    End Property
    Private _CountDiff As Integer
    Public Property CountDiff() As Integer
        Get
            Return _CountDiff
        End Get
        Set(ByVal value As Integer)
            _CountDiff = value
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
    Private _Packingdetails As String
    Public Property Packingdetails() As String
        Get
            Return _Packingdetails
        End Get
        Set(ByVal value As String)
            _Packingdetails = value
        End Set
    End Property

    Private _Purchaseinvoiceid As Integer
    Public Property Purchaseinvoiceid() As Integer
        Get
            Return _Purchaseinvoiceid
        End Get
        Set(ByVal value As Integer)
            _Purchaseinvoiceid = value
        End Set
    End Property
    Private _PRDID As Integer
    Public Property PRDID() As Integer
        Get
            Return _PRDID
        End Get
        Set(ByVal value As Integer)
            _PRDID = value
        End Set
    End Property

    Private _RefDate As Date
    Public Property RefDate() As Date
        Get
            Return _RefDate
        End Get
        Set(ByVal value As Date)
            _RefDate = value
        End Set
    End Property

    Private _PurchaseRate As Double
    Public Property PurchaseRate() As Double
        Get
            Return _PurchaseRate
        End Get
        Set(ByVal value As Double)
            _PurchaseRate = value
        End Set
    End Property

    Private _TradeDisc As Double
    Public Property TradeDisc() As Double
        Get
            Return _TradeDisc
        End Get
        Set(ByVal value As Double)
            _TradeDisc = value
        End Set
    End Property
    Private _FlatDisc As Double
    Public Property FlatDisc() As Double
        Get
            Return _FlatDisc
        End Get
        Set(ByVal value As Double)
            _FlatDisc = value
        End Set
    End Property

    Private _PurchseTaxstrid As Integer
    Public Property PurchseTaxstrid() As Integer
        Get
            Return _PurchseTaxstrid
        End Get
        Set(ByVal value As Integer)
            _PurchseTaxstrid = value
        End Set
    End Property
    Private _PurchseTaxBeforafterDisc As Integer
    Public Property PurchseTaxBeforafterDisc() As Integer
        Get
            Return _PurchseTaxBeforafterDisc
        End Get
        Set(ByVal value As Integer)
            _PurchseTaxBeforafterDisc = value
        End Set
    End Property

    Private _PurchseTaxPlan As Integer
    Public Property PurchseTaxPlan() As Integer
        Get
            Return _PurchseTaxPlan
        End Get
        Set(ByVal value As Integer)
            _PurchseTaxPlan = value
        End Set
    End Property
    Private _PurchseVAT As Double
    Public Property PurchseVAT() As Double
        Get
            Return _PurchseVAT
        End Get
        Set(ByVal value As Double)
            _PurchseVAT = value
        End Set
    End Property
    Private _PurchseCAT As Double
    Public Property PurchseCAT() As Double
        Get
            Return _PurchseCAT
        End Get
        Set(ByVal value As Double)
            _PurchseCAT = value
        End Set
    End Property

    Private _FlatRate As Double
    Public Property FlatRate() As Double
        Get
            Return _FlatRate
        End Get
        Set(ByVal value As Double)
            _FlatRate = value
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
    Private _MRP As Double
    Public Property MRP() As Double
        Get
            Return _MRP
        End Get
        Set(ByVal value As Double)
            _MRP = value
        End Set
    End Property
    Private _StkDiff As Integer
    Public Property StkDiff() As Integer
        Get
            Return _StkDiff
        End Get
        Set(ByVal value As Integer)
            _StkDiff = value
        End Set
    End Property
    Private _ExpiryDate As Date
    Public Property ExpiryDate() As Date
        Get
            Return _ExpiryDate
        End Get
        Set(ByVal value As Date)
            _ExpiryDate = value
        End Set
    End Property
    Private _QtyinStk As Integer
    Public Property QtyinStk() As Integer
        Get
            Return _QtyinStk
        End Get
        Set(ByVal value As Integer)
            _QtyinStk = value
        End Set
    End Property

    Private _Stock_Date As Date
    Public Property Stock_Date() As Date
        Get
            Return _Stock_Date
        End Get
        Set(ByVal value As Date)
            _Stock_Date = value
        End Set
    End Property

    Private _CurrencyRate As Double
    Public Property CurrencyRate() As Double
        Get
            Return _CurrencyRate
        End Get
        Set(ByVal value As Double)
            _CurrencyRate = value
        End Set
    End Property
    Private _PurchaseVAT_Amount As Double
    Public Property PurchaseVAT_Amount() As Double
        Get
            Return _PurchaseVAT_Amount
        End Get
        Set(ByVal value As Double)
            _PurchaseVAT_Amount = value
        End Set
    End Property
    Private _PurchaseCST_Amount As Double
    Public Property PurchaseCST_Amount() As Double
        Get
            Return _PurchaseCST_Amount
        End Get
        Set(ByVal value As Double)
            _PurchaseCST_Amount = value
        End Set
    End Property

End Class
