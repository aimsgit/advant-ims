Imports Microsoft.VisualBasic
Public Class Company
    Private _id As Long
    Private _name As String
    Private _contactperson As String
    Private _contactno As String
    Private _address As String
    Private _deleteflag As Int16
    Private _BrnchCode As String
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Public Property ContactPerson() As String
        Get
            Return _contactperson
        End Get
        Set(ByVal value As String)
            _contactperson = value
        End Set
    End Property
    Public Property ContactNo() As String
        Get
            Return _contactno
        End Get
        Set(ByVal value As String)
            _contactno = value
        End Set
    End Property
    Public Property BrnchCode() As String
        Get
            Return _BrnchCode
        End Get
        Set(ByVal value As String)
            _BrnchCode = value
        End Set
    End Property

    Public Property Address() As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
        End Set
    End Property
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property
    Public Sub New()
    End Sub
    Public Sub New(ByVal id As Long, ByVal name As String, ByVal contactperson As String, ByVal contactno As String, ByVal address As String)
        _id = id
        _name = name
        _contactperson = contactperson
        _contactno = contactno
        _address = address


    End Sub
End Class
