Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class AccountSubGroup
    Private _Acct_Sub_Group_ID As Long
    Public Property Acct_Sub_Group_ID() As Long
        Get
            Return _Acct_Sub_Group_ID
        End Get
        Set(ByVal value As Long)
            _Acct_Sub_Group_ID = value
        End Set
    End Property
    Private _Acct_Sub_Group As String
    Public Property Acct_Sub_Group() As String
        Get
            Return _Acct_Sub_Group
        End Get
        Set(ByVal value As String)
            _Acct_Sub_Group = value
        End Set
    End Property
    Private _Acct_Group_ID As Int16
    Public Property Acct_Group_ID() As Int16
        Get
            Return _Acct_Group_ID
        End Get
        Set(ByVal value As Int16)
            _Acct_Group_ID = value
        End Set
    End Property

    Public Sub New(ByVal Acct_Sub_Group_ID As Long, ByVal Acct_Sub_Group As String, ByVal Acct_Group_ID As Int16)
        _Acct_Sub_Group_ID = Acct_Sub_Group_ID
        _Acct_Sub_Group = Acct_Sub_Group
        _Acct_Group_ID = Acct_Group_ID
    End Sub
    Public Sub New()
    End Sub
End Class
