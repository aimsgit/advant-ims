Imports Microsoft.VisualBasic

Public Class Prospectus
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _institute As Long
    Public Property Institute() As Long
        Get
            Return _institute
        End Get
        Set(ByVal value As Long)
            _institute = value
        End Set
    End Property
    Private _branch As Long
    Public Property Branch() As Long
        Get
            Return _branch
        End Get
        Set(ByVal value As Long)
            _branch = value
        End Set
    End Property
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
    Public Property Quantity() As Long
        Get
            Return _quantity
        End Get
        Set(ByVal value As Long)
            _quantity = value
        End Set
    End Property
    Private _serialno As String
    Public Property SerialNo() As String
        Get
            Return _serialno
        End Get
        Set(ByVal value As String)
            _serialno = value
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
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
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
    Private _admissionflag As Int32
    Public Property AdmissionFlag() As Int32
        Get
            Return _admissionflag
        End Get
        Set(ByVal value As Int32)
            _admissionflag = value
        End Set
    End Property
    Private _Qty_In As String
    Public Property Qty_In() As String
        Get
            Return _Qty_In
        End Get
        Set(ByVal value As String)
            _Qty_In = value
        End Set
    End Property
    Private _Qty_Out As String
    Public Property Qty_Out() As String
        Get
            Return _Qty_Out
        End Get
        Set(ByVal value As String)
            _Qty_Out = value
        End Set
    End Property
    Private _psid As Int16
    Public Property PSID() As Int16
        Get
            Return _psid
        End Get
        Set(ByVal value As Int16)
            _psid = value
        End Set
    End Property
    Private _eid As Int16
    Public Property EID() As Int16
        Get
            Return _eid
        End Get
        Set(ByVal value As Int16)
            _eid = value
        End Set
    End Property
    Private _ProspectusStatus As String
    Public Property ProspectusStatus() As String
        Get
            Return _ProspectusStatus
        End Get
        Set(ByVal value As String)
            _ProspectusStatus = value
        End Set
    End Property
    Private _Complementary As Boolean
    Public Property Complementary() As Boolean
        Get
            Return _Complementary
        End Get
        Set(ByVal value As Boolean)
            _Complementary = value
        End Set
    End Property
    Public Sub New(ByVal id As Long, ByVal institute As Long, ByVal branch As Long, ByVal entrydate As Date, ByVal price As Long, ByVal remarks As String, ByVal name As String, ByVal serialno As String, ByVal quantity As Integer, ByVal preceiptno As String, ByVal Qty_In As String, ByVal Qty_Out As String)
        _id = id
        _institute = institute
        _branch = branch
        _entrydate = entrydate
        _serialno = serialno
        _price = price
        _remarks = remarks
        _name = name
        _preceiptno = preceiptno
        _Qty_In = Qty_In
        _Qty_Out = Qty_Out
        If Qty_In > 0 Then
            _psid = 2
        ElseIf Qty_Out > 0 Then
            _psid = 1
        End If
        _quantity = quantity * _psid
    End Sub
    Public Sub New(ByVal id As Long, ByVal institute As Long, ByVal branch As Long, ByVal entrydate As Date, ByVal price As Long, ByVal remarks As String, ByVal name As String, ByVal serialno As String, ByVal quantity As Integer, ByVal preceiptno As String, ByVal admissionflag As Int32, ByVal Qty_In As String, ByVal Qty_Out As String)
        _id = id
        _institute = institute
        _branch = branch
        _entrydate = entrydate
        _serialno = serialno
        _price = price
        _remarks = remarks
        _name = name
        _preceiptno = preceiptno
        _admissionflag = admissionflag
        _Qty_In = Qty_In
        _Qty_Out = Qty_Out
        If Qty_In > 0 Then
            _psid = 2
        ElseIf Qty_Out > 0 Then
            _psid = 1
        End If
        _quantity = quantity * _psid
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
    Public Sub New(ByVal id As Long, ByVal institute As Long, ByVal branch As Long, ByVal entrydate As Date, ByVal price As Long, ByVal remarks As String, ByVal name As String, ByVal serialno As String, ByVal quantity As Integer, ByVal preceiptno As String)
        _id = id
        _institute = institute
        _branch = branch
        _entrydate = entrydate
        _serialno = serialno
        _price = price
        _remarks = remarks
        _name = name
        _quantity = quantity
        _preceiptno = preceiptno
    End Sub
    Public Sub New()

    End Sub
End Class
