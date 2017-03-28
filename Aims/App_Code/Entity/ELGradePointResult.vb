Imports Microsoft.VisualBasic

Public Class ELGradePointResult
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _Assesmentid As Integer
    Public Property Assesmentid() As Integer
        Get
            Return _Assesmentid
        End Get
        Set(ByVal value As Integer)
            _Assesmentid = value
        End Set
    End Property
    Private _batchId As Integer
    Public Property batchId() As Integer
        Get
            Return _batchId
        End Get
        Set(ByVal value As Integer)
            _batchId = value
        End Set
    End Property
    Private _sem As Integer
    Public Property sem() As Integer
        Get
            Return _sem
        End Get
        Set(ByVal value As Integer)
            _sem = value
        End Set
    End Property
    Private _semester As String
    Public Property semester() As String
        Get
            Return _semester
        End Get
        Set(ByVal value As String)
            _semester = value
        End Set
    End Property
    Private _sem1 As Integer
    Public Property sem1() As Integer
        Get
            Return _sem1
        End Get
        Set(ByVal value As Integer)
            _sem1 = value
        End Set
    End Property
    Private _Subject As String
    Public Property Subject() As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
        End Set
    End Property
    Private _Result As String
    Public Property Result() As String
        Get
            Return _Result
        End Get
        Set(ByVal value As String)
            _Result = value
        End Set
    End Property
    Private _TotalMarks As Double
    Public Property TotalMarks() As Double
        Get
            Return _TotalMarks
        End Get
        Set(ByVal value As Double)
            _TotalMarks = value
        End Set
    End Property
    Private _Percentage As Double
    Public Property Percentage() As Double
        Get
            Return _Percentage
        End Get
        Set(ByVal value As Double)
            _Percentage = value
        End Set
    End Property
    Private _MaxMarks As Double
    Public Property MaxMarks() As Double
        Get
            Return _MaxMarks
        End Get
        Set(ByVal value As Double)
            _MaxMarks = value
        End Set
    End Property
    Private _TotalMarkswithGrace As Double
    Public Property TotalMarkswithGrace() As Double
        Get
            Return _TotalMarkswithGrace
        End Get
        Set(ByVal value As Double)
            _TotalMarkswithGrace = value
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
    Private _Rank As String
    Public Property Rank() As String
        Get
            Return _Rank
        End Get
        Set(ByVal value As String)
            _Rank = value
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

    Private _StdId As Integer
    Public Property StdId() As Integer
        Get
            Return _StdId
        End Get
        Set(ByVal value As Integer)
            _StdId = value
        End Set
    End Property
    Private _CGPA As Double
    Public Property CGPA() As Double
        Get
            Return _CGPA
        End Get
        Set(ByVal value As Double)
            _CGPA = value
        End Set
    End Property
    Private _CreditTotal As Double
    Public Property CreditTotal() As Double
        Get
            Return _CreditTotal
        End Get
        Set(ByVal value As Double)
            _CreditTotal = value
        End Set
    End Property
    Private _CGPA1 As Double
    Public Property CGPA1() As Double
        Get
            Return _CGPA1
        End Get
        Set(ByVal value As Double)
            _CGPA1 = value
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
    Private _GradePoint As Double
    Public Property GradePoint() As Double
        Get
            Return _GradePoint
        End Get
        Set(ByVal value As Double)
            _GradePoint = value
        End Set
    End Property
    Private _Percntage As Double
    Public Property Percntage() As Double
        Get
            Return _Percntage
        End Get
        Set(ByVal value As Double)
            _Percntage = value
        End Set
    End Property
End Class


