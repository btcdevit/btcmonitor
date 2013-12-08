<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_alert_ok = New System.Windows.Forms.Button()
        Me.btn_alert_cancel = New System.Windows.Forms.Button()
        Me.nud_alert_lower = New System.Windows.Forms.NumericUpDown()
        Me.nud_alert_higher = New System.Windows.Forms.NumericUpDown()
        Me.btn_alert_clear = New System.Windows.Forms.Button()
        Me.cb_alert_or = New System.Windows.Forms.CheckBox()
        Me.alert_ar1 = New System.Windows.Forms.ComboBox()
        Me.alert_ar2 = New System.Windows.Forms.ComboBox()
        CType(Me.nud_alert_lower, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nud_alert_higher, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_alert_ok
        '
        Me.btn_alert_ok.Location = New System.Drawing.Point(211, 73)
        Me.btn_alert_ok.Name = "btn_alert_ok"
        Me.btn_alert_ok.Size = New System.Drawing.Size(75, 23)
        Me.btn_alert_ok.TabIndex = 0
        Me.btn_alert_ok.Text = "OK"
        Me.btn_alert_ok.UseVisualStyleBackColor = True
        '
        'btn_alert_cancel
        '
        Me.btn_alert_cancel.Location = New System.Drawing.Point(12, 73)
        Me.btn_alert_cancel.Name = "btn_alert_cancel"
        Me.btn_alert_cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_alert_cancel.TabIndex = 1
        Me.btn_alert_cancel.Text = "Cancel"
        Me.btn_alert_cancel.UseVisualStyleBackColor = True
        '
        'nud_alert_lower
        '
        Me.nud_alert_lower.DecimalPlaces = 8
        Me.nud_alert_lower.Location = New System.Drawing.Point(140, 3)
        Me.nud_alert_lower.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nud_alert_lower.Name = "nud_alert_lower"
        Me.nud_alert_lower.Size = New System.Drawing.Size(120, 20)
        Me.nud_alert_lower.TabIndex = 2
        Me.nud_alert_lower.ThousandsSeparator = True
        '
        'nud_alert_higher
        '
        Me.nud_alert_higher.DecimalPlaces = 8
        Me.nud_alert_higher.Location = New System.Drawing.Point(140, 47)
        Me.nud_alert_higher.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nud_alert_higher.Name = "nud_alert_higher"
        Me.nud_alert_higher.Size = New System.Drawing.Size(120, 20)
        Me.nud_alert_higher.TabIndex = 3
        Me.nud_alert_higher.ThousandsSeparator = True
        Me.nud_alert_higher.Visible = False
        '
        'btn_alert_clear
        '
        Me.btn_alert_clear.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_alert_clear.Location = New System.Drawing.Point(117, 74)
        Me.btn_alert_clear.Name = "btn_alert_clear"
        Me.btn_alert_clear.Size = New System.Drawing.Size(75, 23)
        Me.btn_alert_clear.TabIndex = 4
        Me.btn_alert_clear.Text = "Clear"
        Me.btn_alert_clear.UseVisualStyleBackColor = True
        '
        'cb_alert_or
        '
        Me.cb_alert_or.AutoSize = True
        Me.cb_alert_or.Location = New System.Drawing.Point(140, 29)
        Me.cb_alert_or.Name = "cb_alert_or"
        Me.cb_alert_or.Size = New System.Drawing.Size(42, 17)
        Me.cb_alert_or.TabIndex = 7
        Me.cb_alert_or.Text = "OR"
        Me.cb_alert_or.UseVisualStyleBackColor = True
        '
        'alert_ar1
        '
        Me.alert_ar1.FormattingEnabled = True
        Me.alert_ar1.Items.AddRange(New Object() {"Price >=", "Price <="})
        Me.alert_ar1.Location = New System.Drawing.Point(12, 3)
        Me.alert_ar1.Name = "alert_ar1"
        Me.alert_ar1.Size = New System.Drawing.Size(100, 21)
        Me.alert_ar1.TabIndex = 8
        '
        'alert_ar2
        '
        Me.alert_ar2.FormattingEnabled = True
        Me.alert_ar2.Items.AddRange(New Object() {"Price >=", "Price <="})
        Me.alert_ar2.Location = New System.Drawing.Point(12, 46)
        Me.alert_ar2.Name = "alert_ar2"
        Me.alert_ar2.Size = New System.Drawing.Size(100, 21)
        Me.alert_ar2.TabIndex = 9
        Me.alert_ar2.Visible = False
        '
        'Form2
        '
        Me.AcceptButton = Me.btn_alert_ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.btn_alert_clear
        Me.ClientSize = New System.Drawing.Size(298, 109)
        Me.Controls.Add(Me.alert_ar2)
        Me.Controls.Add(Me.alert_ar1)
        Me.Controls.Add(Me.cb_alert_or)
        Me.Controls.Add(Me.btn_alert_clear)
        Me.Controls.Add(Me.nud_alert_higher)
        Me.Controls.Add(Me.nud_alert_lower)
        Me.Controls.Add(Me.btn_alert_cancel)
        Me.Controls.Add(Me.btn_alert_ok)
        Me.Name = "Form2"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Set alert"
        CType(Me.nud_alert_lower, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nud_alert_higher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_alert_ok As System.Windows.Forms.Button
    Friend WithEvents btn_alert_cancel As System.Windows.Forms.Button
    Friend WithEvents nud_alert_lower As System.Windows.Forms.NumericUpDown
    Friend WithEvents nud_alert_higher As System.Windows.Forms.NumericUpDown
    Friend WithEvents btn_alert_clear As System.Windows.Forms.Button
    Friend WithEvents cb_alert_or As System.Windows.Forms.CheckBox
    Friend WithEvents alert_ar1 As System.Windows.Forms.ComboBox
    Friend WithEvents alert_ar2 As System.Windows.Forms.ComboBox
End Class
