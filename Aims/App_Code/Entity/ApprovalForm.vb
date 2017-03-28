Imports Microsoft.VisualBasic

Public Class ApprovalForm
    Private _ApproveId As Long
    Public Property ApproveId() As Long
        Get
            Return _ApproveId
        End Get
        Set(ByVal value As Long)
            _ApproveId = value
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
    Private _UserCode As String
    Public Property UserCode() As String
        Get
            Return _UserCode
        End Get
        Set(ByVal value As String)
            _UserCode = value
        End Set
    End Property
    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
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
    Private _Office As String
    Public Property Office() As String
        Get
            Return _Office
        End Get
        Set(ByVal value As String)
            _Office = value
        End Set
    End Property
End Class
