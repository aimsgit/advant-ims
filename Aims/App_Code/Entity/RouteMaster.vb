Imports Microsoft.VisualBasic

Public Class RouteMaster
    Private _RouteID As Int16
    Public Property RouteID() As Int16
        Get
            Return _RouteID
        End Get
        Set(ByVal value As Int16)
            _RouteID = value
        End Set
    End Property
    Private _InstituteID As Long
    Public Property InstituteID() As Long
        Get
            Return _InstituteID
        End Get
        Set(ByVal value As Long)
            _InstituteID = value
        End Set
    End Property
    Private _Branch As Long
    Public Property Branch() As Long
        Get
            Return _Branch
        End Get
        Set(ByVal value As Long)
            _Branch = value
        End Set
    End Property
    Private _RouteNumber As String
    Public Property RouteNumber() As String
        Get
            Return _RouteNumber
        End Get
        Set(ByVal value As String)
            _RouteNumber = value
        End Set
    End Property
    Private _RouteName As String
    Public Property RouteName() As String

        Get
            Return _RouteName
        End Get
        Set(ByVal value As String)
            _RouteName = value
        End Set
    End Property
    Private _ArrivalTime As DateTime

    Public Property ArrivalTime() As DateTime

        Get
            Return _ArrivalTime
        End Get
        Set(ByVal value As DateTime)

            _ArrivalTime = value
        End Set
    End Property
    Private _DepartureTime As DateTime

    Public Property DepartureTime() As DateTime

        Get
            Return _DepartureTime
        End Get
        Set(ByVal value As DateTime)

            _DepartureTime = value
        End Set
    End Property

    Private _VehicleID As Int16

    Public Property VehicleID() As Int16

        Get
            Return _VehicleID
        End Get
        Set(ByVal value As Int16)

            _VehicleID = value
        End Set
    End Property
    Private _DriverID As Int16
    Public Property DriverID() As Int16
        Get
            Return _DriverID
        End Get
        Set(ByVal value As Int16)
            _DriverID = value
        End Set
    End Property
    Private _PickUpPoints As String

    Public Property PickUpPoints() As String

        Get
            Return _PickUpPoints
        End Get
        Set(ByVal value As String)

            _PickUpPoints = value
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
    Public Sub New()
    End Sub
    Public Sub New(ByVal RouteID As Int16, ByVal InstituteID As Long, ByVal Branch As Long, ByVal RouteNumber As Int16, ByVal RouteName As String, ByVal ArrivalTime As DateTime, ByVal DepartureTime As DateTime, ByVal VehicleID As Int16, ByVal DriverID As String, ByVal PickUpPoints As String, ByVal Remarks As String)
        _RouteID = RouteID
        _InstituteID = InstituteID
        _Branch = Branch
        _RouteNumber = RouteNumber
        _ArrivalTime = ArrivalTime
        _DepartureTime = DepartureTime
        _RouteName = RouteName
        _VehicleID = VehicleID
        _DriverID = DriverID
        _PickUpPoints = PickUpPoints
        _Remarks = Remarks
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