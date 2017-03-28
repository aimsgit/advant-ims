Imports Microsoft.VisualBasic

Public Class EHostelMaster11
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _HostelCode As String
    Public Property HostelCode() As String
        Get
            Return _HostelCode
        End Get
        Set(ByVal value As String)
            _HostelCode = value
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
    Private _HostelName As String

    Public Property HostelName() As String
        Get
            Return _HostelName
        End Get
        Set(ByVal value As String)
            _HostelName = value
        End Set
    End Property


    Private _HostelType As String

    Public Property HostelType() As String
        Get
            Return _HostelType
        End Get
        Set(ByVal value As String)
            _HostelType = value
        End Set
    End Property
    Private _HostelAddress As String

    Public Property HostelAddress() As String
        Get
            Return _HostelAddress
        End Get
        Set(ByVal value As String)
            _HostelAddress = value
        End Set
    End Property

    Private _Warden As String

    Public Property Warden() As String
        Get
            Return _Warden
        End Get
        Set(ByVal value As String)
            _Warden = value
        End Set
    End Property

    Private _HouseKeeping As String

    Public Property HouseKeeping() As String
        Get
            Return _HouseKeeping
        End Get
        Set(ByVal value As String)
            _HouseKeeping = value
        End Set
    End Property
    'Private _Day As DateTime
    'Public Property Day() As DateTime
    '    Get
    '        Return _Day
    '    End Get
    '    Set(ByVal value As DateTime)
    '        _Day = value
    '    End Set
    'End Property
    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
    Public Sub New()
    End Sub


End Class
