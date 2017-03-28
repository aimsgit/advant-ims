Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLStockStatus
    Public Function GetGodownCode() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        'arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        'arParms(1).Value = HttpContext.Current.Session("BranchCode")


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectGodownCode", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetStockStmtReport(ByVal StartDate As String, ByVal EndDate As String, ByVal Company_Id As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        para(2).Value = StartDate
        para(3) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        para(3).Value = EndDate
        para(4) = New SqlParameter("@Company_Id", SqlDbType.Int)
        para(4).Value = Company_Id


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_RptStockStatement", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetRacknumber() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        'arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        'arParms(1).Value = HttpContext.Current.Session("BranchCode")


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectRackNumber", arParms)
        Return ds.Tables(0)
    End Function

    Public Function GetProductName(ByVal id As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = id

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectProductName", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetViewdetails(ByVal prodid As Integer, ByVal Gno As Integer, ByVal Rno As Integer, ByVal Sdate As Date, ByVal edate As Date, ByVal ptype As Integer, ByVal Catgry As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        'If Sdate = "1/1/1900" Then
        '    arParms(0) = New SqlParameter("@StartDate", SqlDbType.VarChar)
        '    arParms(0).Value = DBNull.Value
        'Else
        arParms(0) = New SqlParameter("@StartDate", SqlDbType.VarChar)
        arParms(0).Value = Sdate
        'End If

        'If edate = "1/1/1900" Then
        '    arParms(1) = New SqlParameter("@Enddate", SqlDbType.VarChar)
        '    arParms(1).Value = DBNull.Value
        'Else
        arParms(1) = New SqlParameter("@Enddate", SqlDbType.Date)
        arParms(1).Value = edate

        'End If

        arParms(2) = New SqlParameter("@ProdId", SqlDbType.Int)
        arParms(2).Value = prodid

        arParms(3) = New SqlParameter("@GodownNo", SqlDbType.Int)
        arParms(3).Value = Gno

        arParms(4) = New SqlParameter("@RackNo", SqlDbType.Int)
        arParms(4).Value = Rno


        arParms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("Office")

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@Ptype", SqlDbType.Int)
        arParms(7).Value = ptype

        arParms(8) = New SqlParameter("@Category", SqlDbType.Int)
        arParms(8).Value = Catgry

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStkStatusReport", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetViewdetails2(ByVal prodid As Integer, ByVal Gno As Integer, ByVal Rno As Integer, ByVal Sdate As Date, ByVal edate As Date, ByVal ptype As Integer, ByVal Catgry As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        'If Sdate = "1/1/1900" Then
        '    arParms(0) = New SqlParameter("@StartDate", SqlDbType.VarChar)
        '    arParms(0).Value = DBNull.Value
        'Else
        arParms(0) = New SqlParameter("@StartDate", SqlDbType.Date)
        arParms(0).Value = Sdate
        'End If

        'If edate = "1/1/1900" Then
        '    arParms(1) = New SqlParameter("@Enddate", SqlDbType.VarChar)
        '    arParms(1).Value = DBNull.Value
        'Else
        arParms(1) = New SqlParameter("@Enddate", SqlDbType.Date)
        arParms(1).Value = edate

        'End If

        arParms(2) = New SqlParameter("@ProdId", SqlDbType.Int)
        arParms(2).Value = prodid

        arParms(3) = New SqlParameter("@GodownNo", SqlDbType.Int)
        arParms(3).Value = Gno

        arParms(4) = New SqlParameter("@RackNo", SqlDbType.Int)
        arParms(4).Value = Rno


        arParms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("Office")

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@Ptype", SqlDbType.Int)
        arParms(7).Value = ptype

        arParms(8) = New SqlParameter("@Category", SqlDbType.Int)
        arParms(8).Value = Catgry

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStkStatusReport2", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetViewdetails1(ByVal prodid As Integer, ByVal Gno As Integer, ByVal Rno As Integer, ByVal Sdate As Date, ByVal edate As Date, ByVal ptype As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        'If Sdate = "1/1/1900" Then
        '    arParms(0) = New SqlParameter("@StartDate", SqlDbType.VarChar)
        '    arParms(0).Value = DBNull.Value
        'Else
        arParms(0) = New SqlParameter("@StartDate", SqlDbType.VarChar)
        arParms(0).Value = Sdate
        'End If

        'If edate = "1/1/1900" Then
        '    arParms(1) = New SqlParameter("@Enddate", SqlDbType.VarChar)
        '    arParms(1).Value = DBNull.Value
        'Else
        arParms(1) = New SqlParameter("@Enddate", SqlDbType.Date)
        arParms(1).Value = edate

        'End If

        arParms(2) = New SqlParameter("@ProdId", SqlDbType.Int)
        arParms(2).Value = prodid

        arParms(3) = New SqlParameter("@GodownNo", SqlDbType.Int)
        arParms(3).Value = Gno

        arParms(4) = New SqlParameter("@RackNo", SqlDbType.Int)
        arParms(4).Value = Rno


        arParms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("Office")

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@Ptype", SqlDbType.Int)
        arParms(7).Value = ptype

      
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStkStatus", arParms)
        Return ds.Tables(0)
    End Function

    Public Function GetStkExpirydetails(ByVal id As Integer, ByVal Ptype As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        'arParms(0) = New SqlParameter("@StartDate", SqlDbType.Date)
        'arParms(0).Value = Sdate

        'arParms(1) = New SqlParameter("@Enddate", SqlDbType.Date)
        'arParms(1).Value = edate

        'arParms(2) = New SqlParameter("@ProdId", SqlDbType.Int)
        'arParms(2).Value = prodid

        'arParms(3) = New SqlParameter("@GodownNo", SqlDbType.Int)
        'arParms(3).Value = Gno

        'arParms(4) = New SqlParameter("@RackNo", SqlDbType.Int)
        'arParms(4).Value = Rno


        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = id

        arParms(3) = New SqlParameter("@Ptype", SqlDbType.Int)
        arParms(3).Value = Ptype



        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStkStatusExpiry", arParms)
        Return ds.Tables(0)
    End Function

    Public Function GetStkNormaldetails(ByVal id As Integer, ByVal Ptype As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        'arParms(0) = New SqlParameter("@StartDate", SqlDbType.Date)
        'arParms(0).Value = Sdate

        'arParms(1) = New SqlParameter("@Enddate", SqlDbType.Date)
        'arParms(1).Value = edate

        'arParms(2) = New SqlParameter("@ProdId", SqlDbType.Int)
        'arParms(2).Value = prodid

        'arParms(3) = New SqlParameter("@GodownNo", SqlDbType.Int)
        'arParms(3).Value = Gno

        'arParms(4) = New SqlParameter("@RackNo", SqlDbType.Int)
        'arParms(4).Value = Rno


        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = id

        arParms(3) = New SqlParameter("@Ptype", SqlDbType.Int)
        arParms(3).Value = Ptype



        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStkStatusNormal", arParms)
        Return ds.Tables(0)
    End Function
End Class
