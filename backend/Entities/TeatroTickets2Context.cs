using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class TeatroTickets2Context : DbContext
{
    public TeatroTickets2Context()
    {
    }

    public TeatroTickets2Context(DbContextOptions<TeatroTickets2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Performance> Performances { get; set; }

    public virtual DbSet<Performer> Performers { get; set; }

    public virtual DbSet<Play> Plays { get; set; }

    public virtual DbSet<PriceZone> PriceZones { get; set; }

    public virtual DbSet<PriceZoneSeat> PriceZoneSeats { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Row> Rows { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Theater> Theaters { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-6L6ASHP\\SQLEXPRESS;Database=TeatroTickets2;Integrated Security=True;TrustServerCertificate=True");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__CUSTOMER__B611CB9D16D63BA3");

            entity.ToTable("CUSTOMERS");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.Customers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_customer_user");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__PAYMENTS__A0D9EFA672B2B18E");

            entity.ToTable("PAYMENTS");

            entity.Property(e => e.PaymentId).HasColumnName("paymentID");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())", "DF_payment_date")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Method)
                .HasConversion(
                    v => v.HasValue ? v.Value.ToString().ToLower() : null,
                    v => v != null ? (PaymentMethod)Enum.Parse(typeof(PaymentMethod), v, true) : (PaymentMethod?)null
                )
                .HasMaxLength(20)
                .HasColumnName("method");
            entity.Property(e => e.ReservationId).HasColumnName("reservationID");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_payment_reservation");
        });

        modelBuilder.Entity<Performance>(entity =>
        {
            entity.HasKey(e => e.PerformanceId).HasName("PK__PERFORMA__AC2FDEC1B53FFC5D");

            entity.ToTable("PERFORMANCES");

            entity.Property(e => e.PerformanceId).HasColumnName("performanceID");
            entity.Property(e => e.Datetime)
                .HasColumnType("datetime")
                .HasColumnName("datetime");
            entity.Property(e => e.PlayId).HasColumnName("playID");
            entity.Property(e => e.State)
                .HasConversion(
                    v => v.ToString().ToLower(),
                    v => (PerformanceState)Enum.Parse(typeof(PerformanceState), v)
                )
                .HasMaxLength(20)
                // .HasDefaultValue("created", "DF_performance_state")
                .HasColumnName("state");

            entity.HasOne(d => d.Play).WithMany(p => p.Performances)
                .HasForeignKey(d => d.PlayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_performance_play");
        });

        modelBuilder.Entity<Performer>(entity =>
        {
            entity.HasKey(e => e.PerformerId).HasName("PK__PERFORME__90A94E6122997653");

            entity.ToTable("PERFORMERS");

            entity.Property(e => e.PerformerId).HasColumnName("performerID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Contact)
                .HasMaxLength(50)
                .HasColumnName("contact");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasConversion(
                    v => v.ToString().ToLower(),
                    v => (PerformerType)Enum.Parse(typeof(PerformerType), v)
                )
                .HasMaxLength(20)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.Performers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_performer_user");
        });

        modelBuilder.Entity<Play>(entity =>
        {
            entity.HasKey(e => e.PlayId).HasName("PK__PLAYS__A77B07D7C89B34DF");

            entity.ToTable("PLAYS");

            entity.Property(e => e.PlayId).HasColumnName("playID");
            entity.Property(e => e.Category)
                .HasConversion(
                    v => v.HasValue ? v.Value.ToString().ToLower() : null,
                    v => v != null ? (PlayCategory)Enum.Parse(typeof(PlayCategory), v, true) : (PlayCategory?)null
                )
                /*
                .HasConversion(
                    v => v.ToString(),
                    v => (PlayCategory)Enum.Parse(typeof(PlayCategory), v)
                )
                .HasConversion(
                    v => v.HasValue ? v.Value.ToString().ToLower() : null,
                    v => v != null ? (PlayCategory)Enum.Parse(typeof(PlayCategory), v) : (PlayCategory?)null
                )
                */
                .HasMaxLength(20)
                .HasColumnName("category");
            entity.Property(e => e.DateStartOnsale)
                .HasColumnType("datetime")
                .HasColumnName("dateStartOnsale");
            entity.Property(e => e.DateStartPresale)
                .HasColumnType("datetime")
                .HasColumnName("dateStartPresale");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.PerformerId).HasColumnName("performerID");
            entity.Property(e => e.PlaybillPdf)
                .HasMaxLength(200)
                .HasColumnName("playbillPDF");
            entity.Property(e => e.State)
                .HasConversion(
                    v => v.ToString().ToLower(),
                    v => (PlayState)Enum.Parse(typeof(PlayState), v)
                )
                .HasMaxLength(20)
                // .HasDefaultValue("draft", "DF_event_state")
                .HasColumnName("state");
            entity.Property(e => e.TheaterId).HasColumnName("theaterID");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.Performer).WithMany(p => p.Plays)
                .HasForeignKey(d => d.PerformerId)
                .HasConstraintName("FK_play_performer");

            entity.HasOne(d => d.Theater).WithMany(p => p.Plays)
                .HasForeignKey(d => d.TheaterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_play_theater");
        });

        modelBuilder.Entity<PriceZone>(entity =>
        {
            entity.HasKey(e => e.PriceZoneId).HasName("PK__PRICE_ZO__A89565DA7938F444");

            entity.ToTable("PRICE_ZONES");

            entity.Property(e => e.PriceZoneId).HasColumnName("priceZoneID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PerformanceId).HasColumnName("performanceID");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PricePresale)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("pricePresale");

            entity.HasOne(d => d.Performance).WithMany(p => p.PriceZones)
                .HasForeignKey(d => d.PerformanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_priceZone_performance");
        });

        modelBuilder.Entity<PriceZoneSeat>(entity =>
        {
            entity.HasKey(e => e.PriceZoneSeatId).HasName("PK__PRICE_ZO__369BC391D53FFDC9");

            entity.ToTable("PRICE_ZONE_SEATS");

            entity.Property(e => e.PriceZoneSeatId).HasColumnName("priceZoneSeatID");
            entity.Property(e => e.PriceZoneId).HasColumnName("priceZoneID");
            entity.Property(e => e.SeatId).HasColumnName("seatID");
            entity.Property(e => e.State)
                .HasConversion(
                    v => v.ToString(),
                    v => (PriceZoneSeatState)Enum.Parse(typeof(PriceZoneSeatState), v)
                )
                .HasMaxLength(10)
                // .HasDefaultValue("available", "DF_priceZoneSeat_state")
                .HasColumnName("state");

            entity.HasOne(d => d.PriceZone).WithMany(p => p.PriceZoneSeats)
                .HasForeignKey(d => d.PriceZoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_priceZoneSeat_priceZone");

            entity.HasOne(d => d.Seat).WithMany(p => p.PriceZoneSeats)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_priceZoneSeat_seat");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__RESERVAT__B14BF5A5E11DC0F4");

            entity.ToTable("RESERVATIONS");

            entity.Property(e => e.ReservationId).HasColumnName("reservationID");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())", "DF_reservation_date")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.PerformanceId).HasColumnName("performanceID");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_reservation_customer");

            entity.HasOne(d => d.Performance).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.PerformanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reservation_performance");
        });

        modelBuilder.Entity<Row>(entity =>
        {
            entity.HasKey(e => e.RowId).HasName("PK__ROWS__4B58DA60A1431F4F");

            entity.ToTable("ROWS");

            entity.Property(e => e.RowId).HasColumnName("rowID");
            entity.Property(e => e.Name)
                .HasMaxLength(2)
                .HasColumnName("name");
            entity.Property(e => e.TheaterId).HasColumnName("theaterID");

            entity.HasOne(d => d.Theater).WithMany(p => p.Rows)
                .HasForeignKey(d => d.TheaterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_row_theater");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__SCHEDULE__A532EDB4965BBBAD");

            entity.ToTable("SCHEDULES");

            entity.Property(e => e.ScheduleId).HasColumnName("scheduleID");
            entity.Property(e => e.ClosingTime).HasColumnName("closingTime");
            entity.Property(e => e.Day)
                .HasMaxLength(20)
                .HasColumnName("day");
            entity.Property(e => e.OpeningTime).HasColumnName("openingTime");
            entity.Property(e => e.TheaterId).HasColumnName("theaterID");

            entity.HasOne(d => d.Theater).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.TheaterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_theaterSchedule_theater");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PK__SEATS__BC5329CA3089C2CD");

            entity.ToTable("SEATS");

            entity.Property(e => e.SeatId).HasColumnName("seatID");
            entity.Property(e => e.Column).HasColumnName("column");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.RowId).HasColumnName("rowID");
            entity.Property(e => e.Side)
                .HasConversion(
                    v => v.ToString(),
                    v => (SeatSide)Enum.Parse(typeof(SeatSide), v)
                )
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("side");

            entity.HasOne(d => d.Row).WithMany(p => p.Seats)
                .HasForeignKey(d => d.RowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_seat_row");
        });

        modelBuilder.Entity<Theater>(entity =>
        {
            entity.HasKey(e => e.TheaterId).HasName("PK__THEATERS__C94587D50E4F61DF");

            entity.ToTable("THEATERS");

            entity.Property(e => e.TheaterId).HasColumnName("theaterID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Contact)
                .HasMaxLength(50)
                .HasColumnName("contact");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.Theaters)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_theater_user");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__TICKETS__3333C670B39A2C76");

            entity.ToTable("TICKETS");

            entity.Property(e => e.TicketId).HasColumnName("ticketID");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.PriceZoneSeatId).HasColumnName("priceZoneSeatID");
            entity.Property(e => e.ReservationId).HasColumnName("reservationID");

            entity.HasOne(d => d.PriceZoneSeat).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PriceZoneSeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ticket_priceZoneSeat");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ticket_reservation");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__USERS__CB9A1CDFAEA049C0");

            entity.ToTable("USERS");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("password");
            entity.Property(e => e.Rol)
                .HasMaxLength(10)
                .HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
