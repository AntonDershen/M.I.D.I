using BussinessLogic.Interface.Converters;
using System.Threading.Tasks;
using BussinessLogic.Interface.Entities;
using BussinessLogic.Interface.Services;
using DataAccess.Interface.Repositories;
using System;
using System.Collections.Generic;
using NAudio.Midi;
using System.IO;
using System.Linq;

namespace BussinessLogic.ConvertService
{
    public class ConvertMIDI : IConvertService
    {
        private List<TempoEvent> tempoEvents;
        private MidiFile midiFile;
        private long ticksPerQuarter;
        private List<NoteEvent> absoluteNotes;
        IEnumerable<NoteEntity> Notes { get; set; }

        public byte[] Data { get; private set; }
        
        public ConvertMIDI(string Path, bool strictCheck = true)
        {
            if (!File.Exists(Path))
                throw new FileNotFoundException(String.Format("Midi file not found at {0}!", Path));

            try
            {
                midiFile = new MidiFile(Path, strictCheck);
            }
            catch (FormatException formatEx)
            {
                throw formatEx;
            }

            ticksPerQuarter = midiFile.DeltaTicksPerQuarterNote;
            BuildTempoList();
            BuildAbsoluteNotes();
        }

        public IEnumerable<NoteEntity> GetNotes()
        {
            int counter = 0;
            double currentRealTime = 0.0;
            double lastRealTime = 0.0;
            List<NoteEntity> output = new List<NoteEntity>(absoluteNotes.Count);
            foreach (var absoluteNote in absoluteNotes)
            {
                counter++;
                currentRealTime = GetRealtime(absoluteNote.AbsoluteTime);
                output.Add(new NoteEntity()
                {
                    RealTime = currentRealTime,
                    NoteNumber = absoluteNote.NoteNumber,
                    Channel = absoluteNote.Channel,
                    CommandCode = (int)absoluteNote.CommandCode
                });
                lastRealTime = currentRealTime;
            }
            return output;
        }

        private void BuildAbsoluteNotes()
        {
            absoluteNotes = new List<NoteEvent>();
            foreach (var CollectionEvent in midiFile.Events)
            {
                foreach (var Event in CollectionEvent)
                {
                    if (Event.CommandCode == MidiCommandCode.NoteOn)
                    {
                        absoluteNotes.Add((NoteEvent)Event);
                    }
                    if (Event.CommandCode == MidiCommandCode.NoteOff)
                    {
                        absoluteNotes.Add((NoteEvent)Event);
                    }
                }
            }
            absoluteNotes = absoluteNotes.OrderBy(x => x.AbsoluteTime).ToList();
        }

        private double GetRealtime(long currentNoteAbsTime)
        {
            var BPM = 120.0;   
            var reldelta = currentNoteAbsTime;   
            var time = 0.0;   
            foreach (var tempo in tempoEvents.Where(tempo => tempo.AbsoluteTime <= currentNoteAbsTime))
            {
                BPM = tempo.BPM;
                time = tempo.RealTime;
                reldelta = currentNoteAbsTime - tempo.AbsoluteTime;
            }
            time += ((double)reldelta / ticksPerQuarter) * (60000.0 / BPM);
            return Math.Round(time / 1000.0, 5);
        }

        private void BuildTempoList()
        {
            var currentbpm = 120.00;
            var realtime = 0.0;
            var reldelta = 0;
            tempoEvents = new List<TempoEvent>();
            foreach (var ev in midiFile.Events[0])
            {
                reldelta += ev.DeltaTime;
                if (ev.CommandCode != MidiCommandCode.MetaEvent)
                {
                    continue;
                }
                var tempo = (MetaEvent)ev;

                if (tempo.MetaEventType != MetaEventType.SetTempo)
                {
                    continue;
                }
                var relativetime = (double)reldelta / ticksPerQuarter * (60000.0 / currentbpm);
                currentbpm = ((NAudio.Midi.TempoEvent)tempo).Tempo;
                realtime += relativetime;
                reldelta = 0;
                var tempo_event = new TempoEvent
                {
                    AbsoluteTime = tempo.AbsoluteTime,
                    RealTime = realtime,
                    BPM = currentbpm
                };
                tempoEvents.Add(tempo_event);
            }
        }

        internal class TempoEvent
        {
            public long AbsoluteTime { get; set; }
            public double RealTime { get; set; }
            public double BPM { get; set; }
        }
    }

}