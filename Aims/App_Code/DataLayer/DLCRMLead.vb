Imports Microsoft.VisualBasic
Imports System.Data.SqlClient


Public Class DLCRMLead
    Shared Function GetProposalDetails(ByVal EL As ELCRMLead) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = EL.DemoID

        arParms(3) = New SqlParameter("@LeadID", SqlDbType.Int)
        arParms(3).Value = EL.LeadID

        arParms(4) = New SqlParameter("@AssignedToId", SqlDbType.Int)
        arParms(4).Value = EL.AssignedTo

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetProposalCRM", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetProposalDetailsfordrilldown(ByVal Demodate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Demodate", SqlDbType.Date)
        arParms(2).Value = Demodate

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetProposalDetails", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function InsertUpdateProposal(ByVal EL As ELCRMLead) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(10) {}
        arParms(0) = New SqlParameter("@LeadID", SqlDbType.Int)
        arParms(0).Value = EL.LeadID
        If EL.DemoDate = Nothing Then
            arParms(1) = New SqlParameter("@Proposaldate", SqlDbType.VarChar)
            arParms(1).Value = DBNull.Value
        Else
            arParms(1) = New SqlParameter("@Proposaldate", SqlDbType.DateTime)
            arParms(1).Value = EL.DemoDate
        End If

        If EL.ProposalValue = Nothing Then
            arParms(2) = New SqlParameter("@Proposaltime", SqlDbType.VarChar)
            arParms(2).Value = DBNull.Value
        Else
            arParms(2) = New SqlParameter("@Proposaltime", SqlDbType.Money)
            arParms(2).Value = EL.ProposalValue
        End If

        arParms(3) = New SqlParameter("@AssignedToId", SqlDbType.Int)
        arParms(3).Value = EL.AssignedTo

        arParms(4) = New SqlParameter("@Status", SqlDbType.VarChar, 250)
        arParms(4).Value = EL.Status

        arParms(5) = New SqlParameter("@Remarks", SqlDbType.VarChar, 5000)
        arParms(5).Value = EL.DemoReport

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")

        arParms(9) = New SqlParameter("@ProposalID", SqlDbType.Int)
        arParms(9).Value = EL.DemoID

        arParms(10) = New SqlParameter("@Attachment", SqlDbType.VarChar, EL.Attachment.Length)
        arParms(10).Value = EL.Attachment
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertProposalCRM", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function CheckDuplicate(ByVal f As ELCRMLead) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Adate", SqlDbType.Date)
        arParms(1).Value = f.DemoDate

        arParms(2) = New SqlParameter("@Atime", SqlDbType.DateTime)
        arParms(2).Value = f.DemoTime

        arParms(3) = New SqlParameter("@AssignedTo", SqlDbType.Int)
        arParms(3).Value = f.AssignedTo

        arParms(4) = New SqlParameter("@id", SqlDbType.Int)
        arParms(4).Value = f.DemoID

        arParms(5) = New SqlParameter("@status", SqlDbType.VarChar, 50)
        arParms(5).Value = f.Status


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[proc_DuplicateApptCRM]", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing

        End Try
    End Function
    Shared Function GetCommunication(ByVal ID As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim parms() As SqlParameter = New SqlParameter(1) {}

        parms(0) = New SqlParameter("@CAID", SqlDbType.VarChar, 200)
        parms(0).Value = ID

        parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 30)
        parms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCommunicationforApptCRM", parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Shared Function GetDemoDetailsfordrilldown(ByVal Demodate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Demodate", SqlDbType.Date)
        arParms(2).Value = Demodate

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDemoDetails", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function InsertUpdateDemo(ByVal EL As ELCRMLead) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        arParms(0) = New SqlParameter("@LeadID", SqlDbType.Int)
        arParms(0).Value = EL.LeadID
        If EL.DemoDate = Nothing Then
            arParms(1) = New SqlParameter("@Demodate", SqlDbType.VarChar)
            arParms(1).Value = DBNull.Value
        Else
            arParms(1) = New SqlParameter("@Demodate", SqlDbType.DateTime)
            arParms(1).Value = EL.DemoDate
        End If

        If EL.DemoTime = Nothing Then
            arParms(2) = New SqlParameter("@Demotime", SqlDbType.VarChar)
            arParms(2).Value = DBNull.Value
        Else
            arParms(2) = New SqlParameter("@Demotime", SqlDbType.DateTime)
            arParms(2).Value = EL.DemoTime
        End If

        arParms(3) = New SqlParameter("@AssignedToId", SqlDbType.Int)
        arParms(3).Value = EL.AssignedTo

        arParms(4) = New SqlParameter("@Status", SqlDbType.VarChar, 250)
        arParms(4).Value = EL.Status

        arParms(5) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(5).Value = EL.DemoReport

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")

        arParms(9) = New SqlParameter("@DemoID", SqlDbType.Int)
        arParms(9).Value = EL.DemoID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertDemoCRM", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetDemoDetails(ByVal EL As ELCRMLead) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = EL.DemoID

        arParms(3) = New SqlParameter("@LeadID", SqlDbType.Int)
        arParms(3).Value = EL.LeadID

        arParms(4) = New SqlParameter("@AssignedToId", SqlDbType.Int)
        arParms(4).Value = EL.AssignedTo

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDemoCRM", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function DeleteDemo(ByVal CO_ID As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@CO_ID", SqlDbType.Int)
        arParms(0).Value = CO_ID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteApptCRM", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Delete(ByVal LeadID As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@LeadID", SqlDbType.Int)
        arParms(0).Value = LeadID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteCRMLead", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function CloseAlert(ByVal LeadID As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@LeadID", SqlDbType.Int)
        arParms(0).Value = LeadID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_CloseCRMLead", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function InsertUpdate(ByVal EL As ELCRMLead) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(18) {}
        arParms(0) = New SqlParameter("@LeadID", SqlDbType.Int)
        arParms(0).Value = EL.LeadID

        arParms(1) = New SqlParameter("@LeadName", SqlDbType.VarChar, 200)
        arParms(1).Value = EL.LeadName

        arParms(2) = New SqlParameter("@Product", SqlDbType.VarChar, 50)
        arParms(2).Value = EL.Product

        arParms(3) = New SqlParameter("@PropectId", SqlDbType.VarChar, 50)
        arParms(3).Value = EL.PropectId

        arParms(4) = New SqlParameter("@Address", SqlDbType.VarChar, 250)
        arParms(4).Value = EL.Address

        arParms(5) = New SqlParameter("@ContactNo", SqlDbType.VarChar, 50)
        arParms(5).Value = EL.ContactNo

        arParms(6) = New SqlParameter("@EmailID", SqlDbType.VarChar, 200)
        arParms(6).Value = EL.EmailID

        arParms(7) = New SqlParameter("@LeadFrom", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.LeadFrom

        arParms(8) = New SqlParameter("@EstimatedValue", SqlDbType.Money)
        arParms(8).Value = EL.EstimatedValue

        arParms(9) = New SqlParameter("@Probability", SqlDbType.Float)
        arParms(9).Value = EL.Probability

        arParms(10) = New SqlParameter("@Status", SqlDbType.VarChar, 50)
        arParms(10).Value = EL.Status

        'If EL.LeadDate = "1/1/1900" Then
        '    arParms(11) = New SqlParameter("@LeadDate", SqlDbType.Date)
        '    arParms(11).Value = DBNull.Value
        'Else
        arParms(11) = New SqlParameter("@LeadDate", SqlDbType.Date)
        arParms(11).Value = EL.LeadDate
        'End If

        arParms(12) = New SqlParameter("@State", SqlDbType.VarChar, 50)
        arParms(12).Value = EL.State

        arParms(13) = New SqlParameter("@Country", SqlDbType.VarChar, 150)
        arParms(13).Value = EL.Country

        arParms(14) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(14).Value = EL.Remarks

        arParms(15) = New SqlParameter("@SkypeID", SqlDbType.VarChar, 150)
        arParms(15).Value = EL.Skypeid

        arParms(16) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(16).Value = HttpContext.Current.Session("BranchCode")

        arParms(17) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(17).Value = HttpContext.Current.Session("EmpCode")

        arParms(18) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(18).Value = HttpContext.Current.Session("UserCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveCRMLead", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function Display(ByVal EL As ELCRMLead) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(10) {}
        arParms(0) = New SqlParameter("@LeadID", SqlDbType.Int)
        arParms(0).Value = EL.LeadID

        arParms(1) = New SqlParameter("@LeadName", SqlDbType.VarChar, 200)
        arParms(1).Value = EL.LeadName

        arParms(2) = New SqlParameter("@Product", SqlDbType.VarChar, 50)
        arParms(2).Value = EL.Product

        arParms(3) = New SqlParameter("@LeadFrom", SqlDbType.VarChar, 50)
        arParms(3).Value = EL.LeadFrom

        arParms(4) = New SqlParameter("@Status", SqlDbType.VarChar, 50)
        arParms(4).Value = EL.Status

        arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("BranchCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@Prospectid", SqlDbType.VarChar, 50)
        arParms(8).Value = EL.PropectId

        arParms(9) = New SqlParameter("@State", SqlDbType.VarChar, 50)
        arParms(9).Value = EL.State

        arParms(10) = New SqlParameter("@Country", SqlDbType.VarChar, 150)
        arParms(10).Value = EL.Country
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCRMLead", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function

    Shared Function DisplayAlerts(ByVal FromDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(0).Value = FromDate

        arParms(1) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(1).Value = ToDate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(3).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCRMAlerts", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    ' Code Written by Niraj on 27 May 2013 
    Shared Function GetState(ByVal StateId As Long) As System.Data.DataSet
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        If StateId = 0 Then
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, "Select StateId,StateName From State")
        Else
            Dim arParms() As SqlParameter = New SqlParameter(0) {}
            arParms(0) = New SqlParameter("@StateId", SqlDbType.Int)
            arParms(0).Value = StateId
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStateByID", arParms)
        End If
        Return ds
    End Function
    Public Function RptGetCRMLead(ByVal ProductId As String, ByVal StatusId As String, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@ProductId", SqlDbType.NVarChar, 50)
        arParms(2).Value = ProductId

        arParms(3) = New SqlParameter("@StatusId", SqlDbType.NVarChar, 50)
        arParms(3).Value = StatusId

        arParms(4) = New SqlParameter("@FromDate", SqlDbType.Date)
        arParms(4).Value = FromDate

        arParms(5) = New SqlParameter("@ToDate", SqlDbType.Date)
        arParms(5).Value = ToDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_CRMLead", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
