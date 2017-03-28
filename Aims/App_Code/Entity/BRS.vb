Imports Microsoft.VisualBasic

Public Class BRSEntity
    Private _table As String
    Public Property table() As String
        Get
            Return _table
        End Get
        Set(ByVal value As String)
            _table = value
        End Set
    End Property
    Private _StatusFlag As String
    Public Property StatusFlag() As String
        Get
            Return _StatusFlag
        End Get
        Set(ByVal value As String)
            _StatusFlag = value
        End Set
    End Property
    Private _BounceStatus As String
    Public Property BounceStatus() As String
        Get
            Return _BounceStatus
        End Get
        Set(ByVal value As String)
            _BounceStatus = value
        End Set
    End Property
    Private _FromDate As Date
    Public Property FromDate() As Date
        Get
            Return _FromDate
        End Get
        Set(ByVal value As Date)
            _FromDate = value
        End Set
    End Property
    Private _Clearing_Date As Date
    Public Property Clearing_Date() As Date
        Get
            Return _Clearing_Date
        End Get
        Set(ByVal value As Date)
            _Clearing_Date = value
        End Set
    End Property
    Private _ChequeBounce_Date As Date
    Public Property ChequeBounce_Date() As Date
        Get
            Return _ChequeBounce_Date
        End Get
        Set(ByVal value As Date)
            _ChequeBounce_Date = value
        End Set
    End Property
    Private _ToDate As Date
    Public Property ToDate() As Date
        Get
            Return _ToDate
        End Get
        Set(ByVal value As Date)
            _ToDate = value
        End Set
    End Property
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
End Class
