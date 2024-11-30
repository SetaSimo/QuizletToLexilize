using ClosedXML.Excel;
using Newtonsoft.Json;
using QuizletToLexilize.Dto;

class Program
{
    static void Main()
    {
        try
        {
            var filePath = "C:\\Users\\Seta\\Desktop\\quizlet";
            var jsonFiles = Directory.GetFiles(filePath, "*.json", SearchOption.TopDirectoryOnly);

            foreach (var jsonFilePath in jsonFiles)
            {

                var rawJson = File.ReadAllText(jsonFilePath);
                var jsonData = JsonConvert.DeserializeObject<Root>(rawJson);

                var words = GetJapaneseAndRussianWords(jsonData);
                CreateExcelDocument(words, Path.GetFileNameWithoutExtension(jsonFilePath), Path.Combine(filePath, "Done"));
            }


            Console.WriteLine("Done");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ooops...");
            Console.WriteLine(ex.Message);
        }
    }

    private static List<DocRowDto> GetJapaneseAndRussianWords(Root jsonData)
    {
        Console.WriteLine("Reading json...");

        var russianAndJapaneseWords = new List<DocRowDto>();

        foreach (var term in jsonData?.Terms)
        {
            var russianWord = string.Empty;
            var japaneseWord = string.Empty;

            foreach (var cardSide in term.CardSides)
            {
                foreach (var media in cardSide.Media)
                {
                    if (media.Type == 1)
                    {
                        if (media.LanguageCode == "ru")
                        {
                            russianWord = media.PlainText?.Trim();
                        }
                        else if (media.LanguageCode == "ja")
                        {
                            japaneseWord = media.PlainText?.Trim();
                        }
                    }
                }
            }

            russianAndJapaneseWords.Add(new DocRowDto(russianWord, japaneseWord));
        }

        return russianAndJapaneseWords;
    }

    private static void CreateExcelDocument(IEnumerable<DocRowDto> russianAndJapaneseWords, string fileName, string outputPath)
    {
        Console.WriteLine("Converting to excel...");

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Words");

            // Add words to the Excel file
            var cell = 1;
            foreach (var cellData in russianAndJapaneseWords)
            {
                worksheet.Cell(cell, 1).Value = cellData.RussianWord;
                worksheet.Cell(cell, 2).Value = cellData.JapaneseWord;
                cell++;
            }

            // Save the Excel file
            outputPath = Path.Combine(outputPath, $"{fileName}.xlsx");
            workbook.SaveAs(outputPath);
        }
    }
}
