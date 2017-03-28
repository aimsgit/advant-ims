Imports Microsoft.VisualBasic

Public Class FeeDueRpt
    
    Shared _BatchId As Int64
    Public Shared Property BatchId() As Int64
        Get
            Return _BatchId
        End Get
        Set(ByVal value As Int64)
            _BatchId = value
        End Set
    End Property
    Shared _BatchNme As String
    Public Shared Property BatchNme() As String
        Get
            Return _BatchNme
        End Get
        Set(ByVal value As String)
            _BatchNme = value
        End Set
    End Property
    Private _SemID As Int64
    Public Property SemID() As Int64
        Get
            Return _SemID
        End Get
        Set(ByVal value As Int64)
            _SemID = value
        End Set
    End Property
    Private _SemNme As Int64
    Public Property SemNme() As String
        Get
            Return _SemNme
        End Get
        Set(ByVal value As String)
            _SemNme = value
        End Set
    End Property
    Private _StdID As Int64
    Public Property StdID() As Int64
        Get
            Return _StdID
        End Get
        Set(ByVal value As Int64)
            _StdID = value
        End Set
    End Property
    Private _StdNme As String
    Public Property StdNme() As String
        Get
            Return _StdNme
        End Get
        Set(ByVal value As String)
            _StdNme = value
        End Set
    End Property
    Private _CategoryID As Int64
    Public Property CategoryID() As Int64
        Get
            Return _CategoryID
        End Get
        Set(ByVal value As Int64)
            _CategoryID = value
        End Set
    End Property
    Private _CategoryNme As String
    Public Property CategoryNme() As String
        Get
            Return _CategoryNme
        End Get
        Set(ByVal value As String)
            _CategoryNme = value
        End Set
    End Property
End Class
