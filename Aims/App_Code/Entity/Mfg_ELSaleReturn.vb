Imports Microsoft.VisualBasic

Public Class Mfg_ELSaleReturn
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
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

    Private _PRD_ID As Integer
    Public Property PRD_ID() As Integer
        Get
            Return _PRD_ID
        End Get
        Set(ByVal value As Integer)
            _PRD_ID = value
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
    Private _ReturnId As Integer
    Public Property ReturnId() As Integer
        Get
            Return _ReturnId
        End Get
        Set(ByVal value As Integer)
            _ReturnId = value
        End Set
    End Property
    Private _StockId As Integer
    Public Property StockId() As Integer
        Get
            Return _StockId
        End Get
        Set(ByVal value As Integer)
            _StockId = value
        End Set
    End Property
    Private _ReturnNo As String
    Public Property ReturnNo() As String
        Get
            Return _ReturnNo
        End Get
        Set(ByVal value As String)
            _ReturnNo = value
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
    Private _ReturnDate As DateTime
    Public Property ReturnDate() As DateTime
        Get
            Return _ReturnDate
        End Get
        Set(ByVal value As DateTime)
            _ReturnDate = value
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
    Private _Product As Integer
    Public Property Product() As Integer
        Get
            Return _Product
        End Get
        Set(ByVal value As Integer)
            _Product = value
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
    Private _ReturnedQty As Double
    Public Property ReturnedQty() As Double
        Get
            Return _ReturnedQty
        End Get
        Set(ByVal value As Double)
            _ReturnedQty = value
        End Set
    End Property
    Private _RemarksS As String
    Public Property RemarksS() As String
        Get
            Return _RemarksS
        End Get
        Set(ByVal value As String)
            _RemarksS = value
        End Set
    End Property
    Private _ExchRate As Double
    Public Property ExchRate() As Double
        Get
            Return _ExchRate
        End Get
        Set(ByVal value As Double)
            _ExchRate = value
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
    Private _Currency As Integer
    Public Property Currency() As Integer
        Get
            Return _Currency
        End Get
        Set(ByVal value As Integer)
            _Currency = value
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
    Private _BatchName As String
    Public Property BatchName() As String
        Get
            Return _BatchName
        End Get
        Set(ByVal value As String)
            _BatchName = value
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
    Private _ExpiryDtae As DateTime
    Public Property ExpiryDtae() As DateTime
        Get
            Return _ExpiryDtae
        End Get
        Set(ByVal value As DateTime)
            _ExpiryDtae = value
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
    Private _QtyInStock As Double
    Public Property QtyInStock() As Double
        Get
            Return _QtyInStock
        End Get
        Set(ByVal value As Double)
            _QtyInStock = value
        End Set
    End Property
    Private _QtyInUsed As Double
    Public Property QtyInUsed() As Double
        Get
            Return _QtyInUsed
        End Get
        Set(ByVal value As Double)
            _QtyInUsed = value
        End Set
    End Property
    Private _NetUsableQty As Double
    Public Property NetUsableQty() As Double
        Get
            Return _NetUsableQty
        End Get
        Set(ByVal value As Double)
            _NetUsableQty = value
        End Set
    End Property
    Private _HidPurchaseReturnId As Integer
    Public Property HidPurchaseReturnId() As Integer
        Get
            Return _HidPurchaseReturnId
        End Get
        Set(ByVal value As Integer)
            _HidPurchaseReturnId = value
        End Set
    End Property
End Class
