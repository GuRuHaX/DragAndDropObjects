using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfCursus
{
    public class OfficePrograms
    {
        public string Name { get; set; }
        public BitmapImage Symbol { get; set; }

        public OfficePrograms(string name, BitmapImage symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
