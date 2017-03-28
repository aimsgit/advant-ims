Imports Microsoft.VisualBasic

Public Class BLAttenSummaryBySubject
    Dim DL As DLAttenSummaryBySubject
    Public Function RunSummary(ByVal El As ELAttenSummaryBySubject) As Integer
        Return DLAttenSummaryBySubject.RunSummary(El)
    End Function

    Public Function BatchAccess(ByVal El As ELAttenSummaryBySubject) As Data.DataTable
        Return DL.BatchAccess(El)
    End Function

    Public Function SemAccess(ByVal El As ELAttenSummaryBySubject) As Data.DataTable
        Return DL.SemAccess(El)
    End Function

    Public Function DuplicateSummary(ByVal El As ELAttenSummaryBySubject) As DataTable
        Return DLAttenSummaryBySubject.DuplicateSummary(El)
    End Function

    Public Function ViewSummary(ByVal El As ELAttenSummaryBySubject) As DataTable
        Return DLAttenSummaryBySubject.ViewSummary(El)
    End Function

    Public Function ClearSummary(ByVal El As ELAttenSummaryBySubject) As Integer
        Return DLAttenSummaryBySubject.ClearSummary(El)
    End Function

    Public Function ClrSummary(ByVal id As Integer) As Integer
        Return DLAttenSummaryBySubject.ClrSummary(id)
    End Function

    Public Function UpdateSummary(ByVal id As Integer, ByVal TotAttend As Integer, ByVal ActAttend As Integer) As Integer
        Return DLAttenSummaryBySubject.UpdateSummary(id, TotAttend, ActAttend)
    End Function

    Public Function ChkLockSummary(ByVal El As ELAttenSummaryBySubject) As DataSet
        Return DLAttenSummaryBySubject.ChkLockSummary(El)
    End Function
    Public Function LockSummary(ByVal El As ELAttenSummaryBySubject) As Integer
        Return DLAttenSummaryBySubject.LockSummary(El)
    End Function
    Public Function UnLockSummary(ByVal El As ELAttenSummaryBySubject) As Integer
        Return DLAttenSummaryBySubject.UnLockSummary(El)
    End Function
End Class
