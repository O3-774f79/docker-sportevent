using Microsoft.EntityFrameworkCore;
using SportEvent.Data.Repository.EF;

namespace SportEvent.Data
{
    /// <summary>
    /// SeUnitOfWork class is a unit of work for manipulating about utility data in database via repository.
    /// </summary>
    public class SeUnitOfWork : EfUnitOfWork<DbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeUnitOfWork" /> class.
        /// </summary>
        /// <param name="seDbContext">The Sport Event database context what inherits from DbContext of EF.</param>
        public SeUnitOfWork(DbContext seDbContext) : base(seDbContext)
        { }

    }
}
