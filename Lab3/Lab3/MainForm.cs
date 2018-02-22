using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab3
{
    public partial class MainForm : Form
    {
        private const int N = 40;
        private const double Step = 0.01;
        private const double ComparativePrecision = 0.001;

        private static readonly Color FirstChartColor = Color.Green;
        private static readonly Color SecondChartColor = Color.Red;
        private const SeriesChartType ChartsType = SeriesChartType.Spline;

        private double _falseAlarmProbability;
        private double _missingErrorDetectionProbability;
        private double _totalClassificationErrorProbability;

        private double _probabilityOne;
        private double _probabilityTwo;
        private DataPoint[] _pointsSetOne;
        private DataPoint[] _pointsSetTwo;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GraphicsChart.Series[0].Name = "Graphics of the 1st function";
            GraphicsChart.Series.Add("Graphics of the 2nd function");
            InitializeCharts();
        }

        private void InitializeCharts()
        {
            GraphicsChart.Series[0].Color = FirstChartColor;
            GraphicsChart.Series[1].Color = SecondChartColor;

            GraphicsChart.Series[0].ChartType = GraphicsChart.Series[1].ChartType = ChartsType;
        }

        private void BuildChartButton_Click(object sender, EventArgs e)
        {
            ClearCharts();

            if (!TryGetPrioriProbabilityFromString(InputProbabilityTextBox.Text, out _probabilityOne))
            {
                MessageBox.Show(@"Input error", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            CalculateClassificationErrorsProbabilities();
            BuildGraphicsByPoints();
            OutputCalculatedProbabilities();
        }

        private static bool TryGetPrioriProbabilityFromString(string probabilityValue, out double probability)
        {
            probabilityValue = probabilityValue.Replace(".", ",");

            var parsingResult = double.TryParse(probabilityValue, out probability);
            if (probability < 0)
            {
                return false;
            }

            return parsingResult;
        }

        private void BuildGraphicsByPoints()
        {
            for (var i = 0; i < _pointsSetOne.Length; i++)
            {
                GraphicsChart.Series[0].Points.AddXY(_pointsSetOne[i].XValue, _pointsSetOne[i].YValues[0]);
                GraphicsChart.Series[1].Points.AddXY(_pointsSetTwo[i].XValue, _pointsSetTwo[i].YValues[0]);
            }
        }

        private void OutputCalculatedProbabilities()
        {
            FalseAlarmZoneValueLabel.Text = Math.Round(_falseAlarmProbability, 4).ToString(CultureInfo.InvariantCulture);
            MissingErrorDetectionZoneValueLabel.Text = Math.Round(_missingErrorDetectionProbability, 4).ToString(CultureInfo.InvariantCulture);
            TotalClassificationErrorValueLabel.Text = Math.Round(_totalClassificationErrorProbability, 4).ToString(CultureInfo.InvariantCulture);
        }

        private void ClearCharts()
        {
            GraphicsChart.Series[0].Points.Clear();
            GraphicsChart.Series[1].Points.Clear();
        }

        private void CalculateClassificationErrorsProbabilities()
        {
            _probabilityTwo = 1 - _probabilityOne;

            var random = new Random();

            var pointsAbscissesOne = new int[N];
            var pointsAbscissesTwo = new int[N];

            for (var i = 0; i < N; i++)
            {
                pointsAbscissesOne[i] = random.Next(N - N / 4);
                pointsAbscissesTwo[i] = random.Next(N / 4, N);
            }

            var mathExpectancyOne = CalculateMathExpectancy(pointsAbscissesOne);
            var mathExpectancyTwo = CalculateMathExpectancy(pointsAbscissesTwo);
            var deviationOne = CalculateStandardDeviation(mathExpectancyOne, pointsAbscissesOne);
            var deviationTwo = CalculateStandardDeviation(mathExpectancyTwo, pointsAbscissesTwo);

            const int differenciatedPointsCount = (int)(N / Step);
            double currentDifferentialNumber = 0;
            var firstPointsSetGreaterPointsCount = 0;
            double dencityOne;
            double dencityTwo;
            _pointsSetOne = new DataPoint[differenciatedPointsCount];
            _pointsSetTwo = new DataPoint[differenciatedPointsCount];

            for (var i = 0; i < differenciatedPointsCount; i++)
            {
                currentDifferentialNumber += Step;
                dencityOne = CalculateDensity(currentDifferentialNumber, mathExpectancyOne, deviationOne);
                dencityTwo = CalculateDensity(currentDifferentialNumber, mathExpectancyTwo, deviationTwo);

                _pointsSetOne[i] = new DataPoint(currentDifferentialNumber, dencityOne * _probabilityOne);
                _pointsSetTwo[i] = new DataPoint(currentDifferentialNumber, dencityTwo * _probabilityTwo);

                if (Math.Abs(dencityOne * _probabilityOne - dencityTwo * _probabilityTwo) <= ComparativePrecision)
                {
                    firstPointsSetGreaterPointsCount = i;
                }
            }
            if (firstPointsSetGreaterPointsCount.Equals(0))
            {
                firstPointsSetGreaterPointsCount = differenciatedPointsCount;
            }

            var j = 0;
            _falseAlarmProbability = 0;
            _missingErrorDetectionProbability = 0;
            currentDifferentialNumber = 0;

            dencityTwo = CalculateDensity(currentDifferentialNumber, mathExpectancyTwo, deviationTwo);
            dencityOne = CalculateDensity(currentDifferentialNumber, mathExpectancyOne, deviationOne);
            if (dencityTwo * _probabilityTwo < dencityOne * _probabilityOne)
            {
                while (j++ < firstPointsSetGreaterPointsCount)
                {
                    currentDifferentialNumber += Step;
                    _falseAlarmProbability += CalculateDensity(currentDifferentialNumber, mathExpectancyTwo, deviationTwo) * _probabilityTwo;
                    j++;
                }
                for (j = firstPointsSetGreaterPointsCount; j < differenciatedPointsCount; j++)
                {
                    currentDifferentialNumber += Step;
                    _missingErrorDetectionProbability += CalculateDensity(currentDifferentialNumber, mathExpectancyOne, deviationOne) * _probabilityOne;
                }
            }
            else
            {
                while (j < firstPointsSetGreaterPointsCount)
                {
                    currentDifferentialNumber += Step;
                    _missingErrorDetectionProbability += CalculateDensity(currentDifferentialNumber, mathExpectancyOne, deviationOne) * _probabilityOne;
                    j++;
                }
                for (j = firstPointsSetGreaterPointsCount; j < differenciatedPointsCount; j++)
                {
                    currentDifferentialNumber += Step;
                    _falseAlarmProbability += CalculateDensity(currentDifferentialNumber, mathExpectancyTwo, deviationTwo) * _probabilityTwo;
                }
            }

            _falseAlarmProbability *= Step;
            _missingErrorDetectionProbability *= Step;
            _totalClassificationErrorProbability = _falseAlarmProbability + _missingErrorDetectionProbability;
        }

        private static double CalculateMathExpectancy(IEnumerable<int> pointsAbscisses)
        {
            var mathExpectancy = pointsAbscisses.Aggregate<int, double>(0, (current, x) => current + x) / N;

            return mathExpectancy;
        }

        private static double CalculateStandardDeviation(double m, IEnumerable<int> pointsAbscisses)
        {
            var dispersion = pointsAbscisses.Sum(pointsAbscissa => Math.Pow(pointsAbscissa - m, 2)) / N;
            var deviation = Math.Sqrt(dispersion);

            return deviation;
        }

        private static double CalculateDensity(double point, double mathExpectancy, double dispersion)
        {
            var density = 1 / (dispersion * Math.Sqrt(2 * Math.PI)) * Math.Exp(-0.5 * Math.Pow((point - mathExpectancy) / dispersion, 2));

            return density;
        }
    }
}