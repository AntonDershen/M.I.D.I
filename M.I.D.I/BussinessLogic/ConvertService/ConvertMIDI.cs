using BussinessLogic.Interface.Converters;
using System.Threading.Tasks;
using BussinessLogic.Interface.Entities;
using BussinessLogic.Interface.Services;
using DataAccess.Interface.Repositories;
using System;
using System.Collections.Generic;

namespace BussinessLogic.ConvertService
{
    public class ConvertMIDI : IConvertService
    {
        IEnumerable<NoteEntity> Notes { get; set; }
        public byte[] Data { get; private set; }
        
        public ConvertMIDI(byte[] data)
        {
            this.Data = data;
        }
        public IEnumerable<NoteEntity> GetNotes()
        {
            return Notes;
        }
    }

}