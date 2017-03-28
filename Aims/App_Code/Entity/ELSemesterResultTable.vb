Imports Microsoft.VisualBasic

Public Class ELSemesterResultTable
    Private _A_Year As Integer
    Public Property A_Year() As Integer
        Get
            Return _A_Year
        End Get
        Set(ByVal value As Integer)
            _A_Year = value
        End Set
    End Property
    Private _Stdid As Integer
    Public Property Stdid() As Integer
        Get
            Return _Stdid
        End Get
        Set(ByVal value As Integer)
            _Stdid = value
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
    Private _Semester As Integer
    Public Property Semester() As Integer
        Get
            Return _Semester
        End Get
        Set(ByVal value As Integer)
            _Semester = value
        End Set
    End Property
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
End Class
