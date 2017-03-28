Imports Microsoft.VisualBasic

Public Class ELEnquiryLogin
    Public _Name As String
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property
    Public _EmailID As String
    Public Property EmailID() As String
        Get
            Return _EmailID
        End Get
        Set(ByVal value As String)
            _EmailID = value
        End Set
    End Property
    Public _ContactNo As String
    Public Property ContactNo() As String
        Get
            Return _ContactNo
        End Get
        Set(ByVal value As String)
            _ContactNo = value
        End Set
    End Property
    Public _Password As String
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property
    Public _PrvsUrl As String
    Public Property PrvsUrl() As String
        Get
            Return _PrvsUrl
        End Get
        Set(ByVal value As String)
            _PrvsUrl = value
        End Set
    End Property
    Public _Website As String
    Public Property Website() As String
        Get
            Return _Website
        End Get
        Set(ByVal value As String)
            _Website = value
        End Set
    End Property
End Class
