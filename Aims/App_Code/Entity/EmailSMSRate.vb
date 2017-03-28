Imports Microsoft.VisualBasic
Imports System.Data

Public Class EmailSMSRate
    Private _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
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
    Private _SMSRate As Double
    Public Property SMSRate() As Double
        Get
            Return _SMSRate
        End Get
        Set(ByVal value As Double)
            _SMSRate = value
        End Set
    End Property
    Private _EmailRate As Double
    Public Property EmailRate() As Double
        Get
            Return _EmailRate
        End Get
        Set(ByVal value As Double)
            _EmailRate = value
        End Set
    End Property
    Private _InstituteId As String
    Public Property InstituteId() As String
        Get
            Return _InstituteId
        End Get
        Set(ByVal value As String)
            _InstituteId = value
        End Set
    End Property
    Private _BranchId As String
    Public Property BranchId() As String
        Get
            Return _BranchId
        End Get
        Set(ByVal value As String)
            _BranchId = value
        End Set
    End Property
    Private _EmpCode As String
    Public Property EmpCode() As String
        Get
            Return _EmpCode
        End Get
        Set(ByVal value As String)
            _EmpCode = value
        End Set
    End Property
    Private _UserCode As String
    Public Property UserCode() As String
        Get
            Return _UserCode
        End Get
        Set(ByVal value As String)
            _UserCode = value
        End Set
    End Property
    Private _ValId As Integer
    Public Property ValId() As Integer
        Get
            Return _ValId
        End Get
        Set(ByVal value As Integer)
            _ValId = value
        End Set
    End Property
End Class
