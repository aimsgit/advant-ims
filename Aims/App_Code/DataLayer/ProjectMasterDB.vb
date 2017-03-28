Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class ProjectMasterDB
    'Shared Function GetProject() As System.Data.DataSet
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetProjectDetails")
    '    Return ds
    'End Function
    Shared Function GetProject(ByVal projectid As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        'If placementid = 0 Then
        '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getPlacementDetails")
        'Else
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@ProjectId", SqlDbType.Int)
        arParms.Value = projectid
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetProjectDetails", arParms)
        'End If
        Return ds
    End Function
   
    Shared Function ChangeFlag(ByVal Id As Long) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@ProjectId", SqlDbType.Int)
        arParms(0).Value = Id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteProjectMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetProjectMaster(ByVal Inst As Int64, ByVal Brch As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Institute", SqlDbType.Int)
        arParms(0).Value = Inst

        arParms(1) = New SqlParameter("@Branch", SqlDbType.Int)
        arParms(1).Value = Brch

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetProjectMaster", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetProjectDetails(ByVal Inst As Int64, ByVal Brch As Int64, ByVal ProjectId As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Institute", SqlDbType.Int)
        arParms(0).Value = Inst

        arParms(1) = New SqlParameter("@Branch", SqlDbType.Int)
        arParms(1).Value = Brch

        arParms(2) = New SqlParameter("@ProjectId", SqlDbType.Int)
        arParms(2).Value = ProjectId
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetProject", arParms)
        Return ds.Tables(0)
    End Function
End Class
