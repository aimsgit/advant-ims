Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class BookMasterDB
    'taking data for ComboBox
    Shared Function subjectcombo() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Getsubjectcombo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetBook(ByVal id As Long, ByVal inst As Long, ByVal brch As Long) As System.Data.DataSet

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As DataSet
        If id = 0 Then
            Dim arParms() As SqlParameter = New SqlParameter(1) {}
            arParms(0) = New SqlParameter("@office", SqlDbType.Int)
            arParms(0).Value = inst

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.Int)
            arParms(1).Value = brch

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DispBookMaster", arParms)
        ElseIf id <> 0 Then
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBookDetailsByID", New System.Data.SqlClient.SqlParameter("@id", SqlDbType.SmallInt, 10, ParameterDirection.Input, False, 0, 0, "id", DataRowVersion.Current, id))
        Else
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBookDetails")
        End If
        Return ds

    End Function
    Shared Function Insert(ByVal BM As BookMaster) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(18) {}

        arParms(0) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(0).Value = BM.DeptId

        arParms(1) = New SqlParameter("@name", SqlDbType.VarChar, 250)
        arParms(1).Value = BM.Name

        arParms(2) = New SqlParameter("@code", SqlDbType.VarChar, 50)
        arParms(2).Value = BM.Code

        arParms(3) = New SqlParameter("@author", SqlDbType.VarChar, 250)
        arParms(3).Value = BM.Author

        arParms(4) = New SqlParameter("@publisher", SqlDbType.VarChar, 250)
        arParms(4).Value = BM.Publisher

        arParms(5) = New SqlParameter("@edition", SqlDbType.VarChar, 50)
        arParms(5).Value = BM.Edition

        arParms(6) = New SqlParameter("@pages", SqlDbType.Int)
        arParms(6).Value = BM.Pages

        arParms(7) = New SqlParameter("@subject", SqlDbType.Int)
        arParms(7).Value = BM.Subject

        arParms(8) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("BranchCode")

        arParms(9) = New SqlParameter("@quantity", SqlDbType.Int)
        arParms(9).Value = BM.Quantity

        arParms(10) = New SqlParameter("@price", SqlDbType.Money)
        arParms(10).Value = BM.Price

        arParms(11) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("UserCode")

        arParms(12) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("EmpCode")

        'If BM.ReceiveDate = "1/1/1900" Then
        '    arParms(13) = New SqlParameter("@Recievedate", SqlDbType.DateTime)
        '    arParms(13).Value = DBNull.Value
        'Else
        arParms(13) = New SqlParameter("@Recievedate", SqlDbType.DateTime)
        arParms(13).Value = BM.ReceiveDate
        'End If

        arParms(14) = New SqlParameter("@ISBN", SqlDbType.VarChar, 50)
        arParms(14).Value = BM.ISBN

        arParms(15) = New SqlParameter("@IssueRef", SqlDbType.VarChar, 2)
        arParms(15).Value = BM.IssueRef

        arParms(16) = New SqlParameter("@RackNo", SqlDbType.VarChar, 50)
        arParms(16).Value = BM.RackNo

        arParms(17) = New SqlParameter("@ShelfNo", SqlDbType.VarChar, 50)
        arParms(17).Value = BM.ShelfNo

        arParms(18) = New SqlParameter("@ClassNo", SqlDbType.VarChar, 50)
        arParms(18).Value = BM.classno
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveBookDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function Update(ByVal BM As BookMaster) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(19) {}

        arParms(0) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(0).Value = BM.DeptId

        arParms(1) = New SqlParameter("@name", SqlDbType.VarChar, 250)
        arParms(1).Value = BM.Name

        arParms(2) = New SqlParameter("@code", SqlDbType.VarChar, 50)
        arParms(2).Value = BM.Code

        arParms(3) = New SqlParameter("@author", SqlDbType.VarChar, 250)
        arParms(3).Value = BM.Author

        arParms(4) = New SqlParameter("@publisher", SqlDbType.VarChar, 250)
        arParms(4).Value = BM.Publisher

        arParms(5) = New SqlParameter("@edition", SqlDbType.VarChar, 50)
        arParms(5).Value = BM.Edition

        arParms(6) = New SqlParameter("@pages", SqlDbType.Int)
        arParms(6).Value = BM.Pages

        arParms(7) = New SqlParameter("@subject", SqlDbType.Int)
        arParms(7).Value = BM.Subject

        arParms(8) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("BranchCode")


        arParms(9) = New SqlParameter("@quantity", SqlDbType.Int)
        arParms(9).Value = BM.Quantity

        arParms(10) = New SqlParameter("@price", SqlDbType.Money)
        arParms(10).Value = BM.Price

        arParms(11) = New SqlParameter("@BMID", SqlDbType.Int)
        arParms(11).Value = BM.Id

        arParms(12) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("UserCode")

        arParms(13) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(13).Value = HttpContext.Current.Session("EmpCode")

      
        arParms(14) = New SqlParameter("@ReceiveDate", SqlDbType.DateTime)
        arParms(14).Value = BM.ReceiveDate


        arParms(15) = New SqlParameter("@ISBN", SqlDbType.VarChar, 50)
        arParms(15).Value = BM.ISBN

        arParms(16) = New SqlParameter("@IssueRef", SqlDbType.VarChar, 2)
        arParms(16).Value = BM.IssueRef

        arParms(17) = New SqlParameter("@RackNo", SqlDbType.VarChar, 50)
        arParms(17).Value = BM.RackNo

        arParms(18) = New SqlParameter("@ShelfNo", SqlDbType.VarChar, 50)
        arParms(18).Value = BM.ShelfNo

        arParms(19) = New SqlParameter("@ClassNo", SqlDbType.VarChar, 50)
        arParms(19).Value = BM.classno


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateBookDetails", arParms)
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

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteBookDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetBookCode() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBookDetails")
        Return ds.Tables(0)
    End Function
    Shared Function GetMaxBookCode() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMaxBookCode")
        Return ds.Tables(0)
    End Function
    Shared Function GetBookId(ByVal code As String, ByVal ins As Int64, ByVal brn As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@code", SqlDbType.Char)
        arParms(0).Value = code

        arParms(1) = New SqlParameter("@ins", SqlDbType.Int)
        arParms(1).Value = ins

        arParms(2) = New SqlParameter("@brn", SqlDbType.Int)
        arParms(2).Value = brn

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_BookIdCheck", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetBookQuantity(ByVal id As Long, ByVal ins As Int64, ByVal brn As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id

        arParms(1) = New SqlParameter("@ins", SqlDbType.Int)
        arParms(1).Value = ins

        arParms(2) = New SqlParameter("@brn", SqlDbType.Int)
        arParms(2).Value = brn

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBookQuantity", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function Getdatafrmbook(ByVal AssetDetail_ID As Long) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@AssetDetail_ID", SqlDbType.Int)
        arParms(0).Value = AssetDetail_ID

        arParms(1) = New SqlParameter("@inst", SqlDbType.Int)
        arParms(1).Value = HttpContext.Current.Session("InstituteID")

        arParms(2) = New SqlParameter("@brch", SqlDbType.Int)
        arParms(2).Value = HttpContext.Current.Session("BranchID")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDataFrmBook", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetReport(ByVal inst As Int64, ByVal brch As Int64) As System.Data.DataSet

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@inst", SqlDbType.Int)
        arParms(0).Value = inst

        arParms(1) = New SqlParameter("@brch", SqlDbType.Int)
        arParms(1).Value = brch

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_BookMasterReport", arParms)
        Return ds

    End Function
    Shared Function UpdateQtyPrice(ByVal b As BookMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@quantity", SqlDbType.Int)
        arParms(0).Value = b.Quantity

        arParms(1) = New SqlParameter("@price", SqlDbType.Money)
        arParms(1).Value = b.Price

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = b.AssetDet

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateQtyPrice", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DispGrid(ByVal b As BookMaster) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BMID", SqlDbType.Int)
        arParms(2).Value = b.Id

        arParms(3) = New SqlParameter("@BookName", SqlDbType.VarChar, 250)
        arParms(3).Value = b.Name

        arParms(4) = New SqlParameter("@BookCode", SqlDbType.VarChar, 50)
        arParms(4).Value = b.Code

        arParms(5) = New SqlParameter("@ReceivedDate", SqlDbType.DateTime)
        arParms(5).Value = b.ReceiveDate

        arParms(6) = New SqlParameter("@Publisher", SqlDbType.VarChar, 250)
        arParms(6).Value = b.Publisher

        Dim ds As New DataSet

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DispBookMaster", arParms)
        Return ds.Tables(0)

    End Function
    'For Preventing from Duplicate Entry
    Public Function GetDuplicateEntry(ByVal BM As BookMaster) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}
        para(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("office")
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Code", SqlDbType.VarChar, 50)
        para(2).Value = BM.Code
        para(3) = New SqlParameter("@id", SqlDbType.VarChar, 50)
        para(3).Value = BM.Id

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDuplicateBookDetails", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Code Written By: Niraj on 12 March 2013
    Public Function GetRptBookDetails(ByVal Dept As String, ByVal ReceiveFrom As Date, ByVal ReceiveTo As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@FromReceiveDate", SqlDbType.Date)
        arParms(2).Value = ReceiveFrom

        arParms(3) = New SqlParameter("@ToReceiveDate", SqlDbType.Date)
        arParms(3).Value = ReceiveTo

        arParms(4) = New SqlParameter("@DeptID", SqlDbType.NVarChar, 50)
        arParms(4).Value = Dept
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_BookDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDeptType() As System.Data.DataTable
        'Function for Inserting the data into DDL. By: Niraj 08-04-2013 .
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DDLDeptType", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDeptTypeAll() As System.Data.DataTable
        'Function for Inserting the data into DDL. By: Niraj 16-04-2013 .
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ddlDepartmentReport", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

End Class

