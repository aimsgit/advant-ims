Imports Microsoft.VisualBasic

Public Class RoleMaster
    Private _Branch_ID As Int32
    Public Property Branch_ID() As Long
        Get
            Return _Branch_ID
        End Get
        Set(ByVal value As Long)
            _Branch_ID = value
        End Set
    End Property
    Private _UserRoleID As Int64
    Public Property UserRoleID() As Int64
        Get
            Return _UserRoleID
        End Get
        Set(ByVal value As Int64)
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
    Private _Del_Flag As String
    Public Property Del_Flag() As String
        Get
            Return _Del_Flag
        End Get
        Set(ByVal value As String)
            _Del_Flag = value
        End Set
    End Property
    Private _UserId As Int64
    Public Property UserId() As Int64
        Get
            Return _UserId
        End Get
        Set(ByVal value As Int64)
            _UserId = value
        End Set
    End Property
    Private _Emp_ID As Int64
    Public Property Emp_ID() As Int64
        Get
            Return _Emp_ID
        End Get
        Set(ByVal value As Int64)
            _Emp_ID = value
        End Set
    End Property
    Public Sub New()
    End Sub
End Class
