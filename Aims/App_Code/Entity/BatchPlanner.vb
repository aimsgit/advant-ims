Imports Microsoft.VisualBasic

Public Class BatchPlanner
    Private _id As Long
    Public Property id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _BatchID As Long
    Public Property BatchID() As Long
        Get
            Return _BatchID
        End Get
        Set(ByVal value As Long)
            _BatchID = value
        End Set
    End Property

    Private _Emp_Name As String
    Public Property Emp_Name() As String
        Get
            Return _Emp_Name
        End Get
        Set(ByVal value As String)
            _Emp_Name = value
        End Set
    End Property
    Private _Batch_No As String
    Public Property Batch_No() As String
        Get
            Return _Batch_No
        End Get
        Set(ByVal value As String)
            _Batch_No = value
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
    Private _Course As String
    Public Property Course() As String
        Get
            Return _Course
        End Get
        Set(ByVal value As String)
            _Course = value
        End Set
    End Property
    Private _Subject As Integer
    Public Property Subject() As Integer
        Get
            Return _Subject
        End Get
        Set(ByVal value As Integer)
            _Subject = value
        End Set
    End Property
    Private _Gid As Integer
    Public Property Gid() As Integer
        Get
            Return _Gid
        End Get
        Set(ByVal value As Integer)
            _Gid = value
        End Set
    End Property
    Private _TotalHours As Double
    Public Property TotalHours() As Double
        Get
            Return _TotalHours
        End Get
        Set(ByVal value As Double)
            _TotalHours = value
        End Set
    End Property
    Private _Theory As Integer
    Public Property Theory() As Integer
        Get
            Return _Theory
        End Get
        Set(ByVal value As Integer)
            _Theory = value
        End Set
    End Property
    Public _Lab As Integer
    Public Property Lab() As Integer
        Get
            Return _Lab
        End Get
        Set(ByVal value As Integer)
            _Lab = value
        End Set
    End Property

    Private _Project As Integer
    Public Property Project() As Integer
        Get
            Return _Project
        End Get
        Set(ByVal value As Integer)
            _Project = value
        End Set
    End Property
    Private _Lecturer As String
    Public Property Lecturer() As String
        Get
            Return _Lecturer
        End Get
        Set(ByVal value As String)
            _Lecturer = value
        End Set
    End Property
    Private _Elective_Status As String
    Public Property Elective_Status() As String
        Get
            Return _Elective_Status
        End Get
        Set(ByVal value As String)
            _Elective_Status = value
        End Set
    End Property
    Private _Semester As Integer
    Public Property Semester() As Integer
        Get
            Return _Semester
        End Get
        Set(ByVal value As Integer)
            _Semester = value
        End Set
    End Property
    Private _Sequence As Integer
    Public Property Sequence() As Integer
        Get
            Return _Sequence
        End Get
        Set(ByVal value As Integer)
            _Sequence = value
        End Set
    End Property
    Private _Credit As Double
    Public Property Credit() As Double
        Get
            Return _Credit
        End Get
        Set(ByVal value As Double)
            _Credit = value
        End Set
    End Property
    Private _AcademicYear As String
    Public Property AcademicYear() As String
        Get
            Return _AcademicYear
        End Get
        Set(ByVal value As String)
            _AcademicYear = value
        End Set
    End Property
    Private _Completon_status As String
    Public Property Completon_status() As String
        Get
            Return _Completon_status
        End Get
        Set(ByVal value As String)
            _Completon_status = value
        End Set
    End Property
    Private _Generatestatus As String
    Public Property Generatestatus() As String
        Get
            Return _Generatestatus
        End Get
        Set(ByVal value As String)
            _Generatestatus = value
        End Set
    End Property
    Private _StartDate As DateTime
    Public Property StartDate() As DateTime
        Get
            Return _StartDate
        End Get
        Set(ByVal value As DateTime)
            _StartDate = value
        End Set
    End Property
    Private _EndDate As DateTime
    Public Property EndDate() As DateTime
        Get
            Return _EndDate
        End Get
        Set(ByVal value As DateTime)
            _EndDate = value
        End Set
    End Property
    Public Sub New()

    End Sub
End Class
