Imports Microsoft.VisualBasic

Public Class ELCapacityPlan
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set

    End Property
    Private _Dept As Integer
    Public Property Dept() As Integer
        Get
            Return _Dept
        End Get
        Set(ByVal value As Integer)
            _Dept = value
        End Set
    End Property

    Private _Grade As Integer
    Public Property Grade() As Integer
        Get
            Return _Grade
        End Get
        Set(ByVal value As Integer)
            _Grade = value
        End Set
    End Property
    Private _NosReq As Integer
    Public Property NosReq() As Integer
        Get
            Return _NosReq
        End Get
        Set(ByVal value As Integer)
            _NosReq = value
        End Set
    End Property
    Private _Year As Integer
    Public Property Year() As Integer
        Get
            Return _Year
        End Get
        Set(ByVal value As Integer)
            _Year = value
        End Set
    End Property
    Private _Reqdate As DateTime
    Public Property Reqdate() As DateTime
        Get
            Return _Reqdate
        End Get
        Set(ByVal value As DateTime)
            _Reqdate = value
        End Set
    End Property
    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
End Class
