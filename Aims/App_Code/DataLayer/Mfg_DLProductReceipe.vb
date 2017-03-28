Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLProductReceipe
    Public Function InsertProductReceipe(ByVal EL As Mfg_ELProductReceipeMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@RM", SqlDbType.Int)
        arParms(0).Value = EL.RMPart
        arParms(1) = New SqlParameter("@Unit", SqlDbType.Int)
        arParms(1).Value = EL.Unit
        arParms(2) = New SqlParameter("@Conv", SqlDbType.Float)
        arParms(2).Value = EL.CF
        arParms(3) = New SqlParameter("@Quantity", SqlDbType.Float)
        arParms(3).Value = EL.Quantity
        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")
        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")
        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")
        arParms(7) = New SqlParameter("@Sequence", SqlDbType.Float)
        arParms(7).Value = EL.Sequence
        
        arParms(8) = New SqlParameter("@wastage", SqlDbType.Float)
        arParms(8).Value = EL.Wastage


        arParms(9) = New SqlParameter("@Product", SqlDbType.Int)
        arParms(9).Value = EL.Product

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertProductReceipe", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function UpdateProductReceipe(ByVal EL As Mfg_ELProductReceipeMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@RM", SqlDbType.Int)
        arParms(0).Value = EL.RMPart
        arParms(1) = New SqlParameter("@Unit", SqlDbType.Int)
        arParms(1).Value = EL.Unit
        arParms(2) = New SqlParameter("@Conv", SqlDbType.Float)
        arParms(2).Value = EL.CF
        arParms(3) = New SqlParameter("@Quantity", SqlDbType.Float)
        arParms(3).Value = EL.Quantity
        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")
        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")
        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")
        arParms(7) = New SqlParameter("@Sequence", SqlDbType.Float)
        arParms(7).Value = EL.Sequence

      

        arParms(8) = New SqlParameter("@wastage", SqlDbType.Float)
        arParms(8).Value = EL.Wastage

        arParms(9) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(9).Value = EL.Id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateProductReceipe", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function DeteteProductReceipe(ByVal EL As Mfg_ELProductReceipeMaster) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.Id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteRecepeMaster", arParms)
        Return rowsaffected
    End Function
    Public Function getProductReceipe(ByVal EL As Mfg_ELProductReceipeMaster) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.Id

        arParms(3) = New SqlParameter("@Product", SqlDbType.Int)
        arParms(3).Value = EL.Product

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProductReceipeDetails", arParms)
        Return ds.Tables(0)
    End Function
    Public Function getProducyDetailsReceipe(ByVal EL As Mfg_ELProductReceipeMaster) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.Id

        arParms(3) = New SqlParameter("@productid", SqlDbType.Int)
        arParms(3).Value = EL.Product

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProductReceipeDetailsView", arParms)
        Return ds.Tables(0)
    End Function

End Class
