Public Class nooooo

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Timer1.Enabled = True
        'Shell("msg * NOOOOERGOEROGOOOREOGOERGOoefoerogooooooOOOOO")
        Dim a As New nooooo
        a.Show()
    End Sub


    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        RichTextBox1.BackColor = Color.Yellow
        Me.Refresh()
        Console.Beep(300, 100)
        RichTextBox1.BackColor = SystemColors.Window
        RichTextBox1.BackColor = Color.Orange
        Me.Refresh()
        Console.Beep(200, 100)
        RichTextBox1.BackColor = SystemColors.Window
        RichTextBox1.BackColor = Color.Yellow
        Me.Refresh()
        Console.Beep(300, 100)
        RichTextBox1.BackColor = SystemColors.Window
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.TopMost = True
    End Sub
End Class