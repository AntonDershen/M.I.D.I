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
        public string NewPath { get; set; }
        public string Extension { get; set; }
        public DateTime Date { get; set; }
    }

    public class NoteEntity
    {
        public int NoteEntityId { get; set; }
        public double RealTime;
        public int NoteNumber;
        public int Channel;
        public int CommandCode;
    }

    public class AlbumEntity
    {
        public int AlbumEntityId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<MusicEntity> MusicEntities { get; set; }
    }
}
