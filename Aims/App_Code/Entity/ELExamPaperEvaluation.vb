Imports Microsoft.VisualBasic

Public Class ELExamPaperEvaluation
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
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
    Private _Subject As Integer
    Public Property Subject() As Integer
        Get
            Return _Subject
        End Get
        Set(ByVal value As Integer)
            _Subject = value
        End Set
    End Property
    Private _Faculty As Integer
    Public Property Faculty() As Integer
        Get
            Return _Faculty
        End Get
        Set(ByVal value As Integer)
            _Faculty = value
        End Set
    End Property
    Private _FrmSerialNo As String
    Public Property FrmSerialNo() As String
        Get
            Return _FrmSerialNo
        End Get
        Set(ByVal value As String)
            _FrmSerialNo = value
        End Set
    End Property
    Private _ToSerialNo As String
    Public Property ToSerialNo() As String
        Get
            Return _ToSerialNo
        End Get
        Set(ByVal value As String)
            _ToSerialNo = value
        End Set
    End Property
End Class
