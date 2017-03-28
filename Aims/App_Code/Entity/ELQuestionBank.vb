Imports Microsoft.VisualBasic

Public Class ELQuestionBank
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _CourseId As Integer
    Public Property CourseId() As Integer
        Get
            Return _CourseId
        End Get
        Set(ByVal value As Integer)
            _CourseId = value
        End Set
    End Property
    Private _ChkID As String
    Public Property ChkID() As String
        Get
            Return _ChkID
        End Get
        Set(ByVal value As String)
            _ChkID = value
        End Set
    End Property
    Private _APhoto As String
    Public Property APhoto() As String
        Get
            Return _APhoto
        End Get
        Set(ByVal value As String)
            _APhoto = value
        End Set
    End Property
    Private _SubjectId As Integer
    Public Property SubjectId() As Integer
        Get
            Return _SubjectId
        End Get
        Set(ByVal value As Integer)
            _SubjectId = value
        End Set
    End Property
    Private _Q_Type As String
    Public Property Q_Type() As String
        Get
            Return _Q_Type
        End Get
        Set(ByVal value As String)
            _Q_Type = value
        End Set
    End Property
    Private _Q_No As String
    Public Property Q_No() As String
        Get
            Return _Q_No
        End Get
        Set(ByVal value As String)
            _Q_No = value
        End Set
    End Property
    Private _Q_SubNo As String
    Public Property Q_SubNo() As String
        Get
            Return _Q_SubNo
        End Get
        Set(ByVal value As String)
            _Q_SubNo = value
        End Set
    End Property
    Private _Ques As String
    Public Property Ques() As String
        Get
            Return _Ques
        End Get
        Set(ByVal value As String)
            _Ques = value
        End Set
    End Property
    Private _Image As String
    Public Property Image() As String
        Get
            Return _Image
        End Get
        Set(ByVal value As String)
            _Image = value
        End Set
    End Property
    Private _Ans As String
    Public Property Ans() As String
        Get
            Return _Ans
        End Get
        Set(ByVal value As String)
            _Ans = value
        End Set
    End Property
    Private _Q_date As String
    Public Property Q_date() As String
        Get
            Return _Q_date
        End Get
        Set(ByVal value As String)
            _Q_date = value
        End Set
    End Property
End Class
