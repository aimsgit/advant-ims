<%@ Application Language="VB" %>

<script runat="server">   

    Public Shared rowpos1 As Integer
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup   

        'Application("Strcontent") = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        'Application("GlbProviderName") = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ProviderName

    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
        If HttpContext.Current IsNot Nothing Then
            For Each de As DictionaryEntry In HttpContext.Current.Cache
                HttpContext.Current.Cache.Remove(DirectCast(de.Key, String))
            Next
            'Begin Edit by Kusum
            Dim i As Int16 = UserDetailsDB.UpdateUserlog() 'Reset user session
            GlobalFunction.logid = Nothing 'Nullify global variable - LogID
            HttpContext.Current.Session.Abandon()
            'End Edit by Kusum
        End If
    End Sub
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        'Begin comment by Kusum. 19-05-2012
        'Dim exc As Exception = Server.GetLastError
        'try
        'If (exc.GetType Is GetType(HttpException)) Then
        'Else
        '    Session("ErrorMsg") = Server.GetLastError.ToString()
        'End If
        'catch
        'end try 
        'End comment by Kusum

        Dim exc As Exception = Server.GetLastError
        Try
            If (exc.GetType Is GetType(HttpException)) Then
            Else
                Session("ErrorMsg") = Server.GetLastError.ToString()
            End If
        Catch
        End Try
        'Begin Edit by Kusum
        Dim i As Int16 = UserDetailsDB.UpdateUserlog() 'Reset user session
        GlobalFunction.logid = Nothing 'Nullify global variable - LogID
        'End Edit by Kusum
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

        ' Code that runs when a new session is started 
        If Session.IsNewSession Then
            Dim EMPID As Long = 0
            Dim sesbranch As Long = 0
            Dim sesInstitute As Long = 0
            Dim sesDepartment As Long = 0
            Dim sesCourse As Long = 0
            Dim sesStartDate As String = String.Empty
            Dim sesEndDate As String = String.Empty
            Dim sesThemeName As String = String.Empty

            ' initialize Financial Start Date and Financial End Date
            Dim ConL As New ConfigurationB
            Dim ConEL As New EntConfiguration

            'Commented by Nethra during Build March-30-2012

            ConEL = ConL.GetConfigId(11)
            Session.Add("FinStartDate", ConEL.config_value) ' Financial Year Start Date
            ConEL = ConL.GetConfigId(12)
            Session.Add("FinEndDate", ConEL.config_value)   ' Financial Year End Date 
            ConEL = ConL.GetConfigId(34)
            Session.Add("TestUser", ConEL.config_value)   ' Test User
            ConEL = ConL.GetConfigId(50)
            Session.Add("Path", ConEL.config_value)
            ConEL = ConL.GetConfigId(57)
            Session.Add("Theme", ConEL.config_value)   ' Random Theme
            ConEL = ConL.GetConfigId(59)
            Session.Add("EmailID", ConEL.config_value)   ' Email ID
            ConEL = ConL.GetConfigId(60)
            Session.Add("Password", ConEL.config_value)   ' Password
            ConEL = ConL.GetConfigId(61)
            Session.Add("SMTP", ConEL.config_value)   ' SMTP
            ConEL = ConL.GetConfigId(62)
            Session.Add("Port", ConEL.config_value)   ' Port

            ConEL = ConL.GetConfigId(76)
            Session.Add("CurrentYear", ConEL.config_value)   ' Current Year
            'Response.Redirect("Login.aspx")
        End If

    End Sub


    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        'Session.Add("EMPID", 0)
        'Session("USER") = ""
        'Session("sesLoginBranch") = ""
        'Session("sesLoginInstitute") = ""
        'Session("Access_Per_Frm") = ""
        'Session("UserRole") = ""

        'Session("BranchID") = ""
        'Session("InstituteID") = ""
        'Session("UserName") = ""
        'Session("BranchName") = ""
        'Session("InstituteName") = ""
        'Session("UserID") = ""
        'Session("sesPartyType") = ""
        'Session("sesPartyId") = ""
        'Begin Edit by Kusum
        Dim i As Int16 = UserDetailsDB.UpdateUserlog() 'Reset user session
        GlobalFunction.logid = Nothing 'Nullify global variable - LogID
        'FormsAuthentication.SignOut()
        'Roles.DeleteCookie()
        Session.Abandon()
        'End Edit by Kusum
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
    'End Sub
    'Protected Sub Application_AuthorizeRequest(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If (Me.Request.Path.ToUpper().EndsWith("LOGIN.ASPX") And Me.Request.IsAuthenticated) Then
    '        Me.Response.Redirect("AccessDenied.aspx")
    '    End If
    'End Sub

    Protected Sub Application_PreRequestHandlerExecute(ByVal sender As Object, ByVal e As System.EventArgs)
        'Session("ErrorMsg") = ""
        '           Session("ErrorPageLink") = ""
    End Sub
    Protected Sub Application_BeginRequest()
        Response.Headers.Remove("Server")
        Response.Headers.Remove("X-AspNet-Version")
        Response.Headers.Remove("X-AspNetMvc-Version")
        Response.Headers.Remove("X-Powered-By")
    End Sub

</script>