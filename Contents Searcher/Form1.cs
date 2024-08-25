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
        private string fileTypes = ".h,.cpp"; // Default file types to search, comma-separated
        private string result;
        private List<string> searchResults = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            // Assuming you have already set up your Form and controls in the designer.
            // Make sure the panel is set up with AutoScroll enabled.
            panelButtons.AutoScroll = true;
        }

        private void SearchInFolder(string currentFolder)
        {
            searchResults.Clear(); // Clear previous search results
            panelButtons.Controls.Clear(); // Clear previous buttons

            StringComparison comparisonType = caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
            SearchOption searchOption = recursiveSearch ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            // Define the directories to skip
            var directoriesToSkip = new List<string>
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
                    // Collect files, handling unauthorized access
                    files.AddRange(Directory.EnumerateFiles(currentFolder, "*.*", searchOption)
                        .Where(file => extensions.Any(ext => file.EndsWith(ext.Trim(), comparisonType))));
                }
                catch (UnauthorizedAccessException)
                {
                    // Handle or log the exception as needed
                }

                int verticalPosition = 10; // Initial vertical position for the first button

                foreach (string file in files)
                {
                    try
                    {
                        string fileContent = File.ReadAllText(file);
                        if (fileContent.IndexOf(searchString, comparisonType) >= 0)
                        {
                            string result = $"Found matching content in file: {file}";
                            searchResults.Add(result);

                            // Create a button for this file
                            Button openButton = new Button
                            {
                                Text = $"Open: {Path.GetFileName(file)}",
                                Tag = file, // Store the file path in the Tag
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
                    catch (UnauthorizedAccessException)
                    {
                        // Handle or log the exception as needed
                    }
                }

                // Adjust the scroll range of the panel based on the total height of the buttons
                panelButtons.AutoScrollMinSize = new Size(0, verticalPosition);
            }
            else
            {
                string result = "Folder does not exist: " + currentFolder;
                searchResults.Add(result);
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string file)
            {
                // Open the file's directory in File Explorer and optionally highlight the file
                string args = $"/select,\"{file}\"";
                Process.Start("explorer.exe", args);

                // You could also open the file in a text editor
                // Example: Process.Start("notepad.exe", $"{file}");
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
            SearchInFolder(folderPath); 
            consoleOutRichTextBox1.Text = string.Join(Environment.NewLine, searchResults);
        }

        private void fileTypesTextBox1_TextChanged(object sender, EventArgs e)
        {

            fileTypes = fileTypesTextBox1.Text;
        }
    }
}
