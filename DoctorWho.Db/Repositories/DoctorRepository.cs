using DoctorWho.Db.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class DoctorRepository
    {
        private readonly DoctorWhoCoreDbContext context;
        public DoctorRepository(DoctorWhoCoreDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddDoctor(Doctor doctor)
        {
            context.Doctors.Add(doctor);
            context.SaveChangesAsync();
        }
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            var deletedObjec = await context.Doctors.FindAsync(id);
            if (deletedObjec == null)
                return new NotFoundResult();
            if (deletedObjec != null)
                context.Doctors.Remove(deletedObjec);
            await context.SaveChangesAsync();
            return new NoContentResult();

        }
        public async Task<Doctor?> GetDoctor(int id, bool includeEpisodes = false)
        {
            if (includeEpisodes)
                return await context.Doctors.Include(d => d.Episodes).Where(d => d.DoctorId == id).FirstOrDefaultAsync();
            return await context.Doctors.FindAsync(id);
        }
        public async Task<IEnumerable<Doctor>> GetAllDoctors(bool includeEpisodes = false)
        {
            if (includeEpisodes)
                return await context.Doctors
                        .OrderBy(a => a.DoctorName).Include("Episodes").ToListAsync();
            return await context.Doctors
                       .OrderBy(a => a.DoctorName).ToListAsync();
        }
        public async Task<bool> DoctorExist(int id)
        {
            var result = await context.Doctors.FindAsync(id);
            if (result == null)
                return false;
            return true;
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }

}
