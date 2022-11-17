namespace Data{
    public class DiarioContext : DbContext{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySQL("server=localhost;database=nomedb;user=root;password=Katana88*");
        }
    }
}