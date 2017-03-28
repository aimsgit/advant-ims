Imports Microsoft.VisualBasic

Public Class changepassword
    Private _BranchCode As String
    Public Property BranchCode() As String
        Get
            Return _BranchCode
        End Get
        Set(ByVal value As String)
            _BranchCode = value
        End Set
    End Property
    Private _EmpCode As String
    Public Property EmpCode() As String
        Get
            Return _EmpCode
        End Get
        Set(ByVal value As String)
            _EmpCode = value
        End Set
    End Property
    Private _UserCode As String
    Public Property UserCode() As String
        Get
            Return _UserCode
        End Get
        Set(ByVal value As String)
            _UserCode = value
        End Set
    End Property
    Private _UserDetailsID As Long
    Public Property UserDetailsID() As Long
        Get
            Return _UserDetailsID
        End Get
        Set(ByVal value As Long)
            _UserDetailsID = value
        End Set
    End Property
    Private _UserName As String
    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property
    Private _Password As String
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property
    Public Sub New(ByVal BranchCode As String, ByVal UserCode As String, ByVal EmpCode As String, ByVal UserDetailsID As Long, ByVal Password As String)
        _BranchCode = BranchCode
        _UserCode = UserCode
        _EmpCode = EmpCode
        _UserDetailsID = UserDetailsID
        _Password = Password
    End Sub
    Public Sub New()

    End Sub
End Class
