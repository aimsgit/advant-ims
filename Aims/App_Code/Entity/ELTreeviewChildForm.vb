
'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'
'--Author: Kusum.C.Akki
'--Date: 02.01.2013
'--Description: Treeview form to configure the module and its respective child.
'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'
Imports Microsoft.VisualBasic

Public Class ELTreeviewChildForm
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Moduleid As Integer
    Public Property Moduleid() As Integer
        Get
            Return _Moduleid
        End Get
        Set(ByVal value As Integer)
            _Moduleid = value
        End Set
    End Property
    Private _FormName As String
    Public Property FormName() As String
        Get
            Return _FormName
        End Get
        Set(ByVal value As String)
            _FormName = value
        End Set
    End Property
    Private _FormFileName As String
    Public Property FormFileName() As String
        Get
            Return _FormFileName
        End Get
        Set(ByVal value As String)
            _FormFileName = value
        End Set
    End Property
    Private _SequenceNo As Integer
    Public Property SequenceNo() As Integer
        Get
            Return _SequenceNo
        End Get
        Set(ByVal value As Integer)
            _SequenceNo = value
        End Set
    End Property

    Private _Modules As Integer
    Public Property Modules() As Integer
        Get
            Return _Modules
        End Get
        Set(ByVal value As Integer)
            _Modules = value
        End Set
    End Property
    Private _FormNames As Integer
    Public Property FormNames() As Integer
        Get
            Return _FormNames
        End Get
        Set(ByVal value As Integer)
            _FormNames = value
        End Set
    End Property
    Private _AliasName As String
    Public Property AliasName() As String
        Get
            Return _AliasName
        End Get
        Set(ByVal value As String)
            _AliasName = value
        End Set
    End Property
    Private _CustomizeTreeviewId As Integer
    Public Property CustomizeTreeviewId() As Integer
        Get
            Return _CustomizeTreeviewId
        End Get
        Set(ByVal value As Integer)
            _CustomizeTreeviewId = value
        End Set
    End Property

    Private _Institute As String
    Public Property Institute() As String
        Get
            Return _Institute
        End Get
        Set(ByVal value As String)
            _Institute = value
        End Set
    End Property
    Private _BranchName As String
    Public Property BranchName() As String
        Get
            Return _BranchName
        End Get
        Set(ByVal value As String)
            _BranchName = value
        End Set
    End Property

End Class
