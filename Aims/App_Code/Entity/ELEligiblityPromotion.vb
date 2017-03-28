Imports Microsoft.VisualBasic

Public Class ELEligiblityPromotion
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _StdId As String
    Public Property StdId() As String
        Get
            Return _StdId
        End Get
        Set(ByVal value As String)
            _StdId = value
        End Set
    End Property
    Private _StdCode As String
    Public Property StdCode() As String
        Get
            Return _StdCode
        End Get
        Set(ByVal value As String)
            _StdCode = value
        End Set
    End Property
    Private _Assisment As Integer
    Public Property Assisment() As Integer
        Get
            Return _Assisment
        End Get
        Set(ByVal value As Integer)
            _Assisment = value
        End Set
    End Property

    Private _NoofSubject As Integer
    Public Property NoofSubject() As Integer
        Get
            Return _NoofSubject
        End Get
        Set(ByVal value As Integer)
            _NoofSubject = value
        End Set
    End Property
    Private _SBatchid As Integer
    Public Property SBatchid() As Integer
        Get
            Return _SBatchid
        End Get
        Set(ByVal value As Integer)
            _SBatchid = value
        End Set
    End Property
    Private _TBatchid As Integer
    Public Property TBatchid() As Integer
        Get
            Return _TBatchid
        End Get
        Set(ByVal value As Integer)
            _TBatchid = value
        End Set
    End Property
    Private _Semid As Integer
    Public Property Semid() As Integer
        Get
            Return _Semid
        End Get
        Set(ByVal value As Integer)
            _Semid = value
        End Set
    End Property
    Private _Semid2 As Integer
    Public Property Semid2() As Integer
        Get
            Return _Semid2
        End Get
        Set(ByVal value As Integer)
            _Semid2 = value
        End Set
    End Property
    Private _SFailed As Integer
    Public Property SFailed() As Integer
        Get
            Return _SFailed
        End Get
        Set(ByVal value As Integer)
            _SFailed = value
        End Set
    End Property

End Class
