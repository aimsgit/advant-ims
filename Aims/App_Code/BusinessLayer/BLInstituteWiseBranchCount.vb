Imports Microsoft.VisualBasic

Public Class BLInstituteWiseBranchCount
    Public Function GetInstituteWiseBranch() As System.Data.DataTable
        Return DLInstituteWiseBranchCount.GetInstituteWiseBranch()
    End Function
    Public Function GetInstituteWiseBranchZone(ByVal HOCode As String) As System.Data.DataTable
        Return DLInstituteWiseBranchCount.GetInstituteWiseBranchZone(HOCode)
    End Function
    Public Function GetInstituteWiseBranchRO(ByVal HOCode As String) As System.Data.DataTable
        Return DLInstituteWiseBranchCount.GetInstituteWiseBranchRO(HOCode)
    End Function
    Public Function GetInstituteWiseBranchHUB(ByVal HOCode As String) As System.Data.DataTable
        Return DLInstituteWiseBranchCount.GetInstituteWiseBranchHUB(HOCode)
    End Function
    Public Function GetInstituteWiseBranchCenter(ByVal HOCode As String) As System.Data.DataTable
        Return DLInstituteWiseBranchCount.GetInstituteWiseBranchCenter(HOCode)
    End Function
End Class
