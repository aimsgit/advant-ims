Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class ExperienceDB
    Shared Function GetExperience2(ByVal scode As Integer, ByVal id As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim dbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection(connectionString)
        'Dim queryString As String
        'queryString = "SELECT ExpId,Std_code,NameofOrganisation,NoOfYears,Natureofjob  FROM(ExperienceDetails) WHERE (((Std_code)=@code))"
        'Dim dbCommand As System.Data.IDbCommand = New System.Data.OleDb.OleDbCommand
        'dbCommand.CommandText = queryString
        'dbCommand.Connection = dbConnection

        'Dim dbParam_id As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_id.ParameterName = "@code"
        'dbParam_id.Value = scode
        'dbParam_id.DbType = System.Data.DbType.String
        'dbCommand.Parameters.Add(dbParam_id)

        'Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
        'dataAdapter.SelectCommand = dbCommand
        'Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        'dataAdapter.Fill(dataSet)
        'Return dataSet
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@std_code", SqlDbType.Int)
        arParms(0).Value = scode
        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = id
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetExperienceDetails", arParms)

        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal exp As Experience) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim dbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection
        'Dim querystring As String = "INSERT INTO ExperienceDetails (Std_code,NameofOrganisation,NoOfYears,Natureofjob)VALUES(@code,@name,@NOY,@NOJ)"

        'Dim dbCommand As System.Data.IDbCommand = New System.Data.OleDb.OleDbCommand
        'dbConnection.ConnectionString = connectionString
        'dbCommand.CommandText = querystring
        'dbCommand.Connection = dbConnection

        'Dim dbParam_code As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_code.ParameterName = "@code"
        'dbParam_code.Value = exp.Std_code
        'dbParam_code.DbType = System.Data.DbType.[String]
        'dbCommand.Parameters.Add(dbParam_code)


        'Dim dbParam_name As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_name.ParameterName = "@name"
        'dbParam_name.Value = exp.Name
        'dbParam_name.DbType = System.Data.DbType.[String]
        'dbCommand.Parameters.Add(dbParam_name)


        'Dim dbParam_bou As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_bou.ParameterName = "@NOY"
        'dbParam_bou.Value = exp.NoOfYears
        'dbParam_bou.DbType = System.Data.DbType.[String]
        'dbCommand.Parameters.Add(dbParam_bou)

        'Dim dbParam_marks As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_marks.ParameterName = "@NOJ"
        'dbParam_marks.Value = exp.Natureofjob
        'dbParam_marks.DbType = System.Data.DbType.[String]
        'dbCommand.Parameters.Add(dbParam_marks)

        'Dim rowsAffected As Integer = 0
        'dbConnection.Open()
        'Try
        '    rowsAffected = dbCommand.ExecuteNonQuery
        'Finally
        '    dbConnection.Close()
        'End Try
        'Return rowsAffected


        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}

        arParms(0) = New SqlParameter("@expId", SqlDbType.Int)
        arParms(0).Value = exp.ExpId

        arParms(1) = New SqlParameter("@code", SqlDbType.Int)
        arParms(1).Value = exp.Std_code

        arParms(2) = New SqlParameter("@Organization", SqlDbType.NVarChar, 50)
        arParms(2).Value = exp.Name

        arParms(3) = New SqlParameter("@ExperienceTypeID", SqlDbType.Int)
        arParms(3).Value = exp.ExperienceType

       

        arParms(4) = New SqlParameter("@Description", SqlDbType.NVarChar, 100)
        arParms(4).Value = exp.Natureofjob

        If exp.FromDate = Nothing Then
            arParms(5) = New SqlParameter("@FromDate", SqlDbType.VarChar)
            arParms(5).Value = DBNull.Value
        Else
            arParms(5) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            arParms(5).Value = exp.FromDate
        End If

        If exp.ToDate = Nothing Then
            arParms(6) = New SqlParameter("@ToDate", SqlDbType.VarChar)
            arParms(6).Value = DBNull.Value
        Else
            arParms(6) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            arParms(6).Value = exp.ToDate
        End If
        arParms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(7).Value = exp.RemarksE

        arParms(8) = New SqlParameter("@Certificate", SqlDbType.VarChar, 250)
        arParms(8).Value = exp.Certificate


        arParms(9) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("EmpCode")

        arParms(10) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("UserCode")

        arParms(11) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveExperienceDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    'Shared Function Update(ByVal exp As Experience) As Integer
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
    '    Dim dbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection
    '    ' Dim querystring As String = "UPDATE ExperienceDetails SET Std_code=@code,NameofOrganisation=@name,NoOfYears=@NOY,Natureofjob=@NOJ WHERE (((ExperienceDetails.ExpId)=@id))"
    '    Dim querystring As String = "UPDATE ExperienceDetails SET NameofOrganisation=@name,NoOfYears=@NOY,Natureofjob=@NOJ WHERE (((ExperienceDetails.ExpId)=@id))"
    '    Dim dbCommand As System.Data.IDbCommand = New System.Data.OleDb.OleDbCommand
    '    dbConnection.ConnectionString = connectionString
    '    dbCommand.CommandText = querystring
    '    dbCommand.Connection = dbConnection

    '    'Dim dbParam_code As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    'dbParam_code.ParameterName = "@code"
    '    'dbParam_code.Value = exp.Std_code
    '    'dbParam_code.DbType = System.Data.DbType.[String]
    '    'dbCommand.Parameters.Add(dbParam_code)


    '    Dim dbParam_name As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    dbParam_name.ParameterName = "@name"
    '    dbParam_name.Value = exp.Name
    '    dbParam_name.DbType = System.Data.DbType.[String]
    '    dbCommand.Parameters.Add(dbParam_name)


    '    Dim dbParam_bou As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    dbParam_bou.ParameterName = "@NOY"
    '    dbParam_bou.Value = exp.NoOfYears
    '    dbParam_bou.DbType = System.Data.DbType.[String]
    '    dbCommand.Parameters.Add(dbParam_bou)

    '    Dim dbParam_marks As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    dbParam_marks.ParameterName = "@NOJ"
    '    dbParam_marks.Value = exp.Natureofjob
    '    dbParam_marks.DbType = System.Data.DbType.[String]
    '    dbCommand.Parameters.Add(dbParam_marks)

    '    Dim dbParam_id As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    dbParam_id.ParameterName = "@id"
    '    dbParam_id.Value = exp.ExpId
    '    dbParam_id.DbType = System.Data.DbType.[Int64]
    '    dbCommand.Parameters.Add(dbParam_id)


    '    Dim rowsAffected As Integer = 0
    '    dbConnection.Open()
    '    Try
    '        rowsAffected = dbCommand.ExecuteNonQuery
    '    Finally
    '        dbConnection.Close()
    '    End Try
    '    Return rowsAffected
    'End Function
    Shared Function ChangeFlag(ByVal ExpId As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim dbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection
        'Dim querystring As String = "DELETE ExperienceDetails.*, ExperienceDetails.ExpId FROM(ExperienceDetails) WHERE (((ExperienceDetails.ExpId)=@id))"

        ''Dim querystring As String = "UPDATE QualificationMaster SET [Del_Flag]=-1 WHERE (((QualificationMaster.Qualification_ID)=@id))"
        'Dim dbCommand As System.Data.IDbCommand = New System.Data.OleDb.OleDbCommand
        'dbConnection.ConnectionString = connectionString
        'dbCommand.CommandText = querystring
        'dbCommand.Connection = dbConnection

        'Dim dbParam_id As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_id.ParameterName = "@id"
        'dbParam_id.Value = ExpId
        'dbParam_id.DbType = System.Data.DbType.[Int64]
        'dbCommand.Parameters.Add(dbParam_id)

        'Dim rowsAffected As Integer = 0
        'dbConnection.Open()
        'Try
        '    rowsAffected = dbCommand.ExecuteNonQuery
        'Finally
        '    dbConnection.Close()
        'End Try
        'Return rowsAffected


        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@expId", SqlDbType.Int)
        arParms(0).Value = ExpId
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_DelExpDetails]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
End Class
