Imports Microsoft.VisualBasic

Public Class Batch
    Private _BatchID As Long
    Public Property BatchID() As Long
        Get
            Return _BatchID
        End Get
        Set(ByVal value As Long)
            _BatchID = value
        End Set
    End Property


    Private _BatchName As String
    Public Property BatchName() As String
        Get
            Return _BatchName
        End Get
        Set(ByVal value As String)
            _BatchName = value
        End Set
    End Property


    Private _DelFlag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _DelFlag
        End Get
        Set(ByVal value As Int16)
            _DelFlag = value
        End Set
    End Property

    Private _sessioncnt As Int64
    Public Property SessionCnt() As Int64
        Get
            Return _sessioncnt
        End Get
        Set(ByVal value As Int64)
            _sessioncnt = value
        End Set
    End Property

    Private _sessioncntDaily As Int32
    Public Property SessionCntDaily() As Int32
        Get
            Return _sessioncntDaily
        End Get
        Set(ByVal value As Int32)
            _sessioncntDaily = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal Batchid As Long, ByVal BatchName As String)
        _BatchID = Batchid
        _BatchName = BatchName
    End Sub

    Public Sub New(ByVal Batchid As Long, ByVal sessioncnt As Int64, ByVal sessioncntDaily As Int32)
        _BatchID = Batchid
        _sessioncnt = sessioncnt
        _sessioncntDaily = sessioncntDaily
    End Sub
End Class
