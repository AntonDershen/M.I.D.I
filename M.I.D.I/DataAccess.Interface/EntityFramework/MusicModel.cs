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
        public string Extension { get; set; }
        public DateTime Date { get; set; }
        public byte[] Content { get; set; }
        public virtual ConvertedMusicModel ConvertedMusicModel { get; set; }
    }

    public class ConvertedMusicModel
    {
        public int ConvertedMusicModelId { get; set; }
        public DateTime ConvertedDate { get; set; }
        public virtual IEnumerable<NoteModel> Notes { get; set; }
    }

    public class NoteModel
    {
        public int NoteModelId { get; set; }
        public double RealTime { get; set; }
        public int NoteNumber { get; set; }
        public int Channel { get; set; }
        public int CommandCode { get; set; }
    }

    public class AlbumModel
    {
        public int AlbumModelId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public virtual IEnumerable<MusicModel> MusicModels { get; set; }
    }
}
