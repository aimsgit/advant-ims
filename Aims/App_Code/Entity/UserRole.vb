Imports Microsoft.VisualBasic

Public Class UserRole
    Private _UserRoleID As Long
    Public Property UserRoleID() As Integer
        Get
            Return _UserRoleID
        End Get
        Set(ByVal value As Integer)

            _UserRoleID = value
        End Set
    End Property

    Private _UserRole As String
    Public Property UserRole() As String
        Get
            Return _UserRole
        End Get
        Set(ByVal value As String)
            _UserRole = value
        End Set
    End Property
    Private _FormAccess As String
    Public Property FormAccess() As String
        Get
            Return _FormAccess
        End Get
        Set(ByVal value As String)
            _FormAccess = value
        End Set
    End Property
    Private _DelFlag As Int16
    Public Property DelFlag() As Int16
        Get
            Return _DelFlag
        End Get
        Set(ByVal value As Int16)
            _DelFlag = value
        End Set
    End Property

    Sub New(ByVal UserRoleID As Long, ByVal UserRole As String, ByVal DelFlag As Int16, ByVal FormAccess As String)
        _UserRoleID = UserRoleID
        _UserRole = UserRole
        _DelFlag = DelFlag
        _FormAccess = FormAccess
    End Sub
    Sub New()

    End Sub
End Class
