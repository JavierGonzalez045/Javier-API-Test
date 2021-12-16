using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Javier_API_Test.Models
{
    public class ToDo
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime MnfDate { get; set; }
        public enum Status { Pending, Completed, Cancel };
        public Guid Id { get; set;}
    }
}
