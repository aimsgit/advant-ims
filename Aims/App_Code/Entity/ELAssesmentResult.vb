Imports Microsoft.VisualBasic

Public Class ELAssesmentResult
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _BestOf As Integer
    Public Property BestOf() As Integer
        Get
            Return _BestOf
        End Get
        Set(ByVal value As Integer)
            _BestOf = value
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
    Private _Academicyr As Integer
    Public Property Academicyr() As Integer
        Get
            Return _Academicyr
        End Get
        Set(ByVal value As Integer)
            _Academicyr = value
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
    Private _TotalMarksPer As Double
    Public Property TotalMarksPer() As Double
        Get
            Return _TotalMarksPer
        End Get
        Set(ByVal value As Double)
            _TotalMarksPer = value
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
    Private _MinMarks As Double
    Public Property MinMarks() As Double
        Get
            Return _MinMarks
        End Get
        Set(ByVal value As Double)
            _MinMarks = value
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
    Private _Asses As Integer
    Public Property Asses() As Integer
        Get
            Return _Asses
        End Get
        Set(ByVal value As Integer)
            _Asses = value
        End Set
    End Property
    Private _AssesmentId As String
    Public Property AssesmentId() As String
        Get
            Return _AssesmentId
        End Get
        Set(ByVal value As String)
            _AssesmentId = value
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
    Private _sem1 As Integer
    Public Property sem1() As Integer
        Get
            Return _sem1
        End Get
        Set(ByVal value As Integer)
            _sem1 = value
        End Set
    End Property
    Private _Ass1 As Integer
    Public Property Ass1() As Integer
        Get
            Return _Ass1
        End Get
        Set(ByVal value As Integer)
            _Ass1 = value
        End Set
    End Property
    Private _Ass2 As Integer
    Public Property Ass2() As Integer
        Get
            Return _Ass2
        End Get
        Set(ByVal value As Integer)
            _Ass2 = value
        End Set
    End Property
    Private _Ass3 As Integer
    Public Property Ass3() As Integer
        Get
            Return _Ass3
        End Get
        Set(ByVal value As Integer)
            _Ass3 = value
        End Set
    End Property
    Private _Ass4 As Integer
    Public Property Ass4() As Integer
        Get
            Return _Ass4
        End Get
        Set(ByVal value As Integer)
            _Ass4 = value
        End Set
    End Property
    Private _Ass5 As Integer
    Public Property Ass5() As Integer
        Get
            Return _Ass5
        End Get
        Set(ByVal value As Integer)
            _Ass5 = value
        End Set
    End Property
    Private _Ass6 As Integer
    Public Property Ass6() As Integer
        Get
            Return _Ass6
        End Get
        Set(ByVal value As Integer)
            _Ass6 = value
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
End Class
