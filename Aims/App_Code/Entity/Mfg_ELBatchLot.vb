Imports Microsoft.VisualBasic

Public Class Mfg_ELBatchLot
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Batch As String
    Public Property Batch() As String
        Get
            Return _Batch
        End Get
        Set(ByVal value As String)
            _Batch = value
        End Set
    End Property
    Private _MfgDate As DateTime
    Public Property MfgDate() As DateTime
        Get
            Return _MfgDate
        End Get
        Set(ByVal value As DateTime)
            _MfgDate = value
        End Set
    End Property
    Private _Productid As Integer
    Public Property Productid() As Integer
        Get
            Return _Productid
        End Get
        Set(ByVal value As Integer)
            _Productid = value
        End Set
    End Property
    Private _Processid As Integer
    Public Property Processid() As Integer
        Get
            Return _Processid
        End Get
        Set(ByVal value As Integer)
            _Processid = value
        End Set
    End Property
    Private _Issueid As String
    Public Property Issueid() As String
        Get
            Return _Issueid
        End Get
        Set(ByVal value As String)
            _Issueid = value
        End Set
    End Property
    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
End Class
