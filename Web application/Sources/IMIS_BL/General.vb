''Copyright (c) 2016-2017 Swiss Agency for Development and Cooperation (SDC)
''
''The program users must agree to the following terms:
''
''Copyright notices
''This program is free software: you can redistribute it and/or modify it under the terms of the GNU AGPL v3 License as published by the 
''Free Software Foundation, version 3 of the License.
''This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of 
''MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU AGPL v3 License for more details www.gnu.org.
''
''Disclaimer of Warranty
''There is no warranty for the program, to the extent permitted by applicable law; except when otherwise stated in writing the copyright 
''holders and/or other parties provide the program "as is" without warranty of any kind, either expressed or implied, including, but not 
''limited to, the implied warranties of merchantability and fitness for a particular purpose. The entire risk as to the quality and 
''performance of the program is with you. Should the program prove defective, you assume the cost of all necessary servicing, repair or correction.
''
''Limitation of Liability 
''In no event unless required by applicable law or agreed to in writing will any copyright holder, or any other party who modifies and/or 
''conveys the program as permitted above, be liable to you for damages, including any general, special, incidental or consequential damages 
''arising out of the use or inability to use the program (including but not limited to loss of data or data being rendered inaccurate or losses 
''sustained by you or third parties or a failure of the program to operate with any other programs), even if such holder or other party has been 
''advised of the possibility of such damages.
''
''In case of dispute arising out or in relation to the use of the program, it is subject to the public law of Switzerland. The place of jurisdiction is Berne.
'
' 
'

Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Public Class GeneralBL


    Public Function getMessage(ByVal MessageID As String) As String
        Return System.Web.HttpContext.GetGlobalResourceObject("Resource", MessageID)
    End Function
    Public Function GetGender() As DataTable

        Dim dtbl As New DataTable
        dtbl.Columns.Add("Code")
        dtbl.Columns.Add("Gender")
        Dim dr As DataRow = dtbl.NewRow
        dr("Code") = ""
        dr("Gender") = getMessage("T_SELECTGENDER")
        dtbl.Rows.Add(dr)
        dr = dtbl.NewRow
        dr("Code") = "M"
        dr("Gender") = getMessage("T_MALE")
        dtbl.Rows.Add(dr)
        dr = dtbl.NewRow
        dr("Code") = "F"
        dr("Gender") = getMessage("T_FEMALE")
        dtbl.Rows.Add(dr)
        dr = dtbl.NewRow
        dr("Code") = "O"
        dr("Gender") = getMessage("T_OTHER")
        dtbl.Rows.Add(dr)
        Return dtbl
    End Function
    Public Function GetMaritalStatus() As DataTable

        Dim dtbl As New DataTable
        dtbl.Columns.Add("Code")
        dtbl.Columns.Add("Status")
        Dim dr As DataRow = dtbl.NewRow
        dr("Code") = ""
        dr("Status") = getMessage("T_SELECTSTATUS")
        dtbl.Rows.Add(dr)
        dr = dtbl.NewRow
        dr("Code") = "M"
        dr("Status") = getMessage("T_MARRIED")
        dtbl.Rows.Add(dr)
        dr = dtbl.NewRow
        dr("Code") = "S"
        dr("Status") = getMessage("T_SINGLE")
        dtbl.Rows.Add(dr)
        dr = dtbl.NewRow
        dr("Code") = "D"
        dr("Status") = getMessage("T_DIVORCED")
        dtbl.Rows.Add(dr)
        dr = dtbl.NewRow
        dr("Code") = "W"
        dr("Status") = getMessage("T_WIDOWED")
        dtbl.Rows.Add(dr)
        dr = dtbl.NewRow
        dr("Code") = "N"
        dr("Status") = getMessage("T_NOTSPECIFIED")
        dtbl.Rows.Add(dr)

        Return dtbl
    End Function
    Public Function GetYesNo() As DataTable

        Dim dtbl As New DataTable
        dtbl.Columns.Add("Code")
        dtbl.Columns.Add("Status")
        Dim dr As DataRow = dtbl.NewRow
        dr("Code") = ""
        dr("Status") = getMessage("T_SELECTYESNO")
        dtbl.Rows.Add(dr)
        dr = dtbl.NewRow
        dr("Code") = "1"
        dr("Status") = getMessage("T_YES")
        dtbl.Rows.Add(dr)
        dr = dtbl.NewRow
        dr("Code") = "0"
        dr("Status") = getMessage("T_NO")
        dtbl.Rows.Add(dr)
        Return dtbl
    End Function
    Public Function GetYesN(Optional ByVal showSelect As Boolean = False) As DataTable

        Dim dtbl As New DataTable
        dtbl.Columns.Add("Code")
        dtbl.Columns.Add("Status")
        Dim dr As DataRow

        If showSelect = True Then
            dr = dtbl.NewRow
            dr("Code") = ""
            dr("Status") = getMessage("T_SELECTYESNO")
            dtbl.Rows.Add(dr)
        End If
        
        dr = dtbl.NewRow
        dr("Code") = 1
        dr("Status") = getMessage("T_YES")
        dtbl.Rows.Add(dr)
        dr = dtbl.NewRow
        dr("Code") = 0
        dr("Status") = getMessage("T_NO")
        dtbl.Rows.Add(dr)
        Return dtbl
    End Function
     Public Function GetLanguage() As DataTable
        Dim DAL As New IMIS_DAL.LanguagesDAL
        Dim dt As DataTable = DAL.GetLanguages
        Dim dr As DataRow = dt.NewRow
        dr("LanguageCode") = -1
        dr("LanguageName") = getMessage("T_SELECTLANGUAGE")
        dt.Rows.InsertAt(dr, 0)
        Return dt
    End Function
    Public Function GetPatient(Optional ByVal showSelect As Boolean = False) As DataTable
        Dim dtbl As New DataTable
        dtbl.Columns.Add("ID")
        dtbl.Columns.Add("Patient")
        Dim dr As DataRow
        If showSelect = True Then
            dr = dtbl.NewRow
            dr("ID") = "0"
            dr("Patient") = getMessage("T_SELECTPATIENT")
            dtbl.Rows.Add(dr)
        End If

        dr = dtbl.NewRow
        dr("ID") = "1"
        dr("Patient") = getMessage("T_MAN")
        dtbl.Rows.Add(dr)

        dr = dtbl.NewRow
        dr("ID") = "2"
        dr("Patient") = getMessage("T_WOMAN")
        dtbl.Rows.Add(dr)

        dr = dtbl.NewRow
        dr("ID") = "3"
        dr("Patient") = getMessage("T_ADULT")
        dtbl.Rows.Add(dr)

        dr = dtbl.NewRow
        dr("ID") = "4"
        dr("Patient") = getMessage("T_CHILD")
        dtbl.Rows.Add(dr)

        Return dtbl

    End Function

    'Public Function GetPayerType(Optional ByVal showSelect As Boolean = False) As DataTable
    '    Dim dtbl As New DataTable
    '    Dim dr As DataRow
    '    dtbl.Columns.Add("Code")
    '    dtbl.Columns.Add("PayerType")
    '    If showSelect = True Then
    '        dr = dtbl.NewRow
    '        dr("Code") = ""
    '        dr("PayerType") = getMessage("T_SELECTPAYERTYPE")
    '        dtbl.Rows.Add(dr)
    '    End If
    '    dr = dtbl.NewRow
    '    dr("Code") = "G"
    '    dr("PayerType") = getMessage("T_GOVERNMENT")
    '    dtbl.Rows.Add(dr)

    '    dr = dtbl.NewRow
    '    dr("Code") = "L"
    '    dr("PayerType") = getMessage("T_LOCALAUTHORITY")
    '    dtbl.Rows.Add(dr)

    '    dr = dtbl.NewRow
    '    dr("Code") = "C"
    '    dr("PayerType") = getMessage("T_COOPERATIVE")
    '    dtbl.Rows.Add(dr)

    '    dr = dtbl.NewRow
    '    dr("Code") = "P"
    '    dr("PayerType") = getMessage("T_PRIVATEORGANIZATION")
    '    dtbl.Rows.Add(dr)

    '    dr = dtbl.NewRow
    '    dr("Code") = "D"
    '    dr("PayerType") = getMessage("T_DONOR")
    '    dtbl.Rows.Add(dr)

    '    dr = dtbl.NewRow
    '    dr("Code") = "O"
    '    dr("PayerType") = getMessage("T_OTHER")
    '    dtbl.Rows.Add(dr)

    '    Return dtbl
    'End Function

    'Public Function GetNumberTypeStatus(ByVal min As Integer, ByVal max As Integer) As DataTable

    '    Dim dtbl As New DataTable
    '    dtbl.Columns.Add("value")
    '    dtbl.Columns.Add("name")
    '    Dim dr As DataRow
    '    dr = dtbl.NewRow
    '    dr("value") = 0
    '    dr("name") = getMessage("T_STATUS")
    '    dtbl.Rows.Add(dr)
    '    If min = 0 Then
    '        min = 1
    '    End If
    '    For i As Integer = min To max

    '        If min > max Then
    '            Exit For
    '        End If

    '        dr = dtbl.NewRow
    '        dr = dtbl.NewRow
    '        dr("value") = i
    '        dr("name") = min
    '        min += 1
    '        dtbl.Rows.Add(dr)
    '    Next
    '    Return dtbl
    'End Function

    'Public Function GetReviewStatus(Optional ByVal showSelect As Boolean = False) As DataTable
    '    Dim dtbl As New DataTable
    '    Dim dr As DataRow
    '    dtbl.Columns.Add("Code")
    '    dtbl.Columns.Add("Status")
    '    If showSelect = True Then
    '        dr = dtbl.NewRow
    '        dr("Code") = 7
    '        dr("Status") = getMessage("T_SELECTSTATUS")
    '        dtbl.Rows.Add(dr)
    '    End If
    '    dr = dtbl.NewRow
    '    dr("Code") = 0
    '    dr("Status") = getMessage("T_IDLE")
    '    dtbl.Rows.Add(dr)

    '    dr = dtbl.NewRow
    '    dr("Code") = 1
    '    dr("Status") = getMessage("T_NOTSELECTED")
    '    dtbl.Rows.Add(dr)

    '    dr = dtbl.NewRow
    '    dr("Code") = 2
    '    dr("Status") = getMessage("T_SELECTED")
    '    dtbl.Rows.Add(dr)

    '    dr = dtbl.NewRow
    '    dr("Code") = 4
    '    dr("Status") = getMessage("T_REVIEWED")
    '    dtbl.Rows.Add(dr)

    '    dr = dtbl.NewRow
    '    dr("Code") = 8
    '    dr("Status") = getMessage("T_BYPASSED")
    '    dtbl.Rows.Add(dr)


    '    Return dtbl
    'End Function

    Public Function GetItemServiceStatus(Optional ByVal showSelect As Boolean = False) As DataTable
        Dim dtbl As New DataTable
        Dim dr As DataRow
        dtbl.Columns.Add("Code")
        dtbl.Columns.Add("Status")
        If showSelect = True Then
            dr = dtbl.NewRow
            dr("Code") = 3
            dr("Status") = getMessage("T_SELECTSTATUS")
            dtbl.Rows.Add(dr)
        End If
        dr = dtbl.NewRow
        dr("Code") = 1
        dr("Status") = getMessage("T_PASSED")
        dtbl.Rows.Add(dr)

        dr = dtbl.NewRow
        dr("Code") = 2
        dr("Status") = getMessage("T_REJECTED")
        dtbl.Rows.Add(dr)

        Return dtbl
    End Function

    Public Function GetMonths(ByVal start As Integer, ByVal ending As Integer) As DataTable
        Dim dtmonth As New DataTable
        Dim gen As New GeneralBL
        dtmonth.Columns.Add("MonthNum")
        dtmonth.Columns.Add("MonthName")
        Dim month() As String = {gen.getMessage("T_JANUARY"), gen.getMessage("T_FEBRUARY"), gen.getMessage("T_MARCH"), gen.getMessage("T_APRIL"), gen.getMessage("T_MAY"), gen.getMessage("T_JUNE"), gen.getMessage("T_JULY"), gen.getMessage("T_AUGUST"), gen.getMessage("T_SEPTEMBER"), gen.getMessage("T_OCTOBER"), gen.getMessage("T_NOVEMBER"), gen.getMessage("T_DECEMBER")}
        Dim dr As DataRow

        dr = dtmonth.NewRow
        dr("monthNum") = 0
        dr("monthName") = getMessage("T_MONTH")
        dtmonth.Rows.Add(dr)


        If ending > 12 Then
            ending = 12
        End If

        If start < 0 Then
            start = 1
        End If


        For i As Integer = start To ending
            dr = dtmonth.NewRow
            dr("MonthNum") = i
            dr("MonthName") = month(i - 1)
            dtmonth.Rows.Add(dr)
        Next

        Return dtmonth
    End Function

    Public Function GetYears(ByVal start As Integer, ByVal ending As Integer) As DataTable
        Dim dtYear As New DataTable
        dtYear.Columns.Add("YearId", GetType(Integer))
        dtYear.Columns.Add("Year")

        Dim dr As DataRow

        dr = dtYear.NewRow

        dr("YearId") = 0
        dr("Year") = getMessage("T_YEAR")
        dtYear.Rows.Add(dr)

        For i As Integer = start To ending
            dr = dtYear.NewRow
            dr("YearId") = i
            dr("Year") = i
            dtYear.Rows.Add(dr)
        Next

        Return dtYear
    End Function
    Public Function Decrypt(ByVal key As String, ByVal inFile As String) As String
        Dim DESalg As New DESCryptoServiceProvider
        Dim fs As New FileStream(inFile, FileMode.Open)
        Dim objEncod As Encoding = Encoding.ASCII
        DESalg.IV = objEncod.GetBytes("11110000")

        DESalg.Key = objEncod.GetBytes(key)
        Dim cryp As New CryptoStream(fs, DESalg.CreateDecryptor(DESalg.Key, DESalg.IV), CryptoStreamMode.Read)
        Dim fileInf As New IO.FileInfo(inFile)
        Dim strReader As New StreamReader(cryp)

        Dim str As String = strReader.ReadToEnd
        strReader.Close()
        cryp.Close()
        fs.Close()

        Return str
    End Function
    Public Function GetSMSStatus() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Value")
        dt.Columns.Add("Status")
        Dim dr As DataRow
        dr = dt.NewRow
        dr("Value") = -1
        dr("Status") = getMessage("T_SELECTSTATUS")
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Value") = 0
        dr("Status") = getMessage("T_RECEIVED")
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Value") = 1
        dr("Status") = getMessage("T_FAILED")
        dt.Rows.Add(dr)
        Return dt
    End Function
    Public Function GetPeriodNo(ByVal Type As Char) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Period")
        dt.Columns.Add("Value")
        'Dim count As Integer
        Dim dr As DataRow
        'If Type = "M" Then
        '    count = 12
        'ElseIf Type = "Q" Then
        '    count = 4
        'ElseIf Type = "Y" Then
        '    count = 1
        'End If
        'For i As Integer = 1 To count
        '    dr = dt.NewRow
        '    dr("Period") = i
        '    dr("Value") = i
        '    dt.Rows.Add(dr)
        'Next

        If Type = "Y" Then
            dr = dt.NewRow
            dr("Period") = "--" & getMessage("L_PERIOD") & "--"
            dr("Value") = 0
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("L_YEAR")
            dr("Value") = 1
            dt.Rows.Add(dr)
        ElseIf Type = "Q" Then
            dr = dt.NewRow
            dr("Period") = "--" & getMessage("L_PERIOD") & "--"
            dr("Value") = 0
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("M_Q1")
            dr("Value") = 1
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("M_Q2")
            dr("Value") = 2
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("M_Q3")
            dr("Value") = 3
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("M_Q4")
            dr("Value") = 4
            dt.Rows.Add(dr)
        ElseIf Type = "M" Then
            dr = dt.NewRow
            dr("Period") = "--" & getMessage("L_PERIOD") & "--"
            dr("Value") = 0
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("T_JANUARY")
            dr("Value") = 1
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("T_FEBRUARY")
            dr("Value") = 2
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("T_MARCH")
            dr("Value") = 3
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("T_APRIL")
            dr("Value") = 4
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("T_MAY")
            dr("Value") = 5
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("T_JUNE")
            dr("Value") = 6
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("T_JULY")
            dr("Value") = 7
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("T_AUGUST")
            dr("Value") = 8
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("T_SEPTEMBER")
            dr("Value") = 9
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("T_OCTOBER")
            dr("Value") = 10
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("T_NOVEMBER")
            dr("Value") = 11
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("Period") = getMessage("T_DECEMBER")
            dr("Value") = 12
            dt.Rows.Add(dr)
        End If
        Return dt
    End Function
    Public Function sendSMS(ByVal PhoneNumber As String, ByVal Message As String) As Boolean
        Dim WebRequest As Net.WebRequest 'object for WebRequest
        Dim WebResponse As Net.WebResponse 'object for WebResponse



        Dim serv As String = "http://smsplus3.routesms.com:8080/bulksms/bulksms?username=paul1&password=gd7heq&type=0&dlr=0&destination="
        Dim Numb As String = PhoneNumber
        Dim Mess As String = "&source=BEPHA%20IMIS&message="
        Mess += Message

        Dim URL As String = serv & Numb & Mess
        Dim WebResponseString As String = ""


        WebRequest = Net.HttpWebRequest.Create(URL) 'Hit URL Link
        WebRequest.Timeout = 25000
        Try
            WebResponse = WebRequest.GetResponse 'Get Response
            Dim reader As IO.StreamReader = New IO.StreamReader(WebResponse.GetResponseStream)
            'Read Response and store in variable
            WebResponseString = reader.ReadToEnd()
            WebResponse.Close()
            Return True
            ' Response.Write(WebResponseString) 'Display Response.
        Catch ex As Exception
            WebResponseString = "Request Timeout" 'If any exception occur.
            System.Web.HttpContext.Current.Response.Write(WebResponseString)
            Return False
        End Try
    End Function
    Public Function ReadSMSDatatable(ByVal dt As DataTable) As String


        Dim strReturn As String = ""
        For Each row As DataRow In dt.Rows
            Dim Num As String = row("PhoneNumber").ToString
            If Num.StartsWith("255") And Num.Length = 12 Then
                If sendSMS(Num, row("SMSMessage")) = True Then
                    strReturn += Num & " SMS sent OK" & "<br/>"
                Else
                    strReturn += Num & " SMS Failed" & "<br/>"
                End If
            Else
                strReturn += Num & "Invalid Phone Number" & "<br/>"
            End If
        Next
        If strReturn.Length = 0 Then Return "Nothing to send for selected period"
        Return strReturn
    End Function

End Class
