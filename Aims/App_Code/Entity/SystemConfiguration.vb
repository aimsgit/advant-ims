Imports Microsoft.VisualBasic

Public Class SystemConfiguration
    Private _configID As Int16
    Public Property configID() As Int16
        Get
            Return _configID
        End Get
        Set(ByVal value As Int16)
            _configID = value
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
    Private _Value As String
    Public Property Value() As String
        Get
            Return _Value
        End Get
        Set(ByVal value As String)
            _Value = value
        End Set
    End Property
    Private _BranchCode As String
    Public Property BranchCode() As String
        Get
            Return _BranchCode
        End Get
        Set(ByVal value As String)
            _BranchCode = value
        End Set
    End Property
    Private _ConfigDate As DateTime
    Public Property ConfigDate() As DateTime
        Get
            Return _ConfigDate
        End Get
        Set(ByVal value As DateTime)
            _ConfigDate = value
        End Set
    End Property
    Private _Description As String
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property
    Private _ReadOnlys As String
    Public Property ReadOnlys() As String
        Get
            Return _ReadOnlys
        End Get
        Set(ByVal value As String)
            _ReadOnlys = value
        End Set
    End Property
    Public Sub New()
    End Sub
End Class
