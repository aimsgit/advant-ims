Imports Microsoft.VisualBasic

Public Class BLCommunication
    Dim Dl As New DLCommunicationModule
    Public Function GetNameCombo(ByVal GroupID As Integer, ByVal Code As String, ByVal Name As String) As DataTable
        Return DLCommunicationModule.GetNameCombo(GroupID, Code, Name)
    End Function
    Public Function GetNameComboSuper(ByVal GroupID As Integer, ByVal SelectClient As String, ByVal SelectBranch As String, ByVal Code As String, ByVal Name As String) As DataTable
        Return DLCommunicationModule.GetNameComboSuper(GroupID, SelectClient, SelectBranch, Code, Name)
    End Function
    Public Function InsertCommunication(ByVal el As ELCommunication) As Integer
        Return DLCommunicationModule.InsertCommunication(el)
    End Function
    Public Function GetViewStatus() As DataTable
        Return Dl.GetViewStatus()
    End Function
    Public Function GetSMSTemplate() As DataTable
        Return DLCommunicationModule.GetSMSTemplate()
    End Function
    Public Function GetSMSMessage(ByVal Id As Integer) As DataTable
        Return DLCommunicationModule.GetSMSMessage(Id)
    End Function
End Class
