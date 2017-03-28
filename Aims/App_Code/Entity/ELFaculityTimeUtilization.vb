Imports Microsoft.VisualBasic

Public Class ELFaculityTimeUtilization
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Eid As Integer
    Public Property Eid() As Integer
        Get
            Return _Eid
        End Get
        Set(ByVal value As Integer)
            _Eid = value
        End Set
    End Property
    Private _Faculity As String
    Public Property Faculity() As String
        Get
            Return _Faculity
        End Get
        Set(ByVal value As String)
            _Faculity = value
        End Set
    End Property
    Private _Batch As Integer
    Public Property Batch() As Integer
        Get
            Return _Batch
        End Get
        Set(ByVal value As Integer)
            _Batch = value
        End Set
    End Property
    Private _Course As Integer
    Public Property Course() As Integer
        Get
            Return _Course
        End Get
        Set(ByVal value As Integer)
            _Course = value
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
    Private _Subject As Integer
    Public Property Subject() As Integer
        Get
            Return _Subject
        End Get
        Set(ByVal value As Integer)
            _Subject = value
        End Set
    End Property
    Private _Dates As DateTime
    Public Property Dates() As DateTime
        Get
            Return _Dates
        End Get
        Set(ByVal value As DateTime)
            _Dates = value
        End Set
    End Property
    Private _Hours As Double
    Public Property Hours() As Double
        Get
            Return _Hours
        End Get
        Set(ByVal value As Double)
            _Hours = value
        End Set
    End Property
End Class
