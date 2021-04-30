using SautinSoft.Document;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            ExampleHelloWorld();
        }
		
        /// <summary>
        /// Create file with Hello World.
        /// </summary>
        /// <remarks>
        /// Details: https://sautinsoft.com/products/document/help/net/developer-guide/using-in-netcore.php
        /// </remarks>
        static void ExampleHelloWorld()
        {
            DocumentCore dc = new DocumentCore();
            dc.Content.End.Insert("Hello World!", new CharacterFormat() { FontName = "Verdana", Size = 65.5d,FontColor = Color.DarkBlue });
			
            // Save a document to a file in PDF format.
            string filePath = @"Result.pdf";
            dc.Save(filePath);

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }
}
