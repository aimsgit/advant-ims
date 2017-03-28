Imports Microsoft.VisualBasic

Public Class BranchType

    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property

    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    'Private _Code As String
    'Public Property BranchTypeCode() As String
    '    Get
    '        Return _Code
    '    End Get
    '    Set(ByVal value As String)
    '        _Code = value
    '    End Set
    'End Property
    Public Sub New(ByVal id As Long, ByVal name As String)
        _id = id
        _name = name
        '_Code = Code
    End Sub

    Public Sub New()

    End Sub

End Class
