Imports Microsoft.VisualBasic

Public Class Mfg_ElStockIssue
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _EntryDate As DateTime
    Public Property EntryDate() As DateTime
        Get
            Return _EntryDate
        End Get
        Set(ByVal value As DateTime)
            _EntryDate = value
        End Set
    End Property
    Private _PID As Integer
    Public Property PID() As Integer
        Get
            Return _PID
        End Get
        Set(ByVal value As Integer)
            _PID = value
        End Set
    End Property
    Private _PartyName As Integer
    Public Property PartyName() As Integer
        Get
            Return _PartyName
        End Get
        Set(ByVal value As Integer)
            _PartyName = value
        End Set
    End Property
    Private _CV As Integer
    Public Property CV() As Integer
        Get
            Return _CV
        End Get
        Set(ByVal value As Integer)
            _CV = value
        End Set
    End Property
    Private _QtyIssued As Integer
    Public Property QtyIssued() As Integer
        Get
            Return _QtyIssued
        End Get
        Set(ByVal value As Integer)
            _QtyIssued = value
        End Set
    End Property
    Private _QtyReturned As Integer
    Public Property QtyReturned() As Integer
        Get
            Return _QtyReturned
        End Get
        Set(ByVal value As Integer)
            _QtyReturned = value
        End Set
    End Property
    Private _ExpiryDate As DateTime
    Public Property ExpiryDate() As DateTime
        Get
            Return _ExpiryDate
        End Get
        Set(ByVal value As DateTime)
            _ExpiryDate = value
        End Set
    End Property
    Private _PartyType As Integer
    Public Property PartyType() As Integer
        Get
            Return _PartyType
        End Get
        Set(ByVal value As Integer)
            _PartyType = value
        End Set
    End Property
End Class
