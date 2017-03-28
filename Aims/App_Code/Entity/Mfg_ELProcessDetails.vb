Imports Microsoft.VisualBasic

Public Class Mfg_ELProcessDetails
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _PID As Integer
    Public Property PID() As Integer
        Get
            Return _PID
        End Get
        Set(ByVal value As Integer)
            _PID = value
        End Set
    End Property
    Private _ProcessID As Integer
    Public Property ProcessID() As Integer
        Get
            Return _ProcessID
        End Get
        Set(ByVal value As Integer)
            _ProcessID = value
        End Set
    End Property
    Private _Sequence As Integer
    Public Property Sequence() As Integer
        Get
            Return _Sequence
        End Get
        Set(ByVal value As Integer)
            _Sequence = value
        End Set
    End Property
    Private _ProcessDesc As String
    Public Property ProcessDesc() As String
        Get
            Return _ProcessDesc
        End Get
        Set(ByVal value As String)
            _ProcessDesc = value
        End Set
    End Property
    Private _ItemDesc As Integer
    Public Property ItemDesc() As Integer
        Get
            Return _ItemDesc
        End Get
        Set(ByVal value As Integer)
            _ItemDesc = value
        End Set
    End Property
    Private _IO As String
    Public Property IO() As String
        Get
            Return _IO
        End Get
        Set(ByVal value As String)
            _IO = value
        End Set
    End Property
End Class
