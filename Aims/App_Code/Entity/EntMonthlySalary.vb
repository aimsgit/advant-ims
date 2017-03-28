Imports Microsoft.VisualBasic
Imports System

Public Class EntMonthlySalary
    Private _MSid As Long
    Public Property MSid() As Long
        Get
            Return _MSid
        End Get
        Set(ByVal value As Long)
            _MSid = value
        End Set
    End Property

    Private _EMPid As Long
    Public Property EMPid() As Long
        Get
            Return _EMPid
        End Get
        Set(ByVal value As Long)
            _EMPid = value
        End Set
    End Property

    Private _PaymentDate As Date
    Public Property PaymentDate() As Date
        Get
            Return _PaymentDate
        End Get
        Set(ByVal value As Date)
            _PaymentDate = value
        End Set
    End Property

    Private _EntryDate As Date
    Public Property EntryDate() As Date
        Get
            Return _EntryDate
        End Get
        Set(ByVal value As Date)
            _EntryDate = value
        End Set
    End Property

    Private _BasicPay As Single
    Public Property BasicPay() As Single
        Get
            Return _BasicPay
        End Get
        Set(ByVal value As Single)
            _BasicPay = value
        End Set
    End Property

    Private _SpecialAllowance As Single
    Public Property SpecialAllowance() As Single
        Get
            Return _SpecialAllowance
        End Get
        Set(ByVal value As Single)
            _SpecialAllowance = value
        End Set
    End Property

    Private _HRA As Single
    Public Property HRA() As Single
        Get
            Return _HRA
        End Get
        Set(ByVal value As Single)
            _HRA = value
        End Set
    End Property

    Private _Medical As Single
    Public Property Medical() As Single
        Get
            Return _Medical
        End Get
        Set(ByVal value As Single)
            _Medical = value
        End Set
    End Property

    Private _TransportAllowance As Single
    Public Property TransportAllowance() As Single
        Get
            Return _TransportAllowance
        End Get
        Set(ByVal value As Single)
            _TransportAllowance = value
        End Set
    End Property

    Private _OtherAllowance As Single
    Public Property OtherAllowance() As Single
        Get
            Return _OtherAllowance
        End Get
        Set(ByVal value As Single)
            _OtherAllowance = value
        End Set
    End Property

    Private _Incentives As Single
    Public Property Incentives() As Single
        Get
            Return _Incentives
        End Get
        Set(ByVal value As Single)
            _Incentives = value
        End Set
    End Property

    Private _MiscellaneousPay As Single
    Public Property MiscellaneousPay() As Single
        Get
            Return _MiscellaneousPay
        End Get
        Set(ByVal value As Single)
            _MiscellaneousPay = value
        End Set
    End Property

    Private _TaxDeduction As Single
    Public Property TaxDeduction() As Single
        Get
            Return _TaxDeduction
        End Get
        Set(ByVal value As Single)
            _TaxDeduction = value
        End Set
    End Property
    Private _ITTaxDeduction As Single
    Public Property ITTaxDeduction() As Single
        Get
            Return _ITTaxDeduction
        End Get
        Set(ByVal value As Single)
            _ITTaxDeduction = value
        End Set
    End Property

    Private _AdvStlDeduction As Single
    Public Property AdvStlDeduction() As Single
        Get
            Return _AdvStlDeduction
        End Get
        Set(ByVal value As Single)
            _AdvStlDeduction = value
        End Set
    End Property

    Private _OtherDeduction As Single
    Public Property OtherDeduction() As Single
        Get
            Return _OtherDeduction
        End Get
        Set(ByVal value As Single)
            _OtherDeduction = value
        End Set
    End Property

    Private _GrossSalary As Single
    Public Property GrossSalary() As Single
        Get
            Return _GrossSalary
        End Get
        Set(ByVal value As Single)
            _GrossSalary = value
        End Set
    End Property

    Private _NetSalary As Single
    Public Property NetSalary() As Single
        Get
            Return _NetSalary
        End Get
        Set(ByVal value As Single)
            _NetSalary = value
        End Set
    End Property

    Private _LOPay As Single
    Public Property LOPay() As Single
        Get
            Return _LOPay
        End Get
        Set(ByVal value As Single)
            _LOPay = value
        End Set
    End Property

    Private _OtherPay As Single
    Public Property OtherPay() As Single
        Get
            Return _OtherPay
        End Get
        Set(ByVal value As Single)
            _OtherPay = value
        End Set
    End Property
    Private _DelFlag As Int16
    Public Property DelFlag() As Int16
        Get
            Return _DelFlag
        End Get
        Set(ByVal value As Int16)
            _DelFlag = value
        End Set
    End Property

    Public Sub New(ByVal MSid As Long, ByVal EMPid As Long, ByVal PaymentDate As Date, ByVal EntryDate As Date, ByVal BasicPay As Single, ByVal SpecialAllowance As Single, ByVal HRA As Single, ByVal Medical As Single, ByVal TransportAllowance As Single, ByVal OtherAllowance As Single, ByVal Incentives As Single, ByVal MiscellaneousPay As Single, ByVal TaxDeduction As Single, ByVal ITTaxDeduction As Single, ByVal AdvStlDeduction As Single, ByVal OtherDeduction As Single, ByVal GrossSalary As Double, ByVal NetSalary As Double, ByVal LOPay As Single, ByVal DelFlag As Integer, ByVal OtherPay As Single)
        _MSid = MSid
        _EMPid = EMPid
        _PaymentDate = PaymentDate
        _EntryDate = EntryDate
        _BasicPay = BasicPay
        _SpecialAllowance = SpecialAllowance
        _HRA = HRA
        _Medical = Medical
        _TransportAllowance = TransportAllowance
        _OtherAllowance = OtherAllowance
        _Incentives = Incentives
        _MiscellaneousPay = MiscellaneousPay
        _TaxDeduction = TaxDeduction
        _ITTaxDeduction = ITTaxDeduction
        _AdvStlDeduction = AdvStlDeduction
        _OtherDeduction = OtherDeduction
        _GrossSalary = GrossSalary
        _NetSalary = NetSalary
        _LOPay = LOPay
        _OtherPay = OtherPay
        _DelFlag = DelFlag
    End Sub

    Public Sub New()

    End Sub

End Class
