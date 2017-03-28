Imports Microsoft.VisualBasic
Public Class BLQuestionPaper
    Dim DL As New DLQuestionPaper
    Public Function CheckDuplicate(ByVal EL As ELQuestionPaper) As System.Data.DataTable
        Return DL.CheckDuplicateQuestionPaper(EL)
    End Function
    Public Function InsertQuestionPaper(ByVal EL As ELQuestionPaper) As Integer
        Return DLQuestionPaper.InsertQuestionPaper(EL)
    End Function
    Public Function QuestionpaperGridView(ByVal EL As ELQuestionPaper) As DataTable
        Return DLQuestionPaper.QuestionPaperGridView(EL)
    End Function
    Public Function DeleteQuestionpaper(ByVal EL As ELQuestionPaper) As Integer
        Return DLQuestionPaper.DeleteQuestionPaper(EL)
    End Function
    Public Function UpdateQuestionPaperMarks(ByVal EL As ELQuestionPaper) As Integer
        Return DLQuestionPaper.UpdateQuestionPaperMarks(EL)
    End Function
End Class
