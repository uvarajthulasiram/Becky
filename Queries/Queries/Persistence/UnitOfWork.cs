﻿using Queries.Core;
using Queries.Core.Domain;
using Queries.Core.Repositories;
using Queries.Persistence.Repositories;

namespace Queries.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlutoContext _context;
        private ICourseRepository _courseRepository;

        public UnitOfWork(PlutoContext context)
        {
            _context = context;
            //Courses = new CourseRepository(_context);
            //Authors = new AuthorRepository(_context);
        }

        //public ICourseRepository Courses { get; private set; }
        //public IAuthorRepository Authors { get; private set; }

        public ICourseRepository Courses
        {
            get
            {
                if (_courseRepository == null)
                    _courseRepository = ObjectFactory.GetInstance<Course, ICourseRepository>();

                return _courseRepository;
            }
        }

        public IAuthorRepository Authors { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}