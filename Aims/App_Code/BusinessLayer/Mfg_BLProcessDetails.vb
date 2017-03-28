Imports Microsoft.VisualBasic

Public Class Mfg_BLProcessDetails
    Dim DL As New Mfg_DLProcessDetails
    Public Function InsertProcessMaster(ByVal i As Mfg_ELProcessDetails) As Integer
        Return DL.InsertProcessMaster(i)
    End Function
    Public Function InsertProcessDetails(ByVal i As Mfg_ELProcessDetails) As Integer
        Return DL.InsertProcessDetails(i)
    End Function
    Public Function UpdateRecord(ByVal i As Mfg_ELProcessDetails) As Integer
        Return DL.UpdateProcessDetails(i)
    End Function
    Public Function GetProcessDetails(ByVal i As Mfg_ELProcessDetails) As DataTable
        Return DL.GetProcessDetails(i)
    End Function
    Public Function UpdateProcessMaster(ByVal i As Mfg_ELProcessDetails) As Integer
        Return DL.UpdateProcessMaster(i)
    End Function
    Public Function DeteteProcessMaster(ByVal i As Mfg_ELProcessDetails) As Integer
        Return DL.DeteteProcessMaster(i)
    End Function

    Public Function DeteteProcessDetails(ByVal i As Mfg_ELProcessDetails) As Integer
        Return DL.DeteteProcessDetails(i)
    End Function
   
    Public Function GetProcessMaster(ByVal i As Mfg_ELProcessDetails) As DataTable
        Return DL.GetProcessMaster(i)
    End Function
  
    Public Function GetProcessID() As DataTable
        Return DL.GetProcessID()
    End Function
End Class
