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
    [Route("odata/moodle_vsamk/mdlou_teacher_hours")]
    public partial class mdlou_teacher_hoursController : ODataController
    {
        private TrackHourBlazor.Server.Data.moodle_vsamkContext context;

        public mdlou_teacher_hoursController(TrackHourBlazor.Server.Data.moodle_vsamkContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour> Getmdlou_teacher_hours()
        {
            var items = this.context.mdlou_teacher_hours.AsQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour>();
            this.Onmdlou_teacher_hoursRead(ref items);

            return items;
        }

        partial void Onmdlou_teacher_hoursRead(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour> items);

        partial void Onmdlou_teacher_hourGet(ref SingleResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/moodle_vsamk/mdlou_teacher_hours(id={id})")]
        public SingleResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour> Getmdlou_teacher_hour(long key)
        {
            var items = this.context.mdlou_teacher_hours.Where(i => i.id == key);
            var result = SingleResult.Create(items);

            Onmdlou_teacher_hourGet(ref result);

            return result;
        }
        partial void Onmdlou_teacher_hourDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour item);
        partial void OnAftermdlou_teacher_hourDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour item);

        [HttpDelete("/odata/moodle_vsamk/mdlou_teacher_hours(id={id})")]
        public IActionResult Deletemdlou_teacher_hour(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var items = this.context.mdlou_teacher_hours
                    .Where(i => i.id == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour>(Request, items);

                var item = items.FirstOrDefault();

                if (item == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                this.Onmdlou_teacher_hourDeleted(item);
                this.context.mdlou_teacher_hours.Remove(item);
                this.context.SaveChanges();
                this.OnAftermdlou_teacher_hourDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void Onmdlou_teacher_hourUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour item);
        partial void OnAftermdlou_teacher_hourUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour item);

        [HttpPut("/odata/moodle_vsamk/mdlou_teacher_hours(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Putmdlou_teacher_hour(long key, [FromBody]TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var items = this.context.mdlou_teacher_hours
                    .Where(i => i.id == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour>(Request, items);

                var firstItem = items.FirstOrDefault();

                if (firstItem == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                this.Onmdlou_teacher_hourUpdated(item);
                this.context.mdlou_teacher_hours.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_teacher_hours.Where(i => i.id == key);
                Request.QueryString = Request.QueryString.Add("$expand", "course,group,teacher");
                this.OnAftermdlou_teacher_hourUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/moodle_vsamk/mdlou_teacher_hours(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Patchmdlou_teacher_hour(long key, [FromBody]Delta<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var items = this.context.mdlou_teacher_hours
                    .Where(i => i.id == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour>(Request, items);

                var item = items.FirstOrDefault();

                if (item == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                patch.Patch(item);

                this.Onmdlou_teacher_hourUpdated(item);
                this.context.mdlou_teacher_hours.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_teacher_hours.Where(i => i.id == key);
                Request.QueryString = Request.QueryString.Add("$expand", "course,group,teacher");
                this.OnAftermdlou_teacher_hourUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void Onmdlou_teacher_hourCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour item);
        partial void OnAftermdlou_teacher_hourCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour item)
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

                this.Onmdlou_teacher_hourCreated(item);
                this.context.mdlou_teacher_hours.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_teacher_hours.Where(i => i.id == item.id);

                Request.QueryString = Request.QueryString.Add("$expand", "course,group,teacher");

                this.OnAftermdlou_teacher_hourCreated(item);

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
