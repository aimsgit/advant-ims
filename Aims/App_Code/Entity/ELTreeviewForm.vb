
'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'
'--Author: Kusum.C.Akki
'--Date: 02.01.2013
'--Description: Treeview form to configure the module and its respective child.
'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'
Imports Microsoft.VisualBasic

Public Class ELTreeviewForm
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _ModuleName As String
    Public Property ModuleName() As String
        Get
            Return _ModuleName
        End Get
        Set(ByVal value As String)
            _ModuleName = value
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

End Class
