Imports Microsoft.VisualBasic

Public Class MfgStkstatus




    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            value = _id
        End Set
    End Property
    Private _productname As String

    Public Property ProdName() As String
        Get
            Return _productname
        End Get
        Set(ByVal value As String)
            value = _productname
        End Set
    End Property
    Private _godownno As Integer

    Public Property GodownNo() As Integer
        Get
            Return _godownno
        End Get
        Set(ByVal value As Integer)
            value = _godownno
        End Set
    End Property
    Private _rackno As Integer

    Public Property RackNo() As Integer
        Get
            Return _rackno
        End Get
        Set(ByVal value As Integer)
            value = _rackno
        End Set
    End Property
    Private _startdate As Date

    Public Property StartDate() As Date
        Get
            Return _startdate
        End Get
        Set(ByVal value As Date)
            value = _startdate
        End Set
    End Property
    Private _enddate As Date
    Public Property EndDate() As Date
        Get
            Return _enddate
        End Get
        Set(ByVal value As Date)
            value = _enddate
        End Set
    End Property




End Class
