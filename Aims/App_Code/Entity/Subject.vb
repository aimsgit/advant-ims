Imports Microsoft.VisualBasic

Public Class Subject
    Private _id As Int64
    Private _name As String
    Private _code As String
    Private _deleteflag As Int16
    Private _DeptId As Integer
    Private _Subgrp As String
    Private _PrincipleSubject As Integer
    Private _SubjectCategory As Integer
    Private _PreRequisites As String
    Public Property Id() As Int64
        Get
            Return _id
        End Get
        Set(ByVal value As Int64)
            _id = value
        End Set
    End Property
    Public Property DeptId() As Integer
        Get
            Return _DeptId
        End Get
        Set(ByVal value As Integer)
            _DeptId = value
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
    Public Property Subgrp() As String
        Get
            Return _Subgrp
        End Get
        Set(ByVal value As String)
            _Subgrp = value
        End Set
    End Property
    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property

    Public Property SubjectCategory() As Integer
        Get
            Return _SubjectCategory
        End Get
        Set(ByVal value As Integer)
            _SubjectCategory = value
        End Set
    End Property
    Public Property PreRequisites() As String
        Get
            Return _PreRequisites
        End Get
        Set(ByVal value As String)
            _PreRequisites = value
        End Set
    End Property

    Public Property PrincipleSubject() As Integer
        Get
            Return _PrincipleSubject
        End Get
        Set(ByVal value As Integer)
            _PrincipleSubject = value
        End Set
    End Property

    Public Sub New(ByVal id As Long, ByVal code As String, ByVal name As String)
        _id = id
        _code = code
        _name = name
        _DeptId = DeptId
    End Sub
    Public Sub New()

    End Sub
End Class
