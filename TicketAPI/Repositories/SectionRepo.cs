using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;
using TicketAPI.ResponseModels;

namespace TicketAPI.Repositories
{
    public class SectionRepo
    {
        private readonly TicketsDBContext _context;

        public SectionRepo(TicketsDBContext context)
        {
            _context = context;
        }

        public IEnumerable<SectionResponse> GetAll()
        {
            IEnumerable<SectionResponse> sections =
                _context.Section.Select(s => new SectionResponse() { 
                    SectionId = s.SectionId,
                    SectionName = s.SectionName,
                    VenueName = s.VenueName
                });

            return sections;
        }        

        public SectionResponse GetSection(long id)
        {
            Section targetSection = _context.Section.Where(s => s.SectionId == id).FirstOrDefault();

            SectionResponse section = new SectionResponse()
            {
                SectionId = targetSection.SectionId,
                SectionName = targetSection.SectionName,
                VenueName = targetSection.VenueName
            };

            return section;
        }
    }
}
