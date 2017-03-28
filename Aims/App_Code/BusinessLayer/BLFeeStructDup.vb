Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class BLFeeStructDup
    Public Function GetDuplicate(ByVal f As feeStructureE) As Data.DataTable
        Return DLFeeStructDup.GetFeeStructureDuplicate(f)
    End Function
    Public Function GetDuplicateNew(ByVal f As feeStructureE) As Data.DataTable
        Return DLFeeStructDup.GetFeeStructureDuplicateNew(f)
    End Function
End Class
