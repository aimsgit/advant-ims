Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BookManager
    Dim BMDB As New BookMasterDB

    Public Function subjectcombo() As Data.DataTable
        'for Combo box
        Return BookMasterDB.subjectcombo()
    End Function
    Public Function InsertRecord(ByVal BM As BookMaster) As Integer
        Return BookMasterDB.Insert(BM)
    End Function
    Public Function UpdateRecord(ByVal BM As BookMaster) As Integer
        Return BookMasterDB.Update(BM)
    End Function
    Public Function ChangeFlag(ByVal bk As BookMaster) As Integer
        Return BookMasterDB.ChangeFlag(bk.Id)
    End Function
    Public Function BookCode() As Data.DataTable
        Return BookMasterDB.GetBookCode()
    End Function
    Public Function MaxBookCode() As Data.DataTable
        Return BookMasterDB.GetMaxBookCode()
    End Function
    Public Function GetBookId(ByVal code As String, ByVal ins As Int64, ByVal brn As Int64) As Data.DataTable
        Return BookMasterDB.GetBookId(code, ins, brn)
    End Function
    Public Function GetBookQuantity(ByVal id As Long, ByVal ins As Int64, ByVal brn As Int64) As Data.DataTable
        Return BookMasterDB.GetBookQuantity(id, ins, brn)
    End Function
    Public Function GetDataFromBook(ByVal AssetDetail_ID As Long) As Data.DataTable
        Return BookMasterDB.Getdatafrmbook(AssetDetail_ID)
    End Function
    Public Function GetReportL(ByVal inst As Int64, ByVal brch As Int64) As List(Of BookMaster)
        Dim book As New List(Of BookMaster)
        Dim row As DataRow
        Dim ds As New DataSet
        ds = BookMasterDB.GetReport(inst, brch)
        For Each row In ds.Tables(0).Rows
            book.Add(New BookMaster(row("Book_ID"), row("BookName"), row("BookCode"), row("Author"), row("BookPublisher"), row("BookEditionNo"), row("Pages"), row("Subject_ID"), row("Branch_ID"), row("Institute_ID"), row("Quantity"), row("Price"), row("Transfer_Book_ID"), row("InstituteName"), row("BranchName")))
        Next
        Return book
    End Function
    Public Function GetReport(ByVal inst As Int64, ByVal brch As Int64) As Data.DataTable
        Return BookMasterDB.GetReport(inst, brch).Tables(0)
    End Function
    Public Function UpdateQtyPrice(ByVal b As BookMaster) As Integer
        Return BookMasterDB.UpdateQtyPrice(b)
    End Function
    Public Function GetBookDetails(ByVal b As BookMaster) As Data.DataTable
        Return BookMasterDB.DispGrid(b)
    End Function
    'For Prevanting from Duplicate Entry
    Public Function GetDuplicateENTRY(ByVal BM As BookMaster) As DataTable
        Return BMDB.GetDuplicateEntry(BM)
    End Function
End Class
