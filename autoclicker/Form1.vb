Public Class Form1
  Private Declare Sub mouse_event _
    Lib "user32" _
    Alias "mouse_event" _
    (ByVal dwFlags As Long,
     ByVal dx As Long,
     ByVal dy As Long,
     ByVal cButtons As Long,
     ByVal dwExtraInfo As Long)

  Private Declare Function GetAsyncKeyState _
    Lib "user32" _
    (ByVal vKey As Long) As Integer

  Private Sub Button1_Click(sender As Object, e As EventArgs) _
    Handles Button1.Click

    MsgBox("To use, check on Activate then:" & vbNewLine &
      "Hit F1 to click once every 0.75 seconds" & vbNewLine &
      "Hit F2 to click once every 0.001 seconds" & vbNewLine &
      "Hit F3 to stop clicking." & vbNewLine & vbNewLine &
      "Created by https://github.com/manhquynh-github")
  End Sub

  Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles CheckBox1.CheckedChanged

    If CheckBox1.Checked = True Then
      Hotkeys.Start()
      Me.TopMost = True
    Else
      Hotkeys.Stop()
      Timer1.Stop()
      Timer2.Stop()
      Me.TopMost = False
    End If
  End Sub

  Private Sub Hotkeys_Tick(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Hotkeys.Tick

    If GetAsyncKeyState(Keys.F1) Then
      Timer1.Start()
      Timer2.Stop()
    ElseIf GetAsyncKeyState(Keys.F2) Then
      Timer2.Start()
      Timer1.Stop()
    ElseIf GetAsyncKeyState(Keys.F3) Then
      Timer1.Stop()
      Timer2.Stop()
    End If
  End Sub

  Private Sub PerformClick()
    mouse_event(&H2, 0, 0, 0, 1) 'Perform mouse down
    mouse_event(&H4, 0, 0, 0, 1) 'Perform mouse up
  End Sub

  Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) _
    Handles Timer1.Tick

    PerformClick()
  End Sub

  Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles _
    Timer2.Tick

    PerformClick()
  End Sub
End Class