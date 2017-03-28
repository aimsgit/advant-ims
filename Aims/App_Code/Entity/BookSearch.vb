Imports Microsoft.VisualBasic

Public Class BookSearch
    Private _id As Int64
    Public Property ID() As Int64
        Get
            Return _id
        End Get
        Set(ByVal value As Int64)
            _id = value
        End Set
    End Property
    Private _BookName As String
    Public Property BookName() As String
        Get
            Return _BookName
        End Get
        Set(ByVal value As String)
            _BookName = value
        End Set
    End Property
    Private _Classification As String
    Public Property Classification() As String
        Get
            Return _Classification
        End Get
        Set(ByVal value As String)
            _Classification = value
        End Set
    End Property
    Private _bookAuthor As String
    Public Property BookAuthor() As String
        Get
            Return _bookAuthor
        End Get
        Set(ByVal value As String)
            _bookAuthor = value
        End Set
    End Property
    Private _Publisher As String
    Public Property publisher() As String
        Get
            Return _Publisher
        End Get
        Set(ByVal value As String)
            _Publisher = value
        End Set
    End Property
    Private _BookCode As String
    Public Property BookCode() As String
        Get
            Return _BookCode
        End Get
        Set(ByVal value As String)
            _BookCode = value
        End Set
    End Property
    Private _Ins As Int64
    Public Property ins() As Int64
        Get
            Return _Ins
        End Get
        Set(ByVal value As Int64)
            _Ins = value
        End Set
    End Property
    Private _Brn As Int64
    Public Property Brn() As Int64
        Get
            Return _Brn
        End Get
        Set(ByVal value As Int64)
            _Brn = value
        End Set
    End Property
    Private _Dept As Int64
    Public Property Dept() As Int64
        Get
            Return _Dept
        End Get
        Set(ByVal value As Int64)
            _Dept = value
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
    Private _Branch As String
    Public Property Branch() As String
        Get
            Return _Branch
        End Get
        Set(ByVal value As String)
            _Branch = value
        End Set
    End Property
    Private _Isbnno As String
    Public Property Isbno() As String
        Get
            Return _Isbnno
        End Get
        Set(ByVal value As String)
            _Isbnno = value
        End Set
    End Property
    Private _BookId As Integer
    Public Property BookId() As Integer
        Get
            Return _BookId
        End Get
        Set(ByVal value As Integer)
            _BookId = value
        End Set
    End Property
End Class
