Imports Microsoft.VisualBasic

Public Class slssbhierarchytreeview
    Private _BranchCode As String
    Public Property BranchCode() As String
        Get
            Return _BranchCode
        End Get
        Set(ByVal value As String)
            _BranchCode = value
        End Set
    End Property
    Private _BranchName As String
    Public Property BranchName() As String
        Get
            Return _BranchName
        End Get
        Set(ByVal value As String)
            _BranchName = value
        End Set
    End Property
    'Private _BranchCode As Long
    'Public Property BranchCode() As Long
    '    Get
    '        Return _BranchCode
    '    End Get
    '    Set(ByVal value As Long)
    '        _BranchCode = value
    '    End Set
    'End Property
    Private _ReportBranchID As Long
    Public Property ReportBranchID() As Long
        Get
            Return _ReportBranchID
        End Get
        Set(ByVal value As Long)
            _ReportBranchID = value
        End Set
    End Property
    Public Sub New(ByVal BranchCode As String, ByVal BranchName As String, ByVal ReportBranchID As Long)
        _BranchCode = BranchCode
        _BranchName = BranchName
        '_BranchCode = BranchCode
        _ReportBranchID = ReportBranchID
    End Sub
    Public Sub New()

    End Sub
End Class
