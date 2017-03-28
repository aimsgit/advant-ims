Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLNoticeBoard
    Public Function GetNotice(ByVal el As ELCommunication) As DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet
            Dim parms() As SqlParameter = New SqlParameter(4) {}
            parms(0) = New SqlParameter("@Date", SqlDbType.DateTime)
            parms(0).Value = el.date1
            parms(1) = New SqlParameter("@NameID", SqlDbType.VarChar)
            parms(1).Value = el.ID
            parms(2) = New SqlParameter("@GroupType", SqlDbType.VarChar)
            parms(2).Value = el.GroupType
            parms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            parms(3).Value = el.toDate
            parms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            parms(4).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetNoticeBoard", parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function BatchComboD() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim parms() As SqlParameter = New SqlParameter(1) {}

        parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        parms(0).Value = HttpContext.Current.Session("BranchCode")
        parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        parms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_OnlyBatchCombo", parms)
        Return ds.Tables(0)
    End Function

End Class
