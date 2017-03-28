Imports Microsoft.VisualBasic

Public Class PartyLedger
    Shared Function GetGenPartyLedgRpt() As Data.DataTable
        Return PartyLedgerDB.GetGenPartyLedgRpt()
    End Function
End Class
