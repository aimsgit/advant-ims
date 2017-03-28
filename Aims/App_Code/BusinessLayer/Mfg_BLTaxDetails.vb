Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class Mfg_BLTaxDetails
    Dim DL As Mfg_DLTaxDetails
    Public Function GetDuplicateTaxDetails(ByVal EL As String, ByVal id As Integer) As DataTable
        Return DL.GetDuplicateTaxDEtails(EL, id)
    End Function
    Public Function UpdateRecord(ByVal EL As Mfg_ELTaxDetails) As Integer
        Return Mfg_DLTaxDetails.Update(EL)
    End Function
    Public Function InsertRecord(ByVal EL As Mfg_ELTaxDetails) As Integer
        Return Mfg_DLTaxDetails.Insert(EL)
    End Function
    Public Function GetGridData(ByVal Id As Integer) As DataTable
        Return Mfg_DLTaxDetails.GetGridData(Id)
    End Function
    Public Function ChangeFlag(ByVal EL As Mfg_ELTaxDetails) As Integer
        Return Mfg_DLTaxDetails.ChangeFlag(EL)
    End Function
End Class
