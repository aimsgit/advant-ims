Imports Microsoft.VisualBasic
Imports FeePaymentDetails
Imports System.Data.SqlClient
Namespace GlobalDataSetTableAdapters
    Partial Public Class Fee_DetailsTableAdapter
        Dim da As OleDb.OleDbDataAdapter
        Private _transaction As SqlTransaction
        Private Property Transaction() As SqlClient.SqlTransaction
            Get
                Return Me._transaction
            End Get
            Set(ByVal Value As SqlTransaction)
                Me._transaction = Value
            End Set
        End Property
        'Public Sub BeginTransaction()
        '    ' Open the connection, if needed
        '    If Me.Connection.State <> ConnectionState.Open Then
        '        Me.Connection.Open()
        '    End If
        '    ' Create the transaction and assign it to the Transaction property
        '    Me.Transaction = Me.Connection.BeginTransaction()
        '    ' Attach the transaction to the Adapters
        '    For Each command As SqlCommand In Me.CommandCollection
        '        command.Transaction = Me.Transaction
        '    Next
        '    Me.Adapter.InsertCommand.Transaction = Me.Transaction
        '    Me.Adapter.UpdateCommand.Transaction = Me.Transaction
        '    Me.Adapter.DeleteCommand.Transaction = Me.Transaction
        'End Sub
        'Public Sub CommitTransaction()
        '    ' Commit the transaction
        '    Me.Transaction.Commit()
        '    ' Close the connection
        '    Me.Connection.Close()
        'End Sub
        'Public Sub RollbackTransaction()
        '    ' Rollback the transaction
        '    Me.Transaction.Rollback()
        '    ' Close the connection
        '    Me.Connection.Close()
        'End Sub
        'Public Function UpdateWithTransaction(ByVal dataTable As GlobalDataSet.Fee_DetailsDataTable) As Integer
        '    Me.BeginTransaction()
        '    Try                ' Perform the update on the DataTable
        '        Dim returnValue As Integer = Me.Adapter.Update(dataTable)
        '        ' If we reach here, no errors, so commit the transaction
        '        Me.CommitTransaction()
        '        Return returnValue
        '    Catch
        '        ' If we reach here, there was an error, so rollback the transaction
        '        Me.RollbackTransaction()
        '        Throw
        '    End Try
        'End Function
    End Class
    Public Class FeeDetailsDB
        Public Function GetUpdate(ByVal ID As Int64) As Data.DataTable
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet

            Dim arParms As SqlParameter = New SqlParameter()

            arParms = New SqlParameter("@ID", SqlDbType.Int)
            arParms.Value = ID

            Try
                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetFeeDetailByID", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)
        End Function
        
        Public Function FeeDetailsInsert(ByVal Prop As FeePaymentDetails) As Int64
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim Id As Int64

            Dim arParms() As SqlParameter = New SqlParameter(8) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.Int)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.Int)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")


            arParms(2) = New SqlParameter("@cource_Id", SqlDbType.Int)
            arParms(2).Value = Prop.CourseId

            arParms(3) = New SqlParameter("@batch_Id", SqlDbType.Int)
            arParms(3).Value = Prop.CoursePlannerId

            arParms(4) = New SqlParameter("@feeStructure_Id", SqlDbType.Int)
            arParms(4).Value = Prop.FeeStructure

            arParms(5) = New SqlParameter("@student_id", SqlDbType.Int)
            arParms(5).Value = Prop.StdId

            arParms(6) = New SqlParameter("@NewId", SqlDbType.Int)
            arParms(6).Direction = ParameterDirection.Output

            arParms(7) = New SqlParameter("@remarks", SqlDbType.Char, Prop.Remarks.Length)
            arParms(7).Value = Prop.Remarks

            arParms(8) = New SqlParameter("@FCfortheYear", SqlDbType.Char, Prop.FCfortheYear.Length)
            arParms(8).Value = Prop.FCfortheYear

            Id = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_InsertFeeCollecion", arParms)

            Return arParms(6).Value
        End Function
        Public Function GetStd(ByVal insId As Int64, ByVal brnId As Int64, ByVal crsId As Int64, ByVal batchId As Int64) As Data.DataTable
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet

            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@Ins", SqlDbType.Int)
            arParms(0).Value = insId

            arParms(1) = New SqlParameter("@Brn", SqlDbType.Int)
            arParms(1).Value = brnId

            arParms(2) = New SqlParameter("@Crs", SqlDbType.Int)
            arParms(2).Value = crsId

            arParms(3) = New SqlParameter("@btch", SqlDbType.Int)
            arParms(3).Value = batchId
            Try
                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStdCode", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)
        End Function
        Public Function GetFeeStructureId(ByVal batchId As Int64, ByVal semsterId As Int64) As Data.DataTable
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet

            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@batchId", SqlDbType.Int)
            arParms(0).Value = batchId

            arParms(1) = New SqlParameter("@semsterId", SqlDbType.Int)
            arParms(1).Value = semsterId
            Try
                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetFeeStructureId", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)
        End Function
        Public Function Update(ByVal Prop As FeePaymentDetails) As Int16

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim rowsAffected As Integer = 0
            Dim arParms As SqlParameter() = New SqlParameter(4) {}

            arParms(0) = New SqlParameter("@StdId", SqlDbType.Int, 50)
            arParms(0).Value = Prop.StdId

            arParms(1) = New SqlParameter("@StructId", SqlDbType.Int, 50)
            arParms(1).Value = Prop.FeeStructure

            arParms(2) = New SqlParameter("@remarks", SqlDbType.Char, Prop.Remarks.Length)
            arParms(2).Value = Prop.Remarks

            arParms(3) = New SqlParameter("@ID", SqlDbType.Int, 50)
            arParms(3).Value = Prop.Id

            arParms(4) = New SqlParameter("@FCfortheYear", SqlDbType.Char, Prop.FCfortheYear.Length)
            arParms(4).Value = Prop.FCfortheYear

            Try
                rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateFeeDetail", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return rowsAffected
        End Function
        Public Function FillGrid(ByVal Batch As Int64, ByVal crsID As Int64, ByVal stdID As Int64, ByVal semID As Int64) As Data.DataTable
            Dim ds As New DataSet
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

            Dim arParms() As SqlParameter = New SqlParameter(5) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@crsID", SqlDbType.Int)
            arParms(2).Value = crsID

            arParms(3) = New SqlParameter("@batch_Id", SqlDbType.Int)
            arParms(3).Value = Batch

            arParms(4) = New SqlParameter("@stdID", SqlDbType.Int)
            arParms(4).Value = stdID

            arParms(5) = New SqlParameter("@semID", SqlDbType.Int)
            arParms(5).Value = semID


            Try
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetFeeDetails", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)
        End Function
        Public Function GetStdName(ByVal stdId As Int64) As Data.DataTable
            Dim ds As New DataSet
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim arParms As SqlParameter = New SqlParameter()
            arParms = New SqlParameter("@stdid", SqlDbType.Int, 50)
            arParms.Value = stdId
            Try
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdName", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)
        End Function
        Public Function GetReport(ByVal Batch As Int64, ByVal FeeStructure_id As Long) As Int32
            Dim id As Int32
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@batch_Id", SqlDbType.Int, 50)
            arParms(0).Value = Batch

            arParms(1) = New SqlParameter("@feeStructure_Id", SqlDbType.Int, 50)
            arParms(1).Value = FeeStructure_id
            Try
                id = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_GetFeeDetailCount", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return id
        End Function
        Public Function getReceipt(ByVal Stid As String, ByVal ID As String) As Data.DataTable
            Dim dt As New Data.DataSet
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim arParms() As SqlParameter = New SqlParameter(2) {}


            arParms(0) = New SqlParameter("@stdId", SqlDbType.VarChar, 50)
            arParms(0).Value = Stid

            'arParms(1) = New SqlParameter("@ID", SqlDbType.VarChar, 50)
            'arParms(1).Value = ID

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("Office")

            Try
                dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_rptReceipt", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return dt.Tables(0)
        End Function
        Public Function Receipt(ByVal Department As Integer, ByVal FromReceipt As Integer, ByVal ToReceipt As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal Radio As String) As Data.DataTable
            Dim dt As New Data.DataSet
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim arParms() As SqlParameter = New SqlParameter(7) {}


            arParms(0) = New SqlParameter("@Dept", SqlDbType.Int)
            arParms(0).Value = Department

            arParms(1) = New SqlParameter("@FromReceipt", SqlDbType.Int)
            arParms(1).Value = FromReceipt

            arParms(2) = New SqlParameter("@ToReceipt", SqlDbType.Int)
            arParms(2).Value = ToReceipt
            arParms(3) = New SqlParameter("@StartDate", SqlDbType.Date)
            arParms(3).Value = StartDate

            arParms(4) = New SqlParameter("@EndDate", SqlDbType.Date)
            arParms(4).Value = EndDate
            arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(5).Value = HttpContext.Current.Session("BranchCode")

            arParms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(6).Value = HttpContext.Current.Session("Office")
            arParms(7) = New SqlParameter("@Radio", SqlDbType.VarChar, 50)
            arParms(7).Value = Radio

            Try
                dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "RptBulkFeeReceipt", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return dt.Tables(0)
        End Function
        Public Function getAdhocFeeReceipt(ByVal Stid As String, ByVal ID As String) As Data.DataTable
            Dim dt As New Data.DataSet
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim arParms() As SqlParameter = New SqlParameter(3) {}


            arParms(0) = New SqlParameter("@stdId", SqlDbType.VarChar, 50)
            arParms(0).Value = Stid

            arParms(1) = New SqlParameter("@ID", SqlDbType.VarChar, 50)
            arParms(1).Value = ID

            arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("BranchCode")

            arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(3).Value = HttpContext.Current.Session("Office")

            Try
                dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_rptAdhocFeeReceipt", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return dt.Tables(0)
        End Function
        Public Function GetGrid(ByVal crsId As Int64, ByVal batchId As Int64, ByVal semsterId As Int16, ByVal stdId As Int64) As Data.DataTable
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet
            Dim arParms() As SqlParameter = New SqlParameter(5) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@crsID", SqlDbType.Int)
            arParms(2).Value = crsId

            arParms(3) = New SqlParameter("@batch_Id", SqlDbType.Int)
            arParms(3).Value = batchId

            arParms(4) = New SqlParameter("@semID", SqlDbType.Int)
            arParms(4).Value = semsterId

            arParms(5) = New SqlParameter("@stdID", SqlDbType.Int)
            arParms(5).Value = stdId
            Try
                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetFeeDetails", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)
        End Function
        'Public Function Payment_Methode() As System.Data.DataTable
        '    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        '    Dim ds As New DataSet
        '    Dim arParms() As SqlParameter = New SqlParameter(1) {}
        '    arParms(0) = New SqlParameter("@Office", SqlDbType.Int)
        '    arParms(0).Value = HttpContext.Current.Session("Office")
        '    arParms(1) = New SqlParameter("@BranchCode", SqlDbType.Int)
        '    arParms(1).Value = HttpContext.Current.Session("BranchCode")
        '    Try
        '        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_GetPaymentMethode", arParms)
        '    Catch ex As Exception
        '        MsgBox(ex.ToString)
        '    End Try
        '    Return ds.Tables(0)
        'End Function
        Public Function Delete(ByVal id As Int64) As int16
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(0) {}
            arParms(0) = New SqlParameter("@id", SqlDbType.Int)
            arParms(0).Value = id
            Try
                rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_DeleteFeeDetails", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return rowsAffected
        End Function
        Shared Function GetPaymentMode(ByVal PaymentMethodID As Long) As System.Data.DataSet
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            If PaymentMethodID = 0 Then
                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, "Select PaymentMethodID,Payment_Method from PaymentMethods where Del_Flag=0")
            Else
                Dim arParms() As SqlParameter = New SqlParameter(0) {}
                arParms(0) = New SqlParameter("@PaymentMethodID", SqlDbType.Int)
                arParms(0).Value = PaymentMethodID
                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetPaymentByID", arParms)
            End If
            Return ds
        End Function
        
    End Class
End Namespace
