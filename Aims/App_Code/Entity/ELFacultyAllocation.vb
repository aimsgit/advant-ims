Imports Microsoft.VisualBasic

Public Class ELFacultyAllocation
    Private _BatchId As Integer
    Public Property BatchId() As Integer
        Get
            Return _BatchId
        End Get
        Set(ByVal value As Integer)
            _BatchId = value
        End Set
    End Property
    Private _CourseID As Int64
    Public Property CourseID() As Integer
        Get
            Return _CourseID
        End Get
        Set(ByVal value As Integer)
            _CourseID = value
        End Set
    End Property
    Private _TeacherID1 As Int64
    Public Property TeacherID1() As Integer
        Get
            Return _TeacherID1
        End Get
        Set(ByVal value As Integer)
            _TeacherID1 = value
        End Set
    End Property
    Private _TeacherID2 As Int64
    Public Property TeacherID2() As Integer
        Get
            Return _TeacherID2
        End Get
        Set(ByVal value As Integer)
            _TeacherID2 = value
        End Set
    End Property
    Private _TeacherID3 As Int64
    Public Property TeacherID3() As Integer
        Get
            Return _TeacherID3
        End Get
        Set(ByVal value As Integer)
            _TeacherID3 = value
        End Set
    End Property
    Private _Hours1 As Int64
    Public Property Hours1() As Integer
        Get
            Return _Hours1
        End Get
        Set(ByVal value As Integer)
            _Hours1 = value
        End Set
    End Property
    Private _Hours2 As Int64
    Public Property Hours2() As Integer
        Get
            Return _Hours2
        End Get
        Set(ByVal value As Integer)
            _Hours2 = value
        End Set
    End Property
    Private _Hours3 As Int64
    Public Property Hours3() As Integer
        Get
            Return _Hours3
        End Get
        Set(ByVal value As Integer)
            _Hours3 = value
        End Set
    End Property
    Private _Lock As String
    Public Property Lock() As String
        Get
            Return _Lock
        End Get
        Set(ByVal value As String)
            _Lock = value
        End Set
    End Property
    Private _Hours4 As Int64
    Public Property Hours4() As Integer
        Get
            Return _Hours4
        End Get
        Set(ByVal value As Integer)
            _Hours4 = value
        End Set
    End Property
    Private _TeacherID4 As Int64
    Public Property TeacherID4() As Integer
        Get
            Return _TeacherID4
        End Get
        Set(ByVal value As Integer)
            _TeacherID4 = value
        End Set
    End Property
    Private _SemesterId As Integer
    Public Property SemesterId() As Integer
        Get
            Return _SemesterId
        End Get
        Set(ByVal value As Integer)
            _SemesterId = value
        End Set
    End Property
    Private _Id As String
    Public Property Id() As String
        Get
            Return _Id
        End Get
        Set(ByVal value As String)
            _Id = value
        End Set
    End Property
End Class
