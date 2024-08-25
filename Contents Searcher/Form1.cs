using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Contents_Searcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string folderPath = "Assets"; // The folder path to search.
        private string searchString = ""; // The string to check for.
        private bool caseSensitive = false; // Toggle for case sensitivity
        private bool recursiveSearch = true; // Toggle for recursive searching
        private string fileTypes = ".h,.cpp,.txt,.cs,.py"; // Default file types to search, comma-separated
        private int results;
        private List<string> searchResults = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            results = 0;
            resultsCountLabel.Text = "Results = " + results;
            fileTypesTextBox1.Text = fileTypes;
            // Assuming you have already set up your Form and controls in the designer.
            // Make sure the panel is set up with AutoScroll enabled.
            panelButtons.AutoScroll = true;
        }
        private void UpdateProgressBar(int currentValue, int maxValue)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = maxValue;
            progressBar1.Value = currentValue;
        }

        private void SearchInFolderRootIncluded(string currentFolder)
        {
            results = 0;
            resultsCountLabel.Text = "Results = " + results;
            searchResults.Clear(); // Clear previous search results
            panelButtons.Controls.Clear(); // Clear previous buttons

            StringComparison comparisonType = caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
            SearchOption searchOption = recursiveSearch ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            // Define the directories to skip
            var directoriesToSkip = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "System Volume Information",
        "Recycler",
        "$RECYCLE.BIN"
    };

            if (Directory.Exists(currentFolder))
            {
                string[] extensions = fileTypes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> files = new List<string>();

                try
                {
                    // Log current folder being searched
                    Console.WriteLine($"Searching in directory: {currentFolder}");

                    // Collect files in the current directory
                    files.AddRange(Directory.EnumerateFiles(currentFolder, "*.*", SearchOption.TopDirectoryOnly)
                        .Where(file => extensions.Any(ext => file.EndsWith(ext.Trim(), comparisonType))));

                    // Collect files in subdirectories
                    foreach (var dir in Directory.EnumerateDirectories(currentFolder, "*", SearchOption.AllDirectories))
                    {
                        var dirName = new DirectoryInfo(dir).Name;
                        if (!directoriesToSkip.Contains(dirName))
                        {
                            try
                            {
                                files.AddRange(Directory.EnumerateFiles(dir, "*.*", SearchOption.TopDirectoryOnly)
                                    .Where(file => extensions.Any(ext => file.EndsWith(ext.Trim(), comparisonType))));
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                // Log or handle the exception as needed
                                Console.WriteLine($"UnauthorizedAccessException accessing directory {dir}: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                // Catch other potential exceptions
                                Console.WriteLine($"Exception accessing directory {dir}: {ex.Message}");
                            }
                        }
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    // Log or handle the exception as needed
                    Console.WriteLine($"UnauthorizedAccessException: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Catch other potential exceptions
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                int verticalPosition = 10; // Initial vertical position for the first button

                foreach (string file in files)
                {
                    try
                    {
                        Console.WriteLine($"Checking file: {file}");

                        string fileContent = File.ReadAllText(file);
                        if (fileContent.IndexOf(searchString, comparisonType) >= 0)
                        {
                            // Normalize the path to ensure consistent use of backslashes
                            string normalizedPath = Path.GetFullPath(file);

                            string result = $"Found matching content in file: {normalizedPath}";
                            searchResults.Add(result);

                            results++;
                            resultsCountLabel.Text = "Results = " + results;
                            // Create a button for this file
                            Button openButton = new Button
                            {
                                Text = $"Open: {Path.GetFileName(file)}",
                                Tag = normalizedPath, // Store the file path in the Tag
                                AutoSize = true,
                                Margin = new Padding(1),
                                Location = new Point(1, verticalPosition) // Set the location dynamically
                            };

                            // Increment the vertical position for the next button
                            verticalPosition += openButton.Height + 10; // Adjust spacing between buttons

                            // Add click event to open directory and highlight the file
                            openButton.Click += OpenButton_Click;

                            // Add the button to the panel
                            panelButtons.Controls.Add(openButton);
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        // Log or handle the exception as needed
                        Console.WriteLine($"UnauthorizedAccessException while reading file: {file}, Exception: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        // Catch other potential exceptions
                        Console.WriteLine($"Exception while reading file: {file}, Exception: {ex.Message}");
                    }
                }

                // Adjust the scroll range of the panel based on the total height of the buttons
                panelButtons.AutoScrollMinSize = new Size(0, verticalPosition);
                consoleOutRichTextBox1.Text = string.Join(Environment.NewLine, searchResults);
            }
            else
            {
                string result = "Folder does not exist: " + currentFolder;
                searchResults.Add(result);
                consoleOutRichTextBox1.Text = result;
            }
        }
        private void SearchInFolderDeep(string currentFolder)
        {
            results = 0;
            resultsCountLabel.Text = "Results = " + results;
            searchResults.Clear(); // Clear previous search results
            panelButtons.Controls.Clear(); // Clear previous buttons

            StringComparison comparisonType = caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
            SearchOption searchOption = recursiveSearch ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            // Define the directories to skip
            var directoriesToSkip = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "System Volume Information",
        "Recycler",
        "$RECYCLE.BIN"
    };

            if (Directory.Exists(currentFolder))
            {
                string[] extensions = fileTypes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> files = new List<string>();

                try
                {
                    // Collect files, handling unauthorized access and skipping certain directories
                    foreach (var dir in Directory.EnumerateDirectories(currentFolder, "*", searchOption))
                    {
                        var dirName = new DirectoryInfo(dir).Name;
                        if (!directoriesToSkip.Contains(dirName))
                        {
                            try
                            {
                                files.AddRange(Directory.EnumerateFiles(dir, "*.*", searchOption)
                                    .Where(file => extensions.Any(ext => file.EndsWith(ext.Trim(), comparisonType))));
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                // Log or handle the exception as needed
                                Console.WriteLine($"UnauthorizedAccessException accessing directory {dir}: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                // Catch other potential exceptions
                                Console.WriteLine($"Exception accessing directory {dir}: {ex.Message}");
                            }
                        }
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    // Log or handle the exception as needed
                    Console.WriteLine($"UnauthorizedAccessException: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Catch other potential exceptions
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                int verticalPosition = 10; // Initial vertical position for the first button

                foreach (string file in files)
                {
                    try
                    {
                        string fileContent = File.ReadAllText(file);
                        if (fileContent.IndexOf(searchString, comparisonType) >= 0)
                        {
                            // Normalize the path to ensure consistent use of backslashes
                            string normalizedPath = Path.GetFullPath(file);

                            string result = $"Found matching content in file: {normalizedPath}";
                            searchResults.Add(result);

                            results++;
                            resultsCountLabel.Text = "Results = " + results;
                            // Create a button for this file
                            Button openButton = new Button
                            {
                                Text = $"Open: {Path.GetFileName(file)}",
                                Tag = normalizedPath, // Store the file path in the Tag
                                AutoSize = true,
                                Margin = new Padding(1),
                                Location = new Point(1, verticalPosition) // Set the location dynamically
                            };

                            // Increment the vertical position for the next button
                            verticalPosition += openButton.Height + 10; // Adjust spacing between buttons

                            // Add click event to open directory and highlight the file
                            openButton.Click += OpenButton_Click;

                            // Add the button to the panel
                            panelButtons.Controls.Add(openButton);
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        // Log or handle the exception as needed
                        Console.WriteLine($"UnauthorizedAccessException while reading file: {file}, Exception: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        // Catch other potential exceptions
                        Console.WriteLine($"Exception while reading file: {file}, Exception: {ex.Message}");
                    }
                }

                // Adjust the scroll range of the panel based on the total height of the buttons
                panelButtons.AutoScrollMinSize = new Size(0, verticalPosition);
                consoleOutRichTextBox1.Text = string.Join(Environment.NewLine, searchResults);
            }
            else
            {
                string result = "Folder does not exist: " + currentFolder;
                searchResults.Add(result);
                consoleOutRichTextBox1.Text = result;
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string file)
            {
                // Log the file path to debug
                Console.WriteLine($"Opening file: {file}");

                // Ensure the path is correctly enclosed in quotes
                string args = $"/select,\"{file}\"";

                try
                {
                    Process.Start("explorer.exe", args);
                }
                catch (Exception ex)
                {
                    // Handle or log the exception as needed
                    MessageBox.Show($"Failed to open file: {ex.Message}");
                }
            }
        }

        private void searchLocationBox1_TextChanged(object sender, EventArgs e)
        {
            folderPath = searchLocationBox1.Text;
        }

        private void searchStringTextBox1_TextChanged(object sender, EventArgs e)
        {
            searchString = searchStringTextBox1.Text;
        }

        private void searchButton1_Click(object sender, EventArgs e)
        {
            SearchInFolderDeep(folderPath); 
            consoleOutRichTextBox1.Text = string.Join(Environment.NewLine, searchResults);
        }

        private void fileTypesTextBox1_TextChanged(object sender, EventArgs e)
        {

            fileTypes = fileTypesTextBox1.Text;
        }

        private void altSearchButton1_Click(object sender, EventArgs e)
        {

            SearchInFolderRootIncluded(folderPath);
            consoleOutRichTextBox1.Text = string.Join(Environment.NewLine, searchResults);
        }
    }
}
