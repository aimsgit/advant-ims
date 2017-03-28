Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLBranchType
    Shared Function GetBranchType(ByVal id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        If id = 0 Then
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT * FROM View_GetBranchType")
        Else
            Dim arParms As SqlParameter = New SqlParameter("@id", SqlDbType.Int)
            arParms.Value = id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBranchTypeByBrTypeID", arParms)
        End If
        Return ds
    End Function
    Shared Function Insert(ByVal i As BranchType) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.Char, i.Name.Length)
        arParms(0).Value = i.Name

        'arParms(1) = New SqlParameter("@code", SqlDbType.Char, i.BranchTypeCode.Length)
        'arParms(1).Value = i.BranchTypeCode

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveBranchType", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function Update(ByVal i As BranchType) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@name", SqlDbType.Char, i.Name.Length)
        arParms(0).Value = i.Name

        'arParms(1) = New SqlParameter("@code", SqlDbType.Char, i.BranchTypeCode.Length)
        'arParms(1).Value = i.BranchTypeCode

        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = i.Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateBranchType", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    'Shared Function ChangeFlag(ByVal Id As Long) As Integer
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim rowsAffected As Integer = 0

    '    Dim arParms() As SqlParameter = New SqlParameter(0) {}

    '    arParms(0) = New SqlParameter("@id", SqlDbType.Int)
    '    arParms(0).Value = Id

    '    Try
    '        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteBranchType", arParms)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try

    '    Return rowsAffected
    'End Function
    Shared Function GVComboUser(ByVal code As String) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT BranchTypeCode,BranchTypeName FROM View_GetBranchType")
        Return ds
    End Function
    Shared Function FillAllBranchTypes() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT BranchTypeCode, BranchTypeName FROM VGetAllBranchTypes")
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
