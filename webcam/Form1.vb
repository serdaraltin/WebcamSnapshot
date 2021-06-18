
Imports System.Runtime
Imports System.Runtime.InteropServices
Public Class Form1
    Public hHwnd As Integer
    Dim yol As String
    Dim shot As New Threading.Thread(New Threading.ThreadStart(AddressOf aa))
    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
    (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer
    Public Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Public Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean
    Public Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
    (ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Short, ByVal hWndParent As Integer, ByVal nID As Integer) As Integer
    Public Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        On Error Resume Next
        Dim random As Random = New Random
        Dim picture As PictureBox = New PictureBox
        picture.Size = New Drawing.Size(1280, 720)
        hHwnd = capCreateCaptureWindowA(0, &H10000000 Or &H40000000, 0, 0, 1280, 720, picture.Handle.ToInt32, 0)
        If SendMessage(hHwnd, &H400S + 10, 0, 0) Then
            SendMessage(hHwnd, &H400S + 52, 66, 0)
        Else
            DestroyWindow(hHwnd)
        End If
        Dim data As IDataObject
        Dim bmap As Image
        SendMessage(hHwnd, &H400S + 30, 0, 0)
        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
            SendMessage(hHwnd, &H400S + 11, 0, 0)
            DestroyWindow(hHwnd)
            yol = My.Computer.FileSystem.GetTempFileName.ToString()
            bmap.Save(yol, Imaging.ImageFormat.Jpeg)

        End If
        data = Nothing
        pView.Image = Image.FromFile(yol)
    End Sub
    Private Sub aa()
        While (True)
            Dim random As Random = New Random
        Dim picture As PictureBox = New PictureBox
        picture.Size = New Drawing.Size(1280, 720)
        hHwnd = capCreateCaptureWindowA(0, &H10000000 Or &H40000000, 0, 0, 1280, 720, picture.Handle.ToInt32, 0)
        If SendMessage(hHwnd, &H400S + 10, 0, 0) Then
            SendMessage(hHwnd, &H400S + 52, 66, 0)
        Else
            DestroyWindow(hHwnd)
        End If
        Dim data As IDataObject
        Dim bmap As Image
        SendMessage(hHwnd, &H400S + 30, 0, 0)
        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
            SendMessage(hHwnd, &H400S + 11, 0, 0)
            DestroyWindow(hHwnd)
            yol = My.Computer.FileSystem.GetTempFileName.ToString()
            bmap.Save(yol, Imaging.ImageFormat.Jpeg)

        End If
        data = Nothing
            pView.Image = Image.FromFile(yol)
            Threading.Thread.Sleep(3000)
        End While
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
