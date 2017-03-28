Imports Microsoft.VisualBasic

Public Class Semester
    Private _id As Int64
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _semesterid As String
    Public Property SemesterId() As String
        Get
            Return _semesterid
        End Get
        Set(ByVal value As String)
            _semesterid = value
        End Set
    End Property
    Private _Course As Int64
    Public Property Course() As Int64
        Get
            Return _Course
        End Get
        Set(ByVal value As Int64)
            _Course = value
        End Set
    End Property
    Private _Duration As Int32
    Public Property Duration() As Int32
        Get
            Return _Duration
        End Get
        Set(ByVal value As Int32)
            _Duration = value
        End Set
    End Property
    Private _Weeks As Int32
    Public Property Weeks() As Int32
        Get
            Return _Weeks
        End Get
        Set(ByVal value As Int32)
            _Weeks = value
        End Set
    End Property
    Private _Sequence As Int32
    Public Property Sequence() As Int32
        Get
            Return _Sequence
        End Get
        Set(ByVal value As Int32)
            _Sequence = value
        End Set
    End Property


    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _durationDays As Integer
    Public Property durationDays() As Integer
        Get
            Return _durationDays
        End Get
        Set(ByVal value As Integer)
            _durationDays = value
        End Set
    End Property
    Sub New()

    End Sub
    Sub New(ByVal _id As Int64, ByVal _name As String)
        Me._id = _id
        Me._name = _name
    End Sub
End Class
