
Partial Class PopUp
    Inherits System.Web.UI.MasterPage
    Dim new_dbconn1 As New OleDbConnection
    'Code by Nakul Bharadwaj for popups
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'new_dbconn1.ConnectionString = Application("Strcontent")
        'Dim Tdt As New DataTable
        'Dim Tda As New OleDbDataAdapter
        'Tda = New OleDbDataAdapter("Select MyCo_Name from SelfDetails", new_dbconn1)
        'Tdt.Clear()
        'Tda.Fill(Tdt)
        'If Tdt.Rows.Count = 0 Then
        'Else
        '    Me.lblTitle.Text = Tdt.Rows(0)("MyCo_Name").ToString
        'End If
        If Session("UserName") = "" Then
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim emp As New GlobalDataSetTableAdapters.EmployeeCodeTableAdapter
        'If Session("EMPID") = 0 Then
        '    'Me.lblUserName.Text = "Welcome User!" & "_______" & "DATE:" & Today.ToString("dd-MMM-yyyy")
        '    Me.lblUserName.Text = "Welcome User!"
        'Else
        '    Me.lblUserName.Text = "User Name:" & emp.GetDataBy(Session("EMPID")).Rows(0)("Emp_Name").ToString()
        'End If
        'If Not IsPostBack Then
        Try
            If Session("FrmParentName") <> "" Then
                Me.lblUserName.Text = "User : " & Session("UserName") & ", Branch : " & Session("BranchName") & ", Institute : " & Session("InstituteName") & ", >> " & Session("FrmParentName") & " > " & Session("RptFrmTitleName")
                lblSmallTitle.Text = Session("BranchName")
                lblTitle.Text = Session("InstituteName")
                Me.Image1.ImageUrl = Session("Logo").ToString
                lblSmallTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(Session("HeaderTextColor").ToString)
                lblTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(Session("HeaderTextColor").ToString)
                HeaderPanel.BackImageUrl = Session("ImgHeader").ToString
            Else
                Me.lblUserName.Text = "User : " & Session("UserName") & ", Branch : " & Session("BranchName") & ", Institute : " & Session("InstituteName") '& ", >> " & Session("FrmParentName") & " > " & Session("RptFrmTitleName")
                lblSmallTitle.Text = Session("BranchName")
                lblTitle.Text = Session("InstituteName")
                Me.Image1.ImageUrl = Session("Logo")
                lblSmallTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(Session("HeaderTextColor").ToString)
                lblTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(Session("HeaderTextColor").ToString)
                HeaderPanel.BackImageUrl = Session("ImgHeader").ToString
            End If
            If Session("UserID") <> "" Then
                'Dim dt As DataTable = selfdetailsDB.GetSelfDetailsByUID()
                'If dt.Rows.Count > 0 Then
                '    Me.lblTitle.Text = dt.Rows(0)("MyCo_Name").ToString
                '    lblSmallTitle.Text = Session("BranchName")
                '    lblTitle.Text = Session("InstituteName")
                'End If
                Me.lblUserName.Text = "User : " & Session("UserName") & ", Branch : " & Session("BranchName") & ", Institute : " & Session("InstituteName") '& ", >> " & Session("FrmParentName") & " > " & Session("RptFrmTitleName")
                lblSmallTitle.Text = Session("BranchName")
                lblTitle.Text = Session("InstituteName")
                Me.Image1.ImageUrl = Session("Logo")
                lblSmallTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(Session("HeaderTextColor").ToString)
                lblTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(Session("HeaderTextColor").ToString)
                HeaderPanel.BackImageUrl = Session("ImgHeader").ToString
            Else
                Dim i As Int16 = UserDetailsDB.UpdateUserlog()
                FormsAuthentication.SignOut()
                Roles.DeleteCookie()
                FormsAuthentication.RedirectToLoginPage()
            End If
        Catch ex As Exception
            Session.Clear()
            Session("UserName") = ""
            Session.Abandon()
            ''new_dbconn1.ConnectionString = Application("Strcontent")
            ''new_dbconn1.Dispose()
            Response.CacheControl = "no-cache"
            Response.AddHeader("Pragma", "no-cache")
            Response.Expires = -1
            Response.Buffer = True
            Response.ExpiresAbsolute = Now()
            Response.Expires = 0
            Response.CacheControl = "no-cache"
            Dim i As Int16 = UserDetailsDB.UpdateUserlog()
            FormsAuthentication.SignOut()
            Roles.DeleteCookie()
            FormsAuthentication.RedirectToLoginPage()
        End Try
        'End If
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        'If i = 1 Then
        'End If
        HttpContext.Current.Session.Abandon()
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
    End Sub
End Class

