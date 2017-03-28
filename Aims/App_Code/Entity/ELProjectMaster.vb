Imports Microsoft.VisualBasic
Public Class ELProjectMaster
    Private _ProjectID As Integer
    Public Property ProjectID() As Integer
        Get
            Return _ProjectID
        End Get
        Set(ByVal value As Integer)
            _ProjectID = value
        End Set
    End Property
    Private _SponsorID As Integer
    Public Property SponsorID() As Integer
        Get
            Return _SponsorID
        End Get
        Set(ByVal value As Integer)
            _SponsorID = value
        End Set
    End Property
    Private _Emp_ID As Integer
    Public Property Emp_ID() As Integer
        Get
            Return _Emp_ID
        End Get
        Set(ByVal value As Integer)
            _Emp_ID = value
        End Set
    End Property

    Private _ProjectName As String
    Public Property ProjectName() As String
        Get
            Return _ProjectName
        End Get
        Set(ByVal value As String)
            _ProjectName = value
        End Set
    End Property
    Private _Description As String
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property
    Private _SubmittedBy As Integer
    Public Property SubmittedBy() As Integer
        Get
            Return _SubmittedBy
        End Get
        Set(ByVal value As Integer)
            _SubmittedBy = value
        End Set
    End Property
    Private _ApprovedBy As Integer
    Public Property ApprovedBy() As Integer
        Get
            Return _ApprovedBy
        End Get
        Set(ByVal value As Integer)
            _ApprovedBy = value
        End Set
    End Property
    Private _SubmittedDate As Date
    Public Property SubmittedDate() As Date
        Get
            Return _SubmittedDate
        End Get
        Set(ByVal value As Date)
            _SubmittedDate = value
        End Set
    End Property
    Private _ApprovedDate As Date
    Public Property ApprovedDate() As Date
        Get
            Return _ApprovedDate
        End Get
        Set(ByVal value As Date)
            _ApprovedDate = value
        End Set
    End Property
    Private _StartDate As Date
    Public Property StartDate() As Date
        Get
            Return _StartDate
        End Get
        Set(ByVal value As Date)
            _StartDate = value
        End Set
    End Property
    Private _EndDate As Date
    Public Property EndDate() As Date
        Get
            Return _EndDate
        End Get
        Set(ByVal value As Date)
            _EndDate = value
        End Set
    End Property
End Class
