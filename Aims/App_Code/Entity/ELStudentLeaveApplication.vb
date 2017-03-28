Imports Microsoft.VisualBasic

Public Class ELStudentLeaveApplication
    Private _Reason As String
    Public Property Reason() As String
        Get
            Return _Reason
        End Get
        Set(ByVal value As String)
            _Reason = value
        End Set
    End Property
    Private _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property
    Private _Batch As Integer
    Public Property Batch() As Integer
        Get
            Return _Batch
        End Get
        Set(ByVal value As Integer)
            _Batch = value
        End Set
    End Property
    Private _studentcode As String
    Public Property studentcode() As String
        Get
            Return _studentcode
        End Get
        Set(ByVal value As String)
            _studentcode = value
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
    Private _NoofDays As Integer
    Public Property NoofDays() As Integer
        Get
            Return _NoofDays
        End Get
        Set(ByVal value As Integer)
            _NoofDays = value
        End Set
    End Property
End Class
