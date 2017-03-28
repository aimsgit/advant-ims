Imports Microsoft.VisualBasic

Public Class BLFrmCollectSponsor
    Dim DL As New DLFrmCollectSponsor
    Public Function InsertSponsor(ByVal EL As ELFrmCollectSponsor) As Integer
        Return DL.InsertSponsor(EL)
    End Function
    Public Function UpdateSponsor(ByVal EL As ELFrmCollectSponsor) As String
        Return DLFrmCollectSponsor.UpdateSponsor(EL)
    End Function
    Public Function DisplayGridview(ByVal id As Integer, ByVal STDID As Integer) As DataTable
        Return DLFrmCollectSponsor.DisplayGridview(id,STDID)
    End Function
    Public Function DeleteSponsor(ByVal EL As ELFrmCollectSponsor) As Integer
        Return DL.DeleteSponsor(EL)
    End Function
    Public Function CheckDuplicate(ByVal EL As ELFrmCollectSponsor) As System.Data.DataTable
        Return DL.CheckDuplicate(EL)
    End Function
    Public Function DisplayGridviewPayable(ByVal A_Year As Integer, ByVal BatchId As Integer, ByVal StdID As Integer, ByVal Category As Integer) As DataTable
        Return DLFrmCollectSponsor.GetFeePayableDetails(A_Year, BatchId, StdID, Category)
    End Function
    Public Function DisplayGridviewPaid(ByVal A_Year As Integer, ByVal BatchId As Integer, ByVal StdID As Integer, ByVal Category As Integer) As DataTable
        Return DLFrmCollectSponsor.GetFeePaidDetails(A_Year, BatchId, StdID, Category)
    End Function
    Public Function InsertSponsorRef(ByVal EL As ELFrmCollectSponsor) As Integer
        Return DL.InsertSponsorRef(EL)
    End Function
    Public Function CheckDuplicateRef(ByVal EL As ELFrmCollectSponsor) As System.Data.DataTable
        Return DL.CheckDuplicateRef(EL)
    End Function
    Public Function UpdateSponsorTransfer(ByVal EL As ELFrmCollectSponsor) As Integer
        Return DLFrmCollectSponsor.UpdateSponsorTransfer(EL)
    End Function
    Public Function UpdateRefund(ByVal EL As ELFrmCollectSponsor) As String
        Return DLFrmCollectSponsor.UpdateRefund(EL)
    End Function
    Public Function GetSponsorAmt(ByVal STDID As Integer) As DataTable
        Return DLFrmCollectSponsor.GetSponsorAmt(STDID)
    End Function
    Public Function UpdateTransfer(ByVal EL As ELFrmCollectSponsor) As String
        Return DLFrmCollectSponsor.UpdateTransfer(EL)
    End Function

End Class
