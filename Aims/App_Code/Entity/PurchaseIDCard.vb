Imports Microsoft.VisualBasic

Public Class PurchaseIDCard
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    'Private _institute As Long
    'Public Property Institute() As Long
    '    Get
    '        Return _institute
    '    End Get
    '    Set(ByVal value As Long)
    '        _institute = value
    '    End Set
    'End Property
    'Private _branch As Long
    'Public Property Branch() As Long
    '    Get
    '        Return _branch
    '    End Get
    '    Set(ByVal value As Long)
    '        _branch = value
    '    End Set
    'End Property
    Private _entrydate As Date
    Public Property Entrydate() As Date
        Get
            Return _entrydate
        End Get
        Set(ByVal value As Date)
            _entrydate = value
        End Set
    End Property
    Private _quantity As Long
    Public Property Quantity() As String
        Get
            Return _quantity
        End Get
        Set(ByVal value As String)
            _quantity = value
        End Set
    End Property

    Private _price As Long
    Public Property Price() As Long
        Get
            Return _price
        End Get
        Set(ByVal value As Long)
            _price = value
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

    Private _preceiptno As String
    Public Property PreceiptNO() As String
        Get
            Return _preceiptno
        End Get
        Set(ByVal value As String)
            _preceiptno = value
        End Set
    End Property
    Private _admissionflag As String
    Public Property AdmissionFlag() As String
        Get
            Return _admissionflag
        End Get
        Set(ByVal value As String)
            _admissionflag = value
        End Set
    End Property

    Public Sub New()
    End Sub
    Public Sub New(ByVal id As Long, ByVal entrydate As Date, ByVal price As Long, ByVal remarks As String, ByVal quantity As Integer, ByVal preceiptno As String)
        _id = id
        _entrydate = entrydate
        _price = price
        _remarks = remarks

        _quantity = quantity
        _preceiptno = preceiptno
    End Sub
    Public Sub New(ByVal id As Long, ByVal entrydate As Date, ByVal price As Long, ByVal remarks As String, ByVal quantity As Integer, ByVal preceiptno As String, ByVal admissionflag As String)
        _id = id
        _entrydate = entrydate
        _price = price
        _remarks = remarks
        _quantity = quantity
        _preceiptno = preceiptno
        _admissionflag = admissionflag
    End Sub
    Private _deleteflag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property
End Class
