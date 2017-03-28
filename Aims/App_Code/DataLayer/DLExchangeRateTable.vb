Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLExchangeRateTable
    Shared Function Insert(ByVal EL As ELExchangeRateTable) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@Currency_Name", SqlDbType.VarChar, 100)
        arParms(0).Value = EL.CName

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@Symbol", SqlDbType.VarChar, 50)
        arParms(4).Value = EL.CSymbol

        arParms(5) = New SqlParameter("@BRate", SqlDbType.Float)
        arParms(5).Value = EL.BRate

        arParms(6) = New SqlParameter("@SRate", SqlDbType.Float)
        arParms(6).Value = EL.SRate

        arParms(7) = New SqlParameter("@Currency_One", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.Cone

        arParms(8) = New SqlParameter("@Currency_Two", SqlDbType.VarChar, 50)
        arParms(8).Value = EL.Ctwo
        arParms(9) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("Office")



        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertExchangeRate Table", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetData(ByVal EL As ELExchangeRateTable) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = EL.id

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetExchangeRateTable", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal EL As ELExchangeRateTable) As Long
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@Currency_Name", SqlDbType.VarChar, 100)
        arParms(0).Value = EL.CName

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@Symbol", SqlDbType.VarChar, 50)
        arParms(4).Value = EL.CSymbol

        arParms(5) = New SqlParameter("@BRate", SqlDbType.Float)
        arParms(5).Value = EL.BRate

        arParms(6) = New SqlParameter("@SRate", SqlDbType.Float)
        arParms(6).Value = EL.SRate

        arParms(7) = New SqlParameter("@Currency_One", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.Cone

        arParms(8) = New SqlParameter("@Currency_Two", SqlDbType.VarChar, 50)
        arParms(8).Value = EL.Ctwo

        arParms(9) = New SqlParameter("@id", SqlDbType.Int)
        arParms(9).Value = EL.Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateExchangeRateTable", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal EL As ELExchangeRateTable) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.Id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteExchangeRateTable", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetDuplicateType(ByVal El As ELExchangeRateTable) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@csymbol", SqlDbType.VarChar, 50)
        arParms(1).Value = El.CSymbol

        arParms(2) = New SqlParameter("@Cname", SqlDbType.VarChar, 100)
        arParms(2).Value = El.CName

        arParms(3) = New SqlParameter("@id", SqlDbType.Int)
        arParms(3).Value = El.Id


        

      
        Try

            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Mfg_DuplicateExchangeRateTable", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
