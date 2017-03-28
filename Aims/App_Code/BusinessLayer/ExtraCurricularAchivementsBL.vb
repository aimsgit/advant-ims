Imports Microsoft.VisualBasic

Public Class ExtraCurricularAchivementsBL
    Public Function InsertRecord(ByVal ECA As ExtraCurricularAchievementsEL) As Integer
        Return ExtraCurricularAchivementsDL.Insert(ECA)
    End Function

    Public Function GetECA(ByVal ECA As ExtraCurricularAchievementsEL) As DataTable
        Return ExtraCurricularAchivementsDL.GetECA(ECA)
    End Function
    Public Function GetDepartment() As DataTable
        Return ExtraCurricularAchivementsDL.GetDepartment()
    End Function

    Public Function UpdateRecord(ByVal ECA As ExtraCurricularAchievementsEL) As Integer
        Return ExtraCurricularAchivementsDL.Update(ECA)
    End Function
    Public Function ChangeFlag(ByVal ECA As ExtraCurricularAchievementsEL) As Integer
        Return ExtraCurricularAchivementsDL.ChangeFlag(ECA)
    End Function
    '------Report functions
    Public Function GetDepartmentR() As DataTable
        Return ExtraCurricularAchivementsDL.GetDepartmentR()
    End Function
End Class
