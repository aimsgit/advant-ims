Imports Microsoft.VisualBasic

Public Class Mfg_ELPurchaseInvoice
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
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
    Private _Invoice_Type As String
    Public Property Invoice_Type() As String
        Get
            Return _Invoice_Type
        End Get
        Set(ByVal value As String)
            _Invoice_Type = value
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
    Private _TaxPlan As Integer
    Public Property TaxPlan() As Integer
        Get
            Return _TaxPlan
        End Get
        Set(ByVal value As Integer)
            _TaxPlan = value
        End Set
    End Property
    Private _ProductId As Integer
    Public Property ProductId() As Integer
        Get
            Return _ProductId
        End Get
        Set(ByVal value As Integer)
            _ProductId = value
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
    Private _PurchaseInvoiceID As Integer
    Public Property PurchaseInvoiceID() As Integer
        Get
            Return _PurchaseInvoiceID
        End Get
        Set(ByVal value As Integer)
            _PurchaseInvoiceID = value
        End Set
    End Property
    Private _PurchaseInvoiceNo As String
    Public Property PurchaseInvoiceNo() As String
        Get
            Return _PurchaseInvoiceNo
        End Get
        Set(ByVal value As String)
            _PurchaseInvoiceNo = value
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
    Private _InvoiceDate As DateTime
    Public Property InvoiceDate() As DateTime
        Get
            Return _InvoiceDate
        End Get
        Set(ByVal value As DateTime)
            _InvoiceDate = value
        End Set
    End Property
    Private _ReceiptDate As DateTime
    Public Property ReceiptDate() As DateTime
        Get
            Return _ReceiptDate
        End Get
        Set(ByVal value As DateTime)
            _ReceiptDate = value
        End Set
    End Property
    Private _PaymentType As Integer
    Public Property PaymentType() As Integer
        Get
            Return _PaymentType
        End Get
        Set(ByVal value As Integer)
            _PaymentType = value
        End Set
    End Property
    Private _GRN As String
    Public Property GRN() As String
        Get
            Return _GRN
        End Get
        Set(ByVal value As String)
            _GRN = value
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
    Private _MRPValue As Double
    Public Property MRPValue() As Double
        Get
            Return _MRPValue
        End Get
        Set(ByVal value As Double)
            _MRPValue = value
        End Set
    End Property
    Private _MRPTotalValue As Double
    Public Property MRPTotalValue() As Double
        Get
            Return _MRPTotalValue
        End Get
        Set(ByVal value As Double)
            _MRPTotalValue = value
        End Set
    End Property
    Private _MiscExpValue As Double
    Public Property MiscExpValue() As Double
        Get
            Return _MiscExpValue
        End Get
        Set(ByVal value As Double)
            _MiscExpValue = value
        End Set
    End Property
    Private _FlatDiscount As Double
    Public Property FlatDiscount() As Double
        Get
            Return _FlatDiscount
        End Get
        Set(ByVal value As Double)
            _FlatDiscount = value
        End Set
    End Property
    Private _FlatDiscountAmt As Double
    Public Property FlatDiscountAmt() As Double
        Get
            Return _FlatDiscountAmt
        End Get
        Set(ByVal value As Double)
            _FlatDiscountAmt = value
        End Set
    End Property
    Private _DiffAmt As Double
    Public Property DiffAmt() As Double
        Get
            Return _DiffAmt
        End Get
        Set(ByVal value As Double)
            _DiffAmt = value
        End Set
    End Property
    Private _TaxDiff As Double
    Public Property TaxDiff() As Double
        Get
            Return _TaxDiff
        End Get
        Set(ByVal value As Double)
            _TaxDiff = value
        End Set
    End Property
    Private _DiscDiff As Double
    Public Property DiscDiff() As Double
        Get
            Return _DiscDiff
        End Get
        Set(ByVal value As Double)
            _DiscDiff = value
        End Set
    End Property
    Private _ExiciseDiff As Double
    Public Property ExiciseDiff() As Double
        Get
            Return _ExiciseDiff
        End Get
        Set(ByVal value As Double)
            _ExiciseDiff = value
        End Set
    End Property
 Private _RoundOff As Double
    Public Property RoundOff() As Double
        Get
            Return _RoundOff
        End Get
        Set(ByVal value As Double)
            _RoundOff = value
        End Set
    End Property
    Private _PONO As Integer
    Public Property PONO() As Integer
        Get
            Return _PONO
        End Get
        Set(ByVal value As Integer)
            _PONO = value
        End Set
    End Property
    Private _DispatchFrom As String
    Public Property DispatchFrom() As String
        Get
            Return _DispatchFrom
        End Get
        Set(ByVal value As String)
            _DispatchFrom = value
        End Set
    End Property
    Private _DispatchTo As String
    Public Property DispatchTo() As String
        Get
            Return _DispatchTo
        End Get
        Set(ByVal value As String)
            _DispatchTo = value
        End Set
    End Property
    Private _TransportationNo As String
    Public Property TransportationNo() As String
        Get
            Return _TransportationNo
        End Get
        Set(ByVal value As String)
            _TransportationNo = value
        End Set
    End Property
    Private _TransporatationId As Integer
    Public Property TransporatationId() As Integer
        Get
            Return _TransporatationId
        End Get
        Set(ByVal value As Integer)
            _TransporatationId = value
        End Set
    End Property
    Private _ReceivedBy As String
    Public Property ReceivedBy() As String
        Get
            Return _ReceivedBy
        End Get
        Set(ByVal value As String)
            _ReceivedBy = value
        End Set
    End Property
    Private _ReceivedAddress As String
    Public Property ReceivedAddress() As String
        Get
            Return _ReceivedAddress
        End Get
        Set(ByVal value As String)
            _ReceivedAddress = value
        End Set
    End Property
    Private _PaymentDate As DateTime
    Public Property PaymentDate() As DateTime
        Get
            Return _PaymentDate
        End Get
        Set(ByVal value As DateTime)
            _PaymentDate = value
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
    Private _BatchID As Integer
    Public Property BatchID() As Integer
        Get
            Return _BatchID
        End Get
        Set(ByVal value As Integer)
            _BatchID = value
        End Set
    End Property
    Private _Product As Integer
    Public Property Product() As Integer
        Get
            Return _Product
        End Get
        Set(ByVal value As Integer)
            _Product = value
        End Set
    End Property
    Private _Batchs As String
    Public Property Batchs() As String
        Get
            Return _Batchs
        End Get
        Set(ByVal value As String)
            _Batchs = value
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
    Private _PurchaseDeal1 As Double
    Public Property PurchaseDeal1() As Double
        Get
            Return _PurchaseDeal1
        End Get
        Set(ByVal value As Double)
            _PurchaseDeal1 = value
        End Set
    End Property
    Private _QtyRecd As Double
    Public Property QtyRecd() As Double
        Get
            Return _QtyRecd
        End Get
        Set(ByVal value As Double)
            _QtyRecd = value
        End Set
    End Property
    Private _QtyAccept As Double
    Public Property QtyAccept() As Double
        Get
            Return _QtyAccept
        End Get
        Set(ByVal value As Double)
            _QtyAccept = value
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
    Private _MFG As Integer
    Public Property MFG() As Integer
        Get
            Return _MFG
        End Get
        Set(ByVal value As Integer)
            _MFG = value
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

    Private _RemarksProduct As String
    Public Property RemarksProduct() As String
        Get
            Return _RemarksProduct
        End Get
        Set(ByVal value As String)
            _RemarksProduct = value
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
    Private _PurchRate As Double
    Public Property PurchRate() As Double
        Get
            Return _PurchRate
        End Get
        Set(ByVal value As Double)
            _PurchRate = value
        End Set
    End Property
    Private _PurchRateIV As String
    Public Property PurchRateIV() As String
        Get
            Return _PurchRateIV
        End Get
        Set(ByVal value As String)
            _PurchRateIV = value
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
    Private _Excise As Double
    Public Property Excise() As Double
        Get
            Return _Excise
        End Get
        Set(ByVal value As Double)
            _Excise = value
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
    Private _Discount As Double
    Public Property Discount() As Double
        Get
            Return _Discount
        End Get
        Set(ByVal value As Double)
            _Discount = value
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
    Private _FlatRate As Double
    Public Property FlatRate() As Double
        Get
            Return _FlatRate
        End Get
        Set(ByVal value As Double)
            _FlatRate = value
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
    Private _FinalAmount As Double
    Public Property FinalAmount() As Double
        Get
            Return _FinalAmount
        End Get
        Set(ByVal value As Double)
            _FinalAmount = value
        End Set
    End Property
    Private _TotalAmount As Double
    Public Property TotalAmount() As Double
        Get
            Return _TotalAmount
        End Get
        Set(ByVal value As Double)
            _TotalAmount = value
        End Set
    End Property
    Private _TradeDiscAmount As Double
    Public Property TradeDiscAmount() As Double
        Get
            Return _TradeDiscAmount
        End Get
        Set(ByVal value As Double)
            _TradeDiscAmount = value
        End Set
    End Property
    Private _ExciseDuty As Double
    Public Property ExciseDuty() As Double
        Get
            Return _ExciseDuty
        End Get
        Set(ByVal value As Double)
            _ExciseDuty = value
        End Set
    End Property
    Private _VatAmount As Double
    Public Property VatAmount() As Double
        Get
            Return _VatAmount
        End Get
        Set(ByVal value As Double)
            _VatAmount = value
        End Set
    End Property
    Private _CstAmount As Double
    Public Property CstAmount() As Double
        Get
            Return _CstAmount
        End Get
        Set(ByVal value As Double)
            _CstAmount = value
        End Set
    End Property
    Private _FinalAmountTot As Double
    Public Property FinalAmountTot() As Double
        Get
            Return _FinalAmountTot
        End Get
        Set(ByVal value As Double)
            _FinalAmountTot = value
        End Set
    End Property
    Private _TotalMRP As Double
    Public Property TotalMRP() As Double
        Get
            Return _TotalMRP
        End Get
        Set(ByVal value As Double)
            _TotalMRP = value
        End Set
    End Property
    Private _TotalVATAmount As Double
    Public Property TotalVATAmount() As Double
        Get
            Return _TotalVATAmount
        End Get
        Set(ByVal value As Double)
            _TotalVATAmount = value
        End Set
    End Property
    Private _TotalCSTAmount As Double
    Public Property TotalCSTAmount() As Double
        Get
            Return _TotalCSTAmount
        End Get
        Set(ByVal value As Double)
            _TotalCSTAmount = value
        End Set
    End Property

    Private _TotalFinalAmount As Double
    Public Property TotalFinalAmount() As Double
        Get
            Return _TotalFinalAmount
        End Get
        Set(ByVal value As Double)
            _TotalFinalAmount = value
        End Set
    End Property
    Private _TotalExcise As Double
    Public Property TotalExcise() As Double
        Get
            Return _TotalExcise
        End Get
        Set(ByVal value As Double)
            _TotalExcise = value
        End Set
    End Property
    Private _GrandFinalAmount As Double
    Public Property GrandFinalAmount() As Double
        Get
            Return _GrandFinalAmount
        End Get
        Set(ByVal value As Double)
            _GrandFinalAmount = value
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
    Private _CST As Double
    Public Property CST() As Double
        Get
            Return _CST
        End Get
        Set(ByVal value As Double)
            _CST = value
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

    Private _HIDPurchaseInvoice As Integer
    Public Property HIDPurchaseInvoice() As Integer
        Get
            Return _HIDPurchaseInvoice
        End Get
        Set(ByVal value As Integer)
            _HIDPurchaseInvoice = value
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
    Private _free As Double
    Public Property free() As Double
        Get
            Return _free
        End Get
        Set(ByVal value As Double)
            _free = value
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
Private _VATRate  As Double
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
End Class
