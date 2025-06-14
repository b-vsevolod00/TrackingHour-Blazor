using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TrackHourBlazor.Server.Models.moodle_vsamk;

namespace TrackHourBlazor.Server.Data
{
    public partial class moodle_vsamkContext : DbContext
    {
        public moodle_vsamkContext()
        {
        }

        public moodle_vsamkContext(DbContextOptions<moodle_vsamkContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort>()
              .Property(p => p.visible)
              .HasDefaultValueSql(@"'1'");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>()
              .Property(p => p.idnumber)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>()
              .Property(p => p.format)
              .HasDefaultValueSql(@"'topics'");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>()
              .Property(p => p.showgrades)
              .HasDefaultValueSql(@"'1'");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>()
              .Property(p => p.newsitems)
              .HasDefaultValueSql(@"'1'");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>()
              .Property(p => p.visible)
              .HasDefaultValueSql(@"'1'");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>()
              .Property(p => p.visibleold)
              .HasDefaultValueSql(@"'1'");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>()
              .Property(p => p.lang)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>()
              .Property(p => p.calendartype)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>()
              .Property(p => p.theme)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group>()
              .Property(p => p.idnumber)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.auth)
              .HasDefaultValueSql(@"'manual'");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.idnumber)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.phone1)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.phone2)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.institution)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.department)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.address)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.city)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.country)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.lang)
              .HasDefaultValueSql(@"'en'");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.calendartype)
              .HasDefaultValueSql(@"'gregorian'");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.theme)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.timezone)
              .HasDefaultValueSql(@"'99'");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.lastip)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.secret)
              .HasDefaultValueSql(@"''");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.descriptionformat)
              .HasDefaultValueSql(@"'1'");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.mailformat)
              .HasDefaultValueSql(@"'1'");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.maildisplay)
              .HasDefaultValueSql(@"'2'");

            builder.Entity<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>()
              .Property(p => p.autosubscribe)
              .HasDefaultValueSql(@"'1'");
            this.OnModelBuilding(builder);
        }

        public DbSet<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort> mdlou_cohorts { get; set; }

        public DbSet<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course> mdlou_courses { get; set; }

        public DbSet<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group> mdlou_groups { get; set; }

        public DbSet<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user> mdlou_users { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }
    }
}