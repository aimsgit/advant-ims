Imports Microsoft.VisualBasic

Public Class AcademicYear
    Private _id As String
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property
    Private _AcdYear As String
    Public Property AcdYear() As String
        Get
            Return _AcdYear
        End Get
        Set(ByVal value As String)
            _AcdYear = value
        End Set
    End Property
    Private _deleteFlag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteFlag
        End Get
        Set(ByVal value As Int16)
            _deleteFlag = value
        End Set
    End Property
    Private _Startdate As DateTime
    Public Property Startdate() As DateTime
        Get
            Return _Startdate
        End Get
        Set(ByVal value As DateTime)
            _Startdate = value
        End Set
    End Property
    Private _Enddate As DateTime
    Public Property Enddate() As DateTime
        Get
            Return _Enddate
        End Get
        Set(ByVal value As DateTime)
            _Enddate = value
        End Set
    End Property
    Private _curryear As String
    Public Property curryear() As String

        Get
            Return _curryear
        End Get
        Set(ByVal value As String)
            _curryear = value
        End Set
    End Property
    Public Sub New(ByVal id As Integer, ByVal AcdYear As String)
        _id = id
        _AcdYear = AcdYear
    End Sub
    Public Sub New()
    End Sub
End Class
