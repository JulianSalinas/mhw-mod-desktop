using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.IO.Compression;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mhw_mod_desktop
{
    class Manager
    {

        /// <summary>
        /// Gets the user's personal folder 
        /// </summary>
        /// <returns> Ej. C:\Users\{userId}\ </returns>
        public string GetPersonalFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }

        /// <summary>
        /// Gets the user's desktop folder 
        /// </summary>
        /// <returns> Ej. C:\Users\{userId}\Desktop\ </returns>
        public string GetDesktopFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        /// <summary>
        /// Gets the user's documents folder 
        /// </summary>
        /// <returns> Ej. C:\Users\{userId}\Documents\ </returns>
        public string GetDocumentsFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        /// <summary>
        /// Gets the fullpath from a folder according to its name 
        /// </summary>
        /// <param name="name">Folder's name Ej.Documents</param>
        /// <returns> Ej.C:\Users\{userId}\Documents\ </returns>
        public string GetFolderOf(string name)
        {
            string methodName = string.Format("Get{0}Folder", name);
            MethodInfo method = GetType().GetMethod(methodName);
            return (string)method.Invoke(this, null);
        }

        /// <summary>
        /// Gets the fullpath from a folder according to its name 
        /// </summary>
        /// <param name="name">Folder's name Ej.Mods</param>
        /// <param name="start">Folder where the programa can start the searching</param>
        /// <returns> Ej.C:\Users\{userId}\Documents\Mods </returns>
        public string GetFolderOf(string name, string start)
        {
            if (name.Equals(GetFolderName(start)))
                return start;

            foreach (string subFolder in GetFolderList(start))
            {
                string required = GetFolderOf(name, subFolder);
                if (required != null) return required;
            }
            return null;
        }

        /// <summary>
        /// Given a fullpath, returns the folder's name
        /// </summary>
        /// <param name="folder">Ej.C:\Users\{userId}\Documents\</param>
        /// <returns>Ej.Documents</returns>
        public string GetFolderName(string folder)
        {
            return Path.GetFileNameWithoutExtension(folder);
        }

        /// <summary>
        /// Gets a list of files inside a folder 
        /// </summary>
        /// <param name="from">Folder to get the files</param>
        /// <returns>Fullpath of the files inside the folder</returns>
        public List<string> GetFileList(string from)
        {
            try
            {
                return Directory.GetFiles(from).ToList();
            }
            catch (Exception e)
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// Given a list of files with their fullnames, returns just the names 
        /// </summary>
        /// <param name="files"></param>
        /// <returns>Simple name of the given files</returns>
        public List<string> MapFilesToNames(List<string> files)
        {
            return files.Select(file => Path.GetFileName(file)).ToList();
        }

        /// <summary>
        /// Gets the list of folders inside a folder 
        /// </summary>
        /// <param name="from">Forlde</param>
        /// <returns>Fullpath of the folders inside the folder</returns>
        public List<string> GetFolderList(string from)
        {
            try
            {
                return Directory.GetDirectories(from).ToList();
            }
            catch (Exception e)
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// Renames a file using the path from the first argument 
        /// </summary>
        /// <param name="oldFile">Fullpath of the file</param>
        /// <param name="fileName">Just the new name without path</param>
        public void ChangeFileName(string oldFile, string fileName)
        {
            string oldFileFolder = Path.GetDirectoryName(oldFile);
            string newFile = string.Format("{0}/{1}", oldFileFolder, fileName);
            if (!oldFile.Equals(newFile))
            {
                File.Move(oldFile, newFile);
            }
        }

        /// <summary>
        /// Gets the name of each entry inside a zip file 
        /// </summary>
        /// <param name="zip">Zip's filename</param>
        public void GetZipEntries(string zip, GetZipEntriesCallback callback)
        {
            using (ZipArchive archive = ZipFile.OpenRead(zip))
            {
                callback(archive.Entries.Select(entry => entry.FullName).ToList());
            }
        }

        public delegate void GetZipEntriesCallback(List<string> entries);

        /// <summary>
        /// Given a list of files, it tries to extract the Id from at least one of them 
        /// </summary>
        /// <param name="files">Entries from the zip</param>
        /// <returns>The armor Id if exists, otherwise null </returns>
        public string ExtractArmorId(List<string> files)
        {
            string chosen = files.Find(file => ExtractArmorId(file) != null);
            return ExtractArmorId(chosen);
        }

        /// <summary>
        /// Try to extract the name from a single file, The armor follow the next pattern NNN_NNNN
        /// </summary>
        /// <param name="file">Entry from the zip</param>
        /// <returns>The armor Id if exists, otherwise null </returns>
        public string ExtractArmorId(string file)
        {
            if (file == null)
            {
                return null;
            }
            Regex regex = new Regex(@"pl(\d{3}_\d{4})");
            List<Match> matches = regex.Matches(file).Cast<Match>().ToList();
            Match chosen = matches.Count > 0 ? matches.Find(DoesArmorMatch) : null;
            return chosen?.Groups[1].Value;
        }

        /// <summary>
        /// Returns true if the patterns of the armor id is NNN_NNNN
        /// </summary>
        /// <param name="armoId">Armor Id to validate</param>
        /// <returns>True if the armor fulfills the pattern</returns>
        public bool IsValidArmor(string armoId)
        {
            Regex regex = new Regex(@"(\d{3}_\d{4})");
            List<Match> matches = regex.Matches(armoId).Cast<Match>().ToList();
            return matches.Count > 0;
        }

        /// <summary>
        /// Used by IsValidArmor to check if the armor has coincidence with the pattern
        /// </summary>
        /// <param name="match">Match got from IsValidArmor</param>
        /// <returns>True if the amount of groups in the match are greater than 0</returns>
        private bool DoesArmorMatch(Match match)
        {
            return match.Groups.Count > 0;
        }

        /// <summary>
        /// Rename all the entries from the zip the fulfill with the new Id
        /// </summary>
        /// <param name="file">The zip file's fullpath</param>
        /// <param name="oldId">The old armor Id to replace</param>
        /// <param name="newId">The new armor Id</param>
        /// <param name="callback">Used when the renaming process finishes</param>
        public void RenameArmor(string file, string oldId, string newId, RenameCallback callback)
        {
            using (ZipArchive archive = ZipFile.Open(file, ZipArchiveMode.Update))
            {
                RenameArmorFiles(archive, oldId, newId);
            }
            callback();
        }

        private void RenameArmorFiles(ZipArchive archive, string oldId, string newId)
        {

            List<string> filesToCreate = new List<string>();
            List<string> filesToReplace = new List<string>();
            List<ZipArchiveEntry> entriesToRemove = new List<ZipArchiveEntry>();
            
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                string oldFile = entry.FullName;
                string newFile = oldFile.Replace(oldId, newId);
                filesToCreate.Add(newFile);
                filesToReplace.Add(oldFile);
            }

            for (int i = 0; i < filesToCreate.Count; i++)
            {
                string newFile = filesToCreate[i];
                string oldFile = filesToReplace[i];

                ZipArchiveEntry newEntry = archive.GetEntry(newFile);
                ZipArchiveEntry oldEntry = archive.GetEntry(oldFile);

                if (newEntry == null && oldEntry != null)
                {
                    using (var openFile = oldEntry.Open())
                    {
                        using (var b = archive.CreateEntry(newFile).Open())
                        {
                            openFile.CopyTo(b);
                        }
                    }
                    entriesToRemove.Add(oldEntry);
                }

            }
            
            entriesToRemove.ForEach(entry => { if (entry != null) entry.Delete(); });
        }


        public delegate void RenameCallback();

    }

}
