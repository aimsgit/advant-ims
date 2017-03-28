Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
'Namespace GlobalDataSetTableAdapters
'Partial Public Class Machine_MaintenanceTableAdapter
Public Class MachineMaintenanceDB
    'Dim newidd As Integer
    'Public Function GetMachineMaintenence(ByVal maintainid As Long) As System.Data.DataSet
    Shared Function GetMachineMaintenence(ByVal maintainid As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        If maintainid = 0 Then
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT * FROM View_GetMachineMaintenence")
        Else
            Dim arParms As SqlParameter = New SqlParameter("@maintainid", SqlDbType.Int)
            arParms.Value = maintainid
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMachineMaintenenceById", arParms)
        End If
        Return ds
    End Function
    Shared Function Insert(ByVal mm As MachineMaintenence) As Integer
        'Public Function Insert(ByVal mm As MachineMaintenence) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(19) {}

        arParms(0) = New SqlParameter("@entrydate", SqlDbType.DateTime)
        arParms(0).Value = mm.EntryDate

        arParms(1) = New SqlParameter("@machinemake", SqlDbType.Int)
        arParms(1).Value = mm.MachineMake

        arParms(2) = New SqlParameter("@machinemodel", SqlDbType.Char, mm.MachineModel.Length)
        arParms(2).Value = mm.MachineModel

        arParms(3) = New SqlParameter("@machineno", SqlDbType.Char, mm.MachineNo.Length)
        arParms(3).Value = mm.MachineNo

        arParms(4) = New SqlParameter("@machinetype", SqlDbType.Int)
        arParms(4).Value = mm.MachineType

        arParms(5) = New SqlParameter("@Maintenencetype", SqlDbType.Int)
        arParms(5).Value = mm.MaintenenceType

        arParms(6) = New SqlParameter("@cleaneddate", SqlDbType.DateTime)
        arParms(6).Value = mm.CleanedDate

        arParms(7) = New SqlParameter("@duedate", SqlDbType.DateTime)
        arParms(7).Value = mm.DueDate

        arParms(8) = New SqlParameter("@timestopped", SqlDbType.Char, mm.TimeStopped.Length)
        arParms(8).Value = mm.TimeStopped

        arParms(9) = New SqlParameter("@partchanged", SqlDbType.Char, mm.PartChanged.Length)
        arParms(9).Value = mm.PartChanged

        arParms(10) = New SqlParameter("@timerun", SqlDbType.Char, mm.TimeRun.Length)
        arParms(10).Value = mm.TimeRun

        arParms(11) = New SqlParameter("@operation", SqlDbType.Char, mm.Operation.Length)
        arParms(11).Value = mm.Operation

        arParms(12) = New SqlParameter("@operationname", SqlDbType.Char, mm.OperationName.Length)
        arParms(12).Value = mm.OperationName

        arParms(13) = New SqlParameter("@needle", SqlDbType.Char, mm.Needle.Length)
        arParms(13).Value = mm.Needle

        arParms(14) = New SqlParameter("@parts", SqlDbType.Char, mm.Parts.Length)
        arParms(14).Value = mm.Parts

        arParms(15) = New SqlParameter("@courseid", SqlDbType.Int)
        arParms(15).Value = mm.CourseId

        arParms(16) = New SqlParameter("@batchno", SqlDbType.Char, mm.BatchNo.Length)
        arParms(16).Value = mm.BatchNo

        arParms(17) = New SqlParameter("@remarks", SqlDbType.Char, mm.Remarks.Length)
        arParms(17).Value = mm.Remarks

        arParms(18) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(18).Value = HttpContext.Current.Session("Office")

        arParms(19) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
        arParms(19).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveMachineMaintenence", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    ''Public Function InsertRecord_Details(ByVal Maintain_ID As Int32, ByVal Entry_Date As Date, ByVal Machine_Make As Int32, ByVal Institute_Id As Int32, ByVal Supp_Id As Int32, ByVal ManuFacturer_Id As Int32, ByVal InvoiceNo As String, ByVal PurchaseDate As Date, ByVal EntryDate As Date, ByVal Quantity As Double, ByVal Price As Double, ByVal Model_Number As String, ByVal Brought_by As String, ByVal AmtPaid As Int32, ByVal BillType As String, ByVal PaymentMethod_Id As Int32, ByVal Total_Value As Int32, ByVal Serial_No As String, ByVal Description As String, ByVal Location As String) As Integer
    'Public Function InsertRecord_Details(ByVal Entry_Date As Date, ByVal Machine_Make As Int32, ByVal Machine_Model As String, ByVal Machine_No As String, ByVal MachineType As Int32, ByVal MaintenanceType As Int32, ByVal Cleaned_Date As Date, ByVal Due_Date As Date, ByVal Time_Stopped As String, ByVal Part_Changed As String, ByVal Time_Run As String, ByVal Operation As String, ByVal Operator_Name As String, ByVal Needle As String, ByVal Remarks As String, ByVal Course_ID As Integer, ByVal Batch_No As String, ByVal Parts As String, ByVal Institute_ID As Integer, ByVal Branch_ID As Integer) As Integer
    '    Dim MM As New GlobalDataSet.Machine_MaintenanceDataTable
    '    Dim newdetails As GlobalDataSet.Machine_MaintenanceRow = MM.NewMachine_MaintenanceRow()
    '    newdetails.Entry_Date = Entry_Date
    '    newdetails.Machine_Make = Machine_Make
    '    newdetails.Machine_Model = Machine_Model
    '    newdetails.Machine_No = Machine_No
    '    newdetails.MachineType = MachineType
    '    newdetails.MaintenanceType = MaintenanceType
    '    newdetails.Cleaned_Date = Cleaned_Date
    '    newdetails.Due_Date = Due_Date
    '    newdetails.Time_Stopped = Time_Stopped
    '    newdetails.Part_Changed = Part_Changed
    '    newdetails.Time_Run = Time_Run
    '    newdetails.Operation = Operation
    '    newdetails.Operator_Name = Operator_Name
    '    newdetails.Needle = Needle
    '    newdetails.Parts = Parts
    '    newdetails.Remarks = Remarks
    '    newdetails.Course_ID = Course_ID
    '    newdetails.Batch_No = Batch_No
    '    newdetails.Institute_ID = Institute_ID
    '    newdetails.Branch_ID = Branch_ID
    '    MM.AddMachine_MaintenanceRow(newdetails)
    '    Me.Adapter.Update(MM)
    '    Return newidd
    'End Function
    Shared Function ChangeFlag(ByVal maintainid As Long) As Integer
        'Public Function ChangeFlag(ByVal maintainid As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@maintainid", SqlDbType.Int)
        arParms(0).Value = maintainid

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteMachineMaintenence", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetMachinMaintenenceByIBMf(ByVal mfr As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@machinemake", SqlDbType.Int)
        arParms(0).Value = mfr

        arParms(1) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMachinMaintenenceBy_IBMf", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetMachinMaintnceByIBMfMt(ByVal mct As Int64, ByVal mfr As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@machinetype", SqlDbType.Int)
        arParms(0).Value = mct

        arParms(1) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@machinemake", SqlDbType.Int)
        arParms(3).Value = mfr

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMachinMaintnceBy_IBMfMt", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetMaintnceManufByIB() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMaintnceManufBy_IB", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function MachineMaintenenceGridFill(ByVal mnt As Int64, ByVal id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Maintenencetype", SqlDbType.Int)
        arParms(2).Value = mnt

        arParms(3) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(3).Value = id

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_MachnMaintenanceGridFil", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetRPT_MachineMaintenence(ByVal ins As Int64, ByVal brn As Int64, ByVal mnt As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@instituteid", SqlDbType.Int)
        arParms(0).Value = ins

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
        arParms(1).Value = brn

        arParms(2) = New SqlParameter("@Maintenencetype", SqlDbType.Int)
        arParms(2).Value = mnt

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_RPT_MachnMaintenanceDtls]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function DispGV_MaintenanceRPT(ByVal ins As Int64, ByVal brn As Int64, ByVal mnt As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@instituteid", SqlDbType.Int)
        arParms(0).Value = ins

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
        arParms(1).Value = brn

        arParms(2) = New SqlParameter("@Maintenencetype", SqlDbType.Int)
        arParms(2).Value = mnt

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDataByMachinMataincReport", arParms)
        Return ds.Tables(0)
    End Function
End Class
'End Namespace