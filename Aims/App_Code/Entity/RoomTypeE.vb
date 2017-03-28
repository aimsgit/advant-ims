Imports Microsoft.VisualBasic

Public Class RoomTypeE
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _RoomType As String
    Public Property RoomType() As String
        Get
            Return _RoomType
        End Get
        Set(ByVal value As String)
            _RoomType = value
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
    Private _deleteFlag As Int16
    Public Property deleteFlag() As Int16
        Get
            Return _deleteFlag
        End Get
        Set(ByVal value As Int16)
            _deleteFlag = value
        End Set
    End Property

    Private _Occupant As Integer
    Public Property Occupant() As Integer
        Get
            Return _Occupant
        End Get
        Set(ByVal value As Integer)
            _Occupant = value
        End Set
    End Property
    Public Sub New(ByVal RoomType As String, ByVal Remarks As String, ByVal id As Integer, ByVal Occupant As Integer)

        _RoomType = RoomType
        _Remarks = Remarks
        _id = id
        _Occupant = Occupant
    End Sub
    Public Sub New()
    End Sub
End Class



