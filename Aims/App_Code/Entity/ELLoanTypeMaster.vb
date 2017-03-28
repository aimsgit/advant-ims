Imports Microsoft.VisualBasic

Public Class ELLoanTypeMaster
    Private _LoanCode As String
    Public Property LoanCode() As String
        Get
            Return _LoanCode
        End Get
        Set(ByVal value As String)
            _LoanCode = value
        End Set
    End Property
    Private _LoanType As String
    Public Property LoanType() As String
        Get
            Return _LoanType
        End Get
        Set(ByVal value As String)
            _LoanType = value
        End Set
    End Property
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set

    End Property
End Class



