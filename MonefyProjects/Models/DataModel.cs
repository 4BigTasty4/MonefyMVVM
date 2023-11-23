using GalaSoft.MvvmLight.Command;
using System;

namespace MonefyProjects.Models
{
    internal class DataModel : IData
    {
        public string Cotegorie { get; set; }
        public string Note { get; set; }
        public string Color { get; set; }
        public DateTime TimeCreate { get; set; }
        public bool Income { get; set; }
        public string IncomeColor
        {
            get
            {
                if (Income)
                {
                    return "Green";
                }
                return "Red";
            }
        }
        public double Money { get; set; }

        public static implicit operator DataModel(RelayCommand<string> v)
        {
            throw new NotImplementedException();
        }
    }
}
