Imports Microsoft.VisualBasic

Public Class GeneralLedgercls
    Shared Function GetGeneralLedgRpt(ByVal AH As Int16, ByVal PR As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal AC As Int16) As Data.DataTable
        Return GeneralLedgerDB.GetGeneralLedgRpt(AH, PR, StartDate, EndDate, AC)
    End Function
End Class
