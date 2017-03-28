Imports Microsoft.VisualBasic

Public Class BLErrorLog
    Dim Dl As New DLErrorLog
    Public Function ShowLog(ByVal El As ElErrorLog) As Data.DataTable
        Return Dl.ShowLog(El)
    End Function
    Public Function ShowError(ByVal LogId As Integer) As Data.DataTable
        Return Dl.ShowError(LogId)
    End Function
    Public Function DeleteErrorLog(ByVal El As ElErrorLog) As Integer
        Return DLErrorLog.DeleteErrorLog(El)
    End Function
    Public Function Close(ByVal El As ElErrorLog) As Integer
        Return DLErrorLog.Close(El)
    End Function
End Class
