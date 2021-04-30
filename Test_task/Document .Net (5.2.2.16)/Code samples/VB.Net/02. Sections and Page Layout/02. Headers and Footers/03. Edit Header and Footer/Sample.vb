Imports System
Imports System.IO
Imports SautinSoft.Document

Module Sample
    Sub Main()
        ChangeHeader()
    End Sub

    ''' <summary>
    ''' How to edit Header and Footer in PDF file
    ''' </summary>
    ''' <remarks>
    ''' Details: https://www.sautinsoft.com/products/document/help/net/developer-guide/edit-header-and-footer-in-pdf-net-csharp-vb.php
    ''' </remarks>
    Sub ChangeHeader()
        Dim inpFile As String = "..\somebody.pdf"
        Dim outFile As String = "With changed header.pdf"
        Dim dc As DocumentCore = DocumentCore.Load(inpFile)

        ' Create new header with formatted text.
        Dim header As New HeaderFooter(dc, HeaderFooterType.HeaderDefault)
        header.Content.Start.Insert("Modified : 1 April 2020", New CharacterFormat() With {
                .Size = 14.0,
                .FontColor = Color.DarkGreen
            })
        For Each s As Section In dc.Sections
            If s.Blocks.Count > 0 Then
                s.Blocks.RemoveAt(1)
            End If
            s.HeadersFooters.Add(header.Clone(True))
        Next s
        dc.Save(outFile)

        ' Open the results for demonstration purposes.
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(inpFile) With {.UseShellExecute = True})
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
    End Sub
End Module