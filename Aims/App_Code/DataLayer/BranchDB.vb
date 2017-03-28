Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class BranchDB
    Shared Function GetBranch(ByVal branchid As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        If branchid = 0 Then
            Dim para() As SqlParameter = New SqlParameter(1) {}
            para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            para(0).Value = HttpContext.Current.Session("Office")
            para(1) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
            para(1).Value = HttpContext.Current.Session("BranchCode")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBranchDetails")
        Else
            'Dim para() As SqlParameter = New SqlParameter(0) {}
            'para(0) = New SqlParameter("BranchID", SqlDbType.Int)
            'para(0).Value = branchid
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBranchDetailsByBrnchID", New System.Data.SqlClient.SqlParameter("@BranchID", SqlDbType.SmallInt, 10, ParameterDirection.Input, False, 0, 0, "BranchID", DataRowVersion.Current, branchid))
        End If
        Return ds

    End Function
    Shared Function Insert(ByVal b As Branch) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        'arParms(0) = New SqlParameter("@name", SqlDbType.Char, b.Name.Length)
        'arParms(0).Value = b.Name
        'arParms(1) = New SqlParameter("@address", SqlDbType.Char, b.Address.Length)
        'arParms(1).Value = b.Address
        'arParms(2) = New SqlParameter("@city", SqlDbType.Char, b.City.Length)
        'arParms(2).Value = b.City
        'arParms(3) = New SqlParameter("@state", SqlDbType.Char, b.State.Length)
        'arParms(3).Value = b.State
        'arParms(4) = New SqlParameter("@country", SqlDbType.Char, b.Country.Length)
        'arParms(4).Value = b.Country
        'arParms(5) = New SqlParameter("@contactno", SqlDbType.Char, b.ContactNo.Length)
        'arParms(5).Value = b.ContactNo
        'arParms(6) = New SqlParameter("@BranchType", SqlDbType.Int)
        'arParms(6).Value = b.TypeID
        'arParms(7) = New SqlParameter("@ZoneID", SqlDbType.Int)
        'arParms(7).Value = b.ZoneID
        'arParms(8) = New SqlParameter("@RO_ID", SqlDbType.Int)
        'arParms(8).Value = b.ROID
        'arParms(9) = New SqlParameter("@HO_ID", SqlDbType.Int)
        'arParms(9).Value = b.HOID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveBranchDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal b As Branch) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        'dbConnection.Open()
        'Try
        '    rowsAffected = dbCommand.ExecuteNonQuery
        'Finally
        '    dbConnection.Close()
        'End Try
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.Char, b.Name.Length)
        arParms(0).Value = b.Name

        'arParms(1) = New SqlParameter("@code", SqlDbType.Char, b.Code.Length)
        'arParms(1).Value = b.Code

        'arParms(1) = New SqlParameter("@address", SqlDbType.Char, b.Address.Length)
        'arParms(1).Value = b.Address

        'arParms(2) = New SqlParameter("@city", SqlDbType.Char, b.City.Length)
        'arParms(2).Value = b.City

        'arParms(3) = New SqlParameter("@state", SqlDbType.Char, b.State.Length)
        'arParms(3).Value = b.State

        'arParms(4) = New SqlParameter("@country", SqlDbType.Char, b.Country.Length)
        'arParms(4).Value = b.Country

        'arParms(5) = New SqlParameter("@contactno", SqlDbType.Char, b.ContactNo.Length)
        'arParms(5).Value = b.ContactNo

        'arParms(6) = New SqlParameter("@branchid", SqlDbType.Int)
        'arParms(6).Value = b.Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateBranchDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString


        Dim rowsAffected As Integer = 0
        'dbConnection.Open()
        ' Try
        'rowsAffected = dbCommand.ExecuteNonQuery
        'Finally
        'dbConnection.Close()
        'End Try
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@branchid", SqlDbType.Int)
        arParms(0).Value = Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteBranchDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GVBranchComboUser(ByVal id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString


        Dim ds As DataSet


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT Branch_ID,BranchName FROM View_GetBranchDetails")
        Return ds
    End Function

    Shared Function GVBranchInsWise(ByVal id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms(0).Value = id
        If HttpContext.Current.Session("Admin") = 1 Then
            arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(1).Value = HttpContext.Current.Session("NewBranchID")
        Else
            arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(1).Value = HttpContext.Current.Session("sesbranch")
        End If
        If arParms(1).Value = Nothing Then
            arParms(1).Value = HttpContext.Current.Session("BranchID")
        End If
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SP_GetBranchByTypeID", arParms)
        Return ds
    End Function
    Shared Function FillBranchByUID() As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim arParms() As SqlParameter = New SqlParameter(2) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            'arParms(0) = New SqlParameter("@UID", SqlDbType.Int)
            'arParms(0).Value = CInt(HttpContext.Current.Session("UserID").ToString)

            'Dim s As String = CInt(HttpContext.Current.Session("UserID").ToString)

            'arParms(1) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            'arParms(1).Value = id

            arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("AccessLevel")

            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_GetBranchByUID", arParms)
            Return ds.Tables(0) 'Rpt_GetBranchByUID
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function RptFillBranchCenter() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_BranchMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function FillBranchCenter() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GetBranchByUID", arParms)
        Return ds.Tables(0)
    End Function
End Class
