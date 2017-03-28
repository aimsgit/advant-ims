Imports Microsoft.VisualBasic

Public Class ELFacutlyDevelopment
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Private _DeptId As Integer
    Public Property DeptId() As Integer
        Get
            Return _DeptId
        End Get
        Set(ByVal value As Integer)
            _DeptId = value
        End Set
    End Property
    Private _FromDate As Date
    Public Property FromDate() As Date
        Get
            Return _FromDate
        End Get
        Set(ByVal value As Date)
            _FromDate = value
        End Set
    End Property
    Private _ToDate As Date
    Public Property ToDate() As Date
        Get
            Return _ToDate
        End Get
        Set(ByVal value As Date)
            _ToDate = value
        End Set
    End Property
    Private _Program_Name As String
    Public Property Program_Name() As String
        Get
            Return _Program_Name
        End Get
        Set(ByVal value As String)
            _Program_Name = value
        End Set
    End Property
    Private _ConductedBy As String
    Public Property ConductedBy() As String
        Get
            Return _ConductedBy
        End Get
        Set(ByVal value As String)
            _ConductedBy = value
        End Set
    End Property
    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
End Class
