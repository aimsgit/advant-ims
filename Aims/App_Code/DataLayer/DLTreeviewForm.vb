
'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'
'--Author: Kusum.C.Akki
'--Date: 02.01.2013
'--Description: Treeview form to configure the module and its respective child.
'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLTreeviewForm
    Shared Function GetModule(ByVal M As ELTreeviewForm) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Parms(1).Value = HttpContext.Current.Session("Office")

        Parms(2) = New SqlParameter("@MNPKID", SqlDbType.Int)
        Parms(2).Value = M.id

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetModuleMaster", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_DdlModuleMaster", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetDuplicateModule(ByVal M As ELTreeviewForm) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(4) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Parms(1).Value = HttpContext.Current.Session("Office")

        Parms(2) = New SqlParameter("@MNPKID", SqlDbType.Int)
        Parms(2).Value = M.id

        Parms(3) = New SqlParameter("@ModuleName", SqlDbType.VarChar, 150)
        Parms(3).Value = M.ModuleName

        Parms(4) = New SqlParameter("@SequenceNo", SqlDbType.Int)
        Parms(4).Value = M.SequenceNo

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetDuplicateModuleMaster", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Insert(ByVal M As ELTreeviewForm) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(5) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("UserCode")

        Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("EmpCode")

        Parms(3) = New SqlParameter("@MNPKID", SqlDbType.Int)
        Parms(3).Value = M.id

        Parms(4) = New SqlParameter("@ModuleName", SqlDbType.VarChar, 150)
        Parms(4).Value = M.ModuleName

        Parms(5) = New SqlParameter("@SequenceNo", SqlDbType.Int)
        Parms(5).Value = M.SequenceNo

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertModuleMaster", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Delete(ByVal M As ELTreeviewForm) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Parms(0) = New SqlParameter("@MNPKID", SqlDbType.Int)
        Parms(0).Value = M.id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteModuleMaster", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function DeleteChild(ByVal M As ELTreeviewChildForm) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Parms(0) = New SqlParameter("@CNPKID", SqlDbType.Int)
        Parms(0).Value = M.id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteTreeviewChild", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function InsertChild(ByVal M As ELTreeviewChildForm) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(7) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("UserCode")

        Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("EmpCode")

        Parms(3) = New SqlParameter("@CNPKID", SqlDbType.Int)
        Parms(3).Value = M.id

        Parms(4) = New SqlParameter("@MNIDAuto", SqlDbType.Int)
        Parms(4).Value = M.Moduleid

        Parms(5) = New SqlParameter("@ChildName", SqlDbType.VarChar, 150)
        Parms(5).Value = M.FormName

        Parms(6) = New SqlParameter("@ChildFileName", SqlDbType.VarChar, 150)
        Parms(6).Value = M.FormFileName

        Parms(7) = New SqlParameter("@SequenceNo", SqlDbType.Int)
        Parms(7).Value = M.SequenceNo
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertTreeview_ChildMaster", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetDuplicateChild(ByVal M As ELTreeviewChildForm) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(5) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Moduleid", SqlDbType.Int)
        Parms(1).Value = M.Moduleid

        Parms(2) = New SqlParameter("@CNPKID", SqlDbType.Int)
        Parms(2).Value = M.id

        Parms(3) = New SqlParameter("@FormName", SqlDbType.VarChar, 150)
        Parms(3).Value = M.FormName

        Parms(4) = New SqlParameter("@FormLinkName", SqlDbType.VarChar, 150)
        Parms(4).Value = M.FormFileName

        Parms(5) = New SqlParameter("@SequenceNo", SqlDbType.Int)
        Parms(5).Value = M.SequenceNo

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetDuplicateChildMaster", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetChild(ByVal M As ELTreeviewChildForm) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(3) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Parms(1).Value = HttpContext.Current.Session("Office")

        Parms(2) = New SqlParameter("@CNPKID", SqlDbType.Int)
        Parms(2).Value = M.id

        Parms(3) = New SqlParameter("@MNIDAuto", SqlDbType.Int)
        Parms(3).Value = M.Moduleid
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetTreeview_ChildMaster", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCustTreeviewDetails(ByVal M As ELTreeviewChildForm, ByVal formname As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(3) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Parms(1).Value = HttpContext.Current.Session("Office")

        Parms(2) = New SqlParameter("@childname", SqlDbType.Int)
        Parms(2).Value = formname

        Parms(3) = New SqlParameter("@MNIDAuto", SqlDbType.Int)
        Parms(3).Value = M.Modules
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Treeviewchildautofill", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCustomizeChild(ByVal M As ELTreeviewChildForm) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(3) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Parms(1).Value = HttpContext.Current.Session("Office")

        Parms(2) = New SqlParameter("@CNPKID", SqlDbType.Int)
        Parms(2).Value = M.CustomizeTreeviewId

        Parms(3) = New SqlParameter("@MNIDAuto", SqlDbType.Int)
        Parms(3).Value = M.Moduleid

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetTanentCustomizeTreeview", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function DeleteCustomizeChild(ByVal M As ELTreeviewChildForm) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Parms(0) = New SqlParameter("@CustomizeTreeviewId", SqlDbType.Int)
        Parms(0).Value = M.CustomizeTreeviewId

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteCustomizeTreeviewChild", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function InsertCustomizeTreeview(ByVal M As ELTreeviewChildForm) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(8) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("UserCode")

        Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("EmpCode")

        Parms(3) = New SqlParameter("@CNPKID", SqlDbType.Int)
        Parms(3).Value = M.id

        Parms(4) = New SqlParameter("@MNIDAuto", SqlDbType.Int)
        Parms(4).Value = M.Modules

        Parms(5) = New SqlParameter("@ChildName", SqlDbType.Int)
        Parms(5).Value = M.FormNames

        Parms(6) = New SqlParameter("@ChildFileName", SqlDbType.VarChar, 150)
        Parms(6).Value = M.FormFileName

        Parms(7) = New SqlParameter("@SequenceNo", SqlDbType.Int)
        Parms(7).Value = M.SequenceNo
        Parms(8) = New SqlParameter("@ChildName", SqlDbType.VarChar, 150)
        Parms(8).Value = M.FormName
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertTreeview_ChildMaster", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function InsertTanentChild(ByVal M As ELTreeviewChildForm) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(9) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = M.BranchName

        Parms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("UserCode")

        Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("EmpCode")

        Parms(3) = New SqlParameter("@CNPKID", SqlDbType.Int)
        Parms(3).Value = M.CustomizeTreeviewId

        Parms(4) = New SqlParameter("@MNIDAuto", SqlDbType.Int)
        Parms(4).Value = M.Moduleid

        Parms(5) = New SqlParameter("@ChildName", SqlDbType.VarChar, 150)
        Parms(5).Value = M.FormName

        Parms(6) = New SqlParameter("@ChildAliasFileName", SqlDbType.VarChar, 150)
        Parms(6).Value = M.AliasName

        Parms(7) = New SqlParameter("@SequenceNo", SqlDbType.Int)
        Parms(7).Value = M.SequenceNo

        Parms(8) = New SqlParameter("@ChildFileName", SqlDbType.VarChar, 50)
        Parms(8).Value = M.FormFileName

        Parms(9) = New SqlParameter("@CNIDAUTO", SqlDbType.Int)
        Parms(9).Value = M.id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertTanentTreeview_ChildMaster", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_ddlChild", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function CustomizeDuplicate(ByVal M As ELTreeviewChildForm) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(3) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = M.BranchName

        Parms(1) = New SqlParameter("@formname", SqlDbType.Int)
        Parms(1).Value = M.FormNames

        Parms(2) = New SqlParameter("@MNIDAutoCust ", SqlDbType.Int)
        Parms(2).Value = M.Moduleid

        Parms(3) = New SqlParameter("@id", SqlDbType.Int)
        Parms(3).Value = M.CustomizeTreeviewId
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetDuplicatedeptCustomizeTreeview", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
