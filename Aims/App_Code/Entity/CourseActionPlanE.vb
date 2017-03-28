Imports Microsoft.VisualBasic

Public Class CourseActionPlanE
    Private _Sun As String
    Private _Mon As String
    Private _Tue As String
    Private _Wed As String
    Private _Thu As String
    Private _Fri As String
    Private _Sat As String
    Public Property Sun() As String
        Get
            Return _Sun
        End Get
        Set(ByVal value As String)
            _Sun = value
        End Set
    End Property
    Public Property Mon() As String
        Get
            Return _Mon
        End Get
        Set(ByVal value As String)
            _Mon = value
        End Set
    End Property
    Public Property Tue() As String
        Get
            Return _Tue
        End Get
        Set(ByVal value As String)
            _Tue = value
        End Set
    End Property
    Public Property Wed() As String
        Get
            Return _Wed
        End Get
        Set(ByVal value As String)
            _Wed = value
        End Set
    End Property
    Public Property Thu() As String
        Get
            Return _Thu
        End Get
        Set(ByVal value As String)
            _Thu = value
        End Set
    End Property
    Public Property Fri() As String
        Get
            Return _Fri
        End Get
        Set(ByVal value As String)
            _Fri = value
        End Set
    End Property
    Public Property Sat() As String
        Get
            Return _Sat
        End Get
        Set(ByVal value As String)
            _Sat = value
        End Set
    End Property

    Public Sub New(ByVal Sun As String, ByVal Mon As String, ByVal Tue As String, ByVal Wed As String, ByVal Thu As String, ByVal Fri As String, ByVal Sat As String)
        _Sun = Sun
        _Mon = Mon
        _Tue = Tue
        _Wed = Wed
        _Thu = Thu
        _Fri = Fri
        _Sat = Sat
    End Sub
End Class
