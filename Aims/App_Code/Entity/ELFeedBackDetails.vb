Imports Microsoft.VisualBasic

Public Class ELFeedBackDetails
    Private _BranchName As String
    Public Property BranchName() As String
        Get
            Return _BranchName
        End Get
        Set(ByVal value As String)
            _BranchName = value
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
    Private _Email As String
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property
    Private _ContactNo As String
    Public Property ContactNo() As String
        Get
            Return _ContactNo
        End Get
        Set(ByVal value As String)
            _ContactNo = value
        End Set
    End Property
    Private _Empid As Integer
    Public Property Empid() As Integer
        Get
            Return _Empid
        End Get
        Set(ByVal value As Integer)
            _Empid = value
        End Set
    End Property
    Private _ChildLink As Integer
    Public Property ChildLink() As Integer
        Get
            Return _ChildLink
        End Get
        Set(ByVal value As Integer)
            _ChildLink = value
        End Set
    End Property
    Private _FeedBack As String
    Public Property FeedBack() As String
        Get
            Return _FeedBack
        End Get
        Set(ByVal value As String)
            _FeedBack = value
        End Set
    End Property
    Private _Suggestion As String
    Public Property Suggestion() As String
        Get
            Return _Suggestion
        End Get
        Set(ByVal value As String)
            _Suggestion = value
        End Set
    End Property

    Private _Fid As Integer
    Public Property Fid() As Integer
        Get
            Return _Fid
        End Get
        Set(ByVal value As Integer)
            _Fid = value
        End Set
    End Property
    Private _StudentCode As String
    Public Property StudentCode() As String
        Get
            Return _StudentCode
        End Get
        Set(ByVal value As String)
            _StudentCode = value
        End Set
    End Property
    Private _EStatus As String
    Public Property Estatus() As String
        Get
            Return _EStatus
        End Get
        Set(ByVal value As String)
            _EStatus = value
        End Set
    End Property
End Class
