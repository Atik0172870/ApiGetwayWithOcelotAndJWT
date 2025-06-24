using Writers.Api.Models;

namespace Writers.Api.Repository
{
    public interface IWriterRep
    {
        Writer  AddWriter(Writer writer);
        Writer GetWriter(int id);
        IEnumerable<Writer> GetWriters();
        Writer UpdateWriter(Writer writer);
        void DeleteWriter(int id);

    }
}
