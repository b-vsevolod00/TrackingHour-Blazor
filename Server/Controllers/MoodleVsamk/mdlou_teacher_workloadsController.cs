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
    [Route("odata/moodle_vsamk/mdlou_teacher_workloads")]
    public partial class mdlou_teacher_workloadsController : ODataController
    {
        private TrackHourBlazor.Server.Data.moodle_vsamkContext context;

        public mdlou_teacher_workloadsController(TrackHourBlazor.Server.Data.moodle_vsamkContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload> Getmdlou_teacher_workloads()
        {
            var items = this.context.mdlou_teacher_workloads.AsQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload>();
            this.Onmdlou_teacher_workloadsRead(ref items);

            return items;
        }

        partial void Onmdlou_teacher_workloadsRead(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload> items);

        partial void Onmdlou_teacher_workloadGet(ref SingleResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/moodle_vsamk/mdlou_teacher_workloads(id={id})")]
        public SingleResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload> Getmdlou_teacher_workload(long key)
        {
            var items = this.context.mdlou_teacher_workloads.Where(i => i.id == key);
            var result = SingleResult.Create(items);

            Onmdlou_teacher_workloadGet(ref result);

            return result;
        }
        partial void Onmdlou_teacher_workloadDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload item);
        partial void OnAftermdlou_teacher_workloadDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload item);

        [HttpDelete("/odata/moodle_vsamk/mdlou_teacher_workloads(id={id})")]
        public IActionResult Deletemdlou_teacher_workload(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var items = this.context.mdlou_teacher_workloads
                    .Where(i => i.id == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload>(Request, items);

                var item = items.FirstOrDefault();

                if (item == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                this.Onmdlou_teacher_workloadDeleted(item);
                this.context.mdlou_teacher_workloads.Remove(item);
                this.context.SaveChanges();
                this.OnAftermdlou_teacher_workloadDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void Onmdlou_teacher_workloadUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload item);
        partial void OnAftermdlou_teacher_workloadUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload item);

        [HttpPut("/odata/moodle_vsamk/mdlou_teacher_workloads(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Putmdlou_teacher_workload(long key, [FromBody]TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var items = this.context.mdlou_teacher_workloads
                    .Where(i => i.id == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload>(Request, items);

                var firstItem = items.FirstOrDefault();

                if (firstItem == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                this.Onmdlou_teacher_workloadUpdated(item);
                this.context.mdlou_teacher_workloads.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_teacher_workloads.Where(i => i.id == key);
                Request.QueryString = Request.QueryString.Add("$expand", "course,teacher");
                this.OnAftermdlou_teacher_workloadUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/moodle_vsamk/mdlou_teacher_workloads(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Patchmdlou_teacher_workload(long key, [FromBody]Delta<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var items = this.context.mdlou_teacher_workloads
                    .Where(i => i.id == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload>(Request, items);

                var item = items.FirstOrDefault();

                if (item == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                patch.Patch(item);

                this.Onmdlou_teacher_workloadUpdated(item);
                this.context.mdlou_teacher_workloads.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_teacher_workloads.Where(i => i.id == key);
                Request.QueryString = Request.QueryString.Add("$expand", "course,teacher");
                this.OnAftermdlou_teacher_workloadUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void Onmdlou_teacher_workloadCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload item);
        partial void OnAftermdlou_teacher_workloadCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload item)
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

                this.Onmdlou_teacher_workloadCreated(item);
                this.context.mdlou_teacher_workloads.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_teacher_workloads.Where(i => i.id == item.id);

                Request.QueryString = Request.QueryString.Add("$expand", "course,teacher");

                this.OnAftermdlou_teacher_workloadCreated(item);

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
