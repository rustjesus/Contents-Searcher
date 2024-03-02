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
        private string result;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private List<string> searchResults = new List<string>();
        
        private void SearchInFolder(string currentFolder)
        {
            searchResults.Clear(); // Clear previous search results

            StringComparison comparisonType = caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
            SearchOption searchOption = recursiveSearch ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            if (Directory.Exists(currentFolder))
            {
                string[] files = Directory.EnumerateFiles(currentFolder, "*.*", searchOption)
                        .Where(file => file.EndsWith(".h") || file.EndsWith(".cpp"))
                        .ToArray();

                foreach (string file in files)
                {
                    string fileContent = File.ReadAllText(file);
                    if (fileContent.IndexOf(searchString, comparisonType) >= 0)
                    {
                        result = "Found matching content in file: " + file;
                        searchResults.Add(result);
                    }
                }
            }
            else
            {
                result = "Folder does not exist: " + currentFolder;
                searchResults.Add(result);
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
    }
}
