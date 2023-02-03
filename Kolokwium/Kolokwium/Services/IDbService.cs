using Kolokwium.DTO;
using Kolokwium.Model;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Services
{
    public interface IDbService
    {
        Task<ICollection<ProjectDTO>> GetProjects(int idProject);
        Task<bool> CreateTaskAsync(TaskREQDTO request);
    }

    public class DbService : IDbService
    {
        private readonly APBD_KOL_1Context _context;

        public DbService(APBD_KOL_1Context context)
        { 
            _context = context;
        }

        public async Task<bool> CreateTaskAsync(TaskREQDTO request)
        {
           // TaskType tt = await _context.TaskTypes.SingleOrDefaultAsync(e => e.IdTaskType == request.IdTaskType);
            TaskType tt = await _context.TaskTypes.SingleOrDefaultAsync(e => e.IdTaskType == request.TaskType.IdTaskType);

            if (tt == null)
            {
                //tt = new TaskType { IdTaskType = request.IdTaskType, Name = request.TaskTypeName };
                tt = new TaskType { IdTaskType = request.TaskType.IdTaskType, Name = request.TaskType.Name };
                await _context.TaskTypes.AddAsync(tt);
                await _context.SaveChangesAsync();
            }


            Model.Task t = new Model.Task
            {
                Name = request.Name,
                Description = request.Description,
                Deadline = DateTime.Parse(request.Deadline),
                IdTaskType = request.IdTeam,
                IdAssignedTo = request.IdAssignedTo,
                IdCreator = request.IdCreator
            };

            await _context.Tasks.AddAsync(t);

            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<ICollection<ProjectDTO>> GetProjects(int idProject)
        {
            Project p = await _context.Projects.SingleOrDefaultAsync(e => e.IdProject == idProject);

            if (p == null)
            {
                return null;
            }


            return await _context
                .Projects
                .Include(e => e.Tasks)
                .Where(e => e.IdProject == idProject)
                .Select(e => new ProjectDTO
                {
                    IdProject = e.IdProject,
                    Name = e.Name,
                    Deadline = e.Deadline,
                    Tasks = e.Tasks.Select(x =>
                        new TaskDTO
                        {
                            IdTask = x.IdTask,
                            Name = x.Name,
                            Description = x.Description,
                            Deadline = x.Deadline
                        }).ToList()
                })
                .OrderByDescending(e => e.Deadline)
                .ToListAsync();

        }



    }
}
