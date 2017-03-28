Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class LessonPlanBL
    Public Function InsertRecord(ByVal LP As LessonPlanEL) As Integer
        Return LessonPlanDL.Insert(LP)
    End Function
    Public Function GetLessonPlan(ByVal LP As LessonPlanEL) As DataTable
        Return LessonPlanDL.GetLessonPlan(LP)
    End Function

    Public Function UpdateRecord(ByVal LP As LessonPlanEL) As Integer
        Return LessonPlanDL.Update(LP)
    End Function
    Public Function ChangeFlag(ByVal LP As LessonPlanEL) As Integer
        Return LessonPlanDL.ChangeFlag(LP)
    End Function
End Class
