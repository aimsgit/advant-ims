Imports Microsoft.VisualBasic

Public Class ELGradeMaster
    Private _CourseName As Integer
    Public Property CourseName() As Integer
        Get
            Return _CourseName
        End Get
        Set(ByVal value As Integer)
            _CourseName = value
        End Set
    End Property
    Private _Min As Double
    Public Property Min() As Double
        Get
            Return _Min
        End Get
        Set(ByVal value As Double)
            _Min = value
        End Set
    End Property
    Private _Max As Double
    Public Property Max() As Double
        Get
            Return _Max
        End Get
        Set(ByVal value As Double)
            _Max = value
        End Set
    End Property
    Private _Grade As String
    Public Property Grade() As String
        Get
            Return _Grade
        End Get
        Set(ByVal value As String)
            _Grade = value
        End Set
    End Property
    Private _GradePoint As Double
    Public Property GradePoint() As Double
        Get
            Return _GradePoint
        End Get
        Set(ByVal value As Double)
            _GradePoint = value
        End Set
    End Property
    Private _Division As String
    Public Property Division() As String
        Get
            Return _Division
        End Get
        Set(ByVal value As String)
            _Division = value
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
