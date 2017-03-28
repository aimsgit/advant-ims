Imports Microsoft.VisualBasic

Public Class Zone
    Private _hOID As Int64
    Public Property HOID() As Int64
        Get
            Return _hOID
        End Get
        Set(ByVal value As Int64)
            _hOID = value
        End Set
    End Property
    Private _zoneID As Int64
    Public Property ZoneID() As Int64
        Get
            Return _zoneID
        End Get
        Set(ByVal value As Int64)
            _zoneID = value
        End Set
    End Property
    Private _zoneName As String
    Public Property ZoneName() As String
        Get
            Return _zoneName
        End Get
        Set(ByVal value As String)
            _zoneName = value
        End Set
    End Property
    Private _zoneCode As String
    Public Property ZoneCode() As String
        Get
            Return _zoneCode
        End Get
        Set(ByVal value As String)
            _zoneCode = value
        End Set
    End Property
End Class
