Imports System
Imports System.Linq
Imports SautinSoft.Document
Module Sample
    Sub Main()
        ShowLists()
    End Sub

    ''' <summary>
    ''' Find all paragraphs in a document marked as list (ordered or unordered).
    ''' </summary>
    ''' <remarks>
    ''' Details: https://sautinsoft.com/products/document/help/net/developer-guide/elementcollection-linq.php
    ''' </remarks>
    Sub ShowLists()
        Dim filePath As String = "..\example.docx"
        Dim dc As DocumentCore = DocumentCore.Load(filePath)

        For Each p As Paragraph In dc.GetChildElements(True, ElementType.Paragraph).Where(Function(par) (TryCast(par, Paragraph)).ListFormat.IsList)
            Console.WriteLine(p.Content.ToString())
        Next p
        Console.ReadKey()
    End Sub
End Module