Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLPurchaseRequisition
    Shared Function GetRecord(ByVal b As ELPurchaseRequisition) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = b.id
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        para(3) = New SqlParameter("@PurchaseReq_No", SqlDbType.NVarChar, 50)
        para(3).Value = b.PurchaseReq_No
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Mfg_GetPurchaserequisition", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)


    End Function
    Public Function PuurchaseRequisitionNo() As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_PuurchaseRequisitionNo", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function PuurchaseRequisitionNo1() As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_PuurchaseRequisitionNo1", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetPurchaseRequisition(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal PurchaseReqNo As String) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(4) {}
        para(0) = New SqlParameter("@Startdate", SqlDbType.DateTime)
        para(0).Value = StartDate
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        para(3) = New SqlParameter("@PurchaseReq_No", SqlDbType.NVarChar, 50)
        para(3).Value = PurchaseReqNo
        para(4) = New SqlParameter("@Enddate", SqlDbType.DateTime)
        para(4).Value = EndDate
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Mfg_Rpt_PurchaseRequisition", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)


    End Function
    Shared Function GetRecord1(ByVal b As ELPurchaseRequisition) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = b.id
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Mfg_GetPurchaserequisition1", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)


    End Function
    Shared Function checkSubmit(ByVal b As ELPurchaseRequisition) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = b.id
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_CheckSubmit", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)


    End Function
    Shared Function Insert(ByVal b As ELPurchaseRequisition) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@PurchaseReq_No", SqlDbType.NVarChar, 50)
        arParms(0).Value = b.PurchaseReq_No

        arParms(1) = New SqlParameter("@Product_Id", SqlDbType.Int)
        arParms(1).Value = b.Product_Id

        arParms(2) = New SqlParameter("@Unit_Id", SqlDbType.NVarChar, 50)
        arParms(2).Value = b.Unit_Id

        arParms(3) = New SqlParameter("@Quantity", SqlDbType.Int)
        arParms(3).Value = b.Quantity

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertPurchaseRequisition", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateRecord(ByVal b As ELPurchaseRequisition) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        
        arParms(0) = New SqlParameter("@PurchaseReq_No", SqlDbType.NVarChar, 50)
        arParms(0).Value = b.PurchaseReq_No

        arParms(1) = New SqlParameter("@Product_Id", SqlDbType.Int)
        arParms(1).Value = b.Product_Id

        arParms(2) = New SqlParameter("@Unit_Id", SqlDbType.NVarChar, 50)
        arParms(2).Value = b.Unit_Id

        arParms(3) = New SqlParameter("@Quantity", SqlDbType.Int)
        arParms(3).Value = b.Quantity

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@id", SqlDbType.Int)
        arParms(7).Value = b.id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdatePurchaseRequisition", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function getProductforPurchaseReq(ByVal el As ELPurchaseRequisition) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@Purchase_Req_No", SqlDbType.VarChar, 15)
        arParms(2).Value = el.PurchaseReq_No

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProductforPurchaseRequisition", arParms)

        Return ds.Tables(0)

    End Function
    Shared Function Insert1(ByVal b As ELPurchaseRequisition) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@PurchaseReq_No", SqlDbType.NVarChar, 50)
        arParms(0).Value = b.PurchaseReq_No

        arParms(1) = New SqlParameter("@Reqdate", SqlDbType.DateTime)
        arParms(1).Value = b.Reqdate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        arParms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@Status", SqlDbType.VarChar, 50)
        arParms(5).Value = b.Status

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertPurchaseRequisition1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateRecord1(ByVal b As ELPurchaseRequisition) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}


        arParms(0) = New SqlParameter("@PurchaseReq_No", SqlDbType.NVarChar, 50)
        arParms(0).Value = b.PurchaseReq_No

        arParms(1) = New SqlParameter("@Req_date", SqlDbType.DateTime)
        arParms(1).Value = b.Reqdate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        arParms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@Status", SqlDbType.VarChar, 50)
        arParms(5).Value = b.Status

        arParms(6) = New SqlParameter("@id", SqlDbType.Int)
        arParms(6).Value = b.id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdatePurchaseRequisition1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function DeleteRecord(ByVal id As Long) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = id
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Mfg_DeletePurchaseRequisition", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function GetUnit(ByVal EL As ELPurchaseRequisition) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}
            Parms(0) = New SqlParameter("@Product_Id", SqlDbType.Int)
            Parms(0).Value = EL.Product_Id

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetUnit", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DeleteRecord1(ByVal id As Long) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = id
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Mfg_DeletePurchaseRequisition1", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function PostRequest(ByVal Id As String) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.VarChar, 500)
        arParms(0).Value = Id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_PostPurchaseRequisition", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetPONo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SelectPurchaseRequisition", arParms)
        Return ds.Tables(0)
    End Function
End Class
