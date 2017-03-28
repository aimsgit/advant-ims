Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Public Class ProspectusB
    Public Function GetProspectus(ByVal id As Long) As List(Of Prospectus)
        Dim prospectus As New List(Of Prospectus)
        Dim ds As DataSet = ProspectusDB.GetProspectus(id, 0, 0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            prospectus.Add(New Prospectus(row("Prosp_ID"), row("BranchCode"), row("Entry_Date"), row("Prosp_Price"), row("Remarks"), row("Student_Name"), row("SerialNo"), row("Prosp_Quantity"), row("PReceipt_No"), row("Admitted_Flag"), row("Qty_In"), row("Qty_Out")))
        Next
        Return prospectus
    End Function
    Public Function GetProspectus(ByVal InstituteID As Int64, ByVal BranchID As Int64) As List(Of Prospectus)
        Dim prospectus As New List(Of Prospectus)
        Dim ds As DataSet = ProspectusDB.GetProspectus(0, InstituteID, BranchID)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            prospectus.Add(New Prospectus(row("Prosp_ID"), row("BranchCode"), row("Entry_Date"), row("Prosp_Price"), row("Remarks"), row("Student_Name"), row("SerialNo"), row("Prosp_Quantity"), row("PReceipt_No"), row("Admitted_Flag"), row("Qty_In"), row("Qty_Out")))
        Next
        Return prospectus
    End Function
    Public Function GetProspectus() As List(Of Prospectus)
        Dim prospectus As New List(Of Prospectus)
        Dim ds As DataSet = ProspectusDB.GetProspectus(0, 0, 0)

        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            prospectus.Add(New Prospectus(row("Prosp_ID"), row("BranchCode"), row("Entry_Date"), row("Prosp_Price"), row("Remarks"), row("Student_Name"), row("SerialNo"), row("Prosp_Quantity"), row("PReceipt_No"), row("Admitted_Flag"), row("Qty_In"), row("Qty_Out")))
        Next
        Return prospectus
    End Function
    Public Function InsertRecord(ByVal p As Prospectus) As Integer
        If p.Remarks = Nothing Then
            p.Remarks = ""
        End If
        Return ProspectusDB.Insert(p)
    End Function
    Public Function UpdateRecord(ByVal p As Prospectus) As Integer
        If p.Remarks = Nothing Then
            p.Remarks = ""
        End If
        Return ProspectusDB.Update(p)
    End Function
    Public Function ChangeFlag(ByVal p As Prospectus) As Integer
        Return ProspectusDB.ChangeFlag(p.Id)
    End Function
    Public Function EnquiryEditByProsp(ByVal id As Int64) As Data.DataTable
        Return ProspectusDB.EnqEditData(id)
    End Function
    Public Function ProspID(ByVal id As Int64, ByVal brch As Int64) As Data.DataTable
        Return ProspectusDB.ProspID(id, brch)
    End Function
    Public Function UpdateEnqDetl(ByVal p As Prospectus) As Integer
        Return ProspectusDB.UpdateEnq(p.SerialNo, p.Institute, p.Branch)
    End Function
    Public Function DeleteProspByEnq(ByVal p As Prospectus) As Integer
        Return ProspectusDB.DeleteProsp(p.EID)
    End Function
    Public Function EIdfmProsp(ByVal id As Int64) As Data.DataTable
        Return ProspectusDB.GetEidfmProsp(id)
    End Function
    Public Function ProspBalance() As Data.DataTable
        Return ProspectusDB.ProspBal()
    End Function
    Public Function GetReport() As Data.DataTable
        Return ProspectusDB.GetReport()
    End Function
    Public Function Getprospdtls(ByVal id As Long, ByVal RadioButtonSelection As String) As Data.DataTable
        Return ProspectusDB.DispGrid(id, RadioButtonSelection)
    End Function
    Public Function RptCompPros(ByVal inst As Int64, ByVal bran As Int64) As Data.DataTable
        Return ProspectusDB.RptCompPros(inst, bran)
    End Function
    Public Function GetDuplicateProspectus(ByVal p As Prospectus) As Data.DataTable
        Return ProspectusDB.GetDuplicateProspectus(p)
    End Function
End Class
