Imports Microsoft.VisualBasic
Imports System

Public Class BranchTypeCombo
    Private _code As String
    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
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
    Private _deletelag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deletelag
        End Get
        Set(ByVal value As Int16)
            _deletelag = value
        End Set
    End Property
    Public Sub New(ByVal code As String, ByVal name As String)
        _code = code
        _name = name
    End Sub

    Public Sub New()

    End Sub
End Class
