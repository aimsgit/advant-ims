Imports Microsoft.VisualBasic

Public Class ELFeedbackDept
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Private _DeptID As Integer
    Public Property DeptID() As Integer
        Get
            Return _DeptID

        End Get
        Set(ByVal value As Integer)
            _DeptID = value
        End Set
    End Property
    Private _StartDate As DateTime
    Public Property StartDate() As DateTime
        Get
            Return _StartDate

        End Get
        Set(ByVal value As DateTime)
            _StartDate = value
        End Set
    End Property
    Private _EndDate As DateTime
    Public Property EndDate() As DateTime
        Get
            Return _EndDate

        End Get
        Set(ByVal value As DateTime)
            _EndDate = value
        End Set
    End Property

    Private _DeptName As String
    Public Property DeptName() As String
        Get
            Return _DeptName

        End Get
        Set(ByVal value As String)
            _DeptName = value
        End Set
    End Property

End Class
