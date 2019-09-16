<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.UserTreeView = New System.Windows.Forms.TreeView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CompactRepairDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FirstNameTextBox = New System.Windows.Forms.TextBox()
        Me.LblFname = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BDDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Lblbirthdate = New System.Windows.Forms.Label()
        Me.LandLineTextBox = New System.Windows.Forms.TextBox()
        Me.LblLandline = New System.Windows.Forms.Label()
        Me.MobileTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AddressTextBox = New System.Windows.Forms.TextBox()
        Me.LblAddress = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblCountry = New System.Windows.Forms.Label()
        Me.CountryComboBox = New System.Windows.Forms.ComboBox()
        Me.UserPictureBox = New System.Windows.Forms.PictureBox()
        Me.LastNameTextBox = New System.Windows.Forms.TextBox()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.MaleRadioButton = New System.Windows.Forms.RadioButton()
        Me.FemaleRadioButton = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.DBlblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.UserActionsLblStat = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.UserPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UserTreeView
        '
        Me.UserTreeView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UserTreeView.Location = New System.Drawing.Point(516, 27)
        Me.UserTreeView.Name = "UserTreeView"
        Me.UserTreeView.ShowNodeToolTips = True
        Me.UserTreeView.Size = New System.Drawing.Size(374, 380)
        Me.UserTreeView.TabIndex = 10
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(902, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SearchToolStripMenuItem, Me.UpdateToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem2, Me.CompactRepairDatabaseToolStripMenuItem, Me.ToolStripMenuItem1, Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F"
        Me.SearchToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.SearchToolStripMenuItem.Text = "&Find"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Enabled = False
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.ShortcutKeyDisplayString = "F10"
        Me.UpdateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.UpdateToolStripMenuItem.Text = "Up&date"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Enabled = False
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeyDisplayString = "Del"
        Me.DeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.DeleteToolStripMenuItem.Text = "D&elete"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(169, 6)
        '
        'CompactRepairDatabaseToolStripMenuItem
        '
        Me.CompactRepairDatabaseToolStripMenuItem.Name = "CompactRepairDatabaseToolStripMenuItem"
        Me.CompactRepairDatabaseToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CompactRepairDatabaseToolStripMenuItem.Text = "Compact && Repair"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(169, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeyDisplayString = "Esc"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CloseToolStripMenuItem.Text = "C&lose"
        '
        'FirstNameTextBox
        '
        Me.FirstNameTextBox.Location = New System.Drawing.Point(143, 35)
        Me.FirstNameTextBox.Name = "FirstNameTextBox"
        Me.FirstNameTextBox.Size = New System.Drawing.Size(194, 20)
        Me.FirstNameTextBox.TabIndex = 1
        '
        'LblFname
        '
        Me.LblFname.AutoSize = True
        Me.LblFname.Location = New System.Drawing.Point(140, 19)
        Me.LblFname.Name = "LblFname"
        Me.LblFname.Size = New System.Drawing.Size(57, 13)
        Me.LblFname.TabIndex = 3
        Me.LblFname.Text = "First Name"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.BDDateTimePicker)
        Me.GroupBox2.Controls.Add(Me.Lblbirthdate)
        Me.GroupBox2.Controls.Add(Me.LandLineTextBox)
        Me.GroupBox2.Controls.Add(Me.LblLandline)
        Me.GroupBox2.Controls.Add(Me.MobileTextBox)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.AddressTextBox)
        Me.GroupBox2.Controls.Add(Me.LblAddress)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.LblCountry)
        Me.GroupBox2.Controls.Add(Me.CountryComboBox)
        Me.GroupBox2.Controls.Add(Me.UserPictureBox)
        Me.GroupBox2.Controls.Add(Me.LastNameTextBox)
        Me.GroupBox2.Controls.Add(Me.lblLastName)
        Me.GroupBox2.Controls.Add(Me.FirstNameTextBox)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.LblFname)
        Me.GroupBox2.Location = New System.Drawing.Point(165, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(345, 381)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Info"
        '
        'BDDateTimePicker
        '
        Me.BDDateTimePicker.CustomFormat = "d-MMMM-yyyy"
        Me.BDDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.BDDateTimePicker.Location = New System.Drawing.Point(9, 351)
        Me.BDDateTimePicker.Name = "BDDateTimePicker"
        Me.BDDateTimePicker.Size = New System.Drawing.Size(194, 20)
        Me.BDDateTimePicker.TabIndex = 9
        '
        'Lblbirthdate
        '
        Me.Lblbirthdate.AutoSize = True
        Me.Lblbirthdate.Location = New System.Drawing.Point(6, 335)
        Me.Lblbirthdate.Name = "Lblbirthdate"
        Me.Lblbirthdate.Size = New System.Drawing.Size(54, 13)
        Me.Lblbirthdate.TabIndex = 17
        Me.Lblbirthdate.Text = "Birth Date"
        Me.Lblbirthdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LandLineTextBox
        '
        Me.LandLineTextBox.Location = New System.Drawing.Point(9, 302)
        Me.LandLineTextBox.Name = "LandLineTextBox"
        Me.LandLineTextBox.Size = New System.Drawing.Size(194, 20)
        Me.LandLineTextBox.TabIndex = 8
        '
        'LblLandline
        '
        Me.LblLandline.AutoSize = True
        Me.LblLandline.Location = New System.Drawing.Point(6, 286)
        Me.LblLandline.Name = "LblLandline"
        Me.LblLandline.Size = New System.Drawing.Size(47, 13)
        Me.LblLandline.TabIndex = 16
        Me.LblLandline.Text = "Landline"
        Me.LblLandline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MobileTextBox
        '
        Me.MobileTextBox.Location = New System.Drawing.Point(9, 256)
        Me.MobileTextBox.MaxLength = 20
        Me.MobileTextBox.Name = "MobileTextBox"
        Me.MobileTextBox.Size = New System.Drawing.Size(194, 20)
        Me.MobileTextBox.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 240)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Mobile"
        '
        'AddressTextBox
        '
        Me.AddressTextBox.Location = New System.Drawing.Point(9, 200)
        Me.AddressTextBox.Multiline = True
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.AddressTextBox.Size = New System.Drawing.Size(328, 37)
        Me.AddressTextBox.TabIndex = 4
        '
        'LblAddress
        '
        Me.LblAddress.AutoSize = True
        Me.LblAddress.Location = New System.Drawing.Point(6, 184)
        Me.LblAddress.Name = "LblAddress"
        Me.LblAddress.Size = New System.Drawing.Size(45, 13)
        Me.LblAddress.TabIndex = 12
        Me.LblAddress.Text = "Address"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(14, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Click to change Photo"
        '
        'LblCountry
        '
        Me.LblCountry.AutoSize = True
        Me.LblCountry.Location = New System.Drawing.Point(140, 110)
        Me.LblCountry.Name = "LblCountry"
        Me.LblCountry.Size = New System.Drawing.Size(60, 13)
        Me.LblCountry.TabIndex = 9
        Me.LblCountry.Text = "State / City"
        '
        'CountryComboBox
        '
        Me.CountryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.CountryComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CountryComboBox.FormattingEnabled = True
        Me.CountryComboBox.Location = New System.Drawing.Point(143, 126)
        Me.CountryComboBox.Name = "CountryComboBox"
        Me.CountryComboBox.Size = New System.Drawing.Size(194, 72)
        Me.CountryComboBox.Sorted = True
        Me.CountryComboBox.TabIndex = 3
        '
        'UserPictureBox
        '
        Me.UserPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UserPictureBox.ErrorImage = Global.HierarchicalTreeView.My.Resources.Resources.no_photo
        Me.UserPictureBox.Image = Global.HierarchicalTreeView.My.Resources.Resources.no_photo
        Me.UserPictureBox.InitialImage = Global.HierarchicalTreeView.My.Resources.Resources.no_photo
        Me.UserPictureBox.Location = New System.Drawing.Point(6, 19)
        Me.UserPictureBox.Name = "UserPictureBox"
        Me.UserPictureBox.Size = New System.Drawing.Size(128, 128)
        Me.UserPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.UserPictureBox.TabIndex = 7
        Me.UserPictureBox.TabStop = False
        '
        'LastNameTextBox
        '
        Me.LastNameTextBox.Location = New System.Drawing.Point(143, 81)
        Me.LastNameTextBox.Name = "LastNameTextBox"
        Me.LastNameTextBox.Size = New System.Drawing.Size(194, 20)
        Me.LastNameTextBox.TabIndex = 2
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(140, 65)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(58, 13)
        Me.lblLastName.TabIndex = 5
        Me.lblLastName.Text = "Last Name"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.MaleRadioButton)
        Me.GroupBox1.Controls.Add(Me.FemaleRadioButton)
        Me.GroupBox1.Location = New System.Drawing.Point(250, 243)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(87, 66)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User Gender"
        '
        'MaleRadioButton
        '
        Me.MaleRadioButton.AutoSize = True
        Me.MaleRadioButton.Location = New System.Drawing.Point(6, 19)
        Me.MaleRadioButton.Name = "MaleRadioButton"
        Me.MaleRadioButton.Size = New System.Drawing.Size(48, 17)
        Me.MaleRadioButton.TabIndex = 6
        Me.MaleRadioButton.TabStop = True
        Me.MaleRadioButton.Text = "Male"
        Me.MaleRadioButton.UseVisualStyleBackColor = True
        '
        'FemaleRadioButton
        '
        Me.FemaleRadioButton.AutoSize = True
        Me.FemaleRadioButton.Location = New System.Drawing.Point(6, 42)
        Me.FemaleRadioButton.Name = "FemaleRadioButton"
        Me.FemaleRadioButton.Size = New System.Drawing.Size(59, 17)
        Me.FemaleRadioButton.TabIndex = 7
        Me.FemaleRadioButton.TabStop = True
        Me.FemaleRadioButton.Text = "Female"
        Me.FemaleRadioButton.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DBlblStatus, Me.ToolStripSeparator1, Me.UserActionsLblStat, Me.ToolStripProgressBar1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 407)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(902, 25)
        Me.ToolStrip1.TabIndex = 20
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'DBlblStatus
        '
        Me.DBlblStatus.Name = "DBlblStatus"
        Me.DBlblStatus.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'UserActionsLblStat
        '
        Me.UserActionsLblStat.Name = "UserActionsLblStat"
        Me.UserActionsLblStat.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 22)
        '
        'BackgroundWorker1
        '
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 432)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.UserTreeView)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User ID Card © projectzone.co®"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.UserPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UserTreeView As TreeView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FirstNameTextBox As TextBox
    Friend WithEvents LblFname As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LastNameTextBox As TextBox
    Friend WithEvents lblLastName As Label
    Friend WithEvents UserPictureBox As PictureBox
    Friend WithEvents LblCountry As Label
    Friend WithEvents CountryComboBox As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BDDateTimePicker As DateTimePicker
    Friend WithEvents Lblbirthdate As Label
    Friend WithEvents LandLineTextBox As TextBox
    Friend WithEvents LblLandline As Label
    Friend WithEvents MobileTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents AddressTextBox As TextBox
    Friend WithEvents LblAddress As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents DBlblStatus As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents UserActionsLblStat As ToolStripLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents MaleRadioButton As RadioButton
    Friend WithEvents FemaleRadioButton As RadioButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents CompactRepairDatabaseToolStripMenuItem As ToolStripMenuItem
End Class
