Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class LetterPadDB
    Shared Function GetLetterPad(ByVal Rid As LetterPad) As System.Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@Ref_ID_Auto", SqlDbType.Int)
            arParms(0).Value = Rid.Ref_ID_Auto
            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")
            arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetLetterPadDetails", arParms)

        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal lp As LetterPad) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(11) {}
        arParms(0) = New SqlParameter("@Ref_No", SqlDbType.NVarChar, 100)
        arParms(0).Value = lp.Ref_No

        arParms(1) = New SqlParameter("@Ref_Person", SqlDbType.NVarChar, 1000)
        arParms(1).Value = lp.Ref_Person

        arParms(2) = New SqlParameter("@Ref_Date", SqlDbType.DateTime)
        arParms(2).Value = lp.Ref_Date

        arParms(3) = New SqlParameter("@Subject", SqlDbType.NVarChar, 1000)
        arParms(3).Value = lp.Subject

        arParms(4) = New SqlParameter("@ContentLP", SqlDbType.NVarChar)
        arParms(4).Value = lp.ContentLP

        arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("BranchCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@FromPerson", SqlDbType.VarChar, 1000)
        arParms(8).Value = lp.From

        arParms(9) = New SqlParameter("@Salutation", SqlDbType.VarChar, 1000)
        arParms(9).Value = lp.Salutation

        arParms(10) = New SqlParameter("@Signature", SqlDbType.VarChar, 255)
        arParms(10).Value = lp.Signature

        arParms(11) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertintoLetterPad", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal lp As LetterPad) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(11) {}
        arParms(0) = New SqlParameter("@Ref_No", SqlDbType.Char, lp.Ref_No.Length)
        arParms(0).Value = lp.Ref_No

        arParms(1) = New SqlParameter("@Ref_Person", SqlDbType.Char, lp.Ref_Person.Length)
        arParms(1).Value = lp.Ref_Person

        arParms(2) = New SqlParameter("@Ref_Date", SqlDbType.DateTime)
        arParms(2).Value = lp.Ref_Date

        arParms(3) = New SqlParameter("@Subject", SqlDbType.VarChar, 1000)
        arParms(3).Value = lp.Subject

        arParms(4) = New SqlParameter("@ContentLP", SqlDbType.VarChar)
        arParms(4).Value = lp.ContentLP

        arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("BranchCode")

        arParms(6) = New SqlParameter("@Ref_ID", SqlDbType.Int)
        arParms(6).Value = lp.Ref_ID_Auto

        arParms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")

        arParms(9) = New SqlParameter("@FromPerson", SqlDbType.VarChar, 1000)
        arParms(9).Value = lp.From

        arParms(10) = New SqlParameter("@Salutation", SqlDbType.VarChar, 1000)
        arParms(10).Value = lp.Salutation

        arParms(11) = New SqlParameter("@Signature", SqlDbType.VarChar, 250)
        arParms(11).Value = lp.Signature

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateLetterPad", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal RId As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Ref_Id", SqlDbType.Int)
        arParms(0).Value = RId

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteLetterPad", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetReport(ByVal Ref_ID As Integer) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@Ref_ID", SqlDbType.Int)
        arParms(2).Value = Ref_ID

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_LetterpadReport", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function CheckDuplicate(ByVal lp As LetterPad) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Ref_No", SqlDbType.VarChar, 50)
        arParms(1).Value = lp.Ref_No
        arParms(2) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(2).Value = lp.Ref_ID_Auto

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CheckDuplicateLetterNo]", arParms)
        Return ds.Tables(0)

    End Function
End Class