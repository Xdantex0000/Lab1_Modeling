using System;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;

namespace Generator
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            const int generatorSize = 100;

            #region FirstPunct

            double lamda1;
            const double lamda2 = 3;
            

            var rand = new Random();
            var maxEx = 0.0;
            var generatedNums1 = new List<double>();
            var x11 = new List<double>();
            var x12 = new List<double>();
            var pi1 = new List<double>();
            var Fx11 = new List<double>();
            var Fx12 = new List<double>();

            var histogramData = new int[10];
            var teorProbability = new double[10];

            for (var i = 0; i < generatorSize; i++) generatedNums1.Add(rand.NextDouble());

            double mu = 0.0;
            foreach (var x in generatedNums1)
            {
                mu += x;
            }
            
            mu /= generatorSize;
            avg1 = $" Average: {mu}";
            disp1 = $" Dispersion: {Math.Pow(mu, 2.0)}";
            lamda1 = 1 / mu;
            
            foreach (var x in generatedNums1)
            {
                x11.Add(-Math.Log2(x) / lamda1);
                x12.Add(-Math.Log2(x) / lamda2);
            }


            foreach (var num in x11)
            {
                if (maxEx < num) maxEx = num;
                Fx11.Add(1 - Math.Pow(Math.E, -lamda1 * num));
            }

            foreach (var num in x12) Fx12.Add(1 - Math.Pow(Math.E, -lamda2 * num));

            foreach (var x in x11)
            {
                if (x >= 0 && x < maxEx / 10) histogramData[0]++;
                if (x >= maxEx / 10 && x < 2 * maxEx / 10) histogramData[1]++;
                if (x >= 2 * maxEx / 10 && x < 3 * maxEx / 10) histogramData[2]++;
                if (x >= 3 * maxEx / 10 && x < 4 * maxEx / 10) histogramData[3]++;
                if (x >= 4 * maxEx / 10 && x < 5 * maxEx / 10) histogramData[4]++;
                if (x >= 5 * maxEx / 10 && x < 6 * maxEx / 10) histogramData[5]++;
                if (x >= 6 * maxEx / 10 && x < 7 * maxEx / 10) histogramData[6]++;
                if (x >= 7 * maxEx / 10 && x < 8 * maxEx / 10) histogramData[7]++;
                if (x >= 8 * maxEx / 10 && x < 9 * maxEx / 10) histogramData[8]++;
                if (x >= 9 * maxEx / 10 && x < 10 * maxEx / 10) histogramData[9]++;
            }

            var hikv = 0.0;

            for (var i = 0; i < 10; i++)
            {
                var x = (Math.Exp(-lamda1 * i * maxEx / 10 - Math.Exp(-lamda1* i+1 * maxEx / 10)));
                pi1.Add(x);
            }

            for (var i = 0; i < pi1.Count; i++)
                hikv += Math.Pow(histogramData[i] - pi1[i] * generatorSize,2.0) / generatorSize * pi1[i];

            hi1 = $" Hi^2: {hikv}";

            #endregion

            #region SecondPunct

            double sigma1 = 2;
            const double a1 = 3;
            const double sigma2 = 4;
            const double a2 = 5;

            double sum;
            var rand2 = new Random();
            var maxNorm = 0.0;
            var generatedList2 = new List<double>();
            var muList = new List<double>();
            var normalXList1 = new List<double>();
            var normalXList2 = new List<double>();
            var normalYList1 = new List<double>();
            var normalYList2 = new List<double>();
            var pi2 = new List<double>();

            var histogramData2 = new int[10];

            double mu2 = 0.0;
            double sigma = 0.0;
            for (var i = 0; i < generatorSize; i++)
            {
                sum = 0;
                var randomed = rand2.NextDouble();
                generatedList2.Add(randomed);
                for (var j = 0; j < 12; j++) sum += rand2.NextDouble();
                muList.Add(sum - 6);
            }

            foreach (var x in generatedList2)
            {
                mu2 += x;
            }
            
            mu2 /= generatorSize;

            foreach (var x in generatedList2)
            {
                sigma += Math.Pow(x - mu2,2.0);
            }

            sigma /= (generatorSize-1);
            
            
            avg2 = $" Average: {mu2}";
            disp2 = $" Dispersion: {sigma}";
            

            foreach (var x in muList) normalXList1.Add(sigma1 * x + a1);

            foreach (var x in muList) normalXList2.Add(sigma2 * x + a2);

            foreach (var x in normalXList1)
            {
                normalYList1.Add(Math.Exp(-(x - a1)) / (2 * Math.Pow(sigma1, 2.0)) / (sigma1 * Math.Sqrt(2 * Math.PI)));
                if (maxNorm < x) maxNorm = x;
            }

            foreach (var x in normalXList2)
                normalYList2.Add(Math.Exp(-(x - a2)) / (2 * Math.Pow(sigma2, 2.0)) / (sigma2 * Math.Sqrt(2 * Math.PI)));

            foreach (var x in normalXList1)
            {
                if (x >= 0 && x < maxNorm / 10) histogramData2[0]++;
                if (x >= maxNorm / 10 && x < 2 * maxNorm / 10) histogramData2[1]++;
                if (x >= 2 * maxNorm / 10 && x < 3 * maxNorm / 10) histogramData2[2]++;
                if (x >= 3 * maxNorm / 10 && x < 4 * maxNorm / 10) histogramData2[3]++;
                if (x >= 4 * maxNorm / 10 && x < 5 * maxNorm / 10) histogramData2[4]++;
                if (x >= 5 * maxNorm / 10 && x < 6 * maxNorm / 10) histogramData2[5]++;
                if (x >= 6 * maxNorm / 10 && x < 7 * maxNorm / 10) histogramData2[6]++;
                if (x >= 7 * maxNorm / 10 && x < 8 * maxNorm / 10) histogramData2[7]++;
                if (x >= 8 * maxNorm / 10 && x < 9 * maxNorm / 10) histogramData2[8]++;
                if (x >= 9 * maxNorm / 10 && x < 10 * maxNorm / 10) histogramData2[9]++;
            }

            var hikv2 = 0.0;

            for (var i = 0; i < 10; i++)
            {
                var x = Math.Pow(a1,i)/factorial_Recursion(i)*Math.Exp(-a1);
                pi2.Add(x);
            }

            for (var i = 0; i < pi1.Count; i++)
                hikv2 += Math.Pow(histogramData2[i] - pi2[i] * generatorSize,2.0) / generatorSize * pi2[i];

            hi2 = $" Hi^2: {hikv2}";
            
            #endregion

            #region ThirdPunct

            var a = Math.Pow(5, 13);
            var c = Math.Pow(2, 31);
            var max = 0.0;
            var rand3 = new Random().NextDouble();
            var z = new List<double>();
            var x1 = new List<double>();
            
            avg3 = $" Average: {rand3}";
            disp3 = $" Dispersion: {Math.Pow(rand3,2.0)}";
            
            var histogramData3 = new int[10];

            for (var i = 0; i < generatorSize; i++)
                if (i == 0)
                    z.Add(a * rand3 % c);
                else
                    z.Add(a * z[i - 1] % c);

            foreach (var y in z)
            {
                var temp = y / c;
                if (max < temp) max = temp;
                x1.Add(temp);
            }

            foreach (var x in x1)
            {
                if (x >= 0 && x < max / 10) histogramData3[0]++;
                if (x >= max / 10 && x < 2 * max / 10) histogramData3[1]++;
                if (x >= 2 * max / 10 && x < 3 * max / 10) histogramData3[2]++;
                if (x >= 3 * max / 10 && x < 4 * max / 10) histogramData3[3]++;
                if (x >= 4 * max / 10 && x < 5 * max / 10) histogramData3[4]++;
                if (x >= 5 * max / 10 && x < 6 * max / 10) histogramData3[5]++;
                if (x >= 6 * max / 10 && x < 7 * max / 10) histogramData3[6]++;
                if (x >= 7 * max / 10 && x < 8 * max / 10) histogramData3[7]++;
                if (x >= 8 * max / 10 && x < 9 * max / 10) histogramData3[8]++;
                if (x >= 9 * max / 10 && x < 10 * max / 10) histogramData3[9]++;
            }

            var hikv3 = 0.0;
            for (var i = 0; i < 10; i++)
            {
                var chisl = Math.Pow(histogramData3[i] - 0.1 * generatorSize, 2);
                var znam = 0.1 * generatorSize;
                hikv3 += chisl / znam;
            }

            hi3 = $" Hi^2: {hikv3}";

            #endregion

            #region Graph

            Title_ex1 = "Expotential (lamda = 2)";
            Title_ex2 = "Expotential (lamda = 3)";
            Title_ex3 = "Normal (sigma = 2, a = 3)";
            Title_ex4 = "Normal (sigma = 4, a = 5)";
            Histogram1_title = "Histogram for expotential distribution law";
            Histogram2_title = "Histogram for normal distribution law";
            Histogram3_title = "Histogram for uniform distribution law";

            #region Expot

            for (var i = 0; i < x11.Count; i++) Points1.Add(new DataPoint(x11[i], Fx11[i]));
            for (var i = 0; i < x12.Count; i++) Points2.Add(new DataPoint(x12[i], Fx12[i]));

            #region Histogram

            for (var i = 0; i < histogramData.Length; i++)
                Items1.Add(new ColumnItem {Value = histogramData[i], CategoryIndex = i});

            #endregion

            #endregion

            #region Normal

            for (var i = 0; i < normalXList1.Count; i++) Points3.Add(new DataPoint(normalXList1[i], normalYList1[i]));
            for (var i = 0; i < normalXList2.Count; i++) Points4.Add(new DataPoint(normalXList2[i], normalYList2[i]));

            #region Histogram

            for (var i = 0; i < histogramData2.Length; i++)
                Items2.Add(new ColumnItem {Value = histogramData2[i], CategoryIndex = i});

            #endregion

            #endregion

            #region Third

            for (var i = 0; i < histogramData3.Length; i++)
                Items3.Add(new ColumnItem {Value = histogramData3[i], CategoryIndex = i});

            #endregion

            #endregion
        }

        public string Title_ex1 { get; }
        public string hi1 { get; }
        public string hi2 { get; }
        public string hi3 { get; }
        public string avg1 { get; }
        public string avg2 { get; }
        public string avg3 { get; }
        public string disp1 { get; }
        public string disp2 { get; }
        public string disp3 { get; }
        public string Title_ex2 { get; }
        public string Title_ex3 { get; }
        public string Title_ex4 { get; }
        public string Histogram1_title { get; }
        public string Histogram2_title { get; }
        public string Histogram3_title { get; }
        public IList<DataPoint> Points1 { get; } = new List<DataPoint>();
        public IList<DataPoint> Points2 { get; } = new List<DataPoint>();
        public IList<DataPoint> Points3 { get; } = new List<DataPoint>();
        public IList<DataPoint> Points4 { get; } = new List<DataPoint>();
        public IList<ColumnItem> Items1 { get; } = new List<ColumnItem>();
        public IList<ColumnItem> Items2 { get; } = new List<ColumnItem>();
        public IList<ColumnItem> Items3 { get; } = new List<ColumnItem>();

        public double factorial_Recursion(int number)
        {
            if (number == 1 || number == 0)
                return 1;
            return number * factorial_Recursion(number - 1);
        }
    }

    public class Item
    {
        public string Label { get; set; }
        public double Value { get; set; }
    }
}