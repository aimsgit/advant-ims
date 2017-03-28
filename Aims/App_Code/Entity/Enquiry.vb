Imports Microsoft.VisualBasic

Public Class Enquiry
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _branchid As String
    Public Property Branchid() As String
        Get
            Return _branchid
        End Get
        Set(ByVal value As string)
            _branchid = value
        End Set
    End Property
    Private _edate As Date
    Public Property EDate() As Date
        Get
            Return _edate
        End Get
        Set(ByVal value As Date)
            _edate = value
        End Set
    End Property
    Private _DOB As Date
    Public Property DOB() As Date
        Get
            Return _DOB
        End Get
        Set(ByVal value As Date)
            _DOB = value
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
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Private _address As String
    Public Property Address() As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
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
    Private _phone As String
    Public Property Phone() As String
        Get
            Return _phone
        End Get
        Set(ByVal value As String)
            _phone = value
        End Set
    End Property
    Private _mobile As String
    Public Property Mobile() As String
        Get
            Return _mobile
        End Get
        Set(ByVal value As String)
            _mobile = value
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
    Private _qualification As String
    Public Property Qualification() As String
        Get
            Return _qualification
        End Get
        Set(ByVal value As String)
            _qualification = value
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
    Private _erelates As String
    Public Property ERelates() As String
        Get
            Return _erelates
        End Get
        Set(ByVal value As String)
            _erelates = value
        End Set
    End Property
    Private _coursetype As Int32
    Public Property CourseType() As Int32
        Get
            Return _coursetype
        End Get
        Set(ByVal value As Int32)
            _coursetype = value
        End Set
    End Property
    Private _course As Int32
    Public Property Course() As Int32
        Get
            Return _course
        End Get
        Set(ByVal value As Int32)
            _course = value
        End Set
    End Property
    Private _yenquiry As String
    Public Property YEnquiry() As String
        Get
            Return _yenquiry
        End Get
        Set(ByVal value As String)
            _yenquiry = value
        End Set
    End Property
    Private _source As Integer
    Public Property Source() As Integer
        Get
            Return _source
        End Get
        Set(ByVal value As Integer)
            _source = value
        End Set
    End Property
    Private _institute As Int32
    Public Property Institute() As Int32
        Get
            Return _institute
        End Get
        Set(ByVal value As Int32)
            _institute = value
        End Set
    End Property
    Private _branch As String
    Public Property Branch() As String
        Get
            Return _branch
        End Get
        Set(ByVal value As String)
            _branch = value
        End Set
    End Property
    Private _prospectus As Int32
    Public Property Prospectus() As Int32
        Get
            Return _prospectus
        End Get
        Set(ByVal value As Int32)
            _prospectus = value
        End Set
    End Property
    Private _fname As String
    Public Property FName() As String
        Get
            Return _fname
        End Get
        Set(ByVal value As String)
            _fname = value
        End Set
    End Property
    Private _foccupation As String
    Public Property FOccupation() As String
        Get
            Return _foccupation
        End Get
        Set(ByVal value As String)
            _foccupation = value
        End Set
    End Property
    Private _aincome As Double
    Public Property AIncome() As Double
        Get
            Return _aincome
        End Get
        Set(ByVal value As Double)
            _aincome = value
        End Set
    End Property
    Private _enquirer As String
    Public Property Enquirer() As String
        Get
            Return _enquirer
        End Get
        Set(ByVal value As String)
            _enquirer = value
        End Set
    End Property
    Private _enqno As String
    Public Property EnqNo() As String
        Get
            Return _enqno
        End Get
        Set(ByVal value As String)
            _enqno = value
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
    Private _district As String
    Public Property District() As String
        Get
            Return _district
        End Get
        Set(ByVal value As String)
            _district = value
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
    Private _state As Int32
    Public Property State() As Int32
        Get
            Return _state
        End Get
        Set(ByVal value As Int32)
            _state = value
        End Set
    End Property
    'Prospectus Details
    Private _price As Int32
    Public Property Price() As Int32
        Get
            Return _price
        End Get
        Set(ByVal value As Int32)
            _price = value
        End Set
    End Property
    Private _serialno As String
    Public Property Serialno() As String
        Get
            Return _serialno
        End Get
        Set(ByVal value As String)
            _serialno = value
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
    Private _qty As Int32
    Public Property Qty() As Int32
        Get
            Return _qty
        End Get
        Set(ByVal value As Int32)
            _qty = value
        End Set
    End Property
    Private _psid As Int16
    Public Property PSID() As Int16
        Get
            Return _psid
        End Get
        Set(ByVal value As Int16)
            _psid = value
        End Set
    End Property
    Private _entrydate As Date
    Public Property Entrydate() As Date
        Get
            Return _entrydate
        End Get
        Set(ByVal value As Date)
            _entrydate = value
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
    Private _Hostel As String
    Public Property Hostel() As String
        Get
            Return _Hostel
        End Get
        Set(ByVal value As String)
            _Hostel = value
        End Set
    End Property
    Private _EnquiryNo As String
    Public Property EnquiryNo() As String
        Get
            Return _EnquiryNo
        End Get
        Set(ByVal value As String)
            _EnquiryNo = value
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
    Private _deleteflag As Int16

    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property
    Private _NormalOnlineEnq As String

    Public Property NormalOnlineEnq() As String
        Get
            Return _NormalOnlineEnq
        End Get
        Set(ByVal value As String)
            _NormalOnlineEnq = value
        End Set
    End Property
    Private _OnlineEnqId As Integer

    Public Property OnlineEnqId() As Integer
        Get
            Return _OnlineEnqId
        End Get
        Set(ByVal value As Integer)
            _OnlineEnqId = value
        End Set
    End Property
    Private _CategoryId As Integer

    Public Property CategoryId() As Integer
        Get
            Return _CategoryId
        End Get
        Set(ByVal value As Integer)
            _CategoryId = value
        End Set
    End Property
    Private _Marks As Long
    Public Property Marks() As Long
        Get
            Return _Marks
        End Get
        Set(ByVal value As Long)
            _Marks = value
        End Set
    End Property
    Public Sub New()
    End Sub
End Class
