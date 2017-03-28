Imports Microsoft.VisualBasic

Public Class ELRollOver
    Private _Academicyr As Int64
    Public Property Academicyr() As Integer
        Get
            Return _Academicyr
        End Get
        Set(ByVal value As Integer)
            _Academicyr = value
        End Set
    End Property
    Private _date As Date
    Public Property Tdate() As Date
        Get
            Return _date
        End Get
        Set(ByVal value As Date)
            _date = value
        End Set
    End Property
    Private _BatchId As Integer
    Public Property BatchId() As Integer
        Get
            Return _BatchId
        End Get
        Set(ByVal value As Integer)
            _BatchId = value
        End Set
    End Property
    Private _StdCode As String
    Public Property StdCode() As String
        Get
            Return _StdCode
        End Get
        Set(ByVal value As String)
            _StdCode = value
        End Set
    End Property
    Private _ToBatchId As Integer
    Public Property ToBatchId() As Integer
        Get
            Return _ToBatchId
        End Get
        Set(ByVal value As Integer)
            _ToBatchId = value
        End Set
    End Property
    Private _CourseId As String
    Public Property CourseId() As String
        Get
            Return _CourseId
        End Get
        Set(ByVal value As String)
            _CourseId = value
        End Set
    End Property
    Private _Id As String
    Public Property Id() As String
        Get
            Return _Id
        End Get
        Set(ByVal value As String)
            _Id = value
        End Set
    End Property
    Private _Lock As String
    Public Property Lock() As String
        Get
            Return _Lock
        End Get
        Set(ByVal value As String)
            _Lock = value
        End Set
    End Property
    Private _Type As String
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property
    Private _frmbrnch As String
    Public Property FRMBRANCH() As String
        Get
            Return _frmbrnch
        End Get
        Set(ByVal value As String)
            _frmbrnch = value
        End Set
    End Property

    Private _tobranch As String
    Public Property TOBRANCH() As String
        Get
            Return _tobranch
        End Get
        Set(ByVal value As String)
            _tobranch = value
        End Set
    End Property
  
End Class
