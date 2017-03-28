Imports Microsoft.VisualBasic

Public Class BLCreateExamCalendar
    Dim Dl As New DLCreateExamCalendar
    Public Function Insert(ByVal b As ELCreateExamCalendar) As Integer
        Return DLCreateExamCalendar.Insert(b)
    End Function

    Public Function Update(ByVal b As ELCreateExamCalendar) As Integer
        Return DLCreateExamCalendar.Insert(b)
    End Function
    Public Function GetAddCreateExamCalender(ByVal e As String) As Data.DataTable
        Return DLCreateExamCalendar.GetAddCreateExamCalender(e)
    End Function
    Public Function GetCreateExamCalender(ByVal b As ELCreateExamCalendar) As Data.DataTable
        Return DLCreateExamCalendar.GetCreateExamCalender(b)
    End Function

    Public Function GetPublishCreateExamCalender(ByVal b As ELCreateExamCalendar) As Data.DataTable
        Return DLCreateExamCalendar.GetPublishCreateExamCalender(b)
    End Function
    'Public Function GetLockStatus(ByVal b As ELCreateExamCalendar) As Integer
    '    Return DLCreateExamCalendar.GetLockStatus(b)
    'End Function

    Public Function UpdatePublish(ByVal b As ELCreateExamCalendar) As Integer
        Return DLCreateExamCalendar.UpdatePublish(b)
    End Function
    Public Function Delete(ByVal EL As ELCreateExamCalendar) As Integer
        Return DLCreateExamCalendar.delete(EL)
    End Function

    Public Function CntData(ByVal ExamBatchId As Integer) As Data.DataSet
        Return Dl.CntData(ExamBatchId)
    End Function

    Public Function LockData(ByVal ExamBatchId As Integer) As Integer
        Return DLCreateExamCalendar.LockData(ExamBatchId)
    End Function

    Public Function GetunlockData(ByVal Id As String) As Data.DataTable
        Return DLCreateExamCalendar.GetunlockData(Id)
    End Function

    Public Function UnLockData(ByVal ExamBatchId As Integer) As Integer
        Return DLCreateExamCalendar.UnLockData(ExamBatchId)
    End Function

    Public Function CountData(ByVal ExamBatchId As Integer) As Data.DataSet
        Return Dl.CountData(ExamBatchId)
    End Function
End Class
