using MonefyProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonefyProjects.Messages
{
    internal class SpendingMessage : ValueMessage, IData
    {
        public string Categorie { get; set; }
        public SpendingMessage(double value, string operation, string categorie) : base(value, operation)
        {
            Categorie = categorie;
        }
    }
}
