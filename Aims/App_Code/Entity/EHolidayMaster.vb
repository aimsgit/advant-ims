'Imports Microsoft.VisualBasic

Public Class EHolidayMaster
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Private _Shortname As String
    Public Property Shortname() As String
        Get
            Return _Shortname
        End Get
        Set(ByVal value As String)
            _Shortname = value
        End Set
    End Property
    Private _Rbid As String
    Public Property Rbid() As String
        Get
            Return _Rbid
        End Get
        Set(ByVal value As String)
            _Rbid = value
        End Set
    End Property
    Private _deleteflag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property
    Private _Date As Date
    Public Property Date1() As Date
        Get
            Return _Date
        End Get
        Set(ByVal value As Date)
            _Date = value
        End Set
    End Property
    'Private _Day As DateTime
    'Public Property Day() As DateTime
    '    Get
    '        Return _Day
    '    End Get
    '    Set(ByVal value As DateTime)
    '        _Day = value
    '    End Set
    'End Property
    Public Sub New()
    End Sub
    Public Sub New(ByVal id As Long, ByVal name As String, ByVal Date1 As DateTime)
        _id = id
        _name = name
        _Date = Date1
        '_Day = day

    End Sub
End Class

