using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySysApi.Models
{
    public class LibrarySysApiContext:DbContext
    {
        public LibrarySysApiContext(DbContextOptions<LibrarySysApiContext> options)
            : base(options)
        {
        }

        public DbSet<BookC>BookC { get; set; }
        public DbSet<Reader> Reader { get; set; }
    }
}
