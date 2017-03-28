Imports Microsoft.VisualBasic

Public Class Institute

    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
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

    Private _Code As String
    Public Property InstituteCode() As String
        Get
            Return _Code
        End Get
        Set(ByVal value As String)
            _Code = value
        End Set
    End Property

    Private _City As String
    Public Property City() As String
        Get
            Return _City
        End Get
        Set(ByVal value As String)
            _City = value
        End Set
    End Property

    Private _State As String
    Public Property State() As String
        Get
            Return _State
        End Get
        Set(ByVal value As String)
            _State = value
        End Set
    End Property

    Private _Country As String
    Public Property Country() As String
        Get
            Return _Country
        End Get
        Set(ByVal value As String)
            _Country = value
        End Set
    End Property

    'Private _Country As String
    'Public Property Country() As String
    '    Get
    '        Return _Country
    '    End Get
    '    Set(ByVal value As String)
    '        _Country = value
    '    End Set
    'End Property

    Private _ContactNo As String
    Public Property ContactNo() As String
        Get
            Return _ContactNo
        End Get
        Set(ByVal value As String)
            _ContactNo = value
        End Set
    End Property

    Private _ContactPerson As String
    Public Property ContactPerson() As String
        Get
            Return _ContactPerson
        End Get
        Set(ByVal value As String)
            _ContactPerson = value
        End Set
    End Property


    'Private _branchid As Long
    'Public Property BranchId() As Long
    '    Get
    '        Return _branchid
    '    End Get
    '    Set(ByVal value As Long)
    '        _branchid = value
    '    End Set
    'End Property

    Private _deletelag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deletelag
        End Get
        Set(ByVal value As Int16)
            _deletelag = value
        End Set
    End Property

    Public Sub New(ByVal id As Long, ByVal name As String, ByVal address As String, ByVal Code As String, ByVal City As String, ByVal State As String, ByVal Country As String, ByVal ContactNo As String, ByVal ContactPerson As String)
        _id = id
        _name = name
        _address = address
        _Code = Code
        _City = City
        _State = State
        _Country = Country
        _ContactNo = ContactNo
        _ContactPerson = ContactPerson
        '_branchid = branchid
    End Sub

    Public Sub New()

    End Sub

End Class
