Public Class Form1
    Dim randomer As New Random
    Dim fps As Integer = 0
    Dim cnt As Integer = 0
    Dim filecount As Integer = 0
    Dim ffoption As Boolean = True
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.Enabled = False
        CheckBox1.Enabled = False
        CheckBox2.Enabled = False
        CheckBox3.Enabled = False
        NumericUpDown1.Enabled = False
        Label1.Text = "Computing.."
        Label1.Update()
        filecount = IIf(ffoption = True, OpenFileDialog1.FileNames.Length, countFiles(FolderBrowserDialog1.SelectedPath).Count)
        BackgroundWorker1.RunWorkerAsync({CheckBox1.Checked, CheckBox2.Checked, IIf(ffoption = "true", OpenFileDialog1.FileNames, countFiles(FolderBrowserDialog1.SelectedPath)), CheckBox3.Checked, NumericUpDown1.Value})
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim i = 0
        Dim cnt As Integer
        If TypeOf e.Argument(2) Is Array Then
            cnt = e.Argument(2).length
        Else
            cnt = e.Argument(2).count
        End If
        For Each a As String In e.Argument(2)
            Try
                Dim bytz As Array = My.Computer.FileSystem.ReadAllBytes(a)
                randomer.NextBytes(bytz)
                If e.Argument(0) = True Then
                    My.Computer.FileSystem.WriteAllBytes(a + ".corrupt", bytz, False)
                Else
                    My.Computer.FileSystem.WriteAllBytes(a, bytz, False)
                End If

            Catch ex As Exception
                If e.Argument(1) = True Then
                    Try
                        My.Computer.FileSystem.WriteAllText(a, "", False)
                    Catch exa As Exception
                        If e.Argument(3) = False Then
                            MsgBox(exa.Message)
                        End If
                    End Try
                Else
                    If e.Argument(3) = False Then
                        MsgBox(ex.Message)
                    End If
                End If
            End Try
            i += 1
            Dim crr As String = ""
            Try
                crr = e.Argument(2)(i)
            Catch ex As Exception

            End Try
            BackgroundWorker1.ReportProgress((i / (cnt)) * 100, {i, crr})
            System.Threading.Thread.Sleep(e.Argument(4))
        Next
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        cnt += 1
        Label1.Text = e.ProgressPercentage.ToString + "% " + e.UserState(0).ToString + " of " + filecount.ToString + " files (" + fps.ToString + " Fips)"
        Label3.Text = e.UserState(1)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Button2.Enabled = True
        CheckBox1.Enabled = True
        CheckBox2.Enabled = True
        CheckBox3.Enabled = True
        NumericUpDown1.Enabled = True
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Label1.Text = OpenFileDialog1.FileNames.Length.ToString + " files"
        ffoption = True
        Button1.BackColor = Color.Orange
        Button3.BackColor = SystemColors.Control
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            CheckBox2.Enabled = False
            CheckBox2.Checked = False
        Else
            CheckBox2.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        fps = cnt
        cnt = 0
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            ffoption = False
            Button3.BackColor = Color.Orange
            Button1.BackColor = SystemColors.Control
        End If
    End Sub
    Private Function countFiles(ByVal driveRootPath As String) As ArrayList
        Dim queue As New List(Of IO.DirectoryInfo)
        Dim di As New IO.DirectoryInfo(driveRootPath)
        queue.Add(di)
        Dim fs As New ArrayList
        Do
            di = queue(0)
            Try
                queue.AddRange(di.GetDirectories)
            Catch ex As Exception
            End Try
            Try
                For Each aa As IO.FileInfo In di.GetFiles
                    Try
                        fs.Add(aa.FullName)
                    Catch
                    End Try
                Next
            Catch ex As Exception
            End Try
            queue.Remove(di)
        Loop Until queue.Count = 0
        Return fs
    End Function
End Class
