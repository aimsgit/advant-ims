Imports Microsoft.VisualBasic

Public Class ELfrmDataBackupCenterWise
    Private _BranchCode As String
    Public Property BranchCode() As String
        Get
            Return _BranchCode
        End Get
        Set(ByVal value As String)
            _BranchCode = value

        End Set
    End Property
    
    Private _id As Integer

    Public Property Id() As Integer

        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set

    End Property
    Private _RbId As String

    Public Property RbId() As String
        Get
            Return _RbId
        End Get
        Set(ByVal value As String)
            _RbId = value
        End Set
    End Property
    Private _BranchName As String
    Public Property BranchName() As String
        Get
            Return _BranchName
        End Get
        Set(ByVal value As String)
            _BranchName = value
        End Set
    End Property


End Class
