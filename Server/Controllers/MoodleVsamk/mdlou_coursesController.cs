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
    [Route("odata/moodle_vsamk/mdlou_courses")]
    public partial class mdlou_coursesController : ODataController
    {
        private TrackHourBlazor.Server.Data.moodle_vsamkContext context;

        public mdlou_coursesController(TrackHourBlazor.Server.Data.moodle_vsamkContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> Getmdlou_courses()
        {
            var items = this.context.mdlou_courses.AsQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>();
            this.Onmdlou_coursesRead(ref items);

            return items;
        }

        partial void Onmdlou_coursesRead(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> items);

        partial void Onmdlou_courseGet(ref SingleResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/moodle_vsamk/mdlou_courses(id={id})")]
        public SingleResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> Getmdlou_course(long key)
        {
            var items = this.context.mdlou_courses.Where(i => i.id == key);
            var result = SingleResult.Create(items);

            Onmdlou_courseGet(ref result);

            return result;
        }
        partial void Onmdlou_courseDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item);
        partial void OnAftermdlou_courseDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item);

        [HttpDelete("/odata/moodle_vsamk/mdlou_courses(id={id})")]
        public IActionResult Deletemdlou_course(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.mdlou_courses
                    .Where(i => i.id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.Onmdlou_courseDeleted(item);
                this.context.mdlou_courses.Remove(item);
                this.context.SaveChanges();
                this.OnAftermdlou_courseDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void Onmdlou_courseUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item);
        partial void OnAftermdlou_courseUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item);

        [HttpPut("/odata/moodle_vsamk/mdlou_courses(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Putmdlou_course(long key, [FromBody]TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.id != key))
                {
                    return BadRequest();
                }
                this.Onmdlou_courseUpdated(item);
                this.context.mdlou_courses.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_courses.Where(i => i.id == key);
                
                this.OnAftermdlou_courseUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/moodle_vsamk/mdlou_courses(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Patchmdlou_course(long key, [FromBody]Delta<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.mdlou_courses.Where(i => i.id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.Onmdlou_courseUpdated(item);
                this.context.mdlou_courses.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_courses.Where(i => i.id == key);
                
                this.OnAftermdlou_courseUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void Onmdlou_courseCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item);
        partial void OnAftermdlou_courseCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item)
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

                this.Onmdlou_courseCreated(item);
                this.context.mdlou_courses.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_courses.Where(i => i.id == item.id);

                

                this.OnAftermdlou_courseCreated(item);

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
