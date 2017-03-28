Imports Microsoft.VisualBasic

Public Class SMSTempleteEL
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _SMSName As String
    Public Property SMSName() As String
        Get
            Return _SMSName
        End Get
        Set(ByVal value As String)
            _SMSName = value
        End Set
    End Property
    Private _SMSDescription As String
    Public Property SMSDescription() As String
        Get
            Return _SMSDescription
        End Get
        Set(ByVal value As String)
            _SMSDescription = value
        End Set
    End Property
End Class
