using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing;

namespace ImageViewer2
{
    class DeformationManager
    {
        private PointF[,] std_grid;

        private PointF[,] corr_grid;

        private int x_lines_num;
        private int y_lines_num;
        private int image_width;
        private int image_height;

        public DeformationManager(int width, int height, int x_lanes, int y_lanes)
        {
            image_height = height;
            image_width  = width;
            x_lines_num = x_lanes;
            y_lines_num = y_lanes;
            SetUpGrids();


        }
        public void SetUpGrids()
        {
            float x_step = image_width / (float)(y_lines_num+1);
            float y_step = image_height / (float)(x_lines_num+1);

            std_grid = new PointF[x_lines_num+2, y_lines_num+2];
            corr_grid = new PointF[x_lines_num+2, y_lines_num+2];

            for(int i = 0; i<=x_lines_num+1; i++)
            {
                float x = (x_step * i);
                for(int z = 0; z<=y_lines_num+1; z++)
                {
                    float y = (y_step * z);
                    std_grid[i, z]  = new PointF(x, y);
                    corr_grid[i, z] = new PointF(x, y);
                }


            }
        }

        public PointF[,] GetStandartGrid()
        {
            return std_grid;
        }
        public PointF[,] GetCorrectioGrid()
        {
            return corr_grid;
        }

        public void Paint(PaintEventArgs e, Rectangle rec)
        {
            Pen std_brush = new Pen(Color.Blue);
            Pen corr_brush = new Pen(Color.Red);
            PointF[,] trs_std_grid = new PointF[x_lines_num + 2, y_lines_num + 2];
            PointF[,] trs_corr_grid = new PointF[x_lines_num + 2, y_lines_num + 2];
            TransformGrids(ref trs_std_grid, ref trs_corr_grid, rec);


            for (int i = 0; i <= x_lines_num+1; i++)
            {
                for (int z = 0; z <= y_lines_num+1; z++)
                {
                    if(i< x_lines_num+1)
                    {
                        e.Graphics.DrawLine(std_brush, trs_std_grid[i, z], trs_std_grid[i + 1, z]);
                        e.Graphics.DrawLine(corr_brush, trs_corr_grid[i, z], trs_corr_grid[i + 1, z]);
                    }
                    if(z< y_lines_num+1)
                    {
                        e.Graphics.DrawLine(std_brush, trs_std_grid[i, z], trs_std_grid[i, z + 1]);
                        e.Graphics.DrawLine(corr_brush, trs_corr_grid[i, z], trs_corr_grid[i, z + 1]);

                    }
                }
            }
        }

        private void TransformGrids(ref PointF[,] trs_std_grid, ref PointF[,] trs_corr_grid, Rectangle rec)
        {
            float x_factor = image_width / (float)rec.Width;
            float y_factor = image_height / (float)rec.Height;
            for (int i = 0; i <= x_lines_num+1; i++)
            {
                for (int z = 0; z <= y_lines_num+1; z++)
                {
                    trs_std_grid[i, z] = new PointF(std_grid[i, z].X / x_factor + rec.X, std_grid[i, z].Y / y_factor + rec.Y);
                    trs_corr_grid[i, z] = new PointF(corr_grid[i, z].X / x_factor + rec.X, corr_grid[i, z].Y / y_factor + rec.Y);
                }


            }
        }

        public void ChangeStdPoint(PointF point, int row_idx, int col_idx)
        {
            std_grid[col_idx, row_idx] = point;
        }
        public void ChangeCorrPoint(PointF point, int row_idx, int col_idx)
        {
            corr_grid[col_idx, row_idx] = point;
        }

    }
}
