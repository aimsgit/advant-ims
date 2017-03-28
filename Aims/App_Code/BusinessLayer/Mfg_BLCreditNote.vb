Imports Microsoft.VisualBasic

Public Class Mfg_BLCreditNote
    Dim DL As New Mfg_DLCreditNote
    Public Function GetDetails(ByVal EL As Mfg_ELCreditNote) As DataTable
        Return Mfg_DLCreditNote.GetDetails(EL)
    End Function
    'Public Function CheckDuplicate(ByVal EL As Mfg_ELCreditNote) As System.Data.DataTable
    '    Return DL.CheckDuplicate(EL)
    'End Function
    Public Function Update(ByVal EL As Mfg_ELCreditNote) As Integer
        Return DL.Update(EL)
    End Function
    Public Function Insert(ByVal EL As Mfg_ELCreditNote) As Int16
        Return DL.Insert(EL)
    End Function
    Public Function GetGridData(ByVal EL As Mfg_ELCreditNote) As DataTable
        Return DL.GetGridData(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As Mfg_ELCreditNote) As Integer
        Return DL.ChangeFlag(EL)
    End Function

End Class
