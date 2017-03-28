Imports Microsoft.VisualBasic

Public Class ELAchievementAndAward
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _EmpStudStatus As Integer
    Public Property EmpStudStatus() As Integer
        Get
            Return _EmpStudStatus
        End Get
        Set(ByVal value As Integer)
            _EmpStudStatus = value
        End Set
    End Property
    Private _Departmentid As Integer
    Public Property Departmentid() As Integer
        Get
            Return _Departmentid
        End Get
        Set(ByVal value As Integer)
            _Departmentid = value
        End Set
    End Property
    Private _AchievementDetails As String
    Public Property AchievementDetails() As String
        Get
            Return _AchievementDetails
        End Get
        Set(ByVal value As String)
            _AchievementDetails = value
        End Set
    End Property
    Private _AchievementDate As DateTime
    Public Property AchievementDate() As DateTime
        Get
            Return _AchievementDate
        End Get
        Set(ByVal value As DateTime)
            _AchievementDate = value
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
