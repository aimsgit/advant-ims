Imports Microsoft.VisualBasic
Imports System.Data.OleDb
Imports System.Data


Public Class TreeView_FormAccess
    Dim new_dbconn1 As New OleDbConnection

    'Sub Access_Menu(ByVal Access_Per_Frm As String)
    '    new_dbconn1.ConnectionString = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
    '    Dim SearchString, SearchChar, com, sec, sqlF, sqlT, sqlP, sqlPF As String
    '    Dim MyPos, SPos, CPos, Ppos, i As Integer
    '    Dim dt, dt1 As New DataTable
    '    Dim da, da1 As New OleDbDataAdapter

    '    sqlT = "Update TreeView_Data set Access_Flag=0 where Access_Flag=-1"
    '    Dim dbcommand As New OleDbCommand
    '    dbcommand.Connection = new_dbconn1
    '    new_dbconn1.Open()
    '    dbcommand.CommandType = CommandType.Text
    '    dbcommand.CommandText = sqlT
    '    dbcommand.ExecuteNonQuery()
    '    new_dbconn1.Close()

    '    SearchString = Access_Per_Frm        ' String to search in.
    '    SearchChar = "Master"
    '    MyPos = InStr(1, SearchString, SearchChar, CompareMethod.Text)
    '    If MyPos <> 0 Then
    '        sec = (Mid(Access_Per_Frm, MyPos))
    '        MyPos = InStr(1, sec, SearchChar, CompareMethod.Text)
    '        SPos = InStr(MyPos, sec, "[")
    '        Ppos = InStr(MyPos, sec, "]")
    '        Dim Mas As String
    '        Mas = "Master"
    '        For i = SPos + 1 To Ppos - 1
    '            CPos = InStr(i, Access_Per_Frm, ",")
    '            com = Mid(sec, i, 2)

    '            If com = "00" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "01" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "02" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "03" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "04" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "05" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "06" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "07" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "08" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "09" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "10" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "11" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "12" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "13" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "14" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "15" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "16" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "17" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            If com = "18" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Mas + "'"
    '            End If
    '            Flag_Execute(sqlF)
    '            i = i + 2
    '        Next
    '        sqlP = "Select Parent_ID from TreeView_Data where Parent_Name='" + Mas + "' and Parent_ID<>0"
    '        da = New OleDbDataAdapter(sqlP, new_dbconn1)
    '        dt.Clear()
    '        da.Fill(dt)

    '        sqlPF = "select * from TreeView_Data where Access_Flag=-1 and Parent_ID=" + dt.Rows(0)("Parent_ID").ToString + " and Parent_Name='" + Mas + "'"
    '        da1 = New OleDbDataAdapter(sqlPF, new_dbconn1)
    '        dt1.Clear()
    '        da1.Fill(dt1)
    '        If dt1.Rows.Count = 19 Then
    '            sqlPF = "Update TreeView_Data set Access_Flag=-1 where  Parent_ID=0 and Parent_Name='" + Mas + "'"
    '            Flag_Execute(sqlPF)
    '        End If

    '    End If


    '    SearchString = Access_Per_Frm ' String to search in.
    '    SearchChar = "Admin"
    '    MyPos = InStr(1, SearchString, SearchChar, CompareMethod.Text)
    '    If MyPos <> 0 Then
    '        sec = (Mid(Access_Per_Frm, MyPos))
    '        MyPos = InStr(1, sec, SearchChar, CompareMethod.Text)
    '        SPos = InStr(MyPos, sec, "[")
    '        Ppos = InStr(MyPos, sec, "]")
    '        Dim admin As String
    '        admin = "Administration"
    '        For i = SPos + 1 To Ppos - 1
    '            CPos = InStr(i, Access_Per_Frm, ",")
    '            If CPos <> 0 Then
    '                com = Mid(sec, i, 2)
    '                'Response.Write(com & "   ")

    '                If com = "00" Then
    '                    sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + admin + "'"
    '                End If
    '                'MsgBox(sqlF)
    '                If com = "01" Then
    '                    sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + admin + "'"
    '                End If
    '                If com = "02" Then
    '                    sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + admin + "'"
    '                End If
    '                If com = "03" Then
    '                    sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + admin + "'"
    '                End If
    '                If com = "04" Then
    '                    sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + admin + "'"
    '                End If
    '                If com = "05" Then
    '                    sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + admin + "'"
    '                End If
    '                If com = "06" Then
    '                    sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + admin + "'"
    '                End If
    '                If com = "07" Then
    '                    sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + admin + "'"
    '                End If
    '                If com = "08" Then
    '                    sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + admin + "'"
    '                End If
    '                If com = "09" Then
    '                    sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + admin + "'"
    '                End If
    '                Flag_Execute(sqlF)
    '                i = i + 2
    '            End If
    '        Next
    '        sqlP = "Select Parent_ID from TreeView_Data where Parent_Name='" + admin + "' and Parent_ID<>0"
    '        da = New OleDbDataAdapter(sqlP, new_dbconn1)
    '        dt.Clear()
    '        da.Fill(dt)

    '        sqlPF = "select * from TreeView_Data where Access_Flag=-1 and Parent_ID=" + dt.Rows(0)("Parent_ID").ToString + " and Parent_Name='" + admin + "'"
    '        da1 = New OleDbDataAdapter(sqlPF, new_dbconn1)
    '        dt1.Clear()
    '        da1.Fill(dt1)
    '        If dt1.Rows.Count = 10 Then
    '            sqlPF = "Update TreeView_Data set Access_Flag=-1 where  Parent_ID=0 and Parent_Name='" + admin + "'"
    '            Flag_Execute(sqlPF)
    '        End If
    '    End If

    '    SearchString = Access_Per_Frm ' String to search in.
    '    SearchChar = "Staff"
    '    MyPos = InStr(1, SearchString, SearchChar, CompareMethod.Text)
    '    If MyPos <> 0 Then
    '        sec = (Mid(Access_Per_Frm, MyPos))
    '        MyPos = InStr(1, sec, SearchChar, CompareMethod.Text)
    '        'MyPos = InStr(1, sec, SearchChar, CompareMethod.Text)
    '        'sec = (Mid(Access_Per_Frm, MyPos))
    '        SPos = InStr(MyPos, sec, "[")
    '        Ppos = InStr(MyPos, sec, "]")
    '        Dim Stf As String
    '        Stf = "Staff"
    '        For i = SPos + 1 To Ppos - 1
    '            CPos = InStr(i, Access_Per_Frm, ",")
    '            com = Mid(sec, i, 2)
    '            'Response.Write(com & "   ")

    '            If com = "00" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Stf + "'"
    '            End If
    '            Flag_Execute(sqlF)
    '            i = i + 2
    '        Next
    '        sqlP = "Select Parent_ID from TreeView_Data where Parent_Name='" + Stf + "' and Parent_ID<>0"
    '        da = New OleDbDataAdapter(sqlP, new_dbconn1)
    '        dt.Clear()
    '        da.Fill(dt)

    '        sqlPF = "select * from TreeView_Data where Access_Flag=-1 and Parent_ID=" + dt.Rows(0)("Parent_ID").ToString + " and Parent_Name='" + Stf + "'"
    '        da1 = New OleDbDataAdapter(sqlPF, new_dbconn1)
    '        dt1.Clear()
    '        da1.Fill(dt1)
    '        If dt1.Rows.Count = 1 Then
    '            sqlPF = "Update TreeView_Data set Access_Flag=-1 where  Parent_ID=0 and Parent_Name='" + Stf + "'"
    '            Flag_Execute(sqlPF)
    '        End If
    '    End If

    '    SearchString = Access_Per_Frm ' String to search in.
    '    SearchChar = "Accounts"
    '    MyPos = InStr(1, SearchString, SearchChar, CompareMethod.Text)
    '    If MyPos <> 0 Then
    '        sec = (Mid(Access_Per_Frm, MyPos))
    '        MyPos = InStr(1, sec, SearchChar, CompareMethod.Text)
    '        SPos = InStr(MyPos, sec, "[")
    '        Ppos = InStr(MyPos, sec, "]")
    '        Dim Acct As String
    '        Acct = "Accounts"

    '        For i = SPos + 1 To Ppos - 1
    '            CPos = InStr(i, Access_Per_Frm, ",")
    '            com = Mid(sec, i, 2)

    '            If com = "00" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Acct + "'"
    '            End If

    '            If com = "01" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Acct + "'"
    '            End If
    '            If com = "02" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Acct + "'"
    '            End If

    '            If com = "03" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Acct + "'"
    '            End If
    '            If com = "04" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Acct + "'"
    '            End If

    '            If com = "05" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Acct + "'"
    '            End If
    '            If com = "06" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Acct + "'"
    '            End If
    '            Flag_Execute(sqlF)
    '            i = i + 2
    '        Next
    '        sqlP = "Select Parent_ID from TreeView_Data where Parent_Name='" + Acct + "' and Parent_ID<>0"
    '        da = New OleDbDataAdapter(sqlP, new_dbconn1)
    '        dt.Clear()
    '        da.Fill(dt)

    '        sqlPF = "select * from TreeView_Data where Access_Flag=-1 and Parent_ID=" + dt.Rows(0)("Parent_ID").ToString + " and Parent_Name='" + Acct + "'"
    '        da1 = New OleDbDataAdapter(sqlPF, new_dbconn1)
    '        dt1.Clear()
    '        da1.Fill(dt1)
    '        If dt1.Rows.Count = 7 Then
    '            sqlPF = "Update TreeView_Data set Access_Flag=-1 where  Parent_ID=0 and Parent_Name='" + Acct + "'"
    '            Flag_Execute(sqlPF)
    '        End If
    '    End If

    '    SearchString = Access_Per_Frm ' String to search in.
    '    SearchChar = "Assets"
    '    ''MsgBox("Master" & "  " & SearchString & " " & SearchChar)
    '    MyPos = InStr(1, SearchString, SearchChar, CompareMethod.Text)
    '    If MyPos <> 0 Then
    '        sec = (Mid(Access_Per_Frm, MyPos))
    '        MyPos = InStr(1, sec, SearchChar, CompareMethod.Text)
    '        'MyPos = InStr(1, sec, SearchChar, CompareMethod.Text)
    '        SPos = InStr(MyPos, sec, "[")
    '        Ppos = InStr(MyPos, sec, "]")
    '        Dim Ast As String
    '        Ast = "Assets"
    '        For i = SPos + 1 To Ppos - 1
    '            CPos = InStr(i, Access_Per_Frm, ",")
    '            com = Mid(sec, i, 2)
    '            'Response.Write(com & "   ")

    '            If com = "00" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Ast + "'"
    '            End If
    '            If com = "01" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Ast + "'"
    '            End If
    '            If com = "02" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Ast + "'"
    '            End If
    '            If com = "03" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Ast + "'"
    '            End If

    '            Flag_Execute(sqlF)
    '            i = i + 2
    '        Next
    '        sqlP = "Select Parent_ID from TreeView_Data where Parent_Name='" + Ast + "' and Parent_ID<>0"
    '        da = New OleDbDataAdapter(sqlP, new_dbconn1)
    '        dt.Clear()
    '        da.Fill(dt)

    '        sqlPF = "select * from TreeView_Data where Access_Flag=-1 and Parent_ID=" + dt.Rows(0)("Parent_ID").ToString + " and Parent_Name='" + Ast + "'"
    '        da1 = New OleDbDataAdapter(sqlPF, new_dbconn1)
    '        dt1.Clear()
    '        da1.Fill(dt1)

    '        If dt1.Rows.Count = 4 Then
    '            sqlPF = "Update TreeView_Data set Access_Flag=-1 where  Parent_ID=0 and Parent_Name='" + Ast + "'"
    '            Flag_Execute(sqlPF)
    '        End If
    '    End If
    '    'If all childnodes are not allowed then that parent node should also be hidded.



    '    SearchString = Access_Per_Frm ' String to search in.
    '    SearchChar = "Payroll"
    '    ''MsgBox("Master" & "  " & SearchString & " " & SearchChar)
    '    MyPos = InStr(1, SearchString, SearchChar, CompareMethod.Text)
    '    If MyPos <> 0 Then
    '        sec = (Mid(Access_Per_Frm, MyPos))
    '        MyPos = InStr(1, sec, SearchChar, CompareMethod.Text)
    '        'MyPos = InStr(1, sec, SearchChar, CompareMethod.Text)
    '        SPos = InStr(MyPos, sec, "[")
    '        Ppos = InStr(MyPos, sec, "]")
    '        Dim pay As String
    '        pay = "Payroll"
    '        For i = SPos + 1 To Ppos - 1
    '            CPos = InStr(i, Access_Per_Frm, ",")
    '            com = Mid(sec, i, 2)
    '            'Response.Write(com & "   ")

    '            If com = "00" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + pay + "'"
    '            End If
    '            If com = "01" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + pay + "'"
    '            End If
    '            If com = "02" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + pay + "'"
    '            End If
    '            If com = "03" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + pay + "'"
    '            End If
    '            Flag_Execute(sqlF)
    '            i = i + 2
    '        Next
    '        sqlP = "Select Parent_ID from TreeView_Data where Parent_Name='" + pay + "' and Parent_ID<>0"
    '        da = New OleDbDataAdapter(sqlP, new_dbconn1)
    '        dt.Clear()
    '        da.Fill(dt)

    '        sqlPF = "select * from TreeView_Data where Access_Flag=-1 and Parent_ID=" + dt.Rows(0)("Parent_ID").ToString + " and Parent_Name='" + pay + "'"
    '        da1 = New OleDbDataAdapter(sqlPF, new_dbconn1)
    '        dt1.Clear()
    '        da1.Fill(dt1)
    '        If dt1.Rows.Count = 4 Then
    '            sqlPF = "Update TreeView_Data set Access_Flag=-1 where  Parent_ID=0 and Parent_Name='" + pay + "'"
    '            Flag_Execute(sqlPF)
    '        End If
    '    End If

    '    SearchString = Access_Per_Frm ' String to search in.
    '    SearchChar = "Library"
    '    MyPos = InStr(1, SearchString, SearchChar, CompareMethod.Text)
    '    If MyPos <> 0 Then
    '        sec = (Mid(Access_Per_Frm, MyPos))
    '        MyPos = InStr(1, sec, SearchChar, CompareMethod.Text)
    '        SPos = InStr(MyPos, sec, "[")
    '        Ppos = InStr(MyPos, sec, "]")
    '        Dim Lbr As String
    '        Lbr = "Library"
    '        For i = SPos + 1 To Ppos - 1
    '            CPos = InStr(i, Access_Per_Frm, ",")
    '            com = Mid(sec, i, 2)
    '            'Response.Write(com & "   ")

    '            'If com = "00" Then
    '            '    sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Lbr + "'"
    '            'End If
    '            If com = "00" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Lbr + "'"
    '            End If
    '            If com = "01" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Lbr + "'"
    '            End If
    '            If com = "02" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Lbr + "'"
    '            End If
    '            Flag_Execute(sqlF)
    '            i = i + 2
    '        Next
    '        sqlP = "Select Parent_ID from TreeView_Data where Parent_Name='" + Lbr + "' and Parent_ID<>0"
    '        da = New OleDbDataAdapter(sqlP, new_dbconn1)
    '        dt.Clear()
    '        da.Fill(dt)

    '        sqlPF = "select * from TreeView_Data where Access_Flag=-1 and Parent_ID=" + dt.Rows(0)("Parent_ID").ToString + " and Parent_Name='" + Lbr + "'"
    '        da1 = New OleDbDataAdapter(sqlPF, new_dbconn1)
    '        dt1.Clear()
    '        da1.Fill(dt1)
    '        If dt1.Rows.Count = 3 Then
    '            sqlPF = "Update TreeView_Data set Access_Flag=-1 where  Parent_ID=0 and Parent_Name='" + Lbr + "'"
    '            Flag_Execute(sqlPF)
    '        End If
    '    End If

    '    SearchString = Access_Per_Frm ' String to search in.
    '    SearchChar = "Adms"
    '    MyPos = InStr(1, SearchString, SearchChar, CompareMethod.Text)
    '    If MyPos <> 0 Then
    '        sec = (Mid(Access_Per_Frm, MyPos))
    '        MyPos = InStr(1, sec, SearchChar, CompareMethod.Text)
    '        SPos = InStr(MyPos, sec, "[")
    '        Ppos = InStr(MyPos, sec, "]")
    '        Dim Admis As String
    '        Admis = "Admission"
    '        For i = SPos + 1 To Ppos - 1
    '            CPos = InStr(i, Access_Per_Frm, ",")
    '            com = Mid(sec, i, 2)
    '            'Response.Write(com & "   ")

    '            If com = "00" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Admis + "'"
    '            End If
    '            If com = "01" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Admis + "'"
    '            End If
    '            If com = "02" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Admis + "'"
    '            End If
    '            Flag_Execute(sqlF)
    '            i = i + 2
    '        Next

    '        sqlP = "Select Parent_ID from TreeView_Data where Parent_Name='" + Admis + "' and Parent_ID<>0"
    '        da = New OleDbDataAdapter(sqlP, new_dbconn1)
    '        dt.Clear()
    '        da.Fill(dt)

    '        sqlPF = "select * from TreeView_Data where Access_Flag=-1 and Parent_ID=" + dt.Rows(0)("Parent_ID").ToString + " and Parent_Name='" + Admis + "'"
    '        da1 = New OleDbDataAdapter(sqlPF, new_dbconn1)
    '        dt1.Clear()
    '        da1.Fill(dt1)
    '        If dt1.Rows.Count = 3 Then
    '            sqlPF = "Update TreeView_Data set Access_Flag=-1 where  Parent_ID=0 and Parent_Name='" + Admis + "'"
    '            Flag_Execute(sqlPF)
    '        End If
    '    End If

    '    SearchString = Access_Per_Frm ' String to search in.
    '    SearchChar = "Std"
    '    MyPos = InStr(1, SearchString, SearchChar, CompareMethod.Text)
    '    If MyPos <> 0 Then
    '        sec = (Mid(Access_Per_Frm, MyPos))
    '        MyPos = InStr(1, sec, SearchChar, CompareMethod.Text)
    '        SPos = InStr(MyPos, sec, "[")
    '        Ppos = InStr(MyPos, sec, "]")
    '        Dim Std As String
    '        Std = "Students"
    '        For i = SPos + 1 To Ppos - 1
    '            CPos = InStr(i, Access_Per_Frm, ",")
    '            com = Mid(sec, i, 2)
    '            'Response.Write(com & "   ")

    '            If com = "00" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Std + "'"
    '            End If
    '            If com = "01" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Std + "'"
    '            End If
    '            If com = "02" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Std + "'"
    '            End If
    '            Flag_Execute(sqlF)
    '            i = i + 2
    '        Next
    '        sqlP = "Select Parent_ID from TreeView_Data where Parent_Name='" + Std + "' and Parent_ID<>0"
    '        da = New OleDbDataAdapter(sqlP, new_dbconn1)
    '        dt.Clear()
    '        da.Fill(dt)

    '        sqlPF = "select * from TreeView_Data where Access_Flag=-1 and Parent_ID=" + dt.Rows(0)("Parent_ID").ToString + " and Parent_Name='" + Std + "'"
    '        da1 = New OleDbDataAdapter(sqlPF, new_dbconn1)
    '        dt1.Clear()
    '        da1.Fill(dt1)
    '        If dt1.Rows.Count = 3 Then
    '            sqlPF = "Update TreeView_Data set Access_Flag=-1 where  Parent_ID=0 and Parent_Name='" + Std + "'"
    '            Flag_Execute(sqlPF)
    '        End If
    '    End If

    '    SearchString = Access_Per_Frm ' String to search in.
    '    SearchChar = "Programs"
    '    MyPos = InStr(1, SearchString, SearchChar, CompareMethod.Text)
    '    If MyPos <> 0 Then
    '        sec = (Mid(Access_Per_Frm, MyPos))
    '        MyPos = InStr(1, sec, SearchChar, CompareMethod.Text)
    '        SPos = InStr(MyPos, sec, "[")
    '        Ppos = InStr(MyPos, sec, "]")
    '        Dim Progs As String
    '        Progs = "Programs"
    '        For i = SPos + 1 To Ppos - 1
    '            CPos = InStr(i, Access_Per_Frm, ",")
    '            com = Mid(sec, i, 2)
    '            'Response.Write(com & "   ")

    '            If com = "00" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Progs + "'"
    '                ''sqlF = "insert into User_Authorization(Username,Form_ID,Parent_Name)values('" + txtUserName.Text + "','" + com + "', '" + Progs + "')"
    '                'sqlF = "SELECT TreeView_Data.ID, TreeView_Data.Parent_ID, TreeView_Data.Title, TreeView_Data.Parent_Name, TreeView_Data.LinkName, TreeView_Data.Form_ID FROM TreeView_Data WHERE (((TreeView_Data.Parent_Name)<>'" + Progs + "') AND ((TreeView_Data.Form_ID)<>'" + com + "'))"
    '            End If
    '            If com = "01" Then
    '                sqlF = "Update TreeView_Data set Access_Flag=-1 where  Form_ID='" + com + "' and Parent_Name='" + Progs + "'"

    '            End If
    '            Flag_Execute(sqlF)
    '            i = i + 2
    '        Next
    '        sqlP = "Select Parent_ID from TreeView_Data where Parent_Name='" + Progs + "' and Parent_ID<>0"
    '        da = New OleDbDataAdapter(sqlP, new_dbconn1)
    '        dt.Clear()
    '        da.Fill(dt)

    '        sqlPF = "select * from TreeView_Data where Access_Flag=-1 and Parent_ID=" + dt.Rows(0)("Parent_ID").ToString + " and Parent_Name='" + Progs + "'"
    '        da1 = New OleDbDataAdapter(sqlPF, new_dbconn1)
    '        dt1.Clear()
    '        da1.Fill(dt1)
    '        If dt1.Rows.Count = 2 Then
    '            sqlPF = "Update TreeView_Data set Access_Flag=-1 where  Parent_ID=0 and Parent_Name='" + Progs + "'"
    '            Flag_Execute(sqlPF)
    '        End If
    '    End If
    'End Sub
    Sub Flag_Execute(ByVal SqlFlag As String)
        Dim myDS As New GlobalDataSet
        Dim myDA As New OleDbDataAdapter()
        Dim dbcommand As New OleDbCommand
        dbcommand.Connection = new_dbconn1
        new_dbconn1.Open()
        dbcommand.CommandType = CommandType.Text
        dbcommand.CommandText = SqlFlag
        myDA.SelectCommand = dbcommand
        myDS.Clear()
        myDA.Fill(myDS, "TreeView_Data")
        dbcommand.ExecuteNonQuery()
        new_dbconn1.Close()
    End Sub

End Class
