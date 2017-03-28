Imports Microsoft.VisualBasic

Public Class ELLoginReport
    Private _Institute As String
    Public Property institute() As String
        Get
            Return _Institute
        End Get
        Set(ByVal value As String)
            _Institute = value
        End Set
    End Property
    Private _Branch As String
    Public Property branch() As String
        Get
            Return _Institute
        End Get
        Set(ByVal value As String)
            _Branch = value
        End Set
    End Property
    Private _FrmDate As Date
    Public Property frmDate() As Date
        Get
            Return _FrmDate
        End Get
        Set(ByVal value As Date)
            _FrmDate = value
        End Set
    End Property
    Private _ToDate As Date
    Public Property toDate() As Date
        Get
            Return _ToDate
        End Get
        Set(ByVal value As Date)
            _ToDate = value
        End Set
    End Property

End Class
