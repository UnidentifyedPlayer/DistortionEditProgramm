using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer2
{
    class ImManager
    {

        // https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image?view=netframework-4.8

        // image
        Bitmap Image;
        // image rectangle for src in draw funciton
        Rectangle im_rec;

        // Rectangle used to draw to screen
        Rectangle disp_rec;

        public DeformationManager def_grid;
        private bool is_def_grid_set = false;
        // coord
        //private Point image_offset = new Point(0, 0);

        // current zoom (% of screen height and/or width)
        private double zoom = 100;        // The zoom of the image
        private readonly double max_zoom = 3000;      // The maximum allowed zoom
        private readonly double min_zoom = 5;         // The minimum allowed zoom
        private double zoom_step = 1.2;


        string err;


        // canvas reference
        PictureBox canvas;


        public ImManager(PictureBox picturebox)
        {

            this.canvas = picturebox;
            disp_rec = new Rectangle(0, 0, 0, 0);

            picturebox.Paint += picturebox_Paint;
        }


        public ImManager(PictureBox picturebox, FileInfo file)
        {
            this.canvas = picturebox;
            disp_rec = new Rectangle(0, 0, 0, 0);

            picturebox.Paint += picturebox_Paint;

            Change_Image(file);
        }

        public Bitmap GetImage()
        {
            return Image;
        }

        public void InitDefGrid(int x_lanes, int y_lanes)
        {
            def_grid = new DeformationManager(Image.Width, Image.Height, x_lanes, y_lanes);
            is_def_grid_set = true;
        }

        public bool EditDefStdGrid(string coordstr, int row_idx, int col_idx)
        {
            string[] coord = coordstr.Split(';');
            PointF point = new PointF(Convert.ToSingle(coord[0]), Convert.ToSingle(coord[1]));
            def_grid.ChangeStdPoint(point, row_idx, col_idx);
            return true;
        }

        public bool EditDefCorrGrid(string coordstr, int row_idx, int col_idx)
        {
            string[] coord = coordstr.Split(';');
            PointF point = new PointF(Convert.ToSingle(coord[0]), Convert.ToSingle(coord[1]));
            def_grid.ChangeCorrPoint(point, row_idx, col_idx);
            return true;
        }


        // draw function draw image to screen
        private void picturebox_Paint(object sender, PaintEventArgs e)
        {
            if (Image == null)
            {
                e.Graphics.Clear(Color.Gray);
                return;
            }

            /*
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;
            */

            e.Graphics.DrawImage(this.Image, disp_rec, im_rec, GraphicsUnit.Pixel);
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                //Draw a black rectangle at some coordinates
                e.Graphics.DrawRectangle(new Pen(Color.Black), disp_rec);
            }

            if(is_def_grid_set)def_grid.Paint(e, disp_rec);
        }

        public void Change_Image(FileInfo file)
        {
            try
            {
                if (Image != null) Image.Dispose();
                
                Image = (Bitmap)Bitmap.FromFile(file.FullName);
                im_rec = new Rectangle(0, 0, Image.Width, Image.Height);
                is_def_grid_set = false;
                rezise_reset();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error when opening image", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Image = null;
            }
        }

        // dispose image freeing file
        public void DisposeImage()
        {
            if (Image == null) return;
            Image.Dispose();
        }



        internal void CorrectImage()
        {
            float xs1 = 0, xs2 = 0, ys1 = 0, ys2 = 0, xc1 = 0, xc2 = 0, yc1 = 0, yc2 = 0;
            int w = Image.Width, h = Image.Height, k = 0, i = 0;
            PointF[,] std_grid = def_grid.GetStandartGrid(), corr_grid = def_grid.GetCorrectioGrid();
            Bitmap newimg = new Bitmap(w, h);
            int startidx = 0, endidx = 0, sign = 0;
            for(int x = 0; x<w; x++)
            {
                if ((x % 2) == 0)
                { startidx = 0; endidx = h-1; sign = 1; }
                else
                { startidx = h-1; endidx = 0; sign = -1; }
                for (int y = startidx; y - endidx != 0; y += sign)
                {
                    if (x < xs1) { i--; }
                    if (x > xs2) { i++; }
                    if (y < ys1) { k--; }
                    if (y > ys2) { k++; }
                    xs1 = Intrapolate(y,  std_grid[i, k].Y,      std_grid[i, k + 1].Y,      std_grid[i, k].X,      std_grid[i, k + 1].X);
                    xs2 = Intrapolate(y,  std_grid[i + 1, k].Y,  std_grid[i + 1, k + 1].Y,  std_grid[i + 1, k].X,  std_grid[i + 1, k + 1].X);
                    ys1 = Intrapolate(x,  std_grid[i, k].X,      std_grid[i + 1, k].X,      std_grid[i, k].Y,      std_grid[i + 1, k].Y);
                    ys2 = Intrapolate(x,  std_grid[i, k + 1].X,  std_grid[i + 1, k + 1].X,  std_grid[i, k + 1].Y,  std_grid[i + 1, k + 1].Y);
                    xc1 = Intrapolate(y, corr_grid[i, k].Y,     corr_grid[i, k + 1].Y,     corr_grid[i, k].X,     corr_grid[i, k + 1].X);
                    xc2 = Intrapolate(y, corr_grid[i + 1, k].Y, corr_grid[i + 1, k + 1].Y, corr_grid[i + 1, k].X, corr_grid[i + 1, k + 1].X);
                    yc1 = Intrapolate(x, corr_grid[i, k].X,     corr_grid[i + 1, k].X,     corr_grid[i, k].Y,     corr_grid[i + 1, k].Y);
                    yc2 = Intrapolate(x, corr_grid[i, k + 1].X, corr_grid[i + 1, k + 1].X, corr_grid[i, k + 1].Y, corr_grid[i + 1, k + 1].Y);


                    PointF intrpoint = new PointF(IntrapolateNewPoint(x, xc1, xc2, xs1, xs2), IntrapolateNewPoint(y, yc1, yc2, ys1, ys2));
                    newimg.SetPixel(x, y, Image.GetPixel((int)intrpoint.X, (int)intrpoint.Y));
                    
                }
            }
            Image = newimg;
        }

        public float Intrapolate(float u, float u1, float u2, float w1, float w2)
        {
            if (u1 - u2 == 0) return w1;
            return (u - u1) * (w2 - w1) / (u2 - u1) + w1;
        }
        public float IntrapolateNewPoint(float u, float u1, float u2, float w1, float w2)
        {
            //if (w2 - w1 == 0) return u1;
            return (u - w1) * (u2 - u1) / (w2 - w1) + u1;
        }


        // change speed



        // zoom function
        // zoom and move image so that it zooms in on cursor location if image size is bigger than screen height or width
        public void zoom_image(MouseEventArgs e)
        {
            //if (isGIF) timer1.Stop();
            double oldzoom = zoom;
            zoom = e.Delta < 0 ? zoom / zoom_step : zoom * zoom_step;
            if (zoom > max_zoom || zoom < min_zoom)
            {
                zoom = oldzoom;
                return;
            }

            //double new_width = (e.Delta < 0 ? disp_rec.Width / zoom_step : disp_rec.Width * zoom_step);
            //double new_height = e.Delta < 0 ? disp_rec.Height / zoom_step : disp_rec.Height * zoom_step;
            double new_height = Image.Height * zoom / 100;
            double new_width = Image.Width * zoom / 100;

            double width_delta = disp_rec.Width - new_width; // - disp_rec.Width;
            double height_delta = disp_rec.Height - new_height; // - disp_rec.Height;

            int mouse_rx = e.X - disp_rec.X;
            int mouse_ry = e.Y - disp_rec.Y;

            /* https://stackoverflow.com/questions/16349798/reposition-rectangle-after-zooming
            Width delta is the new width minus the old width.
            Height delta is the new height minus the old height.
            Mouse x relative is the x-coordinate relative to the rect's left side
            Mouse y relative is the y-coordinate relative to the rect's top side 
             */

            int x_delta = (int)(width_delta * mouse_rx / disp_rec.Width);
            int y_delta = (int)(height_delta * mouse_ry / disp_rec.Height);

            disp_rec.Height = (int)new_height;
            disp_rec.Width = (int)new_width;
            move(x_delta, y_delta);
            //zoom = zoom_constrain((double)disp_rec.Height * 100.0 / (double)Image.Height);

            //center_image();


            //if (isGIF) timer1.Start();

        }



        // move function
        // image only moves in dimension were image size is bigger than screen
        public void move(int dx, int dy)
        {
            if (disp_rec.Width > canvas.Width) disp_rec.X += dx;
            else disp_rec.X = ((canvas.Width - disp_rec.Width) / 2);

            if (disp_rec.Height > canvas.Height) disp_rec.Y += dy;
            else disp_rec.Y = ((canvas.Height - disp_rec.Height) / 2);
            /*
            if (disp_rec.X + dx < 0 || disp_rec.Right + dx > canvas.Width)
            {
                if (dx < 0) disp_rec.X = 0;
                else disp_rec.X = canvas.Width - disp_rec.Width;
            }
            else
            {
                disp_rec.X += dx;
            }
            if(disp_rec.Y + dy < 0 || disp_rec.Bottom + dy > canvas.Height)
            {
                if (dy < 0) disp_rec.Y = 0;
                else disp_rec.Y = canvas.Height - disp_rec.Height;
            }
            else
            {
                disp_rec.Y += dy;
            }
            */
        }


        // rezise function resize and center
        public void rezise_reset()
        {
            if (Image == null) return;

            zoom_to_fit();
            center_image();
        }

        private void zoom_to_fit()
        {
            if (Image.Width > Image.Height)
            {
                zoom = zoom_constrain((double)canvas.Width * 100.0 / (double)Image.Width);
                disp_rec.Width = (int)(Image.Width * zoom / 100);
                disp_rec.Height = (int)(Image.Height * zoom / 100);
                if (disp_rec.Height > canvas.Height)
                {
                    zoom = zoom_constrain((double)canvas.Height * 100.0 / (double)Image.Height);
                    disp_rec.Width = (int)(Image.Width * zoom / 100);
                    disp_rec.Height = (int)(Image.Height * zoom / 100);
                }
            }
            else
            {
                zoom = zoom_constrain((double)canvas.Height * 100.0 / (double)Image.Height);
                disp_rec.Width = (int)(Image.Width * zoom / 100);
                disp_rec.Height = (int)(Image.Height * zoom / 100);
                if (disp_rec.Width > canvas.Width)
                {
                    zoom = zoom_constrain((double)canvas.Width * 100.0 / (double)Image.Width);
                    disp_rec.Width = (int)(Image.Width * zoom / 100);
                    disp_rec.Height = (int)(Image.Height * zoom / 100);
                }
            }
            //return zoom;
        }


        private double zoom_constrain(double val)
        {
            if (val < min_zoom) return min_zoom;
            if (val > max_zoom) return max_zoom;
            return val;
        }

        public double get_zoom() { return zoom; }


        public void center_image()
        {
            if (Image == null) return;
            disp_rec.X = ((canvas.Width - disp_rec.Width) / 2);
            disp_rec.Y = ((canvas.Height - disp_rec.Height) / 2);
        }

        private Size rezise_to(Size s)
        {
            return disp_rec.Size = s;
        }

        // returns size  of image to be drawn on screen in pixels
        public Size draw_size()
        {
            return disp_rec.Size;
        }

        //private void change_canvas_size(Size new_size)
        //{
        //    this.canvas_size = new_size;
        //}




    }
}
