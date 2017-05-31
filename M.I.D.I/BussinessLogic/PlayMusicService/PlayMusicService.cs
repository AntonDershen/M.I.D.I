using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using BussinessLogic.ConvertService;
using BussinessLogic.Interface.Converters;
using BussinessLogic.Interface.Entities;
using BussinessLogic.Interface.Services;
using DataAccess.Interface.Repositories;
using NAudio.Midi;

namespace BussinessLogic.PlayMusicService
{
    public class PlayMusicService : IPlayMusicService, IDisposable
    {
        private Timer musicTimer;
        private List<NoteEntity> notes;
        private int CurrentNote = 0;
        private double CurrentTime = 0.0;
        private bool IsPlaying = false;
        private readonly IUnitOfWork unitOfWork;
        private double freeqency = 200;
        private MidiOut midiOut;

        public PlayMusicService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            musicTimer = new Timer(freeqency);
            musicTimer.Elapsed += (sender, e) => HandleTimer();
            midiOut = new MidiOut(0);
        }

        public void Play()
        {
            if (notes == null)
            {
                return;
            }
            musicTimer.Start();
        }

        public void Stop()
        {
            if (notes == null)
            {
                return;
            }
            musicTimer.Stop();
        }

        public void SetComposition(int compositionID)
        {
            musicTimer.Stop();
            var musicModel = unitOfWork.MusicRepository.Find(compositionID).ToMusicEntity();
            ConvertMIDI convertMidi = new ConvertMIDI(musicModel.NewPath);
            notes = convertMidi.GetNotes().ToList();
            ClearPlayer();
            musicTimer.Start();
        }

        private void ClearPlayer()
        {
            CurrentNote = 0;
            CurrentTime = 0.0;
        }

        private void HandleTimer()
        {
            CurrentTime += (freeqency/1000);
            if(CurrentNote < notes.Count)
            {
                while (notes[CurrentNote].RealTime <= CurrentTime)
                {
                    //PlayNote
                    NoteEntity entity = notes[CurrentNote];
                    MidiMessage message;
                    if (entity.CommandCode == (int)MidiCommandCode.NoteOn)
                    {
                        message = MidiMessage.StartNote(entity.NoteNumber,100,entity.Channel);
                    }
                    else
                    {
                        message = MidiMessage.StopNote(entity.NoteNumber, 100, entity.Channel);
                    }
                    midiOut.Send(message.RawData);
                    CurrentNote++;
                    if (CurrentNote >= notes.Count)
                    {
                        return;
                    }
                }
            }
            else
            {
                musicTimer.Stop();
                IsPlaying = false;
            }
        }

        public void Dispose()
        {
            midiOut.Dispose();
        }
    }
}
