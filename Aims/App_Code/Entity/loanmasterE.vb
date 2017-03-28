Imports Microsoft.VisualBasic

Public Class loanmasterE
    Private _loanidcode As String
    Private _loanid As Int64
    Private _empId As Int64
    Private _empname As String
    Private _loantype As String
    Private _loandate As Date
    Private _loanamount As Double
    Private _interestrate As Double
    Private _bank As Integer
    Private _branch As String
    Private _chqno As String
    Private _chequedate As Date
    Private _monthlyded As Double
    Private _balanceloan As Double
    Private _deleteflag As Boolean
    Private _startdate As Date
    Private _id As Int64
    Private _TotalInstallment As Int64
    Private _InstallmentCollected As Int64
    Private _CurrentMonthDedu As Double
    Private _OpeningBalance As Double
    Private _amountType As String
    Private _paymentMethod As String
    Private _guaranteedBy1 As String
    Private _guaranteedBy2 As String
    Private _recovered As String
    Private _remarks As String

    Public Property TotalInstallment() As Int64
        Get
            Return _TotalInstallment
        End Get
        Set(ByVal value As Int64)
            _TotalInstallment = value
        End Set
    End Property
    Public Property InstallmentCollected() As Int64
        Get
            Return _InstallmentCollected
        End Get
        Set(ByVal value As Int64)
            _InstallmentCollected = value
        End Set
    End Property
    Public Property CurrentMonthDedu() As Double
        Get
            Return _CurrentMonthDedu
        End Get
        Set(ByVal value As Double)
            _CurrentMonthDedu = value
        End Set
    End Property
    Public Property OpeningBalance() As Double
        Get
            Return _OpeningBalance
        End Get
        Set(ByVal value As Double)
            _OpeningBalance = value
        End Set
    End Property
    Public Property Loanidcode() As String
        Get
            Return _loanidcode
        End Get
        Set(ByVal value As String)
            _loanidcode = value
        End Set
    End Property
    Public Property ChqNo() As String
        Get
            Return _chqno
        End Get
        Set(ByVal value As String)
            _chqno = value
        End Set
    End Property

    Public Property Empid() As Int64
        Get
            Return _empId
        End Get
        Set(ByVal value As Int64)
            _empId = value
        End Set
    End Property
    Public Property Loanid() As Int64
        Get
            Return _loanid
        End Get
        Set(ByVal value As Int64)
            _loanid = value
        End Set
    End Property
    Public Property Empname() As String
        Get
            Return _empname
        End Get
        Set(ByVal value As String)
            _empname = value
        End Set
    End Property
    Public Property Loantype() As String
        Get
            Return _loantype
        End Get
        Set(ByVal value As String)
            _loantype = value
        End Set
    End Property
    Public Property Loandate() As Date
        Get
            Return _loandate
        End Get
        Set(ByVal value As Date)
            _loandate = value
        End Set
    End Property

    Public Property Loanamount() As Double
        Get
            Return _loanamount
        End Get
        Set(ByVal value As Double)
            _loanamount = value
        End Set
    End Property
    Public Property Interestrate() As Double
        Get
            Return _interestrate
        End Get
        Set(ByVal value As Double)
            _interestrate = value
        End Set
    End Property
    Public Property bank() As Integer
        Get
            Return _bank
        End Get
        Set(ByVal value As Integer)
            _bank = value
        End Set
    End Property
    Public Property branch() As String
        Get
            Return _branch
        End Get
        Set(ByVal value As String)
            _branch = value
        End Set
    End Property
    Public Property Chequedate() As Date
        Get
            Return _chequedate
        End Get
        Set(ByVal value As Date)
            _chequedate = value
        End Set
    End Property
    Public Property monthlyded() As Double
        Get
            Return _monthlyded
        End Get
        Set(ByVal value As Double)
            _monthlyded = value
        End Set
    End Property
    Public Property Balanceloan() As Double
        Get
            Return _balanceloan
        End Get
        Set(ByVal value As Double)
            _balanceloan = value
        End Set
    End Property
    Public Property Deleteflag() As String
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As String)
            _deleteflag = value
        End Set
    End Property
    'Public Property Hold() As Boolean
    '    Get
    '        Return _hold
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _hold = value
    '    End Set
    'End Property
    Public Property id() As Int64
        Get
            Return _id
        End Get
        Set(ByVal value As Int64)
            _id = value
        End Set
    End Property
    Public Property Startdate() As Date
        Get
            Return _startdate
        End Get
        Set(ByVal value As Date)
            _startdate = value
        End Set
    End Property
    Public Property AmountType() As String

        Get
            Return _amountType
        End Get
        Set(ByVal value As String)

            _amountType = value
        End Set
    End Property
    Public Property PaymentMethod() As String
        Get
            Return _paymentMethod
        End Get
        Set(ByVal value As String)
            _paymentMethod = value
        End Set
    End Property
    Public Property GuaranteedBy1() As String
        Get
            Return _guaranteedBy1
        End Get
        Set(ByVal value As String)
            _guaranteedBy1 = value
        End Set
    End Property
    Public Property GuaranteedBy2() As String
        Get
            Return _guaranteedBy2
        End Get
        Set(ByVal value As String)
            _guaranteedBy2 = value
        End Set
    End Property
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property
    Public Property Recovered() As String
        Get
            Return _recovered
        End Get
        Set(ByVal value As String)

            _recovered = value
        End Set
    End Property
End Class

