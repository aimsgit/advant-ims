Imports Microsoft.VisualBasic

Public Class Pay
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _eid As Long
    Public Property EId() As Long
        Get
            Return _eid
        End Get
        Set(ByVal value As Long)
            _eid = value
        End Set
    End Property
    Private _leavefrom As Date
    Public Property Leavefrom() As Date
        Get
            Return _leavefrom
        End Get
        Set(ByVal value As Date)
            _leavefrom = value
        End Set
    End Property
    Private _leaveto As Date
    Public Property Leaveto() As Date
        Get
            Return _leaveto
        End Get
        Set(ByVal value As Date)
            _leaveto = value
        End Set
    End Property
    Private _leavetype As Long
    Public Property Leavetype() As Long
        Get
            Return _leavetype
        End Get
        Set(ByVal value As Long)
            _leavetype = value
        End Set
    End Property
    Private _approved As Boolean
    Public Property Approved() As Boolean
        Get
            Return _approved
        End Get
        Set(ByVal value As Boolean)
            _approved = value
        End Set
    End Property
    Private _approvedby As String
    Public Property Approvedby() As String
        Get
            Return _approvedby
        End Get
        Set(ByVal value As String)
            _approvedby = value
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
    Private _LossOfPayAmt As Double
    Public Property LossOfPayAmt() As Double
        Get
            Return _LossOfPayAmt
        End Get
        Set(ByVal value As Double)
            _LossOfPayAmt = value
        End Set
    End Property

    Public Sub New(ByVal id As Long, ByVal eid As Long, ByVal leavefrom As Date, ByVal leaveto As Date, ByVal leavetype As Long, ByVal approved As Boolean, ByVal approvedby As String, ByVal remark As String, ByVal LossOfPayAmt As Double)
        _id = id
        _eid = eid
        _leavefrom = leavefrom
        _leaveto = leaveto
        _leavetype = leavetype
        _approved = approved
        _approvedby = approvedby
        _remark = remark
        _LossOfPayAmt = LossOfPayAmt
    End Sub

    Public Sub New()

    End Sub
    Private _deleteflag As Boolean
    Public Property DeleteFlag() As Boolean
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Boolean)
            _deleteflag = value
        End Set
    End Property
End Class
