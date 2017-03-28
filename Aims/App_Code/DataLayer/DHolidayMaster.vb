Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DHolidayMaster
    Shared Function getHolidayMaster(ByVal el As EHolidayMaster) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@HM_ID", SqlDbType.Int)
        arParms(2).Value = el.Id
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetHolidayMaster", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function Insert(ByVal el As EHolidayMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        'arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        'arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(3) = New SqlParameter("@HolidayName", SqlDbType.NVarChar, 50)
        arParms(3).Value = el.Name
        arParms(4) = New SqlParameter("@HolidayDate", SqlDbType.DateTime)
        arParms(4).Value = el.Date1
        arParms(5) = New SqlParameter("@RbType", SqlDbType.VarChar, 2)
        arParms(5).Value = el.Rbid
        arParms(6) = New SqlParameter("@ShortName", SqlDbType.NVarChar, 50)
        arParms(6).Value = el.Shortname
        arParms(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("Office")



        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InsertIntoHolidayMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function CheckDuplicate(ByVal el As EHolidayMaster) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        'Dim para() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@HolidayDate", SqlDbType.DateTime)
        arParms(1).Value = el.Date1
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = el.Id
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_DuplicateHolidayMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function


    Shared Function Update(ByVal el As EHolidayMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        'arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        'arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(3) = New SqlParameter("@HolidayName", SqlDbType.NVarChar, 50)
        arParms(3).Value = el.Name
        arParms(4) = New SqlParameter("@HolidayDate", SqlDbType.DateTime)
        arParms(4).Value = el.Date1
        arParms(5) = New SqlParameter("@HM_ID", SqlDbType.Int)
        arParms(5).Value = el.Id
        arParms(6) = New SqlParameter("@RbType", SqlDbType.VarChar, 2)
        arParms(6).Value = el.Rbid
        arParms(7) = New SqlParameter("@ShortName", SqlDbType.NVarChar, 50)
        arParms(7).Value = el.Shortname

        

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateHolidayMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ChangeFlag(ByVal Id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@HM_ID", SqlDbType.Int)
        arParms(0).Value = Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteHolidayMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function


End Class

