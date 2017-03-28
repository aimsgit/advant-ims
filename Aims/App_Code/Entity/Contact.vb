Imports Microsoft.VisualBasic

Public Class Contact
    Private _contactId As Integer
    Public Property ContactId() As Integer
        Get
            Return _contactId
        End Get
        Set(ByVal value As Integer)
            _contactId = value
        End Set
    End Property
    Private _firstName As String
    Public Property FirstName() As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
        End Set
    End Property
    Private _lastName As String
    Public Property LastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property
    Private _address As String
    Public Property Address() As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
        End Set
    End Property
    Private _city As String
    Public Property City() As String
        Get
            Return _city
        End Get
        Set(ByVal value As String)
            _city = value
        End Set
    End Property
    Private _state As String
    Public Property State() As String
        Get
            Return _state
        End Get
        Set(ByVal value As String)
            _state = value
        End Set
    End Property
    Private _postalCode As String
    Public Property PostalCode() As String
        Get
            Return _postalCode
        End Get
        Set(ByVal value As String)
            _postalCode = value
        End Set
    End Property
    Public Sub New(ByVal contactId As Int16, ByVal firstName As String, ByVal lastName As String, ByVal address As String, ByVal city As String, ByVal state As String, ByVal postalCode As String)
        _contactId = contactId
        _firstName = firstName
        _lastName = lastName
        _address = address
        _city = city
        _state = state
        _postalCode = postalCode
    End Sub
    Public Sub New()
    End Sub
End Class
