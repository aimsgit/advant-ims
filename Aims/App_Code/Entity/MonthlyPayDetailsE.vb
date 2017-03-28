Imports Microsoft.VisualBasic

Public Class MonthlyPayDetailsE

    Private _empname As String
    Public Property EmpName() As String
        Get
            Return _empname
        End Get
        Set(ByVal value As String)
            _empname = value
        End Set
    End Property
    Private _md_id As Long
    Public Property MD_ID() As Long
        Get
            Return _md_id
        End Get
        Set(ByVal value As Long)
            _md_id = value
        End Set
    End Property
    Private _empcode As Long
    Public Property EmpCode() As Long
        Get
            Return _empcode
        End Get
        Set(ByVal value As Long)
            _empcode = value
        End Set
    End Property
    Private _daysworked As Integer
    Public Property DaysWorked() As Integer
        Get
            Return _daysworked
        End Get
        Set(ByVal value As Integer)
            _daysworked = value
        End Set
    End Property
    Private _monthlyincentive As Double
    Public Property MonthlyIncentive() As Double
        Get
            Return _monthlyincentive
        End Get
        Set(ByVal value As Double)
            _monthlyincentive = value
        End Set
    End Property
    Private _bonus As Double
    Public Property Bonus() As Double
        Get
            Return _bonus
        End Get
        Set(ByVal value As Double)
            _bonus = value
        End Set
    End Property
    Private _reimbursements As Double
    Public Property Reimbursements() As Double
        Get
            Return _reimbursements
        End Get
        Set(ByVal value As Double)
            _reimbursements = value
        End Set
    End Property
    Private _othermonthlypayments As Double
    Public Property OtherMonthlyPayments() As Double
        Get
            Return _othermonthlypayments
        End Get
        Set(ByVal value As Double)
            _othermonthlypayments = value
        End Set
    End Property
    Private _itdeduction As Double
    Public Property ITDeduction() As Double
        Get
            Return _itdeduction
        End Get
        Set(ByVal value As Double)
            _itdeduction = value
        End Set
    End Property
    Private _loandeduction As Double
    Public Property LoanDeduction() As Double
        Get
            Return _loandeduction
        End Get
        Set(ByVal value As Double)
            _loandeduction = value
        End Set
    End Property
    Private _transportdeduction As Double
    Public Property TransportDeduction() As Double
        Get
            Return _transportdeduction
        End Get
        Set(ByVal value As Double)
            _transportdeduction = value
        End Set
    End Property
    Private _otherdeduction As Double
    Public Property OtherDeduction() As Double
        Get
            Return _otherdeduction
        End Get
        Set(ByVal value As Double)
            _otherdeduction = value
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
    Private _saladv As Double
    Public Property Saladv() As Double
        Get
            Return _saladv
        End Get
        Set(ByVal value As Double)
            _saladv = value
        End Set
    End Property
    Private _advsalded As Double
    Public Property Advsalded() As Double
        Get
            Return _advsalded
        End Get
        Set(ByVal value As Double)
            _advsalded = value
        End Set
    End Property
    Private _PLDays As Double
    Public Property PLDays() As Double
        Get
            Return _PLDays
        End Get
        Set(ByVal value As Double)
            _PLDays = value
        End Set
    End Property
    Public Sub New()

    End Sub

End Class
