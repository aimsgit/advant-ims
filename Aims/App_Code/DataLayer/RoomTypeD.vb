Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class RoomTypeD


    Shared Function Insert(ByVal EL As RoomTypeE) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@RoomType", SqlDbType.VarChar, 50)
        arParms(0).Value = EL.RoomType


        arParms(1) = New SqlParameter("@NoOfOccupants", SqlDbType.Int)
        arParms(1).Value = EL.Occupant

        arParms(2) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(2).Value = EL.Remarks

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")

        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "H_InsertRoomType", arParms)
        Catch ex As Exception
        End Try
        Return rowsAffected
    End Function
    Shared Function GetRoomType(ByVal EL As RoomTypeE) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.id

        arParms(3) = New SqlParameter("@RoomType", SqlDbType.VarChar, 50)
        arParms(3).Value = EL.RoomType


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "H_GetRoomType", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function Update(ByVal EL As RoomTypeE) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(6) {}




        arParms(0) = New SqlParameter("@RoomTypeAuto", SqlDbType.Int)
        arParms(0).Value = EL.id

        arParms(1) = New SqlParameter("@RoomType", SqlDbType.VarChar, 50)
        arParms(1).Value = EL.RoomType


        arParms(2) = New SqlParameter("@NoOfOccupants", SqlDbType.Int)
        arParms(2).Value = EL.Occupant

        arParms(3) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(3).Value = EL.Remarks

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "H_UpdateRoomType", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function CheckDuplicate(ByVal s As RoomTypeE) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = s.id
        para(1) = New SqlParameter("@RoomType", SqlDbType.VarChar, 50)
        para(1).Value = s.RoomType

        para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "H_DuplicateRoomType", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function

    Shared Function Delete(ByVal EL As RoomTypeE) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.id
        Dim rowsAffected As Integer = 0

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "H_DeleteRoomType", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function


End Class
