using BussinessLogic.Interface.Entities;
using System.Collections.Generic;

namespace BussinessLogic.Interface.Services
{
    public interface IConvertService
    {
        IEnumerable<NoteEntity> GetNotes();
    }
}
