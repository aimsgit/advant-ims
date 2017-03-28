Imports System.Data
Imports System.Data.SqlClient

Partial Public Class GetChatMsg
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Clear()
        Response.ClearContent()
        Response.AddHeader("Cache-Control", "no-cache, must-revalidate")

        Dim ds As DataSet = GetMessage(Session("ID"))
        'HttpContext.Current.User.Identity.Name)
        Dim strMsg As String = ""
        If ds.Tables.Count > 0 Then

            If ds.Tables(0).Rows.Count > 0 Then

                For Each dr As DataRow In ds.Tables(0).Rows
                    strMsg = ""
                    If strMsg.Length > 0 Then
                        strMsg += "#"
                    End If
                    strMsg += dr("Snid").ToString() + "&"
                    strMsg += dr("ChatId").ToString() + "&"
                    strMsg += dr("Msg").ToString().Replace("&", "_@AMP__").Replace("#", "_@HASH__")
                Next

            End If
        End If
        Session("Message") = strMsg
        Response.Write(Session("Message").ToString)

        Response.End()
    End Sub

    Private Function GetMessage(ByVal strUid As String) As DataSet
        Dim dsMsgs As DataSet = New DataSet()
        Dim con As SqlConnection = New SqlConnection( _
                ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        con.Open()
        Dim comm As SqlCommand = New SqlCommand("stp_GetMessage", con)
        comm.CommandType = CommandType.StoredProcedure
        Dim paramSender As SqlParameter = New SqlParameter( _
            "@Uid", SqlDbType.VarChar, 10)
        paramSender.Value = Session("ID")
        'HttpContext.Current.User.Identity.Name
        comm.Parameters.Add(paramSender)

        If (Request.QueryString("cid") <> Nothing) Then
            Dim paramChatId As SqlParameter = New SqlParameter( _
                             "@ChatId", SqlDbType.VarChar, 100)
            paramChatId.Value = Request.QueryString("cid")
            comm.Parameters.Add(paramChatId)
        End If

        Dim da As SqlDataAdapter = New SqlDataAdapter(comm)
        da.Fill(dsMsgs)

        con.Close()
        Return dsMsgs
    End Function

End Class