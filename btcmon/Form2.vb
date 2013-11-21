Public Class Form2

  

    Private Sub btn_alert_ok_Click(sender As System.Object, e As System.EventArgs) Handles btn_alert_ok.Click
        Dim k As Integer
        k = alert_ar1.SelectedIndex


        If ALERT_PANEL = 1 Then
            Form1.p1_alert_onoff.BackColor = Color.Red
            p1.alert_2_val = nud_alert_higher.Value
            p1.alert_1_val = nud_alert_lower.Value
            p1.alert_1_ar = alert_ar1.SelectedIndex
            p1.alert_2_ar = alert_ar2.SelectedIndex
            p1.alert_or = cb_alert_or.Checked
            p1.alert_set = True
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_alert_val1", p1.alert_1_val)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_alert_val2", p1.alert_2_val)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_alert_ar1", p1.alert_1_ar)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_alert_ar2", p1.alert_2_ar)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_alert_or", p1.alert_or)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_alert_set", p1.alert_set)
            Me.Close()
            p1.alert = 1
        End If
        If ALERT_PANEL = 2 Then
            Form1.rb_p2_alertonoff.BackColor = Color.Red
            p2.alert_2_val = nud_alert_higher.Value
            p2.alert_1_val = nud_alert_lower.Value
            p2.alert_1_ar = alert_ar1.SelectedIndex
            p2.alert_2_ar = alert_ar2.SelectedIndex
            p2.alert_or = cb_alert_or.Checked
            p2.alert_set = True
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_alert_val1", p2.alert_1_val)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_alert_val2", p2.alert_2_val)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_alert_ar1", p2.alert_1_ar)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_alert_ar2", p2.alert_2_ar)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_alert_or", p2.alert_or)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_alert_set", p2.alert_set)
            Me.Close()
        End If
        If ALERT_PANEL = 3 Then
            Form1.rb_p3_alertonoff.BackColor = Color.Red
            p3.alert_2_val = nud_alert_higher.Value
            p3.alert_1_val = nud_alert_lower.Value
            p3.alert_or = cb_alert_or.Checked
            p3.alert_1_ar = alert_ar1.SelectedIndex
            p3.alert_2_ar = alert_ar2.SelectedIndex
            p3.alert_set = True
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_alert_val1", p3.alert_1_val)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_alert_val2", p3.alert_2_val)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_alert_ar1", p3.alert_1_ar)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_alert_ar2", p3.alert_2_ar)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_alert_or", p3.alert_or)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_alert_set", p3.alert_set)
            Me.Close()
        End If
        If ALERT_PANEL = 4 Then
            Form1.rb_p4_alertonoff.BackColor = Color.Red
            p4.alert_2_val = nud_alert_higher.Value
            p4.alert_1_val = nud_alert_lower.Value
            p4.alert_or = cb_alert_or.Checked
            p4.alert_1_ar = alert_ar1.SelectedIndex
            p4.alert_2_ar = alert_ar2.SelectedIndex
            p4.alert_set = True
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_alert_val1", p4.alert_1_val)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_alert_val2", p4.alert_2_val)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_alert_ar1", p4.alert_1_ar)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_alert_ar2", p4.alert_2_ar)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_alert_or", p4.alert_or)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_alert_set", p4.alert_set)
            Me.Close()
        End If
    End Sub

    Private Sub Form2_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.TopMost = True
        alert_ar1.SelectedIndex = 0
        alert_ar2.SelectedIndex = 0
        If ALERT_PANEL = 1 Then
            If p1.alert_set Then
                nud_alert_higher.Value = p1.alert_2_val
                nud_alert_lower.Value = p1.alert_1_val
                alert_ar1.SelectedIndex = p1.alert_1_ar
                alert_ar2.SelectedIndex = p1.alert_2_ar
                cb_alert_or.Checked = p1.alert_or
                If p1.alert_or Then
                    cb_alert_or.Visible = True
                    nud_alert_higher.Visible = True
                End If
            End If
        End If

        If ALERT_PANEL = 2 Then
            If p2.alert_set Then
                nud_alert_higher.Value = p2.alert_2_val
                nud_alert_lower.Value = p2.alert_1_val
                alert_ar1.SelectedIndex = p2.alert_1_ar
                alert_ar2.SelectedIndex = p2.alert_2_ar
                cb_alert_or.Checked = p2.alert_or
                If p2.alert_or Then
                    cb_alert_or.Visible = True
                    nud_alert_higher.Visible = True
                End If
            End If
        End If
        If ALERT_PANEL = 3 Then
            If p3.alert_set Then
                nud_alert_higher.Value = p3.alert_2_val
                nud_alert_lower.Value = p3.alert_1_val
                alert_ar1.SelectedIndex = p3.alert_1_ar
                alert_ar2.SelectedIndex = p3.alert_2_ar
                cb_alert_or.Checked = p3.alert_or
                If p3.alert_or Then
                    cb_alert_or.Visible = True
                    nud_alert_higher.Visible = True
                End If
            End If
        End If
        If ALERT_PANEL = 4 Then
            If p4.alert_set Then
                nud_alert_higher.Value = p4.alert_2_val
                nud_alert_lower.Value = p4.alert_1_val
                alert_ar1.SelectedIndex = p4.alert_1_ar
                alert_ar2.SelectedIndex = p4.alert_2_ar
                cb_alert_or.Checked = p4.alert_or
                If p4.alert_or Then
                    cb_alert_or.Visible = True
                    nud_alert_higher.Visible = True
                End If
            End If
        End If
    End Sub

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_alert_cancel_Click(sender As System.Object, e As System.EventArgs) Handles btn_alert_cancel.Click
        Me.Close()

    End Sub

    Private Sub btn_alert_clear_Click(sender As System.Object, e As System.EventArgs) Handles btn_alert_clear.Click
        If ALERT_PANEL = 1 Then
            p1.alert_set = False
            Form1.p1_alert_onoff.BackColor = Color.Black
            p1.alert = 0
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_alert_set", p1.alert_set)
        End If
        If ALERT_PANEL = 2 Then
            p2.alert_set = False
            Form1.rb_p2_alertonoff.BackColor = Color.Black
            p2.alert = 0
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_alert_set", p2.alert_set)
        End If
        If ALERT_PANEL = 3 Then
            p3.alert_set = False
            Form1.rb_p3_alertonoff.BackColor = Color.Black
            p3.alert = 0
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_alert_set", p3.alert_set)
        End If
        If ALERT_PANEL = 4 Then
            p4.alert_set = False
            Form1.rb_p4_alertonoff.BackColor = Color.Black
            p4.alert = 0
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_alert_set", p4.alert_set)
        End If

    End Sub

    Private Sub alert_ar1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles alert_ar1.SelectedIndexChanged

    End Sub

    Private Sub cb_alert_or_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_alert_or.CheckedChanged
        If cb_alert_or.Checked Then
            alert_ar2.Visible = True
            nud_alert_higher.Visible = True
        Else
            alert_ar2.Visible = False
            nud_alert_higher.Visible = False
        End If
    End Sub
End Class