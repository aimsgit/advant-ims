Imports Microsoft.VisualBasic

Public Class FeedBackParamsBL
    Public Function GenerateParameters() As Integer
        Return FeedBackParamsDL.GenerateParameters()
    End Function
    Public Function ViewParameters() As Data.DataTable
        Return FeedBackParamsDL.ViewParameters()
    End Function
    Public Function ClearParameters() As Integer
        Return FeedBackParamsDL.ClearParameters()
    End Function
    Public Function UpdateFeedBackParameters(ByVal FeedBackId As Integer, ByVal ParameterName As String, ByVal Max As Integer, ByVal Min As Integer, ByVal Weightage As Integer) As Integer
        Return FeedBackParamsDL.UpdateFeedBackParameters(FeedBackId, ParameterName, Max, Min, Weightage)
    End Function

    Public Function CheckFeedBackGenStatus() As Data.DataTable
        Return FeedBackParamsDL.CheckFeedBackGenStatus()
    End Function
    Public Function InsertRecordFeed(ByVal EL As ELFeedbackDept) As Integer
        Return FeedBackParamsDL.InserFeedbackDept(EL)
    End Function
    Public Function DisplayDeptFeedback(ByVal EL As ELFeedbackDept) As Data.DataTable
        Return FeedBackParamsDL.DisplayDeptFeedback(EL)
    End Function
    Public Function UpdateDeptFeedBack(ByVal EN As ELFeedbackDept) As Integer
        Return FeedBackParamsDL.UpdateDeptFeedback(EN)
    End Function
    Public Function PublishFeedback(ByVal DeptId As Integer) As Integer
        Return FeedBackParamsDL.PublishFeedback(DeptId)
    End Function
End Class
