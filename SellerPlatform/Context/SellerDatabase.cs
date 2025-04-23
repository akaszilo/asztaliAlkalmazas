using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SellerPlatform.Model;
using System.Text.Json;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SellerPlatform.Context;

public partial class SellerDatabase : DbContext
{
    private static readonly HttpClient client = new HttpClient();

    private async Task AddProductAsync(Product product)
    {
        try
        {
            client.BaseAddress = new Uri("http://localhost:8000/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("products", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Termék sikeresen hozzáadva!");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Hiba történt: " + error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hiba: " + ex.Message);
        }
    }
    public SellerDatabase()
    {
    }

    public SellerDatabase(DbContextOptions<SellerDatabase> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\szilo\\Desktop\\szakdoga\\database\\sellerPlatformDatabase.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carts__3214EC078B33E438");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Carts_ToProducts");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC07C27C5B3C");

            entity.HasOne(d => d.Cart).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK_Orders_ToCart");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Orders_ToProduct");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Orders_ToUser");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC074D263526");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC072437AA50");

            entity.ToTable("User");

            entity.HasOne(d => d.Cart).WithMany(p => p.Users)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK_User_ToCart");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
