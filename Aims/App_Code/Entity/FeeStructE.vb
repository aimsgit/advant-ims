Imports Microsoft.VisualBasic

Public Class FeeStructE
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
    Private _categoryid As Integer
    Public Property CategoryID() As Integer
        Get
            Return _categoryid
        End Get
        Set(ByVal value As Integer)
            _categoryid = value
        End Set

    End Property
End Class
