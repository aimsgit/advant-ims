Imports Microsoft.VisualBasic

Public Class ELBatchSemester
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
    Private _GradePoint As String
    Public Property GradePoint() As String
        Get
            Return _GradePoint
        End Get
        Set(ByVal value As String)
            _GradePoint = value
        End Set
    End Property
    Private _Credit As String
    Public Property Credit() As String
        Get
            Return _Credit
        End Get
        Set(ByVal value As String)
            _Credit = value
        End Set
    End Property
    Private _CGPA As String
    Public Property CGPA() As String
        Get
            Return _CGPA
        End Get
        Set(ByVal value As String)
            _CGPA = value
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

    Private _StdId As Integer
    Public Property StdId() As Integer
        Get
            Return _StdId
        End Get
        Set(ByVal value As Integer)
            _StdId = value
        End Set
    End Property
End Class
