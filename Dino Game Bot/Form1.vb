Imports System.Runtime.InteropServices

Public Class Form1
    ' API Declarations for screen color detection
    <DllImport("user32.dll")>
    Public Shared Function GetDC(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Public Shared Function ReleaseDC(ByVal hWnd As IntPtr, ByVal hDC As IntPtr) As Integer
    End Function

    <DllImport("gdi32.dll")>
    Public Shared Function GetPixel(ByVal hDC As IntPtr, ByVal x As Integer, ByVal y As Integer) As Integer
    End Function

    ' API for simulating key press (UP arrow)
    <DllImport("user32.dll")>
    Public Shared Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As UInteger, ByVal dwExtraInfo As UInteger)
    End Sub

    ' API for global mouse click detection (to select points)
    Private Delegate Function HookProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SetWindowsHookEx(ByVal idHook As Integer, ByVal lpfn As HookProc, ByVal hMod As IntPtr, ByVal dwThreadId As UInteger) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Private Shared Function UnhookWindowsHookEx(ByVal hhk As IntPtr) As Boolean
    End Function
    <DllImport("user32.dll")>
    Private Shared Function CallNextHookEx(ByVal hhk As IntPtr, ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Private Shared Function GetCursorPos(ByRef lpPoint As Point) As Boolean
    End Function

    Private Const WH_MOUSE_LL As Integer = 14
    Private Const WM_LBUTTONDOWN As Integer = &H201
    Private mouseHookHandle As IntPtr = IntPtr.Zero
    Private hookProcDelegate As HookProc = Nothing

    ' Variables to store selected points
    Private backgroundPoint As Point = Point.Empty
    Private detectionPoint As Point = Point.Empty
    Private isSelectingBackground As Boolean = False
    Private isSelectingDetection As Boolean = False

    ' Handle mouse clicks globally
    Private Function MouseHookCallback(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        If nCode >= 0 AndAlso wParam = WM_LBUTTONDOWN Then
            Dim mousePos As Point
            GetCursorPos(mousePos)

            ' Capture the clicked point based on which button was pressed
            If isSelectingBackground Then
                backgroundPoint = mousePos
                lblBackgroundPoint.Text = $"Background: {mousePos.X}, {mousePos.Y}"
                isSelectingBackground = False
                UnhookWindowsHookEx(mouseHookHandle)
            ElseIf isSelectingDetection Then
                detectionPoint = mousePos
                lblDetectionPoint.Text = $"Detection: {mousePos.X}, {mousePos.Y}"
                isSelectingDetection = False
                UnhookWindowsHookEx(mouseHookHandle)
            End If
        End If
        Return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam)
    End Function


    Private Function GetScreenColor(x As Integer, y As Integer) As Color
        ' Capture a 1x1 pixel region of the screen
        Using bmp As New Bitmap(1, 1)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.CopyFromScreen(New Point(x, y), Point.Empty, New Size(1, 1))
            End Using
            Return bmp.GetPixel(0, 0)
        End Using
    End Function

    ' Calculate brightness (0-255)
    Private Function GetBrightness(ByVal color As Color) As Integer
        Return CInt((0.299 * color.R) + (0.587 * color.G) + (0.114 * color.B))
    End Function


    'Private Sub tmrDetection_Tick(sender As Object, e As EventArgs) Handles tmrDetection.Tick
    '    If backgroundPoint.IsEmpty OrElse detectionPoint.IsEmpty Then Exit Sub

    '    ' Get colors of both points
    '    Dim bgColor = GetScreenColor(backgroundPoint.X, backgroundPoint.Y)
    '    Dim detectColor = GetScreenColor(detectionPoint.X, detectionPoint.Y)
    '    lblBackColor.BackColor = bgColor
    '    lblForeColor.BackColor = detectColor
    '    ' Calculate brightness
    '    Dim bgBrightness = GetBrightness(bgColor)
    '    Dim detectBrightness = GetBrightness(detectColor)

    '    ' Determine if a jump is needed
    '    If (bgBrightness > 200 AndAlso detectBrightness < 50) OrElse
    '   (bgBrightness < 50 AndAlso detectBrightness > 200) Then
    '        keybd_event(&H26, 0, 0, 0) ' Send UP arrow key press
    '        keybd_event(&H26, 0, &H2, 0) ' Release the key
    '    End If
    'End Sub

    'Private Sub tmrDetection_Tick(sender As Object, e As EventArgs) Handles tmrDetection.Tick
    '    If backgroundPoint.IsEmpty OrElse detectionPoint.IsEmpty Then Exit Sub

    '    ' Capture a small region around the points (adjust size if needed)
    '    Using screenCap As New Bitmap(10, 10)
    '        Using g As Graphics = Graphics.FromImage(screenCap)
    '            ' Capture area around background point
    '            g.CopyFromScreen(backgroundPoint.X - 5, backgroundPoint.Y - 5, 0, 0, New Size(10, 10))
    '        End Using
    '        Dim bgColor = screenCap.GetPixel(5, 5) ' Center pixel

    '        ' Capture area around detection point
    '        Using g As Graphics = Graphics.FromImage(screenCap)
    '            g.CopyFromScreen(detectionPoint.X - 5, detectionPoint.Y - 5, 0, 0, New Size(10, 10))
    '        End Using
    '        Dim detectColor = screenCap.GetPixel(5, 5) ' Center pixel

    '        ' Update UI labels
    '        lblBackColor.BackColor = bgColor
    '        lblForeColor.BackColor = detectColor
    '        lblBackColor.BackColor = bgColor
    '        lblForeColor.BackColor = detectColor
    '        ' Your existing brightness/jump logic here
    '        Dim bgBrightness = GetBrightness(bgColor)
    '        Dim detectBrightness = GetBrightness(detectColor)

    '        If (bgBrightness > 200 AndAlso detectBrightness < 50) OrElse
    '       (bgBrightness < 50 AndAlso detectBrightness > 200) Then
    '            keybd_event(&H26, 0, 0, 0)
    '            keybd_event(&H26, 0, &H2, 0)
    '            Beep()
    '        End If
    '    End Using
    'End Sub
    Private Sub tmrDetection_Tick(sender As Object, e As EventArgs) Handles tmrDetection.Tick
        If backgroundPoint.IsEmpty OrElse detectionPoint.IsEmpty Then Exit Sub

        ' Capture regions
        Using screenCap As New Bitmap(20, 20) ' Larger area for detection
            ' Background point (single pixel)
            Using g As Graphics = Graphics.FromImage(screenCap)
                g.CopyFromScreen(backgroundPoint.X, backgroundPoint.Y, 0, 0, New Size(1, 1))
            End Using
            Dim bgColor = screenCap.GetPixel(0, 0)
            Dim bgBrightness = GetBrightness(bgColor)
            lblBackColor.BackColor = bgColor

            ' Detection point (20x20 region)
            Using g As Graphics = Graphics.FromImage(screenCap)
                g.CopyFromScreen(detectionPoint.X - 10, detectionPoint.Y - 10, 0, 0, New Size(20, 20))
            End Using

            ' Calculate average brightness over a 10x10 central area
            Dim detectBrightnessAvg As Integer = 0
            Dim pixelCount As Integer = 0
            For x = 5 To 14 ' Central 10x10 pixels
                For y = 5 To 14
                    detectBrightnessAvg += GetBrightness(screenCap.GetPixel(x, y))
                    pixelCount += 1
                Next
            Next
            detectBrightnessAvg /= pixelCount ' Average brightness


            ' Update UI
            Dim detectColor = screenCap.GetPixel(10, 10) ' Center pixel for display
            lblForeColor.BackColor = detectColor
            lblStatus.Text = $"BG: {bgBrightness}, DetectAvg: {detectBrightnessAvg}"

            If detectBrightnessAvg < 200 Then
                keybd_event(&H26, 0, 0, 0)
                keybd_event(&H26, 0, &H2, 0)
                System.Media.SystemSounds.Beep.Play()
                lblkick.BackColor = Color.Red
            Else
                lblkick.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If

            '' Detection logic
            'If bgBrightness > 150 AndAlso detectBrightnessAvg < 100 Then
            '    keybd_event(&H26, 0, 0, 0) ' Press UP arrow
            '    keybd_event(&H26, 0, &H2, 0) ' Release UP arrow
            '    System.Media.SystemSounds.Beep.Play() ' Audible feedback
            '    lblkick.BackColor = Color.Red
            'Else
            '    lblkick.BackColor = Color.FromKnownColor(KnownColor.Control)
            'End If
        End Using
    End Sub

    ' Start listening for mouse clicks when "Set Background Point" is clicked
    Private Sub btnSetBackgroundPoint_Click(sender As Object, e As EventArgs) Handles btnSetBackgroundPoint.Click
        isSelectingBackground = True
        hookProcDelegate = New HookProc(AddressOf MouseHookCallback)
        mouseHookHandle = SetWindowsHookEx(WH_MOUSE_LL, hookProcDelegate, IntPtr.Zero, 0)
        ' Removed: Call tmrDetection_Tick(Nothing, Nothing)
    End Sub

    ' Start listening for mouse clicks when "Set Detection Point" is clicked
    Private Sub btnSetDetectionPoint_Click(sender As Object, e As EventArgs) Handles btnSetDetectionPoint.Click
        isSelectingDetection = True
        hookProcDelegate = New HookProc(AddressOf MouseHookCallback)
        mouseHookHandle = SetWindowsHookEx(WH_MOUSE_LL, hookProcDelegate, IntPtr.Zero, 0)
        ' Removed: Call tmrDetection_Tick(Nothing, Nothing)
    End Sub
    ' Start/Stop button
    Private Sub btnStartStop_Click(sender As Object, e As EventArgs) Handles btnStartStop.Click
        If tmrDetection.Enabled Then
            tmrDetection.Stop()
            btnStartStop.Text = "Start"
            lblStatus.Text = "Stopped"
        Else
            tmrDetection.Start()
            btnStartStop.Text = "Stop"
            lblStatus.Text = "Running"
        End If
    End Sub

    ' Reset points
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        backgroundPoint = Point.Empty
        detectionPoint = Point.Empty
        lblBackgroundPoint.Text = "Background: Not Set"
        lblDetectionPoint.Text = "Detection: Not Set"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrDetection.Interval = 2 ' 2ms
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        '   screenCap.Save("C:\debug_bg.png", Imaging.ImageFormat.Png)
    End Sub
End Class