Imports Microsoft.VisualBasic

Public Class CertificateIssuedLateral
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
    Private _marks As String
    Public Property Marks() As String
        Get
            Return _marks
        End Get
        Set(ByVal value As String)
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
    Public Sub New(ByVal id As Long, ByVal std_code As String, ByVal name As String, ByVal board_Univ As String, ByVal marks As String, ByVal yearofPassing As String)
        _id = id
        _std_code = std_code
        _qname = name
        _board_Univ = board_Univ
        _marks = marks
        _yearofPassing = yearofPassing
    End Sub
    Public Sub New()
    End Sub
End Class
