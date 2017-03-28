Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLCapacityPlan
    Shared Function GetCapacityPlan(ByVal EL As ELCapacityPlan) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.Id

        arParms(3) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(3).Value = EL.Dept
        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCapacityPlan", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return dt
    End Function

    Shared Function Insert(ByVal EL As ELCapacityPlan) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(1).Value = EL.Dept

        arParms(2) = New SqlParameter("@Grade", SqlDbType.Int)
        arParms(2).Value = EL.Grade

        arParms(3) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(3).Value = EL.Year

        arParms(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")
        If EL.Reqdate = "1/1/1900" Then
            arParms(6) = New SqlParameter("@Reqdate", SqlDbType.DateTime)
            arParms(6).Value = DBNull.Value
        Else
            arParms(6) = New SqlParameter("@Reqdate", SqlDbType.DateTime)
            arParms(6).Value = EL.Reqdate
        End If
        arParms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.Remarks

        arParms(8) = New SqlParameter("@NosReq", SqlDbType.Int)
        arParms(8).Value = EL.NosReq
        arParms(9) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
        arParms(9).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertCapacityPlan", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal EL As ELCapacityPlan) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(1).Value = EL.Dept

        arParms(2) = New SqlParameter("@Grade", SqlDbType.Int)
        arParms(2).Value = EL.Grade

        arParms(3) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(3).Value = EL.Year

        arParms(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@Reqdate", SqlDbType.DateTime)
        arParms(6).Value = EL.Reqdate

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.Remarks

        arParms(8) = New SqlParameter("@id", SqlDbType.Int)
        arParms(8).Value = EL.Id

        arParms(9) = New SqlParameter("@NosReq", SqlDbType.Int)
        arParms(9).Value = EL.NosReq


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdatecapacityPlan", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ChangeFlag(ByVal EL As ELCapacityPlan) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.Id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteCapacityPlan", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function CheckDuplicate(ByVal EL As ELCapacityPlan) As DataTable

        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(5) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Dept", SqlDbType.Int)
        para(1).Value = EL.Dept
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = EL.Id
        para(3) = New SqlParameter("@Grade", SqlDbType.VarChar, 50)
        para(3).Value = EL.Grade
        para(4) = New SqlParameter("@Year", SqlDbType.VarChar, 50)
        para(4).Value = EL.Year
        para(5) = New SqlParameter("@Reqdate", SqlDbType.DateTime)
        para(5).Value = EL.Reqdate

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_DuplicateCapacityPlan", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
