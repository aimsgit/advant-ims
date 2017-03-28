Imports Microsoft.VisualBasic

Public Class CertificateReceived

    Private _name As String
    Private _remarks As String
    Private _id As Long
    Public Property Qualification_ID() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _std_code As String
    Public Property Std_code() As String
        Get
            Return _std_code
        End Get
        Set(ByVal value As String)
            _std_code = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property
    Public Sub New(ByVal id As Long, ByVal std_code As String, ByVal name As String, ByVal remarks As String)
        _id = id
        _std_code = std_code
        _name = name
        _remarks = remarks
    End Sub
    Public Sub New()
    End Sub
End Class
