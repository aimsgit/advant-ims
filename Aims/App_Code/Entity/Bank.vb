Imports Microsoft.VisualBasic

Public Class Bank
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
    Private _address As String
    Public Property Address() As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
        End Set
    End Property
    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property
    Private _deletelag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deletelag
        End Get
        Set(ByVal value As Int16)
            _deletelag = value
        End Set
    End Property
    Public Sub New(ByVal id As Long, ByVal name As String, ByVal address As String, ByVal remarks As String)
        _id = id
        _name = name
        _address = address
        _remarks = remarks
    End Sub
    Public Sub New()
    End Sub
End Class
