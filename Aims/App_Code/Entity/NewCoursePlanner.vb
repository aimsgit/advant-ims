Imports Microsoft.VisualBasic

Public Class NewCoursePlanner
    Private _Course As Integer
    Public Property Course() As Integer
        Get
            Return _Course
        End Get
        Set(ByVal value As Integer)

            _Course = value
        End Set
    End Property
    Private _subject As Integer
    Public Property subject() As Integer
        Get
            Return _subject
        End Get
        Set(ByVal value As Integer)

            _subject = value
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
    Private _theory As Double
    Public Property theory() As Double
        Get
            Return _theory
        End Get
        Set(ByVal value As Double)

            _theory = value
        End Set
    End Property
    Private _Lab As Double
    Public Property Lab() As Double
        Get
            Return _Lab
        End Get
        Set(ByVal value As Double)

            _Lab = value
        End Set
    End Property
    Private _Project As Double
    Public Property Project() As Double
        Get
            Return _Project
        End Get
        Set(ByVal value As Double)

            _Project = value
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

    Private _PrincipalSubject As Integer
    Public Property PrincipalSubject() As Integer
        Get
            Return _PrincipalSubject
        End Get
        Set(ByVal value As Integer)
            _PrincipalSubject = value
        End Set
    End Property
    Private _SubjectCategory As Integer
    Public Property SubjectCategory() As Integer
        Get
            Return _SubjectCategory
        End Get
        Set(ByVal value As Integer)
            _SubjectCategory = value
        End Set
    End Property

    Sub New(ByVal Course As Integer, ByVal subject As Integer, ByVal theory As Double, ByVal Lab As Double, ByVal Project As Double, ByVal Semester As Integer, ByVal id As Integer)
        _Course = Course
        _subject = subject
        _theory = theory
        _Lab = Lab
        _Project = Project
        _Semester = Semester
        _id = id
    End Sub
    Sub New()

    End Sub
End Class
