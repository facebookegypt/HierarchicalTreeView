Imports System.Data.OleDb
'======Creadits--------------
'Evry1falls [Ahmed Samir] : (+20) 120 0908 486
'projectzone.co
'----------------------------
Module Connections
    Dim DBLocation As String = Application.StartupPath & "\hierarchical.accdb"
    Dim DBPass As String = ("projectzone.co")
    Dim CN As New OleDb.OleDbConnection With
        {
        .ConnectionString =
        ("Provider = Microsoft.ACE.OLEDB.12.0;Data Source= " &
        "'" & DBLocation & "'; " &
        "Jet OLEDB:Database Password = '" & DBPass & "'; " &
        "Persist Security Info=True;")
                }
    Public DateCreatedModified As Date = Now.Date
    Public Trans As OleDbTransaction = Nothing
    Public Function DBConnected() As Boolean
        Dim Result As Boolean = False
        If CN.State = ConnectionState.Open Then CN.Close()
        Try
            CN.Open()
            Trans = CN.BeginTransaction(IsolationLevel.ReadCommitted)
        Catch ex As Exception
            MsgBox("Error Database connection : " & ex.Message, MsgBoxStyle.Critical)
            Result = False
            Return Result
            Exit Function
        End Try
        Result = True
        Return Result
    End Function
    Public Sub _ExecuteCMD(ByVal _SqlStmnt As String, ByRef _ThisCommand As OleDbCommand)
        _ThisCommand = New OleDbCommand
        With _ThisCommand
            .Connection = CN
            .Transaction = Trans
            .CommandType = CommandType.Text
            .CommandText = _SqlStmnt
        End With
    End Sub
    Public Sub PopulateTreeView(TRV As TreeView)
        TRV.Nodes.Clear()
        Dim ImgLst As New ImageList()
        Dim TRN, TRN0, TRN1, TRN2 As TreeNode
#Region "Populate ImageList"
        'Populate ImageList With Images from Database Table [BasicInfo]---------
        TRV.ImageList = ImgLst
        Dim SqlStrImg As String = ("SELECT UsrID,Usr_IMG FROM BasicInfo")
        Dim ImgCMD As New OleDbCommand
        _ExecuteCMD(SqlStrImg, ImgCMD)
        Dim ImgReader As OleDbDataReader = ImgCMD.ExecuteReader
        If ImgReader.HasRows Then
            While ImgReader.Read
                'User Photo=========================================
                Dim ImageBytes As Byte() = CType(ImgReader!Usr_IMG, Byte())
                Dim MyStream As New IO.MemoryStream(ImageBytes)
                Dim IMG As Image = Image.FromStream(MyStream)
                ImgLst.Images.Add(ImgReader!UsrID, IMG)
                MyStream.Flush()
                MyStream.Close()
                '===================================================
            End While
            ImgReader.Close()
        End If
        ImgCMD.Dispose()
        '---------------------------------------------------------------------------
#End Region
        TRV.BeginUpdate()
        Dim SqlStr As String =
            ("SELECT BasicInfo.UsrID, BasicInfo.Usr_Fnm, BasicInfo.Usr_Lnm, BasicInfo.Usr_CityID, BasicInfo.Usr_Adrs, " &
            "BasicInfo.Usr_Phon, BasicInfo.Usr_Mob, BasicInfo.Usr_Gndr, BasicInfo.Usr_Bdate, BasicInfo.Usr_IMG, us_cities.CITY, " &
            "us_states.STATE_CODE From us_states INNER Join (us_cities INNER Join BasicInfo On " &
            "us_cities.ID = BasicInfo.Usr_CityID) ON us_states.ID = us_cities.ID_STATE;")
        Dim SelectCMD As New OleDbCommand
        _ExecuteCMD(SqlStr, SelectCMD)
        Dim SelectReader As OleDbDataReader = SelectCMD.ExecuteReader
        If SelectReader.HasRows Then
            While SelectReader.Read
                'TRN : Full Name
                TRN = New TreeNode(SelectReader!UsrID)
                With TRN
                    .Name = SelectReader!UsrID
                    .Text = SelectReader!Usr_Fnm & "," & SelectReader!Usr_Lnm
                    .StateImageKey = SelectReader!UsrID.ToString
                    .ImageKey = SelectReader!UsrID.ToString
                    .SelectedImageKey = SelectReader!UsrID.ToString
                    .ToolTipText = ("User Full Name")
                End With
                TRV.Nodes.Add(TRN)
                'TRN0 : Full Address
                TRN0 = New TreeNode(SelectReader!UsrID)
                With TRN0
                    .Name = SelectReader!UsrID
                    .Text = SelectReader!CITY & "," & SelectReader!STATE_CODE & "," & SelectReader!Usr_Adrs
                    .StateImageKey = SelectReader!UsrID.ToString
                    .ImageKey = SelectReader!UsrID.ToString
                    .SelectedImageKey = SelectReader!UsrID.ToString
                    .ToolTipText = ("User Full Address")
                End With
                TRN.Nodes.Add(TRN0)
                'TRN1 : Contact
                TRN1 = New TreeNode(SelectReader!UsrID)
                With TRN1
                    .Name = SelectReader!UsrID
                    .Text = SelectReader!Usr_Phon & "," & SelectReader!Usr_Mob
                    .StateImageKey = SelectReader!UsrID.ToString
                    .ImageKey = SelectReader!UsrID.ToString
                    .SelectedImageKey = SelectReader!UsrID.ToString
                    .ToolTipText = ("User phone numbers")
                End With
                TRN.Nodes.Add(TRN1)
                'TRN2 : Contact
                TRN2 = New TreeNode(SelectReader!UsrID)
                With TRN2
                    .Name = SelectReader!UsrID
                    .Text = SelectReader!Usr_Gndr & "," & SelectReader!Usr_Bdate
                    .StateImageKey = SelectReader!UsrID.ToString
                    .ImageKey = SelectReader!UsrID.ToString
                    .SelectedImageKey = SelectReader!UsrID.ToString
                    .ToolTipText = ("User Gender and Birthdate")
                End With
                TRN.Nodes.Add(TRN2)
            End While
            SelectReader.Close()
        End If
        TRV.EndUpdate()
    End Sub
    Public Function FindNode(SearchTerm As String, TRV As TreeView) As String
        'Reset TreeView
        TRV.CollapseAll()
        'Begin Search
        Dim AllSubjectsCount As Integer = TRV.GetNodeCount(False)
        Dim SrchRslt As Integer = 0
        For I As Integer = 0 To AllSubjectsCount - 1
            'Tolower : False case sensitive
            'Contains : False case sensitive
            If TRV.Nodes(I).Text.ToLower.Contains(SearchTerm.ToLower) Or _
                TRV.Nodes(I).Text = (SearchTerm) Then
                'Expands all search results
                TRV.Nodes(I).Expand()
                'High-light search result
                TRV.Nodes(I).BackColor = Color.Yellow
                TRV.Nodes(I).ForeColor = Color.Red
                SrchRslt += 1
            Else
                'Clear other nodes and previous search result
                TRV.Nodes(I).BackColor = Nothing
                TRV.Nodes(I).ForeColor = Nothing
            End If
            Dim trn As New TreeNode
            trn = TRV.Nodes(I)
            For Each Trn1 As TreeNode In trn.Nodes
                If Trn1.Text = SearchTerm Or _
                    Trn1.Text.ToLower.Contains(SearchTerm.ToLower) Then
                    trn.Expand()
                    Trn1.BackColor = Color.Yellow
                    Trn1.ForeColor = Color.Red
                    SrchRslt += 1
                Else
                    Trn1.BackColor = Nothing
                    Trn1.ForeColor = Nothing
                End If
            Next
        Next
        Return ("Found " & SrchRslt & " result(s).")
    End Function
    Public Function GetCityCountry(City_ID As Long) As String
        'Function Returs (CITY) from [us_cities] and "-" and [STATE_CODE] from [us_states]
        Dim CmboStr As String = String.Empty
        Dim SqlStr As String =
            ("SELECT us_cities.ID, us_cities.CITY, us_states.STATE_CODE " &
             "FROM us_states RIGHT JOIN us_cities ON us_states.ID = us_cities.ID_STATE " &
             "WHERE (((us_cities.ID)=" & City_ID & "));")
        Dim CMD As New OleDbCommand
        _ExecuteCMD(SqlStr, CMD)
        Dim DataRdr As OleDbDataReader = CMD.ExecuteReader
        If DataRdr.HasRows Then
            While DataRdr.Read
                CmboStr = DataRdr!CITY & "-" & DataRdr!STATE_CODE
            End While
            DataRdr.Close()
        End If
        Return CmboStr
    End Function
    Public Function CompRepair() As Boolean
        'This will Compact & Repair MSAccess2007 Database to the same location with the same name.
        Dim Result As Boolean = False
        If DBConnected() Then
            CN.Close()
            Result = True
        End If
        Cursor.Current = Cursors.WaitCursor
        'Compact & Repair needs the Database File (*.accdb) to be closed.
        Dim MyAccDB As New Microsoft.Office.Interop.Access.Dao.DBEngine()
        Dim Compactedfil As String = Application.StartupPath & "\mydbcompacted.accdb"
        MyAccDB.CompactDatabase(DBLocation, Compactedfil, , , ";pwd=" & DBPass)
        Try
            My.Computer.FileSystem.DeleteFile(DBLocation)
            Result = True
        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
            Return Result
            Exit Function
        End Try
        Try
            Rename(Compactedfil, DBLocation)
            Result = True
        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
            Return Result
            Exit Function
        End Try
        Application.DoEvents()
        Return Result
        Cursor.Current = Cursors.Default
    End Function
End Module
