using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;

namespace MidiConverter
{
    public class MidiConverter
    {
        private StorageFile file;
        private ulong fileSize;
        private byte[] fileContent;

        public MidiConverter(StorageFile file)
        {
            this.file = file;
        }
        public async Task ConvertToNotes()
        {
            await GetFileSize();
            await GetFileBytes();
            List<byte> result = new List<byte>();
            for (int i = 0; i < fileContent.Length; i++)
            {
                if (fileContent[i] == 144)
                {
                    result.Add(fileContent[i + 1]); 
                }
            }

        }
        private async Task GetFileSize()
        {
            BasicProperties basicProperties = await file.GetBasicPropertiesAsync();
            fileSize = basicProperties.Size;
        }
        private async Task GetFileBytes()
        {
            IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read);
            var midiReader = new DataReader(stream.GetInputStreamAt(0));
            fileContent = new byte[fileSize];
            await midiReader.LoadAsync((uint)fileSize);
            midiReader.ReadBytes(fileContent);
        }
    }
}
