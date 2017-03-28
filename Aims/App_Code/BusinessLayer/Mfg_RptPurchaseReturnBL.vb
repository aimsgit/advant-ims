Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class Mfg_RptPurchaseReturnBL
    Public Function GetPurRet(ByVal Supp_id As Integer) As Data.DataTable
        Dim dt As DataTable = Mfg_RptPurchaseReturnDL.GetPurRet(Supp_id)
        Return dt
    End Function

End Class
