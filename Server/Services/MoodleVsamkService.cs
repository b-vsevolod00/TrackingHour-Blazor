using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Radzen;

using TrackHourBlazor.Server.Data;

namespace TrackHourBlazor.Server
{
    public partial class moodle_vsamkService
    {
        moodle_vsamkContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly moodle_vsamkContext context;
        private readonly NavigationManager navigationManager;

        public moodle_vsamkService(moodle_vsamkContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public void ApplyQuery<T>(ref IQueryable<T> items, Query query = null)
        {
            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }
        }


        public async Task Exportmdlou_cohortsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_cohorts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_cohorts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task Exportmdlou_cohortsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_cohorts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_cohorts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void Onmdlou_cohortsRead(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> items);

        public async Task<IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort>> Getmdlou_cohorts(Query query = null)
        {
            var items = Context.mdlou_cohorts.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            Onmdlou_cohortsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void Onmdlou_cohortGet(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item);
        partial void OnGetmdlou_cohortById(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> items);


        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> Getmdlou_cohortById(long id)
        {
            var items = Context.mdlou_cohorts
                              .AsNoTracking()
                              .Where(i => i.id == id);

 
            OnGetmdlou_cohortById(ref items);

            var itemToReturn = items.FirstOrDefault();

            Onmdlou_cohortGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void Onmdlou_cohortCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item);
        partial void OnAftermdlou_cohortCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> Createmdlou_cohort(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort mdloucohort)
        {
            Onmdlou_cohortCreated(mdloucohort);

            var existingItem = Context.mdlou_cohorts
                              .Where(i => i.id == mdloucohort.id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.mdlou_cohorts.Add(mdloucohort);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(mdloucohort).State = EntityState.Detached;
                throw;
            }

            OnAftermdlou_cohortCreated(mdloucohort);

            return mdloucohort;
        }

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> Cancelmdlou_cohortChanges(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void Onmdlou_cohortUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item);
        partial void OnAftermdlou_cohortUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> Updatemdlou_cohort(long id, TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort mdloucohort)
        {
            Onmdlou_cohortUpdated(mdloucohort);

            var itemToUpdate = Context.mdlou_cohorts
                              .Where(i => i.id == mdloucohort.id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(mdloucohort);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAftermdlou_cohortUpdated(mdloucohort);

            return mdloucohort;
        }

        partial void Onmdlou_cohortDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item);
        partial void OnAftermdlou_cohortDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort item);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> Deletemdlou_cohort(long id)
        {
            var itemToDelete = Context.mdlou_cohorts
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            Onmdlou_cohortDeleted(itemToDelete);


            Context.mdlou_cohorts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAftermdlou_cohortDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task Exportmdlou_coursesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_courses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_courses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task Exportmdlou_coursesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_courses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_courses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void Onmdlou_coursesRead(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> items);

        public async Task<IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>> Getmdlou_courses(Query query = null)
        {
            var items = Context.mdlou_courses.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            Onmdlou_coursesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void Onmdlou_courseGet(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item);
        partial void OnGetmdlou_courseById(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> items);


        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> Getmdlou_courseById(long id)
        {
            var items = Context.mdlou_courses
                              .AsNoTracking()
                              .Where(i => i.id == id);

 
            OnGetmdlou_courseById(ref items);

            var itemToReturn = items.FirstOrDefault();

            Onmdlou_courseGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void Onmdlou_courseCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item);
        partial void OnAftermdlou_courseCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> Createmdlou_course(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course mdloucourse)
        {
            Onmdlou_courseCreated(mdloucourse);

            var existingItem = Context.mdlou_courses
                              .Where(i => i.id == mdloucourse.id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.mdlou_courses.Add(mdloucourse);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(mdloucourse).State = EntityState.Detached;
                throw;
            }

            OnAftermdlou_courseCreated(mdloucourse);

            return mdloucourse;
        }

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> Cancelmdlou_courseChanges(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void Onmdlou_courseUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item);
        partial void OnAftermdlou_courseUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> Updatemdlou_course(long id, TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course mdloucourse)
        {
            Onmdlou_courseUpdated(mdloucourse);

            var itemToUpdate = Context.mdlou_courses
                              .Where(i => i.id == mdloucourse.id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(mdloucourse);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAftermdlou_courseUpdated(mdloucourse);

            return mdloucourse;
        }

        partial void Onmdlou_courseDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item);
        partial void OnAftermdlou_courseDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course item);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> Deletemdlou_course(long id)
        {
            var itemToDelete = Context.mdlou_courses
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            Onmdlou_courseDeleted(itemToDelete);


            Context.mdlou_courses.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAftermdlou_courseDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task Exportmdlou_groupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_groups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_groups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task Exportmdlou_groupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_groups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_groups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void Onmdlou_groupsRead(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> items);

        public async Task<IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group>> Getmdlou_groups(Query query = null)
        {
            var items = Context.mdlou_groups.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            Onmdlou_groupsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void Onmdlou_groupGet(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item);
        partial void OnGetmdlou_groupById(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> items);


        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> Getmdlou_groupById(long id)
        {
            var items = Context.mdlou_groups
                              .AsNoTracking()
                              .Where(i => i.id == id);

 
            OnGetmdlou_groupById(ref items);

            var itemToReturn = items.FirstOrDefault();

            Onmdlou_groupGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void Onmdlou_groupCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item);
        partial void OnAftermdlou_groupCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> Createmdlou_group(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group mdlougroup)
        {
            Onmdlou_groupCreated(mdlougroup);

            var existingItem = Context.mdlou_groups
                              .Where(i => i.id == mdlougroup.id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.mdlou_groups.Add(mdlougroup);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(mdlougroup).State = EntityState.Detached;
                throw;
            }

            OnAftermdlou_groupCreated(mdlougroup);

            return mdlougroup;
        }

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> Cancelmdlou_groupChanges(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void Onmdlou_groupUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item);
        partial void OnAftermdlou_groupUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> Updatemdlou_group(long id, TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group mdlougroup)
        {
            Onmdlou_groupUpdated(mdlougroup);

            var itemToUpdate = Context.mdlou_groups
                              .Where(i => i.id == mdlougroup.id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(mdlougroup);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAftermdlou_groupUpdated(mdlougroup);

            return mdlougroup;
        }

        partial void Onmdlou_groupDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item);
        partial void OnAftermdlou_groupDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group item);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> Deletemdlou_group(long id)
        {
            var itemToDelete = Context.mdlou_groups
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            Onmdlou_groupDeleted(itemToDelete);


            Context.mdlou_groups.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAftermdlou_groupDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task Exportmdlou_usersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_users/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_users/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task Exportmdlou_usersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_users/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_users/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void Onmdlou_usersRead(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> items);

        public async Task<IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>> Getmdlou_users(Query query = null)
        {
            var items = Context.mdlou_users.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            Onmdlou_usersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void Onmdlou_userGet(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item);
        partial void OnGetmdlou_userById(ref IQueryable<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> items);


        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> Getmdlou_userById(long id)
        {
            var items = Context.mdlou_users
                              .AsNoTracking()
                              .Where(i => i.id == id);

 
            OnGetmdlou_userById(ref items);

            var itemToReturn = items.FirstOrDefault();

            Onmdlou_userGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void Onmdlou_userCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item);
        partial void OnAftermdlou_userCreated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> Createmdlou_user(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user mdlouuser)
        {
            Onmdlou_userCreated(mdlouuser);

            var existingItem = Context.mdlou_users
                              .Where(i => i.id == mdlouuser.id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.mdlou_users.Add(mdlouuser);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(mdlouuser).State = EntityState.Detached;
                throw;
            }

            OnAftermdlou_userCreated(mdlouuser);

            return mdlouuser;
        }

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> Cancelmdlou_userChanges(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void Onmdlou_userUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item);
        partial void OnAftermdlou_userUpdated(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> Updatemdlou_user(long id, TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user mdlouuser)
        {
            Onmdlou_userUpdated(mdlouuser);

            var itemToUpdate = Context.mdlou_users
                              .Where(i => i.id == mdlouuser.id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(mdlouuser);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAftermdlou_userUpdated(mdlouuser);

            return mdlouuser;
        }

        partial void Onmdlou_userDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item);
        partial void OnAftermdlou_userDeleted(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user item);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> Deletemdlou_user(long id)
        {
            var itemToDelete = Context.mdlou_users
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            Onmdlou_userDeleted(itemToDelete);


            Context.mdlou_users.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAftermdlou_userDeleted(itemToDelete);

            return itemToDelete;
        }
        }
}