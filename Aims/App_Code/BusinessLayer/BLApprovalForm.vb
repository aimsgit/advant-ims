Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BLApprovalForm
    Public Function GetGrid(ByVal TableCode As Integer) As DataTable
        Return DLApprovalForm.GetGrid(TableCode)
    End Function
    Public Function GetGrid1(ByVal TableCode As Integer) As DataTable
        Return DLApprovalForm.GetGrid1(TableCode)
    End Function
    Public Function GetBatchGrid(ByVal BatchCode As String) As DataTable
        Return DLApprovalForm.GetBatchGrid(BatchCode)
    End Function
    Public Function Approval(ByVal appr As ApprovalForm) As Integer
        Return DLApprovalForm.Approval(appr)
    End Function
    Public Function ApprovalStudent(ByVal appr As ApprovalForm) As Integer
        Return DLApprovalForm.ApprovalStudent(appr)
    End Function
    Public Function ApprovalPurchase(ByVal appr As ApprovalForm) As Integer
        Return DLApprovalForm.ApprovalPurchase(appr)
    End Function
    Public Function Approval1(ByVal appr As ApprovalForm) As Integer
        Return DLApprovalForm.Approval1(appr)
    End Function
    Public Function Rejection() As Integer
        Return DLApprovalForm.Rejection()
    End Function
    Public Function SCRejection() As Integer
        Return DLApprovalForm.SCRejection()
    End Function
    Public Function PRejection() As Integer
        Return DLApprovalForm.PRejection()
    End Function
    Public Function RRejection(ByVal Remarks As String) As Integer
        Return DLApprovalForm.RRejection(Remarks)
    End Function
    Public Function GratuityRejection() As Integer
        Return DLApprovalForm.GratuityRejection()
    End Function
   Public Function GetEnrollAgentDdl(ByVal branch As String) As Data.DataTable
        Return DLApprovalForm.GetEnrollAgentDdl(branch)
    End Function
    Public Function email(ByVal EmpId As Integer) As Data.DataTable
        Return DLApprovalForm.email(EmpId)
    End Function
    Public Function Nextemail(ByVal EmpId As Integer, ByVal RNo As Integer) As Data.DataTable
        Return DLApprovalForm.Nextemail(EmpId, RNo)
    End Function
    Public Function email1(ByVal EmpId1 As Integer) As Data.DataTable
        Return DLApprovalForm.email(EmpId1)
    End Function
    Public Function ApproveforCancellation(ByVal appr As ApprovalForm) As Integer
        Return DLApprovalForm.ApproveforCancellation(appr)
    End Function
    Public Function RejectforCancellation(ByVal Remarks As String) As Integer
        Return DLApprovalForm.RejectforCancellation(Remarks)
    End Function
    Public Function GetHREmail(ByVal EmpId As Integer) As Data.DataTable
        Return DLApprovalForm.GetHREmail(EmpId)
    End Function

End Class
