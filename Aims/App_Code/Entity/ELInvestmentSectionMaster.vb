Imports Microsoft.VisualBasic

Public Class ELInvestmentSectionMaster
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Private _SectionID As Integer
    Public Property SectionID() As Integer
        Get
            Return _SectionID

        End Get
        Set(ByVal value As Integer)
            _SectionID = value
        End Set
    End Property
    Private _Description As String
    Public Property Description() As String
        Get
            Return _Description

        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property
    Private _SubDescription As String
    Public Property SubDescription() As String
        Get
            Return _SubDescription

        End Get
        Set(ByVal value As String)
            _SubDescription = value
        End Set
    End Property


End Class
