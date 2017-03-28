Imports Microsoft.VisualBasic

Public Class CompanyDetails
    Private _id As Long
    Private _name As String
    Private _contactperson As String
    Private _contactno As String
    Private _address As String
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
    Public Property Address() As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
        End Set
    End Property
End Class
