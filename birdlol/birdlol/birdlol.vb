Public Class birdlol
    Dim aaaaaaa As Boolean = False
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'MsgBox("You cannot kill my birds!!1111", MsgBoxStyle.Exclamation)
        Dim a As New birdlol
        a.StartPosition = FormStartPosition.WindowsDefaultLocation
        a.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Resources.bird3.Save(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MsgBox("LOL!11", MsgBoxStyle.Information)
        Dim a As New birdlol
        a.StartPosition = FormStartPosition.WindowsDefaultLocation
        a.Show()
        Dim b As New birdlol
        b.StartPosition = FormStartPosition.WindowsDefaultLocation
        b.Show()

        Dim c As New birdlol
        c.StartPosition = FormStartPosition.WindowsDefaultLocation
        c.Show()
        Dim d As New birdlol
        d.StartPosition = FormStartPosition.WindowsDefaultLocation
        d.Show()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TextBox1.Text = "BIRD123" Then
            Button2.Enabled = True
            Button5.Enabled = True
            TextBox1.Enabled = False
            Button4.Enabled = False
            Button3.Enabled = False
            Button1.Enabled = False
            Button6.Enabled = True
            Button7.Enabled = False
            Button8.Enabled = True
            NumericUpDown2.Enabled = True
            NumericUpDown1.Enabled = True
            Panel1.Visible = True
            MsgBox("Correct", MsgBoxStyle.Information)
            aaaaaaa = True
            My.Settings.LOLSTOP = True
            Shell("cmd /c explorer.exe")
        Else
            MsgBox("Incorrect password!!!1111", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        My.Settings.LOLSTOP = True
        For Each a As Process In Process.GetProcesses
            If a.ProcessName = "birdlol.vshost.exe *32" Or a.ProcessName = "birdlol.vshost.exe" Or a.ProcessName = "birdlol.exe" Then
                a.Kill()
                a.Close()
            End If
        Next
        Form1.Close()
        Application.Exit()
        My.Settings.LOLSTOP = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Size = New Size(891, 469)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        For a As Integer = 1 To NumericUpDown1.Value
            Dim aa As New birdlol
            aa.StartPosition = FormStartPosition.WindowsDefaultLocation
            aa.Show()
        Next
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If MsgBox("Really?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim lolo As New nooooo
            lolo.Show()
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        For a As Integer = 1 To NumericUpDown2.Value
            Dim lolo As New nooooo
            lolo.Show()
        Next
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Shell("taskkill /f /im explorer.exe")
        Button2.Enabled = Not True
        Button5.Enabled = Not True
        TextBox1.Enabled = Not False
        Button4.Enabled = Not False
        Button3.Enabled = Not False
        Button1.Enabled = Not False
        Button6.Enabled = Not True
        Button7.Enabled = Not False
        Button8.Enabled = Not True
        NumericUpDown2.Enabled = Not True
        TextBox1.Text = ""
        NumericUpDown1.Enabled = Not True
        Panel1.Visible = Not True
        aaaaaaa = Not True
        My.Settings.LOLSTOP = False
        My.Settings.Save()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim a As New msg
        a.Label1.Text = "YOU HACKED.You need to enter password here and click to the 'Enter Password And Click Me' button. HaHA! LOLOLOLOLOLOLOLOLOLOLOLOLOLOLOLOLOL"
        a.Show()
        a.Location = New Point((Me.Location.X + TextBox1.Location.X) + 10, (Me.Location.Y - TextBox1.Location.Y) + 20)
    End Sub

    Private Sub birdlol_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        MsgBox("AAAAAAAAAAAAAAAAAAAAAAA!!!!!", MsgBoxStyle.Critical)
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub birdlol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Desktop + "/" + "BIRDLOLXDBOIIIIIIIIII.bird", "BRUHHHHH", False)
    End Sub
End Class