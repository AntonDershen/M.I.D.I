using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interface.Entities
{
    public class MusicEntity
    {
        public int MusicEntityId { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public byte[] ConvertedContent { get; set; }
    }
}
