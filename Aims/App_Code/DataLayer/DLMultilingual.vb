Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLMultilingual
    'Function for Inserting the data into DDL. By: Niraj 07-10-2013 
    Shared Function GetLanguageType() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLanguageType")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetModuleDdl() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Parms(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_DdlgetModule", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetFormName(ByVal MNIDAuto As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(3) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Parms(1).Value = HttpContext.Current.Session("Office")

        Parms(2) = New SqlParameter("@MNIDAuto", SqlDbType.Int)
        Parms(2).Value = MNIDAuto

        Parms(3) = New SqlParameter("@Languageid", SqlDbType.Int)
        Parms(3).Value = HttpContext.Current.Session("LanguageID")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_ddlFormName", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    
    Public Shared Function Insert(ByVal El As ELMultilingual) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@Module_Id ", SqlDbType.Int)
        arParms(0).Value = El.moduleId

        arParms(1) = New SqlParameter("@FormId", SqlDbType.NVarChar, 100)
        arParms(1).Value = El.FormId

        arParms(2) = New SqlParameter("@LangId", SqlDbType.Int)
        arParms(2).Value = El.Lang_Id

        arParms(3) = New SqlParameter("@CType", SqlDbType.VarChar, 100)
        arParms(3).Value = El.Control_Type

        arParms(4) = New SqlParameter("@CCName", SqlDbType.NVarChar, 250)
        arParms(4).Value = El.CCName

        arParms(5) = New SqlParameter("@CId", SqlDbType.NVarChar, 250)
        arParms(5).Value = El.Control_Id

        arParms(6) = New SqlParameter("@Trans", SqlDbType.NVarChar, 1000)
        arParms(6).Value = El.Translation

        arParms(7) = New SqlParameter("@Type", SqlDbType.VarChar, 2)
        arParms(7).Value = El.Type

        arParms(8) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("EmpCode")

        arParms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("UserCode")

        arParms(10) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertMultilingual", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal El As ELMultilingual) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}


        arParms(0) = New SqlParameter("@Module_Id ", SqlDbType.Int)
        arParms(0).Value = El.moduleId

        arParms(1) = New SqlParameter("@FormId", SqlDbType.NVarChar, 100)
        arParms(1).Value = El.FormId

        arParms(2) = New SqlParameter("@LangId", SqlDbType.Int)
        arParms(2).Value = El.Lang_Id

        arParms(3) = New SqlParameter("@CType", SqlDbType.VarChar, 100)
        arParms(3).Value = El.Control_Type

        arParms(4) = New SqlParameter("@CCName", SqlDbType.NVarChar, 250)
        arParms(4).Value = El.CCName

        arParms(5) = New SqlParameter("@CId", SqlDbType.NVarChar, 250)
        arParms(5).Value = El.Control_Id

        arParms(6) = New SqlParameter("@Trans", SqlDbType.NVarChar, 1000)
        arParms(6).Value = El.Translation

        arParms(7) = New SqlParameter("@Type", SqlDbType.VarChar, 2)
        arParms(7).Value = El.Type

        arParms(8) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("EmpCode")

        arParms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("UserCode")

        arParms(10) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("BranchCode")

        arParms(11) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(11).Value = El.ID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateMultilingual", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DisplayGridValue(ByVal El As ELMultilingual) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = El.ID

        arParms(3) = New SqlParameter("@Types", SqlDbType.VarChar, 2)
        arParms(3).Value = El.Type

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMultilingualDetails", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function ChangeFlag(ByVal EL As ELMultilingual) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.ID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteMultilingual", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function insertBranchCombo() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectBranchComboSelect", arParms)
        Return ds.Tables(0)
    End Function
    Public Shared Function InsertLabel(ByVal El As ELMultilingual) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@Module_Id ", SqlDbType.Int)
        arParms(0).Value = El.moduleId

        arParms(1) = New SqlParameter("@FormId", SqlDbType.NVarChar, 100)
        arParms(1).Value = El.FormId

        arParms(2) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        arParms(2).Value = El.Branch

        arParms(3) = New SqlParameter("@CType", SqlDbType.VarChar, 100)
        arParms(3).Value = El.Control_Type

        arParms(4) = New SqlParameter("@CCName", SqlDbType.NVarChar, 250)
        arParms(4).Value = El.CCName

        arParms(5) = New SqlParameter("@CId", SqlDbType.NVarChar, 250)
        arParms(5).Value = El.Control_Id

        arParms(6) = New SqlParameter("@Trans", SqlDbType.NVarChar, 1000)
        arParms(6).Value = El.Translation

        arParms(7) = New SqlParameter("@Type", SqlDbType.VarChar, 2)
        arParms(7).Value = El.Type

        arParms(8) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("EmpCode")

        arParms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("UserCode")

        arParms(10) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertSpecificLabel", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function UpdateLabel(ByVal El As ELMultilingual) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}


        arParms(0) = New SqlParameter("@Module_Id ", SqlDbType.Int)
        arParms(0).Value = El.moduleId

        arParms(1) = New SqlParameter("@FormId", SqlDbType.NVarChar, 100)
        arParms(1).Value = El.FormId

        arParms(2) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        arParms(2).Value = El.Branch

        arParms(3) = New SqlParameter("@CType", SqlDbType.VarChar, 100)
        arParms(3).Value = El.Control_Type

        arParms(4) = New SqlParameter("@CCName", SqlDbType.NVarChar, 250)
        arParms(4).Value = El.CCName

        arParms(5) = New SqlParameter("@CId", SqlDbType.NVarChar, 250)
        arParms(5).Value = El.Control_Id

        arParms(6) = New SqlParameter("@Trans", SqlDbType.NVarChar, 1000)
        arParms(6).Value = El.Translation

        arParms(7) = New SqlParameter("@Type", SqlDbType.VarChar, 2)
        arParms(7).Value = El.Type

        arParms(8) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("EmpCode")

        arParms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("UserCode")

        arParms(10) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("BranchCode")

        arParms(11) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(11).Value = El.ID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateLabel", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DisplayLabelGrid(ByVal El As ELMultilingual) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = El.Branch

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = El.ID

        arParms(3) = New SqlParameter("@Types", SqlDbType.VarChar, 2)
        arParms(3).Value = El.Type

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLabelDetails", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function ChangeLabelFlag(ByVal EL As ELMultilingual) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.ID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteLabel", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
End Class
