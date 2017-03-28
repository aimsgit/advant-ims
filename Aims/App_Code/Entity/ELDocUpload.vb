Imports Microsoft.VisualBasic

Public Class ELDocUpload
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _deleteFlag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteFlag
        End Get
        Set(ByVal value As Int16)
            _deleteFlag = value
        End Set
    End Property
    Private _Link As String
    Public Property Link() As String
        Get
            Return _Link
        End Get
        Set(ByVal value As String)
            _Link = value
        End Set
    End Property
    Private _Desc As String
    Public Property Desc() As String
        Get
            Return _Desc
        End Get
        Set(ByVal value As String)
            _Desc = value
        End Set
    End Property
    Private _RevNo As String
    Public Property RevNo() As String
        Get
            Return _RevNo
        End Get
        Set(ByVal value As String)
            _RevNo = value
        End Set
    End Property
    Private _RevDate As Date
    Public Property RevDate() As Date
        Get
            Return _RevDate
        End Get
        Set(ByVal value As Date)
            _RevDate = value
        End Set
    End Property
    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
End Class
