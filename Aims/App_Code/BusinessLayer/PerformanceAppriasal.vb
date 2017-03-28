Imports Microsoft.VisualBasic

Public Class PerformanceAppriasal
    Public Function GenerateParameters(ByVal TP As Integer, ByVal Sp As Integer) As Integer
        Return PerfAppriasalDL.GenerateParameters(TP, Sp)
    End Function
    Public Function ViewParameters(ByVal app As Integer) As Data.DataTable
        Return PerfAppriasalDL.ViewParameters(app)
    End Function
    Public Function ClearParameters(ByVal app As Integer) As Integer
        Return PerfAppriasalDL.ClearParameters(app)
    End Function
    Public Function UpdateFeedBackParameters(ByVal FeedBackId As Integer, ByVal ParameterName As String, ByVal Max As Integer, ByVal Min As Integer) As Integer
        Return PerfAppriasalDL.UpdateFeedBackParameters(FeedBackId, ParameterName, Max, Min)
    End Function

    Public Function CheckFeedBackGenStatus(ByVal app As Integer) As Data.DataTable
        Return PerfAppriasalDL.CheckFeedBackGenStatus(app)
    End Function
End Class
