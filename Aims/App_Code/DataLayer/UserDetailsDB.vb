Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class UserDetailsDB
    'Public Shared Function Insert(ByVal UserID As String, ByVal UserName As String, ByVal EDate As DateTime) As Integer
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim rowsAffected As Integer = 0
    '    Dim arParms() As SqlParameter = New SqlParameter(5) {}

    '    arParms(0) = New SqlParameter("@UserID", SqlDbType.NVarChar)
    '    arParms(0).Value = UserID
    '    If HttpContext.Current.Session("Admin") = 1 Then
    '        arParms(1) = New SqlParameter("@BranchID", SqlDbType.Int)
    '        arParms(1).Value = CInt(HttpContext.Current.Session("NewBranchID"))

    '        arParms(2) = New SqlParameter("@BranchTypeID", SqlDbType.Int)
    '        arParms(2).Value = 0
    '    Else
    '        arParms(1) = New SqlParameter("@BranchID", SqlDbType.Int)
    '        arParms(1).Value = CInt(HttpContext.Current.Session("BranchID"))

    '        arParms(2) = New SqlParameter("@BranchTypeID", SqlDbType.Int)
    '        arParms(2).Value = CInt(HttpContext.Current.Session("BranchTypeID"))
    '    End If

    '    arParms(3) = New SqlParameter("@UserName", SqlDbType.NVarChar)
    '    arParms(3).Value = UserName

    '    arParms(4) = New SqlParameter("@Emp_ID", SqlDbType.Int)
    '    arParms(4).Value = HttpContext.Current.Session("EMPID")

    '    arParms(5) = New SqlParameter("@ExpDate", SqlDbType.DateTime)
    '    arParms(5).Value = EDate

    '    Try
    '        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveUserDetails", arParms)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try

    '    Return rowsAffected
    'End Function
    Shared Function GetAllUsers() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@ApplicationName", SqlDbType.NVarChar)
        arParms(0).Value = "/SLSSB_DEV"

        arParms(1) = New SqlParameter("@PageIndex", SqlDbType.Int)
        arParms(1).Value = 0

        arParms(2) = New SqlParameter("@PageSize", SqlDbType.Int)
        arParms(2).Value = 10
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "aspnet_Membership_GetAllUsers", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If ds.Tables.Count > 0 Then
            Return ds.Tables(0)
        Else
            Return Nothing
        End If
    End Function
    Shared Function GetOnlineUserInfo(ByVal UserID As String, ByVal PassWord As String, ByVal SPassWord As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@UserID", SqlDbType.NVarChar)
        arParms(0).Value = UserID


        arParms(1) = New SqlParameter("@pass", SqlDbType.NVarChar)
        arParms(1).Value = PassWord

        arParms(2) = New SqlParameter("@Spass", SqlDbType.NVarChar)
        arParms(2).Value = SPassWord
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetOnlineUserInfoNew", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If ds.Tables.Count = 0 Then
            Return Nothing
        Else
            Return ds.Tables(0)
        End If
    End Function
    Shared Function GetParentOnlineInfo(ByVal UserID As String, ByVal PassWord As String, ByVal SPassWord As String, ByVal LoginType As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@UserID", SqlDbType.NVarChar)
        arParms(0).Value = UserID

        arParms(1) = New SqlParameter("@pass", SqlDbType.NVarChar)
        arParms(1).Value = PassWord

        arParms(2) = New SqlParameter("@Spass", SqlDbType.NVarChar)
        arParms(2).Value = SPassWord

        arParms(3) = New SqlParameter("@LoginType", SqlDbType.NVarChar)
        arParms(3).Value = LoginType
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetParentOnlineInfo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If ds.Tables.Count = 0 Then
            Return Nothing
        Else
            Return ds.Tables(0)
        End If
    End Function
    Shared Function GetLogInNewsEvents() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetLogInNewsEvents")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If ds.Tables.Count = 0 Then
            Return Nothing
        Else
            Return ds.Tables(0)
        End If
    End Function
    Shared Function GetLogInNotice() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetLogInNotice")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If ds.Tables.Count = 0 Then
            Return Nothing
        Else
            Return ds.Tables(0)
        End If
    End Function
    Shared Function GetLogInObj() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetLogInObj")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If ds.Tables.Count = 0 Then
            Return Nothing
        Else
            Return ds.Tables(0)
        End If
    End Function
    Shared Function GetHeader() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetHeader")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If ds.Tables.Count = 0 Then
            Return Nothing
        Else
            Return ds.Tables(0)
        End If
    End Function
    Shared Function GetHeader1() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetHeader1")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If ds.Tables.Count = 0 Then
            Return Nothing
        Else
            Return ds.Tables(0)
        End If
    End Function
    Shared Function InsertError() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim roweffectted As Integer
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@ErrorDate", SqlDbType.DateTime)
        arParms(0).Value = DateAndTime.Now

        arParms(1) = New SqlParameter("@InstitueName", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("InstituteName")

        arParms(2) = New SqlParameter("@InstitueCode", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("InstituteCode")

        arParms(3) = New SqlParameter("@UserName", SqlDbType.VarChar)
        arParms(3).Value = IIf(HttpContext.Current.Session("StudentName") Is DBNull.Value Or HttpContext.Current.Session("StudentName") = "", HttpContext.Current.Session("EmpName"), HttpContext.Current.Session("StudentName"))

        arParms(4) = New SqlParameter("@ErrorMessage", SqlDbType.VarChar)
        arParms(4).Value = HttpContext.Current.Session("ErrorMsg")

        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@Formname", SqlDbType.VarChar)
        arParms(6).Value = HttpContext.Current.Session("RptFrmTitleName")

        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")
        Try
            roweffectted = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveErrorLOG", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Shared Function GetOnlyUserNames(ByVal EMPID As Long) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@Emp_ID", SqlDbType.Int)
        arParms(0).Value = EMPID

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetOnlyUserNames", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Shared Function Update(ByVal UDtlsId As Long, ByVal TypeID As Long, ByVal BranchID As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@UserDetailsID", SqlDbType.NVarChar)
        arParms(0).Value = UDtlsId

        arParms(1) = New SqlParameter("@BranchTypeID", SqlDbType.Int)
        arParms(1).Value = TypeID

        arParms(2) = New SqlParameter("@BranchID", SqlDbType.Int)
        arParms(2).Value = BranchID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateUserDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Shared Function insert(ByVal usrid As Integer, ByVal LoginType As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@UserID", SqlDbType.Int)
        arParms(0).Value = usrid

        arParms(1) = New SqlParameter("@LoginType", SqlDbType.VarChar)
        arParms(1).Value = LoginType

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SaveUSERLOG", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Shared Function GetTypeAndBranchByUID(ByVal UID As Long) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@UID", SqlDbType.Int)
        arParms(0).Value = UID


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SP_GetTypeAndBranchByUID", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Shared Function UpdateUserlog() As Int16
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(0) {}

            'Begin Edit by Kusum
            arParms(0) = New SqlParameter("@LogID", SqlDbType.BigInt)
            arParms(0).Value = HttpContext.Current.Session("logid")
            'End Edit by Kusum

            Try
                rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateLogUsers", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return rowsAffected
        Catch ex As Exception
            Return 0
        End Try
    End Function
    'Begin Edit by Kusum   
    Public Shared Function Update_sessionclear(ByVal username As String) As Int16
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(0) {}


            arParms(0) = New SqlParameter("@u_name", SqlDbType.VarChar, 50)
            arParms(0).Value = username

            Try
                rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_Update_sessionclear", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return rowsAffected
        Catch ex As Exception
            Return 0
        End Try
    End Function
    'End Edit by Kusum
    Shared Function CheckAlreadyLogged(ByVal usrid As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@UsrID", SqlDbType.NVarChar)
        arParms(0).Value = usrid

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckAlreadyLogged", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetLinkName() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@ID", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserRole")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@LanguageID", SqlDbType.Int)
        arParms(3).Value = HttpContext.Current.Session("LanguageID")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCutomizeLinkNameTree", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function SearchParentLinkName(ByVal prefix As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@ID", SqlDbType.VarChar, 150)
        arParms(0).Value = HttpContext.Current.Session("UserRole")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@LinkName", SqlDbType.VarChar, 50)
        arParms(3).Value = prefix
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_SearchParentLinkName]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function SearchLinkName(ByVal prefix As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@ID", SqlDbType.VarChar, 150)
        arParms(0).Value = HttpContext.Current.Session("UserRole")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@LinkName", SqlDbType.VarChar, 50)
        arParms(3).Value = prefix
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SearchLinkName", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetParentsLinkName() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetParentsLinkName")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetParentsName() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetParentsName1")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetParentName() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@ID", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserRole")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@LanguageID", SqlDbType.Int)
        arParms(3).Value = HttpContext.Current.Session("LanguageID")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetParentName", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetParentNameddl() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@ID", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserRole")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@LanguageID", SqlDbType.Int)
        arParms(3).Value = HttpContext.Current.Session("LanguageID")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetParentNameddl", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function SaveTestTrace() As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim RowsEffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")

        arParms(1) = New SqlParameter("@Module", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("FrmParentName")

        arParms(2) = New SqlParameter("@FormName", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("RptFrmTitleName")

        arParms(3) = New SqlParameter("@Duration", SqlDbType.VarChar, 50)
        arParms(3).Value = ""

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")
        Try
            RowsEffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveTestTrace", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return RowsEffected
    End Function

    Shared Function GetMacAddress(ByVal LocalMAC As String) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As String
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@MAC", SqlDbType.VarChar, 250)
        arParms(0).Value = LocalMAC
        Try
            ds = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_CheckMACAddress", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    '' global or local table

    'Public Function GetConfigTable() As System.Data.DataSet
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As DataSet
    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Select TableName,TableAccessLevel From TableMaster")
    '    Return ds
    'End Function
    '' user role 

    'Public Function RoleMap() As System.Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As DataSet
    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Select * From View_RoleMap")
    '    Return ds.Tables(0)
    'End Function
    Shared Function CheckSecurityCheck() As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As String
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_GetCheckUnlockStatus", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Shared Function GetHelpLink(ByVal Code As String, ByVal Type As String) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As String

     
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Code", SqlDbType.VarChar, 50)
        arParms(0).Value = Code

        arParms(1) = New SqlParameter("@Type", SqlDbType.VarChar, 50)
        arParms(1).Value = Type


        Try
            ds = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_GetHelpLink", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function

    'Shared Function GetErrorLogEmail() As System.Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As DataSet
    '    Dim arParms() As SqlParameter = New SqlParameter() {}

    '    Try
    '        ds = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_ErrorLogAdvant", arParms)

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds
    'End Function
    Shared Function GetCurrentErrorLog() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@ErrorDate", SqlDbType.DateTime)
        arParms(0).Value = DateAndTime.Now

        arParms(1) = New SqlParameter("@InstitueName", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("InstituteName")

        arParms(2) = New SqlParameter("@InstitueCode", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("InstituteCode")

        arParms(3) = New SqlParameter("@UserName", SqlDbType.VarChar)
        arParms(3).Value = IIf(HttpContext.Current.Session("StudentName") Is DBNull.Value Or HttpContext.Current.Session("StudentName") = "", HttpContext.Current.Session("EmpName"), HttpContext.Current.Session("StudentName"))

        arParms(4) = New SqlParameter("@ErrorMessage", SqlDbType.VarChar)
        arParms(4).Value = IIf(HttpContext.Current.Session("ErrorMsg") = "", " ", HttpContext.Current.Session("ErrorMsg"))

        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@Formname", SqlDbType.VarChar)
        arParms(6).Value = HttpContext.Current.Session("RptFrmTitleName")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetErrorDetails", arParms)
            ' ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetParentName", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetAimsFeatures() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dttree As DataSet
        Try
            dttree = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Get_NewLogintreeview")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return dttree.Tables(0)
    End Function
    Shared Function SetLoginBlockedTime(ByVal UserID As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@UserID", SqlDbType.NVarChar)
        arParms(0).Value = UserID

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SetLoginBlockedTime", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If ds.Tables.Count = 0 Then
            Return Nothing
        Else
            Return ds.Tables(0)
        End If
    End Function
    Shared Function CheckRoleElgibility(ByVal UserID As String, ByVal UserRole As String, ByVal UserBranchCode As String, RequestedPage As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@UserID", SqlDbType.NVarChar)
        arParms(0).Value = UserID

        arParms(1) = New SqlParameter("@UserRole", SqlDbType.NVarChar)
        arParms(1).Value = UserRole

        arParms(2) = New SqlParameter("@UserBranch", SqlDbType.NVarChar)
        arParms(2).Value = UserBranchCode

        arParms(3) = New SqlParameter("@RequestedPage", SqlDbType.NVarChar)
        arParms(3).Value = RequestedPage

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckRoleEligibility", arParms)
            'Catch ex As Exception
            '    MsgBox(ex.ToString)
            'End Try
            'Try
            Return ds.Tables(0).Rows(0).Item(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return 0
        End Try
    End Function
End Class
