Imports Microsoft.VisualBasic

Public Class ELSubjectSubGrpMapping
    Private _Id As Integer
    Private _CourseId As Integer
    Private _BatchId As Integer
    Private _SemesterId As Integer
    Private _SubjectId As Integer
    Private _SubuGrp As Integer
    Private _Stdid As Integer
    'Private _Priority As String
    'Private _DescOfRequest As String
    'Private _ApprovedBy As String
    'Private _Status As String
    'Private _ClosedDate As Date
    'Private _Remarks As String
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property
    Public Property CourseId() As Integer
        Get
            Return _CourseId
        End Get
        Set(ByVal value As Integer)
            _CourseId = value
        End Set
    End Property
    Public Property Stdid() As Integer
        Get
            Return _Stdid
        End Get
        Set(ByVal value As Integer)
            _Stdid = value
        End Set
    End Property
    Public Property BatchId() As Integer
        Get
            Return _BatchId
        End Get
        Set(ByVal value As Integer)
            _BatchId = value
        End Set
    End Property
    Public Property SemesterId() As Integer
        Get
            Return _SemesterId
        End Get
        Set(ByVal value As Integer)
            _SemesterId = value
        End Set
    End Property
    Public Property SubuGrp() As Integer
        Get
            Return _SubuGrp
        End Get
        Set(ByVal value As Integer)
            _SubuGrp = value
        End Set
    End Property
    Public Property SubjectId() As Integer
        Get
            Return _SubjectId
        End Get
        Set(ByVal value As Integer)
            _SubjectId = value
        End Set
    End Property
End Class
