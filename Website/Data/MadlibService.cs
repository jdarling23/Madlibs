using Models;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Data
{
    public class MadlibService
    {
        public Task<Madlib> GetMadlibByStudentName(string name)
        {
            Madlib madlib = new Madlib();

            using (var context = new MadlibContext())
            {
                madlib = context.Madlibs
                            .Where(m => m.StudentName == name)
                            .FirstOrDefault();
            }

            return Task.FromResult(madlib);
        }
    }
}
