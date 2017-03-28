Imports Microsoft.VisualBasic

Public Class FeeCollectionEl

    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _Fee As Long
    Public Property Fee() As Long
        Get
            Return _Fee
        End Get
        Set(ByVal value As Long)
            _Fee = value
        End Set
    End Property
    Private _SemId As Long
    Public Property SemId() As Long
        Get
            Return _SemId
        End Get
        Set(ByVal value As Long)
            _SemId = value
        End Set
    End Property
    Private _sid As Long
    Public Property SID() As Long
        Get
            Return _sid
        End Get
        Set(ByVal value As Long)
            _sid = value
        End Set
    End Property
    Private _amountpaid As Double
    Public Property Amountpaid() As Double
        Get
            Return _amountpaid
        End Get
        Set(ByVal value As Double)
            _amountpaid = value
        End Set
    End Property
    Private _discount As Double
    Public Property Discount() As Double
        Get
            Return _discount
        End Get
        Set(ByVal value As Double)
            _discount = value
        End Set
    End Property
    Private _Fine As Double
    Public Property Fine() As Double
        Get
            Return _Fine
        End Get
        Set(ByVal value As Double)
            _Fine = value
        End Set
    End Property
    Private _totalfee As Double
    Public Property Totalfee() As Double
        Get
            Return _totalfee
        End Get
        Set(ByVal value As Double)
            _totalfee = value
        End Set
    End Property
    Private _bankid As Long
    Public Property Bankid() As Long
        Get
            Return _bankid
        End Get
        Set(ByVal value As Long)
            _bankid = value
        End Set
    End Property
    Private _paymentmethodid As Long
    Public Property Paymentmethodid() As Long
        Get
            Return _paymentmethodid
        End Get
        Set(ByVal value As Long)
            _paymentmethodid = value
        End Set
    End Property
    Private _dd As String
    Public Property Dd() As String
        Get
            Return _dd
        End Get
        Set(ByVal value As String)
            _dd = value
        End Set
    End Property
    Private _paymentdate As Date
    Public Property PaymentDate() As Date
        Get
            Return _paymentdate
        End Get
        Set(ByVal value As Date)
            _paymentdate = value
        End Set
    End Property
    Private _Chequedate As Date
    Public Property Chequedate() As Date
        Get
            Return _Chequedate
        End Get
        Set(ByVal value As Date)
            _Chequedate = value
        End Set
    End Property
    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property

    Public Sub New()

    End Sub



End Class
