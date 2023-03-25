bool retry = false;
do
{
    try
    {
        Console.WriteLine("Enter directory path:");
        string? directoryPath = Console.ReadLine();

        if (!Directory.Exists(directoryPath))
        {
            throw new DirectoryNotFoundException("Directory not found.");
        }

        Console.WriteLine("Enter word to remove from file names:");
        string? wordToRemove = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(wordToRemove))
        {
            throw new ArgumentException("Word to remove cannot be empty.");
        }

        RenameFiles(directoryPath, wordToRemove);

        Console.WriteLine($"All files with '{wordToRemove}' in their name have been renamed.");

        retry = false;
    }
    catch (DirectoryNotFoundException ex)
    {
        Console.WriteLine(ex.Message);
        retry = true;
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        retry = true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Console.WriteLine("An error occurred while renaming files. Would you like to try again? (Y/N)");

        string userInput = Console.ReadLine().ToUpper();
        retry = userInput == "Y" || userInput == "YES";
    }
} while (retry);

static void RenameFiles(string directoryPath, string wordToRemove)
{
    string[] files = Directory.GetFiles(directoryPath, "*.*", SearchOption.TopDirectoryOnly);

    foreach (string file in files)
    {
        if (file.Contains(wordToRemove))
        {
            string newFileName = file.Replace(wordToRemove, "");
            File.Move(file, Path.Combine(Path.GetDirectoryName(file), newFileName));
        }
    }
}