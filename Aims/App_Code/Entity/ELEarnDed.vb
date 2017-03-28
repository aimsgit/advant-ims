Imports Microsoft.VisualBasic

Public Class ELEarnDed
    Private _Description As String
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property
    Private _SubDescription As String
    Public Property SubDescription() As String
        Get
            Return _SubDescription
        End Get
        Set(ByVal value As String)
            _SubDescription = value
        End Set
    End Property
    Private _EarnDedCode As String
    Public Property EarnDedCode() As String
        Get
            Return _EarnDedCode
        End Get
        Set(ByVal value As String)
            _EarnDedCode = value
        End Set
    End Property
    Private _EarnDedType As String
    Public Property EarnDedType() As String
        Get
            Return _EarnDedType
        End Get
        Set(ByVal value As String)
            _EarnDedType = value
        End Set
    End Property
    Private _Taxable As String
    Public Property Taxable() As String
        Get
            Return _Taxable
        End Get
        Set(ByVal value As String)
            _Taxable = value
        End Set
    End Property
    Private _PFApplicable As String
    Public Property PFApplicable() As String
        Get
            Return _PFApplicable
        End Get
        Set(ByVal value As String)
            _PFApplicable = value
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
