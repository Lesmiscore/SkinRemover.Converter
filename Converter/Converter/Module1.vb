Imports System.IO
Imports System.Drawing

Module Module1
    '
    Sub Main(args As String())
        Console.WriteLine("Starting...")
        For Each i In args
            If i.EndsWith(".png") Then
                Console.WriteLine("The file is PNG file:" & i)
                Continue For
            End If
            Dim fileSize = GetFileSize(i)
            Select Case fileSize
                Case 64 * 64 * 4
                    Console.WriteLine("Converting:" & i)
                    Dim bmp As New Bitmap(64, 64)
                    Using fs As New FileStream(i, FileMode.Open)
                        For j = 0 To 64 * 64 - 1
                            Dim b = fs.ReadByte
                            Dim c = fs.ReadByte
                            Dim d = fs.ReadByte
                            Dim a = fs.ReadByte
                            bmp.SetPixel(j Mod 64, Math.Floor(j / 64), Color.FromArgb(a, b, c, d))
                        Next
                    End Using
                    bmp.Save(i & ".png")
                Case 64 * 32 * 4
                    Console.WriteLine("Converting:" & i)
                    Dim bmp As New Bitmap(64, 32)
                    Using fs As New FileStream(i, FileMode.Open)
                        For j = 0 To 64 * 32 - 1
                            Dim b = fs.ReadByte
                            Dim c = fs.ReadByte
                            Dim d = fs.ReadByte
                            Dim a = fs.ReadByte
                            bmp.SetPixel(j Mod 64, Math.Floor(j / 64), Color.FromArgb(a, b, c, d))
                        Next
                    End Using
                    bmp.Save(i & ".png")
                Case Else
                    Console.WriteLine("The file is invalid:" & i)
            End Select
        Next
        Console.WriteLine("Complete!")
    End Sub
    Function GetFileSize(s As String) As Long
        Using fs As New FileStream(s, FileMode.Open)
            Return fs.Length
        End Using
    End Function
End Module
