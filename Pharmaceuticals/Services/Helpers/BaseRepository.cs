using PharmaceuticalsApp.Entities;

namespace PharmaceuticalsApp.Services
{
    public abstract class BaseRepository
    {
        protected Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public bool Save()
        {
            if (_context.ChangeTracker.HasChanges())
            {
                return (_context.SaveChanges() >= 0);
            }

            return true;
        }
    }
}