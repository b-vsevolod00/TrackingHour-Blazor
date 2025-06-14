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
    [Route("odata/moodle_vsamk/mdlou_users")]
    public partial class mdlou_usersController : ODataController
    {
        private TrackHourBlazor.Server.Data.moodle_vsamkContext context;

        public mdlou_usersController(TrackHourBlazor.Server.Data.moodle_vsamkContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> Getmdlou_users()
        {
            var items = this.context.mdlou_users.AsQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>();
            this.Onmdlou_usersRead(ref items);

            return items;
        }

        partial void Onmdlou_usersRead(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> items);

        partial void Onmdlou_userGet(ref SingleResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/moodle_vsamk/mdlou_users(id={id})")]
        public SingleResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> Getmdlou_user(long key)
        {
            var items = this.context.mdlou_users.Where(i => i.id == key);
            var result = SingleResult.Create(items);

            Onmdlou_userGet(ref result);

            return result;
        }
        partial void Onmdlou_userDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item);
        partial void OnAftermdlou_userDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item);

        [HttpDelete("/odata/moodle_vsamk/mdlou_users(id={id})")]
        public IActionResult Deletemdlou_user(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.mdlou_users
                    .Where(i => i.id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.Onmdlou_userDeleted(item);
                this.context.mdlou_users.Remove(item);
                this.context.SaveChanges();
                this.OnAftermdlou_userDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void Onmdlou_userUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item);
        partial void OnAftermdlou_userUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item);

        [HttpPut("/odata/moodle_vsamk/mdlou_users(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Putmdlou_user(long key, [FromBody]TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item)
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
                this.Onmdlou_userUpdated(item);
                this.context.mdlou_users.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_users.Where(i => i.id == key);
                
                this.OnAftermdlou_userUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/moodle_vsamk/mdlou_users(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Patchmdlou_user(long key, [FromBody]Delta<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.mdlou_users.Where(i => i.id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.Onmdlou_userUpdated(item);
                this.context.mdlou_users.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_users.Where(i => i.id == key);
                
                this.OnAftermdlou_userUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void Onmdlou_userCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item);
        partial void OnAftermdlou_userCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item)
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

                this.Onmdlou_userCreated(item);
                this.context.mdlou_users.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.mdlou_users.Where(i => i.id == item.id);

                

                this.OnAftermdlou_userCreated(item);

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
