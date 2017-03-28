Imports Microsoft.VisualBasic
Public Class BLBatchPlanner
    Dim dl As New DLBatchPlanner
    'Public Function InsertBatchPlanner(ByVal p As BatchPlanner) As Integer
    '    Return DLBatchPlanner.InsertBatchPlanner(p)
    'End Function
    Public Function UpdateBatchPlanner(ByVal p As BatchPlanner) As Integer
        Return DLBatchPlanner.UpdateBatchPlanner(p)
    End Function
    Public Function DeleteBatchPlanner(ByVal id As Integer) As Integer
        Return DLBatchPlanner.DeleteBatchPlanner(id)
    End Function
    Public Function GetBatchPlannerView(ByVal p As BatchPlanner) As Data.DataTable
        Return DLBatchPlanner.GetBatchPlannerView(p)
    End Function
    Public Function CheckLockBatchPl(ByVal p As BatchPlanner) As DataSet
        Return DLBatchPlanner.CheckLockBatchPl(p)
    End Function
    Public Function UNLockBatchPl(ByVal p As BatchPlanner) As Integer
        Return DLBatchPlanner.UNLockBatchPl(p)
    End Function
    Public Function CheckLockBatchPln(ByVal p As BatchPlanner) As Integer
        Return DLBatchPlanner.CheckLockBatchPln(p)
    End Function
    Public Function GetAcedemicYear(ByVal p As BatchPlanner) As Integer
        Return DLBatchPlanner.GetAcedemicYear(p)
    End Function
    Public Function GetBatchPlanner(ByVal p As BatchPlanner) As Integer
        Return DLBatchPlanner.GetBatchPlanner(p)
    End Function
    Public Function getBatchPlannerCombo() As Data.DataTable
        Return DLBatchPlanner.getBatchPlannerCombo()
    End Function
    Public Function filltextbox(ByVal p As BatchPlanner) As Data.DataTable
        Return DLBatchPlanner.filltextbox(p)
    End Function
    Public Function GetLecturercombo() As Data.DataTable
        Return DLBatchPlanner.GetLecturercombo()
    End Function
    Public Function GetEmpUpdate(ByVal p As BatchPlanner) As Integer
        Return DLBatchPlanner.GetEmpUpdate(p)
    End Function
    Public Function DeleteBatchPlanner1(ByVal id As Integer) As Integer
        Return DLBatchPlanner.DeleteBatchPlanner1(id)
    End Function
    Public Function UpdateCollectionVerification(ByVal El As BatchPlanner) As Integer
        Return dl.UpdateCollectionVerification(El)
    End Function
End Class
