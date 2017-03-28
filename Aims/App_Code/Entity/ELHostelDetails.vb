Imports Microsoft.VisualBasic

Public Class ELHostelDetails
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set

    End Property
    Private _Hostel_COde As Integer
    Public Property Hostel_COde() As Integer
        Get
            Return _Hostel_COde
        End Get
        Set(ByVal value As Integer)
            _Hostel_COde = value
        End Set
    End Property
    Private _Room_No As String
    Public Property Room_No() As String
        Get
            Return _Room_No
        End Get
        Set(ByVal value As String)
            _Room_No = value
        End Set
    End Property
    Private _HostelName As String
    Public Property HostelName() As String
        Get
            Return _HostelName
        End Get
        Set(ByVal value As String)
            _HostelName = value
        End Set
    End Property
    Private _Room_Type As Integer
    Public Property Room_Type() As Integer
        Get
            Return _Room_Type
        End Get
        Set(ByVal value As Integer)
            _Room_Type = value
        End Set
    End Property
    Private _Occupants As Integer
    Public Property Occupants() As Integer
        Get
            Return _Occupants
        End Get
        Set(ByVal value As Integer)
            _Occupants = value
        End Set
    End Property
End Class
