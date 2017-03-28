Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class VisitingDB
    Shared Function DispGrid(ByVal v As Visiting) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@VID", SqlDbType.Int)
        arParms(2).Value = v.VId
        Dim ds As New DataSet

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetVisitingDetails", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function Insert(ByVal v As Visiting) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(10) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

     
        arParms(1) = New SqlParameter("@Visiting_Date", SqlDbType.DateTime)
        arParms(1).Value = v.VisitingDate

        arParms(2) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(2).Value = v.Empid
        If v.Fromtime = "1/1/1900" Then
            arParms(3) = New SqlParameter("@From_Time", SqlDbType.DateTime)
            arParms(3).Value = DBNull.Value
        Else
            arParms(3) = New SqlParameter("@From_Time", SqlDbType.DateTime)
            arParms(3).Value = v.Fromtime
        End If

        If v.Totime = "1/1/1900" Then
            arParms(4) = New SqlParameter("@To_Time", SqlDbType.DateTime)
            arParms(4).Value = DBNull.Value
        Else
            arParms(4) = New SqlParameter("@To_Time", SqlDbType.DateTime)
            arParms(4).Value = v.Totime
        End If

        arParms(5) = New SqlParameter("@Contact_Details", SqlDbType.VarChar, 500)
        arParms(5).Value = v.Contactdetails

        arParms(6) = New SqlParameter("@Discussion", SqlDbType.VarChar, 1000)
        arParms(6).Value = v.Discussion

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 1000)
        arParms(7).Value = v.Remarks

        arParms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")

        arParms(9) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("EmpCode")

        arParms(10) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveVisitingDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal v As Visiting) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(10) {}
        arParms(0) = New SqlParameter("@VID", SqlDbType.Int)
        arParms(0).Value = v.VId

        If v.VisitingDate = Today.ToString("dd-MMM-yyyy") Then
            arParms(1) = New SqlParameter("@Visiting_Date", SqlDbType.DateTime)
            arParms(1).Value = Today.ToString("dd-MMM-yyyy")
        Else
            arParms(1) = New SqlParameter("@Visiting_Date", SqlDbType.DateTime)
            arParms(1).Value = v.VisitingDate
        End If

        arParms(2) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(2).Value = v.Empid


        If v.Fromtime = "1/1/1900" Then
            arParms(3) = New SqlParameter("@From_Time", SqlDbType.DateTime)
            arParms(3).Value = DBNull.Value
        Else
            arParms(3) = New SqlParameter("@From_Time", SqlDbType.DateTime)
            arParms(3).Value = v.Fromtime
        End If

        If v.Totime = "1/1/1900" Then
            arParms(4) = New SqlParameter("@To_Time", SqlDbType.DateTime)
            arParms(4).Value = DBNull.Value
        Else
            arParms(4) = New SqlParameter("@To_Time", SqlDbType.DateTime)
            arParms(4).Value = v.Totime
        End If

        arParms(5) = New SqlParameter("@Contact_Details", SqlDbType.VarChar, 500)
        arParms(5).Value = v.Contactdetails

        arParms(6) = New SqlParameter("@Discussion", SqlDbType.VarChar, 1000)
        arParms(6).Value = v.Discussion

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 1000)
        arParms(7).Value = v.Remarks

        arParms(8) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("BranchCode")

        arParms(9) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("EmpCode")

        arParms(10) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("UserCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateVisitingDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal v As Visiting) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@VID", SqlDbType.Int)
        arParms(0).Value = v.VId

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteVisitingDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
   
    Shared Function RptGetVisitingDetails(ByVal VID As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@VID", SqlDbType.Int)
        arParms(2).Value = VID
        Dim ds As New DataSet

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_VisitingDetails", arParms)
        Return ds.Tables(0)

    End Function

End Class
