﻿using Microsoft.EntityFrameworkCore;
using PhoneBook.Model;

namespace PhoneBook_DbLib;

public class PhoneBookContext : DbContext
{
    private readonly string _connectionString; 
    
    public DbSet<Person> Persons{ get; set; }
    public DbSet<Phone> Phones { get; set; }

    protected PhoneBookContext(string connectionString)
    {
        _connectionString = connectionString;

        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }
}