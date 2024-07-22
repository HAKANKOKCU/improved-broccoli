Public Class orginal
    Dim rightv As Boolean = False
    Dim leftv As Boolean = False
    Dim score As Integer = 0
    Dim speed As Integer = 0
    Dim mov As Integer = -20
    Dim sp As Point
    Private Sub move_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles move.Tick
        ball.Top += speed
        ball.Left += mov
    End Sub

    Private Sub RectangleShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.AssemblyName
        '1020; 590
        sp = ball.Location
        If My.Settings.fullscreen = True Then
            WindowState = FormWindowState.Normal
            FormBorderStyle = FormBorderStyle.None
            WindowState = FormWindowState.Maximized
            My.Settings.fullscreen = True
        Else
            WindowState = FormWindowState.Normal
            FormBorderStyle = FormBorderStyle.FixedDialog
            My.Settings.fullscreen = False
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ball.Left += 10
        ball.Top -= 5
        For Each a As Control In Me.Controls
            If a.Tag = "bound" Or a.Tag = "r1" Or a.Tag = "r2" Then
                If ball.Bounds.IntersectsWith(a.Bounds) Then
                    mov = -mov
                End If
            End If
        Next
        ball.Left -= 20
        For Each a As Control In Me.Controls
            If a.Tag = "bound" Or a.Tag = "r1" Or a.Tag = "r2" Then
                If ball.Bounds.IntersectsWith(a.Bounds) Then
                    mov = -mov
                End If
            End If
        Next
        ball.Top += 5
        For Each a As Control In Me.Controls
            If a.Tag = "arena" Then
                If Not ball.Bounds.IntersectsWith(a.Bounds) Then
                    mov = -mov
                End If
            End If
        Next
        ball.Left += 10
        speed += 2
        For Each b As Control In Me.Controls
            If b.Tag = "bound" Then
                If ball.Bounds.IntersectsWith(b.Bounds) Then
                    speed = -2
                    If b.Text = "bounce" Then
                        speed -= 40
                        My.Computer.Audio.Play(My.Resources.Finger_Snap, AudioPlayMode.Background)
                    End If

                End If

            End If
            If b.Tag = "r1" Then
                If ball.Bounds.IntersectsWith(b.Bounds) Then
                    speed = -8
                    If leftv Then
                        speed = -40
                        My.Computer.Audio.Play(My.Resources.Finger_Snap, AudioPlayMode.Background)
                    End If
                End If
            End If
            If b.Tag = "r2" Then
                If ball.Bounds.IntersectsWith(b.Bounds) Then
                    speed -= 20
                    If rightv Then
                        speed = -40
                        My.Computer.Audio.Play(My.Resources.Finger_Snap, AudioPlayMode.Background)
                    End If
                End If
            End If
        Next
        For Each i As Control In Me.Controls
            If i.Tag = "wall" Then
                If ball.Bounds.IntersectsWith(i.Bounds) Then
                    mov = -mov
                    speed = -8
                    My.Computer.Audio.Play(My.Resources.Finger_Snap, AudioPlayMode.Background)
                End If
            End If
            If i.Tag = "score" Then
                If ball.Bounds.IntersectsWith(i.Bounds) Then
                    mov = -mov
                    speed = -10
                    score += 100
                    My.Computer.Audio.Play(My.Resources.Coin, AudioPlayMode.Background)
                End If
            End If
        Next
        For Each a As Control In Me.Controls
            If a.Tag = "no." Then
                If ball.Bounds.IntersectsWith(a.Bounds) Then
                    gameover()
                End If
            End If
        Next
    End Sub

    Private Sub LineShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click

    End Sub

    Private Sub PictureBox3_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles PictureBox3.PreviewKeyDown

    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Right Then
            rightv = True
            PictureBox3.BackColor = Color.Gold
        ElseIf e.KeyCode = Keys.Left Then
            leftv = True
            PictureBox2.BackColor = Color.Gold
        ElseIf e.KeyCode = Keys.E Then
            score = 0
            '708; 494
            ball.Location = sp
            speed = 0
            mov = -20
            Timer2.Start()
            Timer1.Start()
        End If
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Right Then
            rightv = False
            PictureBox3.BackColor = Color.Orange
        ElseIf e.KeyCode = Keys.Left Then
            leftv = False
            PictureBox2.BackColor = Color.Orange
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Label1.Text = "SCORE: " & vbNewLine & score.ToString

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Sub gameover()
        Timer1.Stop()
        Timer2.Stop()
        Dim br = vbNewLine
        My.Computer.Audio.Play(My.Resources.Lose, AudioPlayMode.Background)
        MsgBox("game over" & br & br & "Your score : " & score, MsgBoxStyle.Information)
        Label1.Text = "SCORE: " & vbNewLine & score.ToString & vbNewLine & "GAME OVER. PRESS E TO RESTART."
    End Sub

    Private Sub Timer3_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Settings.Save()
        Application.Exit()
    End Sub

    Private Sub FullscreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '
        '
        '
        'If FullscreenToolStripMenuItem.Checked = True Then
        'WindowState = FormWindowState.Normal
        'FormBorderStyle = FormBorderStyle.None
        ' WindowState = FormWindowState.Maximized
        'My.Settings.fullscreen = True
        ' Else
        'WindowState = FormWindowState.Normal
        '   FormBorderStyle = FormBorderStyle.FixedDialog
        '   My.Settings.fullscreen = False
        'End If
        '
        '
        '
    End Sub
End Class
