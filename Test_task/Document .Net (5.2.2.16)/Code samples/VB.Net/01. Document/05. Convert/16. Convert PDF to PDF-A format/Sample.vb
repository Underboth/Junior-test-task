Imports System.IO
Imports SautinSoft.Document

Namespace Example
    Friend Class Program
        Shared Sub Main(ByVal args() As String)
            ConvertFromFile()
            ConvertFromStream()
        End Sub

        ''' <summary>
        ''' Convert PDF to PDF/A format (file to file).
        ''' </summary>
        ''' <remarks>
        ''' Details: https://www.sautinsoft.com/products/document/help/net/developer-guide/convert-pdf-to-pdf-a-in-csharp-vb.php
        ''' </remarks>
        Private Shared Sub ConvertFromFile()
            Dim inpFile As String = "..\example.pdf"
            Dim outFile As String = "Result.pdf"

            ' Specifying PdfLoadOptions we explicitly set that a loadable document is PDF.
            Dim pdfLO As New PdfLoadOptions() With
            {
                .RasterizeVectorGraphics = False,
                .DetectTables = False,
                .PreserveEmbeddedFonts = False
            }

            ' RasterizeVectorGraphics = False
            ' This means to load vector graphics as is. Don't transform it to raster images.

            ' DetectTables = False
            ' This means don't detect tables.
            ' The PDF format doesn't have real tables, in fact it's a set of orthogonal graphic lines.
            ' Set it to 'True' and the component will detect and recreate tables from graphic lines.

            'PreserveEmbeddedFonts = False
            ' True - Means to load embedded fonts from PDF document, 
            ' even if the font with the same name is installed in your System.

            Dim dc As DocumentCore = DocumentCore.Load(inpFile, pdfLO)

            Dim pdfSO As New PdfSaveOptions() With
            {
                .Compliance = PdfCompliance.PDF_A1a
            }

            dc.Save(outFile, pdfSO)

            ' Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
        End Sub

        ''' <summary>
        ''' Convert PDF to PDF/A format (using Stream).
        ''' </summary>
        ''' <remarks>
        ''' Details: https://www.sautinsoft.com/products/document/help/net/developer-guide/convert-pdf-to-pdf-a-in-csharp-vb.php
        ''' </remarks>
        Private Shared Sub ConvertFromStream()

            ' We need files only for demonstration purposes.
            ' The conversion process will be done completely in memory.
            Dim inpFile As String = "..\example.pdf"
            Dim outFile As String = "ResultStream.pdf"
            Dim inpData() As Byte = File.ReadAllBytes(inpFile)
            Dim outData() As Byte = Nothing

            Using msInp As New MemoryStream(inpData)

                ' Specifying PdfLoadOptions we explicitly set that a loadable document is PDF.
                Dim pdfLO As New PdfLoadOptions() With
                {
                    .RasterizeVectorGraphics = False,
                    .DetectTables = False,
                    .PreserveEmbeddedFonts = False
                }

                ' RasterizeVectorGraphics = False
                ' This means to load vector graphics as is. Don't transform it to raster images.

                ' DetectTables = False
                ' This means don't detect tables.
                ' The PDF format doesn't have real tables, in fact it's a set of orthogonal graphic lines.
                ' Set it to 'True' and the component will detect and recreate tables from graphic lines.

                'PreserveEmbeddedFonts = False
                ' True - Means to load embedded fonts from PDF document, 
                ' even if the font with the same name is installed in your System.

                ' Load a document.
                Dim dc As DocumentCore = DocumentCore.Load(msInp, pdfLO)

                ' Save the document to PDF/A format.

                Dim pdfSO As New PdfSaveOptions() With
                {
                    .Compliance = PdfCompliance.PDF_A1a
                }

                Using outMs As New MemoryStream()
                    dc.Save(outMs, pdfSO)
                    outData = outMs.ToArray()
                End Using
                ' Show the result for demonstration purposes.
                If outData IsNot Nothing Then
                    File.WriteAllBytes(outFile, outData)
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(outFile) With {.UseShellExecute = True})
                End If
            End Using
        End Sub
    End Class
End Namespace
