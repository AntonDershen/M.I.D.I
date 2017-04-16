using BussinessLogic.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interface.Services
{
    public interface IConvertService
    {
        IEnumerable<NoteEntity> GetNotes();
    }
}
