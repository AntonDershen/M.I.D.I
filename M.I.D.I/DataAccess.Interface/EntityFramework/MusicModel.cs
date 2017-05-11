using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.EntityFramework
{
    public class MusicModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MusicModelId { get; set; }
        public string Name { get; set; }
        public string NewPath { get; set; }
        public string Extension { get; set; }
        public DateTime Date { get; set; }
    }

    public class AlbumModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumModelId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public virtual IEnumerable<MusicModel> MusicModels { get; set; }
    }
}
