using BussinessLogic.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Interface.Entities;
using System.IO;

namespace BussinessLogic.ConvertService
{
    public class ConvertMp3 : IConvertService
    {
        public IEnumerable<NoteEntity> GetNotes()
        {
            ConvertWav convertWav = new ConvertWav();
            var notes = convertWav.GetNotes();
            return notes;
        }
    }
}
