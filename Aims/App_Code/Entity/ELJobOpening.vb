Imports Microsoft.VisualBasic

Public Class ELJobOpening
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _Copmpanyid As Long
    Public Property Copmpanyid() As Long
        Get
            Return _Copmpanyid
        End Get
        Set(ByVal value As Long)
            _Copmpanyid = value
        End Set
    End Property
    Private _JobTitle As String
    Public Property JobTitle() As String
        Get
            Return _JobTitle
        End Get
        Set(ByVal value As String)
            _JobTitle = value
        End Set
    End Property
    Private _Specilization As String
    Public Property Specilization() As String
        Get
            Return _Specilization
        End Get
        Set(ByVal value As String)
            _Specilization = value
        End Set
    End Property
    Private _Skill As String
    Public Property Skill() As String
        Get
            Return _Skill
        End Get
        Set(ByVal value As String)
            _Skill = value
        End Set
    End Property
    Private _CloseApplication As Date
    Public Property CloseApplication() As Date
        Get
            Return _CloseApplication
        End Get
        Set(ByVal value As Date)
            _CloseApplication = value
        End Set
    End Property
    Private _StatusOfJobOpening As String
    Public Property StatusOfJobOpening() As String
        Get
            Return _StatusOfJobOpening
        End Get
        Set(ByVal value As String)
            _StatusOfJobOpening = value
        End Set
    End Property
    Private _Eligibility As String
    Public Property Eligibility() As String
        Get
            Return _Eligibility
        End Get
        Set(ByVal value As String)
            _Eligibility = value
        End Set
    End Property
    Private _SelectionProcess As String
    Public Property SelectionProcess() As String
        Get
            Return _SelectionProcess
        End Get
        Set(ByVal value As String)
            _SelectionProcess = value
        End Set
    End Property
End Class
