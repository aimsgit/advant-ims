Imports Microsoft.VisualBasic

Public Class EmpTransE


    Private _DID As Integer
    Public Property DID() As Integer
        Get
            Return _DID
        End Get
        Set(ByVal value As Integer)
            _DID = value
        End Set
    End Property
    Private _empid As Integer
    Public Property EmpID() As Integer
        Get
            Return _empid
        End Get
        Set(ByVal value As Integer)
            _empid = value
        End Set
    End Property
    Private _empname As String
    Public Property EmpName() As String
        Get
            Return _empname
        End Get
        Set(ByVal value As String)
            _empname = value
        End Set
    End Property
    Private _empcd As String
    Public Property EmpCD() As String
        Get
            Return _empcd
        End Get
        Set(ByVal value As String)
            _empcd = value
        End Set
    End Property

    Private _dol As Date
    Public Property DOL() As Date
        Get
            Return _dol
        End Get
        Set(ByVal value As Date)
            _dol = value
        End Set
    End Property

    Private _doj As Date
    Public Property DOJ() As Date
        Get
            Return _doj
        End Get
        Set(ByVal value As Date)
            _doj = value
        End Set
    End Property

    Private _frmbrnch As String
    Public Property FRMBRANCH() As String
        Get
            Return _frmbrnch
        End Get
        Set(ByVal value As String)
            _frmbrnch = value
        End Set
    End Property

    Private _tobranch As String
    Public Property TOBRANCH() As String
        Get
            Return _tobranch
        End Get
        Set(ByVal value As String)
            _tobranch = value
        End Set
    End Property
    Private _toempcode As String
    Public Property EmpCode() As String
        Get
            Return _toempcode
        End Get
        Set(ByVal value As String)
            _toempcode = value
        End Set
    End Property
    Private _TransferRemarks As String
    Public Property TransferRemarks() As String
        Get
            Return _TransferRemarks
        End Get
        Set(ByVal value As String)
            _TransferRemarks = value
        End Set
    End Property
End Class
