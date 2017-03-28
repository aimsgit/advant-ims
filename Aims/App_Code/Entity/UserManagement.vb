Imports Microsoft.VisualBasic

Public Class UserManagement
    Private _BranchID As Int32
    Public Property BranchID() As Long
        Get
            Return _BranchID
        End Get
        Set(ByVal value As Long)
            _BranchID = value
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
    Private _Emp_code As String
    Public Property Emp_code() As String
        Get
            Return _Emp_code
        End Get
        Set(ByVal value As String)
            _Emp_code = value
        End Set
    End Property
    Private _ExpDate As DateTime
    Public Property ExpDate() As DateTime
        Get
            Return _ExpDate
        End Get
        Set(ByVal value As DateTime)
            _ExpDate = value
        End Set
    End Property
    Private _UserDetailsID As Int64
    Public Property UserDetailsID() As Int64
        Get
            Return _UserDetailsID
        End Get
        Set(ByVal value As Int64)
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
    Private _AccessLevel As String
    Public Property AccessLevel() As String
        Get
            Return _AccessLevel
        End Get
        Set(ByVal value As String)
            _AccessLevel = value
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
    Private _Roles As String
    Public Property Roles() As String
        Get
            Return _Roles
        End Get
        Set(ByVal value As String)
            _Roles = value
        End Set
    End Property
    Private _Privilages As String
    Public Property Privilages() As String
        Get
            Return _Privilages
        End Get
        Set(ByVal value As String)
            _Privilages = value
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
    Private _BranchType_Id As Int32
    Public Property BranchType_Id() As Int32
        Get
            Return _BranchType_Id
        End Get
        Set(ByVal value As Int32)
            _BranchType_Id = value
        End Set
    End Property

    Public Sub New()
    End Sub
End Class
