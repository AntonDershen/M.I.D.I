using BussinessLogic.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Interface.Entities;


namespace BussinessLogic.ConvertService
{
    public class ConvertWav : IConvertService
    {
        public IEnumerable<NoteEntity> GetNotes()
        {
            List<byte> data = new List<byte>();
            WaveFile waveFile = new WaveFile("e:\\march.wav");
            waveFile.Read();
            return null;
        }
    }
}
