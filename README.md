# CommonTextFileRename
Very basic and simple console application developed in .NET 7 that renames files in a directory by removing a specific word from their names.
The user is prompted to enter the directory path and the word to remove, and the program renames all files in the directory that contain the specified word in their name.

The logic of the application is formed by the RenameFiles method, which takes the directory path and the word to remove as input parameters. The method uses the Directory.GetFiles method to get a list of all files in the directory and loops through each file. If the file name contains the specified word, the method uses the File.Move method to rename the file by replacing the word with an empty string.

The application includes exception handling to handle errors such as invalid directory paths, invalid input, and file renaming failures. If an error occurs during renaming, the user is prompted to retry renaming or exit the program.
