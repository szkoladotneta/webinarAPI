using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebinarAPI.Application.Interfaces;
using WebinarAPI.Application.ViewModels.Presents;
using WebinarAPI.Domain.Interfaces;
using WebinarAPI.Domain.Model;

namespace WebinarAPI.Application.Services
{
    public class PresentService : IPresentService
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        public PresentService(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PresentsVm> GetAllPresents()
        {
            var presents = await _context.Presents.ProjectTo<PresentDto>(_mapper.ConfigurationProvider).ToListAsync();
            return new ()
            {
                Presents = presents,
                Count = presents.Count
            };

        }
        public async Task<PresentDto> GetPresentById(int id)
        {
            var present = await _context.Presents.FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<PresentDto>(present);
        }

        public async Task AddNewPresent(CreatePresentDto newPresent)
        {
            var present = _mapper.Map<Present>(newPresent);
            _context.Presents.Add(present);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePresent(int id)
        {
            var present = await _context.Presents.FirstOrDefaultAsync(p => p.Id == id);
            _context.Presents.Remove(present);
            await _context.SaveChangesAsync();
        }

        public async Task<PresentsVm> GetPresentsByQuery(string query)
        {
            var presents = await _context.Presents.Where(p => p.Name.ToLower().Contains(query.ToLower())).ProjectTo<PresentDto>(_mapper.ConfigurationProvider).ToListAsync();
            return new ()
            {
                Presents = presents,
                Count = presents.Count
            };
        }

        public async Task UpdatePresnet(UpdatePresentDto updatePresent)
        {
            var existing = await _context.Presents.FirstOrDefaultAsync(p => p.Id == updatePresent.Id);

            _mapper.Map(updatePresent, existing);
            await _context.SaveChangesAsync();
        }
    }
}
