Imports Microsoft.VisualBasic

Public Class TransportAndroid
    Private _Route As String
    Public Property Route() As String
        Get
            Return _Route
        End Get
        Set(ByVal value As String)
            _Route = value
        End Set
    End Property
    Private _Latitude As String
    Public Property Latitude() As String
        Get
            Return _Latitude
        End Get
        Set(ByVal value As String)
            _Latitude = value
        End Set
    End Property

    Private _Longitude As String
    Public Property Longitude() As String
        Get
            Return _Longitude
        End Get
        Set(ByVal value As String)
            _Longitude = value
        End Set
    End Property

    Private _gpsDate As String
    Public Property gpsDate() As String
        Get
            Return _gpsDate
        End Get
        Set(ByVal value As String)
            _gpsDate = value
        End Set
    End Property

    Private _Time As String
    Public Property Time() As String
        Get
            Return _Time
        End Get
        Set(ByVal value As String)
            _Time = value
        End Set
    End Property

    Private _IMEINO As String
    Public Property IMEINO() As String
        Get
            Return _IMEINO
        End Get
        Set(ByVal value As String)
            _IMEINO = value
        End Set
    End Property

    Private _Branchcode As String
    Public Property Branchcode() As String
        Get
            Return _Branchcode
        End Get
        Set(ByVal value As String)
            _Branchcode = value
        End Set
    End Property
End Class
