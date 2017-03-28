Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLPropertyLot
    Shared Function InsertRecord(ByVal EL As ELProperty) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim aParams() As SqlParameter = New SqlParameter(10) {}
        aParams(0) = New SqlParameter("@Lot_Number", SqlDbType.VarChar, 50)
        aParams(0).Value = EL.Lot_Number
        aParams(1) = New SqlParameter("@SaleDate", SqlDbType.VarChar, 50)
        aParams(1).Value = EL.SaleDate
        aParams(2) = New SqlParameter("@Properties", SqlDbType.VarChar, 50)
        aParams(2).Value = EL.Properties
        aParams(3) = New SqlParameter("@NoofUnits", SqlDbType.VarChar, 50)
        aParams(3).Value = EL.NoofUnits
        aParams(4) = New SqlParameter("@Avg_price ", SqlDbType.Money, 50)
        aParams(4).Value = EL.Avg_price
        aParams(5) = New SqlParameter("@LotStatus ", SqlDbType.VarChar, 50)
        aParams(5).Value = EL.LotStatus
        aParams(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        aParams(6).Value = HttpContext.Current.Session("BranchCode")

        aParams(7) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        aParams(7).Value = HttpContext.Current.Session("EmpCode")

        aParams(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        aParams(8).Value = HttpContext.Current.Session("UserCode")

        aParams(9) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        aParams(9).Value = HttpContext.Current.Session("Office")
        aParams(10) = New SqlParameter("@Location ", SqlDbType.VarChar, 50)
        aParams(10).Value = EL.Location
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_InsertExamBatches", aParams)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetRecord(ByVal EL As ELProperty) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim aParms() As SqlParameter = New SqlParameter(4) {}
        Dim ds As New DataSet
        aParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        aParms(0).Value = EL.ID
        aParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        aParms(1).Value = HttpContext.Current.Session("Office")
        aParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        aParms(2).Value = HttpContext.Current.Session("BranchCode")
        aParms(3) = New SqlParameter("@Project_id", SqlDbType.VarChar, 50)
        aParms(3).Value = EL.Properties
        aParms(4) = New SqlParameter("@Lot_Number", SqlDbType.VarChar, 50)
        aParms(4).Value = EL.Lot_Number
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "PropertyDetails", aParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal EL As ELProperty) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim aParms() As SqlParameter = New SqlParameter(11) {}
        Dim rowsAffected As Integer = 0

        aParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        aParms(0).Value = EL.ID
        aParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        aParms(1).Value = HttpContext.Current.Session("Office")
        aParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        aParms(2).Value = HttpContext.Current.Session("BranchCode")
        aParms(3) = New SqlParameter("@Lot_Number", SqlDbType.VarChar, 50)
        aParms(3).Value = EL.Lot_Number
        aParms(4) = New SqlParameter("@SaleDate", SqlDbType.DateTime)
        aParms(4).Value = EL.SaleDate
        aParms(5) = New SqlParameter("@Properties", SqlDbType.VarChar, 50)
        aParms(5).Value = EL.Properties
        aParms(6) = New SqlParameter("@NoofUnits", SqlDbType.VarChar, 50)
        aParms(6).Value = EL.NoofUnits
        aParms(7) = New SqlParameter("@Avg_price ", SqlDbType.Money, 50)
        aParms(7).Value = EL.Avg_price
        aParms(8) = New SqlParameter("@LotStatus ", SqlDbType.VarChar, 50)
        aParms(8).Value = EL.LotStatus

        aParms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        aParms(9).Value = HttpContext.Current.Session("UserCode")
        aParms(10) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        aParms(10).Value = HttpContext.Current.Session("Empcode")
        aParms(11) = New SqlParameter("@Location ", SqlDbType.VarChar, 50)
        aParms(11).Value = EL.Location
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_UpdateProperty", aParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Delete(ByVal EL As ELProperty) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim RowsEffected As Integer
        Dim aParms() As SqlParameter = New SqlParameter(0) {}
        aParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        aParms(0).Value = EL.ID
        'aParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        'aParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            RowsEffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_DeleteQuery", aParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return RowsEffected
    End Function
    Shared Function CheckDuplicate(ByVal EL As ELProperty) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim aParms() As SqlParameter = New SqlParameter(2) {}
        aParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        aParms(0).Value = EL.ID
        aParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        aParms(1).Value = HttpContext.Current.Session("BranchCode")
        aParms(2) = New SqlParameter("@Lot_Number", SqlDbType.VarChar, 50)
        aParms(2).Value = EL.Lot_Number
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetDuplicate", aParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DDlData() As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "DDlDataSet")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

End Class
