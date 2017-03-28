Imports Microsoft.VisualBasic

Public Class BatchSemesterMap
    Private _Batch As String

    Private _A_Year As Long
    Public Property A_Year() As Long
        Get
            Return _A_Year
        End Get
        Set(ByVal value As Long)
            _A_Year = value
        End Set
    End Property
    Private _PKID As Long
    Public Property PKID() As Long
        Get
            Return _PKID
        End Get
        Set(ByVal value As Long)
            _PKID = value
        End Set
    End Property

    Private _BatchID As Long
    Public Property BatchID() As Long
        Get
            Return _BatchID
        End Get
        Set(ByVal value As Long)
            _BatchID = value
        End Set
    End Property
    Private _Count As Long
    Public Property Count() As Long
        Get
            Return _Count
        End Get
        Set(ByVal value As Long)
            _Count = value
        End Set
    End Property

    Public Property Batch() As String
        Get
            Return _Batch
        End Get
        Set(ByVal value As String)
            _Batch = value
        End Set
    End Property
    Private _StartDate As Date
    Public Property StartDate() As Date
        Get
            Return _StartDate
        End Get

        Set(ByVal value As Date)
            _StartDate = value
        End Set
    End Property
    Private _EndDate As Date
    Public Property EndDate() As Date
        Get
            Return _EndDate
        End Get

        Set(ByVal value As Date)
            _EndDate = value
        End Set
    End Property
End Class
