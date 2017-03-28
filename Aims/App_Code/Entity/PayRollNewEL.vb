Imports Microsoft.VisualBasic

Public Class PayRollNewEL
    Private _id As Integer

    Public Property Id() As Integer

        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set

    End Property
    Private _empId As Integer
    Public Property EmpId() As Integer
        Get
            Return _empId
        End Get
        Set(ByVal value As Integer)
            _empId = value
        End Set
    End Property
    Private _earningDeduction As String
    Public Property EarningDeduction() As String
        Get
            Return _earningDeduction
        End Get
        Set(ByVal value As String)
            _earningDeduction = value
        End Set
    End Property
    Private _amount As Double
    Public Property Amount() As Double
        Get
            Return _amount
        End Get
        Set(ByVal value As Double)
            _amount = value
        End Set
    End Property
    Private _FromDate As DateTime
    Public Property FromDate() As DateTime
        Get
            Return _FromDate
        End Get
        Set(ByVal value As DateTime)
            _FromDate = value
        End Set
    End Property
    Private _ToDate As DateTime
    Public Property ToDate() As DateTime
        Get
            Return _ToDate
        End Get
        Set(ByVal value As DateTime)
            _ToDate = value
        End Set
    End Property
    Private _StopSalary As String
    Public Property StopSalary() As String
        Get
            Return _StopSalary
        End Get
        Set(ByVal value As String)
            _StopSalary = value
        End Set
    End Property
End Class
