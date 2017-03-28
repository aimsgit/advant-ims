Imports Microsoft.VisualBasic

Public Class EntPayroll

    Private _Year As Integer
    Public Property Year() As Integer
        Get
            Return _Year
        End Get
        Set(ByVal value As Integer)
            _Year = value
        End Set
    End Property
    Private _Formula As Integer
    Public Property Formula() As Integer
        Get
            Return _Formula
        End Get
        Set(ByVal value As Integer)
            _Formula = value
        End Set
    End Property
    Private _WorkDays As Integer
    Public Property WorkDays() As Integer
        Get
            Return _WorkDays
        End Get
        Set(ByVal value As Integer)
            _WorkDays = value
        End Set
    End Property
    Private _Dept As Integer
    Public Property Dept() As Integer
        Get
            Return _Dept
        End Get
        Set(ByVal value As Integer)
            _Dept = value
        End Set
    End Property
    Private _Month As String
    Public Property Month() As String
        Get
            Return _Month
        End Get
        Set(ByVal value As String)
            _Month = value
        End Set
    End Property
    Private _LoanCode As String
    Public Property LoanCode() As String
        Get
            Return _LoanCode
        End Get
        Set(ByVal value As String)
            _LoanCode = value
        End Set
    End Property
    Private _Lock As String
    Public Property Lock() As String
        Get
            Return _Lock
        End Get
        Set(ByVal value As String)
            _Lock = value
        End Set
    End Property
    Private _WD_InMonth As Integer
    Public Property WD_InMonth() As Integer
        Get
            Return _WD_InMonth
        End Get
        Set(ByVal value As Integer)
            _WD_InMonth = value
        End Set
    End Property
    Private _PaymentId As Integer
    Public Property PaymentId() As Integer
        Get
            Return _PaymentId
        End Get
        Set(ByVal value As Integer)
            _PaymentId = value
        End Set
    End Property
    Private _PayDate As Date
    Public Property PayDate() As Date
        Get
            Return _PayDate
        End Get
        Set(ByVal value As Date)
            _PayDate = value
        End Set
    End Property
    Private _MS_id As Long
    Public Property iMS_id() As Long
        Get
            Return _MS_id
        End Get
        Set(ByVal value As Long)
            _MS_id = value
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
    Private _SRDate As Date
    Public Property SRDate() As Date
        Get
            Return _SRDate
        End Get
        Set(ByVal value As Date)
            _SRDate = value
        End Set
    End Property
    Private _BasicPay As Double
    Public Property BasicPay() As Double
        Get
            Return _BasicPay
        End Get
        Set(ByVal value As Double)
            _BasicPay = value
        End Set
    End Property
    Private _LoanAmt As Double
    Public Property LoanAmt() As Double
        Get
            Return _LoanAmt
        End Get
        Set(ByVal value As Double)
            _LoanAmt = value
        End Set
    End Property
    Private _SpecialAllowance As Double
    Public Property SpecialAllowance() As Double
        Get
            Return _SpecialAllowance
        End Get
        Set(ByVal value As Double)
            _SpecialAllowance = value
        End Set
    End Property
    Private _VPF As Double
    Public Property VPF() As Double
        Get
            Return _VPF
        End Get
        Set(ByVal value As Double)
            _VPF = value
        End Set
    End Property
    Private _DearnessAllowance As Double
    Public Property DearnessAllowance() As Double
        Get
            Return _DearnessAllowance
        End Get
        Set(ByVal value As Double)
            _DearnessAllowance = value
        End Set
    End Property
    Private _HRA As Double
    Public Property HRA() As Double
        Get
            Return _HRA
        End Get
        Set(ByVal value As Double)
            _HRA = value
        End Set
    End Property
    Private _Medical As Double
    Public Property Medical() As Double
        Get
            Return _Medical
        End Get
        Set(ByVal value As Double)
            _Medical = value
        End Set
    End Property
    Private _TransportAllowance As Double
    Public Property TransportAllowance() As Double
        Get
            Return _TransportAllowance
        End Get
        Set(ByVal value As Double)
            _TransportAllowance = value
        End Set
    End Property
    Private _FixedIncentive As Double
    Public Property FixedIncentive() As Double
        Get
            Return _FixedIncentive
        End Get
        Set(ByVal value As Double)
            _FixedIncentive = value
        End Set
    End Property
    Private _PF As Double
    Public Property PF() As Double
        Get
            Return _PF
        End Get
        Set(ByVal value As Double)
            _PF = value
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
    Private _ProfTaxDeduction As Double
    Public Property ProfTaxDeduction() As Double
        Get
            Return _ProfTaxDeduction
        End Get
        Set(ByVal value As Double)
            _ProfTaxDeduction = value
        End Set
    End Property
    Private _CityCompAllw As Double
    Public Property CityCompAllw() As Double
        Get
            Return _CityCompAllw
        End Get
        Set(ByVal value As Double)
            _CityCompAllw = value
        End Set
    End Property
    Private _MA1 As Double
    Public Property MA1() As Double
        Get
            Return _MA1
        End Get
        Set(ByVal value As Double)
            _MA1 = value
        End Set
    End Property
    Private _MA2 As Double
    Public Property MA2() As Double
        Get
            Return _MA2
        End Get
        Set(ByVal value As Double)
            _MA2 = value
        End Set
    End Property
    Private _MA3 As Double
    Public Property MA3() As Double
        Get
            Return _MA3
        End Get
        Set(ByVal value As Double)
            _MA3 = value
        End Set
    End Property
    Private _MA4 As Double
    Public Property MA4() As Double
        Get
            Return _MA4
        End Get
        Set(ByVal value As Double)
            _MA4 = value
        End Set
    End Property
    Private _MA5 As Double
    Public Property MA5() As Double
        Get
            Return _MA5
        End Get
        Set(ByVal value As Double)
            _MA5 = value
        End Set
    End Property
    Private _MA6 As Double
    Public Property MA6() As Double
        Get
            Return _MA6
        End Get
        Set(ByVal value As Double)
            _MA6 = value
        End Set
    End Property
    Private _MA7 As Double
    Public Property MA7() As Double
        Get
            Return _MA7
        End Get
        Set(ByVal value As Double)
            _MA7 = value
        End Set
    End Property
    Private _MA8 As Double
    Public Property MA8() As Double
        Get
            Return _MA8
        End Get
        Set(ByVal value As Double)
            _MA8 = value
        End Set
    End Property
    Private _MA9 As Double
    Public Property MA9() As Double
        Get
            Return _MA9
        End Get
        Set(ByVal value As Double)
            _MA9 = value
        End Set
    End Property
    Private _OverTime As Double
    Public Property OverTime() As Double
        Get
            Return _OverTime
        End Get
        Set(ByVal value As Double)
            _OverTime = value
        End Set
    End Property
    Private _Honorary As Double
    Public Property Honorary() As Double
        Get
            Return _Honorary
        End Get
        Set(ByVal value As Double)
            _Honorary = value
        End Set
    End Property


    Private _DA As Double
    Public Property DA() As Double
        Get
            Return _DA
        End Get
        Set(ByVal value As Double)
            _DA = value
        End Set
    End Property
    Private _MD1 As Double
    Public Property MD1() As Double
        Get
            Return _MD1
        End Get
        Set(ByVal value As Double)
            _MD1 = value
        End Set
    End Property
    Private _MD2 As Double
    Public Property MD2() As Double
        Get
            Return _MD2
        End Get
        Set(ByVal value As Double)
            _MD2 = value
        End Set

    End Property
    Private _MD3 As Double
    Public Property MD3() As Double
        Get
            Return _MD3
        End Get
        Set(ByVal value As Double)
            _MD3 = value
        End Set
    End Property
    Private _MD4 As Double
    Public Property MD4() As Double
        Get
            Return _MD4
        End Get
        Set(ByVal value As Double)
            _MD4 = value
        End Set
    End Property
    Private _MD5 As Double
    Public Property MD5() As Double
        Get
            Return _MD5
        End Get
        Set(ByVal value As Double)
            _MD5 = value
        End Set
    End Property
    Private _MD6 As Double
    Public Property MD6() As Double
        Get
            Return _MD6
        End Get
        Set(ByVal value As Double)
            _MD6 = value
        End Set
    End Property
    Private _MD7 As Double
    Public Property MD7() As Double
        Get
            Return _MD7
        End Get
        Set(ByVal value As Double)
            _MD7 = value
        End Set
    End Property
    Private _MD8 As Double
    Public Property MD8() As Double
        Get
            Return _MD8
        End Get
        Set(ByVal value As Double)
            _MD8 = value
        End Set
    End Property
    Private _MD9 As Double
    Public Property MD9() As Double
        Get
            Return _MD9
        End Get
        Set(ByVal value As Double)
            _MD9 = value
        End Set
    End Property
    Private _MD10 As Double
    Public Property MD10() As Double
        Get
            Return _MD10
        End Get
        Set(ByVal value As Double)
            _MD10 = value
        End Set
    End Property
    Private _MD11 As Double
    Public Property MD11() As Double
        Get
            Return _MD11
        End Get
        Set(ByVal value As Double)
            _MD11 = value
        End Set
    End Property
    Private _MD12 As Double
    Public Property MD12() As Double
        Get
            Return _MD12
        End Get
        Set(ByVal value As Double)
            _MD12 = value
        End Set
    End Property
    Private _MD13 As Double
    Public Property MD13() As Double
        Get
            Return _MD13
        End Get
        Set(ByVal value As Double)
            _MD13 = value
        End Set
    End Property
    Private _MD14 As Double
    Public Property MD14() As Double
        Get
            Return _MD14
        End Get
        Set(ByVal value As Double)
            _MD14 = value
        End Set
    End Property
    Private _MD15 As Double
    Public Property MD15() As Double
        Get
            Return _MD15
        End Get
        Set(ByVal value As Double)
            _MD15 = value
        End Set
    End Property
    Private _MD16 As Double
    Public Property MD16() As Double
        Get
            Return _MD16
        End Get
        Set(ByVal value As Double)
            _MD16 = value
        End Set
    End Property
    Private _FestAdvantce As Double
    Public Property FestAdvantce() As Double
        Get
            Return _FestAdvantce
        End Get
        Set(ByVal value As Double)
            _FestAdvantce = value
        End Set
    End Property
    Private _EmpName As String
    Public Property EmpName() As String
        Get
            Return _EmpName
        End Get
        Set(ByVal value As String)
            _EmpName = value
        End Set
    End Property
    Private _Empcode As String
    Public Property Empcode() As String
        Get
            Return _Empcode
        End Get
        Set(ByVal value As String)
            _Empcode = value
        End Set
    End Property
    Private _PFAcct As String
    Public Property PFAcct() As String
        Get
            Return _PFAcct
        End Get
        Set(ByVal value As String)
            _PFAcct = value
        End Set
    End Property
    Private _Settlement As String
    Public Property Settlement() As String
        Get
            Return _Settlement
        End Get
        Set(ByVal value As String)
            _Settlement = value
        End Set
    End Property
    Private _MonthNo As Integer
    Public Property MonthNo() As Integer
        Get
            Return _MonthNo
        End Get
        Set(ByVal value As Integer)
            _MonthNo = value
        End Set
    End Property

    Private _Pensionable As String
    Public Property Pensionable() As String
        Get
            Return _Pensionable
        End Get
        Set(ByVal value As String)
            _Pensionable = value
        End Set
    End Property





    Private _SFN As Double


    'Private _Insentive As Double
    'Public Property Insentive() As Double
    '    Get
    '        Return _Insentive
    '    End Get
    '    Set(ByVal value As Double)
    '        _Insentive = value
    '    End Set
    'End Property


    Public Sub New(ByVal EMPid As Double, ByVal SRDate As Date, ByVal BasicPay As Double, ByVal SpecialAllowance As Double, ByVal VPF As Double, ByVal DearnessAllowance As Double, ByVal HRA As Double, ByVal Medical As Double, ByVal TransportAllowance As Double, ByVal PF As Double, ByVal FixedIncentive As Double, ByVal DelFlag As Integer, ByVal ProfTaxDeduction As Double, ByVal MA1 As Double, ByVal MA2 As Double, ByVal MA3 As Double, ByVal MA4 As Double, ByVal MA5 As Double, ByVal MA6 As Double, ByVal MA7 As Double, ByVal MA8 As Double, ByVal MA9 As Double, ByVal MD1 As Double, ByVal MD2 As Double, ByVal MD3 As Double, ByVal MD4 As Double, ByVal MD5 As Double, ByVal MD6 As Double, ByVal MD7 As Double, ByVal MD8 As Double, ByVal MD9 As Double, ByVal MD10 As Double, ByVal MD11 As Double, ByVal MD12 As Double, ByVal MD13 As Double, ByVal MD14 As Double, ByVal MD15 As Double, ByVal MD16 As Double)

        _EMPid = EMPid
        _SRDate = SRDate
        _BasicPay = BasicPay
        _SpecialAllowance = SpecialAllowance
        _DearnessAllowance = DearnessAllowance
        _HRA = HRA
        _Medical = Medical
        _TransportAllowance = TransportAllowance
        _FixedIncentive = FixedIncentive
        _PF = PF
        _ProfTaxDeduction = ProfTaxDeduction
        _MA1 = MA1
        _MA2 = MA2
        _MA3 = MA3
        _MA4 = MA4
        _MA5 = MA5
        _MA6 = MA6
        _MA7 = MA7
        _MA8 = MA8
        _MA9 = MA9
        _MD1 = MD1
        _MD2 = MD2
        _MD3 = MD3
        _MD4 = MD4
        _MD5 = MD5
        _MD6 = MD6
        _MD7 = MD7
        _MD8 = MD8
        _MD9 = MD9
        _MD10 = MD10
        _MD11 = MD11
        _MD12 = MD12
        _MD13 = MD13
        _MD14 = MD14
        _MD15 = MD15
        _MD16 = MD16
        _VPF = VPF

        _DelFlag = DelFlag
    End Sub
   
    

    Public Sub New()

    End Sub
End Class
