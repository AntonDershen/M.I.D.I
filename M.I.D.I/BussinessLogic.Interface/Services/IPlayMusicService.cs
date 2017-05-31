using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interface.Services
{
    public interface IPlayMusicService
    {
        void Play();
        void Stop();
        void SetComposition(int compositionID);
    }
}
