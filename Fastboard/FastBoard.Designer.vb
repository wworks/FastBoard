<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FastBoard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.EditButton = New System.Windows.Forms.Button()
        Me.TaskPanel = New System.Windows.Forms.Panel()
        Me.TaskTextTxtbox = New System.Windows.Forms.TextBox()
        Me.TaskNameTextBox = New System.Windows.Forms.TextBox()
        Me.TaskDataTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TaskHeigthtextBox = New System.Windows.Forms.TextBox()
        Me.TaskWidthTextBox = New System.Windows.Forms.TextBox()
        Me.TaskYTextBox = New System.Windows.Forms.TextBox()
        Me.TaskXTextBox = New System.Windows.Forms.TextBox()
        Me.TaskTypeTextBox = New System.Windows.Forms.ComboBox()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DeleteTaskButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'EditButton
        '
        Me.EditButton.Location = New System.Drawing.Point(978, 649)
        Me.EditButton.Name = "EditButton"
        Me.EditButton.Size = New System.Drawing.Size(226, 58)
        Me.EditButton.TabIndex = 1
        Me.EditButton.Text = "Edit Tasks"
        Me.EditButton.UseVisualStyleBackColor = True
        '
        'TaskPanel
        '
        Me.TaskPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TaskPanel.BackColor = System.Drawing.Color.White
        Me.TaskPanel.Location = New System.Drawing.Point(12, 12)
        Me.TaskPanel.Name = "TaskPanel"
        Me.TaskPanel.Size = New System.Drawing.Size(850, 695)
        Me.TaskPanel.TabIndex = 3
        '
        'TaskTextTxtbox
        '
        Me.TaskTextTxtbox.Location = New System.Drawing.Point(975, 38)
        Me.TaskTextTxtbox.Name = "TaskTextTxtbox"
        Me.TaskTextTxtbox.Size = New System.Drawing.Size(227, 20)
        Me.TaskTextTxtbox.TabIndex = 5
        '
        'TaskNameTextBox
        '
        Me.TaskNameTextBox.Location = New System.Drawing.Point(975, 64)
        Me.TaskNameTextBox.Name = "TaskNameTextBox"
        Me.TaskNameTextBox.Size = New System.Drawing.Size(227, 20)
        Me.TaskNameTextBox.TabIndex = 6
        '
        'TaskDataTextBox
        '
        Me.TaskDataTextBox.Location = New System.Drawing.Point(975, 116)
        Me.TaskDataTextBox.MaxLength = 327670000
        Me.TaskDataTextBox.Multiline = True
        Me.TaskDataTextBox.Name = "TaskDataTextBox"
        Me.TaskDataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TaskDataTextBox.Size = New System.Drawing.Size(227, 103)
        Me.TaskDataTextBox.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(878, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 25)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Text:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(878, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 25)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Name"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(878, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 25)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Type"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(878, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 25)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Data"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(878, 301)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 25)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Height:"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(878, 275)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 25)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Width:"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(878, 249)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 25)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Y:"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(878, 223)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 25)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "X:"
        '
        'TaskHeigthtextBox
        '
        Me.TaskHeigthtextBox.Location = New System.Drawing.Point(975, 301)
        Me.TaskHeigthtextBox.Name = "TaskHeigthtextBox"
        Me.TaskHeigthtextBox.Size = New System.Drawing.Size(227, 20)
        Me.TaskHeigthtextBox.TabIndex = 17
        '
        'TaskWidthTextBox
        '
        Me.TaskWidthTextBox.Location = New System.Drawing.Point(975, 275)
        Me.TaskWidthTextBox.Name = "TaskWidthTextBox"
        Me.TaskWidthTextBox.Size = New System.Drawing.Size(227, 20)
        Me.TaskWidthTextBox.TabIndex = 16
        '
        'TaskYTextBox
        '
        Me.TaskYTextBox.Location = New System.Drawing.Point(975, 249)
        Me.TaskYTextBox.Name = "TaskYTextBox"
        Me.TaskYTextBox.Size = New System.Drawing.Size(227, 20)
        Me.TaskYTextBox.TabIndex = 15
        '
        'TaskXTextBox
        '
        Me.TaskXTextBox.Location = New System.Drawing.Point(975, 223)
        Me.TaskXTextBox.Name = "TaskXTextBox"
        Me.TaskXTextBox.Size = New System.Drawing.Size(227, 20)
        Me.TaskXTextBox.TabIndex = 14
        '
        'TaskTypeTextBox
        '
        Me.TaskTypeTextBox.FormattingEnabled = True
        Me.TaskTypeTextBox.Location = New System.Drawing.Point(975, 89)
        Me.TaskTypeTextBox.Name = "TaskTypeTextBox"
        Me.TaskTypeTextBox.Size = New System.Drawing.Size(226, 21)
        Me.TaskTypeTextBox.TabIndex = 22
        '
        'SaveButton
        '
        Me.SaveButton.Enabled = False
        Me.SaveButton.Location = New System.Drawing.Point(974, 327)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(227, 41)
        Me.SaveButton.TabIndex = 23
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(881, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(323, 25)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Task Options:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DeleteTaskButton
        '
        Me.DeleteTaskButton.Enabled = False
        Me.DeleteTaskButton.Location = New System.Drawing.Point(974, 374)
        Me.DeleteTaskButton.Name = "DeleteTaskButton"
        Me.DeleteTaskButton.Size = New System.Drawing.Size(227, 41)
        Me.DeleteTaskButton.TabIndex = 25
        Me.DeleteTaskButton.Text = "Delete Task"
        Me.DeleteTaskButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1214, 719)
        Me.Controls.Add(Me.DeleteTaskButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.TaskTypeTextBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TaskHeigthtextBox)
        Me.Controls.Add(Me.TaskWidthTextBox)
        Me.Controls.Add(Me.TaskYTextBox)
        Me.Controls.Add(Me.TaskXTextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TaskDataTextBox)
        Me.Controls.Add(Me.TaskNameTextBox)
        Me.Controls.Add(Me.TaskTextTxtbox)
        Me.Controls.Add(Me.TaskPanel)
        Me.Controls.Add(Me.EditButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.Text = "FastBoard"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EditButton As System.Windows.Forms.Button
    Friend WithEvents TaskPanel As System.Windows.Forms.Panel
    Friend WithEvents TaskTextTxtbox As System.Windows.Forms.TextBox
    Friend WithEvents TaskNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TaskDataTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TaskHeigthtextBox As System.Windows.Forms.TextBox
    Friend WithEvents TaskWidthTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TaskYTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TaskXTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TaskTypeTextBox As System.Windows.Forms.ComboBox
    Friend WithEvents SaveButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DeleteTaskButton As System.Windows.Forms.Button

End Class
