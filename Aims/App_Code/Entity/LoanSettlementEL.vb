Imports Microsoft.VisualBasic

Public Class LoanSettlementEL
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Private _EmpNo As Integer
    Public Property EmpNo() As Integer
        Get
            Return _EmpNo

        End Get
        Set(ByVal value As Integer)
            _EmpNo = value
        End Set
    End Property
    Private _LoanTypeCode As Integer
    Public Property LoanTypeCode() As Integer
        Get
            Return _LoanTypeCode

        End Get
        Set(ByVal value As Integer)
            _LoanTypeCode = value
        End Set
    End Property

    Private _SType As String
    Public Property SType() As String
        Get
            Return _SType

        End Get
        Set(ByVal value As String)
            _SType = value
        End Set
    End Property
    Private _SMethod As String
    Public Property SMethod() As String
        Get
            Return _SMethod

        End Get
        Set(ByVal value As String)
            _SMethod = value
        End Set
    End Property
    Private _SAmount As Double
    Public Property SAmount() As Double
        Get
            Return _SAmount

        End Get
        Set(ByVal value As Double)
            _SAmount = value
        End Set
    End Property
    Private _NoOfInstl As Integer
    Public Property NoOfInstl() As Integer
        Get
            Return _NoOfInstl

        End Get
        Set(ByVal value As Integer)
            _NoOfInstl = value
        End Set
    End Property
    Private _LoanSettlementDate As DateTime
    Public Property LoanSettlementDate() As DateTime
        Get
            Return _LoanSettlementDate

        End Get
        Set(ByVal value As DateTime)
            _LoanSettlementDate = value
        End Set
    End Property

End Class
