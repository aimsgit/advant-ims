Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class VehicleDB

    Shared Function GetVehicle(ByVal v As VehicleDetails) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@VehicleID", SqlDbType.Int)
        arParms(2).Value = v.VehicleID

        arParms(3) = New SqlParameter("@Ownership_Status", SqlDbType.VarChar, 50)
        arParms(3).Value = v.OwnerShipStatus

        arParms(4) = New SqlParameter("@RegNo", SqlDbType.VarChar, 50)
        arParms(4).Value = v.VehicleRegistrationnNo

        arParms(5) = New SqlParameter("@VehicleType", SqlDbType.VarChar, 50)
        arParms(5).Value = v.VehicleType

        arParms(6) = New SqlParameter("@VihicleMake", SqlDbType.VarChar, 50)
        arParms(6).Value = v.VehicleMake


        arParms(7) = New SqlParameter("@FuelType", SqlDbType.VarChar, 50)
        arParms(7).Value = v.FuelType

        Dim ds As New DataSet

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetVehicleDetails", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal v As VehicleDetails) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(25) {}

        arParms(0) = New SqlParameter("@VehicleRegNum", SqlDbType.VarChar, 50)
        arParms(0).Value = v.VehicleRegistrationnNo

        arParms(1) = New SqlParameter("@YearRegistration", SqlDbType.DateTime)
        arParms(1).Value = v.YearRegistrationnNo

        arParms(2) = New SqlParameter("@VehicleType", SqlDbType.VarChar, 50)
        arParms(2).Value = v.VehicleType

        arParms(3) = New SqlParameter("@VehicleMake", SqlDbType.VarChar, 50)
        arParms(3).Value = v.VehicleMake

        arParms(4) = New SqlParameter("@MakeYear", SqlDbType.Int)
        arParms(4).Value = v.MakeYear

        arParms(5) = New SqlParameter("@ModelNumber", SqlDbType.VarChar, 50)
        arParms(5).Value = v.Model

        arParms(6) = New SqlParameter("@EngineNum", SqlDbType.VarChar, 50)
        arParms(6).Value = v.EngineNumber

        arParms(7) = New SqlParameter("@ChassisNo", SqlDbType.VarChar, 50)
        arParms(7).Value = v.CharsyNo

        arParms(8) = New SqlParameter("@NoOfSeats", SqlDbType.VarChar, 10)
        arParms(8).Value = v.NoOfSeats

        arParms(9) = New SqlParameter("@FuelType", SqlDbType.NVarChar, 50)
        arParms(9).Value = v.FuelType

        arParms(10) = New SqlParameter("@InsuranceComp_name", SqlDbType.NVarChar, 50)
        arParms(10).Value = v.InsuranceCompanyname

        arParms(11) = New SqlParameter("@InsuranceContact_No", SqlDbType.NVarChar, 50)
        arParms(11).Value = v.InsuranceContactNo

        arParms(12) = New SqlParameter("@PolicyNo", SqlDbType.NVarChar, 50)
        arParms(12).Value = v.PolicyNo

        If v.InsuranceExpiry = ("1/1/1900") Then
            arParms(13) = New SqlParameter("@InsuranceExpiry", SqlDbType.DateTime)
            arParms(13).Value = DBNull.Value
        Else
            arParms(13) = New SqlParameter("@InsuranceExpiry", SqlDbType.DateTime)
            arParms(13).Value = v.InsuranceExpiry
        End If

        If v.RenewalOfPermit = ("1/1/1900") Then
            arParms(14) = New SqlParameter("@RenewalOfPermit", SqlDbType.DateTime)
            arParms(14).Value = DBNull.Value
        Else
            arParms(14) = New SqlParameter("@RenewalOfPermit", SqlDbType.DateTime)
            arParms(14).Value = v.RenewalOfPermit
        End If

        arParms(15) = New SqlParameter("@PurchasePrice", SqlDbType.Money)
        arParms(15).Value = v.Price

        arParms(16) = New SqlParameter("@Ownership_Status", SqlDbType.NVarChar, 50)
        arParms(16).Value = v.OwnerShipStatus


        arParms(17) = New SqlParameter("@ContractorName", SqlDbType.NVarChar, 50)
        arParms(17).Value = v.ContratorName

        arParms(18) = New SqlParameter("@ContactNo", SqlDbType.NVarChar, 50)
        arParms(18).Value = v.contactNumber

        arParms(19) = New SqlParameter("@Address", SqlDbType.NVarChar, 250)
        arParms(19).Value = v.Address


        If v.StartDate = ("1/1/1900") Then
            arParms(20) = New SqlParameter("@StartDate", SqlDbType.DateTime)
            arParms(20).Value = DBNull.Value
        Else
            arParms(20) = New SqlParameter("@StartDate", SqlDbType.DateTime)
            arParms(20).Value = v.StartDate
        End If
        

        If v.EndDate = ("1/1/1900") Then
            arParms(21) = New SqlParameter("@EndDate", SqlDbType.DateTime)
            arParms(21).Value = DBNull.Value
        Else
            arParms(21) = New SqlParameter("@EndDate", SqlDbType.DateTime)
            arParms(21).Value = v.EndDate

        End If
      
        arParms(22) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(22).Value = HttpContext.Current.Session("BranchCode")

        arParms(23) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(23).Value = HttpContext.Current.Session("UserCode")

        arParms(24) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(24).Value = HttpContext.Current.Session("EmpCode")

        arParms(25) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(25).Value = HttpContext.Current.Session("Office")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveVehicleDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function Update(ByVal v As VehicleDetails) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(25) {}

        arParms(0) = New SqlParameter("@VehicleRegNum", SqlDbType.VarChar, 50)
        arParms(0).Value = v.VehicleRegistrationnNo

        arParms(1) = New SqlParameter("@YearRegistration", SqlDbType.DateTime)
        arParms(1).Value = v.YearRegistrationnNo

        arParms(2) = New SqlParameter("@VehicleType", SqlDbType.VarChar, 50)
        arParms(2).Value = v.VehicleType

        arParms(3) = New SqlParameter("@VehicleMake", SqlDbType.VarChar, 50)
        arParms(3).Value = v.VehicleMake

        arParms(4) = New SqlParameter("@MakeYear", SqlDbType.Int)
        arParms(4).Value = v.MakeYear

        arParms(5) = New SqlParameter("@ModelNumber", SqlDbType.VarChar, 50)
        arParms(5).Value = v.Model

        arParms(6) = New SqlParameter("@EngineNum", SqlDbType.VarChar, 50)
        arParms(6).Value = v.EngineNumber

        arParms(7) = New SqlParameter("@ChassisNo", SqlDbType.VarChar, 50)
        arParms(7).Value = v.CharsyNo

        arParms(8) = New SqlParameter("@NoOfSeats", SqlDbType.VarChar, 10)
        arParms(8).Value = v.NoOfSeats

        arParms(9) = New SqlParameter("@FuelType", SqlDbType.NVarChar, 50)
        arParms(9).Value = v.FuelType

        arParms(10) = New SqlParameter("@InsuranceComp_name", SqlDbType.NVarChar, 50)
        arParms(10).Value = v.InsuranceCompanyname

        arParms(11) = New SqlParameter("@InsuranceContact_No", SqlDbType.NVarChar, 50)
        arParms(11).Value = v.InsuranceContactNo

        arParms(12) = New SqlParameter("@PolicyNo", SqlDbType.NVarChar, 50)
        arParms(12).Value = v.PolicyNo

        If v.InsuranceExpiry = ("1/1/1900") Then
            arParms(13) = New SqlParameter("@InsuranceExpiry", SqlDbType.DateTime)
            arParms(13).Value = DBNull.Value
        Else
            arParms(13) = New SqlParameter("@InsuranceExpiry", SqlDbType.DateTime)
            arParms(13).Value = v.InsuranceExpiry
        End If


        If v.RenewalOfPermit = ("1/1/1900") Then
            arParms(14) = New SqlParameter("@RenewalOfPermit", SqlDbType.DateTime)
            arParms(14).Value = DBNull.Value
        Else
            arParms(14) = New SqlParameter("@RenewalOfPermit", SqlDbType.DateTime)
            arParms(14).Value = v.RenewalOfPermit
        End If


        arParms(15) = New SqlParameter("@PurchasePrice", SqlDbType.Money)
        arParms(15).Value = v.Price

        arParms(16) = New SqlParameter("@Ownership_Status", SqlDbType.NVarChar, 50)
        arParms(16).Value = v.OwnerShipStatus

        arParms(17) = New SqlParameter("@ContractorName", SqlDbType.NVarChar, 50)
        arParms(17).Value = v.ContratorName

        arParms(18) = New SqlParameter("@ContactNo", SqlDbType.NVarChar, 50)
        arParms(18).Value = v.contactNumber

        arParms(19) = New SqlParameter("@Address", SqlDbType.NVarChar, 250)
        arParms(19).Value = v.Address

        If v.StartDate = ("1/1/1900") Then
            arParms(20) = New SqlParameter("@StartDate", SqlDbType.DateTime)
            arParms(20).Value = DBNull.Value
        Else
            arParms(20) = New SqlParameter("@StartDate", SqlDbType.DateTime)
            arParms(20).Value = v.StartDate
        End If

        If v.EndDate = ("1/1/1900") Then
            arParms(21) = New SqlParameter("@EndDate", SqlDbType.DateTime)
            arParms(21).Value = DBNull.Value
        Else
            arParms(21) = New SqlParameter("@EndDate", SqlDbType.DateTime)
            arParms(21).Value = v.EndDate
        End If

        arParms(22) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(22).Value = HttpContext.Current.Session("BranchCode")

        arParms(23) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(23).Value = HttpContext.Current.Session("UserCode")

        arParms(24) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(24).Value = HttpContext.Current.Session("EmpCode")

        arParms(25) = New SqlParameter("@VehicleId", SqlDbType.Int)
        arParms(25).Value = v.VehicleID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateVehicleDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal v As VehicleDetails) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@VehicleId", SqlDbType.Int)
        arParms(0).Value = v.VehicleID

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteVehicleDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function VehicleDuplicateEntry(ByVal v As VehicleDetails) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}

        para(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("office")

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@VehicleRegnNo", SqlDbType.VarChar, 50)
        para(2).Value = v.VehicleRegistrationnNo
        para(3) = New SqlParameter("@id", SqlDbType.Int)
        para(3).Value = v.VehicleID


        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDuplicateVehicleDetails", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetOwnVehicleDetails(ByVal id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = id

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetOwnVehicleDetails", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetContractVehicleDetails(ByVal id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = id

        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetContractVehicleDetails", arParms)
        Return ds.Tables(0)
    End Function
    Public Function RptVehicleDetails(ByVal vid As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@office", SqlDbType.Varchar, 50)
        arParms(1).Value = HttpContext.Current.Session("office")

        arParms(2) = New SqlParameter("@VehicleID", SqlDbType.Int)
        arParms(2).Value = 0

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_VehicleDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    'Shared Function GetVehicleDetails(ByVal Inst As Int64, ByVal Brch As Int64, ByVal vehicleid As Integer, ByVal RB As Integer) As Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim arParms() As SqlParameter = New SqlParameter(3) {}

    '    arParms(0) = New SqlParameter("@instituteid", SqlDbType.Int)
    '    arParms(0).Value = Inst

    '    arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
    '    arParms(1).Value = Brch

    '    arParms(2) = New SqlParameter("@vehicleid", SqlDbType.Int)
    '    arParms(2).Value = vehicleid

    '    arParms(3) = New SqlParameter("@RB", SqlDbType.Bit)
    '    arParms(3).Value = vehicleid
    '    Dim ds As New DataSet
    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetVehicleDetails", arParms)
    '    Return ds.Tables(0)
    'End Function

End Class
