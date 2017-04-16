using BussinessLogic.Interface.Entities;
using DataAccess.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interface.Converters
{
    public static class NoteEntityToNoteModel
    {
        public static NoteModel ToNoteModel(this NoteEntity noteEntity)
        {
            return new NoteModel
            {
               Channel = noteEntity.Channel,
               CommandCode = noteEntity.CommandCode,
               NoteModelId = noteEntity.NoteEntityId,
               RealTime = noteEntity.RealTime,
               NoteNumber = noteEntity.NoteNumber
            };
        }
        public static NoteEntity ToNoteEntity(this NoteModel noteModel)
        {
            return new NoteEntity
            {
                Channel = noteModel.Channel,
                CommandCode = noteModel.CommandCode,
                NoteEntityId = noteModel.NoteModelId,
                RealTime = noteModel.RealTime,
                NoteNumber = noteModel.NoteNumber
            };
        }
    }
}
