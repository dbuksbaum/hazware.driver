using System;
using System.ComponentModel.Composition;
using RunnableApplication;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Reflection;

namespace ConsoleDriver
{
  class RunnableProgram : IDisposable
  {
    #region Fields
    private CompositionContainer _container;
    #endregion

    [Import]
    public IRunnableApplication TheApp { get; set; }

    #region Constructors
    public RunnableProgram()
    {
      Compose();
    }
    ~RunnableProgram()
    {
      Dispose(false);
    }
    #endregion

    #region IDisposable Members
    public void Dispose()
    {
      Dispose(true);
    }
    #endregion

    public void Dispose(bool disposing)
    {
      if (disposing && (_container != null))
        _container.Dispose();
      _container = null;
    }

    private void Compose()
    {
      var catalog = new AggregateCatalog();

      // TODO:  first we try and get a specific assembly
      //string assemblyName = ConfigurationManager.AppSettings.Get("sourceAssembly");
      //if (!string.IsNullOrEmpty(assemblyName))
      //  catalog.Catalogs.Add(new AssemblyCatalog(Assembly.LoadFrom(assemblyName)));

      // TODO:  then we try and get all assemblies specific path
      //string pathName = ConfigurationManager.AppSettings.Get("sourcePath");
      //if(!string.IsNullOrEmpty(pathName))
      //  catalog.Catalogs.Add(new DirectoryCatalog(pathName));
      
      //  then we check all DLL's in the running directory
      catalog.Catalogs.Add(new DirectoryCatalog("."));

      _container = new CompositionContainer(catalog);
      CompositionBatch batch = new CompositionBatch();
      batch.AddPart(this);

      _container.Compose(batch);
    }
  }
}
