﻿using Testr.Domain.Entities;
using Testr.Domain.Interfaces;
using Testr.Infrastructure.Authentication;

namespace Testr.Infrastructure.Repositories
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        private readonly AppDbContext _context;

        public CandidateRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}