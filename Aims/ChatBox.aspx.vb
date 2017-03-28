Imports System.Data.SqlClient

Partial Public Class ChatBox
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As Integer = Session("ID")
        msgPanel.Style.Add("overflow-y", "scroll")

        ViewState("uid") = Request.QueryString("uid")
        hidChatId.Value = Request.QueryString("cid")
        ViewState("vwChatId") = Request.QueryString("cid")
        Session("K") = ViewState("vwChatId").ToString()
    End Sub

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSend.Click

        If ViewState("vwChatId") = Nothing Then
            ViewState("vwChatId") = Request.QueryString("cid")

        End If
        SendMessage(txtMsg.Text)
        txtMsg.Text = ""
        txtMsg.Focus()

    End Sub

    Private Sub SendMessage(ByVal msg As String)

        Dim con As SqlConnection = New SqlConnection( _
                ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        con.Open()
        Dim comm As SqlCommand = New SqlCommand("stp_SendMessage", con)
        comm.CommandType = CommandType.StoredProcedure

        Dim words As String() = ViewState("vwChatId").ToString().Split(New Char() {"_"c})
        Dim temp As Integer = words(0)
        Dim Rec As String
        If (temp.ToString.Equals(Session("ID").ToString)) Then
            Rec = words(1)
        Else
            Rec = words(0)
        End If
        Dim paramSender As SqlParameter = New SqlParameter( _
            "@Sender", SqlDbType.VarChar, 10)
        paramSender.Value = Session("ID")
        'HttpContext.Current.User.Identity.Name
        comm.Parameters.Add(paramSender)

        Dim paramRec As SqlParameter = New SqlParameter( _
            "@Reciever", SqlDbType.VarChar, 10)
        paramRec.Value = Rec
        comm.Parameters.Add(paramRec)

        Dim paramMsg As SqlParameter = New SqlParameter( _
           "@Msg", SqlDbType.VarChar, 4000)
        paramMsg.Value = msg
        comm.Parameters.Add(paramMsg)

        Dim paramChatId As SqlParameter = New SqlParameter( _
         "@ChatId", SqlDbType.VarChar, 100)
        paramChatId.Value = ViewState("vwChatId").ToString()
        comm.Parameters.Add(paramChatId)

        comm.ExecuteNonQuery()
        con.Close()

    End Sub

    <System.Web.Services.WebMethod()> _
    Public Shared Sub Logout()
        'Dim con As SqlConnection = New SqlConnection( _
        '     ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        'con.Open()
        'Dim comm As SqlCommand = New SqlCommand("proc_ClearBox", con)
        'comm.CommandType = CommandType.StoredProcedure
        'Dim paramSender As SqlParameter = New SqlParameter( _
        '    "@ID", SqlDbType.VarChar, 100)
        'paramSender.Value = HttpContext.Current.Session("k")
        'comm.Parameters.Add(paramSender)
        'comm.ExecuteNonQuery()


    End Sub

End Class