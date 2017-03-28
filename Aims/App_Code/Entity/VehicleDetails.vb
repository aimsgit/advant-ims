Imports Microsoft.VisualBasic

Public Class VehicleDetails
    Private _VehicleID As Int16
    Public Property VehicleID() As Int16
        Get
            Return _VehicleID
        End Get
        Set(ByVal value As Int16)
            _VehicleID = value
        End Set
    End Property
    Private _institute As Long
    Public Property Institute() As Long
        Get
            Return _institute
        End Get
        Set(ByVal value As Long)
            _institute = value
        End Set
    End Property
    Private _branch As Long
    Public Property Branch() As Long
        Get
            Return _branch
        End Get
        Set(ByVal value As Long)
            _branch = value
        End Set
    End Property
    Private _VehicleRegistrationnNo As String

    Public Property VehicleRegistrationnNo() As String

        Get
            Return _VehicleRegistrationnNo
        End Get
        Set(ByVal value As String)

            _VehicleRegistrationnNo = value
        End Set
    End Property
    Private _YearRegistrationnNo As DateTime

    Public Property YearRegistrationnNo() As DateTime

        Get
            Return _YearRegistrationnNo
        End Get
        Set(ByVal value As DateTime)

            _YearRegistrationnNo = value
        End Set
    End Property
    Private _VehicleType As String

    Public Property VehicleType() As String

        Get
            Return _VehicleType
        End Get
        Set(ByVal value As String)

            _VehicleType = value
        End Set
    End Property
    Private _VehicleMake As String

    Public Property VehicleMake() As String

        Get
            Return _VehicleMake
        End Get
        Set(ByVal value As String)

            _VehicleMake = value
        End Set
    End Property
    Private _MakeYear As Int16

    Public Property MakeYear() As Int16

        Get
            Return _MakeYear
        End Get
        Set(ByVal value As Int16)

            _MakeYear = value
        End Set
    End Property
    Private _Model As String

    Public Property Model() As String

        Get
            Return _Model
        End Get
        Set(ByVal value As String)

            _Model = value
        End Set
    End Property
    Private _Price As Double

    Public Property Price() As Double

        Get
            Return _Price
        End Get
        Set(ByVal value As Double)

            _Price = value
        End Set
    End Property
    Private _EngineNumber As String
    Public Property EngineNumber() As String
        Get
            Return _EngineNumber
        End Get
        Set(ByVal value As String)
            _EngineNumber = value
        End Set
    End Property
    Private _NoOfSeats As String
    Public Property NoOfSeats() As String
        Get
            Return _NoOfSeats
        End Get
        Set(ByVal value As String)
            _NoOfSeats = value
        End Set
    End Property

    Private _FuelType As String

    Public Property FuelType() As String

        Get
            Return _FuelType
        End Get
        Set(ByVal value As String)

            _FuelType = value
        End Set
    End Property
    Private _InsuranceExpiry As DateTime

    Public Property InsuranceExpiry() As DateTime

        Get
            Return _InsuranceExpiry
        End Get
        Set(ByVal value As DateTime)

            _InsuranceExpiry = value
        End Set
    End Property
    Private _RenewalOfPermit As DateTime

    Public Property RenewalOfPermit() As DateTime

        Get
            Return _RenewalOfPermit
        End Get
        Set(ByVal value As DateTime)

            _RenewalOfPermit = value
        End Set
    End Property
    Private _OwnerShipStatus As String

    Public Property OwnerShipStatus() As String

        Get
            Return _OwnerShipStatus
        End Get
        Set(ByVal value As String)

            _OwnerShipStatus = value
        End Set
    End Property

    Private _ContratorName As String

    Public Property ContratorName() As String

        Get
            Return _ContratorName
        End Get
        Set(ByVal value As String)

            _ContratorName = value
        End Set
    End Property
    Private _contactNumber As String
    Public Property contactNumber() As String
        Get
            Return _contactNumber
        End Get
        Set(ByVal value As String)
            _contactNumber = value
        End Set
    End Property
    Private _Address As String

    Public Property Address() As String

        Get
            Return _Address
        End Get
        Set(ByVal value As String)

            _Address = value
        End Set
    End Property
    Private _StartDate As DateTime

    Public Property StartDate() As DateTime

        Get
            Return _StartDate
        End Get
        Set(ByVal value As DateTime)

            _StartDate = value
        End Set
    End Property
    Private _EndDate As DateTime

    Public Property EndDate() As DateTime

        Get
            Return _EndDate
        End Get
        Set(ByVal value As DateTime)

            _EndDate = value
        End Set
    End Property
    Private _CharsyNo As String

    Public Property CharsyNo() As String

        Get
            Return _CharsyNo
        End Get
        Set(ByVal value As String)

            _CharsyNo = value
        End Set
    End Property
    Private _InsuranceCompanyname As String

    Public Property InsuranceCompanyname() As String

        Get
            Return _InsuranceCompanyname
        End Get
        Set(ByVal value As String)

            _InsuranceCompanyname = value
        End Set
    End Property
    Private _PolicyNo As String

    Public Property PolicyNo() As String

        Get
            Return _PolicyNo
        End Get
        Set(ByVal value As String)

            _PolicyNo = value
        End Set
    End Property
    Private _InsuranceContactNo As String

    Public Property InsuranceContactNo() As String

        Get
            Return _InsuranceContactNo
        End Get
        Set(ByVal value As String)

            _InsuranceContactNo = value
        End Set
    End Property

    Public Sub New(ByVal VehicleID As Int16, ByVal Institute As Long, ByVal Branch As Long, ByVal VehicleRegistrationnNo As String, ByVal YearRegistrationnNo As DateTime, ByVal VehicleType As Int16, ByVal VehicleMake As String, ByVal MakeYear As Int16, ByVal Model As String, ByVal Price As Double, ByVal EngineNumber As Int16, ByVal NoOfSeats As String, ByVal FuelType As String, ByVal InsuranceExpiry As DateTime, ByVal RenewalOfPermit As String, ByVal OwnerShipStatus As Integer, ByVal ContratorName As String, ByVal contactNumber As Int16, ByVal Address As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime)

        _VehicleID = VehicleID
        _institute = Institute
        _branch = Branch
        _VehicleRegistrationnNo = VehicleRegistrationnNo
        _YearRegistrationnNo = YearRegistrationnNo
        _VehicleType = VehicleMake
        _VehicleMake = VehicleMake
        _MakeYear = MakeYear
        _Model = Model
        _Price = Price
        _EngineNumber = EngineNumber
        _NoOfSeats = NoOfSeats
        _FuelType = FuelType
        _InsuranceExpiry = InsuranceExpiry
        _RenewalOfPermit = RenewalOfPermit
        _OwnerShipStatus = OwnerShipStatus
        _ContratorName = ContratorName
        _contactNumber = contactNumber
        _Address = Address
        _StartDate = StartDate
        _EndDate = EndDate
        _CharsyNo = CharsyNo
        _InsuranceCompanyname = InsuranceCompanyname
        _InsuranceContactNo = InsuranceContactNo
        _PolicyNo = PolicyNo
    End Sub
    Public Sub New()
    End Sub
    Private _deleteflag As Int16

    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property
End Class
