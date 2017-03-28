Imports Microsoft.VisualBasic

Public Class ELMultilingual
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Private _moduleId As Integer
    Public Property moduleId() As Integer
        Get
            Return _moduleId
        End Get
        Set(ByVal value As Integer)
            _moduleId = value
        End Set
    End Property
    Private _FormId As String
    Public Property FormId() As String
        Get
            Return _FormId
        End Get
        Set(ByVal value As String)
            _FormId = value
        End Set
    End Property
    'Private _ReportName As String
    'Public Property ReportName() As String
    '    Get
    '        Return _ReportName
    '    End Get
    '    Set(ByVal value As String)
    '        _ReportName = value
    '    End Set
    'End Property
    Private _Lang_Id As Integer
    Public Property Lang_Id() As Integer
        Get
            Return _Lang_Id
        End Get
        Set(ByVal value As Integer)
            _Lang_Id = value
        End Set
    End Property
    Private _Control_Type As String
    Public Property Control_Type() As String
        Get
            Return _Control_Type
        End Get
        Set(ByVal value As String)
            _Control_Type = value
        End Set
    End Property
    Private _Type As String
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property
    Private _CCName As String
    Public Property CCName() As String
        Get
            Return _CCName
        End Get
        Set(ByVal value As String)
            _CCName = value
        End Set
    End Property
    Private _Control_Id As String
    Public Property Control_Id() As String
        Get
            Return _Control_Id
        End Get
        Set(ByVal value As String)
            _Control_Id = value
        End Set
    End Property
    Private _Translation As String
    Public Property Translation() As String
        Get
            Return _Translation
        End Get
        Set(ByVal value As String)
            _Translation = value
        End Set
    End Property
    Private _Branch As String
    Public Property Branch() As String
        Get
            Return _Branch
        End Get
        Set(ByVal value As String)
            _Branch = value
        End Set
    End Property
End Class
