Imports Microsoft.VisualBasic

Public Class VehicleMaintenanceEn
    Private _vmid As Integer
    Public Property VMID() As Integer
        Get
            Return _vmid
        End Get
        Set(ByVal value As Integer)
            _vmid = value

        End Set
    End Property
    Private _vehicleno As Integer
    Public Property VehicleNo() As Integer
        Get
            Return _vehicleno
        End Get
        Set(ByVal value As Integer)
            _vehicleno = value
        End Set
    End Property
    Private _AssetId As Integer
    Public Property AssetId() As Integer
        Get
            Return _AssetId
        End Get
        Set(ByVal value As Integer)
            _AssetId = value
        End Set
    End Property
    Private _AssetTypeId As Integer
    Public Property AssetTypeId() As Integer
        Get
            Return _AssetTypeId
        End Get
        Set(ByVal value As Integer)
            _AssetTypeId = value
        End Set
    End Property
    Private _amount As Long
    Public Property Amount() As Long
        Get
            Return _amount
        End Get
        Set(ByVal value As Long)
            _amount = value
        End Set
    End Property

    Private _servicedetail As String

    Public Property ServiceDetails() As String
        Get
            Return _servicedetail
        End Get
        Set(ByVal value As String)
            _servicedetail = value
        End Set
    End Property
    Private _Type As String

    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property

    Private _servicedate As DateTime
    Public Property ServiceDate() As DateTime
        Get
            Return _servicedate
        End Get
        Set(ByVal value As DateTime)
            _servicedate = value
        End Set
    End Property
    Private _nextservicedate As Date
    Public Property NextServiceDate() As Date
        Get
            Return _nextservicedate
        End Get
        Set(ByVal value As Date)
            _nextservicedate = value
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
    Private _institute As Integer
    Public Property Institute() As Integer
        Get
            Return _institute
        End Get
        Set(ByVal value As Integer)
            _institute = value
        End Set
    End Property
    Private _branch As Integer
    Public Property Branch() As Integer
        Get
            Return _branch
        End Get
        Set(ByVal value As Integer)
            _branch = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Private _delflag As Int16
    Public Property Delflag() As Int16
        Get
            Return _delflag
        End Get
        Set(ByVal value As Int16)
            _delflag = value
        End Set
    End Property
End Class








