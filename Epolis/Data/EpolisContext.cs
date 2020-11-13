using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Epolis.Models;

public class EpolisContext : DbContext
{
    public EpolisContext(DbContextOptions<EpolisContext> options)
        : base(options)
    {
    }

    public DbSet<Epolis.Models.Mbroker> Mbroker { get; set; }

    public DbSet<Epolis.Models.Mperusahaanasuransi> Mperusahaanasuransi { get; set; }

    public DbSet<Epolis.Models.Mjenisasuransi> Mjenisasuransi { get; set; }

    public DbSet<Epolis.Models.Mokupasi> Mokupasi { get; set; }
    public DbSet<Epolis.Models.Msysparam> Msysparam { get; set; }
    public DbSet<Epolis.Models.Mperluasan> Mperluasan { get; set; }
    public DbSet<Epolis.Models.Mpertanggungan> Mpertanggungan { get; set; }
    public DbSet<Epolis.Models.MuserGroup> MuserGroup { get; set; }
    public DbSet<Epolis.Models.Munit> Munit { get; set; }
    public DbSet<Epolis.Models.Tkontrakasuransi> Tkontrakasuransi { get; set; }
    public DbSet<Epolis.Models.Mmenu> Mmenu { get; set; }

    public DbSet<Epolis.Models.Mlookup> Mlookup { get; set; }
    public DbSet<Epolis.Models.Muser> Muser { get; set; }
    public DbSet<Epolis.Models.Tpenutupan> Tpenutupan { get; set; }
    public DbSet<Epolis.Models.Mcabang> Mcabang { get; set; }
    public DbSet<Epolis.Models.Tnasabah> Tnasabah { get; set; }
    public DbSet<Epolis.Models.Tpenutupandetil> Tpenutupandetil { get; set; }
    public DbSet<Epolis.Models.Tfile> Tfile { get; set; }
    public DbSet<Epolis.Models.Tpertanggungan> Tpertanggungan { get; set; }
    public DbSet<Epolis.Models.Tperluasan> Tperluasan { get; set; }
    public DbSet<Epolis.Models.Tcatatan> Tcatatan { get; set; }
    public DbSet<Epolis.Models.Toperator> Toperator { get; set; }
    public DbSet<Epolis.Models.Tbroker> Tbroker { get; set; }
}
