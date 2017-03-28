Imports Microsoft.VisualBasic

Public Class BLFeedBack
    Dim DAL As New DLFeedBack
    Public Function insertFeedbackStudent(ByVal s As ELFeedBackDetails) As Integer
        Return DAL.InsertFeedBackStudent(s)
    End Function
    Public Function InsertFeedBackEmp(ByVal s As ELFeedBackDetails) As Integer
        Return DAL.InsertFeedBackEmp(s)
    End Function
End Class
