Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class AdmissionCriteriaDL
    Shared Function InsertAdmissionCriteria(ByVal AddCriteria As AdmissionCriteriaEL) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(6) {}
        Params(0) = New SqlParameter("@Criteria", Data.SqlDbType.NVarChar)
        Params(0).Value = AddCriteria.Criteria
        Params(1) = New SqlParameter("@CriteriaValue", Data.SqlDbType.NVarChar)
        Params(1).Value = AddCriteria.CriteriaValue
        Params(2) = New SqlParameter("@id", Data.SqlDbType.Int)
        Params(2).Value = AddCriteria.id
        Params(3) = New SqlParameter("@Office", Data.SqlDbType.VarChar)
        Params(3).Value = HttpContext.Current.Session("Office")
        Params(4) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar)
        Params(4).Value = HttpContext.Current.Session("BranchCode")
        Params(5) = New SqlParameter("@EmpCode", Data.SqlDbType.VarChar)
        Params(5).Value = HttpContext.Current.Session("EmpCode")
        Params(6) = New SqlParameter("@UserCode", Data.SqlDbType.VarChar)
        Params(6).Value = HttpContext.Current.Session("UserCode")
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_InsertAdmissionCriteriaMaster", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function AdmissionCriteriaGridView(ByVal ID As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}
            Parms(0) = New SqlParameter("@ID", SqlDbType.Int)
            Parms(0).Value = ID

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(2).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "prc_AdmissionCriteriaGridView", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DeleteAdmissionCriteriaMaster(ByVal AddCriteria As AdmissionCriteriaEL) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(2) {}
        Params(0) = New SqlParameter("@ID", Data.SqlDbType.Int)
        Params(0).Value = AddCriteria.id

        Params(1) = New SqlParameter("@Office", SqlDbType.VarChar)
        Params(1).Value = HttpContext.Current.Session("Office")

        Params(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        Params(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_DeleteAdmissionCriteriaMaster", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
        Return rowsaffected
    End Function
    Shared Function UpdateCriteriaStatusMaster(ByVal AddCriteria As AdmissionCriteriaEL) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(2) {}
        Params(0) = New SqlParameter("@ID", Data.SqlDbType.Int)
        Params(0).Value = AddCriteria.id

        Params(1) = New SqlParameter("@Office", SqlDbType.VarChar)
        Params(1).Value = HttpContext.Current.Session("Office")

        Params(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        Params(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_UpdateCriteriaStatusMaster", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
        Return rowsaffected
    End Function
    Public Function CheckDuplicateAdmissionCriteria(ByVal AddCriteria As AdmissionCriteriaEL) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        'Dim para() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Criteria", SqlDbType.NVarChar)
        arParms(1).Value = AddCriteria.Criteria
        arParms(2) = New SqlParameter("@CriteriaValue", SqlDbType.NVarChar)
        arParms(2).Value = AddCriteria.CriteriaValue
        arParms(3) = New SqlParameter("@id", SqlDbType.Int)
        arParms(3).Value = AddCriteria.id
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_DuplicateAdmissionCriteriaMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Function getAdmissionCriteriaStatus(ByVal AddCriteria As AdmissionCriteriaEL) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        'Dim para() As SqlParameter = New SqlParameter(1) {}
       
        arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(0).Value = AddCriteria.id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_getStatusCriteria", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Shared Function RptAdmissionCriteria(ByVal CourseType As Integer, ByVal Course As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@CourseTypeId", SqlDbType.Int)
        arParms(1).Value = CourseType

        arParms(2) = New SqlParameter("@CourseName", SqlDbType.Int)
        arParms(2).Value = Course

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")



        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_AdmissionCriteria", arParms)
        Return ds.Tables(0)

    End Function

End Class
