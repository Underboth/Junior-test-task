Imports System
Imports System.IO
Imports SautinSoft.Document

Module Sample
    Sub Main()
        LoadPDFFromFile()
        'LoadPDFFromStream()
    End Sub

    ''' <summary>
    ''' Loads a PDF document into DocumentCore (dc) from a file.
    ''' </summary>
    ''' <remarks>
    ''' Details: https://www.sautinsoft.com/products/document/help/net/developer-guide/load-pdf-document-net-csharp-vb.php
    ''' </remarks>
    Sub LoadPDFFromFile()
        Dim filePath As String = "..\example.pdf"

        ' The file format is detected automatically from the file extension: ".pdf".
        ' But as shown in the example below, we can specify PdfLoadOptions as 2nd parameter
        ' to explicitly set that a loadable document has PDF format.
        Dim dc As DocumentCore = DocumentCore.Load(filePath)

        If dc IsNot Nothing Then
            Console.WriteLine("Loaded successfully!")
        End If

        Console.ReadKey()
    End Sub

    ''' <summary>
    ''' Loads a PDF document into DocumentCore (dc) from a MemoryStream.
    ''' </summary>
    ''' <remarks>
    ''' Details: https://www.sautinsoft.com/products/document/help/net/developer-guide/load-pdf-document-net-csharp-vb.php
    ''' </remarks>
    Sub LoadPDFFromStream()
        ' Assume that we already have a PDF document as bytes array.
        Dim fileBytes() As Byte = File.ReadAllBytes("..\example.pdf")

        Dim dc As DocumentCore = Nothing

        ' Create a MemoryStream
        Using pdfStream As New MemoryStream(fileBytes)

            ' Specifying PdfLoadOptions we explicitly set that a loadable document is PDF.
            Dim pdfLO As New PdfLoadOptions() With {
            .RasterizeVectorGraphics = False,
            .DetectTables = False,
            .PreserveEmbeddedFonts = False,
            .PageIndex = 0,
            .PageCount = 1
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


            ' Load a PDF document from the MemoryStream.
            dc = DocumentCore.Load(pdfStream, New PdfLoadOptions())
        End Using
        If dc IsNot Nothing Then
            Console.WriteLine("Loaded successfully!")
        End If

        Console.ReadKey()
    End Sub
End Module