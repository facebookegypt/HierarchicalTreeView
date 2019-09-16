Imports System.ComponentModel
Public Class MainForm
    Dim UsrGndr As String = String.Empty
    Dim User_ID As Long = -1 'Not Selected
    Private Sub MainForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        'Closes the application on 'Escape' Button click from keyboard.
        If e.KeyChar = ChrW(Keys.Escape) Then Close()
    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DBConnected() Then
            'Database connected
            DBlblStatus.Text = ("Database connected.")
            DBlblStatus.ForeColor = Color.Green
        Else
            'Database not connected
            DBlblStatus.Text = ("Database Error.")
            DBlblStatus.ForeColor = Color.Red
            Enabled = False
            Exit Sub
        End If
        CountryComboBox.Text = ("Wait ... Loading Data.")
        UserTreeView.Nodes.Add("Wait.... Fetching Data.")
        UseWaitCursor = True
        ToolStripProgressBar1.Minimum = 0
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Close()
    End Sub
    Sub ClearCntrls()
        'Reset All TextBoxes
        For Each CtrlSet As Control In GroupBox2.Controls
            If TypeOf CtrlSet Is TextBox Then
                CtrlSet.Text = String.Empty
            End If
        Next
        'Reset ToolStripMenuItems
        SaveToolStripMenuItem.Enabled = True
        UpdateToolStripMenuItem.Enabled = False
        DeleteToolStripMenuItem.Enabled = False
        'Reset DateTimePicker
        BDDateTimePicker.Value = Now
        'Reset RadioButtons
        MaleRadioButton.Checked = False
        FemaleRadioButton.Checked = False
        'Reset PictureBox
        UserPictureBox.Image = My.Resources.no_photo
        'Reset ComboBox
        CountryComboBox.Text = String.Empty
        CountryComboBox.SelectedIndex = -1
        'Reset Progressbar
        With ToolStripProgressBar1
            .Step = 1
            .Minimum = 0
            .Value = 0
        End With
        'Reset UserAction Status Label
        If UserActionsLblStat.ForeColor = Color.Red Then UserActionsLblStat.Text = String.Empty
        'Clear TreeView search items
        For Each Node As TreeNode In UserTreeView.Nodes
            Node.BackColor = Nothing
            Node.ForeColor = Nothing
        Next
    End Sub
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        ClearCntrls()
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        System.Threading.Thread.Sleep(1000)
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'Populate ComboBox with Data From Tables [us_states],[us_cities]
        CountryComboBox.DataSource = Nothing
        CountryComboBox.Items.Clear()
        Dim ComboCMD As New OleDb.OleDbCommand
        'You can change this Sql Statement to be .. SELECT TOP 100 .. for easy testing.
        'Of find a way to populate ComboBox with 29.8k data without waiting.
        Dim SqlStr As String =
            ("SELECT us_states.STATE_CODE,us_cities.CITY, us_cities.ID " &
            "FROM us_states RIGHT JOIN us_cities ON us_states.ID = us_cities.ID_STATE;")
        _ExecuteCMD(SqlStr, ComboCMD)
        Dim ComboReader As OleDb.OleDbDataReader = ComboCMD.ExecuteReader
        Dim ComboItems As New Dictionary(Of String, String)()
        If ComboReader.HasRows Then
            CountryComboBox.BeginUpdate()
            While ComboReader.Read
                'Almost 29.8k records of string.
                ComboItems.Add(ComboReader!ID.ToString, ComboReader!CITY & "-" & ComboReader!STATE_CODE)
                ToolStripProgressBar1.PerformStep()
            End While
            ComboReader.Close()
        Else
            CountryComboBox.DataSource = Nothing
        End If
        ComboCMD.Dispose()
        With CountryComboBox
            .DataSource = New BindingSource(ComboItems, Nothing)
            .DisplayMember = "Value"
            .ValueMember = "key"
        End With
        CountryComboBox.Text = String.Empty
        CountryComboBox.EndUpdate()
        'Populate TreeView with Database from Access table
        PopulateTreeView(UserTreeView)
        '-------------------------------------------------
        If ToolStripProgressBar1.Value >= ToolStripProgressBar1.Maximum Then ToolStripProgressBar1.Value = 0
        UseWaitCursor = False
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If Not DBConnected() Then
            UserActionsLblStat.ForeColor = Color.Red
            UserActionsLblStat.Text = ("Database Error.")
            Exit Sub
        End If
        Dim Fname, Lname, Adrs As String
        Fname = FirstNameTextBox.Text
        Lname = LastNameTextBox.Text
        Adrs = AddressTextBox.Text
        If String.IsNullOrEmpty(Fname) Or
                String.IsNullOrEmpty(Lname) Or
                String.IsNullOrEmpty(Adrs) Or
                String.IsNullOrEmpty(UsrGndr) Then
            UserActionsLblStat.ForeColor = Color.Red
            UserActionsLblStat.Text = ("Don't leave blanks.")
            Exit Sub
        End If
        Dim UsrAge As Integer = DateDiff(DateInterval.Year, BDDateTimePicker.Value, DateCreatedModified)
        'Retrieve Keys from ComboBox ("Key","Value") structure
        Dim ID_City As Long = DirectCast(CountryComboBox.SelectedItem, KeyValuePair(Of String, String)).Key
        If ID_City = -1 Or
                UsrAge <= 16 Then
            UserActionsLblStat.ForeColor = Color.Red
            UserActionsLblStat.Text = ("User is a minor '<= 16 years old' or you did not specify a City/state.")
            Exit Sub
        End If
        'User Photo=========================================
        Dim IMG As Bitmap = Nothing
        IMG = New Bitmap(UserPictureBox.Image)
        Dim MyStream = New IO.MemoryStream
        IMG.Save(MyStream, Imaging.ImageFormat.Png)
        '===================================================
        Dim SqlStr As String =
            ("INSERT INTO BasicInfo (Usr_Fnm,Usr_Lnm,Usr_CityID,Usr_Adrs,Usr_Phon,Usr_Mob,Usr_Gndr,Usr_Bdate,Usr_IMG,DtCreated) " &
            "VALUES (@Fnm,@Lnm,@Cid,@Uad,@Ufon,@Umob,@Uge,@Ubd,@uimg,@dtC)")
        Dim InsertCMD As New OleDb.OleDbCommand
        _ExecuteCMD(SqlStr, InsertCMD)
        Try
            With InsertCMD.Parameters
                .AddWithValue("@Fnm", Fname)
                .AddWithValue("@Lnm", Lname)
                .AddWithValue("@Cid", ID_City)
                .AddWithValue("@Uad", Adrs)
                .AddWithValue("@Ufon", LandLineTextBox.Text)
                .AddWithValue("@Umob", MobileTextBox.Text)
                .AddWithValue("@Uge", UsrGndr)
                .AddWithValue("@Ubd", BDDateTimePicker.Value)
                .AddWithValue("@uimg", OleDb.OleDbType.VarBinary).Value = MyStream.GetBuffer()
                .AddWithValue("@dtC", DateCreatedModified)
            End With
            InsertCMD.ExecuteNonQuery()
            InsertCMD.Parameters.Clear()
        Catch ex As Exception
            UserActionsLblStat.ForeColor = Color.Red
            UserActionsLblStat.Text = ("Error in Sql Statement : " & ex.Message)
            Exit Sub
        End Try
        Try
            Trans.Commit()
        Catch ex As Exception
            Trans.Rollback()
            UserActionsLblStat.ForeColor = Color.Red
            UserActionsLblStat.Text = ("Transaction Error : " & ex.Message)
            Exit Sub
        End Try
        UserActionsLblStat.ForeColor = Color.Green
        UserActionsLblStat.Text = ("Saved successfully.")
        Trans.Dispose()
        InsertCMD.Dispose()
        MyStream.Flush()
        MyStream.Close()
        'Populate TreeView with Database from Access table
        PopulateTreeView(UserTreeView)
        'Clear Form
        ClearCntrls()
    End Sub
    Private Sub MaleRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles MaleRadioButton.CheckedChanged
        If MaleRadioButton.Checked Then
            UsrGndr = "Male"
        Else
            UsrGndr = String.Empty
        End If
    End Sub
    Private Sub FemaleRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles FemaleRadioButton.CheckedChanged
        If FemaleRadioButton.Checked Then
            UsrGndr = "Female"
        Else
            UsrGndr = String.Empty
        End If
    End Sub
    Private Sub UserPictureBox_MouseClick(sender As Object, e As MouseEventArgs) Handles UserPictureBox.MouseClick
        If e.Button = MouseButtons.Left Then
            Dim OFD As New OpenFileDialog
            With OFD
                .Filter = ("Image File (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png")
                If .ShowDialog = DialogResult.OK Then
                    Try
                        UserPictureBox.Image = Image.FromFile(.FileName)
                    Catch ex As Exception
                        UserPictureBox.Image = My.Resources.no_photo
                    End Try
                End If
            End With
        End If
    End Sub
    Private Sub SearchToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Dim SearchLbl1 As String = String.Empty  'Find TreeView Node [TreeNode]
        'Clear search result on form.
        ClearCntrls()
        'Begin search
        SearchLbl1 = _
            InputBox("Enter any search term", "Search All TreeView")
        If String.IsNullOrEmpty(SearchLbl1) Or _
            String.IsNullOrWhiteSpace(SearchLbl1) Then
            MsgBox("Don't leave blanks.")
            Exit Sub
        End If
        UserActionsLblStat.Text = FindNode(SearchLbl1, UserTreeView)
    End Sub
    Private Sub UserTreeView_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles UserTreeView.AfterSelect
        If String.IsNullOrEmpty(e.Node.Name) Then Exit Sub
        User_ID = CLng(e.Node.Name)
    End Sub
    Private Sub UserTreeView_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles UserTreeView.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            'Begin display TreeNode contents on Form Controls
            If User_ID = -1 Then Exit Sub
            'Clear the form from previous display----------
            ClearCntrls()
            '----------------------------------------------
            Dim Sqlstr As String = _
                ("SELECT * FROM BasicInfo WHERE BasicInfo.UsrID=" & User_ID)
            Dim SrchCMD As New OleDb.OleDbCommand
            _ExecuteCMD(Sqlstr, SrchCMD)
            Dim SrchReader As OleDb.OleDbDataReader = SrchCMD.ExecuteReader
            If SrchReader.HasRows Then
                While SrchReader.Read
                    FirstNameTextBox.Text = SrchReader!Usr_Fnm
                    LastNameTextBox.Text = SrchReader!Usr_Lnm
                    'User City-State------------------------------------------
                    CountryComboBox.Text = GetCityCountry(SrchReader!Usr_CityID)
                    'User Gender----------------------------------------------
                    Select Case SrchReader!Usr_Gndr
                        Case Is = ("Male")
                            MaleRadioButton.Checked = True
                        Case Is = ("Female")
                            FemaleRadioButton.Checked = True
                    End Select
                    '-------------------------------------------------------------
                    AddressTextBox.Text = SrchReader!Usr_Adrs
                    LandLineTextBox.Text = SrchReader!Usr_Phon
                    MobileTextBox.Text = SrchReader!Usr_Mob
                    BDDateTimePicker.Value = SrchReader!Usr_Bdate
                    'User Image-------------------------------------------------
                    Dim ImageBytes As Byte() = CType(SrchReader!Usr_IMG, Byte())
                    'Progressbar--------------------------------------
                    ToolStripProgressBar1.Maximum = ImageBytes.Count
                    '-------------------------------------------------
                    Dim MyStream As New IO.MemoryStream(ImageBytes)
                    Dim IMG As Image = Image.FromStream(MyStream)
                    For I As Integer = 0 To ImageBytes.Count - 1
                        ToolStripProgressBar1.Step = 5
                        ToolStripProgressBar1.PerformStep()
                        If ToolStripProgressBar1.Value >= ImageBytes.Count Then
                            ToolStripProgressBar1.Value = 0
                            Exit For
                        End If
                    Next
                    UserPictureBox.Image = IMG
                    '-----------------------------------------------------------
                End While
                SrchReader.Close()
                UpdateToolStripMenuItem.Enabled = True
                DeleteToolStripMenuItem.Enabled = True
                SaveToolStripMenuItem.Enabled = False
                UserTreeView.SelectedNode.Expand()
            Else
                UpdateToolStripMenuItem.Enabled = False
                DeleteToolStripMenuItem.Enabled = False
            End If
        End If
    End Sub
    Private Sub UpdateToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        If User_ID = -1 Then Exit Sub
        If Not DBConnected() Then
            UserActionsLblStat.ForeColor = Color.Red
            UserActionsLblStat.Text = ("Database Error.")
            Exit Sub
        End If
        Dim Fname, Lname, Adrs As String
        Fname = FirstNameTextBox.Text
        Lname = LastNameTextBox.Text
        Adrs = AddressTextBox.Text
        If String.IsNullOrEmpty(Fname) Or
                String.IsNullOrEmpty(Lname) Or
                String.IsNullOrEmpty(Adrs) Or
                String.IsNullOrEmpty(UsrGndr) Then
            UserActionsLblStat.ForeColor = Color.Red
            UserActionsLblStat.Text = ("Don't leave blanks.")
            Exit Sub
        End If
        'User Age-----------------------------------------------------------------------------------------
        Dim UsrAge As Integer = DateDiff(DateInterval.Year, BDDateTimePicker.Value, DateCreatedModified)
        '-------------------------------------------------------------------------------------------------
        Dim ID_City As Long = DirectCast(CountryComboBox.SelectedItem, KeyValuePair(Of String, String)).Key
        'User Photo=========================================
        Dim IMG As Bitmap = Nothing
        IMG = New Bitmap(UserPictureBox.Image)
        Dim MyStream = New IO.MemoryStream
        IMG.Save(MyStream, Imaging.ImageFormat.Png)
        '===================================================
        Dim SqlStr As String =
            ("UPDATE BasicInfo SET Usr_Fnm=@ufnm, Usr_Lnm=@ulnm, Usr_CityID=@ucid, Usr_Adrs=@uadrs, " &
             "Usr_Phon=@ufon, Usr_Mob=@umob, Usr_Gndr=@ugndr, Usr_Bdate=@ubd, Usr_IMG=@uimg, DtModfd=@udtm WHERE BasicInfo.UsrID=@uid;")
        Dim UpdateCMD As New OleDb.OleDbCommand
        _ExecuteCMD(SqlStr, UpdateCMD)
        Try
            With UpdateCMD.Parameters
                .AddWithValue("@ufnm", Fname)
                .AddWithValue("@ulnm", Lname)
                .AddWithValue("@ucid", ID_City)
                .AddWithValue("@uadrs", Adrs)
                .AddWithValue("@Ufon", LandLineTextBox.Text)
                .AddWithValue("@Umob", MobileTextBox.Text)
                .AddWithValue("@ugndr", UsrGndr)
                .AddWithValue("@ubd", BDDateTimePicker.Value)
                .AddWithValue("@uimg", OleDb.OleDbType.VarBinary).Value = MyStream.GetBuffer()
                .AddWithValue("@udtm", DateCreatedModified)
                .AddWithValue("@uid", User_ID)
            End With
            UpdateCMD.ExecuteNonQuery()
            UpdateCMD.Parameters.Clear()
        Catch ex As Exception
            UserActionsLblStat.ForeColor = Color.Red
            UserActionsLblStat.Text = ("Error in Sql Statement UPDATE : " & ex.Message)
            Exit Sub
        End Try
        Try
            Trans.Commit()
        Catch ex As Exception
            Trans.Rollback()
            UserActionsLblStat.ForeColor = Color.Red
            UserActionsLblStat.Text = ("Transaction Error : " & ex.Message)
            Exit Sub
        End Try
        UserActionsLblStat.ForeColor = Color.Green
        UserActionsLblStat.Text = ("Updated successfully.")
        Trans.Dispose()
        UpdateCMD.Dispose()
        MyStream.Flush()
        MyStream.Close()
        'Populate TreeView with Database from Access table
        PopulateTreeView(UserTreeView)
        'Activate Delete ToolStripMenuItem
        DeleteToolStripMenuItem.Enabled = True
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If User_ID = -1 Then Exit Sub
        Dim AreYouSure As String =
            MsgBox("Do you wish to delete this User " & UserTreeView.Nodes(User_ID.ToString).Text & "?",
                   MsgBoxStyle.Critical + MsgBoxStyle.YesNo,
                   "Delete user.")
        If AreYouSure = vbYes Then
            If Not DBConnected() Then
                UserActionsLblStat.ForeColor = Color.Red
                UserActionsLblStat.Text = ("Database Error.")
                Exit Sub
            End If
            Dim SqlStr As String =
            ("DELETE * FROM BasicInfo WHERE BasicInfo.UsrID=@uid;")
            Dim DeleteCmd As New OleDb.OleDbCommand
            _ExecuteCMD(SqlStr, DeleteCmd)
            Try
                With DeleteCmd.Parameters
                    .AddWithValue("@uid", User_ID)
                End With
                DeleteCmd.ExecuteNonQuery()
                DeleteCmd.Parameters.Clear()
            Catch ex As Exception
                UserActionsLblStat.ForeColor = Color.Red
                UserActionsLblStat.Text = ("Error in Sql Statement Delete : " & ex.Message)
                Exit Sub
            End Try
            Try
                Trans.Commit()
            Catch ex As Exception
                Trans.Rollback()
                UserActionsLblStat.ForeColor = Color.Red
                UserActionsLblStat.Text = ("Transaction Error : " & ex.Message)
                Exit Sub
            End Try
            UserActionsLblStat.ForeColor = Color.Green
            UserActionsLblStat.Text = ("Deleted successfully.")
            Trans.Dispose()
            DeleteCmd.Dispose()
            'Clear Form
            ClearCntrls()
            'Populate TreeView with Database from Access table
            PopulateTreeView(UserTreeView)
        Else
            Exit Sub
        End If
    End Sub
    Private Sub CompactRepairDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompactRepairDatabaseToolStripMenuItem.Click
        'compact and repair database
        If CompRepair() Then
            UserActionsLblStat.ForeColor = Color.Green
            UserActionsLblStat.Text = ("Database compacted and repaired successfully.")
        Else
            UserActionsLblStat.ForeColor = Color.Red
            UserActionsLblStat.Text = ("Error in Database.")
        End If
    End Sub
End Class
