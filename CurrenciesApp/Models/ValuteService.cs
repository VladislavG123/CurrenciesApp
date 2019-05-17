using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrenciesApp.Models
{
    public class ValuteService
    {
        public string Title { get; set; }
        public double? Description { get; set; }
        public double? Change { get; set; }
        public MaterialDesignThemes.Wpf.PackIconKind? Index { get; set; }
    }
}
