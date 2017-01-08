using BussinessLogic.Interface.Converters;
using System.Threading.Tasks;
using BussinessLogic.Interface.Entities;
using BussinessLogic.Interface.Services;
using DataAccess.Interface.Repositories;
using System;
using System.Collections.Generic;

namespace BussinessLogic.Services
{
    public class ConvertMIDI
    {
        public byte[] ConvertedData { get; private set; }
        public byte[] Data { get; private set; }
        
        public ConvertMIDI(byte[] data)
        {
            this.Data = data;
            ConvertData();
        }
        private void ConvertData()
        {
            List<byte> result = new List<byte>();
            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i] == 144)
                {
                    result.Add(Data[i + 1]);
                }
            }
            this.ConvertedData = result.ToArray();
        }
    }

}