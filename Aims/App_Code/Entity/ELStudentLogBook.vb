Imports Microsoft.VisualBasic

Public Class ELStudentLogBook
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Private _BatchID As Integer
    Public Property BatchID() As Integer
        Get
            Return _BatchID
        End Get
        Set(ByVal value As Integer)
            _BatchID = value
        End Set
    End Property
    Private _STID As Integer
    Public Property STID() As Integer
        Get
            Return _STID
        End Get
        Set(ByVal value As Integer)
            _STID = value
        End Set
    End Property
    Private _EmpID As Integer
    Public Property EmpID() As Integer
        Get
            Return _EmpID
        End Get
        Set(ByVal value As Integer)
            _EmpID = value
        End Set
    End Property
    Private _LogDate As Date
    Public Property LogDate() As Date
        Get
            Return _LogDate
        End Get
        Set(ByVal value As Date)
            _LogDate = value
        End Set
    End Property
    Private _LogType As Integer
    Public Property LogType() As Integer
        Get
            Return _LogType
        End Get
        Set(ByVal value As Integer)
            _LogType = value
        End Set
    End Property
    Private _Feedback As String
    Public Property Feedback() As String
        Get
            Return _Feedback
        End Get
        Set(ByVal value As String)
            _Feedback = value
        End Set
    End Property
End Class
