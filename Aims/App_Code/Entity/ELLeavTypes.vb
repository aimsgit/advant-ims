Imports Microsoft.VisualBasic

Public Class ELLeavTypes
    Private _TY_ID As Long
    Public Property TY_ID() As Long
        Get
            Return _TY_ID
        End Get
        Set(ByVal value As Long)
            _TY_ID = value
        End Set
    End Property
    Private _Leave_Type As String
    Public Property Leave_Type() As String
        Get
            Return _Leave_Type
        End Get
        Set(ByVal value As String)
            _Leave_Type = value
        End Set
    End Property
    Private _Leave_TypeCode As String
    Public Property Leave_TypeCode() As String
        Get
            Return _Leave_TypeCode
        End Get
        Set(ByVal value As String)
            _Leave_TypeCode = value
        End Set
    End Property
    Private _LeaveDescription As String
    Public Property LeaveDescription() As String
        Get
            Return _LeaveDescription
        End Get
        Set(ByVal value As String)
            _LeaveDescription = value
        End Set
    End Property
    Private _Paid As String
    Public Property Paid() As String
        Get
            Return _Paid
        End Get
        Set(ByVal value As String)
            _Paid = value
        End Set
    End Property
    Public Sub New(ByVal TY_ID As Long, ByVal Leave_Type As String, ByVal LeaveDescription As String)
        _TY_ID = TY_ID
        _Leave_Type = Leave_Type
        _LeaveDescription = LeaveDescription
    End Sub
    Public Sub New()
    End Sub
    Private _delflag As Int16
    Public Property Del_flag() As Int16
        Get
            Return _delflag
        End Get
        Set(ByVal value As Int16)
            _delflag = value
        End Set
    End Property
    Private _LeaveFor As String
    Public Property LeaveFor() As String
        Get
            Return _LeaveFor
        End Get
        Set(ByVal value As String)
            _LeaveFor = value
        End Set
    End Property
End Class
