Imports Microsoft.VisualBasic

Public Class ELCompanyRegister

    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _id1 As String
    Public Property Id1() As String
        Get
            Return _id1
        End Get
        Set(ByVal value As String)
            _id1 = value
        End Set
    End Property
    Private _CompanyRegName As String
    Public Property CompanyRegName() As String
        Get
            Return _CompanyRegName
        End Get
        Set(ByVal value As String)
            _CompanyRegName = value
        End Set
    End Property
   

    Private _CompanyRegCode As String
    Public Property CompanyRegCode() As String
        Get
            Return _CompanyRegCode
        End Get
        Set(ByVal value As String)
            _CompanyRegCode = value
        End Set
    End Property
    Private _CompanyRegAddress As String
    Public Property CompanyRegAddress() As String
        Get
            Return _CompanyRegAddress
        End Get
        Set(ByVal value As String)
            _CompanyRegAddress = value
        End Set
    End Property
    Private _CompanyRegLocation As String
    Public Property CompanyRegLocation() As String
        Get
            Return _CompanyRegLocation
        End Get
        Set(ByVal value As String)
            _CompanyRegLocation = value
        End Set
    End Property
    Private _CompanyRegState As Integer
    Public Property CompanyRegState() As Integer
        Get
            Return _CompanyRegState
        End Get
        Set(ByVal value As Integer)
            _CompanyRegState = value
        End Set
    End Property
    Private _CompanyRegPostalCode As Integer
    Public Property CompanyRegPostalCode() As Integer
        Get
            Return _CompanyRegPostalCode
        End Get
        Set(ByVal value As Integer)
            _CompanyRegPostalCode = value
        End Set
    End Property
    Private _CompanyRegDistrict As String
    Public Property CompanyRegDistrict() As String
        Get
            Return _CompanyRegDistrict
        End Get
        Set(ByVal value As String)
            _CompanyRegDistrict = value
        End Set
    End Property
    Private _CompanyRegActivites As String
    Public Property CompanyRegActivites() As String
        Get
            Return _CompanyRegActivites
        End Get
        Set(ByVal value As String)
            _CompanyRegActivites = value
        End Set
    End Property
    Private _CompanyRegDwebDetails As String
    Public Property CompanyRegDwebDetails() As String
        Get
            Return _CompanyRegDwebDetails
        End Get
        Set(ByVal value As String)
            _CompanyRegDwebDetails = value
        End Set
    End Property
    Private _CompanyRegNoOfEmployee As Integer
    Public Property CompanyRegNoOfEmployee() As Integer
        Get
            Return _CompanyRegNoOfEmployee
        End Get
        Set(ByVal value As Integer)
            _CompanyRegNoOfEmployee = value
        End Set
    End Property
    Private _CompanyRegNoOfFresher As Integer
    Public Property CompanyRegNoOfFresher() As Integer
        Get
            Return _CompanyRegNoOfFresher
        End Get
        Set(ByVal value As Integer)
            _CompanyRegNoOfFresher = value
        End Set
    End Property
    Private _CompanyRegCeoName As String
    Public Property CompanyRegCeoName() As String
        Get
            Return _CompanyRegCeoName
        End Get
        Set(ByVal value As String)
            _CompanyRegCeoName = value
        End Set
    End Property

    Private _CompanyRegCeoEmail As String
    Public Property CompanyRegCeoEmail() As String
        Get
            Return _CompanyRegCeoEmail
        End Get
        Set(ByVal value As String)
            _CompanyRegCeoEmail = value
        End Set
    End Property
    Private _CompanyRegCeoMobile As String
    Public Property CompanyRegCeoMobile() As String
        Get
            Return _CompanyRegCeoMobile
        End Get
        Set(ByVal value As String)
            _CompanyRegCeoMobile = value
        End Set
    End Property
    Private _CompanyRegCeoLandline As String
    Public Property CompanyRegCeoLandline() As String
        Get
            Return _CompanyRegCeoLandline
        End Get
        Set(ByVal value As String)
            _CompanyRegCeoLandline = value
        End Set
    End Property
    Private _MKDCompanyName As String
    Public Property MKDCompanyName() As String
        Get
            Return _MKDCompanyName
        End Get
        Set(ByVal value As String)
            _MKDCompanyName = value
        End Set
    End Property
    Private _MKDName As String
    Public Property MKDName() As String
        Get
            Return _MKDName
        End Get
        Set(ByVal value As String)
            _MKDName = value
        End Set
    End Property
    Private _KDMDesignation As String
    Public Property KDMDesignation() As String
        Get
            Return _KDMDesignation
        End Get
        Set(ByVal value As String)
            _KDMDesignation = value
        End Set
    End Property
    Private _KDMLandLine As String
    Public Property KDMLandLine() As String
        Get
            Return _KDMLandLine
        End Get
        Set(ByVal value As String)
            _KDMLandLine = value
        End Set
    End Property
    Private _KDMMobile As String
    Public Property KDMMobile() As String
        Get
            Return _KDMMobile
        End Get
        Set(ByVal value As String)
            _KDMMobile = value
        End Set
    End Property
    Private _KDMEmail As String
    Public Property KDMEmail() As String
        Get
            Return _KDMEmail
        End Get
        Set(ByVal value As String)
            _KDMEmail = value
        End Set
    End Property
    Private _CompanySName As String
    Public Property CompanySName() As String
        Get
            Return _CompanySName
        End Get
        Set(ByVal value As String)
            _CompanySName = value
        End Set
    End Property
    Private _CompanySGross As Double
    Public Property CompanySGross() As Double
        Get
            Return _CompanySGross
        End Get
        Set(ByVal value As Double)
            _CompanySGross = value
        End Set
    End Property
    Private _CompanySCTC As Double
    Public Property CompanySCTC() As Double
        Get
            Return _CompanySCTC
        End Get
        Set(ByVal value As Double)
            _CompanySCTC = value
        End Set

    End Property
    Private _SalaryStrMedical As String
    Public Property SalaryStrMedical() As String
        Get
            Return _SalaryStrMedical
        End Get
        Set(ByVal value As String)
            _SalaryStrMedical = value
        End Set
    End Property
    Private _SalaryStrMInsurance As String
    Public Property SalaryStrMInsurance() As String
        Get
            Return _SalaryStrMInsurance
        End Get
        Set(ByVal value As String)
            _SalaryStrMInsurance = value
        End Set
    End Property
    Private _SalaryStrMPF As String
    Public Property SalaryStrMPF() As String
        Get
            Return _SalaryStrMPF
        End Get
        Set(ByVal value As String)
            _SalaryStrMPF = value
        End Set
    End Property
    Private _SalaryStrLTA As String
    Public Property SalaryStrLTA() As String
        Get
            Return _SalaryStrLTA
        End Get
        Set(ByVal value As String)
            _SalaryStrLTA = value
        End Set
    End Property
    Private _SalaryStrSFood As String
    Public Property SalaryStrSFood() As String
        Get
            Return _SalaryStrSFood
        End Get
        Set(ByVal value As String)
            _SalaryStrSFood = value
        End Set
    End Property
    Private _SalaryStrMTransport As String
    Public Property SalaryStrMTransport() As String
        Get
            Return _SalaryStrMTransport
        End Get
        Set(ByVal value As String)
            _SalaryStrMTransport = value
        End Set
    End Property
    Private _SalaryStrAssistance As String
    Public Property SalaryStrAssistance() As String
        Get
            Return _SalaryStrAssistance
        End Get
        Set(ByVal value As String)
            _SalaryStrAssistance = value
        End Set
    End Property
    Private _SalaryStrAccommodation As String
    Public Property SalaryStrAccommodation() As String
        Get
            Return _SalaryStrAccommodation
        End Get
        Set(ByVal value As String)
            _SalaryStrAccommodation = value
        End Set
    End Property
End Class
