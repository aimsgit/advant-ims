Imports Microsoft.VisualBasic

Public Class ELFrmCollectSponsor
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _SpId As Integer
    Public Property SpId() As Integer
        Get
            Return _SpId
        End Get
        Set(ByVal value As Integer)
            _SpId = value
        End Set
    End Property
    Private _amount As Double
    Public Property amount() As Double
        Get
            Return _amount
        End Get
        Set(ByVal value As Double)
            _amount = value
        End Set
    End Property
    Private _Mode As Integer
    Public Property mode() As Integer
        Get
            Return _Mode
        End Get
        Set(ByVal value As Integer)
            _Mode = value
        End Set
    End Property
    Private _chqno As String
    Public Property chqno() As String
        Get
            Return _chqno
        End Get
        Set(ByVal value As String)
            _chqno = value
        End Set
    End Property
    Private _chqdate As Date
    Public Property chqdate() As Date
        Get
            Return _chqdate
        End Get
        Set(ByVal value As Date)
            _chqdate = value
        End Set
    End Property
    Private _date1 As Date
    Public Property date1() As Date
        Get
            Return _date1
        End Get
        Set(ByVal value As Date)
            _date1 = value
        End Set
    End Property
    Private _refund As String
    Public Property refund() As String
        Get
            Return _refund
        End Get
        Set(ByVal value As String)
            _refund = value
        End Set
    End Property
    Private _TRF As String
    Public Property TRF() As String
        Get
            Return _TRF
        End Get
        Set(ByVal value As String)
            _TRF = value
        End Set
    End Property
    Private _Branchcode As String
    Public Property Branchcode() As String
        Get
            Return _Branchcode
        End Get
        Set(ByVal value As String)
            _Branchcode = value
        End Set
    End Property
    Private _remarks As String
    Public Property remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property
    Private _SId As Integer
    Public Property SId() As Integer
        Get
            Return _SId
        End Get
        Set(ByVal value As Integer)
            _SId = value
        End Set
    End Property
    Private _Batch As Integer
    Public Property Batch() As Integer
        Get
            Return _Batch
        End Get
        Set(ByVal value As Integer)
            _Batch = value
        End Set
    End Property
    Private _academic As Integer
    Public Property academic() As Integer
        Get
            Return _academic
        End Get
        Set(ByVal value As Integer)
            _academic = value
        End Set
    End Property
    Private _STDID As Integer
    Public Property STDID() As Integer
        Get
            Return _STDID
        End Get
        Set(ByVal value As Integer)
            _STDID = value
        End Set
    End Property
    Private _Sname As String
    Public Property Sname() As String
        Get
            Return _Sname
        End Get
        Set(ByVal value As String)
            _Sname = value
        End Set
    End Property
    Private _ref As String
    Public Property ref() As String
        Get
            Return _ref
        End Get
        Set(ByVal value As String)
            _ref = value
        End Set
    End Property
    Private _Category As Integer
    Public Property Category() As Integer
        Get
            Return _Category
        End Get
        Set(ByVal value As Integer)
            _Category = value
        End Set
    End Property

End Class
