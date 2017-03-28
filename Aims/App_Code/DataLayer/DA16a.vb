Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class DA16a
    Dim ds As New DataSet
    Public Function check(ByVal prop As E16a) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim count As Int16 = 0
        ds.Clear()
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@formid", SqlDbType.Int, 50)
        arParms.Value = prop.Formid
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Check", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        count = ds.Tables(0).Rows.Count
        Return count
    End Function
    Public Function GetEmployee() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds.Clear()
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmployee")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function send(ByVal prop As E16a) As Int64
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(16) {}

        arParms(0) = New SqlParameter("@empid", SqlDbType.Int, 50)
        arParms(0).Value = prop.Empid

        arParms(1) = New SqlParameter("@formid", SqlDbType.Int, 50)
        arParms(1).Value = prop.Formid

        arParms(2) = New SqlParameter("@natureofpayment", SqlDbType.NVarChar, 50)
        arParms(2).Value = prop.Nature_of_payment

        arParms(3) = New SqlParameter("@duration", SqlDbType.NVarChar, 50)
        arParms(3).Value = prop.Duration

        arParms(4) = New SqlParameter("@taxableamt", SqlDbType.Float, 100)
        arParms(4).Value = prop.Taxable_amt

        arParms(5) = New SqlParameter("@deddate", SqlDbType.DateTime, 100)
        arParms(5).Value = prop.deduction_date

        arParms(6) = New SqlParameter("@tds", SqlDbType.Float, 100)
        arParms(6).Value = prop.TDS

        arParms(7) = New SqlParameter("@surcharges", SqlDbType.Real, 100)
        arParms(7).Value = prop.Surcharges

        arParms(8) = New SqlParameter("@educationcess", SqlDbType.Real, 100)
        arParms(8).Value = prop.Education_cess

        arParms(9) = New SqlParameter("@taxamt", SqlDbType.Float, 100)
        arParms(9).Value = prop.Tax_amt

        arParms(10) = New SqlParameter("@paymentdtls", SqlDbType.NVarChar, 50)
        arParms(10).Value = prop.Payment_details

        arParms(11) = New SqlParameter("@BSR", SqlDbType.NVarChar, 50)
        arParms(11).Value = prop.BSR

        arParms(12) = New SqlParameter("@paymentdate", SqlDbType.DateTime, 100)
        arParms(12).Value = prop.Payment_date

        arParms(13) = New SqlParameter("@paymentidentificationno", SqlDbType.Int, 100)
        arParms(13).Value = prop.Payment_identification_no

        arParms(14) = New SqlParameter("@institute", SqlDbType.Int)
        arParms(14).Value = HttpContext.Current.Session("InstituteID")

        arParms(15) = New SqlParameter("@branch", SqlDbType.Int)
        arParms(15).Value = HttpContext.Current.Session("BranchID")

        arParms(16) = New SqlParameter("@period", SqlDbType.VarChar, 50)
        arParms(16).Value = prop.For_the_period


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertLoanDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function Update16a(ByVal id As Int32, ByVal empid As Int32, ByVal formid As Int32, ByVal natureofpayment As String, ByVal duration As String, ByVal taxableamt As Int32, ByVal deddate As DateTime, ByVal tds As Double, ByVal surcharges As Double, ByVal educationcess As Double, ByVal taxamt As Double, ByVal paymentdtls As String, ByVal BSR As String, ByVal paymentdate As DateTime, ByVal paymentidentificationno As Int32, ByVal For_the_period As String) As Int64
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(15) {}

        arParms(0) = New SqlParameter("@empid", SqlDbType.Int, 50)
        arParms(0).Value = empid

        arParms(1) = New SqlParameter("@formid", SqlDbType.Int, 50)
        arParms(1).Value = formid

        arParms(2) = New SqlParameter("@natureofpayment", SqlDbType.NVarChar, 50)
        arParms(2).Value = natureofpayment

        arParms(3) = New SqlParameter("@duration", SqlDbType.NVarChar, 50)
        arParms(3).Value = duration

        arParms(4) = New SqlParameter("@taxableamt", SqlDbType.Float, 100)
        arParms(4).Value = taxableamt

        arParms(5) = New SqlParameter("@deddate", SqlDbType.DateTime, 100)
        arParms(5).Value = deddate

        arParms(6) = New SqlParameter("@tds", SqlDbType.Float, 100)
        arParms(6).Value = tds

        arParms(7) = New SqlParameter("@surcharges", SqlDbType.Real, 100)
        arParms(7).Value = surcharges

        arParms(8) = New SqlParameter("@educationcess", SqlDbType.Real, 100)
        arParms(8).Value = educationcess

        arParms(9) = New SqlParameter("@taxamt", SqlDbType.Float, 100)
        arParms(9).Value = taxamt

        arParms(10) = New SqlParameter("@paymentdtls", SqlDbType.NVarChar, 50)
        arParms(10).Value = paymentdtls

        arParms(11) = New SqlParameter("@BSR", SqlDbType.NVarChar, 50)
        arParms(11).Value = BSR

        arParms(12) = New SqlParameter("@paymentdate", SqlDbType.DateTime, 100)
        arParms(12).Value = paymentdate

        arParms(13) = New SqlParameter("@paymentidentificationno", SqlDbType.Int, 100)
        arParms(13).Value = paymentidentificationno

        arParms(14) = New SqlParameter("@period", SqlDbType.VarChar, 50)
        arParms(14).Value = For_the_period

        arParms(15) = New SqlParameter("@id", SqlDbType.Int)
        arParms(15).Value = id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_Update16a", arParms)
        Catch ex As Exception
            MsgBox("This form ID is already in use. Please choose any other ID.")
        End Try
        Return rowsAffected
    End Function
    'Public Function showgrid(ByVal prop As E16a) As Data.DataTable
    Public Function showgrid() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim query As String
        ''query = "SELECT * FROM Form16A INNER JOIN EmployeeMaster ON Form16A.EmpID = EmployeeMaster.Emp_Id WHERE Form16A.Duration='" & prop.Duration & "'AND Form16A.EmpID=" & prop.Empid
        'query = "SELECT * FROM Form16A INNER JOIN EmployeeMaster ON Form16A.EmpID = EmployeeMaster.Emp_Id WHERE ((Form16A.Del_Flag)= 0) AND ((Form16A.Duration)='" & prop.Duration & "') AND (Form16A.EmpID)=" & prop.Empid
        'da = New OleDbDataAdapter(query, Conn)
        'da.Fill(dt)
        ds.Clear()
        'Dim arParms() As SqlParameter = New SqlParameter(1) {}
        'arParms(0) = New SqlParameter("@empid", SqlDbType.Int, 50)
        'arParms(0).Value = prop.Empid

        'arParms(1) = New SqlParameter("@duration", SqlDbType.NVarChar, 50)
        'arParms(1).Value = prop.Duration

        Try
            'ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "select * From Proc_Get16aDetails", arParms)
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Select * from Form16A where Del_Flag =0 and Institute_ID=" & HttpContext.Current.Session("InstituteID") & " and Branch_ID=" & HttpContext.Current.Session("BranchID"))
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function showgrid(ByVal id As Int32, ByVal duration As String, ByVal insID As Int64, ByVal brnID As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds.Clear()
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@empid", SqlDbType.Int, 50)
        arParms(0).Value = id

        arParms(1) = New SqlParameter("@duration", SqlDbType.NVarChar, duration.Length)
        arParms(1).Value = duration
        arParms(2) = New SqlParameter("@institute", SqlDbType.Int)
        arParms(2).Value = insID
        arParms(3) = New SqlParameter("@branch", SqlDbType.Int)
        arParms(3).Value = brnID
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Get16aDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function showgrid(ByVal id As Int32, ByVal duration As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds.Clear()
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@empid", SqlDbType.Int, 50)
        arParms(0).Value = id

        arParms(1) = New SqlParameter("@duration", SqlDbType.NVarChar, duration.Length)
        arParms(1).Value = duration
        arParms(2) = New SqlParameter("@institute", SqlDbType.Int)
        arParms(2).Value = HttpContext.Current.Session("InstituteID")
        arParms(3) = New SqlParameter("@branch", SqlDbType.Int)
        arParms(3).Value = HttpContext.Current.Session("BranchID")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Get16aDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function Del16A(ByVal ID As Int32) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@id", SqlDbType.Int)
        arParms.Value = ID
        Dim rows As Int16
        Try
            rows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_Del16A", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rows
    End Function
End Class
