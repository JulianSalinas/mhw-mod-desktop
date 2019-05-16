using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Reflection;

namespace mhw_mod_desktop
{
    public partial class Window : Form
    {
        /// <summary>
        /// All used functions are here 
        /// </summary>
        private Manager manager;

        /// <summary>
        /// Files inside the directory found 
        /// </summary>
        private List<string> files;

        /// <summary>
        /// Files inside the zip file selected 
        /// </summary>
        private List<string> zipEntries;

        /// <summary>
        /// Invisible box that only is showed when a file is double clicked to change its name 
        /// </summary>
        private TextBox fileEditBox;

        /// <summary>
        /// Points the last used file in @files 
        /// </summary>
        private int lastSelectedIndex;

        /// <summary>
        /// It is the current id that the selected file has
        /// </summary>
        private string oldId;

        /// <summary>
        /// It is the id to rename the selected file 
        /// </summary>
        private string newId;

        public Window()
        {
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
            true);

            InitializeComponent();
            lastSelectedIndex = -1;
            manager = new Manager();

            searchTextBox.Text = ConfigurationManager.AppSettings.Get("initialSearch");
            findInComboBox.SelectedItem = ConfigurationManager.AppSettings.Get("initialFolder");

            InitializeFileEditBox();
            UpdateFolders();
        }

        /// <summary>
        /// Puts the fileEditBox invisible 
        /// </summary>
        public void InitializeFileEditBox()
        {
            fileEditBox = new TextBox
            {
                Visible = false,
                Size = new Size(0, 0),
                Location = new Point(0, 0)
            };

            fileEditBox.LostFocus += new EventHandler(FocusOver);
            fileEditBox.KeyPress += new KeyPressEventHandler(EditOver);
            filesListBox.Controls.AddRange(new Control[] { fileEditBox });
        }

        /// <summary>
        /// Just updates the folders when the user inserts and clicks a new folder to find 
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            UpdateFolders();
            UpdateConfigFile("initialSearch", searchTextBox.Text);
        }

        private void FindInComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateConfigFile("initialFolder", findInComboBox.Text);
        }

        private void UpdateConfigFile(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }

        /// <summary>
        /// Fires the action of renaming the Id written by the user in all the files 
        /// inside the zip. It does not do nothing if the choosen file is not a zip.
        /// </summary>
        private void AssignButton_Click(object sender, EventArgs e)
        {
            newId = newArmorIdTextBox.Text;
            if (!(zipEntries != null && zipEntries.Count > 0))
            {
                statusLabel.Text = "There are no files to change";
            }
            else if (!(oldId != null && manager.IsValidArmor(newId)))
            {
                statusLabel.Text = "Invalid armor id";
            }
            else
            {
                string zip = files[filesListBox.SelectedIndex];
                manager.RenameArmor(zip, oldId, newId, AssignIdCallback);
            }
        }

        /// <summary>
        /// It is called after renaming al the files inside the zip 
        /// </summary>
        private void AssignIdCallback()
        {
            string message = "Armor {0} was changed to {1}";
            statusLabel.Text = string.Format(message, oldId, newId);
            oldId = newId;
            armorTextBox.Text = oldId;
            UpdateZipEntries();
        }

        /// <summary>
        /// Refresh the information when the user inputs new informations 
        /// </summary>
        private void UpdateFolders()
        {
            string startFolder = manager.GetFolderOf(findInComboBox.Text);
            string foundFolder = manager.GetFolderOf(searchTextBox.Text, startFolder);

            files = manager.GetFileList(foundFolder);
            filesListBox.DataSource = manager.MapFilesToNames(files);

            if (foundFolder == null)
            {
                folderTextBox.Text = null;
                armorTextBox.Text = null;
                currentFileTextBox.Text = null;
                zipFilesListBox.DataSource = null;
                statusLabel.Text = "Nothing found there";
            }
            else
            {
                folderTextBox.Text = foundFolder;
                statusLabel.Text = string.Format("Path updated to {0}", foundFolder);
            }

        }

        /// <summary>
        /// Change the zip entries when the user clicks a zip file 
        /// </summary>
        private void FilesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lastSelectedIndex == filesListBox.SelectedIndex)
            {
                return;
            }
            UpdateZipEntries();
        }

        /// <summary>
        /// Fired when entries have changed 
        /// </summary>
        private void UpdateZipEntries()
        {
            string file = files[filesListBox.SelectedIndex];
            currentFileTextBox.Text = file;
            if (Path.GetExtension(file) == ".zip")
            {
                manager.GetZipEntries(file, ZipEntriesUpdated);
            }
            else
            {
                zipEntries = null;
                zipFilesListBox.DataSource = null;
                armorTextBox.Text = null;
            }
            lastSelectedIndex = filesListBox.SelectedIndex;
        }

        private void ZipEntriesUpdated(List<string> entries)
        {
            zipEntries = entries;
            zipFilesListBox.DataSource = zipEntries;
            oldId = manager.ExtractArmorId(zipEntries);
            armorTextBox.Text = oldId;
        }

        /// <summary>
        /// Shows the a component to edit the file's name 
        /// </summary>
        private void FilesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string file = manager.GetFolderName(files[filesListBox.SelectedIndex]);
            statusLabel.Text = string.Format("Changing name of \"{0}\"", file);
            ShowFileEditBox(sender);
        }

        /// <summary>
        /// Fired by @FilesListBox_MouseDoubleClick
        /// </summary>
        private void ShowFileEditBox(object sender)
        {
            int index = filesListBox.SelectedIndex;
            Rectangle shape = filesListBox.GetItemRectangle(index);

            fileEditBox.Location = new Point(shape.X, shape.Y);
            fileEditBox.Size = new Size(shape.Width, shape.Height);
            fileEditBox.Show();

            fileEditBox.Text = (string)filesListBox.Items[index];
            fileEditBox.Focus();
            fileEditBox.SelectAll();
        }

        /// <summary>
        /// The clicks outside the edit box 
        /// </summary>
        private void FocusOver(object sender, EventArgs e)
        {
            fileEditBox.Hide();
        }

        /// <summary>
        /// User press enter the confirm the edition 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditOver(object sender, KeyPressEventArgs e)
        {
            // Enter was pressed
            if (e.KeyChar == 13)
            {
                UpdateFileName();
            }
        }

        /// <summary>
        /// Updates the file's name of the selected item 
        /// </summary>
        public void UpdateFileName()
        {
            int index = filesListBox.SelectedIndex;
            string itemSelected = files[index];
            manager.ChangeFileName(itemSelected, fileEditBox.Text);
            UpdateFolders();
            fileEditBox.Hide();
        }

        private void Window_Load(object sender, EventArgs e)
        {
            
        }
    }

}
