Imports Microsoft.VisualBasic

Public Class Mfg_ElPaymentMade
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _currency As Integer
    Public Property currency() As Integer
        Get
            Return _currency
        End Get
        Set(ByVal value As Integer)
            _currency = value
        End Set
    End Property
    Private _entrydate As DateTime
    Public Property entrydate() As DateTime
        Get
            Return _entrydate
        End Get
        Set(ByVal value As DateTime)
            _entrydate = value
        End Set
    End Property
    Private _supplier As Integer
    Public Property supplier() As Integer
        Get
            Return _supplier
        End Get
        Set(ByVal value As Integer)
            _supplier = value
        End Set
    End Property
    Private _Address As String
    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property
    Private _InvoiceNo As Integer
    Public Property InvoiceNo() As Integer
        Get
            Return _InvoiceNo
        End Get
        Set(ByVal value As Integer)
            _InvoiceNo = value
        End Set
    End Property
    Private _AmtPaid As Integer
    Public Property AmtPaid() As Integer
        Get
            Return _AmtPaid
        End Get
        Set(ByVal value As Integer)
            _AmtPaid = value
        End Set
    End Property
    Private _RecDate As DateTime
    Public Property RecDate() As DateTime
        Get
            Return _RecDate
        End Get
        Set(ByVal value As DateTime)
            _RecDate = value
        End Set
    End Property
    Private _PaymentMethod As Integer
    Public Property PaymentMethod() As Integer
        Get
            Return _PaymentMethod
        End Get
        Set(ByVal value As Integer)
            _PaymentMethod = value
        End Set
    End Property
    Private _VoucherNo As Integer
    Public Property VoucherNo() As Integer
        Get
            Return _VoucherNo
        End Get
        Set(ByVal value As Integer)
            _VoucherNo = value
        End Set
    End Property
    Private _ChequeNo As String
    Public Property ChequeNo() As String
        Get
            Return _ChequeNo
        End Get
        Set(ByVal value As String)
            _ChequeNo = value
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
    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
    Private _Payable As Double
    Public Property Payable() As Double
        Get
            Return _Payable
        End Get
        Set(ByVal value As Double)
            _Payable = value
        End Set
    End Property
    Private _TotalPaid As Double
    Public Property TotalPaid() As Double
        Get
            Return _TotalPaid
        End Get
        Set(ByVal value As Double)
            _TotalPaid = value
        End Set
    End Property
    Private _ExchangeRate As Integer
    Public Property ExchangeRate() As Integer
        Get
            Return _ExchangeRate
        End Get
        Set(ByVal value As Integer)
            _ExchangeRate = value
        End Set
    End Property
    Private _Balance As Double
    Public Property Balance() As Double
        Get
            Return _Balance
        End Get
        Set(ByVal value As Double)
            _Balance = value
        End Set
    End Property
    Private _Payable1 As Double
    Public Property Payable1() As Double
        Get
            Return _Payable1
        End Get
        Set(ByVal value As Double)
            _Payable1 = value
        End Set
    End Property
    Private _TotalPaid1 As Double
    Public Property TotalPaid1() As Double
        Get
            Return _TotalPaid1
        End Get
        Set(ByVal value As Double)
            _TotalPaid1 = value
        End Set
    End Property
    Private _Balance1 As Double
    Public Property Balance1() As Double
        Get
            Return _Balance1
        End Get
        Set(ByVal value As Double)
            _Balance1 = value
        End Set
    End Property
End Class
