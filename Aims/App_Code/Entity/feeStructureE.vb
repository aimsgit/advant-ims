Imports Microsoft.VisualBasic

Public Class feeStructureE
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _batchid As Integer
    Public Property batchID() As Integer
        Get
            Return _batchid
        End Get
        Set(ByVal value As Integer)
            _batchid = value
        End Set
    End Property
    Private _batchNo As String
    Public Property batchNo() As String
        Get
            Return _batchNo
        End Get
        Set(ByVal value As String)
            _batchNo = value
        End Set
    End Property

    Private _semesterid As Integer
    Public Property Semester_ID() As Integer
        Get
            Return _semesterid
        End Get
        Set(ByVal value As Integer)
            _semesterid = value
        End Set
    End Property
    Private _academicYearid As Integer
    Public Property AcademicYear_id() As Integer
        Get
            Return _academicYearid
        End Get
        Set(ByVal value As Integer)
            _academicYearid = value
        End Set

    End Property
    Private _AYearid As String
    Public Property AYearid() As String
        Get
            Return _AYearid
        End Get
        Set(ByVal value As String)
            _AYearid = value
        End Set

    End Property
   
    Private _CourseTypeid As String
    Public Property CourseTypeid() As String
        Get
            Return _CourseTypeid
        End Get
        Set(ByVal value As String)
            _CourseTypeid = value
        End Set

    End Property
    Private _CourseName As Integer
    Public Property CourseName() As Integer
        Get
            Return _CourseName
        End Get
        Set(ByVal value As Integer)
            _CourseName = value
        End Set

    End Property
    Private _Course As String
    Public Property Course() As String
        Get
            Return _Course
        End Get
        Set(ByVal value As String)
            _Course = value
        End Set

    End Property
    Private _categoryid As Integer
    Public Property CategoryID() As Integer
        Get
            Return _categoryid
        End Get
        Set(ByVal value As Integer)
            _categoryid = value
        End Set

    End Property
    Private _feeheadid As Integer
    Public Property Feehead_ID() As Integer
        Get
            Return _feeheadid
        End Get
        Set(ByVal value As Integer)
            _feeheadid = value
        End Set

    End Property
    Private _feeamt As Integer
    Public Property Amount() As Integer
        Get
            Return _feeamt
        End Get
        Set(ByVal value As Integer)
            _feeamt = value
        End Set

    End Property
    Private _duedate As Date
    Public Property DueDate() As Date
        Get
            Return _duedate
        End Get
        Set(ByVal value As Date)
            _duedate = value
        End Set
    End Property

End Class
