namespace MovieApp.Contexts
{
    using MovieApp.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LocalDatabase : DbContext
    {
        // Your context has been configured to use a 'LocalDatabase' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MovieApp.Contexts.LocalDatabase' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LocalDatabase' 
        // connection string in the application configuration file.
        public LocalDatabase()
            : base("name=LocalDatabase")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }

}