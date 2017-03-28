Imports Microsoft.VisualBasic


Public Class BLAttenSummary
    Dim DL As DLAttenSummary
    Public Function RunSummary(ByVal El As ELAttenSummary) As Integer
        Return DLAttenSummary.RunSummary(El)
    End Function
    Public Function ViewSummary(ByVal El As ELAttenSummary) As DataTable
        Return DLAttenSummary.ViewSummary(El)
    End Function
    Public Function ClearSummary(ByVal El As ELAttenSummary) As Integer
        Return DLAttenSummary.ClearSummary(El)
    End Function
    Public Function ClrSummary(ByVal id As Integer) As Integer
        Return DLAttenSummary.ClrSummary(id)
    End Function
    Public Function UpdateSummary(ByVal id As Integer, ByVal TotAttend As Integer, ByVal ActAttend As Integer) As Integer
        Return DLAttenSummary.UpdateSummary(id, TotAttend, ActAttend)
    End Function
    Public Function DuplicateSummary(ByVal El As ELAttenSummary) As DataTable
        Return DLAttenSummary.DuplicateSummary(El)
    End Function
    Public Function ChkLockSummary(ByVal El As ELAttenSummary) As DataSet
        Return DLAttenSummary.ChkLockSummary(El)
    End Function
    Public Function LockSummary(ByVal El As ELAttenSummary) As Integer
        Return DLAttenSummary.LockSummary(El)
    End Function
    Public Function UnLockSummary(ByVal El As ELAttenSummary) As Integer
        Return DLAttenSummary.UnLockSummary(El)
    End Function

End Class
