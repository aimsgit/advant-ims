Imports Microsoft.VisualBasic

Public Class BLOpeningBalanceEntry
    Dim DL As New DLOpeningBalanceEntry
    Public Function Insert(ByVal El As ELOpeningBalanceEntry) As Integer
        Return DLOpeningBalanceEntry.Insert(El)
    End Function
    Public Function Update(ByVal El As ELOpeningBalanceEntry) As Integer
        Return DLOpeningBalanceEntry.Update(El)
    End Function
    Public Function ChangeFlag(ByVal ID As Long) As Integer
        Return DLOpeningBalanceEntry.ChangeFlag(ID)
    End Function
    Public Function GetOpeningBalanceEntry(ByVal El As ELOpeningBalanceEntry) As Data.DataTable
        Return DLOpeningBalanceEntry.GetOpeningBalanceEntry(El)
    End Function
End Class
