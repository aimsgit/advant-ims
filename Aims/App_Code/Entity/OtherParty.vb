Imports Microsoft.VisualBasic

Public Class OtherParty
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _opid As String
    Public Property Opid() As String
        Get
            Return _opid
        End Get
        Set(ByVal value As String)
            _opid = value
        End Set
    End Property
    Private _FaxNO As String
    Public Property FaxNO() As String
        Get
            Return _FaxNO
        End Get
        Set(ByVal value As String)
            _FaxNO = value
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
    Private _city As String
    Public Property City() As String
        Get
            Return _city
        End Get
        Set(ByVal value As String)
            _city = value
        End Set
    End Property
    Private _state As Integer
    Public Property State() As Integer
        Get
            Return _state
        End Get
        Set(ByVal value As Integer)
            _state = value
        End Set
    End Property
    Private _pcode As String
    Public Property Pcode() As String
        Get
            Return _pcode
        End Get
        Set(ByVal value As String)
            _pcode = value
        End Set
    End Property
    Private _country As String
    Public Property Country() As String
        Get
            Return _country
        End Get
        Set(ByVal value As String)
            _country = value
        End Set
    End Property
    Private _contactperson As String
    Public Property Contactperson() As String
        Get
            Return _contactperson
        End Get
        Set(ByVal value As String)
            _contactperson = value
        End Set
    End Property
    Private _contactno As String
    Public Property Contactno() As String
        Get
            Return _contactno
        End Get
        Set(ByVal value As String)
            _contactno = value
        End Set
    End Property
    Private _email As String
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property
    Private _creditperiod As Long
    Public Property Creditperiod() As Long
        Get
            Return _creditperiod
        End Get
        Set(ByVal value As Long)
            _creditperiod = value
        End Set
    End Property
    Private _creditlimit As Long
    Public Property Creditlimit() As Long
        Get
            Return _creditlimit
        End Get
        Set(ByVal value As Long)
            _creditlimit = value
        End Set
    End Property
    Private _openingbalanceCR As Long
    Public Property OpeningBalanceCR() As Long
        Get
            Return _openingbalanceCR
        End Get
        Set(ByVal value As Long)
            _openingbalanceCR = value
        End Set
    End Property
    Private _openingbalanceDR As Long
    Public Property OpeningBalanceDR() As Long
        Get
            Return _openingbalanceDR
        End Get
        Set(ByVal value As Long)
            _openingbalanceDR = value
        End Set
    End Property
    Private _opbalancedate As Date
    Public Property OpBalanceDate() As Date
        Get
            Return _opbalancedate
        End Get
        Set(ByVal value As Date)
            _opbalancedate = value
        End Set
    End Property
    Private _remark As String
    Public Property Remark() As String
        Get
            Return _remark
        End Get
        Set(ByVal value As String)
            _remark = value
        End Set
    End Property
    'Public Sub New()

    'End Sub
    'Public Sub New(ByVal id As Integer, ByVal opid As String, ByVal name As String, ByVal address As String, ByVal city As String, ByVal state As String, ByVal pcode As String, ByVal country As String, ByVal contactperson As String, ByVal contactno As String, ByVal email As String, ByVal creditperiod As Long, ByVal creditlimit As Long, ByVal openingbalanceCR As Long, ByVal openingbalanceDR As Long, ByVal opbalancedate As Date, ByVal remark As String)
    '    _id = id
    '    _opid = opid
    '    _name = name
    '    _address = address
    '    _city = city
    '    _state = state
    '    _pcode = pcode
    '    _country = country
    '    _contactperson = contactperson
    '    _contactno = contactno
    '    _email = email
    '    _creditperiod = creditperiod
    '    _creditlimit = creditlimit
    '    _openingbalanceCR = openingbalanceCR
    '    _openingbalanceDR = openingbalanceDR
    '    _opbalancedate = opbalancedate
    '    _remark = remark
    'End Sub
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
