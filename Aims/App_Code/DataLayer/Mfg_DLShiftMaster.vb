Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLShiftMaster
    Shared Function Insert(ByVal EL As Mfg_ELShiftMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Shift_Desc", SqlDbType.VarChar, 250)
        arParms(1).Value = EL.Shift_Desc

        arParms(2) = New SqlParameter("@Start_Time", SqlDbType.DateTime)
        arParms(2).Value = EL.Start_Time

        arParms(3) = New SqlParameter("@End_Time", SqlDbType.DateTime)
        arParms(3).Value = EL.End_Time
        If EL.DurationHrs = 0 Then
            arParms(4) = New SqlParameter("@DurationHrs", SqlDbType.Int)
            arParms(4).Value = DBNULL.value
        Else
            arParms(4) = New SqlParameter("@DurationHrs", SqlDbType.Int)
            arParms(4).Value = EL.DurationHrs

        End If
        
        arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(7).Value = EL.Remarks
        arParms(8) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("office")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertShiftMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
   
    Shared Function GetGridData(ByVal Id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = Id


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetShiftMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    
    Shared Function Update(ByVal EL As Mfg_ELShiftMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Shift_Desc", SqlDbType.VarChar, 250)
        arParms(1).Value = EL.Shift_Desc

        arParms(2) = New SqlParameter("@Start_Time", SqlDbType.DateTime)
        arParms(2).Value = EL.Start_Time

        arParms(3) = New SqlParameter("@End_Time", SqlDbType.DateTime)
        arParms(3).Value = EL.End_Time

        If EL.DurationHrs = 0 Then
            arParms(4) = New SqlParameter("@DurationHrs", SqlDbType.Int)
            arParms(4).Value = DBNULL.value
        Else
            arParms(4) = New SqlParameter("@DurationHrs", SqlDbType.Int)
            arParms(4).Value = EL.DurationHrs

        End If

        arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(7).Value = EL.Remarks

        arParms(8) = New SqlParameter("@id", SqlDbType.Int)
        arParms(8).Value = EL.id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateShiftMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ChangeFlag(ByVal EL As Mfg_ELShiftMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteShiftMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function GetDuplicateShift(ByVal EL As Mfg_ELShiftMaster) As Data.DataTable

        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Shift_Desc", SqlDbType.VarChar, 250)
        para(1).Value = EL.Shift_Desc

        para(2) = New SqlParameter("@Start_Time", SqlDbType.DateTime)
        para(2).Value = EL.Start_Time

        para(3) = New SqlParameter("@End_Time", SqlDbType.DateTime)
        para(3).Value = EL.End_Time

        para(4) = New SqlParameter("@id", SqlDbType.Int)
        para(4).Value = EL.id

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Mfg_DuplicateShift", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
