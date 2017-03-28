Imports Microsoft.VisualBasic

Public Class CourseType
    Private _CourseType_ID As Integer
    Public Property CourseType_ID() As Integer
        Get
            Return _CourseType_ID
        End Get
        Set(ByVal value As Integer)
            _CourseType_ID = value
        End Set
    End Property

    Private _CourseType As String
    Public Property CourseType() As String
        Get
            Return _CourseType
        End Get
        Set(ByVal value As String)
            _CourseType = value
        End Set
    End Property
    Private _deleteFlag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteFlag
        End Get
        Set(ByVal value As Int16)
            _deleteFlag = value
        End Set
    End Property
    Public Sub New(ByVal CourseTypeID As Integer, ByVal CourseType As String, ByVal deleteflag As Int16)
        _CourseType_ID = CourseTypeID
        _CourseType = CourseType
        _deleteFlag = deleteflag
    End Sub

    Private _Duration As String
    Public Property Duratuion() As String
        Get
            Return _Duration
        End Get
        Set(ByVal value As String)
            _Duration = value
        End Set
    End Property
    Private _CourseLevel As String
    Public Property CourseLevel() As String
        Get
            Return _CourseLevel
        End Get
        Set(ByVal value As String)
            _CourseLevel = value
        End Set
    End Property
    Public Sub New()
    End Sub
End Class
