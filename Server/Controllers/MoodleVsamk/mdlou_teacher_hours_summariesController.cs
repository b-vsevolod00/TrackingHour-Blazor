using System;
using System.Net;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TrackHourBlazor.Server.Controllers.moodle_vsamk
{
    [Route("odata/moodle_vsamk/mdlou_teacher_hours_summaries")]
    public partial class mdlou_teacher_hours_summariesController : ODataController
    {
        private TrackHourBlazor.Server.Data.moodle_vsamkContext context;

        public mdlou_teacher_hours_summariesController(TrackHourBlazor.Server.Data.moodle_vsamkContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary> Getmdlou_teacher_hours_summaries()
        {
            var items = this.context.mdlou_teacher_hours_summaries.AsQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary>();
            this.Onmdlou_teacher_hours_summariesRead(ref items);

            return items;
        }

        partial void Onmdlou_teacher_hours_summariesRead(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary> items);

        partial void Onmdlou_teacher_hours_summaryGet(ref SingleResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/moodle_vsamk/mdlou_teacher_hours_summaries(id={id})")]
        public SingleResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary> Getmdlou_teacher_hours_summary(long key)
        {
            var items = this.context.mdlou_teacher_hours_summaries.Where(i => i.id == key);
            var result = SingleResult.Create(items);

            Onmdlou_teacher_hours_summaryGet(ref result);

            return result;
        }
        partial void Onmdlou_teacher_hours_summaryDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary item);
        partial void OnAftermdlou_teacher_hours_summaryDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary item);

        [HttpDelete("/odata/moodle_vsamk/mdlou_teacher_hours_summaries(id={id})")]
        public IActionResult Deletemdlou_teacher_hours_summary(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var items = this.context.mdlou_teacher_hours_summaries
                    .Where(i => i.id == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary>(Request, items);

                var item = items.FirstOrDefault();

                if (item == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                this.Onmdlou_teacher_hours_summaryDeleted(item);
                this.context.mdlou_teacher_hours_summaries.Remove(item);
                this.context.SaveChanges();
                this.OnAftermdlou_teacher_hours_summaryDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void Onmdlou_teacher_hours_summaryUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary item);
        partial void OnAftermdlou_teacher_hours_summaryUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary item);

        [HttpPut("/odata/moodle_vsamk/mdlou_teacher_hours_summaries(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Putmdlou_teacher_hours_summary(long key, [FromBody]TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var items = this.context.mdlou_teacher_hours_summaries
                    .Where(i => i.id == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary>(Request, items);

                var firstItem = items.FirstOrDefault();

                if (firstItem == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                this.Onmdlou_teacher_hours_summaryUpdated(item);
                this.context.mdlou_teacher_hours_summaries.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_teacher_hours_summaries.Where(i => i.id == key);
                Request.QueryString = Request.QueryString.Add("$expand", "course,teacher");
                this.OnAftermdlou_teacher_hours_summaryUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/moodle_vsamk/mdlou_teacher_hours_summaries(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Patchmdlou_teacher_hours_summary(long key, [FromBody]Delta<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var items = this.context.mdlou_teacher_hours_summaries
                    .Where(i => i.id == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary>(Request, items);

                var item = items.FirstOrDefault();

                if (item == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                patch.Patch(item);

                this.Onmdlou_teacher_hours_summaryUpdated(item);
                this.context.mdlou_teacher_hours_summaries.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_teacher_hours_summaries.Where(i => i.id == key);
                Request.QueryString = Request.QueryString.Add("$expand", "course,teacher");
                this.OnAftermdlou_teacher_hours_summaryUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void Onmdlou_teacher_hours_summaryCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary item);
        partial void OnAftermdlou_teacher_hours_summaryCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null)
                {
                    return BadRequest();
                }

                this.Onmdlou_teacher_hours_summaryCreated(item);
                this.context.mdlou_teacher_hours_summaries.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_teacher_hours_summaries.Where(i => i.id == item.id);

                Request.QueryString = Request.QueryString.Add("$expand", "course,teacher");

                this.OnAftermdlou_teacher_hours_summaryCreated(item);

                return new ObjectResult(SingleResult.Create(itemToReturn))
                {
                    StatusCode = 201
                };
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
