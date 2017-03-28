Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class VehicleMaintenanceDB
    Shared Function GetVehicleMaintainRpt(ByVal Inst As Int64, ByVal Brch As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@instituteid", SqlDbType.Int)
        arParms(0).Value = Inst
        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
        arParms(1).Value = Brch
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_RptVehicleMaintainance]", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function Insert(ByVal v As VehicleMaintenanceEn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@AssetId", SqlDbType.Int)
        arParms(0).Value = v.AssetId

        arParms(1) = New SqlParameter("@Amount", SqlDbType.Money)
        arParms(1).Value = v.Amount

        arParms(2) = New SqlParameter("@ServiceDetail", SqlDbType.NVarChar, 150)
        arParms(2).Value = v.ServiceDetails

        arParms(3) = New SqlParameter("@Service_Date", SqlDbType.DateTime)
        arParms(3).Value = v.ServiceDate

        If v.NextServiceDate = "1/1/1900" Then
            arParms(4) = New SqlParameter("@NextServiceDate", SqlDbType.DateTime)
            arParms(4).Value = DBNull.Value
        Else
            arParms(4) = New SqlParameter("@NextServiceDate", SqlDbType.DateTime)
            arParms(4).Value = v.NextServiceDate
        End If

        arParms(5) = New SqlParameter("@remarks", SqlDbType.NVarChar, 250)
        arParms(5).Value = v.Remarks

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")

        arParms(9) = New SqlParameter("@AssetTypeId", SqlDbType.Int)
        arParms(9).Value = v.AssetTypeId

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveVehicleMaintenance", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function Update(ByVal v As VehicleMaintenanceEn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(10) {}


        arParms(0) = New SqlParameter("@AssetId", SqlDbType.Int)
        arParms(0).Value = v.AssetId

        arParms(1) = New SqlParameter("@amount", SqlDbType.Money)
        arParms(1).Value = v.Amount

        arParms(2) = New SqlParameter("@servicedet", SqlDbType.NVarChar, 150)
        arParms(2).Value = v.ServiceDetails

        arParms(3) = New SqlParameter("@servicedate", SqlDbType.DateTime)
        arParms(3).Value = v.ServiceDate

        If v.NextServiceDate = "1/1/1900" Then
            arParms(4) = New SqlParameter("@nxtservicedate", SqlDbType.DateTime)
            arParms(4).Value = DBNull.Value
        Else
            arParms(4) = New SqlParameter("@nxtservicedate", SqlDbType.DateTime)
            arParms(4).Value = v.NextServiceDate
        End If


        arParms(5) = New SqlParameter("@remarks", SqlDbType.NVarChar, 250)
        arParms(5).Value = v.Remarks


        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("Office")

        arParms(8) = New SqlParameter("@vehicleno", SqlDbType.Int)
        arParms(8).Value = HttpContext.Current.Session("VehNo")

        arParms(9) = New SqlParameter("@vmid", SqlDbType.Int)
        arParms(9).Value = Convert.ToInt32(HttpContext.Current.Session("VMID"))

        arParms(10) = New SqlParameter("@AssetTypeId", SqlDbType.Int)
        arParms(10).Value = v.AssetTypeId

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateVehicleMaintenance1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update1(ByVal v As VehicleMaintenanceEn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(10) {}


        arParms(0) = New SqlParameter("@AssetId", SqlDbType.Int)
        arParms(0).Value = v.AssetId

        arParms(1) = New SqlParameter("@Amount", SqlDbType.Money)
        arParms(1).Value = v.Amount

        arParms(2) = New SqlParameter("@ServiceDetail", SqlDbType.NVarChar, 150)
        arParms(2).Value = v.ServiceDetails

        arParms(3) = New SqlParameter("@Service_Date", SqlDbType.DateTime)
        arParms(3).Value = v.ServiceDate
        'arParms(4) = New SqlParameter("@NextServiceDate", SqlDbType.DateTime)
        'arParms(4).Value = v.NextServiceDate
        If v.NextServiceDate = "1/1/1900" Then
            arParms(4) = New SqlParameter("@NextServiceDate", SqlDbType.DateTime)
            arParms(4).Value = DBNull.Value
        Else
            arParms(4) = New SqlParameter("@NextServiceDate", SqlDbType.DateTime)
            arParms(4).Value = v.NextServiceDate
        End If

        arParms(5) = New SqlParameter("@remarks", SqlDbType.NVarChar)
        arParms(5).Value = v.Remarks

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")



        arParms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")

        arParms(9) = New SqlParameter("@VMID", SqlDbType.Int)
        arParms(9).Value = v.VMID

        arParms(10) = New SqlParameter("@AssetTypeId", SqlDbType.Int)
        arParms(10).Value = v.AssetTypeId


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateVehicleMaintenance1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function GetVehicleDetails(ByVal Inst As Integer, ByVal Branch As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetVehicleDetExt", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function DispVehicleDB(ByVal VehicleMaintenanceEn As VehicleMaintenanceEn) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlClient.SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = VehicleMaintenanceEn.VMID

        arParms(3) = New SqlParameter("@AssetId", SqlDbType.Int)
        arParms(3).Value = VehicleMaintenanceEn.AssetId

        arParms(4) = New SqlClient.SqlParameter("@ServiceDate", SqlDbType.DateTime)
        arParms(4).Value = VehicleMaintenanceEn.ServiceDate

        arParms(5) = New SqlParameter("@AssetTypeId", SqlDbType.Int)
        arParms(5).Value = VehicleMaintenanceEn.AssetTypeId

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetVehicleDet", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function vechileduplicate(ByVal v As VehicleMaintenanceEn) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@VehicleID", SqlDbType.Int)
        arParms(0).Value = v.VehicleNo

        arParms(1) = New SqlParameter("@ServiceDetail", SqlDbType.NVarChar)
        arParms(1).Value = v.ServiceDetails

        arParms(2) = New SqlParameter("@Service_Date", SqlDbType.DateTime)
        arParms(2).Value = v.ServiceDate

        arParms(3) = New SqlParameter("@NextServiceDate", SqlDbType.DateTime)
        arParms(3).Value = v.NextServiceDate


        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

      

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_DuplicateVechileMaintenance", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


    Shared Function DispAllVehicleDB(ByVal Inst As Integer, ByVal Branch As Integer) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAllVehicleDet", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function DeleteVehicleDB(ByVal v As VehicleMaintenanceEn) As Integer
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

       

        arParms(0) = New SqlClient.SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = v.VMID

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        'arParms(3) = New SqlParameter("@vmid", SqlDbType.Int)
        'arParms(3).Value = Convert.ToInt32(HttpContext.Current.Session("VMIDDel"))

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteVehicleMaintenance", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    'Code For To Get Vehicle Maintenance Details by Nitin 12/05/2012
    Shared Function GetVehicleMaintenanceDetailsRpt() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptVehicleMaintenanceDetails", arParms)
        Return ds.Tables(0)
    End Function


End Class
