namespace B2D3
{
    using System.Data.Common;
    using System.Data.Entity;
    using Classes;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class Casusblok5Model : DbContext
    {
        // Your context has been configured to use a 'Casusblok5Model' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'B2D3.Casusblok5Model' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Casusblok5Model' 
        // connection string in the application configuration file.
        public Casusblok5Model()
            : base("name=Casusblok5Model")
        { }

        static Casusblok5Model()
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<Casusblok5Model>());
            Database.SetInitializer(new Casusblok5Initializer());
        }

        // Constructor to use on a DbConnection that is already opened
        public Casusblok5Model(DbConnection existingConnection, bool contextOwnsConnection)
      : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<AccountRole> AccountRole { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<OperationArea> OperationArea { get; set; }
        public DbSet<ProductReview> ProductReview { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        //Inheritance objects
        public DbSet<History> History { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Occasion> Occasions { get; set; }
        public DbSet<Product> Products { get; set; }

        
    }

    public class Casusblok5Initializer : DropCreateDatabaseIfModelChanges<Casusblok5Model>
    {
        protected override void Seed(Casusblok5Model dbContext)
        {
            // seed data

            base.Seed(dbContext);
        }
    }

}