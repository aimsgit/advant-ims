Imports Microsoft.VisualBasic

Public Class Mfg_ELSaleInvoice
    Private _Id As Long
    Public Property Id() As Long
        Get
            Return _Id
        End Get
        Set(ByVal value As Long)
            _Id = value
        End Set
    End Property
    Private _Buyer_ID As Integer
    Public Property Buyer_ID() As Integer
        Get
            Return _Buyer_ID
        End Get
        Set(ByVal value As Integer)
            _Buyer_ID = value
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
    Private _InvoiceNo As String
    Public Property InvoiceNo() As String
        Get
            Return _InvoiceNo
        End Get
        Set(ByVal value As String)
            _InvoiceNo = value
        End Set
    End Property
    Private _PurchaseInvoiceMain As Integer
    Public Property PurchaseInvoiceMain() As Integer
        Get
            Return _PurchaseInvoiceMain
        End Get
        Set(ByVal value As Integer)
            _PurchaseInvoiceMain = value
        End Set
    End Property
    Private _PurchaseInvoiceDetails As Integer
    Public Property PurchaseInvoiceDetails() As Integer
        Get
            Return _PurchaseInvoiceDetails
        End Get
        Set(ByVal value As Integer)
            _PurchaseInvoiceDetails = value
        End Set
    End Property

    Private _Sale_Invoice_No As String
    Public Property Sale_Invoice_No() As String
        Get
            Return _Sale_Invoice_No
        End Get
        Set(ByVal value As String)
            _Sale_Invoice_No = value
        End Set
    End Property
    Private _Invoice_Date As DateTime
    Public Property Invoice_Date() As DateTime
        Get
            Return _Invoice_Date
        End Get
        Set(ByVal value As DateTime)
            _Invoice_Date = value
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
    Private _PurchaseRate As Double
    Public Property PurchaseRate() As Double
        Get
            Return _PurchaseRate
        End Get
        Set(ByVal value As Double)
            _PurchaseRate = value
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
    Private _Margin As Double
    Public Property Margin() As Double
        Get
            Return _Margin
        End Get
        Set(ByVal value As Double)
            _Margin = value
        End Set
    End Property

    Private _HIDELFlatRate As Double
    Public Property HIDELFlatRate() As Double
        Get
            Return _HIDELFlatRate
        End Get
        Set(ByVal value As Double)
            _HIDELFlatRate = value
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
    Private _FinalAmount As Double
    Public Property FinalAmount() As Double
        Get
            Return _FinalAmount
        End Get
        Set(ByVal value As Double)
            _FinalAmount = value
        End Set
    End Property
    Private _SE As Integer
    Public Property SE() As Integer
        Get
            Return _SE
        End Get
        Set(ByVal value As Integer)
            _SE = value
        End Set
    End Property
    Private _Payment_Method As Integer
    Public Property Payment_Method() As Integer
        Get
            Return _Payment_Method
        End Get
        Set(ByVal value As Integer)
            _Payment_Method = value
        End Set
    End Property
    Private _Cheque_No As String
    Public Property Cheque_No() As String
        Get
            Return _Cheque_No
        End Get
        Set(ByVal value As String)
            _Cheque_No = value
        End Set
    End Property
    Private _Bank As Integer
    Public Property Bank() As Integer
        Get
            Return _Bank
        End Get
        Set(ByVal value As Integer)
            _Bank = value
        End Set
    End Property
    Private _Branch As String
    Public Property Branch() As String
        Get
            Return _Branch
        End Get
        Set(ByVal value As String)
            _Branch = value
        End Set
    End Property
    Private _Flat_disc_Amt As Double
    Public Property Flat_disc_Amt() As Double
        Get
            Return _Flat_disc_Amt
        End Get
        Set(ByVal value As Double)
            _Flat_disc_Amt = value
        End Set
    End Property
    Private _NO_Of_Item As Integer
    Public Property NO_Of_Item() As Integer
        Get
            Return _NO_Of_Item
        End Get
        Set(ByVal value As Integer)
            _NO_Of_Item = value
        End Set
    End Property
    Private _Challan_NO As String
    Public Property Challan_NO() As String
        Get
            Return _Challan_NO
        End Get
        Set(ByVal value As String)
            _Challan_NO = value
        End Set
    End Property
    Private _Note As String
    Public Property Note() As String
        Get
            Return _Note
        End Get
        Set(ByVal value As String)
            _Note = value
        End Set
    End Property
    Private _Sent_By As String
    Public Property Sent_By() As String
        Get
            Return _Sent_By
        End Get
        Set(ByVal value As String)
            _Sent_By = value
        End Set
    End Property
    Private _Entry_Date As DateTime
    Public Property Entry_Date() As DateTime
        Get
            Return _Entry_Date
        End Get
        Set(ByVal value As DateTime)
            _Entry_Date = value
        End Set
    End Property
    Private _Ref_Date As DateTime
    Public Property Ref_Date() As DateTime
        Get
            Return _Ref_Date
        End Get
        Set(ByVal value As DateTime)
            _Ref_Date = value
        End Set
    End Property
    Private _IN_Date As DateTime
    Public Property IN_Date() As DateTime
        Get
            Return _IN_Date
        End Get
        Set(ByVal value As DateTime)
            _IN_Date = value
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
    Private _Out_Date As DateTime
    Public Property Out_Date() As DateTime
        Get
            Return _Out_Date
        End Get
        Set(ByVal value As DateTime)
            _Out_Date = value
        End Set
    End Property
    Private _SO_NO As Integer
    Public Property SO_NO() As Integer
        Get
            Return _SO_NO
        End Get
        Set(ByVal value As Integer)
            _SO_NO = value
        End Set
    End Property
    Private _Transaction_Type As Integer
    Public Property Transaction_Type() As Integer
        Get
            Return _Transaction_Type
        End Get
        Set(ByVal value As Integer)
            _Transaction_Type = value
        End Set
    End Property
    Private _Flat_Disc As Double
    Public Property Flat_Disc() As Double
        Get
            Return _Flat_Disc
        End Get
        Set(ByVal value As Double)
            _Flat_Disc = value
        End Set
    End Property
    Private _Transport_NO As Integer
    Public Property Transport_NO() As Integer
        Get
            Return _Transport_NO
        End Get
        Set(ByVal value As Integer)
            _Transport_NO = value
        End Set
    End Property
    Private _Curr_rec_Amt As Double
    Public Property Curr_rec_Amt() As Double
        Get
            Return _Curr_rec_Amt
        End Get
        Set(ByVal value As Double)
            _Curr_rec_Amt = value
        End Set
    End Property
    Private _Freight_charges As Double
    Public Property Freight_charges() As Double
        Get
            Return _Freight_charges
        End Get
        Set(ByVal value As Double)
            _Freight_charges = value
        End Set
    End Property
    Private _Credit As Integer
    Public Property Credit() As Integer
        Get
            Return _Credit
        End Get
        Set(ByVal value As Integer)
            _Credit = value
        End Set
    End Property
    Private _Debit As Integer
    Public Property Debit() As Integer
        Get
            Return _Debit
        End Get
        Set(ByVal value As Integer)
            _Debit = value
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
    Private _Dispatched_From As String
    Public Property Dispatched_From() As String
        Get
            Return _Dispatched_From
        End Get
        Set(ByVal value As String)
            _Dispatched_From = value
        End Set
    End Property
    Private _Dispatched_To As String
    Public Property Dispatched_To() As String
        Get
            Return _Dispatched_To
        End Get
        Set(ByVal value As String)
            _Dispatched_To = value
        End Set
    End Property
    Private _Received_Address As Integer
    Public Property Received_Address() As Integer
        Get
            Return _Received_Address
        End Get
        Set(ByVal value As Integer)
            _Received_Address = value
        End Set
    End Property
    Private _Transportation_Mode As Integer
    Public Property Transportation_Mode() As Integer
        Get
            Return _Transportation_Mode
        End Get
        Set(ByVal value As Integer)
            _Transportation_Mode = value
        End Set
    End Property
    Private _Received_Date As DateTime
    Public Property Received_Date() As DateTime
        Get
            Return _Received_Date
        End Get
        Set(ByVal value As DateTime)
            _Received_Date = value
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
    Private _Batch As Integer
    Public Property Batch() As Integer
        Get
            Return _Batch
        End Get
        Set(ByVal value As Integer)
            _Batch = value
        End Set
    End Property
    Private _TotalQty As Double
    Public Property TotalQty() As Double
        Get
            Return _TotalQty
        End Get
        Set(ByVal value As Double)
            _TotalQty = value
        End Set
    End Property
    Private _Deal As Integer
    Public Property Deal() As Integer
        Get
            Return _Deal
        End Get
        Set(ByVal value As Integer)
            _Deal = value
        End Set
    End Property
    Private _Deal1 As Integer
    Public Property Deal1() As Integer
        Get
            Return _Deal1
        End Get
        Set(ByVal value As Integer)
            _Deal1 = value
        End Set
    End Property
    Private _Trade_Rate As Double
    Public Property Trade_Rate() As Double
        Get
            Return _Trade_Rate
        End Get
        Set(ByVal value As Double)
            _Trade_Rate = value
        End Set
    End Property
    Private _DiscPer As Integer
    Public Property DiscPer() As Integer
        Get
            Return _DiscPer
        End Get
        Set(ByVal value As Integer)
            _DiscPer = value
        End Set
    End Property
    Private _Disc_Amt As Double
    Public Property Disc_Amt() As Double
        Get
            Return _Disc_Amt
        End Get
        Set(ByVal value As Double)
            _Disc_Amt = value
        End Set
    End Property
    Private _TaxAB As Integer
    Public Property TaxAB() As Integer
        Get
            Return _TaxAB
        End Get
        Set(ByVal value As Integer)
            _TaxAB = value
        End Set
    End Property
    Private _TaxON As Integer
    Public Property TaxON() As Integer
        Get
            Return _TaxON
        End Get
        Set(ByVal value As Integer)
            _TaxON = value
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
    Private _TotalFinalAmount As Double
    Public Property TotalFinalAmount() As Double
        Get
            Return _TotalFinalAmount
        End Get
        Set(ByVal value As Double)
            _TotalFinalAmount = value
        End Set
    End Property
    Private _FlatDiscAmount As Double
    Public Property FlatDiscAmount() As Double
        Get
            Return _FlatDiscAmount
        End Get
        Set(ByVal value As Double)
            _FlatDiscAmount = value
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
    Private _TotalCSTValue As Double
    Public Property TotalCSTValue() As Double
        Get
            Return _TotalCSTValue
        End Get
        Set(ByVal value As Double)
            _TotalCSTValue = value
        End Set
    End Property
    Private _TotalFinalAmt As Double
    Public Property TotalFinalAmt() As Double
        Get
            Return _TotalFinalAmt
        End Get
        Set(ByVal value As Double)
            _TotalFinalAmt = value
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
    Private _profitLoss As Double
    Public Property profitLoss() As Double
        Get
            Return _profitLoss
        End Get
        Set(ByVal value As Double)
            _profitLoss = value
        End Set
    End Property
    Private _TotalGrandFinalAmt As Double
    Public Property TotalGrandFinalAmt() As Double
        Get
            Return _TotalGrandFinalAmt
        End Get
        Set(ByVal value As Double)
            _TotalGrandFinalAmt = value
        End Set
    End Property
    Private _AddFriCharges As Double
    Public Property AddFriCharges() As Double
        Get
            Return _AddFriCharges
        End Get
        Set(ByVal value As Double)
            _AddFriCharges = value
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
    Private _FlatRate As Double
    Public Property FlatRate() As Double
        Get
            Return _FlatRate
        End Get
        Set(ByVal value As Double)
            _FlatRate = value
        End Set
    End Property
    Private _TotalMargin As Double
    Public Property TotalMargin() As Double
        Get
            Return _TotalMargin
        End Get
        Set(ByVal value As Double)
            _TotalMargin = value
        End Set
    End Property
End Class
