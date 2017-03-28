Imports Microsoft.VisualBasic

Public Class IDCardIssue
    Public _BacthID As Integer
    Public Property BacthID() As Integer
        Get
            Return _BacthID
        End Get
        Set(ByVal value As Integer)
            _BacthID = value
        End Set
    End Property

    Public _StudentID As Integer
    Public Property StudentID() As Integer
        Get
            Return _StudentID
        End Get
        Set(ByVal value As Integer)
            _StudentID = value
        End Set
    End Property

    Public _CardType As String
    Public Property CardType() As String
        Get
            Return _CardType
        End Get
        Set(ByVal value As String)
            _CardType = value
        End Set
    End Property

    Public _IssueDate As DateTime
    Public Property IssueDate() As DateTime
        Get
            Return _IssueDate
        End Get
        Set(ByVal value As DateTime)
            _IssueDate = value
        End Set
    End Property


    Public _PKID As Integer
    Public Property PKID() As Integer
        Get
            Return _PKID
        End Get
        Set(ByVal value As Integer)
            _PKID = value
        End Set
    End Property

    Public _Auto_PKID As Integer
    Public Property Auto_PKID() As Integer
        Get
            Return _Auto_PKID
        End Get
        Set(ByVal value As Integer)
            _Auto_PKID = value
        End Set
    End Property

    Public Sub New()

    End Sub

End Class
