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

namespace ImageViewer2
{
    public partial class Form1 : Form
    {
        ImFileManager manager;
        Point mouseLastPos = new Point(0, 0); // Last mouse position used for panning
        bool settingup_grids = false;
        //ImManager image;

        // Default contructor causes file dialog to open when imageviewer called without file as argument
        public Form1()
        {
            InitializeComponent();
            ImageViewerInit(null);
        }

        // contructor which is called when imageviewer is opened with command line argument
        public Form1(String arg)
        {
            InitializeComponent();
            //Form1_Construct();
            ImageViewerInit(arg);
        }

        // ImageViewer initialze
        private void ImageViewerInit(String file)
        {
            this.WindowState = FormWindowState.Maximized;
            // Bring this form to the front of the screen
            this.BringToFront();
            //DoubleBuffered = true;
            pictureBox1.MouseWheel += PictureBox1_MouseWheel;
            if (file == null)
            {
                manager = new ImFileManager(pictureBox1);
            }
            else
            {
                FileInfo temp = new FileInfo(file);
                manager = new ImFileManager(temp, pictureBox1);
                
            }


            update_form_text();

        }

        private void update_form_text()
        {
            Text = "ImageViewer - " + manager.get_form_text();
        }

        // Previous image
        private void prev_image()
        {
            manager.ShowPreviousImage();
            pictureBox1.Invalidate();
            update_form_text();
        }
        // Next image
        private void next_image()
        {
            manager.ShowNextImage();
            pictureBox1.Invalidate();
            update_form_text();
        }

        // Open new image from filedialog
        private void open_new_image()
        {
            if(manager.OpenNewFile())
            {
                StandartGrid.Rows.Clear();
                StandartGrid.Columns.Clear();
                StandartGrid.Refresh();
                CorrectionGrid.Rows.Clear();
                CorrectionGrid.Columns.Clear();
                CorrectionGrid.Refresh();
            }
            pictureBox1.Invalidate();
            update_form_text();
        }



        // GIF control
        // Start stop

        // Next frame

        // Set delay between frames to value


        // Prev image
        private void button1_Click(object sender, EventArgs e)
        {
            prev_image();
        }

        // next image
        private void button2_Click(object sender, EventArgs e)
        {
            next_image();
        }

        // Rename current image
        private void button3_Click(object sender, EventArgs e)
        {
            manager.RenameImage();
            update_form_text();
        }

        // delete current image
        private void button4_Click(object sender, EventArgs e)
        {
            manager.DeleteImage();
            pictureBox1.Invalidate();
            update_form_text();
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        // open new image by selecting from openfiledialog
        private void button7_Click(object sender, EventArgs e)
        {
            open_new_image();
        }

        // start pause gif
        // Refresh button
        private void button9_Click(object sender, EventArgs e)
        {
            manager.RefreshFileList();
            update_form_text();
        }

        // Seek to image
        private void button10_Click(object sender, EventArgs e)
        {
            manager.SeekToImage();
            pictureBox1.Invalidate();
            update_form_text();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreateGrid_Click(object sender, EventArgs e)
        {
            int x_lanes = (int)X_.Value;
            int y_lanes = (int)Y_.Value;
            manager.image.InitDefGrid(x_lanes, y_lanes);
            DrawMatrix();
        }

        private void StandartGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!settingup_grids)
            {          
                bool shise = manager.image.EditDefStdGrid(StandartGrid[e.ColumnIndex, e.RowIndex].Value.ToString(), e.RowIndex+1, e.ColumnIndex+1);
                if (shise)
                {
                    DrawMatrix();
                }
            }
        }
        private void CorrectionGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!settingup_grids)
            {
                bool shise = manager.image.EditDefCorrGrid(CorrectionGrid[e.ColumnIndex, e.RowIndex].Value.ToString(), e.RowIndex + 1, e.ColumnIndex + 1);
                if (shise)
                {
                    DrawMatrix();
                }
            }
        }

        private void DrawMatrix()
        {
            settingup_grids = true;
            DrawFromGrids(manager.image.def_grid.GetStandartGrid(), StandartGrid);
            DrawFromGrids(manager.image.def_grid.GetCorrectioGrid(), CorrectionGrid);
            settingup_grids = false;
            pictureBox1.Invalidate();
        }

        private void Correct_button_Click(object sender, EventArgs e)
        {
            manager.image.CorrectImage();
            pictureBox1.Invalidate();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            manager.Saveimage();
        }

        private void DrawFromGrids(PointF[,] def_grid, DataGridView form_grid)
        {
            int x_len = def_grid.GetLength(0) - 2;
            int y_len = def_grid.GetLength(1) - 2;
            form_grid.ColumnCount = x_len;
            form_grid.RowCount = y_len;
            for (int z = 0; z < x_len; z++)
            {
                form_grid.Columns[z].Name = $"{z + 1}";
            }
            for (int i = 0; i < x_len; i++)
            {
                form_grid.Columns[i].Name = $"{i + 1}";
                for (int z = 0; z < y_len; z++)
                {
                    PointF point = def_grid[i + 1, z + 1];
                    form_grid[i, z].Value = $"{point.X};{point.Y}";
                }
            }
        }

    }
}
