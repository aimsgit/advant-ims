Imports Microsoft.VisualBasic

Public Class BLSubjectSubgrp
    Dim DL As New DLSubjectSubgroup
    Public Function InsertRecord(ByVal EL As ELSubjectSubgrp) As Integer
        Return DLSubjectSubgroup.Insert(EL)
    End Function
    Public Function UpdateRecord(ByVal EL As ELSubjectSubgrp) As Integer
        Return DLSubjectSubgroup.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As ELSubjectSubgrp) As Integer
        Return DLSubjectSubgroup.ChangeFlag(EL)
    End Function
    Public Function GetGridData(ByVal EL As ELSubjectSubgrp) As DataTable
        Return DLSubjectSubgroup.GetGridData(EL)
    End Function
    Public Function CheckDuplicate(ByVal EL As ELSubjectSubgrp) As System.Data.DataTable
        Return DL.CheckDuplicate(EL)
    End Function
End Class
