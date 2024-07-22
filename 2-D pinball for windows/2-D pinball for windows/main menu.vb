Public Class main_menu

    Private Sub main_menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.AssemblyName
        '1020; 590
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        mode(orginal)
    End Sub
    Sub mode(ByVal mode As Form)
        mode.Show()
    End Sub
End Class