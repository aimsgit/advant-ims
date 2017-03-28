Imports Microsoft.VisualBasic

Public Class ELParentMngt
    Private _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property
    Private _Username As String
    Public Property Username() As String
        Get
            Return _Username
        End Get
        Set(ByVal value As String)
            _Username = value
        End Set
    End Property
    Private _srchuser As String
    Public Property srchuser() As String
        Get
            Return _srchuser
        End Get
        Set(ByVal value As String)
            _srchuser = value
        End Set
    End Property
    Private _StdCode As String
    Public Property StdCode() As String
        Get
            Return _StdCode
        End Get
        Set(ByVal value As String)
            _StdCode = value
        End Set
    End Property
    Private _LoginType As String
    Public Property LoginType() As String
        Get
            Return _LoginType
        End Get
        Set(ByVal value As String)
            _LoginType = value
        End Set
    End Property
    Private _Password As String
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property
    Private _Features As String
    Public Property Features() As String
        Get
            Return _Features
        End Get
        Set(ByVal value As String)
            _Features = value
        End Set
    End Property
    Private _ExpDate As Date
    Public Property ExpDate() As Date
        Get
            Return _ExpDate
        End Get
        Set(ByVal value As Date)
            _ExpDate = value
        End Set
    End Property
    Private _Privilages As String
    Public Property Privilages() As String
        Get
            Return _Privilages
        End Get
        Set(ByVal value As String)
            _Privilages = value
        End Set
    End Property
    Private _BatchID As Integer
    Public Property BatchID() As Integer
        Get
            Return _BatchID
        End Get
        Set(ByVal value As Integer)
            _BatchID = value
        End Set
    End Property
End Class
