Imports Microsoft.VisualBasic

Public Class ELExamHallAllocation
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _ExamBatchId As Integer
    Public Property ExamBatchId() As Integer
        Get
            Return _ExamBatchId
        End Get
        Set(ByVal value As Integer)
            _ExamBatchId = value
        End Set
    End Property
    Private _SubId As Integer
    Public Property SubId() As Integer
        Get
            Return _SubId
        End Get
        Set(ByVal value As Integer)
            _SubId = value
        End Set
    End Property
    Private _RoomId As Integer
    Public Property RoomId() As Integer
        Get
            Return _RoomId
        End Get
        Set(ByVal value As Integer)
            _RoomId = value
        End Set
    End Property
    Private _Fromsl As String
    Public Property Fromsl() As String
        Get
            Return _Fromsl
        End Get
        Set(ByVal value As String)
            _Fromsl = value
        End Set
    End Property
    Private _Tosl As String
    Public Property Tosl() As String
        Get
            Return _Tosl
        End Get
        Set(ByVal value As String)
            _Tosl = value
        End Set
    End Property
    Private _BranchCode As String
    Public Property BranchCode() As String
        Get
            Return _BranchCode
        End Get
        Set(ByVal value As String)
            _BranchCode = value
        End Set
    End Property
End Class
