Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient
Imports System.Data
Imports RijndaelSimple

'==========================
'Author: Keshav Pandey
'Date: 16/08/2014
'Language: VB.Net
'.Net Framework : 4.5
'IDE: Visual Studio 2014
'Project: AIMS for Mobile
'==========================
'MobileWebService holds functions which provide basic features to AIMS users on a mobile device
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class MobileWebService
    Inherits System.Web.Services.WebService
    'Connection String

    Dim connectionString As String = "Server=development;Database=AIMS_Test;User=sa;Password=Advant.123;"
   
    <WebMethod()> _
    Public Function Attendance(ByVal uname As String, ByVal passwd As String) As String
        'Connection String which defines the connection parameters required to connect to SQL Server
        'Dim connectionString As String = "Server=development;Database=AIMS_Dev;User=sa;Password=Advant.123;"
        'html cariable which will be used to create the required html format for the function
        Dim PasswordE As String = RijndaelSimple.Encrypt(passwd, _
                                          RijndaelSimple.passPhrase, _
                                          RijndaelSimple.saltValue, _
                                          RijndaelSimple.hashAlgorithm, _
                                          RijndaelSimple.passwordIterations, _
                                          RijndaelSimple.initVector, _
                                          RijndaelSimple.keySize)
        Dim html As String
        html = ""
        'Initializing a Sql Connection with the Connection String and Establising a Connection
        Using conn As New SqlConnection(connectionString)
            'Opening a connection
            conn.Open()
            'Creating SQL Command
            Dim cmd As SqlCommand = New SqlCommand("proc_MobileStudentAttendance1", conn)
            'Specifying command is a Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure
            'Providing the parameters required for the Stored Procedure
            cmd.Parameters.AddWithValue("@UserName", uname)
            cmd.Parameters.AddWithValue("@Password", PasswordE)
            'Create SqlDataReader which reads the data retrieved
            Dim r As SqlDataReader = cmd.ExecuteReader()
            'Declaring a DataTable to hold the data retrieved
            Dim dt As New DataTable("Attendace")
            dt.Clear()
            'Load data from SqlDataReader to DataTable
            dt.Load(r)
            If (dt.Rows(0).item("ActualAttend").ToString = "wrong credential !") Then
                Return "Wrong Username/Password."
            End If
            'Traverse through each row in the data table to fetch values
            For Each row As DataRow In dt.Rows
                'Capture values and store them in apporpriate variables
                Dim max = row("MaxAttend").ToString
                Dim actual = row("ActualAttend").ToString
                Dim PercentAttendence = row("PerAttend").ToString
                Dim subname = row("Subject_Name").ToString
                Dim subcode = row("Subject_Code").ToString
                Dim Semester = row("SemName").ToString
                'Final html formatting
                html += "<tr>" + "<td>" + subcode + "</td>" + "<td>" + subname + "</td>" + "<td>" + max + "</td>" + "<td>" + actual + "</td><td>" + PercentAttendence + "</td><td>" + Semester + "</td></tr>"
                'Iterate over to next row
            Next row
        End Using
        'Return the final formatted data
        Return html
    End Function

    <WebMethod()> _
    Public Function Notice(ByVal uname As String, ByVal passwd As String) As String
        'Connection String which defines the connection parameters required to connect to SQL Server
        'Dim connectionString As String = "Data Source=(localdb)\Projects;Initial Catalog=AIMS_Dev;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;"
        'Dim connectionString As String = "Server=development;Database=AIMS_Dev;user id=sa;Password=Advant.123;"
        'html cariable which will be used to create the required html format for the function
        Dim PasswordE As String = RijndaelSimple.Encrypt(passwd, _
                                          RijndaelSimple.passPhrase, _
                                          RijndaelSimple.saltValue, _
                                          RijndaelSimple.hashAlgorithm, _
                                          RijndaelSimple.passwordIterations, _
                                          RijndaelSimple.initVector, _
                                          RijndaelSimple.keySize)
        Dim html As String
        html = ""
        'Initializing a Sql Connection with the Connection Stringand Establising a Connection
        Using conn As New SqlConnection(connectionString)
            'Opening a connection
            conn.Open()
            'Creating SQL Command
            Dim cmd As SqlCommand = New SqlCommand("proc_MobileNoticeBoard", conn)
            'Specifying command is a Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure
            'Providing the parameters required for the Stored Procedure
            cmd.Parameters.AddWithValue("@username", uname)
            cmd.Parameters.AddWithValue("@Password", PasswordE)
            'Create SqlDataReader which reads the data retrieved
            Dim r As SqlDataReader = cmd.ExecuteReader()
            'Declaring a DataTable to hold the data retrieved
            Dim dt As New DataTable("Notice")
            dt.Clear()
            'Load data from SqlDataReader to DataTable
            dt.Load(r)
            If (dt.Rows(0).item("GroupType").ToString = "wrong credential !") Then
                Return "Wrong Username/Password."
            End If
            'Traverse through each row in the data table to fetch values
            For Each row As DataRow In dt.Rows
                'Capture values and store them in apporpriate variables
                Dim msg = row("Message")
                Dim msgfrm = row("MsgFrom")
                Dim grp = row("GroupType")
                Dim day = row("Date").ToString()
                'Final html formatting
                html += "Msg From: " + msgfrm + "</br>Group :" + grp + "</br>Message:</br>" + msg + "</br>"
                'Iterate over to next row
            Next row
        End Using
        'Return the final formatted data
        Return html
    End Function

    <WebMethod()> _
    Public Function Fee(ByVal uname As String, ByVal passwd As String) As String
        'Connection String which defines the connection parameters required to connect to SQL Server
        'Dim connectionString As String = "Server=development;Database=AIMS_Dev;User=sa;Password=Advant.123;"
        'html cariable which will be used to create the required html format for the function
        Dim PasswordE As String = RijndaelSimple.Encrypt(passwd, _
                                          RijndaelSimple.passPhrase, _
                                          RijndaelSimple.saltValue, _
                                          RijndaelSimple.hashAlgorithm, _
                                          RijndaelSimple.passwordIterations, _
                                          RijndaelSimple.initVector, _
                                          RijndaelSimple.keySize)
        Dim html As String
        html = ""
        'Initializing a Sql Connection with the Connection Stringand Establising a Connection
        Using conn As New SqlConnection(connectionString)
            'Opening a connection
            conn.Open()
            'Creating SQL Command
            Dim cmd As SqlCommand = New SqlCommand("Proc_MobileFeeDueStatement", conn)
            'Specifying command is a Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure
            'Providing the parameters required for the Stored Procedure
            cmd.Parameters.AddWithValue("@username", uname)
            cmd.Parameters.AddWithValue("@Password", PasswordE)
            'Create SqlDataReader which reads the data retrieved
            Dim r As SqlDataReader = cmd.ExecuteReader()
            'Declaring a DataTable to hold the data retrieved
            Dim dt As New DataTable("Fee")
            dt.Clear()
            'Load data from SqlDataReader to DataTable
            dt.Load(r)
            If (dt.Rows(0).item("StdCode").ToString = "wrong credential !") Then
                Return "Wrong Username/Password."
            End If
            'Traverse through each row in the data table to fetch values
            For Each row As DataRow In dt.Rows
                'Capture values and store them in apporpriate variables
                Dim stdcode = row("StdCode").ToString
                Dim stdname = row("StdName").ToString
                Dim total = row("TotalFee").ToString
                Dim paid = row("FeePaid").ToString
                Dim cat = row("Std_CategoryName").ToString
                'Final html formatting
                html += "<h3>Total Fee: " + total + "</hr><br/><h3>Fee Paid: " + paid + "<br/><h4>Std_CategoryName : " + cat + "</h4>"
                'Iterate over to next row
            Next row
        End Using
        'Return the final formatted data
        Return html
    End Function

    <WebMethod()> _
    Public Function timetable(ByVal uname As String, ByVal passwd As String) As String
        'Connection String which defines the connection parameters required to connect to SQL Server
        'Dim connectionString As String = "Server=development;Database=AIMS_Dev;User=sa;Password=Advant.123;"
        'html cariable which will be used to create the required html format for the function
        Dim PasswordE As String = RijndaelSimple.Encrypt(passwd, _
                                          RijndaelSimple.passPhrase, _
                                          RijndaelSimple.saltValue, _
                                          RijndaelSimple.hashAlgorithm, _
                                          RijndaelSimple.passwordIterations, _
                                          RijndaelSimple.initVector, _
                                          RijndaelSimple.keySize)
        Dim html As String
        html = ""
        'Initializing a Sql Connection with the Connection Stringand Establising a Connection
        Using conn As New SqlConnection(connectionString)
            'Opening a connection
            conn.Open()
            'Creating SQL Command
            Dim cmd As SqlCommand = New SqlCommand("Proc_MobileTimeTable", conn)
            'Specifying command is a Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure
            'Providing the parameters required for the Stored Procedure
            cmd.Parameters.AddWithValue("@username", uname)
            cmd.Parameters.AddWithValue("@Password", PasswordE)
            'Create SqlDataReader which reads the data retrieved
            Dim r As SqlDataReader = cmd.ExecuteReader()
            'Declaring a DataTable to hold the data retrieved
            Dim dt As New DataTable("TimeTable")
            dt.Clear()
            'Load data from SqlDataReader to DataTable
            dt.Load(r)
            If (dt.Rows(0).item("Batch_No").ToString = "wrong credential !") Then
                Return "Wrong Username/Password."
            End If
            'Traverse through each row in the data table to fetch values
            For Each row As DataRow In dt.Rows
                'Capture values and store them in apporpriate variables
                Dim subname1 = row("Subject_Name1")
                Dim subname2 = row("Subject_Name2")
                Dim subname3 = row("Subject_Name3")
                Dim subname4 = row("Subject_Name4")
                Dim subname5 = row("Subject_Name5")
                Dim subname6 = row("Subject_Name6")
                Dim subname7 = row("Subject_Name7")
                'Final html formatting
                html += "<tr>" + "<td>" + subname1 + "</td>" + "<td>" + subname2 + "</td>" + "<td>" + subname3 + "</td>" + "<td>" + subname4 + "</td>" + "<td>" + subname5 + "</td>" + "<td>" + subname6 + "</td>" + "<td>" + subname7 + "</td>" + "</tr>"
                'Iterate over to next row
            Next row
        End Using
        'Return the final formatted data
        Return html
    End Function

    <WebMethod()> _
    Public Function Marks(ByVal uname As String, ByVal passwd As String) As String
        'Connection String which defines the connection parameters required to connect to SQL Server
        'Dim connectionString As String = "Server=development;Database=AIMS_Dev;User=sa;Password=Advant.123;"
        'html cariable which will be used to create the required html format for the function
        Dim PasswordE As String = RijndaelSimple.Encrypt(passwd, _
                                          RijndaelSimple.passPhrase, _
                                          RijndaelSimple.saltValue, _
                                          RijndaelSimple.hashAlgorithm, _
                                          RijndaelSimple.passwordIterations, _
                                          RijndaelSimple.initVector, _
                                          RijndaelSimple.keySize)
        Dim html As String
        html = ""
        'Initializing a Sql Connection with the Connection Stringand Establising a Connection
        Using conn As New SqlConnection(connectionString)
            'Opening a connection
            conn.Open()
            'Creating SQL Command
            Dim cmd As SqlCommand = New SqlCommand("Proc_MobileStudentMarks", conn)
            'Specifying command is a Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure
            'Providing the parameters required for the Stored Procedure
            cmd.Parameters.AddWithValue("@username", uname)
            cmd.Parameters.AddWithValue("@Password", PasswordE)
            'Create SqlDataReader which reads the data retrieved
            Dim r As SqlDataReader = cmd.ExecuteReader()
            'Declaring a DataTable to hold the data retrieved
            Dim dt As New DataTable("Marks")
            dt.Clear()
            'Load data from SqlDataReader to DataTable
            dt.Load(r)
            If (dt.Rows(0).item("Grade").ToString = "wrong credential !") Then
                Return "Wrong Username/Password."
            End If
            'Traverse through each row in the data table to fetch values
            For Each row As DataRow In dt.Rows
                'Capture values and store them in apporpriate variables
                Dim min = row("MinMarks").ToString
                Dim max = row("MaxMarks").ToString
                Dim mrks = row("ActualMarks").ToString
                Dim at = row("AssessmentType").ToString
                Dim subname = row("Subject_Name").ToString
                Dim subcode = row("Subject_Code").ToString
                Dim sem = row("SemName").ToString
                'Final html formatting
                html += "<tr><td>" + subcode + "</td><td>" + subname + "</td><td>" + min + "</td><td>" + max + "</td><td>" + mrks + "</td><td>" + at + "</td><td>" + sem + "</td></tr>"
                'Iterate over to next row
            Next row
        End Using
        'Return the final formatted data
        Return html
    End Function

    '<WebMethod()> _
    'Public Function Today(ByVal uname As String, ByVal passwd As String) As String
    '    'Connection String which defines the connection parameters required to connect to SQL Server
    '    'Dim connectionString As String = "Server=development;Database=AIMS_Dev;User=sa;Password=Advant.123;"
    '    'html cariable which will be used to create the required html format for the function
    '    Dim PasswordE As String = RijndaelSimple.Encrypt(passwd, _
    '                                      RijndaelSimple.passPhrase, _
    '                                      RijndaelSimple.saltValue, _
    '                                      RijndaelSimple.hashAlgorithm, _
    '                                      RijndaelSimple.passwordIterations, _
    '                                      RijndaelSimple.initVector, _
    '                                      RijndaelSimple.keySize)
    '    Dim html As String
    '    Dim html1 As String
    '    Dim html2 As String
    '    html = ""
    '    html1 = ""
    '    html2 = ""
    '    'Initializing a Sql Connection with the Connection Stringand Establising a Connection
    '    Using conn As New SqlConnection(connectionString)
    '        'Opening a connection
    '        conn.Open()
    '        'Creating SQL Command
    '        Dim cmd As SqlCommand = New SqlCommand("Proc_MobileTimeTable", conn)
    '        'Specifying command is a Stored Procedure
    '        cmd.CommandType = CommandType.StoredProcedure
    '        'Providing the parameters required for the Stored Procedure
    '        cmd.Parameters.AddWithValue("@username", uname)
    '        cmd.Parameters.AddWithValue("@Password", PasswordE)
    '        'Create SqlDataReader which reads the data retrieved
    '        Dim r As SqlDataReader = cmd.ExecuteReader()
    '        'Declaring a DataTable to hold the data retrieved
    '        Dim dt As New DataTable("TimeTable")
    '        dt.Clear()
    '        'Load data from SqlDataReader to DataTable
    '        dt.Load(r)

    '        If (dt.Rows(0).item("Batch_No").ToString = "wrong credential !") Then
    '            Return "Wrong Username/Password."
    '        End If
    '        'Traverse through each row in the data table to fetch values
    '        For Each row As DataRow In dt.Rows
    '            'Capture values and store them in apporpriate variables
    '            Dim subname1 = row("Subject_Name1")
    '            Dim subname2 = row("Subject_Name2")
    '            Dim subname3 = row("Subject_Name3")
    '            Dim subname4 = row("Subject_Name4")
    '            Dim subname5 = row("Subject_Name5")
    '            Dim subname6 = row("Subject_Name6")
    '            Dim subname7 = row("Subject_Name7")
    '            'Final html formatting
    '            html += "<tr>" + "<td>" + subname1 + "</td>" + "<td>" + subname2 + "</td>" + "<td>" + subname3 + "</td>" + "<td>" + subname4 + "</td>" + "<td>" + subname5 + "</td>" + "<td>" + subname6 + "</td>" + "<td>" + subname7 + "</td>" + "</tr>"
    '            'Iterate over to next row
    '        Next row
    '    End Using
    '    'Initializing a Sql Connection with the Connection Stringand Establising a Connection
    '    Using conn As New SqlConnection(connectionString)
    '        'Opening a connection
    '        conn.Open()
    '        'Creating SQL Command
    '        Dim cmd As SqlCommand = New SqlCommand("proc_MobileNoticeBoard", conn)
    '        'Specifying command is a Stored Procedure
    '        cmd.CommandType = CommandType.StoredProcedure
    '        'Providing the parameters required for the Stored Procedure
    '        cmd.Parameters.AddWithValue("@username", uname)
    '        cmd.Parameters.AddWithValue("@Password", PasswordE)
    '        'Create SqlDataReader which reads the data retrieved
    '        Dim r As SqlDataReader = cmd.ExecuteReader()
    '        'Declaring a DataTable to hold the data retrieved
    '        Dim dt As New DataTable("Notice")
    '        dt.Clear()
    '        'Load data from SqlDataReader to DataTable
    '        dt.Load(r)

    '        'Traverse through each row in the data table to fetch values
    '        For Each row As DataRow In dt.Rows
    '            'Capture values and store them in apporpriate variables
    '            Dim msg = row("Message")
    '            Dim msgfrm = row("MsgFrom")
    '            Dim grp = row("GroupType")
    '            Dim day = row("Date").ToString()
    '            'Final html formatting
    '            html1 += "</br></br>Msg From: " + msgfrm + "</br>Group :" + grp + "</br>Message:</br>" + msg + "</br>"
    '            'Iterate over to next row
    '            html2 = html + html1
    '        Next row
    '    End Using

    '    'Return the final formatted data
    '    Return html1
    'End Function
End Class