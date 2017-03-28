Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class InstituteDB
    Shared Function GetInstitute(ByVal id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        If id = 0 Then
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT * FROM View_GetInstitute")
        Else
            Dim arParms As SqlParameter = New SqlParameter("@id", SqlDbType.Int)
            arParms.Value = id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetInstituteDetailsByInstID", arParms)
        End If
        Return ds
    End Function
    Shared Function Insert(ByVal i As Institute) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.Char, i.Name.Length)
        arParms(0).Value = i.Name

        arParms(1) = New SqlParameter("@code", SqlDbType.Char, i.InstituteCode.Length)
        arParms(1).Value = i.InstituteCode

        arParms(2) = New SqlParameter("@city", SqlDbType.Char, i.City.Length)
        arParms(2).Value = i.City

        arParms(3) = New SqlParameter("@state", SqlDbType.Char, i.State.Length)
        arParms(3).Value = i.State

        arParms(4) = New SqlParameter("@Country", SqlDbType.Char, i.Country.Length)
        arParms(4).Value = i.Country

        arParms(5) = New SqlParameter("@ContactNo", SqlDbType.Char, i.ContactNo.Length)
        arParms(5).Value = i.ContactNo

        arParms(6) = New SqlParameter("@ContactPerson", SqlDbType.Char, i.ContactPerson.Length)
        arParms(6).Value = i.ContactPerson

        arParms(7) = New SqlParameter("@address", SqlDbType.Char, i.Address.Length)
        arParms(7).Value = i.Address

        arParms(8) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("BranchCode")

        arParms(9) = New SqlParameter("@empid", SqlDbType.Int)
        arParms(9).Value = HttpContext.Current.Session("UserID")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveInstituteDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function Update(ByVal i As Institute) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
       
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(11) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.Char, i.Name.Length)
        arParms(0).Value = i.Name

        arParms(1) = New SqlParameter("@code", SqlDbType.Char, i.InstituteCode.Length)
        arParms(1).Value = i.InstituteCode

        arParms(2) = New SqlParameter("@city", SqlDbType.Char, i.City.Length)
        arParms(2).Value = i.City

        arParms(3) = New SqlParameter("@state", SqlDbType.Char, i.State.Length)
        arParms(3).Value = i.State

        arParms(4) = New SqlParameter("@Country", SqlDbType.Char, i.Country.Length)
        arParms(4).Value = i.Country

        arParms(5) = New SqlParameter("@ContactNo", SqlDbType.Char, i.ContactNo.Length)
        arParms(5).Value = i.ContactNo

        arParms(6) = New SqlParameter("@ContactPerson", SqlDbType.Char, i.ContactPerson.Length)
        arParms(6).Value = i.ContactPerson

        arParms(7) = New SqlParameter("@address", SqlDbType.Char, i.Address.Length)
        arParms(7).Value = i.Address

        arParms(8) = New SqlParameter("@id", SqlDbType.Int)
        arParms(8).Value = i.Id

        arParms(9) = New SqlParameter("@branch", SqlDbType.Int)
        arParms(9).Value = HttpContext.Current.Session("BranchID")

        arParms(10) = New SqlParameter("@institute", SqlDbType.Int)
        arParms(10).Value = HttpContext.Current.Session("InstituteID")

        arParms(11) = New SqlParameter("@empid", SqlDbType.Int)
        arParms(11).Value = HttpContext.Current.Session("UserID")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateInstituteDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function ChangeFlag(ByVal Id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteInstituteDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GVComboUser(ByVal id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
      
        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT Institute_ID,InstituteName FROM View_GetInstitute")
        Return ds
    End Function
    Shared Function FillAllBranchTypes() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT   Institute_ID, InstituteName FROM VGetAllBranchTypes")
        Return ds
    End Function
    Shared Function FillBranchTypesByUID(ByVal UserID As Int64) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@UID", SqlDbType.Int)
        arParms(0).Value = UserID
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_GetTypesByUID", arParms)
        Return ds
    End Function
    Shared Function FillZoneCombo(ByVal id As Int64) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT  ZoneID, ZoneName FROM vFillZoneCombo Where HOID=" & id)
        Return ds
    End Function
    Shared Function FillROCombo(ByVal Hoid As Long, ByVal id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@RO_ID", SqlDbType.Int)
        arParms(0).Value = id
        arParms(1) = New SqlParameter("@HO_ID", SqlDbType.Int)
        arParms(1).Value = Hoid
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SP_FillROCombo", arParms)
        Return ds
    End Function
End Class
