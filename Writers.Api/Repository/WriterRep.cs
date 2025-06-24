using Writers.Api.Models;

namespace Writers.Api.Repository
{
    public static class WriterData
    {
        public static List<Writer> Writers { get; set; } = new List<Writer>
        {
            new ()   { Id = 1, Name = "Author One" },
            new ()  { Id = 2, Name = "Author Two" },
            new ()  { Id = 3, Name = "Author Three" },
            new ()  { Id = 4, Name = "Author Four" },
            new ()  { Id = 5, Name = "Author Five" },
        };
    }


    public class WriterRep : IWriterRep
    {
        public Writer AddWriter(Writer writer)
        {
            WriterData.Writers.Add(writer);
            return writer;
        }

        public void DeleteWriter(int id)
        {
            var item = WriterData.Writers.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException($"Writer with ID {id} not found.");
            }
            WriterData.Writers.Remove(item);
        }

        public Writer GetWriter(int id)
        {
            var item = WriterData.Writers.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException($"Writer with ID {id} not found.");
            }
            return item;
        }

        public IEnumerable<Writer> GetWriters()
        {
          return  WriterData.Writers;
        }

        public Writer UpdateWriter(Writer writer)
        {
            var item = WriterData.Writers.FirstOrDefault(x => x.Id == writer.Id);
            if (item == null)
            {
                throw new KeyNotFoundException($"Writer with ID {writer.Id} not found.");
            }
            item.Name = writer.Name;
            return item;
        }
    }
}
