Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLAppraisalform
    Shared Function EmployeeCode(ByVal ApprasialId As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Branchcode")


        arParms(1) = New SqlParameter("@ApprasialId", SqlDbType.Int)
        arParms(1).Value = ApprasialId

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        arParms(3) = New SqlParameter("@Empid", SqlDbType.Int)
        arParms(3).Value = HttpContext.Current.Session("EmpID")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetEmpCodeBasedonApprisalcycle", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function ViewParameters(ByVal EmpId As Integer, ByVal APID As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Empid", SqlDbType.Int)
        arParms(2).Value = EmpId
        arParms(3) = New SqlParameter("@APID", SqlDbType.Int)
        arParms(3).Value = APID
        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getAppraisalPara", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return dt
    End Function
    Public Function InsertAprrisalScore(ByVal EL As ELAppraisalform) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Empid", SqlDbType.Int)
        arParms(2).Value = EL.Empid
        arParms(3) = New SqlParameter("@AppraisalType", SqlDbType.Int)
        arParms(3).Value = EL.AppraisalType
        arParms(4) = New SqlParameter("@PID", SqlDbType.Int)
        arParms(4).Value = EL.P_Id
        'arParms(5) = New SqlParameter("@id", SqlDbType.Int)
        'arParms(5).Value = EL.id
        arParms(5) = New SqlParameter("@S_score", SqlDbType.Int)
        arParms(5).Value = EL.S_score
        'arParms(6) = New SqlParameter("@M_score", SqlDbType.Int)
        'arParms(6).Value = EL.M_score
        'arParms(7) = New SqlParameter("@R_score", SqlDbType.Int)
        'arParms(7).Value = EL.R_score
        'arParms(8) = New SqlParameter("@F_score", SqlDbType.Int)
        'arParms(8).Value = EL.F_score
        arParms(6) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Empcode")
        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")
        arParms(8) = New SqlParameter("@APID", SqlDbType.Int)
        arParms(8).Value = EL.APID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InsertApprisalScore", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function UpdateAprrisalScore(ByVal EL As ELAppraisalform) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Empid", SqlDbType.Int)
        arParms(2).Value = EL.Empid
        'arParms(3) = New SqlParameter("@AppraisalType", SqlDbType.Int)
        'arParms(3).Value = EL.AppraisalType
        arParms(3) = New SqlParameter("@PID", SqlDbType.Int)
        arParms(3).Value = EL.P_Id
        'arParms(5) = New SqlParameter("@id", SqlDbType.Int)
        'arParms(5).Value = EL.id
        'arParms(5) = New SqlParameter("@S_score", SqlDbType.Int)
        'arParms(5).Value = EL.S_score
        arParms(4) = New SqlParameter("@M_score", SqlDbType.Int)
        arParms(4).Value = EL.M_score
        'arParms(7) = New SqlParameter("@R_score", SqlDbType.Int)
        'arParms(7).Value = EL.R_score
        'arParms(8) = New SqlParameter("@F_score", SqlDbType.Int)
        'arParms(8).Value = EL.F_score
        arParms(5) = New SqlParameter("@APID", SqlDbType.Int)
        arParms(5).Value = EL.APID
        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")
        arParms(7) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("Empcode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "UpdateAppraisalscore", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function UpdateAprrisalScore1(ByVal EL As ELAppraisalform) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Empid", SqlDbType.Int)
        arParms(2).Value = EL.Empid
        'arParms(3) = New SqlParameter("@AppraisalType", SqlDbType.Int)
        'arParms(3).Value = EL.AppraisalType
        arParms(3) = New SqlParameter("@PID", SqlDbType.Int)
        arParms(3).Value = EL.P_Id
        'arParms(5) = New SqlParameter("@id", SqlDbType.Int)
        'arParms(5).Value = EL.id
        'arParms(5) = New SqlParameter("@S_score", SqlDbType.Int)
        'arParms(5).Value = EL.S_score
        'arParms(5) = New SqlParameter("@M_score", SqlDbType.Int)
        'arParms(5).Value = EL.M_score
        arParms(4) = New SqlParameter("@R_score", SqlDbType.Int)
        arParms(4).Value = EL.R_score
        arParms(5) = New SqlParameter("@F_score", SqlDbType.Int)
        arParms(5).Value = EL.F_score
        arParms(6) = New SqlParameter("@APID", SqlDbType.Int)
        arParms(6).Value = EL.APID
        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")
        arParms(8) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("Empcode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "UpdateAppraisalscore1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetApprasialCycle() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getAppraisalCycle", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return dt
    End Function
    Shared Function FinalScore() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getAppraisalfinalScore", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return dt
    End Function
End Class