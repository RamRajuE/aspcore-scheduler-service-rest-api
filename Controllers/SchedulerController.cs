using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;
using System.ComponentModel.DataAnnotations;
using Syncfusion.Blazor.Gantt;
using schedule_aspcore_service.Models;
using schedule_aspcore_service.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Extensions.Logging;


namespace aspcore_scheduler_service_web_api.Controllers
{
    [ApiController]
    public class SchedulerController : ControllerBase
    {
        private readonly SchedulerDbContext? _context;
        public SchedulerController(SchedulerDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/scheduler")]
        public ActionResult<IEnumerable<ScheduleModel>> GetEvents()
        {

            //IEnumerable<ScheduleModel> events = _context.ScheduleTableAspCore.ToList();
            return Ok(_context.ScheduleTableAspCore.ToList());
        }

        [HttpPost]
        [Route("api/add")]
        public async Task Add([FromBody] CRUDModel<ScheduleModel> args)
        {
            var newEvent = new ScheduleModel
            {
                Subject = args.Value.Subject,
                StartTime = args.Value.StartTime,
                EndTime = args.Value.EndTime,
                StartTimezone = args.Value.StartTimezone,
                EndTimezone = args.Value.EndTimezone,
                Location = args.Value.Location,
                Description = args.Value.Description,
                IsAllDay = args.Value.IsAllDay,
                IsBlock = args.Value.IsBlock,
                IsReadOnly = args.Value.IsReadOnly,
                FollowingID = args.Value.FollowingID,
                RecurrenceID = args.Value.RecurrenceID,
                RecurrenceRule = args.Value.RecurrenceRule,
                RecurrenceException = args.Value.RecurrenceException,
                OwnerId = args.Value.OwnerId,
                Guid = args.Value.Guid
            };

            _context.ScheduleTableAspCore.Add(newEvent);
            await _context.SaveChangesAsync();
        }
            [HttpPost]
        [Route("api/update")]
        public async Task Update(CRUDModel<ScheduleModel> args)
        {
            var entity = await _context.ScheduleTableAspCore.FindAsync(args.Value.Id);
            if (entity != null)
            {
                _context.Entry(entity).CurrentValues.SetValues(args.Value);
                await _context.SaveChangesAsync();
            }
        }

        [HttpPost]
        [Route("api/delete")]
        public async Task Delete(CRUDModel<ScheduleModel> args)
        {
            var key = Convert.ToInt32(Convert.ToString(args.Key));
            var app = _context.ScheduleTableAspCore.Find(key);
            if (app != null)
            {
                _context.ScheduleTableAspCore.Remove(app);
                await _context.SaveChangesAsync();
            }
        }

        //[HttpPost]
        //[Route("api/schedulerCrud")]
        // public async Task Batch([FromBody] CRUDModel<ScheduleModel> args)
        //{
        //    if (args.Changed.Count > 0)
        //    {
        //        foreach (ScheduleModel appointment in args.Changed)
        //        {
        //            var entity = await _context.ScheduleTableAspCore.FindAsync(appointment.Id);
        //            if (entity != null)
        //            {
        //                _context.Entry(entity).CurrentValues.SetValues(appointment);
        //            }
        //        }
        //    }
        //    if (args.Added.Count > 0)
        //    {
        //        foreach (ScheduleModel appointment in args.Added)
        //        {
        //            _context.ScheduleTableAspCore.Add(appointment);

        //        }
        //    }
        //    if (args.Deleted.Count > 0)
        //    {
        //        foreach (ScheduleModel appointment in args.Deleted)
        //        {
        //            var app = _context.ScheduleTableAspCore.Find(appointment.Id);
        //            if (app != null)
        //            {
        //                _context.ScheduleTableAspCore.Remove(app);
        //            }
        //        }
        //    }
        //    await _context.SaveChangesAsync();
        //} 

    }

}

