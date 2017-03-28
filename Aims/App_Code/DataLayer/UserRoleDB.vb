'Imports Microsoft.VisualBasic

Public Class UserRoleDB
    'Shared Function UserRole(ByVal UserRoleID As Long) As System.Data.DataSet
    '    Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
    '    Dim dbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection(connectionstring)
    '    Dim querystring As String
    '    If UserRoleID = 0 Then
    '        querystring = "Select UserRoleCreation.UserRoleID,UserRoleCreation.UserRole, UserRoleCreation.Access_Permission_Forms from UserRoleCreation where Del_Flag=0 order by UserRole"
    '    Else
    '        querystring = "Select  UserRoleCreation.UserRoleID,UserRoleCreation.UserRole, UserRoleCreation.Access_Permission_Forms from UserRoleCreation where Del_Flag=0 and UserRoleID=@UserRoleID order by UserRole"
    '    End If

    '    Dim dbcommand As System.Data.IDbCommand = New System.Data.OleDb.OleDbCommand
    '    dbcommand.CommandText = querystring
    '    dbcommand.Connection = dbConnection
    '    If Not (UserRoleID = 0) Then
    '        Dim db_UserRole_Param As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '        db_UserRole_Param.ParameterName = "@UserRoleID"
    '        db_UserRole_Param.Value = UserRoleID
    '        db_UserRole_Param.DbType = DbType.Int64
    '        dbcommand.Parameters.Add(db_UserRole_Param)
    '    End If
    '    Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
    '    dataAdapter.SelectCommand = dbcommand
    '    Dim dataSet As System.Data.DataSet = New System.Data.DataSet
    '    dataAdapter.Fill(dataSet)
    '    Return dataSet

    'End Function
    'Shared Function GVComboUser(ByVal id As Long) As System.Data.DataSet
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
    '    Dim dbConnection As IDbConnection = New OleDb.OleDbConnection
    '    Dim qryString As String
    '    If (id = 0) Then
    '        qryString = "Select  UserRoleCreation.UserRoleID,UserRoleCreation.UserRole  from UserRoleCreation where Del_Flag=0   order by UserRole"

    '    Else
    '        qryString = "Select  UserRoleCreation.UserRoleID,UserRoleCreation.UserRole  from UserRoleCreation where Del_Flag=0 and UserRoleID=@UserRoleID order by UserRole"

    '    End If
    '    Dim dbCommand As IDbCommand = New OleDb.OleDbCommand
    '    dbConnection.ConnectionString = connectionString
    '    dbCommand.CommandText = qryString
    '    dbCommand.Connection = dbConnection
    '    Dim dataAdapter As IDbDataAdapter = New OleDb.OleDbDataAdapter
    '    dataAdapter.SelectCommand = dbCommand
    '    Dim dataSet As DataSet = New DataSet
    '    dataAdapter.Fill(dataSet)
    '    Return dataSet
    'End Function
End Class
