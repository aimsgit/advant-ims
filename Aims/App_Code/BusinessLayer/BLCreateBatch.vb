Imports Microsoft.VisualBasic

Public Class BLCreateBatch
    Public Function InsertRecord(ByVal b As CreateBatch) As Integer
        Return DLCreateBatch.Insert(b)
    End Function
    Public Function UpdateRecord(ByVal b As CreateBatch) As Integer
        Return DLCreateBatch.UpdateRecord(b)
    End Function
    Public Function GetRecord(ByVal b As CreateBatch) As DataTable
        Return DLCreateBatch.GetRecord(b)
    End Function
    Public Function DeleteRecord(ByVal id As Long) As Integer
        Return DLCreateBatch.DeleteRecord(id)
    End Function
    Public Function getCreateBatchCourse() As DataTable
        Return DLCreateBatch.getCreateBatchCourse()
    End Function

    Public Function GetCreateBatchAcademicYearCombo() As DataTable
        Return DLCreateBatch.GetCreateBatchAcademicYearCombo()
    End Function

    Public Function CheckDuplicate(ByVal b As CreateBatch) As DataTable
        Return DLCreateBatch.CheckDuplicate(b)
    End Function

End Class
