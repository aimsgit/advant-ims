Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class Payroll
    Shared Function GVComboLeave() As DataTable
        Return Payroll.GVComboLeave
    End Function
    Public Function GetDetails(ByVal id As Long) As List(Of Pay)
        Dim pay As New List(Of Pay)
        Dim ds As DataSet = PayDB.GetDetails(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            pay.Add(New Pay(row("LR_ID"), row("E_ID"), row("LeaveFrom"), row("LeaveTo"), row("LeaveTypes"), row("Approved"), row("ApprovedBy"), row("Remarks"), row("LossOfPayAmt")))
        Next
        Return pay
    End Function
    Public Function GetDetails() As List(Of Pay)
        Dim pay As New List(Of Pay)
        Dim ds As DataSet = PayDB.GetDetails(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            pay.Add(New Pay(row("LR_ID"), row("E_ID"), row("LeaveFrom"), row("LeaveTo"), row("LeaveTypes"), row("Approved"), row("ApprovedBy"), row("Remarks"), row("LossOfPayAmt")))
        Next
        Return pay
    End Function
    Public Function InsertRecord(ByVal r As Pay) As Integer
        If r.Remark = Nothing Then
            r.Remark = ""
        End If
        Return PayDB.Insert(r)
    End Function
    Public Function UpdateRecord(ByVal r As Pay) As Integer
        If r.Remark = Nothing Then
            r.Remark = ""
        End If
        Return PayDB.Update(r)
    End Function
    Public Function ChangeFlag(ByVal r As Pay) As Integer
        Return PayDB.ChangeFlag(r.Id)
    End Function
End Class
