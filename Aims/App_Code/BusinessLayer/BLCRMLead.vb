Imports Microsoft.VisualBasic

Public Class BLCRMLead
    Public Function Delete(ByVal LeadID As Integer) As Integer
        Return DLCRMLead.Delete(LeadID)
    End Function
    Public Function CloseAlert(ByVal LeadID As Integer) As Integer
        Return DLCRMLead.CloseAlert(LeadID)
    End Function
    Public Function DeleteDemo(ByVal LeadID As Integer) As Integer
        Return DLCRMLead.DeleteDemo(LeadID)
    End Function
    Public Function InsertUpdate(ByVal EL As ELCRMLead) As Integer
        Return DLCRMLead.InsertUpdate(EL)
    End Function
    Public Function Display(ByVal EL As ELCRMLead) As DataTable
        Return DLCRMLead.Display(EL)
    End Function
    Public Function DisplayAlerts(ByVal FromDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Return DLCRMLead.DisplayAlerts(FromDate, ToDate)
    End Function
    Public Function GetDemoDetailsfordrilldown(ByVal DemoDate As DateTime) As DataTable
        Return DLCRMLead.GetDemoDetailsfordrilldown(DemoDate)
    End Function
    Public Function GetDemoDetails(ByVal El As ELCRMLead) As DataTable
        Return DLCRMLead.GetDemoDetails(El)
    End Function
    Public Function GetCommunication(ByVal LeadID As String) As DataTable
        Return DLCRMLead.GetCommunication(LeadID)
    End Function
    Public Function InsertUpdateDemo(ByVal EL As ELCRMLead) As Integer
        Return DLCRMLead.InsertUpdateDemo(EL)
    End Function
    Public Function InsertUpdateProposal(ByVal EL As ELCRMLead) As Integer
        Return DLCRMLead.InsertUpdateProposal(EL)
    End Function
    Public Function GetProposalDetailsfordrilldown(ByVal DemoDate As DateTime) As DataTable
        Return DLCRMLead.GetProposalDetailsfordrilldown(DemoDate)
    End Function
    Public Function GetProposalDetails(ByVal El As ELCRMLead) As DataTable
        Return DLCRMLead.GetProposalDetails(El)
    End Function
End Class
