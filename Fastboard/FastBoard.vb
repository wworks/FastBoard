Public Class FastBoard
    Dim CurrentMode As Integer = 0
    Private CurrentSelectedControl As TaskControl
    Private SelectedBackColor As Color = Color.LightGray
    Private UnselectedBackColor As Color = Color.Gainsboro


#Region "Form Events"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TaskPanel.Region = GetRegion(TaskPanel.Width, TaskPanel.Height, 10)


        'TaskPanel.Cursor = Cursors.Cross
        Dim TaskTypesArray = [Enum].GetValues(GetType(TaskTypes))
        For i = 0 To TaskTypesArray.Length - 1
            TaskTypeTextBox.Items.Add(TaskTypesArray(i))
        Next
        LoadTasks()

    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveTasks()

    End Sub
#End Region
#Region "Region Function"
    Private Function GetRegion(WIdth As Integer, Height As Integer, Round As Integer) As Region
        Dim p As New Drawing2D.GraphicsPath()
        p.StartFigure()
        p.AddArc(New Rectangle(0, 0, Round, Round), 180, 90)
        p.AddLine(40, 0, WIdth - 40, 0)
        p.AddArc(New Rectangle(WIdth - Round, 0, Round, Round), -90, 90)
        p.AddLine(WIdth, 40, WIdth, Height - 40)
        p.AddArc(New Rectangle(WIdth - Round, Height - Round, Round, Round), 0, 90)
        p.AddLine(WIdth - 40, Height, 40, Height)
        p.AddArc(New Rectangle(0, Height - Round, Round, Round), 90, 90)
        p.CloseFigure()
        Return New Region(p)
    End Function

#End Region

#Region "TaskPanel Events"
    Dim x As Integer = 0
    Dim y As Integer = 0

    Private MovingTask As Boolean = False

    Private Sub TaskPanel_MouseDown(sender As Object, e As MouseEventArgs) Handles TaskPanel.MouseDown
        x = e.X
        y = e.Y



    End Sub

    Private Sub TaskPanel_MouseMove(sender As Object, e As MouseEventArgs) Handles TaskPanel.MouseMove
        If CurrentMode <> Mode.Edit Then
            Exit Sub
        End If

        If MovingTask = True Then
            ' CurrentSelectedControl.Location = Point.Subtract(e.Location, New Point(CurrentSelectedControl.Height / 2, CurrentSelectedControl.Width / 2))
            'Me.Refresh()
        End If
    End Sub

    Private Sub TaskPanel_MouseUp(sender As Object, e As MouseEventArgs) Handles TaskPanel.MouseUp
        If CurrentMode <> Mode.Edit Then
            Exit Sub
        End If

        Dim Controlx = 0
        Dim Controly = 0


        Dim NewWidth As Integer = e.X - x
        Dim NewHeigth As Integer = e.Y - y

        If NewHeigth < 0 Then
            Controly = y + NewHeigth
            NewHeigth = Math.Abs(NewHeigth)
        ElseIf NewHeigth > 0 Then
            Controly = y
        End If

        If NewWidth < 0 Then
            Controlx = x + NewWidth
            NewWidth = Math.Abs(NewWidth)
        Else
            Controlx = x
        End If


        Dim Task As New TaskControl
        Task.TextAlign = ContentAlignment.MiddleCenter

        Dim TaskText = InputBox("Enter the taskname:")
        If TaskText <> "" Then
            Task.Text = TaskText
            Task.TaskName = TaskText
        Else
            Exit Sub
        End If

        Task.BackColor = UnselectedBackColor
        Task.ForeColor = Color.Black
        Task.Location = New Point(Controlx, Controly)
        Task.Height = NewHeigth
        Task.Width = NewWidth


        AddHandler Task.GotFocus, AddressOf TaskControl_GotFocus
        AddHandler Task.LostFocus, AddressOf TaskControl_LostFocus

        AddHandler Task.MouseEnter, AddressOf TaskControl_MouseEnter
        AddHandler Task.MouseClick, AddressOf TaskControl_MouseClick
        AddHandler Task.MouseDown, AddressOf TaskControl_MouseDown
        AddHandler Task.MouseUp, AddressOf TaskControl_MouseUp
        AddHandler Task.MouseMove, AddressOf TaskControl_MouseMove
        AddHandler Task.DoubleClick, AddressOf TaskControl_MouseDoubleClick

        TaskPanel.Controls.Add(Task)
        CurrentSelectedControl = Task
        Task.Focus()

        MovingTask = False


    End Sub
#End Region

#Region "TaskControl Events"
    Private Sub TaskControl_MouseEnter(sender As Label, e As EventArgs)
        If CurrentMode <> Mode.Edit Then
            sender.Cursor = Cursors.Hand
            Exit Sub
        End If

        sender.Cursor = Cursors.SizeAll

    End Sub
    Private Sub TaskControl_GotFocus(sender As TaskControl, e As EventArgs)
        sender.BackColor = SelectedBackColor

        FillTaskInfo(sender)
    End Sub
    Private Sub TaskControl_LostFocus(TaskControl As TaskControl, e As EventArgs)
        TaskControl.BackColor = UnselectedBackColor
    End Sub
    Private Sub TaskControl_MouseDown(sender As TaskControl, e As EventArgs)
        If CurrentMode <> Mode.Edit Then
            Exit Sub

        End If
        sender.Focus()
        MovingTask = True
        CurrentSelectedControl = sender
        'SelectTaskControl(sender)
        FillTaskInfo(sender)

    End Sub
    Private Sub TaskControl_MouseMove(sender As TaskControl, e As MouseEventArgs)
        If CurrentMode <> Mode.Edit Then
            Exit Sub

        End If


        If MovingTask = True Then
            Dim x = CurrentSelectedControl.Location.X + e.X
            Dim y = CurrentSelectedControl.Location.Y + e.Y

            If (x >= 0 And x < TaskPanel.Width - CurrentSelectedControl.Width) And (y >= 0 And y < TaskPanel.Height - CurrentSelectedControl.Height) Then
                CurrentSelectedControl.Location = Point.Add(e.Location, CurrentSelectedControl.Location) 'Point.Subtract(,  New Point(CurrentSelectedControl.Height / 2, CurrentSelectedControl.Width / 2))
            End If

            FillTaskInfo(sender)
        End If

    End Sub
    Private Sub TaskControl_MouseDoubleClick(sender As TaskControl, e As MouseEventArgs)
        ExecuteTask(sender)

    End Sub
    Private Sub TaskControl_MouseUp(sender As TaskControl, e As EventArgs)
        If CurrentMode <> Mode.Edit Then
            Exit Sub

        End If
        MovingTask = False
        CurrentSelectedControl = sender
    End Sub
    Private Sub TaskControl_MouseClick(sender As TaskControl, e As EventArgs)
        If IsNothing(CurrentSelectedControl) = False Then
            CurrentSelectedControl.BackColor = UnselectedBackColor
        End If

        CurrentSelectedControl = sender
        sender.Selected = True
        FillTaskInfo(sender)
        sender.BackColor = SelectedBackColor

        'SelectTaskControl(sender)

        If CurrentMode <> Mode.Edit Then
            Exit Sub
        End If



    End Sub
#End Region

#Region "Task Info Panel"
    Private Sub FillTaskInfo(Task As TaskControl)



        TaskTextTxtbox.Text = Task.Text
        TaskNameTextBox.Text = Task.TaskName
        TaskDataTextBox.Text = Task.TaskData
        TaskTypeTextBox.Text = Task.TaskType.ToString
        TaskXTextBox.Text = Task.Location.X
        TaskYTextBox.Text = Task.Location.Y
        TaskWidthTextBox.Text = Task.Width
        TaskHeigthtextBox.Text = Task.Height


    End Sub

    Private Sub TaskTextBox_KeyUp(sender As Object, e As KeyEventArgs) Handles TaskDataTextBox.KeyUp, TaskTextTxtbox.KeyUp, TaskNameTextBox.KeyUp, TaskTypeTextBox.KeyUp, TaskDataTextBox.KeyUp, TaskXTextBox.KeyUp, TaskYTextBox.KeyUp, TaskWidthTextBox.KeyUp, TaskHeigthtextBox.KeyUp
        If CurrentMode <> Mode.Edit Then
            Exit Sub

        End If

        If e.KeyData = Keys.Enter Then
            CurrentSelectedControl.Text = TaskTextTxtbox.Text
            CurrentSelectedControl.TaskName = TaskNameTextBox.Text
            CurrentSelectedControl.TaskType = CInt(TaskTypeTextBox.SelectedItem)
            CurrentSelectedControl.TaskData = TaskDataTextBox.Text
            CurrentSelectedControl.Location = New Point(TaskXTextBox.Text, TaskYTextBox.Text)
            CurrentSelectedControl.Size = New Point(TaskWidthTextBox.Text, TaskHeigthtextBox.Text)
        End If
    End Sub
    Private Sub TaskTxtbox_LostFocus(sender As Object, e As EventArgs) Handles TaskTextTxtbox.LostFocus, TaskNameTextBox.LostFocus, TaskTypeTextBox.LostFocus, TaskDataTextBox.LostFocus, TaskXTextBox.LostFocus, TaskYTextBox.LostFocus, TaskWidthTextBox.LostFocus, TaskHeigthtextBox.LostFocus, TaskTextTxtbox.Leave, TaskNameTextBox.Leave, TaskTypeTextBox.Leave, TaskDataTextBox.Leave, TaskXTextBox.Leave, TaskYTextBox.Leave, TaskWidthTextBox.Leave, TaskHeigthtextBox.Leave
        If CurrentMode <> Mode.Edit Then
            Exit Sub

        End If

        CurrentSelectedControl.Text = TaskTextTxtbox.Text
        CurrentSelectedControl.TaskName = TaskNameTextBox.Text
        CurrentSelectedControl.TaskType = CInt(TaskTypeTextBox.Text)
        CurrentSelectedControl.TaskData = TaskDataTextBox.Text
        CurrentSelectedControl.Location = New Point(TaskXTextBox.Text, TaskYTextBox.Text)
        CurrentSelectedControl.Size = New Point(TaskWidthTextBox.Text, TaskHeigthtextBox.Text)




    End Sub
    Private Sub TaskTypeTextBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TaskTypeTextBox.SelectedIndexChanged
        If CurrentMode <> Mode.Edit Then
            Exit Sub

        End If

        If IsNothing(CurrentSelectedControl) = False Then
            Select Case TaskTypeTextBox.SelectedItem
                Case TaskTypes.OpenFile
                    CurrentSelectedControl.TaskType = TaskTypes.OpenFile
                    TaskDataTextBox.Text = "Filepath"
                Case TaskTypes.DeleteFile
                    CurrentSelectedControl.TaskType = TaskTypes.DeleteFile
                    TaskDataTextBox.Text = "Filepath"
                Case TaskTypes.CopyFile
                    CurrentSelectedControl.TaskType = TaskTypes.CopyFile
                    TaskDataTextBox.Text = "Sourcepath, DestinationPath"
                Case TaskTypes.CreateFile
                    CurrentSelectedControl.TaskType = TaskTypes.CreateFile
                    TaskDataTextBox.Text = "Filepath"
                Case TaskTypes.SendEmail

                    CurrentSelectedControl.TaskType = TaskTypes.SendEmail
                    TaskDataTextBox.Text = "Port,Host,Password,Username, From,To,Subject,Body"
                Case TaskTypes.OpenHyperLink
                    TaskDataTextBox.Text = "Hyperlink"
                    CurrentSelectedControl.TaskType = TaskTypes.OpenHyperLink
                Case TaskTypes.RunCommand
                    TaskDataTextBox.Text = "Command Parameters"
                    CurrentSelectedControl.TaskType = TaskTypes.RunCommand
            End Select


        End If
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        If CurrentMode <> Mode.Edit Then
            Exit Sub

        End If

        CurrentSelectedControl.Text = TaskTextTxtbox.Text
        CurrentSelectedControl.TaskName = TaskNameTextBox.Text
        CurrentSelectedControl.TaskType = TaskTypeTextBox.SelectedItem
        CurrentSelectedControl.TaskData = TaskDataTextBox.Text
        CurrentSelectedControl.Location = New Point(TaskXTextBox.Text, TaskYTextBox.Text)
        CurrentSelectedControl.Size = New Point(TaskWidthTextBox.Text, TaskHeigthtextBox.Text)

    End Sub
    Private Sub DeleteTaskButton_Click(sender As Object, e As EventArgs) Handles DeleteTaskButton.Click
        If IsNothing(CurrentSelectedControl) = False Then
            TaskPanel.Controls.Remove(CurrentSelectedControl)
        End If
    End Sub
#End Region

#Region "TaskLoading_Saving"

    Const TasksFileLocation = "\Tasks\Tasks.txt"


    Private Sub SaveTasks()
        Dim FilePath = Application.StartupPath & TasksFileLocation
        'If IO.File.Exists(FilePath) = False Then
        '   IO.File.Create(FilePath)
        ' End If

        Dim TasksData As String = ""
        For Each Task As TaskControl In TaskPanel.Controls
            Dim TaskData As String = ""
            TaskData &= Task.Text & ","
            TaskData &= Task.TaskName & ","
            TaskData &= Task.TaskType & ","
            TaskData &= Task.TaskData & ","
            TaskData &= Task.Location.X & ","
            TaskData &= Task.Location.Y & ","
            TaskData &= Task.Width & ","
            TaskData &= Task.Height & ","

            TasksData &= TaskData & "{"

        Next

        'Dim objWriter As New System.IO.StreamWriter(FilePath)

        'objWriter.Write(TasksData)
        'objWriter.Close()

        IO.File.WriteAllText(FilePath, TasksData)



    End Sub

    Private Sub LoadTasks()
        Dim FilePath = Application.StartupPath & TasksFileLocation

        Dim TasksData = IO.File.ReadAllText(FilePath)
        For Each Task As String In TasksData.Split("{")
            Dim TaskData = Task.Split(",")

            Dim NewTask As New TaskControl
            NewTask.Text = TaskData(0)
            NewTask.TaskName = TaskData(1)
            NewTask.TaskType = TaskData(2)
            NewTask.TaskData = TaskData(3)
            NewTask.Location = New Point(TaskData(4), TaskData(5))
            NewTask.Size = New Point(TaskData(6), TaskData(7).TrimEnd)
            NewTask.BackColor = UnselectedBackColor
            NewTask.TextAlign = ContentAlignment.MiddleCenter

            AddHandler NewTask.GotFocus, AddressOf TaskControl_GotFocus
            AddHandler NewTask.LostFocus, AddressOf TaskControl_LostFocus

            AddHandler NewTask.MouseEnter, AddressOf TaskControl_MouseEnter
            AddHandler NewTask.MouseClick, AddressOf TaskControl_MouseClick
            AddHandler NewTask.MouseDown, AddressOf TaskControl_MouseDown
            AddHandler NewTask.MouseUp, AddressOf TaskControl_MouseUp
            AddHandler NewTask.MouseMove, AddressOf TaskControl_MouseMove
            AddHandler NewTask.DoubleClick, AddressOf TaskControl_MouseDoubleClick


            TaskPanel.Controls.Add(NewTask)

        Next
    End Sub
#End Region



    Private Sub ExecuteTask(TaskControl As TaskControl)
        Select Case TaskControl.TaskType
            Case TaskTypes.OpenFile
                Dim FilePath As String = TaskControl.TaskData
                'If System.IO.File.Exists(FilePath) Then
                Diagnostics.Process.Start(FilePath)
                'End If
            Case TaskTypes.CopyFile
                Dim FilePaths = TaskControl.TaskData.Split(",")
                If IO.File.Exists(FilePaths(1)) = False Then
                    My.Computer.FileSystem.CopyFile(FilePaths(0), FilePaths(1))
                End If
            Case TaskTypes.CreateFile
                Dim filePath = TaskControl.TaskData
                If IO.File.Exists(filePath) = False Then
                    IO.File.Create(filePath)
                Else
                    MsgBox("File Already Exists")
                End If
            Case TaskTypes.DeleteFile
                Dim filepath = TaskControl.TaskData
                If System.IO.File.Exists(filepath) = True Then
                    My.Computer.FileSystem.DeleteFile(filepath)
                End If
            Case TaskTypes.OpenHyperLink
                Dim Hyperlink = TaskControl.TaskData
                Diagnostics.Process.Start(Hyperlink)
            Case TaskTypes.RunCommand
                Dim Command = TaskControl.TaskData
                System.Diagnostics.Process.Start("cmd.exe", "/k" + " " & Command)
            Case TaskTypes.SendEmail
                Dim Data = TaskControl.TaskData.Split(",")
                Dim port = Data(0)
                Dim host = Data(1)
                Dim Password = Data(2)
                Dim Username = Data(3)
                Dim Sender = Data(4)
                Dim Recipient = Data(5)
                Dim Subject = Data(6)
                Dim Body = Data(7)

                Dim Message As New System.Net.Mail.MailMessage
                Dim Client As New System.Net.Mail.SmtpClient
                'port,host,password,username, From,to,subject,body

                Client.EnableSsl = True
                Client.Host = host
                Client.UseDefaultCredentials = False
                Client.Credentials = New System.Net.NetworkCredential(Username, Password)

                Message.From = New System.Net.Mail.MailAddress(Sender)
                Message.To.Add(New System.Net.Mail.MailAddress(Recipient))
                Message.Subject = Subject
                Message.Body = Body
                Client.Send(Message)


        End Select

    End Sub

    Private Sub EditButton_Click(sender As Object, e As EventArgs) Handles EditButton.Click
        If CurrentMode <> Mode.Edit Then
            CurrentMode = Mode.Edit
            TaskPanel.Cursor = Cursors.Cross

            SaveButton.Enabled = True

            DeleteTaskButton.Enabled = True


        Else
            CurrentMode = Mode.View
            TaskPanel.Cursor = Cursors.Arrow
            SaveButton.Enabled = False
            DeleteTaskButton.Enabled = False

        End If
    End Sub


End Class

Public Enum Mode
    View = 0
    Edit = 1

End Enum
Public Class TaskControl : Inherits Label
    Public TaskName As String = ""
    Public TaskType As Integer
    Public TaskData As String
    Public Selected As Boolean = False

End Class
Public Enum TaskTypes
    OpenFile = 0
    DeleteFile = 1
    CopyFile = 2
    CreateFile = 3

    SendEmail = 4

    OpenHyperLink = 5

    RunCommand = 6






End Enum