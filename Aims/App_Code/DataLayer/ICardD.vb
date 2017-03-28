Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.web.UI.WebControls
Imports System.Data.SqlClient
Public Class ICardD
    Dim dt As New DataTable
    Dim query As String
    Dim da As OleDbDataAdapter
    Dim ds As New DataSet
    Dim cmd As OleDbCommand
    
    Public Function getInstitutes() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ' query = "SELECT EmployeeMaster.Emp_Name, LoanMaster.LoanIDCode, LoanMaster.LoanID, LoanMaster.LoanType, LoanMaster.LoanAmt, LoanMaster.LoanDate, LoanMaster.InterestRate, LoanMaster.ChequeDate, LoanMaster.MonthlyDed, LoanMaster.BalanceLoan, LoanMaster.StartDate, LoanMaster.Hold, LoanMaster.Del_Flag FROM LoanMaster LEFT JOIN EmployeeMaster ON LoanMaster.EmpId = EmployeeMaster.Emp_Id WHERE(((LoanMaster.Del_Flag) = 0))"
        'da = New OleDbDataAdapter(query, Conn)
        ' da.Fill(dt)
        'MsgBox(dt.Rows.Count)
        ds.Clear()
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetInst")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function getBranches() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ' query = "SELECT EmployeeMaster.Emp_Name, LoanMaster.LoanIDCode, LoanMaster.LoanID, LoanMaster.LoanType, LoanMaster.LoanAmt, LoanMaster.LoanDate, LoanMaster.InterestRate, LoanMaster.ChequeDate, LoanMaster.MonthlyDed, LoanMaster.BalanceLoan, LoanMaster.StartDate, LoanMaster.Hold, LoanMaster.Del_Flag FROM LoanMaster LEFT JOIN EmployeeMaster ON LoanMaster.EmpId = EmployeeMaster.Emp_Id WHERE(((LoanMaster.Del_Flag) = 0))"
        'da = New OleDbDataAdapter(query, Conn)
        ' da.Fill(dt)
        'MsgBox(dt.Rows.Count)
        ds.Clear()
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAllBranches")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function recovergrid() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'query = "SELECT EmployeeMaster.Emp_Name,LoanMaster.LoanIDCode,LoanID,LoanType,LoanAmt,LoanDate,InterestRate,ChequeDate,MonthlyDed,BalanceLoan,StartDate,Hold FROM LoanMaster LEFT JOIN EmployeeMaster ON LoanMaster.EmpId = EmployeeMaster.Emp_Id WHERE Del_Flag=0"
        'da = New OleDbDataAdapter(query, Conn)
        'da.Fill(dt)
        'MsgBox(dt.Rows.Count)
        ds.Clear()
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDeletedLoanRecords")
        Catch ex As Exception
        End Try
        Return ds.Tables(0)
    End Function
    Public Function updateStdDetails(ByVal Prop As ICardE) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@rcptno", SqlDbType.NVarChar, 250)
        arParms(0).Value = Prop.Receiptno

        arParms(1) = New SqlParameter("@rcptdate", SqlDbType.DateTime)
        arParms(1).Value = Prop.Receiptdate

        arParms(2) = New SqlParameter("@rcptamt", SqlDbType.NVarChar)
        arParms(2).Value = Prop.amount

        arParms(3) = New SqlParameter("@rcptmonth", SqlDbType.NVarChar)
        arParms(3).Value = Prop.issuedmonth

        arParms(4) = New SqlParameter("@insid", SqlDbType.Int)
        arParms(4).Value = Prop.Instituteid

        arParms(5) = New SqlParameter("@branchid", SqlDbType.Int)
        arParms(5).Value = Prop.Branchid

        arParms(6) = New SqlParameter("@courseid", SqlDbType.Int)
        arParms(6).Value = Prop.Courseid

        arParms(7) = New SqlParameter("@batchno", SqlDbType.NVarChar)
        arParms(7).Value = Prop.Batchno

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_updateStdDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Sub delete(ByVal LoanId As Int64)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        'Dim query As String = "UPDATE LoanMaster SET Del_Flag='-1' WHERE LoanId=" & LoanId
        'cmd = New OleDbCommand(query, Conn)
        'Conn.Open()
        'cmd.ExecuteNonQuery()
        'Conn.Close()
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@loanid", SqlDbType.Int)
        arParms.Value = LoanId
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteRecords", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub recover(ByVal LoanId As Int64)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        'Dim query As String = "UPDATE LoanMaster SET DeleteFlag='N' WHERE LoanId=" & LoanId
        'cmd = New OleDbCommand(query, Conn)
        'Conn.Open()
        'cmd.ExecuteNonQuery()
        'Conn.Close()
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@loanid", SqlDbType.Int)
        arParms.Value = LoanId
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_RecoverRecords", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Function GetAllCourses(ByVal Prop As ICardE) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim dt As New Data.DataTable
        'Dim query As String
        'query = "SELECT Emp_Id,Emp_Name FROM EmployeeMaster WHERE Del_Flag=0 order by Emp_name"
        'da = New OleDbDataAdapter(query, Conn)
        'da.Fill(dt)
        'Return dt
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@insid", SqlDbType.Int, 50)
        arParms(0).Value = Prop.Instituteid

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int, 50)
        arParms(1).Value = Prop.Branchid
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAllCourses", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetAllBatchs(ByVal Prop As ICardE) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim dt As New Data.DataTable
        'Dim query As String
        'query = "SELECT Emp_Id,Emp_Name FROM EmployeeMaster WHERE Del_Flag=0 order by Emp_name"
        'da = New OleDbDataAdapter(query, Conn)
        'da.Fill(dt)
        'Return dt
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@insid", SqlDbType.Int, 50)
        arParms(0).Value = Prop.Instituteid

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int, 50)
        arParms(1).Value = Prop.Branchid

        arParms(2) = New SqlParameter("@courseid", SqlDbType.Int, 50)
        arParms(2).Value = Prop.Courseid
        
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAllBatchs", arParms)
        Return ds.Tables(0)
    End Function
    Public Function FillICardGrid(ByVal Prop As ICardE) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim dt As New Data.DataTable
        'Dim query As String
        'query = "SELECT Emp_Id,Emp_Name FROM EmployeeMaster WHERE Del_Flag=0 order by Emp_name"
        'da = New OleDbDataAdapter(query, Conn)
        'da.Fill(dt)
        'Return dt
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@insid", SqlDbType.Int, 50)
        arParms(0).Value = Prop.Instituteid

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int, 50)
        arParms(1).Value = Prop.Branchid

        arParms(2) = New SqlParameter("@courseid", SqlDbType.Int, 50)
        arParms(2).Value = Prop.Courseid

        arParms(3) = New SqlParameter("@batchno", SqlDbType.Int)
        arParms(3).Value = Prop.Batchno

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FillICardGrid", arParms)
        Return ds.Tables(0)
    End Function
    Public Function send(ByVal Prop As loanmasterE) As Int64
        'Dim query As String
        'Dim parm_connect As OleDbParameter
        'query = "INSERT INTO LoanMaster(LoanIDCode,EmpId,LoanType,LoanDate,LoanAmt,InterestRate,ChequeDate,MonthlyDed,BalanceLoan,StartDate) values(@loanidcode,@Empid,@loantype,@loandate,@loanamount,@interestrate,@chequedate,@monthlyded,@balanceloan,@startdate)"
        'Dim cmd1 As OleDbCommand = New OleDbCommand(query, Conn)

        'parm_connect = New OleDbParameter
        'parm_connect.ParameterName = "@loanidcode"
        'parm_connect.Value = Prop.Loanidcode
        'cmd1.Parameters.Add(parm_connect)

        'parm_connect = New OleDbParameter
        'parm_connect.ParameterName = "@empid"
        'parm_connect.Value = Prop.Empid
        'cmd1.Parameters.Add(parm_connect)

        'parm_connect = New OleDbParameter
        'parm_connect.ParameterName = "@loantype"
        'parm_connect.Value = Prop.Loantype
        'cmd1.Parameters.Add(parm_connect)

        'parm_connect = New OleDbParameter
        'parm_connect.ParameterName = "@loandate"
        'parm_connect.Value = Prop.Loandate
        'cmd1.Parameters.Add(parm_connect)

        'parm_connect = New OleDbParameter
        'parm_connect.ParameterName = "@loanamount"
        'parm_connect.Value = Prop.Loanamount
        'cmd1.Parameters.Add(parm_connect)

        'parm_connect = New OleDbParameter
        'parm_connect.ParameterName = "@interestrate"
        'parm_connect.Value = Prop.Interestrate
        'cmd1.Parameters.Add(parm_connect)

        'parm_connect = New OleDbParameter
        'parm_connect.ParameterName = "@chequedate"
        'parm_connect.Value = Prop.Chequedate
        'cmd1.Parameters.Add(parm_connect)

        'parm_connect = New OleDbParameter
        'parm_connect.ParameterName = "@monthlyded"
        'parm_connect.Value = Prop.monthlyded
        'cmd1.Parameters.Add(parm_connect)

        'parm_connect = New OleDbParameter
        'parm_connect.ParameterName = "@balanceloan"
        'parm_connect.Value = Prop.Balanceloan
        'cmd1.Parameters.Add(parm_connect)

        'parm_connect = New OleDbParameter
        'parm_connect.ParameterName = "@startdate"
        'parm_connect.Value = Prop.Startdate
        'cmd1.Parameters.Add(parm_connect)

        'parm_connect = New OleDbParameter
        'parm_connect.ParameterName = "@deleteflag"
        'parm_connect.Value = Prop.Deleteflag
        'cmd1.Parameters.Add(parm_connect)

        ''parm_connect = New OleDbParameter
        ''parm_connect.ParameterName = "@hold"
        ''parm_connect.Value = Prop.Hold
        ''cmd1.Parameters.Add(parm_connect)

        'Conn.Open()
        'cmd1.ExecuteNonQuery()
        'Conn.Close()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(10) {}
        Dim rowsAffected As Integer = 0
        Dim delflag As Int16 = 0
        arParms(0) = New SqlParameter("@loanidcode", SqlDbType.NVarChar, 50)
        arParms(0).Value = Prop.Loanidcode

        arParms(1) = New SqlParameter("@empid", SqlDbType.Int, 50)
        arParms(1).Value = Prop.Empid

        arParms(2) = New SqlParameter("@loantype", SqlDbType.NVarChar, 250)
        arParms(2).Value = Prop.Loantype

        arParms(3) = New SqlParameter("@loandate", SqlDbType.DateTime)
        arParms(3).Value = Prop.Loandate

        arParms(4) = New SqlParameter("@loanamt", SqlDbType.Float)
        arParms(4).Value = Prop.Loanamount

        arParms(5) = New SqlParameter("@intrate", SqlDbType.Real)
        arParms(5).Value = Prop.Interestrate

        arParms(6) = New SqlParameter("@chqdate", SqlDbType.DateTime)
        arParms(6).Value = Prop.Chequedate

        arParms(7) = New SqlParameter("@monthded", SqlDbType.Real)
        arParms(7).Value = Prop.monthlyded

        arParms(8) = New SqlParameter("@balanceloan", SqlDbType.Float)
        arParms(8).Value = Prop.Balanceloan

        arParms(9) = New SqlParameter("@sdate", SqlDbType.DateTime)
        arParms(9).Value = Prop.Startdate

        arParms(10) = New SqlParameter("@deleteflag", SqlDbType.Bit)
        arParms(10).Value = delflag

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertLoanRecord", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function UpdateICardStatus(ByVal Prop As ICardE, ByVal flag As Boolean) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim dt As New Data.DataTable
        'Dim query As String
        'query = "SELECT Emp_Id,Emp_Name FROM EmployeeMaster WHERE Del_Flag=0 order by Emp_name"
        'da = New OleDbDataAdapter(query, Conn)
        'da.Fill(dt)
        'Return dt
        Dim rowsAffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@insid", SqlDbType.Int, 50)
        arParms(0).Value = Prop.Instituteid

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int, 50)
        arParms(1).Value = Prop.Branchid

        arParms(2) = New SqlParameter("@courseid", SqlDbType.Int, 50)
        arParms(2).Value = Prop.Courseid

        arParms(3) = New SqlParameter("@batchno", SqlDbType.Int)
        arParms(3).Value = Prop.Batchno

        arParms(4) = New SqlParameter("@stdid", SqlDbType.Int, 50)
        arParms(4).Value = Prop.Stdid

        Try
            Dim str As String
            If flag = False Then
                str = "Update StudentMaster set IDCard_Issue=0 where StdId=" & Prop.Stdid & " and Institute_ID=" & Prop.Instituteid & " and Branch_ID= " & Prop.Branchid & "  and Course_ID=" & Prop.Courseid & "  and Batch_No=" & Prop.Batchno

            Else
                str = "Update StudentMaster set IDCard_Issue=1 where StdId=" & Prop.Stdid & " and Institute_ID=" & Prop.Instituteid & " and Branch_ID= " & Prop.Branchid & "  and Course_ID=" & Prop.Courseid & "  and Batch_No=" & Prop.Batchno
            End If
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, str)
            'If flag = False Then
            '    rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateICardStatus", arParms)
            'Else
            '    rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateICardStatusToFalse", arParms)
            'End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function GetRcptDetails(ByVal Prop As ICardE) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim dt As New Data.DataTable
        'Dim query As String
        'query = "SELECT Emp_Id,Emp_Name FROM EmployeeMaster WHERE Del_Flag=0 order by Emp_name"
        'da = New OleDbDataAdapter(query, Conn)
        'da.Fill(dt)
        'Return dt
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@insid", SqlDbType.Int, 50)
        arParms(0).Value = Prop.Instituteid

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int, 50)
        arParms(1).Value = Prop.Branchid

        arParms(2) = New SqlParameter("@courseid", SqlDbType.Int, 50)
        arParms(2).Value = Prop.Courseid

        arParms(3) = New SqlParameter("@batchno", SqlDbType.Int)
        arParms(3).Value = Prop.Batchno

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetRcptDetails", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetReport(ByVal inst As Int64, ByVal brn As Int64, ByVal crs As Int64, ByVal btch As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@insid", SqlDbType.Int, 50)
        arParms(0).Value = inst

        arParms(1) = New SqlParameter("@branchid", SqlDbType.Int, 50)
        arParms(1).Value = brn

        arParms(2) = New SqlParameter("@courseid", SqlDbType.Int, 50)
        arParms(2).Value = crs

        arParms(3) = New SqlParameter("@batchno", SqlDbType.Int, 50)
        arParms(3).Value = btch
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptIDCardIssue", arParms)
        Return ds.Tables(0)
    End Function
End Class

