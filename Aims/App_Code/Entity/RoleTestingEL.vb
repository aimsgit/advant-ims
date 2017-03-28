Imports Microsoft.VisualBasic
Public Class RoleTestingEL
    Private _institute As String
    Public Property institute() As String
        Get
            Return _institute
        End Get
        Set(ByVal value As String)
            _institute = value
        End Set
    End Property
    Private _branch As String
    Public Property branch() As String
        Get
            Return _branch
        End Get
        Set(ByVal value As String)
            _branch = value
        End Set
    End Property
    Private _role As Integer
    Public Property role() As Integer
        Get
            Return _role
        End Get
        Set(ByVal value As Integer)
            _role = value

        End Set
    End Property

End Class
