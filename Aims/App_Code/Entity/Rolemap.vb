Imports Microsoft.VisualBasic

Public Class Rolemap
    Private _BranchCode As String
    Public Property BranchCode() As String
        Get
            Return _BranchCode
        End Get
        Set(ByVal value As String)
            _BranchCode = value
        End Set
    End Property
    Private _RMID As Long
    Public Property RMID() As Long
        Get
            Return _RMID
        End Get
        Set(ByVal value As Long)
            _RMID = value
        End Set
    End Property
    Private _Code As Long
    Public Property Code() As Long
        Get
            Return _Code
        End Get
        Set(ByVal value As Long)
            _Code = value
        End Set
    End Property
    Private _id As String
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property
    Private _RoleCode As Long
    Public Property RoleCode() As Long
        Get
            Return _RoleCode
        End Get
        Set(ByVal value As Long)
            _RoleCode = value
        End Set
    End Property
    Public Sub New(ByVal BranchCode As String, ByVal RMID As Long, ByVal Code As Long, ByVal RoleCode As Long)
        _BranchCode = BranchCode
        _RMID = RMID
        _Code = Code
        _RoleCode = RoleCode
    End Sub
    Public Sub New()

    End Sub
End Class
