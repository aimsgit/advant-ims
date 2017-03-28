Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLEndowment
    Shared Function GetSponsor() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Endo_ddlSponser", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Shared Function Insert(ByVal El As ELEndowment) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}

        arParms(0) = New SqlParameter("@SponsorID", SqlDbType.Int)
        arParms(0).Value = El.SponsorID

        arParms(1) = New SqlParameter("@DonorCode", SqlDbType.NVarChar, 50)
        arParms(1).Value = El.Donor_ID

        arParms(2) = New SqlParameter("@Amount", SqlDbType.Money)
        arParms(2).Value = El.Amount

        arParms(3) = New SqlParameter("@Currency", SqlDbType.NVarChar, 150)
        arParms(3).Value = El.Currency

        arParms(4) = New SqlParameter("@RecdDate", SqlDbType.DateTime)
        arParms(4).Value = El.RcvdDate


        arParms(5) = New SqlParameter("@ChequeNo", SqlDbType.NVarChar, 50)
        arParms(5).Value = El.ChqNo

        arParms(6) = New SqlParameter("@BankID", SqlDbType.Int)
        arParms(6).Value = El.Bank

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 250)
        arParms(7).Value = El.Remarks

        arParms(8) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("EmpCode")

        arParms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("UserCode")

        arParms(10) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("BranchCode")
        arParms(11) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("Office")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertEndowment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function Update(ByVal El As ELEndowment) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}

        arParms(0) = New SqlParameter("@SponsorID", SqlDbType.Int)
        arParms(0).Value = El.SponsorID

        arParms(1) = New SqlParameter("@DonorCode", SqlDbType.NVarChar, 50)
        arParms(1).Value = El.Donor_ID

        arParms(2) = New SqlParameter("@Amount", SqlDbType.Money)
        arParms(2).Value = El.Amount

        arParms(3) = New SqlParameter("@Currency", SqlDbType.NVarChar, 150)
        arParms(3).Value = El.Currency

        arParms(4) = New SqlParameter("@RecdDate", SqlDbType.DateTime)
        arParms(4).Value = El.RcvdDate


        arParms(5) = New SqlParameter("@ChequeNo", SqlDbType.NVarChar, 50)
        arParms(5).Value = El.ChqNo

        arParms(6) = New SqlParameter("@BankID", SqlDbType.Int)
        arParms(6).Value = El.Bank

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 250)
        arParms(7).Value = El.Remarks

        arParms(8) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("EmpCode")

        arParms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("UserCode")

        arParms(10) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("BranchCode")

        arParms(11) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(11).Value = El.ID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateEndowment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DisplayGridValue(ByVal El As ELEndowment) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = El.ID

        arParms(3) = New SqlParameter("@Sponsor_ID", SqlDbType.Int)
        arParms(3).Value = El.SponsorID

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEndowment", arParms)
        Return ds.Tables(0)
    End Function
    Public Function Duplicate(ByVal EL As ELEndowment) As Data.DataTable

        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@SponsorID", SqlDbType.Int)
        arParms(0).Value = EL.SponsorID

        arParms(1) = New SqlParameter("@DonorCode", SqlDbType.NVarChar, 50)
        arParms(1).Value = EL.Donor_ID

        arParms(2) = New SqlParameter("@ChequeNo", SqlDbType.NVarChar, 50)
        arParms(2).Value = EL.ChqNo

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(4).Value = EL.ID

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_CheckEndowment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function RptGetEndowmentDetails(ByVal FromDate As Date, ByVal ToDate As Date) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode ", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@fromdate", SqlDbType.Date)
        arParms(2).Value = FromDate

        arParms(3) = New SqlParameter("@ToDate", SqlDbType.Date)
        arParms(3).Value = ToDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_EndowmentDetails", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEndowmentAlertMsg() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")


        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEndowmentAlertMsg", arParms)
        Return ds.Tables(0)
    End Function
End Class
