Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class TutorialBL
    Public Function InsertTutorialEL(ByVal Tutorial As TutorialEL) As String
        Return TutorialDL.InsertTutorialEL(Tutorial)
    End Function
    Public Function DisplayGridview(ByVal id As Integer) As Data.DataTable
        Return TutorialDL.DisplayGridview(id)
    End Function
    Public Function DeleteTutorialEL(ByVal Tutorial As TutorialEL) As String
        Return TutorialDL.DeleteTutorialEL(Tutorial)
    End Function
    Public Function UpdateTutorialEL(ByVal Tutorial As TutorialEL) As String
        Return TutorialDL.UpdateTutorialEL(Tutorial)
    End Function
End Class
