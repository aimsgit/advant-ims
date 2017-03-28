Imports Microsoft.VisualBasic

Public Class BLRollOver
    Dim DAL As New DLRollOver
    Public Function FromStudentGrid(ByVal BatchId As ELRollOver) As DataTable
        Return DAL.FromStudentGrid(BatchId)
    End Function
    Public Function transfer(ByVal el As ELRollOver) As Integer
        Return DAL.transfer(el)
    End Function
    Public Function InsertRecord(ByVal el As ELRollOver) As Integer
        Return DAL.InsertRecord(el)
    End Function
    Public Function RollOver(ByVal el As ELRollOver) As Integer
        Return DAL.RollOver(el)
    End Function
    Public Function CourseTransfer(ByVal el As ELRollOver) As Integer
        Return DAL.CourseTransfer(el)
    End Function
    Public Function Forum(ByVal el As ELRollOver) As Integer
        Return DAL.Forum(el)
    End Function
    Public Function GetForumBatch(ByVal el As ELRollOver) As DataTable
        Return DAL.GetForumBatch(el)
    End Function
    Public Function StudentBatchTransfer(ByVal el As ELRollOver) As Integer
        Return DAL.StudentBatchTransfer(el)
    End Function
    Public Function RollBack(ByVal el As ELRollOver) As Integer
        Return DAL.RollBack(el)
    End Function
    Public Function DeleteForum(ByVal el As ELRollOver) As Integer
        Return DAL.DeleteForum(el)
    End Function
    Public Function LockStatus(ByVal el As ELRollOver) As String
        Return DAL.LockStatus(el)
    End Function
    Public Function LockStatusForum(ByVal el As ELRollOver) As String
        Return DAL.LockStatusForum(el)
    End Function
    Public Function ToStudentGrid(ByVal el As ELRollOver) As DataTable
        Return DAL.ToStudentGrid(el)
    End Function
    Public Function ToStudentGridForum(ByVal el As ELRollOver) As DataTable
        Return DAL.ToStudentGridForum(el)
    End Function
    Public Function lockunlock(ByVal el As ELRollOver) As String
        Return DAL.lockunlock(el)
    End Function
    Public Function GetDuplicateRollOver(ByVal EL As ELRollOver) As DataTable
        Return DAL.GetDuplicateRollOver(EL)
    End Function
    Public Function GetDuplicateForum(ByVal EL As ELRollOver) As DataTable
        Return DAL.GetDuplicateForum(EL)
    End Function
    Public Function GetDuplicateTransfer(ByVal EL As ELRollOver) As DataTable
        Return DAL.GetDuplicateTransfer(EL)
    End Function
End Class
