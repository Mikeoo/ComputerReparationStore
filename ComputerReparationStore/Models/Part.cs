using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerReparationStore.Models
{
    public class Part : ListAllParts
    {
        public bool InStock { get; set; }
    }
}