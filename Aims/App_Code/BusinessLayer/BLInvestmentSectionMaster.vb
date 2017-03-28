Imports Microsoft.VisualBasic

Public Class BLInvestmentSectionMaster
    Dim DL As New DLInvestmentSectionMaster

    Public Function InsertRecordInv(ByVal EL As ELInvestmentSectionMaster) As Integer
        Return DLInvestmentSectionMaster.InsertInvestnentDet(EL)
    End Function
    Public Function DisplaInvestment(ByVal EL As ELInvestmentSectionMaster) As Data.DataTable
        Return DLInvestmentSectionMaster.DisplayInvestmentDet(EL)
    End Function
    Public Function UpdateInvestment(ByVal EN As ELInvestmentSectionMaster) As Integer
        Return DLInvestmentSectionMaster.UpdateInvestmentDet(EN)
    End Function
    Public Function ChangeFlagInv(ByVal EN As ELInvestmentSectionMaster) As Integer
        Return DLInvestmentSectionMaster.ChangeFlagInv(EN)
    End Function


End Class
