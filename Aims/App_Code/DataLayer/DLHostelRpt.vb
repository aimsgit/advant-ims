Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLHostelRpt

    Shared Function GetRoomTypeMasterReport() As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_RoomType", para)
        Return ds.Tables(0)

    End Function

    Shared Function GetHostelMasterReport() As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_Hostelmaster", para)
        Return ds.Tables(0)

    End Function
    Shared Function GetHostelName() As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_HostelRoomDetailsCombo", para)
        Return ds.Tables(0)

    End Function

    Shared Function GetHostelRoomDetailsRpt(ByVal branchcode As String, ByVal Hid As Integer, ByVal Rid As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}

        para(0) = New SqlParameter("@Hid", SqlDbType.Int)
        para(0).Value = Hid

        para(1) = New SqlParameter("@Rid", SqlDbType.Int)
        para(1).Value = Rid

        para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(2).Value = branchcode

        para(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_HostelRoommaster", para)
        Return ds.Tables(0)

    End Function
    Public Function RoomTypeCombo(ByVal Hid As Integer, ByVal BranchCode As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@HID", SqlDbType.Int)
        param(0).Value = Hid
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = BranchCode
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Hostel_RoomTypeComboRpt", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function


    Shared Function GetHostelAdmissionDetailsRpt(ByVal Hid As Integer, ByVal Rid As Integer, ByVal Status As Integer, ByVal Frmdate As Date, ByVal Todate As Date, ByVal BranchCode As String) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim para() As SqlParameter = New SqlParameter(6) {}

        para(0) = New SqlParameter("@Hid", SqlDbType.Int)
        para(0).Value = Hid

        para(1) = New SqlParameter("@Rid", SqlDbType.Int)
        para(1).Value = Rid

        para(2) = New SqlParameter("@Status", SqlDbType.Int)
        para(2).Value = Status

        para(3) = New SqlParameter("@FrmDate", SqlDbType.Date)
        para(3).Value = Frmdate

        para(4) = New SqlParameter("@ToDate", SqlDbType.Date)
        para(4).Value = Todate

        para(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(5).Value = BranchCode

        para(6) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(6).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_HostelAdmission", para)
        Return ds.Tables(0)

    End Function
End Class
