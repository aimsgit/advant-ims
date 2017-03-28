Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLTransportReg
    Shared Function GetRouteNamecombo() As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlParameter = New SqlParameter(1) {}
        Dim ds As New DataSet
        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetRouteNameCombo", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetPickuppointcombo(ByVal RouteIDAuto As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim ds As New DataSet
        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@RouteIDAuto", SqlDbType.Int)
        para(2).Value = RouteIDAuto
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetPickUpPointCombo", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function AutofillName(ByVal El As TransportReg) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlParameter = New SqlParameter(3) {}
        Dim ds As New DataSet
        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@Code", SqlDbType.VarChar, 50)
        para(2).Value = El.Code

        para(3) = New SqlParameter("@STD_ID", SqlDbType.Int)
        para(3).Value = El.Std_ID

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ProcAutoFillStdCode", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function AutoFilForRutNo(ByVal RouteIDAuto As TransportReg) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim ds As New DataSet
        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@RouteIDAuto", SqlDbType.Int)
        para(2).Value = RouteIDAuto.RouteID

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_AutoFillRutNumber", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function InsertIntoReg(ByVal m As TransportReg) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(11) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")
        Parms(1) = New SqlParameter("@A_Code", SqlDbType.Int)
        Parms(1).Value = m.Acode
        Parms(2) = New SqlParameter("@Std_ID", SqlDbType.Int)
        Parms(2).Value = m.Std_ID
        Parms(3) = New SqlParameter("@EmpID", SqlDbType.Int)
        Parms(3).Value = m.EmpId
        If m.RegistrationDate = "1/1/1900" Then
            Parms(4) = New SqlParameter("@RegistrationDate", SqlDbType.DateTime)
            Parms(4).Value = DBNull.Value
        Else
            Parms(4) = New SqlParameter("@RegistrationDate", SqlDbType.DateTime)
            Parms(4).Value = m.RegistrationDate
        End If
    
        Parms(5) = New SqlParameter("@PickUpPoint", SqlDbType.VarChar, 50)
        Parms(5).Value = m.PickUpPoint
        If m.PickUptime = "1/1/1900" Then
            Parms(6) = New SqlParameter("@PickUpTime", SqlDbType.DateTime)
            Parms(6).Value = DBNull.Value
        Else
            Parms(6) = New SqlParameter("@PickUpTime", SqlDbType.DateTime)
            Parms(6).Value = m.PickUptime
        End If

        Parms(7) = New SqlParameter("@RouteIDAuto", SqlDbType.VarChar, 50)
        Parms(7).Value = m.RouteID
        Parms(8) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        Parms(8).Value = m.Remarks
        Parms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(9).Value = HttpContext.Current.Session("UserCode")
        Parms(10) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(10).Value = HttpContext.Current.Session("EmpCode")


        Parms(11) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(11).Value = HttpContext.Current.Session("Office")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[InsertIntoTransportReg]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function
    'Code For Update
    Shared Function Update(ByVal m As TransportReg) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(11) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")
        Parms(1) = New SqlParameter("@A_Code", SqlDbType.Int)
        Parms(1).Value = m.Acode
        Parms(2) = New SqlParameter("@Std_ID", SqlDbType.Int)
        Parms(2).Value = m.Std_ID
        Parms(3) = New SqlParameter("@EmpID", SqlDbType.Int)
        Parms(3).Value = m.EmpId

        If m.RegistrationDate = "1/1/1900" Then
            Parms(4) = New SqlParameter("@RegistrationDate", SqlDbType.DateTime)
            Parms(4).Value = DBNull.Value
        Else
            Parms(4) = New SqlParameter("@RegistrationDate", SqlDbType.DateTime)
            Parms(4).Value = m.RegistrationDate
        End If

        Parms(5) = New SqlParameter("@PickUpPoint", SqlDbType.VarChar, 50)
        Parms(5).Value = m.PickUpPoint
        If m.PickUptime = "1/1/1900" Then
            Parms(6) = New SqlParameter("@PickUpTime", SqlDbType.DateTime)
            Parms(6).Value = DBNull.Value
        Else
            Parms(6) = New SqlParameter("@PickUpTime", SqlDbType.DateTime)
            Parms(6).Value = m.PickUptime
        End If

        Parms(7) = New SqlParameter("@RouteIDAuto", SqlDbType.VarChar, 50)
        Parms(7).Value = m.RouteID
        Parms(8) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        Parms(8).Value = m.Remarks
        Parms(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(9).Value = HttpContext.Current.Session("UserCode")
        Parms(10) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(10).Value = HttpContext.Current.Session("EmpCode")

        Parms(11) = New SqlParameter("@TRNO_Auto", SqlDbType.Int)
        Parms(11).Value = m.TRNO
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "UpdateTransportReg", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function
    Public Shared Function GetDatStdTransport(ByVal prefixText As String) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@StdCode", SqlDbType.VarChar, 100)
        arParms(0).Value = prefixText

        arParms(1) = New SqlParameter("@Office", SqlDbType.varchar, 50)
        arParms(1).Value = HttpContext.current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.varchar, 50)
        arParms(2).Value = HttpContext.current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[GetStudentExtTransport]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetTransportReg(ByVal TransportReg As TransportReg) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlParameter = New SqlParameter(9) {}
        Dim ds As New DataSet
        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = TransportReg.TRNO

        para(3) = New SqlParameter("@Acode", SqlDbType.VarChar)
        para(3).Value = TransportReg.Acode

        para(4) = New SqlParameter("@StudentCode", SqlDbType.VarChar)
        para(4).Value = TransportReg.Std_Emp

        para(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar)
        para(5).Value = TransportReg.EmpCod

        para(6) = New SqlParameter("@RouteName", SqlDbType.VarChar)
        para(6).Value = TransportReg.RouteID

        para(7) = New SqlParameter("@stdName", SqlDbType.VarChar)
        para(7).Value = TransportReg.StdName

        para(8) = New SqlParameter("@EmpName", SqlDbType.VarChar)
        para(8).Value = TransportReg.EmpName

        para(9) = New SqlParameter("@StudentEmp", SqlDbType.VarChar)
        para(9).Value = TransportReg.RBUser

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetTransportReg", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function ChangeFlag(ByVal TRNO As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@TRNO", SqlDbType.Int)
        arParms(0).Value = TRNO

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "DeleteTransportAssignmentSTD", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Shared Function GetPickUpPoints(ByVal RouteIDAuto As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim ds As New DataSet
        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@RouteIDAuto", SqlDbType.Int)
        para(2).Value = RouteIDAuto
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetPickUpPointCombo", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CheckDuplicate(ByVal s As TransportReg) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@STD_ID", SqlDbType.Int)
        para(1).Value = s.Std_ID

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_DuplicateTransportReg", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function

    Shared Function CheckDuplicateEmp(ByVal s As TransportReg) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@EmpID", SqlDbType.Int)
        para(1).Value = s.EmpId

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetDuplicateEmpCode", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
End Class
