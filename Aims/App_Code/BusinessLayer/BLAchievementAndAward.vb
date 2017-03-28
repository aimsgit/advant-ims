Imports Microsoft.VisualBasic

Public Class BLAchievementAndAward
    Public Function Insert(ByVal EL As ELAchievementAndAward) As Integer
        Return DLAchievementAndAward.Insert(EL)
    End Function

    Public Function getAchievementAward(ByVal EL As ELAchievementAndAward) As DataTable
        Return DLAchievementAndAward.getAchievementAward(EL)
    End Function
    Public Function Update(ByVal EL As ELAchievementAndAward) As Integer
        Return DLAchievementAndAward.Update(EL)
    End Function
    Public Function Delete(ByVal EL As ELAchievementAndAward) As Integer
        Return DLAchievementAndAward.Delete(EL)
    End Function
    Public Function GetAddAchievement(ByVal e As String) As Data.DataTable
        Return DLAchievementAndAward.GetAddAchievement(e)
    End Function
End Class
