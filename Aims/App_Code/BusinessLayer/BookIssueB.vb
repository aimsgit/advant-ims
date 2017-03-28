Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BookIssueB
    Public Function GetBookCount(ByVal id As Long) As Data.DataTable
        Return BookIssueDB.GetBookCount(id)
    End Function
    Public Function GetStdBookIssuedDet(ByVal bookid As Long, ByVal stdno As Long, ByVal brch As Long, ByVal inst As Long) As Data.DataTable
        Return BookIssueDB.GetStdBookIssued(bookid, stdno, brch, inst)
    End Function
    Public Function GetEmpBookIssuedDet(ByVal bookid As Long, ByVal empno As Long, ByVal brch As Long, ByVal inst As Long) As Data.DataTable
        Return BookIssueDB.GetEmpBookIssued(bookid, empno, brch, inst)
    End Function
    Public Function InsertRecord(ByVal b As BookIssue) As Integer
        Return BookIssueDB.Insert(b)
    End Function
    Public Function UpdateRecord(ByVal BLIssue As BookIssue) As Integer
        Return BookIssueDB.Update(BLIssue)
    End Function
    Public Function Display(ByVal ELIssue As BookIssue) As Data.DataTable
        Return BookIssueDB.DisplayGridValue(ELIssue)
    End Function
    Public Function DisplayByID(ByVal ELIssue As BookIssue) As Data.DataTable
        Return BookIssueDB.DisplayGridValueByID(ELIssue)
    End Function
    Public Function duplicate(ByVal ELIssue As BookIssue) As Data.DataTable
        Return BookIssueDB.Getduplicate(ELIssue)
    End Function
    Public Function GetBookNameExt(ByVal prefixText As String) As Data.DataTable
        Return BookIssueDB.GetBookNameExt(prefixText)
    End Function
    Public Function GetBookNameExtN(ByVal prefixText As String) As Data.DataTable
        Return BookIssueDB.GetBookNameExt(prefixText)
    End Function
End Class
