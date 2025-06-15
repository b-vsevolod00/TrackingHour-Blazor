using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using TrackHourBlazor.Server.Data;

namespace TrackHourBlazor.Server.Controllers
{
    public partial class Exportmoodle_vsamkController : ExportController
    {
        private readonly moodle_vsamkContext context;
        private readonly moodle_vsamkService service;

        public Exportmoodle_vsamkController(moodle_vsamkContext context, moodle_vsamkService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/moodle_vsamk/mdlou_cohorts/csv")]
        [HttpGet("/export/moodle_vsamk/mdlou_cohorts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> Exportmdlou_cohortsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.Getmdlou_cohorts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/moodle_vsamk/mdlou_cohorts/excel")]
        [HttpGet("/export/moodle_vsamk/mdlou_cohorts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> Exportmdlou_cohortsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.Getmdlou_cohorts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/moodle_vsamk/mdlou_courses/csv")]
        [HttpGet("/export/moodle_vsamk/mdlou_courses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> Exportmdlou_coursesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.Getmdlou_courses(), Request.Query, false), fileName);
        }

        [HttpGet("/export/moodle_vsamk/mdlou_courses/excel")]
        [HttpGet("/export/moodle_vsamk/mdlou_courses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> Exportmdlou_coursesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.Getmdlou_courses(), Request.Query, false), fileName);
        }

        [HttpGet("/export/moodle_vsamk/mdlou_groups/csv")]
        [HttpGet("/export/moodle_vsamk/mdlou_groups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> Exportmdlou_groupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.Getmdlou_groups(), Request.Query, false), fileName);
        }

        [HttpGet("/export/moodle_vsamk/mdlou_groups/excel")]
        [HttpGet("/export/moodle_vsamk/mdlou_groups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> Exportmdlou_groupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.Getmdlou_groups(), Request.Query, false), fileName);
        }

        [HttpGet("/export/moodle_vsamk/mdlou_users/csv")]
        [HttpGet("/export/moodle_vsamk/mdlou_users/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> Exportmdlou_usersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.Getmdlou_users(), Request.Query, false), fileName);
        }

        [HttpGet("/export/moodle_vsamk/mdlou_users/excel")]
        [HttpGet("/export/moodle_vsamk/mdlou_users/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> Exportmdlou_usersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.Getmdlou_users(), Request.Query, false), fileName);
        }

        [HttpGet("/export/moodle_vsamk/mdlou_teacher_hours/csv")]
        [HttpGet("/export/moodle_vsamk/mdlou_teacher_hours/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> Exportmdlou_teacher_hoursToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.Getmdlou_teacher_hours(), Request.Query, false), fileName);
        }

        [HttpGet("/export/moodle_vsamk/mdlou_teacher_hours/excel")]
        [HttpGet("/export/moodle_vsamk/mdlou_teacher_hours/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> Exportmdlou_teacher_hoursToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.Getmdlou_teacher_hours(), Request.Query, false), fileName);
        }

        [HttpGet("/export/moodle_vsamk/mdlou_teacher_hours_summaries/csv")]
        [HttpGet("/export/moodle_vsamk/mdlou_teacher_hours_summaries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> Exportmdlou_teacher_hours_summariesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.Getmdlou_teacher_hours_summaries(), Request.Query, false), fileName);
        }

        [HttpGet("/export/moodle_vsamk/mdlou_teacher_hours_summaries/excel")]
        [HttpGet("/export/moodle_vsamk/mdlou_teacher_hours_summaries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> Exportmdlou_teacher_hours_summariesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.Getmdlou_teacher_hours_summaries(), Request.Query, false), fileName);
        }

        [HttpGet("/export/moodle_vsamk/mdlou_teacher_workloads/csv")]
        [HttpGet("/export/moodle_vsamk/mdlou_teacher_workloads/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> Exportmdlou_teacher_workloadsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.Getmdlou_teacher_workloads(), Request.Query, false), fileName);
        }

        [HttpGet("/export/moodle_vsamk/mdlou_teacher_workloads/excel")]
        [HttpGet("/export/moodle_vsamk/mdlou_teacher_workloads/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> Exportmdlou_teacher_workloadsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.Getmdlou_teacher_workloads(), Request.Query, false), fileName);
        }
    }
}
