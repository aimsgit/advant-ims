Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class feeStructureBL
    Public Function InsertRecord(ByVal f As feeStructureE) As Integer
        Return feeStructureDL.Insert(f)
    End Function
   Public Function UpdateRecord(ByVal f As feeStructureE) As Integer
        Return feeStructureDL.Update(f)
    End Function
    Public Function GetRecord(ByVal feeStructureE As feeStructureE) As DataTable
        Return feeStructureDL.GetRecord(feeStructureE)
    End Function
    Public Function GetRecordNew(ByVal feeStructureE As feeStructureE) As DataTable
        Return feeStructureDL.GetRecordNew(feeStructureE)
    End Function
    Public Function GetCategoryGrid(ByVal feeStructureE As feeStructureE) As DataTable
        Return feeStructureDL.GetCategoryGrid(feeStructureE)
    End Function
    Public Function DeleteRecord(ByVal id As Long) As Integer
        Return feeStructureDL.DeleteRecord(id)
    End Function
    Public Function DeleteRecordNew(ByVal feeStructureE As feeStructureE) As Integer
        Return feeStructureDL.DeleteRecordNew(feeStructureE)
    End Function
    Public Function getCourse(ByVal f As feeStructureE) As DataTable
        Return feeStructureDL.getCourse(f)
    End Function
   
    Public Function batchList(ByVal feeStructureE As feeStructureE) As DataTable
        Return feeStructureDL.GetBatchComboFee(feeStructureE)
    End Function
End Class
