using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.EntityFramework
{
    public class MusicModel
    {
        public int MusicModelId { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public byte[] ConvertedContent { get; set; }
    }
}
