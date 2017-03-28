Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data


Public Class ProjectManajer
    Public Function GetProjectMaster(ByVal Inst As Int64, ByVal Brch As Int64) As Data.DataTable
        Dim dt As DataTable = ProjectMasterDB.GetProjectMaster(Inst, Brch)
        Return dt
    End Function
    Public Function GetProject(ByVal Inst As Int64, ByVal Brch As Int64, ByVal ProjectId As Int64) As Data.DataTable
        Return ProjectMasterDB.GetProjectDetails(Inst, Brch, ProjectId)
    End Function

    Public Function ChangeFlag(ByVal Id As Integer) As Integer
        Return ProjectMasterDB.ChangeFlag(Id)
    End Function
End Class


