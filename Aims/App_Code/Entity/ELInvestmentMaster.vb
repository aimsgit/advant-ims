Imports Microsoft.VisualBasic

Public Class ELInvestmentMaster
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Private _Sponsor_ID As Integer
    Public Property Sponsor_ID() As Integer
        Get
            Return _Sponsor_ID
        End Get
        Set(ByVal value As Integer)
            _Sponsor_ID = value
        End Set
    End Property
    Private _InvestmentAmount As Integer
    Public Property InvestmentAmount() As Integer
        Get
            Return _InvestmentAmount
        End Get
        Set(ByVal value As Integer)
            _InvestmentAmount = value
        End Set
    End Property
    Private _Currency As String
    Public Property Currency() As String
        Get
            Return _Currency
        End Get
        Set(ByVal value As String)
            _Currency = value
        End Set
    End Property
   
    Private _InvestmentType As String
    Public Property InvestmentType() As String
        Get
            Return _InvestmentType
        End Get
        Set(ByVal value As String)
            _InvestmentType = value
        End Set
    End Property
    Private _InvestmentSTDT As Date
    Public Property InvestmentSTDT() As Date
        Get
            Return _InvestmentSTDT
        End Get
        Set(ByVal value As Date)
            _InvestmentSTDT = value
        End Set
    End Property
    Private _InvestmentMaturityDate As Date
    Public Property InvestmentMaturityDate() As Date
        Get
            Return _InvestmentMaturityDate
        End Get
        Set(ByVal value As Date)
            _InvestmentMaturityDate = value
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
    Private _Rateofinterest As Double
    Public Property Rateofinterest() As Double
        Get
            Return _Rateofinterest
        End Get
        Set(ByVal value As Double)
            _Rateofinterest = value
        End Set
    End Property
    Private _InterestAmt As Double
    Public Property InterestAmt() As Double
        Get
            Return _InterestAmt
        End Get
        Set(ByVal value As Double)
            _InterestAmt = value
        End Set
    End Property
    Private _AdminCost As Double
    Public Property AdminCost() As Double
        Get
            Return _AdminCost
        End Get
        Set(ByVal value As Double)
            _AdminCost = value
        End Set
    End Property
    Private _BalanceAmt As Double
    Public Property BalanceAmt() As Double
        Get
            Return _BalanceAmt
        End Get
        Set(ByVal value As Double)
            _BalanceAmt = value
        End Set
    End Property
    Private _AdminAmt As Double
    Public Property AdminAmt() As Double
        Get
            Return _AdminAmt
        End Get
        Set(ByVal value As Double)
            _AdminAmt = value
        End Set
    End Property
    Private _BankID As Integer
    Public Property BankID() As Integer
        Get
            Return _BankID
        End Get
        Set(ByVal value As Integer)
            _BankID = value
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
End Class
