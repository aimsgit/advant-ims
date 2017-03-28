Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLPublishResult
    Shared Function GetGridData(ByVal EL As ELPublishResult) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(1).Value = EL.Batchid

        arParms(2) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(2).Value = EL.Semesterid

        arParms(3) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(3).Value = EL.Subjectid

        arParms(4) = New SqlParameter("@AssessmentType", SqlDbType.Int)
        arParms(4).Value = EL.Assessmentid



        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_PublishResult", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal EL As ELPublishResult) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(1).Value = EL.Batchid

        arParms(2) = New SqlParameter("@SemesterId", SqlDbType.Int)
        arParms(2).Value = EL.Semesterid

        arParms(3) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(3).Value = EL.Subjectid

        arParms(4) = New SqlParameter("@AssessmentId", SqlDbType.Int)
        arParms(4).Value = EL.Assessmentid

        arParms(5) = New SqlParameter("@Publish_Result", SqlDbType.VarChar, 2)
        arParms(5).Value = EL.Publish_Result

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("Empcode")



        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdatePublishResult", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
End Class
