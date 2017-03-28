Imports Microsoft.VisualBasic

Public Class IndividualFormMaster
    Private _BranchCode As String
    Public Property BranchCode() As String
        Get
            Return _BranchCode
        End Get
        Set(ByVal value As String)
            _BranchCode = value
        End Set
    End Property
    Private _EmpType As String
    Public Property EmpType() As String
        Get
            Return _EmpType
        End Get
        Set(ByVal value As String)
            _EmpType = value
        End Set
    End Property
    Private _SalaryGrade As String
    Public Property SalaryGrade() As String
        Get
            Return _SalaryGrade
        End Get
        Set(ByVal value As String)
            _SalaryGrade = value
        End Set
    End Property
    Private _ESINo As String
    Public Property ESINo() As String
        Get
            Return _ESINo
        End Get
        Set(ByVal value As String)
            _ESINo = value
        End Set
    End Property
    Private _VDA As String
    Public Property VDA() As String
        Get
            Return _VDA
        End Get
        Set(ByVal value As String)
            _VDA = value
        End Set
    End Property
    Private _BankId As Integer
    Public Property BankId() As Integer
        Get
            Return _BankId
        End Get
        Set(ByVal value As Integer)
            _BankId = value
        End Set
    End Property
    Private _DistrictCode As String
    Public Property DistrictCode() As String
        Get
            Return _DistrictCode
        End Get
        Set(ByVal value As String)
            _DistrictCode = value
        End Set
    End Property
    Private _Emp_Name As String
    Public Property Emp_Name() As String
        Get
            Return _Emp_Name
        End Get
        Set(ByVal value As String)
            _Emp_Name = value
        End Set
    End Property
   
    Private _Emp_Address As String
    Public Property Emp_Address() As String
        Get
            Return _Emp_Address
        End Get
        Set(ByVal value As String)
            _Emp_Address = value
        End Set
    End Property
    Private _Country As String
    Public Property Country() As String
        Get
            Return _Country
        End Get
        Set(ByVal value As String)
            _Country = value
        End Set
    End Property
    Private _ContactNo As String
    Public Property ContactNo() As String
        Get
            Return _ContactNo
        End Get
        Set(ByVal value As String)
            _ContactNo = value
        End Set
    End Property
    Private _LandlineNo As String
    Public Property LandlineNo() As String
        Get
            Return _LandlineNo
        End Get
        Set(ByVal value As String)
            _LandlineNo = value
        End Set
    End Property
    Private _DOB As DateTime
    Public Property DOB() As DateTime
        Get
            Return _DOB
        End Get
        Set(ByVal value As DateTime)
            _DOB = value
        End Set
    End Property
    Private _Emp_Code As String
    Public Property Emp_Code() As String
        Get
            Return _Emp_Code
        End Get
        Set(ByVal value As String)
            _Emp_Code = value
        End Set
    End Property
    Private _Emp_Id As Long
    Public Property Emp_Id() As Long
        Get
            Return _Emp_Id
        End Get
        Set(ByVal value As Long)
            _Emp_Id = value
        End Set
    End Property
    Private _BranchID As Long
    Public Property BranchID() As Long
        Get
            Return _BranchID
        End Get
        Set(ByVal value As Long)
            _BranchID = value
        End Set
    End Property
    Private _DeptID As Long
    Public Property DeptID() As Long
        Get
            Return _DeptID
        End Get
        Set(ByVal value As Long)
            _DeptID = value
        End Set
    End Property
    Private _Email As String
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property
    Private _DOJ As DateTime
    Public Property DOJ() As DateTime
        Get
            Return _DOJ
        End Get
        Set(ByVal value As DateTime)
            _DOJ = value
        End Set
    End Property
    Private _DOL As DateTime
    Public Property DOL() As DateTime
        Get
            Return _DOL
        End Get
        Set(ByVal value As DateTime)
            _DOL = value
        End Set
    End Property
    Private _DOR As DateTime
    Public Property DOR() As DateTime
        Get
            Return _DOR
        End Get
        Set(ByVal value As DateTime)
            _DOR = value
        End Set
    End Property
    Private _DOA As DateTime
    Public Property DOA() As DateTime
        Get
            Return _DOA
        End Get
        Set(ByVal value As DateTime)
            _DOA = value
        End Set
    End Property
    Private _BranchTypeCode As String
    Public Property BranchTypeCode() As String
        Get
            Return _BranchTypeCode
        End Get
        Set(ByVal value As String)
            _BranchTypeCode = value
        End Set
    End Property
    Private _Designation As String
    Public Property Designation() As String
        Get
            Return _Designation
        End Get
        Set(ByVal value As String)
            _Designation = value
        End Set
    End Property
    Private _ServicePeriod As String
    Public Property ServicePeriod() As String
        Get
            Return _ServicePeriod
        End Get
        Set(ByVal value As String)
            _ServicePeriod = value
        End Set
    End Property
    Private _Branch_Code As String
    Public Property Branch_Code() As String
        Get
            Return _Branch_Code
        End Get
        Set(ByVal value As String)
            _Branch_Code = value
        End Set
    End Property
    Private _Salary As Double
    Public Property Salary() As Double
        Get
            Return _Salary
        End Get
        Set(ByVal value As Double)
            _Salary = value
        End Set
    End Property
    Private _AccountNo As String
    Public Property AccountNo() As String
        Get
            Return _AccountNo
        End Get
        Set(ByVal value As String)
            _AccountNo = value
        End Set
    End Property
    Private _AgentTypeCode As Integer
    Public Property AgentTypeCode() As Integer
        Get
            Return _AgentTypeCode
        End Get
        Set(ByVal value As Integer)
            _AgentTypeCode = value
        End Set
    End Property
    Private _Photos As String
    Public Property Photos() As String
        Get
            Return _Photos
        End Get
        Set(ByVal value As String)
            _Photos = value
        End Set
    End Property
    Private _sex As String
    Public Property Sex() As String
        Get
            Return _sex
        End Get
        Set(ByVal value As String)
            _sex = value
        End Set
    End Property
    Private _EmploymentType As String
    Public Property EmploymentType() As String
        Get
            Return _EmploymentType
        End Get
        Set(ByVal value As String)
            _EmploymentType = value
        End Set
    End Property
    Private _EmpCode As String
    Public Property EmpCode() As String
        Get
            Return _EmpCode
        End Get
        Set(ByVal value As String)
            _EmpCode = value
        End Set
    End Property
    Private _UserCode As String
    Public Property UserCode() As String
        Get
            Return _UserCode
        End Get
        Set(ByVal value As String)
            _UserCode = value
        End Set
    End Property
    Private _Delegate1 As String
    Public Property Delegate1() As String
        Get
            Return _Delegate1
        End Get
        Set(ByVal value As String)
            _Delegate1 = value
        End Set
    End Property
    Private _Delegated As String
    Public Property Delegated() As String
        Get
            Return _Delegated
        End Get
        Set(ByVal value As String)
            _Delegated = value
        End Set
    End Property
    Private _FMEmpCode As String
    Public Property FMEmpCode() As String
        Get
            Return _FMEmpCode
        End Get
        Set(ByVal value As String)
            _FMEmpCode = value
        End Set
    End Property
    Private _RMEmpCode As String
    Public Property RMEmpCode() As String
        Get
            Return _RMEmpCode
        End Get
        Set(ByVal value As String)
            _RMEmpCode = value
        End Set
    End Property
    Private _HRAEmpCode As String
    Public Property HRAEmpCode() As String
        Get
            Return _HRAEmpCode
        End Get
        Set(ByVal value As String)
            _HRAEmpCode = value
        End Set
    End Property
    Private _PANNO As String
    Public Property PANNO() As String
        Get
            Return _PANNO
        End Get
        Set(ByVal value As String)
            _PANNO = value
        End Set
    End Property
    Private _Qualification As String
    Public Property Qualification() As String
        Get
            Return _Qualification
        End Get
        Set(ByVal value As String)
            _Qualification = value
        End Set
    End Property
    Private _EmpCategory As String
    Public Property EmpCategory() As String
        Get
            Return _EmpCategory
        End Get
        Set(ByVal value As String)
            _EmpCategory = value
        End Set
    End Property
    Private _dpt_Id As Long
    Public Property dpt_Id() As Long
        Get
            Return _dpt_Id
        End Get
        Set(ByVal value As Long)
            _dpt_Id = value
        End Set
    End Property

    Private _NICNO As String
    Public Property NICNO() As String
        Get
            Return _NICNo
        End Get
        Set(ByVal value As String)
            _NICNo = value
        End Set
    End Property
    Private _Corres_Address As String
    Public Property Corres_Address() As String
        Get
            Return _Corres_Address
        End Get
        Set(ByVal value As String)
            _Corres_Address = value
        End Set
    End Property
    Private _Hostel As String
    Public Property Hostel() As String
        Get
            Return _Hostel
        End Get
        Set(ByVal value As String)
            _Hostel = value
        End Set
    End Property
    Private _Transport As String
    Public Property Transport() As String
        Get
            Return _Transport
        End Get
        Set(ByVal value As String)
            _Transport = value
        End Set
    End Property
    Private _FatherName As String
    Public Property FatherName() As String
        Get
            Return _FatherName
        End Get
        Set(ByVal value As String)
            _FatherName = value
        End Set
    End Property
    Private _MotherName As String
    Public Property MotherName() As String
        Get
            Return _MotherName
        End Get
        Set(ByVal value As String)
            _MotherName = value
        End Set
    End Property
    Private _SpouseName As String
    Public Property SpouseName() As String
        Get
            Return _SpouseName
        End Get
        Set(ByVal value As String)
            _SpouseName = value
        End Set
    End Property
    Private _NameInPassport As String
    Public Property NameInPassport() As String
        Get
            Return _NameInPassport
        End Get
        Set(ByVal value As String)
            _NameInPassport = value
        End Set
    End Property
    Private _PlaceofIssue As String
    Public Property PlaceofIssue() As String
        Get
            Return _PlaceofIssue
        End Get
        Set(ByVal value As String)
            _PlaceofIssue = value
        End Set
    End Property
    Private _PassportNo As String
    Public Property PassportNo() As String
        Get
            Return _PassportNo
        End Get
        Set(ByVal value As String)
            _PassportNo = value
        End Set
    End Property
    Private _PFNo As String
    Public Property PFNo() As String
        Get
            Return _PFNo
        End Get
        Set(ByVal value As String)
            _PFNo = value
        End Set
    End Property
    Private _PassportExpiryDate As Date
    Public Property PassportExpiryDate() As Date
        Get
            Return _PassportExpiryDate
        End Get
        Set(ByVal value As Date)
            _PassportExpiryDate = value
        End Set
    End Property
    Private _PassportIssueDate As Date
    Public Property PassportIssueDate() As Date
        Get
            Return _PassportIssueDate
        End Get
        Set(ByVal value As Date)
            _PassportIssueDate = value
        End Set
    End Property
    Private _VisaIssueDate As Date
    Public Property VisaIssueDate() As Date
        Get
            Return _VisaIssueDate
        End Get
        Set(ByVal value As Date)
            _VisaIssueDate = value
        End Set
    End Property
    Private _VisaExpiryDate As Date
    Public Property VisaExpiryDate() As Date
        Get
            Return _VisaExpiryDate
        End Get
        Set(ByVal value As Date)
            _VisaExpiryDate = value
        End Set
    End Property
    Private _FRROExpDate As Date
    Public Property FRROExpDate() As Date
        Get
            Return _FRROExpDate
        End Get
        Set(ByVal value As Date)
            _FRROExpDate = value
        End Set
    End Property
    Private _VisaNo As String
    Public Property VisaNo() As String
        Get
            Return _VisaNo
        End Get
        Set(ByVal value As String)
            _VisaNo = value
        End Set
    End Property
    Private _Nationality As String
    Public Property Nationality() As String
        Get
            Return _Nationality
        End Get
        Set(ByVal value As String)
            _Nationality = value
        End Set
    End Property
    Private _Ethnicity As String
    Public Property Ethnicity() As String
        Get
            Return _Ethnicity
        End Get
        Set(ByVal value As String)
            _Ethnicity = value
        End Set
    End Property
    Private _Religion As String
    Public Property Religion() As String
        Get
            Return _Religion
        End Get
        Set(ByVal value As String)
            _Religion = value
        End Set
    End Property
    Private _CivilStates As String
    Public Property CivilStates() As String
        Get
            Return _CivilStates
        End Get
        Set(ByVal value As String)
            _CivilStates = value
        End Set
    End Property
    Private _OtherName As String
    Public Property OtherName() As String
        Get
            Return _OtherName
        End Get
        Set(ByVal value As String)
            _OtherName = value
        End Set
    End Property
    Private _Initial As String
    Public Property Initial() As String
        Get
            Return _Initial

        End Get

        Set(ByVal value As String)
            _Initial = value
        End Set
    End Property
    Private _PersonalFileNo As String
    Public Property PersonalFileNo() As String
        Get
            Return _PersonalFileNo
        End Get
        Set(ByVal value As String)
            _PersonalFileNo = value
        End Set
    End Property

    Private _DOP As DateTime
    Public Property DOP() As DateTime
        Get
            Return _DOP
        End Get
        Set(ByVal value As DateTime)
            _DOP = value
        End Set
    End Property
    Private _Nominee As String
    Public Property Nominee() As String
        Get
            Return _Nominee
        End Get
        Set(ByVal value As String)
            _Nominee = value
        End Set
    End Property
    Private _Race As String
    Public Property Race() As String
        Get
            Return _Race
        End Get
        Set(ByVal value As String)
            _Race = value
        End Set
    End Property
    Private _ETF As String
    Public Property ETF() As String
        Get
            Return _ETF
        End Get
        Set(ByVal value As String)
            _ETF = value
        End Set
    End Property
    Private _Distric As String
    Public Property Distric() As String
        Get
            Return _Distric
        End Get
        Set(ByVal value As String)
            _Distric = value
        End Set
    End Property
    Private _City As String
    Public Property City() As String
        Get
            Return _City
        End Get
        Set(ByVal value As String)
            _City = value
        End Set
    End Property
    Private _PinCode As String
    Public Property PinCode() As String
        Get
            Return _PinCode
        End Get
        Set(ByVal value As String)
            _PinCode = value
        End Set
    End Property
    Private _StateName As Integer
    Public Property StateName() As Integer
        Get
            Return _StateName
        End Get
        Set(ByVal value As Integer)
            _StateName = value
        End Set
    End Property
    Private _Title As String
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
        End Set
    End Property
    Private _Increment As String
    Public Property Increment() As String
        Get
            Return _Increment
        End Get
        Set(ByVal value As String)
            _Increment = value
        End Set
    End Property
    Private _Gratuity As String
    Public Property Gratuity() As String
        Get
            Return _Gratuity
        End Get
        Set(ByVal value As String)
            _Gratuity = value
        End Set
    End Property
    Private _Pension As String
    Public Property Pension() As String
        Get
            Return _Pension
        End Get
        Set(ByVal value As String)
            _Pension = value
        End Set
    End Property
    Private _Uniform As String
    Public Property Uniform() As String
        Get
            Return _Uniform
        End Get
        Set(ByVal value As String)
            _Uniform = value
        End Set
    End Property
    Private _Promotion As String
    Public Property Promotion() As String
        Get
            Return _Promotion
        End Get
        Set(ByVal value As String)
            _Promotion = value
        End Set
    End Property
    Private _Resignation As String
    Public Property Resignation() As String
        Get
            Return _Resignation
        End Get
        Set(ByVal value As String)
            _Resignation = value
        End Set
    End Property
    Private _Settelement As String
    Public Property Settelement() As String
        Get
            Return _Settelement
        End Get
        Set(ByVal value As String)
            _Settelement = value
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
    Private _SalaryRevDate As DateTime
    Public Property SalaryRevDate() As DateTime
        Get
            Return _SalaryRevDate
        End Get
        Set(ByVal value As DateTime)
            _SalaryRevDate = value
        End Set
    End Property
    Private _ModeOfpayement As Integer
    Public Property ModeOfpayement() As Integer
        Get
            Return _ModeOfpayement
        End Get
        Set(ByVal value As Integer)
            _ModeOfpayement = value
        End Set
    End Property
    Private _PFACCNO As String
    Public Property PFACCNO() As String
        Get
            Return _PFACCNO
        End Get
        Set(ByVal value As String)
            _PFACCNO = value
        End Set
    End Property
    Private _MiddleName As String
    Public Property MiddleName() As String
        Get
            Return _MiddleName
        End Get
        Set(ByVal value As String)
            _MiddleName = value
        End Set
    End Property
    Private _StopSalary As String
    Public Property StopSalary() As String
        Get
            Return _StopSalary
        End Get
        Set(ByVal value As String)
            _StopSalary = value
        End Set
    End Property
    Private _StopSalaryReason As String
    Public Property StopSalaryReason() As String
        Get
            Return _StopSalaryReason
        End Get
        Set(ByVal value As String)
            _StopSalaryReason = value
        End Set
    End Property
    Private _StopSalaryDate As DateTime
    Public Property StopSalaryDate() As DateTime
        Get
            Return _StopSalaryDate
        End Get
        Set(ByVal value As DateTime)
            _StopSalaryDate = value
        End Set
    End Property
    Private _Remark As String
    Public Property Remark() As String
        Get
            Return _Remark
        End Get
        Set(ByVal value As String)
            _Remark = value
        End Set
    End Property
    Public Sub New()

    End Sub
End Class
