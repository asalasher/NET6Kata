namespace NET6Kata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMemoryCache(memoryCacheOptions =>
            {
                memoryCacheOptions.SizeLimit = 1024;
                memoryCacheOptions.ExpirationScanFrequency = TimeSpan.FromMinutes(1);
            });

            //builder.Services.AddScoped<IPInterfaceProperties, ImplementacionQueToque>();

            builder.Services.AddControllers(); // addd scope, add singleton, etc
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}