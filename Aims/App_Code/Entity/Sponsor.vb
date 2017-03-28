Imports Microsoft.VisualBasic
Public Class Sponsor
    Private _Sponsor_ID As Long
    Public Property Sponsor_ID() As Long
        Get
            Return _Sponsor_ID
        End Get
        Set(ByVal value As Long)
            _Sponsor_ID = value
        End Set
    End Property
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
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
    Private _contactno As String
    Public Property ContactNo() As String
        Get
            Return _contactno
        End Get
        Set(ByVal value As String)
            _contactno = value
        End Set
    End Property
    Private _email As String
    Public Property EMail() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property
    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property
    Private _deleteflag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property
    Public Sub New(ByVal Sponsor_ID As Long, ByVal name As String, ByVal address As String, ByVal contactno As String, ByVal email As String, ByVal remarks As String)
        _Sponsor_ID = Sponsor_ID
        _name = name
        _address = address
        _contactno = contactno
        _email = email
        _remarks = remarks
    End Sub
    Public Sub New(ByVal Sponsor_ID As Long, ByVal name As String)
        _Sponsor_ID = Sponsor_ID
        _name = name
    End Sub
    Public Sub New()
    End Sub
End Class
