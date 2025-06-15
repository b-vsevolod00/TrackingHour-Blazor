
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Radzen;

namespace TrackHourBlazor.Client
{
    public partial class moodle_vsamkService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;

        public moodle_vsamkService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/moodle_vsamk/");
        }


        public async System.Threading.Tasks.Task Exportmdlou_cohortsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_cohorts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_cohorts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task Exportmdlou_cohortsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_cohorts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_cohorts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetmdlou_cohorts(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort>> Getmdlou_cohorts(Query query)
        {
            return await Getmdlou_cohorts(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort>> Getmdlou_cohorts(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string), string apply = default(string))
        {
            var uri = new Uri(baseUri, $"mdlou_cohorts");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count, apply:apply);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetmdlou_cohorts(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort>>(response);
        }

        partial void OnCreatemdlou_cohort(HttpRequestMessage requestMessage);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> Createmdlou_cohort(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort mdlouCohort = default(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort))
        {
            var uri = new Uri(baseUri, $"mdlou_cohorts");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mdlouCohort), Encoding.UTF8, "application/json");

            OnCreatemdlou_cohort(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort>(response);
        }

        partial void OnDeletemdlou_cohort(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> Deletemdlou_cohort(long id = default(long))
        {
            var uri = new Uri(baseUri, $"mdlou_cohorts({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeletemdlou_cohort(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetmdlou_cohortById(HttpRequestMessage requestMessage);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> Getmdlou_cohortById(string expand = default(string), long id = default(long))
        {
            var uri = new Uri(baseUri, $"mdlou_cohorts({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetmdlou_cohortById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort>(response);
        }

        partial void OnUpdatemdlou_cohort(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> Updatemdlou_cohort(long id = default(long), TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort mdlouCohort = default(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort))
        {
            var uri = new Uri(baseUri, $"mdlou_cohorts({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", mdlouCohort.ETag);    

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mdlouCohort), Encoding.UTF8, "application/json");

            OnUpdatemdlou_cohort(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task Exportmdlou_coursesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_courses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_courses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task Exportmdlou_coursesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_courses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_courses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetmdlou_courses(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>> Getmdlou_courses(Query query)
        {
            return await Getmdlou_courses(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>> Getmdlou_courses(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string), string apply = default(string))
        {
            var uri = new Uri(baseUri, $"mdlou_courses");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count, apply:apply);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetmdlou_courses(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>>(response);
        }

        partial void OnCreatemdlou_course(HttpRequestMessage requestMessage);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> Createmdlou_course(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course mdlouCourse = default(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course))
        {
            var uri = new Uri(baseUri, $"mdlou_courses");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mdlouCourse), Encoding.UTF8, "application/json");

            OnCreatemdlou_course(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>(response);
        }

        partial void OnDeletemdlou_course(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> Deletemdlou_course(long id = default(long))
        {
            var uri = new Uri(baseUri, $"mdlou_courses({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeletemdlou_course(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetmdlou_courseById(HttpRequestMessage requestMessage);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> Getmdlou_courseById(string expand = default(string), long id = default(long))
        {
            var uri = new Uri(baseUri, $"mdlou_courses({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetmdlou_courseById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>(response);
        }

        partial void OnUpdatemdlou_course(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> Updatemdlou_course(long id = default(long), TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course mdlouCourse = default(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course))
        {
            var uri = new Uri(baseUri, $"mdlou_courses({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", mdlouCourse.ETag);    

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mdlouCourse), Encoding.UTF8, "application/json");

            OnUpdatemdlou_course(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task Exportmdlou_groupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_groups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_groups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task Exportmdlou_groupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_groups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_groups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetmdlou_groups(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group>> Getmdlou_groups(Query query)
        {
            return await Getmdlou_groups(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group>> Getmdlou_groups(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string), string apply = default(string))
        {
            var uri = new Uri(baseUri, $"mdlou_groups");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count, apply:apply);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetmdlou_groups(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group>>(response);
        }

        partial void OnCreatemdlou_group(HttpRequestMessage requestMessage);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> Createmdlou_group(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group mdlouGroup = default(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group))
        {
            var uri = new Uri(baseUri, $"mdlou_groups");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mdlouGroup), Encoding.UTF8, "application/json");

            OnCreatemdlou_group(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group>(response);
        }

        partial void OnDeletemdlou_group(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> Deletemdlou_group(long id = default(long))
        {
            var uri = new Uri(baseUri, $"mdlou_groups({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeletemdlou_group(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetmdlou_groupById(HttpRequestMessage requestMessage);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> Getmdlou_groupById(string expand = default(string), long id = default(long))
        {
            var uri = new Uri(baseUri, $"mdlou_groups({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetmdlou_groupById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group>(response);
        }

        partial void OnUpdatemdlou_group(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> Updatemdlou_group(long id = default(long), TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group mdlouGroup = default(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group))
        {
            var uri = new Uri(baseUri, $"mdlou_groups({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", mdlouGroup.ETag);    

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mdlouGroup), Encoding.UTF8, "application/json");

            OnUpdatemdlou_group(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task Exportmdlou_usersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_users/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_users/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task Exportmdlou_usersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_users/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_users/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetmdlou_users(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>> Getmdlou_users(Query query)
        {
            return await Getmdlou_users(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>> Getmdlou_users(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string), string apply = default(string))
        {
            var uri = new Uri(baseUri, $"mdlou_users");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count, apply:apply);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetmdlou_users(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>>(response);
        }

        partial void OnCreatemdlou_user(HttpRequestMessage requestMessage);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> Createmdlou_user(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user mdlouUser = default(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user))
        {
            var uri = new Uri(baseUri, $"mdlou_users");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mdlouUser), Encoding.UTF8, "application/json");

            OnCreatemdlou_user(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>(response);
        }

        partial void OnDeletemdlou_user(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> Deletemdlou_user(long id = default(long))
        {
            var uri = new Uri(baseUri, $"mdlou_users({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeletemdlou_user(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetmdlou_userById(HttpRequestMessage requestMessage);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> Getmdlou_userById(string expand = default(string), long id = default(long))
        {
            var uri = new Uri(baseUri, $"mdlou_users({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetmdlou_userById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>(response);
        }

        partial void OnUpdatemdlou_user(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> Updatemdlou_user(long id = default(long), TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user mdlouUser = default(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user))
        {
            var uri = new Uri(baseUri, $"mdlou_users({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", mdlouUser.ETag);    

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mdlouUser), Encoding.UTF8, "application/json");

            OnUpdatemdlou_user(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task Exportmdlou_teacher_hoursToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_teacher_hours/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_teacher_hours/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task Exportmdlou_teacher_hoursToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_teacher_hours/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_teacher_hours/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetmdlou_teacher_hours(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour>> Getmdlou_teacher_hours(Query query)
        {
            return await Getmdlou_teacher_hours(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour>> Getmdlou_teacher_hours(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string), string apply = default(string))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_hours");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count, apply:apply);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetmdlou_teacher_hours(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour>>(response);
        }

        partial void OnCreatemdlou_teacher_hour(HttpRequestMessage requestMessage);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour> Createmdlou_teacher_hour(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour mdlouTeacherHour = default(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_hours");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mdlouTeacherHour), Encoding.UTF8, "application/json");

            OnCreatemdlou_teacher_hour(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour>(response);
        }

        partial void OnDeletemdlou_teacher_hour(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> Deletemdlou_teacher_hour(long id = default(long))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_hours({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeletemdlou_teacher_hour(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetmdlou_teacher_hourById(HttpRequestMessage requestMessage);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour> Getmdlou_teacher_hourById(string expand = default(string), long id = default(long))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_hours({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetmdlou_teacher_hourById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour>(response);
        }

        partial void OnUpdatemdlou_teacher_hour(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> Updatemdlou_teacher_hour(long id = default(long), TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour mdlouTeacherHour = default(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_hours({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", mdlouTeacherHour.ETag);    

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mdlouTeacherHour), Encoding.UTF8, "application/json");

            OnUpdatemdlou_teacher_hour(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task Exportmdlou_teacher_hours_summariesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_teacher_hours_summaries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_teacher_hours_summaries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task Exportmdlou_teacher_hours_summariesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_teacher_hours_summaries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_teacher_hours_summaries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetmdlou_teacher_hours_summaries(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary>> Getmdlou_teacher_hours_summaries(Query query)
        {
            return await Getmdlou_teacher_hours_summaries(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary>> Getmdlou_teacher_hours_summaries(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string), string apply = default(string))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_hours_summaries");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count, apply:apply);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetmdlou_teacher_hours_summaries(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary>>(response);
        }

        partial void OnCreatemdlou_teacher_hours_summary(HttpRequestMessage requestMessage);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary> Createmdlou_teacher_hours_summary(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary mdlouTeacherHoursSummary = default(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_hours_summaries");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mdlouTeacherHoursSummary), Encoding.UTF8, "application/json");

            OnCreatemdlou_teacher_hours_summary(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary>(response);
        }

        partial void OnDeletemdlou_teacher_hours_summary(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> Deletemdlou_teacher_hours_summary(long id = default(long))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_hours_summaries({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeletemdlou_teacher_hours_summary(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetmdlou_teacher_hours_summaryById(HttpRequestMessage requestMessage);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary> Getmdlou_teacher_hours_summaryById(string expand = default(string), long id = default(long))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_hours_summaries({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetmdlou_teacher_hours_summaryById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary>(response);
        }

        partial void OnUpdatemdlou_teacher_hours_summary(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> Updatemdlou_teacher_hours_summary(long id = default(long), TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary mdlouTeacherHoursSummary = default(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_hours_summaries({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", mdlouTeacherHoursSummary.ETag);    

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mdlouTeacherHoursSummary), Encoding.UTF8, "application/json");

            OnUpdatemdlou_teacher_hours_summary(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task Exportmdlou_teacher_workloadsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_teacher_workloads/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_teacher_workloads/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task Exportmdlou_teacher_workloadsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/moodle_vsamk/mdlou_teacher_workloads/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/moodle_vsamk/mdlou_teacher_workloads/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetmdlou_teacher_workloads(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload>> Getmdlou_teacher_workloads(Query query)
        {
            return await Getmdlou_teacher_workloads(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload>> Getmdlou_teacher_workloads(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string), string apply = default(string))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_workloads");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count, apply:apply);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetmdlou_teacher_workloads(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload>>(response);
        }

        partial void OnCreatemdlou_teacher_workload(HttpRequestMessage requestMessage);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload> Createmdlou_teacher_workload(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload mdlouTeacherWorkload = default(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_workloads");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mdlouTeacherWorkload), Encoding.UTF8, "application/json");

            OnCreatemdlou_teacher_workload(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload>(response);
        }

        partial void OnDeletemdlou_teacher_workload(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> Deletemdlou_teacher_workload(long id = default(long))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_workloads({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeletemdlou_teacher_workload(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetmdlou_teacher_workloadById(HttpRequestMessage requestMessage);

        public async Task<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload> Getmdlou_teacher_workloadById(string expand = default(string), long id = default(long))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_workloads({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetmdlou_teacher_workloadById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload>(response);
        }

        partial void OnUpdatemdlou_teacher_workload(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> Updatemdlou_teacher_workload(long id = default(long), TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload mdlouTeacherWorkload = default(TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload))
        {
            var uri = new Uri(baseUri, $"mdlou_teacher_workloads({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", mdlouTeacherWorkload.ETag);    

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mdlouTeacherWorkload), Encoding.UTF8, "application/json");

            OnUpdatemdlou_teacher_workload(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}