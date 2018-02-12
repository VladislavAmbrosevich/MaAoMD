using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public partial class MainWIndow : Form
    {
        private readonly List<Area> _savedAreas;
        private readonly List<Point> _savedPoints;


        public MainWIndow()
        {
            InitializeComponent();

            _savedAreas = new List<Area>();
            _savedPoints = new List<Point>();
        }


        public void SetAreas(List<Area> areas, int pointsCount)
        {
            for (var i = 0; i < pointsCount; i++)
            {
                var p = Area.GetPoint(i);
                var core = areas[0].Core;
                var min = Math.Sqrt(Math.Pow(p.X - core.X, 2) + Math.Pow(p.Y - core.Y, 2));
                var index = 0;
                for (var j = 1; j < areas.Count; j++)
                {
                    core = areas[j].Core;
                    var range = Math.Sqrt(Math.Pow(p.X - core.X, 2) + Math.Pow(p.Y - core.Y, 2));
                    if (range < min)
                    {
                        index = j;
                        min = range;
                    }
                }
                areas[index].AddPointtoArea(p);
            }
        }


        private void AverageKButton_Click(object sender, EventArgs e)
        {
            CalculateKAverage();
        }

        private void CalculateKAverage()
        {
            var graph = Graphics.FromHwnd(DrawAreaPictureBox.Handle);
            var rand = new Random();
            int ptsCount;
            var areas = new List<Area>();
            if (_savedAreas.Count != 0)
            {
                Area.LoadPts(_savedPoints);
                areas = _savedAreas;
                ptsCount = _savedPoints.Count;
            }
            else
            {
                DrawAreaPictureBox.Refresh();
                var index = ClassesCountComboBox.SelectedIndex;
                if (index == -1)
                {
                    index = 0;
                }
                int.TryParse(ClassesCountComboBox.Items[index].ToString(), out var areasCount);
                if (!int.TryParse(PointsCountTextBox.Text, out ptsCount))
                {
                    MessageBox.Show(@"Please, enter correct count of points", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Area.AddPoints(ptsCount);
                for (var i = 0; i < areasCount; i++)
                {
                    var area = new Area();
                    index = rand.Next(0, ptsCount - 1);
                    area.SetCore(Area.GetPoint(index));
                    area.SetColor(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                    areas.Add(area);
                }
            }
            var equal = false;
            while (!equal)
            {
                foreach (var area in areas)
                {
                    area.AreaClear();
                }
                SetAreas(areas, ptsCount);
                areas[0].SetNewCore();
                equal = areas[0].Equal();
                areas[0].AreaClear();
                for (var i = 1; i < areas.Count; i++)
                {
                    areas[i].SetNewCore();
                    equal = equal && areas[i].Equal();
                    areas[i].AreaClear();
                }
            }
            foreach (var area in areas)
            {
                area.AreaClear();
            }
            SetAreas(areas, ptsCount);
            foreach (var area in areas)
            {
                area.Draw(graph);
            }
            _savedAreas.Clear();
            _savedPoints.Clear();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            DrawAreaPictureBox.Refresh();
            Area area = new Area();
            Point p;
            Random rand = new Random();
            Graphics graph = Graphics.FromHwnd(DrawAreaPictureBox.Handle);
            SolidBrush brush = new SolidBrush(Color.Black);
            int areasCount = 0;
            int ptsCount;
            int index;
            List<Area> Areas = new List<Area>();
            if (!int.TryParse(PointsCountTextBox.Text, out ptsCount))
            {
                MessageBox.Show("Введите корректное кол-во точек");
                return;
            }
            Area.AddPoints(ptsCount);
            index = rand.Next(0, ptsCount - 1);
            area.SetCore(Area.GetPoint(index));
            area.SetColor(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            Areas.Add(area);
            areasCount++;
            double max;
            double range;
            max = 0;
            SetAreas(Areas, ptsCount);
            Areas[0].GetMax(ref Area.NewCore);
            area = new Area();
            area.SetCore(Area.NewCore);
            area.SetColor(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            areasCount++;
            Areas.Add(area);
            bool above = true;
            while (above)
            {
                for (int i = 0; i < Areas.Count; i++)
                {
                    Areas[i].AreaClear();
                }
                SetAreas(Areas, ptsCount);
                for (int i = 0; i < Areas.Count; i++)
                {
                    Areas[i].Draw(graph);
                }
                max = 0;
                p = new Point();
                for (int i = 0; i < Areas.Count; i++)
                {
                    if (Areas[i].GetMax(ref p) > max)
                    {
                        max = Areas[i].GetMax(ref Area.NewCore);
                    }
                }
                int count = 0;
                range = 0;
                for (int i = 0; i < Areas.Count - 1; i++)
                {
                    for (int j = i + 1; j < Areas.Count; j++)
                    {
                        range += Math.Sqrt(Math.Pow(Areas[i].Core.X - Areas[j].Core.X, 2) + Math.Pow(Areas[i].Core.Y - Areas[j].Core.Y, 2));
                        count++;
                    }
                }
                range /= count;
                if (max > range / 2)
                {
                    area = new Area();
                    area.SetCore(Area.NewCore);
                    area.SetColor(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                    Areas.Add(area);
                }
                else
                {
                    above = false;
                }
            }
            //SavedAreas = Areas;
            //SavedPts = Area.getPts();
        }
    }
}