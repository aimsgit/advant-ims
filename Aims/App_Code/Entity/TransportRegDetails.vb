Imports Microsoft.VisualBasic

Public Class TransportRegDetails
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _AcademicYear As String
    Public Property AcademicYear() As String
        Get
            Return _AcademicYear
        End Get
        Set(ByVal value As String)
            _AcademicYear = value
        End Set
    End Property
    Private _RouteIDAuto As Integer
    Public Property RouteIDAuto() As Integer
        Get
            Return _RouteIDAuto
        End Get
        Set(ByVal value As Integer)
            _RouteIDAuto = value
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
    Private _RouteID As Integer
    Public Property RouteID() As Integer
        Get
            Return _RouteName
        End Get
        Set(ByVal value As Integer)
            _RouteID = value
        End Set
    End Property
    Private _A_Year As Integer
    Public Property A_Year() As Integer
        Get
            Return _A_Year
        End Get
        Set(ByVal value As Integer)
            _A_Year = value
        End Set
    End Property
End Class
