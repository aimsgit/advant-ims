Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class MediumDB
    Dim md As New Medium
    Shared Function GetMedium(ByVal id As Int64) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            If id = 0 Then

                Dim arParms() As SqlParameter = New SqlParameter(1) {}
                arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
                arParms(0).Value = HttpContext.Current.Session("Office")
                arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
                arParms(1).Value = HttpContext.Current.Session("BranchCode")
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMediumDetails", arParms)

            Else
                Dim arParms() As SqlParameter = New SqlParameter(2) {}
                arParms(0) = New SqlParameter("@MediumID", SqlDbType.Int)
                arParms(0).Value = id
                arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
                arParms(1).Value = HttpContext.Current.Session("Office")
                arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
                arParms(2).Value = HttpContext.Current.Session("BranchCode")
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMediumDetailsByID", arParms)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function

    Shared Function Insert(ByVal mediumname As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@MediumName", SqlDbType.NVarChar, 50)
        arParms(0).Value = mediumname
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")
        arParms(4) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("Office")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_SaveMedium", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal md As Medium) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@Medium_Id", SqlDbType.Char, md.Name.Length)
        arParms(0).Value = md.Id
        arParms(1) = New SqlParameter("@MediumName", SqlDbType.NVarChar, md.Name.Length)
        arParms(1).Value = md.Name
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")
        arParms(4) = New SqlParameter("@BranchCode ", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateMediumDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function ChangeFlag(ByVal md As Medium) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim arParms As SqlParameter() = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Medium_Id", SqlDbType.Char, 100)
        arParms(0).Value = md.Id
        arParms(1) = New SqlParameter("@BranchCode ", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteMedium", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function

    'Shared Function GetMedium(ByVal id As Long) As System.Data.DataSet
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
    '    Dim dbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection(connectionString)
    '    Dim queryString As String
    '    If id = 0 Then
    '        queryString = "SELECT MediumMaster.Medium_ID,MediumMaster.MediumName FROM(MediumMaster) WHERE (((MediumMaster.Del_Flag)=0)) order by MediumMaster.MediumName"
    '    Else
    '        queryString = "SELECT MediumMaster.Medium_ID,MediumMaster.MediumName FROM(MediumMaster) WHERE (((MediumMaster.Medium_ID)=@id) AND((MediumMaster.Del_Flag)=0)) order by MediumMaster.MediumName"
    '    End If
    '    Dim dbCommand As System.Data.IDbCommand = New System.Data.OleDb.OleDbCommand

    '    If Not (id = 0) Then
    '        Dim dbParam_id As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
    '        dbParam_id.ParameterName = "@id"
    '        dbParam_id.Value = id
    '        dbParam_id.DbType = System.Data.DbType.Int64
    '        dbCommand.Parameters.Add(dbParam_id)
    '    End If
    '    dbCommand.CommandText = queryString
    '    dbCommand.Connection = dbConnection
    '    Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
    '    dataAdapter.SelectCommand = dbCommand
    '    Dim dataSet As System.Data.DataSet = New System.Data.DataSet
    '    dataAdapter.Fill(dataSet)
    '    Return dataSet
    'End Function
    Shared Function GetMediumRpt(ByVal md As Medium) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")
            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")
            arParms(2) = New SqlParameter("@Medium_ID", SqlDbType.Int)
            arParms(2).Value = md.Id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMediumDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Public Function GetDuplicateMediumType(ByVal md As Medium) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@MediumName", SqlDbType.NVarChar, 50)
        para(1).Value = md.Name

        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = md.Id
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDuplicateMediumNameType", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
