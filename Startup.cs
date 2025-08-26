using System.ComponentModel.Design.Serialization;
using Web_Api_Contable.Services.FOP;
using Web_Api_Contable.Services.SEGURIDAD;
using Web_Api_Contable.Services.SM;

namespace Web_Api_Contable
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            // configure DI for application services
            //services.AddScoped<ITramitesServices, TramitesServices>();
            //services.AddScoped<ITiposTramitesServices, TiposTramitesServices>();
            //services.AddScoped<IUsuarioServices, UsuarioServices>();
            //services.AddScoped<IAdjuntos_x_TramitesServices, Adjuntos_x_TramitesServices>();
            //services.AddScoped<ICatastroServices, CatastroServices>();
            services.AddScoped<IUsuarioServices, UsuarioServices>();
            services.AddScoped<IProveedoresService, ProveedoresService>();
            services.AddScoped<IOrdenes_pedidoService, Ordenes_pedidoService>();
            services.AddScoped<IDetalle_orden_pedidoService, Detalle_orden_pedidoService>();
            services.AddScoped<IFactura_x_orden_pedidoServices, Factura_x_orden_pedidoService>();
            services.AddScoped<IFactura_x_orden_pedidoServices, Factura_x_orden_pedidoService>();
            services.AddScoped<ISecretariasService, SecretariasServices>();
            services.AddScoped<IDireccionService, DireccionesServices>();
            services.AddScoped<IProgramasService, ProgramaService>();
            services.AddScoped<IOficinaService,OficinaService>();
            services.AddScoped<IOrdenesCompraService, Ordenes_CompraService>();
            services.AddScoped<IDetalle_orden_compraService, Detalle_orden_compraService>();
            services.AddScoped<IOrdenes_pagoService, Ordenes_pagoService>();
            ////
            ///
            services.AddScoped<ISM_Solicitud_materialService, SM_Solicitud_materialService>();
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseStaticFiles();
                app.UseStaticFiles(new StaticFileOptions()
                {
                    OnPrepareResponse = ctx =>
                    {
                        ctx.Context.Response.Headers
                           .Add("X-Copyright", "Copyright 2016 - JMA");
                    }
                });
            }

            //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taskman API V1"); });

            app.UseRouting();
            // if (env.EnvironmentName == "Development")
            // {

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            Console.WriteLine(env.EnvironmentName);
            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
