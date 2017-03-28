Imports Microsoft.VisualBasic

Public Class Mfg_ELShiftMaster
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Shift_Desc As String
    Public Property Shift_Desc() As String
        Get
            Return _Shift_Desc
        End Get
        Set(ByVal value As String)
            _Shift_Desc = value
        End Set
    End Property

    Private _Start_Time As DateTime
    Public Property Start_Time() As DateTime
        Get
            Return _Start_Time
        End Get
        Set(ByVal value As DateTime)
            _Start_Time = value
        End Set
    End Property
    Private _End_Time As DateTime
    Public Property End_Time() As DateTime
        Get
            Return _End_Time
        End Get
        Set(ByVal value As DateTime)
            _End_Time = value
        End Set
    End Property
    Private _DurationHrs As Integer
    Public Property DurationHrs() As Integer
        Get
            Return _DurationHrs
        End Get
        Set(ByVal value As Integer)
            _DurationHrs = value
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
