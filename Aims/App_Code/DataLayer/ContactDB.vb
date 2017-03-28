Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class ContactDB
    Shared Function GVDetails(ByVal contactId As Integer) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms As SqlParameter
        arParms = New SqlParameter("@ContactId", SqlDbType.Int)

        arParms.Value = contactId
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetContactDetails]", arParms)

        Return ds
    End Function
    Public Shared Function Insert(ByVal con As Contact) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@ContactId", SqlDbType.Int)
        arParms(0).Value = con.ContactId

        arParms(1) = New SqlParameter("@FirstName", SqlDbType.VarChar, 100)
        arParms(1).Value = con.FirstName

        arParms(2) = New SqlParameter("@LastName", SqlDbType.VarChar, 100)
        arParms(2).Value = con.LastName

        arParms(3) = New SqlParameter("@Address", SqlDbType.VarChar, 250)
        arParms(3).Value = con.Address

        arParms(4) = New SqlParameter("@City", SqlDbType.VarChar, 50)
        arParms(4).Value = con.City

        arParms(5) = New SqlParameter("@State", SqlDbType.VarChar, 50)
        arParms(5).Value = con.State

        arParms(6) = New SqlParameter("@PostalCode", SqlDbType.VarChar, 50)
        arParms(6).Value = con.PostalCode

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_SaveContacts]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Delete(ByVal Id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms As SqlParameter
        arParms = New SqlParameter("@ContactId", SqlDbType.Int, 10)
        arParms.Value = Id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteContacts", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
End Class
