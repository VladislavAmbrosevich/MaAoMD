using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public partial class MainWIndow : Form
    {
        private List<Area> _savedAreas;
        private List<Point> _savedPoints;


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
            DrawAreaPictureBox.Refresh();
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


        private void MaximinButton_Click(object sender, EventArgs e)
        {
            DrawAreaPictureBox.Refresh();
            CalculateMaximin();
        }


        private void CalculateMaximin()
        {
            DrawAreaPictureBox.Refresh();
            var area = new Area();
            var rand = new Random();
            var graph = Graphics.FromHwnd(DrawAreaPictureBox.Handle);
            var areas = new List<Area>();
            if (!int.TryParse(PointsCountTextBox.Text, out var ptsCount))
            {
                MessageBox.Show(@"Please, enter correct count of points", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            Area.AddPoints(ptsCount);
            var index = rand.Next(0, ptsCount - 1);
            area.SetCore(Area.GetPoint(index));
            area.SetColor(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            areas.Add(area);
            SetAreas(areas, ptsCount);
            areas[0].GetMax(ref Area.NewCore);
            area = new Area();
            area.SetCore(Area.NewCore);
            area.SetColor(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            areas.Add(area);
            var above = true;
            while (above)
            {
                foreach (var ar in areas)
                {
                    ar.AreaClear();
                }
                SetAreas(areas, ptsCount);
                foreach (var ar in areas)
                {
                    ar.Draw(graph);
                }
                double max = 0;
                var p = new Point();
                foreach (var ar in areas)
                {
                    if (ar.GetMax(ref p) > max)
                    {
                        max = ar.GetMax(ref Area.NewCore);
                    }
                }
                var count = 0;
                double range = 0;
                for (var i = 0; i < areas.Count - 1; i++)
                {
                    for (var j = i + 1; j < areas.Count; j++)
                    {
                        range += Math.Sqrt(Math.Pow(areas[i].Core.X - areas[j].Core.X, 2) + Math.Pow(areas[i].Core.Y - areas[j].Core.Y, 2));
                        count++;
                    }
                }
                range /= count;
                if (max > range / 2)
                {
                    area = new Area();
                    area.SetCore(Area.NewCore);
                    area.SetColor(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                    areas.Add(area);
                }
                else
                {
                    above = false;
                }
            }
            _savedAreas = areas;
            _savedPoints= Area.GetPts();
        }
    }
}