Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class OtherpartyDB
    Shared Function GetDatOthParty(ByVal prefixText As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@OP_Name", SqlDbType.NVarChar, 50)
        arParms(2).Value = prefixText
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetOtherExt", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetDeatils(ByVal op As OtherParty) As Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = op.Id

        arParms(3) = New SqlParameter("@OP_Name", SqlDbType.NVarChar, 50)
        arParms(3).Value = op.Name

        arParms(4) = New SqlParameter("@OP_Id", SqlDbType.VarChar, 50)
        arParms(4).Value = op.Opid
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetOtherParty", arParms)
           
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
        Return ds.Tables(0)

    End Function
    Shared Function Insert(ByVal op As OtherParty) As Integer


        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(19) {}

        arParms(0) = New SqlParameter("@code", SqlDbType.NVarChar, 50)
        arParms(0).Value = op.Opid

        arParms(1) = New SqlParameter("@name", SqlDbType.NVarChar, 100)
        arParms(1).Value = op.Name

        arParms(2) = New SqlParameter("@Address", SqlDbType.NVarChar, 250)
        arParms(2).Value = op.Address

        arParms(3) = New SqlParameter("@city", SqlDbType.NVarChar, 50)
        arParms(3).Value = op.City

        arParms(4) = New SqlParameter("@state", SqlDbType.Int)
        arParms(4).Value = op.State

        arParms(5) = New SqlParameter("@postalcode", SqlDbType.NVarChar, 50)
        arParms(5).Value = op.Pcode

        arParms(6) = New SqlParameter("@contact_Person", SqlDbType.NVarChar, 50)
        arParms(6).Value = op.Contactperson

        arParms(7) = New SqlParameter("@contact_Number", SqlDbType.VarChar, 20)
        arParms(7).Value = op.Contactno

        arParms(8) = New SqlParameter("@email", SqlDbType.NVarChar, 250)
        arParms(8).Value = op.Email

        arParms(9) = New SqlParameter("@credit_Period", SqlDbType.Int)
        arParms(9).Value = op.Creditperiod

        arParms(10) = New SqlParameter("@credit_Limit", SqlDbType.Int)
        arParms(10).Value = op.Creditlimit

        arParms(11) = New SqlParameter("@partytorec", SqlDbType.Int)
        arParms(11).Value = op.OpeningBalanceCR

        arParms(12) = New SqlParameter("@partytopay", SqlDbType.Int)
        arParms(12).Value = op.OpeningBalanceDR

        
        arParms(13) = New SqlParameter("@ob_date", SqlDbType.DateTime)
        arParms(13).Value = op.OpBalanceDate


        arParms(14) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 250)
        arParms(14).Value = op.Remark

        arParms(15) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("BranchCode")

        arParms(16) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(16).Value = HttpContext.Current.Session("UserCode")

        arParms(17) = New SqlParameter("@empCode", SqlDbType.VarChar, 50)
        arParms(17).Value = HttpContext.Current.Session("empCode")

        arParms(18) = New SqlParameter("@faxno", SqlDbType.NVarChar, 50)
        arParms(18).Value = op.FaxNO

        arParms(19) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(19).Value = HttpContext.Current.Session("Office")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InserOtherParty", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal op As OtherParty) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString


        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(19) {}

        arParms(0) = New SqlParameter("@code", SqlDbType.NVarChar, 50)
        arParms(0).Value = op.Opid

        arParms(1) = New SqlParameter("@name", SqlDbType.NVarChar, 100)
        arParms(1).Value = op.Name

        arParms(2) = New SqlParameter("@Address", SqlDbType.NVarChar, 250)
        arParms(2).Value = op.Address

        arParms(3) = New SqlParameter("@city", SqlDbType.NVarChar, 50)
        arParms(3).Value = op.City

        arParms(4) = New SqlParameter("@state", SqlDbType.Int)
        arParms(4).Value = op.State

        arParms(5) = New SqlParameter("@postalcode", SqlDbType.NVarChar, 50)
        arParms(5).Value = op.Pcode

        arParms(6) = New SqlParameter("@contact_Person", SqlDbType.NVarChar, 50)
        arParms(6).Value = op.Contactperson

        arParms(7) = New SqlParameter("@contact_Number", SqlDbType.NVarChar, 20)
        arParms(7).Value = op.Contactno

        arParms(8) = New SqlParameter("@email", SqlDbType.NVarChar, 250)
        arParms(8).Value = op.Email

        arParms(9) = New SqlParameter("@credit_Period", SqlDbType.Int)
        arParms(9).Value = op.Creditperiod

        arParms(10) = New SqlParameter("@credit_Limit", SqlDbType.Int)
        arParms(10).Value = op.Creditlimit

        arParms(11) = New SqlParameter("@partytorec", SqlDbType.Int)
        arParms(11).Value = op.OpeningBalanceCR

        arParms(12) = New SqlParameter("@partytopay", SqlDbType.Int)
        arParms(12).Value = op.OpeningBalanceDR


        arParms(13) = New SqlParameter("@ob_date", SqlDbType.DateTime)
        arParms(13).Value = op.OpBalanceDate


        arParms(14) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 250)
        arParms(14).Value = op.Remark

        arParms(15) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("BranchCode")
        arParms(16) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(16).Value = HttpContext.Current.Session("UserCode")
        arParms(17) = New SqlParameter("@empCode", SqlDbType.VarChar, 50)
        arParms(17).Value = HttpContext.Current.Session("empCode")
        arParms(18) = New SqlParameter("@faxno", SqlDbType.NVarChar, 50)
        arParms(18).Value = op.FaxNO
        arParms(19) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(19).Value = op.Id

       

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateOtherParty", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal op As OtherParty) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = op.Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteOtherParty", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetOtherComboDayBook(ByVal id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            If id = 0 Then
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetOtherPartyComboDB")
            Else
                Dim arParms As SqlParameter = New SqlParameter("@OPAutoNo", SqlDbType.Int, 10)
                arParms.Value = id
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetOtherPartyComboDBbyID", arParms)
            End If
        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds
    End Function
    Shared Function GetReport() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetOtherPartyDetails", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetDuplicateotherparty(ByVal op As OtherParty) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}
        para(0) = New SqlParameter("@OP_Name", SqlDbType.VarChar, 50)
        para(0).Value = op.Name
        para(1) = New SqlParameter("@OP_Id", SqlDbType.NVarChar, 50)
        para(1).Value = op.Opid
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = op.Id
        para(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "ProcOtherPartyDetailsDuplicate", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function RptGetDeatils() As Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = 0
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetOtherPartyDetails", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
        Return ds.Tables(0)

    End Function
End Class
