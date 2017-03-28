Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class ProspectusDB
    Shared Function GetProspectus(ByVal prospectusid As Long, ByVal Inst As Int64, ByVal branch As Int64) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        If prospectusid = 0 Then
            Dim arParms() As SqlParameter = New SqlParameter(0) {}
            
            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = branch

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetProspectusDetailsByInstBrch", arParms)

        ElseIf (prospectusid <> 0) Then

            Dim arParms As SqlParameter = New SqlParameter("@prospectusid", SqlDbType.Int, 10)
            arParms.Value = prospectusid
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetProspectusDetailsByID", arParms)

        Else
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetProspectusDetails")
        End If
        Return ds
    End Function
    Shared Function DispGrid(ByVal id As Long, ByVal RadioButtonSelection As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = id

        arParms(3) = New SqlParameter("@RadioButtonSelection", SqlDbType.VarChar)
        arParms(3).Value = RadioButtonSelection

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ProspDisplayGrid", arParms)
            Return ds.Tables(0)

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Shared Function Insert(ByVal p As Prospectus) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}


        arParms(0) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@entrydate", SqlDbType.DateTime)
        arParms(1).Value = p.Entrydate

        arParms(2) = New SqlParameter("@serialno", SqlDbType.NVarChar, p.SerialNo.Length)
        arParms(2).Value = p.SerialNo

        arParms(3) = New SqlParameter("@price", SqlDbType.Int)
        arParms(3).Value = p.Price

        arParms(4) = New SqlParameter("@remarks", SqlDbType.NVarChar, p.Remarks.Length)
        arParms(4).Value = p.Remarks

        arParms(5) = New SqlParameter("@name", SqlDbType.NVarChar, p.Name.Length)
        arParms(5).Value = p.Name

        arParms(6) = New SqlParameter("@receiptno", SqlDbType.NVarChar, p.PreceiptNO.Length)
        arParms(6).Value = p.PreceiptNO

        arParms(7) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")

        If p.ProspectusStatus = "S" Or p.ProspectusStatus = "C" Then
            arParms(9) = New SqlParameter("@Qty_Out", SqlDbType.Int)
            arParms(9).Value = p.Quantity

            arParms(10) = New SqlParameter("@Qty_In", SqlDbType.Int)
            arParms(10).Value = 0
        Else
            arParms(9) = New SqlParameter("@Qty_Out", SqlDbType.Int)
            arParms(9).Value = 0

            arParms(10) = New SqlParameter("@Qty_In", SqlDbType.Int)
            arParms(10).Value = p.Quantity
        End If
        arParms(11) = New SqlParameter("@ProspectusType", SqlDbType.VarChar, 2)
        arParms(11).Value = p.ProspectusStatus
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveProspectusDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal p As Prospectus) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(12) {}

        arParms(0) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@entrydate", SqlDbType.DateTime)
        arParms(1).Value = p.Entrydate

        arParms(2) = New SqlParameter("@serialno", SqlDbType.NVarChar, p.SerialNo.Length)
        arParms(2).Value = p.SerialNo

        arParms(3) = New SqlParameter("@price", SqlDbType.Int)
        arParms(3).Value = p.Price

        arParms(4) = New SqlParameter("@remarks", SqlDbType.NVarChar, p.Remarks.Length)
        arParms(4).Value = p.Remarks

        arParms(5) = New SqlParameter("@name", SqlDbType.NVarChar, p.Name.Length)
        arParms(5).Value = p.Name

        arParms(6) = New SqlParameter("@receiptno", SqlDbType.NVarChar, p.PreceiptNO.Length)
        arParms(6).Value = p.PreceiptNO

        arParms(7) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")

        If p.ProspectusStatus = "S" Or p.ProspectusStatus = "C" Then
            arParms(9) = New SqlParameter("@Qty_Out", SqlDbType.Int)
            arParms(9).Value = p.Quantity

            arParms(10) = New SqlParameter("@Qty_In", SqlDbType.Int)
            arParms(10).Value = 0
        Else
            arParms(9) = New SqlParameter("@Qty_Out", SqlDbType.Int)
            arParms(9).Value = 0

            arParms(10) = New SqlParameter("@Qty_In", SqlDbType.Int)
            arParms(10).Value = p.Quantity
        End If
        arParms(11) = New SqlParameter("@ProspectusType", SqlDbType.VarChar, 2)
        arParms(11).Value = p.ProspectusStatus

        arParms(12) = New SqlParameter("@id", SqlDbType.Int)
        arParms(12).Value = p.Id

       

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateProspectusDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
       
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = Id
        arParms(1) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteProspectusDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function EnqEditData(ByVal id As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id
        arParms(1) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_EnquiryEditByProsp", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function ProspID(ByVal id As Int64, ByVal brch As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id

        'arParms(1) = New SqlParameter("@inst", SqlDbType.Int)
        'arParms(1).Value = inst

        arParms(1) = New SqlParameter("@brch", SqlDbType.Int)
        arParms(1).Value = brch

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetProspID", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function UpdateEnq(ByVal SlNo As Int64, ByVal Inst As Int64, ByVal Brch As Int64) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@slno", SqlDbType.Int)
        arParms(0).Value = SlNo

        arParms(1) = New SqlParameter("@instid", SqlDbType.Int)
        arParms(1).Value = Inst


        arParms(2) = New SqlParameter("@brchid", SqlDbType.Int)
        arParms(2).Value = Brch

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_GetEnqID", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DeleteProsp(ByVal Id As Long) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteProspByEnqID", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetEidfmProsp(ByVal id As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEnqByProsp", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function ProspBal() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ProspBalance", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetReport() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@off", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@bcode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ProspectusReport", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function RptCompPros(ByVal inst As Int64, ByVal bran As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@inst", SqlDbType.Int)
        arParms(0).Value = inst

        arParms(1) = New SqlParameter("@bran", SqlDbType.Int)
        arParms(1).Value = bran

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptCompPros", arParms)
        Return ds.Tables(0)
    End Function

    'Code For Duplicate Value Check  By Nitin 30/07/2012
    Shared Function GetDuplicateProspectus(ByVal p As Prospectus) As Data.DataTable
        Dim connection As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim ds As DataSet
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@ProspectusNo", SqlDbType.VarChar, 50)
        para(1).Value = p.SerialNo

        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = p.Id

        ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "[Proc_GetDuplicateProspectus]", para)
        Return ds.tables(0)
    End Function
End Class
