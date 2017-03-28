Imports Microsoft.VisualBasic

Public Class DayBookPartyName
    Private _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
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

    Public Sub New()

    End Sub
    Public Sub New(ByVal Name As String, ByVal ID As Integer)
        _Id = Id
        _Name = Name
    End Sub
End Class
