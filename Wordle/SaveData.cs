using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Wordle
{
    //class to store information
    internal class SaveData
    {
        public string CopyNameLogin { get; set; }
        public string RandomWord { get; set; }
        public List<List<string>> LabelsText { get; set; }
        public int CurrentRow { get; set; }
        public int CurrentColumn { get; set; }
        public string WordPlayer { get; set; }
    }
}
