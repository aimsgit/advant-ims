Imports Microsoft.VisualBasic

Public Class StudentAndroid
    Private _Route As String
    Public Property Route() As String
        Get
            Return _Route
        End Get
        Set(ByVal value As String)
            _Route = value
        End Set
    End Property

    Private _AtTime As String
    Public Property AtTime() As String
        Get
            Return _AtTime
        End Get
        Set(ByVal value As String)
            _AtTime = value
        End Set
    End Property

    Private _Status As String
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property

    Private _BatchID As String
    Public Property BatchID() As String
        Get
            Return _BatchID
        End Get
        Set(ByVal value As String)
            _BatchID = value
        End Set
    End Property

    Private _StudentCode As String
    Public Property StudentCode() As String
        Get
            Return _StudentCode
        End Get
        Set(ByVal value As String)
            _StudentCode = value
        End Set
    End Property

    Private _StudentID As String
    Public Property StudentID() As String
        Get
            Return _StudentID
        End Get
        Set(ByVal value As String)
            _StudentID = value
        End Set
    End Property

    Private _Name As String
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
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

    Private _Flag As String
    Public Property Flag() As String
        Get
            Return _Flag
        End Get
        Set(ByVal value As String)
            _Flag = value
        End Set
    End Property
End Class
