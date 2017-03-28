Imports Microsoft.VisualBasic

Public Class ELSubjectSubgrp
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _SubGrp As String
    Public Property SubGrp() As String
        Get
            Return _SubGrp
        End Get
        Set(ByVal value As String)
            _SubGrp = value
        End Set
    End Property
    Private _BatchId As Integer
    Public Property BatchId() As Integer
        Get
            Return _BatchId
        End Get
        Set(ByVal value As Integer)
            _BatchId = value
        End Set
    End Property
    Private _Sem_Id As Integer
    Public Property Sem_Id() As Integer
        Get
            Return _Sem_Id
        End Get
        Set(ByVal value As Integer)
            _Sem_Id = value
        End Set
    End Property
    Private _SubGrpId As Integer
    Public Property SubGrpId() As Integer
        Get
            Return _SubGrpId
        End Get
        Set(ByVal value As Integer)
            _SubGrpId = value
        End Set
    End Property
    Private _Emp_Id As Integer
    Public Property Emp_Id() As Integer
        Get
            Return _Emp_Id
        End Get
        Set(ByVal value As Integer)
            _Emp_Id = value
        End Set
    End Property
    Private _Subjectid As Integer
    Public Property Subjectid() As Integer
        Get
            Return _Subjectid
        End Get
        Set(ByVal value As Integer)
            _Subjectid = value
        End Set
    End Property
End Class
