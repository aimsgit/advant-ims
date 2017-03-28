Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class BankDB
    Shared Function GetDatBank(ByVal prefixText As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Bank_Name", SqlDbType.NVarChar, 50)
        arParms(2).Value = prefixText
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBankExt", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetBank(ByVal id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            If id = 0 Then
                Dim arParms() As SqlParameter = New SqlParameter(1) {}
                arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
                arParms(0).Value = HttpContext.Current.Session("Office")
                arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
                arParms(1).Value = HttpContext.Current.Session("BranchCode")

                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBankDetails", arParms)
            Else
                Dim arParms() As SqlParameter = New SqlParameter(2) {}
                arParms(0) = New SqlParameter("@Bankid", SqlDbType.Int)
                arParms(0).Value = id
                'arParms(1) = New SqlParameter("@institute", SqlDbType.Int)
                'arParms(1).Value = HttpContext.Current.Session("InstituteID")
                arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
                arParms(1).Value = HttpContext.Current.Session("Office")
                arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
                arParms(2).Value = HttpContext.Current.Session("BranchCode")
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBankDetailsByBankID", arParms)
            End If
        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds
    End Function
    Shared Function Insert(ByVal B As Bank) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.NVarChar, B.Name.Length)
        arParms(0).Value = B.Name
        arParms(1) = New SqlParameter("@address", SqlDbType.NVarChar, B.Address.Length)
        arParms(1).Value = B.Address
        arParms(2) = New SqlParameter("@remarks", SqlDbType.NVarChar, B.Remarks.Length)
        arParms(2).Value = B.Remarks
        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")
        arParms(4) = New SqlParameter("@empCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")
        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")
        arParms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Office")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveBankDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal B As Bank) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.NVarChar, B.Name.Length)
        arParms(0).Value = B.Name
        arParms(1) = New SqlParameter("@address", SqlDbType.NVarChar, B.Address.Length)
        arParms(1).Value = B.Address
        arParms(2) = New SqlParameter("@remarks", SqlDbType.NVarChar, B.Remarks.Length)
        arParms(2).Value = B.Remarks
        arParms(3) = New SqlParameter("@id", SqlDbType.Int)
        arParms(3).Value = B.Id
        arParms(4) = New SqlParameter("@empCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")
        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")
        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateBankDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Bankid", SqlDbType.Int)
        arParms(0).Value = Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteBankDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function GetBankComboDayBook(ByVal id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            If id = 0 Then
                Dim arParms() As SqlParameter = New SqlParameter(1) {}
                arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
                arParms(0).Value = HttpContext.Current.Session("Office")
                arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
                arParms(1).Value = HttpContext.Current.Session("BranchCode")
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBankDetailsComboDB", arParms)
            Else
                Dim arParms() As SqlParameter = New SqlParameter(2) {}
                arParms(0) = New SqlParameter("@Bankid", SqlDbType.Int)
                arParms(0).Value = id
                arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
                arParms(1).Value = HttpContext.Current.Session("Office")
                arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
                arParms(2).Value = HttpContext.Current.Session("BranchCode")
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBankDetailsComboDBbyID", arParms)
            End If
        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds
    End Function
    Shared Function RptBank(ByVal inst As Int64, ByVal brn As Int64) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}
            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")
            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptBankDetails", arParms)

        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function getBankDetails(ByVal Inst As Bank) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Bank_ID", SqlDbType.Int)
        arParms(2).Value = Inst.Id
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBankDetails", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetBankDetailsDuplicate(ByVal EL As Bank) As DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        If EL.Name = "" Then
            para(0) = New SqlParameter("@BankName", SqlDbType.NVarChar, 50)
            para(0).Value = ""
            para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            para(1).Value = ""
            para(2) = New SqlParameter("@id", SqlDbType.Int)
            para(2).Value = ""
        Else
            para(0) = New SqlParameter("@BankName", SqlDbType.NVarChar, 50)
            para(0).Value = EL.Name
            para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            para(1).Value = HttpContext.Current.Session("BranchCode")
            para(2) = New SqlParameter("@id", SqlDbType.Int)
            para(2).Value = EL.Id
        End If
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetBankDetailsDuplicate", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetReportBankDetails() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Bank_ID", SqlDbType.Int)
        arParms(2).Value = 0
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBankDetails", arParms)
        Return ds.Tables(0)
    End Function
End Class
