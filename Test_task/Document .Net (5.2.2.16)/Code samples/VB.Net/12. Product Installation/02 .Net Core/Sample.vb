Imports System
Imports System.IO
Imports SautinSoft.Document

Module Sample
    Sub Main()
        ExampleHelloWorld()
    End Sub

    ''' <summary>
    ''' Create file with Hello World.
    ''' </summary>
    ''' <remarks>
    ''' Details: https://sautinsoft.com/products/document/help/net/developer-guide/using-in-netcore.php
    ''' </remarks>
    Sub ExampleHelloWorld()
        Dim dc As New DocumentCore()
        dc.Content.End.Insert("Hello World!", New CharacterFormat() With {
                .FontName = "Verdana",
                .Size = 65.5R,
                .FontColor = Color.DarkBlue
            })

        ' Save a document to a file in PDF format.
        Dim filePath As String = "Result.pdf"
        dc.Save(filePath)

        ' Open the result for demonstration purposes.
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(filePath) With {.UseShellExecute = True})
    End Sub
End Module