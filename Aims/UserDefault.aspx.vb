Imports System.Data.SqlClient
Imports System.Data

Partial Public Class UserDefault
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        lblUser.Text = Session("Name")
        Dim ID As Integer = Integer.Parse(Session("ID"))


        'Dim ds As DataSet = New DataSet()
        'Dim con As SqlConnection = New SqlConnection( _
        '    ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        'con.Open()
        'Dim comm As SqlCommand = New SqlCommand("proc_getOnlineUser", con)
        'comm.CommandType = CommandType.StoredProcedure
        'Dim paramSender As SqlParameter = New SqlParameter( _
        '    "@ID", SqlDbType.Int)
        'paramSender.Value = Session("ID")
        'comm.Parameters.Add(paramSender)
        'Dim da As SqlDataAdapter = New SqlDataAdapter(comm)
        'da.Fill(ds)
        'Repeater1.DataSource = ds
        'Repeater1.DataBind()


        hidCurrentUser.Value = Session("ID")
        'HttpContext.Current.User.Identity.Name
        'dsrcWebChat.SelectCommand = "select * from OnlineUsers where Del_Flag = 'N' and UserID = " + ID + ""
        'dsrcWebChat.ConnectionString = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    End Sub

    Private Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim con As SqlConnection = New SqlConnection( _
            ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        con.Open()
        Dim comm As SqlCommand = New SqlCommand("stp_Message", con)
        comm.CommandType = CommandType.StoredProcedure
        Dim paramSender As SqlParameter = New SqlParameter( _
            "@Sender", SqlDbType.Int)
        paramSender.Value = Session("ID")
        comm.Parameters.Add(paramSender)
        comm.ExecuteNonQuery()


        con = New SqlConnection( _
           ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        con.Open()
        comm = New SqlCommand("Proc_DeleteUser", con)
        comm.CommandType = CommandType.StoredProcedure
        paramSender = New SqlParameter( _
            "@ID", SqlDbType.Int)
        paramSender.Value = HttpContext.Current.Session("ID")
        comm.Parameters.Add(paramSender)
        comm.ExecuteNonQuery()

        Response.Redirect("ChatLogin.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub Logout()
        Dim con As SqlConnection = New SqlConnection( _
             ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        con.Open()
        Dim comm As SqlCommand = New SqlCommand("stp_Message", con)
        comm.CommandType = CommandType.StoredProcedure
        Dim paramSender As SqlParameter = New SqlParameter( _
            "@Sender", SqlDbType.Int)
        paramSender.Value = HttpContext.Current.Session("ID")
        comm.Parameters.Add(paramSender)
        comm.ExecuteNonQuery()


        con = New SqlConnection( _
           ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        con.Open()
        comm = New SqlCommand("Proc_DeleteUser", con)
        comm.CommandType = CommandType.StoredProcedure
        paramSender = New SqlParameter( _
            "@ID", SqlDbType.Int)
        paramSender.Value = HttpContext.Current.Session("ID")
        comm.Parameters.Add(paramSender)
        comm.ExecuteNonQuery()


    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Repeater1.DataSource = Nothing
        Repeater1.DataBind()
        Repeater1.DataSourceID = "dsrcWebChat"
        Repeater1.DataBind()
    End Sub
End Class