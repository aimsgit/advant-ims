Imports Microsoft.VisualBasic

Public Class PayDB
    Public Function GVComboLeave() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getLeaveType")
        Return ds.Tables(0)
    End Function
    Shared Function GetDetails(ByVal id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim dataset As New DataSet
        Try
            If id = 0 Then
                Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
                arParms(0) = New SqlClient.SqlParameter("@institute", SqlDbType.Int)
                arParms(0).Value = HttpContext.Current.Session("InstituteID")
                arParms(1) = New SqlClient.SqlParameter("@branch", SqlDbType.Int)
                arParms(1).Value = HttpContext.Current.Session("BranchID")
                dataset = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetLeaveRegisterDetails", arParms)
            Else
                Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
                arParms(0) = New SqlClient.SqlParameter("@id", SqlDbType.Int)
                arParms(0).Value = id
                arParms(1) = New SqlClient.SqlParameter("@institute", SqlDbType.Int)
                arParms(1).Value = HttpContext.Current.Session("InstituteID")
                arParms(2) = New SqlClient.SqlParameter("@branch", SqlDbType.Int)
                arParms(2).Value = HttpContext.Current.Session("BranchID")
                dataset = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetLeaveRegisterDetailsByID", arParms)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return dataset
    End Function

    Shared Function Insert(ByVal l As Pay) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(9) {}

        arParms(0) = New SqlClient.SqlParameter("@eid", SqlDbType.Int)
        arParms(0).Value = l.EId

        arParms(1) = New SqlClient.SqlParameter("@leavefrom", SqlDbType.DateTime)
        arParms(1).Value = l.Leavefrom

        arParms(2) = New SqlClient.SqlParameter("@leaveto", SqlDbType.DateTime)
        arParms(2).Value = l.Leaveto

        arParms(3) = New SqlClient.SqlParameter("@leavetype", SqlDbType.Int)
        arParms(3).Value = l.Leavetype

        arParms(4) = New SqlClient.SqlParameter("@approved", SqlDbType.Bit)
        arParms(4).Value = l.Approved

        arParms(5) = New SqlClient.SqlParameter("@approvedby", SqlDbType.VarChar, 50)
        arParms(5).Value = l.Approvedby

        arParms(6) = New SqlClient.SqlParameter("@Remark", SqlDbType.VarChar, 50)
        arParms(6).Value = l.Remark

        arParms(7) = New SqlClient.SqlParameter("@LossOfPayAmt", SqlDbType.Float)
        arParms(7).Value = l.LossOfPayAmt

        arParms(8) = New SqlClient.SqlParameter("@institute", SqlDbType.Int)
        arParms(8).Value = HttpContext.Current.Session("InstituteID")

        arParms(9) = New SqlClient.SqlParameter("@branch", SqlDbType.Int)
        arParms(9).Value = HttpContext.Current.Session("BranchID")
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_SaveLeaveRegisterDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function

    Shared Function Update(ByVal l As Pay) As Integer
        ' Dim querystring As String = "UPDATE LeaveRegister SET [E_ID]=@eid, [LeaveFrom]=@leavefrom, [LeaveTo]=@leaveto, [LeaveTypes]=@leavetype, [Approved]=@approved, [ApprovedBy]=@approvedby, [Remarks]=@remark, [LossOfPayAmt]=@LossOfPayAmt WHERE (((LeaveRegister.LR_ID)=@lrid))"
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(8) {}

        arParms(0) = New SqlClient.SqlParameter("@eid", SqlDbType.Int)
        arParms(0).Value = l.EId

        arParms(1) = New SqlClient.SqlParameter("@leavefrom", SqlDbType.DateTime)
        arParms(1).Value = l.Leavefrom

        arParms(2) = New SqlClient.SqlParameter("@leaveto", SqlDbType.DateTime)
        arParms(2).Value = l.Leaveto

        arParms(3) = New SqlClient.SqlParameter("@leavetype", SqlDbType.Int)
        arParms(3).Value = l.Leavetype

        arParms(4) = New SqlClient.SqlParameter("@approved", SqlDbType.Bit)
        arParms(4).Value = l.Approved

        arParms(5) = New SqlClient.SqlParameter("@approvedby", SqlDbType.VarChar, 50)
        arParms(5).Value = l.Approvedby

        arParms(6) = New SqlClient.SqlParameter("@Remark", SqlDbType.VarChar, 50)
        arParms(6).Value = l.Remark

        arParms(7) = New SqlClient.SqlParameter("@LossOfPayAmt", SqlDbType.Float)
        arParms(7).Value = l.LossOfPayAmt

        arParms(8) = New SqlClient.SqlParameter("@lrid", SqlDbType.Int)
        arParms(8).Value = l.Id
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateLeaveRegisterDetailsByID", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function

    Shared Function ChangeFlag(ByVal Id As Long) As Integer
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ' Dim querystring As String = "UPDATE LeaveRegister SET [Del_flag]=-1 WHERE (((LeaveRegister.LR_ID)=@lrid))"
        Dim rowsaffected As Integer
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}

        arParms(0) = New SqlClient.SqlParameter("@lrid", SqlDbType.Int)
        arParms(0).Value = Id

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionstring, CommandType.StoredProcedure, "proc_DeleteLeaveRegisterDetailByID", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Public Function RPT_GetLeaveRegister(ByVal insId As Int64, ByVal brnId As Int64) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            arParms(0) = New SqlClient.SqlParameter("@institute", SqlDbType.Int)
            arParms(0).Value = insId
            arParms(1) = New SqlClient.SqlParameter("@branch", SqlDbType.Int)
            arParms(1).Value = brnId
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RPT_GetLeaveRegisterDtls", arParms)
        Catch e As Exception
            ds = New DataSet

        End Try
        Return ds
    End Function
End Class
