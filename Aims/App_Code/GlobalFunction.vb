Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Security.Cryptography
Imports System
Imports System.Data.SqlClient

Public Class GlobalFunction
    'Begin Edit by Kusum
    Public Shared logid As Integer
    Public Shared hashpwd As String
    'Begin Edit by Nethra
    Public Shared ErrorMsg As String
    Public VersionNo As String = "10.36"
    Public Function StripHTML(ByVal source As String) As String
        Try
            Dim result As String

            ' Remove HTML Development formatting
            ' Replace line breaks with space
            ' because browsers inserts space
            result = source.Replace(vbCr, " ")
            ' Replace line breaks with space
            ' because browsers inserts space
            result = result.Replace(vbLf, " ")
            ' Remove step-formatting
            result = result.Replace(vbTab, String.Empty)
            ' Remove repeating spaces because browsers ignore them
            result = System.Text.RegularExpressions.Regex.Replace(result, "( )+", " ")

            ' Remove the header (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*head([^>])*>", "<head>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<( )*(/)( )*head( )*>)", "</head>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<head>).*(</head>)", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' remove all scripts (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*script([^>])*>", "<script>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<( )*(/)( )*script( )*>)", "</script>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            'result = System.Text.RegularExpressions.Regex.Replace(result,
            '         @"(<script>)([^(<script>\.</script>)])*(</script>)",
            '         string.Empty,
            '         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<script>).*(</script>)", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' remove all styles (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*style([^>])*>", "<style>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<( )*(/)( )*style( )*>)", "</style>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<style>).*(</style>)", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' insert tabs in spaces of <td> tags
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*td([^>])*>", vbTab, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' insert line breaks in places of <BR> and <LI> tags
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*br( )*>", vbCr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*li( )*>", vbCr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' insert line paragraphs (double line breaks) in place
            ' if <P>, <DIV> and <TR> tags
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*div([^>])*>", vbCr & vbCr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*tr([^>])*>", vbCr & vbCr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*p([^>])*>", vbCr & vbCr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' Remove remaining tags like <a>, links, images,
            ' comments etc - anything that's enclosed inside < >
            result = System.Text.RegularExpressions.Regex.Replace(result, "<[^>]*>", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' replace special characters:
            result = System.Text.RegularExpressions.Regex.Replace(result, " ", " ", System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            result = System.Text.RegularExpressions.Regex.Replace(result, "&bull;", " * ", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&lsaquo;", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&rsaquo;", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&trade;", "(tm)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&frasl;", "/", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&lt;", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&gt;", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&copy;", "(c)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&reg;", "(r)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            ' Remove all others. More can be added, see
            ' http://hotwired.lycos.com/webmonkey/reference/special_characters/
            result = System.Text.RegularExpressions.Regex.Replace(result, "&(.{2,6});", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' for testing
            'System.Text.RegularExpressions.Regex.Replace(result,
            '       this.txtRegex.Text,string.Empty,
            '       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            ' make line breaking consistent
            result = result.Replace(vbLf, vbCr)

            ' Remove extra line breaks and tabs:
            ' replace over 2 breaks with 2 and over 4 tabs with 4.
            ' Prepare first to remove any whitespaces in between
            ' the escaped characters and remove redundant tabs in between line breaks
            result = System.Text.RegularExpressions.Regex.Replace(result, "(" & vbCr & ")( )+(" & vbCr & ")", vbCr & vbCr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(" & vbTab & ")( )+(" & vbTab & ")", vbTab & vbTab, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(" & vbTab & ")( )+(" & vbCr & ")", vbTab & vbCr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(" & vbCr & ")( )+(" & vbTab & ")", vbCr & vbTab, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            ' Remove redundant tabs
            result = System.Text.RegularExpressions.Regex.Replace(result, "(" & vbCr & ")(" & vbTab & ")+(" & vbCr & ")", vbCr & vbCr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            ' Remove multiple tabs following a line break with just one tab
            result = System.Text.RegularExpressions.Regex.Replace(result, "(" & vbCr & ")(" & vbTab & ")+", vbCr & vbTab, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            ' Initial replacement target string for line breaks
            Dim breaks As String = vbCr & vbCr & vbCr
            ' Initial replacement target string for tabs
            Dim tabs As String = vbTab & vbTab & vbTab & vbTab & vbTab
            For index As Integer = 0 To result.Length - 1
                result = result.Replace(breaks, vbCr & vbCr)
                result = result.Replace(tabs, vbTab & vbTab & vbTab & vbTab)
                breaks = breaks & vbCr
                tabs = tabs & vbTab
            Next

            ' That's it.
            Return result
        Catch
            'MessageBox.Show("Error")
            Return source
        End Try
    End Function
    Public Function IdCutter(ByVal txtBox As String) As Long
        Dim id As Long
        If InStr(txtBox, ":") > 0 Then
            id = Mid(txtBox, 1, InStr(txtBox, ":") - 1)
            Return id
        Else
            Return 0
        End If
    End Function
    Public Function NameCutter(ByVal txtBox As String) As String
        Dim nam As String
        nam = Mid(txtBox, InStr(txtBox, ":") + 1)
        Return nam
    End Function
    'For hashing the User password
    'Raju
    Public Shared Function Login() As String

        Dim myPassword As String = (hashpwd.Trim)

        Dim mhash As HashAlgorithm = New SHA1CryptoServiceProvider

        Dim bytValue() As Byte = System.Text.Encoding.UTF8.GetBytes(myPassword)

        Dim bytHash() As Byte = mhash.ComputeHash(bytValue)

        mhash.Clear()

        hashpwd = Convert.ToBase64String(bytHash)

        'Me.Login(bRedirectOnSuccess)

    End Function
    ' to check if it is global or local table

    'Public Function GetBranchID(ByVal BR_ID As Int16, ByVal tablename As String) As Long
    '    Dim cacheobject As System.Web.Caching.Cache
    '    cacheobject = System.Web.HttpContext.Current.Cache
    '    Dim ds, ds1 As New DataSet
    '    Dim BranchID As Integer
    '    ds = cacheobject("DataGridCache")

    '    ds1 = DLBranchDB.GetBranch(BR_ID)

    '    Dim dt As DataTable = ds.Tables(0)
    '    Dim dt1 As DataTable = ds1.Tables(0)

    '    Dim code As String = dt1.Rows(0)("BranchCode")
    '    Dim List1 As ArrayList = New ArrayList()
    '    For j = 0 To dt.Rows.Count - 1 Step 1
    '        Dim d As String = dt.Rows(j)("TableName")
    '        Dim h As String = dt.Rows(j)("TableAccessLevel")
    '        If d = tablename Then
    '            If h = "Local" Then
    '                BranchID = BR_ID
    '                Return BranchID
    '            Else
    '                code = Left(code, 2)
    '                Dim dt2 As DataTable = DLBranchDB.GetBranchID(code)
    '                BranchID = dt2.Rows(0)("Branch_ID")
    '                Return BranchID
    '            End If
    '        End If
    '    Next j
    'End Function
    ' To check user role

    Public Function UserRole() As Long
        Try
            Dim cacheobject As System.Web.Caching.Cache
            cacheobject = System.Web.HttpContext.Current.Cache
            Dim dt, dt1 As New DataTable
            dt = cacheobject("RoleMapCache")
            Dim loguserrole As String
            Dim a As Integer
            loguserrole = HttpContext.Current.Session("UserRole")
            Dim List1 As ArrayList = New ArrayList()

            List1.AddRange(loguserrole.Split(","))
            Dim i As Integer
            For i = 0 To List1.Count - 1 Step 1
                For j = 0 To dt.Rows.Count - 1 Step 1
                    If ((List1.Item(i)).ToString() = dt.Rows(j)("RoleCode").ToString()) Then
                        If (HttpContext.Current.Session("RptFrmTitleName") = dt.Rows(j)("Title")) Then
                            a = 1
                        End If
                    End If
                Next j
            Next i
            Return a
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'To check user privilages

    Public Function UserPrivilage() As Long
        Dim privilage As String
        Dim a As Integer
        privilage = HttpContext.Current.Session("Privilages")
        If privilage = "R,W,P" Then
            a = 1
        ElseIf privilage = "R,W" Then
            a = 2
        ElseIf privilage = "R" Then
            a = 3
        ElseIf privilage = "R,P" Then
            a = 4
        ElseIf privilage = "P" Then
            a = 5
        ElseIf privilage = "W" Then
            a = 6
        ElseIf privilage = "W,P" Then
            a = 7
        End If
        Return a
    End Function

    Public Function NameInitial(ByVal name As String) As String
        Dim IName, PName, FName, LName As String
        Dim fin, i, j, k As Integer

        Dim parts As String() = name.Split(New Char() {" "})
        If parts.Length = 2 Or parts.Length = 1 Then
            FName = name
        ElseIf parts.Length > 2 Then
            fin = (parts.Length) - (2)

            For i = 0 To fin - 1 Step 1
                PName = parts(i).ToString
                IName = Left(PName, 1)
                LName = LName + IName + "."
            Next
            j = (fin - 1) + 1
            k = j + 1
            FName = Mid(LName, 1, (Len(LName) - 1)) + "." + parts(j).ToString + " " + parts(k).ToString
        End If
        If ConfigurationDB.GetStdNameConfig("Student Name With Initial") = "N" Then
            Return name
        Else
            Return FName
        End If
    End Function



    Public Function SpellNumber(ByVal MyNumber As String) As String
        Dim Dollars As String = ""
        Dim Cents As String = ""
        Dim Temp As String = ""
        Dim DecimalPlace, Count As Integer
        Dim Place(9) As String
        Place(2) = " Thousand "
        Place(3) = " Million "
        Place(4) = " Billion "
        Place(5) = " Trillion "
        ' String representation of amount.
        MyNumber = Trim(Str(MyNumber))
        ' Position of decimal place 0 if none.
        DecimalPlace = InStr(MyNumber, ".")
        ' Convert cents and set MyNumber to dollar amount.
        If DecimalPlace > 0 Then
            Cents = GetTens(Left(Mid(MyNumber, DecimalPlace + 1) & "00", 2))
            MyNumber = Trim(Left(MyNumber, DecimalPlace - 1))
        End If
        Count = 1
        Do While MyNumber <> ""
            Temp = GetHundreds(Right(MyNumber, 3))
            If Temp <> "" Then Dollars = Temp & Place(Count) & Dollars
            If Len(MyNumber) > 3 Then
                MyNumber = Left(MyNumber, Len(MyNumber) - 3)
            Else
                MyNumber = ""
            End If
            Count = Count + 1
        Loop
        'Select Case Dollars
        '    Case ""
        '        Dollars = "No Dollars"
        '    Case "One"
        '        Dollars = "One Dollar"
        '    Case Else
        '        Dollars = Dollars & " Dollars"
        'End Select
        Select Case Cents
            Case ""
                Cents = " Only"
            Case "One"
                Cents = " and One Cent"
            Case Else
                Cents = " and " & Cents & " Cents"
        End Select
        SpellNumber = Dollars & Cents
    End Function
    ' Converts a number from 100-999 into text 
    Function GetHundreds(ByVal MyNumber As String) As String
        Dim Result As String
        If Val(MyNumber) = 0 Then : Return "" : Exit Function : End If
        MyNumber = Right("000" & MyNumber, 3)
        ' Convert the hundreds place.
        If Mid(MyNumber, 1, 1) <> "0" Then
            Result = GetDigit(Mid(MyNumber, 1, 1)) & " Hundred "
        End If
        ' Convert the tens and ones place.
        If Mid(MyNumber, 2, 1) <> "0" Then
            Result = Result & GetTens(Mid(MyNumber, 2))
        Else
            Result = Result & GetDigit(Mid(MyNumber, 3))
        End If
        GetHundreds = Result
    End Function
    ' Converts a number from 10 to 99 into text. 
    Function GetTens(ByVal TensText As String) As String
        Dim Result As String
        Result = ""           ' Null out the temporary function value.
        If Val(Left(TensText, 1)) = 1 Then   ' If value between 10-19...
            Select Case Val(TensText)
                Case 10 : Result = "Ten"
                Case 11 : Result = "Eleven"
                Case 12 : Result = "Twelve"
                Case 13 : Result = "Thirteen"
                Case 14 : Result = "Fourteen"
                Case 15 : Result = "Fifteen"
                Case 16 : Result = "Sixteen"
                Case 17 : Result = "Seventeen"
                Case 18 : Result = "Eighteen"
                Case 19 : Result = "Nineteen"
                Case Else
            End Select
        Else                                 ' If value between 20-99...
            Select Case Val(Left(TensText, 1))
                Case 2 : Result = "Twenty "
                Case 3 : Result = "Thirty "
                Case 4 : Result = "Forty "
                Case 5 : Result = "Fifty "
                Case 6 : Result = "Sixty "
                Case 7 : Result = "Seventy "
                Case 8 : Result = "Eighty "
                Case 9 : Result = "Ninety "
                Case Else
            End Select
            Result = Result & GetDigit _
            (Right(TensText, 1))  ' Retrieve ones place.
        End If
        GetTens = Result
    End Function
    ' Converts a number from 1 to 9 into text. 
    Function GetDigit(ByVal Digit As String) As String
        Select Case Val(Digit)
            Case 1 : GetDigit = "One"
            Case 2 : GetDigit = "Two"
            Case 3 : GetDigit = "Three"
            Case 4 : GetDigit = "Four"
            Case 5 : GetDigit = "Five"
            Case 6 : GetDigit = "Six"
            Case 7 : GetDigit = "Seven"
            Case 8 : GetDigit = "Eight"
            Case 9 : GetDigit = "Nine"
            Case Else : GetDigit = ""
        End Select
    End Function
    '' Getting label text for multilingual appearence
    '' Created By Ajit Kumar Singh
    Shared Function GetValidationMessage(ByVal LanguageID As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
       

        arParms(0) = New SqlParameter("@LanguageID", SqlDbType.Int)
        arParms(0).Value = LanguageID

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetValidationMessage]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    '' Getting label and button text for multilingual appearence
    '' Created By Ajit Kumar Singh
    Shared Function GetChangeLanguage(ByVal FormName As String, ByVal LanguageID As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.NVarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@FormName", SqlDbType.NVarChar, 250)
        arParms(2).Value = FormName

        arParms(3) = New SqlParameter("@LanguageID", SqlDbType.Int)
        arParms(3).Value = LanguageID

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_ChangeLangugae1]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    '' Getting label and button text for Branch Specific Label
    '' Created By Niraj 
    Shared Function GetChangeLabel(ByVal FormName As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.NVarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@FormName", SqlDbType.NVarChar, 250)
        arParms(2).Value = FormName

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_BranchSpecific_Label", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    '' Getting label in Report for Branch Specific Label
    '' Created By Niraj 
    Shared Function GetChangeLabelReport(ByVal FormName As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.NVarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@FormName", SqlDbType.NVarChar, 250)
        arParms(2).Value = FormName

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_BranchSpecific_Label", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    ''Multilingual Text for Report Headings.
    ''Created By Ajit Kumar Singh
    Shared Function EnquiryDetailsHeading(ByVal FormName As String, ByVal LanguageID As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}


        arParms(0) = New SqlParameter("@FormName", SqlDbType.VarChar)
        arParms(0).Value = FormName

        arParms(1) = New SqlParameter("@LanguageID", SqlDbType.Int)
        arParms(1).Value = LanguageID


        Dim ds As DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[ReportHeading]", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
