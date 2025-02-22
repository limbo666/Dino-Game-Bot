<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.btnSetBackgroundPoint = New System.Windows.Forms.Button()
        Me.btnSetDetectionPoint = New System.Windows.Forms.Button()
        Me.btnStartStop = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.lblBackgroundPoint = New System.Windows.Forms.Label()
        Me.lblDetectionPoint = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.tmrDetection = New System.Windows.Forms.Timer(Me.components)
        Me.lblBackColor = New System.Windows.Forms.Label()
        Me.lblForeColor = New System.Windows.Forms.Label()
        Me.lblkick = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSetBackgroundPoint
        '
        Me.btnSetBackgroundPoint.Location = New System.Drawing.Point(9, 10)
        Me.btnSetBackgroundPoint.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSetBackgroundPoint.Name = "btnSetBackgroundPoint"
        Me.btnSetBackgroundPoint.Size = New System.Drawing.Size(86, 34)
        Me.btnSetBackgroundPoint.TabIndex = 0
        Me.btnSetBackgroundPoint.Text = "Background"
        Me.btnSetBackgroundPoint.UseVisualStyleBackColor = True
        '
        'btnSetDetectionPoint
        '
        Me.btnSetDetectionPoint.Location = New System.Drawing.Point(9, 51)
        Me.btnSetDetectionPoint.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSetDetectionPoint.Name = "btnSetDetectionPoint"
        Me.btnSetDetectionPoint.Size = New System.Drawing.Size(86, 34)
        Me.btnSetDetectionPoint.TabIndex = 1
        Me.btnSetDetectionPoint.Text = "Detection"
        Me.btnSetDetectionPoint.UseVisualStyleBackColor = True
        '
        'btnStartStop
        '
        Me.btnStartStop.Location = New System.Drawing.Point(9, 93)
        Me.btnStartStop.Margin = New System.Windows.Forms.Padding(2)
        Me.btnStartStop.Name = "btnStartStop"
        Me.btnStartStop.Size = New System.Drawing.Size(86, 34)
        Me.btnStartStop.TabIndex = 2
        Me.btnStartStop.Text = "Start"
        Me.btnStartStop.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(9, 140)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(86, 28)
        Me.btnReset.TabIndex = 3
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'lblBackgroundPoint
        '
        Me.lblBackgroundPoint.AutoSize = True
        Me.lblBackgroundPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBackgroundPoint.Location = New System.Drawing.Point(129, 24)
        Me.lblBackgroundPoint.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblBackgroundPoint.Name = "lblBackgroundPoint"
        Me.lblBackgroundPoint.Size = New System.Drawing.Size(18, 15)
        Me.lblBackgroundPoint.TabIndex = 4
        Me.lblBackgroundPoint.Text = "..."
        '
        'lblDetectionPoint
        '
        Me.lblDetectionPoint.AutoSize = True
        Me.lblDetectionPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDetectionPoint.Location = New System.Drawing.Point(129, 61)
        Me.lblDetectionPoint.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDetectionPoint.Name = "lblDetectionPoint"
        Me.lblDetectionPoint.Size = New System.Drawing.Size(18, 15)
        Me.lblDetectionPoint.TabIndex = 5
        Me.lblDetectionPoint.Text = "..."
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Location = New System.Drawing.Point(129, 103)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(18, 15)
        Me.lblStatus.TabIndex = 6
        Me.lblStatus.Text = "..."
        '
        'tmrDetection
        '
        Me.tmrDetection.Interval = 2
        '
        'lblBackColor
        '
        Me.lblBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBackColor.Location = New System.Drawing.Point(100, 18)
        Me.lblBackColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblBackColor.Name = "lblBackColor"
        Me.lblBackColor.Size = New System.Drawing.Size(18, 20)
        Me.lblBackColor.TabIndex = 7
        '
        'lblForeColor
        '
        Me.lblForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblForeColor.Location = New System.Drawing.Point(100, 61)
        Me.lblForeColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblForeColor.Name = "lblForeColor"
        Me.lblForeColor.Size = New System.Drawing.Size(18, 20)
        Me.lblForeColor.TabIndex = 8
        '
        'lblkick
        '
        Me.lblkick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblkick.Location = New System.Drawing.Point(98, 103)
        Me.lblkick.Name = "lblkick"
        Me.lblkick.Size = New System.Drawing.Size(20, 20)
        Me.lblkick.TabIndex = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(277, 176)
        Me.Controls.Add(Me.lblkick)
        Me.Controls.Add(Me.lblForeColor)
        Me.Controls.Add(Me.lblBackColor)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblDetectionPoint)
        Me.Controls.Add(Me.lblBackgroundPoint)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnStartStop)
        Me.Controls.Add(Me.btnSetDetectionPoint)
        Me.Controls.Add(Me.btnSetBackgroundPoint)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.Text = "Dino-Game-Bot"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSetBackgroundPoint As Button
    Friend WithEvents btnSetDetectionPoint As Button
    Friend WithEvents btnStartStop As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents lblBackgroundPoint As Label
    Friend WithEvents lblDetectionPoint As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents tmrDetection As Timer
    Friend WithEvents lblBackColor As Label
    Friend WithEvents lblForeColor As Label
    Friend WithEvents lblkick As Label
End Class
