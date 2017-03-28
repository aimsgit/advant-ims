Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLInstituteWiseBranchCount
    Shared Function GetInstituteWiseBranch() As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetInstituteWiseBranch")
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Shared Function GetInstituteWiseBranchZone(ByVal HOCode As String) As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet

            Dim arParms() As SqlParameter = New SqlParameter(0) {}
            arParms(0) = New SqlParameter("@HOCode", SqlDbType.VarChar, 20)
            arParms(0).Value = HOCode

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetInstituteWiseBranchZone", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Shared Function GetInstituteWiseBranchRO(ByVal HOCode As String) As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet

            Dim arParms() As SqlParameter = New SqlParameter(0) {}
            arParms(0) = New SqlParameter("@HOCode", SqlDbType.VarChar, 20)
            arParms(0).Value = HOCode

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetInstituteWiseBranchRO", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Shared Function GetInstituteWiseBranchHUB(ByVal HOCode As String) As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet

            Dim arParms() As SqlParameter = New SqlParameter(0) {}
            arParms(0) = New SqlParameter("@HOCode", SqlDbType.VarChar, 20)
            arParms(0).Value = HOCode

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetInstituteWiseBranchHUB", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Shared Function GetInstituteWiseBranchCenter(ByVal HOCode As String) As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet

            Dim arParms() As SqlParameter = New SqlParameter(0) {}
            arParms(0) = New SqlParameter("@HOCode", SqlDbType.VarChar, 20)
            arParms(0).Value = HOCode

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetInstituteWiseBranchCenter", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
