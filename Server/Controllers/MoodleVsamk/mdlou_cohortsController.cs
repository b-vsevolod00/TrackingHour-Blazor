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
    [Route("odata/moodle_vsamk/mdlou_cohorts")]
    public partial class mdlou_cohortsController : ODataController
    {
        private TrackHourBlazor.Server.Data.moodle_vsamkContext context;

        public mdlou_cohortsController(TrackHourBlazor.Server.Data.moodle_vsamkContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> Getmdlou_cohorts()
        {
            var items = this.context.mdlou_cohorts.AsQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort>();
            this.Onmdlou_cohortsRead(ref items);

            return items;
        }

        partial void Onmdlou_cohortsRead(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> items);

        partial void Onmdlou_cohortGet(ref SingleResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/moodle_vsamk/mdlou_cohorts(id={id})")]
        public SingleResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> Getmdlou_cohort(long key)
        {
            var items = this.context.mdlou_cohorts.Where(i => i.id == key);
            var result = SingleResult.Create(items);

            Onmdlou_cohortGet(ref result);

            return result;
        }
        partial void Onmdlou_cohortDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item);
        partial void OnAftermdlou_cohortDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item);

        [HttpDelete("/odata/moodle_vsamk/mdlou_cohorts(id={id})")]
        public IActionResult Deletemdlou_cohort(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var items = this.context.mdlou_cohorts
                    .Where(i => i.id == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort>(Request, items);

                var item = items.FirstOrDefault();

                if (item == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                this.Onmdlou_cohortDeleted(item);
                this.context.mdlou_cohorts.Remove(item);
                this.context.SaveChanges();
                this.OnAftermdlou_cohortDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void Onmdlou_cohortUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item);
        partial void OnAftermdlou_cohortUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item);

        [HttpPut("/odata/moodle_vsamk/mdlou_cohorts(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Putmdlou_cohort(long key, [FromBody]TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var items = this.context.mdlou_cohorts
                    .Where(i => i.id == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort>(Request, items);

                var firstItem = items.FirstOrDefault();

                if (firstItem == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                this.Onmdlou_cohortUpdated(item);
                this.context.mdlou_cohorts.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_cohorts.Where(i => i.id == key);
                
                this.OnAftermdlou_cohortUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/moodle_vsamk/mdlou_cohorts(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Patchmdlou_cohort(long key, [FromBody]Delta<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var items = this.context.mdlou_cohorts
                    .Where(i => i.id == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort>(Request, items);

                var item = items.FirstOrDefault();

                if (item == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                patch.Patch(item);

                this.Onmdlou_cohortUpdated(item);
                this.context.mdlou_cohorts.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_cohorts.Where(i => i.id == key);
                
                this.OnAftermdlou_cohortUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void Onmdlou_cohortCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item);
        partial void OnAftermdlou_cohortCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item)
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

                this.Onmdlou_cohortCreated(item);
                this.context.mdlou_cohorts.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_cohorts.Where(i => i.id == item.id);

                

                this.OnAftermdlou_cohortCreated(item);

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
