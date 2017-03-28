Imports Microsoft.VisualBasic
Public Class ElMedicalDetails
    Private _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property
    Private _Std_ID As Integer
    Public Property Std_ID() As Integer
        Get
            Return _Std_ID
        End Get
        Set(ByVal value As Integer)
            _Std_ID = value
        End Set
    End Property
    Private _Emp_Id As Integer
    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal value As Integer)
            _Emp_Id = value
        End Set
    End Property
    Private _Height As String
    Public Property Height() As String
        Get
            Return _Height
        End Get
        Set(ByVal value As String)
            _Height = value
        End Set
    End Property
    Private _Weight As String
    Public Property Weight() As String
        Get
            Return _Weight
        End Get
        Set(ByVal value As String)
            _Weight = value
        End Set
    End Property
    Private _IdentificationMark As String
    Public Property IdentificationMark() As String
        Get
            Return _IdentificationMark
        End Get
        Set(ByVal value As String)
            _IdentificationMark = value
        End Set
    End Property
    Private _LoginType As String
    Public Property LoginType() As String
        Get
            Return _LoginType
        End Get
        Set(ByVal value As String)
            _LoginType = value
        End Set
    End Property
    Private _BloodGroup As String
    Public Property BloodGroup() As String
        Get
            Return _BloodGroup
        End Get
        Set(ByVal value As String)
            _BloodGroup = value
        End Set
    End Property
    Private _ImmunizationRecord As String
    Public Property ImmunizationRecord() As String
        Get
            Return _ImmunizationRecord
        End Get
        Set(ByVal value As String)
            _ImmunizationRecord = value
        End Set
    End Property
    Private _Detailsofanyseriousillness As String
    Public Property Detailsofanyseriousillness() As String
        Get
            Return _Detailsofanyseriousillness
        End Get
        Set(ByVal value As String)
            _Detailsofanyseriousillness = value
        End Set
    End Property
    Private _Particularsofanyallergies As String
    Public Property Particularsofanyallergies() As String
        Get
            Return _Particularsofanyallergies
        End Get
        Set(ByVal value As String)
            _Particularsofanyallergies = value
        End Set
    End Property
    Private _EmergencyContactName As String
    Public Property EmergencyContactName() As String
        Get
            Return _EmergencyContactName
        End Get
        Set(ByVal value As String)
            _EmergencyContactName = value
        End Set
    End Property
    Private _EmergencyContactNumber As String
    Public Property EmergencyContactNumber() As String
        Get
            Return _EmergencyContactNumber
        End Get
        Set(ByVal value As String)
            _EmergencyContactNumber = value
        End Set
    End Property
    Private _Disabilitiesifany As String
    Public Property Disabilitiesifany() As String
        Get
            Return _Disabilitiesifany
        End Get
        Set(ByVal value As String)
            _Disabilitiesifany = value
        End Set
    End Property
End Class
