Imports Microsoft.VisualBasic
Public Class Qualification
    Private _id As Long
    Public Property Qualification_ID() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _std_code As String
    Public Property Std_code() As String
        Get
            Return _std_code
        End Get
        Set(ByVal value As String)
            _std_code = value
        End Set
    End Property
    Private _qname As String
    Public Property Name() As String
        Get
            Return _qname
        End Get
        Set(ByVal value As String)
            _qname = value
        End Set
    End Property
    Private _board_Univ As String
    Public Property Board_Univ() As String
        Get
            Return _board_Univ
        End Get
        Set(ByVal value As String)
            _board_Univ = value
        End Set
    End Property
    Private _marks As Double
    Public Property Marks() As Double
        Get
            Return _marks
        End Get
        Set(ByVal value As Double)
            _marks = value
        End Set
    End Property
    Private _yearofPassing As String
    Public Property YearofPassing() As String
        Get
            Return _yearofPassing
        End Get
        Set(ByVal value As String)
            _yearofPassing = value
        End Set
    End Property
    Private _subcertificate As String
    Public Property Subcertificate() As String
        Get
            Return _subcertificate
        End Get
        Set(ByVal value As String)
            _subcertificate = value
        End Set

    End Property

    Private _TotalMarks As String
    Public Property TotalMarks() As String
        Get
            Return _TotalMarks
        End Get
        Set(ByVal value As String)
            _TotalMarks = value
        End Set
    End Property
    Private _Subject1 As String
    Public Property Subject1() As String
        Get
            Return _Subject1
        End Get
        Set(ByVal value As String)
            _Subject1 = value
        End Set
    End Property
    Private _Subject2 As String
    Public Property Subject2() As String
        Get
            Return _Subject2
        End Get
        Set(ByVal value As String)
            _Subject2 = value
        End Set
    End Property
    Private _Subject3 As String
    Public Property Subject3() As String
        Get
            Return _Subject3
        End Get
        Set(ByVal value As String)
            _Subject3 = value
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
    Private _Medium As String
    Public Property Medium() As String
        Get
            Return _Medium
        End Get
        Set(ByVal value As String)
            _Medium = value
        End Set
    End Property
    Private _AdminDistrict As String
    Public Property AdminDistrict() As String
        Get
            Return _AdminDistrict
        End Get
        Set(ByVal value As String)
            _AdminDistrict = value
        End Set
    End Property
    Private _Zindex As String
    Public Property Zindex() As String
        Get
            Return _Zindex
        End Get
        Set(ByVal value As String)
            _Zindex = value
        End Set
    End Property
    Private _Stream As String
    Public Property Stream() As String
        Get
            Return _Stream
        End Get
        Set(ByVal value As String)
            _Stream = value
        End Set
    End Property
    Private _Attempt As Integer
    Public Property Attempt() As Integer
        Get
            Return _Attempt
        End Get
        Set(ByVal value As Integer)
            _Attempt = value
        End Set
    End Property






    Public Sub New(ByVal id As Long, ByVal std_code As String, ByVal name As String, ByVal board_Univ As String, ByVal marks As String, ByVal yearofPassing As String, ByVal subcertificate As String)
        _id = id
        _std_code = std_code
        _qname = name
        _board_Univ = board_Univ
        _marks = marks
        _yearofPassing = yearofPassing
        _subcertificate = subcertificate
    End Sub
    Public Sub New()
    End Sub
End Class

