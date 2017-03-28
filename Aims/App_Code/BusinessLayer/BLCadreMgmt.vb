Imports Microsoft.VisualBasic

Public Class BLCadreMgmt
    Dim DL As DLCadreMgmt
    'Public Function GetCadreMgmt(ByVal el As ELCadreMgmt) As System.Data.DataTable
    '    Return DLCadreMgmt.GetCapacityPlan(el)
    'End Function
    Public Function Insert(ByVal el As ELCadreMgmt) As Integer

        Return DLCadreMgmt.Insert(el)
    End Function
    Public Function Update(ByVal el As ELCadreMgmt) As Integer
        Return DLCadreMgmt.Update(el)
    End Function
    Public Function ChangeFlag(ByVal el As ELCadreMgmt) As Integer

        Return DLCadreMgmt.ChangeFlag(el)
    End Function
    Public Function CheckDuplicate(ByVal EL As ELCadreMgmt) As System.Data.DataTable
        Return DLCadreMgmt.CheckDuplicate(EL)
    End Function
    Public Function ChkLockSummary(ByVal El As ELCadreMgmt) As DataSet
        Return DLCadreMgmt.ChkLockSummary(El)
    End Function
    Public Function ChkLockSummary1(ByVal El As ELCadreMgmt) As DataSet
        Return DLCadreMgmt.ChkLockSummary1(El)
    End Function
    Public Function ChkLockSummary2(ByVal El As ELCadreMgmt) As DataSet
        Return DLCadreMgmt.ChkLockSummary2(El)
    End Function
    Public Function ChkLockSummaryId(ByVal El As ELCadreMgmt) As DataSet
        Return DLCadreMgmt.ChkLockSummaryId(El)
    End Function
    Public Function ChkApproveStatus(ByVal El As ELCadreMgmt) As DataSet
        Return DLCadreMgmt.ChkApproveStatus(El)
    End Function
    Public Function ChkLockStatusChk(ByVal El As ELCadreMgmt) As DataSet
        Return DLCadreMgmt.ChkLockStatusChk(El)
    End Function
    Public Function ChkApproveStatusChk(ByVal El As ELCadreMgmt) As DataSet
        Return DLCadreMgmt.ChkApproveStatusChk(El)
    End Function
    Public Function LockSummary(ByVal El As ELCadreMgmt) As Integer
        Return DLCadreMgmt.LockSummary(El)
    End Function
    Public Function UnLockSummary(ByVal El As ELCadreMgmt) As Integer
        Return DLCadreMgmt.UnLockSummary(El)
    End Function
    Public Function ApproveCadre(ByVal El As ELCadreMgmt) As Integer
        Return DLCadreMgmt.ApproveCadre(El)
    End Function
    Public Function UnApproveCadre(ByVal El As ELCadreMgmt) As Integer
        Return DLCadreMgmt.UnApproveCadre(El)
    End Function
End Class
