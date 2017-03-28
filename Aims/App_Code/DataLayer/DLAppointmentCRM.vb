Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient


Public Class DLAppointmentCRM

    Shared Function GetLeadCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_LeadCombo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function GetEmpCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_EmployeeCombo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function
    Public Function Insert(ByVal El As ELAppointmentCRM) As Int16

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Count As Int32

        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@LeadId", SqlDbType.Int)
        arParms(0).Value = El.LeadId

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        arParms(4) = New SqlParameter("@Adate", SqlDbType.DateTime)
        arParms(4).Value = El.Adate

        arParms(5) = New SqlParameter("@Atime", SqlDbType.DateTime)
        arParms(5).Value = El.Atime

        arParms(6) = New SqlParameter("@AssignedToId", SqlDbType.Int)
        arParms(6).Value = El.AssingedToId

        arParms(7) = New SqlParameter("@Status", SqlDbType.VarChar, 50)
        arParms(7).Value = El.Status

        arParms(8) = New SqlParameter("@Remarks", SqlDbType.VarChar, 5000)
        arParms(8).Value = El.Remarks


        Try
            Count = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertApptCRM", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function GetApptDetails(ByVal id As Integer, ByVal Leadname As String, ByVal Empname As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = id

        arParms(3) = New SqlParameter("@lead", SqlDbType.VarChar, 100)
        arParms(3).Value = Leadname

        arParms(4) = New SqlParameter("@AssingedTo", SqlDbType.VarChar, 100)
        arParms(4).Value = Empname



        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetApptCRM", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function Delete(ByVal id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@CO_ID", SqlDbType.Int)
        arParms.Value = id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteApptCRM", arParms)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal el As ELAppointmentCRM) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@LeadId", SqlDbType.Int)
        arParms(0).Value = el.LeadId

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        arParms(4) = New SqlParameter("@Adate", SqlDbType.DateTime)
        arParms(4).Value = el.Adate

        arParms(5) = New SqlParameter("@Atime", SqlDbType.DateTime)
        arParms(5).Value = el.Atime

        arParms(6) = New SqlParameter("@AssignedToId", SqlDbType.Int)
        arParms(6).Value = el.AssingedToId

        arParms(7) = New SqlParameter("@Status", SqlDbType.VarChar, 50)
        arParms(7).Value = el.Status

        arParms(8) = New SqlParameter("@Remarks", SqlDbType.VarChar, 5000)
        arParms(8).Value = el.Remarks

        arParms(9) = New SqlParameter("@id", SqlDbType.Int)
        arParms(9).Value = el.Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateApptCRM", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function

    Public Function GetApptDetailsfordrilldown(ByVal Adate As Date, ByVal Status As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Adate", SqlDbType.Date)
        arParms(2).Value = Adate

        arParms(3) = New SqlParameter("@Status", SqlDbType.VarChar, 50)
        arParms(3).Value = Status

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetApptDetails", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetCommunication(ByVal ID As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim parms() As SqlParameter = New SqlParameter(1) {}

        parms(0) = New SqlParameter("@CAID", SqlDbType.VarChar, 200)
        parms(0).Value = ID

        parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        parms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCommunicationforApptCRM", parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Shared Function CheckDuplicate(ByVal f As ELAppointmentCRM) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Adate", SqlDbType.Date)
        arParms(1).Value = f.Adate

        arParms(2) = New SqlParameter("@Atime", SqlDbType.DateTime)
        arParms(2).Value = f.Atime

        arParms(3) = New SqlParameter("@AssignedTo", SqlDbType.Int)
        arParms(3).Value = f.AssingedToId

        arParms(4) = New SqlParameter("@id", SqlDbType.Int)
        arParms(4).Value = f.Id

        arParms(5) = New SqlParameter("@status", SqlDbType.VarChar, 50)
        arParms(5).Value = f.Status


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[proc_DuplicateApptCRM]", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing

        End Try
    End Function
    Shared Function UpdateWO(ByVal el As ELAppointmentCRM) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@LeadId", SqlDbType.Int)
        arParms(0).Value = el.LeadId

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        arParms(4) = New SqlParameter("@WOValue", SqlDbType.Float)
        arParms(4).Value = el.EstimatedValue

        arParms(5) = New SqlParameter("@Probability", SqlDbType.Float)
        arParms(5).Value = el.Probability

        arParms(6) = New SqlParameter("@Status", SqlDbType.VarChar, 50)
        arParms(6).Value = el.Status


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateWorkOrderCRM", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function GetWODetails(ByVal lead As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@lead", SqlDbType.VarChar, 100)
        arParms(2).Value = lead


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetWOCRM", arParms)
        Return ds.Tables(0)
    End Function

    Public Function GetPipelineDetails() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDPipelineDetails", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetPipelineTotDetails() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetDPipelineTotDetails]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpComboAll() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_EmployeeComboAll", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
