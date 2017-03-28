Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class Mfg_RptPurchaseInvoiceBL

    Public Function GetPurInv(ByVal Supp_id As Integer) As Data.DataTable
        Dim dt As DataTable = mfg_RptPurchaseInvoiceDL.GetPurInv(Supp_id)
        Return dt
    End Function

    
End Class



