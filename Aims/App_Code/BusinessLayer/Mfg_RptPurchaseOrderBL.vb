Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class Mfg_RptPurchaseOrderBL
    Public Function GetSuppName() As Data.DataTable
        Dim dt As DataTable = Mfg_RptPurchaseOrderDL.GetSuppName()
        Return dt
    End Function
    Public Function GetPurOrd(ByVal supp_id As Integer) As Data.DataTable
        Dim dt As DataTable = Mfg_RptPurchaseOrderDL.GetPurOrd(supp_id)
        Return dt
    End Function
End Class



