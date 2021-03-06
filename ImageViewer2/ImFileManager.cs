﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageViewer2
{
    class ImFileManager
    {
        // list or array of images from current directory
        FileInfo[] file_list;

        // TODO: consider using List<> instead of arrays
        //List<FileInfo> list_files;

        // current working list as array of indeces into directory list
        // to allow for searching
        int[] search_list;

        // current index into working list
        int current_file_index = 0;

        public ImManager image;

        static readonly string[] extensions = new string[] { ".jpg", ".jpeg", ".png", ".jfif" };


        //FileSystemWatcher dir_watch;

        public ImFileManager(PictureBox pictureBox)
        {
            //list_files = new List<FileInfo>();

            image = new ImManager(pictureBox);
            OpenNewFile();
        }

        public ImFileManager(FileInfo image_file, PictureBox pictureBox)
        {
            //this.imagefilepath = image_file;

            GetFileList(image_file);

            image = new ImManager(pictureBox, image_file);

            //this.currentDir = this.imagefilepath.Directory;
            //OpenFile()
        }



        // valid fileextension
        private bool ValidExtension(String ext)
        {
            if (extensions.Contains(ext.ToLower())) return true;
            return false;
        }

        private bool IsUninitialized()
        {
            return file_list == null || search_list == null;
        }


        // open image
        public void OpenImage(FileInfo file)
        {
            if (file.Exists && ValidExtension(file.Extension))
            {
                image.Change_Image(file);
            }
            else
            {
                GetFileList(file);
            }

        }

        private FileInfo GetCurrentFile()
        {
            return file_list[search_list[current_file_index]];
        }

        private FileInfo GetFile(int i)
        {
            return file_list[search_list[i]];
        }

        // open file dialog
        public bool OpenNewFile()
        {

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                DirectoryInfo last_dir = file_list == null ? new DirectoryInfo(@"C:\") : file_list[0].Directory;
                FileInfo last_file = null;

                

                if (file_list != null)
                {
                    last_file = this.GetCurrentFile();
                    openFileDialog1.FileName = last_file.Name;

                }

                openFileDialog1.InitialDirectory = last_dir.FullName;

                //openFileDialog1.Filter = "image files|*.jpg;*.JPG;*.jpeg;*.png|All files|*.*";
                openFileDialog1.Filter = "All files|*.*";

                //openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;

                // RefreshSection ?

                String file_ext = ".fake";
                do
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        FileInfo new_file = new FileInfo(openFileDialog1.FileName);

                        DirectoryInfo new_dir = new_file.Directory;

                        GetFileList(new_file);

                        image.Change_Image(GetCurrentFile());
                        file_ext = GetCurrentFile().Extension;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                } while (!ValidExtension(file_ext));
            }
        }

        public void Saveimage()
        {
            FileInfo curr_file = this.GetCurrentFile();
            ImageFormat format = ImageFormat.Png;
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = curr_file.Name;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string ext = System.IO.Path.GetExtension(saveFileDialog1.FileName);
                    switch (ext)
                    {
                        case ".jpeg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                    }
                    this.image.GetImage().Save(saveFileDialog1.FileName, format);
                }
            }
        }


        private void GetFileList(FileInfo file)
        {
            if (!file.Directory.Exists) throw new System.Exception("Directory does not exist");

            // Get files and order them
            var tmp = file.Directory.GetFiles("*.*", SearchOption.TopDirectoryOnly).Where(s => extensions.Contains(s.Extension.ToLower()));

            file_list = tmp.ToArray();


            search_list = Enumerable.Range(0, file_list.Length).ToArray();

            // Find index of current image
            get_working_index(file);
            //imagefilepath = file_list[search_list[list_index]];
        }

        // set and return index of file in search_list
        private int get_working_index(FileInfo file)
        {
            current_file_index = 0;
            for (int i = 0; i < search_list.Length; i++)
            {
                if (this.GetFile(i).FullName.Equals(file.FullName))
                {
                    // set list_index
                    current_file_index = i;
                    break;
                }
            }
            return current_file_index;
        }

        // next image
        public void ShowNextImage()
        {
            if (file_list == null || search_list == null) return;
            current_file_index = (current_file_index + 1) % (search_list.Length);
            image.Change_Image(GetCurrentFile());
        }


        // prev image
        public void ShowPreviousImage()
        {
            if (file_list == null || search_list == null) return;
            current_file_index = (current_file_index - 1 + search_list.Length) % (search_list.Length);
            image.Change_Image(GetCurrentFile());
        }

        // Refresh file list
        public void RefreshFileList()
        {
            if (file_list == null || search_list == null) return;
            FileInfo tmp = GetCurrentFile();
            GetFileList(tmp);
            //get_working_index(tmp); called by GetFileList(file)
        }


        // Rename current image
        public void RenameImage()
        {
            if (file_list == null || search_list == null) return;
            FileInfo tmp = GetCurrentFile();

            using (RenameForm form = new RenameForm())
            {
                form.FileName = tmp.Name;

                if (form.ShowDialog() == DialogResult.OK)
                {

                    FileInfo newfile = new FileInfo(tmp.DirectoryName + @"\" + form.FileName);

                    if (tmp.Equals(newfile)) return;

                    if (newfile.Exists)
                    {
                        MessageBox.Show("New file name already exists");
                        return;
                    }


                    image.DisposeImage();

                    try
                    {
                        tmp.MoveTo(newfile.FullName);

                        GetFileList(newfile);

                        image.Change_Image(GetCurrentFile());
                    }
                    catch (Exception e)
                    {
                        image.Change_Image(tmp);
                    }


                    //GetFileList(newfile); // refresh

                }
            }

        }


        // Delete current image
        public void DeleteImage()
        {

            if (file_list == null || search_list == null) return;
            FileInfo tmp = GetCurrentFile();

            DialogResult result = MessageBox.Show("Are you sure you want to delete this image", "Delete image", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                image.DisposeImage();

                try
                {
                    File.Delete(tmp.FullName);
                }
                catch (Exception e)
                {
                    image.Change_Image(tmp);
                    return;
                }

                ShowNextImage();

                GetFileList(GetCurrentFile());
            }
            
            //GetFileList(newfile); // refresh


        }



        // TODO: Add seek functionality
        // Seek into current search_list to any position
        public void SeekToImage()
        {
            if (file_list == null || search_list == null) return;
            //FileInfo tmp = GetCurrentFile();

            using (SeekForm form = new SeekForm())
            {
                // max index needs to be set before index
                form.MaxIndex = search_list.Length;

                form.Index = current_file_index + 1;
                


                List<FileInfo> tmplist = new List<FileInfo>();

                foreach(int indexer in search_list)
                {
                    tmplist.Add(file_list[indexer]);
                }


                form.SetFileList(tmplist);


                if (form.ShowDialog() == DialogResult.OK)
                {


                    current_file_index = (int)form.Index - 1;

                    image.Change_Image(GetCurrentFile());



                }
            }
        }






        // search current directory list and update current working list
        // if current image not in new list show first image in list

        public void SearchCurrent(String search_text)
        {
            if (file_list == null) return;


            FileInfo tmp = GetCurrentFile();

            List<int> list = new List<int>();

            for(int i = 0; i < file_list.Length; i++)
            {
                // basic search 
                // no regex
                if (file_list[i].Name.Contains(search_text)) list.Add(i);
            }

            search_list = list.ToArray();
            
            UpdateImage(tmp);
        }


        // clear search


        public void clear_search()
        {

            FileInfo tmp = GetCurrentFile();

            search_list = Enumerable.Range(0, file_list.Length).ToArray();

            UpdateImage(tmp);
        }


        private void UpdateImage(FileInfo file_name)
        {
            int tmp = current_file_index;
            get_working_index(file_name);

            // If current file name does not equal given file name
            // update image to first in array
            if(file_name.Name.CompareTo(GetCurrentFile().Name) != 0)
            {
                image.Change_Image(GetFile(0));
            }

        }


        // text to display in titlebar of from
        // [i/n] - image path - Zoom: zoom_value
        public String get_form_text()
        {
            if (search_list == null || file_list == null || image == null) return "";
            else return "[" + (current_file_index + 1) + "/" + search_list.Length + "] " + file_list[search_list[current_file_index]].FullName + " - Zoom: " + image.get_zoom();
        }


    }
}
