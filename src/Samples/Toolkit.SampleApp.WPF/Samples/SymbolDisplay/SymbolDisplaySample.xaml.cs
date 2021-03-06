﻿using Esri.ArcGISRuntime.Symbology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Esri.ArcGISRuntime.Toolkit.Samples.SymbolDisplay
{
    /// <summary>
    /// Interaction logic for SymbolDisplaySample.xaml
    /// </summary>
    public partial class SymbolDisplaySample : UserControl
    {
        public SymbolDisplaySample()
        {
            InitializeComponent();
            DataContext = this;
        }

        public List<SimpleMarkerSymbolStyle> SimpleMarkerSymbolStyles { get; } = Enum.GetValues(typeof(SimpleMarkerSymbolStyle)).OfType<SimpleMarkerSymbolStyle>().ToList();

        public SimpleMarkerSymbol Symbol { get; } = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.Square, Colors.Red, 20) { Outline = new SimpleLineSymbol(SimpleLineSymbolStyle.Solid, Colors.Black, 2) };
    }
}
