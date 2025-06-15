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
    [Route("odata/moodle_vsamk/mdlou_groups")]
    public partial class mdlou_groupsController : ODataController
    {
        private TrackHourBlazor.Server.Data.moodle_vsamkContext context;

        public mdlou_groupsController(TrackHourBlazor.Server.Data.moodle_vsamkContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> Getmdlou_groups()
        {
            var items = this.context.mdlou_groups.AsQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group>();
            this.Onmdlou_groupsRead(ref items);

            return items;
        }

        partial void Onmdlou_groupsRead(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> items);

        partial void Onmdlou_groupGet(ref SingleResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/moodle_vsamk/mdlou_groups(id={id})")]
        public SingleResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> Getmdlou_group(long key)
        {
            var items = this.context.mdlou_groups.Where(i => i.id == key);
            var result = SingleResult.Create(items);

            Onmdlou_groupGet(ref result);

            return result;
        }
        partial void Onmdlou_groupDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item);
        partial void OnAftermdlou_groupDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item);

        [HttpDelete("/odata/moodle_vsamk/mdlou_groups(id={id})")]
        public IActionResult Deletemdlou_group(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var items = this.context.mdlou_groups
                    .Where(i => i.id == key)
                    .Include(i => i.mdlou_teacher_hours)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group>(Request, items);

                var item = items.FirstOrDefault();

                if (item == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                this.Onmdlou_groupDeleted(item);
                this.context.mdlou_groups.Remove(item);
                this.context.SaveChanges();
                this.OnAftermdlou_groupDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void Onmdlou_groupUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item);
        partial void OnAftermdlou_groupUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item);

        [HttpPut("/odata/moodle_vsamk/mdlou_groups(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Putmdlou_group(long key, [FromBody]TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var items = this.context.mdlou_groups
                    .Where(i => i.id == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group>(Request, items);

                var firstItem = items.FirstOrDefault();

                if (firstItem == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                this.Onmdlou_groupUpdated(item);
                this.context.mdlou_groups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_groups.Where(i => i.id == key);
                
                this.OnAftermdlou_groupUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/moodle_vsamk/mdlou_groups(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Patchmdlou_group(long key, [FromBody]Delta<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var items = this.context.mdlou_groups
                    .Where(i => i.id == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group>(Request, items);

                var item = items.FirstOrDefault();

                if (item == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                patch.Patch(item);

                this.Onmdlou_groupUpdated(item);
                this.context.mdlou_groups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_groups.Where(i => i.id == key);
                
                this.OnAftermdlou_groupUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void Onmdlou_groupCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item);
        partial void OnAftermdlou_groupCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item)
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

                this.Onmdlou_groupCreated(item);
                this.context.mdlou_groups.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_groups.Where(i => i.id == item.id);

                

                this.OnAftermdlou_groupCreated(item);

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
