Imports Microsoft.VisualBasic

Public Class Student
    Private _PassportIssueDate As Date
    Public Property PassportIssueDate() As Date
        Get
            Return _PassportIssueDate
        End Get
        Set(ByVal value As Date)
            _PassportIssueDate = value
        End Set
    End Property
    Private _indexNo As String
    Public Property indexNo() As String
        Get
            Return _indexNo
        End Get
        Set(ByVal value As String)
            _indexNo = value
        End Set
    End Property
    Private _ethnicity As String
    Public Property ethnicity() As String
        Get
            Return _ethnicity
        End Get
        Set(ByVal value As String)
            _ethnicity = value
        End Set
    End Property
    Private _GuardianRelate As String
    Public Property GuardianRelate() As String
        Get
            Return _GuardianRelate
        End Get
        Set(ByVal value As String)
            _GuardianRelate = value
        End Set
    End Property
    Private _coursebranchcode As String
    Public Property coursebranchcode() As String
        Get
            Return _coursebranchcode
        End Get
        Set(ByVal value As String)
            _coursebranchcode = value
        End Set
    End Property
    Private _VisaExpDate As Date
    Public Property VisaExpDate() As Date
        Get
            Return _VisaExpDate
        End Get
        Set(ByVal value As Date)
            _VisaExpDate = value
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
    Private _VisaNo As String
    Public Property VisaNo() As String
        Get
            Return _VisaNo
        End Get
        Set(ByVal value As String)
            _VisaNo = value
        End Set
    End Property
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
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
    Private _PassportName As String
    Public Property PassportName() As String
        Get
            Return _PassportName
        End Get
        Set(ByVal value As String)
            _PassportName = value
        End Set
    End Property
    Private _NicNo As String
    Public Property NicNo() As String
        Get
            Return _NicNo
        End Get
        Set(ByVal value As String)
            _NicNo = value
        End Set
    End Property
    Private _Passportissue As String
    Public Property Passportissue() As String
        Get
            Return _Passportissue
        End Get
        Set(ByVal value As String)
            _Passportissue = value
        End Set
    End Property
    Private _TCNo As String
    Public Property TCNo() As String
        Get
            Return _TCNo
        End Get
        Set(ByVal value As String)
            _TCNo = value
        End Set
    End Property
    Private _MotherTongue As String
    Public Property MotherTongue() As String
        Get
            Return _MotherTongue
        End Get
        Set(ByVal value As String)
            _MotherTongue = value
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
    Private _PassportExpirydate As Date
    Public Property PassportExpirydate() As Date
        Get
            Return _PassportExpirydate
        End Get
        Set(ByVal value As Date)
            _PassportExpirydate = value
        End Set
    End Property
    Private _applicationNo As String
    Public Property ApplicationNo() As String
        Get
            Return _applicationNo
        End Get
        Set(ByVal value As String)
            _applicationNo = value
        End Set
    End Property
    Private _slNo As Int16
    Public Property SLNo() As Int16
        Get
            Return _slNo
        End Get
        Set(ByVal value As Int16)
            _slNo = value
        End Set
    End Property
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Private _Fullname As String
    Public Property Fullname() As String
        Get
            Return _Fullname
        End Get
        Set(ByVal value As String)
            _Fullname = value
        End Set
    End Property
    Private _code As String
    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property
    Private _SecondUSN As String
    Public Property SecondUSN() As String
        Get
            Return _SecondUSN
        End Get
        Set(ByVal value As String)
            _SecondUSN = value
        End Set
    End Property
    Private _eno As Integer
    Public Property Eno() As Integer
        Get
            Return _eno
        End Get
        Set(ByVal value As Integer)
            _eno = value
        End Set
    End Property
    Private _dob As Date
    Public Property DateOfBirth() As Date
        Get
            Return _dob
        End Get
        Set(ByVal value As Date)
            _dob = value
        End Set
    End Property
    Private _fname As String
    Public Property FatherName() As String
        Get
            Return _fname
        End Get
        Set(ByVal value As String)
            _fname = value
        End Set
    End Property
    Private _foccupation As String
    Public Property FatherOccupation() As String
        Get
            Return _foccupation
        End Get
        Set(ByVal value As String)
            _foccupation = value
        End Set
    End Property
    Private _income As Double
    Public Property AnnualIncome() As Double
        Get
            Return _income
        End Get
        Set(ByVal value As Double)
            _income = value
        End Set
    End Property
    Private _paddr As String
    Public Property PermanentAddress() As String
        Get
            Return _paddr
        End Get
        Set(ByVal value As String)
            _paddr = value
        End Set
    End Property
    Private _taddrPeriod As String
    Public Property TemporaryAddressP() As String
        Get
            Return _taddrPeriod
        End Get
        Set(ByVal value As String)
            _taddrPeriod = value
        End Set
    End Property
    Private _taddr As String
    Public Property TemporaryAddress() As String
        Get
            Return _taddr
        End Get
        Set(ByVal value As String)
            _taddr = value
        End Set
    End Property
    Private _contactno As String
    Public Property ContactNumber() As String
        Get
            Return _contactno
        End Get
        Set(ByVal value As String)
            _contactno = value
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
    Private _category As String
    Public Property Category() As String
        Get
            Return _category
        End Get
        Set(ByVal value As String)
            _category = value
        End Set
    End Property
    Private _Alcategory As String
    Public Property Alcategory() As String
        Get
            Return _Alcategory
        End Get
        Set(ByVal value As String)
            _Alcategory = value
        End Set
    End Property
    Private _BirthPlace As String
    Public Property BirthPlace() As String
        Get
            Return _BirthPlace
        End Get
        Set(ByVal value As String)
            _BirthPlace = value
        End Set
    End Property
    Private _courseid As Long
    Public Property CourseId() As Long
        Get
            Return _courseid
        End Get
        Set(ByVal value As Long)
            _courseid = value
        End Set
    End Property
    Private _branchid As Long
    Public Property BranchId() As Long
        Get
            Return _branchid
        End Get
        Set(ByVal value As Long)
            _branchid = value
        End Set
    End Property
    Private _instituteid As Long
    Public Property InstituteId() As Long
        Get
            Return _instituteid
        End Get
        Set(ByVal value As Long)
            _instituteid = value
        End Set
    End Property
    Private _sponsorid As Long
    Public Property SponsorId() As Long
        Get
            Return _sponsorid
        End Get
        Set(ByVal value As Long)
            _sponsorid = value
        End Set
    End Property
    Private _admissiondate As Date
    Public Property AdmissionDate() As Date
        Get
            Return _admissiondate
        End Get
        Set(ByVal value As Date)
            _admissiondate = value
        End Set
    End Property
    Private _batchNo As Integer
    Public Property BatchNo() As Integer
        Get
            Return _batchNo
        End Get
        Set(ByVal value As Integer)
            _batchNo = value
        End Set
    End Property
    Private _caste As String
    Public Property Caste() As String
        Get
            Return _caste
        End Get
        Set(ByVal value As String)
            _caste = value
        End Set
    End Property
    Private _prospno As String
    Public Property ProspectusNo() As String
        Get
            Return _prospno
        End Get
        Set(ByVal value As String)
            _prospno = value
        End Set
    End Property
    Private _age As Int32
    Public Property Age() As Int32
        Get
            Return _age
        End Get
        Set(ByVal value As Int32)
            _age = value
        End Set
    End Property
    Private _title As String
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property
    Private _A_year As Integer

    Public Property A_year() As Integer
        Get
            Return _A_year
        End Get
        Set(ByVal value As Integer)
            _A_year = value
        End Set
    End Property
    Private _photo As String

    Public Property Photo() As String
        Get
            Return _photo
        End Get
        Set(ByVal value As String)
            _photo = value
        End Set
    End Property
    Private _email As String
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property
    Private _ddno As String
    Public Property DDNo() As String
        Get
            Return _ddno
        End Get
        Set(ByVal value As String)
            _ddno = value
        End Set
    End Property
    Private _receiptno As String
    Public Property ReceiptNo() As String
        Get
            Return _receiptno
        End Get
        Set(ByVal value As String)
            _receiptno = value
        End Set
    End Property
    Private _district As String
    Public Property District() As String
        Get
            Return _district
        End Get
        Set(ByVal value As String)
            _district = value
        End Set
    End Property

    Private _admissiontype As String
    Public Property AdmissionType() As String
        Get
            Return _admissiontype
        End Get
        Set(ByVal value As String)
            _admissiontype = value
        End Set
    End Property
    Private _frombranch As Date
    Public Property FromBranch() As Date
        Get
            Return _frombranch
        End Get
        Set(ByVal value As Date)
            _frombranch = value
        End Set
    End Property
    Private _city As String
    Public Property City() As String
        Get
            Return _city
        End Get
        Set(ByVal value As String)
            _city = value
        End Set
    End Property
    Private _pincode As String
    Public Property PinCode() As String
        Get
            Return _pincode
        End Get
        Set(ByVal value As String)
            _pincode = value
        End Set
    End Property
    Private _distance As String
    Public Property Distance() As Double
        Get
            Return _distance

        End Get
        Set(ByVal value As Double)
            _distance = value
        End Set
    End Property
    Private _state As Int32
    Public Property State() As Int32
        Get
            Return _state
        End Get
        Set(ByVal value As Int32)
            _state = value
        End Set
    End Property
    Private _country As String
    Public Property Country() As String
        Get
            Return _country
        End Get
        Set(ByVal value As String)
            _country = value
        End Set
    End Property
    Private _uniquecode As String
    Public Property UniqueCode() As String
        Get
            Return _uniquecode
        End Get
        Set(ByVal value As String)
            _uniquecode = value
        End Set
    End Property
    Private _rollover As Int16
    Public Property RollOver() As Int16
        Get
            Return _rollover
        End Get
        Set(ByVal value As Int16)
            value = _rollover
        End Set
    End Property
    Private _session As String
    Public Property Session() As String
        Get
            Return _session
        End Get
        Set(ByVal value As String)
            _session = value
        End Set
    End Property
    Private _feecollected As String
    Public Property Feecollected() As String
        Get
            Return _feecollected
        End Get
        Set(ByVal value As String)
            _feecollected = value
        End Set
    End Property
    Private _Houseid As Int16
    Public Property HouseId() As Int16
        Get
            Return _Houseid
        End Get
        Set(ByVal value As Int16)
            _Houseid = value
        End Set
    End Property
    Private _Housename As String
    Public Property HouseName() As String
        Get
            Return _Housename
        End Get
        Set(ByVal value As String)
            _Housename = value
        End Set
    End Property

    Private _LeavingDate As Date
    Public Property LeavingDate() As Date
        Get
            Return _LeavingDate
        End Get
        Set(ByVal value As Date)
            _LeavingDate = value
        End Set
    End Property
    Private _StdEmail As String
    Public Property StdEmail() As String
        Get
            Return _StdEmail
        End Get
        Set(ByVal value As String)
            _StdEmail = value
        End Set
    End Property
    Private _FatherEmail As String
    Public Property FatherEmail() As String
        Get
            Return _FatherEmail
        End Get
        Set(ByVal value As String)
            _FatherEmail = value
        End Set
    End Property
    Private _FatherContact As String
    Public Property FatherContact() As String
        Get
            Return _FatherContact
        End Get
        Set(ByVal value As String)
            _FatherContact = value
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
    Private _MotherName As String
    Public Property MotherName() As String
        Get
            Return _MotherName
        End Get
        Set(ByVal value As String)
            _MotherName = value
        End Set
    End Property
    Private _StdContact As String
    Public Property StdContact() As String
        Get
            Return _StdContact
        End Get
        Set(ByVal value As String)
            _StdContact = value
        End Set
    End Property
    Private _MentorId As Integer
    Public Property MentorId() As Integer
        Get
            Return _MentorId
        End Get
        Set(ByVal value As Integer)
            _MentorId = value
        End Set
    End Property
    Private _DOBCertificate As String
    Public Property DOBCertificate() As String
        Get
            Return _DOBCertificate
        End Get
        Set(ByVal value As String)
            _DOBCertificate = value
        End Set
    End Property
    Private _TC As String
    Public Property TC() As String
        Get
            Return _TC
        End Get
        Set(ByVal value As String)
            _TC = value
        End Set
    End Property
    Private _BD As String
    Public Property BD() As String
        Get
            Return _BD
        End Get
        Set(ByVal value As String)
            _BD = value
        End Set
    End Property
    Private _TEN As String
    Public Property TEN() As String
        Get
            Return _TEN
        End Get
        Set(ByVal value As String)
            _TEN = value
        End Set
    End Property
    Private _MigrationCertificate As String
    Public Property MigrationCertificate() As String
        Get
            Return _MigrationCertificate
        End Get
        Set(ByVal value As String)
            _MigrationCertificate = value
        End Set
    End Property
    Private _MasterDegree As String
    Public Property MasterDegree() As String
        Get
            Return _MasterDegree
        End Get
        Set(ByVal value As String)
            _MasterDegree = value
        End Set
    End Property
    Private _twelve As String
    Public Property twelve() As String
        Get
            Return _twelve
        End Get
        Set(ByVal value As String)
            _twelve = value
        End Set
    End Property
    Private _IC As String
    Public Property IC() As String
        Get
            Return _IC
        End Get
        Set(ByVal value As String)
            _IC = value
        End Set
    End Property
    Private _SLC As String
    Public Property SLC() As String
        Get
            Return _SLC
        End Get
        Set(ByVal value As String)
            _SLC = value
        End Set
    End Property
    Private _LOS As String
    Public Property LOS() As String
        Get
            Return _LOS
        End Get
        Set(ByVal value As String)
            _LOS = value
        End Set
    End Property
    Private _AOR As String
    Public Property AOR() As String
        Get
            Return _AOR
        End Get
        Set(ByVal value As String)
            _AOR = value
        End Set
    End Property
    Private _AOU As String
    Public Property AOU() As String
        Get
            Return _AOU
        End Get
        Set(ByVal value As String)
            _AOU = value
        End Set
    End Property
    Private _CPhoto As String
    Public Property CPhoto() As String
        Get
            Return _CPhoto
        End Get
        Set(ByVal value As String)
            _CPhoto = value
        End Set
    End Property
    '''''''''''''''''''''''''''''''''''''
    '@FatherHomeContact varchar(50),
    '@MontherHomeContact varchar(50),
    '@FatherBizOffice varchar(50),
    '@MotherBizOffice varchar(50),
    '@FatherQualification varchar(50),
    '@MotherQualification varchar(50),
    '@Religion varchar(250),
    '@MotherOccupation varchar(100)	
    '''''''''''''''''''''''''''''''''''''
    Private _FatherQualification As String
    Public Property FatherQualification() As String
        Get
            Return _FatherQualification
        End Get
        Set(ByVal value As String)
            _FatherQualification = value
        End Set
    End Property
    Private _MotherMail As String
    Public Property MotherMail() As String
        Get
            Return _MotherMail
        End Get
        Set(ByVal value As String)
            _MotherMail = value
        End Set
    End Property
    Private _FatherMail As String
    Public Property FatherMail() As String
        Get
            Return _FatherMail
        End Get
        Set(ByVal value As String)
            _FatherMail = value
        End Set
    End Property
    Private _MotherSMS As String
    Public Property MotherSMS() As String
        Get
            Return _MotherSMS
        End Get
        Set(ByVal value As String)
            _MotherSMS = value
        End Set
    End Property
    Private _FatherSMS As String
    Public Property FatherSMS() As String
        Get
            Return _FatherSMS
        End Get
        Set(ByVal value As String)
            _FatherSMS = value
        End Set
    End Property
    Private _MotherQualification As String
    Public Property MotherQualification() As String
        Get
            Return _MotherQualification
        End Get
        Set(ByVal value As String)
            _MotherQualification = value
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
    Private _MotherOccupation As String
    Public Property MotherOccupation() As String
        Get
            Return _MotherOccupation
        End Get
        Set(ByVal value As String)
            _MotherOccupation = value
        End Set
    End Property
    Private _FatherHomeContact As String
    Public Property FatherHomeContact() As String
        Get
            Return _FatherHomeContact
        End Get
        Set(ByVal value As String)
            _FatherHomeContact = value
        End Set
    End Property
    Private _MontherHomeContact As String
    Public Property MontherHomeContact() As String
        Get
            Return _MontherHomeContact
        End Get
        Set(ByVal value As String)
            _MontherHomeContact = value
        End Set
    End Property
    Private _FatherBizOffice As String
    Public Property FatherBizOffice() As String
        Get
            Return _FatherBizOffice
        End Get
        Set(ByVal value As String)
            _FatherBizOffice = value
        End Set
    End Property
    Private _MotherBizOffice As String
    Public Property MotherBizOffice() As String
        Get
            Return _MotherBizOffice
        End Get
        Set(ByVal value As String)
            _MotherBizOffice = value
        End Set
    End Property
    Private _LastName As String
    Public Property LastName() As String
        Get
            Return _LastName
        End Get
        Set(ByVal value As String)
            _LastName = value
        End Set
    End Property
    Private _MName As String
    Public Property MName() As String
        Get
            Return _MName
        End Get
        Set(ByVal value As String)
            _MName = value
        End Set
    End Property
    Private _Citizenship As String
    Public Property Citizenship() As String
        Get
            Return _Citizenship
        End Get
        Set(ByVal value As String)
            _Citizenship = value
        End Set
    End Property
    Private _GDName As String
    Public Property GDName() As String
        Get
            Return _GDName
        End Get
        Set(ByVal value As String)
            _GDName = value
        End Set
    End Property
    Private _GDEmailID As String
    Public Property GDEmailID() As String
        Get
            Return _GDEmailID
        End Get
        Set(ByVal value As String)
            _GDEmailID = value
        End Set
    End Property
    Private _GDContactNo As String
    Public Property GDContactNo() As String
        Get
            Return _GDContactNo
        End Get
        Set(ByVal value As String)
            _GDContactNo = value
        End Set
    End Property
    Private _GDOccupation As String
    Public Property GDOccupation() As String
        Get
            Return _GDOccupation
        End Get
        Set(ByVal value As String)
            _GDOccupation = value
        End Set
    End Property
    Public Sub New()
    End Sub
End Class
