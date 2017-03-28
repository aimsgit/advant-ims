Imports Microsoft.VisualBasic

Public Class CreateBatch
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
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
    Private _Forum As String
    Public Property Forum() As String
        Get
            Return _Forum
        End Get
        Set(ByVal value As String)
            _Forum = value
        End Set
    End Property
    Private _ClassTeacher As Int16
    Public Property ClassTeacher() As Int16
        Get
            Return _ClassTeacher
        End Get
        Set(ByVal value As Int16)
            _ClassTeacher = value
        End Set
    End Property
    Private _AssociatedTeacher As Int16
    Public Property AssociatedTeacher() As Int16
        Get
            Return _AssociatedTeacher
        End Get
        Set(ByVal value As Int16)
            _AssociatedTeacher = value
        End Set
    End Property
    Private _CourseCode As Integer
    Public Property CourseCode() As Integer
        Get
            Return _CourseCode
        End Get
        Set(ByVal value As Integer)
            _CourseCode = value
        End Set
    End Property
    Private _Seat As Integer
    Public Property Seat() As Integer
        Get
            Return _Seat
        End Get
        Set(ByVal value As Integer)
            _Seat = value
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
    Private _StartDate As Date
    Public Property StartDate() As Date
        Get
            Return _StartDate
        End Get
        Set(ByVal value As Date)
            _StartDate = value
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

    Private _UserName As String
    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property
    Private _Completonstatus As String
    Public Property Completonstatus() As String
        Get
            Return _Completonstatus
        End Get
        Set(ByVal value As String)
            _Completonstatus = value
        End Set
    End Property
End Class
