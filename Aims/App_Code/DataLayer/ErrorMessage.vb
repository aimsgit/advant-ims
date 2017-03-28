Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class ErrorMessage
    Shared Function GetErrMsg() As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim objDbConnection As New SqlConnection(connectionString)
        Dim strQuery As String = "select Msg_Name from Error_Messages ORDER BY Msg_id"
        Dim objDataAdapter As New SqlDataAdapter(strQuery, objDbConnection)
        Dim objDataSet As New DataSet
        objDataAdapter.Fill(objDataSet, "Error_Messages")
        Return objDataSet
    End Function
End Class
