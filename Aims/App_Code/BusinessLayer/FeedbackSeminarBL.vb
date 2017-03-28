Imports Microsoft.VisualBasic

Public Class FeedbackSeminarBL

    Public Function GetEmployee() As DataTable
        Return FeedbackSeminarDL.GetEmployee()
    End Function

    Public Function InsertRecord(ByVal FS As FeedbackSeminarEL) As Integer
        Return FeedbackSeminarDL.Insert(FS)
    End Function

    Public Function GetFeedback(ByVal FS As FeedbackSeminarEL) As DataTable
        Return FeedbackSeminarDL.GetFeedback(FS)
    End Function
    Public Function UpdateRecord(ByVal FS As FeedbackSeminarEL) As Integer
        Return FeedbackSeminarDL.Update(FS)
    End Function
    Public Function ChangeFlag(ByVal FS As FeedbackSeminarEL) As Integer
        Return FeedbackSeminarDL.ChangeFlag(FS)
    End Function

End Class
