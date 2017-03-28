Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLStudentLeaveApplication
    Shared Function Insert(ByVal DL As ELStudentLeaveApplication) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(8) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@UserCode", SqlDbType.NVarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("UserCode")

        Parms(2) = New SqlParameter("@empCode", SqlDbType.NVarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("EmpCode")

        Parms(3) = New SqlParameter("@Reason", SqlDbType.NVarChar, 500)
        Parms(3).Value = DL.Reason

        Parms(4) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(4).Value = DL.Batch

        Parms(5) = New SqlParameter("@StudentCode", SqlDbType.NVarChar, 50)
        Parms(5).Value = DL.studentcode

        Parms(6) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        Parms(6).Value = DL.FromDate

        Parms(7) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        Parms(7).Value = DL.ToDate

        Parms(8) = New SqlParameter("@NoofDays", SqlDbType.Float)
        Parms(8).Value = DL.NoofDays

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[SP_InsertUserRole]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function Update(ByVal DL As ELStudentLeaveApplication) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(8) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")


        Parms(1) = New SqlParameter("@UserCode", SqlDbType.NVarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("UserCode")

        Parms(2) = New SqlParameter("@empCode", SqlDbType.NVarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("EmpCode")

        Parms(3) = New SqlParameter("@Reason", SqlDbType.NVarChar, 500)
        Parms(3).Value = DL.Reason

        Parms(4) = New SqlParameter("@id", SqlDbType.Int)
        Parms(4).Value = DL.Id

        Parms(5) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        Parms(5).Value = DL.FromDate

        Parms(6) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        Parms(6).Value = DL.ToDate

        Parms(7) = New SqlParameter("@NoofDays", SqlDbType.Float)
        Parms(7).Value = DL.NoofDays

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[SP_InsertUserRole]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetData(ByVal el As ELStudentLeaveApplication) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}
            Parms(0) = New SqlParameter("@id", SqlDbType.Int)
            Parms(0).Value = el.Id

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 1)
            Parms(2).Value = HttpContext.Current.Session("BatchID")

            Parms(3) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 1)
            Parms(3).Value = HttpContext.Current.Session("StudentCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_SelectStudentLeaveApplication]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Delete(ByVal DL As ELStudentLeaveApplication) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Parms(0) = New SqlParameter("@id", SqlDbType.Int)
        Parms(0).Value = DL.Id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_DeleteStudentLeaveApplication]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
End Class
