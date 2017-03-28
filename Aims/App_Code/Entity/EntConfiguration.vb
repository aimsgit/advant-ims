Imports Microsoft.VisualBasic

Public Class EntConfiguration
    Private _config_id As Long
    Public Property Config_ID() As Long
        Get
            Return _config_id
        End Get
        Set(ByVal value As Long)
            _config_id = value
        End Set
    End Property
    Private _config_name As String
    Public Property Config_Name() As String
        Get
            Return _config_name
        End Get
        Set(ByVal value As String)
            _config_name = value
        End Set
    End Property
    Private _config_value As String
    Public Property config_value() As String
        Get
            Return _config_value
        End Get
        Set(ByVal value As String)
            _config_value = value
        End Set
    End Property
    Private _date_value As Date
    Public Property Date_Value() As Date
        Get
            Return _date_value
        End Get
        Set(ByVal value As Date)
            _date_value = value
        End Set
    End Property
    'Private _enddate As Date
    'Public Property EndDate() As Date
    '    Get
    '        Return _enddate
    '    End Get
    '    Set(ByVal value As Date)
    '        _enddate = value
    '    End Set
    'End Property
    Public Sub New()
    End Sub
    'Public Sub New(ByVal cid As Long, ByVal startdate As Date, ByVal enddate As Date)
    Public Sub New(ByVal config_id As Long, ByVal config_name As String, ByVal _date_value As Date, ByVal config_value As String)
        _config_id = config_id
        _config_name = config_name
        Me._date_value = _date_value
        _config_value = config_value
    End Sub
End Class
