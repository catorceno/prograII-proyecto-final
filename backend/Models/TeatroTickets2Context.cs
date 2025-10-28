using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public partial class TeatroTickets2Context : DbContext
{
    public TeatroTickets2Context()
    {
    }

    public TeatroTickets2Context(DbContextOptions<TeatroTickets2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Butaca> Butacas { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventPriceZone> EventPriceZones { get; set; }

    public virtual DbSet<EventPriceZoneSeat> EventPriceZoneSeats { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<SeatingArea> SeatingAreas { get; set; }

    public virtual DbSet<Theater> Theaters { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-6L6ASHP\\SQLEXPRESS;Database=TeatroTickets2;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Butaca>(entity =>
        {
            entity.HasKey(e => e.ButacaId).HasName("PK__BUTACAS__EFE68EB785544FAF");

            entity.ToTable("BUTACAS");

            entity.Property(e => e.ButacaId).HasColumnName("butacaID");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Row)
                .HasMaxLength(2)
                .HasColumnName("row");
            entity.Property(e => e.SeatingAreaId).HasColumnName("seatingAreaID");
            entity.Property(e => e.State)
                .HasMaxLength(10)
                .HasColumnName("state");

            entity.HasOne(d => d.SeatingArea).WithMany(p => p.Butacas)
                .HasForeignKey(d => d.SeatingAreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_butaca_seatingArea");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__EVENTS__2DC7BD69D36EFB36");

            entity.ToTable("EVENTS");

            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.Category)
                .HasMaxLength(10)
                .HasColumnName("category");
            entity.Property(e => e.Datetime)
                .HasColumnType("datetime")
                .HasColumnName("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.PlaybillPdf)
                .HasMaxLength(255)
                .HasColumnName("playbillPDF");
            entity.Property(e => e.State)
                .HasMaxLength(10)
                .HasColumnName("state");
            entity.Property(e => e.TheaterId).HasColumnName("theaterID");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.Theater).WithMany(p => p.Events)
                .HasForeignKey(d => d.TheaterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_event_theater");
        });

        modelBuilder.Entity<EventPriceZone>(entity =>
        {
            entity.HasKey(e => e.PriceZoneId).HasName("PK__EVENT_PR__A89565DAC7110B56");

            entity.ToTable("EVENT_PRICE_ZONES");

            entity.Property(e => e.PriceZoneId).HasColumnName("priceZoneID");
            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");

            entity.HasOne(d => d.Event).WithMany(p => p.EventPriceZones)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_eventPriceZone_event");
        });

        modelBuilder.Entity<EventPriceZoneSeat>(entity =>
        {
            entity.HasKey(e => e.PriceZoneSeatId).HasName("PK__EVENT_PR__369BC391BA9553B3");

            entity.ToTable("EVENT_PRICE_ZONE_SEATS");

            entity.Property(e => e.PriceZoneSeatId).HasColumnName("priceZoneSeatID");
            entity.Property(e => e.ButacaId).HasColumnName("butacaID");
            entity.Property(e => e.PriceZoneId).HasColumnName("priceZoneID");

            entity.HasOne(d => d.Butaca).WithMany(p => p.EventPriceZoneSeats)
                .HasForeignKey(d => d.ButacaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_eventPriceZoneSeat_butaca");

            entity.HasOne(d => d.PriceZone).WithMany(p => p.EventPriceZoneSeats)
                .HasForeignKey(d => d.PriceZoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_eventPriceZoneSeat_eventPriceZone");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__PAYMENTS__A0D9EFA6823F4367");

            entity.ToTable("PAYMENTS");

            entity.Property(e => e.PaymentId).HasColumnName("paymentID");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Method)
                .HasMaxLength(10)
                .HasColumnName("method");
            entity.Property(e => e.ReservationId).HasColumnName("reservationID");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_payment_reservation");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__RESERVAT__B14BF5A5942CD557");

            entity.ToTable("RESERVATIONS");

            entity.Property(e => e.ReservationId).HasColumnName("reservationID");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Event).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reservation_event");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_reservation_user");
        });

        modelBuilder.Entity<SeatingArea>(entity =>
        {
            entity.HasKey(e => e.SeatingAreaId).HasName("PK__SEATING___E587F3CE178FD12F");

            entity.ToTable("SEATING_AREAS");

            entity.Property(e => e.SeatingAreaId).HasColumnName("seatingAreaID");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.TheaterId).HasColumnName("theaterID");

            entity.HasOne(d => d.Theater).WithMany(p => p.SeatingAreas)
                .HasForeignKey(d => d.TheaterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_seatingArea_theater");
        });

        modelBuilder.Entity<Theater>(entity =>
        {
            entity.HasKey(e => e.TheaterId).HasName("PK__THEATERS__C94587D5EE09D46C");

            entity.ToTable("THEATERS");

            entity.Property(e => e.TheaterId).HasColumnName("theaterID");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Direction)
                .HasMaxLength(100)
                .HasColumnName("direction");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.Theaters)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_theater_user");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__TICKETS__3333C6703BE6582B");

            entity.ToTable("TICKETS");

            entity.Property(e => e.TicketId).HasColumnName("ticketID");
            entity.Property(e => e.ButacaId).HasColumnName("butacaID");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ReservationId).HasColumnName("reservationID");

            entity.HasOne(d => d.Butaca).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ButacaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tickets_butaca");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tickets_reservation");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__USERS__CB9A1CDF301D8ED1");

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
