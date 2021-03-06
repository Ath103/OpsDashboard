﻿using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuGetDashboard.Utilities
{
    /// <summary>
    /// Helper methods to get various chart objects - pie chart, bar chart and line chart for the given data.
    /// </summary>
    public class ChartingUtilities
    {
        public static DotNet.Highcharts.Highcharts GetBarChart(List<string> xValues, List<Object> yValues, string YAxisTitle, string chartTitle)
        {

            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts(chartTitle)
            .InitChart(new DotNet.Highcharts.Options.Chart { DefaultSeriesType = ChartTypes.Column })
            .SetPlotOptions(new PlotOptions
            {
                Column = new PlotOptionsColumn
                {
                    Stacking = Stackings.Normal,
                }
            });

            chart.SetXAxis(new XAxis
            {
                Categories = xValues.ToArray(),

            });
            chart.SetSeries(new DotNet.Highcharts.Options.Series
            {
                Data = new Data(yValues.ToArray()),
                Name = YAxisTitle
            });

            chart.SetTitle(new DotNet.Highcharts.Options.Title { Text = chartTitle });
            return chart;
        }

        public static DotNet.Highcharts.Highcharts GetLineChart(List<DotNet.Highcharts.Options.Series> seriesSet, List<string> xValues, string title)
        {
            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts(title);
            chart.InitChart(new Chart
            {
                Height = 200,
                Width = 200
            });

            chart.SetXAxis(new XAxis
            {
                Categories = xValues.ToArray()

            });
            chart.SetSeries(seriesSet.ToArray());
            chart.SetTitle(new DotNet.Highcharts.Options.Title { Text = title });
            return chart;
        }
    }
}