Imports Microsoft.VisualBasic

Public Class ELOverTime
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Private _Month As String
    Public Property Month() As String
        Get
            Return _Month

        End Get
        Set(ByVal value As String)
            _Month = value
        End Set
    End Property
    Private _EmpNo As String
    Public Property EmpNo() As String
        Get
            Return _EmpNo

        End Get
        Set(ByVal value As String)
            _EmpNo = value
        End Set
    End Property
    Private _EmpName As String
    Public Property EmpName() As String
        Get
            Return _EmpName

        End Get
        Set(ByVal value As String)
            _EmpName = value
        End Set
    End Property
    Private _BasicSal As Integer
    Public Property BasicSal() As Integer
        Get
            Return _BasicSal

        End Get
        Set(ByVal value As Integer)
            _BasicSal = value
        End Set
    End Property

    Private _OTRate As Double
    Public Property OTRate() As Double
        Get
            Return _OTRate

        End Get
        Set(ByVal value As Double)
            _OTRate = value
        End Set
    End Property

    Private _DeptName As String
    Public Property DeptName() As String
        Get
            Return _DeptName

        End Get
        Set(ByVal value As String)
            _DeptName = value
        End Set
    End Property
    Private _VoucherNo As String
    Public Property VoucherNo() As String
        Get
            Return _VoucherNo

        End Get
        Set(ByVal value As String)
            _VoucherNo = value
        End Set
    End Property
    Private _TotAmount As Double
    Public Property TotAmount() As Double
        Get
            Return _TotAmount

        End Get
        Set(ByVal value As Double)
            _TotAmount = value
        End Set
    End Property
    Private _NoOfHours As Double
    Public Property NoOfHours() As Double
        Get
            Return _NoOfHours

        End Get
        Set(ByVal value As Double)
            _NoOfHours = value
        End Set
    End Property
    Private _NoOfMinutes As Double
    Public Property NoOfMinutes() As Double
        Get
            Return _NoOfMinutes

        End Get
        Set(ByVal value As Double)
            _NoOfMinutes = value
        End Set
    End Property
End Class
