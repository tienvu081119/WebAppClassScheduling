

namespace WebApp.Models
{
    public abstract class BaseRepository
    {
        protected CSContext context;

        public BaseRepository(CSContext context)
        {
            this.context = context;
        }
    }
}
