using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Manager
{
    public class Panel
    {
        ListView list;
        ComboBox box;
        Label label;
        string currentPath;
        FileInfo copied;
        bool root;
        List<DirectoryInfo> subDirs = new List<DirectoryInfo>();
        List<FileInfo> subFiles = new List<FileInfo>();

        public Panel(ListView lv, ComboBox cb, Label lb, ImageList im)
        {
            list = lv;
            box = cb;
            label = lb;
            currentPath = "";
            list.SmallImageList = im;
        }

        public void Filter(string filterString)
        {
            if (filterString == "")
            {
                SyncWithPath(currentPath);
                return;
            }

            list.Items.Clear();

            if (!root)
                list.Items.Add("...");

            foreach (DirectoryInfo dir in subDirs)
            {
                ListViewItem newItem = new ListViewItem(dir.Name);
                newItem.ImageIndex = 0;
                list.Items.Add(newItem);
            }

            foreach (FileInfo file in subFiles)
            {
                string text = File.ReadAllText(file.FullName);
                if (text.Contains(filterString))
                {
                    ListViewItem newItem = new ListViewItem(file.Name);
                    newItem.ImageIndex = 1;
                    list.Items.Add(newItem);
                }
            }
        }

        public void Open(ListViewItem item)
        {
            int num = subDirs.Count;
            if (root == false) num++;
            if (item.Name == "...")
            {
                DirectoryInfo dir = new DirectoryInfo(currentPath);
                SyncWithPath(dir.Parent.FullName);
            }
            else
            if (item.Index < num)
            {
                DirectoryInfo dir = new DirectoryInfo(Path.Combine(currentPath, item.Text));
                OpenFolder(dir);
            }
            else
            {
                FileInfo file = new FileInfo(Path.Combine(currentPath, item.Text));
                uFileInfo ufile = new defFileInfo(file);
                if (file.Extension == ".txt" || file.Extension == ".html")
                {
                    ufile = new txtFileInfo(file);
                }
                if (file.Extension == ".xml")
                {
                    ufile = new xmlFileInfo(file);
                }

                ufile.Open();
            }

        }

        public void Copy()
        {
            if (list.SelectedItems.Count == 1 && list.SelectedItems[0].Name != "...")// && File.Exists(Path.Combine(currentPath, list.SelectedItems[0].Name)))
            {
                copied = new FileInfo(Path.Combine(currentPath, list.SelectedItems[0].Text));
            }
            else
            {
                ShowMessage newMessage = new ShowMessage();
                newMessage.setText("Виберіть рівно один файл елемент для копіювання");
                newMessage.Show();
                //MessageBox.Show("Виберіть рівно один файл елемент для копіювання");
            }
        }

        public void Paste()
        {
            if (copied != null && !File.Exists(Path.Combine(currentPath, copied.Name)))
            {
                bool conflict = false;
                for (int i = 0; i < subFiles.Count; ++i)
                {
                    if (subFiles[i].Name == copied.Name)
                        conflict = true;
                }

                if (!conflict)
                {
                    copied.CopyTo(Path.Combine(currentPath, copied.Name));
                    SyncWithPath(currentPath);
                }
            }
            else
            {
                ShowMessage newMessage = new ShowMessage();
                newMessage.setText("Помилка доступу або конфлікт імен");
                newMessage.Show();
                //MessageBox.Show("Помилка доступу або конфлікт імен");
            }
        }

        public void SuperPaste()
        {
            Paste();
            string text = File.ReadAllText(copied.FullName);
            string newText = "";
            string prev = "";
            string cur = "";
            foreach (char ch in text)
            {
                if (ch == '\n')
                {
                    if (prev != cur)
                        newText += "\n" + cur;
                    prev = cur;
                    cur = "";
                }
                else
                    cur += ch;
            }

            File.WriteAllText(Path.Combine(currentPath, copied.Name), newText);
        }

        public void Delete()
        {
            if (list.SelectedItems.Count == 1 && list.SelectedItems[0].Name != "...")
            {

                int num = subDirs.Count;

                if (root == false) num++;

                if (list.SelectedItems[0].Index < num)
                {
                    Directory.Delete(Path.Combine(currentPath, list.SelectedItems[0].Text), true);
                }
                else
                {
                    File.Delete(Path.Combine(currentPath, list.SelectedItems[0].Text));
                }
                SyncWithPath(currentPath);
            }
            else
            {
                ShowMessage newMessage = new ShowMessage();
                newMessage.setText("Виберіть рівно один елемент для видалення");
                newMessage.Show();
                //MessageBox.Show("Виберіть рівно один елемент для видалення");
            }
        }

        public void Rename(string newName)
        {
            if (list.SelectedItems.Count == 1)
            {
                int num = subDirs.Count;

                if (root == false) num++;

                if (list.SelectedItems[0].Index < num)
                {
                    //string newPath = Path.Combine(currentPath, newName);
                    bool conflict = false;
                    foreach (DirectoryInfo dir in subDirs)
                    {
                        if (dir.Name == newName)
                            conflict = true;
                    }
                    if (!conflict)
                        Directory.Move(Path.Combine(currentPath, list.SelectedItems[0].Text), Path.Combine(currentPath, newName));
                    else
                    {
                        ShowMessage newMessage = new ShowMessage();
                        newMessage.setText("Конфлікт імен");
                        newMessage.Show();
                        //MessageBox.Show("Конфлікт імен");
                    }
                }
                if (list.SelectedItems[0].Index >= num)
                {
                    FileInfo oldFile = new FileInfo(Path.Combine(currentPath, list.SelectedItems[0].Text));
                    newName += oldFile.Extension;

                    bool conflict = false;
                    foreach (FileInfo file in subFiles)
                    {
                        if (file.Name == newName)
                            conflict = true;
                    }

                    if (!conflict)
                        File.Move(Path.Combine(currentPath, list.SelectedItems[0].Text), Path.Combine(currentPath, newName));
                    else
                    {
                        ShowMessage newMessage = new ShowMessage();
                        newMessage.setText("Конфлікт імен");
                        newMessage.Show();
                        //MessageBox.Show("Конфлікт імен");
                    }
                }
                SyncWithPath(currentPath);

            }
            else
            {
                ShowMessage newMessage = new ShowMessage();
                newMessage.setText("Виберіть рівно один елемент для перейменування");
                newMessage.Show();
                //MessageBox.Show("Виберіть рівно один елемент для перейменування");
            }
        }

        public void CreateFolder(string name)
        {
            if (isValidName(name) == true)
            {
                Directory.CreateDirectory(Path.Combine(currentPath, name));
                SyncWithPath(currentPath);
            }
            else
            {
                ShowMessage newMessage = new ShowMessage();
                newMessage.setText("Ім'я недопустиме або використовується");
                newMessage.Show();
                //MessageBox.Show("Ім'я недопустиме або використовується", "", MessageBoxButtons.OK);
            }
        }

        public void CreateFile(string name, string extension = ".txt")
        {
            if (isValidName(name + extension) == true)
            {
                File.Create(Path.Combine(currentPath, name + extension)).Close();
                SyncWithPath(currentPath);
                if (extension == ".xml")
                    File.WriteAllText(Path.Combine(currentPath, name + extension), File.ReadAllText("defdataset.xml"));
            }
            else
            {
                ShowMessage newMessage = new ShowMessage();
                newMessage.setText("Ім'я недопустиме або використовується");
                newMessage.Show();
                //MessageBox.Show("Ім'я недопустиме або використовується", "", MessageBoxButtons.OK);
            }
        }

        private void OpenFolder(DirectoryInfo folder)
        {
            SyncWithPath(folder.FullName);
        }

        /*private void OpenFile(FileInfo file)
        {
            Editor editor = new Editor(file);
            editor.setText(File.ReadAllText(file.FullName));
            editor.Show();
        }*/

        private bool isValidName(string name)
        {
            bool isValid = true;
            for (int i = 0; i < name.Length; ++i)
                if (!(name[i] >= 'a' && name[i] <= 'z' || name[i] >= 'A' && name[i] <= 'Z' ||
                    name[i] == ' ' || name[i] >= '0' && name[i] <= '9' || name[i] == '.' || name[i] >= 'а' && name[i] <= 'я'))
                    isValid = false;

            int num = list.Items.Count;
            for (int i = 0; i < num; ++i)
                if (name == list.Items[i].Text)
                    isValid = false;
            return isValid;
        }

        public void ChangeDrive(DriveInfo drive)
        {
            root = true;
            SyncWithPath(drive.Name);
        }

        private void SyncWithPath(string path)
        {
            string p = Path.GetPathRoot(path);
            if (path == (Path.GetPathRoot(path))) root = true;
            else root = false;
            currentPath = path;
            SyncListWithCurrentPath();
            SyncLabelWithCurrentPath();
        }

        private void SyncLabelWithCurrentPath()
        {
            label.Text = currentPath;
        }

        private void SyncListWithCurrentPath()
        {
            list.Items.Clear();
            subDirs.Clear();
            subFiles.Clear();
            if (!root)
                list.Items.Add("...");

            string[] dirs = Directory.GetDirectories(currentPath);
            foreach (string dir in dirs)
            {
                DirectoryInfo dirinfo = new DirectoryInfo(dir);

                subDirs.Add(dirinfo);
                ListViewItem newItem = new ListViewItem(dirinfo.Name);
                newItem.ImageIndex = 0;
                list.Items.Add(newItem);
            }

            string[] files = Directory.GetFiles(currentPath);
            foreach (string file in files)
            {
                FileInfo fileinfo = new FileInfo(file);

                subFiles.Add(fileinfo);
                ListViewItem newItem = new ListViewItem(fileinfo.Name);
                newItem.ImageIndex = 1;
                list.Items.Add(newItem);
            }
        }
    }
}
